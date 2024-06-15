Imports System.Data.SqlClient

Public Class DatabaseConnection
    Private Shared _instance As DatabaseConnection
    Private _connection As SqlConnection

    Private Sub New()
        Dim connectionString As String = "Data Source=localhost;Initial Catalog=LoginForm;Integrated Security=True;"
        _connection = New SqlConnection(connectionString)
    End Sub

    Public Shared Function GetInstance() As DatabaseConnection
        If _instance Is Nothing Then
            _instance = New DatabaseConnection()
        End If
        Return _instance
    End Function

    Public Function GetConnection() As SqlConnection
        Return _connection
    End Function

    Public Sub OpenConnection()
        If _connection.State = ConnectionState.Closed Then
            _connection.Open()
        End If
    End Sub

    Public Sub CloseConnection()
        If _connection.State = ConnectionState.Open Then
            _connection.Close()
        End If
    End Sub
End Class
