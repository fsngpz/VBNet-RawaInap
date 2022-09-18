Imports MySql.Data.MySqlClient
Public Class Dokter
    Dim id As New TextBox
    Dim jk As New TextBox
    Dim connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=db_rawat_inap")
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        kodeDokter()

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

        ComboBox1.Focus()

    End Sub

    Sub kodeDokter()
        Dim urutan As Int32
        Dim formatnya As Int32
        Dim newstring As String
        'Dim hitung As Long
        Dim a As String

        Dim command As New MySqlCommand("select kode_dokter from dokter Where kode_dokter In(Select Max(kode_dokter)From dokter)Order By kode_dokter Desc", connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)


        'MsgBox(a + 1)
        If table.Rows.Count = 0 Then
            formatnya = Format(Now, "MM")

            If formatnya > 9 Then
                urutan = formatnya.ToString() + "001"
                'MsgBox(urutan)
                TextBox6.Text = urutan

            Else
                newstring = Format(Now, "MM") + "001"
                TextBox6.Text = newstring
            End If

            'MsgBox(urutan.ToString("D2"))


        Else

            a = table.Rows(0).Item(0)
            Dim x As Int32
            x = Microsoft.VisualBasic.Right(a, 3) + 1
            'MsgBox(x.ToString("D3"))
            If x > 9 Then
                urutan = formatnya.ToString() + x.ToString("D2")
                TextBox6.Text = urutan
            ElseIf x > 99 Then
                urutan = formatnya.ToString() + x
                TextBox6.Text = urutan
            Else
                newstring = Format(Now, "MM") + x.ToString("D3")
                'MsgBox(newstring)
                TextBox6.Text = newstring
            End If



        End If
        TextBox6.Enabled = False

        Return
    End Sub

    Private Sub Dokter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
        Button4.Enabled = False
        Button5.Enabled = False

        Dim command As New MySqlCommand("SELECT * FROM poli order by kode_poli asc", connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)
        For Each row As DataRow In table.Rows
            ComboBox1.Items.Add(row.Item(1))
        Next
    End Sub

    Sub loadData()
        Dim command As New MySqlCommand("SELECT * FROM dokter", connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)
        DataGridView1.DataSource = table

        DataGridView1.Columns(0).HeaderText = "Kode Dokter"
        DataGridView1.Columns(1).HeaderText = "Nama Dokter"
        DataGridView1.Columns(2).HeaderText = "Spesialis"
        DataGridView1.Columns(3).HeaderText = "Alamat"
        DataGridView1.Columns(4).HeaderText = "Telpon"
        DataGridView1.Columns(5).HeaderText = "Kode Poli"
        DataGridView1.Columns(6).HeaderText = "Tarif"
        DataGridView1.Columns(6).DefaultCellStyle.Format = "##,0"
        DataGridView1.AutoResizeColumns()
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gray
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim edit As String
            'nama_dokter,spesialis,alamat,telpon,kode_poli,tarif
            Dim convert As Int32
            convert = ComboBox1.SelectedIndex
            Dim result As String
            If convert > 9 Then
                result = ComboBox1.SelectedIndex
            Else
                result = convert.ToString("D2")
            End If
            edit = "update dokter set nama_dokter = '" & TextBox1.Text & "', spesialis = '" & ComboBox1.SelectedItem & "', alamat = '" & TextBox2.Text & "', telpon = '" & TextBox3.Text & "', kode_poli = '" & result & "', tarif = '" & TextBox4.Text & "'  where kode_dokter = '" & id.Text & "'"
            'Clipboard.SetText(CStr(edit))
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.SelectedItem = "" Then
                MsgBox("Data Gagal Diupdate", MsgBoxStyle.Critical, "Error Message")
            Else
                Dim command As New MySqlCommand(edit, connection)
                connection.Open()
                command.ExecuteNonQuery()
                MsgBox("Data Berhasil diUpdate")
                loadData()
                connection.Close()
            End If
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox6.Text = ""
            ComboBox1.SelectedItem = ""


            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            TextBox6.Enabled = False
            ComboBox1.Enabled = False

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        ComboBox1.Enabled = True


        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        Me.id.Text = DataGridView1.Item(0, i).Value
        Me.ComboBox1.SelectedItem = DataGridView1.Item(2, i).Value
        Me.TextBox1.Text = DataGridView1.Item(1, i).Value
        Me.TextBox2.Text = DataGridView1.Item(3, i).Value
        Me.TextBox3.Text = DataGridView1.Item(4, i).Value
        Me.TextBox4.Text = DataGridView1.Item(6, i).Value
        Me.TextBox6.Text = DataGridView1.Item(0, i).Value
        Button2.Enabled = True
        Button4.Enabled = False
        Button5.Enabled = True

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If id.Text = "" Then
            MsgBox("Silahkan Pilih Data yang akan di hapus")
        Else
            If MessageBox.Show("Yakin akan dihapus..?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String = "delete From dokter  where kode_dokter='" & id.Text & "'"
                Dim command As New MySqlCommand(hapus, connection)
                connection.Open()
                command.ExecuteNonQuery()
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox6.Text = ""
                ComboBox1.SelectedItem = ""


                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox6.Enabled = False
                ComboBox1.Enabled = False

                MsgBox("Data Berhasil Dihapus", MsgBoxStyle.Information)
                loadData()
                connection.Close()
            End If
        End If
        Button5.Enabled = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button5.Enabled = False

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.SelectedItem = "" Then
            MsgBox("Silahkan Isi Semua Form", MsgBoxStyle.Critical, "Error Message")
        Else
            If MessageBox.Show("Apakah Yakin Akan Menyimpan...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim convert As Int32
                    Dim result As String
                    convert = ComboBox1.SelectedIndex
                    If convert > 9 Then
                        result = ComboBox1.SelectedIndex
                    Else
                        result = convert.ToString("D2")
                    End If

                    'MsgBox(ComboBox1.SelectedItem)
                    'MsgBox(convert.ToString("D2"))
                    Dim simpan As String = "insert into dokter (kode_dokter, nama_dokter,spesialis,alamat,telpon,kode_poli,tarif) values ('" & TextBox6.Text & "','" & TextBox1.Text & "','" & ComboBox1.SelectedItem & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & result & "','" & TextBox4.Text & "')"
                    ' Clipboard.SetText(CStr(simpan))
                    Dim command As New MySqlCommand(simpan, connection)
                    connection.Open()
                    command.ExecuteNonQuery()
                    MsgBox("Input data berhasil")
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    TextBox4.Text = ""
                    TextBox6.Text = ""
                    ComboBox1.SelectedItem = ""


                    TextBox1.Enabled = False
                    TextBox2.Enabled = False
                    TextBox3.Enabled = False
                    TextBox4.Enabled = False
                    TextBox6.Enabled = False
                    ComboBox1.Enabled = False

                    loadData()
                    connection.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
                End Try

            End If
            Button4.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = True

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox6.Text = ""
        ComboBox1.Text = ""


        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox6.Enabled = False
        ComboBox1.Enabled = False
        Button5.Enabled = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox5.Text = "" Then
            loadData()

        Else
            Dim command As New MySqlCommand("Select * From dokter where nama_dokter like '%" & TextBox5.Text & "%'", connection)
            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()

            adapter.Fill(table)
            If table.Rows.Count = 0 Then
                MsgBox("Data Dokter Tidak Ditemukan")
                TextBox5.Focus()
            Else
                DataGridView1.DataSource = table
                'DataGridView1.DataSource = (ds.Tables("pasien"))
                DataGridView1.Columns(0).HeaderText = "Kode Dokter"
                DataGridView1.Columns(1).HeaderText = "Nama Dokter"
                DataGridView1.Columns(2).HeaderText = "Spesialis"
                DataGridView1.Columns(3).HeaderText = "Alamat"
                DataGridView1.Columns(4).HeaderText = "Telpon"
                DataGridView1.Columns(5).HeaderText = "Kode Poli"
                DataGridView1.Columns(6).HeaderText = "Tarif"
                DataGridView1.Columns(6).DefaultCellStyle.Format = "##,0"
                DataGridView1.AutoResizeColumns()
                DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gray
            End If
        End If
        Button5.Enabled = True
    End Sub
End Class