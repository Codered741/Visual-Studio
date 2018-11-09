Imports Inventor
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Microsoft.Office.Interop.Excel
Imports System.Collections

Public Class frmMaterialSpec
    Public W_shapes_std As ArrayList
    Public W_shapes_met As ArrayList
    Public C_shapes_std As ArrayList
    Public C_shapes_met As ArrayList
    Public L_shapes_std As ArrayList
    Public L_shapes_met As ArrayList
    Public HSSround_shapes_std As ArrayList
    Public HSSround_shapes_met As ArrayList
    Public HSSrect_shapes_std As ArrayList
    Public HSSrect_shapes_met As ArrayList
    Public Pipe_shapes_std As ArrayList
    Public Pipe_shapes_met As ArrayList

    Public Sub frmMaterialSpec_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''Read the MaterialDescriptions_Material.txt file and populate lbMaterials items
        Dim materials() As String
        Try
            materials = IO.File.ReadAllLines("Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\MaterialDescriptions_Material.txt")
            lbMaterials.Items.AddRange(materials)
        Catch exc As Exception
            ' Report all errors.
            MsgBox("Error importing materials.")
        End Try

        ''Read the MaterialDescriptions_Shape.txt file and populate lbShapes items
        Dim shapes() As String
        Try
            shapes = IO.File.ReadAllLines("Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\MaterialDescriptions_Shape.txt")
            lbShapes.Items.AddRange(shapes)
        Catch exc As Exception
            ' Report all errors.
            MsgBox("Error importing shapes.")
        End Try

        lvGrades.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

        ''clear or generate new list arrays
        Try
            If W_shapes_std.Count > 0 Then
                W_shapes_std.Clear()
            End If
            If W_shapes_met.Count > 0 Then
                W_shapes_met.Clear()
            End If
            If C_shapes_std.Count > 0 Then
                C_shapes_std.Clear()
            End If
            If C_shapes_met.Count > 0 Then
                C_shapes_met.Clear()
            End If
            If L_shapes_std.Count > 0 Then
                L_shapes_std.Clear()
            End If
            If L_shapes_met.Count > 0 Then
                L_shapes_met.Clear()
            End If
            If HSSround_shapes_std.Count > 0 Then
                HSSround_shapes_std.Clear()
            End If
            If HSSround_shapes_met.Count > 0 Then
                HSSround_shapes_met.Clear()
            End If
            If HSSrect_shapes_std.Count > 0 Then
                HSSrect_shapes_std.Clear()
            End If
            If HSSrect_shapes_met.Count > 0 Then
                HSSrect_shapes_met.Clear()
            End If
            If Pipe_shapes_std.Count > 0 Then
                Pipe_shapes_std.Clear()
            End If
            If Pipe_shapes_met.Count > 0 Then
                Pipe_shapes_met.Clear()
            End If
        Catch ex As Exception
            W_shapes_std = New ArrayList
            W_shapes_met = New ArrayList
            C_shapes_std = New ArrayList
            C_shapes_met = New ArrayList
            L_shapes_std = New ArrayList
            L_shapes_met = New ArrayList
            HSSround_shapes_std = New ArrayList
            HSSround_shapes_met = New ArrayList
            HSSrect_shapes_std = New ArrayList
            HSSrect_shapes_met = New ArrayList
            Pipe_shapes_std = New ArrayList
            Pipe_shapes_met = New ArrayList
        End Try

        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\aisc-shapes-database-v15.0_TAIT.csv")
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")

            MyReader.ReadLine() ' skip header line
            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    Dim currentField As String
                    Dim shapetype As String = ""
                    Dim linecount As Integer = 0
                    For Each currentField In currentRow
                        'MsgBox("Shape: " & shapetype & vbNewLine &
                        '       "linecount: " & linecount & vbNewLine &
                        '       "field value: " & currentField)
                        If linecount = 0 Then
                            shapetype = currentField
                        Else
                            Select Case shapetype
                                Case "W"
                                    If linecount = 1 Then
                                        W_shapes_std.Add(currentField)
                                    ElseIf linecount = 4 Then
                                        W_shapes_met.Add(currentField)
                                    End If
                                Case "C"
                                    If linecount = 1 Then
                                        C_shapes_std.Add(currentField)
                                    ElseIf linecount = 4 Then
                                        C_shapes_met.Add(currentField)
                                    End If
                                Case "L"
                                    If linecount = 1 Then
                                        L_shapes_std.Add(currentField)
                                    ElseIf linecount = 4 Then
                                        L_shapes_met.Add(currentField)
                                    End If
                                Case "HSS"
                                    If linecount = 1 And currentField.Split("X").Length = 3 Then
                                        HSSrect_shapes_std.Add(currentField)
                                    ElseIf linecount = 4 And currentField.Split("X").Length = 3 Then
                                        HSSrect_shapes_met.Add(currentField)
                                    ElseIf linecount = 1 And currentField.Split("X").Length = 2 Then
                                        HSSround_shapes_std.Add(currentField)
                                    ElseIf linecount = 4 And currentField.Split("X").Length = 2 Then
                                        HSSround_shapes_met.Add(currentField)
                                    Else
                                        'MsgBox("Problem finding HSS shapes for Carbon Steel.")
                                    End If
                                Case "PIPE"
                                    If linecount = 1 Then
                                        Pipe_shapes_std.Add(currentField)
                                    ElseIf linecount = 4 Then
                                        Pipe_shapes_met.Add(currentField)
                                    End If
                            End Select
                        End If
                        linecount = linecount + 1
                    Next
                Catch ex As Microsoft.VisualBasic.
                  FileIO.MalformedLineException
                    'MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                End Try
            End While

        End Using

        ''Read the aisc-shapes-database-v15.0.xlsx and populate shape sizes
        'Dim HSSname As String
        'Dim excelApp As Microsoft.Office.Interop.Excel.Application
        'Dim aiscdb_wb As Workbook
        'Dim aiscdb_ws As Worksheet

        ''Excel processing
        'excelApp = CreateObject("Excel.Application")
        'excelApp.Visible = False
        'excelApp.DisplayAlerts = False

        'aiscdb_wb = excelApp.Workbooks.Open("Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\aisc-shapes-database-v15.0_TAIT.xlsx", False, True,, "elvisapresley")
        'aiscdb_ws = aiscdb_wb.Worksheets(1)

        'Dim activecell As Range
        'activecell = aiscdb_ws.Range("A2")
        'Dim NumDBRows As Integer
        'NumDBRows = aiscdb_ws.Range("A2", aiscdb_ws.Range("A2").End(XlDirection.xlDown)).Rows.Count  ' Set numrows = number of rows of data.

        'Dim ShapeCategory As String
        'For x = 1 To NumDBRows  ' Establish "For" loop to loop "NumDBrows" number of times.
        '    ShapeCategory = CStr(activecell.Value)
        '    Select Case ShapeCategory
        '        Case "W"
        '            W_shapes_std.Add(CStr(activecell.Offset(0, 2).Value))
        '            W_shapes_met.Add(CStr(activecell.Offset(0, 85).Value))
        '        Case "C"
        '            C_shapes_std.Add(CStr(activecell.Offset(0, 2).Value))
        '            C_shapes_met.Add(CStr(activecell.Offset(0, 85).Value))
        '        Case "L"
        '            L_shapes_std.Add(CStr(activecell.Offset(0, 2).Value))
        '            L_shapes_met.Add(CStr(activecell.Offset(0, 85).Value))
        '        Case "HSS"
        '            HSSname = CStr(activecell.Offset(0, 2).Value)
        '            If HSSname.Split("X").Length = 3 Then
        '                HSSrect_shapes_std.Add(CStr(activecell.Offset(0, 2).Value))
        '                HSSrect_shapes_met.Add(CStr(activecell.Offset(0, 85).Value))
        '            ElseIf HSSname.Split("X").Length = 2 Then
        '                HSSround_shapes_std.Add(CStr(activecell.Offset(0, 2).Value))
        '                HSSround_shapes_met.Add(CStr(activecell.Offset(0, 85).Value))
        '            Else
        '                MsgBox("Problem finding HSS shapes for Carbon Steel.")
        '            End If
        '        Case "PIPE"
        '            Pipe_shapes_std.Add(CStr(activecell.Offset(0, 1).Value))
        '            Pipe_shapes_met.Add(CStr(activecell.Offset(0, 84).Value))
        '    End Select
        '    activecell = activecell.Offset(1, 0)
        'Next

        ' Connect to a running instance of Inventor. 
        ' Watch out for the wrapped line. 
        Dim invApp As Inventor.Application
        invApp = System.Runtime.InteropServices.Marshal.GetActiveObject("Inventor.Application")

        ' Get the active document. 
        Dim Doc As Inventor.Document
        Doc = invApp.ActiveDocument

        'Read the Material iProperty and relay to label
        Call ReadCustomiProperty(Doc, "Material")

        'aiscdb_wb.Close(False)
        'excelApp = Nothing
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
    Public Sub LbShapes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbShapes.SelectedIndexChanged, lbMaterials.SelectedIndexChanged, rbImperial.CheckedChanged
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
        cbDescr.Items.Clear()
        cbDescr.SelectedIndex = -1
        cbDescr.Visible = False
        gbUnits.Visible = True

        Try
            shapechosen = lbShapes.SelectedItem.ToString
        Catch ex As Exception
            Exit Sub
        End Try

        Select Case shapechosen
            Case "Angle"
                If lbMaterials.SelectedItem.ToString = "Carbon Steel" Then
                    If rbImperial.Checked = True Then
                        cbDescr.Items.AddRange(L_shapes_std.ToArray)
                    Else
                        cbDescr.Items.AddRange(L_shapes_met.ToArray)
                    End If
                    cbDescr.Visible = True
                    lblD1.Text = "AISC Shape Designation"
                    lblD1.Visible = True
                Else
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
                End If

            Case "Channel"
                If lbMaterials.SelectedItem.ToString = "Carbon Steel" Then
                    If rbImperial.Checked = True Then
                        cbDescr.Items.AddRange(C_shapes_std.ToArray)
                    Else
                        cbDescr.Items.AddRange(C_shapes_met.ToArray)
                    End If
                    cbDescr.Visible = True
                    lblD1.Text = "AISC Shape Designation"
                    lblD1.Visible = True
                Else
                    lblD1.Text = "Depth"
                    lblD1.Visible = True
                    lblD2.Text = "Nom. Wt."
                    lblD2.Visible = True
                    lblX1.Visible = True
                    nudD1.Visible = True
                    nudD2.Visible = True
                End If

            Case "Wide Flange Beam"
                If lbMaterials.SelectedItem.ToString = "Carbon Steel" Then
                    If rbImperial.Checked = True Then
                        cbDescr.Items.AddRange(W_shapes_std.ToArray)
                    Else
                        cbDescr.Items.AddRange(W_shapes_met.ToArray)
                    End If
                    cbDescr.Visible = True
                    lblD1.Text = "AISC Shape Designation"
                    lblD1.Visible = True
                Else
                    lblD1.Text = "Depth"
                    lblD1.Visible = True
                    lblD2.Text = "Weight/Leg"
                    lblD2.Visible = True
                    lblX1.Visible = True
                    nudD1.Visible = True
                    nudD2.Visible = True
                End If

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
                If lbMaterials.SelectedItem.ToString = "Carbon Steel" Then
                    If rbImperial.Checked = True Then
                        cbDescr.Items.AddRange(HSSround_shapes_std.ToArray)
                    Else
                        cbDescr.Items.AddRange(HSSround_shapes_met.ToArray)
                    End If
                    cbDescr.Visible = True
                    lblD1.Text = "AISC Shape Designation"
                    lblD1.Visible = True
                Else
                    lblD1.Text = "Diameter"
                    lblD1.Visible = True
                    lblD2.Text = "Thickness"
                    lblD2.Visible = True
                    lblX1.Visible = True
                    nudD1.Visible = True
                    nudD2.Visible = True
                End If

            Case "Rect Tube"
                If lbMaterials.SelectedItem.ToString = "Carbon Steel" Then
                    If rbImperial.Checked = True Then
                        cbDescr.Items.AddRange(HSSrect_shapes_std.ToArray)
                    Else
                        cbDescr.Items.AddRange(HSSrect_shapes_met.ToArray)
                    End If
                    cbDescr.Visible = True
                    lblD1.Text = "AISC Shape Designation"
                    lblD1.Visible = True
                Else
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
                End If

            Case "Pipe"
                If lbMaterials.SelectedItem.ToString = "Carbon Steel" Then
                    If rbImperial.Checked = True Then
                        cbDescr.Items.AddRange(Pipe_shapes_std.ToArray)
                    Else
                        cbDescr.Items.AddRange(Pipe_shapes_met.ToArray)
                    End If
                    cbDescr.Visible = True
                    lblD1.Text = "AISC Shape Designation"
                    lblD1.Visible = True
                Else
                    lblD1.Text = "Diameter"
                    lblD1.Visible = True
                    lblD2.Text = "Schedule"
                    lblD2.Visible = True
                    lblX1.Visible = True
                    nudD1.Visible = True
                    nudD2.Visible = True
                End If

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
    Public Sub cbDescr_ValueChanged(sender As Object, e As EventArgs) Handles cbDescr.SelectedValueChanged
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
        If rbStandardMaterial.Checked = True Then
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
            Dim dim4 As String
            dim4 = ""
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
            Try
                dim4 = cbDescr.SelectedItem.ToString
            Catch
                dim4 = ""
            End Try

            'find correct dimension values for shape
            Select Case shape
                Case "Angle"
                    If material = "Carbon Steel" Then
                        lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; " & dim4 & " " & UCase(shape)
                    Else
                        lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; L" & dim1 & "X" & dim2 & "X" & dim3 & " " & UCase(shape)
                    End If

                Case "Channel"
                    If material = "Carbon Steel" Then
                        lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; " & dim4 & " " & UCase(shape)
                    Else
                        lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; C" & dim1 & "X" & dim2 & " " & UCase(shape)
                    End If

                Case "Wide Flange Beam"
                    If material = "Carbon Steel" Then
                        lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; " & dim4 & " " & UCase(shape)
                    Else
                        lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; W" & dim1 & "X" & dim2 & " " & UCase(shape)
                    End If

                Case "Plate"
                    lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; " & dim1 & " " & UCase(shape)

                Case "Bar"
                    lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; " & dim1 & "X" & dim2 & " " & UCase(shape)

                Case "Round"
                    lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; " & dim1 & " " & UCase(shape)

                Case "Round Tube"
                    If material = "Carbon Steel" Then
                        lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; " & dim4 & " " & UCase(shape)
                    Else
                        lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; HSS" & dim1 & "X" & dim2 & " " & UCase(shape)
                    End If

                Case "Rect Tube"
                    If material = "Carbon Steel" Then
                        lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; " & dim4 & " " & UCase(shape)
                    Else
                        lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; HSS" & dim1 & "X" & dim2 & "X" & dim3 & " " & UCase(shape)
                    End If

                Case "Pipe"
                    If material = "Carbon Steel" Then
                        lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; " & dim4 & " " & UCase(shape)
                    Else
                        lblMaterialDescription.Text = UCase(grade) & " " & UCase(material) & "; " & dim1 & " SCH" & dim2 & " " & UCase(shape)
                    End If

                Case Else
                    lblMaterialDescription.Text = ""
            End Select

            lblMaterialDescription.Visible = True
        Else
            lblMaterialDescription.Text = tbCustomMaterial.Text
        End If

    End Sub

    Public Sub btnMaterialFlowChart_Click(sender As Object, e As EventArgs) Handles btnMaterialFlowChart.Click
        Dim FILE_NAME As String = "S:\REFERENCE\ENGINEERING\Reference Docs\Structural Material Selection Flow Chart.pdf"

        If System.IO.File.Exists(FILE_NAME) = True Then
            Process.Start(FILE_NAME)
        Else
            MsgBox("Material Selection Flow Chart not found." & vbNewLine & vbNewLine &
                   "Please check that you have access to the following document:" & vbNewLine &
                   "S:\REFERENCE\ENGINEERING\Reference Docs\Structural Material Selection Flow Chart.pdf")
        End If
    End Sub
    Public Sub btnAISCMaterialDB_Click(sender As Object, e As EventArgs) Handles btnAISCMaterialDB.Click
        Dim FILE_NAME As String = "Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\aisc-shapes-database-v15.0.xlsx"

        If System.IO.File.Exists(FILE_NAME) = True Then
            Process.Start(FILE_NAME)
        Else
            MsgBox("AISC Material Database excel workbook not found." & vbNewLine & vbNewLine &
                   "Please check that you have access to the following document:" & vbNewLine &
                   "Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\aisc-shapes-database-v15.0.xlsx")
        End If
    End Sub

    Private Sub MaterialConstrutorSelection(sender As Object, e As EventArgs) Handles rbStandardMaterial.CheckedChanged
        If rbStandardMaterial.Checked = True Then
            'turn on standard material constructor controls
            lbMaterials.Enabled = True
            lbShapes.Enabled = True
            lvGrades.Enabled = True
            nudD1.ReadOnly = False
            nudD1.Enabled = True
            nudD2.ReadOnly = False
            nudD2.Enabled = True
            nudD3.ReadOnly = False
            nudD3.Enabled = True
            rbImperial.Enabled = True
            rbMetric.Enabled = True
            cbDescr.Enabled = True
            gbUnits.Enabled = True

            'turn off custom material control
            tbCustomMaterial.Enabled = False
            tbCustomMaterial.ReadOnly = True
            tbCustomMaterial.Text = ""
        Else
            'turn off standard material constructor controls
            lbMaterials.Enabled = False
            lbShapes.Enabled = False
            lvGrades.Enabled = False
            nudD1.ReadOnly = True
            nudD1.Enabled = False
            nudD2.ReadOnly = True
            nudD2.Enabled = False
            nudD3.ReadOnly = True
            nudD3.Enabled = False
            rbImperial.Enabled = False
            rbMetric.Enabled = False
            cbDescr.Enabled = False
            gbUnits.Enabled = False

            'turn on custom material control
            tbCustomMaterial.Enabled = True
            tbCustomMaterial.ReadOnly = False
        End If
    End Sub

    Private Sub tbCustomMaterial_TextChanged(sender As Object, e As EventArgs) Handles tbCustomMaterial.TextChanged
        Call Compiler()
    End Sub

    Private Sub rbImperial_CheckedChanged(sender As Object, e As EventArgs) Handles rbImperial.CheckedChanged
        If rbImperial.Checked = True Then
            nudD1.DecimalPlaces = 3
            nudD2.DecimalPlaces = 3
            nudD3.DecimalPlaces = 3
        Else
            nudD1.DecimalPlaces = 2
            nudD2.DecimalPlaces = 2
            nudD3.DecimalPlaces = 2
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class