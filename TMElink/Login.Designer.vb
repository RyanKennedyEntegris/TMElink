<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.SignIn_BTN = New System.Windows.Forms.Button()
        Me.NewUser_BTN = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PW_BOX = New System.Windows.Forms.TextBox()
        Me.UserName_BOX = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'SignIn_BTN
        '
        Me.SignIn_BTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SignIn_BTN.Location = New System.Drawing.Point(174, 94)
        Me.SignIn_BTN.Name = "SignIn_BTN"
        Me.SignIn_BTN.Size = New System.Drawing.Size(203, 50)
        Me.SignIn_BTN.TabIndex = 3
        Me.SignIn_BTN.Text = "Sign In"
        Me.SignIn_BTN.UseVisualStyleBackColor = True
        '
        'NewUser_BTN
        '
        Me.NewUser_BTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewUser_BTN.Location = New System.Drawing.Point(18, 94)
        Me.NewUser_BTN.Name = "NewUser_BTN"
        Me.NewUser_BTN.Size = New System.Drawing.Size(150, 50)
        Me.NewUser_BTN.TabIndex = 4
        Me.NewUser_BTN.Text = "New User"
        Me.NewUser_BTN.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 32)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 32)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "User Name"
        '
        'PW_BOX
        '
        Me.PW_BOX.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PW_BOX.Location = New System.Drawing.Point(174, 50)
        Me.PW_BOX.Name = "PW_BOX"
        Me.PW_BOX.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PW_BOX.Size = New System.Drawing.Size(203, 38)
        Me.PW_BOX.TabIndex = 2
        Me.PW_BOX.UseSystemPasswordChar = True
        '
        'UserName_BOX
        '
        Me.UserName_BOX.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserName_BOX.Location = New System.Drawing.Point(174, 6)
        Me.UserName_BOX.Name = "UserName_BOX"
        Me.UserName_BOX.Size = New System.Drawing.Size(203, 38)
        Me.UserName_BOX.TabIndex = 1
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(389, 157)
        Me.Controls.Add(Me.PW_BOX)
        Me.Controls.Add(Me.UserName_BOX)
        Me.Controls.Add(Me.SignIn_BTN)
        Me.Controls.Add(Me.NewUser_BTN)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(407, 204)
        Me.MinimumSize = New System.Drawing.Size(407, 204)
        Me.Name = "Login"
        Me.Text = "TMELink Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SignIn_BTN As Button
    Friend WithEvents NewUser_BTN As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PW_BOX As TextBox
    Friend WithEvents UserName_BOX As TextBox
End Class
