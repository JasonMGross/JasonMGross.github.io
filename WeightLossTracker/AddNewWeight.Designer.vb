<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddNewWeight
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
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdEnterWeight = New System.Windows.Forms.Button()
        Me.lblCurrentWeight = New System.Windows.Forms.Label()
        Me.lblExerciseMinutes = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.txtCurrentWeight = New System.Windows.Forms.TextBox()
        Me.txtExerciseMinutes = New System.Windows.Forms.TextBox()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(69, 232)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(174, 23)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdEnterWeight
        '
        Me.cmdEnterWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEnterWeight.Location = New System.Drawing.Point(69, 186)
        Me.cmdEnterWeight.Name = "cmdEnterWeight"
        Me.cmdEnterWeight.Size = New System.Drawing.Size(174, 23)
        Me.cmdEnterWeight.TabIndex = 3
        Me.cmdEnterWeight.Text = "Enter Weight"
        Me.cmdEnterWeight.UseVisualStyleBackColor = True
        '
        'lblCurrentWeight
        '
        Me.lblCurrentWeight.AutoSize = True
        Me.lblCurrentWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentWeight.Location = New System.Drawing.Point(69, 24)
        Me.lblCurrentWeight.Name = "lblCurrentWeight"
        Me.lblCurrentWeight.Size = New System.Drawing.Size(96, 13)
        Me.lblCurrentWeight.TabIndex = 7
        Me.lblCurrentWeight.Text = "Current Weight:"
        '
        'lblExerciseMinutes
        '
        Me.lblExerciseMinutes.AutoSize = True
        Me.lblExerciseMinutes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExerciseMinutes.Location = New System.Drawing.Point(69, 73)
        Me.lblExerciseMinutes.Name = "lblExerciseMinutes"
        Me.lblExerciseMinutes.Size = New System.Drawing.Size(107, 13)
        Me.lblExerciseMinutes.TabIndex = 10
        Me.lblExerciseMinutes.Text = "Exercise Minutes:"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(69, 121)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(38, 13)
        Me.lblDate.TabIndex = 12
        Me.lblDate.Text = "Date:"
        '
        'txtCurrentWeight
        '
        Me.txtCurrentWeight.Location = New System.Drawing.Point(72, 41)
        Me.txtCurrentWeight.Name = "txtCurrentWeight"
        Me.txtCurrentWeight.Size = New System.Drawing.Size(164, 20)
        Me.txtCurrentWeight.TabIndex = 0
        '
        'txtExerciseMinutes
        '
        Me.txtExerciseMinutes.Location = New System.Drawing.Point(72, 89)
        Me.txtExerciseMinutes.Name = "txtExerciseMinutes"
        Me.txtExerciseMinutes.Size = New System.Drawing.Size(164, 20)
        Me.txtExerciseMinutes.TabIndex = 1
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(72, 137)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(164, 20)
        Me.txtDate.TabIndex = 2
        '
        'AddNewWeight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(316, 283)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.txtExerciseMinutes)
        Me.Controls.Add(Me.txtCurrentWeight)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblExerciseMinutes)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdEnterWeight)
        Me.Controls.Add(Me.lblCurrentWeight)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "AddNewWeight"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add New Weight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdEnterWeight As Button
    Friend WithEvents lblCurrentWeight As Label
    Friend WithEvents lblExerciseMinutes As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents txtCurrentWeight As TextBox
    Friend WithEvents txtExerciseMinutes As TextBox
    Friend WithEvents txtDate As TextBox
End Class
