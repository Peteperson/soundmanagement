Imports System.Windows.Forms
Imports System.Linq

Public Class TagDialog

	Public ReadOnly Property FinalTag As String
		Get
			Return txtTag.Text.Remove(txtTag.Text.Length - 1)
		End Get
	End Property

	Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.Close()
	End Sub

	Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Close()
	End Sub

	Private Sub TagDialog_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
		Me.TagsTableAdapter.Fill(Me.SoundsDataSet.Tags)
	End Sub

	Private Sub btnInsertTag_Click(sender As System.Object, e As System.EventArgs) Handles btnInsertTag.Click
		If cbTags.Text <> "" Then
			Dim pt As New SoundsDataSetTableAdapters.TagsTableAdapter
			If pt.TagExists(cbTags.Text) = 0 Then
				pt.Insert(cbTags.Text)
			End If
			Dim str As String = txtTag.Text
			str += cbTags.Text & " "
			txtTag.Text = str
		End If
	End Sub
End Class
