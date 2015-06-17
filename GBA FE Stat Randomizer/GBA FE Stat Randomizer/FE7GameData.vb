Public Class FE7GameData
    Public Const DefaultCharacterTableOffset = &HBDCE18
    Public Const DefaultItemTableOffset = &HBE222C
    Public Const DefaultClassTableOffset = &HBE015C

    Public Const PointerToCharacterTableOffset = &H17890
    Public Const PointerToItemTableOffset = &H16060
    Public Const PointerToClassTableOffset = &H178F0

    Public Const CharacterCount = 254
    Public Const ItemCount = 155
    Public Const ClassCount = 99

    Public Const CharacterEntrySize = 52
    Public Const ItemEntrySize = 36
    Public Const ClassEntrySize = 84

    Public Const ChapterUnitEntrySize = 16

    Public Enum EffectivenessPointers
        EffectivenessPointerNone = &H0
        EffectivenessPointerKnightsAndCavalry = &H8C97E9C
        EffectivenessPointerKnights = &H8C97E96
        EffectivenessPointerDragons = &H8C97EC5
        EffectivenessPointerCavalry = &H8C97EB7
        EffectivenessPointerMyrmidon = &H8C97EAD
        EffectivenessPointerFliers = &H8C97ED2
        EffectivenessPointerDragons2 = &H8C97EC5
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

    Public Enum StatBonusPointers
        StatBonusPointerNone = &H0
        StatBonusPointerUberSpear = &H8C99010
        StatBonusPointerDurandal = &H8C9901C
        StatBonusPointerArmads = &H8C99028
        StatBonusPointerAureola = &H8C99034
        StatBonusPointerSolKatti = &H8C99040
        StatBonusPointerDragonStone = &H8C9904C
        StatBonusPointerForblaze = &H8C98F98
    End Enum

    Public Enum ClassList
        None = &H0
        EliwoodLord = &H1
        LynLord = &H2
        HectorLord = &H3

        LordKnight = &H7
        BladeLord = &H8
        GreatLord = &H9
        Mercenary = &HA
        Mercenary_F = &HB ' Does this even work?
        Hero = &HC
        Hero_F = &HD ' There's one in FE6, but I don't know if this works in FE7
        Myrmidon = &HE
        Myrmidon_F = &HF ' I don't think there's one of these either. Karla starts as a swordmaster.
        Swordmaster = &H10
        Swordmaster_F = &H11
        Fighter = &H12
        Warrior = &H13
        Knight = &H14
        Knight_F = &H15 ' Don't think there are any of these either.
        General = &H16
        General_F = &H17 ' See Knight_F
        Archer = &H18
        Archer_F = &H19
        Sniper = &H1A
        Sniper_F = &H1B
        Monk = &H1C
        Cleric = &H1D
        Bishop = &H1E
        Bishop_F = &H1F
        Mage = &H20
        Mage_F = &H21
        Sage = &H22
        Sage_F = &H23
        Shaman = &H24
        Shaman_F = &H25 ' Doesn't exist either.
        Druid = &H26
        Druid_F = &H27 ' See Shaman_F
        Cavalier = &H28
        Cavalier_F = &H29 ' There's Isadora, but she's a paladin. This one may be glitched.
        Paladin = &H2A
        Paladin_F = &H2B
        Troubadour = &H2C
        Valkyrie = &H2D
        Nomad = &H2E
        Nomad_F = &H2F ' Actually doesn't exist either.
        NomadTrooper = &H30
        NomadTrooper_F = &H31 ' See Nomad_F
        PegasusKnight = &H32
        FalconKnight = &H33
        WyvernKnight = &H34
        WyvernKnight_F = &H35 ' Vaida's a Wyvern Lord :(
        WyvernLord = &H36
        WyvernLord_F = &H37
        Soldier = &H38
        Brigand = &H39
        Pirate = &H3A
        Berserker = &H3B
        Thief = &H3C
        Thief_F = &H3D ' Leila?
        Assassin = &H3E

        Dancer = &H40
        Bard = &H41
        Archsage = &H42
    End Enum

    Public Enum CharacterList
        None = &H0
        Eliwood = &H1
        Hector = &H2
        Tutorial_Lyn = &H3
        Raven = &H4
        Geitz = &H5
        Guy = &H6
        Karel = &H7
        Dorcas = &H8
        Bartre = &H9

        Oswin = &HB
        Fargus = &HC
        Tutorial_Wil = &HD
        Rebecca = &HE
        Louise = &HF
        Lucius = &H10
        Serra = &H11
        Renault = &H12
        Erk = &H13
        Nino = &H14
        Pent = &H15
        Canas = &H16
        Tutorial_Kent = &H17
        Tutorial_Sain = &H18
        Lowen = &H19
        Marcus = &H1A
        Priscilla = &H1B
        Tutorial_Rath = &H1C
        Tutorial_Florina = &H1D
        Fiora = &H1E
        Farina = &H1F
        Heath = &H20
        Vaida = &H21
        Hawkeye = &H22
        Matthew = &H23
        Jaffar = &H24
        Ninian = &H25
        Nils = &H26
        Athos = &H27
        Merlinus = &H28
        Nils_Final = &H29
        Uther = &H2A
        Vaida_Boss = &H2B
        Wallace = &H2C
        Lyn = &H2D
        Wil = &H2E
        Kent = &H2F
        Sain = &H30
        Florina = &H31
        Rath = &H32
        Dart = &H33
        Isadora = &H34
        Elenora = &H35
        Legault = &H36
        Karla = &H37
        Harken = &H38

        Leila = &H39
        Bramimond = &H3A
        Kishuna = &H3B

        Groznyi = &H3C
        Wire = &H3D

        Zagan = &H3F
        Boies = &H40
        Puzon = &H41

        Santals = &H43
        Nergal = &H44
        Erik = &H45
        Sealen = &H46
        Bauker = &H47
        Bernard = &H48
        Damian = &H49
        Zoldam = &H4A
        Uhai = &H4B
        Aian = &H4C
        Darin = &H4D
        Cameron = &H4E
        Oleg = &H4F
        Eubans = &H50
        Ursula = &H51

        Paul = &H53
        Jasmine = &H54

        Morph_Jerme = &H56
        Pascal = &H57
        Kenneth = &H58
        Jerme = &H59
        Maxime = &H5A
        Sonia = &H5B
        Teodor = &H5C
        Georg = &H5D
        Kaim = &H5E
        Denning = &H60

        Lloyd_A = &H63
        Linus_A = &H64
        Lloyd_B = &H65
        Linus_B = &H66

        Zephiel = &H7A
        Elbert = &H7B

        Brendan = &H84
        Limstella = &H85
        Dragon = &H86

        Batta = &H87

        Zugu = &H89

        Glass = &H8D
        Migal = &H8E

        Carjiga = &H94

        Bug = &H99

        Natalie = &H9E
        Bool = &H9F

        Heintz = &HA6

        Beyard = &HAD

        Yogi = &HB6

        Eagler = &HBE

        Lundgren = &HC5

        Morph_Lloyd = &HF4
        Morph_Linus = &HF5
        Morph_Brendan = &HF6
        Morph_Uhai = &HF7
        Morph_Ursula = &HF8
        Morph_Kenneth = &HF9
        Morph_Darin = &HFA
    End Enum

    Public Enum ChapterUnitReference
        Prologue = &HCC5B50
        Chapter1 = &HCC5BD0
        Chapter2 = &HCC5CE8
        Chapter3 = &HCC5E88
        Chapter4 = &HCC6058
        Chapter5 = &HCC6300
        Chapter6 = &HCC64E0
        Chapter7 = &HCC6940
        Chapter7x = &HCC6CD8
        Chapter8 = &HCC70F4
        Chapter9 = &HCC7484
        Chapter10 = &HCC7840

        Chapter11_Eliwood = &HCC7BDC
        Chapter11_Hector = &HCC803C
        Chapter12 = &HCC820C
        Chapter13 = &HCC86D4
        Chapter13x = &HCC8C64
        Chapter14 = &HCC9164
        Chapter15 = &HCC9C34
        Chapter16 = &HCCA198
        Chapter17 = &HCCABE0
        Chapter17x = &HCCB970
        Chapter18 = &HCCC1CC
        Chapter19 = &HCCCEB4
        Chapter19x = &HCCDA30
        Chapter19xx = &HCCE490
        Chapter20 = &HCCECEC
        Chapter21 = &HCCFDCC
        Chapter22 = &HCD0884
        Chapter23 = &HCD19FC
        Chapter23x = &HCD2734
        Chapter24_Linus = &HCD3B74
        Chapter24_Lloyd = &HCD2F58
        Chapter25_Cutscene = &HCD5234
        Chapter25 = &HCD4A54
        Chapter26 = &HCD53BC
        Chapter27_Jerme = &HCD6354
        Chapter27_Kenneth = &HCD7444
        Chapter28 = &HCD8498
        Chapter28x = &HCD9500
        Chapter29 = &HCDA738
        Chapter30_Eliwood = &HCDBD3C
        Chapter30_Hector = &HCDC3B4
        Chapter31 = &HCDC87C
        Chapter31x = &HCDDC9C
        Chapter32 = &HCDDED0
        Chapter32x = &HCDF7E4
        Chapter_FinalBoss = &HCE0898
        Chapter_Final = &HCDFE84
    End Enum

    Public Enum ItemList
        IronSword = &H1
        SlimSword = &H2
        SteelSword = &H3
        SilverSword = &H4
        IronBlade = &H5
        SteelBlade = &H6
        SilverBlade = &H7
        PoisonSword = &H8
        Rapier = &H9
        ManiKatti = &HA
        BraveSword = &HB
        WoDao = &HC
        KillingEdge = &HD
        Armorslayer = &HE
        Wyrmslayer = &HF
        LightBrand = &H10
        Runesword = &H11
        Lancereaver = &H12
        Longsword = &H13

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

        IronBow = &H2C
        SteelBow = &H2D
        SilverBow = &H2E
        PoisonBow = &H2F
        KillerBow = &H30
        BraveBow = &H31
        ShortBow = &H32
        Longbow = &H33
        Ballista = &H34
        IronBallista = &H35
        KillerBallista = &H36

        Fire = &H37
        Thunder = &H38
        Elfire = &H39
        Bolting = &H3A
        Fimbulvetr = &H3B
        Forblaze = &H3C
        Excalibur = &H3D

        Lightning = &H3E
        Shine = &H3F
        Divine = &H40
        Purge = &H41
        Aura = &H42
        Luce = &H43

        Flux = &H44
        Luna = &H45
        Nosferatu = &H46
        Eclipse = &H47
        Fenrir = &H48
        Gespenst = &H49

        Heal = &H4A
        Mend = &H4B
        Recover = &H4C
        Physic = &H4D
        Fortify = &H4E
        Restore = &H4F
        Silence = &H50
        Sleep = &H51
        Berserk = &H52
        Warp = &H53
        Rescue = &H54
        TorchStaff = &H55
        Hammerne = &H56
        Unlock = &H57
        Barrier = &H58

        DragonAxe = &H59

        AngelicRobe = &H5A
        EngergyRing = &H5B
        SecretBook = &H5C
        Speedwings = &H5D
        GoddessIcon = &H5E
        Dragonshield = &H5F
        Talisman = &H60
        Boots = &H61
        BodyRing = &H62

        HeroCrest = &H63
        KnightCrest = &H64
        OrionsBolt = &H65
        ElysianWhip = &H66
        GuidingRing = &H67

        ChestKeys = &H68
        DoorKeys = &H69
        Lockpick = &H6A

        Vulnerary = &H6B
        Elixir = &H6C
        PureWater = &H6D
        Antitoxin = &H6E
        Torch = &H6F
        DelphiShield = &H70
        MemberCard = &H71
        SilverCard = &H72
        WhiteGem = &H73
        BlueGem = &H74
        RedGem = &H75

        Unused_Gold = &H76
        Uberspear = &H77
        ChestKeys_5 = &H78
        Mine = &H79
        LightRune = &H7A
        IronRune = &H7B

        FillasMight = &H7C
        NinisGrace = &H7D
        ThorsIre = &H7E
        SetsLitany = &H7F

        EmblemSword = &H80
        EmblemSpear = &H81
        EmblemAxe = &H82
        EmblemBow = &H83

        Durandal = &H84
        Armads = &H85
        Aureola = &H86

        EarthSeal = &H87
        AfasDrops = &H88

        HeavenSeal = &H89
        EmblemSeal = &H8A
        FellContract = &H8B

        SolKatti = &H8C
        WolfBeil = &H8D

        Ereshkigal = &H8E
        Flametongue = &H8F
        RegalBlade = &H90
        RexHasta = &H91
        Basilikos = &H92
        Rienfleche = &H93

        HeavySpear = &H94
        ShortSpear = &H95

        OceanSeal = &H96

        Unused_3000G = &H97
        Unused_5000G = &H98

        WindSword = &H99

        Unused_SuperVulnerary = &H9A
    End Enum

    Public Shared Function randomEffectiveness(ByRef rng As Random)
        Dim result = rng.Next(2, 7)
        If result = 2 Then Return EffectivenessPointers.EffectivenessPointerKnightsAndCavalry
        If result = 3 Then Return EffectivenessPointers.EffectivenessPointerKnights
        If result = 4 Then Return EffectivenessPointers.EffectivenessPointerDragons
        If result = 5 Then Return EffectivenessPointers.EffectivenessPointerCavalry
        If result = 6 Then Return EffectivenessPointers.EffectivenessPointerMyrmidon
        If result = 7 Then Return EffectivenessPointers.EffectivenessPointerFliers

        Return EffectivenessPointers.EffectivenessPointerNone
    End Function

    Public Shared Function randomStatBonus(ByRef rng As Random)
        ' Probably not dragonstone... or uberspear
        Dim result = rng.Next(2, 8)
        If result = 2 Then Return randomStatBonus(rng) 'StatBonusPointers.StatBonusPointerUberSpear
        If result = 3 Then Return StatBonusPointers.StatBonusPointerDurandal
        If result = 4 Then Return StatBonusPointers.StatBonusPointerArmads
        If result = 5 Then Return StatBonusPointers.StatBonusPointerSolKatti
        If result = 6 Then Return StatBonusPointers.StatBonusPointerAureola
        If result = 7 Then Return randomStatBonus(rng) 'StatBonusPointers.StatBonusPointerDragonStone
        If result = 8 Then Return StatBonusPointers.StatBonusPointerForblaze

        Return StatBonusPointers.StatBonusPointerNone
    End Function

    Public Shared Function unpromotedClassList(ByVal female As Boolean) As ArrayList
        Dim list As ArrayList = New ArrayList()
        If female Then
            list.Add(ClassList.LynLord)
            list.Add(ClassList.Archer_F)
            list.Add(ClassList.Cleric)
            list.Add(ClassList.Mage_F)
            list.Add(ClassList.Troubadour)
            list.Add(ClassList.PegasusKnight)
            list.Add(ClassList.Dancer)
        Else
            list.Add(ClassList.EliwoodLord)
            list.Add(ClassList.HectorLord)
            list.Add(ClassList.Mercenary)
            list.Add(ClassList.Myrmidon)
            list.Add(ClassList.Fighter)
            list.Add(ClassList.Knight)
            list.Add(ClassList.Archer)
            list.Add(ClassList.Monk)
            list.Add(ClassList.Mage)
            list.Add(ClassList.Shaman)
            list.Add(ClassList.Cavalier)
            list.Add(ClassList.Nomad)
            list.Add(ClassList.WyvernKnight)
            list.Add(ClassList.Soldier)
            list.Add(ClassList.Pirate)
            list.Add(ClassList.Thief)
            list.Add(ClassList.Bard)
        End If

        Return list
    End Function

    Public Shared Function promotedClassList(ByVal female As Boolean) As ArrayList
        Dim list As ArrayList = New ArrayList()
        If female Then
            list.Add(ClassList.BladeLord)
            list.Add(ClassList.Swordmaster_F)
            list.Add(ClassList.Sniper_F)
            list.Add(ClassList.Bishop_F)
            list.Add(ClassList.Sage_F)
            list.Add(ClassList.Paladin_F)
            list.Add(ClassList.Valkyrie)
            list.Add(ClassList.FalconKnight)
        Else
            list.Add(ClassList.LordKnight)
            list.Add(ClassList.GreatLord)
            list.Add(ClassList.Hero)
            list.Add(ClassList.Swordmaster)
            list.Add(ClassList.Warrior)
            list.Add(ClassList.General)
            list.Add(ClassList.Sniper)
            list.Add(ClassList.Bishop)
            list.Add(ClassList.Sage)
            list.Add(ClassList.Druid)
            list.Add(ClassList.Paladin)
            list.Add(ClassList.NomadTrooper)
            list.Add(ClassList.WyvernLord)
            list.Add(ClassList.Berserker)
            list.Add(ClassList.Assassin)
            list.Add(ClassList.Archsage)
        End If

        Return list
    End Function

    Public Shared Function promotedClassForUnpromotedClass(ByVal unpromotedClassId As ClassList) As ClassList
        If unpromotedClassId = ClassList.EliwoodLord Then Return ClassList.LordKnight
        If unpromotedClassId = ClassList.LynLord Then Return ClassList.BladeLord
        If unpromotedClassId = ClassList.HectorLord Then Return ClassList.GreatLord
        If unpromotedClassId = ClassList.Mercenary Then Return ClassList.Hero
        If unpromotedClassId = ClassList.Myrmidon Then Return ClassList.Swordmaster
        If unpromotedClassId = ClassList.Fighter Then Return ClassList.Warrior
        If unpromotedClassId = ClassList.Knight Then Return ClassList.General
        If unpromotedClassId = ClassList.Archer Then Return ClassList.Sniper
        If unpromotedClassId = ClassList.Archer_F Then Return ClassList.Sniper_F
        If unpromotedClassId = ClassList.Monk Then Return ClassList.Bishop
        If unpromotedClassId = ClassList.Cleric Then Return ClassList.Bishop_F
        If unpromotedClassId = ClassList.Mage Then Return ClassList.Sage
        If unpromotedClassId = ClassList.Mage_F Then Return ClassList.Sage_F
        If unpromotedClassId = ClassList.Shaman Then Return ClassList.Druid
        If unpromotedClassId = ClassList.Cavalier Then Return ClassList.Paladin
        If unpromotedClassId = ClassList.Troubadour Then Return ClassList.Valkyrie
        If unpromotedClassId = ClassList.Nomad Then Return ClassList.NomadTrooper
        If unpromotedClassId = ClassList.PegasusKnight Then Return ClassList.FalconKnight
        If unpromotedClassId = ClassList.WyvernKnight Then Return ClassList.WyvernLord
        If unpromotedClassId = ClassList.Pirate Then Return ClassList.Berserker
        If unpromotedClassId = ClassList.Thief Then Return ClassList.Assassin

        Return ClassList.None
    End Function

    Public Shared Function unpromotedClassForPromotedClass(ByVal promotedClassId As ClassList) As ClassList
        If promotedClassId = ClassList.LordKnight Then Return ClassList.EliwoodLord
        If promotedClassId = ClassList.BladeLord Then Return ClassList.LynLord
        If promotedClassId = ClassList.GreatLord Then Return ClassList.HectorLord
        If promotedClassId = ClassList.Hero Then Return ClassList.Mercenary
        If promotedClassId = ClassList.Swordmaster Then Return ClassList.Myrmidon
        If promotedClassId = ClassList.Warrior Then Return ClassList.Fighter
        If promotedClassId = ClassList.General Then Return ClassList.Knight
        If promotedClassId = ClassList.Sniper Then Return ClassList.Archer
        If promotedClassId = ClassList.Sniper_F Then Return ClassList.Archer_F
        If promotedClassId = ClassList.Bishop Then Return ClassList.Monk
        If promotedClassId = ClassList.Bishop_F Then Return ClassList.Cleric
        If promotedClassId = ClassList.Sage Then Return ClassList.Mage
        If promotedClassId = ClassList.Sage_F Then Return ClassList.Mage_F
        If promotedClassId = ClassList.Druid Then Return ClassList.Shaman
        If promotedClassId = ClassList.Paladin Then Return ClassList.Cavalier
        If promotedClassId = ClassList.Valkyrie Then Return ClassList.Troubadour
        If promotedClassId = ClassList.NomadTrooper Then Return ClassList.Nomad
        If promotedClassId = ClassList.FalconKnight Then Return ClassList.PegasusKnight
        If promotedClassId = ClassList.WyvernLord Then Return ClassList.WyvernKnight
        If promotedClassId = ClassList.Berserker Then Return ClassList.Pirate
        If promotedClassId = ClassList.Assassin Then Return ClassList.Thief

        Return ClassList.None
    End Function

    Public Shared Function isValidClass(ByVal characterClass As Byte) As Boolean
        Return characterClass <= Convert.ToByte(ClassList.HectorLord) Or
            (characterClass >= Convert.ToByte(ClassList.LordKnight) And characterClass <= Convert.ToByte(ClassList.Assassin)) Or
            (characterClass >= Convert.ToByte(ClassList.Dancer) And characterClass <= Convert.ToByte(ClassList.Archsage))

    End Function

    Public Shared Function shouldNotDemoteCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(CharacterList.Vaida)
        list.Add(CharacterList.Athos)
        list.Add(CharacterList.Isadora)
        list.Add(CharacterList.Karla)

        Return list
    End Function

    Public Shared Function canNotPromoteCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(CharacterList.Ninian)
        list.Add(CharacterList.Nils)

        Return list
    End Function

    Public Shared Function randomClassFromOriginalClass(ByVal original As ClassList, ByVal allowLord As Boolean, ByVal allowThief As Boolean, ByVal allowUnique As Boolean, ByRef rng As Random) As ClassList
        Dim classListUnpromoted As ArrayList = unpromotedClassList(True)
        If Not allowLord Then
            classListUnpromoted.Remove(ClassList.LynLord)
        End If
        If Not allowUnique Then
            classListUnpromoted.Remove(ClassList.Dancer)
        End If

        If classListUnpromoted.Contains(System.Enum.ToObject(GetType(ClassList), original)) Then
            Dim newClass As ClassList
            Do
                newClass = classListUnpromoted.Item(rng.Next(classListUnpromoted.Count))
            Loop While newClass = original

            Return newClass
        Else
            Dim classListPromoted = promotedClassList(True)

            If Not allowLord Then
                classListPromoted.Remove(ClassList.BladeLord)
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
            classListUnpromoted.Remove(ClassList.EliwoodLord)
            classListUnpromoted.Remove(ClassList.HectorLord)
        End If
        If Not allowThief Then
            classListUnpromoted.Remove(ClassList.Thief)
        End If
        If Not allowUnique Then
            classListUnpromoted.Remove(ClassList.Brigand)
            classListUnpromoted.Remove(ClassList.Soldier)
            classListUnpromoted.Remove(ClassList.Bard)
        End If

        If classListUnpromoted.Contains(System.Enum.ToObject(GetType(ClassList), original)) Then
            Dim newClass As ClassList
            Do
                newClass = classListUnpromoted.Item(rng.Next(classListUnpromoted.Count))
            Loop While newClass = original

            Return newClass
        Else
            Dim classListPromoted As ArrayList = promotedClassList(False)

            If Not allowLord Then
                classListPromoted.Remove(ClassList.LordKnight)
                classListPromoted.Remove(ClassList.GreatLord)
            End If
            If Not allowUnique Then
                classListPromoted.Remove(ClassList.Archsage)
            End If

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

        list.Add(CharacterList.Eliwood)
        list.Add(CharacterList.Hector)
        list.Add(CharacterList.Raven)
        list.Add(CharacterList.Geitz)
        list.Add(CharacterList.Guy)
        list.Add(CharacterList.Karel)
        list.Add(CharacterList.Dorcas)
        list.Add(CharacterList.Bartre)
        list.Add(CharacterList.Oswin)
        list.Add(CharacterList.Rebecca)
        list.Add(CharacterList.Louise)
        list.Add(CharacterList.Lucius)
        list.Add(CharacterList.Serra)
        list.Add(CharacterList.Renault)
        list.Add(CharacterList.Erk)
        list.Add(CharacterList.Nino)
        list.Add(CharacterList.Pent)
        list.Add(CharacterList.Canas)
        list.Add(CharacterList.Lowen)
        list.Add(CharacterList.Marcus)
        list.Add(CharacterList.Priscilla)
        list.Add(CharacterList.Fiora)
        list.Add(CharacterList.Farina)
        list.Add(CharacterList.Heath)
        list.Add(CharacterList.Vaida)
        list.Add(CharacterList.Hawkeye)
        list.Add(CharacterList.Matthew)
        list.Add(CharacterList.Jaffar)
        list.Add(CharacterList.Ninian)
        list.Add(CharacterList.Nils)
        list.Add(CharacterList.Athos)
        list.Add(CharacterList.Wallace)
        list.Add(CharacterList.Lyn)
        list.Add(CharacterList.Wil)
        list.Add(CharacterList.Kent)
        list.Add(CharacterList.Sain)
        list.Add(CharacterList.Florina)
        list.Add(CharacterList.Rath)
        list.Add(CharacterList.Dart)
        list.Add(CharacterList.Isadora)
        list.Add(CharacterList.Legault)
        list.Add(CharacterList.Karla)
        list.Add(CharacterList.Harken)

        list.Add(CharacterList.Tutorial_Lyn)
        list.Add(CharacterList.Tutorial_Sain)
        list.Add(CharacterList.Tutorial_Kent)
        list.Add(CharacterList.Tutorial_Wil)
        list.Add(CharacterList.Tutorial_Rath)
        list.Add(CharacterList.Tutorial_Florina)

        Return list
    End Function

    Public Shared Function lordCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()
        list.Add(CharacterList.Eliwood)
        list.Add(CharacterList.Hector)
        list.Add(CharacterList.Lyn)
        Return list
    End Function

    Public Shared Function thiefCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()
        list.Add(CharacterList.Matthew)
        list.Add(CharacterList.Legault)
        Return list
    End Function

    Public Shared Function bossCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(CharacterList.Groznyi)
        list.Add(CharacterList.Wire)
        list.Add(CharacterList.Zagan)
        list.Add(CharacterList.Boies)
        list.Add(CharacterList.Puzon)
        list.Add(CharacterList.Santals)
        list.Add(CharacterList.Erik)
        list.Add(CharacterList.Sealen)
        list.Add(CharacterList.Bauker)
        list.Add(CharacterList.Bernard)
        list.Add(CharacterList.Damian)
        list.Add(CharacterList.Zoldam)
        list.Add(CharacterList.Uhai)
        list.Add(CharacterList.Aian)
        list.Add(CharacterList.Darin)
        list.Add(CharacterList.Cameron)
        list.Add(CharacterList.Oleg)
        list.Add(CharacterList.Eubans)
        list.Add(CharacterList.Ursula)
        list.Add(CharacterList.Paul)
        list.Add(CharacterList.Jasmine)
        list.Add(CharacterList.Pascal)
        list.Add(CharacterList.Kenneth)
        list.Add(CharacterList.Jerme)
        list.Add(CharacterList.Maxime)
        list.Add(CharacterList.Sonia)
        list.Add(CharacterList.Teodor)
        list.Add(CharacterList.Georg)
        list.Add(CharacterList.Kaim)
        list.Add(CharacterList.Denning)
        list.Add(CharacterList.Lloyd_A)
        list.Add(CharacterList.Linus_A)
        list.Add(CharacterList.Lloyd_B)
        list.Add(CharacterList.Linus_B)

        list.Add(CharacterList.Dragon)
        list.Add(CharacterList.Batta)
        list.Add(CharacterList.Zugu)
        list.Add(CharacterList.Glass)
        list.Add(CharacterList.Migal)
        list.Add(CharacterList.Carjiga)
        list.Add(CharacterList.Bug)
        list.Add(CharacterList.Bool)
        list.Add(CharacterList.Heintz)
        list.Add(CharacterList.Beyard)
        list.Add(CharacterList.Yogi)
        list.Add(CharacterList.Eagler)
        list.Add(CharacterList.Lundgren)

        list.Add(CharacterList.Morph_Brendan)
        list.Add(CharacterList.Morph_Darin)
        list.Add(CharacterList.Morph_Jerme)
        list.Add(CharacterList.Morph_Kenneth)
        list.Add(CharacterList.Morph_Linus)
        list.Add(CharacterList.Morph_Lloyd)
        list.Add(CharacterList.Morph_Uhai)
        list.Add(CharacterList.Morph_Ursula)

        Return list
    End Function

    Public Shared Function exemptCharacterIDs() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(CharacterList.Leila)
        list.Add(CharacterList.Bramimond)
        list.Add(CharacterList.Kishuna)

        list.Add(CharacterList.Nergal)
        list.Add(CharacterList.Limstella)
        list.Add(CharacterList.Dragon)
        list.Add(CharacterList.Zephiel)
        list.Add(CharacterList.Elbert)
        list.Add(CharacterList.Natalie)

        list.Add(CharacterList.Fargus)
        list.Add(CharacterList.Merlinus)
        list.Add(CharacterList.Vaida_Boss)
        list.Add(CharacterList.Uther)
        list.Add(CharacterList.Elenora)

        Return list
    End Function

    Shared Function isBlacklisted(ByVal itemID As Byte) As Boolean
        Dim itemIDObject As ItemList = System.Enum.ToObject(GetType(ItemList), itemID)
        If itemIDObject = ItemList.Unused_3000G Or
            itemIDObject = ItemList.Unused_5000G Or
            itemIDObject = ItemList.Unused_Gold Or
            itemIDObject = ItemList.Unused_SuperVulnerary Then
            Return True
        End If

        Return False
    End Function

    Public Shared Function randomizedFromThiefEquipment() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(ItemList.DoorKeys)
        list.Add(ItemList.ChestKeys_5)

        Return list
    End Function

    Public Shared Function randomizedToThiefEquipment() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(ItemList.Lockpick)

        Return list
    End Function

    Public Shared Function randomizedToDancerEquipment() As ArrayList
        Dim list As ArrayList = New ArrayList()

        list.Add(ItemList.NinisGrace)

        Return list
    End Function

    Public Shared Function linkedCharacterIDsToCharacterID(ByVal characterId As Byte) As ArrayList
        Dim list As ArrayList = New ArrayList()

        Dim characterIdObject As CharacterList = System.Enum.ToObject(GetType(CharacterList), characterId)

        If characterIdObject = CharacterList.Tutorial_Florina Then
            list.Add(CharacterList.Florina)
        ElseIf characterIdObject = CharacterList.Tutorial_Kent Then
            list.Add(CharacterList.Kent)
        ElseIf characterIdObject = CharacterList.Tutorial_Lyn Then
            list.Add(CharacterList.Lyn)
        ElseIf characterIdObject = CharacterList.Tutorial_Rath Then
            list.Add(CharacterList.Rath)
        ElseIf characterIdObject = CharacterList.Tutorial_Sain Then
            list.Add(CharacterList.Sain)
        ElseIf characterIdObject = CharacterList.Tutorial_Wil Then
            list.Add(CharacterList.Wil)
        ElseIf characterIdObject = CharacterList.Florina Then
            list.Add(CharacterList.Tutorial_Florina)
        ElseIf characterIdObject = CharacterList.Kent Then
            list.Add(CharacterList.Tutorial_Kent)
        ElseIf characterIdObject = CharacterList.Lyn Then
            list.Add(CharacterList.Tutorial_Lyn)
        ElseIf characterIdObject = CharacterList.Rath Then
            list.Add(CharacterList.Tutorial_Rath)
        ElseIf characterIdObject = CharacterList.Sain Then
            list.Add(CharacterList.Tutorial_Sain)
        ElseIf characterIdObject = CharacterList.Wil Then
            list.Add(CharacterList.Tutorial_Wil)

        ElseIf characterIdObject = CharacterList.Morph_Brendan Then
            list.Add(CharacterList.Brendan)
        ElseIf characterIdObject = CharacterList.Morph_Darin Then
            list.Add(CharacterList.Darin)
        ElseIf characterIdObject = CharacterList.Morph_Jerme Then
            list.Add(CharacterList.Jerme)
        ElseIf characterIdObject = CharacterList.Morph_Kenneth Then
            list.Add(CharacterList.Kenneth)
        ElseIf characterIdObject = CharacterList.Morph_Linus Then
            list.Add(CharacterList.Linus_A)
            list.Add(CharacterList.Linus_B)
        ElseIf characterIdObject = CharacterList.Morph_Lloyd Then
            list.Add(CharacterList.Lloyd_A)
            list.Add(CharacterList.Lloyd_B)
        ElseIf characterIdObject = CharacterList.Morph_Uhai Then
            list.Add(CharacterList.Uhai)
        ElseIf characterIdObject = CharacterList.Morph_Ursula Then
            list.Add(CharacterList.Ursula)
        ElseIf characterIdObject = CharacterList.Brendan Then
            list.Add(CharacterList.Morph_Brendan)
        ElseIf characterIdObject = CharacterList.Darin Then
            list.Add(CharacterList.Morph_Darin)
        ElseIf characterIdObject = CharacterList.Jerme Then
            list.Add(CharacterList.Morph_Jerme)
        ElseIf characterIdObject = CharacterList.Kenneth Then
            list.Add(CharacterList.Morph_Kenneth)
        ElseIf characterIdObject = CharacterList.Linus_A Then
            list.Add(CharacterList.Morph_Linus)
            list.Add(CharacterList.Linus_B)
        ElseIf characterIdObject = CharacterList.Linus_B Then
            list.Add(CharacterList.Morph_Linus)
            list.Add(CharacterList.Linus_A)
        ElseIf characterIdObject = CharacterList.Lloyd_A Then
            list.Add(CharacterList.Morph_Lloyd)
            list.Add(CharacterList.Lloyd_B)
        ElseIf characterIdObject = CharacterList.Lloyd_B Then
            list.Add(CharacterList.Morph_Lloyd)
            list.Add(CharacterList.Lloyd_A)
        ElseIf characterIdObject = CharacterList.Uhai Then
            list.Add(CharacterList.Morph_Uhai)
        ElseIf characterIdObject = CharacterList.Ursula Then
            list.Add(CharacterList.Morph_Ursula)
        End If

        Return list
    End Function

    Public Shared Function legendaryWeaponForClass(ByVal classId As Byte) As ItemList
        Dim classIdObject As ClassList = System.Enum.ToObject(GetType(ClassList), classId)

        If classIdObject = ClassList.Sniper Or classIdObject = ClassList.Sniper_F Or
            classIdObject = ClassList.NomadTrooper Then
            Return ItemList.Rienfleche
        ElseIf classIdObject = ClassList.Bishop_F Or classIdObject = ClassList.Bishop_F Then
            Return ItemList.Luce
        ElseIf classIdObject = ClassList.Druid Then
            Return ItemList.Gespenst
        ElseIf classIdObject = ClassList.Warrior Or classIdObject = ClassList.Berserker Then
            Return ItemList.Basilikos
        ElseIf classIdObject = ClassList.Paladin Or classIdObject = ClassList.Paladin_F Or
            classIdObject = ClassList.General Or
            classIdObject = ClassList.WyvernLord Or classIdObject = ClassList.WyvernLord_F Or
            classIdObject = ClassList.FalconKnight Then
            Return ItemList.RexHasta
        ElseIf classIdObject = ClassList.Sage Or classIdObject = ClassList.Sage_F Or
            classIdObject = ClassList.Valkyrie Then
            Return ItemList.Excalibur
        ElseIf classIdObject = ClassList.Swordmaster Or classIdObject = ClassList.Swordmaster_F Or
            classIdObject = ClassList.Hero Or classIdObject = ClassList.Assassin Then
            Return ItemList.RegalBlade
        ElseIf classIdObject = ClassList.LordKnight Then
            Return ItemList.Durandal
        ElseIf classIdObject = ClassList.BladeLord Then
            Return ItemList.SolKatti
        ElseIf classIdObject = ClassList.GreatLord Then
            Return ItemList.Armads
        End If

        Return Nothing
    End Function

    ' Reverse Recruitment Mapping.
    'Hector         Athos           Mage (?)
    'Matthew        Renault         Monk
    'Oswin          Karla           Myrmidon (F) (!) ' Uses male battle sprite, but female map sprite.
    'Serra          Nils            Bard

    'Eliwood        Jaffar          Thief
    'Marcus         Vaida           Wyvern Lord (F)  ' Flipped with Jaffar for less issues.
    'Lowen          Nino            Mage (F)
    'Rebecca        Harken          Mercenary
    'Dorcas         Karel           Myrmidon
    'Bartre         Louise          Archer (F)
    
    'Guy            Pent            Mage
    'Erk            Farina          Pegasus Knight
    'Priscilla      Wallace         Armor Knight
    'Lyn            Geitz           Fighter
    'Sain           Hawkeye         Pirate
    'Kent           Heath           Wyvern Knight
    'Florina        Rath            Nomad
    'Wil            Isadora         Cavalier (F) (!) ' This may have to be a sex change here.
    'Raven          Ninian          Dancer
    'Lucius         Legault         Thief
    'Canas          Fiora           Pegasus Knight
    'Dart           Dart            Pirate
    'Fiora          Canas           Shaman
    'Legault        Lucius          Monk
    'Ninian         Raven           Mercenary
    'Isadora        Wil             Sniper
    'Rath           Florina         Pegasus Knight
    'Heath          Kent            Cavalier
    'Hawkeye        Sain            Paladin
    'Geitz          Lyn             Blade Lord
    'Wallace        Priscilla       Valkyrie
    'Farina         Erk             Mage
    'Pent           Guy             Swordmaster
    'Louise         Bartre          Warrior
    'Karel          Dorcas          Warrior
    'Harken         Rebecca         Sniper (F)
    'Nino           Lowen           Cavalier
    'Jaffar         Eliwood         Lord Knight
    'Vaida          Marcus          Paladin
    'Nils           Serra           Cleric
    'Karla          Oswin           General
    'Renault        Matthew         Assassin
    'Athos          Hector          Great Lord

    Public Shared Function UnitsInEachChapter() As ArrayList
        Dim arrayList As ArrayList = New ArrayList()

        arrayList.Add(4)                ' Prologue
        arrayList.Add(12)               ' Chapter 1
        arrayList.Add(18)               ' Chapter 2
        arrayList.Add(21)               ' Chapter 3
        arrayList.Add(32)               ' Chapter 4
        arrayList.Add(22)               ' Chapter 5
        arrayList.Add(57)               ' Chapter 6
        arrayList.Add(47)               ' Chapter 7
        arrayList.Add(54)               ' Chapter 7x
        arrayList.Add(49)               ' Chapter 8
        arrayList.Add(48)               ' Chapter 9
        arrayList.Add(51)               ' Chapter 10

        arrayList.Add(47)               ' Chapter 11 - Eliwood
        arrayList.Add(20)               ' Chapter 11 - Hector
        arrayList.Add(61)               ' Chapter 12
        arrayList.Add(71)               ' Chapter 13
        arrayList.Add(67)               ' Chapter 13x
        arrayList.Add(150)              ' Chapter 14
        arrayList.Add(72)               ' Chapter 15
        arrayList.Add(144)              ' Chapter 16
        arrayList.Add(184)              ' Chapter 17
        arrayList.Add(117)              ' Chapter 17x
        arrayList.Add(176)              ' Chapter 18
        arrayList.Add(162)              ' Chapter 19
        arrayList.Add(148)              ' Chapter 19x
        arrayList.Add(117)              ' Chapter 19xx
        arrayList.Add(227)              ' Chapter 20
        arrayList.Add(146)              ' Chapter 21
        arrayList.Add(229)              ' Chapter 22
        arrayList.Add(186)              ' Chapter 23
        arrayList.Add(116)              ' Chapter 23x
        arrayList.Add(210)              ' Chapter 24 - Linus
        arrayList.Add(167)              ' Chapter 24 - Lloyd
        arrayList.Add(4)                ' Chapter 25 - Cutscene (for a cutscene?)
        arrayList.Add(130)              ' Chapter 25
        arrayList.Add(219)              ' Chapter 26
        arrayList.Add(248)              ' Chapter 27 - Jerme
        arrayList.Add(222)              ' Chapter 27 - Kenneth
        arrayList.Add(230)              ' Chapter 28
        arrayList.Add(251)              ' Chapter 28x
        arrayList.Add(308)              ' Chapter 29
        arrayList.Add(88)               ' Chapter 30 - Eliwood
        arrayList.Add(66)               ' Chapter 30 - Hector
        arrayList.Add(274)              ' Chapter 31
        arrayList.Add(26)               ' Chapter 31x
        arrayList.Add(347)              ' Chapter 32
        arrayList.Add(86)               ' Chapter 32x
        arrayList.Add(56)               ' Chapter Final Boss
        arrayList.Add(132)              ' Chapter Final

        Return arrayList
    End Function
End Class
