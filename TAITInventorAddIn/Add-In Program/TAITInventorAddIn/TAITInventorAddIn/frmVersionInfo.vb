Imports System.Drawing

Public Class frmVersionManager
    Dim source1 As String
    Dim target1 As String
    Dim source2 As String
    Dim target2 As String
    Public Sub frmVersionInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''DISPLAY CURRENT VERSION''
        Label1.Text = "The current version running is: Version " & Reflection.Assembly.GetExecutingAssembly.GetName.Version.Major & "." &
        Reflection.Assembly.GetExecutingAssembly.GetName.Version.Minor & "." &
            Reflection.Assembly.GetExecutingAssembly.GetName.Version.Build & "." &
            Reflection.Assembly.GetExecutingAssembly.GetName.Version.Revision

        ''LOAD VERSION LIBRARY LISTBOX''
        Try
            Dim files() As String = IO.Directory.GetFiles("Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\Add-In Program\Version Library")
            lbVersionLibrary.Items.Clear()
            For Each file As String In files
                lbVersionLibrary.Items.Add(file)
            Next
        Catch ex As Exception
            lbVersionLibrary.Items.Clear()
        End Try


        ''CHECK FOR UPDATE''
        source1 = "Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\Add-In Program\TAITInventorAddIn\TAITInventorAddIn\Autodesk.TAITInventorAddIn.Inventor.addin"
        target1 = "C:\Users\" & System.Environment.UserName & "\AppData\Roaming\Autodesk\ApplicationPlugins\TAITInventorAddIn\Autodesk.TAITInventorAddIn.Inventor.addin"
        source2 = "Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\Add-In Program\TAITInventorAddIn\TAITInventorAddIn\bin\Debug\TAITInventorAddIn.dll"
        target2 = "C:\Users\" & System.Environment.UserName & "\AppData\Roaming\Autodesk\ApplicationPlugins\TAITInventorAddIn\TAITInventorAddIn.dll"
        Dim OGdate As Date = My.Computer.FileSystem.GetFileInfo(target2).LastWriteTime
        Dim NEWdate As Date = My.Computer.FileSystem.GetFileInfo(source2).LastWriteTime

        Try
            If My.Computer.FileSystem.FileExists(target1) Then
                If NEWdate > OGdate Then 'update available!
                    'display label and button
                    lblUpdateStatus.Visible = True
                    btnUpdateToLatest.Visible = True
                Else
                    'change label and display
                    lblUpdateStatus.ForeColor = Color.Black
                    lblUpdateStatus.TextAlign = ContentAlignment.MiddleCenter
                    lblUpdateStatus.Text = "No Update Available"
                    lblUpdateStatus.Visible = True
                    btnUpdateToLatest.Visible = False
                End If
            End If
        Catch

        End Try


    End Sub

    Sub btnCloseVersionManager_Click(sender As Object, e As EventArgs) Handles btnCloseVersionManager.Click
        Me.Close()
    End Sub

    Sub btnUpdateToLatest_Click(sender As Object, e As EventArgs) Handles btnUpdateToLatest.Click
        My.Computer.FileSystem.CopyFile(source1, target1, True)

    End Sub
End Class