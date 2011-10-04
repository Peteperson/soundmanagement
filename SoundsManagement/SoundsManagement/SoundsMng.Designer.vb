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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SoundsMng))
        Me.FilesJoinedNewBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.FilesJoinedNewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SoundsDataSet = New SoundsManagement.SoundsDataSet()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripFilter = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.lstNoOfSelRecs = New System.Windows.Forms.ToolStripComboBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.btnSetLibPath = New System.Windows.Forms.ToolStripButton()
        Me.btnManageColumns = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.prgBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.btnExport = New System.Windows.Forms.ToolStripButton()
        Me.btnImportData = New System.Windows.Forms.ToolStripButton()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FilesJoinedNewTableAdapter = New SoundsManagement.SoundsDataSetTableAdapters.FilesJoinedNewTableAdapter()
        Me.TableAdapterManager = New SoundsManagement.SoundsDataSetTableAdapters.TableAdapterManager()
        Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel()
        Me.SoundsGrid = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Creator = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Library = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Year = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Track = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Index1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rating = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tags = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Filename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.wmp = New AxWMPLib.AxWindowsMediaPlayer()
        Me.btnPath = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        CType(Me.FilesJoinedNewBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FilesJoinedNewBindingNavigator.SuspendLayout()
        CType(Me.FilesJoinedNewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoundsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoundsGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wmp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FilesJoinedNewBindingNavigator
        '
        Me.FilesJoinedNewBindingNavigator.AddNewItem = Nothing
        Me.FilesJoinedNewBindingNavigator.BindingSource = Me.FilesJoinedNewBindingSource
        Me.FilesJoinedNewBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.FilesJoinedNewBindingNavigator.DeleteItem = Nothing
        Me.FilesJoinedNewBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripFilter, Me.ToolStripLabel2, Me.lstNoOfSelRecs, Me.BindingNavigatorSeparator1, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.btnPath, Me.ToolStripSeparator2, Me.btnSetLibPath, Me.btnManageColumns, Me.ToolStripSeparator1, Me.prgBar, Me.btnExport, Me.btnImportData})
        Me.FilesJoinedNewBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.FilesJoinedNewBindingNavigator.MoveFirstItem = Nothing
        Me.FilesJoinedNewBindingNavigator.MoveLastItem = Nothing
        Me.FilesJoinedNewBindingNavigator.MoveNextItem = Nothing
        Me.FilesJoinedNewBindingNavigator.MovePreviousItem = Nothing
        Me.FilesJoinedNewBindingNavigator.Name = "FilesJoinedNewBindingNavigator"
        Me.FilesJoinedNewBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.FilesJoinedNewBindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.FilesJoinedNewBindingNavigator.Size = New System.Drawing.Size(766, 25)
        Me.FilesJoinedNewBindingNavigator.TabIndex = 0
        Me.FilesJoinedNewBindingNavigator.Text = "BindingNavigator1"
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
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(36, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        Me.BindingNavigatorCountItem.Visible = False
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(44, 22)
        Me.ToolStripLabel1.Text = "Search:"
        '
        'ToolStripFilter
        '
        Me.ToolStripFilter.Name = "ToolStripFilter"
        Me.ToolStripFilter.Size = New System.Drawing.Size(200, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel2.Text = "Show:"
        '
        'lstNoOfSelRecs
        '
        Me.lstNoOfSelRecs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lstNoOfSelRecs.Items.AddRange(New Object() {"TOP 50 records", "TOP 500 records", "ALL records"})
        Me.lstNoOfSelRecs.Name = "lstNoOfSelRecs"
        Me.lstNoOfSelRecs.Size = New System.Drawing.Size(115, 25)
        Me.lstNoOfSelRecs.ToolTipText = "Select the number of displayed records"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        Me.BindingNavigatorSeparator1.Visible = False
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
        'btnSetLibPath
        '
        Me.btnSetLibPath.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnSetLibPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSetLibPath.Image = CType(resources.GetObject("btnSetLibPath.Image"), System.Drawing.Image)
        Me.btnSetLibPath.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSetLibPath.Name = "btnSetLibPath"
        Me.btnSetLibPath.Size = New System.Drawing.Size(23, 22)
        Me.btnSetLibPath.ToolTipText = "Set library path"
        '
        'btnManageColumns
        '
        Me.btnManageColumns.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnManageColumns.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnManageColumns.Image = CType(resources.GetObject("btnManageColumns.Image"), System.Drawing.Image)
        Me.btnManageColumns.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnManageColumns.Name = "btnManageColumns"
        Me.btnManageColumns.Size = New System.Drawing.Size(23, 22)
        Me.btnManageColumns.ToolTipText = "Manage grid columns"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'prgBar
        '
        Me.prgBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.prgBar.Name = "prgBar"
        Me.prgBar.Size = New System.Drawing.Size(100, 22)
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
        Me.btnExport.Size = New System.Drawing.Size(23, 22)
        Me.btnExport.ToolTipText = "Export data to .tab file"
        '
        'btnImportData
        '
        Me.btnImportData.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnImportData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnImportData.Image = CType(resources.GetObject("btnImportData.Image"), System.Drawing.Image)
        Me.btnImportData.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImportData.Name = "btnImportData"
        Me.btnImportData.Size = New System.Drawing.Size(23, 22)
        Me.btnImportData.ToolTipText = "Import sounds file"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
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
        Me.TableAdapterManager.UpdateOrder = SoundsManagement.SoundsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
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
        Me.SoundsGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SoundsGrid.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SoundsGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.SoundsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SoundsGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Creator, Me.Library, Me.CD, Me.Year, Me.Track, Me.Index1, Me.Category, Me.SubCategory, Me.Description, Me.Time, Me.Rating, Me.Tags, Me.Filename})
        Me.SoundsGrid.DataSource = Me.FilesJoinedNewBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.SoundsGrid.DefaultCellStyle = DataGridViewCellStyle2
        Me.SoundsGrid.Location = New System.Drawing.Point(0, 28)
        Me.SoundsGrid.Name = "SoundsGrid"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SoundsGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.SoundsGrid.Size = New System.Drawing.Size(766, 496)
        Me.SoundsGrid.TabIndex = 2
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
        'Index1
        '
        Me.Index1.DataPropertyName = "Index1"
        Me.Index1.HeaderText = "Index"
        Me.Index1.Name = "Index1"
        Me.Index1.Width = 51
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
        Me.Tags.HeaderText = "Tags"
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
        'wmp
        '
        Me.wmp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wmp.Enabled = True
        Me.wmp.Location = New System.Drawing.Point(0, 525)
        Me.wmp.Name = "wmp"
        Me.wmp.OcxState = CType(resources.GetObject("wmp.OcxState"), System.Windows.Forms.AxHost.State)
        Me.wmp.Size = New System.Drawing.Size(766, 45)
        Me.wmp.TabIndex = 3
        '
        'btnPath
        '
        Me.btnPath.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPath.Image = CType(resources.GetObject("btnPath.Image"), System.Drawing.Image)
        Me.btnPath.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPath.Name = "btnPath"
        Me.btnPath.Size = New System.Drawing.Size(23, 22)
        Me.btnPath.ToolTipText = "Get application path"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'SoundsMng
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 572)
        Me.Controls.Add(Me.wmp)
        Me.Controls.Add(Me.SoundsGrid)
        Me.Controls.Add(Me.FilesJoinedNewBindingNavigator)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SoundsMng"
        Me.Text = "SoundsMng"
        CType(Me.FilesJoinedNewBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FilesJoinedNewBindingNavigator.ResumeLayout(False)
        Me.FilesJoinedNewBindingNavigator.PerformLayout()
        CType(Me.FilesJoinedNewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoundsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoundsGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wmp, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
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
    Friend WithEvents wmp As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Creator As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Library As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Year As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Track As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Index1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Time As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rating As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tags As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Filename As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents lstNoOfSelRecs As System.Windows.Forms.ToolStripComboBox
	Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPath As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
End Class
