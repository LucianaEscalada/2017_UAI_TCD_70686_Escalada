Imports BLL


Public Class Tratamientos

    Private Sub Tratamientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With DataGridView1
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DataSource = BLL.tratamientoBLL.Listartratamiento
        End With
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim mtratamiento As New BLL.tratamientoBLL
        mtratamiento.nombretratamiento = TextBox26.Text
        mtratamiento.precio = TextBox1.Text
        mtratamiento.Guardarnuevo()
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = BLL.productoBLL.Listarproducto
        TextBox1.Clear()
        TextBox26.Clear()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim mtratamiento As tratamientoBLL
        mtratamiento.nombretratamiento = TextBox26.Text
        mtratamiento.precio = TextBox1.Text

        mtratamiento.guardarmodificacion()
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = BLL.tratamientoBLL.Listartratamiento
        TextBox1.Clear()
        TextBox26.Clear()

    End Sub
End Class