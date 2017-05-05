Imports BLL
Public Class Patentes

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        '

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        BLL.modelo.GetInstance().PatenteRaiz.MostrarEnTreeview(Me.treePatentes.Nodes)
    End Sub




    Private Sub Patentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked
        Dim nodo As TreeNode = Me.treePatentes.SelectedNode

        If TypeOf nodo.Tag Is GrupoPatente Then

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
                mpatente.Alta()
                nodo.Nodes.Add(nodoNuevo)
                padre.Patentes.Add(patente)
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub
End Class