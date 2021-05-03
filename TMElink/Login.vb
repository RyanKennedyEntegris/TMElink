Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Public Class Login
    Public LoginData As DataSet
    Public Login_Dataset As New DataSet("Users")
    Public elemList As XmlNodeList
    Public UsersCount As Integer
    'The username and password below are used to secure data files so that they can't be edited by operators.
    'This account must have admin rights on the computer or the program will not function correctly.
    Public AdminUserName As String = "Admin Name"
    Public Adminpassword As String = "Admin Password"
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles Me.Load
        AdminOpen()
    End Sub
    Sub AdminOpen()
        'This opens TMElink under the admin user. This is essential to be able to write files into the protected folder.
        Try
            If System.Environment.UserName <> AdminUserName Then
                Dim path As String = Environment.CurrentDirectory
                Dim filename As String = Application.ExecutablePath
                Dim passwordchars As Char() = Adminpassword.ToCharArray()
                Dim password As New Security.SecureString
                For Each c As Char In passwordchars
                    password.AppendChar(c)
                Next
                Dim procinfo As New System.Diagnostics.Process
                procinfo.StartInfo.FileName = filename
                procinfo.StartInfo.UserName = AdminUserName
                procinfo.StartInfo.Domain = "entegris"
                procinfo.StartInfo.Password = password
                procinfo.StartInfo.UseShellExecute = False
                procinfo.StartInfo.CreateNoWindow = True
                procinfo.StartInfo.WorkingDirectory = path
                procinfo.Start()
                Application.Exit()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "run failed")
            Application.Exit()
        End Try
    End Sub
    Sub LoadUserLoginData()
        Dim LoginDataFile As XmlDocument = New XmlDocument()
        If CheckUserFile() = False Then
            Exit Sub
        End If
        LoginDataFile.Load(My.Settings.UserFile)
        Dim root As XmlElement = LoginDataFile.DocumentElement
        elemList = root.GetElementsByTagName("ID")
        LoginData = Login_Dataset
        Dim xmlSerializer As XmlSerializer = New XmlSerializer(LoginData.GetType)
        Dim readStream As FileStream = New FileStream(My.Settings.UserFile, FileMode.Open)
        LoginData = CType(xmlSerializer.Deserialize(readStream), DataSet)
        readStream.Close()
    End Sub
    Private Sub NewUser_BTN_Click(sender As Object, e As EventArgs) Handles NewUser_BTN.Click
        LoadUserLoginData()
        UsersCount = elemList.Count
        Dim NewUserForm As New NewUser With {
            .Visible = True
        }
    End Sub

    Sub SignIn_BTN_Click(sender As Object, e As EventArgs) Handles SignIn_BTN.Click
        Login()
    End Sub
    Sub Login()
        If CheckUserFile() = False Then
            Exit Sub
        End If
        LoadUserLoginData()
        Dim HashedPassword As PasswordHash
        HashedPassword = New PasswordHash()
        If UserName_BOX.Text = "" Then
            MsgBox("Enter user name")
            Exit Sub
        End If
        If PW_BOX.Text = "" Then
            MsgBox("Enter password")
            Exit Sub
        End If
        For i = 0 To elemList.Count - 1
            If UserName_BOX.Text.ToUpper = LoginData.Tables(0).Rows(i).Item(1) Then
                If HashedPassword.Md5FromString(PW_BOX.Text) = LoginData.Tables(0).Rows(i).Item(2) Then
                    Main.Show()
                    Me.Hide()
                    PW_BOX.Text = ""
                    Exit Sub
                Else
                    MsgBox("Incorrect password")
                    PW_BOX.Text = ""
                    Exit Sub
                End If
            End If
        Next
        MsgBox("User name does not exist")
    End Sub
    Function CheckUserFile()
        If System.IO.File.Exists(My.Settings.UserFile) = True Then
            Return True
        Else
            MsgBox("User login file not found")
            Dim fd As OpenFileDialog = New OpenFileDialog With {
            .Title = "Select XML User File",
            .InitialDirectory = "C:\",
            .Filter = "XML User File|*.xml",
            .RestoreDirectory = True
        }
            If fd.ShowDialog() = DialogResult.OK Then
                My.Settings.UserFile = fd.FileName
                My.Settings.Save()
                Return True
            Else
                Return False
            End If
        End If
    End Function
    Private Sub PW_BOX_KeyUp(sender As Object, e As KeyEventArgs) Handles PW_BOX.KeyDown
        If e.KeyCode = Keys.Enter Then
            Login()
        End If
    End Sub
End Class