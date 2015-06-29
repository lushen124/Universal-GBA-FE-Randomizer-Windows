Public Class PromotionManager

    Dim FE6HeroCrestAddressPointer As Integer = &H237B0
    Dim FE6HeroCrestDefaultAddress As Integer = &H6615E2

    Dim FE6KnightCrestAddressPointer As Integer = &H237B8
    Dim FE6KnightCrestDefaultAddress As Integer = &H6615EA

    Dim FE6OrionBoltAddressPointer As Integer = &H237C0
    Dim FE6OrionBoltDefaultAddress As Integer = &H6615EF

    Dim FE6ElysianWhipAddressPointer As Integer = &H237C8
    Dim FE6ElysianWhipDefaultAddress As Integer = &H6615F4

    Dim FE6GuidingRingAddressPointer As Integer = &H237F0
    Dim FE6GuidingRingDefaultAddress As Integer = &H6615F8

    Dim FE6PromotionItemFreeSpaceStartAddress As Integer = &H818300
    Dim FE6PromotionItemFreeSpaceEndAddress As Integer = &H8184E0


    Dim FE7HeroCrestAddressPointer As Integer = &H27500
    Dim FE7HeroCrestDefaultAddress As Integer = &HC97EDD

    Dim FE7KnightCrestAddressPointer As Integer = &H27508
    Dim FE7KnightCrestDefaultAddress As Integer = &HC97EE3

    Dim FE7OrionBoltAddressPointer As Integer = &H27510
    Dim FE7OrionBoltDefaultAddress As Integer = &HC97EE8

    Dim FE7ElysianWhipAddressPointer As Integer = &H27518
    Dim FE7ElysianWhipDefaultAddress As Integer = &HC97EED

    Dim FE7GuidingRingAddressPointer As Integer = &H27520
    Dim FE7GuidingRingDefaultAddress As Integer = &HC97EF1

    Dim FE7MasterSealAddressPointer As Integer = &H27528
    Dim FE7MasterSealDefaultAddress As Integer = &HC97EFD

    Dim FE7FallenContractAddressPointer As Integer = &H2754C
    Dim FE7FallenContractDefaultAddress As Integer = &HC97F29

    Dim FE7OceanSealAddressPointer As Integer = &H27574
    Dim FE7OceanSealDefaultAddress As Integer = &HC97F24

    Dim FE7PromotionItemFreeSpaceStartingAddress As Integer = &HFFFA00
    Dim FE7PromotionItemFreeSpaceEndingAddress As Integer = &HFFFBE0


    Dim FE8HeroCrestAddressPointer As Integer = &H29398
    Dim FE8HeroCrestDefaultAddress As Integer = &H8ADF57

    Dim FE8KnightCrestAddressPointer As Integer = &H293A0
    Dim FE8KnightCrestDefaultAddress As Integer = &H8ADF5E

    Dim FE8OrionBoltAddressPointer As Integer = &H293A8
    Dim FE8OrionBoltDefaultAddress As Integer = &H8ADF64

    Dim FE8ElysianWhipAddressPointer As Integer = &H293B0
    Dim FE8ElysianWhipDefaultAddress As Integer = &H8ADF67

    Dim FE8GuidingRingAddressPointer As Integer = &H293B8
    Dim FE8GuidingRingDefaultAddress As Integer = &H8ADF6B

    Dim FE8MasterSealAddressPointer As Integer = &H293C0
    Dim FE8MasterSealDefaultAddress As Integer = &H8ADF76

    Dim FE8LunarBraceAddressPointer As Integer = &H293C8
    Dim FE8LunarBraceDefaultAddress As Integer = &H8ADFA4

    Dim FE8SolarBraceAddressPointer As Integer = &H293D0
    Dim FE8SolarBraceDefaultAddress As Integer = &H8ADFA6

    Dim FE8OceanSealAddressPointer As Integer = &H29408
    Dim FE8OceanSealDefaultAddress As Integer = &H8ADF9E

    Dim FE8PromotionItemFreeSpaceStartingAddress As Integer = &HE70200
    Dim FE8PromotionItemFreeSpaceEndingAddress As Integer = &HE703E0

    Dim FE8PromotionBranchesAddressPointer As Integer = &HCC7D0
    Dim FE8PromotionBranchesDefaultAddress As Integer = &H95DFA4
    Dim FE8PromotionBranchEntrySize As Integer = 2
    Dim FE8PromotionBranchEntryCount As Integer = 128

    Enum PromotionItems
        HeroCrest
        KnightCrest
        OrionBolt
        ElysianWhip
        GuidingRing
        MasterSeal
        OceanSeal
        FallenContract
    End Enum

    Property gameType As Utilities.GameType

    Private Property heroCrestClasses As ArrayList
    Private Property knightCrestClasses As ArrayList
    Private Property orionBoltClasses As ArrayList
    Private Property elysianWhipClasses As ArrayList
    Private Property guidingRingClasses As ArrayList

    Private Property masterSealClasses As ArrayList ' FE7 and FE8
    Private Property oceanSealClasses As ArrayList

    Private Property fallenContractClasses As ArrayList ' FE7 only

    Private Property heroDirty As Boolean = False
    Private Property knightDirty As Boolean = False
    Private Property orionDirty As Boolean = False
    Private Property elysianDirty As Boolean = False
    Private Property guidingDirty As Boolean = False

    Private Property masterDirty As Boolean = False
    Private Property oceanDirty As Boolean = False

    Private Property fallenDirty As Boolean = False

    ' FE8 only
    Private Property branches As ArrayList
    Private Property branchTableOffset As Integer

    Private Class FE8PromotionBranchEntry
        Property classChoice1 As Byte       ' offset 0, 1 byte
        Property classChoice2 As Byte       ' offset 1, 1 byte
    End Class

    Public Sub New(ByVal type As Utilities.GameType, ByRef filePtr As IO.FileStream)
        gameType = type

        Dim heroCrestAddress As Integer = 0
        Dim knightCrestAddress As Integer = 0
        Dim orionBoltAddress As Integer = 0
        Dim elysianWhipAddress As Integer = 0
        Dim guidingRingAddress As Integer = 0

        If type = Utilities.GameType.GameTypeFE6 Then
            filePtr.Seek(FE6HeroCrestAddressPointer, IO.SeekOrigin.Begin)
            heroCrestAddress = Utilities.ReadWord(filePtr, True)
            filePtr.Seek(FE6KnightCrestAddressPointer, IO.SeekOrigin.Begin)
            knightCrestAddress = Utilities.ReadWord(filePtr, True)
            filePtr.Seek(FE6OrionBoltAddressPointer, IO.SeekOrigin.Begin)
            orionBoltAddress = Utilities.ReadWord(filePtr, True)
            filePtr.Seek(FE6ElysianWhipAddressPointer, IO.SeekOrigin.Begin)
            elysianWhipAddress = Utilities.ReadWord(filePtr, True)
            filePtr.Seek(FE6GuidingRingAddressPointer, IO.SeekOrigin.Begin)
            guidingRingAddress = Utilities.ReadWord(filePtr, True)
        End If

        Dim masterSealAddress As Integer = 0
        Dim oceanSealAddress As Integer = 0

        Dim fallenContractAddress As Integer = 0

        If type = Utilities.GameType.GameTypeFE7 Then
            filePtr.Seek(FE7HeroCrestAddressPointer, IO.SeekOrigin.Begin)
            heroCrestAddress = Utilities.ReadWord(filePtr, True)
            filePtr.Seek(FE7KnightCrestAddressPointer, IO.SeekOrigin.Begin)
            knightCrestAddress = Utilities.ReadWord(filePtr, True)
            filePtr.Seek(FE7OrionBoltAddressPointer, IO.SeekOrigin.Begin)
            orionBoltAddress = Utilities.ReadWord(filePtr, True)
            filePtr.Seek(FE7ElysianWhipAddressPointer, IO.SeekOrigin.Begin)
            elysianWhipAddress = Utilities.ReadWord(filePtr, True)
            filePtr.Seek(FE7GuidingRingAddressPointer, IO.SeekOrigin.Begin)
            guidingRingAddress = Utilities.ReadWord(filePtr, True)

            filePtr.Seek(FE7MasterSealAddressPointer, IO.SeekOrigin.Begin)
            masterSealAddress = Utilities.ReadWord(filePtr, True)
            filePtr.Seek(FE7OceanSealAddressPointer, IO.SeekOrigin.Begin)
            oceanSealAddress = Utilities.ReadWord(filePtr, True)

            filePtr.Seek(FE7FallenContractAddressPointer, IO.SeekOrigin.Begin)
            fallenContractAddress = Utilities.ReadWord(filePtr, True)
        End If

        If type = Utilities.GameType.GameTypeFE8 Then
            filePtr.Seek(FE8HeroCrestAddressPointer, IO.SeekOrigin.Begin)
            heroCrestAddress = Utilities.ReadWord(filePtr, True)
            filePtr.Seek(FE8KnightCrestAddressPointer, IO.SeekOrigin.Begin)
            knightCrestAddress = Utilities.ReadWord(filePtr, True)
            filePtr.Seek(FE8OrionBoltAddressPointer, IO.SeekOrigin.Begin)
            orionBoltAddress = Utilities.ReadWord(filePtr, True)
            filePtr.Seek(FE8ElysianWhipAddressPointer, IO.SeekOrigin.Begin)
            elysianWhipAddress = Utilities.ReadWord(filePtr, True)
            filePtr.Seek(FE8GuidingRingAddressPointer, IO.SeekOrigin.Begin)
            guidingRingAddress = Utilities.ReadWord(filePtr, True)

            filePtr.Seek(FE8MasterSealAddressPointer, IO.SeekOrigin.Begin)
            masterSealAddress = Utilities.ReadWord(filePtr, True)
            filePtr.Seek(FE8OceanSealAddressPointer, IO.SeekOrigin.Begin)
            oceanSealAddress = Utilities.ReadWord(filePtr, True)
        End If

        If heroCrestAddress <> 0 Then
            filePtr.Seek(heroCrestAddress, IO.SeekOrigin.Begin)
            heroCrestClasses = New ArrayList()
            Dim readByte As Byte = filePtr.ReadByte()
            While readByte <> 0
                heroCrestClasses.Add(readByte)
                readByte = filePtr.ReadByte()
            End While
        End If
        If knightCrestAddress <> 0 Then
            filePtr.Seek(knightCrestAddress, IO.SeekOrigin.Begin)
            knightCrestClasses = New ArrayList()
            Dim readByte As Byte = filePtr.ReadByte()
            While readByte <> 0
                knightCrestClasses.Add(readByte)
                readByte = filePtr.ReadByte()
            End While
        End If
        If orionBoltAddress <> 0 Then
            filePtr.Seek(orionBoltAddress, IO.SeekOrigin.Begin)
            orionBoltClasses = New ArrayList()
            Dim readByte As Byte = filePtr.ReadByte()
            While readByte <> 0
                orionBoltClasses.Add(readByte)
                readByte = filePtr.ReadByte()
            End While
        End If
        If elysianWhipAddress <> 0 Then
            filePtr.Seek(elysianWhipAddress, IO.SeekOrigin.Begin)
            elysianWhipClasses = New ArrayList()
            Dim readByte As Byte = filePtr.ReadByte()
            While readByte <> 0
                elysianWhipClasses.Add(readByte)
                readByte = filePtr.ReadByte()
            End While
        End If
        If guidingRingAddress <> 0 Then
            filePtr.Seek(guidingRingAddress, IO.SeekOrigin.Begin)
            guidingRingClasses = New ArrayList()
            Dim readByte As Byte = filePtr.ReadByte()
            While readByte <> 0
                guidingRingClasses.Add(readByte)
                readByte = filePtr.ReadByte()
            End While
        End If
        If masterSealAddress <> 0 Then
            filePtr.Seek(masterSealAddress, IO.SeekOrigin.Begin)
            masterSealClasses = New ArrayList()
            Dim readByte As Byte = filePtr.ReadByte()
            While readByte <> 0
                masterSealClasses.Add(readByte)
                readByte = filePtr.ReadByte()
            End While
        End If
        If oceanSealAddress <> 0 Then
            filePtr.Seek(oceanSealAddress, IO.SeekOrigin.Begin)
            oceanSealClasses = New ArrayList()
            Dim readByte As Byte = filePtr.ReadByte()
            While readByte <> 0
                oceanSealClasses.Add(readByte)
                readByte = filePtr.ReadByte()
            End While
        End If
        If fallenContractAddress <> 0 Then
            filePtr.Seek(fallenContractAddress, IO.SeekOrigin.Begin)
            fallenContractClasses = New ArrayList()
            Dim readByte As Byte = filePtr.ReadByte()
            While readByte <> 0
                fallenContractClasses.Add(readByte)
                readByte = filePtr.ReadByte()
            End While
        End If

        If gameType = Utilities.GameType.GameTypeFE8 Then
            filePtr.Seek(FE8PromotionBranchesAddressPointer, IO.SeekOrigin.Begin)
            Dim realAddress As Integer = Utilities.ReadWord(filePtr, True)
            If realAddress <> FE8PromotionBranchesDefaultAddress Then
                MsgBox("Promotion Branches Table Offset has been updated. Promotions may have been modified." + vbCrLf _
                       & "If this is a hacked game, promotions may not be modified properly.", MsgBoxStyle.OkOnly, "Notice")
            End If
            filePtr.Seek(realAddress, IO.SeekOrigin.Begin)
            branches = New ArrayList()
            For i As Integer = 1 To FE8PromotionBranchEntryCount
                Dim newBranch As FE8PromotionBranchEntry = New FE8PromotionBranchEntry()
                newBranch.classChoice1 = filePtr.ReadByte()
                newBranch.classChoice2 = filePtr.ReadByte()
                branches.Add(newBranch)
            Next

            branchTableOffset = realAddress

        End If

    End Sub

    Public Sub addClassToPromotionItem(ByVal classId As Byte, ByVal promotionItem As PromotionItems)
        If classId = 0 Then Return

        If promotionItem = PromotionItems.HeroCrest And Not IsNothing(heroCrestClasses) Then
            If Not heroCrestClasses.Contains(classId) Then
                heroCrestClasses.Add(classId)
                heroDirty = True
            End If
        End If
        If promotionItem = PromotionItems.KnightCrest And Not IsNothing(knightCrestClasses) Then
            If Not knightCrestClasses.Contains(classId) Then
                knightCrestClasses.Add(classId)
                knightDirty = True
            End If
        End If
        If promotionItem = PromotionItems.OrionBolt And Not IsNothing(orionBoltClasses) Then
            If Not orionBoltClasses.Contains(classId) Then
                orionBoltClasses.Add(classId)
                orionDirty = True
            End If
        End If
        If promotionItem = PromotionItems.ElysianWhip And Not IsNothing(elysianWhipClasses) Then
            If Not elysianWhipClasses.Contains(classId) Then
                elysianWhipClasses.Add(classId)
                elysianDirty = True
            End If
        End If
        If promotionItem = PromotionItems.GuidingRing And Not IsNothing(guidingRingClasses) Then
            If Not guidingRingClasses.Contains(classId) Then
                guidingRingClasses.Add(classId)
                guidingDirty = True
            End If
        End If
        If promotionItem = PromotionItems.MasterSeal And Not IsNothing(masterSealClasses) Then
            If Not masterSealClasses.Contains(classId) Then
                masterSealClasses.Add(classId)
                masterDirty = True
            End If
        End If
        If promotionItem = PromotionItems.OceanSeal And Not IsNothing(oceanSealClasses) Then
            If Not oceanSealClasses.Contains(classId) Then
                oceanSealClasses.Add(classId)
                oceanDirty = True
            End If
        End If
        If promotionItem = PromotionItems.FallenContract And Not IsNothing(fallenContractClasses) Then
            If Not fallenContractClasses.Contains(classId) Then
                fallenContractClasses.Add(classId)
                fallenDirty = True
            End If
        End If
    End Sub

    Public Sub setPromotionBranchesForClass(ByVal unpromotedClassId As Byte, ByVal choice1Id As Byte, ByVal choice2Id As Byte)
        If gameType = Utilities.GameType.GameTypeFE8 Then
            Dim index As Integer = unpromotedClassId
            If index = 0 Then Return ' Don't touch class 0
            If index < branches.Count Then
                Dim entry As FE8PromotionBranchEntry = branches.Item(index)
                entry.classChoice1 = choice1Id
                entry.classChoice2 = choice2Id
            End If
        End If
    End Sub

    Public Sub commitChanges(ByRef filePtr As IO.FileStream)
        If gameType = Utilities.GameType.GameTypeFE6 Then
            Dim freeSpaceAddress As Integer = FE6PromotionItemFreeSpaceStartAddress
            If heroDirty Then
                Dim newAddress As Integer = freeSpaceAddress
                filePtr.Seek(FE6HeroCrestAddressPointer, IO.SeekOrigin.Begin)
                Utilities.WriteWord(filePtr, newAddress + &H8000000)
                filePtr.Seek(newAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To heroCrestClasses.Count - 1
                    Dim classId As Byte = heroCrestClasses.Item(i)
                    filePtr.WriteByte(classId)
                    freeSpaceAddress += 1
                Next
                ' Write the terminal 0x00 byte.
                filePtr.WriteByte(0)
                freeSpaceAddress += 1
            End If
            If knightDirty Then
                Dim newAddress As Integer = freeSpaceAddress
                filePtr.Seek(FE6KnightCrestAddressPointer, IO.SeekOrigin.Begin)
                Utilities.WriteWord(filePtr, newAddress + &H8000000)
                filePtr.Seek(newAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To knightCrestClasses.Count - 1
                    Dim classId As Byte = knightCrestClasses.Item(i)
                    filePtr.WriteByte(classId)
                    freeSpaceAddress += 1
                Next
                ' Write the terminal 0x00 byte.
                filePtr.WriteByte(0)
                freeSpaceAddress += 1
            End If
            If orionDirty Then
                Dim newAddress As Integer = freeSpaceAddress
                filePtr.Seek(FE6OrionBoltAddressPointer, IO.SeekOrigin.Begin)
                Utilities.WriteWord(filePtr, newAddress + &H8000000)
                filePtr.Seek(newAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To orionBoltClasses.Count - 1
                    Dim classId As Byte = orionBoltClasses.Item(i)
                    filePtr.WriteByte(classId)
                    freeSpaceAddress += 1
                Next
                ' Write the terminal 0x00 byte.
                filePtr.WriteByte(0)
                freeSpaceAddress += 1
            End If
            If elysianDirty Then
                Dim newAddress As Integer = freeSpaceAddress
                filePtr.Seek(FE6ElysianWhipAddressPointer, IO.SeekOrigin.Begin)
                Utilities.WriteWord(filePtr, newAddress + &H8000000)
                filePtr.Seek(newAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To elysianWhipClasses.Count - 1
                    Dim classId As Byte = elysianWhipClasses.Item(i)
                    filePtr.WriteByte(classId)
                    freeSpaceAddress += 1
                Next
                ' Write the terminal 0x00 byte.
                filePtr.WriteByte(0)
                freeSpaceAddress += 1
            End If
            If guidingDirty Then
                Dim newAddress As Integer = freeSpaceAddress
                filePtr.Seek(FE6GuidingRingAddressPointer, IO.SeekOrigin.Begin)
                Utilities.WriteWord(filePtr, newAddress + &H8000000)
                filePtr.Seek(newAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To guidingRingClasses.Count - 1
                    Dim classId As Byte = guidingRingClasses.Item(i)
                    filePtr.WriteByte(classId)
                    freeSpaceAddress += 1
                Next
                ' Write the terminal 0x00 byte.
                filePtr.WriteByte(0)
                freeSpaceAddress += 1
            End If
        ElseIf gameType = Utilities.GameType.GameTypeFE7 Then
            Dim freeSpaceAddress As Integer = FE7PromotionItemFreeSpaceStartingAddress
            If heroDirty Then
                Dim newAddress As Integer = freeSpaceAddress
                filePtr.Seek(FE7HeroCrestAddressPointer, IO.SeekOrigin.Begin)
                Utilities.WriteWord(filePtr, newAddress + &H8000000)
                filePtr.Seek(newAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To heroCrestClasses.Count - 1
                    Dim classId As Byte = heroCrestClasses.Item(i)
                    filePtr.WriteByte(classId)
                    freeSpaceAddress += 1
                Next
                ' Write the terminal 0x00 byte.
                filePtr.WriteByte(0)
                freeSpaceAddress += 1
            End If
            If knightDirty Then
                Dim newAddress As Integer = freeSpaceAddress
                filePtr.Seek(FE7KnightCrestAddressPointer, IO.SeekOrigin.Begin)
                Utilities.WriteWord(filePtr, newAddress + &H8000000)
                filePtr.Seek(newAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To knightCrestClasses.Count - 1
                    Dim classId As Byte = knightCrestClasses.Item(i)
                    filePtr.WriteByte(classId)
                    freeSpaceAddress += 1
                Next
                ' Write the terminal 0x00 byte.
                filePtr.WriteByte(0)
                freeSpaceAddress += 1
            End If
            If orionDirty Then
                Dim newAddress As Integer = freeSpaceAddress
                filePtr.Seek(FE7OrionBoltAddressPointer, IO.SeekOrigin.Begin)
                Utilities.WriteWord(filePtr, newAddress + &H8000000)
                filePtr.Seek(newAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To orionBoltClasses.Count - 1
                    Dim classId As Byte = orionBoltClasses.Item(i)
                    filePtr.WriteByte(classId)
                    freeSpaceAddress += 1
                Next
                ' Write the terminal 0x00 byte.
                filePtr.WriteByte(0)
                freeSpaceAddress += 1
            End If
            If elysianDirty Then
                Dim newAddress As Integer = freeSpaceAddress
                filePtr.Seek(FE7ElysianWhipAddressPointer, IO.SeekOrigin.Begin)
                Utilities.WriteWord(filePtr, newAddress + &H8000000)
                filePtr.Seek(newAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To elysianWhipClasses.Count - 1
                    Dim classId As Byte = elysianWhipClasses.Item(i)
                    filePtr.WriteByte(classId)
                    freeSpaceAddress += 1
                Next
                ' Write the terminal 0x00 byte.
                filePtr.WriteByte(0)
                freeSpaceAddress += 1
            End If
            If guidingDirty Then
                Dim newAddress As Integer = freeSpaceAddress
                filePtr.Seek(FE7GuidingRingAddressPointer, IO.SeekOrigin.Begin)
                Utilities.WriteWord(filePtr, newAddress + &H8000000)
                filePtr.Seek(newAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To guidingRingClasses.Count - 1
                    Dim classId As Byte = guidingRingClasses.Item(i)
                    filePtr.WriteByte(classId)
                    freeSpaceAddress += 1
                Next
                ' Write the terminal 0x00 byte.
                filePtr.WriteByte(0)
                freeSpaceAddress += 1
            End If
            If masterDirty Then
                Dim newAddress As Integer = freeSpaceAddress
                filePtr.Seek(FE7MasterSealAddressPointer, IO.SeekOrigin.Begin)
                Utilities.WriteWord(filePtr, newAddress + &H8000000)
                filePtr.Seek(newAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To masterSealClasses.Count - 1
                    Dim classId As Byte = masterSealClasses.Item(i)
                    filePtr.WriteByte(classId)
                    freeSpaceAddress += 1
                Next
                ' Write the terminal 0x00 byte.
                filePtr.WriteByte(0)
                freeSpaceAddress += 1
            End If
            If oceanDirty Then
                Dim newAddress As Integer = freeSpaceAddress
                filePtr.Seek(FE7OceanSealAddressPointer, IO.SeekOrigin.Begin)
                Utilities.WriteWord(filePtr, newAddress + &H8000000)
                filePtr.Seek(newAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To oceanSealClasses.Count - 1
                    Dim classId As Byte = oceanSealClasses.Item(i)
                    filePtr.WriteByte(classId)
                    freeSpaceAddress += 1
                Next
                ' Write the terminal 0x00 byte.
                filePtr.WriteByte(0)
                freeSpaceAddress += 1
            End If
            If fallenDirty Then
                Dim newAddress As Integer = freeSpaceAddress
                filePtr.Seek(FE7FallenContractAddressPointer, IO.SeekOrigin.Begin)
                Utilities.WriteWord(filePtr, newAddress + &H8000000)
                filePtr.Seek(newAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To fallenContractClasses.Count - 1
                    Dim classId As Byte = fallenContractClasses.Item(i)
                    filePtr.WriteByte(classId)
                    freeSpaceAddress += 1
                Next
                ' Write the terminal 0x00 byte.
                filePtr.WriteByte(0)
                freeSpaceAddress += 1
            End If
        ElseIf gameType = Utilities.GameType.GameTypeFE8 Then
            Dim freeSpaceAddress As Integer = FE8PromotionItemFreeSpaceStartingAddress
            If heroDirty Then
                Dim newAddress As Integer = freeSpaceAddress
                filePtr.Seek(FE8HeroCrestAddressPointer, IO.SeekOrigin.Begin)
                Utilities.WriteWord(filePtr, newAddress + &H8000000)
                filePtr.Seek(newAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To heroCrestClasses.Count - 1
                    Dim classId As Byte = heroCrestClasses.Item(i)
                    filePtr.WriteByte(classId)
                    freeSpaceAddress += 1
                Next
                ' Write the terminal 0x00 byte.
                filePtr.WriteByte(0)
                freeSpaceAddress += 1
            End If
            If knightDirty Then
                Dim newAddress As Integer = freeSpaceAddress
                filePtr.Seek(FE8KnightCrestAddressPointer, IO.SeekOrigin.Begin)
                Utilities.WriteWord(filePtr, newAddress + &H8000000)
                filePtr.Seek(newAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To knightCrestClasses.Count - 1
                    Dim classId As Byte = knightCrestClasses.Item(i)
                    filePtr.WriteByte(classId)
                    freeSpaceAddress += 1
                Next
                ' Write the terminal 0x00 byte.
                filePtr.WriteByte(0)
                freeSpaceAddress += 1
            End If
            If orionDirty Then
                Dim newAddress As Integer = freeSpaceAddress
                filePtr.Seek(FE8OrionBoltAddressPointer, IO.SeekOrigin.Begin)
                Utilities.WriteWord(filePtr, newAddress + &H8000000)
                filePtr.Seek(newAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To orionBoltClasses.Count - 1
                    Dim classId As Byte = orionBoltClasses.Item(i)
                    filePtr.WriteByte(classId)
                    freeSpaceAddress += 1
                Next
                ' Write the terminal 0x00 byte.
                filePtr.WriteByte(0)
                freeSpaceAddress += 1
            End If
            If elysianDirty Then
                Dim newAddress As Integer = freeSpaceAddress
                filePtr.Seek(FE8ElysianWhipAddressPointer, IO.SeekOrigin.Begin)
                Utilities.WriteWord(filePtr, newAddress + &H8000000)
                filePtr.Seek(newAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To elysianWhipClasses.Count - 1
                    Dim classId As Byte = elysianWhipClasses.Item(i)
                    filePtr.WriteByte(classId)
                    freeSpaceAddress += 1
                Next
                ' Write the terminal 0x00 byte.
                filePtr.WriteByte(0)
                freeSpaceAddress += 1
            End If
            If guidingDirty Then
                Dim newAddress As Integer = freeSpaceAddress
                filePtr.Seek(FE8GuidingRingAddressPointer, IO.SeekOrigin.Begin)
                Utilities.WriteWord(filePtr, newAddress + &H8000000)
                filePtr.Seek(newAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To guidingRingClasses.Count - 1
                    Dim classId As Byte = guidingRingClasses.Item(i)
                    filePtr.WriteByte(classId)
                    freeSpaceAddress += 1
                Next
                ' Write the terminal 0x00 byte.
                filePtr.WriteByte(0)
                freeSpaceAddress += 1
            End If
            If masterDirty Then
                Dim newAddress As Integer = freeSpaceAddress
                filePtr.Seek(FE8MasterSealAddressPointer, IO.SeekOrigin.Begin)
                Utilities.WriteWord(filePtr, newAddress + &H8000000)
                filePtr.Seek(newAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To masterSealClasses.Count - 1
                    Dim classId As Byte = masterSealClasses.Item(i)
                    filePtr.WriteByte(classId)
                    freeSpaceAddress += 1
                Next
                ' Write the terminal 0x00 byte.
                filePtr.WriteByte(0)
                freeSpaceAddress += 1
            End If
            If oceanDirty Then
                Dim newAddress As Integer = freeSpaceAddress
                filePtr.Seek(FE8OceanSealAddressPointer, IO.SeekOrigin.Begin)
                Utilities.WriteWord(filePtr, newAddress + &H8000000)
                filePtr.Seek(newAddress, IO.SeekOrigin.Begin)
                For i As Integer = 0 To oceanSealClasses.Count - 1
                    Dim classId As Byte = oceanSealClasses.Item(i)
                    filePtr.WriteByte(classId)
                    freeSpaceAddress += 1
                Next
                ' Write the terminal 0x00 byte.
                filePtr.WriteByte(0)
                freeSpaceAddress += 1
            End If

            If branchTableOffset <> 0 Then
                filePtr.Seek(branchTableOffset, IO.SeekOrigin.Begin)
                For i As Integer = 0 To FE8PromotionBranchEntryCount - 1
                    Dim entry As FE8PromotionBranchEntry = branches.Item(i)
                    filePtr.WriteByte(entry.classChoice1)
                    filePtr.WriteByte(entry.classChoice2)
                Next
            End If
        End If

        heroDirty = False
        knightDirty = False
        orionDirty = False
        elysianDirty = False
        guidingDirty = False

        masterDirty = False
        oceanDirty = False

        fallenDirty = False
    End Sub
End Class
