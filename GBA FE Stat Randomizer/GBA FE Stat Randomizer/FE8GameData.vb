Public Class FE8GameData
    Public Const DefaultCharacterTableOffset = &H803D30
    Public Const DefaultItemTableOffset = &H809B10
    Public Const DefaultClassTableOffset = &H807110

    Public Const PointerToCharacterTableOffset = &H17EF0
    Public Const PointerToItemTableOffset = &H16410
    Public Const PointerToClassTableOffset = &H17AB8

    Public Const CharacterCount = 256
    Public Const ItemCount = 187
    Public Const ClassCount = 128

    Public Const CharacterEntrySize = 52
    Public Const ItemEntrySize = 36
    Public Const ClassEntrySize = 84

    Public Const ChapterUnitEntrySize = 20

    Public Const HuffmanTreeStart = &H6E0               ' Redirects once (0x15A72C)
    Public Const HuffmanTreeEnd = &H6DC                 ' Redirects twice (0x15D488 > 0x15D484)
    Public Const TextArrayPointerAddress = &HA2A0               ' Where to find the text array offset
    Public Const TextArrayDefaultOffset = &H15D48C      ' The default location of the text array
    Public Const TextArrayDefaultCount = &HD4C          ' Default number of text entries available.

    Public Const CleanCRC32 = &HA47246AE

    Public Enum EffectivenessPointers
        EffectivenessPointerNone = &H0
        EffectivenessPointerKnights = &H88ADEBB
        EffectivenessPointerKnightsAndCavalry = &H88ADEC2
        EffectivenessPointerSwordfighters = &H88ADED7
        EffectivenessPointerCavalry = &H88ADEE0
        EffectivenessPointerFlyingAndMonsters = &H88ADEF1
        EffectivenessPointerDragons = &H88ADF13
        EffectivenessPointerFliers = &H88ADF2A
        EffectivenessPointerMonsters = &H88ADF39
    End Enum

    Public Enum StatBonusPointers
        StatBonusPointerNone = &H0
        StatBonusPointerExcalibur = &H88AEEC4
        StatBonusPointerGleipnir = &H88AEED0
        StatBonusPointerSieglinde = &H88AEF48
        StatBonusPointerIvaldi = &H88AEF54
        StatBonusPointerVidofnir = &H88AEF60
        StatBonusPointerDecayingBreath = &H88AEF6C
        StatBonusPointerAudhulma = &H88AEF78
        StatBonusPointerSiegmund = &H88AEF84
        StatBonusPointerGarm = &H88AEF90
        StatBonusPointerNidhogg = &H88AEF9C
        StatBonusPointerNightmare = &H88AEFA8
        StatBonusPointerDemonLight = &H88AEFB4
        StatBonusPointerRavager = &H88AEFC0
        StatBonusPointerDragonstone = &H88AEFCC
    End Enum

    Enum WeaponRank
        WeaponRankNone = &H0
        WeaponRankE = &H1
        WeaponRankD = &H1F
        WeaponRankC = &H47
        WeaponRankB = &H79
        WeaponRankA = &HB5
        WeaponRankS = &HFB
    End Enum

    Public Enum ClassList
        None = &H0
        EphraimLord = &H1
        EirikaLord = &H2
        EphraimMasterLord = &H3
        EirikaMasterLord = &H4
        Cavalier = &H5
        Cavalier_F = &H6
        Paladin = &H7
        Paladin_F = &H8
        ArmorKnight = &H9
        ArmorKnight_F = &HA
        General = &HB
        General_F = &HC
        Thief = &HD
        Manakete = &HE ' I don't think these exist.
        Mercenary = &HF
        Mercenary_F = &H10 ' Probably broken
        Hero = &H11
        Hero_F = &H12 ' Also probably broken
        Myrmidon = &H13
        Myrmidon_F = &H14
        Swordmaster = &H15
        Swordmaster_F = &H16
        Assassin = &H17
        Assassin_F = &H18
        Archer = &H19
        Archer_F = &H1A
        Sniper = &H1B
        Sniper_F = &H1C
        Ranger = &H1D
        Ranger_F = &H1E
        DragonKnight = &H1F
        DragonKnight_F = &H20 ' I don't think these exist.
        DragonMaster = &H21
        DragonMaster_F = &H22 ' Pretty sure Pegasus Knights become Wyvern Knights instead.
        WyvernKnight = &H23
        WyvernKnight_F = &H24
        Mage = &H25
        Mage_F = &H26
        Sage = &H27
        Sage_F = &H28
        MageKnight = &H29
        MageKnight_F = &H2A
        Bishop = &H2B
        Bishop_F = &H2C
        Shaman = &H2D
        Shaman_F = &H2E ' Sprite might exist, but her promotions don't.
        Druid = &H2F
        Druid_F = &H30 ' Nope
        Summoner = &H31
        Summoner_F = &H32 ' Definitely Nope.
        Rogue = &H33

        GreatKnight = &H35
        GreatKnight_F = &H36
        Recruit2 = &H37
        Journeyman3 = &H38
        Pupil3 = &H39
        Recruit3 = &H3A
        Manakete2 = &H3B ' Again?
        Manakete_F = &H3C ' I think this is Myrrh
        Journeyman = &H3D
        Pupil = &H3E
        Fighter = &H3F
        Warrior = &H40
        Bandit = &H41
        Pirate = &H42
        Berserker = &H43
        Monk = &H44
        Priest = &H45
        Bard = &H46 ' I don't think these exist.
        Recruit = &H47
        PegasusKnight = &H48
        FalconKnight = &H49
        Cleric = &H4A
        Troubadour = &H4B
        Valkyrie = &H4C
        Dancer = &H4D
        Soldier = &H4E
        Necromancer = &H4F
        Fleet = &H50 ' What is this?
        GhostFighter = &H51 ' Wat?

        ' Monster Classes!
        Zombie = &H52
        Mummy = &H53
        Skeleton = &H54
        SkeletonWithBow = &H55
        Hellbone = &H56
        HellboneWithBow = &H57
        Bael = &H58
        ElderBael = &H59
        Cyclops = &H5A
        Mauthedoog = &H5B
        Cerberus = &H5C
        Tarvos = &H5D
        Macdaire = &H5E
        Mogall = &H5F
        ArchMogall = &H60
        Gorgon = &H61

        Gargoyle = &H63
        Deathgoyle = &H64
        DragonZombie = &H65

        DemonKing = &H66 ' lol

        Cyclops2 = &H7C
        ElderBael2 = &H7D
        Journeyman2 = &H7E
        Pupil2 = &H7F
    End Enum

    Public Enum CharacterList
        None = &H0
        Eirika = &H1
        Seth = &H2
        Gilliam = &H3
        Franz = &H4
        Moulder = &H5
        Vanessa = &H6
        Ross = &H7
        Neimi = &H8
        Colm = &H9
        Garcia = &HA
        Innes = &HB
        Lute = &HC
        Natasha = &HD
        Cormag = &HE
        Ephraim = &HF
        Forde = &H10
        Kyle = &H11
        Amelia = &H12
        Artur = &H13
        Gerik = &H14
        Tethys = &H15
        Marisa = &H16
        Saleh = &H17
        Ewan = &H18
        Larachel = &H19
        Dozla = &H1A

        Rennac = &H1C
        Duessel = &H1D
        Myrrh = &H1E
        Knoll = &H1F
        Joshua = &H20
        Syrene = &H21
        Tana = &H22
        Lyon = &H23
        Orson = &H24
        Glen = &H25
        Selena = &H26
        Valter = &H27
        Riev = &H28
        Caellach = &H29
        Fado = &H2A
        Ismaire = &H2B
        Hayden = &H2C

        Lyon17 = &H40
        Morva = &H41
        Orson5x = &H42
        Valter15 = &H43
        Selena10B13B = &H44
        ValterPrologue = &H45
        Breguet = &H46
        Bone = &H47
        Bazba = &H48
        Mummy4 = &H49
        Saar = &H4A
        Novala = &H4B
        Murray = &H4C
        Tirado = &H4D
        Binks = &H4E
        Pablo10A = &H4F
        Macdaire12A = &H50
        Aias = &H51
        Carlyle = &H52
        Caellach15 = &H53
        Pablo13A = &H54

        Gorgon18 = &H56
        Riev1920 = &H57

        Gheb = &H5A
        Beran = &H5B
        Cyclops12B = &H5C
        Hellbone11A = &H5D
        Deathgoyle11B = &H5E
        Mummy = &H5F

        ONeill = &H68
        GlenCutscene = &H69
        Zonta = &H6A
        Vigarde = &H6B
        LyonFinal = &H6C
        Orson16 = &H6D

        DemonKing = &HBE

    End Enum

    Public Enum ChapterUnitReference
        PrologueScene = &H8B3D18
        PrologueScene2 = &H8B3F68
        Prologue = &H8B3C14
        Chapter1 = &H8B40A0
        Chapter2 = &H8B42CC
        Chapter3Scene = &H8B476C
        Chapter3 = &H8B4574
        Chapter4 = &H8B4904
        Chapter5 = &H8B5630
        Chapter5xScene = &H8B5E94
        Chapter5xScene2 = &H8B5F7C
        Chapter5x = &H8B5A64
        Chapter6 = &H8B61A8
        Chapter7 = &H8B6E78
        Chapter8Scene = &H8B710C
        Chapter8Scene2 = &H8B78EC
        Chapter8 = &H8B7300
        Chapter9AScene = &H8B8394
        Chapter9A = &H8B7C0C
        Chapter9BScene = &H8C296C
        Chapter9BScene2 = &H8C2A00
        Chapter9B = &H8C22C8
        Chapter10A = &H8B8540
        Chapter10BScene = &H8C3CB4
        Chapter10B = &H8C2C54
        Chapter11AScene = &H8B9F14
        Chapter11A = &H8B9894
        Chapter11B = &H8C3E50
        Chapter12A = &H8BA170
        Chapter12B = &H8C46B8
        Chapter13AScene = &H8BB9C4
        Chapter13AScene2 = &H8BBA58
        Chapter13A = &H8BA948
        Chapter13B = &H8C4EB4
        Chapter14AScene = &H8BC350
        Chapter14AScene2 = &H8BC45C
        Chapter14AScene3 = &H8BC4D4
        Chapter14A = &H8BBBA8
        Chapter14BScene = &H8C68B8
        Chapter14BScene2 = &H8C69E8
        Chapter14BScene3 = &H8C6BDC
        Chapter14B = &H8C5FBC
        Chapter15A = &H8BC610
        Chapter15B = &H8C6E14
        Chapter16AScene = &H8BD648
        Chapter16AScene2 = &H8BD810
        Chapter16AScene3 = &H8BDA08
        Chapter16AScene4 = &H8BDAF8
        Chapter16AScene5 = &H8BDC24
        Chapter16A = &H8BCE58
        Chapter16B = &H8C7648
        Chapter17A = &H8BDE58
        Chapter17B = &H8C7C9C
        Chapter18A = &H8BEFE8
        Chapter18B = &H8C8AD8
        Chapter19AScene = &H8C0B90
        Chapter19A = &H8C0290
        Chapter19B = &H8C9CB0
        Chapter20AScene = &H8C172C
        Chapter20A = &H8C0D74
        Chapter20B = &H8CA63C
        ChapterFinalA = &H8C181C
        ChapterFinalBValni1 = &H8CB060
        ChapterFinalBoss = &H8C1F44
        Lagdou2MelkaenCoast = &H8CEC84
        Valni2 = &H8CB918
        Valni3 = &H8CBF24
        Valni4Lagdou1 = &H8CC9B8

    End Enum

    Public Enum ItemList
        None = &H0

        IronSword = &H1
        SlimSword = &H2
        SteelSword = &H3
        SilverSword = &H4
        IronBlade = &H5
        SteelBlade = &H6
        SilverBlade = &H7
        PoisonSword = &H8
        Rapier = &H9
        Dummy_ManiKatti = &HA
        BraveSword = &HB
        Shamshir = &HC
        KillingEdge = &HD
        Armorslayer = &HE
        Wyrmslayer = &HF
        LightBrand = &H10
        Runesword = &H11
        Lancereaver = &H12
        Zanbato = &H13

        IronLance = &H14
        SlimLance = &H15
        SteelLance = &H16
        SilverLance = &H17
        PoisonLance = &H18
        BraveLance = &H19
        KillerLance = &H1A
        Horseslayer = &H1B
        Javelin = &H1C
        Spear = &H1D
        Axereaver = &H1E

        IronAxe = &H1F
        SteelAxe = &H20
        SilverAxe = &H21
        PoisonAxe = &H22
        BraveAxe = &H23
        KillerAxe = &H24
        Halberd = &H25
        Hammer = &H26
        DevilAxe = &H27
        HandAxe = &H28
        Tomahawk = &H29
        Swordreaver = &H2A
        Swordslayer = &H2B
        Hatchet = &H2C

        IronBow = &H2D
        SteelBow = &H2E
        SilverBow = &H2F
        PoisonBow = &H30
        KillerBow = &H31
        BraveBow = &H32
        ShortBow = &H33
        LongBow = &H34
        IronBallista = &H35
        KillerBallista = &H36
        Ballista = &H37

        Fire = &H38
        Thunder = &H39
        Elfire = &H3A
        Bolting = &H3B
        Fimbulvetr = &H3C
        Dummy_Forblaze = &H3D
        Excalibur = &H3E
        Lightning = &H3F
        Shine = &H40
        Divine = &H41
        Purge = &H42
        Aura = &H43
        Dummy_Luce = &H44

        Flux = &H45
        Luna = &H46
        Nosferatu = &H47
        Eclipse = &H48
        Fenrir = &H49
        Gleipnir = &H4A

        Heal = &H4B
        Mend = &H4C
        Recover = &H4D
        Physic = &H4E
        Fortify = &H4F
        Restore = &H50
        Silence = &H51
        Sleep = &H52
        Berserk = &H53
        Warp = &H54
        Rescue = &H55
        TorchStaff = &H56
        Hammerne = &H57
        Unlock = &H58
        Barrier = &H59

        DragonAxe = &H5A

        AngelicRobe = &H5B
        EnergyRing = &H5C
        SecretBook = &H5D
        Speedwings = &H5E
        GoddessIcon = &H5F
        Dragonshield = &H60
        Talisman = &H61
        Boots = &H62
        BodyRing = &H63

        HeroCrest = &H64
        KnightCrest = &H65
        OrionsBolt = &H66
        ElysianWhip = &H67
        GuidingRing = &H68

        ChestKey = &H69
        DoorKey = &H6A
        Lockpick = &H6B

        Vulnerary = &H6C
        Elixir = &H6D
        PureWater = &H6E
        Antitoxin = &H6F
        Torch = &H70

        FiliShield = &H71
        MemberCard = &H72
        SilverCard = &H73

        WhiteGem = &H74
        BlueGem = &H75
        RedGem = &H76

        Reginleif = &H78

        HoplonGuard = &H7C

        ShadowKiller = &H81
        BrightLance = &H82
        FiendCleaver = &H83
        BeaconBow = &H84

        Sieglinde = &H85
        BattleAxe = &H86
        Ivaldi = &H87

        MasterSeal = &H88
        MetisTome = &H89

        SharpClaw = &H8B
        Latona = &H8C
        DragonSpear = &H8D
        Vidofnir = &H8E
        Naglfar = &H8F
        DecayingBreath = &H90
        Audhulma = &H91
        Siegmund = &H92
        Garm = &H93
        Nidhogg = &H94

        HeavySpear = &H95
        ShortSpear = &H96

        ConquerorsProof = &H97
        LunarBracelet = &H98
        SolarBracelet = &H99

        WindSword = &HA1

        Nightmare = &HA6
        DemonShard = &HA7
        DemonLight = &HA8
        Ravager = &HA9

        HolyDragonStone = &HAA

        DemonSurge = &HAB
        Shadowshot = &HAC
        Stone = &HB5

        RottenClaw = &HAD
        FetidClaw = &HAE
        PoisonClaw = &HAF
        LongPoisonClaw = &HB0

        FireFang = &HB1
        HellFang = &HB2

        EvilEye = &HB3
        BloodyEye = &HB4

        BlackGem = &HBA
        GoldGem = &HBB

    End Enum

    Public Shared Function randomEffectiveness(ByRef rng As Random)
        Dim result = rng.Next(2, 10)
        If result = 2 Then Return EffectivenessPointers.EffectivenessPointerKnights
        If result = 3 Then Return EffectivenessPointers.EffectivenessPointerKnightsAndCavalry
        If result = 4 Then Return EffectivenessPointers.EffectivenessPointerSwordfighters
        If result = 5 Then Return EffectivenessPointers.EffectivenessPointerCavalry
        If result = 6 Then Return EffectivenessPointers.EffectivenessPointerFlyingAndMonsters
        If result = 7 Then Return EffectivenessPointers.EffectivenessPointerDragons
        If result = 8 Then Return EffectivenessPointers.EffectivenessPointerFliers
        If result = 9 Then Return EffectivenessPointers.EffectivenessPointerMonsters

        Return EffectivenessPointers.EffectivenessPointerNone
    End Function

    Public Shared Function randomStatBonus(ByRef rng As Random)
        Dim result = rng.Next(2, 16)
        If result = 2 Then Return StatBonusPointers.StatBonusPointerExcalibur
        If result = 3 Then Return StatBonusPointers.StatBonusPointerGleipnir
        If result = 4 Then Return StatBonusPointers.StatBonusPointerSieglinde
        If result = 5 Then Return StatBonusPointers.StatBonusPointerIvaldi
        If result = 6 Then Return StatBonusPointers.StatBonusPointerVidofnir
        If result = 7 Then Return randomStatBonus(rng) 'StatBonusPointers.StatBonusPointerDecayingBreath
        If result = 8 Then Return StatBonusPointers.StatBonusPointerAudhulma
        If result = 9 Then Return StatBonusPointers.StatBonusPointerSiegmund
        If result = 10 Then Return StatBonusPointers.StatBonusPointerGarm
        If result = 11 Then Return StatBonusPointers.StatBonusPointerNidhogg
        ' lol no
        If result = 12 Then Return randomStatBonus(rng) 'StatBonusPointers.StatBonusPointerNightmare
        If result = 13 Then Return randomStatBonus(rng) 'StatBonusPointers.StatBonusPointerDemonLight
        If result = 14 Then Return randomStatBonus(rng) 'StatBonusPointers.StatBonusPointerRavager
        If result = 15 Then Return randomStatBonus(rng) 'StatBonusPointers.StatBonusPointerDragonstone

        Return StatBonusPointers.StatBonusPointerNone

    End Function

    Public Shared Function unpromotedClassList(ByVal female As Boolean, ByVal includeMonsters As Boolean) As ArrayList
        Dim list As ArrayList = New ArrayList()

        If female Then
            list.Add(ClassList.EirikaLord)
            list.Add(ClassList.Cavalier_F)
            list.Add(ClassList.ArmorKnight_F)
            list.Add(ClassList.Myrmidon_F)
            list.Add(ClassList.Archer_F)
            list.Add(ClassList.Mage_F)
            list.Add(ClassList.Recruit2)
            list.Add(ClassList.Cleric)
            list.Add(ClassList.PegasusKnight)
            list.Add(ClassList.Troubadour)
            list.Add(ClassList.Dancer)
        Else
            list.Add(ClassList.EphraimLord)
            list.Add(ClassList.Cavalier)
            list.Add(ClassList.ArmorKnight)
            list.Add(ClassList.Thief)
            list.Add(ClassList.Mercenary)
            list.Add(ClassList.Myrmidon)
            list.Add(ClassList.Archer)
            list.Add(ClassList.DragonKnight)
            list.Add(ClassList.Mage)
            list.Add(ClassList.Shaman)
            list.Add(ClassList.Journeyman2)
            list.Add(ClassList.Pupil2)
            list.Add(ClassList.Fighter)
            list.Add(ClassList.Pirate)
            list.Add(ClassList.Monk)
            list.Add(ClassList.Priest)
            list.Add(ClassList.Soldier)
        End If

        If includeMonsters Then
            list.Add(ClassList.Zombie)
            list.Add(ClassList.Skeleton)
            list.Add(ClassList.SkeletonWithBow)
            list.Add(ClassList.Bael)
            list.Add(ClassList.Mauthedoog)
            list.Add(ClassList.Tarvos)
            list.Add(ClassList.Mogall)
            list.Add(ClassList.Gargoyle)
        End If

        Return list
    End Function

    Shared Function promotedClassList(ByVal female As Boolean, ByVal includeMonsters As Boolean) As ArrayList
        Dim list As ArrayList = New ArrayList()
        If female Then
            list.Add(ClassList.EirikaMasterLord)
            list.Add(ClassList.Paladin_F)
            list.Add(ClassList.General_F)
            list.Add(ClassList.Swordmaster_F)
            list.Add(ClassList.Assassin_F)
            list.Add(ClassList.Sniper_F)
            list.Add(ClassList.Ranger_F)
            list.Add(ClassList.WyvernKnight_F)
            list.Add(ClassList.Sage_F)
            list.Add(ClassList.MageKnight_F)
            list.Add(ClassList.Bishop_F)
            list.Add(ClassList.GreatKnight_F)
            list.Add(ClassList.Recruit3)
            list.Add(ClassList.Manakete_F)
            list.Add(ClassList.FalconKnight)
            list.Add(ClassList.Valkyrie)
        Else
            list.Add(ClassList.EphraimMasterLord)
            list.Add(ClassList.Paladin)
            list.Add(ClassList.General)
            list.Add(ClassList.Hero)
            list.Add(ClassList.Swordmaster)
            list.Add(ClassList.Assassin)
            list.Add(ClassList.Sniper)
            list.Add(ClassList.Ranger)
            list.Add(ClassList.DragonMaster)
            list.Add(ClassList.WyvernKnight)
            list.Add(ClassList.Sage)
            list.Add(ClassList.MageKnight)
            list.Add(ClassList.Bishop)
            list.Add(ClassList.Druid)
            list.Add(ClassList.Summoner)
            list.Add(ClassList.Rogue)
            list.Add(ClassList.GreatKnight)
            list.Add(ClassList.Journeyman3)
            list.Add(ClassList.Pupil3)
            list.Add(ClassList.Warrior)
            list.Add(ClassList.Berserker)
            list.Add(ClassList.Necromancer)
        End If

        If includeMonsters Then
            list.Add(ClassList.Mummy)
            list.Add(ClassList.Hellbone)
            list.Add(ClassList.HellboneWithBow)
            list.Add(ClassList.ElderBael)
            list.Add(ClassList.Cyclops)
            list.Add(ClassList.Cerberus)
            list.Add(ClassList.Macdaire)
            list.Add(ClassList.ArchMogall)
            list.Add(ClassList.Gorgon)
            list.Add(ClassList.Deathgoyle)
            list.Add(ClassList.DragonZombie)
        End If

        Return list
    End Function

    Public Shared Function promotedClassForUnpromotedClass(ByVal unpromotedClassId As ClassList) As ClassList
        If unpromotedClassId = ClassList.EphraimLord Then Return ClassList.EphraimMasterLord
        If unpromotedClassId = ClassList.EirikaLord Then Return ClassList.EirikaMasterLord
        If unpromotedClassId = ClassList.Cavalier Then Return ClassList.Paladin
        If unpromotedClassId = ClassList.Cavalier_F Then Return ClassList.Paladin_F
        If unpromotedClassId = ClassList.ArmorKnight Then Return ClassList.General
        If unpromotedClassId = ClassList.ArmorKnight_F Then Return ClassList.General_F
        If unpromotedClassId = ClassList.Thief Then Return ClassList.Assassin
        If unpromotedClassId = ClassList.Mercenary Then Return ClassList.Hero
        If unpromotedClassId = ClassList.Myrmidon Then Return ClassList.Swordmaster
        If unpromotedClassId = ClassList.Myrmidon_F Then Return ClassList.Swordmaster_F
        If unpromotedClassId = ClassList.Archer Then Return ClassList.Sniper
        If unpromotedClassId = ClassList.Archer_F Then Return ClassList.Sniper_F
        If unpromotedClassId = ClassList.DragonKnight Then Return ClassList.DragonMaster
        If unpromotedClassId = ClassList.Mage Then Return ClassList.Sage
        If unpromotedClassId = ClassList.Mage_F Then Return ClassList.Sage_F
        If unpromotedClassId = ClassList.Shaman Then Return ClassList.Druid
        If unpromotedClassId = ClassList.Fighter Then Return ClassList.Warrior
        If unpromotedClassId = ClassList.Pirate Then Return ClassList.Berserker
        If unpromotedClassId = ClassList.Monk Then Return ClassList.Bishop
        If unpromotedClassId = ClassList.Priest Then Return ClassList.Bishop
        If unpromotedClassId = ClassList.PegasusKnight Then Return ClassList.FalconKnight
        If unpromotedClassId = ClassList.Cleric Then Return ClassList.Bishop_F

        If unpromotedClassId = ClassList.Zombie Then Return ClassList.Mummy
        If unpromotedClassId = ClassList.Skeleton Then Return ClassList.Hellbone
        If unpromotedClassId = ClassList.SkeletonWithBow Then Return ClassList.HellboneWithBow
        If unpromotedClassId = ClassList.Bael Then Return ClassList.ElderBael
        If unpromotedClassId = ClassList.Mauthedoog Then Return ClassList.Cerberus
        If unpromotedClassId = ClassList.Tarvos Then Return ClassList.Macdaire
        If unpromotedClassId = ClassList.Mogall Then Return ClassList.ArchMogall
        If unpromotedClassId = ClassList.Gargoyle Then Return ClassList.Deathgoyle

        ' Handle trainees too. Assume super trainee for the time being.
        If unpromotedClassId = ClassList.Journeyman Then Return ClassList.Journeyman3
        If unpromotedClassId = ClassList.Recruit Then Return ClassList.Recruit3
        If unpromotedClassId = ClassList.Pupil Then Return ClassList.Pupil3

        Return ClassList.None
    End Function

    Public Shared Function alternatePromotionForPromotedClass(ByVal promotedClassId As ClassList) As ClassList
        If promotedClassId = ClassList.Paladin Then Return ClassList.GreatKnight
        If promotedClassId = ClassList.Paladin_F Then Return ClassList.GreatKnight_F
        If promotedClassId = ClassList.General Then Return ClassList.GreatKnight
        If promotedClassId = ClassList.General_F Then Return ClassList.GreatKnight_F
        If promotedClassId = ClassList.Assassin Then Return ClassList.Rogue
        If promotedClassId = ClassList.Hero Then Return ClassList.Ranger
        If promotedClassId = ClassList.Swordmaster Then Return ClassList.Assassin
        If promotedClassId = ClassList.Swordmaster_F Then Return ClassList.Assassin_F
        If promotedClassId = ClassList.Sniper Then Return ClassList.Ranger
        If promotedClassId = ClassList.Sniper_F Then Return ClassList.Ranger_F
        If promotedClassId = ClassList.DragonMaster Then Return ClassList.WyvernKnight
        If promotedClassId = ClassList.Sage Then Return ClassList.MageKnight
        If promotedClassId = ClassList.Sage_F Then Return ClassList.MageKnight_F
        If promotedClassId = ClassList.Druid Then Return ClassList.Summoner
        If promotedClassId = ClassList.Warrior Then Return ClassList.Hero
        If promotedClassId = ClassList.Berserker Then Return ClassList.Warrior
        If promotedClassId = ClassList.Bishop Then Return ClassList.Sage
        If promotedClassId = ClassList.FalconKnight Then Return ClassList.WyvernKnight_F
        If promotedClassId = ClassList.Bishop_F Then Return ClassList.Valkyrie

        Return ClassList.None
    End Function

    Public Shared Function unpromotedClassForPromotedClass(ByVal promotedClassId As ClassList) As ClassList
        If promotedClassId = ClassList.EphraimMasterLord Then Return ClassList.EphraimLord
        If promotedClassId = ClassList.EirikaMasterLord Then Return ClassList.EirikaLord
        If promotedClassId = ClassList.Paladin Then Return ClassList.Cavalier
        If promotedClassId = ClassList.Paladin_F Then Return ClassList.Cavalier_F
        If promotedClassId = ClassList.General Then Return ClassList.ArmorKnight
        If promotedClassId = ClassList.General_F Then Return ClassList.ArmorKnight_F
        If promotedClassId = ClassList.Swordmaster Then Return ClassList.Myrmidon
        If promotedClassId = ClassList.Swordmaster_F Then Return ClassList.Myrmidon_F
        If promotedClassId = ClassList.Assassin_F Then Return ClassList.Myrmidon_F
        If promotedClassId = ClassList.Sniper Then Return ClassList.Archer
        If promotedClassId = ClassList.Sniper_F Then Return ClassList.Archer_F
        If promotedClassId = ClassList.Ranger_F Then Return ClassList.Archer_F
        If promotedClassId = ClassList.DragonMaster Then Return ClassList.DragonKnight
        If promotedClassId = ClassList.WyvernKnight Then Return ClassList.DragonKnight
        If promotedClassId = ClassList.WyvernKnight_F Then Return ClassList.PegasusKnight
        If promotedClassId = ClassList.Sage_F Then Return ClassList.Mage_F
        If promotedClassId = ClassList.MageKnight Then Return ClassList.Mage
        If promotedClassId = ClassList.Bishop_F Then Return ClassList.Cleric
        If promotedClassId = ClassList.Druid Then Return ClassList.Shaman
        If promotedClassId = ClassList.Summoner Then Return ClassList.Shaman
        If promotedClassId = ClassList.Rogue Then Return ClassList.Thief
        If promotedClassId = ClassList.Berserker Then Return ClassList.Pirate
        If promotedClassId = ClassList.FalconKnight Then Return ClassList.PegasusKnight

        If promotedClassId = ClassList.Mummy Then Return ClassList.Zombie
        If promotedClassId = ClassList.Hellbone Then Return ClassList.Skeleton
        If promotedClassId = ClassList.HellboneWithBow Then Return ClassList.SkeletonWithBow
        If promotedClassId = ClassList.ElderBael Then Return ClassList.Bael
        If promotedClassId = ClassList.Cerberus Then Return ClassList.Mauthedoog
        If promotedClassId = ClassList.Macdaire Then Return ClassList.Tarvos
        If promotedClassId = ClassList.ArchMogall Then Return ClassList.Mogall
        If promotedClassId = ClassList.Deathgoyle Then Return ClassList.Gargoyle

        Return ClassList.None
    End Function

    Public Shared Function possibleDemotionsForPromotedClass(ByVal promotedClassId As ClassList) As ArrayList
        Dim list As ArrayList = New ArrayList()

        If promotedClassId = ClassList.Hero Then
            list.Add(ClassList.Mercenary)
            list.Add(ClassList.Fighter)
        ElseIf promotedClassId = ClassList.Assassin Then
            list.Add(ClassList.Myrmidon)
            list.Add(ClassList.Thief)
        ElseIf promotedClassId = ClassList.Ranger Then
            list.Add(ClassList.Archer)
            list.Add(ClassList.Mercenary)
        ElseIf promotedClassId = ClassList.Sage Then
            list.Add(ClassList.Mage)
            list.Add(ClassList.Monk)
            list.Add(ClassList.Priest)
        ElseIf promotedClassId = ClassList.MageKnight_F Then
            list.Add(ClassList.Mage_F)
            list.Add(ClassList.Troubadour)
        ElseIf promotedClassId = ClassList.Bishop Then
            list.Add(ClassList.Monk)
            list.Add(ClassList.Priest)
        ElseIf promotedClassId = ClassList.GreatKnight Then
            list.Add(ClassList.Cavalier)
            list.Add(ClassList.ArmorKnight)
        ElseIf promotedClassId = ClassList.GreatKnight_F Then
            list.Add(ClassList.Cavalier_F)
            list.Add(ClassList.ArmorKnight_F)
        ElseIf promotedClassId = ClassList.Warrior Then
            list.Add(ClassList.Fighter)
            list.Add(ClassList.Pirate)
        ElseIf promotedClassId = ClassList.Valkyrie Then
            list.Add(ClassList.Troubadour)
            list.Add(ClassList.Cleric)
        Else
            ' Return a list with the single class found in the method above.
            list.Add(unpromotedClassForPromotedClass(promotedClassId))
        End If

        ' Make sure none of the entries in the list include the "None" class.
        While list.Contains(ClassList.None)
            list.Remove(ClassList.None)
        End While

        Return list
    End Function

    Public Shared Function isValidClass(ByVal characterClass As Byte) As Boolean
        Return characterClass <> Convert.ToByte(ClassList.None) And
            System.Enum.IsDefined(GetType(ClassList), Convert.ToInt32(characterClass))
    End Function

    Public Shared Function shouldNotDemoteCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()

        Return list
    End Function

    Public Shared Function canNotPromoteCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(CharacterList.Tethys)

        Return list
    End Function

    Public Shared Function traineeCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(CharacterList.Ross)
        list.Add(CharacterList.Amelia)
        list.Add(CharacterList.Ewan)

        Return list
    End Function

    Public Shared Function randomClassFromOriginalClass(ByVal originalClass As Byte, ByVal allowLord As Boolean, ByVal allowThief As Boolean, ByVal allowUnique As Boolean, ByVal requiresPromotion As Boolean, ByVal requiresAttack As Boolean, ByVal isTrainee As Boolean, ByVal allowCrossgender As Boolean, ByRef rng As Random) As ClassList
        Dim original As ClassList = System.Enum.ToObject(GetType(ClassList), originalClass)

        Dim classListUnpromoted As ArrayList = New ArrayList

        If allowCrossgender Then
            classListUnpromoted = Utilities.arrayUnion(unpromotedClassList(True, allowUnique), unpromotedClassList(False, allowUnique))
        Else
            classListUnpromoted = unpromotedClassList(True, allowUnique)
        End If

        If Not allowLord Then
            classListUnpromoted.Remove(ClassList.EirikaLord)
            If allowCrossgender Then
                classListUnpromoted.Remove(ClassList.EphraimLord)
            End If
        End If

        If Not allowThief Then
            If allowCrossgender Then
                classListUnpromoted.Remove(ClassList.Thief)
            End If
        End If

        If Not allowUnique Then
            classListUnpromoted.Remove(ClassList.Dancer)
            classListUnpromoted.Remove(ClassList.Recruit2)
            If allowCrossgender Then
                classListUnpromoted.Remove(ClassList.Soldier)
                classListUnpromoted.Remove(ClassList.Journeyman2)
                classListUnpromoted.Remove(ClassList.Pupil2)
            End If
        Else
            If isTrainee Then
                classListUnpromoted.Remove(ClassList.Recruit2)
                classListUnpromoted.Add(ClassList.Recruit)
                If allowCrossgender Then
                    classListUnpromoted.Remove(ClassList.Pupil2)
                    classListUnpromoted.Add(ClassList.Pupil)
                    classListUnpromoted.Remove(ClassList.Journeyman2)
                    classListUnpromoted.Add(ClassList.Journeyman)
                End If
            End If
        End If

        If requiresAttack Then
            classListUnpromoted.Remove(ClassList.Troubadour)
            classListUnpromoted.Remove(ClassList.Cleric)
            classListUnpromoted.Remove(ClassList.Dancer)
            If allowCrossgender Then
                classListUnpromoted.Remove(ClassList.Priest)
            End If
        End If

        If requiresPromotion Then
            classListUnpromoted.Remove(ClassList.Dancer)
            If allowCrossgender Then
                classListUnpromoted.Remove(ClassList.Soldier)
            End If
        End If

        If classListUnpromoted.Contains(System.Enum.ToObject(GetType(ClassList), original)) Then
            Dim newClass As ClassList
            Do
                newClass = classListUnpromoted.Item(rng.Next(classListUnpromoted.Count))
            Loop While newClass = original

            Return newClass
        Else
            Dim classListPromoted = New ArrayList

            If allowCrossgender Then
                classListPromoted = Utilities.arrayUnion(promotedClassList(True, allowUnique), promotedClassList(False, allowUnique))
            Else
                classListPromoted = promotedClassList(True, allowUnique)
            End If

            If Not allowLord Then
                classListPromoted.Remove(ClassList.EirikaMasterLord)
                If allowCrossgender Then
                    classListPromoted.Remove(ClassList.EphraimMasterLord)
                End If
            End If

            If Not allowThief Then
                If allowCrossgender Then
                    classListPromoted.Remove(ClassList.Rogue)
                End If
            End If

            If Not allowUnique Then
                classListPromoted.Remove(ClassList.Recruit3)
                classListPromoted.Remove(ClassList.Manakete_F)
                If allowCrossgender Then
                    classListPromoted.Remove(ClassList.Pupil3)
                    classListPromoted.Remove(ClassList.Journeyman3)
                End If
            End If

            ' Don't allow these classes ever
            classListPromoted.Remove(ClassList.Necromancer)
            classListPromoted.Remove(ClassList.DragonZombie)

            If classListPromoted.Contains(System.Enum.ToObject(GetType(ClassList), original)) Then
                Dim newClass As ClassList
                Do
                    newClass = classListPromoted.Item(rng.Next(classListPromoted.Count))
                Loop While newClass = original

                Return newClass
            End If
        End If

        ' If we get here, allowCrossgender is false, and we need to look at male classes.
        classListUnpromoted = unpromotedClassList(False, allowUnique)

        If Not allowLord Then
            classListUnpromoted.Remove(ClassList.EphraimLord)
        End If
        If Not allowThief Then
            classListUnpromoted.Remove(ClassList.Thief)
        End If
        If Not allowUnique Then
            classListUnpromoted.Remove(ClassList.Soldier)
            classListUnpromoted.Remove(ClassList.Journeyman2)
            classListUnpromoted.Remove(ClassList.Pupil2)
        Else
            If isTrainee Then
                classListUnpromoted.Remove(ClassList.Pupil2)
                classListUnpromoted.Add(ClassList.Pupil)
                classListUnpromoted.Remove(ClassList.Journeyman2)
                classListUnpromoted.Add(ClassList.Journeyman)
            End If
        End If

        If requiresAttack Then
            classListUnpromoted.Remove(ClassList.Priest)
        End If

        If requiresPromotion Then
            classListUnpromoted.Remove(ClassList.Soldier)
        End If

        If classListUnpromoted.Contains(System.Enum.ToObject(GetType(ClassList), original)) Then
            Dim newClass As ClassList
            Do
                newClass = classListUnpromoted.Item(rng.Next(classListUnpromoted.Count))
            Loop While newClass = original

            Return newClass
        Else
            Dim classListPromoted As ArrayList = promotedClassList(False, allowUnique)

            If Not allowLord Then
                classListPromoted.Remove(ClassList.EphraimMasterLord)
            End If

            If Not allowThief Then
                classListPromoted.Remove(ClassList.Rogue)
            End If

            If Not allowUnique Then
                classListPromoted.Remove(ClassList.Pupil3)
                classListPromoted.Remove(ClassList.Journeyman3)
            End If

            ' Don't allow these classes ever
            classListPromoted.Remove(ClassList.Necromancer)
            classListPromoted.Remove(ClassList.DragonZombie)

            If classListPromoted.Contains(System.Enum.ToObject(GetType(ClassList), original)) Then
                Dim newClass As ClassList
                Do
                    newClass = classListPromoted.Item(rng.Next(classListPromoted.Count))
                Loop While newClass = original

                Return newClass
            End If
        End If

        ' We shouldn't get this far, but if we do, just return the original (i.e. no change)
        Return original
    End Function

    Public Shared Function playableCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(CharacterList.Eirika)
        list.Add(CharacterList.Seth)
        list.Add(CharacterList.Franz)
        list.Add(CharacterList.Gilliam)
        list.Add(CharacterList.Vanessa)
        list.Add(CharacterList.Moulder)
        list.Add(CharacterList.Ross)
        list.Add(CharacterList.Garcia)
        list.Add(CharacterList.Neimi)
        list.Add(CharacterList.Colm)
        list.Add(CharacterList.Lute)
        list.Add(CharacterList.Artur)
        list.Add(CharacterList.Natasha)
        list.Add(CharacterList.Joshua)
        list.Add(CharacterList.Ephraim)
        list.Add(CharacterList.Kyle)
        list.Add(CharacterList.Forde)
        list.Add(CharacterList.Tana)
        list.Add(CharacterList.Gerik)
        list.Add(CharacterList.Innes)
        list.Add(CharacterList.Tethys)
        list.Add(CharacterList.Amelia)
        list.Add(CharacterList.Marisa)
        list.Add(CharacterList.Larachel)
        list.Add(CharacterList.Dozla)
        list.Add(CharacterList.Saleh)
        list.Add(CharacterList.Ewan)
        list.Add(CharacterList.Cormag)
        list.Add(CharacterList.Rennac)
        list.Add(CharacterList.Duessel)
        list.Add(CharacterList.Knoll)
        list.Add(CharacterList.Myrrh)
        list.Add(CharacterList.Syrene)

        ' For our purposes, non-boss CC characters can be considered playable.
        list.Add(CharacterList.Ismaire)
        list.Add(CharacterList.Hayden)
        list.Add(CharacterList.Fado)
        
        Return list
    End Function

    Public Shared Function lordCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()
        list.Add(CharacterList.Ephraim)
        list.Add(CharacterList.Eirika)
        Return list
    End Function

    Public Shared Function thiefCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()
        list.Add(CharacterList.Colm)
        list.Add(CharacterList.Rennac)
        Return list
    End Function

    Public Shared Function bossCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(CharacterList.ONeill)
        list.Add(CharacterList.Breguet)
        list.Add(CharacterList.Bone)
        list.Add(CharacterList.Bazba)
        list.Add(CharacterList.Saar)
        list.Add(CharacterList.Zonta)
        list.Add(CharacterList.Novala)
        list.Add(CharacterList.Murray)
        list.Add(CharacterList.Tirado)
        list.Add(CharacterList.Binks)
        list.Add(CharacterList.Pablo10A)
        list.Add(CharacterList.Pablo13A)
        list.Add(CharacterList.Aias)
        list.Add(CharacterList.Carlyle)
        list.Add(CharacterList.Gheb)
        list.Add(CharacterList.Beran)

        list.Add(CharacterList.Caellach)
        list.Add(CharacterList.Caellach15)
        list.Add(CharacterList.Riev)
        list.Add(CharacterList.Riev1920)
        list.Add(CharacterList.Selena)
        list.Add(CharacterList.Selena10B13B)
        list.Add(CharacterList.Glen)
        list.Add(CharacterList.GlenCutscene)
        list.Add(CharacterList.Valter)
        list.Add(CharacterList.Valter15)
        list.Add(CharacterList.ValterPrologue)
        list.Add(CharacterList.Vigarde)
        list.Add(CharacterList.Orson)
        list.Add(CharacterList.Orson16)
        list.Add(CharacterList.Orson5x)

        Return list
    End Function

    Public Shared Function exemptCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(CharacterList.Lyon)
        list.Add(CharacterList.Lyon17)
        list.Add(CharacterList.LyonFinal)

        list.Add(CharacterList.DemonKing)

        list.Add(CharacterList.Morva)

        Return list
    End Function

    ' Some characters have a special requirement to have their
    ' movement costs modified since they do interesting things during
    ' their initial or scripted appearances. Mostly applies to fliers that spawn
    ' on otherwise impassable terrain.
    ' Since movement costs are on a by-class basis, we want to keep this list
    ' as small as we can, so that we affect as little as possible.
    Public Shared Function specialMovementCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(CharacterList.GlenCutscene) ' Not that it matters which Glen it is.
        list.Add(CharacterList.Valter15)

        Return list
    End Function

    Public Shared Function isBlacklisted(ByVal itemID As Byte) As Boolean
        Dim itemIDObject As ItemList = System.Enum.ToObject(GetType(ItemList), itemID)
        ' Sadly, ballistas don't work in FE8. :(
        If itemIDObject = ItemList.Dummy_Forblaze Or
            itemIDObject = ItemList.Dummy_Luce Or
            itemIDObject = ItemList.Dummy_ManiKatti Or
            itemIDObject = ItemList.Ballista Or
            itemIDObject = ItemList.KillerBallista Or
            itemIDObject = ItemList.IronBallista Or
            itemIDObject = ItemList.DemonLight Or
            itemIDObject = ItemList.Ravager Or
            itemIDObject = ItemList.Nightmare Then
            Return True
        End If

        Return False
    End Function

    Public Shared Function isLegendaryWeapon(ByVal itemID As Byte) As Boolean
        Dim itemIDObject As ItemList = System.Enum.ToObject(GetType(ItemList), itemID)
        If itemIDObject = ItemList.Sieglinde Or
            itemIDObject = ItemList.Siegmund Or
            itemIDObject = ItemList.Gleipnir Or
            itemIDObject = ItemList.Garm Or
            itemIDObject = ItemList.Vidofnir Or
            itemIDObject = ItemList.Nidhogg Or
            itemIDObject = ItemList.Audhulma Or
            itemIDObject = ItemList.Ivaldi Or
            itemIDObject = ItemList.Latona Or
            itemIDObject = ItemList.Excalibur Then
            Return True
        End If

        Return False
    End Function

    Public Shared Function physicalMonsterWeaponIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(ItemList.RottenClaw)
        list.Add(ItemList.FetidClaw)
        list.Add(ItemList.PoisonClaw)
        list.Add(ItemList.SharpClaw)
        list.Add(ItemList.LongPoisonClaw)

        list.Add(ItemList.FireFang)
        list.Add(ItemList.HellFang)

        Return list
    End Function

    Public Shared Function magicalMonsterWeaponIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(ItemList.DemonSurge)
        list.Add(ItemList.Shadowshot)
        list.Add(ItemList.Stone)

        list.Add(ItemList.EvilEye)
        list.Add(ItemList.BloodyEye)

        Return list
    End Function

    ' This list only deals with monster classes that don't use human weaponry.
    Public Shared Function monsterClassIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(ClassList.Zombie)
        list.Add(ClassList.Mummy)
        list.Add(ClassList.Bael)
        list.Add(ClassList.ElderBael)
        list.Add(ClassList.Mogall)
        list.Add(ClassList.ArchMogall)
        list.Add(ClassList.Mauthedoog)
        list.Add(ClassList.Cerberus)
        list.Add(ClassList.Gorgon)

        Return list
    End Function

    Public Shared Function randomMonsterWeaponForMonsterClass(ByVal classId As Byte, ByRef rng As Random) As ItemList
        Dim classIdObject As ClassList = System.Enum.ToObject(GetType(ClassList), classId)
        If classIdObject = ClassList.Mogall Then
            Dim randomNumber As Integer = rng.Next(0, 100)
            If randomNumber < 60 Then Return ItemList.EvilEye
            If randomNumber < 95 Then Return ItemList.BloodyEye
            Return ItemList.Shadowshot
        ElseIf classIdObject = ClassList.ArchMogall Then
            Dim randomNumber As Integer = rng.Next(0, 100)
            If randomNumber < 80 Then Return ItemList.BloodyEye
            If randomNumber < 95 Then Return ItemList.EvilEye
            Return ItemList.Shadowshot
        ElseIf classIdObject = ClassList.Zombie Or classIdObject = ClassList.Bael Then
            Dim randomNumber As Integer = rng.Next(0, 100)
            If randomNumber < 30 Then Return ItemList.RottenClaw
            If randomNumber < 50 Then Return ItemList.PoisonClaw
            If randomNumber < 70 Then Return ItemList.FetidClaw
            If randomNumber < 90 Then Return ItemList.LongPoisonClaw
            Return ItemList.SharpClaw
        ElseIf classIdObject = ClassList.Mummy Or classIdObject = ClassList.ElderBael Then
            Dim randomNumber As Integer = rng.Next(0, 100)
            If randomNumber < 10 Then Return ItemList.RottenClaw
            If randomNumber < 30 Then Return ItemList.PoisonClaw
            If randomNumber < 60 Then Return ItemList.FetidClaw
            If randomNumber < 80 Then Return ItemList.LongPoisonClaw
            Return ItemList.SharpClaw
        ElseIf classIdObject = ClassList.Mauthedoog Then
            Dim randomNumber As Integer = rng.Next(0, 100)
            If randomNumber < 80 Then Return ItemList.FireFang
            Return ItemList.HellFang
        ElseIf classIdObject = ClassList.Cerberus Then
            Dim randomNumber As Integer = rng.Next(0, 100)
            If randomNumber < 10 Then Return ItemList.FireFang
            Return ItemList.HellFang
        ElseIf classIdObject = ClassList.Gorgon Then
            Dim randomNumber As Integer = rng.Next(0, 100)
            If randomNumber < 20 Then Return ItemList.Stone
            If randomNumber < 40 Then Return ItemList.Shadowshot
        End If

        Return ItemList.None
    End Function

    Public Shared Function isHealingStaff(ByVal itemID As Byte) As Boolean
        Dim itemIDObject As ItemList = System.Enum.ToObject(GetType(ItemList), itemID)
        If itemIDObject = ItemList.Heal Or
            itemIDObject = ItemList.Mend Or
            itemIDObject = ItemList.Physic Or
            itemIDObject = ItemList.Recover Then Return True

        Return False
    End Function

    Public Shared Function randomizedFromThiefEquipment() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(ItemList.DoorKey)
        list.Add(ItemList.ChestKey)

        Return list
    End Function

    Public Shared Function randomizedToThiefEquipment() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(ItemList.Lockpick)

        Return list
    End Function

    Public Shared Function linkedCharacterIDsToCharacterID(ByVal characterId As Byte) As ArrayList
        Dim list As ArrayList = New ArrayList()

        Dim characterIDObject As CharacterList = System.Enum.ToObject(GetType(CharacterList), characterId)

        If characterIDObject = CharacterList.Caellach Then
            list.Add(CharacterList.Caellach15)
        ElseIf characterIDObject = CharacterList.Caellach15 Then
            list.Add(CharacterList.Caellach)
        ElseIf characterIDObject = CharacterList.Riev Then
            list.Add(CharacterList.Riev1920)
        ElseIf characterIDObject = CharacterList.Riev1920 Then
            list.Add(CharacterList.Riev)
        ElseIf characterIDObject = CharacterList.Selena Then
            list.Add(CharacterList.Selena10B13B)
        ElseIf characterIDObject = CharacterList.Selena10B13B Then
            list.Add(CharacterList.Selena)
        ElseIf characterIDObject = CharacterList.Glen Then
            list.Add(CharacterList.GlenCutscene)
        ElseIf characterIDObject = CharacterList.GlenCutscene Then
            list.Add(CharacterList.Glen)
        ElseIf characterIDObject = CharacterList.Valter Then
            list.Add(CharacterList.Valter15)
            list.Add(CharacterList.ValterPrologue)
        ElseIf characterIDObject = CharacterList.Valter15 Then
            list.Add(CharacterList.Valter)
            list.Add(CharacterList.ValterPrologue)
        ElseIf characterIDObject = CharacterList.ValterPrologue Then
            list.Add(CharacterList.Valter)
            list.Add(CharacterList.Valter15)
        ElseIf characterIDObject = CharacterList.Pablo10A Then
            list.Add(CharacterList.Pablo13A)
        ElseIf characterIDObject = CharacterList.Pablo13A Then
            list.Add(CharacterList.Pablo10A)

        ElseIf characterIDObject = CharacterList.Orson Then
            list.Add(CharacterList.Orson16)
            list.Add(CharacterList.Orson5x)
        ElseIf characterIDObject = CharacterList.Orson16 Then
            list.Add(CharacterList.Orson)
            list.Add(CharacterList.Orson5x)
        ElseIf characterIDObject = CharacterList.Orson5x Then
            list.Add(CharacterList.Orson)
            list.Add(CharacterList.Orson16)
        End If

        Return list
    End Function

    ' Reverse Recruitment Mapping.
    'Eirika			Knoll			Shaman      ' Did some flipping here to make things more reasonable.
    'Seth			Syrene			Falconknight
    'Franz			Myrrh			Manakete (F)
    'Gilliam		Duessel			Armor Knight
    'Vanessa		Rennac			Thief
    'Moulder		Cormag			Wyvern Rider
    'Ross			Ewan			Pupil
    'Garcia			Saleh			Mage
    'Neimi			Dozla			Pirate
    'Colm			L'Arachel		Troubadour
    'Artur			Marisa			Myrmidon (F)
    'Lute			Tethys			Dancer
    'Natasha		Gerik			Mercenary
    'Joshua			Innes			Archer
    'Ephraim		Amelia			Recruit (2)
    'Forde			Tana			Pegasus Knight
    'Kyle			Kyle			Cavalier
    'Tana			Forde			Cavalier
    'Amelia			Ephraim			Ephraim Lord
    'Innes			Joshua			Swordmaster
    'Gerik			Natasha			Cleric
    'Tethys			Lute			Mage (F)
    'Marisa			Artur			Monk
    'L'Arachel		Colm			Thief
    'Dozla			Neimi			Sniper (F)
    'Saleh			Garcia			Warrior
    'Ewan			Ross			Journeyman
    'Cormag			Moulder			Priest
    'Rennac			Vanessa			Falconknight
    'Duessel		Gilliam			General
    'Knoll			Eirika			Eirika Lord
    'Myrrh			Franz			Paladin
    'Syrene			Seth			Paladin

    Public Shared Function reversedRecruitmentMappingForCharacter(ByVal originalCharacter As CharacterList) As CharacterList
        If originalCharacter = CharacterList.Eirika Then Return CharacterList.Knoll
        If originalCharacter = CharacterList.Seth Then Return CharacterList.Syrene
        If originalCharacter = CharacterList.Franz Then Return CharacterList.Myrrh
        If originalCharacter = CharacterList.Gilliam Then Return CharacterList.Duessel
        If originalCharacter = CharacterList.Vanessa Then Return CharacterList.Rennac
        If originalCharacter = CharacterList.Moulder Then Return CharacterList.Cormag
        If originalCharacter = CharacterList.Ross Then Return CharacterList.Ewan
        If originalCharacter = CharacterList.Garcia Then Return CharacterList.Saleh
        If originalCharacter = CharacterList.Neimi Then Return CharacterList.Dozla
        If originalCharacter = CharacterList.Colm Then Return CharacterList.Larachel
        If originalCharacter = CharacterList.Artur Then Return CharacterList.Marisa
        If originalCharacter = CharacterList.Lute Then Return CharacterList.Tethys
        If originalCharacter = CharacterList.Natasha Then Return CharacterList.Gerik
        If originalCharacter = CharacterList.Joshua Then Return CharacterList.Innes
        If originalCharacter = CharacterList.Ephraim Then Return CharacterList.Amelia
        If originalCharacter = CharacterList.Forde Then Return CharacterList.Tana
        If originalCharacter = CharacterList.Kyle Then Return CharacterList.Kyle
        If originalCharacter = CharacterList.Tana Then Return CharacterList.Forde
        If originalCharacter = CharacterList.Amelia Then Return CharacterList.Ephraim
        If originalCharacter = CharacterList.Innes Then Return CharacterList.Joshua
        If originalCharacter = CharacterList.Gerik Then Return CharacterList.Natasha
        If originalCharacter = CharacterList.Tethys Then Return CharacterList.Lute
        If originalCharacter = CharacterList.Marisa Then Return CharacterList.Artur
        If originalCharacter = CharacterList.Larachel Then Return CharacterList.Colm
        If originalCharacter = CharacterList.Dozla Then Return CharacterList.Neimi
        If originalCharacter = CharacterList.Saleh Then Return CharacterList.Garcia
        If originalCharacter = CharacterList.Ewan Then Return CharacterList.Ross
        If originalCharacter = CharacterList.Cormag Then Return CharacterList.Moulder
        If originalCharacter = CharacterList.Rennac Then Return CharacterList.Vanessa
        If originalCharacter = CharacterList.Duessel Then Return CharacterList.Gilliam
        If originalCharacter = CharacterList.Knoll Then Return CharacterList.Eirika
        If originalCharacter = CharacterList.Myrrh Then Return CharacterList.Franz
        If originalCharacter = CharacterList.Syrene Then Return CharacterList.Seth

        Return originalCharacter
    End Function

    Public Shared Function reversedRecruitmentClassMappingForCharacter(ByVal originalCharacter As CharacterList) As ClassList
        If originalCharacter = CharacterList.Knoll Then Return ClassList.Shaman
        If originalCharacter = CharacterList.Syrene Then Return ClassList.FalconKnight
        If originalCharacter = CharacterList.Myrrh Then Return ClassList.Manakete_F
        If originalCharacter = CharacterList.Duessel Then Return ClassList.ArmorKnight
        If originalCharacter = CharacterList.Rennac Then Return ClassList.Thief
        If originalCharacter = CharacterList.Cormag Then Return ClassList.DragonKnight
        If originalCharacter = CharacterList.Ewan Then Return ClassList.Pupil
        If originalCharacter = CharacterList.Saleh Then Return ClassList.Mage
        If originalCharacter = CharacterList.Dozla Then Return ClassList.Pirate
        If originalCharacter = CharacterList.Larachel Then Return ClassList.Troubadour
        If originalCharacter = CharacterList.Marisa Then Return ClassList.Myrmidon_F
        If originalCharacter = CharacterList.Tethys Then Return ClassList.Dancer
        If originalCharacter = CharacterList.Gerik Then Return ClassList.Mercenary
        If originalCharacter = CharacterList.Innes Then Return ClassList.Archer
        If originalCharacter = CharacterList.Amelia Then Return ClassList.Recruit2
        If originalCharacter = CharacterList.Tana Then Return ClassList.PegasusKnight
        If originalCharacter = CharacterList.Kyle Then Return ClassList.Cavalier
        If originalCharacter = CharacterList.Forde Then Return ClassList.Cavalier
        If originalCharacter = CharacterList.Ephraim Then Return ClassList.EphraimLord
        If originalCharacter = CharacterList.Joshua Then Return ClassList.Swordmaster
        If originalCharacter = CharacterList.Natasha Then Return ClassList.Cleric
        If originalCharacter = CharacterList.Lute Then Return ClassList.Mage_F
        If originalCharacter = CharacterList.Artur Then Return ClassList.Monk
        If originalCharacter = CharacterList.Colm Then Return ClassList.Thief
        If originalCharacter = CharacterList.Neimi Then Return ClassList.Sniper_F
        If originalCharacter = CharacterList.Garcia Then Return ClassList.Warrior
        If originalCharacter = CharacterList.Ross Then Return ClassList.Journeyman
        If originalCharacter = CharacterList.Moulder Then Return ClassList.Priest
        If originalCharacter = CharacterList.Vanessa Then Return ClassList.FalconKnight
        If originalCharacter = CharacterList.Gilliam Then Return ClassList.General
        If originalCharacter = CharacterList.Eirika Then Return ClassList.EirikaLord
        If originalCharacter = CharacterList.Franz Then Return ClassList.Paladin
        If originalCharacter = CharacterList.Seth Then Return ClassList.Paladin

        Return ClassList.None
    End Function

    Public Shared Function UnitsInEachChapter() As ArrayList
        Dim arrayList As ArrayList = New ArrayList()

        arrayList.Add(6)            ' Prologue
        arrayList.Add(26)           ' Prologue Cutscene
        arrayList.Add(8)            ' Prologue Cutscene #2
        arrayList.Add(21)           ' Chapter 1
        arrayList.Add(26)           ' Chapter 2
        arrayList.Add(23)           ' Chapter 3
        arrayList.Add(10)           ' Chapter 3 Cutscene
        arrayList.Add(153)          ' Chapter 4
        arrayList.Add(51)           ' Chapter 5
        arrayList.Add(52)           ' Chapter 5x
        arrayList.Add(6)            ' Chapter 5x Cutscene
        arrayList.Add(23)           ' Chapter 5x Cutscene #2
        arrayList.Add(160)          ' Chapter 6
        arrayList.Add(31)           ' Chapter 7
        arrayList.Add(5)            ' Chapter 8 Cutscene
        arrayList.Add(73)           ' Chapter 8
        arrayList.Add(30)           ' Chapter 8 Cutscene #2
        arrayList.Add(96)           ' Chapter 9A
        arrayList.Add(11)           ' Chapter 9A Cutscene
        arrayList.Add(215)          ' Chapter 10A
        arrayList.Add(78)           ' Chapter 11A
        arrayList.Add(15)           ' Chapter 11A Cutscene
        arrayList.Add(86)           ' Chapter 12A
        arrayList.Add(217)          ' Chapter 13A
        arrayList.Add(6)            ' Chapter 13A Cutscene
        arrayList.Add(4)            ' Chapter 13A Cutscene #2
        arrayList.Add(96)           ' Chapter 14A
        arrayList.Add(6)            ' Chapter 14A Cutscene
        arrayList.Add(4)            ' Chapter 14A Cutscene #2
        arrayList.Add(7)            ' Chapter 14A Cutscene #3
        arrayList.Add(92)           ' Chapter 15A
        arrayList.Add(96)           ' Chapter 16A
        arrayList.Add(11)           ' Chapter 16A Cutscene
        arrayList.Add(22)           ' Chapter 16A Cutscene #2
        arrayList.Add(8)            ' Chapter 16A Cutscene #3
        arrayList.Add(8)            ' Chapter 16A Cutscene #4
        arrayList.Add(11)           ' Chapter 16A Cutscene #5
        arrayList.Add(214)          ' Chapter 17A
        arrayList.Add(228)          ' Chapter 18A
        arrayList.Add(112)          ' Chapter 19A
        arrayList.Add(11)           ' Chapter 19A Cutscene
        arrayList.Add(123)          ' Chapter 20A
        arrayList.Add(1)            ' Chapter 20A Cutscene
        arrayList.Add(86)           ' Final Chapter (A)
        arrayList.Add(19)           ' Final Boss
        arrayList.Add(81)           ' Chapter 9B
        arrayList.Add(6)            ' Chapter 9B Cutscene
        arrayList.Add(5)            ' Chapter 9B Cutscene #2
        arrayList.Add(204)          ' Chapter 10B
        arrayList.Add(13)           ' Chapter 10B Cutscene
        arrayList.Add(94)           ' Chapter 11B
        arrayList.Add(95)           ' Chapter 12B
        arrayList.Add(208)          ' Chapter 13B
        arrayList.Add(112)          ' Chapter 14B
        arrayList.Add(8)            ' Chapter 14B Cutscene
        arrayList.Add(21)           ' Chapter 14B Cutscene #2
        arrayList.Add(14)           ' Chapter 14B Cutscene #3
        arrayList.Add(101)          ' Chapter 15B
        arrayList.Add(79)           ' Chapter 16B
        arrayList.Add(175)          ' Chapter 17B
        arrayList.Add(220)          ' Chapter 18B
        arrayList.Add(109)          ' Chapter 19B
        arrayList.Add(123)          ' Chapter 20B

        arrayList.Add(110)          ' Final Chapter (B) + Valni 1
        arrayList.Add(77)           ' Valni 2
        arrayList.Add(133)          ' Valni 3
        arrayList.Add(445)          ' Valni 4 + Lagdou 1
        arrayList.Add(599)          ' Lagdou 2 + Melkaen Coast

        Return arrayList
    End Function
End Class
