Public Class producto


    Dim mproductoSelec As BLL.productoBLL

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If Not IsNothing(mproductoSelec) Then
            mproductoSelec.Eliminar()

            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = BLL.productoBLL.Listarproducto
        End If
    End Sub


    Private Sub datagridview1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.CurrentRow.Index > -1 And DataGridView1.SelectedRows.Count > 0 Then
            If Not IsNothing(DataGridView1.SelectedRows(0).DataBoundItem) Then
                If TypeOf (DataGridView1.SelectedRows(0).DataBoundItem) Is BLL.productoBLL Then
                    mproductoSelec = DataGridView1.SelectedRows(0).DataBoundItem
                End If
            End If
        End If
    End Sub


    Private Sub producto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With DataGridView1
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DataSource = BLL.productoBLL.Listarproducto
        End With
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim mproducto As New BLL.productoBLL
        mproducto.nombreproducto = TextBox26.Text
        mproducto.precio_compra = TextBox1.Text
        mproducto.precio_venta = TextBox2.Text
        mproducto.cantidad = TextBox3.Text
        mproducto.Guardarnuevo()
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = BLL.productoBLL.Listarproducto
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox26.Clear()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        If Not IsNothing(mproductoSelec) Then
            mproductoSelec.nombreproducto = TextBox26.Text
            mproductoSelec.precio_compra = TextBox1.Text
            mproductoSelec.precio_venta = TextBox2.Text
            mproductoSelec.guardarmodificacion()
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = BLL.productoBLL.Listarproducto
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox26.Clear()
        End If

    End Sub
End Class