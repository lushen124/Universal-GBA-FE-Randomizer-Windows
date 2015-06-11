Public Class FECharacter
    Property characterAffinity As Short 'offset 9, 1 byte
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

    Property characterId As Byte 'offset 4, 1 byte
    Property classId As Byte 'offset 5, 1 byte

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

    Public Sub initializeWithBytesFromOffset(ByRef filePtr As IO.FileStream, ByVal offset As Integer, ByVal entrySize As Integer)
        filePtr.Seek(offset + 4, IO.SeekOrigin.Begin)
        characterId = filePtr.ReadByte()
        classId = filePtr.ReadByte()

        filePtr.Seek(offset + 9, IO.SeekOrigin.Begin)
        characterAffinity = filePtr.ReadByte()

        filePtr.Seek(offset + 12, IO.SeekOrigin.Begin)
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

        filePtr.Seek(offset + entrySize, IO.SeekOrigin.Begin)
    End Sub

    Public Sub writeStatsToCharacterStartingAtOffset(ByRef filePtr As IO.FileStream, ByVal offset As Integer, ByVal entrySize As Integer)
        filePtr.Seek(offset + 5, IO.SeekOrigin.Begin)
        filePtr.WriteByte(classId)

        filePtr.Seek(offset + 9, IO.SeekOrigin.Begin)
        filePtr.WriteByte(characterAffinity)

        filePtr.Seek(offset + 12, IO.SeekOrigin.Begin)
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

    Public Function resolvedAffinity() As Affinity
        If characterAffinity = Affinity.AffinityFire Then Return Affinity.AffinityFire
        If characterAffinity = Affinity.AffinityThunder Then Return Affinity.AffinityThunder
        If characterAffinity = Affinity.AffinityWind Then Return Affinity.AffinityWind
        If characterAffinity = Affinity.AffinityIce Then Return Affinity.AffinityIce
        If characterAffinity = Affinity.AffinityDark Then Return Affinity.AffinityDark
        If characterAffinity = Affinity.AffinityLight Then Return Affinity.AffinityLight
        If characterAffinity = Affinity.AffinityAnima Then Return Affinity.AffinityAnima

        Return Affinity.AffinityNone
    End Function

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

    Public Sub randomizeCON(ByVal minimumCON As Integer, ByRef charClass As FEClass, ByRef rng As Random)
        If IsNothing(charClass) Then Return

        Dim adjustment = rng.Next(0, 10) - 5
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

    Public Sub increaseWeaponRanksWithPercentChance(ByVal chance As Integer, ByVal type As Utilities.GameType, ByRef rng As Random)
        If chance <= 0 Then Return

        Dim noRank As Byte = 0
        Dim eRank As Byte
        Dim dRank As Byte
        Dim cRank As Byte
        Dim bRank As Byte
        Dim aRank As Byte
        Dim sRank As Byte

        If type = Utilities.GameType.GameTypeFE6 Then
            noRank = FE6GameData.WeaponRank.WeaponRankNone
            eRank = FE6GameData.WeaponRank.WeaponRankE
            dRank = FE6GameData.WeaponRank.WeaponRankD
            cRank = FE6GameData.WeaponRank.WeaponRankC
            bRank = FE6GameData.WeaponRank.WeaponRankB
            aRank = FE6GameData.WeaponRank.WeaponRankA
            sRank = FE6GameData.WeaponRank.WeaponRankS
        End If

        Dim maxRank As Byte = aRank

        Dim hasSwordRank As Boolean = swordLevel > noRank And swordLevel < maxRank
        Dim hasLanceRank As Boolean = spearLevel > noRank And spearLevel < maxRank
        Dim hasAxeRank As Boolean = axeLevel > noRank And axeLevel < maxRank
        Dim hasBowRank As Boolean = bowLevel > noRank And bowLevel < maxRank
        Dim hasLightRank As Boolean = lightLevel > noRank And lightLevel < maxRank
        Dim hasDarkRank As Boolean = darkLevel > noRank And darkLevel < maxRank
        Dim hasAnimaRank As Boolean = animaLevel > noRank And animaLevel < maxRank
        Dim hasStaffRank As Boolean = staffLevel > noRank And staffLevel < maxRank

        If Not hasSwordRank And Not hasLanceRank And Not hasAxeRank And Not hasBowRank And Not hasLightRank And Not hasDarkRank And Not hasAnimaRank And Not hasStaffRank Then
            Return
        End If

        Dim shouldIncrease As Boolean = IIf(chance >= 100, True, rng.Next(100) + 1 < chance)

        If shouldIncrease Then
            chance -= 100
            If hasSwordRank Then
                increaseSwordRank(type)
                If swordLevel = maxRank Then hasSwordRank = False
            End If
            If hasLanceRank Then
                increaseLanceRank(type)
                If spearLevel = maxRank Then hasLanceRank = False
            End If
            If hasAxeRank Then
                increaseAxeRank(type)
                If axeLevel = maxRank Then hasAxeRank = False
            End If
            If hasBowRank Then
                increaseBowRank(type)
                If bowLevel = maxRank Then hasBowRank = False
            End If
            If hasLightRank Then
                increaseLightRank(type)
                If lightLevel = maxRank Then hasLightRank = False
            End If
            If hasDarkRank Then
                increaseDarkRank(type)
                If darkLevel = maxRank Then hasDarkRank = False
            End If
            If hasAnimaRank Then
                increaseAnimaRank(type)
                If animaLevel = maxRank Then hasAnimaRank = False
            End If
            If hasStaffRank Then
                increaseStaffRank(type)
                If staffLevel = maxRank Then hasStaffRank = False
            End If

            If chance > 0 Then increaseWeaponRanksWithPercentChance(chance, type, rng)
        End If

    End Sub

    Private Sub increaseSwordRank(ByVal gameType As Utilities.GameType)
        Dim noRank As Byte = 0
        Dim eRank As Byte
        Dim dRank As Byte
        Dim cRank As Byte
        Dim bRank As Byte
        Dim aRank As Byte
        Dim sRank As Byte

        If gameType = Utilities.GameType.GameTypeFE6 Then
            noRank = FE6GameData.WeaponRank.WeaponRankNone
            eRank = FE6GameData.WeaponRank.WeaponRankE
            dRank = FE6GameData.WeaponRank.WeaponRankD
            cRank = FE6GameData.WeaponRank.WeaponRankC
            bRank = FE6GameData.WeaponRank.WeaponRankB
            aRank = FE6GameData.WeaponRank.WeaponRankA
            sRank = FE6GameData.WeaponRank.WeaponRankS
        End If

        If swordLevel < eRank Then
            swordLevel = eRank
        ElseIf swordLevel = eRank Then
            swordLevel = dRank
        ElseIf swordLevel = dRank Then
            swordLevel = cRank
        ElseIf swordLevel = cRank Then
            swordLevel = bRank
        ElseIf swordLevel = bRank Then
            swordLevel = aRank
        ElseIf swordLevel = aRank Then
            swordLevel = sRank
        End If

    End Sub

    Private Sub increaseLanceRank(ByVal gameType As Utilities.GameType)
        Dim noRank As Byte = 0
        Dim eRank As Byte
        Dim dRank As Byte
        Dim cRank As Byte
        Dim bRank As Byte
        Dim aRank As Byte
        Dim sRank As Byte

        If gameType = Utilities.GameType.GameTypeFE6 Then
            noRank = FE6GameData.WeaponRank.WeaponRankNone
            eRank = FE6GameData.WeaponRank.WeaponRankE
            dRank = FE6GameData.WeaponRank.WeaponRankD
            cRank = FE6GameData.WeaponRank.WeaponRankC
            bRank = FE6GameData.WeaponRank.WeaponRankB
            aRank = FE6GameData.WeaponRank.WeaponRankA
            sRank = FE6GameData.WeaponRank.WeaponRankS
        End If

        If spearLevel < eRank Then
            spearLevel = eRank
        ElseIf spearLevel = eRank Then
            spearLevel = dRank
        ElseIf spearLevel = dRank Then
            spearLevel = cRank
        ElseIf spearLevel = cRank Then
            spearLevel = bRank
        ElseIf spearLevel = bRank Then
            spearLevel = aRank
        ElseIf spearLevel = aRank Then
            spearLevel = sRank
        End If

    End Sub

    Private Sub increaseAxeRank(ByVal gameType As Utilities.GameType)
        Dim noRank As Byte = 0
        Dim eRank As Byte
        Dim dRank As Byte
        Dim cRank As Byte
        Dim bRank As Byte
        Dim aRank As Byte
        Dim sRank As Byte

        If gameType = Utilities.GameType.GameTypeFE6 Then
            noRank = FE6GameData.WeaponRank.WeaponRankNone
            eRank = FE6GameData.WeaponRank.WeaponRankE
            dRank = FE6GameData.WeaponRank.WeaponRankD
            cRank = FE6GameData.WeaponRank.WeaponRankC
            bRank = FE6GameData.WeaponRank.WeaponRankB
            aRank = FE6GameData.WeaponRank.WeaponRankA
            sRank = FE6GameData.WeaponRank.WeaponRankS
        End If

        If axeLevel < eRank Then
            axeLevel = eRank
        ElseIf axeLevel = eRank Then
            axeLevel = dRank
        ElseIf axeLevel = dRank Then
            axeLevel = cRank
        ElseIf axeLevel = cRank Then
            axeLevel = bRank
        ElseIf axeLevel = bRank Then
            axeLevel = aRank
        ElseIf axeLevel = aRank Then
            axeLevel = sRank
        End If

    End Sub

    Private Sub increaseBowRank(ByVal gameType As Utilities.GameType)
        Dim noRank As Byte = 0
        Dim eRank As Byte
        Dim dRank As Byte
        Dim cRank As Byte
        Dim bRank As Byte
        Dim aRank As Byte
        Dim sRank As Byte

        If gameType = Utilities.GameType.GameTypeFE6 Then
            noRank = FE6GameData.WeaponRank.WeaponRankNone
            eRank = FE6GameData.WeaponRank.WeaponRankE
            dRank = FE6GameData.WeaponRank.WeaponRankD
            cRank = FE6GameData.WeaponRank.WeaponRankC
            bRank = FE6GameData.WeaponRank.WeaponRankB
            aRank = FE6GameData.WeaponRank.WeaponRankA
            sRank = FE6GameData.WeaponRank.WeaponRankS
        End If

        If bowLevel < eRank Then
            bowLevel = eRank
        ElseIf bowLevel = eRank Then
            bowLevel = dRank
        ElseIf bowLevel = dRank Then
            bowLevel = cRank
        ElseIf bowLevel = cRank Then
            bowLevel = bRank
        ElseIf bowLevel = bRank Then
            bowLevel = aRank
        ElseIf bowLevel = aRank Then
            bowLevel = sRank
        End If

    End Sub

    Private Sub increaseLightRank(ByVal gameType As Utilities.GameType)
        Dim noRank As Byte = 0
        Dim eRank As Byte
        Dim dRank As Byte
        Dim cRank As Byte
        Dim bRank As Byte
        Dim aRank As Byte
        Dim sRank As Byte

        If gameType = Utilities.GameType.GameTypeFE6 Then
            noRank = FE6GameData.WeaponRank.WeaponRankNone
            eRank = FE6GameData.WeaponRank.WeaponRankE
            dRank = FE6GameData.WeaponRank.WeaponRankD
            cRank = FE6GameData.WeaponRank.WeaponRankC
            bRank = FE6GameData.WeaponRank.WeaponRankB
            aRank = FE6GameData.WeaponRank.WeaponRankA
            sRank = FE6GameData.WeaponRank.WeaponRankS
        End If

        If lightLevel < eRank Then
            lightLevel = eRank
        ElseIf lightLevel = eRank Then
            lightLevel = dRank
        ElseIf lightLevel = dRank Then
            lightLevel = cRank
        ElseIf lightLevel = cRank Then
            lightLevel = bRank
        ElseIf lightLevel = bRank Then
            lightLevel = aRank
        ElseIf lightLevel = aRank Then
            lightLevel = sRank
        End If

    End Sub

    Private Sub increaseDarkRank(ByVal gameType As Utilities.GameType)
        Dim noRank As Byte = 0
        Dim eRank As Byte
        Dim dRank As Byte
        Dim cRank As Byte
        Dim bRank As Byte
        Dim aRank As Byte
        Dim sRank As Byte

        If gameType = Utilities.GameType.GameTypeFE6 Then
            noRank = FE6GameData.WeaponRank.WeaponRankNone
            eRank = FE6GameData.WeaponRank.WeaponRankE
            dRank = FE6GameData.WeaponRank.WeaponRankD
            cRank = FE6GameData.WeaponRank.WeaponRankC
            bRank = FE6GameData.WeaponRank.WeaponRankB
            aRank = FE6GameData.WeaponRank.WeaponRankA
            sRank = FE6GameData.WeaponRank.WeaponRankS
        End If

        If darkLevel < eRank Then
            darkLevel = eRank
        ElseIf darkLevel = eRank Then
            darkLevel = dRank
        ElseIf darkLevel = dRank Then
            darkLevel = cRank
        ElseIf darkLevel = cRank Then
            darkLevel = bRank
        ElseIf darkLevel = bRank Then
            darkLevel = aRank
        ElseIf darkLevel = aRank Then
            darkLevel = sRank
        End If

    End Sub

    Private Sub increaseAnimaRank(ByVal gameType As Utilities.GameType)
        Dim noRank As Byte = 0
        Dim eRank As Byte
        Dim dRank As Byte
        Dim cRank As Byte
        Dim bRank As Byte
        Dim aRank As Byte
        Dim sRank As Byte

        If gameType = Utilities.GameType.GameTypeFE6 Then
            noRank = FE6GameData.WeaponRank.WeaponRankNone
            eRank = FE6GameData.WeaponRank.WeaponRankE
            dRank = FE6GameData.WeaponRank.WeaponRankD
            cRank = FE6GameData.WeaponRank.WeaponRankC
            bRank = FE6GameData.WeaponRank.WeaponRankB
            aRank = FE6GameData.WeaponRank.WeaponRankA
            sRank = FE6GameData.WeaponRank.WeaponRankS
        End If

        If animaLevel < eRank Then
            animaLevel = eRank
        ElseIf animaLevel = eRank Then
            animaLevel = dRank
        ElseIf animaLevel = dRank Then
            animaLevel = cRank
        ElseIf animaLevel = cRank Then
            animaLevel = bRank
        ElseIf animaLevel = bRank Then
            animaLevel = aRank
        ElseIf animaLevel = aRank Then
            animaLevel = sRank
        End If

    End Sub

    Private Sub increaseStaffRank(ByVal gameType As Utilities.GameType)
        Dim noRank As Byte = 0
        Dim eRank As Byte
        Dim dRank As Byte
        Dim cRank As Byte
        Dim bRank As Byte
        Dim aRank As Byte
        Dim sRank As Byte

        If gameType = Utilities.GameType.GameTypeFE6 Then
            noRank = FE6GameData.WeaponRank.WeaponRankNone
            eRank = FE6GameData.WeaponRank.WeaponRankE
            dRank = FE6GameData.WeaponRank.WeaponRankD
            cRank = FE6GameData.WeaponRank.WeaponRankC
            bRank = FE6GameData.WeaponRank.WeaponRankB
            aRank = FE6GameData.WeaponRank.WeaponRankA
            sRank = FE6GameData.WeaponRank.WeaponRankS
        End If

        If staffLevel < eRank Then
            staffLevel = eRank
        ElseIf staffLevel = eRank Then
            staffLevel = dRank
        ElseIf staffLevel = dRank Then
            staffLevel = cRank
        ElseIf staffLevel = cRank Then
            staffLevel = bRank
        ElseIf staffLevel = bRank Then
            staffLevel = aRank
        ElseIf staffLevel = aRank Then
            staffLevel = sRank
        End If

    End Sub

End Class