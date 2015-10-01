Public Class TextManager

    Dim addresses As ArrayList
    Dim strings As Hashtable

    Property huffmanTreeStart As Integer
    Property huffmanTreeRoot As Integer

    Public Sub New(ByVal gameType As Utilities.GameType, ByRef filePtr As IO.FileStream)
        addresses = New ArrayList()
        strings = New Hashtable()

        Dim originalPosition = filePtr.Position

        ' Check to see if everything is default.
        Dim pointerAddress As Integer = 0
        Dim defaultArrayOffset As Integer = 0
        Dim defaultArrayCount As Integer = 0

        Dim huffmanStartPointer As Integer = 0
        Dim huffmanEndPointer As Integer = 0

        If gameType = Utilities.GameType.GameTypeFE6 Then
            pointerAddress = FE6GameData.TextArrayPointerAddress
            defaultArrayOffset = FE6GameData.TextArrayDefaultOffset
            defaultArrayCount = FE6GameData.TextArrayDefaultCount

            huffmanStartPointer = FE6GameData.HuffmanTreeStart
            huffmanEndPointer = FE6GameData.HuffmanTreeEnd

        ElseIf gameType = Utilities.GameType.GameTypeFE7 Then
            pointerAddress = FE7GameData.TextArrayPointerAddress
            defaultArrayOffset = FE7GameData.TextArrayDefaultOffset
            defaultArrayCount = FE7GameData.TextArrayDefaultCount

            huffmanStartPointer = FE7GameData.HuffmanTreeStart
            huffmanEndPointer = FE7GameData.HuffmanTreeEnd

        ElseIf gameType = Utilities.GameType.GameTypeFE8 Then
            pointerAddress = FE8GameData.TextArrayPointerAddress
            defaultArrayOffset = FE8GameData.TextArrayDefaultOffset
            defaultArrayCount = FE8GameData.TextArrayDefaultCount

            huffmanStartPointer = FE8GameData.HuffmanTreeStart
            huffmanEndPointer = FE8GameData.HuffmanTreeEnd
        End If

        ' Resolve the huffman offsets. Start is one jump, End (Root) is two jumps
        filePtr.Seek(huffmanStartPointer, IO.SeekOrigin.Begin)
        huffmanTreeStart = Utilities.ReadWord(filePtr, True)

        filePtr.Seek(huffmanEndPointer, IO.SeekOrigin.Begin)
        huffmanEndPointer = Utilities.ReadWord(filePtr, True)
        filePtr.Seek(huffmanEndPointer, IO.SeekOrigin.Begin)
        huffmanTreeRoot = Utilities.ReadWord(filePtr, True)

        filePtr.Seek(pointerAddress, IO.SeekOrigin.Begin)
        Dim textArrayOffset As Integer = Utilities.ReadWord(filePtr, True)
        Dim textArrayCount As Integer = defaultArrayCount

        If textArrayOffset = defaultArrayOffset Then
            ' It's the default. Assume default count.
        Else
            ' Based on the version of FEditor used, it may have two different ways
            ' of storing the count. The new version has it stored right before
            ' the array itself.

            ' TODO: Handle this properly. We're readonly right now, so we don't really care, but
            ' if this becomes mutable, this will need to be addressed.
            ' filePtr.Seek(textArrayOffset - 4, IO.SeekOrigin.Begin)
            ' textArrayCount = Utilities.ReadWord(filePtr, False)
            textArrayCount = &HFFFF ' The maximum allowed count. Reads beyond real data will just read gibberish.
        End If

        filePtr.Seek(textArrayOffset, IO.SeekOrigin.Begin)

        For i As Integer = 1 To textArrayCount
            Dim address As UInteger = Utilities.ReadWord(filePtr, True)
            Dim mask As Integer = address And &H7E000000
            If (mask <> 0) Then
                ' No valid address should set any of those bits, so if we find one, we can fast exit (really only relevant for unknown array counts).
                ' Note: FEditor marks addresses with 0x80000000 so the last bit is valid.
                Exit For
            End If
            addresses.Add(address)
        Next

        For Each address As UInteger In addresses
            Dim resolvedString As String = HuffmanHelper.sanitizeByteArrayIntoTextString(HuffmanHelper.decodeTextAtAddressWithHuffmanTree(filePtr, address, huffmanTreeStart, huffmanTreeRoot), True, gameType)
            strings.Add(address, resolvedString)
        Next

        filePtr.Seek(originalPosition, IO.SeekOrigin.Begin)
    End Sub

    Public Function stringForTextAtIndex(ByVal textIndex As UShort) As String
        Dim address As UInteger = addressForTextAtIndex(textIndex)
        If strings.ContainsKey(address) Then
            Return strings.Item(address)
        End If

        Return ""
    End Function

    Public Function addressForTextAtIndex(ByVal textIndex As UShort) As UInteger
        If (textIndex) < addresses.Count And textIndex >= 1 Then
            Return addresses.Item(textIndex)
        End If

        Return 0
    End Function
End Class
