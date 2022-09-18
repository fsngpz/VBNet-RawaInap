<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MainMenu = New System.Windows.Forms.Label()
        Me.QuitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataPasienToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataDokterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataPoliToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataObatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataPendaftaranToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataPemakaiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataResepToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnOne = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.btnPasien = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.MainMenu)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(0, -34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(770, 658)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(579, 560)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Label4"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(256, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(231, 25)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Selamat Datang Admin"
        '
        'MainMenu
        '
        Me.MainMenu.AutoSize = True
        Me.MainMenu.Font = New System.Drawing.Font("Museo Sans Cyrl 900", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenu.ForeColor = System.Drawing.Color.White
        Me.MainMenu.Location = New System.Drawing.Point(151, 34)
        Me.MainMenu.Name = "MainMenu"
        Me.MainMenu.Size = New System.Drawing.Size(456, 38)
        Me.MainMenu.TabIndex = 17
        Me.MainMenu.Text = "Sistem Informasi Rawat Inap"
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        Me.QuitToolStripMenuItem.Size = New System.Drawing.Size(97, 22)
        Me.QuitToolStripMenuItem.Text = "Quit"
        '
        'LaporanToolStripMenuItem
        '
        Me.LaporanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataPasienToolStripMenuItem, Me.DataDokterToolStripMenuItem, Me.DataPoliToolStripMenuItem, Me.DataObatToolStripMenuItem, Me.DataPendaftaranToolStripMenuItem, Me.DataPemakaiToolStripMenuItem, Me.DataResepToolStripMenuItem})
        Me.LaporanToolStripMenuItem.Name = "LaporanToolStripMenuItem"
        Me.LaporanToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.LaporanToolStripMenuItem.Text = "Laporan"
        '
        'DataPasienToolStripMenuItem
        '
        Me.DataPasienToolStripMenuItem.Name = "DataPasienToolStripMenuItem"
        Me.DataPasienToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.DataPasienToolStripMenuItem.Text = "Data Pasien"
        '
        'DataDokterToolStripMenuItem
        '
        Me.DataDokterToolStripMenuItem.Name = "DataDokterToolStripMenuItem"
        Me.DataDokterToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.DataDokterToolStripMenuItem.Text = "Data Dokter"
        '
        'DataPoliToolStripMenuItem
        '
        Me.DataPoliToolStripMenuItem.Name = "DataPoliToolStripMenuItem"
        Me.DataPoliToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.DataPoliToolStripMenuItem.Text = "Data Poli"
        '
        'DataObatToolStripMenuItem
        '
        Me.DataObatToolStripMenuItem.Name = "DataObatToolStripMenuItem"
        Me.DataObatToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.DataObatToolStripMenuItem.Text = "Data Obat"
        '
        'DataPendaftaranToolStripMenuItem
        '
        Me.DataPendaftaranToolStripMenuItem.Name = "DataPendaftaranToolStripMenuItem"
        Me.DataPendaftaranToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.DataPendaftaranToolStripMenuItem.Text = "Data Pendaftaran"
        '
        'DataPemakaiToolStripMenuItem
        '
        Me.DataPemakaiToolStripMenuItem.Name = "DataPemakaiToolStripMenuItem"
        Me.DataPemakaiToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.DataPemakaiToolStripMenuItem.Text = "Data Pemakai"
        '
        'DataResepToolStripMenuItem
        '
        Me.DataResepToolStripMenuItem.Name = "DataResepToolStripMenuItem"
        Me.DataResepToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.DataResepToolStripMenuItem.Text = "Data Resep"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.LightCoral
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.LaporanToolStripMenuItem, Me.AboutToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(726, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(36, 548)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 25)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Label2"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.btnOne)
        Me.GroupBox2.Controls.Add(Me.Button8)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Button6)
        Me.GroupBox2.Controls.Add(Me.Button5)
        Me.GroupBox2.Controls.Add(Me.btnPasien)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GroupBox2.Location = New System.Drawing.Point(5, 102)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(716, 421)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.BackgroundImage = Global.RawatInap.My.Resources.Resources._289_2899291_transparent_stethoscope_logo_animasi_alat_kesehatan_png_png
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(59, 147)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 117)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Kamar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnOne
        '
        Me.btnOne.BackColor = System.Drawing.Color.White
        Me.btnOne.BackgroundImage = Global.RawatInap.My.Resources.Resources._289_2899291_transparent_stethoscope_logo_animasi_alat_kesehatan_png_png
        Me.btnOne.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnOne.ForeColor = System.Drawing.Color.Black
        Me.btnOne.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOne.Location = New System.Drawing.Point(59, 278)
        Me.btnOne.Name = "btnOne"
        Me.btnOne.Size = New System.Drawing.Size(89, 117)
        Me.btnOne.TabIndex = 19
        Me.btnOne.Text = "Poli"
        Me.btnOne.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnOne.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.Transparent
        Me.Button8.BackgroundImage = Global.RawatInap.My.Resources.Resources._1000_F_163103704_kRoOfR1lNyMtjMOzLD6IxPk6LxAqBgRm
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button8.ForeColor = System.Drawing.Color.Black
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(316, 278)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(89, 117)
        Me.Button8.TabIndex = 18
        Me.Button8.Text = "Resep"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.BackgroundImage = Global.RawatInap.My.Resources.Resources.doctors_logo_icon_29
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(316, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(89, 117)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Dokter"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.White
        Me.Button6.BackgroundImage = Global.RawatInap.My.Resources.Resources.icon_registration_registry_registration_144252898
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button6.ForeColor = System.Drawing.Color.Black
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button6.Location = New System.Drawing.Point(563, 19)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(89, 117)
        Me.Button6.TabIndex = 15
        Me.Button6.Text = "Pendaftaran"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.White
        Me.Button5.BackgroundImage = Global.RawatInap.My.Resources.Resources._764d59d32f61f0f91dec8c442ab052c5
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button5.ForeColor = System.Drawing.Color.Black
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button5.Location = New System.Drawing.Point(316, 147)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(89, 117)
        Me.Button5.TabIndex = 14
        Me.Button5.Text = "Pemakai"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button5.UseVisualStyleBackColor = False
        '
        'btnPasien
        '
        Me.btnPasien.BackColor = System.Drawing.Color.White
        Me.btnPasien.BackgroundImage = Global.RawatInap.My.Resources.Resources.png_clipart_health_care_patient_hospital_health_system_self_service_logo_medicine
        Me.btnPasien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnPasien.ForeColor = System.Drawing.Color.Black
        Me.btnPasien.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPasien.Location = New System.Drawing.Point(59, 19)
        Me.btnPasien.Name = "btnPasien"
        Me.btnPasien.Size = New System.Drawing.Size(89, 117)
        Me.btnPasien.TabIndex = 13
        Me.btnPasien.Tag = "Pasien"
        Me.btnPasien.Text = "Pasien"
        Me.btnPasien.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPasien.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.BackgroundImage = Global.RawatInap.My.Resources.Resources.png_transparent_red_and_green_capsule_illustration_logo_brand_pattern_cartoon_red_green_capsule_pills_miscellaneous_cartoon_character_text
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(563, 147)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(89, 117)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Obat"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Transparent
        Me.Button7.BackgroundImage = Global.RawatInap.My.Resources.Resources.kisspng_computer_icons_abmeldung_clip_art_exit_5abfc80f1ca5a2_4056158015225180311173
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button7.ForeColor = System.Drawing.Color.Black
        Me.Button7.Location = New System.Drawing.Point(645, 529)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(70, 62)
        Me.Button7.TabIndex = 16
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button7.UseVisualStyleBackColor = False
        '
        'FormMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(726, 568)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "FormMenu"
        Me.Text = "Menu"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents MainMenu As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents QuitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LaporanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataPasienToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataDokterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataPoliToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataObatToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataPendaftaranToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataPemakaiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataResepToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnOne As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents btnPasien As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
End Class
