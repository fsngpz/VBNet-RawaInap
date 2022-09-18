Imports MySql.Data.MySqlClient


Public Class LoginForm
    Dim connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=db_rawat_inap")

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click

        If UsernameTextBox.Text = "" Or PasswordTextBox.Text = "" Then
            MsgBox("Harap Isi Username Dan Password !", MsgBoxStyle.Critical, "Error Message")
        Else
            Dim command As New MySqlCommand("SELECT `description` FROM `pemakai` WHERE `username` = @username AND `password` = @password", connection)

            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = UsernameTextBox.Text
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = PasswordTextBox.Text

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()

            adapter.Fill(table)

            If table.Rows.Count = 0 Then
                MsgBox("Username Tidak Ditemukan")
                UsernameTextBox.Text = ""
                PasswordTextBox.Text = ""
            Else
                Me.Hide()

                FormMenu.Label3.Text = "Selamat Datang " & table.Rows(0).Item(0)
                FormMenu.Label4.Text = table.Rows(0).Item(0)
                FormMenu.Show()
            End If
        End If
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
