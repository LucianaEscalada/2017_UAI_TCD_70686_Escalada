Imports DAL
Imports BE
Public Class cliente


#Region "Propiedades"


    Public Property nombreyapellido As String
    Public Property edad As Integer
    Public Property dni As Integer
    Public Property mail As String
    Public Property telefono As Integer
    Public Property direccion As String
    Public Property localidad As String
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
        Dim mBE As clientegral = ClienteDAL.ObtenerCliente(pId)

        Me.nombreyapellido = mBE.nombreyapellido
        Me.edad = mBE.edad
        Me.dni = mBE.dni
        Me.mail = mBE.mail
        Me.telefono = mBE.telefono
        Me.direccion = mBE.direccion
        Me.localidad = mBE.localidad

    End Sub


    Private Sub CargarDTO(mBE As clientegral)
        mBE.nombreyapellido = Me.nombreyapellido
        mBE.edad = Me.edad
        mBE.dni = Me.dni
        mBE.mail = Me.mail
        mBE.telefono = Me.telefono
        mBE.direccion = Me.direccion
        mBE.localidad = Me.localidad
    End Sub


    Public Sub Guardarnuevo()
        Dim mBE As New clientegral

        CargarDTO(mBE)
        ClienteDAL.GuardarNuevo(mBE)
       
    End Sub


    Public Sub guardarmodificacion()
        Dim mBE As New clientegral
        CargarDTO(mBE)
        ClienteDAL.GuardarModificacion(mBE)

    End Sub


    Public Sub Eliminar()
        Dim mBE As New clientegral

        CargarDTO(mBE)

        ClienteDAL.Eliminar(mBE)
    End Sub


    Public Shared Function Listarcliente() As List(Of cliente)
        Dim mLista As New List(Of cliente)
        Dim mListaDTO As List(Of clientegral) = ClienteDAL.ListarCliente

        For Each mBE As clientegral In mListaDTO
            Dim mCliente As New cliente(mBE.dni)

            mLista.Add(mCliente)
        Next

        Return mLista
    End Function

#End Region

End Class
