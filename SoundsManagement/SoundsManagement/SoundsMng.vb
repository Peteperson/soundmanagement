Imports FileHelpers

Public Class SoundsMng
    Private _FilesPath As String = ""
    Public ReadOnly Property FilesPath(Optional ByVal RetrieveFromDB As Boolean = True) As String
        Get
            If _FilesPath = "" Then
                Dim pt As New SoundsDataSetTableAdapters.ParametersTableAdapter
                If RetrieveFromDB Then
                    Dim dt As SoundsDataSet.ParametersDataTable
                    dt = pt.GetData("SoundsLibraryPath")
                    If Not dt.First.IsParamValueNull Then _FilesPath = dt.First.ParamValue
                End If
                If _FilesPath <> "" AndAlso My.Computer.FileSystem.DirectoryExists(_FilesPath) Then Return _FilesPath
                If FolderBrowserDialog1.ShowDialog = vbOK Then
                    _FilesPath = FolderBrowserDialog1.SelectedPath
                    pt.Update(_FilesPath, "SoundsLibraryPath")
                End If
            End If
            Return _FilesPath
        End Get
    End Property

    Private _AudioFileTypes() As String
    Public Property AudioFileTypes() As String()
        Get
            If _AudioFileTypes Is Nothing Then
                Dim pt As New SoundsDataSetTableAdapters.ParametersTableAdapter
                _AudioFileTypes = pt.GetData("AudioFileTypes").First.ParamValue.Split(";")
            End If
            Return _AudioFileTypes
        End Get
        Set(ByVal value() As String)
            _AudioFileTypes = value
        End Set
    End Property

    Private Sub SoundsMng_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        wmp.settings.autoStart = True
        Dim s As String = FilesPath
        FillGrid()
        WindowState = FormWindowState.Maximized
        SetColumns()
    End Sub

    Private Sub SetColumns()
        Dim pt As New SoundsDataSetTableAdapters.ParametersTableAdapter
        Dim dt As SoundsDataSet.ParametersDataTable
        dt = pt.GetData("ColumnInfo")
        Dim cols() As String
        If dt.Count > 0 And Not dt.First.IsParamValueNull Then
            cols = dt.First.ParamValue.Split("|")
            For i As Int16 = 0 To SoundsGrid.Columns.Count - 1
                SoundsGrid.Columns(i).Visible = cols(i).Split(";")(0) = "1"
                SoundsGrid.Columns(i).Width = cols(i).Split(";")(1)
            Next
        End If
    End Sub

    Private Sub PlaySound()
        Dim row As SoundsDataSet.FilesJoinedNewRow
        Dim CurrentFile As String = ""
        Dim tr As System.Data.DataRowView
        tr = SoundsGrid.CurrentRow.DataBoundItem
        row = tr.Row
        For Each ext In AudioFileTypes
            CurrentFile = FilesPath & "\" & (row.Creator & " - " & row.Library & "\" & row.CD & "\" & row.Filename & ".").Replace("/", "\")
            If My.Computer.FileSystem.FileExists(CurrentFile & ext) Then
                wmp.URL = CurrentFile & ext
                Return
            End If
        Next
        WriteToLogFile("File: " & CurrentFile & " does not exist", True)
    End Sub

    Private Sub FillGrid()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim fltr() As String = ToolStripFilter.Text.Split(" ")
            If fltr.Length > 4 Then
                ToolStripFilter.Text = fltr(0) & " " & fltr(1) & " " & fltr(2) & " " & fltr(3)
                MessageBox.Show("Unable to handle more than 4 words")
                Exit Sub
            End If
            Dim fltrprm() As String = {"", "", "", ""}
            For i = 0 To fltr.Length - 1
                fltrprm(i) = fltr(i)
            Next
            FilesJoinedNewTableAdapter.Fill(SoundsDataSet.FilesJoinedNew, fltrprm(0), fltrprm(0), fltrprm(0), fltrprm(0) _
                                            , fltrprm(1), fltrprm(1), fltrprm(1), fltrprm(1) _
                                            , fltrprm(2), fltrprm(2), fltrprm(2), fltrprm(2) _
                                            , fltrprm(3), fltrprm(3), fltrprm(3), fltrprm(3))
        Catch ex As System.Exception
            WriteToLogFile(ex.Message, True)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub SoundsGrid_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoundsGrid.DoubleClick
        PlaySound()
    End Sub

    Private Sub ToolStripFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ToolStripFilter.KeyDown
        Timer1.Enabled = False
    End Sub

    Private Sub ToolStripFilter_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ToolStripFilter.KeyUp
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        FillGrid()
        Timer1.Enabled = False
    End Sub

    Private Sub SoundsMng_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ToolStripFilter.Focus()
    End Sub

    Private Sub btnSetLibPath_Click(sender As System.Object, e As System.EventArgs) Handles btnSetLibPath.Click
        _FilesPath = ""
        Dim s As String = FilesPath(False)
    End Sub

    Private Sub btnImportData_Click(sender As System.Object, e As System.EventArgs) Handles btnImportData.Click
        OpenFileDialog1.InitialDirectory = "c:\"
        OpenFileDialog1.Filter = "tsv files (*.tab)|*.tab|All files (*.*)|*.*"
        OpenFileDialog1.FilterIndex = 0
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.RestoreDirectory = True

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                Dim at As New SoundsDataSetTableAdapters.ArchivesTableAdapter
                Dim ar As SoundsDataSet.ArchivesDataTable
                Dim fname As String = OpenFileDialog1.FileName.Split("\").Last
                ar = at.GetDataBy(fname)
                If ar.Rows.Count = 0 Then
                    Dim engine As New FileHelperEngine(Of SoundRecord)()
                    engine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue
                    Me.Cursor = Cursors.WaitCursor
                    WriteToLogFile("Reading file '" & OpenFileDialog1.FileName & "'", False)
                    Dim res As SoundRecord() = engine.ReadFile(OpenFileDialog1.FileName)
                    If engine.ErrorManager.ErrorCount > 0 Then
                        engine.ErrorManager.SaveErrors("Errors.txt")
                        WriteToLogFile("Error while reading file, please check 'Errors.txt'", True)
                        Exit Try
                    End If
                    WriteToLogFile("File read successfully", False)
                    ImportFiles(res, fname)
                    ExecuteQueries()
                    FillGrid()
                Else
                    WriteToLogFile("File '" & OpenFileDialog1.FileName & "' has been imported before", True)
                End If
            Catch Ex As Exception
                WriteToLogFile("Cannot read file from disk. Original error: " & Ex.Message, True)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Sub WriteToLogFile(msg As String, ShowMessage As Boolean)
        If ShowMessage Then MessageBox.Show(msg)
        System.IO.File.AppendAllText(My.Application.Info.DirectoryPath & "\LogFile.txt", Date.Now.ToString("dd/MM/yyyy HH:mm:ss") & " = " & msg & Environment.NewLine)
    End Sub

    Private Sub btnPlaySound_Click(sender As System.Object, e As System.EventArgs) Handles btnPlaySound.Click
        PlaySound()
    End Sub

    Private Sub btnManageColumns_Click(sender As System.Object, e As System.EventArgs) Handles btnManageColumns.Click
        Dim dlg As New DlgSetColumns
        Dim ci As New List(Of ColumnMetaData)
        Dim cmd As ColumnMetaData
        For i As Int16 = 0 To SoundsGrid.Columns.Count - 1
            cmd = New ColumnMetaData
            cmd.ColumnName = SoundsGrid.Columns(i).HeaderText
            cmd.ColumnVisible = SoundsGrid.Columns(i).Visible
            cmd.ColumnWidth = SoundsGrid.Columns(i).Width
            ci.Add(cmd)
        Next
        dlg.ColumnsInfo = ci
        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then SetColumns()
    End Sub

    Private OldValue As String
    Private Sub SoundsGrid_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles SoundsGrid.CellBeginEdit
        OldValue = SoundsGrid.CurrentCell.Value.ToString
    End Sub

    Private Sub SoundsGrid_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles SoundsGrid.CellEndEdit
        Dim NewValue = SoundsGrid.CurrentCell.Value.ToString
        If NewValue <> OldValue Then
            Dim pt As New SoundsDataSetTableAdapters.FilesTableAdapter
            Dim dgc1 As String = SoundsGrid("Rating", e.RowIndex).Value.ToString
            Dim dgc2 As String = SoundsGrid("Tags", e.RowIndex).Value.ToString
            Dim dgc3 As String = SoundsGrid("ID", e.RowIndex).Value.ToString
            pt.Update(dgc1, dgc2, dgc3)
        End If
    End Sub

    Private Sub ExecuteQueries()
        Dim qry As New SoundsDataSetTableAdapters.QueriesTableAdapter
        Dim tmpRet As Integer
        WriteToLogFile("Executing queries", False)
        tmpRet = qry.ImportArchives
        WriteToLogFile("Imported " & tmpRet & " Archives", False)
        tmpRet = qry.ImportCreators
        WriteToLogFile("Imported " & tmpRet & " Creators", False)
        tmpRet = qry.ImportLibraries
        WriteToLogFile("Imported " & tmpRet & " Libraries", False)
        tmpRet = qry.ImportCDs
        WriteToLogFile("Imported " & tmpRet & " CDs", False)
        tmpRet = qry.ImportCategories
        WriteToLogFile("Imported " & tmpRet & " Categories", False)
        tmpRet = qry.ImportSubCategories
        WriteToLogFile("Imported " & tmpRet & " Subcategories", False)
        tmpRet = qry.ImportFiles
        WriteToLogFile("Imported " & tmpRet & " Files", True)
        tmpRet = qry.DeleteFilesForImport
        WriteToLogFile("Deleted " & tmpRet & " imported records", False)
    End Sub

    Private Sub ImportFiles(res As SoundRecord(), fname As String)
        Dim fta As New SoundsDataSetTableAdapters.FilesForImportTableAdapter
        prgBar.Maximum = res.Count
        prgBar.Value = 0
        Application.DoEvents()
        For Each snd As SoundRecord In res
            If fta.Insert(fname, snd.Creator, snd.Library, snd.Year, snd.CD, snd.Track, snd.Index, snd.Category,
                                snd.SubCategory, snd.Description, snd.Time, snd.Rating, snd.Filename, snd.Tags) <> 1 Then
                WriteToLogFile("Unable to insert line: " & fname & " " & snd.Creator & " " & snd.Library & " " & snd.Year & " " &
                               snd.CD & " " & snd.Track & " " & snd.Index & " " & snd.Category & " " &
                               snd.SubCategory & " " & snd.Description & " " & snd.Time & " " & snd.Rating & " " &
                               snd.Filename & " " & snd.Tags, False)
            End If
            prgBar.Value += 1
        Next
        prgBar.Value = 0
    End Sub

End Class