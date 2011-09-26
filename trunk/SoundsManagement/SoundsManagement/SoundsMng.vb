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

    Private Sub FilesJoinedNewBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilesJoinedNewBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.FilesJoinedNewBindingSource.EndEdit()
        'Me.FilesJoinedNewTableAdapter.Adapter.UpdateCommand.Parameters(
        Me.TableAdapterManager.UpdateAll(Me.SoundsDataSet)
    End Sub

    Private Sub SoundsMng_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        wmp.settings.autoStart = True
        Dim s As String = FilesPath
        FillGrid()
        WindowState = FormWindowState.Maximized
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
        MessageBox.Show("File: " & CurrentFile & " does not exist")
    End Sub

    Private Sub FillGrid()
        Try
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
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SoundsGrid_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoundsGrid.DoubleClick
        PlaySound()
    End Sub

    Private Sub btnLibPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLibPath.Click
        _FilesPath = ""
        Dim s As String = FilesPath(False)
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

    Private Sub btnImport_Click(sender As System.Object, e As System.EventArgs) Handles btnImport.Click
        OpenFileDialog1.InitialDirectory = "c:\"
        OpenFileDialog1.Filter = "tsv files (*.tab)|*.tab|All files (*.*)|*.*"
        OpenFileDialog1.FilterIndex = 0
        OpenFileDialog1.Multiselect = False
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                Dim engine As New FileHelperEngine(Of SoundRecord)()
                engine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue

                Dim res As SoundRecord() = engine.ReadFile(OpenFileDialog1.FileName)
                Dim fta As New SoundsDataSetTableAdapters.FilesForImportTableAdapter
                If engine.ErrorManager.ErrorCount > 0 Then
                    engine.ErrorManager.SaveErrors("Errors.txt")
                End If
                Dim tmpRet As Integer
                For Each snd As SoundRecord In res
                    tmpRet = fta.Insert(snd.Creator, snd.Library, snd.Year, snd.CD, snd.Track, snd.Index, snd.Category,
                               snd.SubCategory, snd.Description, snd.Time, snd.Rating, snd.Filename, snd.Tags)
                Next

                Dim qry As New SoundsDataSetTableAdapters.QueriesTableAdapter
                tmpRet = qry.ImportCreators
                tmpRet = qry.ImportLibraries
                tmpRet = qry.ImportCDs
                tmpRet = qry.ImportCategories
                tmpRet = qry.ImportSubCategories
                tmpRet = qry.ImportFiles
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally

            End Try
        End If
    End Sub
End Class