Imports DAL
Imports System.Windows.Forms
Public Class GrupoPatente
    Inherits BLL.PatenteAbstracta



    Private Sub cargarBE(ppatente As BE.PatenteAbstracta)
        ppatente.id = Me.id
        ppatente.nombre = Me.nombrePatente
        ppatente.formulario = Me.formulario
        ppatente.padre = Me.padre
    End Sub

    Private _patentes As New List(Of BLL.PatenteAbstracta)
    Public Property Patentes() As List(Of BLL.PatenteAbstracta)
        Get
            Return _patentes
        End Get
        Set(ByVal value As List(Of BLL.PatenteAbstracta))
            _patentes = value
        End Set
    End Property


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

    Public Overrides Sub MostrarEnTreeview(ByRef padres As Windows.Forms.TreeNodeCollection)


        Dim node As TreeNode = padres.Add(Me.nombrePatente)
        node.Tag = Me

        For Each patente As BLL.PatenteAbstracta In _patentes
            patente.MostrarEnTreeview(node.Nodes)
        Next

    End Sub

    Public Overrides Function Clone() As PatenteAbstracta
        Dim pat As New BLL.GrupoPatente
        pat.nombrePatente = Me.nombrePatente

        For Each patente As PatenteAbstracta In _patentes
            pat.Patentes.Add(patente.Clone())
        Next

        Return pat
    End Function
End Class
