Imports BE
Public Class GrupoPatenteDAL

    Public Shared Function proximoID() As Integer
        Return BD.ExecuteScalar("Select isnull (max(grupopatente_id), 0) from grupopatente")
    End Function

    Private Shared Function CargarDTO(pgrupopatente As grupopatente, pRow As DataRow) As grupopatente
        pgrupopatente.id = pRow("grupopatente_id")
        pgrupopatente.nombre = pRow("Nombre")
        If TypeOf (pRow("formulario")) Is DBNull Then
            pgrupopatente.formulario = ""
        Else
            pgrupopatente.formulario = pRow("Formulario")
        End If

        If TypeOf (pRow("padre")) Is DBNull Then
            pgrupopatente.padre = 0
        Else
            pgrupopatente.padre = pRow("padre")
        End If
        Return pgrupopatente
    End Function


    Public Shared Function Obtenergrupopatente(pID As Integer) As grupopatente
        Dim mgrupopatente As New grupopatente
        Dim mCommand As String = "SELECT grupopatente_id, Nombre, Formulario, Padre FROM grupopatente WHERE grupopatente_id = " & pID

        Try
            Dim mDataSet As DataSet = BD.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                mgrupopatente = CargarDTO(mgrupopatente, mDataSet.Tables(0).Rows(0))
                Return mgrupopatente
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet - grupopatenteDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Sub GuardarNuevo(pgrupopatente As grupopatente)
        Dim mCommand As String = "INSERT INTO grupopatente(grupopatente_id, nombre, formulario, padre) VALUES (" & pgrupopatente.id & ", '" & pgrupopatente.nombre & "', " & IIf(pgrupopatente.padre = 0, "NULL", pgrupopatente.padre) & ");"

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - grupopatente")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Sub GuardarModificacion(pgrupopatente As grupopatente)
        Dim mCommand As String = "UPDATE grupopatente SET " & _
                                 "grupopatente_id = " & pgrupopatente.id & _
                                 ", Nombre = '" & pgrupopatente.nombre & _
                                  "', formulario = '" & pgrupopatente.formulario & _
                                   "', padre = " & pgrupopatente.padre & _
                                  " WHERE grupopatente_id = " & pgrupopatente.id


        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Modificacion - grupopatenteDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Sub Eliminar(pgrupopatente As grupopatente)
        Dim mCommand As String = "DELETE FROM datoscliente WHERE grupopatente_id = " & pgrupopatente.id

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - grupopatenteDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Function Listar() As List(Of PatenteAbstracta)
        Dim mLista As New List(Of PatenteAbstracta)
        Dim mCommand As String = "SELECT grupopatente_id, Nombre, formulario, padre FROM grupopatente"
        Dim mDataSet As DataSet

        Try
            mDataSet = BD.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim mgrupopatente As New GrupoPatente

                    mgrupopatente = CargarDTO(mgrupopatente, mRow)

                    mLista.Add(mgrupopatente)
                Next

                Return mLista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - grupopatenteDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

End Class
