Public Class Patcher

    Public Shared Function applyUPSPatch(ByVal filename As String, ByVal patchFile As String) As Boolean
        Dim path As New IO.FileInfo(Reflection.Assembly.GetExecutingAssembly.FullName)
        Dim inputFile
        Try
            inputFile = IO.File.OpenRead(IO.Path.Combine(path.DirectoryName, patchFile))
        Catch ex As Exception
            Return False
        End Try

        Dim sourceFile = IO.File.OpenRead(filename)

        Dim sourceData As Byte() = New Byte(sourceFile.Length) {}

        sourceFile.Read(sourceData, 0, sourceFile.Length)
        sourceFile.Close()

        Dim targetFile = IO.File.OpenWrite(filename)

        targetFile.Seek(0, IO.SeekOrigin.Begin)

        Dim header As UInteger = ReadWord(inputFile)
        If header = &H55505331 Then
            Dim inputLength As ULong = decodePointer(inputFile)
            Dim outputLength As ULong = decodePointer(inputFile)

            Dim relative As ULong = 0

            Dim targetOffset As ULong = 0
            Dim lastOffset As ULong = 0

            While inputFile.Position < inputFile.Length - 12
                relative = relative + decodePointer(inputFile)
                If relative > outputLength Then Continue While

                targetFile.Seek(relative, IO.SeekOrigin.Begin)

                targetOffset = relative
                For i As ULong = relative To outputLength - 1
                    Dim delta As Byte = inputFile.ReadByte()
                    relative += 1
                    If delta = 0 Then Exit For
                    If i < outputLength Then
                        ' Read byte from source file (0x00 if beyond bounds)
                        ' XOR and write into target file.
                        Dim currentByte As Byte = IIf(i < inputLength, sourceData(relative - 1), 0)
                        targetFile.WriteByte(delta Xor currentByte)
                    End If
                Next
            End While
        End If

        inputFile.Close()
        targetFile.Close()

        Return True
    End Function

    Private Shared Function decodePointer(ByRef filePtr As IO.FileStream) As ULong
        Dim offset As ULong = 0
        Dim shift As ULong = 1
        While True
            Dim input As Byte = filePtr.ReadByte()
            offset += (input And &H7F) * shift
            If input And &H80 Then Exit While
            shift <<= 7
            offset += shift
        End While

        Return offset
    End Function

    Private Shared Function ReadWord(ByRef filePtr As IO.FileStream) As UInteger
        Dim result As UInteger = 0

        result = result Or filePtr.ReadByte()
        result = (result << 8) Or filePtr.ReadByte()
        result = (result << 8) Or filePtr.ReadByte()
        Dim nextByte As UInteger = filePtr.ReadByte()
        result = (result << 8) Or nextByte

        Return result
    End Function
End Class
