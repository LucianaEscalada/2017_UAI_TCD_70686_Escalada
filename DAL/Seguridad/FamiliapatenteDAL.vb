Imports BE
Public Class FamiliapatenteDAL
  
    Public Shared Sub GuardarNuevo(PfamiliaID As Integer, PpermisoID As Integer)
        Dim mCommand As String = "INSERT INTO Familiapatente(Familia_id, patente_id) VALUES " &
                                 "(" & PfamiliaID & ", " & PpermisoID & ")"

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - FamiliapatenteDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Sub EliminarPorPermiso(PfamiliaID As Integer)
        Dim mCommand As String = "DELETE FROM Familiapatente WHERE Familiapatente = " & PfamiliaID

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminar Permiso - FamiliapatenteDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Sub EliminarPorRol(PfamiliaID As Integer)
        Dim mCommand As String = "DELETE FROM Familiapatente WHERE Familiapatente = " & PfamiliaID

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminar Rol - FamiliapatenteDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Sub Eliminar(pFamiliaID As Integer, PpermisoID As Integer)
        Dim mCommand As String = "DELETE FROM Familiapatente WHERE Familiapatente = " & pFamiliaID & "AND Familiapatente = " & pFamiliaID

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminar Permiso de Rol - FamiliapatenteDAL")
            MsgBox(ex.Message)
        End Try
    End Sub




End Class
