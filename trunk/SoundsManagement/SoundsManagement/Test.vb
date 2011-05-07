Imports System.Data.SqlClient

Public Class Test

    Private Sub Test_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim connectionString As String = My.Settings.SoundsConnectionString
        Dim da = New SqlDataAdapter("SELECT * FROM Files", connectionString)
        Dim commandBuilder As New SqlCommandBuilder(da)
        Dim table As New DataTable()
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        da.Fill(table)
        dgTest.DataSource = table
        dgTest.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader)
    End Sub
End Class