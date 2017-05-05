Imports BLL

Public Class Usuarios


    Private Sub lblTituloPatentes_Click(sender As Object, e As EventArgs) Handles lblTituloPatentes.Click

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        '  Dim usu As New UsuarioBLL With {.Nombre = textBox1.Text, .rol = CType(comboBox1.SelectedItem, BE.Familia)}
        ' modelo.GetInstance.usuarioblls.Add(usu)
        Me.Close()
    End Sub

    Private Sub FormularioUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboBox1.DataSource = Modelo.GetInstance().Familias
    End Sub
End Class