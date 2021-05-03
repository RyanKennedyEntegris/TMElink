<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Op_BOX = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Seq_BOX = New System.Windows.Forms.TextBox()
        Me.Barcode_BOX = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Info_BTN = New System.Windows.Forms.Button()
        Me.Listen_TMR = New System.Windows.Forms.Timer(Me.components)
        Me.Settings_BTN = New System.Windows.Forms.Button()
        Me.Start_BTN = New System.Windows.Forms.Button()
        Me.Logout_TMR = New System.Windows.Forms.Timer(Me.components)
        Me.Status_TXT = New System.Windows.Forms.Label()
        Me.Leak_TXT = New System.Windows.Forms.Label()
        Me.Gauge_TXT = New System.Windows.Forms.Label()
        Me.Comment_BOX = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LogOut_BTN = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Operator"
        '
        'Op_BOX
        '
        Me.Op_BOX.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Op_BOX.Location = New System.Drawing.Point(13, 160)
        Me.Op_BOX.Name = "Op_BOX"
        Me.Op_BOX.ReadOnly = True
        Me.Op_BOX.Size = New System.Drawing.Size(221, 31)
        Me.Op_BOX.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Bag #"
        '
        'Seq_BOX
        '
        Me.Seq_BOX.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Seq_BOX.Location = New System.Drawing.Point(13, 109)
        Me.Seq_BOX.MaxLength = 4
        Me.Seq_BOX.Name = "Seq_BOX"
        Me.Seq_BOX.Size = New System.Drawing.Size(75, 31)
        Me.Seq_BOX.TabIndex = 2
        '
        'Barcode_BOX
        '
        Me.Barcode_BOX.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Barcode_BOX.Location = New System.Drawing.Point(13, 60)
        Me.Barcode_BOX.Name = "Barcode_BOX"
        Me.Barcode_BOX.Size = New System.Drawing.Size(430, 31)
        Me.Barcode_BOX.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Barcode"
        '
        'Info_BTN
        '
        Me.Info_BTN.Location = New System.Drawing.Point(12, 247)
        Me.Info_BTN.Name = "Info_BTN"
        Me.Info_BTN.Size = New System.Drawing.Size(60, 23)
        Me.Info_BTN.TabIndex = 4
        Me.Info_BTN.Text = "Info"
        Me.Info_BTN.UseVisualStyleBackColor = True
        '
        'Listen_TMR
        '
        Me.Listen_TMR.Interval = 1000
        '
        'Settings_BTN
        '
        Me.Settings_BTN.Location = New System.Drawing.Point(78, 247)
        Me.Settings_BTN.Name = "Settings_BTN"
        Me.Settings_BTN.Size = New System.Drawing.Size(75, 23)
        Me.Settings_BTN.TabIndex = 5
        Me.Settings_BTN.Text = "Settings"
        Me.Settings_BTN.UseVisualStyleBackColor = True
        '
        'Start_BTN
        '
        Me.Start_BTN.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Start_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Start_BTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Start_BTN.Location = New System.Drawing.Point(293, 210)
        Me.Start_BTN.Name = "Start_BTN"
        Me.Start_BTN.Size = New System.Drawing.Size(149, 60)
        Me.Start_BTN.TabIndex = 6
        Me.Start_BTN.Text = "Start Test"
        Me.Start_BTN.UseVisualStyleBackColor = False
        '
        'Logout_TMR
        '
        Me.Logout_TMR.Interval = 60000
        '
        'Status_TXT
        '
        Me.Status_TXT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Status_TXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status_TXT.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Status_TXT.Location = New System.Drawing.Point(152, 156)
        Me.Status_TXT.MaximumSize = New System.Drawing.Size(300, 37)
        Me.Status_TXT.Name = "Status_TXT"
        Me.Status_TXT.Size = New System.Drawing.Size(291, 32)
        Me.Status_TXT.TabIndex = 32
        Me.Status_TXT.Text = "Ready"
        Me.Status_TXT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Leak_TXT
        '
        Me.Leak_TXT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Leak_TXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Leak_TXT.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Leak_TXT.Location = New System.Drawing.Point(152, 109)
        Me.Leak_TXT.MaximumSize = New System.Drawing.Size(300, 37)
        Me.Leak_TXT.Name = "Leak_TXT"
        Me.Leak_TXT.Size = New System.Drawing.Size(291, 33)
        Me.Leak_TXT.TabIndex = 33
        Me.Leak_TXT.Text = "Leak Rate"
        Me.Leak_TXT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Gauge_TXT
        '
        Me.Gauge_TXT.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Gauge_TXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gauge_TXT.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Gauge_TXT.Location = New System.Drawing.Point(82, 9)
        Me.Gauge_TXT.MaximumSize = New System.Drawing.Size(300, 37)
        Me.Gauge_TXT.Name = "Gauge_TXT"
        Me.Gauge_TXT.Size = New System.Drawing.Size(300, 37)
        Me.Gauge_TXT.TabIndex = 34
        Me.Gauge_TXT.Text = "Gauge"
        Me.Gauge_TXT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Comment_BOX
        '
        Me.Comment_BOX.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Comment_BOX.Location = New System.Drawing.Point(12, 210)
        Me.Comment_BOX.Name = "Comment_BOX"
        Me.Comment_BOX.Size = New System.Drawing.Size(222, 31)
        Me.Comment_BOX.TabIndex = 35
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 193)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Comment"
        '
        'LogOut_BTN
        '
        Me.LogOut_BTN.Location = New System.Drawing.Point(159, 247)
        Me.LogOut_BTN.Name = "LogOut_BTN"
        Me.LogOut_BTN.Size = New System.Drawing.Size(75, 23)
        Me.LogOut_BTN.TabIndex = 37
        Me.LogOut_BTN.Text = "Log Out"
        Me.LogOut_BTN.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 283)
        Me.Controls.Add(Me.LogOut_BTN)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Comment_BOX)
        Me.Controls.Add(Me.Op_BOX)
        Me.Controls.Add(Me.Gauge_TXT)
        Me.Controls.Add(Me.Leak_TXT)
        Me.Controls.Add(Me.Status_TXT)
        Me.Controls.Add(Me.Start_BTN)
        Me.Controls.Add(Me.Settings_BTN)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Seq_BOX)
        Me.Controls.Add(Me.Barcode_BOX)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Info_BTN)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.Text = "TMElink"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Op_BOX As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Seq_BOX As TextBox
    Friend WithEvents Barcode_BOX As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Info_BTN As Button
    Friend WithEvents Listen_TMR As Timer
    Friend WithEvents Settings_BTN As Button
    Friend WithEvents Start_BTN As Button
    Friend WithEvents Logout_TMR As Timer
    Friend WithEvents Status_TXT As Label
    Friend WithEvents Leak_TXT As Label
    Friend WithEvents Gauge_TXT As Label
    Friend WithEvents Comment_BOX As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents LogOut_BTN As Button
End Class
