Imports MySql.Data.MySqlClient
Public Class Pasien
    Dim id As New TextBox
    Dim jk As New TextBox
    Dim connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=db_rawat_inap")
    Sub loadData()
        Dim command As New MySqlCommand("SELECT * FROM pasien", connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView1.DataSource = table
        DataGridView1.Columns(0).HeaderText = "Kode Pasien"
        DataGridView1.Columns(1).HeaderText = "Nama Pasien"
        DataGridView1.Columns(2).HeaderText = "Alamat"
        DataGridView1.Columns(3).HeaderText = "Jenis Kelamin"
        DataGridView1.Columns(4).HeaderText = "Umur"
        DataGridView1.Columns(5).HeaderText = "Telepon"

        DataGridView1.AutoResizeColumns()
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gray
    End Sub
    Private Sub Pasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button4.Enabled = False
        Button5.Enabled = False
        loadData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        kodepasien()
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = True
        Button5.Enabled = True
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        RadioButton1.Enabled = True
        RadioButton2.Enabled = True

        TextBox1.Focus()

    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Sub kodepasien()
        Dim formatnya As String
        Dim format1 As Int32
        Dim z As Int32
        Dim format2 As Int32
        Dim z2 As Int32
        Dim format3 As Int32
        Dim z3 As Int32
        'Dim newstring As String
        'Dim hitung As Long
        Dim a As Int32

        Dim command As New MySqlCommand("SELECT kode_pasien from pasien WHERE kode_pasien like '%" & Format(Now, "ddMMyy") & "%' ORDER BY kode_pasien Desc LIMIT 1", connection)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If table.Rows.Count = 0 Then
            format1 = Format(Now, "dd")
            format2 = Format(Now, "MM")
            format3 = Format(Now, "yy")
            If format1 > 9 And format2 > 9 And format3 > 9 Then
                z = format1
                z2 = format2
                z3 = format3
                formatnya = z & "" & z2 & "" & z3
                TextBox6.Text = formatnya + "01"
            Else
                z = format1.ToString("D2")
                z2 = format2.ToString("D2")
                z3 = format3.ToString("D2")
                formatnya = z.ToString("D2") & "" & z2.ToString("D2") & "" & z3.ToString("D2")
                TextBox6.Text = formatnya & "01"
            End If
        Else
            a = table.Rows(0).Item(0)
            format1 = Format(Now, "dd")
            If format1 > 9 Then
                TextBox6.Text = a + 1
            Else
                TextBox6.Text = "0" & a + 1
            End If
        End If
        TextBox6.Enabled = False
        Return
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        RadioButton1.Enabled = True
        RadioButton2.Enabled = True

        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        Me.id.Text = DataGridView1.Item(0, i).Value
        Me.TextBox1.Text = DataGridView1.Item(1, i).Value
        Me.TextBox2.Text = DataGridView1.Item(2, i).Value
        If DataGridView1.Item(3, i).Value = "Pria" Then
            Me.RadioButton1.Checked = True
        ElseIf DataGridView1.Item(3, i).Value = "Wanita" Then
            Me.RadioButton2.Checked = True
        End If

        Me.TextBox3.Text = DataGridView1.Item(4, i).Value
        Me.TextBox4.Text = DataGridView1.Item(5, i).Value
        Me.TextBox6.Text = DataGridView1.Item(0, i).Value
        TextBox6.Enabled = False
        Button2.Enabled = True
        Button4.Enabled = False
        Button5.Enabled = True

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If (RadioButton1.Checked) Then
                jk.Text = "Pria"
            ElseIf (RadioButton2.Checked) Then
                jk.Text = "Wanita"
            Else
                jk.Text = ""
            End If
            Dim edit As String
            edit = "update pasien set nama_pasien = '" & TextBox1.Text & "', alamat = '" & TextBox2.Text & "', jenis_kelamin = '" & jk.Text & "', umur = '" & TextBox3.Text & "', telepon = '" & TextBox4.Text & "'  where kode_pasien = '" & id.Text & "'"
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or jk.Text = "" Then
                MsgBox("Data Gagal Diupdate", MsgBoxStyle.Critical, "Error Message")
            Else
                connection.Open()
                Dim command As New MySqlCommand(edit, connection)
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
            RadioButton1.Checked = False
            RadioButton2.Checked = False

            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            TextBox6.Enabled = False
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False
            Button5.Enabled = False
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If (RadioButton1.Checked) Then
            jk.Text = "Pria"
        ElseIf (RadioButton2.Checked) Then
            jk.Text = "Wanita"
        Else
            jk.Text = ""
        End If
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or jk.Text = "" Then
            MsgBox("Silahkan Isi Semua Form", MsgBoxStyle.Critical, "Error Message")
        Else
            If MessageBox.Show("Apakah Yakin Akan Menyimpan...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim simpan As String = "insert into pasien (kode_pasien, nama_pasien,alamat,jenis_kelamin,umur,telepon) values ('" & TextBox6.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & jk.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
                    Dim command As New MySqlCommand(simpan, connection)

                    connection.Open()
                    command.ExecuteNonQuery()
                    MsgBox("Input data berhasil")
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    TextBox4.Text = ""
                    TextBox6.Text = ""
                    RadioButton1.Checked = False
                    RadioButton2.Checked = False
                    TextBox6.Text = ""

                    TextBox1.Enabled = False
                    TextBox2.Enabled = False
                    TextBox3.Enabled = False
                    TextBox4.Enabled = False
                    TextBox6.Enabled = False
                    RadioButton1.Enabled = False
                    RadioButton2.Enabled = False
                    loadData()
                    connection.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
                End Try

            End If
            Button4.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = True
            Button5.Enabled = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If id.Text = "" Then
            MsgBox("Silahkan Pilih Data yang akan di hapus")
        Else
            If MessageBox.Show("Yakin akan dihapus..?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String = "delete From pasien  where kode_pasien='" & id.Text & "'"
                Dim command As New MySqlCommand(hapus, connection)

                connection.Open()
                command.ExecuteNonQuery()
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox6.Text = ""
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox6.Enabled = False
                RadioButton1.Enabled = False
                RadioButton2.Enabled = False
                MsgBox("Data Berhasil Dihapus", MsgBoxStyle.Information)
                loadData()
                Button5.Enabled = False
                connection.Close()
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        TextBox6.Text = ""

        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox6.Enabled = False

        RadioButton1.Enabled = False
        RadioButton2.Enabled = False
        Button5.Enabled = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox5.Text = "" Then
            loadData()

        Else
            Dim command As New MySqlCommand("Select * From pasien where nama_pasien like '%" & TextBox5.Text & "%'", connection)

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()

            adapter.Fill(table)
            If table.Rows.Count = 0 Then
                MsgBox("Data Pasien Tidak Ditemukan")
                TextBox5.Focus()
            Else
                DataGridView1.DataSource = table
                'DataGridView1.DataSource = (ds.Tables("pasien"))
                DataGridView1.Columns(0).HeaderText = "Kode Pasien"
                DataGridView1.Columns(1).HeaderText = "Nama Pasien"
                DataGridView1.Columns(2).HeaderText = "Alamat"
                DataGridView1.Columns(3).HeaderText = "Jenis Kelamin"
                DataGridView1.Columns(4).HeaderText = "Umur"
                DataGridView1.Columns(5).HeaderText = "Telepon"

                DataGridView1.AutoResizeColumns()
                DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gray
            End If
        End If
        Button5.Enabled = True
    End Sub
End Class