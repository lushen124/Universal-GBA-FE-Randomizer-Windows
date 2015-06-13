Public Class FEClass

    Property classId As Byte            'offset 4, 1 byte

    Property baseHP As Byte             'offset 11, 1 byte
    Property baseStr As Byte            'offset 12, 1 byte
    Property baseSkl As Byte            'offset 13, 1 byte
    Property baseSpd As Byte            'offset 14, 1 byte
    Property baseDef As Byte            'offset 15, 1 byte
    Property baseRes As Byte            'offset 16, 1 byte
    Property baseCon As Byte            'offset 17, 1 byte
    Property baseMov As Byte            'offset 18, 1 byte

    Property hpCap As Byte              'offset 19, 1 byte
    Property strCap As Byte             'offset 20, 1 byte
    Property sklCap As Byte             'offset 21, 1 byte
    Property spdCap As Byte             'offset 22, 1 byte
    Property defCap As Byte             'offset 23, 1 byte
    Property resCap As Byte             'offset 24, 1 byte

    Property hpGrowth As Byte           'offset 27, 1 byte
    Property strGrowth As Byte          'offset 28, 1 byte
    Property sklGrowth As Byte          'offset 29, 1 byte
    Property spdGrowth As Byte          'offset 30, 1 byte
    Property defGrowth As Byte          'offset 31, 1 byte
    Property resGrowth As Byte          'offset 32, 1 byte
    Property lckGrowth As Byte          'offset 33, 1 byte

    Property ability1 As Byte           'offset 40, 1 byte (offset 36 in FE6)
    Property ability2 As Byte           'offset 41, 1 byte (offset 37 in FE6)
    Property ability3 As Byte           'offset 42, 1 byte (offset 38 in FE6)
    Property ability4 As Byte           'offset 43, 1 byte (offset 39 in FE6)

    Property swordLevel As Byte         'offset 44, 1 byte (offset 40 in FE6)
    Property spearLevel As Byte         'offset 45, 1 byte (offset 41 in FE6)
    Property axeLevel As Byte           'offset 46, 1 byte (offset 42 in FE6)
    Property bowLevel As Byte           'offset 47, 1 byte (offset 43 in FE6)
    Property staffLevel As Byte         'offset 48, 1 byte (offset 44 in FE6)
    Property animaLevel As Byte         'offset 49, 1 byte (offset 45 in FE6)
    Property lightLevel As Byte         'offset 50, 1 byte (offset 46 in FE6)
    Property darkLevel As Byte          'offset 51, 1 byte (offset 47 in FE6)

    Enum WeaponRank
        WeaponRankNone = &H0
        WeaponRankE = &H1
        WeaponRankD = &H33
        WeaponRankC = &H65
        WeaponRankB = &H97
        WeaponRankA = &HC9
        WeaponRankS = &HFB
    End Enum

    Enum ClassAbility1 'Bitmaskable
        None = &H0
        MountedAidSystem = &H1
        MoveAgain = &H2
        Steal = &H4
        ThiefKey = &H8
        Dance = &H10
        Play = &H20
        CriticalBoost = &H40 '+30 for FE6, +15 for FE7 and FE8
        Ballista = &H80
    End Enum

    Enum ClassAbility2 'Bitmaskable
        None = &H0
        Promoted = &H1
        SupplyDepot = &H2
        ShowHorseIcon = &H4
        ShowDragonIcon = &H8
        ShowPegasusIcon = &H10
        Lord = &H20
        Female = &H40
        Boss = &H80
    End Enum

    Enum ClassAbility3 'Bitmaskable
        None = &H0
        LordPrfWeaponLock = &H1 'Only in FE6
        WoDaoWeaponLock = &H2 'Shamshir in FE8
        DragonstoneLock = &H4 'Monster weapons in FE8
        MorphsMaxLevel10 = &H8 'Morphs in FE7, Max Level 10 in FE8
        Uncontrollable = &H10 'Unknown in FE6
        PegasusKnightTriangle = &H20
        ArmorKnightTriangle = &H40 'Only in FE6
        StartsAsNPC = &H80 'Only in FE6
    End Enum

    Enum ClassAbility4 'Bitmaskable (Only defined for FE7 and FE8)
        None = &H0
        NoExperience = &H1
        Lethality = &H2
        SealsMagic = &H4 'FE7 only
        DropsLastItemOrSummon = &H8 'FE7 drops last item, FE8 is for summoned monsters.
        EliwoodEirikaWeaponLock = &H10
        HectorEphraimWeaponLock = &H20
        LynWeaponLock = &H40 'FE7 only
        AthosWeaponLock = &H80 'FE7 only
    End Enum

    Public Sub initializeWithBytesFromOffset(ByRef filePtr As IO.FileStream, ByVal offset As Integer, ByVal entrySize As Integer, ByVal type As Utilities.GameType)
        filePtr.Seek(offset + 4, IO.SeekOrigin.Begin)
        classId = filePtr.ReadByte()

        filePtr.Seek(offset + 11, IO.SeekOrigin.Begin)
        baseHP = filePtr.ReadByte()
        baseStr = filePtr.ReadByte()
        baseSkl = filePtr.ReadByte()
        baseSpd = filePtr.ReadByte()
        baseDef = filePtr.ReadByte()
        baseRes = filePtr.ReadByte()
        baseCon = filePtr.ReadByte()
        baseMov = filePtr.ReadByte()

        hpCap = filePtr.ReadByte()
        strCap = filePtr.ReadByte()
        sklCap = filePtr.ReadByte()
        spdCap = filePtr.ReadByte()
        defCap = filePtr.ReadByte()
        resCap = filePtr.ReadByte()

        filePtr.Seek(offset + 27, IO.SeekOrigin.Begin)
        hpGrowth = filePtr.ReadByte()
        strGrowth = filePtr.ReadByte()
        sklGrowth = filePtr.ReadByte()
        spdGrowth = filePtr.ReadByte()
        defGrowth = filePtr.ReadByte()
        resGrowth = filePtr.ReadByte()
        lckGrowth = filePtr.ReadByte()

        If type = Utilities.GameType.GameTypeFE6 Then
            filePtr.Seek(offset + 36, IO.SeekOrigin.Begin)
        Else
            filePtr.Seek(offset + 40, IO.SeekOrigin.Begin)
        End If

        ability1 = filePtr.ReadByte()
        ability2 = filePtr.ReadByte()
        ability3 = filePtr.ReadByte()
        ability4 = filePtr.ReadByte()

        swordLevel = filePtr.ReadByte()
        spearLevel = filePtr.ReadByte()
        axeLevel = filePtr.ReadByte()
        bowLevel = filePtr.ReadByte()
        staffLevel = filePtr.ReadByte()
        animaLevel = filePtr.ReadByte()
        lightLevel = filePtr.ReadByte()
        darkLevel = filePtr.ReadByte()

        filePtr.Seek(offset + entrySize, IO.SeekOrigin.Begin)
    End Sub

    Public Sub writeClassStartingAtOffset(ByRef filePtr As IO.FileStream, ByVal offset As Integer, ByVal entrySize As Integer, ByVal type As Utilities.GameType)
        ' The only thing that's really modifiable here is the growths and MOV.
        filePtr.Seek(offset + 18, IO.SeekOrigin.Begin)
        filePtr.WriteByte(baseMov)

        filePtr.Seek(offset + 27, IO.SeekOrigin.Begin)
        filePtr.WriteByte(hpGrowth)
        filePtr.WriteByte(strGrowth)
        filePtr.WriteByte(sklGrowth)
        filePtr.WriteByte(spdGrowth)
        filePtr.WriteByte(defGrowth)
        filePtr.WriteByte(resGrowth)
        filePtr.WriteByte(lckGrowth)

        If type = Utilities.GameType.GameTypeFE6 Then
            filePtr.Seek(offset + 36, IO.SeekOrigin.Begin)
        Else
            filePtr.Seek(offset + 40, IO.SeekOrigin.Begin)
        End If

        filePtr.WriteByte(ability1)
        filePtr.WriteByte(ability2)
        filePtr.WriteByte(ability3)
        filePtr.WriteByte(ability4)

        filePtr.Seek(offset + entrySize, IO.SeekOrigin.Begin)
    End Sub

    Public Sub randomizeMOV(ByVal minimumMOV As Integer, ByVal maximumMOV As Integer, ByRef rng As Random)
        baseMov = rng.Next(minimumMOV, maximumMOV)
    End Sub

    Public Function isLord() As Boolean
        Return ability2 And ClassAbility2.Lord
    End Function

    Public Function isThief() As Boolean
        Return ability1 And ClassAbility1.Steal
    End Function

End Class


