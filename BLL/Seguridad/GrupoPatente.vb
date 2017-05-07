Imports DAL
Imports System.Windows.Forms
Public Class GrupoPatente
    Inherits BLL.PatenteAbstracta

    Private _mPatenteBE As BE.PatenteAbstracta

    Sub New(PBE As BE.GrupoPatente)
        CargarPropiedades(PBE)
        CargarHijos()
    End Sub

    Sub New(pID As Integer)
        CargarPropiedades(pID)
        CargarHijos()
    End Sub

    Sub New(mPatenteBE As BE.PatenteAbstracta)
        ' TODO: Complete member initialization 
        _mPatenteBE = mPatenteBE
    End Sub

    Sub New()
        ' TODO: Complete member initialization 
    End Sub


    Private Sub cargarBE(ppatente As BE.PatenteAbstracta)
        ppatente.id = Me.id
        ppatente.nombre = Me.nombrePatente
        ppatente.formulario = Me.formulario
        ppatente.padre = Me.padre
    End Sub

    Private Sub CargarPropiedades(pid As Integer)
        Dim pBE As BE.GrupoPatente = GrupoPatenteDAL.Obtenergrupopatente(pid)

        If Not IsNothing(pBE) Then
            Me.id = pBE.id
            Me.nombrePatente = pBE.nombre
            Me.padre = pBE.padre

        End If
    End Sub

    Private Sub CargarPropiedades(pbe As BE.GrupoPatente)

        If Not IsNothing(pbe) Then
            Me.id = pbe.id
            Me.nombrePatente = pbe.nombre
            Me.padre = pbe.padre

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

            Me.id = GrupoPatenteDAL.proximoID
            cargarBE(mBE)
            GrupoPatenteDAL.GuardarNuevo(mBE)
        Else
            cargarBE(mBE)
            GrupoPatenteDAL.GuardarModificacion(mBE)
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
        For Each mPatenteabstracta As BLL.GrupoPatente In pPadre.listar
            Dim mNode As New TreeNode
            mNode.Text = mPatenteabstracta.nombrePatente
            mNode.Tag = mPatenteabstracta
            pTreeNode.Nodes.Add(mNode)

            If TypeOf (mPatenteabstracta) Is BLL.GrupoPatente Then
                'mNode.Text = mPermisoAbstracto.Nombre

                Dim mgrupopatente As BLL.GrupoPatente
                mgrupopatente = DirectCast(mPatenteabstracta, BLL.GrupoPatente)

                If mgrupopatente.listar.Count > 0 Then
                    AgregarHijos(mgrupopatente, pTreeNode.LastNode)
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

    Public Function listar() As List(Of BLL.PatenteAbstracta)


        Dim mlista As New List(Of BLL.PatenteAbstracta)
        Dim mlistabe As List(Of BE.GrupoPatente) = GrupoPatenteDAL.Listar

        If Not IsNothing(mlistabe) Then
            For Each mpatente As BE.PatenteAbstracta In mlistabe
                If TypeOf (mpatente) Is BE.GrupoPatente Then
                    Dim ppatente As New BLL.GrupoPatente(mpatente.id)
                    mlista.Add(ppatente)
                End If

            Next
        End If
        Return mlista
    End Function


    Private Sub CargarHijos()
        Dim mListaCompuestos As List(Of BE.GrupoPatente) = GrupoPatenteDAL.Listar(Me.id)
        Dim mListaSimples As List(Of BE.patente) = PatenteDAL.Listar(Me.id)

        If Not IsNothing(mListaCompuestos) Then
            For Each mPermisoAbs As BE.PatenteAbstracta In mListaCompuestos
                Dim mPermisoBLL As New BLL.GrupoPatente(mPermisoAbs)
                Me.listar.Add(mPermisoBLL)
            Next
        End If

        If Not IsNothing(mListaSimples) Then
            For Each mPermisoAbs As BE.PatenteAbstracta In mListaSimples
                Dim mPatentebll As New BLL.Patente(mPermisoAbs)
                Me.listar.Add(mPatentebll)
            Next
        End If
    End Sub
End Class
