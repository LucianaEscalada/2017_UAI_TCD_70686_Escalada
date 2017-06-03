Imports BE
Public Class TratamientoDAL

    Private Shared Function CargarDTO(ptratamiento As BE.Tratamiento, pRow As DataRow) As BE.Tratamiento
        ptratamiento = pRow("nombre_tratamiento")
        ptratamiento.precio = pRow("precio")
        Return ptratamiento
    End Function


    Public Shared Function Obtenertratamiento(pID As Integer) As BE.Tratamiento
        Dim mtratamiento As New BE.tratamiento
        Dim mCommand As String = "SELECT id_tratamiento, nombre_tratamiento, precio, FROM tratamiento WHERE id_tratamiento = " & pID

        Try
            Dim mDataSet As DataSet = BD.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                mtratamiento = CargarDTO(mtratamiento, mDataSet.Tables(0).Rows(0))
                Return mtratamiento
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet - tratamientoDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Sub GuardarNuevo(ptratamiento As BE.Tratamiento)
        Dim mCommand As String = "INSERT INTO tratamiento(nombre_tratamiento, precio) VALUES ('" & ptratamiento.nombretratamiento & "', " & ptratamiento.precio & ");"

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - tratamiento")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Sub GuardarModificacion(ptratamiento As BE.Tratamiento)
        Dim mCommand As String = "UPDATE tratamiento SET " & _
                                 "nombre_tratamiento = '" & ptratamiento.nombretratamiento & _
                                 "', precio = " & ptratamiento.precio & _
                                 "' , WHERE id_tratamiento = " & ptratamiento.id_tratamiento

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Modificacion - tratamientoDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Sub Eliminar(ptratamiento As BE.Tratamiento)
        Dim mCommand As String = "DELETE FROM tratamiento WHERE id_tratamiento = " & ptratamiento.id_tratamiento

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - tratamientoDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Function Listartratamiento() As List(Of BE.Tratamiento)
        Dim mLista As New List(Of BE.tratamiento)
        Dim mCommand As String = "SELECT nombre_tratamiento, precio FROM tratamiento"
        Dim mDataSet As DataSet

        Try
            mDataSet = BD.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim mtratamiento As New BE.tratamiento

                    mtratamiento = CargarDTO(mtratamiento, mRow)

                    mLista.Add(mtratamiento)
                Next

                Return mLista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - tratamientoDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


End Class
