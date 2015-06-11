Public Class FE6GameData
    Public Const DefaultCharacterTableOffset = &H6076A0 ' Length: &H2940 - Default ends at: &H609FE0
    Public Const DefaultItemTableOffset = &H60B648      ' Length: &H1000 - Default ends at: &H60C648
    Public Const DefaultClassTableOffset = &H60A0E8     ' Length: &H1560 - Default ends at: &H60B648

    Public Const PointerToCharacterTableOffset = &H17680
    Public Const PointerToItemTableOffset = &H17360
    Public Const PointerToClassTableOffset = &H176E0

    Public Const CharacterCount = 220
    Public Const ItemCount = 128
    Public Const ClassCount = 76

    Public Const CharacterEntrySize = 48
    Public Const ItemEntrySize = 32
    Public Const ClassEntrySize = 72

    Public Const ChapterUnitEntrySize = 16

    Public Enum EffectivenessPointers
        EffectivenessPointerNone = &H0
        EffectivenessPointerKnights = &H86615C1
        EffectivenessPointerDragons = &H86615D4
        EffectivenessPointerCavalry = &H86615BC
        EffectivenessPointerFliers = &H86616DB
    End Enum

    Enum WeaponRank
        WeaponRankNone = &H0
        WeaponRankE = &H1
        WeaponRankD = &H33
        WeaponRankC = &H65
        WeaponRankB = &H97
        WeaponRankA = &HC9
        WeaponRankS = &HFB
    End Enum

    Public Enum StatBonusPointers
        StatBonusPointerNone = &H0
        StatBonusPointer_5STR = &H8662738
        StatBonusPointer_5DEF_5RES = &H8662744
        StatBonusPointer_5SKL = &H8662750
        StatBonusPointer_5DEF = &H866275C
        StatBonusPointer_5SPD = &H8662768
        StatBonusPointer_5LCK = &H8662774
        StatBonusPointer_5RES = &H8662780
        StatBonusPointer_5MAG = &H866278C
        StatBonusPointer_10STR_10SKL_20DEF_5RES = &H8662798
        StatBonusPointer_12STR_12SKL_15DEF_25RES = &H86627A4
        StatBonusPointer_15STR_15SKL_20DEF_15RES = &H86627B0
    End Enum

    Public Shared Function randomEffectiveness(ByRef rng As Random)
        Dim result = rng.Next(2, 5)
        If result = 2 Then Return EffectivenessPointers.EffectivenessPointerKnights
        If result = 3 Then Return EffectivenessPointers.EffectivenessPointerDragons
        If result = 4 Then Return EffectivenessPointers.EffectivenessPointerCavalry
        If result = 5 Then Return EffectivenessPointers.EffectivenessPointerFliers

        Return EffectivenessPointers.EffectivenessPointerNone
    End Function

    Public Shared Function randomStatBonus(ByRef rng As Random)
        ' Seems too OP if it randomizes a dragonstone bonus on, say, an Iron Axe...
        Dim result = rng.Next(2, 9)
        If result = 2 Then Return StatBonusPointers.StatBonusPointer_5STR
        If result = 3 Then Return StatBonusPointers.StatBonusPointer_5DEF_5RES
        If result = 4 Then Return StatBonusPointers.StatBonusPointer_5SKL
        If result = 5 Then Return StatBonusPointers.StatBonusPointer_5DEF
        If result = 6 Then Return StatBonusPointers.StatBonusPointer_5SPD
        If result = 7 Then Return StatBonusPointers.StatBonusPointer_5LCK
        If result = 8 Then Return StatBonusPointers.StatBonusPointer_5RES
        If result = 9 Then Return StatBonusPointers.StatBonusPointer_5MAG
        If result = 10 Then Return StatBonusPointers.StatBonusPointer_10STR_10SKL_20DEF_5RES
        If result = 11 Then Return StatBonusPointers.StatBonusPointer_12STR_12SKL_15DEF_25RES
        If result = 12 Then Return StatBonusPointers.StatBonusPointer_15STR_15SKL_20DEF_15RES

        Return StatBonusPointers.StatBonusPointerNone
    End Function

    Public Enum ClassList
        Lord = &H1
        Mercenary = &H2
        Mercenary_F = &H3 ' Does this work?
        Hero = &H4
        Hero_F = &H5
        Myrmidon = &H6
        Myrmidon_F = &H7
        Swordmaster = &H8
        Swordmaster_F = &H9
        Fighter = &HA
        Warrior = &HB
        ArmorKnight = &HC
        ArmorKnight_F = &HD
        General = &HE
        General_F = &HF
        Archer = &H10
        Archer_F = &H11
        Sniper = &H12
        Sniper_F = &H13
        Priest = &H14
        Sister = &H15
        Bishop = &H16
        Bishop_F = &H17
        Mage = &H18
        Mage_F = &H19
        Sage = &H1A
        Sage_F = &H1B
        Shaman = &H1C
        Shaman_F = &H1D
        Druid = &H1E
        Druid_F = &H1F
        Cavalier = &H20
        Cavalier_F = &H21 ' Glitched Palette
        Paladin = &H22
        Paladin_F = &H23 'Glitched Palette
        Troubadour = &H24
        Valkyrie = &H25
        Nomad = &H26
        Nomad_F = &H27
        NomadTrooper = &H28
        NomadTrooper_F = &H29
        PegasusKnight = &H2A
        FalconKnight = &H2B
        DragonKnight = &H2C
        DragonKnight_F = &H2D
        DragonMaster = &H2E
        DragonMaster_F = &H2F
        Soldier = &H30
        Bandit = &H31
        Pirate = &H32
        Berserker = &H33
        Thief = &H34
        Thief_F = &H35
        Bard = &H36
        Dancer = &H37
        Manakete = &H38
        Manakete_F = &H39
        FireDragon = &H3A
        DivineDragon = &H3B
        MagicDragon = &H3C ' What is this?
        King = &H3D
        MasterLord = &H43
    End Enum

    Public Shared Function randomClassFromOriginalClass(ByVal original As ClassList, ByVal allowLord As Boolean, ByVal allowThief As Boolean, ByVal allowUnique As Boolean, ByRef rng As Random) As ClassList
        Dim classListUnpromoted As ArrayList = New ArrayList

        ' Not sure if Mercenary_F is allowed so we won't use it.
        classListUnpromoted.Add(ClassList.Myrmidon_F)
        classListUnpromoted.Add(ClassList.ArmorKnight_F)
        classListUnpromoted.Add(ClassList.Archer_F)
        classListUnpromoted.Add(ClassList.Sister)
        classListUnpromoted.Add(ClassList.Mage_F)
        classListUnpromoted.Add(ClassList.Shaman_F)
        ' Paladins have screwy palettes, so we son't use it.
        classListUnpromoted.Add(ClassList.Troubadour)
        classListUnpromoted.Add(ClassList.Nomad_F)
        classListUnpromoted.Add(ClassList.PegasusKnight)
        classListUnpromoted.Add(ClassList.DragonKnight_F)
        If allowThief Then
            classListUnpromoted.Add(ClassList.Thief_F)
        End If
        If allowUnique Then
            classListUnpromoted.Add(ClassList.Dancer)
            classListUnpromoted.Add(ClassList.Manakete_F)
        End If

        If classListUnpromoted.Contains(System.Enum.ToObject(GetType(ClassList), original)) Then
            Dim newClass As ClassList
            Do
                newClass = classListUnpromoted.Item(rng.Next(0, classListUnpromoted.Count - 1))
            Loop While newClass = original

            Return newClass
        Else
            ' Old class was probably promoted, so look for promoted classes.
            Dim classListPromoted As ArrayList = New ArrayList

            classListPromoted.Add(ClassList.Hero_F)
            classListPromoted.Add(ClassList.Swordmaster_F)
            classListPromoted.Add(ClassList.Sniper_F)
            classListPromoted.Add(ClassList.Bishop_F)
            classListPromoted.Add(ClassList.Sage_F)
            classListPromoted.Add(ClassList.Druid_F)
            classListPromoted.Add(ClassList.Valkyrie)
            classListPromoted.Add(ClassList.NomadTrooper_F)
            classListPromoted.Add(ClassList.FalconKnight)
            classListPromoted.Add(ClassList.DragonMaster_F)

            If classListPromoted.Contains(System.Enum.ToObject(GetType(ClassList), original)) Then
                Dim newClass As ClassList
                Do
                    newClass = classListPromoted.Item(rng.Next(0, classListPromoted.Count - 1))
                Loop While newClass = original

                Return newClass
            End If
        End If

        classListUnpromoted.Clear()

        If allowLord Then
            classListUnpromoted.Add(ClassList.Lord)
        End If
        classListUnpromoted.Add(ClassList.Mercenary)
        classListUnpromoted.Add(ClassList.Myrmidon)
        classListUnpromoted.Add(ClassList.Fighter)
        classListUnpromoted.Add(ClassList.ArmorKnight)
        classListUnpromoted.Add(ClassList.Archer)
        classListUnpromoted.Add(ClassList.Priest)
        classListUnpromoted.Add(ClassList.Mage)
        classListUnpromoted.Add(ClassList.Shaman)
        classListUnpromoted.Add(ClassList.Cavalier)
        classListUnpromoted.Add(ClassList.Nomad)
        classListUnpromoted.Add(ClassList.Bandit)
        classListUnpromoted.Add(ClassList.Pirate)
        classListUnpromoted.Add(ClassList.DragonKnight)
        If allowThief Then
            classListUnpromoted.Add(ClassList.Thief)
        End If
        If allowUnique Then
            classListUnpromoted.Add(ClassList.Soldier)
            classListUnpromoted.Add(ClassList.Bard)
            classListUnpromoted.Add(ClassList.Manakete)
        End If

        If classListUnpromoted.Contains(System.Enum.ToObject(GetType(ClassList), original)) Then
            Dim newClass As ClassList
            Do
                newClass = classListUnpromoted.Item(rng.Next(0, classListUnpromoted.Count - 1))
            Loop While newClass = original

            Return newClass
        Else
            ' Old class was probably promoted, so look for promoted classes.
            Dim classListPromoted As ArrayList = New ArrayList

            classListPromoted.Add(ClassList.Hero)
            classListPromoted.Add(ClassList.Swordmaster)
            classListPromoted.Add(ClassList.Sniper)
            classListPromoted.Add(ClassList.Bishop)
            classListPromoted.Add(ClassList.Sage)
            classListPromoted.Add(ClassList.Druid)
            classListPromoted.Add(ClassList.Warrior)
            classListPromoted.Add(ClassList.NomadTrooper)
            classListPromoted.Add(ClassList.Berserker)
            classListPromoted.Add(ClassList.DragonMaster)
            classListPromoted.Add(ClassList.Paladin)

            If allowLord Then
                classListPromoted.Add(ClassList.MasterLord)
            End If

            If classListPromoted.Contains(System.Enum.ToObject(GetType(ClassList), original)) Then
                Dim newClass As ClassList
                Do
                    newClass = classListPromoted.Item(rng.Next(0, classListPromoted.Count - 1))
                Loop While newClass = original

                Return newClass
            End If
        End If

        ' We shouldn't get this far but if we do, just return the original (i.e. no change)
        Return original
    End Function

    Public Shared Function lordCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()
        list.Add(CharacterList.Roy)
        Return list
    End Function

    Public Shared Function thiefCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()
        list.Add(CharacterList.Astore)
        list.Add(CharacterList.Chad)
        list.Add(CharacterList.Cath)
        Return list
    End Function

    Public Shared Function bossCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()
        list.Add(CharacterList.Damas)
        list.Add(CharacterList.Rude)
        list.Add(CharacterList.Slater)
        list.Add(CharacterList.Erik)
        list.Add(CharacterList.Dory)
        list.Add(CharacterList.Wagner)
        list.Add(CharacterList.Devias)
        list.Add(CharacterList.Reigans)
        list.Add(CharacterList.Scott)
        list.Add(CharacterList.Nord)
        list.Add(CharacterList.Flaer)
        list.Add(CharacterList.Oro)
        list.Add(CharacterList.Aine)
        list.Add(CharacterList.Narshen)
        list.Add(CharacterList.Randy)
        list.Add(CharacterList.Maggie)
        list.Add(CharacterList.Rose)
        list.Add(CharacterList.Raeth)
        list.Add(CharacterList.Arcard)
        list.Add(CharacterList.Martel)
        list.Add(CharacterList.Sigune)
        list.Add(CharacterList.Roartz)
        list.Add(CharacterList.Murdock)
        list.Add(CharacterList.Brunya)
        list.Add(CharacterList.Zeke)
        list.Add(CharacterList.Monke)
        list.Add(CharacterList.Kel)

        list.Add(CharacterList.Henning)
        list.Add(CharacterList.Scouran)
        list.Add(CharacterList.Grero)
        list.Add(CharacterList.Ohtz)
        list.Add(CharacterList.Teck)

        list.Add(CharacterList.Thoril)
        list.Add(CharacterList.Brakul)
        list.Add(CharacterList.Kudoka)
        list.Add(CharacterList.Maral)
        list.Add(CharacterList.Kabul)
        list.Add(CharacterList.Chan)
        list.Add(CharacterList.Pereth)
        list.Add(CharacterList.Windam)
        list.Add(CharacterList.Morgan)

        Return list
    End Function

    Public Shared Function exemptCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(CharacterList.Zephiel)
        list.Add(CharacterList.Idoun_Dragon)
        list.Add(CharacterList.Idoun_Shaman)
        list.Add(CharacterList.Yahn)

        ' Some characters cause problems when randomized for scripted events, namely fliers like Miledy who need to do scripted flying.
        ' We need to black list characters.
        list.Add(CharacterList.Miledy)

        Return list
    End Function

    Public Shared Function randomizedFromThiefEquipment() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(ItemList.DoorKeys)
        list.Add(ItemList.ChestKeys)

        Return list
    End Function

    Public Shared Function randomizedToThiefEquipment() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(ItemList.Lockpick)

        Return list
    End Function

    Public Enum CharacterList
        Roy = &H1
        Clarine = &H2
        Fa = &H3
        Shin = &H4
        Sue = &H5
        Dayan = &H6
        Dayan_NPC = &H7
        Barth = &H8
        Bors = &H9
        Wendy = &HA
        Douglas = &HB
        Douglas_NPC = &HC
        Wolt = &HD
        Dorothy = &HE
        Klein = &HF
        Saul = &H10
        Ellen = &H11
        Yodel = &H12
        Yodel_NPC = &H13
        Chad = &H14
        Karel = &H15
        Fir = &H16
        Rutger = &H17
        Dieck = &H18
        Oujay = &H19
        Garret = &H1A
        Alan = &H1B
        Lance = &H1C
        Percival = &H1D
        Igrene = &H1E
        Marcus = &H1F
        Astore = &H20
        Wade = &H21
        Lot = &H22
        Bartre = &H23
        Bartre_NPC = &H24
        Lugh = &H25
        Lilina = &H26
        Hugh = &H27
        Niime = &H28
        Niime_NPC = &H29
        Ray = &H2A
        Lalum = &H2B
        Yuuno = &H2C
        Yuuno_NPC = &H2D
        Tate = &H2E
        Tate_Enemy = &H2F
        Tate_NPC = &H30
        Thany = &H31
        Zeiss = &H32
        Gale = &H33
        Elphin = &H34
        Cath = &H35
        Sophia = &H36
        Miledy = &H37
        Gonzales_A = &H38
        Gonzales_B = &H39
        Noah = &H3A
        Treck = &H3B
        Zealot = &H3C
        Echidna = &H3D
        Echidna_NPC = &H3E
        Cecilia = &H3F
        Geese = &H40
        Geese_NPC = &H41
        Merlinus = &H42
        Eliwood = &H43
        Guinevere = &H44

        Damas = &H4A
        Rude = &H4B
        Slater = &H4C
        Erik = &H4D
        Dory = &H4E
        Wagner = &H4F
        Devias = &H50
        Reigans = &H51
        Scott = &H52
        Nord = &H53
        Flaer = &H55
        Oro = &H56
        Aine = &H58
        Narshen = &H59
        Randy = &H5A
        Maggie = &H5B
        Rose = &H5C
        Raeth = &H5D
        Arcard = &H5E
        Martel = &H5F
        Sigune = &H60
        Roartz = &H61
        Murdock = &H62
        Brunya = &H63
        Zephiel = &H64
        Idoun_Shaman = &H65
        Idoun_Dragon = &H66
        Yahn = &H67
        Zeke = &H68
        Monke = &H69
        Kel = &H6A

        Henning = &HB5
        Scouran = &HB6
        Grero = &HB8
        Ohtz = &HB9
        Teck = &HBA

        Thoril = &HBE
        Brakul = &HBF
        Kudoka = &HC0
        Maral = &HC1
        Kabul = &HC2
        Chan = &HC3
        Pereth = &HC4
        Windam = &HC6
        Morgan = &HC8

        Hector = &HCF
    End Enum

    Public Enum ChapterUnitReference
        Chapter1 = &H679B40
        Chapter2 = &H679DEC
        Chatper3 = &H67A2AC
        Chapter4 = &H67A70C
        Chapter5 = &H67AB48
        Chapter6 = &H67AFA0
        Chapter7 = &H67B680
        Chapter8 = &H67BB5C
        Chapter8x = &H68424C
        Chapter9 = &H67C3A4
        Chapter10A = &H67C898
        Chapter10B = &H681F5C
        Chapter11A = &H67CDAC
        Chapter11B = &H6825C4
        Chapter12 = &H67D538
        Chapter12x = &H684824
        Chapter13 = &H67DA14
        Chapter14 = &H67E13C
        Chapter14x = &H684A94
        Chapter15 = &H67E710
        Chapter16 = &H67EBA4
        Chapter16x = &H684D84
        Chapter17A = &H67F0E4
        Chapter17B = &H682C70
        Chapter18A = &H67F64C
        Chapter18B = &H6830B8
        Chapter19A = &H67FA58
        Chapter19B = &H6837F0
        Chapter20A = &H67FE94
        Chapter20B = &H683DA4
        Chapter20Ax = &H685100
        Chapter20Bx = &H6854A0
        Chapter21 = &H680324
        Chapter21x = &H685BC0
        Chapter22 = &H680C60
        Chapter23 = &H6814B0
        Chapter24 = &H6818F8
        FinalChapter = &H681D04
    End Enum

    Public Shared Function UnitsInEachChapter() As ArrayList
        Dim arrayList As ArrayList = New ArrayList()

        arrayList.Add(28)   ' Chapter 1
        arrayList.Add(46)   ' Chapter 2
        arrayList.Add(57)   ' Chapter 3
        arrayList.Add(56)   ' Chapter 4
        arrayList.Add(59)   ' Chapter 5
        arrayList.Add(92)   ' Chapter 6
        arrayList.Add(66)   ' Chapter 7
        arrayList.Add(105)  ' Chapter 8
        arrayList.Add(78)   ' Chapter 8x
        arrayList.Add(70)   ' Chapter 9
        arrayList.Add(67)   ' Chapter 10A
        arrayList.Add(82)   ' Chapter 10B
        arrayList.Add(94)   ' Chapter 11A
        arrayList.Add(85)   ' Chapter 11B
        arrayList.Add(66)   ' Chapter 12
        arrayList.Add(36)   ' Chapter 12x
        arrayList.Add(94)   ' Chapter 13
        arrayList.Add(79)   ' Chapter 14
        arrayList.Add(44)   ' Chapter 14x
        arrayList.Add(64)   ' Chapter 15
        arrayList.Add(71)   ' Chapter 16
        arrayList.Add(49)   ' Chapter 16x
        arrayList.Add(64)   ' Chapter 17A
        arrayList.Add(56)   ' Chapter 17B
        arrayList.Add(58)   ' Chapter 18A
        arrayList.Add(90)   ' Chapter 18B
        arrayList.Add(61)   ' Chapter 19A
        arrayList.Add(82)   ' Chapter 19B
        arrayList.Add(65)   ' Chapter 20A
        arrayList.Add(55)   ' Chapter 20Ax
        arrayList.Add(64)   ' Chapter 20B
        arrayList.Add(96)   ' Chapter 20Bx
        arrayList.Add(126)  ' Chapter 21
        arrayList.Add(69)   ' Chapter 21x
        arrayList.Add(115)  ' Chapter 22
        arrayList.Add(63)   ' Chapter 23
        arrayList.Add(53)   ' Chapter 24
        arrayList.Add(27)   ' Final

        Return arrayList
    End Function

    Public Enum ItemList
        IronSword = &H1
        IronBlade = &H2
        SteelSword = &H3
        SilverSword = &H4
        SlimSword = &H5
        PoisonSword = &H6
        BraveSword = &H7
        LightBrand = &H8
        Durandal = &H9
        Armourslayer = &HA
        Rapier = &HB
        KillingEdge = &HC
        Lancereaver = &HD
        WoDao = &HE
        SwordOfSeals = &HF

        IronLance = &H10
        SteelLance = &H11
        SilverLance = &H12
        SlimLance = &H13
        PoisonLance = &H14
        BraveLance = &H15
        Javelin = &H16
        Maltae = &H17
        Horseslayer = &H18
        KillerLance = &H19
        Axereaver = &H1A

        IronAxe = &H1B
        SteelAxe = &H1C
        SilverAxe = &H1D
        PoisonAxe = &H1E
        BraveAxe = &H1F
        HandAxe = &H20
        Armads = &H21
        Hammer = &H22
        KillerAxe = &H23
        Swordreaver = &H24
        DevilAxe = &H25
        Halberd = &H26

        IronBow = &H27
        SteelBow = &H28
        SilverBow = &H29
        PoisonBow = &H2A
        KillerBow = &H2B
        BraveBow = &H2C
        ShortBow = &H2D
        Longbow = &H2E
        Miugre = &H2F

        Ballista = &H30
        IronBallista = &H31
        KillerBallista = &H32

        Fire = &H33
        Thunder = &H34
        Fimbulvetr = &H35
        Elfire = &H36
        Aircalibur = &H37

        Fenrir = &H38
        Bolting = &H39
        Forblaze = &H3A

        Lightning = &H3B
        Divine = &H3C
        Purge = &H3D
        Aureola = &H3E

        Flux = &H3F
        Nosferatu = &H40
        Eclipse = &H41
        Apocalypse = &H42

        Heal = &H43
        Mend = &H44
        Recover = &H45
        Physic = &H46
        Fortify = &H47
        Warp = &H48
        Rescue = &H49
        Restore = &H4A
        Silence = &H4B
        Sleep = &H4C
        TorchStaff = &H4D
        Hammerne = &H4E
        Unused_Watch = &H4F
        Berserk = &H50
        Unlock = &H51
        Unused_Shield = &H52

        FireDragonStone = &H53
        DivineDragonStone = &H54
        MagicDragonStone = &H55

        SecretBook = &H56
        GoddessIcon = &H57
        AngelicRobe = &H58
        DragonShield = &H59
        EnergyRing = &H5A
        Speedwing = &H5B
        Talisman = &H5C
        Boots = &H5D
        BodyRing = &H5E

        HeroCrest = &H5F
        KnightCrest = &H60
        OrionsBolt = &H61
        ElysianWhip = &H62
        GuidingRing = &H63

        ChestKeys = &H64
        DoorKeys = &H65
        Unused_BridgeKey = &H66
        Lockpick = &H67

        Vulnerary = &H68
        Elixir = &H69
        HolyWater = &H6A
        Torch = &H6B
        Antitoxin = &H6C
        MemberCard = &H6D
        SilverCard = &H6E
        Unused_Gold = &H6F

        DarkBreath = &H70
        Exaccus = &H71

        SteelBlade = &H72
        SilverBlade = &H73
        AlsSword = &H74
        GantsLance = &H75
        TinasStaff = &H76
        HolyMaiden = &H77
        Wyrmslayer = &H78

        WhiteGem = &H79
        BlueGem = &H7A
        RedGem = &H7B
        DelphiShield = &H7C
        Runesword = &H7D
        Spear = &H7E
        Tomahawk = &H7F
    End Enum
End Class
