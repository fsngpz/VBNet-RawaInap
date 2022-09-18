Imports MySql.Data.MySqlClient
Public Class Pendaftaran
    Dim id As New System.Windows.Forms.TextBox
    Dim save As New System.Windows.Forms.TextBox
    Dim jk As New System.Windows.Forms.TextBox
    Dim getdata As New TextBox
    Dim getdata2 As New TextBox
    Dim getdata3 As New TextBox
    Dim connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=db_rawat_inap")
    Sub loadDataPasien()
        Dim format1 As Int32
        Dim z As Int32
        Dim format2 As Int32
        Dim z2 As Int32
        Dim format3 As Int32
        Dim z3 As Int32
        Dim formatnya As String

        format1 = Format(Now, "dd")
        format2 = Format(Now, "MM")
        format3 = Format(Now, "yy")
        formatnya = z & "" & z2 & "" & z3
        Dim command As New MySqlCommand("select * FROM pasien where kode_pasien like '%" & Format(Now, "ddMMyy") & "%'order by kode_pasien desc", connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)
        ComboBox2.Items.Clear()
        For Each row As DataRow In table.Rows
            ComboBox2.Items.Add(row.Item(0))
        Next
        ComboBox2.Refresh()
    End Sub

    Sub nomorAntrian()
        Dim urutan As String
        Dim a As Long
        Dim query As String

        query = "SELECT * FROM pendaftaran WHERE tanggal_daftar =" & Format(Now, "M/dd/yyyy") & " ORDER BY tanggal_daftar DESC"
        Dim command As New MySqlCommand(query, connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If table.Rows.Count = 0 Then
            urutan = "1"
            TextBox3.Text = urutan

        Else
            a = table.Rows(0).Item(8)
            urutan = a + 1
            TextBox3.Text = urutan
        End If

        Return
    End Sub

    Sub nomorPendaftaran()
        Dim urutan As String

        Dim a As Long

        Dim command As New MySqlCommand("select nomor_daftar from pendaftaran Where nomor_daftar In(Select Max(nomor_daftar)From pendaftaran)Order By nomor_daftar Desc", connection)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If table.Rows.Count = 0 Then
            urutan = Format(Now, "yyMMdd") & "0001"
            TextBox1.Text = urutan

        Else
            a = table.Rows(0).Item(0)
            urutan = a + 1

            TextBox1.Text = urutan
        End If
        TextBox1.Enabled = False

        Return
    End Sub
    Private Sub Pendaftaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
        loadDataPasien()

        Dim command As New MySqlCommand("select * FROM poli order by kode_poli asc", connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)
        For Each row As DataRow In table.Rows
            ComboBox1.Items.Add(row.Item(0))
        Next
        Button2.Enabled = False
        'Button4.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim convert As Int32
        Dim result As String
        convert = ComboBox1.SelectedIndex
        If convert > 9 Then
            result = ComboBox1.SelectedIndex
        Else
            result = convert.ToString("D2")
        End If

        Dim command As New MySqlCommand("select * FROM dokter where kode_poli ='" & result & "'", connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)
        ListBox1.Items.Clear()
        For Each row As DataRow In table.Rows
            ListBox1.Items.Add(row.Item(1))
        Next
        ListBox1.Refresh()

    End Sub
    Sub loadData()
        Dim command As New MySqlCommand("Select * from pendaftaran where tanggal_daftar = '" & Format(Now, "dd-MM-yyyy") & "'", connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView1.DataSource = table
        'DataGridView1.DataSource = (ds.Tables("pasien"))
        DataGridView1.Columns(0).HeaderText = "Nomor Daftar"
        DataGridView1.Columns(1).HeaderText = "Tanggal Daftar"
        DataGridView1.Columns(2).HeaderText = "Kode Dokter"
        DataGridView1.Columns(3).HeaderText = "Kode Pasien"
        DataGridView1.Columns(4).HeaderText = "Kode Poli"
        DataGridView1.Columns(5).HeaderText = "Kode Pemakai"
        DataGridView1.Columns(6).HeaderText = "Biaya"
        DataGridView1.Columns(6).DefaultCellStyle.Format = "##,0"
        DataGridView1.Columns(7).HeaderText = "Keterangan"
        DataGridView1.Columns(8).HeaderText = "Nomor Antrian"
        DataGridView1.Columns(8).DisplayIndex = 0
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gray
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        nomorPendaftaran()
        nomorAntrian()
        TextBox2.Text = Format(Now, "dd-MM-yyy")
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ListBox1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.SelectedItem = "" Then
            MsgBox("Isikan kode poli !", MsgBoxStyle.Critical, "Error Message")
            ComboBox1.Focus()
        ElseIf TextBox9.Text = "" Then
            MsgBox("Silahkan pilih dokter!", MsgBoxStyle.Critical, "Error Message")
            ListBox1.Focus()
        ElseIf ComboBox2.SelectedItem = "" Then
            If MessageBox.Show("Kode pasien kosong tambah baru pasien...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                TextBox4.Enabled = True
                TextBox5.Enabled = True
                TextBox7.Enabled = True
                TextBox8.Enabled = True
                RadioButton1.Enabled = True
                RadioButton2.Enabled = True
                TextBox5.Focus()
            Else
                MsgBox("silahkan pilih data pasien")
                TextBox4.Enabled = False
                TextBox5.Enabled = False
                TextBox7.Enabled = False
                TextBox8.Enabled = False
                RadioButton1.Enabled = False
                RadioButton2.Enabled = False
            End If

            'MsgBox("Isikan kode pasien !", MsgBoxStyle.Critical, "Error Message")
            'ComboBox2.Focus()

        Else
            If MessageBox.Show("Apakah Yakin Akan Menyimpan...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim command As New MySqlCommand("select * FROM dokter where nama_dokter ='" & ListBox1.SelectedItem & "'", connection)
                    Dim adapter As New MySqlDataAdapter(command)
                    Dim table As New DataTable()

                    adapter.Fill(table)
                    For Each row As DataRow In table.Rows
                        getdata.Text = row.Item(0)
                    Next

                    Dim command2 As New MySqlCommand("select * FROM pasien where nama_pasien ='" & ComboBox2.SelectedItem & "'", connection)
                    Dim adapter2 As New MySqlDataAdapter(command2)
                    Dim table2 As New DataTable()

                    adapter2.Fill(table2)

                    For Each row As DataRow In table.Rows
                        getdata2.Text = row.Item(0)
                    Next

                    Dim command3 As New MySqlCommand("select * FROM poli where nama_poli ='" & ComboBox1.SelectedItem & "'", connection)
                    Dim adapter3 As New MySqlDataAdapter(command3)
                    Dim table3 As New DataTable()

                    adapter3.Fill(table3)
                    For Each row As DataRow In table.Rows
                        getdata3.Text = row.Item(0)
                    Next

                    Dim simpan As String
                    Dim converts As Long

                    converts = TextBox9.Text

                    simpan = "insert into pendaftaran(nomor_daftar,tanggal_daftar,kode_dokter,kode_pasien,kode_poli,kode_pemakai,biaya,ket,nomor_antri) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & getdata.Text & "','" & getdata2.Text & "','" & getdata3.Text & "','" & FormMenu.Label4.Text & "'," & converts & ",'0','" & TextBox3.Text & "')"
                    Clipboard.SetText(CStr(simpan))

                    'MsgBox(simpan)
                    Clipboard.SetText(CStr(simpan))

                    Dim cmdSave As New MySqlCommand(simpan, connection)
                    connection.Open()

                    cmdSave.ExecuteNonQuery()
                    MsgBox("Input data berhasil")
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    TextBox4.Text = ""
                    TextBox5.Text = ""

                    TextBox7.Text = ""
                    TextBox8.Text = ""
                    TextBox9.Text = ""
                    ComboBox1.SelectedItem = ""
                    ComboBox2.SelectedItem = ""
                    ListBox1.Items.Clear()
                    TextBox4.Text = ""

                    TextBox1.Enabled = False
                    TextBox2.Enabled = False
                    TextBox3.Enabled = False
                    ComboBox1.Enabled = False
                    ComboBox2.Enabled = False

                    Button2.Enabled = False
                    Button3.Enabled = False
                    Button4.Enabled = False

                    loadData()
                    connection.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
                End Try

            End If

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim formatnya As String
            Dim format1 As Int32
            Dim z As Int32
            Dim format2 As Int32
            Dim z2 As Int32
            Dim format3 As Int32
            Dim z3 As Int32
            Dim a As Int32
            Dim simpanPasien As String

            Dim command As New MySqlCommand("select top 1 kode_pasien from pasien where kode_pasien like '%" & Format(Now, "ddMMyy") & "%' Order By kode_pasien Desc", connection)
            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()

            adapter.Fill(table)

            If table.Rows.Count = 0 Then
                format1 = Format(Now, "dd")
                format2 = Format(Now, "MM")
                format3 = Format(Now, "yy")
                'MsgBox("format 1 is " & format1)
                'formatnya = Format(Now, "ddMMyy")
                If format1 > 9 And format2 > 9 And format3 > 9 Then
                    z = format1
                    z2 = format2
                    z3 = format3
                    formatnya = z & "" & z2 & "" & z3
                    save.Text = formatnya + "01"
                Else
                    z = format1.ToString("D2")
                    z2 = format2.ToString("D2")
                    z3 = format3.ToString("D2")
                    formatnya = z.ToString("D2") & "" & z2.ToString("D2") & "" & z3.ToString("D2")
                    save.Text = formatnya & "01"
                End If

            Else
                a = table.Rows(0).Item(0)

                format1 = Format(Now, "dd")
                If format1 > 9 Then
                    save.Text = a + 1
                Else
                    save.Text = "0" & a + 1
                End If

            End If


            If (RadioButton1.Checked) Then
                jk.Text = "Pria"
            ElseIf (RadioButton2.Checked) Then
                jk.Text = "Wanita"
            Else
                jk.Text = ""
            End If
            If MessageBox.Show("Apakah Yakin Akan Menyimpan...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Try
                    simpanPasien = "insert into pasien (kode_pasien,nama_pasien,alamat,jenis_kelamin,umur,telepon) values ('" & save.Text & "','" & TextBox5.Text & "','" & TextBox4.Text & "','" & jk.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "')"
                    Dim commandPasien As New MySqlCommand(simpanPasien, connection)
                    commandPasien.ExecuteNonQuery()
                    loadDataPasien()
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
                End Try

            End If


            TextBox4.Text = ""
            TextBox5.Text = ""
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            TextBox7.Text = ""
            TextBox8.Text = ""

            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox7.Enabled = False
            TextBox8.Enabled = False
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False



        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedItem = "" Then
            Button4.Enabled = True
            TextBox4.Enabled = True
            TextBox5.Enabled = True
            TextBox7.Enabled = True
            TextBox8.Enabled = True
            RadioButton1.Enabled = True
            RadioButton2.Enabled = True
        Else
            Button4.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox7.Enabled = False
            TextBox8.Enabled = False
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False

            Dim command As New MySqlCommand("select * FROM pasien where kode_pasien = '" & ComboBox2.SelectedItem & "'", connection)
            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()

            adapter.Fill(table)

            For Each row As DataRow In table.Rows
                ComboBox1.Items.Add(row.Item(1))
                TextBox5.Text = row.Item(1)
                TextBox4.Text = row.Item(2)
                TextBox7.Text = row.Item(4)
                TextBox8.Text = row.Item(5)
                If row.Item(3) = "Pria" Then
                    RadioButton1.Checked = True
                Else
                    RadioButton2.Checked = True
                End If
            Next

        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim command As New MySqlCommand("select * FROM dokter where nama_dokter ='" & ListBox1.SelectedItem & "'", connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)
        For Each row As DataRow In table.Rows
            TextBox9.Text = row.Item(6)
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""

        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        ComboBox1.SelectedItem = ""
        ComboBox2.SelectedItem = ""
        ListBox1.Items.Clear()
        TextBox4.Text = ""

        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False

        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class