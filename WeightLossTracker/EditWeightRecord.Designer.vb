<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditWeightRecord
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
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.txtExerciseMinutes = New System.Windows.Forms.TextBox()
        Me.txtCurrentWeight = New System.Windows.Forms.TextBox()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblExerciseMinutes = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdUpdateRecord = New System.Windows.Forms.Button()
        Me.lblWeight = New System.Windows.Forms.Label()
        Me.txtCurrentTarget = New System.Windows.Forms.TextBox()
        Me.lblCurrentTarget = New System.Windows.Forms.Label()
        Me.txtRecordID = New System.Windows.Forms.TextBox()
        Me.lblRecID = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(63, 87)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(162, 20)
        Me.txtDate.TabIndex = 23
        Me.txtDate.TabStop = False
        '
        'txtExerciseMinutes
        '
        Me.txtExerciseMinutes.Location = New System.Drawing.Point(63, 183)
        Me.txtExerciseMinutes.Name = "txtExerciseMinutes"
        Me.txtExerciseMinutes.Size = New System.Drawing.Size(162, 20)
        Me.txtExerciseMinutes.TabIndex = 1
        '
        'txtCurrentWeight
        '
        Me.txtCurrentWeight.Location = New System.Drawing.Point(63, 135)
        Me.txtCurrentWeight.Name = "txtCurrentWeight"
        Me.txtCurrentWeight.Size = New System.Drawing.Size(162, 20)
        Me.txtCurrentWeight.TabIndex = 0
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(60, 71)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(38, 13)
        Me.lblDate.TabIndex = 20
        Me.lblDate.Text = "Date:"
        '
        'lblExerciseMinutes
        '
        Me.lblExerciseMinutes.AutoSize = True
        Me.lblExerciseMinutes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExerciseMinutes.Location = New System.Drawing.Point(60, 167)
        Me.lblExerciseMinutes.Name = "lblExerciseMinutes"
        Me.lblExerciseMinutes.Size = New System.Drawing.Size(107, 13)
        Me.lblExerciseMinutes.TabIndex = 19
        Me.lblExerciseMinutes.Text = "Exercise Minutes:"
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(61, 337)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(172, 23)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdUpdateRecord
        '
        Me.cmdUpdateRecord.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdateRecord.Location = New System.Drawing.Point(61, 291)
        Me.cmdUpdateRecord.Name = "cmdUpdateRecord"
        Me.cmdUpdateRecord.Size = New System.Drawing.Size(172, 23)
        Me.cmdUpdateRecord.TabIndex = 3
        Me.cmdUpdateRecord.Text = "Update Record"
        Me.cmdUpdateRecord.UseVisualStyleBackColor = True
        '
        'lblWeight
        '
        Me.lblWeight.AutoSize = True
        Me.lblWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeight.Location = New System.Drawing.Point(60, 118)
        Me.lblWeight.Name = "lblWeight"
        Me.lblWeight.Size = New System.Drawing.Size(51, 13)
        Me.lblWeight.TabIndex = 18
        Me.lblWeight.Text = "Weight:"
        '
        'txtCurrentTarget
        '
        Me.txtCurrentTarget.Location = New System.Drawing.Point(63, 238)
        Me.txtCurrentTarget.Name = "txtCurrentTarget"
        Me.txtCurrentTarget.Size = New System.Drawing.Size(162, 20)
        Me.txtCurrentTarget.TabIndex = 2
        '
        'lblCurrentTarget
        '
        Me.lblCurrentTarget.AutoSize = True
        Me.lblCurrentTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentTarget.Location = New System.Drawing.Point(60, 222)
        Me.lblCurrentTarget.Name = "lblCurrentTarget"
        Me.lblCurrentTarget.Size = New System.Drawing.Size(93, 13)
        Me.lblCurrentTarget.TabIndex = 24
        Me.lblCurrentTarget.Text = "Current Target:"
        '
        'txtRecordID
        '
        Me.txtRecordID.Location = New System.Drawing.Point(63, 42)
        Me.txtRecordID.Name = "txtRecordID"
        Me.txtRecordID.ReadOnly = True
        Me.txtRecordID.Size = New System.Drawing.Size(162, 20)
        Me.txtRecordID.TabIndex = 27
        Me.txtRecordID.TabStop = False
        '
        'lblRecID
        '
        Me.lblRecID.AutoSize = True
        Me.lblRecID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecID.Location = New System.Drawing.Point(60, 26)
        Me.lblRecID.Name = "lblRecID"
        Me.lblRecID.Size = New System.Drawing.Size(69, 13)
        Me.lblRecID.TabIndex = 26
        Me.lblRecID.Text = "Record ID:"
        '
        'EditWeightRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(299, 386)
        Me.Controls.Add(Me.txtRecordID)
        Me.Controls.Add(Me.lblRecID)
        Me.Controls.Add(Me.txtCurrentTarget)
        Me.Controls.Add(Me.lblCurrentTarget)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.txtExerciseMinutes)
        Me.Controls.Add(Me.txtCurrentWeight)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblExerciseMinutes)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdUpdateRecord)
        Me.Controls.Add(Me.lblWeight)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "EditWeightRecord"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Weight Record"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtDate As TextBox
    Friend WithEvents txtExerciseMinutes As TextBox
    Friend WithEvents txtCurrentWeight As TextBox
    Friend WithEvents lblDate As Label
    Friend WithEvents lblExerciseMinutes As Label
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdUpdateRecord As Button
    Friend WithEvents lblWeight As Label
    Friend WithEvents txtCurrentTarget As TextBox
    Friend WithEvents lblCurrentTarget As Label
    Friend WithEvents txtRecordID As TextBox
    Friend WithEvents lblRecID As Label
End Class
