Imports DAL
Imports BE
Public Class esteticistabll


#Region "propiedades"

    Public Property id_esteticista As Integer
    Public Property nombre As String
    Public Property apellido As String
    Public Property telefono As Integer
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
        Dim mBE As Esteticista = EsteticistaDAL.ObtenerEsteticista(pId)

        Me.id_esteticista = mBE.id_esteticista
        Me.nombre = mBE.nombre
        Me.apellido = mBE.apellido
        Me.telefono = mBE.telefono
       
    End Sub


    Private Sub CargarDTO(mBE As Esteticista)
        mBE.id_esteticista = Me.id_esteticista
        mBE.nombre = Me.nombre
        mBE.apellido = Me.apellido
        mBE.telefono = Me.telefono
       
    End Sub


    Public Sub Guardarnuevo()
        Dim mBE As New Esteticista

        CargarDTO(mBE)
        EsteticistaDAL.GuardarNuevo(mBE)

    End Sub


    Public Sub guardarmodificacion()
        Dim mBE As New Esteticista
        CargarDTO(mBE)
        EsteticistaDAL.GuardarModificacion(mBE)

    End Sub


    Public Sub Eliminar()
        Dim mBE As New Esteticista

        CargarDTO(mBE)

        EsteticistaDAL.Eliminar(mBE)
    End Sub


    Public Shared Function Listaresteticista() As List(Of esteticistabll)
        Dim mLista As New List(Of esteticistabll)
        Dim mListaDTO As List(Of Esteticista) = EsteticistaDAL.ListarCliente

        For Each mBE As Esteticista In mListaDTO
            Dim mesteticista As New esteticistabll(mBE.id_esteticista)

            mLista.Add(mesteticista)
        Next

        Return mLista
    End Function

#End Region


End Class
