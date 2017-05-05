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
        Dim nodo As TreeNode = Me.treePatentes.SelectedNode

        If TypeOf nodo.Tag Is GrupoPatente Then
            Dim formNuevaPatente As New DialogoPatentes
            formNuevaPatente.ShowDialog()

            Dim padre As GrupoPatente = nodo.Tag

            Dim frm As New WindowsApplication1.DialogoPatentes
            frm.ShowDialog()

            Dim nombre As String = frm.Nombre
            Dim formulario As String = frm.Formulario

            If (nombre.Length > 0) And (formulario.Length > 0) Then

                Dim patente As New Patente
                Dim nodoNuevo As New TreeNode
                Dim mpatente As New GrupoPatente
                nodoNuevo.Text = nombre
                patente.nombrePatente = frm.Nombre
                patente.formulario = frm.Formulario
                nodoNuevo.Tag = patente
                mpatente.nombrePatente = DialogoPatentes.Nombre
                mpatente.formulario = DialogoPatentes.Formulario
                patente.Alta()
                nodo.Nodes.Add(nodoNuevo)
                padre.Patentes.Add(mpatente)
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
        If TypeOf vSNode.Tag Is GrupoPatente Then
            Dim vPadre As GrupoPatente = vSNode.Tag
            Dim vNombre As String = InputBox("Ingrese el nombre del Grupo: ")
            If vNombre.Length > 0 Then
                Dim vNNode As New TreeNode
                vNNode.Text = vNombre
                GrupoPatente.nombrePatente = vNombre
                vNNode.Tag = GrupoPatente
                vSNode.Nodes.Add(vNNode)
                vPadre.Patentes.Add(GrupoPatente)
                GrupoPatente.padre = vPadre.id
                GrupoPatente.Alta()
                treePatentes.Nodes.Clear()
                Patentes_Load(Nothing, Nothing)
                treePatentes.ExpandAll()
            End If
        End If
    End Sub
End Class