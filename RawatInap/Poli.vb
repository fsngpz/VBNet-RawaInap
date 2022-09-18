Imports MySql.Data.MySqlClient
Public Class Poli
    Dim connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=db_rawat_inap")
    Dim id As New TextBox
    Dim jk As New TextBox
    Sub kodePoli()
        Dim urutan As Int32
        Dim a As String


        Dim command As New MySqlCommand("select kode_poli from poli Where kode_poli In(Select Max(kode_poli)From poli)Order By kode_poli Desc", connection)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        'MsgBox(a + 1)
        If table.Rows.Count = 0 Then
            urutan = "1"
            TextBox1.Text = urutan.ToString("D2")

        Else
            a = table.Rows(0).Item(0)
            'MsgBox(a)
            urutan = a + 1
            'MsgBox(urutan)
            TextBox1.Text = urutan.ToString("D2")
        End If
        TextBox1.Enabled = False
    End Sub
    Sub loadData()
        Dim command As New MySqlCommand("Select * from poli order by kode_poli asc", connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)
        DataGridView1.DataSource = table
        'DataGridView1.DataSource = (ds.Tables("pasien"))
        DataGridView1.Columns(0).HeaderText = "Kode Poli"
        DataGridView1.Columns(1).HeaderText = "Nama Poli"
        DataGridView1.AutoResizeColumns()
        DataGridView1.Columns(1).Width = 293
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gray
    End Sub
    Private Sub Poli_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
        Button4.Enabled = False
        Button5.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = True
        Button5.Enabled = True
        TextBox1.Text = ""
        TextBox1.Enabled = True
        TextBox2.Text = ""
        TextBox2.Enabled = True
        TextBox1.Focus()
        kodePoli()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim edit As String
            edit = "update poli set nama_poli = '" & TextBox2.Text & "' where kode_poli = " & id.Text & ""
            If TextBox1.Text = "" Then
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
            TextBox1.Enabled = False
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub


    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Enabled = False
        TextBox2.Enabled = True

        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        Me.id.Text = DataGridView1.Item(0, i).Value
        Me.TextBox1.Text = DataGridView1.Item(0, i).Value
        Me.TextBox2.Text = DataGridView1.Item(1, i).Value
        Button2.Enabled = True
        Button4.Enabled = False
        Button5.Enabled = True

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If id.Text = "" Then
            MsgBox("Silahkan Pilih Data yang akan di hapus")
        Else
            If MessageBox.Show("Yakin akan dihapus..?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String = "delete From poli  where kode_poli='" & id.Text & "'"
                Dim cmd As New MySqlCommand(hapus, connection)

                connection.Open()
                cmd.ExecuteNonQuery()
                connection.Close()

                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox1.Enabled = False
                TextBox2.Enabled = False
                MsgBox("Data Berhasil Dihapus", MsgBoxStyle.Information)
                loadData()

            End If
        End If
        Button5.Enabled = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Button5.Enabled = False
        If TextBox1.Text = "" Then
            MsgBox("Silahkan Isi Semua Form", MsgBoxStyle.Critical, "Error Message")
        Else
            If MessageBox.Show("Apakah Yakin Akan Menyimpan...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Try

                    Dim simpan As String = "insert into poli (kode_poli,nama_poli) values ('" & TextBox1.Text & "','" & TextBox2.Text & "')"
                    Dim command As New MySqlCommand(simpan, connection)
                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()
                    MsgBox("Input data berhasil")
                    TextBox1.Text = ""
                    TextBox2.Text = ""

                    TextBox1.Enabled = False
                    TextBox2.Enabled = False
                    loadData()
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
                End Try

            End If

        End If
        Button4.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
    End Sub
End Class