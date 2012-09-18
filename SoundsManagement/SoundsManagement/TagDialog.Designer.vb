<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TagDialog
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
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
		Me.OK_Button = New System.Windows.Forms.Button()
		Me.Cancel_Button = New System.Windows.Forms.Button()
		Me.cbTags = New System.Windows.Forms.ComboBox()
		Me.SoundsDataSet = New SoundsManagement.SoundsDataSet()
		Me.TagsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.TagsTableAdapter = New SoundsManagement.SoundsDataSetTableAdapters.TagsTableAdapter()
		Me.txtTag = New System.Windows.Forms.TextBox()
		Me.btnInsertTag = New System.Windows.Forms.Button()
		Me.TableLayoutPanel1.SuspendLayout()
		CType(Me.SoundsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TagsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(132, 71)
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
		'cbTags
		'
		Me.cbTags.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cbTags.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cbTags.DataSource = Me.TagsBindingSource
		Me.cbTags.DisplayMember = "Description"
		Me.cbTags.FormattingEnabled = True
		Me.cbTags.Location = New System.Drawing.Point(13, 13)
		Me.cbTags.Name = "cbTags"
		Me.cbTags.Size = New System.Drawing.Size(121, 21)
		Me.cbTags.TabIndex = 1
		'
		'SoundsDataSet
		'
		Me.SoundsDataSet.DataSetName = "SoundsDataSet"
		Me.SoundsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
		'
		'TagsBindingSource
		'
		Me.TagsBindingSource.DataMember = "Tags"
		Me.TagsBindingSource.DataSource = Me.SoundsDataSet
		'
		'TagsTableAdapter
		'
		Me.TagsTableAdapter.ClearBeforeFill = True
		'
		'txtTag
		'
		Me.txtTag.Location = New System.Drawing.Point(13, 40)
		Me.txtTag.Name = "txtTag"
		Me.txtTag.Size = New System.Drawing.Size(265, 20)
		Me.txtTag.TabIndex = 2
		'
		'btnInsertTag
		'
		Me.btnInsertTag.Location = New System.Drawing.Point(140, 11)
		Me.btnInsertTag.Name = "btnInsertTag"
		Me.btnInsertTag.Size = New System.Drawing.Size(75, 23)
		Me.btnInsertTag.TabIndex = 3
		Me.btnInsertTag.Text = "Insert"
		Me.btnInsertTag.UseVisualStyleBackColor = True
		'
		'TagDialog
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(290, 112)
		Me.Controls.Add(Me.btnInsertTag)
		Me.Controls.Add(Me.txtTag)
		Me.Controls.Add(Me.cbTags)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "TagDialog"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "TagDialog"
		Me.TableLayoutPanel1.ResumeLayout(False)
		CType(Me.SoundsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.TagsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button
	Friend WithEvents cbTags As System.Windows.Forms.ComboBox
	Friend WithEvents SoundsDataSet As SoundsManagement.SoundsDataSet
	Friend WithEvents TagsBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents TagsTableAdapter As SoundsManagement.SoundsDataSetTableAdapters.TagsTableAdapter
	Friend WithEvents txtTag As System.Windows.Forms.TextBox
	Friend WithEvents btnInsertTag As System.Windows.Forms.Button

End Class
