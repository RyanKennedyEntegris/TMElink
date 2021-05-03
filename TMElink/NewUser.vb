Imports System.Text
Imports System.Security.Cryptography
Imports System.Xml.Serialization
Imports System.IO
Public Class NewUser
    Private Sub Back_BTN_Click(sender As Object, e As EventArgs) Handles Back_BTN.Click
        Me.Close()
        Dim login As New Login
    End Sub
    Private Sub CreateUser_BTN_Click(sender As Object, e As EventArgs) Handles CreateUser_BTN.Click
        Dim HashedPassword As PasswordHash
        HashedPassword = New PasswordHash()
        For i = 0 To Login.UsersCount - 1
            If UserName_BOX.Text.ToUpper = Login.LoginData.Tables(0).Rows(i).Item(1) Then
                MsgBox("User name already exists")
                Exit Sub
            End If
        Next
        If PW_BOX.Text.Length > 2 Then
            If HashedPassword.Md5FromString(PW_BOX.Text) = HashedPassword.Md5FromString(PW2_BOX.Text) Then
                MsgBox("User " & UserName_BOX.Text & " created")
                Login.LoginData.Tables(0).Rows.Add(Login.elemList.Count, UserName_BOX.Text.ToUpper, HashedPassword.Md5FromString(PW_BOX.Text))
                Dim ser As XmlSerializer = New XmlSerializer(GetType(DataSet))
                Dim writer As TextWriter = New StreamWriter(My.Settings.UserFile)
                ser.Serialize(writer, Login.LoginData)
                writer.Close()
                Login.UsersCount = Login.UsersCount + 1
                Me.Close()
            Else
                MsgBox("Passwords must match")
            End If
        Else
            MsgBox("Password must be at least 3 characters")
        End If
    End Sub
End Class
Public Class PasswordHash
    Public Function Md5FromString(ByVal Source As String) As String
        Dim Bytes() As Byte
        Dim sb As New StringBuilder()

        'Check for empty string.
        If String.IsNullOrEmpty(Source) Then
            Throw New ArgumentNullException
        End If

        'Get bytes from string.
        Bytes = Encoding.Default.GetBytes(Source)

        'Get md5 hash
        Bytes = MD5.Create().ComputeHash(Bytes)

        'Loop though the byte array and convert each byte to hex.
        For x As Integer = 0 To Bytes.Length - 1
            sb.Append(Bytes(x).ToString("x2"))
        Next

        'Return md5 hash.
        Return sb.ToString()

    End Function

End Class
