Imports BLL

Public Class Usuarios


    Dim musuarioseleccionado As UsuarioBLL
    Dim mfamiliaseleccionada As BLL.Familia

    Private Sub FormularioUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox2.DataSource = BLL.UsuarioBLL.ListarUsuarios
        ComboBox1.DataSource = BLL.Familia.listar



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub



    'Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedValueChanged
    '    If Not IsNothing(ComboBox2.SelectedValue) Then
    '        If TypeOf ComboBox2.SelectedValue Is BLL.Familia Then
    '            musuarioseleccionado = ComboBox1.SelectedValue
    '        End If
    '    End If
    'End Sub


    'Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
    '    If Not IsNothing(ComboBox1.SelectedValue) Then
    '        If TypeOf ComboBox1.SelectedValue Is BLL.Familia Then
    '            mfamiliaseleccionada = ComboBox1.SelectedValue
    '        End If
    '    End If
    'End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        musuarioseleccionado = ComboBox2.SelectedItem
        mfamiliaseleccionada = ComboBox1.SelectedItem

        musuarioseleccionado.rol = mfamiliaseleccionada.id_familia

        musuarioseleccionado.Guardar()
        MsgBox("Familia Asignada correctamente")
    End Sub
End Class