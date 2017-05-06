Imports BE
Public Class PatenteDAL


    Private Shared Function Cargarbe(Ppatente As patente, pRow As DataRow) As patente
        Ppatente.id = pRow("patente_id")
        Ppatente.nombre = pRow("Nombre")
        If TypeOf (pRow("formulario")) Is DBNull Then
            Ppatente.formulario = ""
        Else
            Ppatente.formulario = pRow("Formulario")
        End If

        If TypeOf (pRow("padre")) Is DBNull Then
            Ppatente.padre = 0
        Else
            Ppatente.padre = pRow("padre")
        End If
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
                Mpatente = Cargarbe(Mpatente, mDataSet.Tables(0).Rows(0))
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
        Dim mCommand As String = ""


        mCommand = "INSERT INTO patente(Patente_id, nombre, formulario, padre) " & _
                    "VALUES (" & Ppatente.id & ", '" & Ppatente.nombre & "' , '" & Ppatente.formulario & "' , " & Ppatente.padre & ");"

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - PatenteDAL")
            MsgBox(ex.Message)
        End Try

       
    End Sub
    Public Shared Sub GuardarModificacion(Ppatente As BE.PatenteAbstracta)
        Dim mCommand As String = ""

        If TypeOf (Ppatente) Is BE.patente Then
            mCommand = "UPDATE Patente SET " &
                                                        "patente_id = " & Ppatente.id & _
                                     ", Nombre = '" & Ppatente.nombre & _
                                     "', Formulario = '" & Ppatente.formulario & _
                                     "', padre= " & Ppatente.padre & _
                                      " WHERE patente_id = " & Ppatente.id
        ElseIf TypeOf (Ppatente) Is BE.GrupoPatente Then
            mCommand = "UPDATE Permiso SET " &
                                     "patente_id = " & Ppatente.id & _
                                     ", Nombre = '" & Ppatente.nombre & _
                                     "', Formulario = '" & Ppatente.formulario & _
                                     "', padre= " & Ppatente.padre & _
                                      " WHERE patente_id = " & Ppatente.id

        End If

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Modificacion - PatenteDAL")
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


    Public Shared Function Listar(Optional pgrupopatente As Boolean = False, Optional pPadreID As Integer = -1) As List(Of BE.patente)
        Dim mLista As New List(Of BE.patente)
        Dim mCommand As String = " "
        Dim mDataSet As DataSet

        If pPadreID <> -1 Then
            mCommand = "SELECT Patente_id, nombre, formulario, padre FROM Patente WHERE padre = " & pPadreID
        Else
            mCommand = "SELECT Patente_id, nombre, formulario, padre FROM Permiso"
        End If

        Try
            mDataSet = BD.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim Mpatente As New patente

                    Mpatente = Cargarbe(Mpatente, mRow)

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
