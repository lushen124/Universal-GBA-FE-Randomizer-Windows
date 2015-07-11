Public Class FE8SummonerModule
    Dim defaultAddress As Integer = &H95F5A4
    Dim defaultCount As Integer = 3
    Dim entrySize As Integer = 2

    Dim addressPointer1 As Integer = &H2442C
    Dim addressPointer2 As Integer = &H7AD54
    Dim addressPointer3 As Integer = &H7AE00

    Dim summonMappingArray As ArrayList
    Dim summonIDPool As ArrayList

    Dim newSummonMappingArray As ArrayList

    Dim realAddress As Integer

    Dim safeForModification As Boolean

    Private Enum DefaultSummonIDs
        LyonSummon = &H3B
        KnollSummon = &H3E
        EwanSummon = &H3F
    End Enum

    Private Class SummonMappingEntry
        Property characterID As Byte  ' offset 0, 1 byte
        Property summonID As Byte     ' offset 1, 1 byte
    End Class

    Public Sub New(ByRef filePtr As IO.FileStream)

        filePtr.Seek(addressPointer1, IO.SeekOrigin.Begin)
        Dim address1 As Integer = Utilities.ReadWord(filePtr, True)

        filePtr.Seek(addressPointer2, IO.SeekOrigin.Begin)
        Dim address2 As Integer = Utilities.ReadWord(filePtr, True)

        filePtr.Seek(addressPointer3, IO.SeekOrigin.Begin)
        Dim address3 As Integer = Utilities.ReadWord(filePtr, True)

        safeForModification = (address1 = address2) And (address2 = address3)

        If safeForModification And address1 <> defaultAddress Then
            MsgBox("Summoner's table address has updated. Summoner's table may have been repointed." + vbCrLf _
                   & "If this is a hacked game, not all summoners may be able to summon properly.", MsgBoxStyle.OkOnly, "Notice")
        End If

        realAddress = address1

        summonMappingArray = New ArrayList()
        summonIDPool = New ArrayList()

        filePtr.Seek(address1, IO.SeekOrigin.Begin)
        For i As Integer = 1 To defaultCount
            Dim newEntry As SummonMappingEntry = New SummonMappingEntry()

            newEntry.characterID = filePtr.ReadByte()
            newEntry.summonID = filePtr.ReadByte()

            If Not summonIDPool.Contains(newEntry.summonID) Then
                summonIDPool.Add(newEntry.summonID)
            End If

            summonMappingArray.Add(newEntry)
        Next

        newSummonMappingArray = New ArrayList()
    End Sub

    Public Sub registerSummoner(ByVal characterID As Byte, ByRef rng As Random)
        If characterID = &H0 Then
            Return
        End If

        Dim alreadyExists As Boolean = False
        For Each entry As SummonMappingEntry In newSummonMappingArray
            alreadyExists = entry.characterID = characterID
            If alreadyExists Then
                Exit For
            End If
        Next

        If Not alreadyExists Then
            Dim newEntry As SummonMappingEntry = New SummonMappingEntry()

            newEntry.characterID = characterID

            If summonIDPool.Count > 0 Then
                newEntry.summonID = summonIDPool.Item(rng.Next(summonIDPool.Count))
            Else
                Dim randomNumber = rng.Next(3)
                If randomNumber = 0 Then
                    newEntry.summonID = DefaultSummonIDs.EwanSummon
                ElseIf randomNumber = 1 Then
                    newEntry.summonID = DefaultSummonIDs.KnollSummon
                Else
                    newEntry.summonID = DefaultSummonIDs.LyonSummon
                End If
            End If

            newSummonMappingArray.Add(newEntry)
        End If
    End Sub

    Public Sub commitChanges(ByRef filePtr As IO.FileStream)
        If Not safeForModification Then
            Return
        End If

        If newSummonMappingArray.Count = 0 Then
            Return
        End If

        Dim needsRepointing As Boolean = newSummonMappingArray.Count > summonMappingArray.Count

        Dim targetAddress As Integer = realAddress

        If needsRepointing Then
            filePtr.Seek(0, IO.SeekOrigin.End)
            targetAddress = filePtr.Position

            filePtr.Seek(addressPointer1, IO.SeekOrigin.Begin)
            Utilities.WriteWord(filePtr, targetAddress + &H8000000)
            filePtr.Seek(addressPointer2, IO.SeekOrigin.Begin)
            Utilities.WriteWord(filePtr, targetAddress + &H8000000)
            filePtr.Seek(addressPointer3, IO.SeekOrigin.Begin)
            Utilities.WriteWord(filePtr, targetAddress + &H8000000)
        End If

        filePtr.Seek(targetAddress, IO.SeekOrigin.Begin)
        For Each entry As SummonMappingEntry In newSummonMappingArray
            filePtr.WriteByte(entry.characterID)
            filePtr.WriteByte(entry.summonID)
        Next

        ' The terminal entry for this array is two 0 bytes.
        filePtr.WriteByte(0)
        filePtr.WriteByte(0)
    End Sub

End Class
