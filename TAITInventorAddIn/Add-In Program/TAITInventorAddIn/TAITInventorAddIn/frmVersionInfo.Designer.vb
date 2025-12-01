<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVersionManager
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbVersionLibrary = New System.Windows.Forms.ListBox()
        Me.btnRevertToSelected = New System.Windows.Forms.Button()
        Me.btnCloseVersionManager = New System.Windows.Forms.Button()
        Me.btnUpdateToLatest = New System.Windows.Forms.Button()
        Me.lblUpdateStatus = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'lbVersionLibrary
        '
        Me.lbVersionLibrary.FormattingEnabled = True
        Me.lbVersionLibrary.Location = New System.Drawing.Point(6, 19)
        Me.lbVersionLibrary.Name = "lbVersionLibrary"
        Me.lbVersionLibrary.Size = New System.Drawing.Size(121, 134)
        Me.lbVersionLibrary.TabIndex = 1
        '
        'btnRevertToSelected
        '
        Me.btnRevertToSelected.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnRevertToSelected.Location = New System.Drawing.Point(6, 158)
        Me.btnRevertToSelected.Name = "btnRevertToSelected"
        Me.btnRevertToSelected.Size = New System.Drawing.Size(121, 37)
        Me.btnRevertToSelected.TabIndex = 3
        Me.btnRevertToSelected.Text = "Revert to Selected"
        Me.btnRevertToSelected.UseVisualStyleBackColor = False
        '
        'btnCloseVersionManager
        '
        Me.btnCloseVersionManager.BackColor = System.Drawing.Color.Salmon
        Me.btnCloseVersionManager.Location = New System.Drawing.Point(336, 247)
        Me.btnCloseVersionManager.Name = "btnCloseVersionManager"
        Me.btnCloseVersionManager.Size = New System.Drawing.Size(120, 37)
        Me.btnCloseVersionManager.TabIndex = 6
        Me.btnCloseVersionManager.Text = "Close"
        Me.btnCloseVersionManager.UseVisualStyleBackColor = False
        '
        'btnUpdateToLatest
        '
        Me.btnUpdateToLatest.BackColor = System.Drawing.Color.LimeGreen
        Me.btnUpdateToLatest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateToLatest.Location = New System.Drawing.Point(33, 92)
        Me.btnUpdateToLatest.Name = "btnUpdateToLatest"
        Me.btnUpdateToLatest.Size = New System.Drawing.Size(233, 33)
        Me.btnUpdateToLatest.TabIndex = 5
        Me.btnUpdateToLatest.Text = "Update Button"
        Me.btnUpdateToLatest.UseVisualStyleBackColor = False
        Me.btnUpdateToLatest.Visible = False
        '
        'lblUpdateStatus
        '
        Me.lblUpdateStatus.AutoSize = True
        Me.lblUpdateStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdateStatus.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblUpdateStatus.Location = New System.Drawing.Point(56, 57)
        Me.lblUpdateStatus.Name = "lblUpdateStatus"
        Me.lblUpdateStatus.Size = New System.Drawing.Size(191, 32)
        Me.lblUpdateStatus.TabIndex = 4
        Me.lblUpdateStatus.Text = "A new version exists!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Update to newest version?"
        Me.lblUpdateStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblUpdateStatus.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblUpdateStatus)
        Me.GroupBox1.Controls.Add(Me.btnUpdateToLatest)
        Me.GroupBox1.Location = New System.Drawing.Point(159, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 204)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Update Available?"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lbVersionLibrary)
        Me.GroupBox2.Controls.Add(Me.btnRevertToSelected)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 37)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(141, 241)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Version Library"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(14, 201)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 26)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "*Will terminate all" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Inventor applications"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmVersionManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 290)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCloseVersionManager)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmVersionManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TAIT Inventor Add-In Version Manager"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents lbVersionLibrary As Windows.Forms.ListBox
    Friend WithEvents btnRevertToSelected As Windows.Forms.Button
    Friend WithEvents btnCloseVersionManager As Windows.Forms.Button
    Friend WithEvents btnUpdateToLatest As Windows.Forms.Button
    Friend WithEvents lblUpdateStatus As Windows.Forms.Label
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents Label2 As Windows.Forms.Label
End Class
