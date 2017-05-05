Imports BE
Imports System.Data.SqlClient

Public Class UsuarioDAL

    'Ejecuta una query sobre la base para saber cual es el ultimo ID de la tabla y le suma uno
    Private Shared mProximoID As Integer
    Public Shared Function GetProximoID() As Integer
        Return BD.ExecuteScalar("select isnull(max(Usuario_id), 0) from Usuario") + 1
    End Function


    Private Shared Function CargarBE(pUsuario As BE.Usuario, pRow As DataRow) As BE.Usuario
        pUsuario.idusuario = pRow("Usuario_id")
        pUsuario.nombre = pRow("Nombre")
        pUsuario.Apellido = pRow("Apellido")
        pUsuario.email() = pRow("email")
        pUsuario.contraseña = pRow("Contraseña")
        If IsNumeric(pRow("Familia")) Then
            pUsuario.familia = pRow("Familia")
        End If

        Return pUsuario
    End Function


    Public Shared Function ObtenerUsuario(pUser As String) As BE.Usuario
        Dim mUsuario As New BE.Usuario
        Dim mCommand As String = "SELECT Usuario_id, nombre, apellido, email, contraseña, familia FROM Usuario WHERE email  LIKE  '" & pUser & "';"

        Try
            Dim mDataSet As DataSet = BD.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                mUsuario = CargarBE(mUsuario, mDataSet.Tables(0).Rows(0))
                Return mUsuario
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet - UsuarioDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Sub GuardarNuevo(pUsuario As BE.Usuario)
        Dim mCommand As String = "INSERT INTO Usuario(Usuario_id, nombre, apellido,email, contraseña)" &
                                 "VALUES (" & pUsuario.idusuario & ", '" & pUsuario.nombre & "', '" & pUsuario.Apellido & "','" & pUsuario.email & "', '" & pUsuario.contraseña & "');"

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - UsuarioDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    'Modifica un registro de la tabla Usuario
    Public Shared Sub GuardarModificacion(pUsuario As BE.Usuario)
        Dim mCommand As String = "UPDATE Usuario SET " &
                                 "', Nombre = '" & pUsuario.nombre &
                                 "', Apellido = '" & pUsuario.Apellido &
                                   "', email = '" & pUsuario.email &
                                 "', Contraseña = '" & pUsuario.contraseña &
                                 "', Familia = " & pUsuario.familia.ToString &
                                 " WHERE Usuario_id = " & pUsuario.idusuario

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Modificacion - UsuarioDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    'Elimina un registro de la tabla Usuario
    Public Shared Sub Eliminar(pUsuario As BE.Usuario)
        Dim mCommand As String = "DELETE FROM Usuario WHERE Usuario_id = " & pUsuario.idusuario

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - UsuarioDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    'Devuelve una lista de objetos be.usuario con los datos de cada registro de la tabla Usuario
    Public Shared Function ListarUsuarios() As List(Of BE.Usuario)
        Dim mLista As New List(Of be.usuario)
        Dim mCommand As String = "SELECT SELECT Usuario_id, Nombre, Apellido,email, contraseña, familia FROM Usuario"
        Dim mDataSet As DataSet

        Try
            mDataSet = BD.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim mUsuario As New be.usuario

                    mUsuario = CargarBE(mUsuario, mRow)

                    mLista.Add(mUsuario)
                Next

                Return mLista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - UsuarioDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
End Class

