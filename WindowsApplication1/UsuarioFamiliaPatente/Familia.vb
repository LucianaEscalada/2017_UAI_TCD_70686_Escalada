Imports BLL
Imports BE
Public Class Familia

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim mfamilia As New BLL.Familia
        Dim mListaPermisos As New List(Of bll.patenteabstracta)

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


    Private Sub treePatentes_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles treePatentes.AfterCheck
        e.Node.Tag.Seleccionada = e.Node.Checked
    End Sub



    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


    Private Sub FormRoles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mPermisoRaiz As New BLL.GrupoPatente(0)
        mPermisoRaiz.MostrarEnTreeview(Me.treePatentes)
    End Sub
    
End Class