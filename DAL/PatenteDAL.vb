Imports BE
Public Class PatenteDAL


    Private Shared Function CargarDTO(Ppatente As patente, pRow As DataRow) As patente
        Ppatente.id = pRow("patente_id")
        Ppatente.nombre = pRow("Nombre")
        Ppatente.formulario = pRow("Formulario")
        Ppatente.padre = pRow("padre")
        Return Ppatente
    End Function

    Public Shared Function proximoID() As Integer
        Return BD.ExecuteScalar("Select isnull (max(patente_id), 0) from patente")
    End Function


    Public Shared Function Obtenerpatente(pID As Integer) As patente
        Dim Mpatente As New patente
        Dim mCommand As String = "SELECT patente_id, Nombre, formulario, padre FROM patente WHERE patente_id = " & pID

        Try
            Dim mDataSet As DataSet = BD.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                Mpatente = CargarDTO(Mpatente, mDataSet.Tables(0).Rows(0))
                Return Mpatente
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet - patenteDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Sub GuardarNuevo(Ppatente As BE.PatenteAbstracta)
        'el iif es un if en una sola linea, si la condicion que le pongo al principio es verdadera voy al null, si no pasa el valor que tenga el padre
        Dim mCommand As String = "INSERT INTO patente(patente_id, nombre, formulario, padre) VALUES (" & Ppatente.id & ", '" & Ppatente.nombre & "' , '" & Ppatente.formulario & "' , " & IIf(Ppatente.padre = 0, "Null", Ppatente.padre) & ");"

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - patente")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Sub GuardarModificacion(Ppatente As BE.PatenteAbstracta)
        Dim mCommand As String = "UPDATE patente SET " & _
                                 "patente_id = " & Ppatente.id & _
                                 ", Nombre = '" & Ppatente.nombre & _
                                 "', Formulario = '" & Ppatente.formulario & _
                                 "', padre= " & Ppatente.padre & _
                                  " WHERE patente_id = " & Ppatente.id

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Modificacion - patenteDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Sub Eliminar(Ppatente As BE.PatenteAbstracta)
        Dim mCommand As String = "DELETE FROM Patente WHERE patente_id = " & Ppatente.id

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - patenteDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Function Listar() As List(Of BE.PatenteAbstracta)
        Dim mLista As New List(Of BE.PatenteAbstracta)
        Dim mCommand As String = "SELECT patente_id, Nombre, formulario, padre FROM patente"
        Dim mDataSet As DataSet

        Try
            mDataSet = BD.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim Mpatente As New patente

                    Mpatente = CargarDTO(Mpatente, mRow)

                    mLista.Add(Mpatente)
                Next

                Return mLista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - patenteDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


End Class
