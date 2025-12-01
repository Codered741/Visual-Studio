Imports Inventor
Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class frmPropConfig
    Dim StdPropSet As PropertySet
    Dim SummaryPropSet As PropertySet
    Dim CustomPropSet As PropertySet
    Public MaterialDescription As String

    Dim tblist_IssueID As New List(Of Windows.Forms.TextBox)
    Dim tblist_IssueDATE As New List(Of Windows.Forms.TextBox)
    Dim tblist_IssuedBY As New List(Of Windows.Forms.TextBox)
    Dim tblist_IssuedFOR As New List(Of Windows.Forms.TextBox)
    Dim tblist_RevID As New List(Of Windows.Forms.TextBox)
    Dim tblist_RevDATE As New List(Of Windows.Forms.TextBox)
    Dim tblist_RevBY As New List(Of Windows.Forms.TextBox)
    Dim tblist_RevDESCRIPTION As New List(Of Windows.Forms.TextBox)
    Dim tblist_RevAPPROVEDBY As New List(Of Windows.Forms.TextBox)



    Public Sub frmPropConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = 320
        Me.Width = 826
        gbIssues.Visible = False
        gbRevisions.Visible = False

        tblist_IssueID.AddRange({Issue_ID1, Issue_ID2, Issue_ID3, Issue_ID4, Issue_ID5, Issue_ID6, Issue_ID7, Issue_ID8})
        tblist_IssueDATE.AddRange({IssuedDate1, IssuedDate2, IssuedDate3, IssuedDate4, IssuedDate5, IssuedDate6, IssuedDate7, IssuedDate8})
        tblist_IssuedBY.AddRange({IssuedBy1, IssuedBy2, IssuedBy3, IssuedBy4, IssuedBy5, IssuedBy6, IssuedBy7, IssuedBy8})
        tblist_IssuedFOR.AddRange({IssuedFor1, IssuedFor2, IssuedFor3, IssuedFor4, IssuedFor5, IssuedFor6, IssuedFor7, IssuedFor8})

        tblist_RevID.AddRange({Rev_ID1, Rev_ID2, Rev_ID3, Rev_ID4, Rev_ID5, Rev_ID6, Rev_ID7, Rev_ID8})
        tblist_RevDATE.AddRange({RevDate1, RevDate2, RevDate3, RevDate4, RevDate5, RevDate6, RevDate7, RevDate8})
        tblist_RevBY.AddRange({RevBy1, RevBy2, RevBy3, RevBy4, RevBy5, RevBy6, RevBy7, RevBy8})
        tblist_RevDESCRIPTION.AddRange({RevDescription1, RevDescription2, RevDescription3, RevDescription4, RevDescription5, RevDescription6, RevDescription7, RevDescription8})
        tblist_RevAPPROVEDBY.AddRange({RevApprovedBy1, RevApprovedBy2, RevApprovedBy3, RevApprovedBy4, RevApprovedBy5, RevApprovedBy6, RevApprovedBy7, RevApprovedBy8})

        ' Connect to a running instance of Inventor. 
        Dim invApp As Inventor.Application
        invApp = System.Runtime.InteropServices.Marshal.GetActiveObject("Inventor.Application")

        ' Get the active document. 
        Dim Doc As Inventor.Document
        Doc = invApp.ActiveDocument

        Try
            StdPropSet = Doc.PropertySets.Item("Design Tracking Properties")                    'Set to access Project & Status property set
        Catch ex As Exception

        End Try
        Try
            SummaryPropSet = Doc.PropertySets.Item("Inventor Summary Information")              'Set to access Summary property set
        Catch ex As Exception

        End Try
        Try
            CustomPropSet = Doc.PropertySets.Item("Inventor User Defined Properties")           'Set to access Custom property set
        Catch ex As Exception

        End Try

        ' Get the existing properties, if they exists.

        Try
            cmbProjects.Text = CustomPropSet.Item("Show").Value.ToString
        Catch ex As Exception
            cmbProjects.Text = ""
        End Try
        Try
            cmbElements.Text = CustomPropSet.Item("Element").Value.ToString
        Catch ex As Exception
            cmbElements.Text = ""
        End Try

        Try
            cmbDesigners.Text = StdPropSet.Item("Designer").Value.ToString
        Catch ex As Exception
            cmbDesigners.Text = ""
        End Try
        Try
            Dim CreatedDate As Date
            CreatedDate = CDate(StdPropSet.Item("Creation Time").Value.ToString)
            dtpDesignedDate.Value = CreatedDate.ToShortDateString
        Catch ex As Exception
            dtpDesignedDate.Value = CDate("1/1/1753").ToShortDateString
        End Try

        Try
            cmbCheckers.Text = StdPropSet.Item("Checked By").Value.ToString
        Catch ex As Exception
            cmbCheckers.Text = ""
        End Try
        Try
            Dim CheckedDate As Date
            CheckedDate = CDate(StdPropSet.Item("Date Checked").Value.ToString)
            dtpCheckedDate.Value = CheckedDate.ToShortDateString
        Catch ex As Exception
            dtpCheckedDate.Value = CDate("1/1/1753").ToShortDateString
        End Try

        Try
            cmbApprovers.Text = StdPropSet.Item("Engr Approved By").Value.ToString
        Catch ex As Exception
            cmbApprovers.Text = ""
        End Try
        Try
            Dim ApprovedDate As Date
            ApprovedDate = CDate(StdPropSet.Item("Engr Date Approved").Value.ToString)
            dtpApprovedDate.Value = ApprovedDate.ToShortDateString
        Catch ex As Exception
            dtpApprovedDate.Value = CDate("1/1/1753").ToShortDateString
        End Try

        Try
            tbProjName.Text = StdPropSet.Item("Project").Value.ToString
        Catch ex As Exception
            tbProjName.Text = ""
        End Try
        Try
            tbProjNo.Text = CustomPropSet.Item("Project Number").Value.ToString
        Catch ex As Exception
            tbProjNo.Text = ""
        End Try
        Try
            tbBuildingNo.Text = CustomPropSet.Item("Building Number").Value.ToString
        Catch ex As Exception
            tbBuildingNo.Text = ""
        End Try

        Try
            tbRevNo.Text = SummaryPropSet.Item("Revision Number").Value.ToString
        Catch ex As Exception
            tbRevNo.Text = ""
        End Try
        Try
            Dim UsedOn As Inventor.Property
            UsedOn = CustomPropSet.Item("UsedOn")
            tbUsedOn.Text = UsedOn.Value.ToString
        Catch ex As Exception
            tbUsedOn.Text = ""
        End Try
        Try
            Dim NextAssy As Inventor.Property
            NextAssy = CustomPropSet.Item("NextAssy")
            tbNextAssy.Text = NextAssy.Value.ToString
        Catch ex As Exception
            tbNextAssy.Text = ""
        End Try
        Try
            tbVendor.Text = StdPropSet.Item("Vendor").Value.ToString
        Catch ex As Exception
            tbVendor.Text = ""
        End Try

        Try
            MaterialDescription = CustomPropSet.Item("Material").Value.ToString
            tbMaterial.Text = MaterialDescription
        Catch ex As Exception
            tbMaterial.Text = ""
        End Try

        'load the issues information. Finds it if it can, otherwise sets the form up to enter info.
        Dim x As Integer
        For x = 0 To 7
            Try
                If CustomPropSet.Item("ISSUED " & x + 1 & " DATE").Value.ToString <> "" Then
                    tblist_IssueDATE.Item(x).Text = CustomPropSet.Item("ISSUED " & x + 1 & " DATE").Value.ToString
                    tblist_IssueDATE.Item(x).Enabled = True
                    tblist_IssuedBY.Item(x).Text = CustomPropSet.Item("ISSUED " & x + 1 & " BY").Value.ToString
                    tblist_IssuedBY.Item(x).Enabled = True
                    tblist_IssuedFOR.Item(x).Text = CustomPropSet.Item("ISSUED " & x + 1 & " FOR").Value.ToString
                    tblist_IssuedFOR.Item(x).Enabled = True
                    tblist_IssueID.Item(x).Text = x + 1
                End If
            Catch ex As Exception
                'MsgBox("HIT CATCH. x = " & x)
                Exit For
            End Try
        Next

        'load the rev information. Finds it if it can, otherwise sets the form up to enter info.
        For x = 0 To 7
            Try
                If CustomPropSet.Item("REV " & x + 1 & " DATE").Value.ToString <> "" Then
                    tblist_RevDATE.Item(x).Text = CustomPropSet.Item("REV " & x + 1 & " DATE").Value.ToString
                    tblist_RevDATE.Item(x).Enabled = True
                    tblist_RevBY.Item(x).Text = CustomPropSet.Item("REV " & x + 1 & " BY").Value.ToString
                    tblist_RevBY.Item(x).Enabled = True
                    tblist_RevDESCRIPTION.Item(x).Text = CustomPropSet.Item("REV " & x + 1 & " DESCRIPTION").Value.ToString
                    tblist_RevDESCRIPTION.Item(x).Enabled = True
                    tblist_RevAPPROVEDBY.Item(x).Text = CustomPropSet.Item("REV " & x + 1 & " APPROVED BY").Value.ToString
                    tblist_RevAPPROVEDBY.Item(x).Enabled = True
                    tblist_RevID.Item(x).Text = x + 1
                End If
            Catch ex As Exception
                'MsgBox("HIT CATCH. x = " & x)
                Exit For
            End Try
        Next

        invApp = Nothing
        Doc = Nothing

        'Validate the existing Project if any was set
        Try
            Call cmbProjects_SelectedIndexChanged(Nothing, Nothing)
        Catch ex As Exception

        End Try

        Dim Projects() As String
        ''Read the Props_Projects.txt file and populate cmbProjects list items
        Try
            Projects = IO.File.ReadAllLines("Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\Props_Projects.txt")

            Dim projectlist As New ArrayList()
            For p As Integer = 0 To Projects.GetUpperBound(0)
                projectlist.Add(Projects(p))
            Next


            Dim XProject As String
            Dim XElement As String
            Dim n As Integer
            For n = 0 To projectlist.Count - 1
                If projectlist.Item(n).ToString.Substring(0, 1) = "*" Then
                    GoTo nOBJ
                End If
                Dim T(1) As String
                T = projectlist.Item(n).ToString.Split("|")
                XProject = T(0)
                XElement = T(1)

                cmbProjects.Items.Add(XProject)
nOBJ:
            Next

        Catch exc As Exception
            ' Report all errors.
            MsgBox("Error loading project list")
        End Try


        Dim Designers() As String
        ''Read the Props_Designers.txt file and populate cmbProjects and cmbCheckers list items
        Try
            Designers = IO.File.ReadAllLines("Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\Props_Designers.txt")

            Dim designerlist As New ArrayList()
            For p As Integer = 0 To Designers.GetUpperBound(0)
                designerlist.Add(Designers(p))
            Next

            Dim XDesigner As String
            Dim n As Integer
            For n = 0 To designerlist.Count - 1
                If designerlist.Item(n).ToString.Substring(0, 1) = "*" Then
                    GoTo nOBJd
                End If
                XDesigner = designerlist.Item(n).ToString
                cmbDesigners.Items.Add(XDesigner)
                cmbCheckers.Items.Add(XDesigner)
nOBJd:
            Next

        Catch exc As Exception
            ' Report all errors.
            MsgBox("Error loading designer list")
        End Try

        Dim Approvers() As String
        ''Read the Props_Designers.txt file and populate cmbProjects and cmbCheckers list items
        Try
            Approvers = IO.File.ReadAllLines("Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\Props_Approvers.txt")

            Dim approverlist As New ArrayList()
            For p As Integer = 0 To Approvers.GetUpperBound(0)
                approverlist.Add(Approvers(p))
            Next

            Dim XApprover As String
            Dim n As Integer
            For n = 0 To approverlist.Count - 1
                If approverlist.Item(n).ToString.Substring(0, 1) = "*" Then
                    GoTo nOBJa
                End If
                XApprover = approverlist.Item(n).ToString
                cmbApprovers.Items.Add(XApprover)
nOBJa:
            Next

        Catch exc As Exception
            ' Report all errors.
            MsgBox("Error loading approver list")
        End Try

    End Sub
    Public Sub cmbProjects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProjects.SelectedIndexChanged
        cmbElements.Items.Clear()
        Dim ProjectChosen As String = cmbProjects.Text
        Dim Elements() As String
        ''Read the Props_Projects.txt file and populate cmbProjects list items
        Try
            Elements = IO.File.ReadAllLines("Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\Props_Projects.txt")

            Dim elementlist As New ArrayList()
            For p As Integer = 0 To Elements.GetUpperBound(0)
                elementlist.Add(Elements(p))
            Next

            Dim X(1) As String
            Dim XProject As String
            Dim XElement As String
            Dim n As Integer
            For n = 0 To elementlist.Count - 1
                If elementlist.Item(n).ToString.Substring(0, 1) = "*" Then
                    GoTo nOBJ
                End If

                X = elementlist.Item(n).ToString.Split("|")
                XProject = X(0)
                If ProjectChosen = XProject Then
                    XElement = X(1)
                    Dim m() As String
                    Dim i As Integer
                    m = XElement.Split(",")
                    For i = 0 To m.Length - 1
                        cmbElements.Items.Add(m(i))
                    Next
                End If
nOBJ:
            Next

        Catch exc As Exception
            ' Report all errors.
            MsgBox("Error loading element list")
        End Try
    End Sub
    Public Sub cmbElements_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbElements.SelectedIndexChanged
        Dim ElementChosen As String = cmbElements.Text
        Dim ElementInfo() As String
        ''Read the Props_Projects.txt file and populate cmbProjects list items
        Try
            ElementInfo = IO.File.ReadAllLines("Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\Props_Elements.txt")

            Dim elementdetailslist As New ArrayList()
            For p As Integer = 0 To ElementInfo.GetUpperBound(0)
                elementdetailslist.Add(ElementInfo(p))
            Next

            Dim X(3) As String
            Dim XElement As String
            Dim XProjectName As String
            Dim XProjectNo As String
            Dim XBuildingNo As String
            Dim n As Integer
            For n = 0 To elementdetailslist.Count - 1
                If elementdetailslist.Item(n).ToString.Substring(0, 1) = "*" Then
                    GoTo nOBJ
                End If
                X = elementdetailslist.Item(n).ToString.Split("|")
                XElement = X(0)

                If ElementChosen = XElement Then
                    XProjectName = X(1)
                    XProjectNo = X(2)
                    XBuildingNo = X(3)
                    tbProjName.Text = XProjectName
                    tbProjNo.Text = XProjectNo
                    tbBuildingNo.Text = XBuildingNo
                End If
nOBJ:
            Next

        Catch exc As Exception
            ' Report all errors.
            MsgBox("Error loading element details")
        End Try
    End Sub
    Public Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        ' Connect to a running instance of Inventor. 
        ' Watch out for the wrapped line. 
        Dim invApp As Inventor.Application
        invApp = System.Runtime.InteropServices.Marshal.GetActiveObject("Inventor.Application")
        Dim n As Integer
        ' Get the active document. 
        Dim Doc As Inventor.Document
        Doc = invApp.ActiveDocument

        Try
            StdPropSet = Doc.PropertySets.Item("Design Tracking Properties")                    'Set to access Project & Status property set
        Catch ex As Exception

        End Try
        Try
            SummaryPropSet = Doc.PropertySets.Item("Inventor Summary Information")              'Set to access Summary property set
        Catch ex As Exception

        End Try
        Try
            CustomPropSet = Doc.PropertySets.Item("Inventor User Defined Properties")           'Set to access Custom property set
        Catch ex As Exception

        End Try

        Try
            Dim propShow As Inventor.Property
            propShow = CustomPropSet.Item("Show")
            propShow.Value = cmbProjects.Text
        Catch ex As Exception
            Dim propShow As Inventor.Property
            propShow = CustomPropSet.Add(cmbProjects.Text, "Show")
        End Try
        Try
            Dim propElement As Inventor.Property
            propElement = CustomPropSet.Item("Element")
            propElement.Value = cmbElements.Text
        Catch ex As Exception
            Dim propElement As Inventor.Property
            propElement = CustomPropSet.Add(cmbElements.Text, "Element")
        End Try
        Try
            Dim propProjectNo As Inventor.Property
            propProjectNo = CustomPropSet.Item("Project Number")
            propProjectNo.Value = tbProjNo.Text
        Catch ex As Exception
            Dim propProjectNo As Inventor.Property
            propProjectNo = CustomPropSet.Add(tbProjNo.Text, "Project Number")
        End Try
        Try
            Dim propProjName As Inventor.Property
            propProjName = StdPropSet.Item("Project")
            propProjName.Value = tbProjName.Text
        Catch ex As Exception
            Dim propProjName As Inventor.Property
            propProjName = StdPropSet.Add(tbProjName.Text, "Project")
        End Try
        Try
            Dim propBuildingNo As Inventor.Property
            propBuildingNo = CustomPropSet.Item("Building Number")
            propBuildingNo.Value = tbBuildingNo.Text
        Catch ex As Exception
            Dim propBuildingNo As Inventor.Property
            propBuildingNo = CustomPropSet.Add(tbBuildingNo.Text, "Building Number")
        End Try

        Try
            Dim propDesigner As Inventor.Property
            propDesigner = StdPropSet.Item("Designer")
            propDesigner.Value = cmbDesigners.Text.Substring(0, 3)
        Catch ex As Exception
            If String.IsNullOrEmpty(cmbDesigners.Text) Then
                Dim propDesigner As Inventor.Property
                propDesigner = StdPropSet.Item("Designer")
                propDesigner.Value = " "
            Else
                Dim propDesigner As Inventor.Property
                propDesigner = StdPropSet.Item("Designer")
                propDesigner.Value = cmbDesigners.Text
            End If
        End Try

        Try
            Dim propDesignDate As Inventor.Property
            propDesignDate = StdPropSet.Item("Creation Time")
            propDesignDate.Value = dtpDesignedDate.Value
        Catch ex As Exception
            Dim propDesignDate As Inventor.Property
            propDesignDate = StdPropSet.Add(dtpDesignedDate.Value, "Creation Time")
        End Try

        Try
            Dim propChecker As Inventor.Property
            propChecker = StdPropSet.Item("Checked By")
            propChecker.Value = cmbCheckers.Text.Substring(0, 3)
        Catch ex As Exception
            If String.IsNullOrEmpty(cmbCheckers.Text) Then
                Dim propChecker As Inventor.Property
                propChecker = StdPropSet.Item("Checked By")
                propChecker.Value = " "
            Else
                Dim propChecker As Inventor.Property
                propChecker = StdPropSet.Item("Checked By")
                propChecker.Value = cmbCheckers.Text
            End If
        End Try
        Try
            Dim propCheckedDate As Inventor.Property
            propCheckedDate = StdPropSet.Item("Date Checked")
            propCheckedDate.Value = dtpCheckedDate.Value
        Catch ex As Exception
            Dim propCheckedDate As Inventor.Property
            propCheckedDate = StdPropSet.Add(dtpCheckedDate.Value, "Date Checked")
        End Try

        Try
            Dim propApprover As Inventor.Property
            propApprover = StdPropSet.Item("Engr Approved By")
            propApprover.Value = cmbApprovers.Text.Substring(0, 3)
        Catch ex As Exception
            If String.IsNullOrEmpty(cmbDesigners.Text) Then
                Dim propApprover As Inventor.Property
                propApprover = StdPropSet.Item("Engr Approved By")
                propApprover.Value = " "
            Else
                Dim propApprover As Inventor.Property
                propApprover = StdPropSet.Item("Engr Approved By")
                propApprover.Value = cmbApprovers.Text
            End If
        End Try
        Try
            Dim propApprovedDate As Inventor.Property
            propApprovedDate = StdPropSet.Item("Engr Date Approved")
            propApprovedDate.Value = dtpApprovedDate.Value
        Catch ex As Exception
            Dim propApprovedDate As Inventor.Property
            propApprovedDate = StdPropSet.Add(dtpApprovedDate.Value, "Engr Date Approved")
        End Try

        Try
            Dim propRevNo As Inventor.Property
            propRevNo = SummaryPropSet.Item("Revision Number")
            propRevNo.Value = tbRevNo.Text
        Catch ex As Exception
            Dim propRevNo As Inventor.Property
            propRevNo = SummaryPropSet.Add(tbRevNo.Text, "Revision Number")
        End Try
        Try
            Dim propNextAssy As Inventor.Property
            propNextAssy = CustomPropSet.Item("NextAssy")
            propNextAssy.Value = tbNextAssy.Text
        Catch ex As Exception
            Dim propNextAssy As Inventor.Property
            propNextAssy = CustomPropSet.Add(tbNextAssy.Text, "NextAssy")
        End Try
        Try
            Dim propUsedOn As Inventor.Property
            propUsedOn = CustomPropSet.Item("UsedOn")
            propUsedOn.Value = tbUsedOn.Text
        Catch ex As Exception
            Dim propUsedOn As Inventor.Property
            propUsedOn = CustomPropSet.Add(tbUsedOn.Text, "UsedOn")
        End Try
        Try
            Dim propVendor As Inventor.Property
            propVendor = StdPropSet.Item("Vendor")
            propVendor.Value = tbVendor.Text
        Catch ex As Exception
            Dim propVendor As Inventor.Property
            propVendor = StdPropSet.Add(tbVendor.Text, "Vendor")
        End Try

        'Set new issue date custom properties
        Dim propIssueDate1 As Inventor.Property = Nothing
        Dim propIssueDate2 As Inventor.Property = Nothing
        Dim propIssueDate3 As Inventor.Property = Nothing
        Dim propIssueDate4 As Inventor.Property = Nothing
        Dim propIssueDate5 As Inventor.Property = Nothing
        Dim propIssueDate6 As Inventor.Property = Nothing
        Dim propIssueDate7 As Inventor.Property = Nothing
        Dim propIssueDate8 As Inventor.Property = Nothing
        Dim proplist_IssueDATE As New List(Of Inventor.Property)({propIssueDate1, propIssueDate2, propIssueDate3, propIssueDate4, propIssueDate5, propIssueDate6, propIssueDate7, propIssueDate8})
        For n = 0 To 7
            Try
                proplist_IssueDATE.Item(n) = CustomPropSet.Item("ISSUED " & n + 1 & " DATE")
                proplist_IssueDATE.Item(n).Value = tblist_IssueDATE.Item(n).Text
            Catch ex As Exception
                proplist_IssueDATE.Item(n) = CustomPropSet.Add(tblist_IssueDATE.Item(n).Text, "ISSUED " & n + 1 & " DATE")
            End Try
        Next
        'Set new issue by custom properties
        Dim propIssueBy1 As Inventor.Property = Nothing
        Dim propIssueBy2 As Inventor.Property = Nothing
        Dim propIssueBy3 As Inventor.Property = Nothing
        Dim propIssueBy4 As Inventor.Property = Nothing
        Dim propIssueBy5 As Inventor.Property = Nothing
        Dim propIssueBy6 As Inventor.Property = Nothing
        Dim propIssueBy7 As Inventor.Property = Nothing
        Dim propIssueBy8 As Inventor.Property = Nothing
        Dim proplist_IssueBY As New List(Of Inventor.Property)({propIssueBy1, propIssueBy2, propIssueBy3, propIssueBy4, propIssueBy5, propIssueBy6, propIssueBy7, propIssueBy8})
        For n = 0 To 7
            Try
                proplist_IssueBY.Item(n) = CustomPropSet.Item("ISSUED " & n + 1 & " BY")
                proplist_IssueBY.Item(n).Value = tblist_IssuedBY.Item(n).Text
            Catch ex As Exception
                proplist_IssueBY.Item(n) = CustomPropSet.Add(tblist_IssuedBY.Item(n).Text, "ISSUED " & n + 1 & " BY")
            End Try
        Next
        'Set new issue Date custom properties
        Dim propIssueFor1 As Inventor.Property = Nothing
        Dim propIssueFor2 As Inventor.Property = Nothing
        Dim propIssueFor3 As Inventor.Property = Nothing
        Dim propIssueFor4 As Inventor.Property = Nothing
        Dim propIssueFor5 As Inventor.Property = Nothing
        Dim propIssueFor6 As Inventor.Property = Nothing
        Dim propIssueFor7 As Inventor.Property = Nothing
        Dim propIssueFor8 As Inventor.Property = Nothing
        Dim proplist_IssueFOR As New List(Of Inventor.Property)({propIssueFor1, propIssueFor2, propIssueFor3, propIssueFor4, propIssueFor5, propIssueFor6, propIssueFor7, propIssueFor8})
        For n = 0 To 7
            Try
                proplist_IssueFOR.Item(n) = CustomPropSet.Item("ISSUED " & n + 1 & " FOR")
                proplist_IssueFOR.Item(n).Value = tblist_IssuedFOR.Item(n).Text
            Catch ex As Exception
                proplist_IssueFOR.Item(n) = CustomPropSet.Add(tblist_IssuedFOR.Item(n).Text, "ISSUED " & n + 1 & " FOR")
            End Try
        Next

        'Set new Rev date custom properties
        Dim propRevDate1 As Inventor.Property = Nothing
        Dim propRevDate2 As Inventor.Property = Nothing
        Dim propRevDate3 As Inventor.Property = Nothing
        Dim propRevDate4 As Inventor.Property = Nothing
        Dim propRevDate5 As Inventor.Property = Nothing
        Dim propRevDate6 As Inventor.Property = Nothing
        Dim propRevDate7 As Inventor.Property = Nothing
        Dim propRevDate8 As Inventor.Property = Nothing
        Dim proplist_RevDATE As New List(Of Inventor.Property)({propRevDate1, propRevDate2, propRevDate3, propRevDate4, propRevDate5, propRevDate6, propRevDate7, propRevDate8})
        For n = 0 To 7
            Try
                proplist_RevDATE.Item(n) = CustomPropSet.Item("REV " & n + 1 & " DATE")
                proplist_RevDATE.Item(n).Value = tblist_RevDATE.Item(n).Text
            Catch ex As Exception
                proplist_RevDATE.Item(n) = CustomPropSet.Add(tblist_RevDATE.Item(n).Text, "REV " & n + 1 & " DATE")
            End Try
        Next
        'Set new Rev by custom properties
        Dim propRevBy1 As Inventor.Property = Nothing
        Dim propRevBy2 As Inventor.Property = Nothing
        Dim propRevBy3 As Inventor.Property = Nothing
        Dim propRevBy4 As Inventor.Property = Nothing
        Dim propRevBy5 As Inventor.Property = Nothing
        Dim propRevBy6 As Inventor.Property = Nothing
        Dim propRevBy7 As Inventor.Property = Nothing
        Dim propRevBy8 As Inventor.Property = Nothing
        Dim proplist_RevBy As New List(Of Inventor.Property)({propRevBy1, propRevBy2, propRevBy3, propRevBy4, propRevBy5, propRevBy6, propRevBy7, propRevBy8})
        For n = 0 To 7
            Try
                proplist_RevBy.Item(n) = CustomPropSet.Item("REV " & n + 1 & " BY")
                proplist_RevBy.Item(n).Value = tblist_RevBY.Item(n).Text
            Catch ex As Exception
                proplist_RevBy.Item(n) = CustomPropSet.Add(tblist_RevBY.Item(n).Text, "REV " & n + 1 & " BY")
            End Try
        Next
        'Set new Rev Description custom properties
        Dim propRevDescr1 As Inventor.Property = Nothing
        Dim propRevDescr2 As Inventor.Property = Nothing
        Dim propRevDescr3 As Inventor.Property = Nothing
        Dim propRevDescr4 As Inventor.Property = Nothing
        Dim propRevDescr5 As Inventor.Property = Nothing
        Dim propRevDescr6 As Inventor.Property = Nothing
        Dim propRevDescr7 As Inventor.Property = Nothing
        Dim propRevDescr8 As Inventor.Property = Nothing
        Dim proplist_RevDescr As New List(Of Inventor.Property)({propRevDescr1, propRevDescr2, propRevDescr3, propRevDescr4, propRevDescr5, propRevDescr6, propRevDescr7, propRevDescr8})
        For n = 0 To 7
            Try
                proplist_RevDescr.Item(n) = CustomPropSet.Item("REV " & n + 1 & " DESCRIPTION")
                proplist_RevDescr.Item(n).Value = tblist_RevDESCRIPTION.Item(n).Text
            Catch ex As Exception
                proplist_RevDescr.Item(n) = CustomPropSet.Add(tblist_RevDESCRIPTION.Item(n).Text, "REV " & n + 1 & " DESCRIPTION")
            End Try
        Next
        'Set new Rev Approved By custom properties
        Dim propRevApprovedBy1 As Inventor.Property = Nothing
        Dim propRevApprovedBy2 As Inventor.Property = Nothing
        Dim propRevApprovedBy3 As Inventor.Property = Nothing
        Dim propRevApprovedBy4 As Inventor.Property = Nothing
        Dim propRevApprovedBy5 As Inventor.Property = Nothing
        Dim propRevApprovedBy6 As Inventor.Property = Nothing
        Dim propRevApprovedBy7 As Inventor.Property = Nothing
        Dim propRevApprovedBy8 As Inventor.Property = Nothing
        Dim proplist_RevApprovedBy As New List(Of Inventor.Property)({propRevApprovedBy1, propRevApprovedBy2, propRevApprovedBy3, propRevApprovedBy4, propRevApprovedBy5, propRevApprovedBy6, propRevApprovedBy7, propRevApprovedBy8})
        For n = 0 To 7
            Try
                proplist_RevApprovedBy.Item(n) = CustomPropSet.Item("REV " & n + 1 & " APPROVED BY")
                proplist_RevApprovedBy.Item(n).Value = tblist_RevAPPROVEDBY.Item(n).Text
            Catch ex As Exception
                proplist_RevApprovedBy.Item(n) = CustomPropSet.Add(tblist_RevAPPROVEDBY.Item(n).Text, "REV " & n + 1 & " APPROVED BY")
            End Try
        Next

        Me.Close()
    End Sub

    Public Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        tbRevNo.Text = "0"
    End Sub

    Public Sub btnCloseCancel_Click(sender As Object, e As EventArgs) Handles btnCloseCancel.Click
        Me.Close()

    End Sub

    Public Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        dtpCheckedDate.Value = Date.Today
    End Sub

    Public Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        dtpApprovedDate.Value = Date.Today
    End Sub

    Public Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        dtpDesignedDate.Value = Date.Today
    End Sub

    Public Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        tbVendor.Text = "TAIT"
    End Sub

    Public Sub BtnMaterialSpecForm_Click(sender As Object, e As EventArgs) Handles BtnMaterialSpecForm.Click
        Dim MaterialSpecForm As New frmMaterialSpec 'Launch the frmMaterialSpec form when the button is clicked.
        MaterialSpecForm.ShowDialog()

        'Try
        '    MaterialDescription = CustomPropSet.Item("Material").Value.ToString
        '    tbMaterial.Text = MaterialDescription
        'Catch ex As Exception
        '    tbMaterial.Text = ""
        'End Try

    End Sub

    Public Sub IssuedDate1_DoubleClick(sender As Object, e As EventArgs) Handles IssuedDate1.DoubleClick, IssuedDate2.DoubleClick, IssuedDate3.DoubleClick, IssuedDate4.DoubleClick, IssuedDate5.DoubleClick, IssuedDate6.DoubleClick, IssuedDate7.DoubleClick, IssuedDate8.DoubleClick

        'DTP_IssueRev.Location()

    End Sub

    Public Sub btnIssueRevDropdown_Click(sender As Object, e As EventArgs) Handles btnIssueRevDropdown.Click
        If btnIssueRevDropdown.Text = "↑ Issues / Revisions ↑" Then
            Me.Height = 320
            Me.Width = 826
            gbIssues.Visible = False
            gbRevisions.Visible = False
            btnIssueRevDropdown.Text = "↓ Issues / Revisions ↓"
        Else
            Me.Height = 880
            Me.Width = 951
            gbIssues.Visible = True
            gbRevisions.Visible = True
            btnIssueRevDropdown.Text = "↑ Issues / Revisions ↑"
        End If
    End Sub

    Public Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles cbRevNo.CheckedChanged
        If cbRevNo.Checked = True Then
            tbRevNo.Enabled = False
        Else
            tbRevNo.Enabled = True
        End If
    End Sub

    Public Sub btnUpIssue_Click(sender As Object, e As EventArgs) Handles btnUpIssue.Click

        Dim i As Integer = 0
        Dim m As Integer
        For m = 0 To 7
            Try
                i = tblist_IssueID.Item(m).Text
            Catch
                Exit For
            End Try
        Next

        If i = 8 Then
            Exit Sub
        End If

        tblist_IssueID.Item(i).Text = i + 1
        tblist_IssuedBY.Item(i).Enabled = True
        tblist_IssueDATE.Item(i).Enabled = True
        tblist_IssuedFOR.Item(i).Enabled = True

    End Sub

    Private Sub btnUpRev_Click(sender As Object, e As EventArgs) Handles btnUpRev.Click
        Dim j As Integer = 0
        Dim m As Integer
        For m = 0 To 7
            Try
                j = tblist_RevID.Item(m).Text
            Catch
                Exit For
            End Try
        Next

        If j = 8 Then
            Exit Sub
        End If

        tblist_RevID.Item(j).Text = j + 1
        tblist_RevBY.Item(j).Enabled = True
        tblist_RevDATE.Item(j).Enabled = True
        tblist_RevDESCRIPTION.Item(j).Enabled = True
        tblist_RevAPPROVEDBY.Item(j).Enabled = True
    End Sub
End Class