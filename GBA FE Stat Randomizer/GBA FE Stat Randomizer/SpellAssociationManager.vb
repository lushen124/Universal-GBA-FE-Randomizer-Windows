Public Class SpellAssociationManager

    Dim FE6SpellAssociationAddressPointer As Integer = &H49DB4
    Dim FE6SpellAssociationDefaultAddress As Integer = &H662E4C
    Dim FE6SpellAssociationEntrySize As Integer = 16
    Dim FE6SpellAssociationEntryCount As Integer = 107

    Dim FE7SpellAssociationAddressPointer As Integer = &H52B24
    Dim FE7SpellAssociationDefaultAddress As Integer = &HC999C0
    Dim FE7SpellAssociationEntrySize As Integer = 16
    Dim FE7SpellAssociationEntryCount As Integer = 127

    Dim FE8SpellAssociationAddressPointer As Integer = &H58014
    Dim FE8SpellAssociationDefaultAddress As Integer = &H8AFBD8
    Dim FE8SpellAssociationEntrySize As Integer = 16
    Dim FE8SpellAssociationEntryCount As Integer = 160

    Private Class FE6SpellAssociationEntry
        Property weaponID As Byte                   ' offset 0, 1 byte
        Property animationUsed As UShort            ' offset 4, 2 bytes

        Property proposedAnimation As UShort
    End Class

    Private Enum FE6SpellAnimations
        None = &H0
        Fire = &H16
        Elfire = &H17
        Thunder = &H19
        Bolting = &H1A
        Fimbulvetr = &H1B
        Aircalibur = &H1C
        Flux = &H1D
        Lightning = &H1F
        Purge = &H20
        Divine = &H22
        None2 = &HFFFF
    End Enum

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

    Private Class FE8SpellAssociationEntry
        Property weaponID As Byte                   ' offset 0, 1 byte
        Property isTerminal As Byte                 ' offset 1, 1 byte (FF for terminal)
        Property displayedCharacters As Byte        ' offset 2, 1 byte

        Property animationUsed As Byte              ' offset 4, 1 byte
        Property rangedAnimationEnabled As Byte     ' offset 5, 1 byte (00 enabled, FF disabled)

        Property proposedAnimation As Byte
    End Class

    Private Enum FE8SpellAnimations
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
        Eclipse = &H24
        Fenrir = &H25
        Shine = &H33
        Excalibur = &H35
        Aura = &H37
        'Ivaldi = &H3F
        'Gleipnir = &H41
        CrimsonEye = &H42
        EvilEye = &H43
        'Shadowshot = &H44
        DemonSurge = &H45
        'Naglfar = &H46
        None2 = &HFF
    End Enum

    Property gameType As Utilities.GameType

    Private Property entries As ArrayList
    Private Property realAddress As Integer

    Public Sub New(ByVal type As Utilities.GameType, ByRef filePtr As IO.FileStream)
        gameType = type

        If type = Utilities.GameType.GameTypeFE6 Then
            filePtr.Seek(FE6SpellAssociationAddressPointer, IO.SeekOrigin.Begin)
            Dim tableOffset As Integer = Utilities.ReadWord(filePtr, True)
            Dim repointedTable As Boolean = False
            If tableOffset <> FE6SpellAssociationDefaultAddress Then
                MsgBox("Spell Association Table Offset has been updated. Spell Association Table may have been repointed." + vbCrLf _
                       & "If this is a hacked game, magic weapons may not have animations.", MsgBoxStyle.OkOnly, "Notice")
                repointedTable = True
            End If

            realAddress = tableOffset
            filePtr.Seek(tableOffset, IO.SeekOrigin.Begin)

            entries = New ArrayList()

            For i As Integer = 1 To FE6SpellAssociationEntryCount
                Dim entry As FE6SpellAssociationEntry = New FE6SpellAssociationEntry()
                Dim entryStartPosition As Integer = filePtr.Position

                entry.weaponID = filePtr.ReadByte()

                filePtr.Seek(entryStartPosition + 4, IO.SeekOrigin.Begin)

                entry.animationUsed = Utilities.ReadHalfWord(filePtr)

                entry.proposedAnimation = entry.animationUsed

                entries.Add(entry)
                filePtr.Seek(entryStartPosition + FE6SpellAssociationEntrySize, IO.SeekOrigin.Begin)
            Next
        End If
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
        ElseIf type = Utilities.GameType.GameTypeFE8 Then
            filePtr.Seek(FE8SpellAssociationAddressPointer, IO.SeekOrigin.Begin)
            Dim tableOffset As Integer = Utilities.ReadWord(filePtr, True)
            Dim repointedTable As Boolean = False
            If tableOffset <> FE8SpellAssociationDefaultAddress Then
                MsgBox("Spell Association Table Offset has been updated. Spell Association Table may have been repointed." + vbCrLf _
                       & "If this is a hacked game, magic weapons may not have animations.", MsgBoxStyle.OkOnly, "Notice")
                repointedTable = True
            End If

            realAddress = tableOffset
            filePtr.Seek(tableOffset, IO.SeekOrigin.Begin)

            entries = New ArrayList()

            For i As Integer = 1 To FE8SpellAssociationEntryCount
                Dim entry As FE8SpellAssociationEntry = New FE8SpellAssociationEntry()
                Dim entryStartPosition As Integer = filePtr.Position

                entry.weaponID = filePtr.ReadByte()
                entry.isTerminal = filePtr.ReadByte()
                entry.displayedCharacters = filePtr.ReadByte()

                ' Skip one byte.
                filePtr.ReadByte()

                entry.animationUsed = filePtr.ReadByte()
                entry.rangedAnimationEnabled = filePtr.ReadByte()

                entry.proposedAnimation = entry.animationUsed

                entries.Add(entry)
                filePtr.Seek(entryStartPosition + FE8SpellAssociationEntrySize, IO.SeekOrigin.Begin)
            Next
        End If
    End Sub

    Private Function randomAnimation(ByRef rng As Random, ByVal gameType As Utilities.GameType) As UShort
        If gameType = Utilities.GameType.GameTypeFE6 Then
            Dim animations As ArrayList = New ArrayList(System.Enum.GetValues(GetType(FE6SpellAnimations)))

            Return animations.Item(rng.Next(1, animations.Count - 1))
        ElseIf gameType = Utilities.GameType.GameTypeFE7 Then
            Dim animations As ArrayList = New ArrayList(System.Enum.GetValues(GetType(FE7SpellAnimations)))

            Return animations.Item(rng.Next(1, animations.Count - 1))
        ElseIf gameType = Utilities.GameType.GameTypeFE8 Then
            Dim animations As ArrayList = New ArrayList(System.Enum.GetValues(GetType(FE8SpellAnimations)))

            Return animations.Item(rng.Next(1, animations.Count - 1))
        End If

        Return 0

    End Function

    Public Sub assignRandomSpellAnimationToWeaponWithID(ByVal weaponId As Byte, ByVal gameType As Utilities.GameType, ByRef rng As Random)
        Dim animation As UShort = Convert.ToUInt16(randomAnimation(rng, gameType))

        For i = 0 To entries.Count - 1
            If gameType = Utilities.GameType.GameTypeFE6 Then
                Dim entry As FE6SpellAssociationEntry = entries.Item(i)
                If entry.weaponID = weaponId And
                    (entry.animationUsed = Convert.ToUInt16(FE6SpellAnimations.None) Or entry.animationUsed = Convert.ToUInt16(FE6SpellAnimations.None2)) Then
                    entry.proposedAnimation = animation
                End If
            ElseIf gameType = Utilities.GameType.GameTypeFE7 Then
                Dim entry As FE7SpellAssociationEntry = entries.Item(i)
                If entry.weaponID = Convert.ToUInt16(weaponId) And
                    (entry.animationUsed = Convert.ToUInt16(FE7SpellAnimations.None) Or entry.animationUsed = Convert.ToUInt16(FE7SpellAnimations.None2)) Then
                    entry.animationUsed = animation
                End If
            ElseIf gameType = Utilities.GameType.GameTypeFE8 Then
                Dim entry As FE8SpellAssociationEntry = entries.Item(i)
                If entry.weaponID = weaponId And
                    (entry.animationUsed = Convert.ToByte(FE8SpellAnimations.None) Or entry.animationUsed = Convert.ToByte(FE8SpellAnimations.None2)) Then
                    entry.proposedAnimation = animation
                End If
            End If
        Next
    End Sub

    Public Sub commitChanges(ByRef filePtr As IO.FileStream)
        If Not IsNothing(filePtr) And realAddress <> 0 Then
            If gameType = Utilities.GameType.GameTypeFE6 Then
                filePtr.Seek(realAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To entries.Count - 1
                    DebugLogger.logMessage("[SpellAssociationManager] - Wrote Address 0x" & Hex(filePtr.Position) & " to 0x" & Hex(filePtr.Position + FE6SpellAssociationEntrySize))

                    Dim entry As FE6SpellAssociationEntry = entries.Item(i)
                    Dim entryStartPosition As Integer = filePtr.Position

                    filePtr.Seek(entryStartPosition + 4, IO.SeekOrigin.Begin)
                    Utilities.WriteHalfWord(filePtr, entry.proposedAnimation)
                    If entry.proposedAnimation <> entry.animationUsed Then
                        entry.animationUsed = entry.proposedAnimation
                    End If

                    filePtr.Seek(entryStartPosition + FE6SpellAssociationEntrySize, IO.SeekOrigin.Begin)
                Next
            ElseIf gameType = Utilities.GameType.GameTypeFE7 Then
                filePtr.Seek(realAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To entries.Count - 1

                    DebugLogger.logMessage("[SpellAssociationManager] - Wrote Address 0x" & Hex(filePtr.Position) & " to 0x" & Hex(filePtr.Position + FE7SpellAssociationEntrySize))

                    Dim entry As FE7SpellAssociationEntry = entries.Item(i)
                    Dim entryStartPosition As Integer = filePtr.Position

                    filePtr.Seek(entryStartPosition + 4, IO.SeekOrigin.Begin)
                    Utilities.WriteHalfWord(filePtr, entry.animationUsed)

                    filePtr.Seek(entryStartPosition + FE7SpellAssociationEntrySize, IO.SeekOrigin.Begin)
                Next
            ElseIf gameType = Utilities.GameType.GameTypeFE8 Then
                filePtr.Seek(realAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To entries.Count - 1

                    DebugLogger.logMessage("[SpellAssociationManager] - Wrote Address 0x" & Hex(filePtr.Position) & " to 0x" & Hex(filePtr.Position + FE8SpellAssociationEntrySize))

                    Dim entry As FE8SpellAssociationEntry = entries.Item(i)
                    Dim entryStartPosition As Integer = filePtr.Position

                    filePtr.Seek(entryStartPosition + 4, IO.SeekOrigin.Begin)
                    filePtr.WriteByte(entry.proposedAnimation)
                    If entry.proposedAnimation <> Convert.ToByte(FE8SpellAnimations.None) And entry.proposedAnimation <> Convert.ToByte(FE8SpellAnimations.None2) And entry.proposedAnimation <> entry.animationUsed Then
                        filePtr.WriteByte(&H0)
                        entry.rangedAnimationEnabled = &H0
                    End If

                    entry.animationUsed = entry.proposedAnimation

                    filePtr.Seek(entryStartPosition + FE8SpellAssociationEntrySize, IO.SeekOrigin.Begin)
                Next
            End If
        End If
    End Sub

End Class
