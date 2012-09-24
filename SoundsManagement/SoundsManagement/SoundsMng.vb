Imports FileHelpers
Imports System.Windows.Forms
Imports System.Text
Imports System.IO

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

	Private Sub SoundsMng_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
		If ChangedColunmSettings Then
			Dim success As Boolean
			Dim AllValues As New StringBuilder
			Try
				For i As Int16 = 0 To SoundsGrid.Columns.Count - 1
					AllValues.Append(IIf(SoundsGrid.Columns(i).Visible, "1", "0") & ";" & SoundsGrid.Columns(i).Width & "|")
				Next
				AllValues.Remove(AllValues.Length - 1, 1)
				success = True
			Catch ex As Exception
				WriteToLogFile(ex.Message, False)
			End Try
			If success Then
				Dim pt As New SoundsDataSetTableAdapters.ParametersTableAdapter
				pt.Update(AllValues.ToString, "ColumnInfo")
			End If
		End If
	End Sub

	Private Sub SoundsMng_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		wmp.settings.autoStart = True
		Dim s As String = FilesPath
		WindowState = FormWindowState.Maximized
		FillGrid()
		SetColumns()
		lstNoOfSelRecs.SelectedIndex = 1
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

	Private Sub ToolStripFilter_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles ToolStripFilter.KeyDown
		Timer1.Enabled = False
	End Sub

	Private Sub ToolStripFilter_KeyUp(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles ToolStripFilter.KeyUp
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

		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
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
		File.AppendAllText(My.Application.Info.DirectoryPath & "\LogFile.txt", Date.Now.ToString("dd/MM/yyyy HH:mm:ss") & " = " & msg & Environment.NewLine)
	End Sub

	Private Sub btnPlaySound_Click(sender As System.Object, e As System.EventArgs)
		PlaySound()
	End Sub

	Private ChangedColunmSettings As Boolean = False
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
		If dlg.ShowDialog() = DialogResult.OK Then
			For i As Int16 = 0 To SoundsGrid.Columns.Count - 1
				SoundsGrid.Columns(i).Visible = dlg.ColumnsInfo(i).ColumnVisible
			Next
			ChangedColunmSettings = True
		End If
		dlg.Close()
	End Sub

	Private OldValue As String
	Private Sub SoundsGrid_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles SoundsGrid.CellBeginEdit
		OldValue = SoundsGrid.CurrentCell.Value.ToString
	End Sub

	Private Sub SoundsGrid_CellEndEdit(sender As System.Object, e As DataGridViewCellEventArgs) Handles SoundsGrid.CellEndEdit
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

	Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
		SaveFileDialog1.Filter = "Tab Files (*.tab)|*.tab|All Files (*.*)|*.*"
		SaveFileDialog1.FilterIndex = 0
		If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
			Dim ft As New SoundsDataSetTableAdapters.FilesJoinedNewTableAdapter
			Dim dt As SoundsDataSet.FilesJoinedNewDataTable
			Me.Cursor = Cursors.WaitCursor
			dt = ft.GetDataBy()
			prgBar.Maximum = dt.Rows.Count
			prgBar.Value = 0
			Dim str As System.Text.StringBuilder = New System.Text.StringBuilder()
			For i As Int16 = 0 To dt.Columns.Count - 3
				str.Append(dt.Columns(i).ColumnName)
				If i < dt.Columns.Count - 3 Then str.Append(vbTab)
			Next
			str.Append(Environment.NewLine)
			For i As Int16 = 0 To dt.Rows.Count - 1
				For j As Int16 = 0 To dt.Columns.Count - 3
					str.Append(dt.Rows(i)(j).ToString())
					If j < dt.Columns.Count - 3 Then str.Append(vbTab)
				Next
				If i < dt.Rows.Count - 1 Then str.Append(Environment.NewLine)
				prgBar.Value += 1
			Next

			Dim myStream As New IO.StreamWriter(SaveFileDialog1.FileName, False)
			myStream.Write(str.ToString())
			myStream.Close()
			prgBar.Value = 0
			Me.Cursor = Cursors.Default
			WriteToLogFile("Exported " & dt.Rows.Count & " records to: " & SaveFileDialog1.FileName, True)
		End If
	End Sub

	Private Sub lstNoOfSelRecs_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstNoOfSelRecs.SelectedIndexChanged
		Dim prevval As String = FilesJoinedNewTableAdapter.Adapter.SelectCommand.CommandText
		Dim newval As String = FilesJoinedNewTableAdapter.Adapter.SelectCommand.CommandText
		Dim regex As New RegularExpressions.Regex("SELECT.+Files\.ID")
		Select Case lstNoOfSelRecs.SelectedIndex
			Case 0
				newval = regex.Replace(prevval, "SELECT TOP 50 Files.ID")
			Case 1
				newval = regex.Replace(prevval, "SELECT     TOP 500 Files.ID")
			Case 2
				newval = regex.Replace(prevval, "SELECT Files.ID")
		End Select
		If prevval <> newval Then
			FilesJoinedNewTableAdapter.Adapter.SelectCommand.CommandText = newval
			FillGrid()
		End If
	End Sub

	Private Sub btnPath_Click(sender As System.Object, e As System.EventArgs) Handles btnPath.Click
		InputBox("Useful message! ", "Application Path: ", My.Application.Info.DirectoryPath)
	End Sub

	Private Sub SoundsGrid_KeyUp(sender As System.Object, e As KeyEventArgs) Handles SoundsGrid.KeyUp
		If (e.KeyCode = 46 Or e.KeyCode = 8) Then
			If SoundsGrid.SelectedRows.Count > 0 AndAlso MessageBox.Show("Really delete those records ?", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.Yes Then
				Dim id As Integer
				Dim pt As New SoundsDataSetTableAdapters.FilesTableAdapter
				For Each row In SoundsGrid.SelectedRows
					id = Integer.Parse(SoundsGrid("ID", row.Index).Value.ToString())
					pt.Delete(id)
					SoundsGrid.Rows.Remove(row)
				Next
			End If
		End If
		If (e.KeyCode = 32) Then
			PlaySound()
		End If
		If (e.KeyCode = 107) Then
			ShowTagsDialog()
		End If
	End Sub

	Private Sub btnTags_Click(sender As System.Object, e As System.EventArgs) Handles btnTags.Click
		ShowTagsDialog()
	End Sub

	Private Sub ShowTagsDialog()
		Dim frmTags As New TagDialog
		If frmTags.ShowDialog() = DialogResult.OK Then
			If SoundsGrid.SelectedRows.Count > 0 AndAlso MessageBox.Show("Really update those records ?", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.Yes Then
				Dim id As Integer
				Dim pt As New SoundsDataSetTableAdapters.FilesTableAdapter
				For Each row In SoundsGrid.SelectedRows
					id = Integer.Parse(SoundsGrid("ID", row.Index).Value.ToString())
					pt.UpdateTagOnly(frmTags.FinalTag, id)
					SoundsGrid("Tags", row.Index).Value = frmTags.FinalTag
				Next
			End If
		End If
	End Sub

	Private Sub btnExpNotExFiles_Click(sender As System.Object, e As System.EventArgs) Handles btnExpNotExFiles.Click
		SaveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
		SaveFileDialog1.FilterIndex = 0
		If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
			Dim fname As String = SaveFileDialog1.FileName
			Dim row As SoundsDataSet.FilesJoinedNewRow
			Dim CurrentFile As String = ""
			Dim finalText As New StringBuilder
			Dim count As Integer = 0
			Dim fileExists As Boolean
			Dim tr As DataGridViewRow

			prgBar.Maximum = SoundsGrid.Rows.Count
			prgBar.Value = 0
			finalText.Append("Exporting not existing files" & Environment.NewLine)
			finalText.Append(DateTime.Now.ToString("dd/MM/yyyy HH:mm") & Environment.NewLine)
			finalText.Append("FileNames:" & Environment.NewLine)
			For Each tr In SoundsGrid.Rows
				prgBar.Value += 1
				row = tr.DataBoundItem.Row
				fileExists = False
				For Each ext In AudioFileTypes
					CurrentFile = FilesPath & "\" & (row.Creator & " - " & row.Library & "\" & row.CD & "\" & row.Filename & ".").Replace("/", "\")
					If My.Computer.FileSystem.FileExists(CurrentFile & ext) Then
						fileExists = True
						Exit For
					End If
				Next
				If Not fileExists Then
					count += 1
					finalText.Append(count.ToString() & ") " & CurrentFile & Environment.NewLine)
				End If
			Next
			File.WriteAllText(fname, finalText.ToString())
			prgBar.Value = 0
			MessageBox.Show("From " & SoundsGrid.Rows.Count & " files shown in DataGrid, " & count & " does not exist.")
		End If
	End Sub

	Private Sub SoundsGrid_RowPrePaint(sender As System.Object, e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles SoundsGrid.RowPrePaint
		Dim row As SoundsDataSet.FilesJoinedNewRow
		Dim fileExists As Boolean
		Dim CurrentFile As String = ""
		row = SoundsGrid.Rows(e.RowIndex).DataBoundItem.Row
		fileExists = False
		For Each ext In AudioFileTypes
			CurrentFile = FilesPath & "\" & (row.Creator & " - " & row.Library & "\" & row.CD & "\" & row.Filename & ".").Replace("/", "\")
			If My.Computer.FileSystem.FileExists(CurrentFile & ext) Then
				fileExists = True
				Exit For
			End If
		Next
		If Not fileExists Then
			SoundsGrid.Rows(e.RowIndex).DefaultCellStyle.Font = New Font(Me.Font, FontStyle.Italic)
			SoundsGrid.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.FromArgb(90, 80, 80)
		End If
	End Sub
End Class