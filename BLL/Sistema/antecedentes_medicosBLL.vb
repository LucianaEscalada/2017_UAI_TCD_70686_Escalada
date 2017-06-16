Imports DAL
Imports BE

Public Class antecedentes_medicosBLL

#Region "propiedades"
    Public Property id_antecedente As Integer
    Public Property id_cliente As Integer
    Public Property enfermedadesodolencias As String
    Public Property medicamentosquetoma As String
    Public Property alergiasaproductos As String
    Public Property antecedentescosmeticosfamiliarias As String
    Public Property antecedenteshormonales As String
    Public Property antecedentescardiacos As String
    Public Property antecedentesasmaticos As String
    Public Property ciclomenstrual As String
    Public Property presionarterial As String
    Public Property protesisdental As String
    Public Property posibilidadesembarazo As String
    Public Property constipacion As String
    Public Property antecedentesdermatologicos

#End Region

#Region "Constructores"

    Sub New()

    End Sub

    Sub New(pId As Integer)
        CargarPropiedades(pId)

    End Sub

#End Region

#Region "Metodos"

    Private Sub CargarPropiedades(pId As Integer)
        Dim mBE As AntecedentesmedicosBE = antecedentesmedicosDAL.Obtenerantecedentesmedicos(pId)

        Me.id_antecedente = mBE.id_antecedente
        Me.id_cliente = mBE.id_cliente
        Me.enfermedadesodolencias = mBE.enfermedadesodolencias
        Me.medicamentosquetoma = mBE.medicamentosquetoma
        Me.alergiasaproductos = mBE.alergiasaproductos
        Me.antecedentescosmeticosfamiliarias = mBE.antecedentescosmeticosfamiliarias
        Me.antecedenteshormonales = mBE.antecedenteshormonales
        Me.antecedentescardiacos = mBE.antecedentescardiacos
        Me.antecedentesasmaticos = mBE.antecedentesasmaticos
        Me.ciclomenstrual = mBE.ciclomenstrual
        Me.presionarterial = mBE.presionarterial
        Me.protesisdental = mBE.protesisdental
        Me.posibilidadesembarazo = mBE.posibilidadesembarazo
        Me.constipacion = mBE.constipacion
        Me.antecedentesdermatologicos = mBE.antecedentesdermatologicos



    End Sub


    Private Sub CargarDTO(mBE As AntecedentesmedicosBE)
        mBE.id_antecedente = Me.id_antecedente
        mBE.id_cliente = Me.id_cliente
        mBE.enfermedadesodolencias = Me.enfermedadesodolencias
        mBE.medicamentosquetoma = Me.medicamentosquetoma
        mBE.alergiasaproductos = Me.alergiasaproductos
        mBE.antecedentescosmeticosfamiliarias = Me.antecedentescosmeticosfamiliarias
        mBE.antecedenteshormonales = Me.antecedenteshormonales
        mBE.antecedentescardiacos = Me.antecedentescardiacos
        mBE.antecedentesasmaticos = Me.antecedentesasmaticos
        mBE.ciclomenstrual = Me.ciclomenstrual
        mBE.presionarterial = Me.presionarterial
        mBE.protesisdental = Me.protesisdental
        mBE.posibilidadesembarazo = Me.posibilidadesembarazo
        mBE.constipacion = Me.constipacion
        mBE.antecedentesdermatologicos = Me.antecedentesdermatologicos



    End Sub


    Public Sub Guardarnuevo()
        Dim mBE As New antecedentesmedicosBE

        CargarDTO(mBE)
        antecedentesMedicosDAL.GuardarNuevo(mBE)

    End Sub


    Public Sub guardarmodificacion()
        Dim mBE As New antecedentesmedicosBE
        CargarDTO(mBE)
        antecedentesMedicosDAL.GuardarModificacion(mBE)

    End Sub


    Public Sub Eliminar()
        Dim mBE As New antecedentesmedicosBE

        CargarDTO(mBE)

        antecedentesMedicosDAL.Eliminar(mBE)
    End Sub


    Public Shared Function Listarantecedentesmedicos() As List(Of antecedentes_medicosBLL)
        Dim mLista As New List(Of antecedentes_medicosBLL)
        Dim mListaDTO As List(Of AntecedentesmedicosBE) = antecedentesmedicosDAL.Listarantecedentesmedicos

        For Each mBE As AntecedentesmedicosBE In mListaDTO
            Dim mantecedentesmedicosBE As New antecedentes_medicosBLL(mBE.id_antecedente)

            mLista.Add(mantecedentesmedicosBE)
        Next

        Return mLista
    End Function

#End Region
End Class
