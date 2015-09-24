Public Class Utilities

    Public Shared Function ReadWord(ByRef filePtr As IO.FileStream, ByVal isPointer As Boolean) As UInteger
        Dim result As UInteger = 0

        result = result Or filePtr.ReadByte()
        result = result Or (filePtr.ReadByte() << 8)
        result = result Or (filePtr.ReadByte() << 16)
        Dim nextByte As UInteger = filePtr.ReadByte()
        result = result Or (nextByte << 24)

        If isPointer And result > &H8000000 Then
            result = result - &H8000000
        End If

        Return result
    End Function

    Public Shared Function ReadHalfWord(ByRef filePtr As IO.FileStream) As UShort
        Dim result As UShort = 0

        result = result Or filePtr.ReadByte()
        result = result Or (filePtr.ReadByte() << 8)

        Return result
    End Function

    Public Shared Function ReadSignedHalfWord(ByRef filePtr As IO.FileStream) As Short
        Dim result As Short = 0

        result = result Or filePtr.ReadByte()
        result = result Or (Convert.ToInt16(filePtr.ReadByte()) << 8)

        Return result
    End Function

    Public Shared Sub WriteWord(ByRef filePtr As IO.FileStream, ByVal wordToWrite As UInteger)
        filePtr.WriteByte(wordToWrite And &HFF)
        filePtr.WriteByte((wordToWrite >> 8) And &HFF)
        filePtr.WriteByte((wordToWrite >> 16) And &HFF)
        filePtr.WriteByte((wordToWrite >> 24) And &HFF)
    End Sub

    Public Shared Sub WriteHalfWord(ByRef filePtr As IO.FileStream, ByVal halfwordToWrite As UShort)
        filePtr.WriteByte(halfwordToWrite And &HFF)
        filePtr.WriteByte((halfwordToWrite >> 8) And &HFF)
    End Sub

    Public Shared Function ReadWordIntoArrayListFromFile(ByRef filePtr As IO.FileStream) As ArrayList
        Dim array As ArrayList = New ArrayList(4)
        For i As Integer = 1 To 4
            array.Add(filePtr.ReadByte())
        Next

        Return array
    End Function

    Public Shared Function signedByteFromByte(ByVal input As Byte) As SByte
        Dim result As SByte = IIf(input < 128, input, input - 256)

        Return result

    End Function

    Public Shared Function unsignedByteFromSignedByte(ByVal input As SByte) As Byte
        If input >= 0 Then
            Return Convert.ToByte(input)
        Else
            Dim leastSigBytes As Byte = input And &H7F
            Dim result As Byte = leastSigBytes Or &H80
            Return result
        End If
    End Function

    Public Shared Function arrayIntersect(ByRef array1 As ArrayList, ByRef array2 As ArrayList) As ArrayList
        Dim newArray As ArrayList = New ArrayList()
        For Each item In array1
            If array2.Contains(item) Then
                newArray.Add(item)
            End If
        Next

        Return newArray
    End Function

    Public Shared Function arrayUnion(ByRef array1 As ArrayList, ByRef array2 As ArrayList) As ArrayList
        Dim newArray As ArrayList = New ArrayList(array1)
        For Each item In array2
            If Not newArray.Contains(item) Then
                newArray.Add(item)
            End If
        Next

        Return newArray
    End Function

    Public Shared Sub setObjectForKey(ByRef table As Hashtable, ByRef value As Object, ByRef key As Object)
        If Not IsNothing(table) And Not IsNothing(key) Then
            If IsNothing(value) Then
                table.Remove(key)
            ElseIf table.ContainsKey(key) Then
                table.Remove(key)
                table.Add(key, value)
            Else
                table.Add(key, value)
            End If
        End If
    End Sub

    Public Enum GameType
        GameTypeUnknown
        GameTypeFE6
        GameTypeFE7
        GameTypeFE8
    End Enum

    ' Note: Does not check dragonstone.
    Public Shared Function canCharacterUseWeapon(ByRef character As FECharacter, ByRef weapon As FEItem, ByRef charClass As FEClass) As Boolean

        If IsNothing(character) Or IsNothing(weapon) Or IsNothing(charClass) Then Return False

        If weapon.type = FEItem.WeaponType.WeaponTypeSword Then

            ' Sword is special because of some weapon locks.
            Dim weaponRankCheck As Boolean = weapon.rank <= character.swordLevel
            If Not weaponRankCheck Then Return False

            Dim classCanUseWoDao As Boolean = charClass.ability3 And FEClass.ClassAbility3.WoDaoWeaponLock
            Dim weaponIsLockedToSwordfighters As Boolean = weapon.weaponAbility2 And FEItem.Ability2.Ability2SwordfighterLock

            If weaponIsLockedToSwordfighters Then
                Return weaponRankCheck And classCanUseWoDao
            End If

            Dim classCanUseLordWeapons As Boolean = charClass.ability3 And FEClass.ClassAbility3.LordPrfWeaponLock
            Dim weaponIsLockedToLords As Boolean = weapon.weaponAbility2 And FEItem.Ability2.Ability2LordLock

            If weaponIsLockedToLords Then
                Return weaponRankCheck And classCanUseLordWeapons
            End If

            Dim classIsEliwoodEirikaClass As Boolean = charClass.ability4 And FEClass.ClassAbility4.EliwoodEirikaWeaponLock
            Dim weaponIsLockedToEliwoodEirika As Boolean = weapon.weaponAbility3 And FEItem.Ability3.Ability3EliwoodEirikaLock

            If weaponIsLockedToEliwoodEirika Then
                Return weaponRankCheck And classIsEliwoodEirikaClass
            End If

            Dim classIsLynClass As Boolean = charClass.ability4 And FEClass.ClassAbility4.LynWeaponLock
            Dim weaponIsLockedToLyn As Boolean = weapon.weaponAbility3 And FEItem.Ability3.Ability3LynLock

            If weaponIsLockedToLyn Then
                Return weaponRankCheck And classIsLynClass
            End If

            Dim weaponIsLockedToKing As Boolean = weapon.weaponAbility2 And FEItem.Ability2.Ability2KingLock

            If weaponIsLockedToKing Then Return False

            Return weaponRankCheck
        ElseIf weapon.type = FEItem.WeaponType.WeaponTypeSpear Then

            ' Ephraim has a lock on some weapons.
            Dim weaponRankCheck As Boolean = weapon.rank <= character.spearLevel
            If Not weaponRankCheck Then Return False

            Dim classIsEphraimClass As Boolean = charClass.ability4 And FEClass.ClassAbility4.HectorEphraimWeaponLock
            Dim weaponIsLockedToEphraim As Boolean = weapon.weaponAbility3 And FEItem.Ability3.Ability3HectorEphraimLock

            If weaponIsLockedToEphraim Then
                Return weaponRankCheck And classIsEphraimClass
            End If

            Return weaponRankCheck
        ElseIf weapon.type = FEItem.WeaponType.WeaponTypeAxe Then

            ' Hector has a lock on some weapons.
            Dim weaponRankCheck As Boolean = weapon.rank <= character.axeLevel
            If Not weaponRankCheck Then Return False

            Dim classIsHectorClass As Boolean = charClass.ability4 And FEClass.ClassAbility4.HectorEphraimWeaponLock
            Dim weaponIsLockedToHector As Boolean = weapon.weaponAbility3 And FEItem.Ability3.Ability3HectorEphraimLock

            If weaponIsLockedToHector Then
                Return weaponRankCheck And classIsHectorClass
            End If

            Return weaponRankCheck
        ElseIf weapon.type = FEItem.WeaponType.WeaponTypeBow Then
            Return weapon.rank <= character.bowLevel
        ElseIf weapon.type = FEItem.WeaponType.WeaponTypeStaff Then
            Return weapon.rank <= character.staffLevel
        ElseIf weapon.type = FEItem.WeaponType.WeaponTypeLight Then
            Return weapon.rank <= character.lightLevel
        ElseIf weapon.type = FEItem.WeaponType.WeaponTypeDark Then
            Return weapon.rank <= character.darkLevel
        ElseIf weapon.type = FEItem.WeaponType.WeaponTypeAnima Then

            ' Athos has a lock on some weapons.
            Dim weaponRankCheck = weapon.rank <= character.animaLevel
            If Not weaponRankCheck Then Return False

            Dim classIsAthosClass As Boolean = charClass.ability4 And FEClass.ClassAbility4.AthosWeaponLock
            Dim weaponIsLockedToAthos As Boolean = weapon.weaponAbility3 And FEItem.Ability3.Ability3AthosLock

            If weaponIsLockedToAthos Then
                Return weaponRankCheck And classIsAthosClass
            End If

            Return weaponRankCheck
        Else
            Return False
        End If
    End Function

End Class
