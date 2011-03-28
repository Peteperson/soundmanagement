Public Class Main

    Private _FilesPath As String = ""
    Public ReadOnly Property FilesPath As String
        Get
            If _FilesPath = "" Then
                Dim frm As New FilesPathDialog
                If frm.ShowDialog = vbOK Then _FilesPath = frm.txtPath.Text
            End If
            Return _FilesPath
        End Get
    End Property


    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FilesDataTableTableAdapter.Fill(Me.SoundsDataSet._FilesDataTable)
        Dim s As String = FilesPath
    End Sub

    Private Sub SoundsGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles SoundsGrid.DoubleClick
        Dim row As SoundsManagement.SoundsDataSet.FilesDataTableRow
        'row = SoundsGrid.FocusedView.GetRow
        'AxWMP.URL = SoundsGrid.fo
        Dim s As String = ""
    End Sub
End Class
