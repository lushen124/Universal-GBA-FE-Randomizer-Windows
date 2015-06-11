Public Class FE8GameData
    Public Const DefaultCharacterTableOffset = &H803D30
    Public Const DefaultItemTableOffset = &H809B10
    Public Const DefaultClassTableOffset = &H807110

    Public Const PointerToCharacterTableOffset = &H17EF0
    Public Const PointerToItemTableOffset = &H16410
    Public Const PointerToClassTableOffset = &H17AB8

    Public Const CharacterCount = 256
    Public Const ItemCount = 206
    Public Const ClassCount = 128

    Public Const CharacterEntrySize = 52
    Public Const ItemEntrySize = 36
    Public Const ClassEntrySize = 84

    Public Const ChapterUnitEntrySize = 20

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

    Public Shared Function randomEffectiveness(ByRef rng As Random)
        Dim result = rng.Next(2, 9)
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
        Dim result = rng.Next(2, 15)
        If result = 2 Then Return StatBonusPointers.StatBonusPointerExcalibur
        If result = 3 Then Return StatBonusPointers.StatBonusPointerGleipnir
        If result = 4 Then Return StatBonusPointers.StatBonusPointerSieglinde
        If result = 5 Then Return StatBonusPointers.StatBonusPointerIvaldi
        If result = 6 Then Return StatBonusPointers.StatBonusPointerVidofnir
        If result = 7 Then Return StatBonusPointers.StatBonusPointerDecayingBreath
        If result = 8 Then Return StatBonusPointers.StatBonusPointerAudhulma
        If result = 9 Then Return StatBonusPointers.StatBonusPointerSiegmund
        If result = 10 Then Return StatBonusPointers.StatBonusPointerGarm
        If result = 11 Then Return StatBonusPointers.StatBonusPointerNidhogg
        If result = 12 Then Return StatBonusPointers.StatBonusPointerNightmare
        If result = 13 Then Return StatBonusPointers.StatBonusPointerDemonLight
        If result = 14 Then Return StatBonusPointers.StatBonusPointerRavager
        If result = 15 Then Return StatBonusPointers.StatBonusPointerDragonstone

        Return StatBonusPointers.StatBonusPointerNone

    End Function
End Class
