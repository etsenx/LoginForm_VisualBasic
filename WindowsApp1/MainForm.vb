Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsUserLoggedIn() Then
            Dim loginForm As New LoginForm()
            loginForm.ShowDialog()
            If Not IsUserLoggedIn() Then
                Me.Close()
            End If
        End If
    End Sub

    Private Function IsUserLoggedIn() As Boolean
        ' Check if the user is logged in (using user-scoped setting)
        Return My.Settings.IsLoggedIn
    End Function

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If IsUserLoggedIn() Then
            ' Display a confirmation message box
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            ' Check the user's response
            If result = DialogResult.Yes Then
                ' User confirmed, log out if necessary
                LogoutUser()
            Else
                ' User canceled, prevent the form from closing
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub LogoutUser()
        ' Reset the login status to indicate that the user is logged out
        My.Settings.IsLoggedIn = False
        My.Settings.Save()
    End Sub
End Class
