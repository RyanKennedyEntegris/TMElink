<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewUser
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
        Me.Back_BTN = New System.Windows.Forms.Button()
        Me.CreateUser_BTN = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PW2_BOX = New System.Windows.Forms.TextBox()
        Me.PW_BOX = New System.Windows.Forms.TextBox()
        Me.UserName_BOX = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Back_BTN
        '
        Me.Back_BTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Back_BTN.Location = New System.Drawing.Point(18, 138)
        Me.Back_BTN.Name = "Back_BTN"
        Me.Back_BTN.Size = New System.Drawing.Size(100, 38)
        Me.Back_BTN.TabIndex = 15
        Me.Back_BTN.Text = "Back"
        Me.Back_BTN.UseVisualStyleBackColor = True
        '
        'CreateUser_BTN
        '
        Me.CreateUser_BTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreateUser_BTN.Location = New System.Drawing.Point(274, 138)
        Me.CreateUser_BTN.Name = "CreateUser_BTN"
        Me.CreateUser_BTN.Size = New System.Drawing.Size(268, 38)
        Me.CreateUser_BTN.TabIndex = 14
        Me.CreateUser_BTN.Text = "Create User"
        Me.CreateUser_BTN.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(256, 32)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Re-enter Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(129, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 32)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(49, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(219, 32)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "New User Name"
        '
        'PW2_BOX
        '
        Me.PW2_BOX.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PW2_BOX.Location = New System.Drawing.Point(274, 94)
        Me.PW2_BOX.Name = "PW2_BOX"
        Me.PW2_BOX.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PW2_BOX.Size = New System.Drawing.Size(268, 38)
        Me.PW2_BOX.TabIndex = 10
        Me.PW2_BOX.UseSystemPasswordChar = True
        '
        'PW_BOX
        '
        Me.PW_BOX.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PW_BOX.Location = New System.Drawing.Point(274, 50)
        Me.PW_BOX.Name = "PW_BOX"
        Me.PW_BOX.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PW_BOX.Size = New System.Drawing.Size(268, 38)
        Me.PW_BOX.TabIndex = 9
        Me.PW_BOX.UseSystemPasswordChar = True
        '
        'UserName_BOX
        '
        Me.UserName_BOX.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserName_BOX.Location = New System.Drawing.Point(274, 6)
        Me.UserName_BOX.Name = "UserName_BOX"
        Me.UserName_BOX.Size = New System.Drawing.Size(268, 38)
        Me.UserName_BOX.TabIndex = 8
        '
        'NewUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 187)
        Me.Controls.Add(Me.PW2_BOX)
        Me.Controls.Add(Me.PW_BOX)
        Me.Controls.Add(Me.UserName_BOX)
        Me.Controls.Add(Me.Back_BTN)
        Me.Controls.Add(Me.CreateUser_BTN)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "NewUser"
        Me.ShowIcon = False
        Me.Text = "Add New User"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Back_BTN As Button
    Friend WithEvents CreateUser_BTN As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PW2_BOX As TextBox
    Friend WithEvents PW_BOX As TextBox
    Friend WithEvents UserName_BOX As TextBox
End Class
