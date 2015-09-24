Public Class RecordKeeper

    Public Interface RecordableItem
        Function stringDescription() As String
    End Interface

    Private Class RecordItem
        Property oldItem As String
        Property newItem As String
        Property key As String

        Property isStatic As Boolean
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
        change.oldItem = oldItem.stringDescription()
        change.newItem = newItem.stringDescription()
        change.isStatic = False

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
        change.oldItem = staticItem.stringDescription()
        change.isStatic = True

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
        change.oldItem = oldItem.stringDescription()
        change.isStatic = False
        change.key = itemKey

        pendingTable.Add(itemKey, change)
    End Sub

    Public Sub finishRecordingPendingChangeInSectionWithKey(ByVal section As String, ByRef newItem As RecordableItem, ByVal itemKey As String)
        Dim pendingTable As Hashtable

        If pendingChanges.ContainsKey(section) Then
            pendingTable = pendingChanges.Item(section)
            If pendingTable.ContainsKey(itemKey) Then
                Dim change As RecordItem = pendingTable.Item(itemKey)
                If itemKey.Equals(change.key) Then
                    change.newItem = newItem.stringDescription()
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
        My.Computer.FileSystem.WriteAllText(filePath, "Change Log Generated on " + Date.Now.ToShortDateString + " " + Date.Now.ToShortTimeString + vbCrLf, False)

        Dim outputLines As ArrayList = New ArrayList()

        For Each sectionKey In changeTable.Keys
            outputLines.Add("======== BEGIN SECTION: " + sectionKey + " ========")
            Dim sectionArray As ArrayList = changeTable.Item(sectionKey)
            For i As Integer = 0 To sectionArray.Count - 1
                Dim item As RecordItem = sectionArray.Item(i)
                If item.isStatic Then
                    outputLines.Add(item.oldItem)
                Else
                    outputLines.Add("Old: " + vbCrLf + vbCrLf + item.oldItem + vbCrLf + vbCrLf + "New: " + vbCrLf + vbCrLf + item.newItem + vbCrLf + vbCrLf + vbCrLf + vbCrLf)
                End If
            Next
            outputLines.Add("======== END SECTION: " + sectionKey + " ========" + vbCrLf)
        Next

        outputLines.Add("End Change Log")

        For Each line In outputLines
            My.Computer.FileSystem.WriteAllText(filePath, line + vbCrLf, True)
        Next

    End Sub

End Class
