Public Class modelo


    ''Esta clase se carga con todas las familias y todos los usuarios que tiene la clase (los guarda dentro de un grupo patente)

    Private Shared _instance As modelo
    Public Shared Function GetInstance() As modelo

        If _instance Is Nothing Then
            _instance = New Modelo
        End If

        Return _instance
    End Function

    Private _familias As New List(Of Familia)
    Public Property Familias() As List(Of Familia)
        Get
            Return _familias
        End Get
        Set(ByVal value As List(Of Familia))
            _familias = value
        End Set
    End Property

    Private _usuarioblls As New List(Of UsuarioBLL)
    Public Property usuarioblls() As List(Of UsuarioBLL)
        Get
            Return _usuarioblls
        End Get
        Set(ByVal value As List(Of UsuarioBLL))
            _usuarioblls = value
        End Set
    End Property


    Private _patenteRaiz As PatenteAbstracta
    Public Property PatenteRaiz() As PatenteAbstracta
        Get
            Return _patenteRaiz
        End Get
        Set(ByVal value As PatenteAbstracta)
            _patenteRaiz = value
        End Set
    End Property

    Public Sub New()
        Dim raiz As New GrupoPatente()
        raiz.nombrePatente = "Patentes Sistema"
        Me._patenteRaiz = raiz
    End Sub

End Class
