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

    Private Sub CargarPropiedades(pid As Integer)
        Dim mBE As BE.patente = PatenteDAL.Obtenerpatente(pid)

        If Not IsNothing(mBE) Then
            Me.id = mBE.id
            Me.nombrePatente = mBE.nombre
            Me.padre = mBE.padre

        End If
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


    Public Overrides Function MostrarEnTreeView(pTreeView As TreeView) As TreeView
        Try
            Dim mListaGrupoPatente As New List(Of BE.PatenteAbstracta)
            mListaGrupoPatente = GrupoPatenteDAL.Listar
            Dim vNode As TreeNode = pTreeView.Nodes.Add(mListaGrupoPatente.Item(0).nombre)
            vNode.Tag = mListaGrupoPatente.Item(0)
            Dim mbe As New BE.GrupoPatente
            cargarBE(vNode.Tag)
            AgregarHijos(mbe, vNode)
        Catch ex As Exception

        End Try
        Return pTreeView
    End Function

    Private Sub AgregarHijos(pPadre As BE.GrupoPatente, pTreeNode As TreeNode)
        For Each PAbstracta As BE.PatenteAbstracta In pPadre.listapatentes
            Dim vNode As New TreeNode
            vNode.Text = PAbstracta.nombre
            vNode.Tag = PAbstracta
            pTreeNode.Nodes.Add(vNode)
            If TypeOf PAbstracta Is BE.GrupoPatente Then
                vNode.Text = PAbstracta.nombre
                Dim vGPatente As BE.GrupoPatente
                vGPatente = DirectCast(PAbstracta, BE.GrupoPatente)
                If Not vGPatente.listapatentes Is Nothing Then
                    AgregarHijos(vGPatente, pTreeNode.LastNode)
                End If
            End If
        Next
    End Sub

    'Public Overrides Function Clone() As PatenteAbstracta
    '    Dim pat As New BLL.GrupoPatente
    '    pat.nombrePatente = Me.nombrePatente

    '    For Each patente As PatenteAbstracta In _patentes
    '        pat.Patentes.Add(patente.Clone())
    '    Next

    '    Return pat
    'End Function

    Public Overrides Function listar() As List(Of PatenteAbstracta)
        Dim mlista As New List(Of BLL.PatenteAbstracta)
        Dim mlistabe As List(Of BE.patente) = PatenteDAL.Listar
        For Each mpatente As BE.patente In mlistabe
            Dim ppatente As New BLL.Patente(mpatente.id)
            mlista.Add(ppatente)
        Next

        Return mlista
    End Function
End Class
