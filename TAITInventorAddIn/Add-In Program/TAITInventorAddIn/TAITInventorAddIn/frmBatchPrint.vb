Public Class frmBatchPrint
    Dim PDFcheck As Boolean
    Dim DWGcheck As Boolean
    Dim DXFcheck As Boolean
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub cbPrintPDF_CheckedChanged(sender As Object, e As EventArgs) Handles cbPrintPDF.CheckedChanged
        If cbPrintPDF.Checked = True Then
            PDFcheck = 1
        Else
            PDFcheck = 0
        End If
    End Sub

    Private Sub cbPrintDWG_CheckedChanged(sender As Object, e As EventArgs) Handles cbPrintDWG.CheckedChanged
        If cbPrintDWG.Checked = True Then
            DWGcheck = 1
        Else
            DWGcheck = 0
        End If
    End Sub

    Private Sub cbPrintDXF_CheckedChanged(sender As Object, e As EventArgs) Handles cbPrintDXF.CheckedChanged
        If cbPrintDXF.Checked = True Then
            DXFcheck = 1
        Else
            DXFcheck = 0
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        cbCancel.Checked = True
        Me.Close()
    End Sub

    Private Sub btnBatchPrint_Click(sender As Object, e As EventArgs) Handles btnBatchPrint.Click
        cbCancel.Checked = False
        Me.Close()
    End Sub

End Class