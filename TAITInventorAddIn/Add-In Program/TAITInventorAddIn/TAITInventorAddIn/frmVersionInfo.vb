Public Class frmVersionInfo
    Private Sub frmVersionInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "The current version running is: Version " & Reflection.Assembly.GetExecutingAssembly.GetName.Version.Major & "." &
        Reflection.Assembly.GetExecutingAssembly.GetName.Version.Minor & "." &
            Reflection.Assembly.GetExecutingAssembly.GetName.Version.Build & "." &
            Reflection.Assembly.GetExecutingAssembly.GetName.Version.Revision
    End Sub
End Class