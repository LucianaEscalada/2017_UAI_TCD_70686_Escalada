<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usuariologin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(usuariologin))
        Me.LinkLblRegistrarse = New System.Windows.Forms.LinkLabel()
        Me.LinkLblPass = New System.Windows.Forms.LinkLabel()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.UsernameTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LinkLblRegistrarse
        '
        Me.LinkLblRegistrarse.AutoSize = True
        Me.LinkLblRegistrarse.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.LinkLblRegistrarse.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LinkLblRegistrarse.Location = New System.Drawing.Point(168, 116)
        Me.LinkLblRegistrarse.Name = "LinkLblRegistrarse"
        Me.LinkLblRegistrarse.Size = New System.Drawing.Size(81, 17)
        Me.LinkLblRegistrarse.TabIndex = 24
        Me.LinkLblRegistrarse.TabStop = True
        Me.LinkLblRegistrarse.Tag = "Registrarse"
        Me.LinkLblRegistrarse.Text = "Registrarse"
        '
        'LinkLblPass
        '
        Me.LinkLblPass.AutoSize = True
        Me.LinkLblPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.LinkLblPass.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LinkLblPass.Location = New System.Drawing.Point(264, 116)
        Me.LinkLblPass.Name = "LinkLblPass"
        Me.LinkLblPass.Size = New System.Drawing.Size(143, 17)
        Me.LinkLblPass.TabIndex = 23
        Me.LinkLblPass.TabStop = True
        Me.LinkLblPass.Tag = "OlvidarContraseña"
        Me.LinkLblPass.Text = "Olvidé mi Contraseña"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.BtnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnCancelar.Location = New System.Drawing.Point(313, 151)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(94, 35)
        Me.BtnCancelar.TabIndex = 22
        Me.BtnCancelar.Tag = "Cancelar"
        Me.BtnCancelar.Text = "Cancelar"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.BtnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnAceptar.Location = New System.Drawing.Point(168, 151)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(94, 35)
        Me.BtnAceptar.TabIndex = 21
        Me.BtnAceptar.Tag = "Aceptar"
        Me.BtnAceptar.Text = "Aceptar"
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.PasswordTextBox.Location = New System.Drawing.Point(168, 93)
        Me.PasswordTextBox.MaxLength = 8
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(239, 23)
        Me.PasswordTextBox.TabIndex = 20
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.UsernameTextBox.Location = New System.Drawing.Point(168, 36)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(239, 23)
        Me.UsernameTextBox.TabIndex = 18
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.PasswordLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PasswordLabel.Location = New System.Drawing.Point(165, 67)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(220, 23)
        Me.PasswordLabel.TabIndex = 19
        Me.PasswordLabel.Tag = "Password"
        Me.PasswordLabel.Text = "&Contraseña"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.UsernameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.UsernameLabel.Location = New System.Drawing.Point(168, 10)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(220, 23)
        Me.UsernameLabel.TabIndex = 17
        Me.UsernameLabel.Tag = "Username"
        Me.UsernameLabel.Text = "Email"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(147, 181)
        Me.PictureBox1.TabIndex = 25
        Me.PictureBox1.TabStop = False
        '
        'usuariologin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 203)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LinkLblRegistrarse)
        Me.Controls.Add(Me.LinkLblPass)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.Controls.Add(Me.UsernameTextBox)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Name = "usuariologin"
        Me.Text = "usuariologin"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LinkLblRegistrarse As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLblPass As System.Windows.Forms.LinkLabel
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
