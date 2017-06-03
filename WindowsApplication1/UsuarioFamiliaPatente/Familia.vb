Imports BLL
Imports BE
Public Class Familia

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs)
        Dim mfamilia As New BLL.Familia
        Dim mListaPermisos As New List(Of BLL.PatenteAbstracta)

        mfamilia.nombreFamilia = txtNombre.Text
        GetPermisosSeleccionados(treePatentes.Nodes, mListaPermisos)
        mfamilia.mlistaPatentes = mListaPermisos
        mfamilia.Alta()

        Me.Close()
    End Sub


    Public Sub GetPermisosSeleccionados(pNodos As TreeNodeCollection, pListaPermisos As List(Of BLL.PatenteAbstracta))
        For Each mNode As TreeNode In pNodos
            If mNode.Checked Then
                pListaPermisos.Add(CType(mNode.Tag, bll.patenteabstracta))
            End If

            GetPermisosSeleccionados(mNode.Nodes, pListaPermisos)
        Next
    End Sub


    Private Sub treePatentes_AfterCheck(sender As Object, e As TreeViewEventArgs)
        e.Node.Tag.Seleccionada = e.Node.Checked
    End Sub



    Private Sub btnCancelar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub


    Private Sub FormRoles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mPermisoRaiz As New BLL.GrupoPatente(0)
        mPermisoRaiz.MostrarEnTreeview(Me.treePatentes)
    End Sub
    
    Private Sub lblNombreFamilia_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged

    End Sub
End Class