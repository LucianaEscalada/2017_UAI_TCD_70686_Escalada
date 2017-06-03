Imports DAL
Imports BE
Public Class productoBLL

#Region "propiedades"

    Public Property id_producto As Integer
    Public Property nombreproducto As String
    Public Property precio_compra As Double
    Public Property precio_venta As Double
    Public Property cantidad As Integer
#End Region


#Region "Constructores"

    Sub New()

    End Sub

    Sub New(pId As Integer)
        CargarPropiedades(pId)
    End Sub

#End Region

#Region "Metodos"

    Private Sub CargarPropiedades(pId As Integer)
        Dim mBE As BE.producto = productoDAL.Obtenerproducto(pId)

        Me.id_producto = mBE.id_producto
        Me.nombreproducto = mBE.nombreproducto
        Me.precio_compra = mBE.preciocompra
        Me.precio_venta = mBE.precioventa
        Me.cantidad = mBE.cantidad

    End Sub


    Private Sub CargarDTO(mBE As BE.producto)
        mBE.id_producto = Me.id_producto
        mBE.nombreproducto = Me.nombreproducto
        mBE.preciocompra = Me.precio_compra
        mBE.precioventa = Me.precio_venta
        mBE.cantidad = Me.cantidad

    End Sub


    Public Sub Guardarnuevo()
        Dim mBE As New BE.producto

        CargarDTO(mBE)
        productoDAL.GuardarNuevo(mBE)

    End Sub


    Public Sub guardarmodificacion()
        Dim mBE As New BE.producto
        CargarDTO(mBE)
        productoDAL.GuardarModificacion(mBE)

    End Sub


    Public Sub Eliminar()
        Dim mBE As New BE.producto

        CargarDTO(mBE)

        productoDAL.Eliminar(mBE)
    End Sub


    Public Shared Function Listarproducto() As List(Of productoBLL)
        Dim mLista As New List(Of productoBLL)
        Dim mListaDTO As List(Of producto) = productoDAL.Listarproducto

        For Each mBE As BE.producto In mListaDTO
            Dim mproducto As New productoBLL(mBE.id_producto)

            mLista.Add(mproducto)
        Next

        Return mLista
    End Function

#End Region

End Class
