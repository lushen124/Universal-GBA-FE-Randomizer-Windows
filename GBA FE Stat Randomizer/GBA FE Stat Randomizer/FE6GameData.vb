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

    Public Enum ClassList
        None = &H0
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

    Public Enum CharacterList
        None = &H0
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
        Gonzales = &H38
        Gonzales_NPC = &H39
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

    Public Shared Function randomEffectiveness(ByRef rng As Random)
        Dim result = rng.Next(2, 6)
        If result = 2 Then Return EffectivenessPointers.EffectivenessPointerKnights
        If result = 3 Then Return EffectivenessPointers.EffectivenessPointerDragons
        If result = 4 Then Return EffectivenessPointers.EffectivenessPointerCavalry
        If result = 5 Then Return EffectivenessPointers.EffectivenessPointerFliers

        Return EffectivenessPointers.EffectivenessPointerNone
    End Function

    Public Shared Function randomStatBonus(ByRef rng As Random)
        ' Seems too OP if it randomizes a dragonstone bonus on, say, an Iron Axe...
        Dim result = rng.Next(2, 10)
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

    Public Shared Function unpromotedClassList(ByVal female As Boolean) As ArrayList
        Dim list As ArrayList = New ArrayList()
        If female Then
            list.Add(ClassList.Myrmidon_F)
            list.Add(ClassList.ArmorKnight_F)
            list.Add(ClassList.Archer_F)
            list.Add(ClassList.Sister)
            list.Add(ClassList.Mage_F)
            list.Add(ClassList.Shaman_F)
            list.Add(ClassList.Troubadour)
            list.Add(ClassList.Nomad_F)
            list.Add(ClassList.PegasusKnight)
            list.Add(ClassList.DragonKnight_F)
            list.Add(ClassList.Thief_F)
            list.Add(ClassList.Dancer)
        Else
            list.Add(ClassList.Lord)
            list.Add(ClassList.Mercenary)
            list.Add(ClassList.Myrmidon)
            list.Add(ClassList.Fighter)
            list.Add(ClassList.ArmorKnight)
            list.Add(ClassList.Archer)
            list.Add(ClassList.Priest)
            list.Add(ClassList.Mage)
            list.Add(ClassList.Shaman)
            list.Add(ClassList.Cavalier)
            list.Add(ClassList.Nomad)
            list.Add(ClassList.Bandit)
            list.Add(ClassList.Pirate)
            list.Add(ClassList.DragonKnight)
            list.Add(ClassList.Thief)
            list.Add(ClassList.Soldier)
            list.Add(ClassList.Bard)
        End If

        Return list
    End Function

    Public Shared Function promotedClassList(ByVal female As Boolean) As ArrayList
        Dim list As ArrayList = New ArrayList()
        If female Then
            list.Add(ClassList.Hero_F)
            list.Add(ClassList.Swordmaster_F)
            list.Add(ClassList.Sniper_F)
            list.Add(ClassList.Bishop_F)
            list.Add(ClassList.Sage_F)
            list.Add(ClassList.Druid_F)
            list.Add(ClassList.Valkyrie)
            list.Add(ClassList.NomadTrooper_F)
            list.Add(ClassList.FalconKnight)
            list.Add(ClassList.DragonMaster_F)
            list.Add(ClassList.Manakete_F)
        Else
            list.Add(ClassList.Hero)
            list.Add(ClassList.Swordmaster)
            list.Add(ClassList.Sniper)
            list.Add(ClassList.Bishop)
            list.Add(ClassList.Sage)
            list.Add(ClassList.Druid)
            list.Add(ClassList.Warrior)
            list.Add(ClassList.NomadTrooper)
            list.Add(ClassList.Berserker)
            list.Add(ClassList.DragonMaster)
            list.Add(ClassList.Paladin)
            list.Add(ClassList.MasterLord)
            list.Add(ClassList.Manakete)
        End If

        Return list
    End Function

    Public Shared Function promotedClassForUnpromotedClass(ByVal unpromotedClassId As ClassList) As ClassList
        If unpromotedClassId = ClassList.Archer Then Return ClassList.Sniper
        If unpromotedClassId = ClassList.Archer_F Then Return ClassList.Sniper_F
        If unpromotedClassId = ClassList.ArmorKnight Then Return ClassList.General
        If unpromotedClassId = ClassList.ArmorKnight_F Then Return ClassList.General_F
        If unpromotedClassId = ClassList.Bandit Then Return ClassList.Berserker
        If unpromotedClassId = ClassList.Cavalier Then Return ClassList.Paladin
        If unpromotedClassId = ClassList.DragonKnight Then Return ClassList.DragonMaster
        If unpromotedClassId = ClassList.DragonKnight_F Then Return ClassList.DragonMaster_F
        If unpromotedClassId = ClassList.Fighter Then Return ClassList.Warrior
        If unpromotedClassId = ClassList.Lord Then Return ClassList.MasterLord
        If unpromotedClassId = ClassList.Mage Then Return ClassList.Sage
        If unpromotedClassId = ClassList.Mage_F Then Return ClassList.Sage_F
        If unpromotedClassId = ClassList.Mercenary Then Return ClassList.Hero
        If unpromotedClassId = ClassList.Myrmidon Then Return ClassList.Swordmaster
        If unpromotedClassId = ClassList.Myrmidon_F Then Return ClassList.Swordmaster_F
        If unpromotedClassId = ClassList.Nomad Then Return ClassList.NomadTrooper
        If unpromotedClassId = ClassList.Nomad_F Then Return ClassList.NomadTrooper_F
        If unpromotedClassId = ClassList.PegasusKnight Then Return ClassList.FalconKnight
        If unpromotedClassId = ClassList.Pirate Then Return ClassList.Berserker
        If unpromotedClassId = ClassList.Priest Then Return ClassList.Bishop
        If unpromotedClassId = ClassList.Shaman Then Return ClassList.Druid
        If unpromotedClassId = ClassList.Shaman_F Then Return ClassList.Druid_F
        If unpromotedClassId = ClassList.Sister Then Return ClassList.Bishop_F
        If unpromotedClassId = ClassList.Troubadour Then Return ClassList.Valkyrie
        Return ClassList.None
    End Function

    Public Shared Function unpromotedClassForPromotedClass(ByVal promotedClassId As ClassList) As ClassList
        If promotedClassId = ClassList.Sniper Then Return ClassList.Archer
        If promotedClassId = ClassList.Sniper_F Then Return ClassList.Archer_F
        If promotedClassId = ClassList.General Then Return ClassList.ArmorKnight
        If promotedClassId = ClassList.General_F Then Return ClassList.ArmorKnight_F
        If promotedClassId = ClassList.Berserker Then Return ClassList.Bandit
        If promotedClassId = ClassList.Paladin Then Return ClassList.Cavalier
        If promotedClassId = ClassList.DragonMaster Then Return ClassList.DragonKnight
        If promotedClassId = ClassList.DragonMaster_F Then Return ClassList.DragonKnight_F
        If promotedClassId = ClassList.Warrior Then Return ClassList.Fighter
        If promotedClassId = ClassList.MasterLord Then Return ClassList.Lord
        If promotedClassId = ClassList.Sage Then Return ClassList.Mage
        If promotedClassId = ClassList.Sage_F Then Return ClassList.Mage_F
        If promotedClassId = ClassList.Hero Then Return ClassList.Mercenary
        If promotedClassId = ClassList.Swordmaster Then Return ClassList.Myrmidon
        If promotedClassId = ClassList.Swordmaster_F Then Return ClassList.Myrmidon_F
        If promotedClassId = ClassList.NomadTrooper Then Return ClassList.Nomad
        If promotedClassId = ClassList.NomadTrooper_F Then Return ClassList.Nomad_F
        If promotedClassId = ClassList.FalconKnight Then Return ClassList.PegasusKnight
        If promotedClassId = ClassList.Bishop Then Return ClassList.Priest
        If promotedClassId = ClassList.Druid Then Return ClassList.Shaman
        If promotedClassId = ClassList.Druid_F Then Return ClassList.Shaman_F
        If promotedClassId = ClassList.Bishop_F Then Return ClassList.Sister
        If promotedClassId = ClassList.Valkyrie Then Return ClassList.Troubadour
        Return ClassList.None
    End Function

    Public Shared Function isValidClass(ByVal characterClass As Byte) As Boolean
        Return Not characterClass = Convert.ToByte(ClassList.None) And (characterClass <= Convert.ToByte(ClassList.King) Or characterClass = Convert.ToByte(ClassList.MasterLord))
    End Function

    Public Shared Function shouldNotDemoteCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(CharacterList.Echidna)

        Return list
    End Function

    Public Shared Function canNotPromoteCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(CharacterList.Chad)
        list.Add(CharacterList.Astore)
        list.Add(CharacterList.Cath)
        list.Add(CharacterList.Elphin)
        list.Add(CharacterList.Lalum)

        Return list
    End Function

    Public Shared Function randomClassFromOriginalClass(ByVal originalClass As Byte, ByVal allowLord As Boolean, ByVal allowThief As Boolean, ByVal allowUnique As Boolean, ByVal requirePromotion As Boolean, ByVal requireAttack As Boolean, ByRef rng As Random) As ClassList
        Dim original As ClassList = System.Enum.ToObject(GetType(ClassList), originalClass)
        Dim classListUnpromoted As ArrayList = New ArrayList

        classListUnpromoted = unpromotedClassList(True)
        ' Not sure if Mercenary_F is allowed so we won't use it.
        If Not allowThief Then
            classListUnpromoted.Remove(ClassList.Thief_F)
        End If
        If Not allowUnique Then
            classListUnpromoted.Remove(ClassList.Dancer)
        End If

        If requireAttack Then
            classListUnpromoted.Remove(ClassList.Dancer)
            classListUnpromoted.Remove(ClassList.Sister)
            classListUnpromoted.Remove(ClassList.Troubadour)
        End If

        If requirePromotion Then
            classListUnpromoted.Remove(ClassList.Thief_F)
            classListUnpromoted.Remove(ClassList.Dancer)
        End If

        If classListUnpromoted.Contains(System.Enum.ToObject(GetType(ClassList), original)) Then
            Dim newClass As ClassList
            Do
                newClass = classListUnpromoted.Item(rng.Next(classListUnpromoted.Count))
            Loop While newClass = original

            Return newClass
        Else
            ' Old class was probably promoted, so look for promoted classes.
            Dim classListPromoted As ArrayList = promotedClassList(True)

            If Not allowUnique Then
                classListPromoted.Remove(ClassList.Manakete_F)
            End If

            If classListPromoted.Contains(System.Enum.ToObject(GetType(ClassList), original)) Then
                Dim newClass As ClassList
                Do
                    newClass = classListPromoted.Item(rng.Next(classListPromoted.Count))
                Loop While newClass = original

                Return newClass
            End If
        End If

        classListUnpromoted = unpromotedClassList(False)

        If Not allowLord Then
            classListUnpromoted.Remove(ClassList.Lord)
        End If
        If Not allowThief Then
            classListUnpromoted.Remove(ClassList.Thief)
        End If
        If Not allowUnique Then
            classListUnpromoted.Remove(ClassList.Soldier)
            classListUnpromoted.Remove(ClassList.Bard)
        End If

        If requireAttack Then
            classListUnpromoted.Remove(ClassList.Bard)
            classListUnpromoted.Remove(ClassList.Priest)
        End If

        If requirePromotion Then
            classListUnpromoted.Remove(ClassList.Soldier)
            classListUnpromoted.Remove(ClassList.Bard)
            classListUnpromoted.Remove(ClassList.Thief)
        End If

        If classListUnpromoted.Contains(System.Enum.ToObject(GetType(ClassList), original)) Then
            Dim newClass As ClassList
            Do
                newClass = classListUnpromoted.Item(rng.Next(classListUnpromoted.Count))
            Loop While newClass = original

            Return newClass
        Else
            ' Old class was probably promoted, so look for promoted classes.
            Dim classListPromoted As ArrayList = promotedClassList(False)

            If Not allowLord Then
                classListPromoted.Remove(ClassList.MasterLord)
            End If

            If Not allowUnique Then
                classListPromoted.Remove(ClassList.Manakete)
            End If

            If classListPromoted.Contains(System.Enum.ToObject(GetType(ClassList), original)) Then
                Dim newClass As ClassList
                Do
                    newClass = classListPromoted.Item(rng.Next(classListPromoted.Count))
                Loop While newClass = original

                Return newClass
            End If
        End If

        ' We shouldn't get this far but if we do, just return the original (i.e. no change)
        Return original
    End Function

    Public Shared Function playableCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(CharacterList.Roy)
        list.Add(CharacterList.Marcus)
        list.Add(CharacterList.Alan)
        list.Add(CharacterList.Lance)
        list.Add(CharacterList.Wolt)
        list.Add(CharacterList.Bors)
        list.Add(CharacterList.Ellen)
        list.Add(CharacterList.Dieck)
        list.Add(CharacterList.Wade)
        list.Add(CharacterList.Lot)
        list.Add(CharacterList.Thany)
        list.Add(CharacterList.Chad)
        list.Add(CharacterList.Lugh)
        list.Add(CharacterList.Clarine)
        list.Add(CharacterList.Rutger)
        list.Add(CharacterList.Saul)
        list.Add(CharacterList.Dorothy)
        list.Add(CharacterList.Sue)
        list.Add(CharacterList.Zealot)
        list.Add(CharacterList.Treck)
        list.Add(CharacterList.Noah)
        list.Add(CharacterList.Astore)
        list.Add(CharacterList.Lilina)
        list.Add(CharacterList.Wendy)
        list.Add(CharacterList.Barth)
        list.Add(CharacterList.Oujay)
        list.Add(CharacterList.Fir)
        list.Add(CharacterList.Shin)
        list.Add(CharacterList.Gonzales)
        list.Add(CharacterList.Geese)
        list.Add(CharacterList.Klein)
        list.Add(CharacterList.Tate)
        list.Add(CharacterList.Lalum)
        list.Add(CharacterList.Echidna)
        list.Add(CharacterList.Elphin)
        list.Add(CharacterList.Bartre)
        list.Add(CharacterList.Ray)
        list.Add(CharacterList.Cath)
        list.Add(CharacterList.Miledy)
        list.Add(CharacterList.Percival)
        list.Add(CharacterList.Cecilia)
        list.Add(CharacterList.Sophia)
        list.Add(CharacterList.Igrene)
        list.Add(CharacterList.Garret)
        list.Add(CharacterList.Fa)
        list.Add(CharacterList.Hugh)
        list.Add(CharacterList.Zeiss)
        list.Add(CharacterList.Douglas)
        list.Add(CharacterList.Niime)
        list.Add(CharacterList.Dayan)
        list.Add(CharacterList.Yuuno)
        list.Add(CharacterList.Yodel)
        list.Add(CharacterList.Karel)

        Return list
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

        list.Add(CharacterList.Zephiel)
        list.Add(CharacterList.Idoun_Dragon)
        list.Add(CharacterList.Yahn)

        Return list
    End Function

    Public Shared Function exemptCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()
        list.Add(CharacterList.None)

        list.Add(CharacterList.Zephiel)
        list.Add(CharacterList.Idoun_Dragon)
        list.Add(CharacterList.Idoun_Shaman)
        list.Add(CharacterList.Yahn)

        list.Add(CharacterList.Merlinus)

        ' Some characters cause problems when randomized for scripted events, namely fliers like Miledy who need to do scripted flying.
        ' We need to black list characters.
        ' list.Add(CharacterList.Miledy)

        Return list
    End Function

    Public Shared Function isBlacklisted(ByVal itemID As Byte) As Boolean
        Dim itemIDObject As ItemList = System.Enum.ToObject(GetType(ItemList), itemID)
        If itemIDObject = ItemList.Unused_BridgeKey Or
            itemIDObject = ItemList.Unused_Gold Or
            itemIDObject = ItemList.Unused_Shield Or
            itemIDObject = ItemList.Unused_Watch Then
            Return True
        End If

        Return False
    End Function

    Public Shared Function isHealingStaff(ByVal itemID As Byte) As Boolean
        Dim itemIDObject As ItemList = System.Enum.ToObject(GetType(ItemList), itemID)
        If itemIDObject = ItemList.Heal Or ItemList.Mend Or ItemList.Recover Or ItemList.Physic Or ItemList.TinasStaff Then Return True
        Return False
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

    ' Reverse Recruitment Mapping.
    'Roy				Karel			Myrmidon
    'Marcus				Yodel			Bishop
    'Allen				Juno			Pegasus Knight
    'Lance				Dayan			Nomad
    'Wolt				Niime			Shaman (F)
    'Bors				Douglas			Armor Knight
    'Elen				Zeiss			Wyvern Knight
    'Dieck				Hugh			Mage
    'Wade				Fae				Manakete (F)
    'Lot				Garret			Bandit
    'Shanna				Igrene			Archer (F)
    'Chad				Sophia			Shaman (F)
    'Lugh				Cecilia			Troubadour
    'Clarine			Perceval		Cavalier
    'Rutger				Miledy			Wyvern Knight (F)
    'Saul				Cath			Thief (F)
    'Dorothy			Raigh			Shaman
    'Sue				Bartre			Fighter
    'Zealot				Elphin			Bard (!)
    'Treck				Echidna			Mercenary (F) (!)
    'Noah				Lalum			Dancer
    'Astore				Tate			Pegasus Knight
    'Lilina				Klein			Archer
    'Wendy				Geese			Pirate
    'Barth				Gonzales		Bandit
    'Oujay				Shin			Nomad
    'Fir				Fir				Myrmidon (F)
    'Shin				Oujay			Mercenary
    'Gonzales			Barth			Armor Knight
    'Geese				Wendy			Armor Knight
    'Klein				Lilina			Sage (F)
    'Tate				Astore			Thief
    'Lalum				Noah			Cavalier
    'Echidna			Treck			Paladin
    'Elphin				Zealot			Cavalier
    'Bartre				Sue				Nomadic Trooper (F)
    'Raigh				Dorothy			Archer (F)
    'Cath				Saul			Priest
    'Miledy				Rutger			Myrmidon
    'Perceval			Clarine			Valkyrie
    'Cecilia			Lugh			Sage
    'Sophia				Chad			Thief
    'Igrene				Shanna			Falcoknight
    'Garret				Lot				Warrior
    'Fae				Wade			Fighter
    'Hugh				Dieck			Mercenary
    'Zeiss				Elen			Cleric		
    'Douglas			Bors			General
    'Niime				Wolt			Sniper
    'Dayan				Lance			Paladin
    'Juno				Allen			Paladin
    'Yodel				Marcus			Paladin
    'Karel				Roy				Master Lord

    Public Shared Function reversedRecruitmentMappingForCharacter(ByVal originalCharacter As CharacterList) As CharacterList
        If originalCharacter = CharacterList.Roy Then Return CharacterList.Karel
        If originalCharacter = CharacterList.Marcus Then Return CharacterList.Yodel
        If originalCharacter = CharacterList.Alan Then Return CharacterList.Yuuno
        If originalCharacter = CharacterList.Lance Then Return CharacterList.Dayan
        If originalCharacter = CharacterList.Wolt Then Return CharacterList.Niime
        If originalCharacter = CharacterList.Bors Then Return CharacterList.Douglas
        If originalCharacter = CharacterList.Ellen Then Return CharacterList.Zeiss
        If originalCharacter = CharacterList.Dieck Then Return CharacterList.Hugh
        If originalCharacter = CharacterList.Wade Then Return CharacterList.Fa
        If originalCharacter = CharacterList.Lot Then Return CharacterList.Garret
        If originalCharacter = CharacterList.Thany Then Return CharacterList.Igrene
        If originalCharacter = CharacterList.Chad Then Return CharacterList.Sophia
        If originalCharacter = CharacterList.Lugh Then Return CharacterList.Cecilia
        If originalCharacter = CharacterList.Clarine Then Return CharacterList.Percival
        If originalCharacter = CharacterList.Rutger Then Return CharacterList.Miledy
        If originalCharacter = CharacterList.Saul Then Return CharacterList.Cath
        If originalCharacter = CharacterList.Dorothy Then Return CharacterList.Ray
        If originalCharacter = CharacterList.Sue Then Return CharacterList.Bartre
        If originalCharacter = CharacterList.Zealot Then Return CharacterList.Echidna ' Going to switch these two around to avoid issues with not having a Female Mercenary class.
        If originalCharacter = CharacterList.Treck Then Return CharacterList.Elphin
        If originalCharacter = CharacterList.Noah Then Return CharacterList.Lalum
        If originalCharacter = CharacterList.Astore Then Return CharacterList.Tate
        If originalCharacter = CharacterList.Lilina Then Return CharacterList.Klein
        If originalCharacter = CharacterList.Wendy Then Return CharacterList.Geese
        If originalCharacter = CharacterList.Barth Then Return CharacterList.Gonzales
        If originalCharacter = CharacterList.Oujay Then Return CharacterList.Shin
        If originalCharacter = CharacterList.Fir Then Return CharacterList.Fir
        If originalCharacter = CharacterList.Shin Then Return CharacterList.Oujay
        If originalCharacter = CharacterList.Gonzales Then Return CharacterList.Barth
        If originalCharacter = CharacterList.Geese Then Return CharacterList.Wendy
        If originalCharacter = CharacterList.Klein Then Return CharacterList.Lilina
        If originalCharacter = CharacterList.Tate Then Return CharacterList.Astore
        If originalCharacter = CharacterList.Lalum Then Return CharacterList.Noah
        If originalCharacter = CharacterList.Echidna Then Return CharacterList.Zealot
        If originalCharacter = CharacterList.Elphin Then Return CharacterList.Treck
        If originalCharacter = CharacterList.Bartre Then Return CharacterList.Sue
        If originalCharacter = CharacterList.Ray Then Return CharacterList.Dorothy
        If originalCharacter = CharacterList.Cath Then Return CharacterList.Saul
        If originalCharacter = CharacterList.Miledy Then Return CharacterList.Rutger
        If originalCharacter = CharacterList.Percival Then Return CharacterList.Clarine
        If originalCharacter = CharacterList.Cecilia Then Return CharacterList.Lugh
        If originalCharacter = CharacterList.Sophia Then Return CharacterList.Chad
        If originalCharacter = CharacterList.Igrene Then Return CharacterList.Thany
        If originalCharacter = CharacterList.Garret Then Return CharacterList.Lot
        If originalCharacter = CharacterList.Fa Then Return CharacterList.Wade
        If originalCharacter = CharacterList.Hugh Then Return CharacterList.Dieck
        If originalCharacter = CharacterList.Zeiss Then Return CharacterList.Ellen
        If originalCharacter = CharacterList.Douglas Then Return CharacterList.Bors
        If originalCharacter = CharacterList.Niime Then Return CharacterList.Wolt
        If originalCharacter = CharacterList.Dayan Then Return CharacterList.Lance
        If originalCharacter = CharacterList.Yuuno Then Return CharacterList.Alan
        If originalCharacter = CharacterList.Yodel Then Return CharacterList.Marcus
        If originalCharacter = CharacterList.Karel Then Return CharacterList.Roy
        ' Shouldn't happen, but we need to return something.
        Return originalCharacter
    End Function

    Public Shared Function reversedRecruitmentClassMappingForCharacter(ByVal originalCharacter As CharacterList) As ClassList
        If originalCharacter = CharacterList.Roy Then Return ClassList.MasterLord
        If originalCharacter = CharacterList.Marcus Then Return ClassList.Paladin
        If originalCharacter = CharacterList.Alan Then Return ClassList.Paladin
        If originalCharacter = CharacterList.Lance Then Return ClassList.Paladin
        If originalCharacter = CharacterList.Wolt Then Return ClassList.Sniper
        If originalCharacter = CharacterList.Bors Then Return ClassList.General
        If originalCharacter = CharacterList.Ellen Then Return ClassList.Sister
        If originalCharacter = CharacterList.Dieck Then Return ClassList.Mercenary
        If originalCharacter = CharacterList.Wade Then Return ClassList.Fighter
        If originalCharacter = CharacterList.Lot Then Return ClassList.Warrior
        If originalCharacter = CharacterList.Thany Then Return ClassList.FalconKnight
        If originalCharacter = CharacterList.Chad Then Return ClassList.Thief
        If originalCharacter = CharacterList.Lugh Then Return ClassList.Sage
        If originalCharacter = CharacterList.Clarine Then Return ClassList.Valkyrie
        If originalCharacter = CharacterList.Rutger Then Return ClassList.Myrmidon
        If originalCharacter = CharacterList.Saul Then Return ClassList.Priest
        If originalCharacter = CharacterList.Dorothy Then Return ClassList.Archer_F
        If originalCharacter = CharacterList.Sue Then Return ClassList.NomadTrooper_F
        If originalCharacter = CharacterList.Zealot Then Return ClassList.Paladin
        If originalCharacter = CharacterList.Treck Then Return ClassList.Cavalier
        If originalCharacter = CharacterList.Noah Then Return ClassList.Cavalier
        If originalCharacter = CharacterList.Astore Then Return ClassList.Thief
        If originalCharacter = CharacterList.Lilina Then Return ClassList.Sage_F
        If originalCharacter = CharacterList.Wendy Then Return ClassList.ArmorKnight_F
        If originalCharacter = CharacterList.Barth Then Return ClassList.ArmorKnight
        If originalCharacter = CharacterList.Oujay Then Return ClassList.Mercenary
        If originalCharacter = CharacterList.Fir Then Return ClassList.Myrmidon_F
        If originalCharacter = CharacterList.Shin Then Return ClassList.Nomad
        If originalCharacter = CharacterList.Gonzales Then Return ClassList.Bandit
        If originalCharacter = CharacterList.Geese Then Return ClassList.Pirate
        If originalCharacter = CharacterList.Klein Then Return ClassList.Archer
        If originalCharacter = CharacterList.Tate Then Return ClassList.PegasusKnight
        If originalCharacter = CharacterList.Lalum Then Return ClassList.Dancer
        If originalCharacter = CharacterList.Echidna Then Return ClassList.Hero_F
        If originalCharacter = CharacterList.Elphin Then Return ClassList.Bard
        If originalCharacter = CharacterList.Bartre Then Return ClassList.Fighter
        If originalCharacter = CharacterList.Ray Then Return ClassList.Shaman
        If originalCharacter = CharacterList.Cath Then Return ClassList.Thief_F
        If originalCharacter = CharacterList.Miledy Then Return ClassList.DragonKnight_F
        If originalCharacter = CharacterList.Percival Then Return ClassList.Cavalier
        If originalCharacter = CharacterList.Cecilia Then Return ClassList.Troubadour
        If originalCharacter = CharacterList.Sophia Then Return ClassList.Shaman_F
        If originalCharacter = CharacterList.Igrene Then Return ClassList.Archer_F
        If originalCharacter = CharacterList.Garret Then Return ClassList.Bandit
        If originalCharacter = CharacterList.Fa Then Return ClassList.Manakete_F
        If originalCharacter = CharacterList.Hugh Then Return ClassList.Mage
        If originalCharacter = CharacterList.Zeiss Then Return ClassList.DragonKnight
        If originalCharacter = CharacterList.Douglas Then Return ClassList.ArmorKnight
        If originalCharacter = CharacterList.Niime Then Return ClassList.Shaman_F
        If originalCharacter = CharacterList.Dayan Then Return ClassList.Nomad
        If originalCharacter = CharacterList.Yuuno Then Return ClassList.PegasusKnight
        If originalCharacter = CharacterList.Yodel Then Return ClassList.Bishop
        If originalCharacter = CharacterList.Karel Then Return ClassList.Myrmidon

        ' Shouldn't get here, but we need to return something
        Return ClassList.None
    End Function

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
        arrayList.Add(70)   ' Chapter 9
        arrayList.Add(67)   ' Chapter 10A
        arrayList.Add(94)   ' Chapter 11A
        arrayList.Add(66)   ' Chapter 12
        arrayList.Add(94)   ' Chapter 13
        arrayList.Add(79)   ' Chapter 14
        arrayList.Add(64)   ' Chapter 15
        arrayList.Add(71)   ' Chapter 16
        arrayList.Add(64)   ' Chapter 17A
        arrayList.Add(58)   ' Chapter 18A
        arrayList.Add(61)   ' Chapter 19A
        arrayList.Add(65)   ' Chapter 20A
        arrayList.Add(126)  ' Chapter 21
        arrayList.Add(115)  ' Chapter 22
        arrayList.Add(63)   ' Chapter 23
        arrayList.Add(53)   ' Chapter 24
        arrayList.Add(27)   ' Final

        arrayList.Add(82)   ' Chapter 10B
        arrayList.Add(85)   ' Chapter 11B
        arrayList.Add(56)   ' Chapter 17B
        arrayList.Add(90)   ' Chapter 18B
        arrayList.Add(82)   ' Chapter 19B
        arrayList.Add(64)   ' Chapter 20B

        arrayList.Add(78)   ' Chapter 8x
        arrayList.Add(36)   ' Chapter 12x
        arrayList.Add(44)   ' Chapter 14x
        arrayList.Add(49)   ' Chapter 16x
        arrayList.Add(55)   ' Chapter 20Ax
        arrayList.Add(96)   ' Chapter 20Bx
        arrayList.Add(69)   ' Chapter 21x

        Return arrayList
    End Function

End Class
