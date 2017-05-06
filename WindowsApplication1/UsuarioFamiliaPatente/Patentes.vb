Imports BLL
Public Class Patentes

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        '

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        BLL.modelo.GetInstance().PatenteRaiz.MostrarEnTreeView(Me.treePatentes)
    End Sub


    Property GrupoPatente As New GrupoPatente

    Private Sub Patentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mlistarpatente As New BLL.Patente
        Dim mlistapatentes As New List(Of PatenteAbstracta)
        mlistapatentes = mlistarpatente.listar
        Dim mlistagrupopatente As New BLL.GrupoPatente
        mlistapatentes.AddRange(mlistagrupopatente.listar)
  

        For Each mgrupopatente As BLL.GrupoPatente In mlistagrupopatente.listar
            mgrupopatente.MostrarEnTreeView(treePatentes)

        Next


    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

        Dim mNodo As TreeNode = Me.treePatentes.SelectedNode

        If TypeOf mNodo.Tag Is BLL.GrupoPatente Then

            Dim mPadre As BLL.GrupoPatente = mNodo.Tag

            Dim mForm As New DialogoPatentes
            mForm.ShowDialog()

            Dim mnombrepatente As String = mForm.Nombre
            Dim mNombreFormulario As String = mForm.Formulario

            If (mnombrepatente.Length > 0) And (mNombreFormulario.Length > 0) Then

                Dim mpatente As New BLL.Patente
                Dim mNodoNuevo As New TreeNode

                mNodoNuevo.Text = mnombrepatente

                mpatente.nombrePatente = mForm.Nombre
                mpatente.formulario = mForm.Formulario

                mpatente.Alta()

                mNodoNuevo.Tag = mpatente

                mNodo.Nodes.Add(mNodoNuevo)
                mPadre.listar.Add(mpatente)
            End If
        End If


    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub



    Private Sub IngresarGrupoPatenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresarGrupoPatenteToolStripMenuItem.Click
        Dim vSNode As TreeNode = treePatentes.SelectedNode
        If TypeOf vSNode.Tag Is BLL.GrupoPatente Then
            Dim vPadre As BLL.GrupoPatente = vSNode.Tag
            Dim vNombre As String = InputBox("Ingrese el nombre del Grupo: ")
            If vNombre.Length > 0 Then
                Dim vNNode As New TreeNode
                vNNode.Text = vNombre
                GrupoPatente.nombrePatente = vNombre
                vNNode.Tag = GrupoPatente
                vSNode.Nodes.Add(vNNode)
                vPadre.listar.Add(GrupoPatente)
                GrupoPatente.padre = vPadre.id
                GrupoPatente.alta()
                treePatentes.Nodes.Clear()
                Patentes_Load(Nothing, Nothing)
                treePatentes.ExpandAll()
            End If
        End If
    End Sub
End Class