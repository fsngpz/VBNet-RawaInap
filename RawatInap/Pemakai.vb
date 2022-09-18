Imports MySql.Data.MySqlClient

Public Class Pemakai
    Dim id As New TextBox
    Dim jk As New TextBox
    Dim connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=db_rawat_inap")
    Private Sub Pemakai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
        Button4.Enabled = False
        Button5.Enabled = False
    End Sub


    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ComboBox1.Enabled = True
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True


        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        Me.id.Text = DataGridView1.Item(0, i).Value
        Me.ComboBox1.SelectedItem = DataGridView1.Item(3, i).Value
        Me.TextBox1.Text = DataGridView1.Item(0, i).Value
        Me.TextBox2.Text = DataGridView1.Item(1, i).Value
        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(DataGridView1.Item(2, i).Value)
        Dim s As String = DataGridView1.Item(2, i).Value
        'Me.TextBox3.Text = Convert.ToString(DataGridView1.Item(2, i).Value)

        Button2.Enabled = True
        Button4.Enabled = False
        Button5.Enabled = True
    End Sub

    Sub loadData()
        Dim command As New MySqlCommand("Select * from pemakai", connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)
        DataGridView1.DataSource = table
        'DataGridView1.DataSource = (ds.Tables("pasien"))
        DataGridView1.Columns(0).HeaderText = "Kode"
        DataGridView1.Columns(1).HeaderText = "Nama"

        DataGridView1.Columns(2).Visible = False
        DataGridView1.Columns(3).HeaderText = "Status"
        DataGridView1.AutoResizeColumns()
        DataGridView1.Columns(1).Width = 180
        DataGridView1.Columns(3).Width = 150
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gray
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = True
        Button5.Enabled = True
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""

        TextBox1.Enabled = False
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        ComboBox1.Enabled = True

        ComboBox1.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim edit As String
            Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(TextBox3.Text)

            'edit = "update pemakai set password = '" & Convert.ToBase64String(byt) & "',status = '" & ComboBox1.SelectedItem & "' where kode_pemakai = '" & id.Text & "'"
            edit = "UPDATE    pemakai SET [password] = '" & Convert.ToBase64String(byt) & "', status = '" & ComboBox1.SelectedItem & "' WHERE     (kode_pemakai = '" & id.Text & "')"
            'MsgBox(edit)
            'Clipboard.SetText(CStr(edit))
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.SelectedItem = "" Then
                MsgBox("Data Gagal Diupdate", MsgBoxStyle.Critical, "Error Message")
            Else
                Dim command As New MySqlCommand(edit, connection)

                connection.Open()

                command.ExecuteNonQuery()

                connection.Close()

                MsgBox("Data Berhasil diUpdate")
                loadData()

            End If
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            ComboBox1.SelectedItem = ""


            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            ComboBox1.Enabled = False
            Button5.Enabled = False

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If id.Text = "" Then
            MsgBox("Silahkan Pilih Data yang akan di hapus")
        Else
            If MessageBox.Show("Yakin akan dihapus..?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String = "delete From pemakai  where kode_pemakai ='" & id.Text & "'"
                Dim command As New MySqlCommand(hapus, connection)
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
                ComboBox1.SelectedItem = ""
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""

                ComboBox1.Enabled = False
                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False

                MsgBox("Data Berhasil Dihapus", MsgBoxStyle.Information)
                loadData()

            End If
        End If
        Button5.Enabled = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        refreshData()

    End Sub

    Sub refreshData()

        Dim urutan As String
        Dim hitung As Long
        Dim command As New MySqlCommand("Select kode_pemakai From pemakai where kode_pemakai like '%" & ComboBox1.SelectedItem & "%' order by kode_pemakai desc limit 1", connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)
        If table.Rows.Count = 0 Then
            urutan = ComboBox1.SelectedItem & "1"
            TextBox1.Text = urutan

        Else
            Dim substrdata As String
            substrdata = ComboBox1.SelectedItem
            hitung = Microsoft.VisualBasic.Right(table.Rows(0).Item(0), 1) + 1
            urutan = ComboBox1.SelectedItem & "" & hitung & ""
            TextBox1.Text = urutan
        End If
        TextBox1.Enabled = False
        Return
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click


        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.SelectedItem = "" Then
            MsgBox("Silahkan Isi Semua Form", MsgBoxStyle.Critical, "Error Message")
        Else
            If MessageBox.Show("Apakah Yakin Akan Menyimpan...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Try


                    Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(TextBox3.Text)

                    Dim simpan As String = "insert into pemakai values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & Convert.ToBase64String(byt) & "','" & ComboBox1.SelectedItem & "')"

                    Dim command As New MySqlCommand(simpan, connection)
                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()
                    MsgBox("Input data berhasil")
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    ComboBox1.SelectedItem = ""

                    TextBox1.Enabled = False
                    TextBox2.Enabled = False
                    TextBox3.Enabled = False
                    ComboBox1.Enabled = False
                    TextBox1.Text = ""
                    loadData()
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
                End Try

            End If

        End If
        Button5.Enabled = False
        Button2.Enabled = True
        Button2.Enabled = True
        Button4.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.SelectedItem = ""

        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        ComboBox1.Enabled = False
        Button5.Enabled = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox5.Text = "" Then
            loadData()

        Else
            Dim command As New MySqlCommand("Select * From pemakai where description like '%" & TextBox5.Text & "%'", connection)
            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()

            adapter.Fill(table)
            If table.Rows.Count = 0 Then
                MsgBox("Data Pemakai Tidak Ditemukan")
                TextBox5.Focus()
            Else
                DataGridView1.DataSource = table
                DataGridView1.Columns(0).HeaderText = "Kode"
                DataGridView1.Columns(1).HeaderText = "Nama"

                DataGridView1.Columns(2).Visible = False
                DataGridView1.Columns(3).HeaderText = "Status"
                DataGridView1.AutoResizeColumns()
                DataGridView1.Columns(1).Width = 180
                DataGridView1.Columns(3).Width = 150
                DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gray
            End If
        End If
        Button5.Enabled = True
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class