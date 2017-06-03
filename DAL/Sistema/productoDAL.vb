Imports BE
Public Class productoDAL


    Private Shared Function CargarDTO(pproducto As BE.producto, pRow As DataRow) As BE.producto
        pproducto.id_producto = pRow("id_producto")
        pproducto.nombreproducto = pRow("nombre_producto")
        pproducto.preciocompra = pRow("precio_compra")
        pproducto.precioventa = pRow("precio_venta")
        pproducto.cantidad = pRow("cantidad")


        Return pproducto
    End Function


    Public Shared Function Obtenerproducto(pID As Integer) As BE.producto
        Dim mproducto As New BE.producto
        Dim mCommand As String = "SELECT id_producto, nombre_producto, precio_compra, precio_venta, cantidad FROM producto WHERE id_producto = " & pID

        Try
            Dim mDataSet As DataSet = BD.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                mproducto = CargarDTO(mproducto, mDataSet.Tables(0).Rows(0))
                Return mproducto
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet - productoDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Sub GuardarNuevo(pproducto As BE.producto)
        Dim mCommand As String = "INSERT INTO producto(nombre_producto, precio_compra,precio_venta , cantidad) VALUES ('" & pproducto.nombreproducto & "', " & pproducto.preciocompra & ", " & pproducto.precioventa & ",  " & pproducto.cantidad & ");"

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - producto")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Sub GuardarModificacion(pproducto As BE.producto)
        Dim mCommand As String = "UPDATE producto SET " & _
                                 "nombre_producto = '" & pproducto.nombreproducto & _
                                 "', precio_compra = " & pproducto.preciocompra & _
                                  ", precio_venta = " & pproducto.precioventa & _
                                  " , cantidad =" & pproducto.cantidad & _
                                 "' , WHERE id_producto = " & pproducto.id_producto

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Modificacion - productoDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Sub Eliminar(pproducto As BE.producto)
        Dim mCommand As String = "DELETE FROM producto WHERE id_producto = " & pproducto.id_producto

        Try
            BD.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - productoDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Function Listarproducto() As List(Of BE.producto)
        Dim mLista As New List(Of BE.producto)
        Dim mCommand As String = "SELECT id_producto, nombre_producto, precio_compra, precio_venta , cantidad FROM producto"
        Dim mDataSet As DataSet

        Try
            mDataSet = BD.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim mproducto As New BE.producto

                    mproducto = CargarDTO(mproducto, mRow)

                    mLista.Add(mproducto)
                Next

                Return mLista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - productoDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


End Class
