Imports BE
Public Class EsteticistaDAL

    Private Shared mProxID As Integer

    Public Shared Function GetProximoID() As Integer
        mProxID = BD.UltimoID("esteticista") + 1
        Return mProxID
    End Function

    Private Shared Function CargarDTO(pesteticista As Esteticista, pRow As DataRow) As Esteticista
        pesteticista.nombre = pRow("Nombre")
        pesteticista.apellido = pRow("apellido")
        pesteticista.telefono = pRow("celular")

        Return pesteticista
    End Function


    Public Shared Function ObtenerEsteticista(pID As Integer) As Esteticista
        Dim mesteticista As New Esteticista
        Dim mCommand As String = "SELECT id_esteticista, nombre, apellido, celular FROM esteticista WHERE id_esteticista = " & pID

        Try
            Dim mDataSet As DataSet = BD.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                mesteticista = CargarDTO(mesteticista, mDataSet.Tables(0).Rows(0))
                Return mesteticista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet - EsteticistaDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Sub GuardarNuevo(pesteticista As Esteticista)
        Dim mCommand As String = "INSERT INTO Esteticista(id_esteticista, nombre, apellido, celular ) VALUES (" & pesteticista.id_esteticista & ",'" & pesteticista.nombre & "','" & pesteticista.apellido & "', " & pesteticista.telefono & "); "

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - Esteticista")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Sub GuardarModificacion(pesteticista As Esteticista)
        Dim mCommand As String = "UPDATE datoscliente SET " & _
                                 "Nombre = '" & pesteticista.nombre & _
                                 "', edad = '" & pesteticista.apellido & _
                                  "', celular = " & pesteticista.telefono & _
                                 " , WHERE id_esteticista = " & pesteticista.id_esteticista

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Modificacion - EsteticistaDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Sub Eliminar(pesteticista As Esteticista)
        Dim mCommand As String = "DELETE FROM esteticista WHERE id_esteticista = " & pesteticista.id_esteticista

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - EsteticistaDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Function ListarCliente() As List(Of Esteticista)
        Dim mLista As New List(Of Esteticista)
        Dim mCommand As String = "SELECT nombre, apellido, celular  FROM esteticista"
        Dim mDataSet As DataSet

        Try
            mDataSet = BD.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim mesteticista As New Esteticista

                    mesteticista = CargarDTO(mesteticista, mRow)

                    mLista.Add(mesteticista)
                Next

                Return mLista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - esteticistaDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

End Class
