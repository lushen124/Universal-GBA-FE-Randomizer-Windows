Imports WindowsApplication1

Public Class FECharacter
    Implements RecordKeeper.RecordableItem

    Property characterAffinity As Short 'offset 9, 1 byte
    Property level As Byte 'offset 11, 1 byte

    Property baseHP As SByte 'offset 12, 1 byte
    Property baseStr As SByte 'offset 13, 1 byte
    Property baseSkl As SByte 'offset 14, 1 byte
    Property baseSpd As SByte 'offset 15, 1 byte
    Property baseDef As SByte 'offset 16, 1 byte
    Property baseRes As SByte 'offset 17, 1 byte
    Property baseLck As SByte 'offset 18, 1 byte
    Property baseCon As SByte 'offset 19, 1 byte

    Property hpGrowth As Byte 'offset 28, 1 byte
    Property strGrowth As Byte 'offset 29, 1 byte
    Property sklGrowth As Byte 'offset 30, 1 byte
    Property spdGrowth As Byte 'offset 31, 1 byte
    Property defGrowth As Byte 'offset 32, 1 byte
    Property resGrowth As Byte 'offset 33, 1 byte
    Property lckGrowth As Byte 'offset 34, 1 byte

    Property swordLevel As Byte 'offset 20, 1 byte
    Property spearLevel As Byte 'offset 21, 1 byte
    Property axeLevel As Byte 'offset 22, 1 byte
    Property bowLevel As Byte 'offset 23, 1 byte
    Property staffLevel As Byte 'offset 24, 1 byte
    Property animaLevel As Byte 'offset 25, 1 byte
    Property lightLevel As Byte 'offset 26, 1 byte
    Property darkLevel As Byte 'offset 27, 1 byte

    Property nameIndex As UShort 'offset 0, 2 bytes (should only be swapped with another valid address)
    Property bioIndex As UShort 'offset 2, 2 bytes (should only be swapped with another valid address)

    Property characterId As Byte 'offset 4, 1 byte
    Property classId As Byte 'offset 5, 1 byte

    Property portraitIndex As Byte 'offset 6, 1 byte (should only be swapped with another valid index)

    Property paletteIndex As Byte 'offset 35, 1 byte (unavailable in FE8)
    Property promotedPaletteIndex As Byte 'offset 36, 1 byte (unavailable in FE8)

    Property customUnpromotedSprite As Byte 'offset 37, 1 byte (Only in FE7)
    Property customPromotedSprite As Byte ' offset 38, 1 byte (Only in FE7)

    Property ability1 As Byte 'offset 40, 1 byte
    Property ability2 As Byte 'offset 41, 1 byte
    Property ability3 As Byte 'offset 42, 1 byte
    Property ability4 As Byte 'offset 43, 1 byte

    Property supportDataPointer As Integer 'offset 44, 4 bytes (address)

    Property shouldResetCustomSpriteToDefault As Boolean

    Property displayName As String
    Property classDisplayName As String
    Property gameType As Utilities.GameType

    Enum CharacterAbility1 'Bitmaskable
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

    Enum CharacterAbility2 'Bitmaskable
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

    Enum CharacterAbility3 'Bitmaskable
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

    Enum CharacterAbility4 'Bitmaskable (Only defined for FE7 and FE8)
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

    Public Function Copy() As FECharacter
        Dim copiedCharacter As FECharacter = New FECharacter()
        copiedCharacter.characterAffinity = characterAffinity
        copiedCharacter.level = level
        copiedCharacter.baseHP = baseHP
        copiedCharacter.baseStr = baseStr
        copiedCharacter.baseSkl = baseSkl
        copiedCharacter.baseSpd = baseSpd
        copiedCharacter.baseDef = baseDef
        copiedCharacter.baseRes = baseRes
        copiedCharacter.baseLck = baseLck
        copiedCharacter.baseCon = baseCon

        copiedCharacter.hpGrowth = hpGrowth
        copiedCharacter.strGrowth = strGrowth
        copiedCharacter.sklGrowth = sklGrowth
        copiedCharacter.spdGrowth = spdGrowth
        copiedCharacter.defGrowth = defGrowth
        copiedCharacter.resGrowth = resGrowth
        copiedCharacter.lckGrowth = lckGrowth

        copiedCharacter.swordLevel = swordLevel
        copiedCharacter.spearLevel = spearLevel
        copiedCharacter.axeLevel = axeLevel
        copiedCharacter.bowLevel = bowLevel
        copiedCharacter.staffLevel = staffLevel
        copiedCharacter.animaLevel = animaLevel
        copiedCharacter.lightLevel = lightLevel
        copiedCharacter.darkLevel = darkLevel

        copiedCharacter.nameIndex = nameIndex
        copiedCharacter.bioIndex = bioIndex

        copiedCharacter.characterId = characterId
        copiedCharacter.classId = classId

        copiedCharacter.portraitIndex = portraitIndex

        copiedCharacter.paletteIndex = paletteIndex
        copiedCharacter.promotedPaletteIndex = promotedPaletteIndex

        copiedCharacter.customUnpromotedSprite = customUnpromotedSprite
        copiedCharacter.customPromotedSprite = customPromotedSprite

        copiedCharacter.ability1 = ability1
        copiedCharacter.ability2 = ability2
        copiedCharacter.ability3 = ability3
        copiedCharacter.ability4 = ability4

        copiedCharacter.supportDataPointer = supportDataPointer

        copiedCharacter.shouldResetCustomSpriteToDefault = shouldResetCustomSpriteToDefault

        copiedCharacter.displayName = displayName
        copiedCharacter.classDisplayName = classDisplayName
        copiedCharacter.gameType = gameType

        Return copiedCharacter
    End Function

    Enum Affinity
        AffinityNone = &H0
        AffinityFire = &H1
        AffinityThunder = &H2
        AffinityWind = &H3
        AffinityIce = &H4
        AffinityDark = &H5
        AffinityLight = &H6
        AffinityAnima = &H7
    End Enum

    Public Sub initializeWithBytesFromOffset(ByRef filePtr As IO.FileStream, ByVal offset As Integer, ByVal entrySize As Integer, ByVal gt As Utilities.GameType, ByRef textManager As TextManager, ByRef classLookup As Hashtable)
        gameType = gt

        filePtr.Seek(offset, IO.SeekOrigin.Begin)
        nameIndex = Utilities.ReadHalfWord(filePtr)
        displayName = textManager.stringForTextAtIndex(nameIndex)

        bioIndex = Utilities.ReadHalfWord(filePtr)

        characterId = filePtr.ReadByte()
        classId = filePtr.ReadByte()
        Dim charClass As FEClass = classLookup.Item(classId)
        If Not IsNothing(charClass) Then
            classDisplayName = charClass.classDisplayName
        Else
            classDisplayName = "???"
        End If

        portraitIndex = filePtr.ReadByte()

        filePtr.Seek(offset + 9, IO.SeekOrigin.Begin)
        characterAffinity = filePtr.ReadByte()

        filePtr.Seek(offset + 11, IO.SeekOrigin.Begin)
        level = filePtr.ReadByte()
        baseHP = Utilities.signedByteFromByte(filePtr.ReadByte())
        baseStr = Utilities.signedByteFromByte(filePtr.ReadByte())
        baseSkl = Utilities.signedByteFromByte(filePtr.ReadByte())
        baseSpd = Utilities.signedByteFromByte(filePtr.ReadByte())
        baseDef = Utilities.signedByteFromByte(filePtr.ReadByte())
        baseRes = Utilities.signedByteFromByte(filePtr.ReadByte())
        baseLck = Utilities.signedByteFromByte(filePtr.ReadByte())
        baseCon = Utilities.signedByteFromByte(filePtr.ReadByte())

        swordLevel = filePtr.ReadByte()
        spearLevel = filePtr.ReadByte()
        axeLevel = filePtr.ReadByte()
        bowLevel = filePtr.ReadByte()
        staffLevel = filePtr.ReadByte()
        animaLevel = filePtr.ReadByte()
        lightLevel = filePtr.ReadByte()
        darkLevel = filePtr.ReadByte()

        hpGrowth = filePtr.ReadByte()
        strGrowth = filePtr.ReadByte()
        sklGrowth = filePtr.ReadByte()
        spdGrowth = filePtr.ReadByte()
        defGrowth = filePtr.ReadByte()
        resGrowth = filePtr.ReadByte()
        lckGrowth = filePtr.ReadByte()

        If gameType <> Utilities.GameType.GameTypeFE8 Then
            paletteIndex = filePtr.ReadByte()
            promotedPaletteIndex = filePtr.ReadByte()

            ' Use the promoted one if the unpromoted one is nil
            If paletteIndex = 0 Then paletteIndex = promotedPaletteIndex
        End If

        If gameType = Utilities.GameType.GameTypeFE7 Then
            customUnpromotedSprite = filePtr.ReadByte()
            customPromotedSprite = filePtr.ReadByte()
        End If

        filePtr.Seek(offset + 40, IO.SeekOrigin.Begin)

        ability1 = filePtr.ReadByte()
        ability2 = filePtr.ReadByte()
        ability3 = filePtr.ReadByte()
        ability4 = filePtr.ReadByte()

        supportDataPointer = Utilities.ReadWord(filePtr, False)

        filePtr.Seek(offset + entrySize, IO.SeekOrigin.Begin)

        shouldResetCustomSpriteToDefault = False


    End Sub

    Public Sub writeStatsToCharacterStartingAtOffset(ByRef filePtr As IO.FileStream, ByVal offset As Integer, ByVal entrySize As Integer, ByVal gameType As Utilities.GameType)

        DebugLogger.logMessage("[FECharacter (" & Hex(characterId) & ")] - Wrote Address 0x" & Hex(offset) & " to 0x" & Hex(offset + entrySize))

        filePtr.Seek(offset, IO.SeekOrigin.Begin)
        Utilities.WriteHalfWord(filePtr, nameIndex)
        Utilities.WriteHalfWord(filePtr, bioIndex)

        filePtr.WriteByte(characterId)
        filePtr.WriteByte(classId)

        filePtr.WriteByte(portraitIndex)

        filePtr.Seek(offset + 9, IO.SeekOrigin.Begin)
        filePtr.WriteByte(characterAffinity)

        filePtr.Seek(offset + 11, IO.SeekOrigin.Begin)
        filePtr.WriteByte(level)
        filePtr.WriteByte(Utilities.unsignedByteFromSignedByte(baseHP))
        filePtr.WriteByte(Utilities.unsignedByteFromSignedByte(baseStr))
        filePtr.WriteByte(Utilities.unsignedByteFromSignedByte(baseSkl))
        filePtr.WriteByte(Utilities.unsignedByteFromSignedByte(baseSpd))
        filePtr.WriteByte(Utilities.unsignedByteFromSignedByte(baseDef))
        filePtr.WriteByte(Utilities.unsignedByteFromSignedByte(baseRes))
        filePtr.WriteByte(Utilities.unsignedByteFromSignedByte(baseLck))
        filePtr.WriteByte(Convert.ToByte(IIf(baseCon < 0, baseCon + 256, baseCon)))

        filePtr.WriteByte(swordLevel)
        filePtr.WriteByte(spearLevel)
        filePtr.WriteByte(axeLevel)
        filePtr.WriteByte(bowLevel)
        filePtr.WriteByte(staffLevel)
        filePtr.WriteByte(animaLevel)
        filePtr.WriteByte(lightLevel)
        filePtr.WriteByte(darkLevel)

        filePtr.WriteByte(hpGrowth)
        filePtr.WriteByte(strGrowth)
        filePtr.WriteByte(sklGrowth)
        filePtr.WriteByte(spdGrowth)
        filePtr.WriteByte(defGrowth)
        filePtr.WriteByte(resGrowth)
        filePtr.WriteByte(lckGrowth)

        If gameType <> Utilities.GameType.GameTypeFE8 Then
            filePtr.WriteByte(paletteIndex)
            filePtr.WriteByte(promotedPaletteIndex)
        End If

        If gameType = Utilities.GameType.GameTypeFE7 Then
            If Not shouldResetCustomSpriteToDefault Then
                filePtr.WriteByte(customUnpromotedSprite)
                filePtr.WriteByte(customPromotedSprite)
            Else
                filePtr.WriteByte(0)
                filePtr.WriteByte(0)
            End If
        End If

        filePtr.Seek(offset + 40, IO.SeekOrigin.Begin)
        filePtr.WriteByte(ability1)
        filePtr.WriteByte(ability2)
        filePtr.WriteByte(ability3)
        filePtr.WriteByte(ability4)

        Utilities.WriteWord(filePtr, supportDataPointer)

        filePtr.Seek(offset + entrySize, IO.SeekOrigin.Begin)
    End Sub

    Public Function totalGrowths() As Integer
        Dim hpInt As Integer = hpGrowth
        Dim strInt As Integer = strGrowth
        Dim sklInt As Integer = sklGrowth
        Dim spdInt As Integer = spdGrowth
        Dim lckInt As Integer = lckGrowth
        Dim defInt As Integer = defGrowth
        Dim resInt As Integer = resGrowth
        Return hpInt + strInt + sklInt + spdInt + lckInt + defInt + resInt
    End Function

    Public Sub resetGrowths()
        hpGrowth = 0
        strGrowth = 0
        sklGrowth = 0
        spdGrowth = 0
        lckGrowth = 0
        defGrowth = 0
        resGrowth = 0
    End Sub

    Public Function totalBases() As Integer
        Dim hpInt As Integer = baseHP
        Dim strInt As Integer = baseStr
        Dim sklInt As Integer = baseSkl
        Dim spdInt As Integer = baseSpd
        Dim lckInt As Integer = baseLck
        Dim defInt As Integer = baseDef
        Dim resInt As Integer = baseRes
        Return hpInt + strInt + sklInt + spdInt + lckInt + defInt + resInt
    End Function

    Public Sub resetBases()
        baseHP = 0
        baseStr = 0
        baseSkl = 0
        baseSpd = 0
        baseLck = 0
        baseDef = 0
        baseRes = 0
    End Sub

    Public Function resolvedAffinity() As String
        If characterAffinity = Affinity.AffinityFire Then Return "Fire"
        If characterAffinity = Affinity.AffinityThunder Then Return "Thunder"
        If characterAffinity = Affinity.AffinityWind Then Return "Wind"
        If characterAffinity = Affinity.AffinityIce Then Return "Ice"
        If characterAffinity = Affinity.AffinityDark Then Return "Dark"
        If characterAffinity = Affinity.AffinityLight Then Return "Light"
        If characterAffinity = Affinity.AffinityAnima Then Return "Anima"

        Return "None"
    End Function

    Public Sub updateClassWithClass(ByRef classObject As FEClass, ByRef rng As Random)
        ' Don't need to do anything if our class id hasn't changed.
        If classId = classObject.classId Then
            Return
        End If

        classId = classObject.classId
        classDisplayName = classObject.classDisplayName

        ' Update weapon levels here.
        Dim noRank As Byte = 0
        Dim eRank As Byte
        Dim dRank As Byte
        Dim cRank As Byte
        Dim bRank As Byte
        Dim aRank As Byte
        Dim sRank As Byte

        setupWeaponRanksForGameType(gameType, noRank, eRank, dRank, cRank, bRank, aRank, sRank)

        Dim highestRank As Byte = Math.Max(swordLevel, Math.Max(spearLevel, Math.Max(axeLevel, Math.Max(bowLevel, Math.Max(lightLevel, Math.Max(darkLevel, Math.Max(animaLevel, staffLevel)))))))

        swordLevel = classObject.swordLevel
        spearLevel = classObject.spearLevel
        axeLevel = classObject.axeLevel
        bowLevel = classObject.bowLevel
        animaLevel = classObject.animaLevel
        lightLevel = classObject.lightLevel
        darkLevel = classObject.darkLevel
        staffLevel = classObject.staffLevel

        If highestRank = noRank Then
            Return
        End If

        ' Carry over the highest rank to one of their valid new ranks and leave the rest the same.
        Dim canIncreaseSwordRank As Boolean = swordLevel > noRank And swordLevel < highestRank
        Dim canIncreaseLanceRank As Boolean = spearLevel > noRank And spearLevel < highestRank
        Dim canIncreaseAxeRank As Boolean = axeLevel > noRank And axeLevel < highestRank
        Dim canIncreaseBowRank As Boolean = bowLevel > noRank And bowLevel < highestRank
        Dim canIncreaseLightRank As Boolean = lightLevel > noRank And lightLevel < highestRank
        Dim canIncreaseDarkRank As Boolean = darkLevel > noRank And darkLevel < highestRank
        Dim canIncreaseAnimaRank As Boolean = animaLevel > noRank And animaLevel < highestRank
        Dim canIncreaseStaffRank As Boolean = staffLevel > noRank And staffLevel < highestRank

        If Not canIncreaseSwordRank And Not canIncreaseLanceRank And Not canIncreaseAxeRank And Not canIncreaseBowRank And Not canIncreaseLightRank And Not canIncreaseDarkRank And Not canIncreaseAnimaRank And Not canIncreaseStaffRank Then
            Return
        End If

        Dim assigned As Boolean = False
        While Not assigned
            Dim i As Integer = rng.Next(8)
            If i = 0 And canIncreaseSwordRank Then
                swordLevel = highestRank
                assigned = True
            ElseIf i = 1 And canIncreaseLanceRank Then
                spearLevel = highestRank
                assigned = True
            ElseIf i = 2 And canIncreaseAxeRank Then
                axeLevel = highestRank
                assigned = True
            ElseIf i = 3 And canIncreaseBowRank Then
                bowLevel = highestRank
                assigned = True
            ElseIf i = 4 And canIncreaseLightRank Then
                lightLevel = highestRank
                assigned = True
            ElseIf i = 5 And canIncreaseDarkRank
                darkLevel = highestRank
                assigned = True
            ElseIf i = 6 And canIncreaseAnimaRank Then
                animaLevel = highestRank
                assigned = True
            ElseIf i = 7 And canIncreaseStaffRank Then
                staffLevel = highestRank
                assigned = True
            End If
        End While

    End Sub

    Public Sub randomizeBases(ByVal variance As Integer, ByRef rng As Random)
        Dim total = totalBases()

        resetBases()

        If variance > 0 Then
            total += rng.Next(0, variance * 2) - variance
        End If

        While total > 0
            ' Figure out which stat. We have HP, STR, SKL, SPD, DEF, RES, and LCK.
            Dim stat = rng.Next(1, 8)
            If stat = 1 Then
                ' HP Should get up to 5 on a hit
                Dim amount = rng.Next(1, Math.Min(6, total + 1))
                baseHP += amount
                total -= amount
            ElseIf stat < 5 Then
                ' STR, SPD, DEF should get up to 2 on a hit
                Dim amount = rng.Next(1, Math.Min(3, total + 1))
                If stat = 2 Then baseStr += amount
                If stat = 3 Then baseSpd += amount
                If stat = 4 Then baseDef += amount
                total -= amount
            ElseIf stat < 7 Then
                ' SKL, RES should get up to 3 on a hit
                Dim amount = rng.Next(1, Math.Min(4, total + 1))
                If stat = 5 Then baseSkl += amount
                If stat = 6 Then baseRes += amount
                total -= amount
            Else
                ' LCK should get up to 4 on a hit
                Dim amount = rng.Next(1, Math.Min(5, total + 1))
                baseLck += amount
                total -= amount
            End If

        End While
    End Sub

    Public Sub randomizeCON(ByVal minimumCON As Integer, ByRef variance As Integer, ByRef charClass As FEClass, ByRef rng As Random)
        If IsNothing(charClass) Or variance <= 0 Then Return

        Dim adjustment = rng.Next(0, variance * 2) - variance
        baseCon += adjustment
        If baseCon + charClass.baseCon < minimumCON Then
            baseCon = minimumCON - charClass.baseCon
        End If
    End Sub

    Public Sub randomizeGrowths(ByVal variance As Integer, ByVal useMinimumGrowth As Boolean, ByVal weightHPGrowth As Boolean, ByRef rng As Random)

        Dim total = totalGrowths()

        resetGrowths()

        If variance > 0 Then
            total += rng.Next(0, variance * 2) - variance
            If total Mod 5 <> 0 Then
                ' Round to nearest increment of 5 if not already an increment of 5.
                total += (5 - total Mod 5)
            End If
        End If

        If useMinimumGrowth Then
            hpGrowth = 5
            strGrowth = 5
            sklGrowth = 5
            spdGrowth = 5
            lckGrowth = 5
            defGrowth = 5
            resGrowth = 5

            total -= 7 * 5
        End If

        While total > 0
            ' Figure out which stat. Again, 7 stats.
            Dim stat = rng.Next(1, 8)
            Dim amount = Math.Min(rng.Next(1, 11) * 5, total)
            If stat = 1 And hpGrowth <= 255 - amount Then
                hpGrowth += amount
                total -= amount
                If weightHPGrowth And total >= 10 And hpGrowth <= 245 Then
                    hpGrowth += 10
                    total -= 10
                End If
            ElseIf stat = 2 And strGrowth <= 255 - amount Then
                strGrowth += amount
                total -= amount
            ElseIf stat = 3 And sklGrowth <= 255 - amount Then
                sklGrowth += amount
                total -= amount
            ElseIf stat = 4 And spdGrowth <= 255 - amount Then
                spdGrowth += amount
                total -= amount
            ElseIf stat = 5 And defGrowth <= 255 - amount Then
                defGrowth += amount
                total -= amount
            ElseIf stat = 6 And resGrowth <= 255 - amount Then
                resGrowth += amount
                total -= amount
            ElseIf stat = 7 And lckGrowth <= 255 - amount Then
                lckGrowth += amount
                total -= amount
            Else
                Exit While ' Should happen, but if we've maxed everything, stop.
            End If

        End While

    End Sub

    Public Sub randomizeAffinity(ByRef rng As Random)
        Dim newAffinity = rng.Next(1, 8)
        characterAffinity = newAffinity
    End Sub

    Public Sub setupWeaponRanksForGameType(ByVal type As Utilities.GameType, ByRef noRank As Byte, ByRef eRank As Byte, ByRef dRank As Byte, ByRef cRank As Byte, ByRef bRank As Byte, ByRef aRank As Byte, ByRef sRank As Byte)
        If type = Utilities.GameType.GameTypeFE6 Then
            noRank = FE6GameData.WeaponRank.WeaponRankNone
            eRank = FE6GameData.WeaponRank.WeaponRankE
            dRank = FE6GameData.WeaponRank.WeaponRankD
            cRank = FE6GameData.WeaponRank.WeaponRankC
            bRank = FE6GameData.WeaponRank.WeaponRankB
            aRank = FE6GameData.WeaponRank.WeaponRankA
            sRank = FE6GameData.WeaponRank.WeaponRankS
        ElseIf type = Utilities.GameType.GameTypeFE7 Then
            noRank = FE7GameData.WeaponRank.WeaponRankNone
            eRank = FE7GameData.WeaponRank.WeaponRankE
            dRank = FE7GameData.WeaponRank.WeaponRankD
            cRank = FE7GameData.WeaponRank.WeaponRankC
            bRank = FE7GameData.WeaponRank.WeaponRankB
            aRank = FE7GameData.WeaponRank.WeaponRankA
            sRank = FE7GameData.WeaponRank.WeaponRankS
        ElseIf type = Utilities.GameType.GameTypeFE8 Then
            noRank = FE8GameData.WeaponRank.WeaponRankNone
            eRank = FE8GameData.WeaponRank.WeaponRankE
            dRank = FE8GameData.WeaponRank.WeaponRankD
            cRank = FE8GameData.WeaponRank.WeaponRankC
            bRank = FE8GameData.WeaponRank.WeaponRankB
            aRank = FE8GameData.WeaponRank.WeaponRankA
            sRank = FE8GameData.WeaponRank.WeaponRankS
        End If
    End Sub

    Public Sub buffHPWithAdditionalLevelsAtRate(ByVal numberOfLevels As Integer, ByVal growth As Integer, ByVal maxValue As Integer, ByRef rng As Random)
        If numberOfLevels > 0 And growth > 0 And Not IsNothing(rng) Then
            For i As Integer = 1 To numberOfLevels
                Dim shouldIncrease As Boolean = rng.Next(100) < growth
                If shouldIncrease Then
                    If maxValue > 0 And baseHP < maxValue Then
                        baseHP = baseHP + 1
                    End If
                End If
            Next
        End If
    End Sub

    Public Sub buffStrWithAdditionalLevelsAtRate(ByVal numberOfLevels As Integer, ByVal growth As Integer, ByVal maxValue As Integer, ByRef rng As Random)
        If numberOfLevels > 0 And growth > 0 And Not IsNothing(rng) Then
            For i As Integer = 1 To numberOfLevels
                Dim shouldIncrease As Boolean = rng.Next(100) < growth
                If shouldIncrease Then
                    If maxValue > 0 And baseStr < maxValue Then
                        baseStr = baseStr + 1
                    End If
                End If
            Next
        End If
    End Sub

    Public Sub buffSklWithAdditionalLevelsAtRate(ByVal numberOfLevels As Integer, ByVal growth As Integer, ByVal maxValue As Integer, ByRef rng As Random)
        If numberOfLevels > 0 And growth > 0 And Not IsNothing(rng) Then
            For i As Integer = 1 To numberOfLevels
                Dim shouldIncrease As Boolean = rng.Next(100) < growth
                If shouldIncrease Then
                    If maxValue > 0 And baseSkl < maxValue Then
                        baseSkl = baseSkl + 1
                    End If
                End If
            Next
        End If
    End Sub

    Public Sub buffSpdWithAdditionalLevelsAtRate(ByVal numberOfLevels As Integer, ByVal growth As Integer, ByVal maxValue As Integer, ByRef rng As Random)
        If numberOfLevels > 0 And growth > 0 And Not IsNothing(rng) Then
            For i As Integer = 1 To numberOfLevels
                Dim shouldIncrease As Boolean = rng.Next(100) < growth
                If shouldIncrease Then
                    If maxValue > 0 And baseSpd < maxValue Then
                        baseSpd = baseSpd + 1
                    End If
                End If
            Next
        End If
    End Sub

    Public Sub buffLckWithAdditionalLevelsAtRate(ByVal numberOfLevels As Integer, ByVal growth As Integer, ByVal maxValue As Integer, ByRef rng As Random)
        If numberOfLevels > 0 And growth > 0 And Not IsNothing(rng) Then
            For i As Integer = 1 To numberOfLevels
                Dim shouldIncrease As Boolean = rng.Next(100) < growth
                If shouldIncrease Then
                    If maxValue > 0 And baseLck < maxValue Then
                        baseLck = baseLck + 1
                    End If
                End If
            Next
        End If
    End Sub

    Public Sub buffDefWithAdditionalLevelsAtRate(ByVal numberOfLevels As Integer, ByVal growth As Integer, ByVal maxValue As Integer, ByRef rng As Random)
        If numberOfLevels > 0 And growth > 0 And Not IsNothing(rng) Then
            For i As Integer = 1 To numberOfLevels
                Dim shouldIncrease As Boolean = rng.Next(100) < growth
                If shouldIncrease Then
                    If maxValue > 0 And baseDef < maxValue Then
                        baseDef = baseDef + 1
                    End If
                End If
            Next
        End If
    End Sub

    Public Sub buffResWithAdditionalLevelsAtRate(ByVal numberOfLevels As Integer, ByVal growth As Integer, ByVal maxValue As Integer, ByRef rng As Random)
        If numberOfLevels > 0 And growth > 0 And Not IsNothing(rng) Then
            For i As Integer = 1 To numberOfLevels
                Dim shouldIncrease As Boolean = rng.Next(100) < growth
                If shouldIncrease Then
                    If maxValue > 0 And baseRes < maxValue Then
                        baseRes = baseRes + 1
                    End If
                End If
            Next
        End If
    End Sub

    Public Sub levelWithClass(ByRef targetClass As FEClass, ByVal levelsToShift As Integer, ByVal delevel As Boolean, ByRef rng As Random)
        If Not IsNothing(targetClass) And levelsToShift > 0 Then
            For i As Integer = 1 To levelsToShift
                Dim growth As Integer

                growth = hpGrowth
                While growth >= 100
                    baseHP = IIf(delevel, baseHP - 1, baseHP + 1)
                    growth = growth - 100
                End While
                If growth > 0 Then
                    Dim shouldShift As Boolean = rng.Next(0, 100) < growth
                    If shouldShift Then
                        baseHP = IIf(delevel, baseHP - 1, baseHP + 1)
                    End If
                End If

                growth = strGrowth
                While growth >= 100
                    baseStr = IIf(delevel, baseStr - 1, baseStr + 1)
                    growth = growth - 100
                End While
                If growth > 0 Then
                    Dim shouldShift As Boolean = rng.Next(0, 100) < growth
                    If shouldShift Then
                        baseStr = IIf(delevel, baseStr - 1, baseStr + 1)
                    End If
                End If

                growth = sklGrowth
                While growth >= 100
                    baseSkl = IIf(delevel, baseSkl - 1, baseSkl + 1)
                    growth = growth - 100
                End While
                If growth > 0 Then
                    Dim shouldShift As Boolean = rng.Next(0, 100) < growth
                    If shouldShift Then
                        baseSkl = IIf(delevel, baseSkl - 1, baseSkl + 1)
                    End If
                End If

                growth = spdGrowth
                While growth >= 100
                    baseSpd = IIf(delevel, baseSpd - 1, baseSpd + 1)
                    growth = growth - 100
                End While
                If growth > 0 Then
                    Dim shouldShift As Boolean = rng.Next(0, 100) < growth
                    If shouldShift Then
                        baseSpd = IIf(delevel, baseSpd - 1, baseSpd + 1)
                    End If
                End If

                growth = lckGrowth
                While growth >= 100
                    baseLck = IIf(delevel, baseLck - 1, baseLck + 1)
                    growth = growth - 100
                End While
                If growth > 0 Then
                    Dim shouldShift As Boolean = rng.Next(0, 100) < growth
                    If shouldShift Then
                        baseLck = IIf(delevel, baseLck - 1, baseLck + 1)
                    End If
                End If

                growth = defGrowth
                While growth >= 100
                    baseDef = IIf(delevel, baseDef - 1, baseDef + 1)
                    growth = growth - 100
                End While
                If growth > 0 Then
                    Dim shouldShift As Boolean = rng.Next(0, 100) < growth
                    If shouldShift Then
                        baseDef = IIf(delevel, baseDef - 1, baseDef + 1)
                    End If
                End If
                growth = resGrowth
                While growth >= 100
                    baseRes = IIf(delevel, baseRes - 1, baseRes + 1)
                    growth = growth - 100
                End While
                If growth > 0 Then
                    Dim shouldShift As Boolean = rng.Next(0, 100) < growth
                    If shouldShift Then
                        baseRes = IIf(delevel, baseRes - 1, baseRes + 1)
                    End If
                End If
            Next

            ' Make sure we're still in line with valid values (no negative stats and
            ' no stats that exceed stat caps)
            ' Since our delevel is more harsh than leveling, apply a baseline of stats so that we don't get completely screwed.
            baseHP = Convert.ToSByte(clampBaseStatWithClassBaseAndCap(Convert.ToInt16(targetClass.baseHP), 8, Convert.ToInt16(targetClass.hpCap), baseHP))
            baseStr = Convert.ToSByte(clampBaseStatWithClassBaseAndCap(Convert.ToInt16(targetClass.baseStr), 2, Convert.ToInt16(targetClass.strCap), baseStr))
            baseSkl = Convert.ToSByte(clampBaseStatWithClassBaseAndCap(Convert.ToInt16(targetClass.baseSkl), 5, Convert.ToInt16(targetClass.sklCap), baseSkl))
            baseSpd = Convert.ToSByte(clampBaseStatWithClassBaseAndCap(Convert.ToInt16(targetClass.baseSpd), 0, Convert.ToInt16(targetClass.spdCap), baseSpd))
            ' Lck has no class base and a universal cap of 30.
            baseLck = Convert.ToSByte(clampBaseStatWithClassBaseAndCap(0, 0, 30, baseLck))
            baseDef = Convert.ToSByte(clampBaseStatWithClassBaseAndCap(Convert.ToInt16(targetClass.baseDef), 0, Convert.ToInt16(targetClass.defCap), baseDef))
            baseRes = Convert.ToSByte(clampBaseStatWithClassBaseAndCap(Convert.ToInt16(targetClass.baseRes), 0, Convert.ToInt16(targetClass.resCap), baseRes))

        End If
    End Sub

    Public Sub validate(ByVal characterClass As FEClass, ByVal minCON As Integer, ByVal gameType As Utilities.GameType)
        baseHP = Convert.ToSByte(clampBaseStatWithClassBaseAndCap(Convert.ToInt16(characterClass.baseHP), 8, Convert.ToInt16(characterClass.hpCap), baseHP))
        baseStr = Convert.ToSByte(clampBaseStatWithClassBaseAndCap(Convert.ToInt16(characterClass.baseStr), 2, Convert.ToInt16(characterClass.strCap), baseStr))
        baseSkl = Convert.ToSByte(clampBaseStatWithClassBaseAndCap(Convert.ToInt16(characterClass.baseSkl), 5, Convert.ToInt16(characterClass.sklCap), baseSkl))
        baseSpd = Convert.ToSByte(clampBaseStatWithClassBaseAndCap(Convert.ToInt16(characterClass.baseSpd), 0, Convert.ToInt16(characterClass.spdCap), baseSpd))
        ' Lck has no class base and a universal cap of 30.
        baseLck = Convert.ToSByte(clampBaseStatWithClassBaseAndCap(0, 0, 30, baseLck))
        baseDef = Convert.ToSByte(clampBaseStatWithClassBaseAndCap(Convert.ToInt16(characterClass.baseDef), 0, Convert.ToInt16(characterClass.defCap), baseDef))
        baseRes = Convert.ToSByte(clampBaseStatWithClassBaseAndCap(Convert.ToInt16(characterClass.baseRes), 0, Convert.ToInt16(characterClass.resCap), baseRes))

        baseCon = Convert.ToSByte(clampBaseStatWithClassBaseAndCap(Convert.ToInt16(characterClass.baseCon), minCON, Convert.ToInt16(characterClass.conCap), baseCon))

        Dim noRank As Byte = 0
        Dim eRank As Byte
        Dim dRank As Byte
        Dim cRank As Byte
        Dim bRank As Byte
        Dim aRank As Byte
        Dim sRank As Byte

        setupWeaponRanksForGameType(gameType, noRank, eRank, dRank, cRank, bRank, aRank, sRank)

        If characterClass.swordLevel = noRank Then swordLevel = noRank
        If characterClass.spearLevel = noRank Then spearLevel = noRank
        If characterClass.axeLevel = noRank Then axeLevel = noRank
        If characterClass.staffLevel = noRank Then staffLevel = noRank
        If characterClass.bowLevel = noRank Then bowLevel = noRank
        If characterClass.animaLevel = noRank Then animaLevel = noRank
        If characterClass.darkLevel = noRank Then darkLevel = noRank
        If characterClass.lightLevel = noRank Then lightLevel = noRank

    End Sub

    Private Function clampBaseStatWithClassBaseAndCap(ByVal classBase As Short, ByVal minimumValue As Short, ByVal classCap As Short, ByVal proposedBase As Short) As Short
        If classBase + proposedBase < minimumValue Then
            Return minimumValue - classBase
        ElseIf classBase + proposedBase > classCap Then
            Return classCap - classBase
        Else
            Return proposedBase
        End If
    End Function

    Private Function weaponRankLetterForValue(ByVal rankValue As Byte) As String
        Dim noRank As Byte = 0
        Dim eRank As Byte
        Dim dRank As Byte
        Dim cRank As Byte
        Dim bRank As Byte
        Dim aRank As Byte
        Dim sRank As Byte

        setupWeaponRanksForGameType(gameType, noRank, eRank, dRank, cRank, bRank, aRank, sRank)

        If rankValue = noRank Then Return ""
        If rankValue = eRank Then Return "E"
        If rankValue = dRank Then Return "D"
        If rankValue = cRank Then Return "C"
        If rankValue = bRank Then Return "B"
        If rankValue = aRank Then Return "A"
        If rankValue = sRank Then Return "S"

        Return ""

    End Function

    Private Function stringForCharacterAbility1() As String
        If ability1 = 0 Then Return "None"

        Dim ability1String As String = "[0x" + Hex(ability1) + "]"

        Dim isMountedAid As Boolean = (ability1 And CharacterAbility1.MountedAidSystem) <> 0
        Dim canMoveAgain As Boolean = (ability1 And CharacterAbility1.MoveAgain) <> 0
        Dim canSteal As Boolean = (ability1 And CharacterAbility1.Steal) <> 0
        Dim canUseLockpicks As Boolean = (ability1 And CharacterAbility1.ThiefKey) <> 0
        Dim canDance As Boolean = (ability1 And CharacterAbility1.Dance) <> 0
        Dim canPlay As Boolean = (ability1 And CharacterAbility1.Play) <> 0
        Dim hasCriticalBoost As Boolean = (ability1 And CharacterAbility1.CriticalBoost) <> 0
        Dim canUseBallistas As Boolean = (ability1 And CharacterAbility1.Ballista) <> 0

        If isMountedAid Then ability1String = ability1String + vbCrLf + vbTab + "Uses Mounted Aid System"
        If canMoveAgain Then ability1String = ability1String + vbCrLf + vbTab + "Can Move Again"
        If canSteal Then ability1String = ability1String + vbCrLf + vbTab + "Can Steal"
        If canUseLockpicks Then ability1String = ability1String + vbCrLf + vbTab + "Can Use Lockpicks"
        If canDance Then ability1String = ability1String + vbCrLf + vbTab + "Can Dance"
        If canPlay Then ability1String = ability1String + vbCrLf + vbTab + "Can Play"
        If hasCriticalBoost Then ability1String = ability1String + vbCrLf + vbTab + IIf(gameType = Utilities.GameType.GameTypeFE6, "+30", "+15") + " Critical"
        If canUseBallistas Then ability1String = ability1String + vbCrLf + vbTab + "Can use Ballistas"

        Return ability1String
    End Function

    Private Function stringForCharacterAbility2() As String
        If ability2 = 0 Then Return "None"

        Dim ability2String As String = "[0x" + Hex(ability2) + "]"

        Dim isPromoted As Boolean = (ability2 And CharacterAbility2.Promoted) <> 0
        Dim isSupplyDepot As Boolean = (ability2 And CharacterAbility2.SupplyDepot) <> 0
        Dim showsHorse As Boolean = (ability2 And CharacterAbility2.ShowHorseIcon) <> 0
        Dim showsDragon As Boolean = (ability2 And CharacterAbility2.ShowDragonIcon) <> 0
        Dim showsPegasus As Boolean = (ability2 And CharacterAbility2.ShowPegasusIcon) <> 0
        Dim isLord As Boolean = (ability2 And CharacterAbility2.Lord) <> 0
        Dim isFemale As Boolean = (ability2 And CharacterAbility2.Female) <> 0
        Dim isBoss As Boolean = (ability2 And CharacterAbility2.Boss) <> 0

        If isPromoted Then ability2String = ability2String + vbCrLf + vbTab + "Is Promoted"
        If isSupplyDepot Then ability2String = ability2String + vbCrLf + vbTab + "Acts As Convoy"
        If showsHorse Then ability2String = ability2String + vbCrLf + vbTab + "Shows Horse Icon"
        If showsDragon Then ability2String = ability2String + vbCrLf + vbTab + "Shows Dragon Icon"
        If showsPegasus Then ability2String = ability2String + vbCrLf + vbTab + "Shows Pegasus Icon"
        If isLord Then ability2String = ability2String + vbCrLf + vbTab + "Is Lord"
        If isFemale Then ability2String = ability2String + vbCrLf + vbTab + "Is Female"
        If isBoss Then ability2String = ability2String + vbCrLf + vbTab + "Is Boss"

        Return ability2String
    End Function

    Private Function stringForCharacterAbility3() As String
        If ability3 = 0 Then Return "None"

        Dim ability3String As String = "[0x" + Hex(ability3) + "]"

        Dim canUseLordWeapons As Boolean = (ability3 And CharacterAbility3.LordPrfWeaponLock) <> 0
        Dim canUseWoDao As Boolean = (ability3 And CharacterAbility3.WoDaoWeaponLock) <> 0
        Dim canUseDragonstone As Boolean = (ability3 And CharacterAbility3.DragonstoneLock) <> 0
        Dim morphsMaxLevel10 As Boolean = (ability3 And CharacterAbility3.MorphsMaxLevel10) <> 0
        Dim isUncontrollable As Boolean = (ability3 And CharacterAbility3.Uncontrollable) <> 0
        Dim pkTriangle As Boolean = (ability3 And CharacterAbility3.PegasusKnightTriangle) <> 0
        Dim akTriangle As Boolean = (ability3 And CharacterAbility3.ArmorKnightTriangle) <> 0
        Dim isNPC As Boolean = (ability3 And CharacterAbility3.StartsAsNPC) <> 0

        If canUseLordWeapons Then ability3String = ability3String + vbCrLf + vbTab + IIf(gameType = Utilities.GameType.GameTypeFE6, "Can Use Lord Weapons", "Unused Weapon Lock")
        If canUseWoDao Then ability3String = ability3String + vbCrLf + vbTab + IIf(gameType = Utilities.GameType.GameTypeFE8, "Can Use Shamshir", "Can Use Wo Dao")
        If canUseDragonstone Then ability3String = ability3String + vbCrLf + vbTab + "Can Use Dragonstone"
        If morphsMaxLevel10 Then ability3String = ability3String + vbCrLf + vbTab + IIf(gameType = Utilities.GameType.GameTypeFE7, "Is Morph (including Boss Vaida)", IIf(gameType = Utilities.GameType.GameTypeFE8, "Max Level 10", "Unknown"))
        If isUncontrollable Then ability3String = ability3String + vbCrLf + vbTab + IIf(gameType = Utilities.GameType.GameTypeFE6, "Unknown", "Uncontrollable")
        If pkTriangle Then ability3String = ability3String + vbCrLf + vbTab + "Pegasus Knight Triangle Attack"
        If akTriangle Then ability3String = ability3String + vbCrLf + vbTab + IIf(gameType = Utilities.GameType.GameTypeFE6, "Armor Knight Triangle Attack", "Unused Triangle Attack")
        If isNPC Then ability3String = ability3String + vbCrLf + vbTab + IIf(gameType = Utilities.GameType.GameTypeFE6, "Starts as NPC", "Unknown")

        Return ability3String
    End Function

    Private Function stringForCharacterAbility4() As String
        If ability4 = 0 Or gameType = Utilities.GameType.GameTypeFE6 Then Return "None"

        Dim ability4String As String = "[0x" + Hex(ability4) + "]"

        Dim givesNoExperience As Boolean = (ability4 And CharacterAbility4.NoExperience) <> 0
        Dim canTriggerLethality As Boolean = (ability4 And CharacterAbility4.Lethality) <> 0
        Dim isMagicSeal As Boolean = (ability4 And CharacterAbility4.SealsMagic) <> 0
        Dim dropOrSummon As Boolean = (ability4 And CharacterAbility4.DropsLastItemOrSummon) <> 0
        Dim eliwoodEirika As Boolean = (ability4 And CharacterAbility4.EliwoodEirikaWeaponLock) <> 0
        Dim hectorEphraim As Boolean = (ability4 And CharacterAbility4.HectorEphraimWeaponLock) <> 0
        Dim lynLock As Boolean = (ability4 And CharacterAbility4.LynWeaponLock) <> 0
        Dim athosLock As Boolean = (ability4 And CharacterAbility4.AthosWeaponLock) <> 0

        If givesNoExperience Then ability4String = ability4String + vbCrLf + vbTab + "Gives No Experience"
        If canTriggerLethality Then ability4String = ability4String + vbCrLf + vbTab + "Can Trigger Lethality"
        If isMagicSeal Then ability4String = ability4String + vbCrLf + vbTab + IIf(gameType = Utilities.GameType.GameTypeFE7, "Is Magic Seal", "Unknown")
        If dropOrSummon Then ability4String = ability4String + vbCrLf + vbTab + IIf(gameType = Utilities.GameType.GameTypeFE7, "Drops Last Item", "Is Summon")
        If eliwoodEirika Then ability4String = ability4String + vbCrLf + vbTab + IIf(gameType = Utilities.GameType.GameTypeFE7, "Can Use Eliwood Locked Weapons", "Can Use Eirika Locked Weapons")
        If hectorEphraim Then ability4String = ability4String + vbCrLf + vbTab + IIf(gameType = Utilities.GameType.GameTypeFE7, "Can Use Hector Locked Weapons", "Can Use Ephraim Locked Weapons")
        If lynLock Then ability4String = ability4String + vbCrLf + vbTab + IIf(gameType = Utilities.GameType.GameTypeFE7, "Can Use Lyn Locked Weapons", "Unused Weapon Lock")
        If athosLock Then ability4String = ability4String + vbCrLf + vbTab + IIf(gameType = Utilities.GameType.GameTypeFE7, "Can Use Athos Locked Weapons", "Unused Weapon Lock")

        Return ability4String
    End Function

    Public Function fieldTable() As Hashtable Implements RecordKeeper.RecordableItem.fieldTable
        Dim table As Hashtable = New Hashtable()

        table.Add("Name", displayName)
        table.Add("Class", classDisplayName)
        table.Add("Affinity", resolvedAffinity())

        table.Add("Base HP", baseHP.ToString)
        table.Add("Base STR/MAG", baseStr.ToString)
        table.Add("Base SKL", baseSkl.ToString)
        table.Add("Base SPD", baseSpd.ToString)
        table.Add("Base LCK", baseLck.ToString)
        table.Add("Base DEF", baseDef.ToString)
        table.Add("Base RES", baseRes.ToString)
        table.Add("Base CON", baseCon.ToString)

        table.Add("HP Growth", hpGrowth.ToString + "%")
        table.Add("STR/MAG Growth", strGrowth.ToString + "%")
        table.Add("SKL Growth", sklGrowth.ToString + "%")
        table.Add("SPD Growth", spdGrowth.ToString + "%")
        table.Add("LCK Growth", lckGrowth.ToString + "%")
        table.Add("DEF Growth", defGrowth.ToString + "%")
        table.Add("RES Growth", resGrowth.ToString + "%")

        table.Add("Weapon Ranks", IIf(weaponRankLetterForValue(swordLevel).Length > 0, weaponRankLetterForValue(swordLevel) + " - Sword" + vbTab, "") _
            & IIf(weaponRankLetterForValue(spearLevel).Length > 0, weaponRankLetterForValue(spearLevel) + " - Lance" + vbTab, "") _
            & IIf(weaponRankLetterForValue(axeLevel).Length > 0, weaponRankLetterForValue(axeLevel) + " - Axe" + vbTab, "") _
            & IIf(weaponRankLetterForValue(bowLevel).Length > 0, weaponRankLetterForValue(bowLevel) + " - Bow" + vbTab, "") _
            & IIf(weaponRankLetterForValue(animaLevel).Length > 0, weaponRankLetterForValue(animaLevel) + " - Anima" + vbTab, "") _
            & IIf(weaponRankLetterForValue(lightLevel).Length > 0, weaponRankLetterForValue(lightLevel) + " - Light" + vbTab, "") _
            & IIf(weaponRankLetterForValue(darkLevel).Length > 0, weaponRankLetterForValue(darkLevel) + " - Dark" + vbTab, "") _
            & IIf(weaponRankLetterForValue(staffLevel).Length > 0, weaponRankLetterForValue(staffLevel) + " - Staff" + vbTab, ""))

        table.Add("Character Ability 1", stringForCharacterAbility1())
        table.Add("Character Ability 2", stringForCharacterAbility2())
        table.Add("Character Ability 3", stringForCharacterAbility3())
        If gameType <> Utilities.GameType.GameTypeFE6 Then
            table.Add("Character Ability 4", stringForCharacterAbility4())
        End If

        Return table
    End Function

    Public Function orderedKeys() As ArrayList Implements RecordKeeper.RecordableItem.orderedKeys
        Dim keyList As ArrayList = New ArrayList

        keyList.Add("Name")
        keyList.Add("Class")
        keyList.Add("Affinity")

        keyList.Add("Base HP")
        keyList.Add("Base STR/MAG")
        keyList.Add("Base SKL")
        keyList.Add("Base SPD")
        keyList.Add("Base LCK")
        keyList.Add("Base DEF")
        keyList.Add("Base RES")
        keyList.Add("Base CON")

        keyList.Add("HP Growth")
        keyList.Add("STR/MAG Growth")
        keyList.Add("SKL Growth")
        keyList.Add("SPD Growth")
        keyList.Add("LCK Growth")
        keyList.Add("DEF Growth")
        keyList.Add("RES Growth")

        keyList.Add("Weapon Ranks")

        keyList.Add("Character Ability 1")
        keyList.Add("Character Ability 2")
        keyList.Add("Character Ability 3")
        If gameType <> Utilities.GameType.GameTypeFE6 Then
            keyList.Add("Character Ability 4")
        End If

        Return keyList
    End Function

    Public Function primaryKey() As String Implements RecordKeeper.RecordableItem.primaryKey
        Return "Name"
    End Function
End Class