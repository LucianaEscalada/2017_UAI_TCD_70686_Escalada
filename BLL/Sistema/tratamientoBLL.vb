Imports DAL
Imports BE
Public Class tratamientoBLL
#Region "propiedades"

    Public Property id_tratamiento As Integer
    Public Property nombretratamiento As String
    Public Property precio As Double
    
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
        Dim mBE As BE.tratamiento = tratamientoDAL.Obtenertratamiento(pId)

        Me.id_tratamiento = mBE.id_tratamiento
        Me.nombretratamiento = mBE.nombretratamiento
        Me.precio = mBE.precio
      

    End Sub


    Private Sub CargarDTO(mBE As BE.Tratamiento)
        mBE.id_tratamiento = Me.id_tratamiento
        mBE.nombretratamiento = Me.nombretratamiento
        mBE.precio = Me.precio
        
    End Sub


    Public Sub Guardarnuevo()
        Dim mBE As New BE.tratamiento

        CargarDTO(mBE)
        tratamientoDAL.GuardarNuevo(mBE)

    End Sub


    Public Sub guardarmodificacion()
        Dim mBE As New BE.tratamiento
        CargarDTO(mBE)
        tratamientoDAL.GuardarModificacion(mBE)

    End Sub


    Public Sub Eliminar()
        Dim mBE As New BE.tratamiento

        CargarDTO(mBE)

        tratamientoDAL.Eliminar(mBE)
    End Sub


    Public Shared Function Listartratamiento() As List(Of tratamientoBLL)
        Dim mLista As New List(Of tratamientoBLL)
        Dim mListaDTO As List(Of tratamiento) = tratamientoDAL.Listartratamiento

        For Each mBE As BE.tratamiento In mListaDTO
            Dim mtratamiento As New tratamientoBLL(mBE.id_tratamiento)

            mLista.Add(mtratamiento)
        Next

        Return mLista
    End Function

#End Region

End Class
