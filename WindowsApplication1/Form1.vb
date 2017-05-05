Imports BLL
Public Class Form1

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim mcliente As New cliente
        mcliente.nombreyapellido = TextBox1.Text
        mcliente.edad = TextBox2.Text
        mcliente.dni = TextBox3.Text
        mcliente.mail = TextBox4.Text
        mcliente.telefono = TextBox5.Text
        mcliente.direccion = TextBox6.Text
        mcliente.localidad = TextBox7.Text

        mcliente.Guardarnuevo()

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click
        With DataGridView1
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub
End Class
