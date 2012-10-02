Imports System.Windows.Forms

Public Class dlgEditForm
	Public Property DataList As New List(Of SoundsDataSet.FilesJoinedNewRow)
	Public ChangedItems As New Dictionary(Of String, Object)
	Private IsLoading As Boolean

	Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.Close()
	End Sub

	Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Close()
	End Sub

	Private Sub dlgEditForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
		IsLoading = True
		Me.SubcategoriesTableAdapter.Fill(Me.SoundsDataSet.Subcategories)
		Me.CategoriesTableAdapter.Fill(Me.SoundsDataSet.Categories)
		Me.CDsTableAdapter.Fill(Me.SoundsDataSet.CDs)
		Me.LibrariesTableAdapter.Fill(Me.SoundsDataSet.Libraries)
		Me.CreatorsTableAdapter.Fill(Me.SoundsDataSet.Creators)

		If DataList.Count() > 0 Then
			Try
				Dim tmp As Object() = DataList.Select(Function(x) x.Year).Distinct().ToArray()
				If tmp.Count() = 1 Then YearTextBox.Text = tmp(0)
				tmp = DataList.Select(Function(x) x.Time).Distinct().ToArray()
				If tmp.Count() = 1 Then TimeTextBox.Text = tmp(0)
				tmp = DataList.Select(Function(x) CType(x.Rating, Object)).Distinct().ToArray()
				If tmp.Count() = 1 Then RatingTextBox.Text = tmp(0)
				tmp = DataList.Select(Function(x) CType(x.Index1, Object)).Distinct().ToArray()
				If tmp.Count() = 1 Then IndexTextBox.Text = tmp(0)
				tmp = DataList.Select(Function(x) CType(x.Track, Object)).Distinct().ToArray()
				If tmp.Count() = 1 Then TrackTextBox.Text = tmp(0)
				tmp = DataList.Select(Function(x) x.Description).Distinct().ToArray()
				If tmp.Count() = 1 Then DescriptionTextBox.Text = tmp(0)
				tmp = DataList.Select(Function(x) x.Tags).Distinct().ToArray()
				If tmp.Count() = 1 Then TagsTextBox.Text = tmp(0)
				tmp = DataList.Select(Function(x) x.Creator).Distinct().ToArray()
				If tmp.Count() = 1 Then Creators_IDComboBox.SelectedIndex = Creators_IDComboBox.FindStringExact(tmp(0)) Else Creators_IDComboBox.SelectedIndex = -1
				tmp = DataList.Select(Function(x) x.Library).Distinct().ToArray()
				If tmp.Count() = 1 Then Libraries_IDComboBox.SelectedIndex = Libraries_IDComboBox.FindStringExact(tmp(0)) Else Libraries_IDComboBox.SelectedIndex = -1
				tmp = DataList.Select(Function(x) x.CD).Distinct().ToArray()
				If tmp.Count() = 1 Then CDs_IDComboBox.SelectedIndex = CDs_IDComboBox.FindStringExact(tmp(0)) Else CDs_IDComboBox.SelectedIndex = -1
				tmp = DataList.Select(Function(x) x.Category).Distinct().ToArray()
				If tmp.Count() = 1 Then Categories_IDComboBox.SelectedIndex = Categories_IDComboBox.FindStringExact(tmp(0)) Else Categories_IDComboBox.SelectedIndex = -1
				tmp = DataList.Select(Function(x) x.SubCategory).Distinct().ToArray()
				If tmp.Count() = 1 Then Subcategories_IDComboBox.SelectedIndex = Subcategories_IDComboBox.FindStringExact(tmp(0)) Else Subcategories_IDComboBox.SelectedIndex = -1
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End If
		IsLoading = False
	End Sub

	Private Sub CreatorComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Creators_IDComboBox.SelectedIndexChanged
		ItemChangedValue(sender)
	End Sub

	Private Sub LibraryComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Libraries_IDComboBox.SelectedIndexChanged
		ItemChangedValue(sender)
	End Sub

	Private Sub CDComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CDs_IDComboBox.SelectedIndexChanged
		ItemChangedValue(sender)
	End Sub

	Private Sub CategoryComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Categories_IDComboBox.SelectedIndexChanged
		ItemChangedValue(sender)
	End Sub

	Private Sub SubCategComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Subcategories_IDComboBox.SelectedIndexChanged
		ItemChangedValue(sender)
	End Sub

	Private Sub ItemChangedValue(sender As System.Object)
		Dim ctrl As Control = CType(sender, Control)
		Dim ctrlName As String
		If Not IsLoading Then
			If TypeOf (ctrl) Is TextBox Then
				ctrlName = ctrl.Name.Replace("TextBox", "")
				If Not ChangedItems.ContainsKey(ctrlName) Then
					ChangedItems.Add(ctrlName, ctrl.Text)
				Else
					ChangedItems(ctrlName) = ctrl.Text
				End If
			End If
			If TypeOf (ctrl) Is ComboBox Then
				ctrlName = ctrl.Name.Replace("ComboBox", "")
				If Not ChangedItems.ContainsKey(ctrlName) Then
					ChangedItems.Add(ctrlName, CType(ctrl, ComboBox).SelectedValue)
				Else
					ChangedItems(ctrlName) = CType(ctrl, ComboBox).SelectedValue
				End If
			End If
		End If
	End Sub

	Private Sub YearTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles YearTextBox.TextChanged
		ItemChangedValue(sender)
	End Sub

	Private Sub TimeTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles TimeTextBox.TextChanged
		ItemChangedValue(sender)
	End Sub

	Private Sub RatingTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles RatingTextBox.TextChanged
		ItemChangedValue(sender)
	End Sub

	Private Sub IndexTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles IndexTextBox.TextChanged
		ItemChangedValue(sender)
	End Sub

	Private Sub TrackTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles TrackTextBox.TextChanged
		ItemChangedValue(sender)
	End Sub

	Private Sub DescriptionTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles DescriptionTextBox.TextChanged
		ItemChangedValue(sender)
	End Sub

	Private Sub TagsTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles TagsTextBox.TextChanged
		ItemChangedValue(sender)
	End Sub
End Class
