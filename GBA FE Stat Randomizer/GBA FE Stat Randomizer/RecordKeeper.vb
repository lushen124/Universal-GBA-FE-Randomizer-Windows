Public Class RecordKeeper

    Public Interface RecordableItem
        Function fieldTable() As Hashtable
        Function orderedKeys() As ArrayList

        Function primaryKey() As String
    End Interface

    Private Class RecordItem
        Property oldTable As Hashtable
        Property newTable As Hashtable

        Property keyList As ArrayList

        Property primaryKey As String

        Property key As String
    End Class

    Dim changeTable As Hashtable
    Dim pendingChanges As Hashtable

    Public Sub New()
        changeTable = New Hashtable
        pendingChanges = New Hashtable
    End Sub

    Public Sub recordChangeInSectionWithOldAndNew(ByVal section As String, ByRef oldItem As RecordableItem, ByRef newItem As RecordableItem)
        Dim sectionArray As ArrayList

        If changeTable.ContainsKey(section) Then
            sectionArray = changeTable.Item(section)
        Else
            sectionArray = New ArrayList()
            changeTable.Add(section, sectionArray)
        End If

        Dim change As RecordItem = New RecordItem()
        change.oldTable = oldItem.fieldTable.Clone()
        change.newTable = newItem.fieldTable.Clone()

        change.keyList = newItem.orderedKeys.Clone()

        change.primaryKey = oldItem.primaryKey()

        sectionArray.Add(change)

    End Sub

    Public Sub recordStaticItemInSection(ByVal section As String, ByRef staticItem As RecordableItem)
        Dim sectionArray As ArrayList

        If changeTable.ContainsKey(section) Then
            sectionArray = changeTable.Item(section)
        Else
            sectionArray = New ArrayList()
            changeTable.Add(section, sectionArray)
        End If

        Dim change As RecordItem = New RecordItem()
        change.oldTable = staticItem.fieldTable.Clone()
        change.keyList = staticItem.orderedKeys.Clone()

        change.primaryKey = staticItem.primaryKey()

        sectionArray.Add(change)
    End Sub

    Public Sub recordPendingChangeInSectionWithExisting(ByVal section As String, ByRef oldItem As RecordableItem, ByVal itemKey As String)
        Dim pendingTable As Hashtable

        If pendingChanges.ContainsKey(section) Then
            pendingTable = pendingChanges.Item(section)
        Else
            pendingTable = New Hashtable()
            pendingChanges.Add(section, pendingTable)
        End If

        Dim change As RecordItem = New RecordItem()
        change.oldTable = oldItem.fieldTable.Clone()
        change.primaryKey = oldItem.primaryKey()
        change.key = itemKey

        Utilities.setObjectForKey(pendingTable, change, itemKey)
    End Sub

    Public Sub finishRecordingPendingChangeInSectionWithKey(ByVal section As String, ByRef newItem As RecordableItem, ByVal itemKey As String)
        Dim pendingTable As Hashtable

        If pendingChanges.ContainsKey(section) Then
            pendingTable = pendingChanges.Item(section)
            If pendingTable.ContainsKey(itemKey) Then
                Dim change As RecordItem = pendingTable.Item(itemKey)
                If itemKey.Equals(change.key) Then
                    change.newTable = newItem.fieldTable.Clone()
                    change.keyList = newItem.orderedKeys.Clone()
                    pendingTable.Remove(itemKey)

                    Dim sectionArray As ArrayList

                    If changeTable.ContainsKey(section) Then
                        sectionArray = changeTable.Item(section)
                    Else
                        sectionArray = New ArrayList()
                        changeTable.Add(section, sectionArray)
                    End If

                    sectionArray.Add(change)

                End If
            Else
                ' If we don't have a previous change, drop it.
            End If
        Else
            ' Shouldn't ever happen. Drop it in this case.
        End If
    End Sub

    Public Sub writeChangesToDiskAtPath(ByVal filePath As String)
        My.Computer.FileSystem.WriteAllText(filePath, "Change Log Generated on " + Date.Now.ToShortDateString + " " + Date.Now.ToShortTimeString + vbCrLf _
                                            & "<html><head>" + vbCrLf _
                                            & "<style>" + vbCrLf _
                                            & "table, th, td { border: 1px solid black; }" + vbCrLf _
                                            & "table { width: 75%; margin: auto;" + vbCrLf _
                                            & "th, td { padding: 5px; }" + vbCrLf _
                                            & ".toc { border: 0px; }" + vbCrLf _
                                            & "</style></head><body><a name=""top"">", False)

        Dim outputLines As ArrayList = New ArrayList()

        outputLines.Add("<hr>")
        For Each sectionKey In changeTable.Keys
            outputLines.Add("<a href=""#" + sectionKey + """>Jump to section: " + sectionKey + "</a><br>")
        Next
        outputLines.Add("<hr>")

        For Each sectionKey In changeTable.Keys
            Dim headerString As String = "<hr><center><a name=""" + sectionKey + """><p>BEGIN SECTION: " + sectionKey + "</p><br><a href=""#top"">To Top</a><br>"
            Dim sectionArray As ArrayList = changeTable.Item(sectionKey)
            Dim column As Integer = 0
            headerString = headerString + vbCrLf + "<table class=""toc""><tr>"
            For i As Integer = 0 To sectionArray.Count - 1
                Dim item As RecordItem = sectionArray.Item(i)
                If Not IsNothing(item.primaryKey) Then
                    headerString = headerString + "<td class=""toc""><a href=""#" + sectionKey + "_" + item.oldTable.Item(item.primaryKey) + """>" + item.oldTable.Item(item.primaryKey) + "</a></td>"
                    column += 1
                    If column = 4 Then
                        column = 0
                        headerString = headerString + "</tr>" + vbCrLf + "<tr>"
                    End If
                End If
            Next
            headerString = headerString + "</table>"
            headerString = headerString + "</center><hr>"
            outputLines.Add(headerString)
            For i As Integer = 0 To sectionArray.Count - 1
                Dim item As RecordItem = sectionArray.Item(i)
                If Not IsNothing(item.primaryKey) Then
                    outputLines.Add("<a name=""" + sectionKey + "_" + item.oldTable.Item(item.primaryKey) + """>")
                End If
                outputLines.Add("<table>")
                If IsNothing(item.newTable) Then
                    outputLines.Add("<tr><td><b>Key</b></td><td><b>Value</b></td></tr>")
                    For j As Integer = 0 To item.keyList.Count - 1
                        Dim currentKey As String = item.keyList.Item(j)
                        'outputLines.Add(currentKey + ": " + item.oldTable.Item(currentKey))
                        outputLines.Add("<tr><td>" + currentKey + "</td><td>" + item.oldTable.Item(currentKey) + "</td></tr>")
                    Next
                    outputLines.Add("</table><br><br>")
                Else
                    outputLines.Add("<tr><td><b>Key</b></td><td><b>Old Value</b></td><td><b>New Value</b></td></tr>")
                    For j As Integer = 0 To item.keyList.Count - 1
                        Dim currentKey As String = item.keyList.Item(j)
                        'outputLines.Add(currentKey + ":" + vbTab + vbTab + item.oldTable.Item(currentKey) + vbTab + " -> " + vbTab + item.newTable.Item(currentKey))
                        outputLines.Add("<tr><td>" + currentKey + "</td><td>" + IIf(item.oldTable.ContainsKey(currentKey), item.oldTable.Item(currentKey), "--") + "</td><td>" + IIf(item.newTable.ContainsKey(currentKey), item.newTable.Item(currentKey), "--") + "</td></tr>")
                    Next
                    outputLines.Add("</table><br><center><a href=""#" + sectionKey + """>Return</a></center><br><br>")
                End If
            Next
            outputLines.Add("<hr><center><p>END SECTION: " + sectionKey + "</p><br></center><hr>" + vbCrLf)
        Next

        outputLines.Add("End Change Log")

        outputLines.Add("</body></html>")

        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(filePath, True)

        For Each line In outputLines
            file.WriteLine(line)
        Next

        file.Close()

    End Sub

End Class
