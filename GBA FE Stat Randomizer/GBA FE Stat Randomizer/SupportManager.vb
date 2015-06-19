Public Class SupportManager

    Dim FE6SupportCompatibilityAddressPointer As Integer = &H6076FC
    Dim FE6SupportCompatibilityDefaultAddress As Integer = &H662098
    Dim FE6SupportCompatibilityEntrySize As Integer = 32
    Dim FE6SupportCompatibilityEntryCount As Integer = 53
    Dim FE6SupportConversationAddressPointer As Integer = &H6AFE0
    Dim FE6SupportConversationDefaultAddress As Integer = &H666CF8
    Dim FE6SupportConversationEntrySize As Integer = 16
    Dim FE6SupportConversationEntryCount As Integer = 143

    Dim FE7SupportCompatibilityAddressPointer As Integer = &HBDCE78
    Dim FE7SupportCompatibilityDefaultAddress As Integer = &HC98B18
    Dim FE7SupportCompatibilityEntrySize As Integer = 24
    Dim FE7SupportCompatibilityEntryCount As Integer = 48
    Dim FE7SupportConversationAddressPointer As Integer = &H78A94
    Dim FE7SupportConversationDefaultAddress As Integer = &HC9F9F4
    Dim FE7SupportConversationEntrySize As Integer = 20
    Dim FE7SupportConversationEntryCount As Integer = 115

    Private Class FE6SupportCompatibilityEntry
        Property supportCount As Byte           ' offset 30, 1 byte

        Property supporterIDs As ArrayList      ' offset 0 - 9, 1 byte per supporter
        Property startingPoints As ArrayList    ' offset 10 - 19, 1 byte per supporter
        Property growthRates As ArrayList        ' offset 20 - 29, 1 byte per supporter

        ' This acts as the area to write changes before committing.
        Property proposedSupporterIDs As ArrayList
        Property proposedStartingPoints As ArrayList
        Property proposedGrowthRates As ArrayList
    End Class

    Private Class FE6SupportConversationEntry
        Property character1 As Byte         ' offset 0, 1 byte
        Property character2 As Byte         ' offset 1, 1 byte

        Property cConversation As UShort    ' offset 4, 2 bytes
        Property bConversation As UShort    ' offset 8, 2 bytes
        Property aConversation As UShort    ' offset 12, 2 bytes

        ' Staging area before commit
        Property proposedCharacter1 As Byte
        Property proposedCharacter2 As Byte
    End Class

    Private Class FE7SupportCompatibilityEntry
        Property supportCount As Byte               ' offset 21, 1 byte

        Property supporterIDs As ArrayList          ' offset 0 - 6, 1 byte per supporter
        Property startingPoints As ArrayList        ' offset 7 - 13, 1 byte per supporter
        Property growthRates As ArrayList           ' offset 14 - 20, 1 byte per supporter

        Property proposedSupporterIDs As ArrayList
        Property proposedStartingPoints As ArrayList
        Property proposedGrowthRates As ArrayList
    End Class

    Private Class FE7SupportConversationEntry
        Property character1 As Byte             ' offset 0, 1 byte
        Property character2 As Byte             ' offset 1, 1 byte

        Property cConversation As UShort        ' offset 4, 2 bytes
        Property bConversation As UShort        ' offset 8, 2 bytes
        Property aConversation As UShort        ' offset 12, 2 bytes

        Property proposedCharacter1 As Byte
        Property proposedCharacter2 As Byte
    End Class

    Property gameType As Utilities.GameType

    Private Property entries As ArrayList
    Private Property realAddress As Integer

    Private Property conversationEntries As ArrayList
    Private Property realConversationAddress As Integer

    Public Sub New(ByVal type As Utilities.GameType, ByRef filePtr As IO.FileStream)
        gameType = type

        If type = Utilities.GameType.GameTypeFE6 Then
            filePtr.Seek(FE6SupportCompatibilityAddressPointer, IO.SeekOrigin.Begin)
            Dim tableOffset As Integer = Utilities.ReadWord(filePtr, True)
            Dim repointedTable As Boolean = False
            If tableOffset <> FE6SupportCompatibilityDefaultAddress Then
                MsgBox("Support Compatibility Table Offset has been updated. Support Compatibility Table may have been repointed." + vbCrLf _
                       & "If this is a hacked game, not all supports may be properly remapped.", MsgBoxStyle.OkOnly, "Notice")
                repointedTable = True
            End If

            realAddress = tableOffset
            filePtr.Seek(tableOffset, IO.SeekOrigin.Begin)

            entries = New ArrayList()

            For i As Integer = 1 To FE6SupportCompatibilityEntryCount
                Dim entry As FE6SupportCompatibilityEntry = New FE6SupportCompatibilityEntry()
                Dim entryStartPosition As Integer = filePtr.Position

                filePtr.Seek(entryStartPosition + 30, IO.SeekOrigin.Begin)
                entry.supportCount = filePtr.ReadByte()

                filePtr.Seek(entryStartPosition, IO.SeekOrigin.Begin)
                entry.supporterIDs = New ArrayList()
                entry.proposedSupporterIDs = New ArrayList()
                entry.startingPoints = New ArrayList()
                entry.proposedStartingPoints = New ArrayList()
                entry.growthRates = New ArrayList()
                entry.proposedGrowthRates = New ArrayList()

                For j As Integer = 1 To 10
                    Dim supporterID As Byte = filePtr.ReadByte()
                    entry.supporterIDs.Add(supporterID)
                    entry.proposedSupporterIDs.Add(supporterID)

                    filePtr.Seek(9, IO.SeekOrigin.Current)
                    Dim startingPoints As Byte = filePtr.ReadByte()
                    entry.startingPoints.Add(startingPoints)
                    entry.proposedStartingPoints.Add(startingPoints)

                    filePtr.Seek(9, IO.SeekOrigin.Current)
                    Dim growthRate As Byte = filePtr.ReadByte()
                    entry.growthRates.Add(growthRate)
                    entry.proposedGrowthRates.Add(growthRate)

                    filePtr.Seek(-20, IO.SeekOrigin.Current)
                Next

                entries.Add(entry)
                filePtr.Seek(entryStartPosition + FE6SupportCompatibilityEntrySize, IO.SeekOrigin.Begin)
            Next

            filePtr.Seek(FE6SupportConversationAddressPointer, IO.SeekOrigin.Begin)
            tableOffset = Utilities.ReadWord(filePtr, True)
            repointedTable = False
            If tableOffset <> FE6SupportConversationDefaultAddress Then
                MsgBox("Support Conversation Table Offset has been updated. Support Conversation Table may have been repointed." + vbCrLf _
                       & "If this is a hacked game, not all supports may have conversations (or correct conversations).", MsgBoxStyle.OkOnly, "Notice")
                repointedTable = True
            End If

            realConversationAddress = tableOffset
            filePtr.Seek(tableOffset, IO.SeekOrigin.Begin)

            conversationEntries = New ArrayList()

            For i As Integer = 1 To FE6SupportConversationEntryCount
                Dim entry As FE6SupportConversationEntry = New FE6SupportConversationEntry()
                Dim entryStartPosition As Integer = filePtr.Position

                entry.character1 = filePtr.ReadByte()
                entry.character2 = filePtr.ReadByte()

                entry.proposedCharacter1 = entry.character1
                entry.proposedCharacter2 = entry.character2

                filePtr.Seek(entryStartPosition + 4, IO.SeekOrigin.Begin)
                entry.cConversation = Utilities.ReadHalfWord(filePtr)

                filePtr.Seek(entryStartPosition + 8, IO.SeekOrigin.Begin)
                entry.bConversation = Utilities.ReadHalfWord(filePtr)

                filePtr.Seek(entryStartPosition + 12, IO.SeekOrigin.Begin)
                entry.aConversation = Utilities.ReadHalfWord(filePtr)

                conversationEntries.Add(entry)
                filePtr.Seek(entryStartPosition + FE6SupportConversationEntrySize, IO.SeekOrigin.Begin)
            Next
        ElseIf type = Utilities.GameType.GameTypeFE7 Then
            filePtr.Seek(FE7SupportCompatibilityAddressPointer, IO.SeekOrigin.Begin)
            Dim tableOffset As Integer = Utilities.ReadWord(filePtr, True)
            Dim repointedTable As Boolean = False
            If tableOffset <> FE7SupportCompatibilityDefaultAddress Then
                MsgBox("Support Compatibility Table Offset has been updated. Support Compatibility Table may have been repointed." + vbCrLf _
                       & "If this is a hacked game, not all supports may be properly remapped.", MsgBoxStyle.OkOnly, "Notice")
                repointedTable = True
            End If

            realAddress = tableOffset
            filePtr.Seek(tableOffset, IO.SeekOrigin.Begin)

            entries = New ArrayList()

            For i As Integer = 1 To FE7SupportCompatibilityEntryCount
                Dim entry As FE7SupportCompatibilityEntry = New FE7SupportCompatibilityEntry()
                Dim entryStartPosition As Integer = filePtr.Position

                filePtr.Seek(entryStartPosition + 21, IO.SeekOrigin.Begin)
                entry.supportCount = filePtr.ReadByte()

                filePtr.Seek(entryStartPosition, IO.SeekOrigin.Begin)
                entry.supporterIDs = New ArrayList()
                entry.proposedSupporterIDs = New ArrayList()
                entry.startingPoints = New ArrayList()
                entry.proposedStartingPoints = New ArrayList()
                entry.growthRates = New ArrayList()
                entry.proposedGrowthRates = New ArrayList()

                For j As Integer = 1 To 7
                    Dim supporterID As Byte = filePtr.ReadByte()
                    entry.supporterIDs.Add(supporterID)
                    entry.proposedSupporterIDs.Add(supporterID)

                    filePtr.Seek(6, IO.SeekOrigin.Current)
                    Dim startingPoints As Byte = filePtr.ReadByte()
                    entry.startingPoints.Add(startingPoints)
                    entry.proposedStartingPoints.Add(startingPoints)

                    filePtr.Seek(6, IO.SeekOrigin.Current)
                    Dim growthRate As Byte = filePtr.ReadByte()
                    entry.growthRates.Add(growthRate)
                    entry.proposedGrowthRates.Add(growthRate)

                    filePtr.Seek(-14, IO.SeekOrigin.Current)
                Next

                entries.Add(entry)
                filePtr.Seek(entryStartPosition + FE7SupportCompatibilityEntrySize, IO.SeekOrigin.Begin)
            Next

            filePtr.Seek(FE7SupportConversationAddressPointer, IO.SeekOrigin.Begin)
            tableOffset = Utilities.ReadWord(filePtr, True)
            repointedTable = False
            If tableOffset <> FE7SupportConversationDefaultAddress Then
                MsgBox("Support Conversation Table Offset has been updated. Support Conversation Table may have been repointed." + vbCrLf _
                       & "If this is a hacked game, not all supports may have conversations (or correct conversations).", MsgBoxStyle.OkOnly, "Notice")
                repointedTable = True
            End If

            realConversationAddress = tableOffset
            filePtr.Seek(tableOffset, IO.SeekOrigin.Begin)

            conversationEntries = New ArrayList()

            For i As Integer = 1 To FE7SupportConversationEntryCount
                Dim entry As FE7SupportConversationEntry = New FE7SupportConversationEntry()
                Dim entryStartPosition As Integer = filePtr.Position

                entry.character1 = filePtr.ReadByte()
                entry.character2 = filePtr.ReadByte()

                entry.proposedCharacter1 = entry.character1
                entry.proposedCharacter2 = entry.character2

                filePtr.Seek(entryStartPosition + 4, IO.SeekOrigin.Begin)
                entry.cConversation = Utilities.ReadHalfWord(filePtr)

                filePtr.Seek(entryStartPosition + 8, IO.SeekOrigin.Begin)
                entry.bConversation = Utilities.ReadHalfWord(filePtr)

                filePtr.Seek(entryStartPosition + 12, IO.SeekOrigin.Begin)
                entry.aConversation = Utilities.ReadHalfWord(filePtr)

                conversationEntries.Add(entry)
                filePtr.Seek(entryStartPosition + FE7SupportConversationEntrySize, IO.SeekOrigin.Begin)
            Next

        End If
    End Sub

    Public Sub updateCharacterIDs(ByVal originalCharacterID As Byte, ByVal newCharacterID As Byte)
        ' 0 isn't valid in any game. We shouldn't be changing to and from 0.
        If originalCharacterID <> 0 And newCharacterID <> 0 Then
            If gameType = Utilities.GameType.GameTypeFE6 Then
                For Each entry As FE6SupportCompatibilityEntry In entries
                    Dim index As Integer = entry.supporterIDs.IndexOf(originalCharacterID)
                    If index <> -1 Then
                        entry.proposedSupporterIDs.RemoveAt(index)
                        entry.proposedSupporterIDs.Insert(index, newCharacterID)
                    End If
                Next

                For Each entry As FE6SupportConversationEntry In conversationEntries
                    If entry.character1 = originalCharacterID Then entry.proposedCharacter1 = newCharacterID
                    If entry.character2 = originalCharacterID Then entry.proposedCharacter2 = newCharacterID
                Next
            ElseIf gameType = Utilities.GameType.GameTypeFE7 Then
                For Each entry As FE7SupportCompatibilityEntry In entries
                    Dim index As Integer = entry.supporterIDs.IndexOf(originalCharacterID)
                    If index <> -1 Then
                        entry.proposedSupporterIDs.RemoveAt(index)
                        entry.proposedSupporterIDs.Insert(index, newCharacterID)
                    End If
                Next

                For Each entry As FE7SupportConversationEntry In conversationEntries
                    If entry.character1 = originalCharacterID Then entry.proposedCharacter1 = newCharacterID
                    If entry.character2 = originalCharacterID Then entry.proposedCharacter2 = newCharacterID
                Next
            End If
        End If
    End Sub

    Public Sub commitChanges(ByRef filePtr As IO.FileStream)
        If Not IsNothing(filePtr) Then
            If gameType = Utilities.GameType.GameTypeFE6 And realAddress <> 0 Then
                filePtr.Seek(realAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To entries.Count - 1
                    Dim entry As FE6SupportCompatibilityEntry = entries.Item(i)
                    Dim entryStartPosition As Integer = filePtr.Position
                    For j As Integer = 0 To entry.proposedSupporterIDs.Count - 1
                        filePtr.WriteByte(entry.proposedSupporterIDs.Item(j))
                        ' commit the changes to the main array as we do this.
                        entry.supporterIDs.RemoveAt(j)
                        entry.supporterIDs.Insert(j, entry.proposedSupporterIDs.Item(j))
                    Next
                    ' We don't change anything else at the moment, so don't write anything else.
                    filePtr.Seek(entryStartPosition + FE6SupportCompatibilityEntrySize, IO.SeekOrigin.Begin)
                Next

                filePtr.Seek(realConversationAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To conversationEntries.Count - 1
                    Dim entry As FE6SupportConversationEntry = conversationEntries.Item(i)
                    Dim entryStartPosition As Integer = filePtr.Position
                    filePtr.WriteByte(entry.proposedCharacter1)
                    filePtr.WriteByte(entry.proposedCharacter2)
                    ' commit changes to memory copy
                    entry.character1 = entry.proposedCharacter1
                    entry.character2 = entry.proposedCharacter2

                    ' Don't touch the other stuff.
                    filePtr.Seek(entryStartPosition + FE6SupportConversationEntrySize, IO.SeekOrigin.Begin)
                Next
            ElseIf gameType = Utilities.GameType.GameTypeFE7 And realAddress <> 0 Then
                filePtr.Seek(realAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To entries.Count - 1
                    Dim entry As FE7SupportCompatibilityEntry = entries.Item(i)
                    Dim entryStartPosition As Integer = filePtr.Position
                    For j As Integer = 0 To entry.proposedSupporterIDs.Count - 1
                        filePtr.WriteByte(entry.proposedSupporterIDs.Item(j))
                        ' commit the changes to the main array as we do this.
                        entry.supporterIDs.RemoveAt(j)
                        entry.supporterIDs.Insert(j, entry.proposedSupporterIDs.Item(j))
                    Next
                    ' We don't change anything else at the moment, so don't write anything else.
                    filePtr.Seek(entryStartPosition + FE7SupportCompatibilityEntrySize, IO.SeekOrigin.Begin)
                Next

                filePtr.Seek(realConversationAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To conversationEntries.Count - 1
                    Dim entry As FE7SupportConversationEntry = conversationEntries.Item(i)
                    Dim entryStartPosition As Integer = filePtr.Position
                    filePtr.WriteByte(entry.proposedCharacter1)
                    filePtr.WriteByte(entry.proposedCharacter2)
                    ' commit changes to memory copy
                    entry.character1 = entry.proposedCharacter1
                    entry.character2 = entry.proposedCharacter2

                    ' Don't touch the other stuff.
                    filePtr.Seek(entryStartPosition + FE7SupportConversationEntrySize, IO.SeekOrigin.Begin)
                Next
            End If
        End If
    End Sub
End Class
