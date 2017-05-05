Imports BLL
Public Class usuariologin

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Dim musuario As New BLL.UsuarioBLL
        musuario.email = UsernameTextBox.Text
        musuario.Password = PasswordTextBox.Text

        'me trae un usuario
        Dim musuario2 As New BLL.UsuarioBLL(UsernameTextBox.Text)
        'me fijo que el mail que me trajo sea igual al mail que ingrese
        If musuario2.email = musuario.email Then
            If musuario.Password = musuario2.Password Then
                Dim mpantallaprincipal As New Principal
                Principal.ShowDialog()
            Else
                MsgBox("Datos incorrectos")
            End If
        Else
            MsgBox("Datos incorrectos")
        End If
        Me.Close()

    End Sub

    Private Sub LinkLblRegistrarse_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLblRegistrarse.LinkClicked
        Dim mformularioregistrarse As New Registrarse
        Registrarse.ShowDialog()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
End Class