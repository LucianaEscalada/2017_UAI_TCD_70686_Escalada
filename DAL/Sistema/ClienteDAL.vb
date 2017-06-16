Imports BE
Public Class ClienteDAL


    Private Shared Function CargarDTO(pcliente As clientegral, pRow As DataRow) As clientegral
        pcliente.nombreyapellido = pRow("Nombreyapellido")
        pcliente.edad = pRow("edad")
        pcliente.dni = pRow("Dni")
        pcliente.mail = pRow("Mail")
        pcliente.telefono = pRow("Telefono")
        pcliente.direccion = pRow("Direccion")
        pcliente.localidad = pRow("Localidad")



        Return pcliente
    End Function


    Public Shared Function ObtenerCliente(pID As Integer) As clientegral
        Dim mcliente As New clientegral
        Dim mCommand As String = "SELECT * FROM datoscliente WHERE dni = " & pID

        Try
            Dim mDataSet As DataSet = BD.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                mcliente = CargarDTO(mcliente, mDataSet.Tables(0).Rows(0))
                Return mcliente
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet - CategoriaDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Sub GuardarNuevo(pcliente As clientegral)
        Dim mCommand As String = "INSERT INTO datoscliente(nombreyapellido, edad, dni , mail, telefono, direccion, localidad) VALUES ('" & pcliente.nombreyapellido & "', " & pcliente.edad & ", " & pcliente.dni & ", ' " & pcliente.mail & "', " & pcliente.telefono & ", ' " & pcliente.direccion & "',' " & pcliente.localidad & "');"

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - clientegral")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Sub GuardarModificacion(pcliente As clientegral)
        Dim mCommand As String = "UPDATE datoscliente SET " & _
                                 "nombreyapellido = '" & pcliente.nombreyapellido & _
                                 "', edad = " & pcliente.edad & _
                                  ", mail = '" & pcliente.mail & _
                                  " ', telefono =" & pcliente.telefono & _
                                  ", direccion = '" & pcliente.direccion & _
                                  "', localidad = '" & pcliente.localidad & _
                                 "' , WHERE dni = " & pcliente.dni

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Modificacion - ClienteDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Sub Eliminar(pcliente As clientegral)
        Dim mCommand As String = "DELETE FROM datoscliente WHERE dni = " & pcliente.dni

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - ClienteDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Function ListarCliente() As List(Of clientegral)
        Dim mLista As New List(Of clientegral)
        Dim mCommand As String = "SELECT nombreyapellido, edad, dni , mail, telefono, direccion , localidad FROM datoscliente"
        Dim mDataSet As DataSet

        Try
            mDataSet = BD.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim mcliente As New clientegral

                    mcliente = CargarDTO(mcliente, mRow)

                    mLista.Add(mcliente)
                Next

                Return mLista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - clienteDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


End Class
