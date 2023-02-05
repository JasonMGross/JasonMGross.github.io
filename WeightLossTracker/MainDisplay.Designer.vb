<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainDisplay
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.chtDataGraphic = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdDeleteWeightRecord = New System.Windows.Forms.Button()
        Me.cmdEditRecord = New System.Windows.Forms.Button()
        Me.cmdLogout = New System.Windows.Forms.Button()
        Me.cmdDeleteAccount = New System.Windows.Forms.Button()
        Me.cmdSetTargetWeight = New System.Windows.Forms.Button()
        Me.cmdAddNewWeight = New System.Windows.Forms.Button()
        Me.dgvWeightData = New System.Windows.Forms.DataGridView()
        Me.chkDisplayWeights = New System.Windows.Forms.CheckBox()
        Me.chkDisplayExerciseMins = New System.Windows.Forms.CheckBox()
        Me.chkDisplayTargetWeights = New System.Windows.Forms.CheckBox()
        CType(Me.chtDataGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvWeightData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chtDataGraphic
        '
        ChartArea1.AxisX.IsLabelAutoFit = False
        ChartArea1.AxisX.LabelStyle.Angle = 75
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver
        ChartArea1.AxisX.MajorTickMark.Enabled = False
        ChartArea1.AxisY.IsLabelAutoFit = False
        ChartArea1.AxisY.MajorGrid.Enabled = False
        ChartArea1.AxisY2.MajorGrid.Enabled = False
        ChartArea1.Name = "caData"
        Me.chtDataGraphic.ChartAreas.Add(ChartArea1)
        Legend1.Alignment = System.Drawing.StringAlignment.Center
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend1.Name = "chartLegend"
        Me.chtDataGraphic.Legends.Add(Legend1)
        Me.chtDataGraphic.Location = New System.Drawing.Point(515, 12)
        Me.chtDataGraphic.Name = "chtDataGraphic"
        Series1.BorderWidth = 2
        Series1.ChartArea = "caData"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Series1.IsValueShownAsLabel = True
        Series1.Legend = "chartLegend"
        Series1.MarkerSize = 10
        Series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series1.Name = "Weights"
        Series2.BorderWidth = 2
        Series2.ChartArea = "caData"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Series2.IsValueShownAsLabel = True
        Series2.Legend = "chartLegend"
        Series2.MarkerSize = 10
        Series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square
        Series2.Name = "Exercise Minutes"
        Series2.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary
        Series2.YValuesPerPoint = 2
        Series3.BorderWidth = 3
        Series3.ChartArea = "caData"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series3.Legend = "chartLegend"
        Series3.Name = "Target Weight"
        Me.chtDataGraphic.Series.Add(Series1)
        Me.chtDataGraphic.Series.Add(Series2)
        Me.chtDataGraphic.Series.Add(Series3)
        Me.chtDataGraphic.Size = New System.Drawing.Size(716, 448)
        Me.chtDataGraphic.TabIndex = 1
        Me.chtDataGraphic.Text = "WeightExerciseMins"
        Title1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title1.Name = "chartTitle"
        Title1.Text = "Daily Weights & Exercise Time"
        Me.chtDataGraphic.Titles.Add(Title1)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdDeleteWeightRecord)
        Me.GroupBox1.Controls.Add(Me.cmdEditRecord)
        Me.GroupBox1.Controls.Add(Me.cmdLogout)
        Me.GroupBox1.Controls.Add(Me.cmdDeleteAccount)
        Me.GroupBox1.Controls.Add(Me.cmdSetTargetWeight)
        Me.GroupBox1.Controls.Add(Me.cmdAddNewWeight)
        Me.GroupBox1.Location = New System.Drawing.Point(515, 511)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(716, 149)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'cmdDeleteWeightRecord
        '
        Me.cmdDeleteWeightRecord.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteWeightRecord.Location = New System.Drawing.Point(49, 91)
        Me.cmdDeleteWeightRecord.Name = "cmdDeleteWeightRecord"
        Me.cmdDeleteWeightRecord.Size = New System.Drawing.Size(170, 38)
        Me.cmdDeleteWeightRecord.TabIndex = 1
        Me.cmdDeleteWeightRecord.Text = "Delete Weight Record"
        Me.cmdDeleteWeightRecord.UseVisualStyleBackColor = True
        '
        'cmdEditRecord
        '
        Me.cmdEditRecord.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEditRecord.Location = New System.Drawing.Point(49, 28)
        Me.cmdEditRecord.Name = "cmdEditRecord"
        Me.cmdEditRecord.Size = New System.Drawing.Size(170, 38)
        Me.cmdEditRecord.TabIndex = 0
        Me.cmdEditRecord.Text = "Edit Weight Record"
        Me.cmdEditRecord.UseVisualStyleBackColor = True
        '
        'cmdLogout
        '
        Me.cmdLogout.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLogout.Location = New System.Drawing.Point(501, 91)
        Me.cmdLogout.Name = "cmdLogout"
        Me.cmdLogout.Size = New System.Drawing.Size(170, 38)
        Me.cmdLogout.TabIndex = 5
        Me.cmdLogout.Text = "Logout"
        Me.cmdLogout.UseVisualStyleBackColor = True
        '
        'cmdDeleteAccount
        '
        Me.cmdDeleteAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteAccount.Location = New System.Drawing.Point(501, 28)
        Me.cmdDeleteAccount.Name = "cmdDeleteAccount"
        Me.cmdDeleteAccount.Size = New System.Drawing.Size(170, 38)
        Me.cmdDeleteAccount.TabIndex = 4
        Me.cmdDeleteAccount.Text = "Delete Account"
        Me.cmdDeleteAccount.UseVisualStyleBackColor = True
        '
        'cmdSetTargetWeight
        '
        Me.cmdSetTargetWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSetTargetWeight.Location = New System.Drawing.Point(281, 91)
        Me.cmdSetTargetWeight.Name = "cmdSetTargetWeight"
        Me.cmdSetTargetWeight.Size = New System.Drawing.Size(170, 38)
        Me.cmdSetTargetWeight.TabIndex = 3
        Me.cmdSetTargetWeight.Text = "Set Target Weight"
        Me.cmdSetTargetWeight.UseVisualStyleBackColor = True
        '
        'cmdAddNewWeight
        '
        Me.cmdAddNewWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddNewWeight.Location = New System.Drawing.Point(281, 28)
        Me.cmdAddNewWeight.Name = "cmdAddNewWeight"
        Me.cmdAddNewWeight.Size = New System.Drawing.Size(170, 38)
        Me.cmdAddNewWeight.TabIndex = 2
        Me.cmdAddNewWeight.Text = "Add New Weight"
        Me.cmdAddNewWeight.UseVisualStyleBackColor = True
        '
        'dgvWeightData
        '
        Me.dgvWeightData.AllowUserToAddRows = False
        Me.dgvWeightData.AllowUserToDeleteRows = False
        Me.dgvWeightData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvWeightData.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvWeightData.Location = New System.Drawing.Point(12, 12)
        Me.dgvWeightData.MultiSelect = False
        Me.dgvWeightData.Name = "dgvWeightData"
        Me.dgvWeightData.ReadOnly = True
        Me.dgvWeightData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvWeightData.Size = New System.Drawing.Size(484, 648)
        Me.dgvWeightData.TabIndex = 6
        '
        'chkDisplayWeights
        '
        Me.chkDisplayWeights.AutoSize = True
        Me.chkDisplayWeights.Checked = True
        Me.chkDisplayWeights.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDisplayWeights.Location = New System.Drawing.Point(667, 478)
        Me.chkDisplayWeights.Name = "chkDisplayWeights"
        Me.chkDisplayWeights.Size = New System.Drawing.Size(102, 17)
        Me.chkDisplayWeights.TabIndex = 7
        Me.chkDisplayWeights.Text = "Display Weights"
        Me.chkDisplayWeights.UseVisualStyleBackColor = True
        '
        'chkDisplayExerciseMins
        '
        Me.chkDisplayExerciseMins.AutoSize = True
        Me.chkDisplayExerciseMins.Checked = True
        Me.chkDisplayExerciseMins.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDisplayExerciseMins.Location = New System.Drawing.Point(796, 478)
        Me.chkDisplayExerciseMins.Name = "chkDisplayExerciseMins"
        Me.chkDisplayExerciseMins.Size = New System.Drawing.Size(143, 17)
        Me.chkDisplayExerciseMins.TabIndex = 8
        Me.chkDisplayExerciseMins.Text = "Display Exercise Minutes"
        Me.chkDisplayExerciseMins.UseVisualStyleBackColor = True
        '
        'chkDisplayTargetWeights
        '
        Me.chkDisplayTargetWeights.AutoSize = True
        Me.chkDisplayTargetWeights.Checked = True
        Me.chkDisplayTargetWeights.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDisplayTargetWeights.Location = New System.Drawing.Point(977, 478)
        Me.chkDisplayTargetWeights.Name = "chkDisplayTargetWeights"
        Me.chkDisplayTargetWeights.Size = New System.Drawing.Size(136, 17)
        Me.chkDisplayTargetWeights.TabIndex = 9
        Me.chkDisplayTargetWeights.Text = "Display Target Weights"
        Me.chkDisplayTargetWeights.UseVisualStyleBackColor = True
        '
        'MainDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1245, 691)
        Me.Controls.Add(Me.chkDisplayTargetWeights)
        Me.Controls.Add(Me.chkDisplayExerciseMins)
        Me.Controls.Add(Me.chkDisplayWeights)
        Me.Controls.Add(Me.dgvWeightData)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chtDataGraphic)
        Me.Name = "MainDisplay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Weight Loss Tracker"
        CType(Me.chtDataGraphic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvWeightData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chtDataGraphic As DataVisualization.Charting.Chart
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmdLogout As Button
    Friend WithEvents cmdDeleteAccount As Button
    Friend WithEvents cmdSetTargetWeight As Button
    Friend WithEvents cmdAddNewWeight As Button
    Friend WithEvents cmdDeleteWeightRecord As Button
    Friend WithEvents cmdEditRecord As Button
    Friend WithEvents dgvWeightData As DataGridView
    Friend WithEvents chkDisplayWeights As CheckBox
    Friend WithEvents chkDisplayExerciseMins As CheckBox
    Friend WithEvents chkDisplayTargetWeights As CheckBox
End Class
