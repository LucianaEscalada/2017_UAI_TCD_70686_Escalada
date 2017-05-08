Imports System.Data.SqlClient
Public Class BD

    Private Shared mConnectionStr As String = "Data Source=LUCHI-PC\sqlexpress;Initial Catalog= sosbelleza;Integrated Security=True"
    'Private Shared mConnectionStr As String = "Data Source=PABLO-PC\SQLEXPRESS;Initial Catalog=sosbelleza;Integrated Security=True"

    Private Shared mConnection As SqlConnection

    Public Shared Function ExecuteDataSet(pCommandStr As String) As DataSet
        Try
            mConnection = New SqlConnection(mConnectionStr)
            Dim mDataSet As New DataSet
            Dim mDataAdapter As New SqlDataAdapter(pCommandStr, mConnection)

            mConnection.Open()
            mDataAdapter.Fill(mDataSet)

            Return mDataSet
        Catch ex As Exception
            MsgBox("Error - DataSet - BD")
            MsgBox(ex.Message)
            Return Nothing
        Finally
            mConnection.Close()
            mConnection.Dispose()
        End Try
    End Function


    Public Shared Function ExecuteNonQuery(pCommandStr As String) As Integer
        Try
            mConnection = New SqlConnection(mConnectionStr)
            Dim mCommand As New SqlCommand(pCommandStr, mConnection)

            mConnection.Open()
            Return mCommand.ExecuteNonQuery
        Catch ex As Exception
            MsgBox("Error - NonQuery - BD")
            MsgBox(ex.Message)
            Return Nothing
        Finally
            mConnection.Close()
            mConnection.Dispose()
        End Try
    End Function


    Public Shared Function ExecuteReader(pCommandStr As String) As SqlDataReader
        Dim mReader As SqlDataReader

        Try
            mConnection = New SqlConnection(mConnectionStr)
            Dim mCommand As New SqlCommand(pCommandStr, mConnection)

            mConnection.Open()
            mReader = mCommand.ExecuteReader

            Return mReader
        Catch ex As Exception
            MsgBox("Error - Reader - BD")
            MsgBox(ex.Message)
            Return Nothing
        Finally
            mReader.Close()
            mConnection.Close()
            mConnection.Dispose()
        End Try
    End Function


    Public Shared Function ExecuteScalar(pCommandStr As String) As Integer
        Try
            mConnection = New SqlConnection(mConnectionStr)
            Dim mCommand As New SqlCommand(pCommandStr, mConnection)

            mConnection.Open()
            Return mCommand.ExecuteScalar
        Catch ex As Exception
            MsgBox("Error - Scalar - BD")
            MsgBox(ex.Message)
            Return Nothing
        Finally
            mConnection.Close()
            mConnection.Dispose()
        End Try
    End Function

    Public Shared Function UltimoID(pTabla As String) As Integer
        Dim mID As Integer

        Try
            mConnection = New SqlConnection(mConnectionStr)
            Dim mCommand As New SqlCommand("SELECT ISNULL(MAX(" & pTabla.ToLower & "_id), 0) FROM " & pTabla, mConnection)

            mConnection.Open()
            mID = mCommand.ExecuteScalar

            Return mID
        Catch ex As Exception
            MsgBox("Error - UltimoID - BD")
            MsgBox(ex.Message)
            Return Nothing
        Finally
            mConnection.Close()
            mConnection.Dispose()
        End Try
    End Function


End Class
