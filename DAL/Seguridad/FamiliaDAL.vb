﻿Imports BE
Public Class FamiliaDAL



    Public Shared Function proximoID() As Integer
        Return BD.ExecuteScalar("Select isnull (max(familia_id), 0) from familia") + 1
    End Function

    Private Shared Function CargarDTO(pfamilia As Familia, pRow As DataRow) As Familia
        pfamilia.familia_id = pRow("Familia_id")
        pfamilia.nombre = pRow("NombreFamilia")
      
        Return pfamilia
    End Function


    Public Shared Function Obtenerfamilia(pID As Integer) As Familia
        Dim mfamilia As New Familia
        Dim mCommand As String = "SELECT familia_id, NombreFamilia FROM familia WHERE Familia_id = " & pID

        Try
            Dim mDataSet As DataSet = BD.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                mfamilia = CargarDTO(mfamilia, mDataSet.Tables(0).Rows(0))
                Return mfamilia
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet - FamiliaDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Sub GuardarNuevo(pfamilia As Familia)
        Dim mCommand As String = "INSERT INTO Familia(Familia_id, nombrefamilia) VALUES (" & pfamilia.familia_id & ", '" & pfamilia.nombre & "');"

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - familia")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Sub GuardarModificacion(pfamilia As Familia)
        Dim mCommand As String = "UPDATE Familia SET " & _
                                 "Familia_id = " & pfamilia.familia_id & _
                                 ", NombreFamilia = '" & pfamilia.nombre & _
                                  "' WHERE Familia_id = " & pfamilia.familia_id

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Modificacion - FamiliaDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Sub Eliminar(pfamilia As Familia)
        Dim mCommand As String = "DELETE FROM datoscliente WHERE Familia_id = " & pfamilia.familia_id

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - FamiliaDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Function ListarCliente() As List(Of Familia)
        Dim mLista As New List(Of familia)
        Dim mCommand As String = "SELECT Familia_id, NombreFamilia FROM Familia"
        Dim mDataSet As DataSet

        Try
            mDataSet = BD.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim mfamilia As New familia

                    mfamilia = CargarDTO(mfamilia, mRow)

                    mLista.Add(mfamilia)
                Next

                Return mLista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - FamiliaDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

End Class
