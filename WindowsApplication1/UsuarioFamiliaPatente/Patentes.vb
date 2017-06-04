Imports BLL
Public Class Patentes
    'Property GrupoPatente As New GrupoPatente

    Private Sub Patentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim mlistarpatente As New BLL.Patente
        'Dim mlistapatentes As New List(Of PatenteAbstracta)
        'mlistapatentes = mlistarpatente.listar
        'Dim mlistagrupopatente As New BLL.GrupoPatente
        'mlistapatentes.AddRange(mlistagrupopatente.listar)


        'For Each mgrupopatente As BLL.GrupoPatente In mlistagrupopatente.listar
        '    mgrupopatente.MostrarEnTreeView(treePatentes)

        'Next

        Dim mPermisoRaiz As New GrupoPatente(0)
        mPermisoRaiz.MostrarEnTreeview(treePatentes)
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As EventArgs) Handles IngresarPatenteToolStripMenuItem.Click

        Dim mSelectedNode As TreeNode = Me.treePatentes.SelectedNode

        If TypeOf mSelectedNode.Tag Is BLL.GrupoPatente Then

            Dim mPadre As BLL.GrupoPatente = mSelectedNode.Tag

            Dim mForm As New DialogoPatentes
            mForm.ShowDialog()

            Dim mNombrePermiso As String = mForm.Nombre
            Dim mNombreFormulario As String = mForm.Formulario

            If (mNombrePermiso.Length > 0) And (mNombreFormulario.Length > 0) Then

                Dim mPermiso As New BLL.Patente
                Dim mNodoNuevo As New TreeNode

                mNodoNuevo.Text = mNombrePermiso

                mPermiso.nombrePatente = mNombrePermiso
                mPermiso.formulario = mNombreFormulario
                mPermiso.padre = mPadre.id

                mPermiso.Alta()

                mNodoNuevo.Tag = mPermiso

                mSelectedNode.Nodes.Add(mNodoNuevo)
                mPadre.Patentes.Add(mPermiso)
            End If
        End If

    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub



    Private Sub IngresarGrupoPatenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresarGrupoPatenteToolStripMenuItem.Click
        Dim mSelectedNode As TreeNode = treePatentes.SelectedNode

        If TypeOf mSelectedNode.Tag Is BLL.GrupoPatente Then
            Dim mPadre As BLL.GrupoPatente = mSelectedNode.Tag
            Dim mNombrePermiso As String = InputBox("Ingrese el nombre de la patente: ")

            If mNombrePermiso.Length > 0 Then
                Dim mgrupopatente As New BLL.GrupoPatente
                mgrupopatente.nombrePatente = mNombrePermiso
                mgrupopatente.padre = mPadre.id

                Dim mNodoNuevo As New TreeNode
                mNodoNuevo.Text = mgrupopatente.nombrePatente
                mNodoNuevo.Tag = mgrupopatente

                mSelectedNode.Nodes.Add(mNodoNuevo)
                mPadre.Patentes.Add(mgrupopatente)

                mgrupopatente.Alta()
                treePatentes.Nodes.Clear()

                Patentes_Load(Nothing, Nothing)
                treePatentes.ExpandAll()
            End If
        End If
    End Sub

    Private Sub treePatentes_AfterSelect(sender As Object, e As TreeViewEventArgs)

    End Sub

    Private Sub btnAceptar_Click_1(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If TypeOf (treePatentes.SelectedNode.Tag) Is BLL.Patente Then
            Dim mFormulario As New DialogoPatentes(treePatentes.SelectedNode.Tag)
            mFormulario.ShowDialog()
        ElseIf TypeOf (treePatentes.SelectedNode.Tag) Is BLL.GrupoPatente Then
            Dim mPermiso As BLL.GrupoPatente = treePatentes.SelectedNode.Tag

            mPermiso.nombrePatente = InputBox("Ingrese el nuevo nombre para el grupo patente:")

            mPermiso.Alta()

            treePatentes.SelectedNode.Tag = mPermiso
            treePatentes.Nodes.Clear()
            Patentes_Load(Nothing, Nothing)
        End If
    End Sub

    Private Sub IngresarPatenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresarPatenteToolStripMenuItem.Click

    End Sub
End Class