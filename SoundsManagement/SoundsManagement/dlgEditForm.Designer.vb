<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgEditForm
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
		Dim CreatorLabel As System.Windows.Forms.Label
		Dim LibraryLabel As System.Windows.Forms.Label
		Dim CDLabel As System.Windows.Forms.Label
		Dim YearLabel As System.Windows.Forms.Label
		Dim TrackLabel As System.Windows.Forms.Label
		Dim IndexLabel As System.Windows.Forms.Label
		Dim CategoryLabel As System.Windows.Forms.Label
		Dim SubCategoryLabel As System.Windows.Forms.Label
		Dim DescriptionLabel As System.Windows.Forms.Label
		Dim TimeLabel As System.Windows.Forms.Label
		Dim RatingLabel As System.Windows.Forms.Label
		Dim TagsLabel As System.Windows.Forms.Label
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
		Me.OK_Button = New System.Windows.Forms.Button()
		Me.Cancel_Button = New System.Windows.Forms.Button()
		Me.SoundsDataSet = New SoundsManagement.SoundsDataSet()
		Me.FilesJoinedNewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.FilesJoinedNewTableAdapter = New SoundsManagement.SoundsDataSetTableAdapters.FilesJoinedNewTableAdapter()
		Me.TableAdapterManager = New SoundsManagement.SoundsDataSetTableAdapters.TableAdapterManager()
		Me.YearTextBox = New System.Windows.Forms.TextBox()
		Me.TrackTextBox = New System.Windows.Forms.TextBox()
		Me.IndexTextBox = New System.Windows.Forms.TextBox()
		Me.DescriptionTextBox = New System.Windows.Forms.TextBox()
		Me.TimeTextBox = New System.Windows.Forms.TextBox()
		Me.RatingTextBox = New System.Windows.Forms.TextBox()
		Me.TagsTextBox = New System.Windows.Forms.TextBox()
		Me.Creators_IDComboBox = New System.Windows.Forms.ComboBox()
		Me.CreatorsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.Libraries_IDComboBox = New System.Windows.Forms.ComboBox()
		Me.LibrariesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.CDs_IDComboBox = New System.Windows.Forms.ComboBox()
		Me.CDsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.Categories_IDComboBox = New System.Windows.Forms.ComboBox()
		Me.CategoriesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.Subcategories_IDComboBox = New System.Windows.Forms.ComboBox()
		Me.SubcategoriesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.CreatorsTableAdapter = New SoundsManagement.SoundsDataSetTableAdapters.CreatorsTableAdapter()
		Me.LibrariesTableAdapter = New SoundsManagement.SoundsDataSetTableAdapters.LibrariesTableAdapter()
		Me.CDsTableAdapter = New SoundsManagement.SoundsDataSetTableAdapters.CDsTableAdapter()
		Me.CategoriesTableAdapter = New SoundsManagement.SoundsDataSetTableAdapters.CategoriesTableAdapter()
		Me.SubcategoriesTableAdapter = New SoundsManagement.SoundsDataSetTableAdapters.SubcategoriesTableAdapter()
		CreatorLabel = New System.Windows.Forms.Label()
		LibraryLabel = New System.Windows.Forms.Label()
		CDLabel = New System.Windows.Forms.Label()
		YearLabel = New System.Windows.Forms.Label()
		TrackLabel = New System.Windows.Forms.Label()
		IndexLabel = New System.Windows.Forms.Label()
		CategoryLabel = New System.Windows.Forms.Label()
		SubCategoryLabel = New System.Windows.Forms.Label()
		DescriptionLabel = New System.Windows.Forms.Label()
		TimeLabel = New System.Windows.Forms.Label()
		RatingLabel = New System.Windows.Forms.Label()
		TagsLabel = New System.Windows.Forms.Label()
		Me.TableLayoutPanel1.SuspendLayout()
		CType(Me.SoundsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.FilesJoinedNewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.CreatorsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.LibrariesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.CDsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.CategoriesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.SubcategoriesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'CreatorLabel
		'
		CreatorLabel.AutoSize = True
		CreatorLabel.Location = New System.Drawing.Point(12, 9)
		CreatorLabel.Name = "CreatorLabel"
		CreatorLabel.Size = New System.Drawing.Size(44, 13)
		CreatorLabel.TabIndex = 3
		CreatorLabel.Text = "Creator:"
		'
		'LibraryLabel
		'
		LibraryLabel.AutoSize = True
		LibraryLabel.Location = New System.Drawing.Point(12, 35)
		LibraryLabel.Name = "LibraryLabel"
		LibraryLabel.Size = New System.Drawing.Size(41, 13)
		LibraryLabel.TabIndex = 5
		LibraryLabel.Text = "Library:"
		'
		'CDLabel
		'
		CDLabel.AutoSize = True
		CDLabel.Location = New System.Drawing.Point(12, 61)
		CDLabel.Name = "CDLabel"
		CDLabel.Size = New System.Drawing.Size(25, 13)
		CDLabel.TabIndex = 7
		CDLabel.Text = "CD:"
		'
		'YearLabel
		'
		YearLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		YearLabel.AutoSize = True
		YearLabel.Location = New System.Drawing.Point(535, 9)
		YearLabel.Name = "YearLabel"
		YearLabel.Size = New System.Drawing.Size(32, 13)
		YearLabel.TabIndex = 9
		YearLabel.Text = "Year:"
		'
		'TrackLabel
		'
		TrackLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		TrackLabel.AutoSize = True
		TrackLabel.Location = New System.Drawing.Point(535, 113)
		TrackLabel.Name = "TrackLabel"
		TrackLabel.Size = New System.Drawing.Size(38, 13)
		TrackLabel.TabIndex = 11
		TrackLabel.Text = "Track:"
		'
		'IndexLabel
		'
		IndexLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		IndexLabel.AutoSize = True
		IndexLabel.Location = New System.Drawing.Point(535, 87)
		IndexLabel.Name = "IndexLabel"
		IndexLabel.Size = New System.Drawing.Size(36, 13)
		IndexLabel.TabIndex = 13
		IndexLabel.Text = "Index:"
		'
		'CategoryLabel
		'
		CategoryLabel.AutoSize = True
		CategoryLabel.Location = New System.Drawing.Point(12, 88)
		CategoryLabel.Name = "CategoryLabel"
		CategoryLabel.Size = New System.Drawing.Size(52, 13)
		CategoryLabel.TabIndex = 15
		CategoryLabel.Text = "Category:"
		'
		'SubCategoryLabel
		'
		SubCategoryLabel.AutoSize = True
		SubCategoryLabel.Location = New System.Drawing.Point(12, 114)
		SubCategoryLabel.Name = "SubCategoryLabel"
		SubCategoryLabel.Size = New System.Drawing.Size(74, 13)
		SubCategoryLabel.TabIndex = 17
		SubCategoryLabel.Text = "Sub Category:"
		'
		'DescriptionLabel
		'
		DescriptionLabel.AutoSize = True
		DescriptionLabel.Location = New System.Drawing.Point(12, 139)
		DescriptionLabel.Name = "DescriptionLabel"
		DescriptionLabel.Size = New System.Drawing.Size(63, 13)
		DescriptionLabel.TabIndex = 19
		DescriptionLabel.Text = "Description:"
		'
		'TimeLabel
		'
		TimeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		TimeLabel.AutoSize = True
		TimeLabel.Location = New System.Drawing.Point(535, 35)
		TimeLabel.Name = "TimeLabel"
		TimeLabel.Size = New System.Drawing.Size(33, 13)
		TimeLabel.TabIndex = 21
		TimeLabel.Text = "Time:"
		'
		'RatingLabel
		'
		RatingLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		RatingLabel.AutoSize = True
		RatingLabel.Location = New System.Drawing.Point(535, 61)
		RatingLabel.Name = "RatingLabel"
		RatingLabel.Size = New System.Drawing.Size(41, 13)
		RatingLabel.TabIndex = 23
		RatingLabel.Text = "Rating:"
		'
		'TagsLabel
		'
		TagsLabel.AutoSize = True
		TagsLabel.Location = New System.Drawing.Point(12, 166)
		TagsLabel.Name = "TagsLabel"
		TagsLabel.Size = New System.Drawing.Size(59, 13)
		TagsLabel.TabIndex = 27
		TagsLabel.Text = "Comments:"
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.TableLayoutPanel1.ColumnCount = 2
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(506, 187)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 1
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
		Me.TableLayoutPanel1.TabIndex = 0
		'
		'OK_Button
		'
		Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.OK_Button.Location = New System.Drawing.Point(3, 3)
		Me.OK_Button.Name = "OK_Button"
		Me.OK_Button.Size = New System.Drawing.Size(67, 23)
		Me.OK_Button.TabIndex = 0
		Me.OK_Button.Text = "OK"
		'
		'Cancel_Button
		'
		Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
		Me.Cancel_Button.Name = "Cancel_Button"
		Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
		Me.Cancel_Button.TabIndex = 1
		Me.Cancel_Button.Text = "Cancel"
		'
		'SoundsDataSet
		'
		Me.SoundsDataSet.DataSetName = "SoundsDataSet"
		Me.SoundsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
		'
		'FilesJoinedNewBindingSource
		'
		Me.FilesJoinedNewBindingSource.DataMember = "FilesJoinedNew"
		Me.FilesJoinedNewBindingSource.DataSource = Me.SoundsDataSet
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
		'YearTextBox
		'
		Me.YearTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.YearTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FilesJoinedNewBindingSource, "Year", True))
		Me.YearTextBox.Location = New System.Drawing.Point(585, 6)
		Me.YearTextBox.Name = "YearTextBox"
		Me.YearTextBox.Size = New System.Drawing.Size(73, 20)
		Me.YearTextBox.TabIndex = 5
		'
		'TrackTextBox
		'
		Me.TrackTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.TrackTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FilesJoinedNewBindingSource, "Track", True))
		Me.TrackTextBox.Location = New System.Drawing.Point(585, 110)
		Me.TrackTextBox.Name = "TrackTextBox"
		Me.TrackTextBox.Size = New System.Drawing.Size(73, 20)
		Me.TrackTextBox.TabIndex = 9
		'
		'IndexTextBox
		'
		Me.IndexTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.IndexTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FilesJoinedNewBindingSource, "Index", True))
		Me.IndexTextBox.Location = New System.Drawing.Point(585, 84)
		Me.IndexTextBox.Name = "IndexTextBox"
		Me.IndexTextBox.Size = New System.Drawing.Size(73, 20)
		Me.IndexTextBox.TabIndex = 8
		'
		'DescriptionTextBox
		'
		Me.DescriptionTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
				  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.DescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FilesJoinedNewBindingSource, "Description", True))
		Me.DescriptionTextBox.Location = New System.Drawing.Point(92, 136)
		Me.DescriptionTextBox.Name = "DescriptionTextBox"
		Me.DescriptionTextBox.Size = New System.Drawing.Size(566, 20)
		Me.DescriptionTextBox.TabIndex = 10
		'
		'TimeTextBox
		'
		Me.TimeTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.TimeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FilesJoinedNewBindingSource, "Time", True))
		Me.TimeTextBox.Location = New System.Drawing.Point(585, 32)
		Me.TimeTextBox.Name = "TimeTextBox"
		Me.TimeTextBox.Size = New System.Drawing.Size(73, 20)
		Me.TimeTextBox.TabIndex = 6
		'
		'RatingTextBox
		'
		Me.RatingTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.RatingTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FilesJoinedNewBindingSource, "Rating", True))
		Me.RatingTextBox.Location = New System.Drawing.Point(585, 58)
		Me.RatingTextBox.Name = "RatingTextBox"
		Me.RatingTextBox.Size = New System.Drawing.Size(73, 20)
		Me.RatingTextBox.TabIndex = 7
		'
		'TagsTextBox
		'
		Me.TagsTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
				  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.TagsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FilesJoinedNewBindingSource, "Tags", True))
		Me.TagsTextBox.Location = New System.Drawing.Point(92, 163)
		Me.TagsTextBox.Name = "TagsTextBox"
		Me.TagsTextBox.Size = New System.Drawing.Size(566, 20)
		Me.TagsTextBox.TabIndex = 11
		'
		'Creators_IDComboBox
		'
		Me.Creators_IDComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
				  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Creators_IDComboBox.DataSource = Me.CreatorsBindingSource
		Me.Creators_IDComboBox.DisplayMember = "Creator"
		Me.Creators_IDComboBox.FormattingEnabled = True
		Me.Creators_IDComboBox.Location = New System.Drawing.Point(92, 5)
		Me.Creators_IDComboBox.Name = "Creators_IDComboBox"
		Me.Creators_IDComboBox.Size = New System.Drawing.Size(417, 21)
		Me.Creators_IDComboBox.TabIndex = 0
		Me.Creators_IDComboBox.ValueMember = "ID"
		'
		'CreatorsBindingSource
		'
		Me.CreatorsBindingSource.DataMember = "Creators"
		Me.CreatorsBindingSource.DataSource = Me.SoundsDataSet
		'
		'Libraries_IDComboBox
		'
		Me.Libraries_IDComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
				  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Libraries_IDComboBox.DataSource = Me.LibrariesBindingSource
		Me.Libraries_IDComboBox.DisplayMember = "Library"
		Me.Libraries_IDComboBox.FormattingEnabled = True
		Me.Libraries_IDComboBox.Location = New System.Drawing.Point(92, 32)
		Me.Libraries_IDComboBox.Name = "Libraries_IDComboBox"
		Me.Libraries_IDComboBox.Size = New System.Drawing.Size(417, 21)
		Me.Libraries_IDComboBox.TabIndex = 1
		Me.Libraries_IDComboBox.ValueMember = "ID"
		'
		'LibrariesBindingSource
		'
		Me.LibrariesBindingSource.DataMember = "Libraries"
		Me.LibrariesBindingSource.DataSource = Me.SoundsDataSet
		'
		'CDs_IDComboBox
		'
		Me.CDs_IDComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
				  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.CDs_IDComboBox.DataSource = Me.CDsBindingSource
		Me.CDs_IDComboBox.DisplayMember = "CD"
		Me.CDs_IDComboBox.FormattingEnabled = True
		Me.CDs_IDComboBox.Location = New System.Drawing.Point(92, 58)
		Me.CDs_IDComboBox.Name = "CDs_IDComboBox"
		Me.CDs_IDComboBox.Size = New System.Drawing.Size(417, 21)
		Me.CDs_IDComboBox.TabIndex = 2
		Me.CDs_IDComboBox.ValueMember = "ID"
		'
		'CDsBindingSource
		'
		Me.CDsBindingSource.DataMember = "CDs"
		Me.CDsBindingSource.DataSource = Me.SoundsDataSet
		'
		'Categories_IDComboBox
		'
		Me.Categories_IDComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
				  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Categories_IDComboBox.DataSource = Me.CategoriesBindingSource
		Me.Categories_IDComboBox.DisplayMember = "Category"
		Me.Categories_IDComboBox.FormattingEnabled = True
		Me.Categories_IDComboBox.Location = New System.Drawing.Point(92, 84)
		Me.Categories_IDComboBox.Name = "Categories_IDComboBox"
		Me.Categories_IDComboBox.Size = New System.Drawing.Size(417, 21)
		Me.Categories_IDComboBox.TabIndex = 3
		Me.Categories_IDComboBox.ValueMember = "ID"
		'
		'CategoriesBindingSource
		'
		Me.CategoriesBindingSource.DataMember = "Categories"
		Me.CategoriesBindingSource.DataSource = Me.SoundsDataSet
		'
		'Subcategories_IDComboBox
		'
		Me.Subcategories_IDComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
				  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Subcategories_IDComboBox.DataSource = Me.SubcategoriesBindingSource
		Me.Subcategories_IDComboBox.DisplayMember = "SubCategory"
		Me.Subcategories_IDComboBox.FormattingEnabled = True
		Me.Subcategories_IDComboBox.Location = New System.Drawing.Point(92, 110)
		Me.Subcategories_IDComboBox.Name = "Subcategories_IDComboBox"
		Me.Subcategories_IDComboBox.Size = New System.Drawing.Size(417, 21)
		Me.Subcategories_IDComboBox.TabIndex = 4
		Me.Subcategories_IDComboBox.ValueMember = "ID"
		'
		'SubcategoriesBindingSource
		'
		Me.SubcategoriesBindingSource.DataMember = "Subcategories"
		Me.SubcategoriesBindingSource.DataSource = Me.SoundsDataSet
		'
		'CreatorsTableAdapter
		'
		Me.CreatorsTableAdapter.ClearBeforeFill = True
		'
		'LibrariesTableAdapter
		'
		Me.LibrariesTableAdapter.ClearBeforeFill = True
		'
		'CDsTableAdapter
		'
		Me.CDsTableAdapter.ClearBeforeFill = True
		'
		'CategoriesTableAdapter
		'
		Me.CategoriesTableAdapter.ClearBeforeFill = True
		'
		'SubcategoriesTableAdapter
		'
		Me.SubcategoriesTableAdapter.ClearBeforeFill = True
		'
		'dlgEditForm
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(670, 223)
		Me.Controls.Add(Me.Subcategories_IDComboBox)
		Me.Controls.Add(Me.Categories_IDComboBox)
		Me.Controls.Add(Me.CDs_IDComboBox)
		Me.Controls.Add(Me.Libraries_IDComboBox)
		Me.Controls.Add(Me.Creators_IDComboBox)
		Me.Controls.Add(CreatorLabel)
		Me.Controls.Add(LibraryLabel)
		Me.Controls.Add(CDLabel)
		Me.Controls.Add(YearLabel)
		Me.Controls.Add(Me.YearTextBox)
		Me.Controls.Add(TrackLabel)
		Me.Controls.Add(Me.TrackTextBox)
		Me.Controls.Add(IndexLabel)
		Me.Controls.Add(Me.IndexTextBox)
		Me.Controls.Add(CategoryLabel)
		Me.Controls.Add(SubCategoryLabel)
		Me.Controls.Add(DescriptionLabel)
		Me.Controls.Add(Me.DescriptionTextBox)
		Me.Controls.Add(TimeLabel)
		Me.Controls.Add(Me.TimeTextBox)
		Me.Controls.Add(RatingLabel)
		Me.Controls.Add(Me.RatingTextBox)
		Me.Controls.Add(TagsLabel)
		Me.Controls.Add(Me.TagsTextBox)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "dlgEditForm"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "dlgEditForm"
		Me.TableLayoutPanel1.ResumeLayout(False)
		CType(Me.SoundsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.FilesJoinedNewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.CreatorsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.LibrariesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.CDsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.CategoriesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.SubcategoriesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button
	Friend WithEvents SoundsDataSet As SoundsManagement.SoundsDataSet
	Friend WithEvents FilesJoinedNewBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents FilesJoinedNewTableAdapter As SoundsManagement.SoundsDataSetTableAdapters.FilesJoinedNewTableAdapter
	Friend WithEvents TableAdapterManager As SoundsManagement.SoundsDataSetTableAdapters.TableAdapterManager
	Friend WithEvents YearTextBox As System.Windows.Forms.TextBox
	Friend WithEvents TrackTextBox As System.Windows.Forms.TextBox
	Friend WithEvents IndexTextBox As System.Windows.Forms.TextBox
	Friend WithEvents DescriptionTextBox As System.Windows.Forms.TextBox
	Friend WithEvents TimeTextBox As System.Windows.Forms.TextBox
	Friend WithEvents RatingTextBox As System.Windows.Forms.TextBox
	Friend WithEvents TagsTextBox As System.Windows.Forms.TextBox
	Friend WithEvents Creators_IDComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents Libraries_IDComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents CDs_IDComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents Categories_IDComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents Subcategories_IDComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents CreatorsBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents CreatorsTableAdapter As SoundsManagement.SoundsDataSetTableAdapters.CreatorsTableAdapter
	Friend WithEvents LibrariesBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents LibrariesTableAdapter As SoundsManagement.SoundsDataSetTableAdapters.LibrariesTableAdapter
	Friend WithEvents CDsBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents CDsTableAdapter As SoundsManagement.SoundsDataSetTableAdapters.CDsTableAdapter
	Friend WithEvents CategoriesBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents CategoriesTableAdapter As SoundsManagement.SoundsDataSetTableAdapters.CategoriesTableAdapter
	Friend WithEvents SubcategoriesBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents SubcategoriesTableAdapter As SoundsManagement.SoundsDataSetTableAdapters.SubcategoriesTableAdapter

End Class
