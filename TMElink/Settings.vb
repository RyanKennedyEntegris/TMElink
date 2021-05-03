Imports System.Xml.Serialization
Imports System.IO

Class Settings
    Public Settings_Dataset As New DataSet("Options")
    Dim Settings_Table As New DataTable("Option")
    Sub Settings_Load(sender As Object, e As EventArgs) Handles Me.Load
        'DS = Settings_Table.DataSet
        LoadFromXMLfile(My.Settings.XMLFile)
        Settings_GRID.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Settings_GRID.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        XMLFile_BOX.Text = My.Settings.XMLFile
    End Sub
    Sub LoadFromXMLfile(filename As String)
        If System.IO.File.Exists(filename) Then

            Dim xmlSerializer As XmlSerializer = New XmlSerializer(DS.GetType)
            Dim readStream As FileStream = New FileStream(filename, FileMode.Open)
            DS = CType(xmlSerializer.Deserialize(readStream), DataSet)
            readStream.Close()
            Settings_GRID.DataSource = DS.Tables("Option")
        Else
            MsgBox("file not found!", MsgBoxStyle.Exclamation, "")
        End If
    End Sub
    Private Sub SaveToXMLFile(filename As String, d As DataSet)
        Dim ser As XmlSerializer = New XmlSerializer(GetType(DataSet))
        Dim writer As TextWriter = New StreamWriter(filename)
        ser.Serialize(writer, d)
        writer.Close()
    End Sub
#Region "Buttons"
    'Buttons on bottom of form
    Private Sub Save_BTN_Click(sender As Object, e As EventArgs) Handles Save_BTN.Click
        If Settings_GRID.Rows(7).Cells(2).Value <> "LEAK" And Settings_GRID.Rows(7).Cells(2).Value <> "BURST" Then
            MsgBox("Test Type must be exactly 'LEAK' or 'BURST'")
            Exit Sub
        End If
        SaveToXMLFile(My.Settings.XMLFile, DS)
        MsgBox("Settings saved")
    End Sub
    Private Sub Back_BTN_Click(sender As Object, e As EventArgs) Handles Back_BTN.Click
        Main.LoadSettings()
        Main.Gauge_TXT.Text = Main.GaugeName
        DS.Dispose()
        Me.Close()
    End Sub

    Private Sub Change_BTN_Click(sender As Object, e As EventArgs) Handles Change_BTN.Click
        Dim fd As OpenFileDialog = New OpenFileDialog With {
            .Title = "Select XML Settings File",
            .InitialDirectory = "C:\",
            .Filter = "XML Settings File|*.xml",
            .RestoreDirectory = True
        }
        If fd.ShowDialog() = DialogResult.OK Then
            My.Settings.XMLFile = fd.FileName
            My.Settings.Save()
            LoadFromXMLfile(My.Settings.XMLFile)
            XMLFile_BOX.Text = My.Settings.XMLFile
        End If
    End Sub
#End Region
End Class

