<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.SoundsGrid = New DevExpress.XtraGrid.GridControl()
        Me.FilesJoinedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SoundsDataSet = New SoundsManagement.SoundsDataSet()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCreator = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLibrary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colYear = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTrack = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIndex = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSubCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRating = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFilename = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTags = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FilesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnLibPath = New System.Windows.Forms.Button()
        Me.wmp = New AxWMPLib.AxWindowsMediaPlayer()
        Me.btnPlaySound = New System.Windows.Forms.Button()
        Me.FilesTableAdapter = New SoundsManagement.SoundsDataSetTableAdapters.FilesTableAdapter()
        Me.FilesJoinedTableAdapter = New SoundsManagement.SoundsDataSetTableAdapters.FilesJoinedTableAdapter()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        CType(Me.SoundsGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FilesJoinedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoundsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FilesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.wmp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SoundsGrid
        '
        Me.SoundsGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SoundsGrid.DataSource = Me.FilesJoinedBindingSource
        Me.SoundsGrid.Location = New System.Drawing.Point(0, 0)
        Me.SoundsGrid.MainView = Me.GridView1
        Me.SoundsGrid.Name = "SoundsGrid"
        Me.SoundsGrid.Size = New System.Drawing.Size(648, 388)
        Me.SoundsGrid.TabIndex = 0
        Me.SoundsGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'FilesJoinedBindingSource
        '
        Me.FilesJoinedBindingSource.DataMember = "FilesJoined"
        Me.FilesJoinedBindingSource.DataSource = Me.SoundsDataSet
        '
        'SoundsDataSet
        '
        Me.SoundsDataSet.DataSetName = "SoundsDataSet"
        Me.SoundsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCreator, Me.colLibrary, Me.colCD, Me.colYear, Me.colTrack, Me.colIndex, Me.colCategory, Me.colSubCategory, Me.colDescription, Me.colTime, Me.colRating, Me.colFilename, Me.colTags})
        Me.GridView1.GridControl = Me.SoundsGrid
        Me.GridView1.GroupCount = 1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colCreator, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colCreator
        '
        Me.colCreator.FieldName = "Creator"
        Me.colCreator.Name = "colCreator"
        Me.colCreator.OptionsColumn.AllowEdit = False
        Me.colCreator.OptionsColumn.ReadOnly = True
        Me.colCreator.Visible = True
        Me.colCreator.VisibleIndex = 0
        '
        'colLibrary
        '
        Me.colLibrary.FieldName = "Library"
        Me.colLibrary.Name = "colLibrary"
        Me.colLibrary.OptionsColumn.AllowEdit = False
        Me.colLibrary.OptionsColumn.ReadOnly = True
        Me.colLibrary.Visible = True
        Me.colLibrary.VisibleIndex = 0
        '
        'colCD
        '
        Me.colCD.FieldName = "CD"
        Me.colCD.Name = "colCD"
        Me.colCD.OptionsColumn.AllowEdit = False
        Me.colCD.OptionsColumn.ReadOnly = True
        Me.colCD.Visible = True
        Me.colCD.VisibleIndex = 1
        '
        'colYear
        '
        Me.colYear.FieldName = "Year"
        Me.colYear.Name = "colYear"
        Me.colYear.OptionsColumn.AllowEdit = False
        Me.colYear.OptionsColumn.ReadOnly = True
        Me.colYear.Visible = True
        Me.colYear.VisibleIndex = 2
        '
        'colTrack
        '
        Me.colTrack.FieldName = "Track"
        Me.colTrack.Name = "colTrack"
        Me.colTrack.OptionsColumn.AllowEdit = False
        Me.colTrack.OptionsColumn.ReadOnly = True
        Me.colTrack.Visible = True
        Me.colTrack.VisibleIndex = 3
        '
        'colIndex
        '
        Me.colIndex.FieldName = "Index"
        Me.colIndex.Name = "colIndex"
        Me.colIndex.OptionsColumn.AllowEdit = False
        Me.colIndex.OptionsColumn.ReadOnly = True
        Me.colIndex.Visible = True
        Me.colIndex.VisibleIndex = 4
        '
        'colCategory
        '
        Me.colCategory.FieldName = "Category"
        Me.colCategory.Name = "colCategory"
        Me.colCategory.OptionsColumn.AllowEdit = False
        Me.colCategory.OptionsColumn.ReadOnly = True
        Me.colCategory.Visible = True
        Me.colCategory.VisibleIndex = 5
        '
        'colSubCategory
        '
        Me.colSubCategory.FieldName = "SubCategory"
        Me.colSubCategory.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.colSubCategory.Name = "colSubCategory"
        Me.colSubCategory.OptionsColumn.AllowEdit = False
        Me.colSubCategory.OptionsColumn.ReadOnly = True
        Me.colSubCategory.Visible = True
        Me.colSubCategory.VisibleIndex = 6
        '
        'colDescription
        '
        Me.colDescription.FieldName = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.OptionsColumn.AllowEdit = False
        Me.colDescription.OptionsColumn.ReadOnly = True
        Me.colDescription.OptionsFilter.AllowAutoFilter = False
        Me.colDescription.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.[True]
        Me.colDescription.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.colDescription.Visible = True
        Me.colDescription.VisibleIndex = 7
        '
        'colTime
        '
        Me.colTime.FieldName = "Time"
        Me.colTime.Name = "colTime"
        Me.colTime.OptionsColumn.AllowEdit = False
        Me.colTime.OptionsColumn.ReadOnly = True
        Me.colTime.Visible = True
        Me.colTime.VisibleIndex = 11
        '
        'colRating
        '
        Me.colRating.FieldName = "Rating"
        Me.colRating.Name = "colRating"
        Me.colRating.Visible = True
        Me.colRating.VisibleIndex = 8
        '
        'colFilename
        '
        Me.colFilename.FieldName = "Filename"
        Me.colFilename.Name = "colFilename"
        Me.colFilename.OptionsColumn.AllowEdit = False
        Me.colFilename.OptionsColumn.ReadOnly = True
        Me.colFilename.Visible = True
        Me.colFilename.VisibleIndex = 9
        '
        'colTags
        '
        Me.colTags.FieldName = "Tags"
        Me.colTags.Name = "colTags"
        Me.colTags.Visible = True
        Me.colTags.VisibleIndex = 10
        '
        'FilesBindingSource
        '
        Me.FilesBindingSource.DataMember = "Files"
        Me.FilesBindingSource.DataSource = Me.SoundsDataSet
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Please provide the folder path of the sounds library:"
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.txtFilter)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.btnLibPath)
        Me.Panel1.Controls.Add(Me.wmp)
        Me.Panel1.Controls.Add(Me.btnPlaySound)
        Me.Panel1.Location = New System.Drawing.Point(0, 393)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(648, 39)
        Me.Panel1.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(407, 13)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save data"
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'btnLibPath
        '
        Me.btnLibPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLibPath.Location = New System.Drawing.Point(488, 13)
        Me.btnLibPath.Name = "btnLibPath"
        Me.btnLibPath.Size = New System.Drawing.Size(75, 23)
        Me.btnLibPath.TabIndex = 2
        Me.btnLibPath.Text = "Set lib path"
        Me.btnLibPath.UseVisualStyleBackColor = True
        '
        'wmp
        '
        Me.wmp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.wmp.Enabled = True
        Me.wmp.Location = New System.Drawing.Point(3, 4)
        Me.wmp.Name = "wmp"
        Me.wmp.OcxState = CType(resources.GetObject("wmp.OcxState"), System.Windows.Forms.AxHost.State)
        Me.wmp.Size = New System.Drawing.Size(220, 33)
        Me.wmp.TabIndex = 1
        '
        'btnPlaySound
        '
        Me.btnPlaySound.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPlaySound.Location = New System.Drawing.Point(569, 13)
        Me.btnPlaySound.Name = "btnPlaySound"
        Me.btnPlaySound.Size = New System.Drawing.Size(75, 23)
        Me.btnPlaySound.TabIndex = 0
        Me.btnPlaySound.Text = "Play sound"
        Me.btnPlaySound.UseVisualStyleBackColor = True
        '
        'FilesTableAdapter
        '
        Me.FilesTableAdapter.ClearBeforeFill = True
        '
        'FilesJoinedTableAdapter
        '
        Me.FilesJoinedTableAdapter.ClearBeforeFill = True
        '
        'txtFilter
        '
        Me.txtFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.Location = New System.Drawing.Point(229, 13)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(100, 20)
        Me.txtFilter.TabIndex = 4
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 435)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.SoundsGrid)
        Me.Name = "Main"
        Me.Text = "Sound Management"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SoundsGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FilesJoinedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoundsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FilesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.wmp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SoundsGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCreator As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLibrary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colYear As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTrack As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIndex As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSubCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRating As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFilename As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTags As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnPlaySound As System.Windows.Forms.Button
    Friend WithEvents wmp As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents colTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnLibPath As System.Windows.Forms.Button
    Friend WithEvents SoundsDataSet As SoundsManagement.SoundsDataSet
    Friend WithEvents FilesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FilesTableAdapter As SoundsManagement.SoundsDataSetTableAdapters.FilesTableAdapter
    Friend WithEvents FilesJoinedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FilesJoinedTableAdapter As SoundsManagement.SoundsDataSetTableAdapters.FilesJoinedTableAdapter
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox

End Class
