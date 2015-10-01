Public Class HuffmanHelper
    Public Shared Function decodeTextAtAddressWithHuffmanTree(ByRef filePtr As IO.FileStream, ByVal textAddress As UInteger, ByVal treeAddress As UInteger, ByVal rootAddress As UInteger) As Byte()
        Dim result(&H1000) As Byte
        Dim i As Integer = 0

        Dim originalFilePosition As Integer = filePtr.Position

        ' FEditor puts a mark on uncompressed pointers. it's the most significant bit. If it's set, the text is uncompressed.
        ' This happens to work because GBA has a limit of 32 MB and it's impossible for a valid address to go that high.
        Dim marked As Boolean = textAddress And &H80000000
        filePtr.Seek(textAddress And &H7FFFFFFF, IO.SeekOrigin.Begin)

        Dim currentByte As Byte = 0

        If marked Then
            ' Uncompressed Text, just read it directly.
            Do
                currentByte = filePtr.ReadByte()
                result(i) = currentByte
                i += 1
            Loop While currentByte <> 0
        Else
            ' Compressed Text. Decode it.
            Dim bit As Integer = 0
            Dim node As Integer = rootAddress
            Dim current As Byte = filePtr.ReadByte()
            While (i < &H1000)
                ' Jump to encoding tree node
                ' First save our current position
                Dim textDataPosition As Integer = filePtr.Position

                ' Now we can traverse the tree.
                filePtr.Seek(node, IO.SeekOrigin.Begin)
                Dim left As Short = Utilities.ReadSignedHalfWord(filePtr)
                Dim right As Short = Utilities.ReadSignedHalfWord(filePtr)
                Dim nodePosition As Integer = filePtr.Position
                Dim rightReachedLeafMask As Boolean = right < 0
                If rightReachedLeafMask <> 0 Then
                    node = rootAddress
                    result(i) = Convert.ToByte(left And &HFF)
                    i += 1
                    If ((left And &HFF00) <> 0) Then
                        If i <> &H1000 Then
                            result(i) = Convert.ToByte((left And &HFF00) >> 8)
                            i += 1
                        End If
                    ElseIf left = 0 Then
                        Exit While
                    End If
                Else
                    If bit = 8 Then
                        bit = 0
                        ' Read the next byte of the data, so we need to jump back.
                        filePtr.Seek(textDataPosition, IO.SeekOrigin.Begin)
                        current = filePtr.ReadByte()
                        textDataPosition = filePtr.Position
                    End If

                    Dim offset As Short = IIf((current And &H1) = 0, left, right)
                    node = treeAddress + (4 * offset)
                    current >>= 1
                    bit += 1
                End If

                ' Always seek back to the text data position. The while loop wile take care of jumping to
                ' the tree as necessary.
                filePtr.Seek(textDataPosition, IO.SeekOrigin.Begin)

            End While
        End If

        ' Return the file pointer to the position before we started.
        filePtr.Seek(originalFilePosition, IO.SeekOrigin.Begin)

        Return result

    End Function

    Public Shared Function sanitizeByteArrayIntoTextString(ByRef byteArray As Byte(), ByVal squelchCodes As Boolean, ByVal gameType As Utilities.GameType) As String
        Dim result As String = ""

        For i As Integer = 0 To byteArray.Length
            Dim currentByte As Byte = byteArray(i)
            If currentByte = 0 Then
                If Not squelchCodes Then
                    result = result + "[X]"
                End If
                Exit For

            ElseIf currentByte = 1 Then
                If Not squelchCodes Then
                    result = result + vbCrLf
                End If

            ElseIf currentByte = 2 Then
                If Not squelchCodes Then
                    result = result + "[0x02]"
                End If

            ElseIf currentByte = 3 Then
                If Not squelchCodes Then
                    result = result + "[A]"
                End If

            ElseIf currentByte = &H10 Then
                If (i + 2 < byteArray.Length) And (byteArray(i + 2) = &HFF) Then
                    If Not squelchCodes Then
                        result = result + "[LoadFace]" + "[0x" + Hex(byteArray(i + 1)) + "][0xFF]"
                    End If
                    i += 2
                Else
                    If Not squelchCodes Then
                        result = result + "[LoadFace]" + "[0x" + Hex(byteArray(i + 1)) + "][0xFF]"
                    End If
                    i += 2
                End If
            ElseIf currentByte = Asc("[") Then
                If Not squelchCodes Then
                    result = result + "\\[\\"
                End If

            ElseIf currentByte = &H80 Then
                If Not squelchCodes Then
                    result = result + "[0x80" + Hex(byteArray(i + 1)) + "]"
                End If

                i += 1
            ElseIf (currentByte = &H82) And gameType = Utilities.GameType.GameTypeFE6 Then
                ' For whatever reason, FE6 has an additional level of encoding on top of it.
                ' All characters start with [0x82] before a code that dictates which character it is.
                ' The second code's range starts from 0x9F to 0xF1. Additionally,
                ' symbols are also decoded differently, starting with an [0x83] byte followed by
                ' what seems to be a unicode character. 
                ' TODO: Implement the symbols later.
                If i + 1 < byteArray.Length Then
                    Dim characterCode As Byte = byteArray(i + 1)
                    i += 1
                    If characterCode = &H9F Then result = result + "2"
                    If characterCode = &HA0 Then result = result + "A"
                    If characterCode = &HA1 Then result = result + "3"
                    If characterCode = &HA2 Then result = result + "B"
                    If characterCode = &HA3 Then result = result + "4"
                    If characterCode = &HA4 Then result = result + "C"
                    If characterCode = &HA5 Then result = result + "5"
                    If characterCode = &HA6 Then result = result + "D"
                    If characterCode = &HA7 Then result = result + "6"
                    If characterCode = &HA8 Then result = result + "E"
                    If characterCode = &HA9 Then result = result + "F"
                    If characterCode = &HAA Then result = result + "u"
                    If characterCode = &HAB Then result = result + "G"
                    If characterCode = &HAC Then result = result + "v"
                    If characterCode = &HAD Then result = result + "H"
                    If characterCode = &HAE Then result = result + "w"
                    If characterCode = &HAF Then result = result + "I"
                    If characterCode = &HB0 Then result = result + "x"
                    If characterCode = &HB1 Then result = result + "J"
                    If characterCode = &HB2 Then result = result + "y"
                    If characterCode = &HB3 Then result = result + "K"
                    If characterCode = &HB4 Then result = result + "z"
                    If characterCode = &HB5 Then result = result + "L"
                    ' No 0xB6?
                    If characterCode = &HB7 Then result = result + "M"
                    If characterCode = &HB8 Then result = result + " "
                    If characterCode = &HB9 Then result = result + "N"
                    If characterCode = &HBA Then result = result + "!"
                    If characterCode = &HBB Then result = result + "O"
                    If characterCode = &HBC Then result = result + """"
                    If characterCode = &HBD Then result = result + "P"
                    If characterCode = &HBE Then result = result + "#"
                    If characterCode = &HBF Then result = result + "Q"
                    If characterCode = &HC0 Then result = result + "$"
                    If characterCode = &HC1 Then result = result + "7"
                    If characterCode = &HC2 Then result = result + "R"
                    If characterCode = &HC3 Then result = result + "%"
                    If characterCode = &HC4 Then result = result + "S"
                    If characterCode = &HC5 Then result = result + "&"
                    If characterCode = &HC6 Then result = result + "T"
                    If characterCode = &HC7 Then result = result + "'"
                    If characterCode = &HC8 Then result = result + "U"
                    If characterCode = &HC9 Then result = result + "V"
                    If characterCode = &HCA Then result = result + "W"
                    If characterCode = &HCB Then result = result + "X"
                    If characterCode = &HCC Then result = result + "Y"
                    If characterCode = &HCD Then result = result + "Z"
                    If characterCode = &HCE Then result = result + "("
                    If characterCode = &HCF Then result = result + "-"
                    If characterCode = &HD0 Then result = result + "a"
                    If characterCode = &HD1 Then result = result + ")"
                    If characterCode = &HD2 Then result = result + "."
                    If characterCode = &HD3 Then result = result + "b"
                    If characterCode = &HD4 Then result = result + "*"
                    If characterCode = &HD5 Then result = result + "/"
                    If characterCode = &HD6 Then result = result + "c"
                    If characterCode = &HD7 Then result = result + "+"
                    If characterCode = &HD8 Then result = result + "0"
                    If characterCode = &HD9 Then result = result + "d"
                    If characterCode = &HDA Then result = result + ","
                    If characterCode = &HDB Then result = result + "1"
                    If characterCode = &HDC Then result = result + "e"
                    If characterCode = &HDD Then result = result + "f"
                    If characterCode = &HDE Then result = result + "g"
                    If characterCode = &HDF Then result = result + "h"
                    If characterCode = &HE0 Then result = result + "i"
                    If characterCode = &HE1 Then result = result + "8"
                    If characterCode = &HE2 Then result = result + "j"
                    If characterCode = &HE3 Then result = result + "9"
                    If characterCode = &HE4 Then result = result + "k"
                    If characterCode = &HE5 Then result = result + ":"
                    If characterCode = &HE6 Then result = result + "l"
                    If characterCode = &HE7 Then result = result + "m"
                    If characterCode = &HE8 Then result = result + "n"
                    If characterCode = &HE9 Then result = result + "o"
                    If characterCode = &HEA Then result = result + "p"
                    If characterCode = &HEB Then result = result + "q"
                    ' No 0xEC?
                    If characterCode = &HED Then result = result + "r"
                    ' No 0xEE?
                    ' No 0xEF?
                    If characterCode = &HF0 Then result = result + "s"
                    If characterCode = &HF1 Then result = result + "t"
                End If
            Else
                If currentByte < &H20 Then
                    If Not squelchCodes Then
                        result = result + "[0x" + Hex(currentByte) + "]"
                    End If

                Else
                    result = result + Chr(currentByte)
                End If
            End If
        Next

        Return result
    End Function
End Class
