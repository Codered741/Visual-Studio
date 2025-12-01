<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBatchPrint
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBatchPrint))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbPrintDXF = New System.Windows.Forms.CheckBox()
        Me.cbPrintDWG = New System.Windows.Forms.CheckBox()
        Me.cbPrintPDF = New System.Windows.Forms.CheckBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnBatchPrint = New System.Windows.Forms.Button()
        Me.cbCancel = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 7)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(673, 78)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'cbPrintDXF
        '
        Me.cbPrintDXF.AutoSize = True
        Me.cbPrintDXF.Checked = True
        Me.cbPrintDXF.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbPrintDXF.Location = New System.Drawing.Point(11, 136)
        Me.cbPrintDXF.Margin = New System.Windows.Forms.Padding(2)
        Me.cbPrintDXF.Name = "cbPrintDXF"
        Me.cbPrintDXF.Size = New System.Drawing.Size(47, 17)
        Me.cbPrintDXF.TabIndex = 2
        Me.cbPrintDXF.Text = "DXF"
        Me.cbPrintDXF.UseVisualStyleBackColor = True
        '
        'cbPrintDWG
        '
        Me.cbPrintDWG.AutoSize = True
        Me.cbPrintDWG.Checked = True
        Me.cbPrintDWG.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbPrintDWG.Location = New System.Drawing.Point(11, 115)
        Me.cbPrintDWG.Margin = New System.Windows.Forms.Padding(2)
        Me.cbPrintDWG.Name = "cbPrintDWG"
        Me.cbPrintDWG.Size = New System.Drawing.Size(53, 17)
        Me.cbPrintDWG.TabIndex = 1
        Me.cbPrintDWG.Text = "DWG"
        Me.cbPrintDWG.UseVisualStyleBackColor = True
        '
        'cbPrintPDF
        '
        Me.cbPrintPDF.AutoSize = True
        Me.cbPrintPDF.Checked = True
        Me.cbPrintPDF.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbPrintPDF.Location = New System.Drawing.Point(11, 93)
        Me.cbPrintPDF.Margin = New System.Windows.Forms.Padding(2)
        Me.cbPrintPDF.Name = "cbPrintPDF"
        Me.cbPrintPDF.Size = New System.Drawing.Size(47, 17)
        Me.cbPrintPDF.TabIndex = 0
        Me.cbPrintPDF.Text = "PDF"
        Me.cbPrintPDF.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.LightCoral
        Me.btnCancel.Location = New System.Drawing.Point(477, 131)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(79, 28)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnBatchPrint
        '
        Me.btnBatchPrint.BackColor = System.Drawing.Color.LightGreen
        Me.btnBatchPrint.Location = New System.Drawing.Point(560, 89)
        Me.btnBatchPrint.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBatchPrint.Name = "btnBatchPrint"
        Me.btnBatchPrint.Size = New System.Drawing.Size(109, 70)
        Me.btnBatchPrint.TabIndex = 3
        Me.btnBatchPrint.Text = "Print -->"
        Me.btnBatchPrint.UseVisualStyleBackColor = False
        '
        'cbCancel
        '
        Me.cbCancel.AutoSize = True
        Me.cbCancel.Location = New System.Drawing.Point(398, 142)
        Me.cbCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.cbCancel.Name = "cbCancel"
        Me.cbCancel.Size = New System.Drawing.Size(70, 17)
        Me.cbCancel.TabIndex = 4
        Me.cbCancel.Text = "canceled"
        Me.cbCancel.UseVisualStyleBackColor = True
        Me.cbCancel.Visible = False
        '
        'frmBatchPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 169)
        Me.Controls.Add(Me.cbCancel)
        Me.Controls.Add(Me.cbPrintDXF)
        Me.Controls.Add(Me.btnBatchPrint)
        Me.Controls.Add(Me.cbPrintDWG)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.cbPrintPDF)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmBatchPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Batch Print?"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents cbPrintDXF As Windows.Forms.CheckBox
    Friend WithEvents cbPrintDWG As Windows.Forms.CheckBox
    Friend WithEvents cbPrintPDF As Windows.Forms.CheckBox
    Friend WithEvents btnCancel As Windows.Forms.Button
    Friend WithEvents btnBatchPrint As Windows.Forms.Button
    Friend WithEvents cbCancel As Windows.Forms.CheckBox
End Class
