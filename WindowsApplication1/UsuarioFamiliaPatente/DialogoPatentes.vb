Imports System.Reflection
Imports BLL
Public Class DialogoPatentes



    Public Sub New(Optional ppatente As BLL.PatenteAbstracta = Nothing)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim Asm As Assembly = Reflection.Assembly.GetExecutingAssembly()

        For Each t As Type In Asm.GetTypes()
            If t.IsSubclassOf(GetType(Form)) Then
                Me.cmbFormularios.Items.Add(t.FullName)
                If Not IsNothing(ppatente) Then
                    If t.FullName = ppatente.formulario Then
                        cmbFormularios.SelectedItem = t.FullName
                    End If
                End If
            End If

        Next
        If Not IsNothing(ppatente) Then
            txtNombre.Text = ppatente.nombrePatente
        End If
    End Sub

    Public Function Nombre() As String
        Return Me.txtNombre.Text
    End Function

    Public Function Formulario() As String
        Return Me.cmbFormularios.Text
    End Function

    Private Sub DialogoPatentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'No conecta con la base de datos
        'Dim mpatente As New BLL.Patente
        '  mpatente.nombrePatente = Me.Nombre
        '
        ' mpatente.Alta()
        Me.Close()
    End Sub
End Class