Imports MySql.Data.MySqlClient
Public Class Kamar
    Dim store As String
    Dim connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=db_rawat_inap")
    Private Sub Kamar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
    End Sub


    Sub loadData()
        Dim command As New MySqlCommand("Select * from kamar", connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)
        DataGridView1.DataSource = table
        'DataGridView1.DataSource = (ds.Tables("pasien"))
        DataGridView1.Columns(0).HeaderText = "Kode"
        DataGridView1.Columns(1).HeaderText = "Nama"

        DataGridView1.Columns(2).HeaderText = "Jenis"
        DataGridView1.Columns(3).HeaderText = "Tarif"
        DataGridView1.AutoResizeColumns()
        DataGridView1.Columns(1).Width = 180
        DataGridView1.Columns(3).Width = 150
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gray
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If Not TextBox1.Text = "" Then
            Dim command As New MySqlCommand("Select * from kamar where nama_kamar like  '%" & TextBox1.Text & "%'", connection)
            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()

            adapter.Fill(table)

            If table.Rows.Count = 0 Then
                TextBox3.Text = TextBox1.Text & "01"
            Else

                For i As Integer = 1 To 100
                    If i > 10 Then
                        TextBox3.Text = TextBox1.Text & i
                    Else
                        TextBox3.Text = TextBox1.Text & "0" & i
                    End If

                    Console.WriteLine(TextBox3.Text)
                    Console.WriteLine("Select * from kamar where kode_kamar like  '%" & TextBox3.Text & "%'")
                    Dim command1 As New MySqlCommand("Select * from kamar where kode_kamar like  '%" & TextBox3.Text & "%'", connection)
                    Dim adapter1 As New MySqlDataAdapter(command1)
                    Dim table1 As New DataTable()

                    adapter1.Fill(table1)
                    If table1.Rows.Count = 0 Then
                        Exit For
                    End If
                Next

            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Enabled = True
        ComboBox2.Enabled = True
        TextBox2.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click


        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox2.SelectedItem = "" Then
            MsgBox("Silahkan Isi Semua Form", MsgBoxStyle.Critical, "Error Message")
        Else
            If MessageBox.Show("Apakah Yakin Akan Menyimpan...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Try


                    Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(TextBox3.Text)

                    Dim simpan As String = "insert into kamar values ('" & TextBox3.Text & "','" & TextBox1.Text & "','" & ComboBox2.SelectedItem & "','" & TextBox2.Text & "')"

                    Dim command As New MySqlCommand(simpan, connection)
                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()
                    MsgBox("Input data berhasil")
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    ComboBox2.SelectedItem = ""

                    TextBox1.Enabled = False
                    TextBox2.Enabled = False
                    TextBox3.Enabled = False
                    ComboBox2.Enabled = False
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim edit As String

            'edit = "update pemakai set password = '" & Convert.ToBase64String(byt) & "',status = '" & ComboBox1.SelectedItem & "' where kode_pemakai = '" & id.Text & "'"
            edit = "UPDATE    kamar SET kode_kamar = '" & TextBox3.Text & "', nama_kamar = '" & TextBox1.Text & "', jenis_kamar = '" & ComboBox2.SelectedItem & "', tarif = '" & TextBox2.Text & "' WHERE     (kode_kamar = '" & Me.store & "')"
            'MsgBox(edit)
            Clipboard.SetText(CStr(edit))
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox2.SelectedItem = "" Then
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
            ComboBox2.SelectedItem = ""


            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            ComboBox2.Enabled = False
            Button5.Enabled = False

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ComboBox2.Enabled = True
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True


        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        Me.TextBox3.Text = DataGridView1.Item(0, i).Value
        Me.TextBox1.Text = DataGridView1.Item(1, i).Value
        Me.ComboBox2.SelectedItem = DataGridView1.Item(2, i).Value
        Me.TextBox2.Text = DataGridView1.Item(3, i).Value

        Me.store = DataGridView1.Item(0, i).Value

        Button2.Enabled = True
        Button4.Enabled = False
        Button5.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Me.store = "" Then
            MsgBox("Silahkan Pilih Data yang akan di hapus")
        Else
            If MessageBox.Show("Yakin akan dihapus..?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String = "delete From kamar  where kode_kamar ='" & Me.store & "'"
                Dim command As New MySqlCommand(hapus, connection)
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
                ComboBox2.SelectedItem = ""
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""

                ComboBox2.Enabled = False
                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False

                MsgBox("Data Berhasil Dihapus", MsgBoxStyle.Information)
                loadData()

            End If
        End If
        Button5.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox2.SelectedItem = ""

        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        ComboBox2.Enabled = False
        Button5.Enabled = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox5.Text = "" Then
            loadData()

        Else
            Dim command As New MySqlCommand("Select * From kamar where nama_kamar like '%" & TextBox5.Text & "%'", connection)
            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()

            adapter.Fill(table)
            If table.Rows.Count = 0 Then
                MsgBox("Data Kamar Tidak Ditemukan")
                TextBox5.Focus()
            Else
                DataGridView1.DataSource = table
                DataGridView1.Columns(0).HeaderText = "Kode"
                DataGridView1.Columns(1).HeaderText = "Nama"

                DataGridView1.Columns(2).HeaderText = "Jenis"
                DataGridView1.Columns(3).HeaderText = "Tarif"
                DataGridView1.AutoResizeColumns()
                DataGridView1.Columns(1).Width = 180
                DataGridView1.Columns(3).Width = 150
                DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gray
            End If
        End If
        Button5.Enabled = True
    End Sub
End Class