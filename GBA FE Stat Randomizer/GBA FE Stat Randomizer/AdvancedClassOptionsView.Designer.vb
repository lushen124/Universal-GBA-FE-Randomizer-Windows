<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdvancedClassOptionsView
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.AdvancedRandomAssignmentOption = New System.Windows.Forms.RadioButton()
        Me.StructuredAssignmentOption = New System.Windows.Forms.RadioButton()
        Me.SourceListBox = New System.Windows.Forms.CheckedListBox()
        Me.TargetListBox = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SourceLords = New System.Windows.Forms.Button()
        Me.TargetLords = New System.Windows.Forms.Button()
        Me.SourceThieves = New System.Windows.Forms.Button()
        Me.TargetThieves = New System.Windows.Forms.Button()
        Me.SourceHorseback = New System.Windows.Forms.Button()
        Me.TargetHorseback = New System.Windows.Forms.Button()
        Me.SourceMagical = New System.Windows.Forms.Button()
        Me.TargetMagical = New System.Windows.Forms.Button()
        Me.SourceUnique = New System.Windows.Forms.Button()
        Me.TargetUnique = New System.Windows.Forms.Button()
        Me.SourceFliers = New System.Windows.Forms.Button()
        Me.TargetFliers = New System.Windows.Forms.Button()
        Me.SourceAll = New System.Windows.Forms.Button()
        Me.TargetAll = New System.Windows.Forms.Button()
        Me.SourceWeapon = New System.Windows.Forms.Button()
        Me.TargetWeapon = New System.Windows.Forms.Button()
        Me.SourceNone = New System.Windows.Forms.Button()
        Me.TargetNone = New System.Windows.Forms.Button()
        Me.AvailableClassList = New System.Windows.Forms.ListBox()
        Me.AddClass = New System.Windows.Forms.Button()
        Me.RemoveClass = New System.Windows.Forms.Button()
        Me.SelectedClassList = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ExhaustBehavior = New System.Windows.Forms.GroupBox()
        Me.RandomOption = New System.Windows.Forms.RadioButton()
        Me.RandomCycleOption = New System.Windows.Forms.RadioButton()
        Me.RandomListOption = New System.Windows.Forms.RadioButton()
        Me.OrderedCycleOption = New System.Windows.Forms.RadioButton()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.RandomAssignmentTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.StructuredAssignmentTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SimpleRandomUniqueOption = New System.Windows.Forms.CheckBox()
        Me.SimpleRandomThievesOption = New System.Windows.Forms.CheckBox()
        Me.SimpleRandomLordsOption = New System.Windows.Forms.CheckBox()
        Me.SimpleRandomAssignmentOption = New System.Windows.Forms.RadioButton()
        Me.CrossgenderPC = New System.Windows.Forms.CheckBox()
        Me.RandomizePlayers = New System.Windows.Forms.CheckBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.RandomizeBosses = New System.Windows.Forms.CheckBox()
        Me.ExhaustBehavior.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'AdvancedRandomAssignmentOption
        '
        Me.AdvancedRandomAssignmentOption.AutoSize = True
        Me.AdvancedRandomAssignmentOption.Location = New System.Drawing.Point(37, 124)
        Me.AdvancedRandomAssignmentOption.Name = "AdvancedRandomAssignmentOption"
        Me.AdvancedRandomAssignmentOption.Size = New System.Drawing.Size(174, 17)
        Me.AdvancedRandomAssignmentOption.TabIndex = 0
        Me.AdvancedRandomAssignmentOption.TabStop = True
        Me.AdvancedRandomAssignmentOption.Text = "Advanced Random Assignment"
        Me.AdvancedRandomAssignmentOption.UseVisualStyleBackColor = True
        '
        'StructuredAssignmentOption
        '
        Me.StructuredAssignmentOption.AutoSize = True
        Me.StructuredAssignmentOption.Location = New System.Drawing.Point(37, 425)
        Me.StructuredAssignmentOption.Name = "StructuredAssignmentOption"
        Me.StructuredAssignmentOption.Size = New System.Drawing.Size(131, 17)
        Me.StructuredAssignmentOption.TabIndex = 1
        Me.StructuredAssignmentOption.TabStop = True
        Me.StructuredAssignmentOption.Text = "Structured Assignment"
        Me.StructuredAssignmentOption.UseVisualStyleBackColor = True
        '
        'SourceListBox
        '
        Me.SourceListBox.CheckOnClick = True
        Me.SourceListBox.FormattingEnabled = True
        Me.SourceListBox.Location = New System.Drawing.Point(339, 157)
        Me.SourceListBox.Name = "SourceListBox"
        Me.SourceListBox.Size = New System.Drawing.Size(144, 229)
        Me.SourceListBox.TabIndex = 2
        '
        'TargetListBox
        '
        Me.TargetListBox.CheckOnClick = True
        Me.TargetListBox.FormattingEnabled = True
        Me.TargetListBox.Location = New System.Drawing.Point(504, 157)
        Me.TargetListBox.Name = "TargetListBox"
        Me.TargetListBox.Size = New System.Drawing.Size(144, 229)
        Me.TargetListBox.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(336, 141)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Randomizing Source Classes"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(501, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Allowed Target Classes"
        '
        'SourceLords
        '
        Me.SourceLords.Location = New System.Drawing.Point(103, 154)
        Me.SourceLords.Name = "SourceLords"
        Me.SourceLords.Size = New System.Drawing.Size(108, 23)
        Me.SourceLords.TabIndex = 6
        Me.SourceLords.Text = "Lords -> ?"
        Me.SourceLords.UseVisualStyleBackColor = True
        '
        'TargetLords
        '
        Me.TargetLords.Location = New System.Drawing.Point(217, 155)
        Me.TargetLords.Name = "TargetLords"
        Me.TargetLords.Size = New System.Drawing.Size(110, 23)
        Me.TargetLords.TabIndex = 7
        Me.TargetLords.Text = "? -> Lords"
        Me.TargetLords.UseVisualStyleBackColor = True
        '
        'SourceThieves
        '
        Me.SourceThieves.Location = New System.Drawing.Point(103, 184)
        Me.SourceThieves.Name = "SourceThieves"
        Me.SourceThieves.Size = New System.Drawing.Size(108, 23)
        Me.SourceThieves.TabIndex = 8
        Me.SourceThieves.Text = "Thieves -> ?"
        Me.SourceThieves.UseVisualStyleBackColor = True
        '
        'TargetThieves
        '
        Me.TargetThieves.Location = New System.Drawing.Point(217, 184)
        Me.TargetThieves.Name = "TargetThieves"
        Me.TargetThieves.Size = New System.Drawing.Size(109, 23)
        Me.TargetThieves.TabIndex = 9
        Me.TargetThieves.Text = "? -> Thieves"
        Me.TargetThieves.UseVisualStyleBackColor = True
        '
        'SourceHorseback
        '
        Me.SourceHorseback.Location = New System.Drawing.Point(103, 214)
        Me.SourceHorseback.Name = "SourceHorseback"
        Me.SourceHorseback.Size = New System.Drawing.Size(108, 23)
        Me.SourceHorseback.TabIndex = 10
        Me.SourceHorseback.Text = "Horseback -> ?"
        Me.SourceHorseback.UseVisualStyleBackColor = True
        '
        'TargetHorseback
        '
        Me.TargetHorseback.Location = New System.Drawing.Point(217, 214)
        Me.TargetHorseback.Name = "TargetHorseback"
        Me.TargetHorseback.Size = New System.Drawing.Size(109, 23)
        Me.TargetHorseback.TabIndex = 11
        Me.TargetHorseback.Text = "? -> Horseback"
        Me.TargetHorseback.UseVisualStyleBackColor = True
        '
        'SourceMagical
        '
        Me.SourceMagical.Location = New System.Drawing.Point(103, 244)
        Me.SourceMagical.Name = "SourceMagical"
        Me.SourceMagical.Size = New System.Drawing.Size(108, 23)
        Me.SourceMagical.TabIndex = 12
        Me.SourceMagical.Text = "Magical -> ?"
        Me.SourceMagical.UseVisualStyleBackColor = True
        '
        'TargetMagical
        '
        Me.TargetMagical.Location = New System.Drawing.Point(217, 244)
        Me.TargetMagical.Name = "TargetMagical"
        Me.TargetMagical.Size = New System.Drawing.Size(109, 23)
        Me.TargetMagical.TabIndex = 13
        Me.TargetMagical.Text = "? -> Magical"
        Me.TargetMagical.UseVisualStyleBackColor = True
        '
        'SourceUnique
        '
        Me.SourceUnique.Location = New System.Drawing.Point(103, 273)
        Me.SourceUnique.Name = "SourceUnique"
        Me.SourceUnique.Size = New System.Drawing.Size(108, 23)
        Me.SourceUnique.TabIndex = 14
        Me.SourceUnique.Text = "Unique -> ?"
        Me.SourceUnique.UseVisualStyleBackColor = True
        '
        'TargetUnique
        '
        Me.TargetUnique.Location = New System.Drawing.Point(217, 274)
        Me.TargetUnique.Name = "TargetUnique"
        Me.TargetUnique.Size = New System.Drawing.Size(109, 23)
        Me.TargetUnique.TabIndex = 15
        Me.TargetUnique.Text = "? -> Unique"
        Me.TargetUnique.UseVisualStyleBackColor = True
        '
        'SourceFliers
        '
        Me.SourceFliers.Location = New System.Drawing.Point(103, 303)
        Me.SourceFliers.Name = "SourceFliers"
        Me.SourceFliers.Size = New System.Drawing.Size(108, 23)
        Me.SourceFliers.TabIndex = 16
        Me.SourceFliers.Text = "Fliers -> ?"
        Me.SourceFliers.UseVisualStyleBackColor = True
        '
        'TargetFliers
        '
        Me.TargetFliers.Location = New System.Drawing.Point(217, 303)
        Me.TargetFliers.Name = "TargetFliers"
        Me.TargetFliers.Size = New System.Drawing.Size(109, 23)
        Me.TargetFliers.TabIndex = 17
        Me.TargetFliers.Text = "? -> Fliers"
        Me.TargetFliers.UseVisualStyleBackColor = True
        '
        'SourceAll
        '
        Me.SourceAll.Location = New System.Drawing.Point(103, 335)
        Me.SourceAll.Name = "SourceAll"
        Me.SourceAll.Size = New System.Drawing.Size(108, 23)
        Me.SourceAll.TabIndex = 18
        Me.SourceAll.Text = "All -> ?"
        Me.SourceAll.UseVisualStyleBackColor = True
        '
        'TargetAll
        '
        Me.TargetAll.Location = New System.Drawing.Point(217, 333)
        Me.TargetAll.Name = "TargetAll"
        Me.TargetAll.Size = New System.Drawing.Size(109, 23)
        Me.TargetAll.TabIndex = 19
        Me.TargetAll.Text = "? -> All"
        Me.TargetAll.UseVisualStyleBackColor = True
        '
        'SourceWeapon
        '
        Me.SourceWeapon.Location = New System.Drawing.Point(103, 364)
        Me.SourceWeapon.Name = "SourceWeapon"
        Me.SourceWeapon.Size = New System.Drawing.Size(108, 23)
        Me.SourceWeapon.TabIndex = 20
        Me.SourceWeapon.Text = "Weapon -> ?..."
        Me.SourceWeapon.UseVisualStyleBackColor = True
        '
        'TargetWeapon
        '
        Me.TargetWeapon.Location = New System.Drawing.Point(217, 363)
        Me.TargetWeapon.Name = "TargetWeapon"
        Me.TargetWeapon.Size = New System.Drawing.Size(109, 23)
        Me.TargetWeapon.TabIndex = 21
        Me.TargetWeapon.Text = "? -> Weapon..."
        Me.TargetWeapon.UseVisualStyleBackColor = True
        '
        'SourceNone
        '
        Me.SourceNone.Location = New System.Drawing.Point(339, 392)
        Me.SourceNone.Name = "SourceNone"
        Me.SourceNone.Size = New System.Drawing.Size(144, 23)
        Me.SourceNone.TabIndex = 22
        Me.SourceNone.Text = "Deselect All Source"
        Me.SourceNone.UseVisualStyleBackColor = True
        '
        'TargetNone
        '
        Me.TargetNone.Location = New System.Drawing.Point(504, 392)
        Me.TargetNone.Name = "TargetNone"
        Me.TargetNone.Size = New System.Drawing.Size(144, 23)
        Me.TargetNone.TabIndex = 23
        Me.TargetNone.Text = "Deslect All Target"
        Me.TargetNone.UseVisualStyleBackColor = True
        '
        'AvailableClassList
        '
        Me.AvailableClassList.FormattingEnabled = True
        Me.AvailableClassList.Location = New System.Drawing.Point(260, 470)
        Me.AvailableClassList.Name = "AvailableClassList"
        Me.AvailableClassList.Size = New System.Drawing.Size(144, 225)
        Me.AvailableClassList.TabIndex = 24
        '
        'AddClass
        '
        Me.AddClass.Location = New System.Drawing.Point(410, 551)
        Me.AddClass.Name = "AddClass"
        Me.AddClass.Size = New System.Drawing.Size(88, 23)
        Me.AddClass.TabIndex = 25
        Me.AddClass.Text = "Add >>"
        Me.AddClass.UseVisualStyleBackColor = True
        '
        'RemoveClass
        '
        Me.RemoveClass.Location = New System.Drawing.Point(410, 581)
        Me.RemoveClass.Name = "RemoveClass"
        Me.RemoveClass.Size = New System.Drawing.Size(88, 23)
        Me.RemoveClass.TabIndex = 26
        Me.RemoveClass.Text = "<< Remove"
        Me.RemoveClass.UseVisualStyleBackColor = True
        '
        'SelectedClassList
        '
        Me.SelectedClassList.FormattingEnabled = True
        Me.SelectedClassList.Location = New System.Drawing.Point(504, 470)
        Me.SelectedClassList.Name = "SelectedClassList"
        Me.SelectedClassList.Size = New System.Drawing.Size(144, 225)
        Me.SelectedClassList.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(257, 451)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Available Classes"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(501, 451)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Selected Classes"
        '
        'ExhaustBehavior
        '
        Me.ExhaustBehavior.Controls.Add(Me.RandomOption)
        Me.ExhaustBehavior.Controls.Add(Me.RandomCycleOption)
        Me.ExhaustBehavior.Controls.Add(Me.RandomListOption)
        Me.ExhaustBehavior.Controls.Add(Me.OrderedCycleOption)
        Me.ExhaustBehavior.Location = New System.Drawing.Point(93, 584)
        Me.ExhaustBehavior.Name = "ExhaustBehavior"
        Me.ExhaustBehavior.Size = New System.Drawing.Size(140, 111)
        Me.ExhaustBehavior.TabIndex = 30
        Me.ExhaustBehavior.TabStop = False
        Me.ExhaustBehavior.Text = "When list is exhausted..."
        '
        'RandomOption
        '
        Me.RandomOption.AutoSize = True
        Me.RandomOption.Location = New System.Drawing.Point(7, 88)
        Me.RandomOption.Name = "RandomOption"
        Me.RandomOption.Size = New System.Drawing.Size(79, 17)
        Me.RandomOption.TabIndex = 3
        Me.RandomOption.TabStop = True
        Me.RandomOption.Text = "Random All"
        Me.RandomOption.UseVisualStyleBackColor = True
        '
        'RandomCycleOption
        '
        Me.RandomCycleOption.AutoSize = True
        Me.RandomCycleOption.Location = New System.Drawing.Point(7, 43)
        Me.RandomCycleOption.Name = "RandomCycleOption"
        Me.RandomCycleOption.Size = New System.Drawing.Size(119, 17)
        Me.RandomCycleOption.TabIndex = 2
        Me.RandomCycleOption.TabStop = True
        Me.RandomCycleOption.Text = "Cycle List (Random)"
        Me.RandomCycleOption.UseVisualStyleBackColor = True
        '
        'RandomListOption
        '
        Me.RandomListOption.AutoSize = True
        Me.RandomListOption.Location = New System.Drawing.Point(7, 65)
        Me.RandomListOption.Name = "RandomListOption"
        Me.RandomListOption.Size = New System.Drawing.Size(84, 17)
        Me.RandomListOption.TabIndex = 1
        Me.RandomListOption.TabStop = True
        Me.RandomListOption.Text = "Random List"
        Me.RandomListOption.UseVisualStyleBackColor = True
        '
        'OrderedCycleOption
        '
        Me.OrderedCycleOption.AutoSize = True
        Me.OrderedCycleOption.Location = New System.Drawing.Point(7, 20)
        Me.OrderedCycleOption.Name = "OrderedCycleOption"
        Me.OrderedCycleOption.Size = New System.Drawing.Size(117, 17)
        Me.OrderedCycleOption.TabIndex = 0
        Me.OrderedCycleOption.TabStop = True
        Me.OrderedCycleOption.Text = "Cycle List (Ordered)"
        Me.OrderedCycleOption.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(20, 745)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(658, 23)
        Me.OKButton.TabIndex = 31
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'RandomAssignmentTooltip
        '
        Me.RandomAssignmentTooltip.AutoPopDelay = 30000
        Me.RandomAssignmentTooltip.InitialDelay = 500
        Me.RandomAssignmentTooltip.ReshowDelay = 100
        '
        'StructuredAssignmentTooltip
        '
        Me.StructuredAssignmentTooltip.AutoPopDelay = 30000
        Me.StructuredAssignmentTooltip.InitialDelay = 500
        Me.StructuredAssignmentTooltip.ReshowDelay = 100
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(20, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(662, 727)
        Me.TabControl1.TabIndex = 32
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SimpleRandomUniqueOption)
        Me.TabPage1.Controls.Add(Me.SimpleRandomThievesOption)
        Me.TabPage1.Controls.Add(Me.SimpleRandomLordsOption)
        Me.TabPage1.Controls.Add(Me.SimpleRandomAssignmentOption)
        Me.TabPage1.Controls.Add(Me.CrossgenderPC)
        Me.TabPage1.Controls.Add(Me.RandomizePlayers)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.AdvancedRandomAssignmentOption)
        Me.TabPage1.Controls.Add(Me.ExhaustBehavior)
        Me.TabPage1.Controls.Add(Me.StructuredAssignmentOption)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.SourceListBox)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.TargetListBox)
        Me.TabPage1.Controls.Add(Me.SelectedClassList)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.RemoveClass)
        Me.TabPage1.Controls.Add(Me.SourceLords)
        Me.TabPage1.Controls.Add(Me.AddClass)
        Me.TabPage1.Controls.Add(Me.TargetLords)
        Me.TabPage1.Controls.Add(Me.AvailableClassList)
        Me.TabPage1.Controls.Add(Me.SourceThieves)
        Me.TabPage1.Controls.Add(Me.TargetNone)
        Me.TabPage1.Controls.Add(Me.TargetThieves)
        Me.TabPage1.Controls.Add(Me.SourceNone)
        Me.TabPage1.Controls.Add(Me.SourceHorseback)
        Me.TabPage1.Controls.Add(Me.TargetWeapon)
        Me.TabPage1.Controls.Add(Me.TargetHorseback)
        Me.TabPage1.Controls.Add(Me.SourceWeapon)
        Me.TabPage1.Controls.Add(Me.SourceMagical)
        Me.TabPage1.Controls.Add(Me.TargetAll)
        Me.TabPage1.Controls.Add(Me.TargetMagical)
        Me.TabPage1.Controls.Add(Me.SourceAll)
        Me.TabPage1.Controls.Add(Me.SourceUnique)
        Me.TabPage1.Controls.Add(Me.TargetFliers)
        Me.TabPage1.Controls.Add(Me.TargetUnique)
        Me.TabPage1.Controls.Add(Me.SourceFliers)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(654, 701)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Playable Characters"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SimpleRandomUniqueOption
        '
        Me.SimpleRandomUniqueOption.AutoSize = True
        Me.SimpleRandomUniqueOption.Location = New System.Drawing.Point(462, 87)
        Me.SimpleRandomUniqueOption.Name = "SimpleRandomUniqueOption"
        Me.SimpleRandomUniqueOption.Size = New System.Drawing.Size(127, 17)
        Me.SimpleRandomUniqueOption.TabIndex = 36
        Me.SimpleRandomUniqueOption.Text = "Allow Unique Classes"
        Me.SimpleRandomUniqueOption.UseVisualStyleBackColor = True
        '
        'SimpleRandomThievesOption
        '
        Me.SimpleRandomThievesOption.AutoSize = True
        Me.SimpleRandomThievesOption.Location = New System.Drawing.Point(275, 87)
        Me.SimpleRandomThievesOption.Name = "SimpleRandomThievesOption"
        Me.SimpleRandomThievesOption.Size = New System.Drawing.Size(102, 17)
        Me.SimpleRandomThievesOption.TabIndex = 35
        Me.SimpleRandomThievesOption.Text = "Include Thieves"
        Me.SimpleRandomThievesOption.UseVisualStyleBackColor = True
        '
        'SimpleRandomLordsOption
        '
        Me.SimpleRandomLordsOption.AutoSize = True
        Me.SimpleRandomLordsOption.Location = New System.Drawing.Point(103, 87)
        Me.SimpleRandomLordsOption.Name = "SimpleRandomLordsOption"
        Me.SimpleRandomLordsOption.Size = New System.Drawing.Size(90, 17)
        Me.SimpleRandomLordsOption.TabIndex = 34
        Me.SimpleRandomLordsOption.Text = "Include Lords"
        Me.SimpleRandomLordsOption.UseVisualStyleBackColor = True
        '
        'SimpleRandomAssignmentOption
        '
        Me.SimpleRandomAssignmentOption.AutoSize = True
        Me.SimpleRandomAssignmentOption.Location = New System.Drawing.Point(37, 53)
        Me.SimpleRandomAssignmentOption.Name = "SimpleRandomAssignmentOption"
        Me.SimpleRandomAssignmentOption.Size = New System.Drawing.Size(156, 17)
        Me.SimpleRandomAssignmentOption.TabIndex = 33
        Me.SimpleRandomAssignmentOption.TabStop = True
        Me.SimpleRandomAssignmentOption.Text = "Simple Random Assignment"
        Me.SimpleRandomAssignmentOption.UseVisualStyleBackColor = True
        '
        'CrossgenderPC
        '
        Me.CrossgenderPC.AutoSize = True
        Me.CrossgenderPC.Location = New System.Drawing.Point(37, 29)
        Me.CrossgenderPC.Name = "CrossgenderPC"
        Me.CrossgenderPC.Size = New System.Drawing.Size(113, 17)
        Me.CrossgenderPC.TabIndex = 32
        Me.CrossgenderPC.Text = "Allow Crossgender"
        Me.CrossgenderPC.UseVisualStyleBackColor = True
        '
        'RandomizePlayers
        '
        Me.RandomizePlayers.AutoSize = True
        Me.RandomizePlayers.Location = New System.Drawing.Point(6, 6)
        Me.RandomizePlayers.Name = "RandomizePlayers"
        Me.RandomizePlayers.Size = New System.Drawing.Size(176, 17)
        Me.RandomizePlayers.TabIndex = 31
        Me.RandomizePlayers.Text = "Randomize Playable Characters"
        Me.RandomizePlayers.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ListBox2)
        Me.TabPage2.Controls.Add(Me.ListBox1)
        Me.TabPage2.Controls.Add(Me.RandomizeBosses)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(654, 701)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Bosses"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(404, 29)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(195, 563)
        Me.ListBox2.TabIndex = 2
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(65, 29)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(195, 563)
        Me.ListBox1.TabIndex = 1
        '
        'RandomizeBosses
        '
        Me.RandomizeBosses.AutoSize = True
        Me.RandomizeBosses.Location = New System.Drawing.Point(6, 6)
        Me.RandomizeBosses.Name = "RandomizeBosses"
        Me.RandomizeBosses.Size = New System.Drawing.Size(116, 17)
        Me.RandomizeBosses.TabIndex = 0
        Me.RandomizeBosses.Text = "Randomize Bosses"
        Me.RandomizeBosses.UseVisualStyleBackColor = True
        '
        'AdvancedClassOptionsView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 780)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.OKButton)
        Me.Name = "AdvancedClassOptionsView"
        Me.Text = "Custom Class Randomization Options"
        Me.ExhaustBehavior.ResumeLayout(False)
        Me.ExhaustBehavior.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AdvancedRandomAssignmentOption As System.Windows.Forms.RadioButton
    Friend WithEvents StructuredAssignmentOption As System.Windows.Forms.RadioButton
    Friend WithEvents SourceListBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents TargetListBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SourceLords As System.Windows.Forms.Button
    Friend WithEvents TargetLords As System.Windows.Forms.Button
    Friend WithEvents SourceThieves As System.Windows.Forms.Button
    Friend WithEvents TargetThieves As System.Windows.Forms.Button
    Friend WithEvents SourceHorseback As System.Windows.Forms.Button
    Friend WithEvents TargetHorseback As System.Windows.Forms.Button
    Friend WithEvents SourceMagical As System.Windows.Forms.Button
    Friend WithEvents TargetMagical As System.Windows.Forms.Button
    Friend WithEvents SourceUnique As System.Windows.Forms.Button
    Friend WithEvents TargetUnique As System.Windows.Forms.Button
    Friend WithEvents SourceFliers As System.Windows.Forms.Button
    Friend WithEvents TargetFliers As System.Windows.Forms.Button
    Friend WithEvents SourceAll As System.Windows.Forms.Button
    Friend WithEvents TargetAll As System.Windows.Forms.Button
    Friend WithEvents SourceWeapon As System.Windows.Forms.Button
    Friend WithEvents TargetWeapon As System.Windows.Forms.Button
    Friend WithEvents SourceNone As System.Windows.Forms.Button
    Friend WithEvents TargetNone As System.Windows.Forms.Button
    Friend WithEvents AvailableClassList As System.Windows.Forms.ListBox
    Friend WithEvents AddClass As System.Windows.Forms.Button
    Friend WithEvents RemoveClass As System.Windows.Forms.Button
    Friend WithEvents SelectedClassList As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ExhaustBehavior As System.Windows.Forms.GroupBox
    Friend WithEvents RandomOption As System.Windows.Forms.RadioButton
    Friend WithEvents RandomCycleOption As System.Windows.Forms.RadioButton
    Friend WithEvents RandomListOption As System.Windows.Forms.RadioButton
    Friend WithEvents OrderedCycleOption As System.Windows.Forms.RadioButton
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents RandomAssignmentTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents StructuredAssignmentTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents CrossgenderPC As System.Windows.Forms.CheckBox
    Friend WithEvents RandomizePlayers As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents RandomizeBosses As System.Windows.Forms.CheckBox
    Friend WithEvents SimpleRandomUniqueOption As System.Windows.Forms.CheckBox
    Friend WithEvents SimpleRandomThievesOption As System.Windows.Forms.CheckBox
    Friend WithEvents SimpleRandomLordsOption As System.Windows.Forms.CheckBox
    Friend WithEvents SimpleRandomAssignmentOption As System.Windows.Forms.RadioButton
End Class
