<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Me.txtServerAddress = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSaveSettings = New System.Windows.Forms.Button()
        Me.lblServerAddress = New System.Windows.Forms.Label()
        Me.lblFormat = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtServerAddress
        '
        Me.txtServerAddress.Location = New System.Drawing.Point(116, 22)
        Me.txtServerAddress.Name = "txtServerAddress"
        Me.txtServerAddress.Size = New System.Drawing.Size(130, 20)
        Me.txtServerAddress.TabIndex = 0
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(63, 182)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(140, 23)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSaveSettings
        '
        Me.cmdSaveSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSaveSettings.Location = New System.Drawing.Point(63, 141)
        Me.cmdSaveSettings.Name = "cmdSaveSettings"
        Me.cmdSaveSettings.Size = New System.Drawing.Size(140, 23)
        Me.cmdSaveSettings.TabIndex = 1
        Me.cmdSaveSettings.Text = "Save Settings"
        Me.cmdSaveSettings.UseVisualStyleBackColor = True
        '
        'lblServerAddress
        '
        Me.lblServerAddress.AutoSize = True
        Me.lblServerAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServerAddress.Location = New System.Drawing.Point(18, 25)
        Me.lblServerAddress.Name = "lblServerAddress"
        Me.lblServerAddress.Size = New System.Drawing.Size(97, 13)
        Me.lblServerAddress.TabIndex = 6
        Me.lblServerAddress.Text = "Server Address:"
        '
        'lblFormat
        '
        Me.lblFormat.AutoSize = True
        Me.lblFormat.Location = New System.Drawing.Point(60, 59)
        Me.lblFormat.Name = "lblFormat"
        Me.lblFormat.Size = New System.Drawing.Size(134, 13)
        Me.lblFormat.TabIndex = 10
        Me.lblFormat.Text = "Example:  127.0.0.1(:3306)"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(60, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 44)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Note:  The IP Address is required but the port is optional."
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(275, 230)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblFormat)
        Me.Controls.Add(Me.txtServerAddress)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSaveSettings)
        Me.Controls.Add(Me.lblServerAddress)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtServerAddress As TextBox
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdSaveSettings As Button
    Friend WithEvents lblServerAddress As Label
    Friend WithEvents lblFormat As Label
    Friend WithEvents Label1 As Label
End Class
