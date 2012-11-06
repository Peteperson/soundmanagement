Imports FileHelpers
Imports System.Text
Imports System.IO
Imports System.Data.OleDb
Imports System.Deployment.Application
Imports NAudio.Wave
Imports NAudio.Wave.Compression
Imports WavLib

Public Class SoundsMng
	Private TmpWavFile0 As String = My.Application.Info.DirectoryPath & "\tmp0.wav"
	Private TmpWavFile1 As String = My.Application.Info.DirectoryPath & "\tmp1.wav"
	Private TmpWavFile2 As String = My.Application.Info.DirectoryPath & "\tmp2.wav"

	Private Property _CopyPreviousFolder As String
	Public Property CopyPreviousFolder As String
		Get
			Return _CopyPreviousFolder
		End Get
		Set(value As String)
			_CopyPreviousFolder = value
			CopyToPreviousFolderToolStripMenuItem1.Enabled = True
		End Set
	End Property

	Private ReadOnly Property DataPath As String
		Get
			If (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) Then
				Return Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory
			Else
				Return My.Application.Info.DirectoryPath
			End If
		End Get
	End Property

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
		If Not wv.WaveStream Is Nothing Then wv.WaveStream.Dispose()
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

	Private Sub SoundsMng_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
		Dim ver As String
		If ApplicationDeployment.IsNetworkDeployed Then
			ver = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
		Else
			ver = Application.ProductVersion
		End If

		Me.Text = "Sounds management application - (Version: " & ver & ")"
		wmp.uiMode = "mini"
		wmp.settings.autoStart = True
		btnHideNotExFiles.BackColor = Color.Lime
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
			For i As Integer = 0 To SoundsGrid.Columns.Count - 1
				SoundsGrid.Columns(i).Visible = cols(i).Split(";")(0) = "1"
				SoundsGrid.Columns(i).Width = cols(i).Split(";")(1)
			Next
		End If
	End Sub

	Private Sub PlaySound()
		wmp.currentPlaylist.clear()
		For Each r In SoundsGrid.SelectedRows
			Dim ret = CheckIfFileExists(r.DataBoundItem)
			If ret.FileFound Then
				wmp.currentPlaylist.appendItem(wmp.newMedia(ret.FilePath))
			Else
				WriteToLogFile("File: " & ret.FilePath & " does not exist", True)
			End If
		Next
		wmp.Ctlcontrols.play()
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
			RetrieveNumberOfFiles()
		Catch ex As Exception
			WriteToLogFile(ex.Message, True)
		Finally
			Me.Cursor = Cursors.Default
		End Try
	End Sub

	Private Sub SoundsGrid_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles SoundsGrid.DoubleClick
		PlaySound()
	End Sub

	Private Sub ToolStripFilter_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles ToolStripFilter.KeyDown
		TimerSearch.Enabled = False
	End Sub

	Private Sub ToolStripFilter_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles ToolStripFilter.KeyUp
		Dim EmptyChars As List(Of Keys) = New List(Of Keys) From {Keys.Apps, Keys.NumLock, Keys.Menu, Keys.Tab, Keys.ShiftKey, Keys.CapsLock, Keys.ControlKey}
		If Not EmptyChars.Contains(e.KeyCode) Then
			TimerSearch.Enabled = True
		End If
	End Sub

	Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TimerSearch.Tick
		FillGrid()
		TimerSearch.Enabled = False
	End Sub

	Private Sub SoundsMng_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
		ToolStripFilter.Focus()
	End Sub

	Private Sub btnSetLibPath_Click(sender As Object, e As EventArgs) Handles btnSetLibPath.Click
		_FilesPath = ""
		Dim s As String = FilesPath(False)
	End Sub

	Private Sub btnImportData_Click(sender As Object, e As EventArgs) Handles btnImportData.Click
		OpenFileDialog1.Filter = "tsv files (*.tab)|*.tab|All files (*.*)|*.*"
		OpenFileDialog1.FilterIndex = 0
		OpenFileDialog1.Multiselect = True
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
						ExecuteQueries(Not (OpenFileDialog1.FileNames.Count > 1))
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
			End Try
		End If
	End Sub

	Private Sub WriteToLogFile(msg As String, Optional ShowMessage As Boolean = False)
		If ShowMessage Then MessageBox.Show(msg)
		File.AppendAllText(My.Application.Info.DirectoryPath & "\LogFile.txt", Date.Now.ToString("dd/MM/yyyy HH:mm:ss") & " = " & msg & Environment.NewLine)
	End Sub

	Private Sub btnPlaySound_Click(sender As Object, e As EventArgs)
		PlaySound()
	End Sub

	Private ChangedColunmSettings As Boolean = False
	Private Sub btnManageColumns_Click(sender As Object, e As EventArgs) Handles btnManageColumns.Click
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

	Private Sub SoundsGrid_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles SoundsGrid.CellEndEdit
		Dim NewValue = SoundsGrid.CurrentCell.Value.ToString
		If NewValue <> OldValue Then
			Dim pt As New SoundsDataSetTableAdapters.FilesTableAdapter
			Dim dgc1 As String = SoundsGrid("Rating", e.RowIndex).Value.ToString
			Dim dgc2 As String = SoundsGrid("Tags", e.RowIndex).Value.ToString
			Dim dgc3 As String = SoundsGrid("ID", e.RowIndex).Value.ToString
			pt.Update(dgc1, dgc2, dgc3)
		End If
	End Sub

	Private Sub ExecuteQueries(ShowResults As Boolean)
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
		WriteToLogFile("Imported " & tmpRet & " Files", ShowResults)
		tmpRet = qry.DeleteFilesForImport
		WriteToLogFile("Deleted " & tmpRet & " imported records", False)
	End Sub

	Private Sub ClearData()
		Dim qry As New SoundsDataSetTableAdapters.QueriesTableAdapter
		Me.Cursor = Cursors.WaitCursor
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
		Me.Cursor = Cursors.Default
	End Sub

	Private ffita As New SoundsDataSetTableAdapters.FilesForImportTableAdapter
	Private fta As New SoundsDataSetTableAdapters.FilesTableAdapter
	Private Sub ImportFiles(res As SoundRecord(), fname As String)
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

	Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
		Dim HeaderNames() As String = {"Creator", "Library", "Year", "CD", "Track", "Index", "Category", "SubCategory", "Description", "Time", "Rating", "Filename", "Tags"} ' "FileExists" ?
		SaveFileDialog1.Filter = "Tab Files (*.tab)|*.tab|All Files (*.*)|*.*"
		SaveFileDialog1.FilterIndex = 0
		If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
			Dim ft As New SoundsDataSetTableAdapters.FilesJoinedNewTableAdapter
			Dim dt As SoundsDataSet.FilesJoinedNewDataTable
			Me.Cursor = Cursors.WaitCursor
			dt = ft.GetDataBy()
			prgBar.Maximum = dt.Rows.Count
			prgBar.Value = 0
			Dim str As StringBuilder = New StringBuilder()
			For Each s In HeaderNames
				str.Append(s & vbTab)
			Next
			str.Append(Environment.NewLine)
			For i As Integer = 0 To dt.Rows.Count - 1
				For j As Integer = 0 To HeaderNames.Length - 1
					str.Append(dt.Rows(i)(HeaderNames(j)).ToString())
					If j < HeaderNames.Length - 1 Then str.Append(vbTab)
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

	Private Sub lstNoOfSelRecs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNoOfSelRecs.SelectedIndexChanged
		Dim prevval As String = FilesJoinedNewTableAdapter.Adapter.SelectCommand.CommandText
		Dim newval As String = FilesJoinedNewTableAdapter.Adapter.SelectCommand.CommandText
		Dim regex As New RegularExpressions.Regex("SELECT.+Files\.ID")
		Select Case lstNoOfSelRecs.SelectedIndex
			Case 0
				newval = regex.Replace(prevval, "SELECT TOP 50 Files.ID")
			Case 1
				newval = regex.Replace(prevval, "SELECT TOP 500 Files.ID")
			Case 2
				newval = regex.Replace(prevval, "SELECT Files.ID")
		End Select
		If prevval <> newval Then
			FilesJoinedNewTableAdapter.Adapter.SelectCommand.CommandText = newval
			FillGrid()
		End If
	End Sub

	Private Sub btnPath_Click(sender As Object, e As EventArgs) Handles btnPath.Click
		Process.Start(My.Application.Info.DirectoryPath)
		Process.Start(Me.DataPath)
	End Sub

	Private Sub SoundsGrid_KeyUp(sender As Object, e As KeyEventArgs) Handles SoundsGrid.KeyUp
		Select Case e.KeyCode
			Case Keys.Home
				ToolStripFilter.Focus()
			Case 46 Or 8
				DeleteSelectedRecords()
			Case 32
				PlaySound()
			Case 107
				EditRecords()
		End Select
	End Sub

	Private Sub DeleteSelectedRecords()
		If SoundsGrid.SelectedRows.Count > 0 AndAlso MessageBox.Show("Really delete those records ?", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.Yes Then
			prgBar.Maximum = SoundsGrid.SelectedRows.Count
			prgBar.Value = 0
			fta.Adapter.DeleteCommand.Connection.Open()
			Dim id As Integer
			Dim pt As New SoundsDataSetTableAdapters.FilesTableAdapter
			For Each row In SoundsGrid.SelectedRows
				id = Integer.Parse(SoundsGrid("ID", row.Index).Value.ToString())
				DeleteRecord(id)
				prgBar.Value += 1
			Next
			fta.Adapter.DeleteCommand.Connection.Close()
			FillGrid()
			prgBar.Value = 0
		End If
	End Sub

	Private Sub btnTags_Click(sender As Object, e As EventArgs) Handles btnTags.Click
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

	Private Sub ExportNotExFiles()
		SaveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
		SaveFileDialog1.FilterIndex = 0
		If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
			Dim fname As String = SaveFileDialog1.FileName
			Dim finalText As New StringBuilder
			Dim count As Integer = 0
			Dim tr As DataGridViewRow

			prgBar.Maximum = SoundsGrid.Rows.Count
			prgBar.Value = 0
			finalText.Append("Exporting not existing files" & Environment.NewLine)
			finalText.Append(DateTime.Now.ToString("dd/MM/yyyy HH:mm") & Environment.NewLine)
			finalText.Append("FileNames:" & Environment.NewLine)
			For Each tr In SoundsGrid.Rows
				prgBar.Value += 1
				Dim ret = CheckIfFileExists(tr.DataBoundItem)
				If Not ret.FileFound Then
					count += 1
					finalText.Append(count.ToString() & ") " & ret.FilePath & Environment.NewLine)
				End If
			Next
			File.WriteAllText(fname, finalText.ToString())
			prgBar.Value = 0
			MessageBox.Show("From " & SoundsGrid.Rows.Count & " files shown in DataGrid, " & count & " do not exist.")
		End If
	End Sub

	Private Sub SoundsGrid_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles SoundsGrid.RowPrePaint
		If Not (SoundsGrid.Rows(e.RowIndex).DataBoundItem).Row.FileExists Then
			SoundsGrid.Rows(e.RowIndex).DefaultCellStyle.Font = New Font(Me.Font, FontStyle.Italic)
			SoundsGrid.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.FromArgb(90, 80, 80)
		End If
	End Sub

	Private Sub btnEditRecs_Click(sender As Object, e As EventArgs) Handles btnEditRecs.Click
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

	Public Function DeleteRecord(ByVal ID As Integer) As Integer
		fta.Adapter.DeleteCommand.Parameters(0).Value = CType(ID, Integer)
		Dim returnValue As Integer = fta.Adapter.DeleteCommand.ExecuteNonQuery
		Return returnValue
	End Function

	Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
		ClearData()
		MessageBox.Show("Successfully cleared data")
	End Sub

	Private Sub RetrieveNumberOfFiles()
		Dim qt As New SoundsDataSetTableAdapters.QueriesTableAdapter
		Dim s As Integer? = qt.NumberOfFiles()
		If s.HasValue AndAlso s.Value > 0 Then
			lblNoOfFiles.Text = "Showing " & SoundsGrid.RowCount & " from " & s.ToString() & " records in DB"
		Else
			lblNoOfFiles.Text = "Empty DB"
		End If
	End Sub

	Private Sub btnDeleteFiles_Click(sender As Object, e As EventArgs) Handles btnDeleteFiles.Click
		If MessageBox.Show("Really delete all files ???", "LOOK OUT", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
			Dim qry As New SoundsDataSetTableAdapters.QueriesTableAdapter
			Dim tmpRet As Integer
			WriteToLogFile("Deleting all records in table Files", False)
			tmpRet = qry.DeleteFiles
			WriteToLogFile("Deleted " & tmpRet & " files", False)
			FillGrid()
		End If
	End Sub

	Private Sub CompactDatabase()
		Dim jro As New JRO.JetEngine
		Dim datapath As String
		If (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) Then
			datapath = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory
		Else
			datapath = My.Application.Info.DirectoryPath
		End If
		jro.CompactDatabase("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & datapath & "\Sounds.accdb;Persist Security Info=True",
		  "Provider=Microsoft.ACE.OLEDB.12.0;Data Source==" & datapath & "\Sounds1.accdb;Persist Security Info=True")

		MsgBox("Database compacted successfully")
	End Sub

	Private Sub btnCompact_Click(sender As Object, e As EventArgs) Handles btnCompact.Click
		Process.Start(DataPath & "\Sounds.accdb")
	End Sub

	Private Sub EditFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditFilesToolStripMenuItem.Click
		EditRecords()
	End Sub

	Private Sub DeleteFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteFileToolStripMenuItem.Click
		DeleteSelectedRecords()
	End Sub

	Private Sub OpenFileLocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFileLocationToolStripMenuItem.Click
		OpenFilesLocation()
	End Sub

	Private Sub OpenFilesLocation()
		For Each r In SoundsGrid.SelectedRows
			Dim ret = CheckIfFileExists(r.DataBoundItem)
			If ret.FileFound Then
				Process.Start(Path.GetDirectoryName(ret.FilePath))
			End If
		Next
	End Sub

	Private Function ExtractFolderFromFname(fname As String) As String
		Dim pos As Integer = fname.LastIndexOfAny("\/".ToCharArray())
		If pos > 0 Then
			Return "\" & fname.Substring(0, pos)
		End If
		Return ""
	End Function

	Private Sub CopyToFolderToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CopyToFolderToolStripMenuItem1.Click
		If FolderBrowserDialog1.ShowDialog = vbOK Then
			CopyPreviousFolder = FolderBrowserDialog1.SelectedPath
			CopyFilesToPreviousFolder()
		End If
	End Sub

	Private Sub CopyToPreviousFolderToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CopyToPreviousFolderToolStripMenuItem1.Click
		CopyFilesToPreviousFolder()
	End Sub

	Private Sub CopyFilesToPreviousFolder()
		Dim DestFile As String
		For Each r In SoundsGrid.SelectedRows
			Dim ret = CheckIfFileExists(r.DataBoundItem)
			If ret.FileFound Then
				DestFile = CopyPreviousFolder & "\" & Path.GetFileName(ret.FilePath)
				If Not My.Computer.FileSystem.FileExists(DestFile) Then
					File.Copy(ret.FilePath, DestFile) 'CopyPreviousFolder & "\" & Path.GetFileName(DestFile))
				End If
			End If
		Next
	End Sub

	Private Sub TimerWMP_Tick(sender As Object, e As EventArgs) Handles TimerWMP.Tick
		ShowCurrentMediaPosition()
	End Sub

	Private WriteOnly Property InvalidWaveFileLabel As String
		Set(value As String)
			If value = String.Empty Then
				lblInvWvFile.Visible = False
				pbEmptyWaveView.Visible = False
				wv.Visible = True
			Else
				wv.Visible = False
				pbEmptyWaveView.Visible = True
				lblInvWvFile.Visible = True
				lblInvWvFile.Text = value
			End If
		End Set
	End Property

	Private Function CheckBitPerSample(fileName As String) As WAVFormat
		Dim ffile = TmpWavFile1
		If fileName <> TmpWavFile1 Then
			File.Copy(fileName, TmpWavFile2, True)
			File.SetAttributes(TmpWavFile2, FileAttributes.Normal)
			ffile = TmpWavFile2
		End If
		Try
			If Not WavLib.WAVFile.IsWaveFile(ffile) Then
				InvalidWaveFileLabel = "Cannot draw waveform. Invalid WAV file"
				Return Nothing
			Else
				InvalidWaveFileLabel = String.Empty
			End If
			Dim ret = WavLib.WAVFile.GetAudioFormat(ffile)
			Return ret
		Catch ex As Exception
			WriteToLogFile(ex.Message, True)
			Return Nothing
		End Try
	End Function

	Private Sub DrawWaveForm()
		If Not wv.WaveStream Is Nothing Then wv.WaveStream.Dispose()
		Dim ws As WaveStream
		Dim wf As WAVFormat
		Dim fileName As String
		Select Case Path.GetExtension(wmp.currentMedia.sourceURL)
			Case ".mp3"
				fileName = TmpWavFile1
				ConvertMp3ToWav(wmp.currentMedia.sourceURL)
			Case ".wav"
				fileName = wmp.currentMedia.sourceURL
			Case ".aif"
				fileName = TmpWavFile1
				ConvertAifToWav(wmp.currentMedia.sourceURL)
			Case Else
				fileName = TmpWavFile0
				InvalidWaveFileLabel = "Not accepted audio file extension"
		End Select
		wf = CheckBitPerSample(fileName)
		If wf = Nothing Or wf.BitsPerSample > 16 Then
			fileName = TmpWavFile0
			InvalidWaveFileLabel = "Preview is not available"
			wf.SampleRateHz = 10000
		End If
		ws = New NAudio.Wave.WaveFileReader(fileName)
		wv.SamplesPerPixel = (wmp.currentMedia.duration * wf.SampleRateHz) / wv.Size.Width
		wv.WaveStream = ws
	End Sub

	Private Sub ConvertAifToWav(aifFile As String)
		If File.Exists(TmpWavFile1) Then
			Try
				File.Delete(TmpWavFile1)
			Catch ex As Exception
				WriteToLogFile(ex.Message, True)
			End Try
		End If
		Using reader As New AiffFileReader(aifFile)
			Using pcmStream As WaveStream = WaveFormatConversionStream.CreatePcmStream(reader)
				WaveFileWriter.CreateWaveFile(TmpWavFile1, pcmStream)
			End Using
		End Using
	End Sub

	Private Sub ConvertMp3ToWav(mp3file As String)
		If File.Exists(TmpWavFile1) Then
			Try
				File.Delete(TmpWavFile1)
			Catch ex As Exception
				WriteToLogFile(ex.Message, True)
			End Try
		End If
		Using reader As New Mp3FileReader(mp3file)
			Using pcmStream As WaveStream = WaveFormatConversionStream.CreatePcmStream(reader)
				WaveFileWriter.CreateWaveFile(TmpWavFile1, pcmStream)
			End Using
		End Using
	End Sub

	Private Sub ShowCurrentMediaPosition()
		If Not wmp.currentMedia Is Nothing Then
			lblMediaPosition.Text = "File playing: " & wmp.currentMedia.name & " (" & _
			 wmp.Ctlcontrols.currentPositionString & "/" & wmp.currentMedia.durationString & ")"
			lblInvWvFile.Left = lblMediaPosition.Right + 5
		End If
	End Sub

	Private Sub PlaySelectedFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlaySelectedFilesToolStripMenuItem.Click
		PlaySound()
	End Sub

	Private Sub btnExpNotExFiles_Click(sender As Object, e As EventArgs) Handles btnExpNotExFiles.Click
		ExportNotExFiles()
	End Sub

	Private Sub btnHideNotExFiles_Click(sender As Object, e As EventArgs) Handles btnHideNotExFiles.Click
		Dim val As String = FilesJoinedNewTableAdapter.Adapter.SelectCommand.CommandText
		If btnHideNotExFiles.Checked Then
			val = val.Replace("ORDER BY Files.ID", " AND Files.FileExists <> 0 ORDER BY Files.ID")
		Else
			val = val.Replace("AND Files.FileExists <> 0 ORDER BY Files.ID", "ORDER BY Files.ID")
		End If
		FilesJoinedNewTableAdapter.Adapter.SelectCommand.CommandText = val
		FillGrid()
	End Sub

	Private Function CheckIfFileExists(drv As DataRowView) As FileExistance
		Dim row As SoundsDataSet.FilesJoinedNewRow
		Dim CurrentFile As String
		row = drv.Row
		CurrentFile = FilesPath & "\" & (row.Creator & " - " & row.Library & "\" & row.CD & "\" & row.Filename & ".").Replace("/", "\")
		For Each ext In AudioFileTypes
			If My.Computer.FileSystem.FileExists(CurrentFile & ext) Then
				Return New FileExistance(True, CurrentFile & ext)
			End If
		Next
		Return New FileExistance(False, CurrentFile)
	End Function

	Private Sub wv_MouseClick(sender As System.Object, e As MouseEventArgs) Handles wv.MouseClick
		SetMediaPosition(e)
	End Sub

	Private Sub SetMediaPosition(e As MouseEventArgs)
		If wmp.currentMedia Is Nothing Then Return
		wmp.Ctlcontrols.currentPosition = wmp.currentMedia.duration * (e.X / wv.Size.Width)
		If wmp.status = "Stopped" Or wmp.status = "Paused" Then wmp.Ctlcontrols.play()
	End Sub

	Private Sub wmp_PlayStateChange(sender As System.Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles wmp.PlayStateChange
		If e.newState = 3 Then
			lblMediaPosition.Visible = True
			TimerWMP.Enabled = True
			pbCaret.Visible = True
			TimerCaret.Enabled = True
			Try
				DrawWaveForm()
			Catch ex As WAVFileException
				InvalidWaveFileLabel = "Cannot draw waveform: " & ex.Message
			End Try
		Else
			TimerWMP.Enabled = False
			TimerCaret.Enabled = False
			pbCaret.Visible = False
			ShowCurrentMediaPosition()
		End If
	End Sub

	Private Sub wv_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles wv.KeyDown
		If e.KeyCode = Keys.Home Then
			ToolStripFilter.Focus()
		End If
	End Sub

	Private Sub TimerCaret_Tick(sender As System.Object, e As System.EventArgs) Handles TimerCaret.Tick
		If Not wmp.currentMedia Is Nothing Then
			pbCaret.Left = (wmp.Ctlcontrols.currentPosition / wmp.currentMedia.duration) * wv.Size.Width
		End If
	End Sub

	Private Sub wmp_KeyDownEvent(sender As System.Object, e As AxWMPLib._WMPOCXEvents_KeyDownEvent) Handles wmp.KeyDownEvent
		If e.nKeyCode = Keys.Home Then
			ToolStripFilter.Focus()
		End If
	End Sub

	Private Sub btnHideNotExFiles_CheckStateChanged(sender As System.Object, e As System.EventArgs) Handles btnHideNotExFiles.CheckStateChanged
		btnHideNotExFiles.BackColor = Color.Lime
	End Sub

	Private Sub btnUpdateExistance_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdateExistance.Click
		Me.Cursor = Cursors.WaitCursor
		prgBar.Maximum = SoundsGrid.RowCount
		prgBar.Value = 0
		Dim fileexists As FileExistance
		Dim tr As DataGridViewRow
		Try
			If ((fta.CommandCollection(1).Connection.State And Global.System.Data.ConnectionState.Open) _
			  <> Global.System.Data.ConnectionState.Open) Then
				fta.CommandCollection(1).Connection.Open()
			End If

			For Each tr In SoundsGrid.Rows
				prgBar.Value += 1
				fileexists = CheckIfFileExists(tr.DataBoundItem)
				Dim row As SoundsDataSet.FilesJoinedNewRow
				row = tr.DataBoundItem.Row
				If fileexists.FileFound <> row.FileExists Then
					UpdateExistance(fileexists.FileFound, row.ID)
				End If
			Next
		Catch ex As Exception
			WriteToLogFile(ex.Message, True)
		Finally
			If ((fta.CommandCollection(1).Connection.State And Global.System.Data.ConnectionState.Open) _
			  = Global.System.Data.ConnectionState.Open) Then
				fta.CommandCollection(1).Connection.Close()
			End If
		End Try

		prgBar.Value = 0
		Me.Cursor = Cursors.Default
		MessageBox.Show("Files' existence completed")
		FillGrid()
	End Sub

	Public Function UpdateExistance(ByVal FileExists As Boolean, ByVal Original_ID As Integer) As Integer
		Dim command As Global.System.Data.OleDb.OleDbCommand = fta.CommandCollection(1)
		command.Parameters(0).Value = CType(FileExists, Boolean)
		command.Parameters(1).Value = CType(Original_ID, Integer)
		Dim returnValue As Integer
		returnValue = command.ExecuteNonQuery
		Return returnValue
	End Function

	Private Sub pbEmptyWaveView_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles pbEmptyWaveView.MouseClick
		SetMediaPosition(e)
	End Sub
End Class