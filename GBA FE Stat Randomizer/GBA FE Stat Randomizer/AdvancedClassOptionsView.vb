Public Class AdvancedClassOptionsView

    Private Property gameType As Utilities.GameType

    Private Property classLookup As Hashtable

    Public Sub New(ByVal type As Utilities.GameType)
        InitializeComponent()

        gameType = type

        Dim list As ArrayList
        Dim enumType As Type = Nothing
        If gameType = Utilities.GameType.GameTypeFE6 Then
            list = Utilities.arrayUnion(Utilities.arrayUnion(FE6GameData.promotedClassList(True), FE6GameData.promotedClassList(False)), Utilities.arrayUnion(FE6GameData.unpromotedClassList(True), FE6GameData.unpromotedClassList(False)))
            enumType = GetType(FE6GameData.ClassList)
        Else
            list = New ArrayList()
        End If

        classLookup = New Hashtable()

        If Not IsNothing(enumType) Then
            For Each item In list
                Utilities.setObjectForKey(classLookup, item, System.Enum.GetName(enumType, item))
            Next
        End If

    End Sub

    Private Sub AdvancedClassOptionsView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim displayList As ArrayList = New ArrayList()
        For Each item In classLookup.Keys
            displayList.Add(item)
        Next

        displayList.Sort()

        For i As Integer = 0 To displayList.Count - 1
            Dim displayName As String = displayList.Item(i)
            SourceListBox.Items.Add(displayName, False)
            TargetListBox.Items.Add(displayName, False)
            AvailableClassList.Items.Add(displayName)
        Next

    End Sub
End Class