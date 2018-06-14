Imports Inventor
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class frmMaterialSpec
    Public Sub frmMaterialSpec_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim materials() As String
        ''Read the Grade .txt file and populate cmbGrade items
        Try
            materials = IO.File.ReadAllLines("Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\MaterialDescriptions_Material.txt")
            lbMaterials.Items.AddRange(materials)
        Catch exc As Exception
            ' Report all errors.
            MsgBox("Error")
        End Try

        Dim shapes() As String
        ''Read the Grade .txt file and populate cmbGrade items
        Try
            shapes = IO.File.ReadAllLines("Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\MaterialDescriptions_Shape.txt")
            lbShapes.Items.AddRange(shapes)
        Catch exc As Exception
            ' Report all errors.
            MsgBox("Error")
        End Try

        lvGrades.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

        ' Connect to a running instance of Inventor. 
        ' Watch out for the wrapped line. 
        Dim invApp As Inventor.Application
        invApp = System.Runtime.InteropServices.Marshal.GetActiveObject("Inventor.Application")

        ' Get the active document. 
        Dim Doc As Inventor.Document
        Doc = invApp.ActiveDocument

        'Read the Material iProperty and relay to label
        Call ReadCustomiProperty(Doc, "Material")

        invApp = Nothing
        Doc = Nothing

    End Sub
    Public Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        ' Connect to a running instance of Inventor. 
        ' Watch out for the wrapped line. 
        Dim invApp As Inventor.Application
        invApp = System.Runtime.InteropServices.Marshal.GetActiveObject("Inventor.Application")

        ' Get the active document. 
        Dim Doc As Inventor.Document
        Doc = invApp.ActiveDocument

        ' Update or create the custom iProperty.
        Call UpdateCustomiProperty(Doc, "Material", CObj(lblMaterialDescription.Text))

        Me.Close()
    End Sub

    Public Sub UpdateCustomiProperty(ByRef Doc As Document, ByRef PropertyName As String, ByRef PropertyValue As Object)
        ' Get the custom property set.
        Dim customPropSet As PropertySet
        customPropSet = Doc.PropertySets.Item("Inventor User Defined Properties")


        ' Get the existing property, if it exists.
        Dim prop As Inventor.Property
        Try
            prop = customPropSet.Item(PropertyName)
            ' Change the value of the existing property.
            prop.Value = PropertyValue
        Catch ex As Exception
            ' Failed to get the existing property so create a new one.
            prop = customPropSet.Add(PropertyValue, PropertyName)
        End Try

    End Sub

    Public Sub btnCloseCancel_Click(sender As Object, e As EventArgs) Handles btnCloseCancel.Click
        Me.Close()
    End Sub
    Public Sub LbMaterials_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbMaterials.SelectedIndexChanged
        Call GradeSpec()
        Call Compiler()
    End Sub

    Public Sub LbShapes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbShapes.SelectedIndexChanged
        Dim shapechosen As String
        lblD1.Visible = False
        lblD2.Visible = False
        lblD3.Visible = False
        lblX1.Visible = False
        lblX2.Visible = False
        nudD1.Visible = False
        nudD1.Value = 0
        nudD2.Visible = False
        nudD2.Value = 0
        nudD3.Visible = False
        nudD3.Value = 0

        shapechosen = lbShapes.SelectedItem.ToString

        Select Case shapechosen
            Case "Angle"
                lblD1.Text = "Leg 1"
                lblD1.Visible = True
                lblD2.Text = "Leg 2"
                lblD2.Visible = True
                lblD3.Text = "Thickness"
                lblD3.Visible = True
                lblX1.Visible = True
                lblX2.Visible = True
                nudD1.Visible = True
                nudD2.Visible = True
                nudD3.Visible = True

            Case "Channel"
                lblD1.Text = "Depth"
                lblD1.Visible = True
                lblD2.Text = "Nom. Wt."
                lblD2.Visible = True
                lblX1.Visible = True
                nudD1.Visible = True
                nudD2.Visible = True

            Case "Wide Flange Beam"
                lblD1.Text = "Depth"
                lblD1.Visible = True
                lblD2.Text = "Weight/Leg"
                lblD2.Visible = True
                lblX1.Visible = True
                nudD1.Visible = True
                nudD2.Visible = True

            Case "Plate"
                lblD1.Text = "Thickness"
                lblD1.Visible = True
                nudD1.Visible = True

            Case "Bar"
                lblD1.Text = "Width"
                lblD1.Visible = True
                lblD2.Text = "Height"
                lblD2.Visible = True
                lblX1.Visible = True
                nudD1.Visible = True
                nudD2.Visible = True

            Case "Round"
                lblD1.Text = "Diameter"
                lblD1.Visible = True
                nudD1.Visible = True

            Case "Round Tube"
                lblD1.Text = "Diameter"
                lblD1.Visible = True
                lblD2.Text = "Thickness"
                lblD2.Visible = True
                lblX1.Visible = True
                nudD1.Visible = True
                nudD2.Visible = True

            Case "Rect Tube"
                lblD1.Text = "Length"
                lblD1.Visible = True
                lblD2.Text = "Width"
                lblD2.Visible = True
                lblD3.Text = "Thickness"
                lblD3.Visible = True
                lblX1.Visible = True
                lblX2.Visible = True
                nudD1.Visible = True
                nudD2.Visible = True
                nudD3.Visible = True

            Case "Pipe"
                lblD1.Text = "Diameter"
                lblD1.Visible = True
                lblD2.Text = "Schedule"
                lblD2.Visible = True
                lblX1.Visible = True
                nudD1.Visible = True
                nudD2.Visible = True

            Case Else
                MsgBox("Failed to determine correct dimension structure.")
        End Select

        Call GradeSpec()
        Call Compiler()
    End Sub
    Public Sub LvGrades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvGrades.SelectedIndexChanged
        Try
            tbComments.Text = lvGrades.SelectedItems.Item(0).Tag.ToString
        Catch ex As Exception
            tbComments.Text = ""
        End Try

        Call Compiler()

    End Sub
    Public Sub NudD1_ValueChanged(sender As Object, e As EventArgs) Handles nudD1.TextChanged
        Call Compiler()
    End Sub
    Public Sub NudD2_ValueChanged(sender As Object, e As EventArgs) Handles nudD2.TextChanged
        Call Compiler()
    End Sub
    Public Sub NudD3_ValueChanged(sender As Object, e As EventArgs) Handles nudD3.TextChanged
        Call Compiler()
    End Sub

    Public Sub ReadCustomiProperty(ByRef Doc As Document, ByRef PropertyName As String)
        ' Get the custom property set.
        Dim customPropSet As PropertySet
        customPropSet = Doc.PropertySets.Item("Inventor User Defined Properties")

        ' Get the existing property, if it exists.
        Dim prop As Inventor.Property
        On Error Resume Next
        prop = customPropSet.Item(PropertyName)

        ' Check to see if the above call failed.  If it failed
        ' then the property doesn't exist.
        If Err.Number <> 0 Then
            ' Failed to get the existing property so display "no current material proprty"
            Me.lblCurrentMaterialDescription.Text = "No material description created."
        Else
            ' Change the value of the existing property.
            Me.lblCurrentMaterialDescription.Text = prop.Value
        End If
    End Sub
    Public Sub GradeSpec()
        lvGrades.Items.Clear()
        Dim selectedMaterial As String = ""
        Dim selectedShape As String = ""
        Try
            selectedMaterial = lbMaterials.SelectedItem.ToString
            selectedShape = lbShapes.SelectedItem.ToString
        Catch ex As Exception
            Exit Sub
        End Try

        Dim grades2() As String = IO.File.ReadAllLines("Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\MaterialDescriptions_Grade2.txt")
        Dim gradesarray As New ArrayList()
        For g As Integer = 0 To grades2.GetUpperBound(0)
            gradesarray.Add(grades2(g))
        Next

        Dim X(3) As String
        Dim XMaterial As String
        Dim XShape As String
        Dim XGrade As String
        Dim XComments As String
        For n = 0 To gradesarray.Count - 1
            If gradesarray.Item(n).ToString.Substring(0, 1) = "*" Then
                GoTo nOBJ
            End If
            X = gradesarray.Item(n).ToString.Split("|")
            XMaterial = X(0)
            XShape = X(1)
            XGrade = X(2)
            XComments = X(3)

            If selectedMaterial = XMaterial And XShape.Contains(selectedShape) Then
                Dim LVI As New ListViewItem
                LVI.Text = XGrade
                LVI.Tag = XComments
                lvGrades.Items.Add(LVI)
            End If
nOBJ:
        Next

    End Sub
    Public Sub Compiler()
        'establish all strings
        Dim grade As String
        grade = ""
        Dim material As String
        material = ""
        Dim shape As String
        shape = ""
        Dim dim1 As String
        dim1 = ""
        Dim dim2 As String
        dim2 = ""
        Dim dim3 As String
        dim3 = ""
        lblMaterialDescription.Text = ""

        'load values for strings
        Try
            grade = lvGrades.SelectedItems.Item(0).Text.ToString
            material = lbMaterials.SelectedItem.ToString
            shape = lbShapes.SelectedItem.ToString
        Catch ex As Exception
            grade = ""
            material = ""
            shape = ""
        End Try

        dim1 = nudD1.Text
        dim2 = nudD2.Text
        dim3 = nudD3.Text

        'find correct dimension values for shape
        Select Case shape
            Case "Angle"
                lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; L" & dim1 & "X" & dim2 & "X" & dim3 & " " & UCase(shape)

            Case "Channel"
                lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; C" & dim1 & "X" & dim2 & " " & UCase(shape)

            Case "Wide Flange Beam"
                lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; W" & dim1 & "X" & dim2 & " " & UCase(shape)

            Case "Plate"
                lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; " & dim1 & " " & UCase(shape)

            Case "Bar"
                lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; " & dim1 & "X" & dim2 & " " & UCase(shape)

            Case "Round"
                lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; " & dim1 & " " & UCase(shape)

            Case "Round Tube"
                lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; HSS" & dim1 & "X" & dim2 & " " & UCase(shape)

            Case "Rect Tube"
                lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; HSS" & dim1 & "X" & dim2 & "X" & dim3 & " " & UCase(shape)

            Case "Pipe"
                lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; " & dim1 & " SCH" & dim2 & " " & UCase(shape)

            Case Else
                lblMaterialDescription.Text = ""
        End Select

        lblMaterialDescription.Visible = True
    End Sub

    Public Sub btnMaterialFlowChart_Click(sender As Object, e As EventArgs) Handles btnMaterialFlowChart.Click
        Dim FILE_NAME As String = "S:\REFERENCE\ENGINEERING\Reference Docs\Structural Material Selection Flow Chart.pdf"

        If System.IO.File.Exists(FILE_NAME) = True Then
            Process.Start(FILE_NAME)
        Else
            MsgBox("File does not exist in specified location")
        End If
    End Sub

End Class