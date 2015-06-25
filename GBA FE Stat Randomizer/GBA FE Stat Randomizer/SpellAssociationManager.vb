Public Class SpellAssociationManager

    ' Only necessary for FE7 so far...
    Dim FE7SpellAssociationAddressPointer As Integer = &H52B24
    Dim FE7SpellAssociationDefaultAddress As Integer = &HC999C0
    Dim FE7SpellAssociationEntrySize As Integer = 16
    Dim FE7SpellAssociationEntryCount As Integer = 127

    Private Class FE7SpellAssociationEntry
        Property weaponID As UShort                  ' offset 0, 2 bytes (?)
        Property displayedCharacters As UShort       ' offset 2, 2 bytes
        Property animationUsed As UShort             ' offset 4, 2 bytes
        ' There's more, but I don't need it.
    End Class

    Private Enum FE7SpellAnimations
        None = &H0
        Fire = &H16
        Elfire = &H17
        Thunder = &H19
        Bolting = &H1A
        Fimbulvetr = &H1B
        Flux = &H1D
        Lightning = &H1F
        Purge = &H20
        Divine = &H22
        None2 = &HFFFF
    End Enum

    Property gameType As Utilities.GameType

    Private Property entries As ArrayList
    Private Property realAddress As Integer

    Public Sub New(ByVal type As Utilities.GameType, ByRef filePtr As IO.FileStream)
        gameType = type

        If type = Utilities.GameType.GameTypeFE7 Then
            filePtr.Seek(FE7SpellAssociationAddressPointer, IO.SeekOrigin.Begin)
            Dim tableOffset As Integer = Utilities.ReadWord(filePtr, True)
            Dim repointedTable As Boolean = False
            If tableOffset <> FE7SpellAssociationDefaultAddress Then
                MsgBox("Spell Association Table Offset has been updated. Spell Association Table may have been repointed." + vbCrLf _
                       & "If this is a hacked game, magic weapons may not have animations.", MsgBoxStyle.OkOnly, "Notice")
                repointedTable = True
            End If

            realAddress = tableOffset
            filePtr.Seek(tableOffset, IO.SeekOrigin.Begin)

            entries = New ArrayList()

            For i As Integer = 1 To FE7SpellAssociationEntryCount
                Dim entry As FE7SpellAssociationEntry = New FE7SpellAssociationEntry()
                Dim entryStartPosition As Integer = filePtr.Position

                entry.weaponID = Utilities.ReadHalfWord(filePtr)
                entry.displayedCharacters = Utilities.ReadHalfWord(filePtr)
                entry.animationUsed = Utilities.ReadHalfWord(filePtr)

                entries.Add(entry)
                filePtr.Seek(entryStartPosition + FE7SpellAssociationEntrySize, IO.SeekOrigin.Begin)
            Next
        End If
    End Sub

    Private Function randomAnimation(ByRef rng As Random) As FE7SpellAnimations
        Dim animations As ArrayList = New ArrayList(System.Enum.GetValues(GetType(FE7SpellAnimations)))

        Return animations.Item(rng.Next(1, animations.Count - 1))
    End Function

    Public Sub assignRandomSpellAnimationToWeaponWithID(ByVal weaponId As Byte, ByRef rng As Random)
        Dim animation As UShort = Convert.ToUInt16(randomAnimation(rng))

        For i = 0 To entries.Count - 1
            Dim entry As FE7SpellAssociationEntry = entries.Item(i)
            If entry.weaponID = Convert.ToUInt16(weaponId) And
                (entry.animationUsed = Convert.ToUInt16(FE7SpellAnimations.None) Or entry.animationUsed = Convert.ToUInt16(FE7SpellAnimations.None2)) Then
                entry.animationUsed = animation
            End If
        Next
    End Sub

    Public Sub commitChanges(ByRef filePtr As IO.FileStream)
        If Not IsNothing(filePtr) Then
            If gameType = Utilities.GameType.GameTypeFE7 And realAddress <> 0 Then
                filePtr.Seek(realAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To entries.Count - 1

                    DebugLogger.logMessage("[SpellAssociationManager] - Wrote Address 0x" & Hex(filePtr.Position) & " to 0x" & Hex(filePtr.Position + FE7SpellAssociationEntrySize))

                    Dim entry As FE7SpellAssociationEntry = entries.Item(i)
                    Dim entryStartPosition As Integer = filePtr.Position

                    filePtr.Seek(entryStartPosition + 4, IO.SeekOrigin.Begin)
                    Utilities.WriteHalfWord(filePtr, entry.animationUsed)

                    filePtr.Seek(entryStartPosition + FE7SpellAssociationEntrySize, IO.SeekOrigin.Begin)
                Next
            End If
        End If
    End Sub

End Class
