Public Class FE7GameData
    Public Const DefaultCharacterTableOffset = &HBDCE18
    Public Const DefaultItemTableOffset = &HBE222C
    Public Const DefaultClassTableOffset = &HBE015C

    Public Const PointerToCharacterTableOffset = &H17890
    Public Const PointerToItemTableOffset = &H16060
    Public Const PointerToClassTableOffset = &H178F0

    Public Const CharacterCount = 254
    Public Const ItemCount = 159
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
        Dim result = rng.Next(2, 8)
        If result = 2 Then Return StatBonusPointers.StatBonusPointerUberSpear
        If result = 3 Then Return StatBonusPointers.StatBonusPointerDurandal
        If result = 4 Then Return StatBonusPointers.StatBonusPointerArmads
        If result = 5 Then Return StatBonusPointers.StatBonusPointerSolKatti
        If result = 6 Then Return StatBonusPointers.StatBonusPointerAureola
        If result = 7 Then Return StatBonusPointers.StatBonusPointerDragonStone
        If result = 8 Then Return StatBonusPointers.StatBonusPointerForblaze

        Return StatBonusPointers.StatBonusPointerNone
    End Function
End Class
