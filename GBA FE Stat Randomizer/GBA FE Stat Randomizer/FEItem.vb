Public Class FEItem

    Enum WeaponEffect
        WeaponEffectNone
        WeaponEffectPoison
        WeaponEffectStealsHP
        WeaponEffectHalvesHP
        WeaponEffectDevilReversal
        WeaponEffectStone   ' Only in FE8
    End Enum

    Enum Ability1   ' These can be bitmasked together.
        Ability1None = &H0
        Ability1Weapon = &H1
        Ability1Magic = &H2     ' Tomes should always bitmask weapon and magic!
        Ability1Staff = &H4
        Ability1Unbreakable = &H8
        Ability1Unsellable = &H10
        Ability1Brave = &H20
        Ability1MagicDamage = &H40
        Ability1Uncounterable = &H80
    End Enum

    Enum Ability2   ' These can be bitmasked together (those not listed shouldn't be touched)
        Ability2None = &H0
        Ability2ReverseTriangle = &H1
        Ability2Hammerne = &H2  ' For FE6 only, FE8 lists "special effect"
        Ability2MonsterWeaponDragonLock = &H4
        Ability2LordLock = &H8 ' FE6 only
        Ability2SwordfighterLock = &H10 ' Lyn Lock in FE7
        Ability2KingLock = &H20 ' FE6 only
        Ability2NegateFlyingEffect = &H40
        Ability2NegateCritical = &H80
    End Enum

    Enum Ability3   ' Can be bitmasked
        Ability3None = &H0
        Ability3NegateDefenses = &H2    ' Only in FE7 and FE8
        Ability3EliwoodEirikaLock = &H4
        Ability3HectorEphraimLock = &H8
        Ability3LynLock = &H10
        Ability3AthosLock = &H20
    End Enum

    Enum WeaponType
        WeaponTypeSword = &H0
        WeaponTypeSpear = &H1
        WeaponTypeAxe = &H2
        WeaponTypeBow = &H3
        WeaponTypeStaff = &H4
        WeaponTypeAnima = &H5
        WeaponTypeLight = &H6
        WeaponTypeDark = &H7
        WeaponTypeItem = &H9
        WeaponTypeDragonstoneMonsterWeapon = &HB     ' Only in FE6 and FE7. Monster Weapon in FE8
        WeaponTypeRing = &HC                        ' Only in FE7, I think.
    End Enum

    Enum PotentialTrait
        PotentialTraitNone
        PotentialTraitPoison
        PotentialTraitHalveHP
        PotentialTraitDevil
        PotentialTraitUnbreakable
        PotentialTraitBrave
        PotentialTraitMagicDamage
        PotentialTraitUncounterable
        PotentialTraitReverseTriangle
        PotentialTraitStatIncrease
        PotentialTraitAddEffect
        PotentialTraitNegateDefense
        PotentialTraitCount
    End Enum

    Property durability As Byte         'offset 20, 1 byte
    Property might As Byte              'offset 21, 1 byte
    Property hit As Byte                'offset 22, 1 byte
    Property weight As Byte             'offset 23, 1 byte
    Property critical As Byte           'offset 24, 1 byte

    Property rank As Byte               'offset 28, 1 byte

    Property effect As Byte             'offset 31, 1 byte

    Property experience As Byte         'offset 32, 1 byte (FE7 and FE8 only)

    Property statBonus As UInteger      'offset 12, 4 bytes
    Property effectiveness As UInteger  'offset 16, 4 bytes

    Property weaponAbility1 As Byte     'offset 8, 1 byte
    Property weaponAbility2 As Byte     'offset 9, 1 byte
    Property weaponAbility3 As Byte     'offset 10, 1 byte (only in FE7, FE8 (for Luna))

    Property type As Byte               'offset 7, 1 byte
    Property weaponID As Byte           'offset 6, 1 byte

    Public Sub initializeWithBytesFromOffset(ByRef filePtr As IO.FileStream, ByVal offset As Integer, ByVal entrySize As Integer, ByVal gameType As Utilities.GameType)
        filePtr.Seek(offset + 6, IO.SeekOrigin.Begin)
        weaponID = filePtr.ReadByte()
        type = filePtr.ReadByte()

        weaponAbility1 = filePtr.ReadByte()
        weaponAbility2 = filePtr.ReadByte()

        If gameType <> Utilities.GameType.GameTypeFE6 Then
            weaponAbility3 = filePtr.ReadByte()
        End If

        filePtr.Seek(offset + 12, IO.SeekOrigin.Begin)
        statBonus = Utilities.ReadWord(filePtr, False)
        effectiveness = Utilities.ReadWord(filePtr, False)

        filePtr.Seek(offset + 20, IO.SeekOrigin.Begin)
        durability = filePtr.ReadByte()
        might = filePtr.ReadByte()
        hit = filePtr.ReadByte()
        weight = filePtr.ReadByte()
        critical = filePtr.ReadByte()

        filePtr.Seek(offset + 28, IO.SeekOrigin.Begin)
        rank = filePtr.ReadByte()

        filePtr.Seek(offset + 31, IO.SeekOrigin.Begin)
        effect = filePtr.ReadByte()

        If gameType <> Utilities.GameType.GameTypeFE6 Then
            experience = filePtr.ReadByte()
        End If

        filePtr.Seek(offset + entrySize, IO.SeekOrigin.Begin)
    End Sub

    Public Sub writeItemToOffset(ByRef filePtr As IO.FileStream, ByVal offset As Integer, ByVal entrySize As Integer, ByVal gameType As Utilities.GameType)
        ' Don't touch ID or type!
        filePtr.Seek(offset + 8, IO.SeekOrigin.Begin)
        filePtr.WriteByte(weaponAbility1)
        filePtr.WriteByte(weaponAbility2)

        If gameType <> Utilities.GameType.GameTypeFE6 Then
            filePtr.WriteByte(weaponAbility3)
        End If

        filePtr.Seek(offset + 12, IO.SeekOrigin.Begin)
        Utilities.WriteWord(filePtr, statBonus)
        Utilities.WriteWord(filePtr, effectiveness)

        filePtr.Seek(offset + 20, IO.SeekOrigin.Begin)
        filePtr.WriteByte(durability)
        filePtr.WriteByte(might)
        filePtr.WriteByte(hit)
        filePtr.WriteByte(weight)
        filePtr.WriteByte(critical)

        filePtr.Seek(offset + 28, IO.SeekOrigin.Begin)
        filePtr.WriteByte(rank)

        filePtr.Seek(offset + 31, IO.SeekOrigin.Begin)
        filePtr.WriteByte(effect)

        If gameType <> Utilities.GameType.GameTypeFE6 Then
            filePtr.WriteByte(experience)
        End If

        filePtr.Seek(offset + entrySize, IO.SeekOrigin.Begin)
    End Sub

    Public Function isWeapon() As Boolean
        Return type = WeaponType.WeaponTypeSword Or
            type = WeaponType.WeaponTypeSpear Or
            type = WeaponType.WeaponTypeAxe Or
            type = WeaponType.WeaponTypeBow Or
            type = WeaponType.WeaponTypeAnima Or
            type = WeaponType.WeaponTypeDark Or
            type = WeaponType.WeaponTypeLight Or
            type = WeaponType.WeaponTypeDragonstoneMonsterWeapon
    End Function

    Private Function randomDeltaWithVariance(ByVal variance As Integer, ByRef rng As Random)
        Dim magnitude = rng.Next(0, variance + 1)
        Dim isNegative = rng.Next(0, 2)

        Return magnitude * IIf(isNegative = 0, -1, 1)
    End Function

    Public Sub randomizeItemDurability(ByVal variance As Integer, ByVal minimum As Integer, ByRef rng As Random)
        If isWeapon() And variance > 0 Then
            durability = Math.Max(durability + randomDeltaWithVariance(variance, rng), minimum)
        End If
    End Sub

    Public Sub randomizeItemMight(ByVal variance As Integer, ByVal minimum As Integer, ByRef rng As Random)
        If isWeapon() And variance > 0 Then
            Dim randomDelta As Integer = randomDeltaWithVariance(variance, rng)
            If randomDelta > 0 Then
                might = Math.Max(IIf(&HFF - randomDelta >= might, might + randomDelta, might), minimum)
            Else
                randomDelta *= -1
                might = Math.Max(IIf(randomDelta <= might, might - randomDelta, might), minimum)
            End If
        End If
    End Sub

    Public Sub randomizeItemCritical(ByVal variance As Integer, ByVal minimum As Integer, ByRef rng As Random)
        If isWeapon() And variance > 0 Then
            Dim randomDelta As Integer = randomDeltaWithVariance(variance, rng)
            If randomDelta > 0 Then
                critical = Math.Max(IIf(&HFF - randomDelta >= critical, critical + randomDelta, critical), minimum)
            Else
                randomDelta *= -1
                critical = Math.Max(IIf(randomDelta <= critical, critical - randomDelta, critical), minimum)
            End If
        End If
    End Sub

    Public Sub randomizeItemHit(ByVal variance As Integer, ByVal minimum As Integer, ByRef rng As Random)
        If isWeapon() And variance > 0 Then
            Dim randomDelta As Integer = randomDeltaWithVariance(variance, rng)
            If randomDelta > 0 Then
                hit = Math.Max(IIf(&HFF - randomDelta >= hit, hit + randomDelta, hit), minimum)
            Else
                randomDelta *= -1
                hit = Math.Max(IIf(randomDelta <= hit, hit - randomDelta, hit), minimum)
            End If
        End If
    End Sub

    Public Sub randomizeItemWeight(ByVal variance As Integer, ByVal minimum As Integer, ByVal maximum As Integer, ByRef rng As Random)
        If isWeapon() And variance > 0 Then
            Dim randomDelta As Integer = randomDeltaWithVariance(variance, rng)
            If randomDelta > 0 Then
                weight = Math.Max(IIf(&HFF - randomDelta >= weight, weight + randomDelta, weight), minimum)
            Else
                randomDelta *= -1
                weight = Math.Max(IIf(randomDelta <= weight, weight - randomDelta, weight), minimum)
            End If
        End If
    End Sub

    Public Sub assignRandomEffect(ByRef rng As Random, ByVal gameType As Utilities.GameType)
        Dim randomTrait = rng.Next(0, PotentialTrait.PotentialTraitCount - IIf(gameType <> Utilities.GameType.GameTypeFE6, 1, 2))

        If randomTrait = PotentialTrait.PotentialTraitPoison Or
            randomTrait = PotentialTrait.PotentialTraitHalveHP Or
            randomTrait = PotentialTrait.PotentialTraitDevil Then
            ' Check to see if one of these is already set. If it is, we don't want to overwrite it
            ' because these cannot be stacked. Choose another if that's the case.
            If effect <> WeaponEffect.WeaponEffectNone Then
                assignRandomEffect(rng, gameType)
            Else
                If randomTrait = PotentialTrait.PotentialTraitPoison Then effect = WeaponEffect.WeaponEffectPoison
                If randomTrait = PotentialTrait.PotentialTraitHalveHP Then effect = WeaponEffect.WeaponEffectHalvesHP
                If randomTrait = PotentialTrait.PotentialTraitDevil Then effect = WeaponEffect.WeaponEffectDevilReversal
            End If
        ElseIf randomTrait = PotentialTrait.PotentialTraitUnbreakable Or
            randomTrait = PotentialTrait.PotentialTraitBrave Or
            randomTrait = PotentialTrait.PotentialTraitMagicDamage Or
            randomTrait = PotentialTrait.PotentialTraitUncounterable Then
            ' These apply to weapon ability 1. These can be bit masked, so let's check to see
            ' if the bit is already set, and if it is, redo the random.
            If randomTrait = PotentialTrait.PotentialTraitUnbreakable Then
                If weaponAbility1 And Ability1.Ability1Unbreakable Then
                    assignRandomEffect(rng, gameType)
                Else
                    weaponAbility1 = weaponAbility1 Or Ability1.Ability1Unbreakable
                End If
            ElseIf randomTrait = PotentialTrait.PotentialTraitBrave Then
                If weaponAbility1 And Ability1.Ability1Brave Then
                    assignRandomEffect(rng, gameType)
                Else
                    weaponAbility1 = weaponAbility1 Or Ability1.Ability1Brave
                End If
            ElseIf randomTrait = PotentialTrait.PotentialTraitMagicDamage Then
                If weaponAbility1 And Ability1.Ability1MagicDamage Or type = WeaponType.WeaponTypeLight Or type = WeaponType.WeaponTypeDark Or type = WeaponType.WeaponTypeAnima Then
                    assignRandomEffect(rng, gameType)
                Else
                    weaponAbility1 = weaponAbility1 Or Ability1.Ability1MagicDamage
                End If
            Else
                ' FE6 does not handle uncounterable very well (forcing it to be animated from 3+ spaces away and locking up weapons that can't do that)
                ' FE7 kind of works, but enemies will force a soft lock when using it.
                If (weaponAbility1 And Ability1.Ability1Uncounterable) Or gameType <> Utilities.GameType.GameTypeFE8 Then
                    assignRandomEffect(rng, gameType)
                Else
                    weaponAbility1 = weaponAbility1 Or Ability1.Ability1Uncounterable
                End If
            End If
        ElseIf randomTrait = PotentialTrait.PotentialTraitReverseTriangle Then
            ' These apply to weapon ability 2. Also bit masked.
            ' Redo if already set.
            If weaponAbility2 And Ability2.Ability2ReverseTriangle Then
                assignRandomEffect(rng, gameType)
            Else
                weaponAbility2 = weaponAbility2 Or Ability2.Ability2ReverseTriangle
            End If
        ElseIf randomTrait = PotentialTrait.PotentialTraitNegateDefense Then
            ' These apply to weapon ability 3. Also bit masked.
            ' This doesn't exist on FE6, so if we somehow got here in FE6, redo.
            ' Again, if it's set, redo as well.
            If type = Utilities.GameType.GameTypeFE6 Or weaponAbility3 And Ability3.Ability3NegateDefenses Then
                assignRandomEffect(rng, gameType)
            Else
                weaponAbility3 = weaponAbility3 Or Ability3.Ability3NegateDefenses
            End If
        ElseIf randomTrait = PotentialTrait.PotentialTraitAddEffect Then
            ' This writes a pointer to the effectiveness slot.
            ' If this pointer isn't 0, then redo
            If effectiveness <> 0 Then
                assignRandomEffect(rng, gameType)
            Else
                If gameType = Utilities.GameType.GameTypeFE6 Then effectiveness = FE6GameData.randomEffectiveness(rng)
                If gameType = Utilities.GameType.GameTypeFE7 Then effectiveness = FE7GameData.randomEffectiveness(rng)
                If gameType = Utilities.GameType.GameTypeFE8 Then effectiveness = FE8GameData.randomEffectiveness(rng)
            End If
        ElseIf randomTrait = PotentialTrait.PotentialTraitStatIncrease Then
            ' This writes a pointer to the stat increase slot.
            ' If this pointer isn't 0, then redo
            If statBonus <> 0 Then
                assignRandomEffect(rng, gameType)
            Else
                If gameType = Utilities.GameType.GameTypeFE6 Then statBonus = FE6GameData.randomStatBonus(rng)
                If gameType = Utilities.GameType.GameTypeFE7 Then statBonus = FE7GameData.randomStatBonus(rng)
                If gameType = Utilities.GameType.GameTypeFE8 Then statBonus = FE8GameData.randomStatBonus(rng)
            End If
        End If
    End Sub

End Class
