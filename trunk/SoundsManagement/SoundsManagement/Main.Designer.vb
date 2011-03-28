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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.SoundsDataSet = New SoundsManagement.SoundsDataSet()
        Me.FilesDataTableBindingSource = New System.Windows.Forms.BindingSource()
        Me.FilesDataTableTableAdapter = New SoundsManagement.SoundsDataSetTableAdapters.FilesDataTableTableAdapter()
        Me.SoundsDataSetBindingSource = New System.Windows.Forms.BindingSource()
        Me.SoundsGrid = New DevExpress.XtraGrid.GridControl()
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
        Me.AxWMP = New AxWMPLib.AxWindowsMediaPlayer()
        CType(Me.SoundsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FilesDataTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoundsDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoundsGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxWMP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SoundsDataSet
        '
        Me.SoundsDataSet.DataSetName = "SoundsDataSet"
        Me.SoundsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FilesDataTableBindingSource
        '
        Me.FilesDataTableBindingSource.DataMember = "FilesDataTable"
        Me.FilesDataTableBindingSource.DataSource = Me.SoundsDataSet
        '
        'FilesDataTableTableAdapter
        '
        Me.FilesDataTableTableAdapter.ClearBeforeFill = True
        '
        'SoundsDataSetBindingSource
        '
        Me.SoundsDataSetBindingSource.DataSource = Me.SoundsDataSet
        Me.SoundsDataSetBindingSource.Position = 0
        '
        'SoundsGrid
        '
        Me.SoundsGrid.DataSource = Me.FilesDataTableBindingSource
        Me.SoundsGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SoundsGrid.Location = New System.Drawing.Point(0, 0)
        Me.SoundsGrid.MainView = Me.GridView1
        Me.SoundsGrid.Name = "SoundsGrid"
        Me.SoundsGrid.Size = New System.Drawing.Size(648, 435)
        Me.SoundsGrid.TabIndex = 0
        Me.SoundsGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCreator, Me.colLibrary, Me.colCD, Me.colYear, Me.colTrack, Me.colIndex, Me.colCategory, Me.colSubCategory, Me.colDescription, Me.colTime, Me.colRating, Me.colFilename, Me.colTags})
        Me.GridView1.GridControl = Me.SoundsGrid
        Me.GridView1.Name = "GridView1"
        '
        'colCreator
        '
        Me.colCreator.FieldName = "Creator"
        Me.colCreator.Name = "colCreator"
        Me.colCreator.OptionsColumn.ReadOnly = True
        Me.colCreator.Visible = True
        Me.colCreator.VisibleIndex = 0
        '
        'colLibrary
        '
        Me.colLibrary.FieldName = "Library"
        Me.colLibrary.Name = "colLibrary"
        Me.colLibrary.OptionsColumn.ReadOnly = True
        Me.colLibrary.Visible = True
        Me.colLibrary.VisibleIndex = 1
        '
        'colCD
        '
        Me.colCD.FieldName = "CD"
        Me.colCD.Name = "colCD"
        Me.colCD.OptionsColumn.ReadOnly = True
        Me.colCD.Visible = True
        Me.colCD.VisibleIndex = 2
        '
        'colYear
        '
        Me.colYear.FieldName = "Year"
        Me.colYear.Name = "colYear"
        Me.colYear.OptionsColumn.ReadOnly = True
        Me.colYear.Visible = True
        Me.colYear.VisibleIndex = 3
        '
        'colTrack
        '
        Me.colTrack.FieldName = "Track"
        Me.colTrack.Name = "colTrack"
        Me.colTrack.OptionsColumn.ReadOnly = True
        Me.colTrack.Visible = True
        Me.colTrack.VisibleIndex = 4
        '
        'colIndex
        '
        Me.colIndex.FieldName = "Index"
        Me.colIndex.Name = "colIndex"
        Me.colIndex.OptionsColumn.ReadOnly = True
        Me.colIndex.Visible = True
        Me.colIndex.VisibleIndex = 5
        '
        'colCategory
        '
        Me.colCategory.FieldName = "Category"
        Me.colCategory.Name = "colCategory"
        Me.colCategory.OptionsColumn.ReadOnly = True
        Me.colCategory.Visible = True
        Me.colCategory.VisibleIndex = 6
        '
        'colSubCategory
        '
        Me.colSubCategory.FieldName = "SubCategory"
        Me.colSubCategory.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.colSubCategory.Name = "colSubCategory"
        Me.colSubCategory.OptionsColumn.ReadOnly = True
        Me.colSubCategory.Visible = True
        Me.colSubCategory.VisibleIndex = 7
        '
        'colDescription
        '
        Me.colDescription.FieldName = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.OptionsColumn.ReadOnly = True
        Me.colDescription.OptionsFilter.AllowAutoFilter = False
        Me.colDescription.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.[True]
        Me.colDescription.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.colDescription.Visible = True
        Me.colDescription.VisibleIndex = 8
        '
        'colTime
        '
        Me.colTime.FieldName = "Time"
        Me.colTime.Name = "colTime"
        Me.colTime.OptionsColumn.ReadOnly = True
        Me.colTime.Visible = True
        Me.colTime.VisibleIndex = 9
        '
        'colRating
        '
        Me.colRating.FieldName = "Rating"
        Me.colRating.Name = "colRating"
        Me.colRating.Visible = True
        Me.colRating.VisibleIndex = 10
        '
        'colFilename
        '
        Me.colFilename.FieldName = "Filename"
        Me.colFilename.Name = "colFilename"
        Me.colFilename.OptionsColumn.ReadOnly = True
        Me.colFilename.Visible = True
        Me.colFilename.VisibleIndex = 11
        '
        'colTags
        '
        Me.colTags.FieldName = "Tags"
        Me.colTags.Name = "colTags"
        Me.colTags.OptionsColumn.ReadOnly = True
        Me.colTags.Visible = True
        Me.colTags.VisibleIndex = 12
        '
        'AxWMP
        '
        Me.AxWMP.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.AxWMP.Enabled = True
        Me.AxWMP.Location = New System.Drawing.Point(0, 402)
        Me.AxWMP.Name = "AxWMP"
        Me.AxWMP.OcxState = CType(resources.GetObject("AxWMP.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWMP.Size = New System.Drawing.Size(648, 33)
        Me.AxWMP.TabIndex = 1
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 435)
        Me.Controls.Add(Me.AxWMP)
        Me.Controls.Add(Me.SoundsGrid)
        Me.Name = "Main"
        Me.Text = "Sound Management"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SoundsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FilesDataTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoundsDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoundsGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxWMP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SoundsDataSet As SoundsManagement.SoundsDataSet
    Friend WithEvents FilesDataTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FilesDataTableTableAdapter As SoundsManagement.SoundsDataSetTableAdapters.FilesDataTableTableAdapter
    Friend WithEvents SoundsDataSetBindingSource As System.Windows.Forms.BindingSource
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
    Friend WithEvents colTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRating As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFilename As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTags As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AxWMP As AxWMPLib.AxWindowsMediaPlayer

End Class
