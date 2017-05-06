Imports System.Windows.Forms
Public MustInherit Class PatenteAbstracta

    Public Property id As Integer
    Public Property nombrePatente
    Public Property formulario As String
    Public Property padre As Integer

    Private _seleccionada As Boolean
    Public Property Seleccionada() As Boolean
        Get
            Return _seleccionada
        End Get
        Set(ByVal value As Boolean)
            _seleccionada = value
        End Set
    End Property



    Public MustOverride Function MostrarEnTreeView(pTreeView As Windows.Forms.TreeView) As Windows.Forms.TreeView
    Public MustOverride Sub Alta()
    Public MustOverride Sub baja()
    'Public MustOverride Function Clone() As PatenteAbstracta


End Class
