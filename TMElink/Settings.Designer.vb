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
        Me.Settings_GRID = New System.Windows.Forms.DataGridView()
        Me.Back_BTN = New System.Windows.Forms.Button()
        Me.Save_BTN = New System.Windows.Forms.Button()
        Me.XMLFile_BOX = New System.Windows.Forms.TextBox()
        Me.Change_BTN = New System.Windows.Forms.Button()
        CType(Me.Settings_GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Settings_GRID
        '
        Me.Settings_GRID.AllowUserToDeleteRows = False
        Me.Settings_GRID.AllowUserToOrderColumns = True
        Me.Settings_GRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Settings_GRID.Location = New System.Drawing.Point(12, 38)
        Me.Settings_GRID.Name = "Settings_GRID"
        Me.Settings_GRID.Size = New System.Drawing.Size(389, 218)
        Me.Settings_GRID.TabIndex = 15
        '
        'Back_BTN
        '
        Me.Back_BTN.Location = New System.Drawing.Point(326, 262)
        Me.Back_BTN.Name = "Back_BTN"
        Me.Back_BTN.Size = New System.Drawing.Size(75, 23)
        Me.Back_BTN.TabIndex = 17
        Me.Back_BTN.Text = "Back"
        Me.Back_BTN.UseVisualStyleBackColor = True
        '
        'Save_BTN
        '
        Me.Save_BTN.Location = New System.Drawing.Point(245, 262)
        Me.Save_BTN.Name = "Save_BTN"
        Me.Save_BTN.Size = New System.Drawing.Size(75, 23)
        Me.Save_BTN.TabIndex = 18
        Me.Save_BTN.Text = "Save"
        Me.Save_BTN.UseVisualStyleBackColor = True
        '
        'XMLFile_BOX
        '
        Me.XMLFile_BOX.Location = New System.Drawing.Point(12, 12)
        Me.XMLFile_BOX.Name = "XMLFile_BOX"
        Me.XMLFile_BOX.ReadOnly = True
        Me.XMLFile_BOX.Size = New System.Drawing.Size(308, 20)
        Me.XMLFile_BOX.TabIndex = 19
        '
        'Change_BTN
        '
        Me.Change_BTN.Location = New System.Drawing.Point(326, 10)
        Me.Change_BTN.Name = "Change_BTN"
        Me.Change_BTN.Size = New System.Drawing.Size(75, 23)
        Me.Change_BTN.TabIndex = 20
        Me.Change_BTN.Text = "Change"
        Me.Change_BTN.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 297)
        Me.Controls.Add(Me.Change_BTN)
        Me.Controls.Add(Me.XMLFile_BOX)
        Me.Controls.Add(Me.Save_BTN)
        Me.Controls.Add(Me.Back_BTN)
        Me.Controls.Add(Me.Settings_GRID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Settings"
        Me.ShowIcon = False
        Me.Text = "Settings"
        CType(Me.Settings_GRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Settings_GRID As DataGridView
    Friend WithEvents Back_BTN As Button
    Friend WithEvents Save_BTN As Button
    Friend WithEvents XMLFile_BOX As TextBox
    Friend WithEvents Change_BTN As Button
End Class
