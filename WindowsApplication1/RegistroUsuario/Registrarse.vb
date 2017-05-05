Imports BLL
Public Class Registrarse

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim mUsuario As New UsuarioBLL

        mUsuario.Nombre = TextBox1.Text
        mUsuario.Apellido = TextBox2.Text
        mUsuario.email = TextBox5.Text
        If TextBox3.Text = TextBox4.Text Then
            mUsuario.Password = TextBox4.Text
        Else
            Label5.Visible = True
        End If

        mUsuario.Guardar()

        MsgBox("Se ha registrado correctamente")
        Me.Close()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class