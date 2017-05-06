Imports BE
Public Class GrupoPatenteDAL

    Public Shared Function proximoID() As Integer
        Return BD.ExecuteScalar("Select isnull (max(grupopatente_id), 0) from grupopatente")
    End Function

    Private Shared Function CargarDTO(pgrupopatente As GrupoPatente, pRow As DataRow) As GrupoPatente
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
        Dim mCommand As String = ""


        mCommand = "INSERT INTO grupopatente(nombre, formulario, padre) " &
                    "VALUES ('" & pgrupopatente.nombre & "' , '" & pgrupopatente.formulario & "' , " & pgrupopatente.padre & ");"

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - PatenteDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Sub GuardarModificacion(pgrupopatente As GrupoPatente)
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


    Public Shared Sub Eliminar(pgrupopatente As GrupoPatente)
        Dim mCommand As String = "DELETE FROM datoscliente WHERE grupopatente_id = " & pgrupopatente.id

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - grupopatenteDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Function Listar(Optional pPadreID As Integer = -1) As List(Of BE.GrupoPatente)
        Dim mLista As New List(Of BE.GrupoPatente)
        Dim mCommand As String = " "
        Dim mDataSet As DataSet

        If pPadreID <> -1 Then
            mCommand = "SELECT grupopatente_id, nombre, formulario, padre FROM grupopatente WHERE padre = " & pPadreID
        Else
            mCommand = "SELECT grupopatente_id, nombre, formulario, padre FROM grupopatente"
        End If

        Try
            mDataSet = BD.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim Mgrupopatente As New GrupoPatente

                    Mgrupopatente = CargarDTO(Mgrupopatente, mRow)

                    mLista.Add(Mgrupopatente)
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
