Imports FileHelpers
Imports System.Windows.Forms
Imports System.Text
Imports System.IO
Imports System.Data.OleDb

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
				For i As Integer = 0 To SoundsGrid.Columns.Count - 1
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
		RetrieveNumberOfFiles()
	End Sub

	Private Sub SetColumns()
		Dim pt As New SoundsDataSetTableAdapters.ParametersTableAdapter
		Dim dt As SoundsDataSet.ParametersDataTable
		dt = pt.GetData("ColumnInfo")
		Dim cols() As String
		If dt.Count > 0 And Not dt.First.IsParamValueNull Then
			cols = dt.First.ParamValue.Split("|")
			For i As Integer = 0 To SoundsGrid.Columns.Count - 1
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
		OpenFileDialog1.Multiselect = True
		OpenFileDialog1.RestoreDirectory = True
		Dim importFilesEnded As Boolean = False

		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
			Try
				Dim at As New SoundsDataSetTableAdapters.ArchivesTableAdapter
				Dim ar As SoundsDataSet.ArchivesDataTable
				For Each filename As String In OpenFileDialog1.FileNames
					Dim fname As String = filename.Split("\").Last
					ar = at.GetDataBy(fname)
					If ar.Rows.Count = 0 Then
						Dim engine As New FileHelperEngine(Of SoundRecord)()
						engine.ErrorManager.ErrorMode = ErrorMode.ThrowException
						Me.Cursor = Cursors.WaitCursor
						WriteToLogFile("Reading file '" & filename & "'", False)
						Dim res As SoundRecord() = engine.ReadFile(filename)
						If engine.ErrorManager.ErrorCount > 0 Then
							engine.ErrorManager.SaveErrors("Errors.txt")
							WriteToLogFile("Error while reading file, please check 'Errors.txt'", True)
							Exit Try
						End If
						WriteToLogFile("File read successfully", False)
						ImportFiles(res, fname)
						importFilesEnded = True
						ExecuteQueries()
						FillGrid()
					Else
						WriteToLogFile("File '" & filename & "' has been imported before", True)
					End If
				Next
			Catch Ex As Exception
				If (importFilesEnded) Then ClearData()
				WriteToLogFile("Error while importing data: " & Ex.Message, True)
			Finally
				Me.prgBar.Value = 0
				Me.Cursor = Cursors.Default
				RetrieveNumberOfFiles()
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
		For i As Integer = 0 To SoundsGrid.Columns.Count - 1
			cmd = New ColumnMetaData
			cmd.ColumnName = SoundsGrid.Columns(i).HeaderText
			cmd.ColumnVisible = SoundsGrid.Columns(i).Visible
			cmd.ColumnWidth = SoundsGrid.Columns(i).Width
			ci.Add(cmd)
		Next
		dlg.ColumnsInfo = ci
		If dlg.ShowDialog() = DialogResult.OK Then
			For i As Integer = 0 To SoundsGrid.Columns.Count - 1
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

	Private Sub ClearData()
		Dim qry As New SoundsDataSetTableAdapters.QueriesTableAdapter
		Dim tmpRet As Integer
		WriteToLogFile("Executing clearing queries", False)
		tmpRet = qry.ClearArchives
		WriteToLogFile("Deleted " & tmpRet & " Archives", False)
		tmpRet = qry.ClearCreators
		WriteToLogFile("Deleted " & tmpRet & " Creators", False)
		tmpRet = qry.ClearLibraries
		WriteToLogFile("Deleted " & tmpRet & " Libraries", False)
		tmpRet = qry.ClearCDs
		WriteToLogFile("Deleted " & tmpRet & " CDs", False)
		tmpRet = qry.ClearCategories
		WriteToLogFile("Deleted " & tmpRet & " Categories", False)
		tmpRet = qry.ClearSubCategories
		WriteToLogFile("Deleted " & tmpRet & " Subcategories", False)
		tmpRet = qry.DeleteFilesForImport
		WriteToLogFile("Deleted " & tmpRet & " records for import", False)
		Dim s As 
	End Sub

	Private ffita As New SoundsManagement.SoundsDataSetTableAdapters.FilesForImportTableAdapter
	Private fta As New SoundsManagement.SoundsDataSetTableAdapters.FilesTableAdapter
	Private Sub ImportFiles(res As SoundRecord(), fname As String)
		Dim fta As New SoundsDataSetTableAdapters.FilesForImportTableAdapter
		prgBar.Maximum = res.Count
		prgBar.Value = 0
		ffita.Adapter.InsertCommand.Connection.Open()
		For Each snd As SoundRecord In res
			Try
				If InsertRecord(fname, snd.Creator, snd.Library, snd.Year, snd.CD, snd.Track, snd.Index, snd.Category,
				 snd.SubCategory, snd.Description, snd.Time, snd.Rating, snd.Filename, snd.Tags) <> 1 Then
					WriteToLogFile("Unable to insert line: " & fname & " " & snd.Creator & " " & snd.Library & " " & snd.Year & " " &
					snd.CD & " " & snd.Track & " " & snd.Index & " " & snd.Category & " " &
					snd.SubCategory & " " & snd.Description & " " & snd.Time & " " & snd.Rating & " " &
					snd.Filename & " " & snd.Tags, False)
				End If
				prgBar.Value += 1
				Application.DoEvents()
			Catch ex As Exception
				WriteToLogFile("Error while importing data on line " & prgBar.Value + 2 & ": " & ex.Message, True)
				ffita.Adapter.InsertCommand.Connection.Close()
				prgBar.Value = 0
				Throw New Exception(ex.Message)
			End Try
		Next
		prgBar.Value = 0
		If ffita.Adapter.InsertCommand.Connection.State = ConnectionState.Open Then
			ffita.Adapter.InsertCommand.Connection.Close()
		End If
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
			For i As Integer = 0 To dt.Columns.Count - 3
				str.Append(dt.Columns(i).ColumnName)
				If i < dt.Columns.Count - 3 Then str.Append(vbTab)
			Next
			str.Append(Environment.NewLine)
			For i As Integer = 0 To dt.Rows.Count - 1
				For j As Integer = 0 To dt.Columns.Count - 3
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
				fta.Adapter.DeleteCommand.Connection.Open()
				Dim id As Integer
				Dim pt As New SoundsDataSetTableAdapters.FilesTableAdapter
				For Each row In SoundsGrid.SelectedRows
					id = Integer.Parse(SoundsGrid("ID", row.Index).Value.ToString())
					DeleteRecord(id)
					SoundsGrid.Rows.Remove(row)
				Next
				fta.Adapter.DeleteCommand.Connection.Close()
			End If
		End If
		If (e.KeyCode = 32) Then
			PlaySound()
		End If
		If (e.KeyCode = 107) Then
			EditRecords()
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

	Private Sub btnEditRecs_Click(sender As System.Object, e As System.EventArgs) Handles btnEditRecs.Click
		EditRecords()
	End Sub

	Private Sub EditRecords()
		Dim frmEdit As New dlgEditForm
		Dim dataList As New List(Of SoundsDataSet.FilesJoinedNewRow)
		Dim n As Integer
		For Each row In SoundsGrid.SelectedRows
			dataList.Add(CType(CType(CType(row, DataGridViewRow).DataBoundItem, DataRowView).Row, SoundsDataSet.FilesJoinedNewRow))
		Next
		frmEdit.DataList = dataList
		If dataList.Count > 0 AndAlso frmEdit.ShowDialog() = DialogResult.OK AndAlso frmEdit.ChangedItems.Count > 0 Then
			Dim query As String = "UPDATE `Files` SET "
			For Each elm In frmEdit.ChangedItems
				query += "`" & elm.Key & "` = ?, "
			Next
			query = query.Remove(query.Length - 2) & " WHERE (`ID` = ?)"
			Dim command As New OleDbCommand(query, New OleDbConnection(My.Settings.SoundsConnectionString))

			For Each elm In frmEdit.ChangedItems
				Select Case elm.Key
					Case "Creators_ID"
						command.Parameters.Add(New OleDbParameter("Creators_ID", OleDbType.[Integer], 0, ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Creators_ID", DataRowVersion.Current, False, Nothing))
						command.Parameters("Creators_ID").Value = Integer.Parse(frmEdit.ChangedItems("Creators_ID"))
					Case "Libraries_ID"
						command.Parameters.Add(New OleDbParameter("Libraries_ID", OleDbType.[Integer], 0, ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Libraries_ID", DataRowVersion.Current, False, Nothing))
						command.Parameters("Libraries_ID").Value = Integer.Parse(frmEdit.ChangedItems("Libraries_ID"))
					Case "CDs_ID"
						command.Parameters.Add(New OleDbParameter("CDs_ID", OleDbType.[Integer], 0, ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "CDs_ID", DataRowVersion.Current, False, Nothing))
						command.Parameters("CDs_ID").Value = Integer.Parse(frmEdit.ChangedItems("CDs_ID"))
					Case "Year"
						command.Parameters.Add(New OleDbParameter("Year", OleDbType.WChar, 4, ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Year", DataRowVersion.Current, False, Nothing))
						command.Parameters("Year").Value = Int16.Parse(frmEdit.ChangedItems("Year"))
					Case "Track"
						command.Parameters.Add(New OleDbParameter("Track", OleDbType.SmallInt, 0, ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Track", DataRowVersion.Current, False, Nothing))
						command.Parameters("Track").Value = Int16.Parse(frmEdit.ChangedItems("Track"))
					Case "Index"
						command.Parameters.Add(New OleDbParameter("Index", OleDbType.SmallInt, 0, ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Index", DataRowVersion.Current, False, Nothing))
						command.Parameters("Index").Value = Int16.Parse(frmEdit.ChangedItems("Index"))
					Case "Categories_ID"
						command.Parameters.Add(New OleDbParameter("Categories_ID", OleDbType.[Integer], 0, ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Categories_ID", DataRowVersion.Current, False, Nothing))
						command.Parameters("Categories_ID").Value = Integer.Parse(frmEdit.ChangedItems("Categories_ID"))
					Case "Subcategories_ID"
						command.Parameters.Add(New OleDbParameter("Subcategories_ID", OleDbType.[Integer], 0, ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Subcategories_ID", DataRowVersion.Current, False, Nothing))
						command.Parameters("Subcategories_ID").Value = Integer.Parse(frmEdit.ChangedItems("Subcategories_ID"))
					Case "Description"
						command.Parameters.Add(New OleDbParameter("Description", OleDbType.WChar, 255, ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Description", DataRowVersion.Current, False, Nothing))
						command.Parameters("Description").Value = frmEdit.ChangedItems("Description")
					Case "Time"
						command.Parameters.Add(New OleDbParameter("Time", OleDbType.WChar, 5, ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Time", DataRowVersion.Current, False, Nothing))
						command.Parameters("Time").Value = frmEdit.ChangedItems("Time")
					Case "Rating"
						command.Parameters.Add(New OleDbParameter("Rating", OleDbType.UnsignedTinyInt, 0, ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Rating", DataRowVersion.Current, False, Nothing))
						command.Parameters("Rating").Value = IIf(Int16.TryParse(frmEdit.ChangedItems("Rating"), n), n, 0)
					Case "Tags"
						command.Parameters.Add(New OleDbParameter("Tags", OleDbType.WChar, 255, ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Tags", DataRowVersion.Current, False, Nothing))
						command.Parameters("Tags").Value = frmEdit.ChangedItems("Tags")
				End Select
			Next
			command.Parameters.Add(New OleDbParameter("Original_ID", OleDbType.[Integer], 0, ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ID", DataRowVersion.Original, False, Nothing))
			Dim pt As New SoundsDataSetTableAdapters.FilesTableAdapter
			Dim id As Integer
			If ((command.Connection.State And ConnectionState.Open) <> ConnectionState.Open) Then
				command.Connection.Open()
			End If
			For Each row In SoundsGrid.SelectedRows
				id = Integer.Parse(SoundsGrid("ID", row.Index).Value.ToString())
				command.Parameters("Original_ID").Value = id
				Dim returnValue As Integer
				Try
					returnValue = command.ExecuteNonQuery
				Catch ex As Exception
					WriteToLogFile(ex.Message, False)
				End Try
			Next
			If ((command.Connection.State And ConnectionState.Open) = ConnectionState.Open) Then
				command.Connection.Close()
			End If
			FillGrid()
		End If
	End Sub

	Private Function InsertRecord(ByVal ArchiveName As String, ByVal Creator As String, ByVal Library As String, ByVal Year As String, ByVal CD As String, ByVal Track As Global.System.Nullable(Of Short), ByVal Index As Global.System.Nullable(Of Byte), ByVal Category As String, ByVal SubCategory As String, ByVal Description As String, ByVal Time As String, ByVal Rating As Global.System.Nullable(Of Byte), ByVal Filename As String, ByVal Tags As String) As Integer
		If (ArchiveName Is Nothing) Then
			ffita.Adapter.InsertCommand.Parameters(0).Value = Global.System.DBNull.Value
		Else
			ffita.Adapter.InsertCommand.Parameters(0).Value = CType(ArchiveName, String)
		End If
		If (Creator Is Nothing) Then
			ffita.Adapter.InsertCommand.Parameters(1).Value = Global.System.DBNull.Value
		Else
			ffita.Adapter.InsertCommand.Parameters(1).Value = CType(Creator, String)
		End If
		If (Library Is Nothing) Then
			ffita.Adapter.InsertCommand.Parameters(2).Value = Global.System.DBNull.Value
		Else
			ffita.Adapter.InsertCommand.Parameters(2).Value = CType(Library, String)
		End If
		If (Year Is Nothing) Then
			ffita.Adapter.InsertCommand.Parameters(3).Value = Global.System.DBNull.Value
		Else
			ffita.Adapter.InsertCommand.Parameters(3).Value = CType(Year, String)
		End If
		If (CD Is Nothing) Then
			ffita.Adapter.InsertCommand.Parameters(4).Value = Global.System.DBNull.Value
		Else
			ffita.Adapter.InsertCommand.Parameters(4).Value = CType(CD, String)
		End If
		If (Track.HasValue = True) Then
			ffita.Adapter.InsertCommand.Parameters(5).Value = CType(Track.Value, Short)
		Else
			ffita.Adapter.InsertCommand.Parameters(5).Value = Global.System.DBNull.Value
		End If
		If (Index.HasValue = True) Then
			ffita.Adapter.InsertCommand.Parameters(6).Value = CType(Index.Value, Byte)
		Else
			ffita.Adapter.InsertCommand.Parameters(6).Value = Global.System.DBNull.Value
		End If
		If (Category Is Nothing) Then
			ffita.Adapter.InsertCommand.Parameters(7).Value = Global.System.DBNull.Value
		Else
			ffita.Adapter.InsertCommand.Parameters(7).Value = CType(Category, String)
		End If
		If (SubCategory Is Nothing) Then
			ffita.Adapter.InsertCommand.Parameters(8).Value = Global.System.DBNull.Value
		Else
			ffita.Adapter.InsertCommand.Parameters(8).Value = CType(SubCategory, String)
		End If
		If (Description Is Nothing) Then
			ffita.Adapter.InsertCommand.Parameters(9).Value = Global.System.DBNull.Value
		Else
			ffita.Adapter.InsertCommand.Parameters(9).Value = CType(Description, String)
		End If
		If (Time Is Nothing) Then
			ffita.Adapter.InsertCommand.Parameters(10).Value = Global.System.DBNull.Value
		Else
			ffita.Adapter.InsertCommand.Parameters(10).Value = CType(Time, String)
		End If
		If (Rating.HasValue = True) Then
			ffita.Adapter.InsertCommand.Parameters(11).Value = CType(Rating.Value, Byte)
		Else
			ffita.Adapter.InsertCommand.Parameters(11).Value = Global.System.DBNull.Value
		End If
		If (Filename Is Nothing) Then
			ffita.Adapter.InsertCommand.Parameters(12).Value = Global.System.DBNull.Value
		Else
			ffita.Adapter.InsertCommand.Parameters(12).Value = CType(Filename, String)
		End If
		If (Tags Is Nothing) Then
			ffita.Adapter.InsertCommand.Parameters(13).Value = Global.System.DBNull.Value
		Else
			ffita.Adapter.InsertCommand.Parameters(13).Value = CType(Tags, String)
		End If
		Dim returnValue As Integer = ffita.Adapter.InsertCommand.ExecuteNonQuery
		Return returnValue
	End Function

	Public Overridable Overloads Function DeleteRecord(ByVal ID As Integer) As Integer
		fta.Adapter.DeleteCommand.Parameters(0).Value = CType(ID, Integer)
		Dim returnValue As Integer = fta.Adapter.DeleteCommand.ExecuteNonQuery
		Return returnValue
	End Function

	Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
		ClearData()
		MessageBox.Show("Successfully cleared data")
	End Sub

	Private Sub RetrieveNumberOfFiles()
		Dim qt As New SoundsDataSetTableAdapters.QueriesTableAdapter
		Dim s As Integer? = qt.NumberOfFiles()
		If s.HasValue AndAlso s.Value > 0 Then
			lblNoOfFiles.Text = s.ToString() & " records in DB"
		Else
			lblNoOfFiles.Text = "Empty DB"
		End If
	End Sub
End Class