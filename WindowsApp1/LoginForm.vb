Imports System.Data.SqlClient

Public Class LoginForm
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.UseSystemPasswordChar = True
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Perform login validation (e.g., check username and password)
        If ValidateLogin(txtUsername.Text, txtPassword.Text) Then
            My.Settings.IsLoggedIn = True
            My.Settings.Save()
            Me.Close()
        Else
            MessageBox.Show("Invalid username or password. Please try again.")
        End If
    End Sub

    Private Function ValidateLogin(username As String, password As String) As Boolean
        ' Perform actual validation (e.g., check against a database)
        Dim dbConnection As DatabaseConnection = DatabaseConnection.GetInstance()
        dbConnection.OpenConnection()
        Dim connection As SqlConnection = dbConnection.GetConnection()

        Dim query As String = "SELECT COUNT(*) FROM users WHERE Username = @username AND Password = @password"
        Using cmd As New SqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@password", password)
            Dim result As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return result > 0
        End Using
        dbConnection.CloseConnection()
    End Function

End Class