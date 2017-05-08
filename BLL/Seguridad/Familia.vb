Imports System.Windows.Forms
Imports DAL
Public Class Familia

    Public Property id_familia As Integer
    Public Property nombreFamilia As String




    Private Sub cargarBE(pfamilia As BE.Familia)

        If Not IsNothing(pfamilia) Then
            pfamilia.familia_id = Me.id_familia
            pfamilia.nombre = Me.nombreFamilia

            If Me.mlistaPatentes.Count > 0 Then
                For Each mPatenteBll As BLL.PatenteAbstracta In Me.mlistaPatentes
                    Dim mPatente As BE.PatenteAbstracta

                    If TypeOf (mPatenteBll) Is BLL.GrupoPatente Then
                        mPatente = New BE.GrupoPatente
                        CType(mPatenteBll, BLL.GrupoPatente).cargarBE(mPatente)
                    Else
                        mPatente = New BE.patente
                        CType(mPatenteBll, BLL.Patente).cargarBE(mPatente)
                    End If

                    pfamilia.listapatentes.Add(mPatente)
                Next
            End If
        End If


    End Sub

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

        If mBE.listapatentes.Count > 0 Then
            For Each mPermiso As BE.PatenteAbstracta In mBE.listapatentes
                If TypeOf (mPermiso) Is BE.patente Then
                    familiaPatente.GuardarNuevo(mBE.familia_id, mPermiso.id)
                Else
                    familiaGrupoPatente.GuardarNuevo(mBE.familia_id, mPermiso.id)
                End If
            Next
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
