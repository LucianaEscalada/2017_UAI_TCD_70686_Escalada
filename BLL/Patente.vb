Imports DAL
Imports System.Windows.Forms
Public Class Patente
    Inherits PatenteAbstracta


    Private _patentes As New List(Of BLL.PatenteAbstracta)
    Public Property Patentes() As List(Of BLL.PatenteAbstracta)
        Get
            Return _patentes
        End Get
        Set(ByVal value As List(Of BLL.PatenteAbstracta))
            _patentes = value
        End Set
    End Property



    Private Sub cargarBE(ppatente As BE.PatenteAbstracta)
        ' ppatente.id = Me.id
        ppatente.nombre = Me.nombrePatente
        ppatente.formulario = Me.formulario
        ppatente.padre = Me.padre
    End Sub



    Private Sub CargarPropiedades(pid As Integer)
        Dim mBE As BE.patente = PatenteDAL.Obtenerpatente(pid)

        If Not IsNothing(mBE) Then
            Me.id = mBE.id
            Me.nombrePatente = mBE.nombre
            Me.padre = mBE.padre

        End If
    End Sub

    Public Overrides Function MostrarEnTreeView(pTreeView As Windows.Forms.TreeView) As Windows.Forms.TreeView
        Return Nothing
    End Function

    Public Overrides Sub Alta()
   
        Dim mBE As New BE.GrupoPatente
        If Me.id = 0 Then

            Me.id = PatenteDAL.proximoID
            cargarBE(mBE)
            PatenteDAL.GuardarNuevo(mBE)
        Else
            cargarBE(mBE)
            PatenteDAL.GuardarModificacion(mBE)
        End If
    End Sub

    Public Overrides Sub baja()
        Dim mbe As New BE.GrupoPatente
        cargarBE(mbe)
        PatenteDAL.Eliminar(mbe)
    End Sub

    Public Overrides Function listar() As List(Of PatenteAbstracta)

        Dim mlista As New List(Of BLL.PatenteAbstracta)
        Dim mlistabe As List(Of BE.patente) = PatenteDAL.Listar

        If Not IsNothing(mlistabe) Then
            For Each mpatente As BE.PatenteAbstracta In mlistabe
                If TypeOf (mpatente) Is BE.patente Then
                    Dim ppatente As New BLL.Patente(mpatente.id)
                End If

            Next
        End If
        Return mlista

    End Function

    Public Sub New()

    End Sub

    Public Sub New(pid As Integer)
        CargarPropiedades(pid)

    End Sub


    'Public Overrides Function Clone() As PatenteAbstracta
    '    Dim pat As New BLL.Patente
    '    pat.nombrePatente = Me.nombrePatente
    '    Return pat
    'End Function
End Class
