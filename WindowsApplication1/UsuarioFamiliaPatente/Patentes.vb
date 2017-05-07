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

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

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
                mPermiso.Formulario = mNombreFormulario
                mPermiso.Padre = mPadre.id

                mPermiso.Alta()

                mNodoNuevo.Tag = mPermiso

                mSelectedNode.Nodes.Add(mNodoNuevo)
                mPadre.Patentes.Add(mPermiso)
            End If
        End If

    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub



    Private Sub IngresarGrupoPatenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresarGrupoPatenteToolStripMenuItem.Click
        Dim mSelectedNode As TreeNode = treePatentes.SelectedNode

        If TypeOf mSelectedNode.Tag Is BLL.GrupoPatente Then
            Dim mPadre As BLL.GrupoPatente = mSelectedNode.Tag
            Dim mNombrePermiso As String = InputBox("Ingrese el nombre del Permiso: ")

            If mNombrePermiso.Length > 0 Then
                Dim mgrupopatente As New BLL.GrupoPatente
                mgrupopatente.nombrePatente = mNombrePermiso
                mgrupopatente.padre = mPadre.id

                Dim mNodoNuevo As New TreeNode
                mNodoNuevo.Text = mNombrePermiso
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
End Class