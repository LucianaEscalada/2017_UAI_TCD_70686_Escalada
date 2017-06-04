Imports BLL
Public Class Principal



    Dim usuario As UsuarioBLL
    Private Sub btnDefinirPatentes_Click(sender As Object, e As EventArgs)
        Dim form As New WindowsApplication1.Patentes
        form.ShowDialog()
    End Sub



    Public Sub New(Optional pUsuario As UsuarioBLL = Nothing)
        InitializeComponent()
        Me.usuario = pUsuario
    End Sub
   
    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mPermisoComp As New BLL.GrupoPatente
        mPermisoComp.MostrarEnMenuStrip(MenuStrip1, Me.usuario, Me)
    End Sub

    Private Sub btnDefinirFamilias_Click(sender As Object, e As EventArgs)
        Dim frm As New WindowsApplication1.Familia
        frm.ShowDialog()
    End Sub

    Private Sub btnDefinirUsuarios_Click(sender As Object, e As EventArgs)
        Dim frm As New WindowsApplication1.Usuarios
        frm.ShowDialog()
    End Sub

    Private Sub btnIniciarSesionComoUsuario_Click(sender As Object, e As EventArgs)
        Dim frm As New WindowsApplication1.Registrarse
        frm.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnDefinirPatentes.Click
        Dim form As New WindowsApplication1.Patentes
        form.ShowDialog()
    End Sub

    Private Sub btnDefinirFamilias_Click_1(sender As Object, e As EventArgs) Handles btnDefinirFamilias.Click
        Dim frm As New WindowsApplication1.Familia
        frm.ShowDialog()
    End Sub

    Private Sub btnDefinirUsuarios_Click_1(sender As Object, e As EventArgs) Handles btnDefinirUsuarios.Click
        Dim frm As New WindowsApplication1.Usuarios
        frm.ShowDialog()
    End Sub

    Private Sub btnIniciarSesionComoUsuario_Click_1(sender As Object, e As EventArgs)
        Dim frm As New WindowsApplication1.Registrarse
        frm.ShowDialog()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class