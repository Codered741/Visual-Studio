Imports Inventor
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.IO
Imports Microsoft.Win32
Imports Microsoft.VisualBasic
Public Class frmBatchChange

    Dim ds As New System.Data.DataSet
    Public Property Compatibility As Object
    Dim bump As Integer
    Dim SelectedRefDocRow As Integer
    Dim SelectedRefDoc As String
    Dim invApp As Inventor.Application

    Private Sub btnGetInfo_Click(sender As Object, e As EventArgs) Handles btnGetInfo.Click
        LoadLabel.Visible = True
        LoadStatus.Text = "Connecting to Application..."
        LoadStatus.Visible = True

        invApp = System.Runtime.InteropServices.Marshal.GetActiveObject("Inventor.Application")
        Threading.Thread.Sleep(500)

        LoadStatus.Text = "Getting active assembly..."
        ' Get the active document. 
        Dim Doc As Inventor.AssemblyDocument
        Doc = invApp.ActiveDocument
        Threading.Thread.Sleep(500)

        LoadStatus.Text = "Initializing dataset..."
        Dim FlatBOM As New List(Of String)
        'Dim FlatBOM() As String
        ds.Clear()
        ds.Tables.Clear()
        ds.Tables.Add("ItemProperties")

        ds.Tables("ItemProperties").Columns.Add("FN")
        ds.Tables("ItemProperties").Columns.Add("PN")
        ds.Tables("ItemProperties").Columns.Add("Image")
        ds.Tables("ItemProperties").Columns.Add("PartDescription")
        ds.Tables("ItemProperties").Columns.Add("DesignedBy")
        ds.Tables("ItemProperties").Columns.Add("CreationDate")
        ds.Tables("ItemProperties").Columns.Add("ApprovedBy")
        ds.Tables("ItemProperties").Columns.Add("ApprovedDate")
        ds.Tables("ItemProperties").Columns.Add("Checked")
        ds.Tables("ItemProperties").Columns.Add("BOMtype")
        'ds.Tables("ItemProperties").Columns.Add("RevisionNumber")
        'ds.Tables("ItemProperties").Columns.Add("MakeBuy")
        'ds.Tables("ItemProperties").Columns.Add("MaterialDescription")
        'ds.Tables("ItemProperties").Columns.Add("Vendor")
        'ds.Tables("ItemProperties").Columns.Add("Drawing Date")
        'ds.Tables("ItemProperties").Columns.Add("Designer")
        'ds.Tables("ItemProperties").Columns.Add("Detailer")
        'ds.Tables("ItemProperties").Columns.Add("CheckedBy")
        'ds.Tables("ItemProperties").Columns.Add("MakeBuyBoolean")
        'ds.Tables("ItemProperties").Columns.Add("VendorSuppliedMtlBoolean")
        'ds.Tables("ItemProperties").Columns.Add("EpicorMtlNumber")
        'ds.Tables("ItemProperties").Columns.Add("EpicorMtlDescription")
        'ds.Tables("ItemProperties").Columns.Add("Operation1")
        'ds.Tables("ItemProperties").Columns.Add("Operation2")
        'ds.Tables("ItemProperties").Columns.Add("Operation3")
        'ds.Tables("ItemProperties").Columns.Add("Operation4")
        'ds.Tables("ItemProperties").Columns.Add("Operations")
        'ds.Tables("ItemProperties").Columns.Add("MtlLength")
        'ds.Tables("ItemProperties").Columns.Add("MtlWidth")
        'ds.Tables("ItemProperties").Columns.Add("XLength")
        'ds.Tables("ItemProperties").Columns.Add("YLength")
        'ds.Tables("ItemProperties").Columns.Add("ZLength")
        Threading.Thread.Sleep(500)

        bump = 0
        LoadStatus.Text = "Retrieving Part and Subassembly properties... (" & bump & " reference documents retrieved)"
        ' Call the function that does the recursion.
        Call GetChildrenProperties(Doc.ComponentDefinition.Occurrences, FlatBOM)
        Threading.Thread.Sleep(500)

        LoadStatus.Text = "Populating Grid View..."
        dgvBOM.Rows.Clear()
        For Each row As System.Data.DataRow In ds.Tables("ItemProperties").Rows
            Dim newrow As Integer
            dgvBOM.Rows.Add()
            newrow = dgvBOM.Rows.GetLastRow(DataGridViewElementStates.None)
            dgvBOM.Rows(newrow).Cells.Item(0).Value = row.Item(0)
            dgvBOM.Rows(newrow).Cells.Item(1).Value = row.Item(1)
            dgvBOM.Rows(newrow).Cells.Item(2).Value = row.Item(2)
            For n = 3 To 7
                dgvBOM.Rows(newrow).Cells.Item(n).Value = row.Item(n)
                If row.Item(n) = "DNE" Or row.Item(n) = "1/1/1601" Then
                    dgvBOM.Rows(newrow).Cells.Item(n).Style.BackColor = System.Drawing.Color.LightCoral
                End If
            Next
            dgvBOM.Rows(newrow).Cells.Item(9).Value = row.Item(9)
        Next
        Threading.Thread.Sleep(500)

        LoadStatus.Text = "Assembly BOM import complete."
        Threading.Thread.Sleep(500)
        LoadLabel.Visible = False
        LoadStatus.Visible = False

    End Sub

    Sub GetChildrenProperties(oDocOccs As ComponentOccurrences, FBOM As List(Of String))
        If oDocOccs.Count > 1 Then

            For Each Occ As ComponentOccurrence In oDocOccs
                ' Get the custom property sets.
                Dim StdPropSet As PropertySet
                Dim SummaryPropSet As PropertySet
                Dim CustomPropSet As PropertySet
                Try
                    StdPropSet = Occ.Definition.Document.PropertySets.Item("Design Tracking Properties")                    'Set to access Project & Status property set
                Catch ex As Exception
                    GoTo nxtOcc
                End Try
                Try
                    SummaryPropSet = Occ.Definition.Document.PropertySets.Item("Inventor Summary Information")              'Set to access Summary property set
                Catch ex As Exception
                    GoTo nxtOcc
                End Try
                Try
                    CustomPropSet = Occ.Definition.Document.PropertySets.Item("Inventor User Defined Properties")           'Set to access Custom property set
                Catch ex As Exception
                    GoTo nxtOcc
                End Try

                Dim params As Parameters
                Try
                    params = Occ.Definition.Parameters                                                                  'Set to access to user parameters
                Catch ex As Exception

                End Try

                If Occ.DefinitionDocumentType = DocumentTypeEnum.kAssemblyDocumentObject Then

                    Dim FileName As String = Occ.Definition.Document.FullFileName.ToString
                    Dim FileNamesplit() As String = FileName.Split("\")
                    Dim m As Integer = FileNamesplit.Length
                    Dim PartNumber As String = FileNamesplit(m - 1).Substring(0, FileNamesplit(m - 1).Length - 4)

                    If FBOM.Contains(PartNumber) = vbFalse Then

                        'Dim thumbprop As Inventor.Property
                        'thumbprop = SummaryPropSet.Item("Thumbnail")
                        'Dim pic As stdole.IPictureDisp
                        'pic = thumbprop.Value
                        'Dim img As Image = Compatibility.VB6.IPictureDispToImage(pic)

                        Dim dr As System.Data.DataRow                                                                               'Initialize a datarow
                        ds.Tables("ItemProperties").Rows.Add()                                                          'Add a new row
                        dr = ds.Tables("ItemProperties").Rows(ds.Tables("ItemProperties").Rows.Count - 1)               'Set datarow variable equal to last row

                        dr.Item(0) = FileNamesplit(m - 1)                                                               'Record filename to datarow
                        Try
                            dr.Item(1) = StdPropSet.Item("Part Number").Value.ToString                                  'Record Part Number property to datarow
                        Catch ex As Exception
                            dr.Item(1) = "DNE"
                        End Try
                        'Try
                        '    dr.Item(2) = ""                                                                             'Record Thumbnail image to datarow
                        'Catch ex As Exception
                        '    dr.Item(2) = "DNE"
                        'End Try
                        Try
                            dr.Item(3) = StdPropSet.Item("Description").Value.ToString                                  'Record PartDescription property to datarow
                        Catch ex As Exception
                            dr.Item(3) = "DNE"
                        End Try
                        'Try
                        '    dr.Item(4) = SummaryPropSet.Item("Revision Number").Value.ToString                          'Record RevisionNumber property to datarow
                        'Catch ex As Exception
                        '    dr.Item(4) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(5) = CustomPropSet.Item("MakeBuy").Value.ToString                                   'Record MakeBuy property to datarow
                        'Catch ex As Exception
                        '    dr.Item(5) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(6) = CustomPropSet.Item("Material").Value.ToString                                  'Record MaterialDescription property to datarow
                        'Catch ex As Exception
                        '    dr.Item(6) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(7) = StdPropSet.Item("Vendor").Value.ToString                                       'Record Vendor property to datarow
                        'Catch ex As Exception
                        '    dr.Item(7) = "DNE"
                        'End Try
                        Try
                            dr.Item(4) = StdPropSet.Item("Designer").Value.ToString                                  'Record Designed By property to datarow
                        Catch ex As Exception
                            dr.Item(4) = "DNE"
                        End Try
                        Try
                            Dim shortdate1 As Date
                            shortdate1 = StdPropSet.Item("Creation Time").Value.ToString
                            dr.Item(5) = shortdate1.ToShortDateString                                                    'Record DrawingDate property to datarow
                        Catch ex As Exception
                            dr.Item(5) = "DNE"
                        End Try
                        Try
                            dr.Item(6) = StdPropSet.Item("Engr Approved By").Value.ToString                                  'Record Approved By property to datarow
                        Catch ex As Exception
                            dr.Item(6) = "DNE"
                        End Try
                        Try
                            Dim shortdate2 As Date
                            shortdate2 = StdPropSet.Item("Engr Date Approved").Value.ToString
                            dr.Item(7) = shortdate2.ToShortDateString                                                   'Record ApprovedDate property to datarow
                        Catch ex As Exception
                            dr.Item(7) = "DNE"
                        End Try
                        'Try
                        '    dr.Item(9) = StdPropSet.Item("Designer").Value.ToString                                     'Record Designer property to datarow
                        'Catch ex As Exception
                        '    dr.Item(9) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(10) = CustomPropSet.Item("Detailer").Value.ToString                                  'Record Detailer property to datarow
                        'Catch ex As Exception
                        '    dr.Item(10) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(11) = StdPropSet.Item("CheckedBy").Value.ToString                                    'Record CheckedBy property to datarow
                        'Catch ex As Exception
                        '    dr.Item(11) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(12) = params.Item("MB").Value.ToString                                               'Record MakeBuyBoolean parameter to datarow
                        'Catch ex As Exception
                        '    dr.Item(12) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(13) = params.Item("VendorSupplyMtl").Value.ToString                                  'Record VendorSuppliedMtlBoolean parameter to datarow
                        'Catch ex As Exception
                        '    dr.Item(13) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(14) = CustomPropSet.Item("MATERIAL NUMBER").Value.ToString                           'Record EpicorMtlNumber property to datarow
                        'Catch ex As Exception
                        '    dr.Item(14) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(15) = CustomPropSet.Item("MATERIAL DESCRIPTION").Value.ToString                      'Record EpicorMtlDescription property to datarow
                        'Catch ex As Exception
                        '    dr.Item(15) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(16) = params.Item("OP1").Value.ToString                                              'Record Operation1 parameter to datarow
                        'Catch ex As Exception
                        '    dr.Item(16) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(17) = params.Item("OP2").Value.ToString                                              'Record Operation2 parameter to datarow
                        'Catch ex As Exception
                        '    dr.Item(17) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(18) = params.Item("OP3").Value.ToString                                              'Record Operation3 parameter to datarow
                        'Catch ex As Exception
                        '    dr.Item(18) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(19) = params.Item("OP4").Value.ToString                                              'Record Operation4 parameter to datarow
                        'Catch ex As Exception
                        '    dr.Item(19) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(20) = CustomPropSet.Item("OPS").Value.ToString                                       'Record Operations property to datarow
                        'Catch ex As Exception
                        '    dr.Item(20) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(21) = CustomPropSet.Item("LENGTH").Value.ToString                                    'Record MtlLength property to datarow
                        'Catch ex As Exception
                        '    dr.Item(21) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(22) = CustomPropSet.Item("WIDTH").Value.ToString                                       'Record MtlWidth property to datarow
                        'Catch ex As Exception
                        '    dr.Item(22) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(23) = params.Item("XDIM").Value.ToString                                              'Record XLength parameter to datarow
                        'Catch ex As Exception
                        '    dr.Item(23) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(24) = params.Item("YDIM").Value.ToString                                              'Record YLength parameter to datarow
                        'Catch ex As Exception
                        '    dr.Item(24) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(25) = params.Item("ZDIM").Value.ToString                                              'Record ZLength parameter to datarow
                        'Catch ex As Exception
                        '    dr.Item(25) = "DNE"
                        'End Try
                        If Occ.BOMStructure = BOMStructureEnum.kPhantomBOMStructure Then
                            dr.Item(9) = "Phantom"
                        Else
                            dr.Item(9) = ""
                        End If

                        FBOM.Add(PartNumber)
                        bump += 1
                        LoadStatus.Text = "Retrieving Part and Subassembly properties... (" & bump & " reference documents retrieved)"
                    End If

                    'If CustomPropSet.Item("MakeBuy").Value.ToString = "Buy" Then 'If the recorded subassembly is a bought assembly, no need to go through it's subitems.
                    '    GoTo Nref
                    'End If

                    Call GetChildrenProperties(Occ.SubOccurrences, FBOM)

                Else
                    Dim FileName As String = Occ.Definition.Document.FullFileName.ToString
                    Dim FileNamesplit() As String = FileName.Split("\")
                    Dim m As Integer = FileNamesplit.Length
                    Dim PartNumber As String = FileNamesplit(m - 1).Substring(0, FileNamesplit(m - 1).Length - 4)

                    If FBOM.Contains(PartNumber) = vbFalse Then

                        'Dim thumbprop As Inventor.Property
                        'thumbprop = SummaryPropSet.Item("Thumbnail")
                        'Dim pic As stdole.IPictureDisp
                        'pic = thumbprop.Value
                        'Dim img As Image = Compatibility.VB6.IPictureDispToImage(pic)

                        Dim dr As System.Data.DataRow                                                                               'Initialize a datarow
                        ds.Tables("ItemProperties").Rows.Add()                                                          'Add a new row
                        dr = ds.Tables("ItemProperties").Rows(ds.Tables("ItemProperties").Rows.Count - 1)               'Set datarow variable equal to last row

                        dr.Item(0) = FileNamesplit(m - 1)                                                               'Record filename to datarow
                        Try
                            dr.Item(1) = StdPropSet.Item("Part Number").Value.ToString                                  'Record Part Number property to datarow
                        Catch ex As Exception
                            dr.Item(1) = "DNE"
                        End Try
                        'Try
                        '    dr.Item(2) = ""                                                                             'Record Thumbnail image to datarow
                        'Catch ex As Exception
                        '    dr.Item(2) = "DNE"
                        'End Try
                        Try
                            dr.Item(3) = StdPropSet.Item("Description").Value.ToString                                  'Record PartDescription property to datarow
                        Catch ex As Exception
                            dr.Item(3) = "DNE"
                        End Try
                        'Try
                        '    dr.Item(4) = SummaryPropSet.Item("Revision Number").Value.ToString                          'Record RevisionNumber property to datarow
                        'Catch ex As Exception
                        '    dr.Item(4) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(5) = CustomPropSet.Item("MakeBuy").Value.ToString                                   'Record MakeBuy property to datarow
                        'Catch ex As Exception
                        '    dr.Item(5) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(6) = CustomPropSet.Item("Material").Value.ToString                                  'Record MaterialDescription property to datarow
                        'Catch ex As Exception
                        '    dr.Item(6) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(7) = StdPropSet.Item("Vendor").Value.ToString                                       'Record Vendor property to datarow
                        'Catch ex As Exception
                        '    dr.Item(7) = "DNE"
                        'End Try
                        Try
                            dr.Item(4) = StdPropSet.Item("Designer").Value.ToString                                  'Record Designed By property to datarow
                        Catch ex As Exception
                            dr.Item(4) = "DNE"
                        End Try
                        Try
                            Dim shortdate1 As Date
                            shortdate1 = StdPropSet.Item("Creation Time").Value.ToString
                            dr.Item(5) = shortdate1.ToShortDateString                                                    'Record DrawingDate property to datarow
                        Catch ex As Exception
                            dr.Item(5) = "DNE"
                        End Try
                        Try
                            dr.Item(6) = StdPropSet.Item("Engr Approved By").Value.ToString                                  'Record Approved By property to datarow
                        Catch ex As Exception
                            dr.Item(6) = "DNE"
                        End Try
                        Try
                            Dim shortdate2 As Date
                            shortdate2 = StdPropSet.Item("Engr Date Approved").Value.ToString
                            dr.Item(7) = shortdate2.ToShortDateString                                                   'Record ApprovedDate property to datarow
                        Catch ex As Exception
                            dr.Item(7) = "DNE"
                        End Try
                        'Try
                        '    dr.Item(9) = StdPropSet.Item("Designer").Value.ToString                                     'Record Designer property to datarow
                        'Catch ex As Exception
                        '    dr.Item(9) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(10) = CustomPropSet.Item("Detailer").Value.ToString                                  'Record Detailer property to datarow
                        'Catch ex As Exception
                        '    dr.Item(10) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(11) = StdPropSet.Item("CheckedBy").Value.ToString                                    'Record CheckedBy property to datarow
                        'Catch ex As Exception
                        '    dr.Item(11) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(12) = params.Item("MB").Value.ToString                                               'Record MakeBuyBoolean parameter to datarow
                        'Catch ex As Exception
                        '    dr.Item(12) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(13) = params.Item("VendorSupplyMtl").Value.ToString                                  'Record VendorSuppliedMtlBoolean parameter to datarow
                        'Catch ex As Exception
                        '    dr.Item(13) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(14) = CustomPropSet.Item("MATERIAL NUMBER").Value.ToString                           'Record EpicorMtlNumber property to datarow
                        'Catch ex As Exception
                        '    dr.Item(14) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(15) = CustomPropSet.Item("MATERIAL DESCRIPTION").Value.ToString                      'Record EpicorMtlDescription property to datarow
                        'Catch ex As Exception
                        '    dr.Item(15) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(16) = params.Item("OP1").Value.ToString                                              'Record Operation1 parameter to datarow
                        'Catch ex As Exception
                        '    dr.Item(16) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(17) = params.Item("OP2").Value.ToString                                              'Record Operation2 parameter to datarow
                        'Catch ex As Exception
                        '    dr.Item(17) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(18) = params.Item("OP3").Value.ToString                                              'Record Operation3 parameter to datarow
                        'Catch ex As Exception
                        '    dr.Item(18) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(19) = params.Item("OP4").Value.ToString                                              'Record Operation4 parameter to datarow
                        'Catch ex As Exception
                        '    dr.Item(19) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(20) = CustomPropSet.Item("OPS").Value.ToString                                       'Record Operations property to datarow
                        'Catch ex As Exception
                        '    dr.Item(20) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(21) = CustomPropSet.Item("LENGTH").Value.ToString                                    'Record MtlLength property to datarow
                        'Catch ex As Exception
                        '    dr.Item(21) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(22) = CustomPropSet.Item("WIDTH").Value.ToString                                       'Record MtlWidth property to datarow
                        'Catch ex As Exception
                        '    dr.Item(22) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(23) = params.Item("XDIM").Value.ToString                                              'Record XLength parameter to datarow
                        'Catch ex As Exception
                        '    dr.Item(23) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(24) = params.Item("YDIM").Value.ToString                                              'Record YLength parameter to datarow
                        'Catch ex As Exception
                        '    dr.Item(24) = "DNE"
                        'End Try
                        'Try
                        '    dr.Item(25) = params.Item("ZDIM").Value.ToString                                              'Record ZLength parameter to datarow
                        'Catch ex As Exception
                        '    dr.Item(25) = "DNE"
                        'End Try

                        FBOM.Add(PartNumber)
                        bump += 1
                        LoadStatus.Text = "Retrieving Part and Subassembly properties... (" & bump & " reference documents retrieved)"
                    End If

                End If
nxtOcc:
            Next
        End If
    End Sub

    Private Sub dgvBOM_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBOM.CellClick

        SelectedRefDocRow = dgvBOM.SelectedCells.Item(0).RowIndex
        SelectedRefDoc = dgvBOM.Rows.Item(SelectedRefDocRow).Cells.Item(0).Value

        ' Create an expression to find FN = SelectedRefDoc.
        Dim expression As String
        expression = "FN = '" & SelectedRefDoc & "'"

        ' Create a result datarow
        Dim foundRows() As System.Data.DataRow

        ' Use the Select method to find all rows matching the filter.
        foundRows = ds.Tables("ItemProperties").Select(expression)

        Dim i As Integer

        For i = 0 To foundRows.GetUpperBound(0)
            '''''Populate part/assembly information for selected row'''''
            tbPartNumber.Text = foundRows(i)(1)
            tbDescription.Text = foundRows(i)(3)
            'tbMaterialDescription.Text = foundRows(i)(6)
            'tbRevisionNumber.Text = foundRows(i)(4)
            tbDesignedBy.Text = foundRows(i)(4)
            Try
                dtpCreatedDate.Format = DateTimePickerFormat.Short
                dtpCreatedDate.Value = CDate(foundRows(i)(5))
            Catch
                dtpCreatedDate.Value = New Date(2000, 1, 1)
            End Try
            tbApprovedBy.Text = foundRows(i)(6)
            Try
                dtpApprovedDate.Format = DateTimePickerFormat.Short
                dtpApprovedDate.Value = CDate(foundRows(i)(7))
            Catch
                dtpApprovedDate.Value = New Date(2000, 1, 1)
            End Try

            'cbDesigner.Text = foundRows(i)(9)
            'cbDetailer.Text = foundRows(i)(10)
            'cbCheckedBy.Text = foundRows(i)(11)

            'Try
            '    cbMake.Checked = CBool(foundRows(i)(12))
            'Catch ex As Exception

            'End Try

            'cbVendor.Text = foundRows(i)(7)

            'Try
            '    cbVendorSuppliedMtl.Checked = CBool(foundRows(i)(13))
            'Catch ex As Exception

            'End Try
            '''''Populate Epicor information for selected row'''''
            'tbEpicorMtlNumber.Text = foundRows(i)(14)
            'tbEpicorMtlDescription.Text = foundRows(i)(15)
            'cbOp1.Text = foundRows(i)(16)
            'cbOp2.Text = foundRows(i)(17)
            'cbOp3.Text = foundRows(i)(18)
            'cbOp4.Text = foundRows(i)(19)
            'tbOperations.Text = foundRows(i)(20)
            'tbMtlLength.Text = foundRows(i)(21)
            'tbMtlWidth.Text = foundRows(i)(22)
            'tbXLength.Text = foundRows(i)(23)
            'tbYLength.Text = foundRows(i)(24)
            'tbZLength.Text = foundRows(i)(25)

        Next i

    End Sub

    Private Sub btnSet1_Click(sender As Object, e As EventArgs) Handles btnSet1.Click
        For Each rw As DataGridViewRow In dgvBOM.Rows
            Dim cbCELL As DataGridViewCheckBoxCell
            cbCELL = rw.Cells.Item(8)
            If cbCELL.Value = True Then

                ' Create an expression to find FN = SelectedRefDoc.
                Dim expression As String
                expression = "FN = '" & rw.Cells.Item(0).Value & "'"

                ' Create a result datarow
                Dim foundRows() As System.Data.DataRow

                ' Use the Select method to find all rows matching the filter.
                foundRows = ds.Tables("ItemProperties").Select(expression)

                'Change the values for DesignedBy and Creation date in the datatable row
                foundRows(0)(4) = tbDesignedBy.Text
                foundRows(0)(5) = dtpCreatedDate.Value.ToShortDateString

                'Change the values in the DGVrow
                rw.Cells.Item(4).Value = tbDesignedBy.Text
                rw.Cells.Item(5).Value = dtpCreatedDate.Value.ToShortDateString

                'Re-check values and color appropriately
                If rw.Cells.Item(4).Value = "DNE" Then
                    rw.Cells.Item(4).Style.BackColor = System.Drawing.Color.Coral
                Else
                    rw.Cells.Item(4).Style.BackColor = System.Drawing.Color.White
                End If
                If rw.Cells.Item(5).Value = "DNE" Or rw.Cells.Item(5).Value = "1/1/1601" Then
                    rw.Cells.Item(5).Style.BackColor = System.Drawing.Color.Coral
                Else
                    rw.Cells.Item(5).Style.BackColor = System.Drawing.Color.White
                End If
            End If
        Next
    End Sub

    Private Sub btnSet2_Click(sender As Object, e As EventArgs) Handles btnSet2.Click
        For Each rw As DataGridViewRow In dgvBOM.Rows
            Dim cbCELL As DataGridViewCheckBoxCell
            cbCELL = rw.Cells.Item(8)
            If cbCELL.Value = True Then

                ' Create an expression to find FN = SelectedRefDoc.
                Dim expression As String
                expression = "FN = '" & rw.Cells.Item(0).Value & "'"

                ' Create a result datarow
                Dim foundRows() As System.Data.DataRow

                ' Use the Select method to find all rows matching the filter.
                foundRows = ds.Tables("ItemProperties").Select(expression)

                'Change the values for DesignedBy and Creation date in the datatable row
                foundRows(0)(6) = tbApprovedBy.Text
                foundRows(0)(7) = dtpApprovedDate.Value.ToShortDateString

                'Change the values in the DGVrow
                rw.Cells.Item(6).Value = tbApprovedBy.Text
                rw.Cells.Item(7).Value = dtpApprovedDate.Value.ToShortDateString

                'Re-check values and color appropriately
                If rw.Cells.Item(6).Value = "DNE" Then
                    rw.Cells.Item(6).Style.BackColor = System.Drawing.Color.Coral
                Else
                    rw.Cells.Item(6).Style.BackColor = System.Drawing.Color.White
                End If
                If rw.Cells.Item(7).Value = "DNE" Or rw.Cells.Item(7).Value = "1/1/1601" Then
                    rw.Cells.Item(7).Style.BackColor = System.Drawing.Color.Coral
                Else
                    rw.Cells.Item(7).Style.BackColor = System.Drawing.Color.White
                End If
            End If
        Next
    End Sub

    Private Sub Label24_DoubleClick(sender As Object, e As EventArgs) Handles Label24.DoubleClick
        Dim newdate1 As Date = New Date(2017, 10, 20)
        dtpCreatedDate.Value = newdate1            'Set the shortcut for the Creation date
    End Sub
    Private Sub Label25_DoubleClick(sender As Object, e As EventArgs) Handles Label25.DoubleClick
        Dim newdate2 As Date = New Date(2018, 3, 20)
        dtpApprovedDate.Value = newdate2             'Set the shortcut for the Approved date
        tbApprovedBy.Text = "A. YEAGER"
    End Sub

    Private Sub btnBATCH_Click(sender As Object, e As EventArgs) Handles btnBATCH.Click
        'get user approval
        If MessageBox.Show("This will modify the created and approved date properties for each document as well as insert a new template for associated drawing documents." _
                    & vbLf & "This command expects that the drawing file shares the same name and location as the part/assembly document." _
                    & vbLf & "Please perform a GET operation from within Vault prior to continuing to ensure you are working with the most up-to-date documents." _
                    & vbLf & " " _
                    & vbLf & "Are you sure you want to continue?", "BATCH CHANGE TEMPLATE AND PROPERTIES", MessageBoxButtons.YesNo) = vbNo Then
            Exit Sub
        End If

        For Each rw As DataGridViewRow In dgvBOM.Rows
            Dim cbCELL As DataGridViewCheckBoxCell
            cbCELL = rw.Cells.Item(8)
            If cbCELL.Value = True Then
                'MsgBox("HIT on " & rw.Cells.Item(0).Value.ToString)

                Dim oDoc As AssemblyDocument
                oDoc = invApp.ActiveDocument
                Dim filename As String = invApp.ActiveDocument.DisplayName
                Dim filenameonly As String = filename.Substring(0, filename.Length - 4)

                'Dim VaultAddin As Inventor.ApplicationAddIn = invApp.ApplicationAddIns.ItemById("{48B682BC-42E6-4953-84C5-3D253B52E77B}")
                'VaultAddin.Deactivate()

                '- - - - - - - - - - - - -Component Drawings - - - - - - - - - - - -'look at the files referenced by the assembly
                Dim oRefDoc As Document
                Dim idwPathName As String
                'Dim drawingname As String
                Dim oNVM As NameValueMap
                oNVM = invApp.TransientObjects.CreateNameValueMap

                '	For Each oRefDoc In oRefDocs = oAsmDoc.AllReferencedDocuments
                For Each oRefDoc In oDoc.AllReferencedDocuments

                    Dim Fname As String = oRefDoc.FullDocumentName
                    Dim Fnamesplit() As String = Fname.Split("\")
                    Dim m As Integer = Fnamesplit.Length
                    Dim refPartNumber As String = Fnamesplit(m - 1).Substring(0, Fnamesplit(m - 1).Length - 4)
                    If refPartNumber = rw.Cells.Item(1).Value.ToString Then                 'If the partnumbers match then process the property update and the drawing open,update,save&close
                        '1.) Change date properties

                        ' Get the PropertySets object. 
                        Dim oPropSets As PropertySets
                        oPropSets = oRefDoc.PropertySets

                        ' Get the design tracking property set. 
                        Dim oPropSet As Inventor.PropertySet
                        oPropSet = oPropSets.Item("Design Tracking Properties")

                        ' Get the Creation Date iProperty. 
                        Dim CreationDate As Inventor.Property
                        CreationDate = oPropSet.Item("Creation Time")
                        ' Get the Designer iProperty. 
                        Dim Designer As Inventor.Property
                        Designer = oPropSet.Item("Designer")

                        ' Get the Approved Date iProperty. 
                        Dim ApprovedDate As Inventor.Property
                        ApprovedDate = oPropSet.Item("Engr Date Approved")
                        ' Get the Approved By iProperty. 
                        Dim ApprovedBy As Inventor.Property
                        ApprovedBy = oPropSet.Item("Engr Approved By")

                        ' Set the Creation Date and Designer
                        Designer.Value = rw.Cells.Item(4).Value.ToString
                        CreationDate.Value = CDate(rw.Cells.Item(5).Value.ToString)

                        ' Set the Approved Date and Approver
                        ApprovedBy.Value = rw.Cells.Item(6).Value.ToString
                        ApprovedDate.Value = CDate(rw.Cells.Item(7).Value.ToString)

                        '2.) Open drawing if it exists in same location as part/assembly file

                        idwPathName = oRefDoc.FullDocumentName.Substring(0, Len(oRefDoc.FullDocumentName) - 3) & "dwg"
                        If (System.IO.File.Exists(idwPathName)) Then
                            Dim oDrawDoc As DrawingDocument
                            oDrawDoc = invApp.Documents.OpenWithOptions(idwPathName, oNVM, True)
                            'drawingname = oRefDoc.DisplayName.Substring(0, Len(oRefDoc.DisplayName) - 3)

                            '3.) Update all sheet title blocks and refresh drawing

                            Dim oTemplate As DrawingDocument
                            Dim oSourceCoverSheetBlockDef As TitleBlockDefinition
                            Dim oSourceMainSheetBlockDef As TitleBlockDefinition
                            Dim oSource2ndSheetBlockDef As TitleBlockDefinition
                            Dim oNewCoverSheetBlockDef As TitleBlockDefinition
                            Dim oNewMainSheetBlockDef As TitleBlockDefinition
                            Dim oNew2ndSheetBlockDef As TitleBlockDefinition
                            Dim oSheet As Sheet

                            Fname = "Waterworld Master_Metric.dwg"
                            oTemplate = invApp.Documents.OpenWithOptions("C:\_vaultWIP\Designs\Templates\Universal\" & Fname, oNVM, False)
                            oSourceCoverSheetBlockDef = oTemplate.TitleBlockDefinitions.Item("Waterworld Cover Sheet TB")
                            oSourceMainSheetBlockDef = oTemplate.TitleBlockDefinitions.Item("Waterworld TB")
                            oSource2ndSheetBlockDef = oTemplate.TitleBlockDefinitions.Item("Waterworld TB SHT2")

                            'oNewTitleBlockDef = oSourceTitleBlockDef.CopyTo(oDrawDoc, True)
                            ' Iterate through the sheets.
                            For Each oSheet In oDrawDoc.Sheets
                                oSheet.Activate() 'Activate sheet
                                If oSheet.TitleBlock.Definition.Name = "Waterworld Cover Sheet TB" Then
                                    'MsgBox("Hit cover sheet change.")
                                    Try
                                        oNewCoverSheetBlockDef = oSourceCoverSheetBlockDef.CopyTo(oDrawDoc, True)
                                        oSheet.TitleBlock.Delete()
                                        oSheet.AddTitleBlock(oNewCoverSheetBlockDef)
                                    Catch ex As Exception
                                        MsgBox("Error inserting Cover Sheet title block.")
                                    End Try

                                ElseIf oSheet.TitleBlock.Definition.Name = "Waterworld TB" Then
                                    'MsgBox("Hit main sheet change.")
                                    Try
                                        oNewMainSheetBlockDef = oSourceMainSheetBlockDef.CopyTo(oDrawDoc, True)
                                        oSheet.TitleBlock.Delete()
                                        oSheet.AddTitleBlock(oNewMainSheetBlockDef)
                                    Catch ex As Exception
                                        MsgBox("Error inserting Main Sheet title block.")
                                    End Try

                                ElseIf oSheet.TitleBlock.Definition.Name = "Waterworld TB SHT2" Then
                                    'MsgBox("Hit 2nd sheet change.")
                                    Try
                                        oNew2ndSheetBlockDef = oSource2ndSheetBlockDef.CopyTo(oDrawDoc, True)
                                        oSheet.TitleBlock.Delete()
                                        oSheet.AddTitleBlock(oNew2ndSheetBlockDef)
                                    Catch ex As Exception
                                        MsgBox("Error inserting 2nd Sheet title block.")
                                    End Try

                                Else
                                    MsgBox("Could not identify existing title block definition for: " & filenameonly & " .")
                                End If
                            Next
                            oTemplate.Close(True)

                            '4.) Close and Save
                            oDrawDoc.Close(False)
                        Else
                            '2a.) Exit loop if doesn't exist
                            GoTo NXT
                        End If

NXT:
                    End If

                Next
                '- - - - - - - - - - - - -

                'VaultAddin.Activate()
            End If
        Next
        MsgBox("DONE BATCH PROCESS")
    End Sub
End Class