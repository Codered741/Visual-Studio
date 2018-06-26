Imports Inventor
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class frmPropConfig
    Dim StdPropSet As PropertySet
    Dim SummaryPropSet As PropertySet
    Dim CustomPropSet As PropertySet
    Public MaterialDescription As String
    Public Sub frmPropConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Connect to a running instance of Inventor. 
        ' Watch out for the wrapped line. 
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

            Dim X(1) As String
            Dim XProject As String
            Dim XElement As String
            For n = 0 To projectlist.Count - 1
                If projectlist.Item(n).ToString.Substring(0, 1) = "*" Then
                    GoTo nOBJ
                End If
                X = projectlist.Item(n).ToString.Split("|")
                XProject = X(0)
                XElement = X(1)

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

        cmbApprovers.Items.Add("ARY (Adam R. Yeager)")
        cmbApprovers.Items.Add("PAW (Peter A. Woods)")
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
            For n = 0 To elementlist.Count - 1
                If elementlist.Item(n).ToString.Substring(0, 1) = "*" Then
                    GoTo nOBJ
                End If

                X = elementlist.Item(n).ToString.Split("|")
                XProject = X(0)
                If ProjectChosen = XProject Then
                    XElement = X(1)
                    Dim m() As String
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
            Dim propDesigner As Inventor.Property
            propDesigner = StdPropSet.Add(cmbDesigners.Text.Substring(0, 3), "Designer")
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
            Dim propChecker As Inventor.Property
            propChecker = StdPropSet.Add(cmbCheckers.Text.Substring(0, 3), "Checked By")
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
            Dim propApprover As Inventor.Property
            propApprover = StdPropSet.Add(cmbApprovers.Text.Substring(0, 3), "Engr Approved By")
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

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim MaterialSpecForm As New frmMaterialSpec 'Launch the frmMaterialSpec form when the button is clicked.
        MaterialSpecForm.ShowDialog(Me)

        'Try
        '    MaterialDescription = CustomPropSet.Item("Material").Value.ToString
        '    tbMaterial.Text = MaterialDescription
        'Catch ex As Exception
        '    tbMaterial.Text = ""
        'End Try

    End Sub
End Class