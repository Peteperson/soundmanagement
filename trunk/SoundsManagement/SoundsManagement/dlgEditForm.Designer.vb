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
		Me.CreatorTextBox = New System.Windows.Forms.TextBox()
		Me.LibraryTextBox = New System.Windows.Forms.TextBox()
		Me.CDTextBox = New System.Windows.Forms.TextBox()
		Me.YearTextBox = New System.Windows.Forms.TextBox()
		Me.TrackTextBox = New System.Windows.Forms.TextBox()
		Me.IndexTextBox = New System.Windows.Forms.TextBox()
		Me.CategoryTextBox = New System.Windows.Forms.TextBox()
		Me.SubCategoryTextBox = New System.Windows.Forms.TextBox()
		Me.DescriptionTextBox = New System.Windows.Forms.TextBox()
		Me.TimeTextBox = New System.Windows.Forms.TextBox()
		Me.RatingTextBox = New System.Windows.Forms.TextBox()
		Me.TagsTextBox = New System.Windows.Forms.TextBox()
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
		Me.SuspendLayout()
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.TableLayoutPanel1.ColumnCount = 2
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(247, 191)
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
		'CreatorLabel
		'
		CreatorLabel.AutoSize = True
		CreatorLabel.Location = New System.Drawing.Point(12, 9)
		CreatorLabel.Name = "CreatorLabel"
		CreatorLabel.Size = New System.Drawing.Size(44, 13)
		CreatorLabel.TabIndex = 3
		CreatorLabel.Text = "Creator:"
		'
		'CreatorTextBox
		'
		Me.CreatorTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FilesJoinedNewBindingSource, "Creator", True))
		Me.CreatorTextBox.Location = New System.Drawing.Point(92, 6)
		Me.CreatorTextBox.Name = "CreatorTextBox"
		Me.CreatorTextBox.Size = New System.Drawing.Size(100, 20)
		Me.CreatorTextBox.TabIndex = 4
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
		'LibraryTextBox
		'
		Me.LibraryTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FilesJoinedNewBindingSource, "Library", True))
		Me.LibraryTextBox.Location = New System.Drawing.Point(92, 32)
		Me.LibraryTextBox.Name = "LibraryTextBox"
		Me.LibraryTextBox.Size = New System.Drawing.Size(100, 20)
		Me.LibraryTextBox.TabIndex = 6
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
		'CDTextBox
		'
		Me.CDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FilesJoinedNewBindingSource, "CD", True))
		Me.CDTextBox.Location = New System.Drawing.Point(92, 58)
		Me.CDTextBox.Name = "CDTextBox"
		Me.CDTextBox.Size = New System.Drawing.Size(100, 20)
		Me.CDTextBox.TabIndex = 8
		'
		'YearLabel
		'
		YearLabel.AutoSize = True
		YearLabel.Location = New System.Drawing.Point(12, 87)
		YearLabel.Name = "YearLabel"
		YearLabel.Size = New System.Drawing.Size(32, 13)
		YearLabel.TabIndex = 9
		YearLabel.Text = "Year:"
		'
		'YearTextBox
		'
		Me.YearTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FilesJoinedNewBindingSource, "Year", True))
		Me.YearTextBox.Location = New System.Drawing.Point(92, 84)
		Me.YearTextBox.Name = "YearTextBox"
		Me.YearTextBox.Size = New System.Drawing.Size(100, 20)
		Me.YearTextBox.TabIndex = 10
		'
		'TrackLabel
		'
		TrackLabel.AutoSize = True
		TrackLabel.Location = New System.Drawing.Point(214, 113)
		TrackLabel.Name = "TrackLabel"
		TrackLabel.Size = New System.Drawing.Size(38, 13)
		TrackLabel.TabIndex = 11
		TrackLabel.Text = "Track:"
		'
		'TrackTextBox
		'
		Me.TrackTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FilesJoinedNewBindingSource, "Track", True))
		Me.TrackTextBox.Location = New System.Drawing.Point(294, 110)
		Me.TrackTextBox.Name = "TrackTextBox"
		Me.TrackTextBox.Size = New System.Drawing.Size(100, 20)
		Me.TrackTextBox.TabIndex = 12
		'
		'IndexLabel
		'
		IndexLabel.AutoSize = True
		IndexLabel.Location = New System.Drawing.Point(214, 87)
		IndexLabel.Name = "IndexLabel"
		IndexLabel.Size = New System.Drawing.Size(36, 13)
		IndexLabel.TabIndex = 13
		IndexLabel.Text = "Index:"
		'
		'IndexTextBox
		'
		Me.IndexTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FilesJoinedNewBindingSource, "Index", True))
		Me.IndexTextBox.Location = New System.Drawing.Point(294, 84)
		Me.IndexTextBox.Name = "IndexTextBox"
		Me.IndexTextBox.Size = New System.Drawing.Size(100, 20)
		Me.IndexTextBox.TabIndex = 14
		'
		'CategoryLabel
		'
		CategoryLabel.AutoSize = True
		CategoryLabel.Location = New System.Drawing.Point(12, 113)
		CategoryLabel.Name = "CategoryLabel"
		CategoryLabel.Size = New System.Drawing.Size(52, 13)
		CategoryLabel.TabIndex = 15
		CategoryLabel.Text = "Category:"
		'
		'CategoryTextBox
		'
		Me.CategoryTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FilesJoinedNewBindingSource, "Category", True))
		Me.CategoryTextBox.Location = New System.Drawing.Point(92, 110)
		Me.CategoryTextBox.Name = "CategoryTextBox"
		Me.CategoryTextBox.Size = New System.Drawing.Size(100, 20)
		Me.CategoryTextBox.TabIndex = 16
		'
		'SubCategoryLabel
		'
		SubCategoryLabel.AutoSize = True
		SubCategoryLabel.Location = New System.Drawing.Point(214, 9)
		SubCategoryLabel.Name = "SubCategoryLabel"
		SubCategoryLabel.Size = New System.Drawing.Size(74, 13)
		SubCategoryLabel.TabIndex = 17
		SubCategoryLabel.Text = "Sub Category:"
		'
		'SubCategoryTextBox
		'
		Me.SubCategoryTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FilesJoinedNewBindingSource, "SubCategory", True))
		Me.SubCategoryTextBox.Location = New System.Drawing.Point(294, 6)
		Me.SubCategoryTextBox.Name = "SubCategoryTextBox"
		Me.SubCategoryTextBox.Size = New System.Drawing.Size(100, 20)
		Me.SubCategoryTextBox.TabIndex = 18
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
		'DescriptionTextBox
		'
		Me.DescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FilesJoinedNewBindingSource, "Description", True))
		Me.DescriptionTextBox.Location = New System.Drawing.Point(92, 136)
		Me.DescriptionTextBox.Name = "DescriptionTextBox"
		Me.DescriptionTextBox.Size = New System.Drawing.Size(302, 20)
		Me.DescriptionTextBox.TabIndex = 20
		'
		'TimeLabel
		'
		TimeLabel.AutoSize = True
		TimeLabel.Location = New System.Drawing.Point(214, 35)
		TimeLabel.Name = "TimeLabel"
		TimeLabel.Size = New System.Drawing.Size(33, 13)
		TimeLabel.TabIndex = 21
		TimeLabel.Text = "Time:"
		'
		'TimeTextBox
		'
		Me.TimeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FilesJoinedNewBindingSource, "Time", True))
		Me.TimeTextBox.Location = New System.Drawing.Point(294, 32)
		Me.TimeTextBox.Name = "TimeTextBox"
		Me.TimeTextBox.Size = New System.Drawing.Size(100, 20)
		Me.TimeTextBox.TabIndex = 22
		'
		'RatingLabel
		'
		RatingLabel.AutoSize = True
		RatingLabel.Location = New System.Drawing.Point(214, 61)
		RatingLabel.Name = "RatingLabel"
		RatingLabel.Size = New System.Drawing.Size(41, 13)
		RatingLabel.TabIndex = 23
		RatingLabel.Text = "Rating:"
		'
		'RatingTextBox
		'
		Me.RatingTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FilesJoinedNewBindingSource, "Rating", True))
		Me.RatingTextBox.Location = New System.Drawing.Point(294, 58)
		Me.RatingTextBox.Name = "RatingTextBox"
		Me.RatingTextBox.Size = New System.Drawing.Size(100, 20)
		Me.RatingTextBox.TabIndex = 24
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
		'TagsTextBox
		'
		Me.TagsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FilesJoinedNewBindingSource, "Tags", True))
		Me.TagsTextBox.Location = New System.Drawing.Point(92, 163)
		Me.TagsTextBox.Name = "TagsTextBox"
		Me.TagsTextBox.Size = New System.Drawing.Size(302, 20)
		Me.TagsTextBox.TabIndex = 28
		'
		'dlgEditForm
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(411, 227)
		Me.Controls.Add(CreatorLabel)
		Me.Controls.Add(Me.CreatorTextBox)
		Me.Controls.Add(LibraryLabel)
		Me.Controls.Add(Me.LibraryTextBox)
		Me.Controls.Add(CDLabel)
		Me.Controls.Add(Me.CDTextBox)
		Me.Controls.Add(YearLabel)
		Me.Controls.Add(Me.YearTextBox)
		Me.Controls.Add(TrackLabel)
		Me.Controls.Add(Me.TrackTextBox)
		Me.Controls.Add(IndexLabel)
		Me.Controls.Add(Me.IndexTextBox)
		Me.Controls.Add(CategoryLabel)
		Me.Controls.Add(Me.CategoryTextBox)
		Me.Controls.Add(SubCategoryLabel)
		Me.Controls.Add(Me.SubCategoryTextBox)
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
	Friend WithEvents CreatorTextBox As System.Windows.Forms.TextBox
	Friend WithEvents LibraryTextBox As System.Windows.Forms.TextBox
	Friend WithEvents CDTextBox As System.Windows.Forms.TextBox
	Friend WithEvents YearTextBox As System.Windows.Forms.TextBox
	Friend WithEvents TrackTextBox As System.Windows.Forms.TextBox
	Friend WithEvents IndexTextBox As System.Windows.Forms.TextBox
	Friend WithEvents CategoryTextBox As System.Windows.Forms.TextBox
	Friend WithEvents SubCategoryTextBox As System.Windows.Forms.TextBox
	Friend WithEvents DescriptionTextBox As System.Windows.Forms.TextBox
	Friend WithEvents TimeTextBox As System.Windows.Forms.TextBox
	Friend WithEvents RatingTextBox As System.Windows.Forms.TextBox
	Friend WithEvents TagsTextBox As System.Windows.Forms.TextBox

End Class
