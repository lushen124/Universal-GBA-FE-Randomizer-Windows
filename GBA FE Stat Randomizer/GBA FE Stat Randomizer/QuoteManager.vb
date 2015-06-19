' The format for this is a bit different depending on the game, so we'll have to hard
' code some stuff here.

Public Class QuoteManager

    Dim FE6DeathQuoteAddressPointer As Integer = &H6B7FC
    Dim FE6DeathQuoteDefaultAddress As Integer = &H666598
    Dim FE6DeathQuoteEntrySize As Integer = 16
    Dim FE6DeathQuoteEntryCount As Integer = 108

    ' FE7 has two types (wtf)
    Dim FE7DeathQuote1AddressPointer As Integer = &H7955C
    Dim FE7DeathQuote1DefaultAddress As Integer = &HC9F16C
    Dim FE7DeathQuote1EntrySize As Integer = 12
    Dim FE7DeathQuote1EntryCount = 30

    Dim FE7DeathQuote2AddressPointer As Integer = &H79550
    Dim FE7DeathQuote2DefaultAddress As Integer = &HC9F2EC
    Dim FE7DeathQuote2EntrySize As Integer = 16
    Dim FE7DeathQuote2EntryCount As Integer = 109

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
    End Class

    Private Class FE7DeathQuote2Entry
        Property characterID As Byte                ' offset 0, 1 byte
        Property chapter As Byte                    ' offset 1, 1 byte
        Property textAddress As UShort              ' offset 4, 2 bytes
        Property deathEventAddress As UInteger      ' offset 8, 4 bytes
        Property triggerID As Byte                  ' offset 12, 1 byte
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

                type2Entries.Add(entry)
                type2OriginalIdList.Add(entry.characterID)

                filePtr.Seek(entryStartPosition + FE7DeathQuote2EntrySize, IO.SeekOrigin.Begin)
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
            End If
        End If
    End Sub

    Public Sub commitChanges(ByRef filePtr As IO.FileStream)
        If Not IsNothing(filePtr) Then
            originalIdList.Clear()
            If gameType = Utilities.GameType.GameTypeFE6 And realAddress <> 0 Then
                filePtr.Seek(realAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To entries.Count - 1
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
                        Dim entry As FE7DeathQuote1Entry = entries.Item(i)
                        Dim entryStartPosition As Integer = filePtr.Position
                        filePtr.WriteByte(entry.characterID)

                        filePtr.Seek(entryStartPosition + FE7DeathQuote1EntrySize, IO.SeekOrigin.Begin)

                        originalIdList.Add(entry.characterID)
                    Next
                End If
                If type2RealAddress <> 0 Then
                    type2OriginalIdList.Clear()
                    filePtr.Seek(type2RealAddress, IO.SeekOrigin.Begin)
                    For i As Integer = 0 To type2Entries.Count - 1
                        Dim entry As FE7DeathQuote2Entry = type2Entries.Item(i)
                        Dim entryStartPosition As Integer = filePtr.Position
                        filePtr.WriteByte(entry.characterID)

                        filePtr.Seek(entryStartPosition + FE7DeathQuote2EntrySize, IO.SeekOrigin.Begin)

                        type2OriginalIdList.Add(entry.characterID)
                    Next
                End If
            End If
        End If

    End Sub

End Class
