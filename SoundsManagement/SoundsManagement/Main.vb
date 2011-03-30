Imports DevExpress.XtraGrid.Views.Grid

Public Class Main
    Private _FilesPath As String = ""
    Public ReadOnly Property FilesPath(Optional ByVal RetrieveFromDB As Boolean = True) As String
        Get
            If _FilesPath = "" Then
                Dim que As New SoundsDataSetTableAdapters.QueriesTableAdapter
                Dim pt As New SoundsDataSetTableAdapters.ParametersTableAdapter
                If RetrieveFromDB Then _FilesPath = que.LibraryPath()
                If _FilesPath <> "" AndAlso My.Computer.FileSystem.DirectoryExists(_FilesPath) Then Return _FilesPath
                If FolderBrowserDialog1.ShowDialog = vbOK Then
                    _FilesPath = FolderBrowserDialog1.SelectedPath
                    Try
                        pt.Update(_FilesPath, "SoundsLibraryPath", "")
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                    SoundsDataSet.AcceptChanges()
                End If
            End If
            Return _FilesPath
        End Get
    End Property

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FilesJoinedTableAdapter.Fill(Me.SoundsDataSet.FilesJoined)
        wmp.settings.autoStart = True
        Dim s As String = FilesPath
    End Sub

    Private Sub btnPlaySound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlaySound.Click
        PlaySound()
    End Sub

    Private Sub SoundsGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles SoundsGrid.DoubleClick
        PlaySound()
    End Sub

    Private Sub PlaySound()
        Dim row As SoundsDataSet.FilesJoinedRow 'SoundsManagement.SoundsDataSet.FilesDataTableRow
        Dim CurrentFile As String
        Dim tr As System.Data.DataRowView
        tr = SoundsGrid.FocusedView.GetRow(CType(SoundsGrid.FocusedView, DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle)
        row = tr.Row
        CurrentFile = FilesPath & "\" & (row.Creator & " - " & row.Library & "\" & row.CD & "\" & row.Filename & ".mp3").Replace("/", "\")
        If My.Computer.FileSystem.FileExists(CurrentFile) Then
            wmp.URL = CurrentFile
        Else
            MessageBox.Show("File: " & CurrentFile & " does not exist")
        End If
    End Sub

    Private Sub btnLibPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLibPath.Click
        _FilesPath = ""
        Dim s As String = FilesPath(False)
    End Sub
End Class
