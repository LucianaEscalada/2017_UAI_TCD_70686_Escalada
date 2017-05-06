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

    Public Overrides Function MostrarEnTreeview(pTreeView As TreeView) As TreeView
        Try
            Dim mListaPermisos As List(Of BLL.PatenteAbstracta) = listar()

           
            Dim mNode As TreeNode = pTreeView.Nodes.Add(mListaPermisos.Item(0).nombrePatente)
            mNode.Tag = mListaPermisos.Item(0)

            AgregarHijos(mNode.Tag, mNode)
        Catch ex As Exception

        End Try

        Return pTreeView
    End Function

    Private Sub AgregarHijos(pPadre As BLL.GrupoPatente, pTreeNode As TreeNode)
        For Each mPermisoAbstracto As BLL.PatenteAbstracta In pPadre.listar
            Dim mNode As New TreeNode
            mNode.Text = mPermisoAbstracto.nombrePatente
            mNode.Tag = mPermisoAbstracto
            pTreeNode.Nodes.Add(mNode)

            If TypeOf (mPermisoAbstracto) Is BLL.GrupoPatente Then
                'mNode.Text = mPermisoAbstracto.Nombre

                Dim mPermisoCompuesto As BLL.GrupoPatente
                mPermisoCompuesto = DirectCast(mPermisoAbstracto, GrupoPatente)

                If mPermisoCompuesto.listar.Count > 0 Then
                    AgregarHijos(mPermisoCompuesto, pTreeNode.LastNode)
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

    Public Overrides Function listar() As List(Of BLL.PatenteAbstracta)


        Dim mlista As New List(Of BLL.PatenteAbstracta)
        Dim mlistabe As List(Of BE.PatenteAbstracta) = GrupoPatenteDAL.Listar

        If Not IsNothing(mlistabe) Then
            For Each mpatente As BE.PatenteAbstracta In mlistabe
                If TypeOf (mpatente) Is BE.GrupoPatente Then
                    Dim ppatente As New BLL.Patente(mpatente.id)
                    mlista.Add(ppatente)
                End If

            Next
        End If
        Return mlista
    End Function
End Class
