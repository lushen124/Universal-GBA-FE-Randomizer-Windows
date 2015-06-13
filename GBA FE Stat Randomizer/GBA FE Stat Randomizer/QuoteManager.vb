' The format for this is a bit different depending on the game, so we'll have to hard
' code some stuff here.

Public Class QuoteManager

    Dim FE6DeathQuoteAddressPointer As Integer = &H6B7FC
    Dim FE6DeathQuoteDefaultAddress As Integer = &H666598
    Dim FE6DeathQuoteEntrySize As Integer = 16
    Dim FE6DeathQuoteEntryCount As Integer = 108

    Private Class FE6DeathQuoteEntry
        Property characterID As Byte        ' offset 0, 1 byte
        Property chapter As Byte            ' offset 1, 1 byte
        Property textValue As UShort        ' offset 4, 2 bytes
        Property eventNumber As Byte        ' offset 8, 1 byte
        Property textValue2 As UShort       ' offset 12, 2 bytes
    End Class

    Property gameType As Utilities.GameType

    Private Property entries As ArrayList
    Private Property originalIdList As ArrayList
    Private Property realAddress As Integer

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
            End If
        End If

    End Sub

End Class
