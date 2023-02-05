<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetTargetWeight
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
        Me.lblTargetWeight = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSetTargetWeight = New System.Windows.Forms.Button()
        Me.txtTargetWeight = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblTargetWeight
        '
        Me.lblTargetWeight.AutoSize = True
        Me.lblTargetWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTargetWeight.Location = New System.Drawing.Point(52, 21)
        Me.lblTargetWeight.Name = "lblTargetWeight"
        Me.lblTargetWeight.Size = New System.Drawing.Size(92, 13)
        Me.lblTargetWeight.TabIndex = 3
        Me.lblTargetWeight.Text = "Target Weight:"
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(52, 127)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(162, 23)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSetTargetWeight
        '
        Me.cmdSetTargetWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSetTargetWeight.Location = New System.Drawing.Point(55, 80)
        Me.cmdSetTargetWeight.Name = "cmdSetTargetWeight"
        Me.cmdSetTargetWeight.Size = New System.Drawing.Size(162, 23)
        Me.cmdSetTargetWeight.TabIndex = 1
        Me.cmdSetTargetWeight.Text = "Set Target Weight"
        Me.cmdSetTargetWeight.UseVisualStyleBackColor = True
        '
        'txtTargetWeight
        '
        Me.txtTargetWeight.Location = New System.Drawing.Point(55, 38)
        Me.txtTargetWeight.Name = "txtTargetWeight"
        Me.txtTargetWeight.Size = New System.Drawing.Size(152, 20)
        Me.txtTargetWeight.TabIndex = 0
        '
        'SetTargetWeight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(273, 179)
        Me.Controls.Add(Me.txtTargetWeight)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSetTargetWeight)
        Me.Controls.Add(Me.lblTargetWeight)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "SetTargetWeight"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Set Target Weight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTargetWeight As Label
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdSetTargetWeight As Button
    Friend WithEvents txtTargetWeight As TextBox
End Class
