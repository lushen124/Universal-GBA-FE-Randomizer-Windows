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

    Public Shared Function sanitizeByteArrayIntoTextString(ByRef byteArray As Byte(), ByVal squelchCodes As Boolean) As String
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
