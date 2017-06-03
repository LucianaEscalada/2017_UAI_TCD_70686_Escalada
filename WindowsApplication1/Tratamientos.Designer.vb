<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tratamientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tratamientos))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox26 = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(297, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(326, 150)
        Me.DataGridView1.TabIndex = 2
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label29.Location = New System.Drawing.Point(156, 11)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(130, 24)
        Me.Label29.TabIndex = 107
        Me.Label29.Text = "Tratamientos"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(160, 95)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 102
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.Location = New System.Drawing.Point(30, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "Precio "
        '
        'TextBox26
        '
        Me.TextBox26.Location = New System.Drawing.Point(160, 69)
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New System.Drawing.Size(100, 20)
        Me.TextBox26.TabIndex = 100
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.BackColor = System.Drawing.Color.Transparent
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.label1.Location = New System.Drawing.Point(30, 76)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(121, 13)
        Me.label1.TabIndex = 101
        Me.label1.Text = "Nombre Tratamiento"
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button7.Location = New System.Drawing.Point(508, 168)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(104, 47)
        Me.Button7.TabIndex = 110
        Me.Button7.Text = "BORRAR"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button8.Location = New System.Drawing.Point(288, 168)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(104, 47)
        Me.Button8.TabIndex = 108
        Me.Button8.Text = "AGREGAR"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button9.CausesValidation = False
        Me.Button9.Location = New System.Drawing.Point(398, 168)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(104, 47)
        Me.Button9.TabIndex = 109
        Me.Button9.Text = "MODIFICAR"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Tratamientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(635, 254)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox26)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Tratamientos"
        Me.Text = "Tratamientos"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox26 As System.Windows.Forms.TextBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
End Class
