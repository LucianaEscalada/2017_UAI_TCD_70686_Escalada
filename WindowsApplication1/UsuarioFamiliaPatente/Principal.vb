Imports BLL
Public Class Principal

    Private Sub btnDefinirPatentes_Click(sender As Object, e As EventArgs) Handles btnDefinirPatentes.Click
        Dim form As New WindowsApplication1.Patentes
        form.ShowDialog()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim p1 As New Patente
        Dim p2 As New Patente
        Dim p3 As New Patente
        Dim p4 As New BLL.Familia


        p1.nombrePatente = "p1"
        p2.nombrePatente = "p1"
        p3.nombrePatente = "p3"
        p4.nombreFamilia = "p1p2"

        Modelo.GetInstance.Familias.Add(p4)

    End Sub

    Private Sub btnDefinirFamilias_Click(sender As Object, e As EventArgs) Handles btnDefinirFamilias.Click
        Dim frm As New WindowsApplication1.Familia
        frm.ShowDialog()
    End Sub

    Private Sub btnDefinirUsuarios_Click(sender As Object, e As EventArgs) Handles btnDefinirUsuarios.Click
        Dim frm As New WindowsApplication1.Usuarios
        frm.ShowDialog()
    End Sub

    Private Sub btnIniciarSesionComoUsuario_Click(sender As Object, e As EventArgs) Handles btnIniciarSesionComoUsuario.Click
        Dim frm As New WindowsApplication1.Registrarse
        frm.ShowDialog()
    End Sub
End Class