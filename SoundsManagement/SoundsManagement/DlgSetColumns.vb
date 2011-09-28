Imports System.Windows.Forms
Imports System.Text

Public Class DlgSetColumns

    Public ColumnsInfo As List(Of ColumnMetaData)
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = DialogResult.OK
        Dim AllValues As New StringBuilder
        For i As Int16 = 0 To ColumnsInfo.Count - 1
            AllValues.Append(IIf(CType(dgColumns.Rows(i).Cells("ColVisible").Value, Boolean), "1", "0") & ";" & dgColumns.Rows(i).Cells("ColWidth").Value & "|")
        Next
        AllValues.Remove(AllValues.Length - 1, 1)
        Dim pt As New SoundsDataSetTableAdapters.ParametersTableAdapter
        pt.Update(AllValues.ToString, "ColumnInfo")
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DlgSetColumns_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        dgColumns.Rows.Add(ColumnsInfo.Count)
        Dim ci As ColumnMetaData
        For i As Int16 = 0 To ColumnsInfo.Count - 1
            ci = ColumnsInfo(i)
            dgColumns.Rows(i).SetValues(ci.ColumnName, ci.ColumnVisible, ci.ColumnWidth)
        Next
    End Sub
End Class
