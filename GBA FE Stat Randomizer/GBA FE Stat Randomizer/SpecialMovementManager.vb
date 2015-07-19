Public Class SpecialMovementManager

    Private classList As ArrayList
    Private classLookup As Hashtable
    Private gameType As Utilities.GameType

    Public Sub New(ByVal type As Utilities.GameType)
        gameType = type
        classList = New ArrayList()
        classLookup = New Hashtable()
    End Sub

    Public Sub registerClassForMovementFix(ByRef characterClass As FEClass)
        If Not IsNothing(characterClass) And Not classLookup.ContainsKey(characterClass.classId) Then
            classList.Add(characterClass)
            Utilities.setObjectForKey(classLookup, characterClass, characterClass.classId)
        End If
    End Sub

    Public Sub commitFixes(ByRef filePtr As IO.FileStream)
        Dim originalPosition As Integer = filePtr.Position

        filePtr.Seek(0, IO.SeekOrigin.End)

        For Each characterClass As FEClass In classList
            Dim entrySize = characterClass.movementCostData.Length
            Dim targetByteArray As Byte() = New Byte(entrySize - 1) {}
            For i As Integer = 0 To entrySize - 1
                Dim originalByte As Byte = characterClass.movementCostData(i)
                If originalByte = &HFF Then
                    targetByteArray(i) = &H1E
                Else
                    targetByteArray(i) = originalByte
                End If
            Next

            characterClass.movementCostData = targetByteArray
            characterClass.movementTypePointer = filePtr.Position
            characterClass.writeMovementCostPointer = True

            For i As Integer = 0 To entrySize - 1
                filePtr.WriteByte(targetByteArray(i))
            Next

        Next

        filePtr.Seek(originalPosition, IO.SeekOrigin.Begin)
    End Sub

End Class
