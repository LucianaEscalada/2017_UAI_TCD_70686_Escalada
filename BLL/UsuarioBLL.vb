Imports DAL
Imports BE
Public Class UsuarioBLL


    Public Property ID As Integer = 0
    Public Property Nombre As String
    Public Property Apellido As String
    Public Property email As String
    Public Property Password As String
    Public Property rol As Integer


    Sub New()

    End Sub

    Sub New(pUser As String)
        CargarPropiedades(pUser)
    End Sub



    Private Sub CargarPropiedades(pUser As String)
        Dim mBE As be.usuario = UsuarioDAL.ObtenerUsuario(pUser)

        If Not IsNothing(mBE) Then
            Me.ID = mBE.idusuario
            Me.Nombre = mBE.Nombre
            Me.Apellido = mBE.Apellido
            Me.email = mBE.email
            Me.Password = mBE.contraseña
            Me.Rol = mBE.familia
        End If
    End Sub


    Private Sub CargarBE(mBE As BE.Usuario)
        mBE.idusuario = Me.ID
        mBE.Nombre = Me.Nombre
        mBE.Apellido = Me.Apellido
        mBE.email = Me.email
        mBE.contraseña = Me.Password
        mBE.familia = Me.Rol
    End Sub


    Public Sub Guardar()
        Dim mBE As New be.usuario

        If Me.ID = 0 Then
            Me.ID = UsuarioDAL.GetProximoID
            CargarBE(mBE)
            UsuarioDAL.GuardarNuevo(mBE)
        Else
            CargarBE(mBE)
            UsuarioDAL.GuardarModificacion(mBE)
        End If
    End Sub


    Public Sub Eliminar()
        Dim mBE As New be.usuario

        CargarBE(mBE)

        UsuarioDAL.Eliminar(mBE)
    End Sub


    Public Shared Function ListarUsuarios() As List(Of UsuarioBLL)
        Dim mLista As New List(Of UsuarioBLL)
        Dim mListaBE As List(Of be.usuario) = UsuarioDAL.ListarUsuarios

        For Each mBE As be.usuario In mListaBE
            Dim mUsuario As New UsuarioBLL(mBE.idusuario)

            mLista.Add(mUsuario)
        Next

        Return mLista
    End Function


End Class
