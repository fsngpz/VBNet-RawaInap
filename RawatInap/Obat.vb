Imports MySql.Data.MySqlClient
Public Class Obat
    Dim id As New TextBox
    Dim jk As New TextBox
    Dim connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=db_rawat_inap")
    Private Sub Obat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
        Button4.Enabled = False
        Button5.Enabled = False

        Dim command As New MySqlCommand("select * FROM poli", connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        For Each row As DataRow In table.Rows
            ComboBox1.Items.Add(row.Item(1))
        Next
    End Sub

    Sub loadData()

        Dim command As New MySqlCommand("Select * from obat", connection)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView1.DataSource = table
        'DataGridView1.DataSource = (ds.Tables("pasien"))
        DataGridView1.Columns(0).HeaderText = "Kode Obat"
        DataGridView1.Columns(1).HeaderText = "Nama Obat"
        DataGridView1.Columns(2).HeaderText = "Kategori"
        DataGridView1.Columns(3).HeaderText = "Jenis"
        DataGridView1.Columns(4).HeaderText = "Harga"
        DataGridView1.Columns(4).DefaultCellStyle.Format = "##,0"
        DataGridView1.Columns(5).HeaderText = "Jumlah"
        DataGridView1.AutoResizeColumns()
        DataGridView1.Columns(5).Width = 83
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gray
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        'If (Not e.KeyChar = ChrW(Keys.Back) And ("0123456789.").IndexOf(e.KeyChar) = -1) Or (e.KeyChar = "." And TextBox3.Text.ToCharArray().Count(Function(c) c = ".") > 0) Then
        '    e.Handled = True
        'End If
        'If e.KeyChar = Chr(13) Then
        '    TextBox3.Text = FormatNumber(TextBox3.Text, 0) ' ini format angka
        'End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

        'If IsNumeric(TextBox3.Text) Then

        '    Dim temp As Integer = TextBox3.Text

        '    TextBox3.Text = Format(temp, "N")

        '    TextBox3.SelectionStart = TextBox3.TextLength - 3


        'End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        refreshdata()
        'TextBox1.Text = ""
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True


        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        Me.id.Text = DataGridView1.Item(0, i).Value
        Me.ComboBox2.SelectedItem = DataGridView1.Item(3, i).Value
        'MsgBox("data2 " & DataGridView1.Item(2, i).Value)
        Me.ComboBox1.SelectedItem = DataGridView1.Item(2, i).Value
        Me.TextBox1.Text = DataGridView1.Item(0, i).Value
        Me.TextBox2.Text = DataGridView1.Item(1, i).Value
        Me.TextBox3.Text = DataGridView1.Item(4, i).Value
        Me.TextBox4.Text = DataGridView1.Item(5, i).Value
        Button2.Enabled = True
        Button4.Enabled = False
        Button5.Enabled = True
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If (Not e.KeyChar = ChrW(Keys.Back) And ("0123456789.").IndexOf(e.KeyChar) = -1) Or (e.KeyChar = "." And TextBox4.Text.ToCharArray().Count(Function(c) c = ".") > 0) Then
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            TextBox4.Text = FormatNumber(TextBox4.Text, 0) ' ini format angka
        End If
    End Sub
    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub
    Sub refreshdata()
        Dim urutan As String
        Dim hitung As Int32
        Dim command As New MySqlCommand("Select kode_obat From obat where kode_obat like '%" & ComboBox1.SelectedItem & "%' order by kode_obat desc LIMIT 1", connection)
        'MsgBox("Select kode_obat From obat where kode_obat = '" & ComboBox1.SelectedItem & "' order by kode_obat desc limit 1")

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If table.Rows.Count = 0 Then
            urutan = ComboBox1.SelectedItem & "01"
            TextBox1.Text = urutan

        Else
            Dim substrdata As String
            substrdata = ComboBox1.SelectedItem
            'MsgBox(RD.GetString(0))
            'MsgBox(substrdata.Length - 1)
            hitung = Microsoft.VisualBasic.Right(table.Rows(0).Item(0), 1) + 1
            'MsgBox(Microsoft.VisualBasic.Right(RD.GetString(0), 5))
            'MsgBox("000" & hitung)
            If hitung > 9 Then
                urutan = ComboBox1.SelectedItem & "" & hitung & ""
                'Dim substrdata As String
                'substrdata = ComboBox1.SelectedItem
                'Console.WriteLine(substrdata)
                'Data = substrdata.Substring(0, substrdata.Length)
                'Console.WriteLine(Data)
                'MsgBox(RD.HasRows)
                TextBox1.Text = urutan
            Else
                'MsgBox(hitung.ToString("D2"))

                urutan = ComboBox1.SelectedItem + hitung.ToString("D2")
                TextBox1.Text = urutan
            End If

        End If
        TextBox1.Enabled = False
        Return
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = True
        Button5.Enabled = True
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True

        ComboBox1.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim edit As String
            'nama_dokter,spesialis,alamat,telpon,kode_poli,tarif
            edit = "update obat set nama_obat = '" & TextBox2.Text & "', jenis = '" & ComboBox2.SelectedItem & "', kategori_obat = '" & ComboBox1.SelectedItem & "', harga = '" & TextBox3.Text & "', jumlah = '" & TextBox4.Text & "'  where kode_obat = '" & id.Text & "'"

            'MsgBox(edit)

            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.SelectedItem = "" Or ComboBox2.SelectedItem = "" Then
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
            TextBox4.Text = ""
            ComboBox1.SelectedItem = ""
            ComboBox2.SelectedItem = ""
            TextBox1.Text = ""

            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
        Button5.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If id.Text = "" Then
            MsgBox("Silahkan Pilih Data yang akan di hapus")
        Else
            If MessageBox.Show("Yakin akan dihapus..?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                'MsgBox(id.Text)
                Dim hapus As String = "delete From obat where kode_obat='" & id.Text & "'"
                Dim command As New MySqlCommand(hapus, connection)
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                ComboBox1.SelectedItem = ""
                ComboBox2.SelectedItem = ""
                TextBox1.Text = ""

                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                ComboBox1.Enabled = False
                ComboBox2.Enabled = False

                MsgBox("Data Berhasil Dihapus", MsgBoxStyle.Information)
                loadData()

            End If
        End If
        Button5.Enabled = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button5.Enabled = False

        If TextBox1.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.SelectedItem = "" Or ComboBox2.SelectedItem = "" Then
            MsgBox("Silahkan Isi Semua Form", MsgBoxStyle.Critical, "Error Message")
        Else
            If MessageBox.Show("Apakah Yakin Akan Menyimpan...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Try

                    Dim simpan As String = "insert into obat (kode_obat, nama_obat,jenis,kategori_obat,harga,jumlah) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox2.SelectedItem & "','" & ComboBox1.SelectedItem & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"

                    Dim command As New MySqlCommand(simpan, connection)
                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()
                    MsgBox("Input data berhasil")
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    TextBox4.Text = ""
                    ComboBox1.SelectedItem = ""
                    ComboBox2.SelectedItem = ""
                    TextBox1.Text = ""

                    TextBox1.Enabled = False
                    TextBox2.Enabled = False
                    TextBox3.Enabled = False
                    TextBox4.Enabled = False
                    ComboBox1.Enabled = False
                    ComboBox2.Enabled = False

                    loadData()
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
                End Try

            End If
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = False

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.SelectedItem = ""
        ComboBox2.SelectedItem = ""


        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        Button5.Enabled = False

        TextBox1.Text = ""
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox5.Text = "" Then
            loadData()

        Else
            Dim command As New MySqlCommand("Select * From obat where nama_obat like '%" & TextBox5.Text & "%'", connection)
            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()

            adapter.Fill(table)
            DataGridView1.DataSource = table
            If table.Rows.Count = 0 Then
                MsgBox("Data Obat Tidak Ditemukan")
                TextBox5.Focus()
            Else

                DataGridView1.DataSource = table
                'DataGridView1.DataSource = (ds.Tables("pasien"))
                DataGridView1.Columns(0).HeaderText = "Kode Obat"
                DataGridView1.Columns(1).HeaderText = "Nama Obat"
                DataGridView1.Columns(2).HeaderText = "Jenis"
                DataGridView1.Columns(3).HeaderText = "Kategori"
                DataGridView1.Columns(4).HeaderText = "Harga"
                DataGridView1.Columns(4).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(5).HeaderText = "Jumlah"
                DataGridView1.AutoResizeColumns()
                DataGridView1.Columns(5).Width = 83
                DataGridView1.AutoResizeColumns()
                DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gray
            End If
        End If
        Button5.Enabled = True
    End Sub
End Class