<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.FilenameTextBox = New System.Windows.Forms.TextBox()
        Me.BrowseButton = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GameDetectionLabel = New System.Windows.Forms.Label()
        Me.RandomizeGrowthsToggle = New System.Windows.Forms.CheckBox()
        Me.RandomizeBasesToggle = New System.Windows.Forms.CheckBox()
        Me.RandomizeCONToggle = New System.Windows.Forms.CheckBox()
        Me.RandomizeButton = New System.Windows.Forms.Button()
        Me.RandomizeAffinityToggle = New System.Windows.Forms.CheckBox()
        Me.GrowthVarianceControl = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BaseVarianceControl = New System.Windows.Forms.NumericUpDown()
        Me.MinimumGrowthToggle = New System.Windows.Forms.CheckBox()
        Me.RandomizeClassesToggle = New System.Windows.Forms.CheckBox()
        Me.IncludeLordsToggle = New System.Windows.Forms.CheckBox()
        Me.IncludeThievesToggle = New System.Windows.Forms.CheckBox()
        Me.IncludeBossesToggle = New System.Windows.Forms.CheckBox()
        Me.RandomizeItemsToggle = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MightVarianceControl = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.HitVarianceControl = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CriticalVarianceControl = New System.Windows.Forms.NumericUpDown()
        Me.WeightVarianceControl = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.MinimumMightControl = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.MinimumHitControl = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.MinimumCriticalControl = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.MinimumWeightControl = New System.Windows.Forms.NumericUpDown()
        Me.MaximumWeightControl = New System.Windows.Forms.NumericUpDown()
        Me.WeightedHPGrowthsToggle = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.MinimumCONControl = New System.Windows.Forms.NumericUpDown()
        Me.RandomizeMOVToggle = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.MinimumMOVControl = New System.Windows.Forms.NumericUpDown()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.MaximumMOVControl = New System.Windows.Forms.NumericUpDown()
        Me.RecruitmentBox = New System.Windows.Forms.GroupBox()
        Me.RandomRecruitmentOption = New System.Windows.Forms.RadioButton()
        Me.ReverseRecruitmentOption = New System.Windows.Forms.RadioButton()
        Me.NormalRecruitmentOption = New System.Windows.Forms.RadioButton()
        Me.AllowUniqueClassesToggle = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DurabilityVarianceControl = New System.Windows.Forms.NumericUpDown()
        Me.AllowRandomTraitsToggle = New System.Windows.Forms.CheckBox()
        Me.IncreaseEnemyGrowthsToggle = New System.Windows.Forms.CheckBox()
        Me.BuffBossesToggle = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.EnemyBuffControl = New System.Windows.Forms.NumericUpDown()
        Me.SetMaximumEnemyBuffControl = New System.Windows.Forms.RadioButton()
        Me.SetConstantEnemyBuffControl = New System.Windows.Forms.RadioButton()
        Me.SetMinimumEnemyBuffControl = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MinimumDurabilityControl = New System.Windows.Forms.NumericUpDown()
        Me.GrowthsTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GrowthsVarianceTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MinimumGrowthTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.WeightedHPTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.BasesTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.BaseVarianceTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.CONTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MinimumCONTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MOVTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MinimumMOVTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MaximumMOVTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.RandomAffinityTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.AffinityBonusAmountTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.RandomItemsTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MightVarianceTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MinimumMightTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MinimumHitTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.HitVarianceTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.CriticalVarianceTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MinimumCriticalTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.WeightVarianceTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MinimumWeightTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MaximumWeightTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.DurabilityVarianceTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MinimumDurabilityTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.AllowRandomTraitsTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.RandomClassesTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.RandomizeLordsTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.RandomizeThievesTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.RandomizeBossesTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.UniqueClassesTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.EnemyBuffTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.BuffAmountTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.BossBuffTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.RecruitmentTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label18 = New System.Windows.Forms.Label()
        Me.CONVarianceControl = New System.Windows.Forms.NumericUpDown()
        Me.CONVarianceTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GameSpecificCheckbox = New System.Windows.Forms.CheckBox()
        CType(Me.GrowthVarianceControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BaseVarianceControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MightVarianceControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HitVarianceControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CriticalVarianceControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WeightVarianceControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinimumMightControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinimumHitControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinimumCriticalControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinimumWeightControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaximumWeightControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinimumCONControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinimumMOVControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaximumMOVControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RecruitmentBox.SuspendLayout()
        CType(Me.DurabilityVarianceControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EnemyBuffControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinimumDurabilityControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CONVarianceControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FilenameTextBox
        '
        Me.FilenameTextBox.Enabled = False
        Me.FilenameTextBox.Location = New System.Drawing.Point(13, 13)
        Me.FilenameTextBox.Name = "FilenameTextBox"
        Me.FilenameTextBox.ReadOnly = True
        Me.FilenameTextBox.Size = New System.Drawing.Size(480, 20)
        Me.FilenameTextBox.TabIndex = 0
        Me.FilenameTextBox.Text = "Load your GBA Fire Emblem ROM..."
        '
        'BrowseButton
        '
        Me.BrowseButton.Location = New System.Drawing.Point(499, 12)
        Me.BrowseButton.Name = "BrowseButton"
        Me.BrowseButton.Size = New System.Drawing.Size(75, 23)
        Me.BrowseButton.TabIndex = 1
        Me.BrowseButton.Text = "Browse..."
        Me.BrowseButton.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "GBA Files|*.gba"
        '
        'GameDetectionLabel
        '
        Me.GameDetectionLabel.AutoSize = True
        Me.GameDetectionLabel.Location = New System.Drawing.Point(13, 48)
        Me.GameDetectionLabel.Name = "GameDetectionLabel"
        Me.GameDetectionLabel.Size = New System.Drawing.Size(86, 13)
        Me.GameDetectionLabel.TabIndex = 2
        Me.GameDetectionLabel.Text = "Select a Game..."
        '
        'RandomizeGrowthsToggle
        '
        Me.RandomizeGrowthsToggle.AutoSize = True
        Me.RandomizeGrowthsToggle.Location = New System.Drawing.Point(16, 73)
        Me.RandomizeGrowthsToggle.Name = "RandomizeGrowthsToggle"
        Me.RandomizeGrowthsToggle.Size = New System.Drawing.Size(121, 17)
        Me.RandomizeGrowthsToggle.TabIndex = 3
        Me.RandomizeGrowthsToggle.Text = "Randomize Growths"
        Me.RandomizeGrowthsToggle.UseVisualStyleBackColor = True
        '
        'RandomizeBasesToggle
        '
        Me.RandomizeBasesToggle.AutoSize = True
        Me.RandomizeBasesToggle.Location = New System.Drawing.Point(16, 179)
        Me.RandomizeBasesToggle.Name = "RandomizeBasesToggle"
        Me.RandomizeBasesToggle.Size = New System.Drawing.Size(111, 17)
        Me.RandomizeBasesToggle.TabIndex = 4
        Me.RandomizeBasesToggle.Text = "Randomize Bases"
        Me.RandomizeBasesToggle.UseVisualStyleBackColor = True
        '
        'RandomizeCONToggle
        '
        Me.RandomizeCONToggle.AutoSize = True
        Me.RandomizeCONToggle.Enabled = False
        Me.RandomizeCONToggle.Location = New System.Drawing.Point(16, 232)
        Me.RandomizeCONToggle.Name = "RandomizeCONToggle"
        Me.RandomizeCONToggle.Size = New System.Drawing.Size(105, 17)
        Me.RandomizeCONToggle.TabIndex = 6
        Me.RandomizeCONToggle.Text = "Randomize CON"
        Me.RandomizeCONToggle.UseVisualStyleBackColor = True
        '
        'RandomizeButton
        '
        Me.RandomizeButton.Enabled = False
        Me.RandomizeButton.Location = New System.Drawing.Point(16, 445)
        Me.RandomizeButton.Name = "RandomizeButton"
        Me.RandomizeButton.Size = New System.Drawing.Size(558, 23)
        Me.RandomizeButton.TabIndex = 7
        Me.RandomizeButton.Text = "Randomize!"
        Me.RandomizeButton.UseVisualStyleBackColor = True
        '
        'RandomizeAffinityToggle
        '
        Me.RandomizeAffinityToggle.AutoSize = True
        Me.RandomizeAffinityToggle.Location = New System.Drawing.Point(14, 389)
        Me.RandomizeAffinityToggle.Name = "RandomizeAffinityToggle"
        Me.RandomizeAffinityToggle.Size = New System.Drawing.Size(113, 17)
        Me.RandomizeAffinityToggle.TabIndex = 8
        Me.RandomizeAffinityToggle.Text = "Randomize Affinity"
        Me.RandomizeAffinityToggle.UseVisualStyleBackColor = True
        '
        'GrowthVarianceControl
        '
        Me.GrowthVarianceControl.Enabled = False
        Me.GrowthVarianceControl.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.GrowthVarianceControl.Location = New System.Drawing.Point(133, 93)
        Me.GrowthVarianceControl.Name = "GrowthVarianceControl"
        Me.GrowthVarianceControl.Size = New System.Drawing.Size(51, 20)
        Me.GrowthVarianceControl.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Growth Variance"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(41, 199)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Base Variance"
        '
        'BaseVarianceControl
        '
        Me.BaseVarianceControl.Enabled = False
        Me.BaseVarianceControl.Location = New System.Drawing.Point(123, 197)
        Me.BaseVarianceControl.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.BaseVarianceControl.Name = "BaseVarianceControl"
        Me.BaseVarianceControl.Size = New System.Drawing.Size(50, 20)
        Me.BaseVarianceControl.TabIndex = 12
        '
        'MinimumGrowthToggle
        '
        Me.MinimumGrowthToggle.AutoSize = True
        Me.MinimumGrowthToggle.Location = New System.Drawing.Point(44, 121)
        Me.MinimumGrowthToggle.Name = "MinimumGrowthToggle"
        Me.MinimumGrowthToggle.Size = New System.Drawing.Size(157, 17)
        Me.MinimumGrowthToggle.TabIndex = 13
        Me.MinimumGrowthToggle.Text = "Force Minimum Growth (5%)"
        Me.MinimumGrowthToggle.UseVisualStyleBackColor = True
        '
        'RandomizeClassesToggle
        '
        Me.RandomizeClassesToggle.AutoSize = True
        Me.RandomizeClassesToggle.Location = New System.Drawing.Point(435, 73)
        Me.RandomizeClassesToggle.Name = "RandomizeClassesToggle"
        Me.RandomizeClassesToggle.Size = New System.Drawing.Size(118, 17)
        Me.RandomizeClassesToggle.TabIndex = 14
        Me.RandomizeClassesToggle.Text = "Randomize Classes"
        Me.RandomizeClassesToggle.UseVisualStyleBackColor = True
        '
        'IncludeLordsToggle
        '
        Me.IncludeLordsToggle.AutoSize = True
        Me.IncludeLordsToggle.Location = New System.Drawing.Point(456, 97)
        Me.IncludeLordsToggle.Name = "IncludeLordsToggle"
        Me.IncludeLordsToggle.Size = New System.Drawing.Size(90, 17)
        Me.IncludeLordsToggle.TabIndex = 15
        Me.IncludeLordsToggle.Text = "Include Lords"
        Me.IncludeLordsToggle.UseVisualStyleBackColor = True
        '
        'IncludeThievesToggle
        '
        Me.IncludeThievesToggle.AutoSize = True
        Me.IncludeThievesToggle.Location = New System.Drawing.Point(456, 120)
        Me.IncludeThievesToggle.Name = "IncludeThievesToggle"
        Me.IncludeThievesToggle.Size = New System.Drawing.Size(102, 17)
        Me.IncludeThievesToggle.TabIndex = 16
        Me.IncludeThievesToggle.Text = "Include Thieves"
        Me.IncludeThievesToggle.UseVisualStyleBackColor = True
        '
        'IncludeBossesToggle
        '
        Me.IncludeBossesToggle.AutoSize = True
        Me.IncludeBossesToggle.Location = New System.Drawing.Point(456, 143)
        Me.IncludeBossesToggle.Name = "IncludeBossesToggle"
        Me.IncludeBossesToggle.Size = New System.Drawing.Size(98, 17)
        Me.IncludeBossesToggle.TabIndex = 17
        Me.IncludeBossesToggle.Text = "Include Bosses"
        Me.IncludeBossesToggle.UseVisualStyleBackColor = True
        '
        'RandomizeItemsToggle
        '
        Me.RandomizeItemsToggle.AutoSize = True
        Me.RandomizeItemsToggle.Location = New System.Drawing.Point(228, 73)
        Me.RandomizeItemsToggle.Name = "RandomizeItemsToggle"
        Me.RandomizeItemsToggle.Size = New System.Drawing.Size(107, 17)
        Me.RandomizeItemsToggle.TabIndex = 18
        Me.RandomizeItemsToggle.Text = "Randomize Items"
        Me.RandomizeItemsToggle.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(249, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Might Variance"
        '
        'MightVarianceControl
        '
        Me.MightVarianceControl.Location = New System.Drawing.Point(352, 95)
        Me.MightVarianceControl.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.MightVarianceControl.Name = "MightVarianceControl"
        Me.MightVarianceControl.Size = New System.Drawing.Size(52, 20)
        Me.MightVarianceControl.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(249, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Hit Variance"
        '
        'HitVarianceControl
        '
        Me.HitVarianceControl.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.HitVarianceControl.Location = New System.Drawing.Point(352, 154)
        Me.HitVarianceControl.Name = "HitVarianceControl"
        Me.HitVarianceControl.Size = New System.Drawing.Size(52, 20)
        Me.HitVarianceControl.TabIndex = 22
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(249, 211)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Critical Variance"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(249, 272)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Weight Variance"
        '
        'CriticalVarianceControl
        '
        Me.CriticalVarianceControl.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.CriticalVarianceControl.Location = New System.Drawing.Point(352, 209)
        Me.CriticalVarianceControl.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.CriticalVarianceControl.Name = "CriticalVarianceControl"
        Me.CriticalVarianceControl.Size = New System.Drawing.Size(52, 20)
        Me.CriticalVarianceControl.TabIndex = 25
        '
        'WeightVarianceControl
        '
        Me.WeightVarianceControl.Location = New System.Drawing.Point(352, 270)
        Me.WeightVarianceControl.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.WeightVarianceControl.Name = "WeightVarianceControl"
        Me.WeightVarianceControl.Size = New System.Drawing.Size(52, 20)
        Me.WeightVarianceControl.TabIndex = 26
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(249, 120)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Minimum Might"
        '
        'MinimumMightControl
        '
        Me.MinimumMightControl.Location = New System.Drawing.Point(352, 118)
        Me.MinimumMightControl.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.MinimumMightControl.Name = "MinimumMightControl"
        Me.MinimumMightControl.Size = New System.Drawing.Size(52, 20)
        Me.MinimumMightControl.TabIndex = 28
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(249, 179)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Minimum Hit"
        '
        'MinimumHitControl
        '
        Me.MinimumHitControl.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.MinimumHitControl.Location = New System.Drawing.Point(352, 177)
        Me.MinimumHitControl.Name = "MinimumHitControl"
        Me.MinimumHitControl.Size = New System.Drawing.Size(52, 20)
        Me.MinimumHitControl.TabIndex = 30
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(249, 236)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Minimum Critical"
        '
        'MinimumCriticalControl
        '
        Me.MinimumCriticalControl.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.MinimumCriticalControl.Location = New System.Drawing.Point(352, 234)
        Me.MinimumCriticalControl.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.MinimumCriticalControl.Name = "MinimumCriticalControl"
        Me.MinimumCriticalControl.Size = New System.Drawing.Size(52, 20)
        Me.MinimumCriticalControl.TabIndex = 32
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(249, 296)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 13)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Minimum Weight"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(249, 321)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 13)
        Me.Label12.TabIndex = 34
        Me.Label12.Text = "Maximum Weight"
        '
        'MinimumWeightControl
        '
        Me.MinimumWeightControl.Location = New System.Drawing.Point(352, 294)
        Me.MinimumWeightControl.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.MinimumWeightControl.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.MinimumWeightControl.Name = "MinimumWeightControl"
        Me.MinimumWeightControl.Size = New System.Drawing.Size(52, 20)
        Me.MinimumWeightControl.TabIndex = 35
        Me.MinimumWeightControl.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'MaximumWeightControl
        '
        Me.MaximumWeightControl.Location = New System.Drawing.Point(352, 318)
        Me.MaximumWeightControl.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.MaximumWeightControl.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.MaximumWeightControl.Name = "MaximumWeightControl"
        Me.MaximumWeightControl.Size = New System.Drawing.Size(52, 20)
        Me.MaximumWeightControl.TabIndex = 36
        Me.MaximumWeightControl.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'WeightedHPGrowthsToggle
        '
        Me.WeightedHPGrowthsToggle.AutoSize = True
        Me.WeightedHPGrowthsToggle.Location = New System.Drawing.Point(44, 145)
        Me.WeightedHPGrowthsToggle.Name = "WeightedHPGrowthsToggle"
        Me.WeightedHPGrowthsToggle.Size = New System.Drawing.Size(154, 17)
        Me.WeightedHPGrowthsToggle.TabIndex = 37
        Me.WeightedHPGrowthsToggle.Text = "Use Weighted HP Growths"
        Me.WeightedHPGrowthsToggle.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(41, 277)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 13)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Minimum CON"
        '
        'MinimumCONControl
        '
        Me.MinimumCONControl.Location = New System.Drawing.Point(116, 275)
        Me.MinimumCONControl.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.MinimumCONControl.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.MinimumCONControl.Name = "MinimumCONControl"
        Me.MinimumCONControl.Size = New System.Drawing.Size(57, 20)
        Me.MinimumCONControl.TabIndex = 39
        Me.MinimumCONControl.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'RandomizeMOVToggle
        '
        Me.RandomizeMOVToggle.AutoSize = True
        Me.RandomizeMOVToggle.Location = New System.Drawing.Point(16, 309)
        Me.RandomizeMOVToggle.Name = "RandomizeMOVToggle"
        Me.RandomizeMOVToggle.Size = New System.Drawing.Size(106, 17)
        Me.RandomizeMOVToggle.TabIndex = 40
        Me.RandomizeMOVToggle.Text = "Randomize MOV"
        Me.RandomizeMOVToggle.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(41, 329)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 13)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "Minimum MOV"
        '
        'MinimumMOVControl
        '
        Me.MinimumMOVControl.Location = New System.Drawing.Point(125, 327)
        Me.MinimumMOVControl.Maximum = New Decimal(New Integer() {9, 0, 0, 0})
        Me.MinimumMOVControl.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.MinimumMOVControl.Name = "MinimumMOVControl"
        Me.MinimumMOVControl.Size = New System.Drawing.Size(56, 20)
        Me.MinimumMOVControl.TabIndex = 42
        Me.MinimumMOVControl.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(41, 354)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(78, 13)
        Me.Label15.TabIndex = 43
        Me.Label15.Text = "Maximum MOV"
        '
        'MaximumMOVControl
        '
        Me.MaximumMOVControl.Location = New System.Drawing.Point(125, 352)
        Me.MaximumMOVControl.Maximum = New Decimal(New Integer() {9, 0, 0, 0})
        Me.MaximumMOVControl.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.MaximumMOVControl.Name = "MaximumMOVControl"
        Me.MaximumMOVControl.Size = New System.Drawing.Size(56, 20)
        Me.MaximumMOVControl.TabIndex = 44
        Me.MaximumMOVControl.Value = New Decimal(New Integer() {9, 0, 0, 0})
        '
        'RecruitmentBox
        '
        Me.RecruitmentBox.Controls.Add(Me.RandomRecruitmentOption)
        Me.RecruitmentBox.Controls.Add(Me.ReverseRecruitmentOption)
        Me.RecruitmentBox.Controls.Add(Me.NormalRecruitmentOption)
        Me.RecruitmentBox.Location = New System.Drawing.Point(435, 345)
        Me.RecruitmentBox.Name = "RecruitmentBox"
        Me.RecruitmentBox.Size = New System.Drawing.Size(139, 87)
        Me.RecruitmentBox.TabIndex = 46
        Me.RecruitmentBox.TabStop = False
        Me.RecruitmentBox.Text = "Recruitment"
        '
        'RandomRecruitmentOption
        '
        Me.RandomRecruitmentOption.AutoSize = True
        Me.RandomRecruitmentOption.Location = New System.Drawing.Point(7, 64)
        Me.RandomRecruitmentOption.Name = "RandomRecruitmentOption"
        Me.RandomRecruitmentOption.Size = New System.Drawing.Size(84, 17)
        Me.RandomRecruitmentOption.TabIndex = 2
        Me.RandomRecruitmentOption.Text = "Randomized"
        Me.RandomRecruitmentOption.UseVisualStyleBackColor = True
        '
        'ReverseRecruitmentOption
        '
        Me.ReverseRecruitmentOption.AutoSize = True
        Me.ReverseRecruitmentOption.Location = New System.Drawing.Point(7, 41)
        Me.ReverseRecruitmentOption.Name = "ReverseRecruitmentOption"
        Me.ReverseRecruitmentOption.Size = New System.Drawing.Size(71, 17)
        Me.ReverseRecruitmentOption.TabIndex = 1
        Me.ReverseRecruitmentOption.Text = "Reversed"
        Me.ReverseRecruitmentOption.UseVisualStyleBackColor = True
        '
        'NormalRecruitmentOption
        '
        Me.NormalRecruitmentOption.AutoSize = True
        Me.NormalRecruitmentOption.Checked = True
        Me.NormalRecruitmentOption.Location = New System.Drawing.Point(7, 17)
        Me.NormalRecruitmentOption.Name = "NormalRecruitmentOption"
        Me.NormalRecruitmentOption.Size = New System.Drawing.Size(58, 17)
        Me.NormalRecruitmentOption.TabIndex = 0
        Me.NormalRecruitmentOption.TabStop = True
        Me.NormalRecruitmentOption.Text = "Normal"
        Me.NormalRecruitmentOption.UseVisualStyleBackColor = True
        '
        'AllowUniqueClassesToggle
        '
        Me.AllowUniqueClassesToggle.AutoSize = True
        Me.AllowUniqueClassesToggle.Location = New System.Drawing.Point(456, 167)
        Me.AllowUniqueClassesToggle.Name = "AllowUniqueClassesToggle"
        Me.AllowUniqueClassesToggle.Size = New System.Drawing.Size(127, 17)
        Me.AllowUniqueClassesToggle.TabIndex = 47
        Me.AllowUniqueClassesToggle.Text = "Allow Unique Classes"
        Me.AllowUniqueClassesToggle.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(249, 354)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 13)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "Durability Variance"
        '
        'DurabilityVarianceControl
        '
        Me.DurabilityVarianceControl.Location = New System.Drawing.Point(352, 352)
        Me.DurabilityVarianceControl.Maximum = New Decimal(New Integer() {49, 0, 0, 0})
        Me.DurabilityVarianceControl.Name = "DurabilityVarianceControl"
        Me.DurabilityVarianceControl.Size = New System.Drawing.Size(52, 20)
        Me.DurabilityVarianceControl.TabIndex = 51
        '
        'AllowRandomTraitsToggle
        '
        Me.AllowRandomTraitsToggle.AutoSize = True
        Me.AllowRandomTraitsToggle.Location = New System.Drawing.Point(252, 415)
        Me.AllowRandomTraitsToggle.Name = "AllowRandomTraitsToggle"
        Me.AllowRandomTraitsToggle.Size = New System.Drawing.Size(123, 17)
        Me.AllowRandomTraitsToggle.TabIndex = 52
        Me.AllowRandomTraitsToggle.Text = "Allow Random Traits"
        Me.AllowRandomTraitsToggle.UseVisualStyleBackColor = True
        '
        'IncreaseEnemyGrowthsToggle
        '
        Me.IncreaseEnemyGrowthsToggle.AutoSize = True
        Me.IncreaseEnemyGrowthsToggle.Location = New System.Drawing.Point(435, 202)
        Me.IncreaseEnemyGrowthsToggle.Name = "IncreaseEnemyGrowthsToggle"
        Me.IncreaseEnemyGrowthsToggle.Size = New System.Drawing.Size(144, 17)
        Me.IncreaseEnemyGrowthsToggle.TabIndex = 53
        Me.IncreaseEnemyGrowthsToggle.Text = "Increase Enemy Growths"
        Me.IncreaseEnemyGrowthsToggle.UseVisualStyleBackColor = True
        '
        'BuffBossesToggle
        '
        Me.BuffBossesToggle.AutoSize = True
        Me.BuffBossesToggle.Location = New System.Drawing.Point(456, 315)
        Me.BuffBossesToggle.Name = "BuffBossesToggle"
        Me.BuffBossesToggle.Size = New System.Drawing.Size(105, 17)
        Me.BuffBossesToggle.TabIndex = 54
        Me.BuffBossesToggle.Text = "Also Buff Bosses"
        Me.BuffBossesToggle.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(453, 224)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(43, 13)
        Me.Label17.TabIndex = 55
        Me.Label17.Text = "Amount"
        '
        'EnemyBuffControl
        '
        Me.EnemyBuffControl.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.EnemyBuffControl.Location = New System.Drawing.Point(502, 222)
        Me.EnemyBuffControl.Name = "EnemyBuffControl"
        Me.EnemyBuffControl.Size = New System.Drawing.Size(72, 20)
        Me.EnemyBuffControl.TabIndex = 56
        '
        'SetMaximumEnemyBuffControl
        '
        Me.SetMaximumEnemyBuffControl.AutoSize = True
        Me.SetMaximumEnemyBuffControl.Location = New System.Drawing.Point(480, 244)
        Me.SetMaximumEnemyBuffControl.Name = "SetMaximumEnemyBuffControl"
        Me.SetMaximumEnemyBuffControl.Size = New System.Drawing.Size(94, 17)
        Me.SetMaximumEnemyBuffControl.TabIndex = 57
        Me.SetMaximumEnemyBuffControl.Text = "Up To Amount"
        Me.SetMaximumEnemyBuffControl.UseVisualStyleBackColor = True
        '
        'SetConstantEnemyBuffControl
        '
        Me.SetConstantEnemyBuffControl.AutoSize = True
        Me.SetConstantEnemyBuffControl.Checked = True
        Me.SetConstantEnemyBuffControl.Location = New System.Drawing.Point(480, 268)
        Me.SetConstantEnemyBuffControl.Name = "SetConstantEnemyBuffControl"
        Me.SetConstantEnemyBuffControl.Size = New System.Drawing.Size(98, 17)
        Me.SetConstantEnemyBuffControl.TabIndex = 58
        Me.SetConstantEnemyBuffControl.TabStop = True
        Me.SetConstantEnemyBuffControl.Text = "Exactly Amount"
        Me.SetConstantEnemyBuffControl.UseVisualStyleBackColor = True
        '
        'SetMinimumEnemyBuffControl
        '
        Me.SetMinimumEnemyBuffControl.AutoSize = True
        Me.SetMinimumEnemyBuffControl.Location = New System.Drawing.Point(480, 292)
        Me.SetMinimumEnemyBuffControl.Name = "SetMinimumEnemyBuffControl"
        Me.SetMinimumEnemyBuffControl.Size = New System.Drawing.Size(103, 17)
        Me.SetMinimumEnemyBuffControl.TabIndex = 59
        Me.SetMinimumEnemyBuffControl.Text = "At Least Amount"
        Me.SetMinimumEnemyBuffControl.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(249, 378)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Minimum Durability"
        '
        'MinimumDurabilityControl
        '
        Me.MinimumDurabilityControl.Location = New System.Drawing.Point(352, 376)
        Me.MinimumDurabilityControl.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.MinimumDurabilityControl.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.MinimumDurabilityControl.Name = "MinimumDurabilityControl"
        Me.MinimumDurabilityControl.Size = New System.Drawing.Size(52, 20)
        Me.MinimumDurabilityControl.TabIndex = 61
        Me.MinimumDurabilityControl.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'GrowthsTooltip
        '
        Me.GrowthsTooltip.AutoPopDelay = 30000
        Me.GrowthsTooltip.InitialDelay = 500
        Me.GrowthsTooltip.ReshowDelay = 100
        '
        'GrowthsVarianceTooltip
        '
        Me.GrowthsVarianceTooltip.AutoPopDelay = 30000
        Me.GrowthsVarianceTooltip.InitialDelay = 500
        Me.GrowthsVarianceTooltip.ReshowDelay = 100
        '
        'MinimumGrowthTooltip
        '
        Me.MinimumGrowthTooltip.AutoPopDelay = 30000
        Me.MinimumGrowthTooltip.InitialDelay = 500
        Me.MinimumGrowthTooltip.ReshowDelay = 100
        '
        'WeightedHPTooltip
        '
        Me.WeightedHPTooltip.AutoPopDelay = 30000
        Me.WeightedHPTooltip.InitialDelay = 500
        Me.WeightedHPTooltip.ReshowDelay = 100
        '
        'BasesTooltip
        '
        Me.BasesTooltip.AutoPopDelay = 30000
        Me.BasesTooltip.InitialDelay = 500
        Me.BasesTooltip.ReshowDelay = 100
        '
        'BaseVarianceTooltip
        '
        Me.BaseVarianceTooltip.AutoPopDelay = 30000
        Me.BaseVarianceTooltip.InitialDelay = 500
        Me.BaseVarianceTooltip.ReshowDelay = 100
        '
        'CONTooltip
        '
        Me.CONTooltip.AutoPopDelay = 30000
        Me.CONTooltip.InitialDelay = 500
        Me.CONTooltip.ReshowDelay = 100
        '
        'MinimumCONTooltip
        '
        Me.MinimumCONTooltip.AutoPopDelay = 30000
        Me.MinimumCONTooltip.InitialDelay = 500
        Me.MinimumCONTooltip.ReshowDelay = 100
        '
        'MOVTooltip
        '
        Me.MOVTooltip.AutoPopDelay = 30000
        Me.MOVTooltip.InitialDelay = 500
        Me.MOVTooltip.ReshowDelay = 100
        '
        'MinimumMOVTooltip
        '
        Me.MinimumMOVTooltip.AutoPopDelay = 30000
        Me.MinimumMOVTooltip.InitialDelay = 500
        Me.MinimumMOVTooltip.ReshowDelay = 100
        '
        'MaximumMOVTooltip
        '
        Me.MaximumMOVTooltip.AutoPopDelay = 30000
        Me.MaximumMOVTooltip.InitialDelay = 500
        Me.MaximumMOVTooltip.ReshowDelay = 100
        '
        'RandomAffinityTooltip
        '
        Me.RandomAffinityTooltip.AutoPopDelay = 30000
        Me.RandomAffinityTooltip.InitialDelay = 500
        Me.RandomAffinityTooltip.ReshowDelay = 100
        '
        'AffinityBonusAmountTooltip
        '
        Me.AffinityBonusAmountTooltip.AutoPopDelay = 30000
        Me.AffinityBonusAmountTooltip.InitialDelay = 500
        Me.AffinityBonusAmountTooltip.ReshowDelay = 100
        '
        'RandomItemsTooltip
        '
        Me.RandomItemsTooltip.AutoPopDelay = 30000
        Me.RandomItemsTooltip.InitialDelay = 500
        Me.RandomItemsTooltip.ReshowDelay = 100
        '
        'MightVarianceTooltip
        '
        Me.MightVarianceTooltip.AutoPopDelay = 30000
        Me.MightVarianceTooltip.InitialDelay = 500
        Me.MightVarianceTooltip.ReshowDelay = 100
        '
        'MinimumMightTooltip
        '
        Me.MinimumMightTooltip.AutoPopDelay = 30000
        Me.MinimumMightTooltip.InitialDelay = 500
        Me.MinimumMightTooltip.ReshowDelay = 100
        '
        'CriticalVarianceTooltip
        '
        Me.CriticalVarianceTooltip.AutoPopDelay = 30000
        Me.CriticalVarianceTooltip.InitialDelay = 500
        Me.CriticalVarianceTooltip.ReshowDelay = 100
        '
        'MinimumCriticalTooltip
        '
        Me.MinimumCriticalTooltip.AutoPopDelay = 30000
        Me.MinimumCriticalTooltip.InitialDelay = 500
        Me.MinimumCriticalTooltip.ReshowDelay = 100
        '
        'WeightVarianceTooltip
        '
        Me.WeightVarianceTooltip.AutoPopDelay = 30000
        Me.WeightVarianceTooltip.InitialDelay = 500
        Me.WeightVarianceTooltip.ReshowDelay = 100
        '
        'MaximumWeightTooltip
        '
        Me.MaximumWeightTooltip.AutoPopDelay = 30000
        Me.MaximumWeightTooltip.InitialDelay = 500
        Me.MaximumWeightTooltip.ReshowDelay = 100
        '
        'DurabilityVarianceTooltip
        '
        Me.DurabilityVarianceTooltip.AutoPopDelay = 30000
        Me.DurabilityVarianceTooltip.InitialDelay = 500
        Me.DurabilityVarianceTooltip.ReshowDelay = 100
        '
        'MinimumDurabilityTooltip
        '
        Me.MinimumDurabilityTooltip.AutoPopDelay = 30000
        Me.MinimumDurabilityTooltip.InitialDelay = 500
        Me.MinimumDurabilityTooltip.ReshowDelay = 100
        '
        'AllowRandomTraitsTooltip
        '
        Me.AllowRandomTraitsTooltip.AutoPopDelay = 30000
        Me.AllowRandomTraitsTooltip.InitialDelay = 500
        Me.AllowRandomTraitsTooltip.ReshowDelay = 100
        '
        'RandomClassesTooltip
        '
        Me.RandomClassesTooltip.AutoPopDelay = 30000
        Me.RandomClassesTooltip.InitialDelay = 500
        Me.RandomClassesTooltip.ReshowDelay = 100
        '
        'RandomizeLordsTooltip
        '
        Me.RandomizeLordsTooltip.AutoPopDelay = 30000
        Me.RandomizeLordsTooltip.InitialDelay = 500
        Me.RandomizeLordsTooltip.ReshowDelay = 100
        '
        'RandomizeThievesTooltip
        '
        Me.RandomizeThievesTooltip.AutoPopDelay = 30000
        Me.RandomizeThievesTooltip.InitialDelay = 500
        Me.RandomizeThievesTooltip.ReshowDelay = 100
        '
        'RandomizeBossesTooltip
        '
        Me.RandomizeBossesTooltip.AutoPopDelay = 30000
        Me.RandomizeBossesTooltip.InitialDelay = 500
        Me.RandomizeBossesTooltip.ReshowDelay = 100
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(41, 252)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(75, 13)
        Me.Label18.TabIndex = 62
        Me.Label18.Text = "CON Variance"
        '
        'CONVarianceControl
        '
        Me.CONVarianceControl.Location = New System.Drawing.Point(116, 250)
        Me.CONVarianceControl.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.CONVarianceControl.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.CONVarianceControl.Name = "CONVarianceControl"
        Me.CONVarianceControl.Size = New System.Drawing.Size(57, 20)
        Me.CONVarianceControl.TabIndex = 63
        Me.CONVarianceControl.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'GameSpecificCheckbox
        '
        Me.GameSpecificCheckbox.AutoSize = True
        Me.GameSpecificCheckbox.Location = New System.Drawing.Point(228, 47)
        Me.GameSpecificCheckbox.Name = "GameSpecificCheckbox"
        Me.GameSpecificCheckbox.Size = New System.Drawing.Size(154, 17)
        Me.GameSpecificCheckbox.TabIndex = 64
        Me.GameSpecificCheckbox.Text = "Apply Arch's Tutorial Slayer"
        Me.GameSpecificCheckbox.UseVisualStyleBackColor = True
        Me.GameSpecificCheckbox.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 480)
        Me.Controls.Add(Me.GameSpecificCheckbox)
        Me.Controls.Add(Me.CONVarianceControl)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.MinimumDurabilityControl)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SetMinimumEnemyBuffControl)
        Me.Controls.Add(Me.SetConstantEnemyBuffControl)
        Me.Controls.Add(Me.SetMaximumEnemyBuffControl)
        Me.Controls.Add(Me.EnemyBuffControl)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.BuffBossesToggle)
        Me.Controls.Add(Me.IncreaseEnemyGrowthsToggle)
        Me.Controls.Add(Me.AllowRandomTraitsToggle)
        Me.Controls.Add(Me.DurabilityVarianceControl)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.AllowUniqueClassesToggle)
        Me.Controls.Add(Me.RecruitmentBox)
        Me.Controls.Add(Me.MaximumMOVControl)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.MinimumMOVControl)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.RandomizeMOVToggle)
        Me.Controls.Add(Me.MinimumCONControl)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.WeightedHPGrowthsToggle)
        Me.Controls.Add(Me.MaximumWeightControl)
        Me.Controls.Add(Me.MinimumWeightControl)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.MinimumCriticalControl)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.MinimumHitControl)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.MinimumMightControl)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.WeightVarianceControl)
        Me.Controls.Add(Me.CriticalVarianceControl)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.HitVarianceControl)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.MightVarianceControl)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.RandomizeItemsToggle)
        Me.Controls.Add(Me.IncludeBossesToggle)
        Me.Controls.Add(Me.IncludeThievesToggle)
        Me.Controls.Add(Me.IncludeLordsToggle)
        Me.Controls.Add(Me.RandomizeClassesToggle)
        Me.Controls.Add(Me.MinimumGrowthToggle)
        Me.Controls.Add(Me.BaseVarianceControl)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GrowthVarianceControl)
        Me.Controls.Add(Me.RandomizeAffinityToggle)
        Me.Controls.Add(Me.RandomizeButton)
        Me.Controls.Add(Me.RandomizeCONToggle)
        Me.Controls.Add(Me.RandomizeBasesToggle)
        Me.Controls.Add(Me.RandomizeGrowthsToggle)
        Me.Controls.Add(Me.GameDetectionLabel)
        Me.Controls.Add(Me.BrowseButton)
        Me.Controls.Add(Me.FilenameTextBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "GBA FE Randomizer v0.99 by OtakuReborn"
        CType(Me.GrowthVarianceControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BaseVarianceControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MightVarianceControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HitVarianceControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CriticalVarianceControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WeightVarianceControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinimumMightControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinimumHitControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinimumCriticalControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinimumWeightControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaximumWeightControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinimumCONControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinimumMOVControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaximumMOVControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RecruitmentBox.ResumeLayout(False)
        Me.RecruitmentBox.PerformLayout()
        CType(Me.DurabilityVarianceControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EnemyBuffControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinimumDurabilityControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CONVarianceControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FilenameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BrowseButton As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GameDetectionLabel As System.Windows.Forms.Label
    Friend WithEvents RandomizeGrowthsToggle As System.Windows.Forms.CheckBox
    Friend WithEvents RandomizeBasesToggle As System.Windows.Forms.CheckBox
    Friend WithEvents RandomizeCONToggle As System.Windows.Forms.CheckBox
    Friend WithEvents RandomizeButton As System.Windows.Forms.Button
    Friend WithEvents RandomizeAffinityToggle As System.Windows.Forms.CheckBox
    Friend WithEvents GrowthVarianceControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BaseVarianceControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents MinimumGrowthToggle As System.Windows.Forms.CheckBox
    Friend WithEvents RandomizeClassesToggle As System.Windows.Forms.CheckBox
    Friend WithEvents IncludeLordsToggle As System.Windows.Forms.CheckBox
    Friend WithEvents IncludeThievesToggle As System.Windows.Forms.CheckBox
    Friend WithEvents IncludeBossesToggle As System.Windows.Forms.CheckBox
    Friend WithEvents RandomizeItemsToggle As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MightVarianceControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents HitVarianceControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CriticalVarianceControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents WeightVarianceControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents MinimumMightControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents MinimumHitControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents MinimumCriticalControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents MinimumWeightControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents MaximumWeightControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents WeightedHPGrowthsToggle As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents MinimumCONControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents RandomizeMOVToggle As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents MinimumMOVControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents MaximumMOVControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents RecruitmentBox As System.Windows.Forms.GroupBox
    Friend WithEvents RandomRecruitmentOption As System.Windows.Forms.RadioButton
    Friend WithEvents ReverseRecruitmentOption As System.Windows.Forms.RadioButton
    Friend WithEvents NormalRecruitmentOption As System.Windows.Forms.RadioButton
    Friend WithEvents AllowUniqueClassesToggle As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DurabilityVarianceControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents AllowRandomTraitsToggle As System.Windows.Forms.CheckBox
    Friend WithEvents IncreaseEnemyGrowthsToggle As System.Windows.Forms.CheckBox
    Friend WithEvents BuffBossesToggle As System.Windows.Forms.CheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents EnemyBuffControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents SetMaximumEnemyBuffControl As System.Windows.Forms.RadioButton
    Friend WithEvents SetConstantEnemyBuffControl As System.Windows.Forms.RadioButton
    Friend WithEvents SetMinimumEnemyBuffControl As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MinimumDurabilityControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents GrowthsTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents GrowthsVarianceTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents MinimumGrowthTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents WeightedHPTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents BasesTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents BaseVarianceTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents CONTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents MinimumCONTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents MOVTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents MinimumMOVTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents MaximumMOVTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents RandomAffinityTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents AffinityBonusAmountTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents RandomItemsTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents MightVarianceTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents MinimumMightTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents MinimumHitTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents HitVarianceTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents CriticalVarianceTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents MinimumCriticalTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents WeightVarianceTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents MinimumWeightTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents MaximumWeightTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents DurabilityVarianceTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents MinimumDurabilityTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents AllowRandomTraitsTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents RandomClassesTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents RandomizeLordsTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents RandomizeThievesTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents RandomizeBossesTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents UniqueClassesTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents EnemyBuffTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents BuffAmountTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents BossBuffTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents RecruitmentTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CONVarianceControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents CONVarianceTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents GameSpecificCheckbox As System.Windows.Forms.CheckBox

End Class
