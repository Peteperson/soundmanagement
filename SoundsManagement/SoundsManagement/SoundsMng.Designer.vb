<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SoundsMng
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SoundsMng))
		Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
		Me.TimerSearch = New System.Windows.Forms.Timer(Me.components)
		Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
		Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel()
		Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel()
		Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel()
		Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel()
		Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel()
		Me.SoundsGrid = New System.Windows.Forms.DataGridView()
		Me.cntxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.DeleteFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.OpenFileLocationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.EditFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.CopyToFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.CopyToFolderToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.CopyToPreviousFolderToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.PlaySelectedFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
		Me.lblMediaPosition = New System.Windows.Forms.Label()
		Me.TimerWMP = New System.Windows.Forms.Timer(Me.components)
		Me.wmp = New AxWMPLib.AxWindowsMediaPlayer()
		Me.FilesJoinedNewBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
		Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
		Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
		Me.ToolStripFilter = New System.Windows.Forms.ToolStripTextBox()
		Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
		Me.lstNoOfSelRecs = New System.Windows.Forms.ToolStripComboBox()
		Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
		Me.btnPath = New System.Windows.Forms.ToolStripButton()
		Me.btnCompact = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		Me.btnSetLibPath = New System.Windows.Forms.ToolStripButton()
		Me.btnManageColumns = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.prgBar = New System.Windows.Forms.ToolStripProgressBar()
		Me.btnExport = New System.Windows.Forms.ToolStripButton()
		Me.btnImportData = New System.Windows.Forms.ToolStripButton()
		Me.btnTags = New System.Windows.Forms.ToolStripButton()
		Me.btnEditRecs = New System.Windows.Forms.ToolStripButton()
		Me.btnClear = New System.Windows.Forms.ToolStripButton()
		Me.lblNoOfFiles = New System.Windows.Forms.ToolStripLabel()
		Me.btnDeleteFiles = New System.Windows.Forms.ToolStripButton()
		Me.btnExpNotExFiles = New System.Windows.Forms.ToolStripButton()
		Me.btnHideNotExFiles = New System.Windows.Forms.ToolStripButton()
		Me.wv = New NAudio.Gui.WaveViewer()
		Me.pbCaret = New System.Windows.Forms.PictureBox()
		Me.TimerCaret = New System.Windows.Forms.Timer(Me.components)
		Me.FilesJoinedNewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.SoundsDataSet = New SoundsManagement.SoundsDataSet()
		Me.FilesJoinedNewTableAdapter = New SoundsManagement.SoundsDataSetTableAdapters.FilesJoinedNewTableAdapter()
		Me.TableAdapterManager = New SoundsManagement.SoundsDataSetTableAdapters.TableAdapterManager()
		Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Creator = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Library = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.CD = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Year = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Track = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Index = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.SubCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Time = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Rating = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Tags = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Filename = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.FileExists = New System.Windows.Forms.DataGridViewCheckBoxColumn()
		CType(Me.SoundsGrid, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.cntxMenu.SuspendLayout()
		CType(Me.wmp, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.FilesJoinedNewBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FilesJoinedNewBindingNavigator.SuspendLayout()
		CType(Me.pbCaret, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.FilesJoinedNewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.SoundsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'TimerSearch
		'
		Me.TimerSearch.Interval = 500
		'
		'OpenFileDialog1
		'
		Me.OpenFileDialog1.FileName = "OpenFileDialog1"
		'
		'BottomToolStripPanel
		'
		Me.BottomToolStripPanel.Location = New System.Drawing.Point(0, 0)
		Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
		Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
		Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
		Me.BottomToolStripPanel.Size = New System.Drawing.Size(0, 0)
		'
		'TopToolStripPanel
		'
		Me.TopToolStripPanel.Location = New System.Drawing.Point(0, 0)
		Me.TopToolStripPanel.Name = "TopToolStripPanel"
		Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
		Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
		Me.TopToolStripPanel.Size = New System.Drawing.Size(0, 0)
		'
		'RightToolStripPanel
		'
		Me.RightToolStripPanel.Location = New System.Drawing.Point(0, 0)
		Me.RightToolStripPanel.Name = "RightToolStripPanel"
		Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
		Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
		Me.RightToolStripPanel.Size = New System.Drawing.Size(0, 0)
		'
		'LeftToolStripPanel
		'
		Me.LeftToolStripPanel.Location = New System.Drawing.Point(0, 0)
		Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
		Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
		Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
		Me.LeftToolStripPanel.Size = New System.Drawing.Size(0, 0)
		'
		'ContentPanel
		'
		Me.ContentPanel.Size = New System.Drawing.Size(150, 175)
		'
		'SoundsGrid
		'
		Me.SoundsGrid.AllowUserToAddRows = False
		Me.SoundsGrid.AllowUserToDeleteRows = False
		Me.SoundsGrid.AllowUserToOrderColumns = True
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(255, Byte), Integer))
		Me.SoundsGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
		Me.SoundsGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
				  Or System.Windows.Forms.AnchorStyles.Left) _
				  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.SoundsGrid.AutoGenerateColumns = False
		DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
		DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.SoundsGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
		Me.SoundsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.SoundsGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Creator, Me.Library, Me.CD, Me.Year, Me.Track, Me.Index, Me.Category, Me.SubCategory, Me.Description, Me.Time, Me.Rating, Me.Tags, Me.Filename, Me.FileExists})
		Me.SoundsGrid.ContextMenuStrip = Me.cntxMenu
		Me.SoundsGrid.DataSource = Me.FilesJoinedNewBindingSource
		DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
		DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
		DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.SoundsGrid.DefaultCellStyle = DataGridViewCellStyle3
		Me.SoundsGrid.Location = New System.Drawing.Point(7, 35)
		Me.SoundsGrid.Name = "SoundsGrid"
		DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
		DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.SoundsGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
		Me.SoundsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.SoundsGrid.Size = New System.Drawing.Size(753, 452)
		Me.SoundsGrid.TabIndex = 2
		'
		'cntxMenu
		'
		Me.cntxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteFileToolStripMenuItem, Me.OpenFileLocationToolStripMenuItem, Me.EditFilesToolStripMenuItem, Me.CopyToFolderToolStripMenuItem, Me.PlaySelectedFilesToolStripMenuItem})
		Me.cntxMenu.Name = "cntxMenu"
		Me.cntxMenu.Size = New System.Drawing.Size(187, 114)
		'
		'DeleteFileToolStripMenuItem
		'
		Me.DeleteFileToolStripMenuItem.Image = Global.SoundsManagement.My.Resources.Resources.Remove
		Me.DeleteFileToolStripMenuItem.Name = "DeleteFileToolStripMenuItem"
		Me.DeleteFileToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
		Me.DeleteFileToolStripMenuItem.Text = "Delete File(s)"
		'
		'OpenFileLocationToolStripMenuItem
		'
		Me.OpenFileLocationToolStripMenuItem.Image = Global.SoundsManagement.My.Resources.Resources.system_file_manager
		Me.OpenFileLocationToolStripMenuItem.Name = "OpenFileLocationToolStripMenuItem"
		Me.OpenFileLocationToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
		Me.OpenFileLocationToolStripMenuItem.Text = "Open File(s) Location"
		'
		'EditFilesToolStripMenuItem
		'
		Me.EditFilesToolStripMenuItem.Image = Global.SoundsManagement.My.Resources.Resources.page_edit
		Me.EditFilesToolStripMenuItem.Name = "EditFilesToolStripMenuItem"
		Me.EditFilesToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
		Me.EditFilesToolStripMenuItem.Text = "Edit File(s)"
		'
		'CopyToFolderToolStripMenuItem
		'
		Me.CopyToFolderToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToFolderToolStripMenuItem1, Me.CopyToPreviousFolderToolStripMenuItem1})
		Me.CopyToFolderToolStripMenuItem.Image = Global.SoundsManagement.My.Resources.Resources.copy
		Me.CopyToFolderToolStripMenuItem.Name = "CopyToFolderToolStripMenuItem"
		Me.CopyToFolderToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
		Me.CopyToFolderToolStripMenuItem.Text = "Copy"
		'
		'CopyToFolderToolStripMenuItem1
		'
		Me.CopyToFolderToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.CopyToFolderToolStripMenuItem1.Name = "CopyToFolderToolStripMenuItem1"
		Me.CopyToFolderToolStripMenuItem1.Size = New System.Drawing.Size(198, 22)
		Me.CopyToFolderToolStripMenuItem1.Text = "Copy to folder..."
		'
		'CopyToPreviousFolderToolStripMenuItem1
		'
		Me.CopyToPreviousFolderToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.CopyToPreviousFolderToolStripMenuItem1.Enabled = False
		Me.CopyToPreviousFolderToolStripMenuItem1.Name = "CopyToPreviousFolderToolStripMenuItem1"
		Me.CopyToPreviousFolderToolStripMenuItem1.Size = New System.Drawing.Size(198, 22)
		Me.CopyToPreviousFolderToolStripMenuItem1.Text = "Copy to previous folder"
		'
		'PlaySelectedFilesToolStripMenuItem
		'
		Me.PlaySelectedFilesToolStripMenuItem.Image = Global.SoundsManagement.My.Resources.Resources.PlayNormal
		Me.PlaySelectedFilesToolStripMenuItem.Name = "PlaySelectedFilesToolStripMenuItem"
		Me.PlaySelectedFilesToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
		Me.PlaySelectedFilesToolStripMenuItem.Text = "Play selected file(s)"
		'
		'lblMediaPosition
		'
		Me.lblMediaPosition.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.lblMediaPosition.AutoSize = True
		Me.lblMediaPosition.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(235, Byte), Integer))
		Me.lblMediaPosition.ForeColor = System.Drawing.Color.White
		Me.lblMediaPosition.Location = New System.Drawing.Point(18, 553)
		Me.lblMediaPosition.Name = "lblMediaPosition"
		Me.lblMediaPosition.Size = New System.Drawing.Size(65, 13)
		Me.lblMediaPosition.TabIndex = 5
		Me.lblMediaPosition.Text = "File playing: "
		'
		'TimerWMP
		'
		Me.TimerWMP.Interval = 500
		'
		'wmp
		'
		Me.wmp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.wmp.Enabled = True
		Me.wmp.Location = New System.Drawing.Point(602, 534)
		Me.wmp.Name = "wmp"
		Me.wmp.OcxState = CType(resources.GetObject("wmp.OcxState"), System.Windows.Forms.AxHost.State)
		Me.wmp.Size = New System.Drawing.Size(158, 34)
		Me.wmp.TabIndex = 8
		'
		'FilesJoinedNewBindingNavigator
		'
		Me.FilesJoinedNewBindingNavigator.AddNewItem = Nothing
		Me.FilesJoinedNewBindingNavigator.AutoSize = False
		Me.FilesJoinedNewBindingNavigator.BackColor = System.Drawing.Color.Transparent
		Me.FilesJoinedNewBindingNavigator.BackgroundImage = Global.SoundsManagement.My.Resources.Resources.BlackBG
		Me.FilesJoinedNewBindingNavigator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.FilesJoinedNewBindingNavigator.BindingSource = Me.FilesJoinedNewBindingSource
		Me.FilesJoinedNewBindingNavigator.CountItem = Me.BindingNavigatorCountItem
		Me.FilesJoinedNewBindingNavigator.CountItemFormat = "{0} records"
		Me.FilesJoinedNewBindingNavigator.DeleteItem = Nothing
		Me.FilesJoinedNewBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripFilter, Me.ToolStripLabel2, Me.lstNoOfSelRecs, Me.BindingNavigatorSeparator1, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.btnPath, Me.btnCompact, Me.ToolStripSeparator2, Me.btnSetLibPath, Me.btnManageColumns, Me.ToolStripSeparator1, Me.prgBar, Me.btnExport, Me.btnImportData, Me.btnTags, Me.btnEditRecs, Me.btnClear, Me.lblNoOfFiles, Me.btnDeleteFiles, Me.btnExpNotExFiles, Me.btnHideNotExFiles})
		Me.FilesJoinedNewBindingNavigator.Location = New System.Drawing.Point(0, 0)
		Me.FilesJoinedNewBindingNavigator.MoveFirstItem = Nothing
		Me.FilesJoinedNewBindingNavigator.MoveLastItem = Nothing
		Me.FilesJoinedNewBindingNavigator.MoveNextItem = Nothing
		Me.FilesJoinedNewBindingNavigator.MovePreviousItem = Nothing
		Me.FilesJoinedNewBindingNavigator.Name = "FilesJoinedNewBindingNavigator"
		Me.FilesJoinedNewBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
		Me.FilesJoinedNewBindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
		Me.FilesJoinedNewBindingNavigator.Size = New System.Drawing.Size(766, 30)
		Me.FilesJoinedNewBindingNavigator.TabIndex = 0
		Me.FilesJoinedNewBindingNavigator.Text = "BindingNavigator1"
		'
		'BindingNavigatorCountItem
		'
		Me.BindingNavigatorCountItem.ForeColor = System.Drawing.Color.Gainsboro
		Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
		Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(63, 27)
		Me.BindingNavigatorCountItem.Text = "{0} records"
		Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
		Me.BindingNavigatorCountItem.Visible = False
		'
		'ToolStripLabel1
		'
		Me.ToolStripLabel1.ForeColor = System.Drawing.Color.Gainsboro
		Me.ToolStripLabel1.Name = "ToolStripLabel1"
		Me.ToolStripLabel1.Size = New System.Drawing.Size(45, 27)
		Me.ToolStripLabel1.Text = "Search:"
		'
		'ToolStripFilter
		'
		Me.ToolStripFilter.Name = "ToolStripFilter"
		Me.ToolStripFilter.Size = New System.Drawing.Size(200, 30)
		'
		'ToolStripLabel2
		'
		Me.ToolStripLabel2.ForeColor = System.Drawing.Color.Gainsboro
		Me.ToolStripLabel2.Name = "ToolStripLabel2"
		Me.ToolStripLabel2.Size = New System.Drawing.Size(39, 27)
		Me.ToolStripLabel2.Text = "Show:"
		'
		'lstNoOfSelRecs
		'
		Me.lstNoOfSelRecs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.lstNoOfSelRecs.Items.AddRange(New Object() {"TOP 50 records", "TOP 500 records", "ALL records"})
		Me.lstNoOfSelRecs.Name = "lstNoOfSelRecs"
		Me.lstNoOfSelRecs.Size = New System.Drawing.Size(115, 30)
		Me.lstNoOfSelRecs.ToolTipText = "Select the number of displayed records"
		'
		'BindingNavigatorSeparator1
		'
		Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
		Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 30)
		'
		'BindingNavigatorPositionItem
		'
		Me.BindingNavigatorPositionItem.AccessibleName = "Position"
		Me.BindingNavigatorPositionItem.AutoSize = False
		Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
		Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
		Me.BindingNavigatorPositionItem.Text = "0"
		Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
		Me.BindingNavigatorPositionItem.Visible = False
		'
		'btnPath
		'
		Me.btnPath.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.btnPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.btnPath.Image = CType(resources.GetObject("btnPath.Image"), System.Drawing.Image)
		Me.btnPath.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnPath.Name = "btnPath"
		Me.btnPath.Size = New System.Drawing.Size(23, 27)
		Me.btnPath.ToolTipText = "Open application path"
		'
		'btnCompact
		'
		Me.btnCompact.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.btnCompact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.btnCompact.Image = CType(resources.GetObject("btnCompact.Image"), System.Drawing.Image)
		Me.btnCompact.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnCompact.Name = "btnCompact"
		Me.btnCompact.Size = New System.Drawing.Size(23, 27)
		Me.btnCompact.ToolTipText = "Open database"
		'
		'ToolStripSeparator2
		'
		Me.ToolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 30)
		'
		'btnSetLibPath
		'
		Me.btnSetLibPath.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.btnSetLibPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.btnSetLibPath.Image = CType(resources.GetObject("btnSetLibPath.Image"), System.Drawing.Image)
		Me.btnSetLibPath.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnSetLibPath.Name = "btnSetLibPath"
		Me.btnSetLibPath.Size = New System.Drawing.Size(23, 27)
		Me.btnSetLibPath.ToolTipText = "Set library path"
		'
		'btnManageColumns
		'
		Me.btnManageColumns.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.btnManageColumns.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.btnManageColumns.Image = CType(resources.GetObject("btnManageColumns.Image"), System.Drawing.Image)
		Me.btnManageColumns.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnManageColumns.Name = "btnManageColumns"
		Me.btnManageColumns.Size = New System.Drawing.Size(23, 27)
		Me.btnManageColumns.ToolTipText = "Manage grid columns"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 30)
		'
		'prgBar
		'
		Me.prgBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.prgBar.AutoSize = False
		Me.prgBar.Name = "prgBar"
		Me.prgBar.Size = New System.Drawing.Size(100, 23)
		Me.prgBar.Step = 1
		Me.prgBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
		Me.prgBar.ToolTipText = "Import progress"
		'
		'btnExport
		'
		Me.btnExport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
		Me.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnExport.Name = "btnExport"
		Me.btnExport.Size = New System.Drawing.Size(23, 27)
		Me.btnExport.ToolTipText = "Export data to .tab file"
		'
		'btnImportData
		'
		Me.btnImportData.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.btnImportData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.btnImportData.Image = CType(resources.GetObject("btnImportData.Image"), System.Drawing.Image)
		Me.btnImportData.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnImportData.Name = "btnImportData"
		Me.btnImportData.Size = New System.Drawing.Size(23, 27)
		Me.btnImportData.ToolTipText = "Import sounds file"
		'
		'btnTags
		'
		Me.btnTags.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.btnTags.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.btnTags.Image = CType(resources.GetObject("btnTags.Image"), System.Drawing.Image)
		Me.btnTags.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnTags.Name = "btnTags"
		Me.btnTags.Size = New System.Drawing.Size(23, 27)
		Me.btnTags.Text = "Add tags"
		Me.btnTags.Visible = False
		'
		'btnEditRecs
		'
		Me.btnEditRecs.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.btnEditRecs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.btnEditRecs.Image = Global.SoundsManagement.My.Resources.Resources.page_edit
		Me.btnEditRecs.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnEditRecs.Name = "btnEditRecs"
		Me.btnEditRecs.Size = New System.Drawing.Size(23, 27)
		Me.btnEditRecs.Text = "ToolStripButton1"
		Me.btnEditRecs.ToolTipText = "Edit records"
		'
		'btnClear
		'
		Me.btnClear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
		Me.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnClear.Name = "btnClear"
		Me.btnClear.Size = New System.Drawing.Size(23, 27)
		Me.btnClear.Text = "ToolStripButton1"
		Me.btnClear.ToolTipText = "Clear data (archives, libraries, categories...)"
		'
		'lblNoOfFiles
		'
		Me.lblNoOfFiles.ForeColor = System.Drawing.Color.Gainsboro
		Me.lblNoOfFiles.Name = "lblNoOfFiles"
		Me.lblNoOfFiles.Size = New System.Drawing.Size(59, 15)
		Me.lblNoOfFiles.Text = "NoOfFiles"
		'
		'btnDeleteFiles
		'
		Me.btnDeleteFiles.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.btnDeleteFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.btnDeleteFiles.Image = CType(resources.GetObject("btnDeleteFiles.Image"), System.Drawing.Image)
		Me.btnDeleteFiles.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnDeleteFiles.Name = "btnDeleteFiles"
		Me.btnDeleteFiles.Size = New System.Drawing.Size(23, 20)
		Me.btnDeleteFiles.Text = "DeleteFiles"
		'
		'btnExpNotExFiles
		'
		Me.btnExpNotExFiles.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.btnExpNotExFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.btnExpNotExFiles.Image = Global.SoundsManagement.My.Resources.Resources.file_missing
		Me.btnExpNotExFiles.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnExpNotExFiles.Name = "btnExpNotExFiles"
		Me.btnExpNotExFiles.Size = New System.Drawing.Size(23, 20)
		Me.btnExpNotExFiles.ToolTipText = "Export not existing files"
		'
		'btnHideNotExFiles
		'
		Me.btnHideNotExFiles.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.btnHideNotExFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnHideNotExFiles.CheckOnClick = True
		Me.btnHideNotExFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.btnHideNotExFiles.Image = Global.SoundsManagement.My.Resources.Resources.showhide
		Me.btnHideNotExFiles.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnHideNotExFiles.Name = "btnHideNotExFiles"
		Me.btnHideNotExFiles.Size = New System.Drawing.Size(23, 20)
		Me.btnHideNotExFiles.ToolTipText = "Show not existing files"
		'
		'wv
		'
		Me.wv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
				  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.wv.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.wv.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
		Me.wv.BackColor = System.Drawing.Color.Transparent
		Me.wv.BackgroundImage = Global.SoundsManagement.My.Resources.Resources.Box_Blue
		Me.wv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.wv.ForeColor = System.Drawing.Color.Coral
		Me.wv.Location = New System.Drawing.Point(0, 489)
		Me.wv.Name = "wv"
		Me.wv.SamplesPerPixel = 128
		Me.wv.Size = New System.Drawing.Size(601, 81)
		Me.wv.StartPosition = CType(0, Long)
		Me.wv.TabIndex = 6
		Me.wv.WaveStream = Nothing
		'
		'pbCaret
		'
		Me.pbCaret.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.pbCaret.BackColor = System.Drawing.Color.White
		Me.pbCaret.Location = New System.Drawing.Point(1, 492)
		Me.pbCaret.Name = "pbCaret"
		Me.pbCaret.Size = New System.Drawing.Size(2, 75)
		Me.pbCaret.TabIndex = 9
		Me.pbCaret.TabStop = False
		Me.pbCaret.Visible = False
		'
		'TimerCaret
		'
		'
		'FilesJoinedNewBindingSource
		'
		Me.FilesJoinedNewBindingSource.DataMember = "FilesJoinedNew"
		Me.FilesJoinedNewBindingSource.DataSource = Me.SoundsDataSet
		'
		'SoundsDataSet
		'
		Me.SoundsDataSet.DataSetName = "SoundsDataSet"
		Me.SoundsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
		'
		'FilesJoinedNewTableAdapter
		'
		Me.FilesJoinedNewTableAdapter.ClearBeforeFill = True
		'
		'TableAdapterManager
		'
		Me.TableAdapterManager.ArchivesTableAdapter = Nothing
		Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
		Me.TableAdapterManager.CategoriesTableAdapter = Nothing
		Me.TableAdapterManager.CDsTableAdapter = Nothing
		Me.TableAdapterManager.CreatorsTableAdapter = Nothing
		Me.TableAdapterManager.FilesForImportTableAdapter = Nothing
		Me.TableAdapterManager.FilesJoinedNewTableAdapter = Me.FilesJoinedNewTableAdapter
		Me.TableAdapterManager.FilesTableAdapter = Nothing
		Me.TableAdapterManager.LibrariesTableAdapter = Nothing
		Me.TableAdapterManager.ParametersTableAdapter = Nothing
		Me.TableAdapterManager.SubcategoriesTableAdapter = Nothing
		Me.TableAdapterManager.TagsTableAdapter = Nothing
		Me.TableAdapterManager.UpdateOrder = SoundsManagement.SoundsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
		'
		'ID
		'
		Me.ID.DataPropertyName = "ID"
		Me.ID.HeaderText = "ID"
		Me.ID.Name = "ID"
		Me.ID.Width = 52
		'
		'Creator
		'
		Me.Creator.DataPropertyName = "Creator"
		Me.Creator.HeaderText = "Creator"
		Me.Creator.Name = "Creator"
		Me.Creator.ReadOnly = True
		Me.Creator.Width = 51
		'
		'Library
		'
		Me.Library.DataPropertyName = "Library"
		Me.Library.HeaderText = "Library"
		Me.Library.Name = "Library"
		Me.Library.ReadOnly = True
		Me.Library.Width = 52
		'
		'CD
		'
		Me.CD.DataPropertyName = "CD"
		Me.CD.HeaderText = "CD"
		Me.CD.Name = "CD"
		Me.CD.ReadOnly = True
		Me.CD.Width = 52
		'
		'Year
		'
		Me.Year.DataPropertyName = "Year"
		Me.Year.HeaderText = "Year"
		Me.Year.Name = "Year"
		Me.Year.ReadOnly = True
		Me.Year.Width = 51
		'
		'Track
		'
		Me.Track.DataPropertyName = "Track"
		Me.Track.HeaderText = "Track"
		Me.Track.Name = "Track"
		Me.Track.Width = 52
		'
		'Index
		'
		Me.Index.DataPropertyName = "Index"
		Me.Index.HeaderText = "Index"
		Me.Index.Name = "Index"
		'
		'Category
		'
		Me.Category.DataPropertyName = "Category"
		Me.Category.HeaderText = "Category"
		Me.Category.Name = "Category"
		Me.Category.ReadOnly = True
		Me.Category.Width = 52
		'
		'SubCategory
		'
		Me.SubCategory.DataPropertyName = "SubCategory"
		Me.SubCategory.HeaderText = "SubCategory"
		Me.SubCategory.Name = "SubCategory"
		Me.SubCategory.ReadOnly = True
		Me.SubCategory.Width = 52
		'
		'Description
		'
		Me.Description.DataPropertyName = "Description"
		Me.Description.HeaderText = "Description"
		Me.Description.Name = "Description"
		Me.Description.ReadOnly = True
		Me.Description.Width = 51
		'
		'Time
		'
		Me.Time.DataPropertyName = "Time"
		Me.Time.HeaderText = "Time"
		Me.Time.Name = "Time"
		Me.Time.ReadOnly = True
		Me.Time.Width = 52
		'
		'Rating
		'
		Me.Rating.DataPropertyName = "Rating"
		Me.Rating.HeaderText = "Rating"
		Me.Rating.Name = "Rating"
		Me.Rating.Width = 52
		'
		'Tags
		'
		Me.Tags.DataPropertyName = "Tags"
		Me.Tags.HeaderText = "Comments"
		Me.Tags.Name = "Tags"
		Me.Tags.Width = 52
		'
		'Filename
		'
		Me.Filename.DataPropertyName = "Filename"
		Me.Filename.HeaderText = "Filename"
		Me.Filename.Name = "Filename"
		Me.Filename.ReadOnly = True
		Me.Filename.Width = 51
		'
		'FileExists
		'
		Me.FileExists.DataPropertyName = "FileExists"
		Me.FileExists.HeaderText = "FileExists"
		Me.FileExists.Name = "FileExists"
		Me.FileExists.Visible = False
		'
		'SoundsMng
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.Black
		Me.BackgroundImage = Global.SoundsManagement.My.Resources.Resources.BlackBG
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.ClientSize = New System.Drawing.Size(766, 572)
		Me.Controls.Add(Me.lblMediaPosition)
		Me.Controls.Add(Me.pbCaret)
		Me.Controls.Add(Me.wmp)
		Me.Controls.Add(Me.SoundsGrid)
		Me.Controls.Add(Me.FilesJoinedNewBindingNavigator)
		Me.Controls.Add(Me.wv)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "SoundsMng"
		Me.Text = "SoundsMng"
		CType(Me.SoundsGrid, System.ComponentModel.ISupportInitialize).EndInit()
		Me.cntxMenu.ResumeLayout(False)
		CType(Me.wmp, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.FilesJoinedNewBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
		Me.FilesJoinedNewBindingNavigator.ResumeLayout(False)
		Me.FilesJoinedNewBindingNavigator.PerformLayout()
		CType(Me.pbCaret, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.FilesJoinedNewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.SoundsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents SoundsDataSet As SoundsManagement.SoundsDataSet
	Friend WithEvents FilesJoinedNewBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents FilesJoinedNewTableAdapter As SoundsManagement.SoundsDataSetTableAdapters.FilesJoinedNewTableAdapter
	Friend WithEvents TableAdapterManager As SoundsManagement.SoundsDataSetTableAdapters.TableAdapterManager
	Friend WithEvents FilesJoinedNewBindingNavigator As System.Windows.Forms.BindingNavigator
	Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
	Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
	Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
	Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
	Friend WithEvents ToolStripFilter As System.Windows.Forms.ToolStripTextBox
	Friend WithEvents TimerSearch As System.Windows.Forms.Timer
	Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
	Friend WithEvents btnSetLibPath As System.Windows.Forms.ToolStripButton
	Friend WithEvents btnImportData As System.Windows.Forms.ToolStripButton
	Friend WithEvents prgBar As System.Windows.Forms.ToolStripProgressBar
	Friend WithEvents btnManageColumns As System.Windows.Forms.ToolStripButton
	Friend WithEvents BottomToolStripPanel As System.Windows.Forms.ToolStripPanel
	Friend WithEvents TopToolStripPanel As System.Windows.Forms.ToolStripPanel
	Friend WithEvents RightToolStripPanel As System.Windows.Forms.ToolStripPanel
	Friend WithEvents LeftToolStripPanel As System.Windows.Forms.ToolStripPanel
	Friend WithEvents ContentPanel As System.Windows.Forms.ToolStripContentPanel
	Friend WithEvents SoundsGrid As System.Windows.Forms.DataGridView
	Friend WithEvents btnExport As System.Windows.Forms.ToolStripButton
	Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
	Friend WithEvents lstNoOfSelRecs As System.Windows.Forms.ToolStripComboBox
	Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
	Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents btnPath As System.Windows.Forms.ToolStripButton
	Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents btnTags As System.Windows.Forms.ToolStripButton
	Friend WithEvents Index1 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents btnEditRecs As System.Windows.Forms.ToolStripButton
	Friend WithEvents btnClear As System.Windows.Forms.ToolStripButton
	Friend WithEvents lblNoOfFiles As System.Windows.Forms.ToolStripLabel
	Friend WithEvents btnDeleteFiles As System.Windows.Forms.ToolStripButton
	Friend WithEvents btnCompact As System.Windows.Forms.ToolStripButton
	Friend WithEvents cntxMenu As System.Windows.Forms.ContextMenuStrip
	Friend WithEvents DeleteFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents OpenFileLocationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents EditFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents CopyToFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents CopyToFolderToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents CopyToPreviousFolderToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents lblMediaPosition As System.Windows.Forms.Label
	Friend WithEvents TimerWMP As System.Windows.Forms.Timer
	Friend WithEvents PlaySelectedFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents btnExpNotExFiles As System.Windows.Forms.ToolStripButton
	Friend WithEvents btnHideNotExFiles As System.Windows.Forms.ToolStripButton
	Friend WithEvents wv As NAudio.Gui.WaveViewer
	Friend WithEvents wmp As AxWMPLib.AxWindowsMediaPlayer
	Friend WithEvents pbCaret As System.Windows.Forms.PictureBox
	Friend WithEvents TimerCaret As System.Windows.Forms.Timer
	Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Creator As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Library As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents CD As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Year As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Track As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Index As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Category As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents SubCategory As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Time As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Rating As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Tags As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Filename As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents FileExists As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
