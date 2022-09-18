Public Class FormMenu
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub btnPasien_Click(sender As Object, e As EventArgs) Handles btnPasien.Click
        Pasien.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dokter.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Pendaftaran.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Pendaftaran.Show()
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Pemakai.Show()
    End Sub

    Private Sub btnOne_Click(sender As Object, e As EventArgs) Handles btnOne.Click
        Poli.Show()
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Pemakai.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Resep.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Obat.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Application.Exit()

    End Sub

    Private Sub FormMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label4.Hide()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Dim TD As Date
        TD = DateTime.Now
        Label2.Text = TD
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Kamar.Show()

    End Sub
End Class