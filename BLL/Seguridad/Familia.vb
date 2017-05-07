Imports System.Windows.Forms
Imports DAL
Public Class Familia

    Public Property id_familia As Integer
    Public Property nombreFamilia As String




    Private Sub cargarBE(pfamilia As BE.Familia)

        If Not IsNothing(pfamilia) Then
            Me.id_familia = pfamilia.familia_id
            Me.nombreFamilia = pfamilia.nombre

            If pfamilia.listapatentes.Count > 0 Then
                For Each mPatenteBE As BE.PatenteAbstracta In pfamilia.listapatentes
                    Dim mPatente As BLL.PatenteAbstracta

                    If TypeOf (mPatenteBE) Is BE.GrupoPatente Then
                        mPatente = New BLL.GrupoPatente(mPatenteBE)
                    Else
                        mPatente = New BLL.Patente(mPatenteBE)
                    End If

                    Me.mlistaPatentes.Add(mPatente)
                Next
            End If
        End If
  

    End Sub

    Private _familia As New List(Of BLL.PatenteAbstracta)
    Public Property familias() As List(Of BLL.PatenteAbstracta)
        Get
            Return _familia
        End Get
        Set(ByVal value As List(Of BLL.PatenteAbstracta))
            _familia = value
        End Set
    End Property
    Public mlistaPatentes As New List(Of BLL.PatenteAbstracta)

    Private _patenteRaiz As PatenteAbstracta

    Public Property PatenteAbstracta() As PatenteAbstracta
        Get
            Return _patenteRaiz
        End Get
        Set(ByVal value As PatenteAbstracta)
            _patenteRaiz = value
        End Set
    End Property

    Public Sub MostrarEnTreeview(ByRef padres As TreeNodeCollection)
       
        ' For Each Familia As BLL.PatenteAbstracta In _familia
        'Patente.MostrarEnTreeview(node.Nodes)
        ' Next

    End Sub
    Public Sub Alta()
        Dim mBE As New BE.Familia
        If Me.id_familia = 0 Then

            Me.id_familia = FamiliaDAL.proximoID
            cargarBE(mBE)
            FamiliaDAL.GuardarNuevo(mBE)
        Else
            cargarBE(mBE)
            FamiliaDAL.GuardarModificacion(mBE)
        End If
    End Sub

    Public Sub baja()
        Dim mbe As New BE.Familia
        cargarBE(mbe)
        FamiliaDAL.Eliminar(mbe)
    End Sub

    Public Overrides Function ToString() As String
        Return Me.nombreFamilia()
    End Function

End Class
