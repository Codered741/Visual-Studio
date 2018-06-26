Imports System.IO
Imports System.Text

Module Module1

    Sub Main()
        'The install/update program copies all necessary files from the compile location to the following target C:\ folder location:
        'C:\Users\[USER NAME]\AppData\Roaming\Autodesk\ApplicationPlugins\TAIT_PI_INV_ADDIN\
        'Inventor Reads the .ADDIN file in order to interpret how to load the Add-In and which files to use for Add-In procedures.
        Dim d As Integer
        Dim di As DirectoryInfo = New DirectoryInfo("C:\Users")
        d = di.GetDirectories.Count

        Dim names(d) As String
        Dim n As Integer = 0
        Console.WriteLine("C:\Users directories:" & vbCrLf)
        For Each fi In di.GetDirectories()
            Console.WriteLine(n + 1 & ".) " & fi.Name)
            names(n) = fi.Name
            n = n + 1
        Next
        Console.WriteLine(vbCrLf)

        Console.WriteLine("Please tell the install/update program who you are. Enter the number corresponding to your username.")
        Dim u = Console.ReadLine()
        Dim username As Integer = u
        Dim userprofile As String = names(username - 1)
        Console.WriteLine("Going to install/update the TAIT PI Inventor Add-in files to the " & userprofile & " user profile." & vbCrLf)
        Console.WriteLine("Press any key to continue.")
        Console.Read()

        Dim source1 As String = "Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\Add-In Program\TAITInventorAddIn\TAITInventorAddIn\Autodesk.TAITInventorAddIn.Inventor.addin"
        Dim target1 As String = "C:\Users\" & userprofile & "\AppData\Roaming\Autodesk\ApplicationPlugins\TAITInventorAddIn\Autodesk.TAITInventorAddIn.Inventor.addin"
        Dim source2 As String = "Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\Add-In Program\TAITInventorAddIn\TAITInventorAddIn\bin\Debug\TAITInventorAddIn.dll"
        Dim target2 As String = "C:\Users\" & userprofile & "\AppData\Roaming\Autodesk\ApplicationPlugins\TAITInventorAddIn\TAITInventorAddIn.dll"
        Dim OGdate As Date
        Dim NEWdate As Date

        Try
            Console.WriteLine("Looking for the .addin text file...")
            If My.Computer.FileSystem.FileExists(target1) Then
                Console.WriteLine("Found the .addin text file! Checking for update.")
                OGdate = My.Computer.FileSystem.GetFileInfo(target1).LastWriteTime
                NEWdate = My.Computer.FileSystem.GetFileInfo(source1).LastWriteTime
                'MsgBox("OGdate: " & OGdate & vbNewLine &
                '       "NEWdate: " & NEWdate)
                If NEWdate > OGdate Then
                    Console.WriteLine("Update required. Attempting to update the .addin text file...")
                    My.Computer.FileSystem.CopyFile(source1, target1, True)
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.WriteLine("SUCCESSFUL UPDATE")
                    Console.ResetColor()
                Else
                    Console.ForegroundColor = ConsoleColor.Yellow
                    Console.WriteLine("ALREADY CURRENT VERSION")
                    Console.ResetColor()
                End If
            Else
                Console.WriteLine("Did not find the .addin text file! Attempting to install the .addin text file...")
                My.Computer.FileSystem.CopyFile(source1, target1, True)
                Console.ForegroundColor = ConsoleColor.Green
                Console.WriteLine("SUCCESSFUL INSTALL")
                Console.ResetColor()
            End If

        Catch ex As Exception
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine("FAILED TO INSTALL/UPDATE")
            Console.ResetColor()
        End Try

        Try
            Console.WriteLine("Looking for the TAITInventorAddIn.dll file...")
            If My.Computer.FileSystem.FileExists(target2) Then
                Console.WriteLine("Found the TAITInventorAddIn.dll file! Checking for update.")
                OGdate = My.Computer.FileSystem.GetFileInfo(target2).LastWriteTime
                NEWdate = My.Computer.FileSystem.GetFileInfo(source2).LastWriteTime
                'MsgBox("OGdate: " & OGdate & vbNewLine &
                '      "NEWdate: " & NEWdate)
                If NEWdate > OGdate Then
                    Console.WriteLine("Update required. Attempting to update the TAITInventorAddIn.dll file...")
                    My.Computer.FileSystem.CopyFile(source2, target2, True)
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.WriteLine("SUCCESSFUL UPDATE")
                    Console.ResetColor()
                Else
                    Console.ForegroundColor = ConsoleColor.Yellow
                    Console.WriteLine("ALREADY CURRENT VERSION")
                    Console.ResetColor()
                End If
            Else
                Console.WriteLine("Did not find the TAITInventorAddIn.dll file! Attempting to install the TAITInventorAddIn.dll text file...")
                My.Computer.FileSystem.CopyFile(source2, target2, True)
                Console.ForegroundColor = ConsoleColor.Green
                Console.WriteLine("SUCCESSFUL INSTALL")
                Console.ResetColor()
            End If

        Catch ex As Exception
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine("FAILED TO INSTALL/UPDATE. MAKE SURE INVENTOR APPLICAITON IS CLOSED AND TRY AGAIN")
            Console.ResetColor()
        End Try

        Console.WriteLine("COMPLETE. The install/update has completed." & vbCrLf & "Please close and reopen the Inventor application to confirm the update has been successful." & vbCrLf & "Press any key to exit.")
        Console.ReadLine()
        Console.ReadLine()
    End Sub

End Module
