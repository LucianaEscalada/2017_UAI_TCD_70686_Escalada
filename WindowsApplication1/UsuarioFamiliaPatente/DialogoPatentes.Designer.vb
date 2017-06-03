<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogoPatentes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogoPatentes))
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbFormularios = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(11, 33)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(248, 20)
        Me.txtNombre.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button1.Location = New System.Drawing.Point(154, 110)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 40)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "ACEPTAR"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cmbFormularios
        '
        Me.cmbFormularios.FormattingEnabled = True
        Me.cmbFormularios.Location = New System.Drawing.Point(11, 65)
        Me.cmbFormularios.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbFormularios.Name = "cmbFormularios"
        Me.cmbFormularios.Size = New System.Drawing.Size(248, 21)
        Me.cmbFormularios.TabIndex = 3
        '
        'DialogoPatentes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(288, 161)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmbFormularios)
        Me.Name = "DialogoPatentes"
        Me.Text = "DialogoPatentes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmbFormularios As System.Windows.Forms.ComboBox
End Class
