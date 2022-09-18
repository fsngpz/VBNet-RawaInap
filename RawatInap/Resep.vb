Imports MySql.Data.MySqlClient
Public Class Resep
    Dim connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=db_rawat_inap")
    Public subtotal As Double = 0
    Sub loadpendaftaran()

        Dim command As New MySqlCommand("Select pendaftaran.nomor_daftar, pasien.nama_pasien From pendaftaran left join pasien on pasien.kode_pasien = pendaftaran.kode_pasien where tanggal_daftar like '%" & Format(Now, "dd-MM-yyyy") & "%'", connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        Console.WriteLine("Select pendaftaran.nomor_daftar, pasien.nama_pasien From pendaftaran left join pasien on pasien.kode_pasien = pendaftaran.kode_pasien where tanggal_daftar like '%" & Format(Now, "dd-MM-yyyy") & "%'")

        adapter.Fill(table)
        ComboBox1.Items.Add("")
        For Each row As DataRow In table.Rows
            ComboBox1.Items.Add(row.Item(1))
            ComboBox1.Items.Add(row.Item(0) & "-" & row.Item(1))
        Next
    End Sub
    Private Sub Resep_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadpendaftaran()
        TextBox6.Text = Format(Now, "dd-MM-yyyy")
        DataGridView1.Enabled = False
        DataGridView1.Columns(2).DefaultCellStyle.Format = "N2"
        DataGridView1.Columns(4).DefaultCellStyle.Format = "N2"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "" Then

        Else
            Button4.Enabled = True

            TextBox9.Text = ""
            TextBox11.Text = ""
            TextBox12.Text = ""
            DataGridView1.Rows.Clear()

            Dim klm As String = ComboBox1.SelectedItem
            Dim arr() As String = klm.Split("-")
            Dim kodedkt As New TextBox
            Dim kodepasien As New TextBox
            Dim kodepoli As New TextBox
            Dim kategoriobat As New TextBox

            Dim command As New MySqlCommand("Select kode_dokter, kode_pasien, kode_poli From pendaftaran where nomor_daftar = '" & arr.First() & "' LIMIT 1", connection)

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()

            adapter.Fill(table)

            For Each row As DataRow In table.Rows
                kodedkt.Text = row.Item(0)
                kodepasien.Text = row.Item(1)
                kodepoli.Text = row.Item(2)
            Next

            Dim command1 As New MySqlCommand("Select kode_dokter, nama_dokter From dokter where kode_dokter = '" & kodedkt.Text & "' LIMIT 1", connection)

            Dim adapter1 As New MySqlDataAdapter(command1)
            Dim table1 As New DataTable()

            adapter1.Fill(table1)

            For Each row As DataRow In table.Rows
                TextBox1.Text = row.Item(0)
                TextBox8.Text = row.Item(1)
            Next

            Dim command2 As New MySqlCommand("Select top 1 kode_pasien, nama_pasien From pasien where kode_pasien = '" & kodepasien.Text & "' LIMIT 1", connection)

            Dim adapter2 As New MySqlDataAdapter(command2)
            Dim table2 As New DataTable()

            adapter2.Fill(table2)

            For Each row As DataRow In table.Rows
                TextBox2.Text = row.Item(0)
                TextBox7.Text = row.Item(1)
            Next


            Dim command3 As New MySqlCommand("Select kode_poli, nama_poli From poli where kode_poli = '" & kodepoli.Text & "' LIMIT 1", connection)

            Dim adapter3 As New MySqlDataAdapter(command3)
            Dim table3 As New DataTable()

            adapter3.Fill(table3)

            For Each row As DataRow In table.Rows
                TextBox3.Text = row.Item(0)
                TextBox4.Text = row.Item(1)
                kategoriobat.Text = row.Item(1)
            Next

            Dim command4 As New MySqlCommand("Select kode_obat, nama_obat From obat where kategori_obat = '" & kategoriobat.Text & "'", connection)
            Dim adapter4 As New MySqlDataAdapter(command4)
            Dim table4 As New DataTable()

            adapter4.Fill(table3)

            ListBox1.Items.Clear()
            For Each row As DataRow In table.Rows
                ListBox1.Items.Add(row.Item(1))
            Next
            ListBox1.Refresh()
        End If
    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        DataGridView1.Enabled = True

        Dim a As String
        a = ListBox1.SelectedItem
        Dim i As Integer = 0

        Dim command As New MySqlCommand("Select kode_obat, nama_obat, harga From obat where nama_obat = '" & a & "'", connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        For Each row As DataRow In table.Rows
            DataGridView1.Rows.Add(New String() {row.Item(0), row.Item(1), row.Item(2), "", row.Item(2)})
            DataGridView1.Columns(2).DefaultCellStyle.Format = "##,0"
            DataGridView1.Columns(4).DefaultCellStyle.Format = "##,0"
        Next

        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(2).ReadOnly = True
        DataGridView1.Columns(3).ReadOnly = False
        DataGridView1.Columns(4).ReadOnly = True


    End Sub

    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Try
            Dim i = DataGridView1.CurrentRow.Index
            Dim command As New MySqlCommand("Select jumlah From obat where kode_obat = '" & DataGridView1.Item(0, i).Value & "'", connection)

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()

            adapter.Fill(table)
            For Each row As DataRow In table.Rows
                If CDbl(DataGridView1.Item(3, i).Value) > row.Item(0) Then
                    MsgBox("Stok Obat Kurang ", MsgBoxStyle.Critical, "Error Message")
                    Button4.Enabled = False
                Else
                    DataGridView1.Item(4, i).Value = CDbl(DataGridView1.Item(2, i).Value) * CDbl(DataGridView1.Item(3, i).Value)
                End If
            Next


            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                If (Not row.IsNewRow) Then
                    subtotal = subtotal + row.Cells(4).Value.ToString
                End If
            Next

            TextBox12.Text = subtotal
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint

        Dim strRowNumber As String = (e.RowIndex + 1).ToString

        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)

        If DataGridView1.RowHeadersWidth < CInt((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = CInt((size.Width + 20))
        End If

        Dim b As Brush = SystemBrushes.ControlText


        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15,
                               e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) _
                                                         / 2))

    End Sub

    Private Sub TextBox12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.TextChanged
        If IsNumeric(TextBox12.Text) Then

            Dim temp As Integer = TextBox12.Text

            TextBox12.Text = Format(temp, "N")

            TextBox9.SelectionStart = TextBox12.TextLength - 3


        End If
    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged
        If IsNumeric(TextBox9.Text) Then

            Dim temp As Integer = TextBox9.Text

            TextBox9.Text = Format(temp, "N")

            TextBox9.SelectionStart = TextBox9.TextLength - 3


        End If
    End Sub

    Private Sub TextBox11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox11.TextChanged
        If IsNumeric(TextBox11.Text) Then

            Dim temp As Integer = TextBox11.Text

            TextBox11.Text = Format(temp, "N")

            TextBox11.SelectionStart = TextBox11.TextLength - 3

            TextBox9.Text = TextBox11.Text - TextBox12.Text
        End If
    End Sub

    Sub bersih()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        'TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        ComboBox1.SelectedItem = ""
        ListBox1.Items.Clear()
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        bersih()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If ComboBox1.SelectedItem = "" Or TextBox9.Text = "" Or TextBox11.Text = "" Or TextBox12.Text = "" Then
            MsgBox("Silahkan Isi Semua Form", MsgBoxStyle.Critical, "Error Message")
        Else
            If MessageBox.Show("Apakah Yakin Akan Menyimpan...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim data As String = ComboBox1.SelectedItem
                    Dim arr() As String = data.Split("-")

                    Dim simpan As String = "insert into resep (nomor_resep, tanggal_resep, kode_dokter, kode_pasien, kode_poli, kode_pemakai, total_harga, dibayar, kembali) values ('" & arr.First & "','" & TextBox6.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & FormMenu.Label4.Text & "','" & TextBox12.Text & "','" & TextBox11.Text & "','" & TextBox9.Text & "')"

                    Dim command As New MySqlCommand(simpan, connection)
                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()


                    Dim x As MySqlCommand
                    Dim update As String = "update pendaftaran set ket='1' where nomor_daftar='" & arr.First & "'"
                    x = New MySqlCommand(update, connection)

                    connection.Open()
                    x.ExecuteNonQuery()
                    connection.Close()


                    Dim i = DataGridView1.CurrentRow.Index

                    'DataGridView1.Item(4, i).Value = CDbl(DataGridView1.Item(2, i).Value) * CDbl(DataGridView1.Item(3, i).Value)

                    For Each row As DataGridViewRow In Me.DataGridView1.Rows
                        If (Not row.IsNewRow) Then
                            'subtotal = subtotal + row.Cells(4).Value.ToString
                            Dim CMD2 As MySqlCommand
                            Dim simpan2 As String = "insert into detail (nomor_resep, kode_obat, harga, dosis, subtotal) values ('" & arr.First & "','" & row.Cells(0).Value.ToString & "','" & row.Cells(2).Value.ToString & "','" & row.Cells(3).Value.ToString & "','" & row.Cells(4).Value.ToString & "')"

                            CMD2 = New MySqlCommand(simpan2, connection)
                            connection.Open()

                            CMD2.ExecuteNonQuery()

                            connection.Close()

                            Dim CMD4 As MySqlCommand
                            CMD4 = New MySqlCommand("Select jumlah From obat where kode_obat = '" & row.Cells(0).Value.ToString & "'", connection)


                            Dim adapter As New MySqlDataAdapter(command)
                            Dim table As New DataTable()

                            adapter.Fill(table)
                            For Each rows As DataRow In table.Rows
                                Dim angka As Integer
                                angka = row.Cells(3).Value.ToString
                                Dim xx As MySqlCommand
                                Dim updatee As String = "update obat set jumlah='" & rows.Item(0) - angka & "' where kode_obat='" & row.Cells(0).Value.ToString & "'"
                                xx = New MySqlCommand(updatee, connection)
                                'Clipboard.SetText(CStr(updatee))
                                connection.Open()
                                xx.ExecuteNonQuery()
                                connection.Close()
                            Next

                        End If
                    Next

                    Dim CMD3 As MySqlCommand
                    Dim simpan3 As String = "insert into pembayaran (nomor_byr, kode_pasien, tanggal_bayar, jumlah_bayar) values ('" & arr.First & "','" & TextBox2.Text & "','" & TextBox6.Text & "','" & TextBox12.Text & "')"
                    Clipboard.SetText(CStr(simpan3))
                    CMD3 = New MySqlCommand(simpan3, connection)
                    connection.Open()
                    CMD3.ExecuteNonQuery()
                    connection.Close()

                    MsgBox("Input data berhasil")

                    bersih()

                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
                End Try

            End If
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class