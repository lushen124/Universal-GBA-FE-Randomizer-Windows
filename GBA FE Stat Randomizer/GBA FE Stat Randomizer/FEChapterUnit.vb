Public Class FEChapterUnit

    Property characterId As Byte        'offset 0, 1 byte
    Property classId As Byte            'offset 1, 1 byte

    Property item1Id As Byte            'offset 8, 1 byte (offset 12 for FE8)
    Property item2Id As Byte            'offset 9, 1 byte (offset 13 for FE8)
    Property item3Id As Byte            'offset 10, 1 byte (offset 14 for FE8)
    Property item4Id As Byte            'offset 11, 1 byte (offset 15 for FE8)

    ' Level/Alliance is interesting because it has a lot of information.
    ' It holds starting level, alliance, as well as autolevel information.
    ' We don't really care about autolevel information or level, but alliance is important.
    ' Read the entire byte and then parse it out later.
    ' The least significant bit determins autolevel (0 for fixed, 1 for autolevel)
    ' The next bit determines flags whether or not it's an NPC (1 if NPC)
    ' The bit after that determines if it's an enemy (1 if Enemy)
    ' The remaining bits after that determine level (from 0 to a max of 31)
    Property levelAlliance As Byte      'offset 3, 1 byte

    ' In order to minimize change (and reduce on potential issues), only write these if necessary,
    ' since there are a lot that we don't need to change.
    Property hasChanged As Boolean

    Public Sub initializeWithBytesFromOffset(ByRef filePtr As IO.FileStream, ByVal offset As Integer, ByVal entrySize As Integer, ByVal type As Utilities.GameType)
        filePtr.Seek(offset, IO.SeekOrigin.Begin)
        characterId = filePtr.ReadByte()
        classId = filePtr.ReadByte()

        filePtr.Seek(offset + 3, IO.SeekOrigin.Begin)
        levelAlliance = filePtr.ReadByte()

        If type = Utilities.GameType.GameTypeFE8 Then
            filePtr.Seek(offset + 12, IO.SeekOrigin.Begin)
        Else
            filePtr.Seek(offset + 8, IO.SeekOrigin.Begin)
        End If

        item1Id = filePtr.ReadByte()
        item2Id = filePtr.ReadByte()
        item3Id = filePtr.ReadByte()
        item4Id = filePtr.ReadByte()

        filePtr.Seek(offset + entrySize, IO.SeekOrigin.Begin)
    End Sub

    Public Sub writeChapterUnitToOffset(ByRef filePtr As IO.FileStream, ByVal offset As Integer, ByVal entrySize As Integer, ByVal type As Utilities.GameType, ByVal debugInfo As String)

        If hasChanged Then
            DebugLogger.logMessage("[ChapterUnit (" & debugInfo & ")] - Wrote Address 0x" & Hex(offset) & " to 0x" & Hex(offset + entrySize))

            filePtr.Seek(offset, IO.SeekOrigin.Begin)
            filePtr.WriteByte(characterId)
            filePtr.WriteByte(classId)

            ' Don't mess with level alliance. 

            If type = Utilities.GameType.GameTypeFE8 Then
                filePtr.Seek(offset + 12, IO.SeekOrigin.Begin)
            Else
                filePtr.Seek(offset + 8, IO.SeekOrigin.Begin)
            End If

            ' We always need to write 4 items, but collapse them if we have gaps because
            ' the game stops after the first 0.
            If item1Id = &H0 Then
                If item4Id <> &H0 Then
                    item1Id = item4Id
                    item4Id = &H0
                ElseIf item3Id <> &H0 Then
                    item1Id = item3Id
                    item3Id = &H0
                ElseIf item2Id <> &H0 Then
                    item1Id = item2Id
                    item2Id = &H0
                End If
            End If

            If item2Id = &H0 Then
                If item4Id <> &H0 Then
                    item2Id = item4Id
                    item4Id = &H0
                ElseIf item3Id <> &H0 Then
                    item2Id = item3Id
                    item3Id = &H0
                End If
            End If

            If item3Id = &H0 Then
                If item4Id <> &H0 Then
                    item3Id = item4Id
                    item4Id = &H0
                End If
            End If

            filePtr.WriteByte(item1Id)
            filePtr.WriteByte(item2Id)
            filePtr.WriteByte(item3Id)
            filePtr.WriteByte(item4Id)
        End If

        filePtr.Seek(offset + entrySize, IO.SeekOrigin.Begin)
    End Sub

    Public Function isEnemy() As Boolean
        Return levelAlliance And &H4
    End Function

    Public Function isNPC() As Boolean
        Return levelAlliance And &H2
    End Function

    Public Function isAutolevel() As Boolean
        Return levelAlliance And &H1
    End Function

    Public Function isPlayable() As Boolean
        Return Not isEnemy() And Not isNPC()
    End Function

    Public Function startingLevel() As Byte
        Return levelAlliance And &HF8 >> 3
    End Function

End Class
