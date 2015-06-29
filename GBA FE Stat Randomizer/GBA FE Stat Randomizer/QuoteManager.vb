' The format for this is a bit different depending on the game, so we'll have to hard
' code some stuff here.

Public Class QuoteManager

    Dim FE6DeathQuoteAddressPointer As Integer = &H6B7FC
    Dim FE6DeathQuoteDefaultAddress As Integer = &H666598
    Dim FE6DeathQuoteEntrySize As Integer = 16
    Dim FE6DeathQuoteEntryCount As Integer = 108

    Dim FE6DeathQuoteAllChaptersValue As Byte = &H2D

    ' FE7 has two types (wtf)
    Dim FE7DeathQuote1AddressPointer As Integer = &H7955C
    Dim FE7DeathQuote1DefaultAddress As Integer = &HC9F16C
    Dim FE7DeathQuote1EntrySize As Integer = 12
    Dim FE7DeathQuote1EntryCount = 30

    Dim FE7DeathQuote2AddressPointer As Integer = &H79550
    Dim FE7DeathQuote2DefaultAddress As Integer = &HC9F2EC
    Dim FE7DeathQuote2EntrySize As Integer = 16
    Dim FE7DeathQuote2EntryCount As Integer = 109

    Dim FE7DeathQuoteAllChaptersValue As Byte = &H43

    Dim FE8DeathQuoteAddressPointer As Integer = &H8472C
    Dim FE8DeathQuoteDefaultAddress As Integer = &H9ECD4C
    Dim FE8DeathQuoteEntrySize As Integer = 12
    Dim FE8DeathQuoteEntryCount As Integer = 79

    Dim FE8DeathQuoteAllChaptersValue As Byte = &HFF

    Private Class FE6DeathQuoteEntry
        Property characterID As Byte        ' offset 0, 1 byte
        Property chapter As Byte            ' offset 1, 1 byte
        Property textValue As UShort        ' offset 4, 2 bytes
        Property eventNumber As Byte        ' offset 8, 1 byte
        Property textValue2 As UShort       ' offset 12, 2 bytes
    End Class

    Private Class FE7DeathQuote1Entry
        Property characterID As Byte                ' offset 0, 1 byte
        Property chapter As Byte                    ' offset 1, 1 byte
        Property deathEventAddress As UInteger      ' offset 4, 4 bytes
        Property triggerID As Byte                  ' offset 8, 1 byte

        Property proposedTriggerID As Byte
    End Class

    Private Class FE7DeathQuote2Entry
        Property characterID As Byte                ' offset 0, 1 byte
        Property chapter As Byte                    ' offset 1, 1 byte
        Property textAddress As UShort              ' offset 4, 2 bytes
        Property deathEventAddress As UInteger      ' offset 8, 4 bytes
        Property triggerID As Byte                  ' offset 12, 1 byte

        Property proposedTriggerID As Byte
    End Class

    Private Class FE8DeathQuoteEntry
        Property characterID As Byte            ' offset 0, 1 byte
        Property chapter As Byte                ' offset 3, 1 byte
        Property eventID As Byte                ' offset 4, 1 byte
        Property textID As UShort               ' offset 6, 2 bytes
    End Class

    Property gameType As Utilities.GameType

    Private Property entries As ArrayList
    Private Property originalIdList As ArrayList
    Private Property realAddress As Integer

    Private Property type2Entries As ArrayList
    Private Property type2OriginalIdList As ArrayList
    Private Property type2RealAddress As Integer

    Public Sub New(ByVal type As Utilities.GameType, ByRef filePtr As IO.FileStream)
        gameType = type

        If type = Utilities.GameType.GameTypeFE6 Then
            filePtr.Seek(FE6DeathQuoteAddressPointer, IO.SeekOrigin.Begin)
            Dim tableOffset As Integer = Utilities.ReadWord(filePtr, True)
            Dim repointedTable As Boolean = False
            If tableOffset <> FE6DeathQuoteDefaultAddress Then
                MsgBox("Death Quotes Table Offset has been updated. Death Quotes Table may have been repointed." + vbCrLf _
                       & "If this is a hacked game, not all death quotes may be updated consistently.", MsgBoxStyle.OkOnly, "Notice")
                repointedTable = True
            End If

            realAddress = tableOffset
            filePtr.Seek(tableOffset, IO.SeekOrigin.Begin)

            entries = New ArrayList()
            originalIdList = New ArrayList()

            For i As Integer = 1 To FE6DeathQuoteEntryCount
                Dim entry As FE6DeathQuoteEntry = New FE6DeathQuoteEntry()
                Dim entryStartPosition As Integer = filePtr.Position
                entry.characterID = filePtr.ReadByte()
                entry.chapter = filePtr.ReadByte()

                filePtr.Seek(entryStartPosition + 4, IO.SeekOrigin.Begin)
                entry.textValue = Utilities.ReadHalfWord(filePtr)

                filePtr.Seek(entryStartPosition + 8, IO.SeekOrigin.Begin)
                entry.eventNumber = filePtr.ReadByte()

                filePtr.Seek(entryStartPosition + 12, IO.SeekOrigin.Begin)
                entry.textValue2 = Utilities.ReadHalfWord(filePtr)

                entries.Add(entry)
                originalIdList.Add(entry.characterID)

                filePtr.Seek(entryStartPosition + FE6DeathQuoteEntrySize, IO.SeekOrigin.Begin)
            Next
        ElseIf type = Utilities.GameType.GameTypeFE7 Then
            ' FE7 uses two different sets, for whatever reason. Read both of them.
            filePtr.Seek(FE7DeathQuote1AddressPointer, IO.SeekOrigin.Begin)
            Dim tableOffset As Integer = Utilities.ReadWord(filePtr, True)
            Dim repointedTable As Boolean = False
            If tableOffset <> FE7DeathQuote1DefaultAddress Then
                MsgBox("Death Quotes Table (1) has been updated. Death Quotes Table may have been repointed." + vbCrLf _
                       & "If this is a hacked game, not all death quotes may be updated consistently.", MsgBoxStyle.OkOnly, "Notice")
                repointedTable = True
            End If

            realAddress = tableOffset
            filePtr.Seek(tableOffset, IO.SeekOrigin.Begin)

            entries = New ArrayList()
            originalIdList = New ArrayList()

            For i As Integer = 1 To FE7DeathQuote1EntryCount
                Dim entry As FE7DeathQuote1Entry = New FE7DeathQuote1Entry()
                Dim entryStartPosition As Integer = filePtr.Position
                entry.characterID = filePtr.ReadByte()
                entry.chapter = filePtr.ReadByte()

                filePtr.Seek(entryStartPosition + 4, IO.SeekOrigin.Begin)
                entry.deathEventAddress = Utilities.ReadWord(filePtr, False)

                filePtr.Seek(entryStartPosition + 8, IO.SeekOrigin.Begin)
                entry.triggerID = filePtr.ReadByte()
                entry.proposedTriggerID = entry.triggerID

                entries.Add(entry)
                originalIdList.Add(entry.characterID)

                filePtr.Seek(entryStartPosition + FE7DeathQuote1EntrySize, IO.SeekOrigin.Begin)
            Next

            filePtr.Seek(FE7DeathQuote2AddressPointer, IO.SeekOrigin.Begin)
            tableOffset = Utilities.ReadWord(filePtr, True)
            repointedTable = False
            If tableOffset <> FE7DeathQuote2DefaultAddress Then
                MsgBox("Death Quotes Table (2) has been updated. Death Quotes Table may have been repointed." + vbCrLf _
                       & "If this is a hacked game, not all death quotes may be updated consistently.", MsgBoxStyle.OkOnly, "Notice")
                repointedTable = True
            End If

            type2RealAddress = tableOffset
            filePtr.Seek(tableOffset, IO.SeekOrigin.Begin)

            type2Entries = New ArrayList()
            type2OriginalIdList = New ArrayList()

            For i As Integer = 1 To FE7DeathQuote2EntryCount
                Dim entry As FE7DeathQuote2Entry = New FE7DeathQuote2Entry()
                Dim entryStartPosition As Integer = filePtr.Position
                entry.characterID = filePtr.ReadByte()
                entry.chapter = filePtr.ReadByte()

                filePtr.Seek(entryStartPosition + 4, IO.SeekOrigin.Begin)
                entry.textAddress = Utilities.ReadHalfWord(filePtr)

                filePtr.Seek(entryStartPosition + 8, IO.SeekOrigin.Begin)
                entry.deathEventAddress = Utilities.ReadWord(filePtr, False)

                filePtr.Seek(entryStartPosition + 12, IO.SeekOrigin.Begin)
                entry.triggerID = filePtr.ReadByte()
                entry.proposedTriggerID = entry.triggerID

                type2Entries.Add(entry)
                type2OriginalIdList.Add(entry.characterID)

                filePtr.Seek(entryStartPosition + FE7DeathQuote2EntrySize, IO.SeekOrigin.Begin)
            Next
        Else
            filePtr.Seek(FE8DeathQuoteAddressPointer, IO.SeekOrigin.Begin)
            Dim tableOffset As Integer = Utilities.ReadWord(filePtr, True)
            Dim repointedTable As Boolean = False

            If tableOffset <> FE8DeathQuoteDefaultAddress Then
                MsgBox("Death Quotes Table has been updated. Death Quotes Table may have been repointed." + vbCrLf _
                       & "If this is a hacked game, not all death quotes may be updated consistently.", MsgBoxStyle.OkOnly, "Notice")
                repointedTable = True
            End If

            realAddress = tableOffset
            filePtr.Seek(tableOffset, IO.SeekOrigin.Begin)

            entries = New ArrayList()
            originalIdList = New ArrayList()

            For i As Integer = 1 To FE8DeathQuoteEntryCount
                Dim entry As FE8DeathQuoteEntry = New FE8DeathQuoteEntry()
                Dim entryStartPosition As Integer = filePtr.Position
                entry.characterID = filePtr.ReadByte()

                filePtr.Seek(entryStartPosition + 3, IO.SeekOrigin.Begin)
                entry.chapter = filePtr.ReadByte()

                entry.eventID = filePtr.ReadByte()

                filePtr.Seek(entryStartPosition + 6, IO.SeekOrigin.Begin)
                entry.textID = Utilities.ReadHalfWord(filePtr)

                entries.Add(entry)
                originalIdList.Add(entry.textID)

                filePtr.Seek(entryStartPosition + FE8DeathQuoteEntrySize, IO.SeekOrigin.Begin)
            Next
        End If
    End Sub

    Public Sub updateCharacterIDs(ByVal originalCharacterID As Byte, ByVal newCharacterID As Byte)
        ' 0 isn't valid in any game. We shouldn't be changing to and from 0.
        If originalCharacterID <> 0 And newCharacterID <> 0 Then
            If gameType = Utilities.GameType.GameTypeFE6 Then
                For i As Integer = 0 To entries.Count - 1
                    If originalIdList.Item(i) = originalCharacterID Then
                        Dim entry As FE6DeathQuoteEntry = entries.Item(i)
                        entry.characterID = newCharacterID
                    End If
                Next
            ElseIf gameType = Utilities.GameType.GameTypeFE7 Then
                For i As Integer = 0 To entries.Count - 1
                    If originalIdList.Item(i) = originalCharacterID Then
                        Dim entry As FE7DeathQuote1Entry = entries.Item(i)
                        entry.characterID = newCharacterID
                    End If
                Next
                For i As Integer = 0 To type2Entries.Count - 1
                    If type2OriginalIdList.Item(i) = originalCharacterID Then
                        Dim entry As FE7DeathQuote2Entry = type2Entries.Item(i)
                        entry.characterID = newCharacterID
                    End If
                Next
            Else
                ' It's far easier to just swap text IDs for FE8.
                ' The variable names are kind of flipped due to FE6 and FE7. The first paramter is the replacement. The second paramter is who he's replacing.
                Dim targetTextID As UShort = 0
                ' Find the new character's original text ID.
                For i As Integer = 0 To entries.Count - 1
                    Dim entry As FE8DeathQuoteEntry = entries.Item(i)
                    If entry.characterID = originalCharacterID And entry.chapter = FE8DeathQuoteAllChaptersValue Then
                        targetTextID = originalIdList.Item(i)
                        Exit For
                    End If
                Next

                If targetTextID <> 0 Then
                    ' Paste it over the old character's text ID.
                    For i As Integer = 0 To entries.Count - 1
                        Dim entry As FE8DeathQuoteEntry = entries.Item(i)
                        If entry.characterID = newCharacterID And entry.chapter = FE8DeathQuoteAllChaptersValue Then
                            entry.textID = targetTextID
                            Exit For
                        End If
                    Next
                End If
            End If

        End If
    End Sub

    Public Sub transferTriggerIDs(ByVal fromCharacter As Byte, ByVal toCharacter As Byte)
        If fromCharacter <> 0 And toCharacter <> 0 Then
            ' FE7 does things a bit differently. In addition to the characterID,
            ' some characters have event IDs that trigger when they die.
            ' We need to preserve these and transfer these to the new characters
            ' if we swap IDs.
            ' The most relevant example is lords, which trigger event 0x65 (the game over event)
            ' which has to be triggered by whoever the new lord is. At the same time,
            ' a lord that no longer is a lord, shouldn't be triggering 0x65.
            If gameType = Utilities.GameType.GameTypeFE7 Then
                Dim fromTrigger As Byte = 0
                For i As Integer = 0 To entries.Count - 1
                    If originalIdList.Item(i) = fromCharacter Then
                        Dim entry As FE7DeathQuote1Entry = entries.Item(i)
                        If entry.chapter = FE7DeathQuoteAllChaptersValue Then
                            fromTrigger = entry.triggerID
                            Exit For
                        End If
                    End If
                Next

                If fromTrigger = 0 Then
                    For i As Integer = 0 To type2Entries.Count - 1
                        If type2OriginalIdList.Item(i) = fromCharacter Then
                            Dim entry As FE7DeathQuote2Entry = type2Entries.Item(i)
                            If entry.chapter = FE7DeathQuoteAllChaptersValue Then
                                fromTrigger = entry.triggerID
                                Exit For
                            End If
                        End If
                    Next
                End If

                For i As Integer = 0 To entries.Count - 1
                    If originalIdList.Item(i) = toCharacter Then
                        Dim entry As FE7DeathQuote1Entry = entries.Item(i)
                        If entry.chapter = FE7DeathQuoteAllChaptersValue Then
                            entry.proposedTriggerID = fromTrigger
                            Exit For
                        End If
                    End If
                Next

                For i As Integer = 0 To type2Entries.Count - 1
                    If type2OriginalIdList.Item(i) = toCharacter Then
                        Dim entry As FE7DeathQuote2Entry = type2Entries.Item(i)
                        If entry.chapter = FE7DeathQuoteAllChaptersValue Then
                            entry.proposedTriggerID = fromTrigger
                            Exit For
                        End If
                    End If
                Next

            End If
        End If
    End Sub

    Public Sub commitChanges(ByRef filePtr As IO.FileStream)
        If Not IsNothing(filePtr) Then
            originalIdList.Clear()
            If gameType = Utilities.GameType.GameTypeFE6 And realAddress <> 0 Then
                filePtr.Seek(realAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To entries.Count - 1

                    DebugLogger.logMessage("[QuoteManager] - Wrote Address 0x" & Hex(filePtr.Position) & " to 0x" & Hex(filePtr.Position + FE6DeathQuoteEntrySize))

                    Dim entry As FE6DeathQuoteEntry = entries.Item(i)
                    Dim entryStartPosition As Integer = filePtr.Position
                    filePtr.WriteByte(entry.characterID)
                    ' Don't write anything else, because we shouldn't be changing those.

                    filePtr.Seek(entryStartPosition + FE6DeathQuoteEntrySize, IO.SeekOrigin.Begin)

                    ' Update the character ID list if we've comitted.
                    originalIdList.Add(entry.characterID)
                Next
            ElseIf gameType = Utilities.GameType.GameTypeFE7 Then
                If realAddress <> 0 Then
                    originalIdList.Clear()
                    filePtr.Seek(realAddress, IO.SeekOrigin.Begin)
                    For i As Integer = 0 To entries.Count - 1

                        DebugLogger.logMessage("[QuoteManager] - Wrote Address 0x" & Hex(filePtr.Position) & " to 0x" & Hex(filePtr.Position + FE7DeathQuote1EntrySize))

                        Dim entry As FE7DeathQuote1Entry = entries.Item(i)
                        Dim entryStartPosition As Integer = filePtr.Position
                        filePtr.WriteByte(entry.characterID)

                        ' FE7 could modify triggers. We need to write them.
                        filePtr.Seek(entryStartPosition + 8, IO.SeekOrigin.Begin)
                        filePtr.WriteByte(entry.proposedTriggerID)
                        entry.triggerID = entry.proposedTriggerID

                        filePtr.Seek(entryStartPosition + FE7DeathQuote1EntrySize, IO.SeekOrigin.Begin)

                        originalIdList.Add(entry.characterID)
                    Next
                End If
                If type2RealAddress <> 0 Then
                    type2OriginalIdList.Clear()
                    filePtr.Seek(type2RealAddress, IO.SeekOrigin.Begin)
                    For i As Integer = 0 To type2Entries.Count - 1

                        DebugLogger.logMessage("[QuoteManager] - Wrote Address 0x" & Hex(filePtr.Position) & " to 0x" & Hex(filePtr.Position + FE7DeathQuote2EntrySize))

                        Dim entry As FE7DeathQuote2Entry = type2Entries.Item(i)
                        Dim entryStartPosition As Integer = filePtr.Position
                        filePtr.WriteByte(entry.characterID)

                        ' FE7 could modify triggers. We need to write them.
                        filePtr.Seek(entryStartPosition + 12, IO.SeekOrigin.Begin)
                        filePtr.WriteByte(entry.proposedTriggerID)
                        entry.triggerID = entry.proposedTriggerID

                        filePtr.Seek(entryStartPosition + FE7DeathQuote2EntrySize, IO.SeekOrigin.Begin)

                        type2OriginalIdList.Add(entry.characterID)
                    Next
                End If
            Else
                filePtr.Seek(realAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To entries.Count - 1

                    DebugLogger.logMessage("[QuoteManager] - Wrote Address 0x" & Hex(filePtr.Position) & " to 0x" & Hex(filePtr.Position + FE8DeathQuoteEntrySize))

                    Dim entry As FE8DeathQuoteEntry = entries.Item(i)
                    Dim entryStartPosition As Integer = filePtr.Position

                    filePtr.Seek(entryStartPosition + 6, IO.SeekOrigin.Begin)
                    Utilities.WriteHalfWord(filePtr, entry.textID)
                    ' Don't write anything else, because we shouldn't be changing those.

                    filePtr.Seek(entryStartPosition + FE8DeathQuoteEntrySize, IO.SeekOrigin.Begin)

                    ' Update the character ID list if we've comitted.
                    originalIdList.Add(entry.textID)
                Next
            End If
        End If

    End Sub

End Class
