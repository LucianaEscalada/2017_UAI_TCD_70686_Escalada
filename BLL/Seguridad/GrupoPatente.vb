Imports DAL
Imports System.Windows.Forms
Imports System.Reflection

Public Class GrupoPatente
    Inherits BLL.PatenteAbstracta

    'Private _mPatenteBE As BE.PatenteAbstracta

    Sub New(PBE As BE.GrupoPatente)
        CargarPropiedades(PBE)
        CargarHijos()
    End Sub

    Sub New(pID As Integer)
        CargarPropiedades(pID)
        CargarHijos()
    End Sub

    Sub New(mPatenteBE As BE.PatenteAbstracta)
        CargarPropiedades(mPatenteBE.id)
        CargarHijos()
    End Sub

    Sub New()
        ' TODO: Complete member initialization 
    End Sub


    Public Sub cargarBE(ppatente As BE.PatenteAbstracta)
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
        For Each mPatenteabstracta As BLL.PatenteAbstracta In pPadre.Patentes
            Dim mNode As New TreeNode
            mNode.Text = mPatenteabstracta.nombrePatente
            mNode.Tag = mPatenteabstracta
            pTreeNode.Nodes.Add(mNode)

            If TypeOf (mPatenteabstracta) Is BLL.GrupoPatente Then
                mNode.Text = mPatenteabstracta.nombrePatente

                Dim mgrupopatente As BLL.GrupoPatente
                mgrupopatente = DirectCast(mPatenteabstracta, BLL.GrupoPatente)

                If mgrupopatente.Patentes.Count > 0 Then
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


    'Este metodo es el encargado de ir a la base y traer todas las patentes que tengan como padre el id de este
    'grupoPatente (sin importar si son patentes o gruposPatente). Si dentro de esa lista de "patentes hijo" hay
    'alguna que sea grupoPatente, esa tambien se carga con las patentes que tenga como hijo.
    '(Eso ultimo pasa porque este metodo se llama desde los constructores de grupoPatente, entonces cada vez que
    ' se instancia uno este ya carga su lista de patentes)
    Private Sub CargarHijos()
        Dim mListaCompuestos As List(Of BE.GrupoPatente) = GrupoPatenteDAL.Listar(Me.id)
        Dim mListaSimples As List(Of BE.patente) = PatenteDAL.Listar(Me.id)

        If Not IsNothing(mListaCompuestos) Then
            For Each mPermisoAbs As BE.PatenteAbstracta In mListaCompuestos
                Dim mPermisoBLL As New BLL.GrupoPatente(mPermisoAbs)
                Me.Patentes.Add(mPermisoBLL)
            Next
        End If

        If Not IsNothing(mListaSimples) Then
            For Each mPermisoAbs As BE.PatenteAbstracta In mListaSimples
                Dim mPatentebll As New BLL.Patente(mPermisoAbs)
                Me.Patentes.Add(mPatentebll)
            Next
        End If
    End Sub


    Public Overrides Sub MostrarEnMenuStrip(pMenuStrip As MenuStrip, pUsuario As UsuarioBLL, pFormulario As Form)
        Dim mRol As New BLL.Familia(pUsuario.rol)

        For Each mPermisoAbs As BLL.PatenteAbstracta In mRol.mlistaPatentes
            Dim mMenuItem As New ToolStripMenuItem()

            mMenuItem.Name = mPermisoAbs.nombrePatente
            mMenuItem.Tag = mPermisoAbs

            pMenuStrip.Items.Add(mMenuItem)
            pMenuStrip.Items.Item(mMenuItem.Name).Text = mPermisoAbs.nombrePatente

            If TypeOf mPermisoAbs Is BLL.GrupoPatente Then
                AgregarToolStrip(mPermisoAbs, mMenuItem, pFormulario)
            Else
                AddHandler mMenuItem.Click, AddressOf Menu_Click
            End If
        Next
    End Sub

    Public Sub AgregarToolStrip(pPermiso As BLL.PatenteAbstracta, pMenuItem As ToolStripMenuItem, pFormulario As Form)
        Try
            Dim mPadre As BLL.GrupoPatente = DirectCast(pPermiso, BLL.GrupoPatente)

            If Not mPadre.Patentes Is Nothing Then
                For Each mPermisoAbs As BLL.PatenteAbstracta In mPadre.Patentes
                    Dim mMenuItem As New ToolStripMenuItem

                    mMenuItem.Name = mPermisoAbs.nombrePatente
                    mMenuItem.Tag = mPermisoAbs

                    pMenuItem.DropDownItems.Add(mMenuItem)
                    pMenuItem.DropDownItems.Item(mMenuItem.Name).Text = mPermisoAbs.nombrePatente


                    If TypeOf mPermisoAbs Is BLL.GrupoPatente Then
                        AgregarToolStrip(mPermisoAbs, mMenuItem, pFormulario)
                    Else
                        AddHandler mMenuItem.Click, AddressOf Menu_Click
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub


    Public Sub Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mMenuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Click(mMenuItem)
    End Sub


    Private Sub Click(pMenuItem As ToolStripItem)
        Dim mFormName As String = DirectCast(pMenuItem.Tag, BLL.Patente).formulario.ToString
        Dim mAssembly As Assembly = Assembly.GetEntryAssembly
        Dim mType As Type = mAssembly.GetType(mFormName)
        Dim mForm = Activator.CreateInstance(mType)
        mForm.ShowDialog()
    End Sub


End Class
