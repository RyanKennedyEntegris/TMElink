'Written by Ryan Kennedy. Initial version in January 2021. 
'Intended for use in Entegris Life Sciences for operating TME leak and burst testers and formatting data to be uploaded to camLine.

Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.IO
Imports System.Xml.Serialization
Imports System.ComponentModel
Imports System.Security

Module GlobalVariables
    Public DS As DataSet
    Public Settings_Dataset As New DataSet("Options")
    Public Settings_Table As New DataTable("Option")
End Module
Public Class Main
    Dim remoteIPAddress As IPAddress
    Dim ep As IPEndPoint
    Dim tnSocket As Socket
    Dim RecString As String = String.Empty
    Dim HandledRecString As String
    Dim SendBytes As [Byte]() = Encoding.ASCII.GetBytes(Command() & vbCrLf)
    Dim Reconnects As Integer
    Dim Barcode As String
    Dim KeyOutput As String
    Public IPSetting, FolderSetting, GaugeSetting, GaugeName, LogoutTimeSetting, PasswordSetting, FTPClientFolder, TestType As String
    Dim LogoutTime As Integer = 0
    Dim RecResult, RecLeakDelta, RecProgram, RecTestType As String
    Dim Comment As String
    Dim PrevSeq As String
    Dim PrevBC As String
    Dim XMLFile As String
#Region "Startup"
    Sub Startup(sender As Object, e As EventArgs) Handles Me.Load
        Me.Show()
        LoadXML()
        LoadSettings()
        LoadFTPClient()
        Status_TXT.Text = "Ready"
        Leak_TXT.Text = ""
        Gauge_TXT.Text = GaugeName
        Op_BOX.Text = Login.UserName_BOX.Text.ToUpper
        Logout_TMR.Start()
    End Sub
    Sub LoadXML()
        'The XML file contains settings for this program.
        If My.Settings.XMLFile = "nofile" Then
            MsgBox("XML settings file must be selected before using program.")
            Dim fd As OpenFileDialog = New OpenFileDialog With {
                .Title = "Select XML Settings File",
                .InitialDirectory = "C:\",
                .Filter = "XML Settings File|*.xml",
                .RestoreDirectory = True}
            If fd.ShowDialog() = DialogResult.OK Then
                XMLFile = fd.FileName
                My.Settings.XMLFile = XMLFile
                My.Settings.Save()
            End If
        End If
        DS = Settings.Settings_Dataset
LoadFile:
        Try
            If System.IO.File.Exists(My.Settings.XMLFile) Then
                Dim xmlSerializer As XmlSerializer = New XmlSerializer(DS.GetType)
                Dim readStream As FileStream = New FileStream(My.Settings.XMLFile, FileMode.Open)
                DS = CType(xmlSerializer.Deserialize(readStream), DataSet)
                readStream.Close()
            Else
                MsgBox("XML Settings file not found! Settings file must be selected before using program.", MsgBoxStyle.Exclamation, "ERROR")
                Dim fd As OpenFileDialog = New OpenFileDialog With {
                   .Title = "Select XML Settings File",
                   .InitialDirectory = "C:\",
                   .Filter = "XML Settings File|*.xml",
                   .RestoreDirectory = True}

                If fd.ShowDialog() = DialogResult.OK Then
                    XMLFile = fd.FileName
                    My.Settings.XMLFile = XMLFile
                    My.Settings.Save()
                    GoTo LoadFile

                End If
            End If
        Catch
            MsgBox("Error loading XML file. Select valid XML Settings file.")
            Dim fd As OpenFileDialog = New OpenFileDialog With {
                  .Title = "Select XML Settings File",
                  .InitialDirectory = "C:\",
                  .Filter = "XML Settings File|*.xml",
                  .RestoreDirectory = True}
            If fd.ShowDialog() = DialogResult.OK Then
                XMLFile = fd.FileName
                My.Settings.XMLFile = XMLFile
                My.Settings.Save()
                GoTo LoadFile
            Else
                MsgBox("Program will not function without valid XML settings file.")
            End If
        End Try
    End Sub
    Sub LoadSettings()
        'Get settings from table and puts them into variables
        Try
            IPSetting = DS.Tables(0).Rows(0).Item(2).ToString
            FolderSetting = DS.Tables(0).Rows(1).Item(2).ToString
            If FolderSetting.Last <> "\" Then
                FolderSetting = FolderSetting & "\"
            End If
            FTPClientFolder = DS.Tables(0).Rows(2).Item(2).ToString
            If FTPClientFolder.Last <> "\" Then
                FTPClientFolder = FTPClientFolder & "\"
            End If
            GaugeSetting = DS.Tables(0).Rows(3).Item(2).ToString
            GaugeName = DS.Tables(0).Rows(4).Item(2).ToString
            LogoutTimeSetting = DS.Tables(0).Rows(5).Item(2).ToString
            PasswordSetting = DS.Tables(0).Rows(6).Item(2).ToString
            TestType = DS.Tables(0).Rows(7).Item(2).ToString
        Catch
            MsgBox("Error with XML file. Program closing.")
            End
        End Try

    End Sub
    Sub LoadFTPClient()
        'Launches FTP client with admin rights if it isn't already running
        If Process.GetProcessesByName("JavaW").Count > 0 Then
            'FTP Client is already running
        Else
            Dim myProcessStartInfo As ProcessStartInfo = New ProcessStartInfo
            With myProcessStartInfo
                .FileName = FTPClientFolder & "FTP Client.bat"
                .WorkingDirectory = FTPClientFolder
                .Domain = "Entegris"
                .UserName = Login.AdminUserName
                .UseShellExecute = False
                Using NewPassword As New SecureString
                    With NewPassword
                        For Each c As Char In Login.Adminpassword.ToCharArray
                            .AppendChar(c)
                        Next c
                        .MakeReadOnly()
                    End With
                    .Password = NewPassword.Copy
                End Using
            End With
            Using Process As New System.Diagnostics.Process
                With Process
                    .StartInfo = myProcessStartInfo
                    .Start()
                End With
            End Using
        End If
    End Sub
#End Region
#Region "TME Communication"
    Function Connect(ByVal PIPAddress As String, ByVal PPort As String)
        'Get the IP Address and the Port and create an IPEndpoint (ep)
        remoteIPAddress = IPAddress.Parse(PIPAddress.Trim)
        ep = New IPEndPoint(remoteIPAddress, CType(PPort.Trim, Integer))

        'Set the socket up (type etc)
        tnSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        My.Application.DoEvents()
        Threading.Thread.Sleep(10)
        Try
            'Connect to TME unit
            tnSocket.Connect(ep)
        Catch oEX As SocketException
            tnSocket.Close()
            MsgBox("Failed to connect to leak tester. Check cable and IP settings.")
            Status_TXT.Text = "Connection Failed"
            Return False
        End Try

        Listen_TMR.Start()
        Return True

    End Function
    Sub Send(command As String)
        SendBytes = System.Text.Encoding.ASCII.GetBytes(command & vbCr)
        Try
            If tnSocket.Connected Then
                tnSocket.Send(SendBytes, SendBytes.Length, SocketFlags.None)
                Wait(20)
            Else
                MsgBox("Failed to send to TME tester.")
            End If
        Catch oEX As Exception
            MsgBox("Error when trying to send to TME tester.")
        End Try
    End Sub
    Private Sub Listen_TMR_Tick(sender As Object, e As EventArgs) Handles Listen_TMR.Tick
        RecString = ""
        Dim RecvBytes(255) As [Byte]
        Dim NumBytes As Integer
        Dim SingleChar As Char
        Dim DataString As String = ""
        If tnSocket.Connected Then

            'Check if data is available
            If tnSocket.Available > 0 Then
                Wait(100)
                'Read data from leak tester
                NumBytes = tnSocket.Receive(RecvBytes, RecvBytes.Length, 0)
                RecString = RecString + Encoding.ASCII.GetString(RecvBytes, 0, NumBytes)
                'Checks if repeat message
                If RecString <> HandledRecString Then
                    'Gets useful information from message
                    For i = 0 To NumBytes - 1
                        SingleChar = RecString.Chars(i)
                        If Char.IsLetterOrDigit(SingleChar) Then
                            DataString = DataString & SingleChar
                        ElseIf SingleChar = " " Then
                            DataString = DataString & SingleChar
                        ElseIf SingleChar = "." Then
                            DataString = DataString & SingleChar
                        ElseIf SingleChar = ":" Then
                            DataString = DataString & SingleChar
                        ElseIf SingleChar = "-" Then
                            DataString = DataString & SingleChar
                        ElseIf SingleChar = "," Then
                            DataString = DataString & SingleChar
                        End If
                    Next

                    Try
                        Dim CellValueArray() As String = DataString.Split(","c)
                        If CellValueArray(0) = "Leak" Or CellValueArray(0) = "Burst" Then
                            ParseReceived(DataString)
                            Comment = ""
                            WriteCSV()
                            Status_TXT.Text = CellValueArray(8)
                            If TestType = "LEAK" Then
                                Leak_TXT.Text = "Leak Rate = " & CellValueArray(1)
                            Else
                                Leak_TXT.Text = "Burst Pressure = " & CellValueArray(1)
                            End If

                            Start_BTN.Text = "Start Test"
                                tnSocket.Close()
                                Barcode_BOX.Enabled = True
                                Seq_BOX.Enabled = True
                                Comment_BOX.Enabled = True
                                Comment_BOX.Text = ""
                                If CellValueArray(8) = "ACCEPT" Then
                                    Seq_BOX.Text = Convert.ToInt16(Seq_BOX.Text) + 1
                                End If
                            End If
                    Catch
                        Debug.Print("Was not able to find a pass or fail value")
                    End Try
                End If
            End If
            HandledRecString = RecString
        End If
    End Sub
    Sub ParseReceived(ReceivedString As String)
        Try
            RecLeakDelta = "null"
            RecProgram = "null"
            RecResult = "null"
            Dim ParsedData() As String = ReceivedString.Split(","c)
            RecTestType = ParsedData(0)
            RecLeakDelta = ParsedData(1)
            RecProgram = ParsedData(4)
            RecResult = ParsedData(8)
        Catch ex As Exception
            MsgBox("Failed to parse. " & ex.Message)
        End Try

    End Sub
    Private Sub Wait(ByVal PMillseconds As Integer)
        ' Waits a set amount of time while still allowing other functions to run
        Dim TimeNow As DateTime
        Dim TimeEnd As DateTime
        Dim StopFlag As Boolean
        TimeEnd = Now()
        TimeEnd = TimeEnd.AddMilliseconds(PMillseconds)
        StopFlag = False
        While Not StopFlag
            TimeNow = Now()
            If TimeNow > TimeEnd Then
                StopFlag = True
            End If
            Application.DoEvents()
        End While
        TimeNow = Nothing
        TimeEnd = Nothing
    End Sub
#End Region
#Region "Buttons"
    Private Sub Info_BTN_Click(sender As Object, e As EventArgs) Handles Info_BTN.Click
        MsgBox("Leak tester IP must be " & IPSetting & ". Files are written to " & FolderSetting)
    End Sub
    Private Sub LogOut_BTN_Click(sender As Object, e As EventArgs) Handles LogOut_BTN.Click
        Me.Close()
    End Sub
    Private Sub Settings_BTN_Click(sender As Object, e As EventArgs) Handles Settings_BTN.Click
        Dim Password As String
        Password = InputBox("Enter Password")
        If Password = PasswordSetting Then
            Settings.Show()
        Else
            MsgBox("Password Incorrect")
        End If
    End Sub
    Private Sub Start_BTN_Click(sender As Object, e As EventArgs) Handles Start_BTN.Click
        LoadSettings()
        Logout_TMR.Start()
        LogoutTime = 0
        If Start_BTN.Text = "Start Test" Then
            If ValidateInfo() = True Then
                Status_TXT.Text = "Connecting"
                If Connect(IPSetting, "23") = True Then
                    If TestType = "LEAK" Then
                        Send("start testLeak")
                    ElseIf TestType = "BURST" Then
                        Send("start testBurst")
                    End If
                    Status_TXT.Text = "Testing"
                    Start_BTN.Text = "Stop Test"
                    Barcode_BOX.Enabled = False
                    Seq_BOX.Enabled = False
                    Comment_BOX.Enabled = False
                End If
            Else
                Debug.Print("No test")
            End If
        Else
            If TestType = "LEAK" Then
                Send("stop testLeak")
            ElseIf TestType = "BURST" Then
                Send("stop testBurst")
            End If

            Start_BTN.Text = "Start Test"
            Status_TXT.Text = "Test Stopped"
            Barcode_BOX.Enabled = True
            Seq_BOX.Enabled = True
            tnSocket.Close()
        End If

    End Sub
#End Region

    Private Sub WriteCSV()
        Dim FileName As String = FolderSetting & GaugeSetting & " Leak Data " & Date.Now.ToString("yyyyMMdd_HHmmss") & ".csv"
        'Creates CSV file that will be uploaded to camLine parser.
        Try
            File.Create(FileName).Dispose()
            Dim lines(13) As String
            lines(0) = "DATE_FORMAT,MM/dd/yyyy HH:mm:ss"
            lines(1) = "DATE," & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)
            lines(2) = "MES,Barcode," & Barcode.ToUpper
            lines(3) = "MES,WipServer,blm-cln03"
            If RecTestType = "Leak" Then
                lines(4) = "EX04,ARAMUS LEAK TEST"
            ElseIf RecTestType = "Burst" Then
                lines(4) = "EX04,ARAMUS BURST TEST"
            End If
            lines(5) = "DA01," & Op_BOX.Text
            lines(6) = "DA03," & GaugeSetting
            lines(7) = "DA07," & RecResult
            lines(8) = "DA08," & RecProgram
            If Comment_BOX.Text = "" Then
                lines(9) = "DA09,-"
            Else
                lines(9) = "DA09," & Comment_BOX.Text
            End If
            If RecTestType = "Leak" Then
                lines(10) = "PARAMETER_NAME,Decay"
            ElseIf RecTestType = "Burst" Then
                lines(10) = "PARAMETER_NAME,Pressure"
            End If
            lines(11) = "PARAMETER_UNIT,PSI"
            lines(12) = "SAMPLE"
            lines(13) = "RAW," & RecLeakDelta
            File.WriteAllLines(FileName, lines)
        Catch
            Debug.Print("Failed to create csv")
        End Try
    End Sub
    Private Sub Logout_TMR_Tick(sender As Object, e As EventArgs) Handles Logout_TMR.Tick
        If LogoutTime = LogoutTimeSetting Then
            Me.Close()
        Else
            LogoutTime = LogoutTime + 1
        End If
    End Sub
    Function ValidateInfo()
        'Checks for correct entry of product information prior to testing.
        If Barcode_BOX.Text.Length <> 19 Then
            MsgBox("Barcode length is not correct.")
            Return False
        End If
        If Seq_BOX.Text = "" Or IsNumeric(Seq_BOX.Text) = False Then
            MsgBox("Sequence box must contain a number.")
            Return False
        End If
        If Seq_BOX.Text <> Convert.ToInt16(PrevSeq) + 1 And Barcode_BOX.Text = PrevBC And Status_TXT.Text = "ACCEPT" Then
            If MsgBox("Sequence is not one higher than previous test. Continue test?", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
                Return False
            End If
        End If
        If Seq_BOX.Text.Length > 4 Then
            MsgBox("Sequence must be four digits or fewer.")
            Return False
        End If
        'Insert sequence into barcode
        Barcode = Barcode_BOX.Text.Substring(0, 15) & Seq_BOX.Text.PadLeft(4, "0")
        PrevBC = Barcode_BOX.Text
        PrevSeq = Seq_BOX.Text
        Return True
    End Function

    Private Sub Main_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Login.Visible = True
    End Sub
End Class


