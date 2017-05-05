Imports BLL
Imports BE
Public Class Familia

    Dim family As New BLL.Familia

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ' Me.family.PatenteAbstracta = modelo.GetInstance().PatenteRaiz.Clone()
        Me.family.PatenteAbstracta.MostrarEnTreeView(Me.treePatentes)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim gp = New BLL.GrupoPatente

        PatentesSeleccionas(treePatentes.Nodes, gp.Patentes)

        family.nombreFamilia = Me.txtNombre.Text
        modelo.GetInstance.Familias.Add(family)
        Me.Close()
    End Sub

    Public Sub PatentesSeleccionas(Node As TreeNodeCollection, ByRef list As IList(Of BLL.PatenteAbstracta))

        For Each n As System.Windows.Forms.TreeNode In Node
            PatentesSeleccionas(n.Nodes, list)

            If n.Checked Then
                list.Add(CType(n.Tag, BLL.PatenteAbstracta))
            End If
        Next
    End Sub


    Private Sub treePatentes_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles treePatentes.AfterCheck
        e.Node.Tag.Seleccionada = e.Node.Checked
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class