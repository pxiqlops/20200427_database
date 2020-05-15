<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cmbKind = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.dgvCat = New System.Windows.Forms.DataGridView()
        Me.a = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.d = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.e = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvCat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(87, 40)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(116, 22)
        Me.txtName.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(414, 34)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 33)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "検索"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cmbKind
        '
        Me.cmbKind.FormattingEnabled = True
        Me.cmbKind.Location = New System.Drawing.Point(269, 39)
        Me.cmbKind.Name = "cmbKind"
        Me.cmbKind.Size = New System.Drawing.Size(121, 23)
        Me.cmbKind.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "名前："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(218, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "種類："
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(27, 421)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 28)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "追加"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(109, 420)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 28)
        Me.btnUpdate.TabIndex = 8
        Me.btnUpdate.Text = "更新"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(191, 421)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 28)
        Me.btnDelete.TabIndex = 9
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'dgvCat
        '
        Me.dgvCat.AllowUserToAddRows = False
        Me.dgvCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.a, Me.b, Me.ColSex, Me.d, Me.e, Me.f})
        Me.dgvCat.Location = New System.Drawing.Point(27, 103)
        Me.dgvCat.Name = "dgvCat"
        Me.dgvCat.RowHeadersWidth = 51
        Me.dgvCat.RowTemplate.Height = 24
        Me.dgvCat.Size = New System.Drawing.Size(1031, 311)
        Me.dgvCat.TabIndex = 4
        '
        'a
        '
        Me.a.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.a.FillWeight = 50.0!
        Me.a.HeaderText = "No"
        Me.a.MinimumWidth = 6
        Me.a.Name = "a"
        Me.a.Width = 50
        '
        'b
        '
        Me.b.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.b.FillWeight = 50.0!
        Me.b.HeaderText = "名前"
        Me.b.MinimumWidth = 6
        Me.b.Name = "b"
        Me.b.Width = 150
        '
        'ColSex
        '
        Me.ColSex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColSex.HeaderText = "性別"
        Me.ColSex.MinimumWidth = 6
        Me.ColSex.Name = "ColSex"
        Me.ColSex.Width = 60
        '
        'd
        '
        Me.d.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.d.HeaderText = "年齢"
        Me.d.MinimumWidth = 6
        Me.d.Name = "d"
        Me.d.Width = 60
        '
        'e
        '
        Me.e.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.e.HeaderText = "種別"
        Me.e.MinimumWidth = 6
        Me.e.Name = "e"
        Me.e.Width = 200
        '
        'f
        '
        Me.f.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.f.HeaderText = "好物"
        Me.f.MinimumWidth = 6
        Me.f.Name = "f"
        Me.f.Width = 200
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1092, 479)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvCat)
        Me.Controls.Add(Me.cmbKind)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtName)
        Me.Name = "Form1"
        Me.Text = "一覧表"
        CType(Me.dgvCat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtName As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents cmbKind As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents dgvCat As DataGridView
    Friend WithEvents a As DataGridViewTextBoxColumn
    Friend WithEvents b As DataGridViewTextBoxColumn
    Friend WithEvents ColSex As DataGridViewTextBoxColumn
    Friend WithEvents d As DataGridViewTextBoxColumn
    Friend WithEvents e As DataGridViewTextBoxColumn
    Friend WithEvents f As DataGridViewTextBoxColumn
End Class
