Imports System.Data.SQLite
Imports System.Data.Linq


Public Class Form1
    Dim AddRowFlg As Boolean

    ''' <summary>
    ''' フォームロード時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Using conn As New SQLiteConnection("Data Source=SampleDb.sqlite")

            ' データベースオープン
            conn.Open()

            ' テーブルが存在しなければ作成
            Using command = conn.CreateCommand()
                Dim sb As New System.Text.StringBuilder()
                sb.Append("CREATE TABLE IF NOT EXISTS MSTKIND (")
                sb.Append("  KIND_CD NCHAR NOT NULL")
                sb.Append("  , KIND_NAME NVARCHAR")
                sb.Append("  , primary key (KIND_CD)")
                sb.Append(")")

                command.CommandText = sb.ToString()
                command.ExecuteNonQuery()

                sb.Clear()
                sb.Append("CREATE TABLE IF NOT EXISTS TBLCAT (")
                sb.Append("  NO INT NOT NULL")
                sb.Append("  , NAME NVARCHAR NOT NULL")
                sb.Append("  , SEX NVARCHAR NOT NULL")
                sb.Append("  , AGE INT DEFAULT 0 NOT NULL")
                sb.Append("  , KIND_CD NCHAR DEFAULT 0 NOT NULL")
                sb.Append("  , FAVORITE NVARCHAR")
                sb.Append("  , primary key (NO)")
                sb.Append(")")

                command.CommandText = sb.ToString()
                command.ExecuteNonQuery()

            End Using

            ' 種別コンボボックスの内容をデータベースから取得して設定
            Using con As New DataContext(conn)
                Dim kinds As Table(Of Kind) = con.GetTable(Of Kind)
                Dim result As IQueryable(Of Kind) = From x In kinds Order By x.KindCd Select x

                Dim empty As New Kind()
                empty.KindCd = ""
                empty.KindName = "指定なし"

                Dim list = result.ToList()
                list.Insert(0, empty)

                ' コンボボックスに設定
                cmbKind.DataSource = list
                cmbKind.DisplayMember = "kindName"

            End Using

            ' データベースクローズ
            conn.Close()

        End Using

    End Sub

    ''' <summary>
    ''' 検索ボタンクリックイベント.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search()
    End Sub


    ''' <summary>
    ''' 検索処理
    ''' </summary>
    Private Sub search()
        Using conn As New SQLiteConnection("Data Source=SampleDb.sqlite")

            ' データベースオープン
            conn.Open()

            ' 検索条件を指定してデータを取得
            Using con As New DataContext(conn)
                Dim searchName As String = txtName.Text
                Dim searchKind As String = CType(cmbKind.SelectedValue, Kind).KindCd

                ' 種別マスタ取得
                Dim kinds As Table(Of Kind) = con.GetTable(Of Kind)
                Dim kindResult As IQueryable(Of Kind) = From x In kinds Order By x.KindCd Select x
                Dim kindList = kindResult.ToList()

                ' 猫一覧取得
                Dim tblCat As Table(Of Cat) = con.GetTable(Of Cat)
                Dim result As IQueryable(Of Cat)

                If (searchKind = "") Then

                    ' 種別が選択されていなければ名前のみ前方一致指定
                    result = From x In tblCat
                             Where x.Name.StartsWith(searchName)
                             Order By x.No
                             Select x
                Else

                    ' 種別が選択されていれば名前＋種別で検索
                    result = From x In tblCat
                             Where x.Name.StartsWith(searchName) And x.KindCd = searchKind
                             Order By x.No
                             Select x
                End If

                ' データグリッドビューに設定
                'dgvCat.DataSource = result.ToList()
                Dim list As List(Of Cat) = result.ToList()
                Dim i As Integer = 0
                dgvCat.Rows.Clear()
                For i = 0 To list.Count() - 1

                    Dim cat = list(i)

                    ' 行追加
                    dgvCat.Rows.Add()

                    ' No（プライマリなので編集不可）
                    Dim no = New DataGridViewTextBoxCell()
                    no.Value = cat.No
                    dgvCat(0, i) = no
                    dgvCat(0, i).ReadOnly = True

                    ' 名前
                    Dim name = New DataGridViewTextBoxCell()
                    name.Value = cat.Name
                    dgvCat(1, i) = name

                    ' 性別
                    Dim sex = New DataGridViewComboBoxCell()
                    sex.Items.AddRange({"♂", "♀"})
                    sex.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                    dgvCat(2, i) = sex
                    dgvCat(2, i).Value = cat.Sex

                    ' 年齢
                    Dim age = New DataGridViewTextBoxCell()
                    age.Value = cat.Age
                    dgvCat(3, i) = age

                    ' 種別
                    Dim kind = New DataGridViewComboBoxCell()
                    kind.DataSource = kindList
                    kind.DisplayMember = "KindName"
                    kind.ValueMember = "KindCd"
                    kind.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                    dgvCat(4, i) = kind
                    dgvCat(4, i).Value = cat.KindCd

                    ' 好物
                    Dim favorite = New DataGridViewTextBoxCell()
                    favorite.Value = cat.Favorite
                    dgvCat(5, i) = favorite

                Next

            End Using

            ' データベースクローズ
            conn.Close()

        End Using
    End Sub
    ''' <summary>
    ''' 追加ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        ' 追加後に更新されていなければ処理しない
        If (AddRowFlg) Then
            Return
        End If

        AddRowFlg = True

        Using conn As New SQLiteConnection("Data Source=SampleDb.sqlite")

            ' データベースオープン
            conn.Open()

            ' データ追加
            Using con As New DataContext(conn)

                Dim idx = dgvCat.Rows.Count()

                ' 行追加
                dgvCat.Rows.Add()

                ' 種別マスタ取得
                Dim kinds As Table(Of Kind) = con.GetTable(Of Kind)
                Dim kindResult As IQueryable(Of Kind) = From x In kinds Order By x.KindCd Select x
                Dim kindList = kindResult.ToList()

                ' 猫一覧取得
                Dim tblCat As Table(Of Cat) = con.GetTable(Of Cat)
                Dim newNo = 0

                ' 使用できるNoを判定
                For i As Integer = 1 To tblCat.ToList().Count() + 1
                    Dim selectNo = i
                    If tblCat.SingleOrDefault(Function(x As Cat) x.No = selectNo) Is Nothing Then
                        newNo = selectNo
                    End If
                Next

                ' No（プライマリなので編集不可）
                Dim no = New DataGridViewTextBoxCell()
                no.Value = newNo
                dgvCat(0, idx) = no
                dgvCat(0, idx).ReadOnly = True

                ' 名前
                Dim name = New DataGridViewTextBoxCell()
                dgvCat(1, idx) = name

                ' 性別
                Dim sex = New DataGridViewComboBoxCell()
                sex.Items.AddRange({"♂", "♀"})
                sex.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                dgvCat(2, idx) = sex

                ' 年齢
                Dim age = New DataGridViewTextBoxCell()
                dgvCat(3, idx) = age

                ' 種別
                Dim kind = New DataGridViewComboBoxCell()
                kind.DataSource = kindList
                kind.DisplayMember = "KindName"
                kind.ValueMember = "KindCd"
                kind.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                dgvCat(4, idx) = kind

                ' 好物
                Dim favorite = New DataGridViewTextBoxCell()
                dgvCat(5, idx) = favorite

            End Using

            conn.Close()

        End Using

    End Sub

    ''' <summary>
    ''' 更新ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Using conn As New SQLiteConnection("Data Source=SampleDb.sqlite")

            ' データベースオープン
            conn.Open()

            ' データ更新
            Using con As New DataContext(conn)
                ' 対象のテーブルオブジェクトを取得
                Dim Table = con.GetTable(Of Cat)
                ' 選択されているデータを取得
                For i = 0 To dgvCat.Rows.Count - 1
                    ' テーブルから対象のデータを取得
                    Dim no As Integer = dgvCat(0, i).Value
                    Dim target As Cat = Table.SingleOrDefault(Function(x As Cat) x.No = no)
                    If (target Is Nothing) Then
                        ' データ作成
                        Dim Cat As New Cat()
                        Cat.No = dgvCat(0, i).Value
                        Cat.Name = dgvCat(1, i).Value
                        Cat.Sex = dgvCat(2, i).Value
                        Cat.Age = dgvCat(3, i).Value
                        Cat.KindCd = dgvCat(4, i).Value
                        Cat.Favorite = dgvCat(5, i).Value
                        Table.InsertOnSubmit(Cat)

                    Else

                        ' データ変更
                        target.Name = dgvCat(1, i).Value
                        target.Sex = dgvCat(2, i).Value
                        target.Age = dgvCat(3, i).Value
                        target.KindCd = dgvCat(4, i).Value
                        target.Favorite = dgvCat(5, i).Value

                    End If
                    ' DBの変更を確定
                    con.SubmitChanges()
                Next

            End Using

            conn.Close()
        End Using

        AddRowFlg = False

        ' データ再検索
        search()
        MessageBox.Show("データを更新しました。")

    End Sub
    ''' <summary>
    ''' 削除ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Using conn As New SQLiteConnection("Data Source=SampleDb.sqlite")

            ' データベースオープン
            conn.Open()

            ' データ削除
            Using con As New DataContext(conn)

                ' 対象のテーブルオブジェクトを取得
                Dim Table = con.GetTable(Of Cat)
                ' 選択されているデータを取得
                For Each r As DataGridViewRow In dgvCat.SelectedRows
                    Dim Cat As Cat = CType(dgvCat.DataSource(), List(Of Cat)).Item(r.Index)
                    ' テーブルから対象のデータを取得
                    Dim target As Cat = Table.Single(Function(x As Cat) x.No = Cat.No)
                    ' データ削除
                    Table.DeleteOnSubmit(target)
                    ' DBの変更を確定
                    con.SubmitChanges()

                Next

            End Using

            conn.Close()
        End Using

        ' データ再検索
        search()
        MessageBox.Show("データを削除しました。")

    End Sub

    ''' <summary>
    ''' データグリッドビューセルクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgvCat_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCat.CellClick
        Dim dgv As DataGridView = CType(sender, DataGridView)
        gridComboHandle(dgv, e)
    End Sub

    ''' <summary>
    ''' データグリッドビューのコンボボックス制御
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <param name="e"></param>
    Private Sub gridComboHandle(dgv As DataGridView, e As DataGridViewCellEventArgs)

        If e.ColumnIndex <> -1 Then
            ' 対象の列だった場合
            If dgv.Columns(e.ColumnIndex).Name = "ColSex" Or dgv.Columns(e.ColumnIndex).Name = "ColKind" Then

                SendKeys.SendWait("{F4}")
            End If

        End If

    End Sub

End Class