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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LinkLblRegistrarse
        '
        Me.LinkLblRegistrarse.AutoSize = True
        Me.LinkLblRegistrarse.BackColor = System.Drawing.Color.Transparent
        Me.LinkLblRegistrarse.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.LinkLblRegistrarse.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LinkLblRegistrarse.LinkColor = System.Drawing.Color.LightCoral
        Me.LinkLblRegistrarse.Location = New System.Drawing.Point(82, 126)
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
        Me.LinkLblPass.BackColor = System.Drawing.Color.Transparent
        Me.LinkLblPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.LinkLblPass.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LinkLblPass.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LinkLblPass.LinkColor = System.Drawing.Color.LightCoral
        Me.LinkLblPass.Location = New System.Drawing.Point(178, 126)
        Me.LinkLblPass.Name = "LinkLblPass"
        Me.LinkLblPass.Size = New System.Drawing.Size(143, 17)
        Me.LinkLblPass.TabIndex = 23
        Me.LinkLblPass.TabStop = True
        Me.LinkLblPass.Tag = "OlvidarContraseña"
        Me.LinkLblPass.Text = "Olvidé mi Contraseña"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.BtnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnCancelar.Location = New System.Drawing.Point(227, 158)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(94, 35)
        Me.BtnCancelar.TabIndex = 22
        Me.BtnCancelar.Tag = "Cancelar"
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = False
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.BtnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnAceptar.Location = New System.Drawing.Point(82, 158)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(94, 35)
        Me.BtnAceptar.TabIndex = 21
        Me.BtnAceptar.Tag = "Aceptar"
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.PasswordTextBox.Location = New System.Drawing.Point(82, 100)
        Me.PasswordTextBox.MaxLength = 8
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(239, 23)
        Me.PasswordTextBox.TabIndex = 20
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.UsernameTextBox.Location = New System.Drawing.Point(82, 43)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(239, 23)
        Me.UsernameTextBox.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(82, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 16)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Email"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(82, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 16)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Contraseña"
        '
        'usuariologin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(369, 235)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LinkLblRegistrarse)
        Me.Controls.Add(Me.LinkLblPass)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.Controls.Add(Me.UsernameTextBox)
        Me.Name = "usuariologin"
        Me.Text = "usuariologin"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LinkLblRegistrarse As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLblPass As System.Windows.Forms.LinkLabel
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
