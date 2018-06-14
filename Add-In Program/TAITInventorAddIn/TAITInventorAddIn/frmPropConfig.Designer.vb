<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPropConfig
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPropConfig))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbProjects = New System.Windows.Forms.ComboBox()
        Me.cmbElements = New System.Windows.Forms.ComboBox()
        Me.cmbDesigners = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpDesignedDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpCheckedDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbCheckers = New System.Windows.Forms.ComboBox()
        Me.dtpApprovedDate = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbApprovers = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbRevNo = New System.Windows.Forms.TextBox()
        Me.tbUsedOn = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbNextAssy = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbBuildingNo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbProjName = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tbProjNo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnCloseCancel = New System.Windows.Forms.Button()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.tbVendor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbMaterial = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ttUsedOn = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Project"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Element"
        '
        'cmbProjects
        '
        Me.cmbProjects.FormattingEnabled = True
        Me.cmbProjects.Location = New System.Drawing.Point(103, 6)
        Me.cmbProjects.Name = "cmbProjects"
        Me.cmbProjects.Size = New System.Drawing.Size(223, 21)
        Me.cmbProjects.TabIndex = 3
        '
        'cmbElements
        '
        Me.cmbElements.FormattingEnabled = True
        Me.cmbElements.Location = New System.Drawing.Point(103, 33)
        Me.cmbElements.Name = "cmbElements"
        Me.cmbElements.Size = New System.Drawing.Size(223, 21)
        Me.cmbElements.TabIndex = 4
        '
        'cmbDesigners
        '
        Me.cmbDesigners.FormattingEnabled = True
        Me.cmbDesigners.Location = New System.Drawing.Point(103, 84)
        Me.cmbDesigners.Name = "cmbDesigners"
        Me.cmbDesigners.Size = New System.Drawing.Size(223, 21)
        Me.cmbDesigners.Sorted = True
        Me.cmbDesigners.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Designed By"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(343, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Designed Date"
        '
        'dtpDesignedDate
        '
        Me.dtpDesignedDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesignedDate.Location = New System.Drawing.Point(427, 84)
        Me.dtpDesignedDate.Name = "dtpDesignedDate"
        Me.dtpDesignedDate.Size = New System.Drawing.Size(123, 20)
        Me.dtpDesignedDate.TabIndex = 9
        '
        'dtpCheckedDate
        '
        Me.dtpCheckedDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCheckedDate.Location = New System.Drawing.Point(427, 111)
        Me.dtpCheckedDate.Name = "dtpCheckedDate"
        Me.dtpCheckedDate.Size = New System.Drawing.Size(123, 20)
        Me.dtpCheckedDate.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(343, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Checked Date"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 114)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Checked By"
        '
        'cmbCheckers
        '
        Me.cmbCheckers.FormattingEnabled = True
        Me.cmbCheckers.Location = New System.Drawing.Point(103, 111)
        Me.cmbCheckers.Name = "cmbCheckers"
        Me.cmbCheckers.Size = New System.Drawing.Size(223, 21)
        Me.cmbCheckers.Sorted = True
        Me.cmbCheckers.TabIndex = 10
        '
        'dtpApprovedDate
        '
        Me.dtpApprovedDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpApprovedDate.Location = New System.Drawing.Point(427, 138)
        Me.dtpApprovedDate.Name = "dtpApprovedDate"
        Me.dtpApprovedDate.Size = New System.Drawing.Size(123, 20)
        Me.dtpApprovedDate.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(343, 141)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Approved Date"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 141)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Approved By"
        '
        'cmbApprovers
        '
        Me.cmbApprovers.FormattingEnabled = True
        Me.cmbApprovers.Location = New System.Drawing.Point(103, 138)
        Me.cmbApprovers.Name = "cmbApprovers"
        Me.cmbApprovers.Size = New System.Drawing.Size(223, 21)
        Me.cmbApprovers.Sorted = True
        Me.cmbApprovers.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 168)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Revision No."
        '
        'tbRevNo
        '
        Me.tbRevNo.Location = New System.Drawing.Point(103, 165)
        Me.tbRevNo.Name = "tbRevNo"
        Me.tbRevNo.Size = New System.Drawing.Size(40, 20)
        Me.tbRevNo.TabIndex = 19
        '
        'tbUsedOn
        '
        Me.tbUsedOn.Location = New System.Drawing.Point(103, 191)
        Me.tbUsedOn.Name = "tbUsedOn"
        Me.tbUsedOn.ShortcutsEnabled = False
        Me.tbUsedOn.Size = New System.Drawing.Size(125, 20)
        Me.tbUsedOn.TabIndex = 21
        Me.ttUsedOn.SetToolTip(Me.tbUsedOn, "The Element the part/asm is used on.")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 194)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Used On"
        '
        'tbNextAssy
        '
        Me.tbNextAssy.Location = New System.Drawing.Point(103, 217)
        Me.tbNextAssy.Name = "tbNextAssy"
        Me.tbNextAssy.Size = New System.Drawing.Size(125, 20)
        Me.tbNextAssy.TabIndex = 23
        Me.ttUsedOn.SetToolTip(Me.tbNextAssy, "The kit/subassembly/weldment the part is used on.")
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 220)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Next Assy"
        '
        'tbBuildingNo
        '
        Me.tbBuildingNo.Enabled = False
        Me.tbBuildingNo.Location = New System.Drawing.Point(427, 58)
        Me.tbBuildingNo.Name = "tbBuildingNo"
        Me.tbBuildingNo.Size = New System.Drawing.Size(91, 20)
        Me.tbBuildingNo.TabIndex = 29
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(343, 61)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 13)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "Bulding No."
        '
        'tbProjName
        '
        Me.tbProjName.Enabled = False
        Me.tbProjName.Location = New System.Drawing.Point(427, 32)
        Me.tbProjName.Name = "tbProjName"
        Me.tbProjName.Size = New System.Drawing.Size(182, 20)
        Me.tbProjName.TabIndex = 27
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(343, 35)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(71, 13)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Project Name"
        '
        'tbProjNo
        '
        Me.tbProjNo.Enabled = False
        Me.tbProjNo.Location = New System.Drawing.Point(427, 6)
        Me.tbProjNo.Name = "tbProjNo"
        Me.tbProjNo.Size = New System.Drawing.Size(182, 20)
        Me.tbProjNo.TabIndex = 25
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(343, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 13)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "Project No."
        '
        'btnCloseCancel
        '
        Me.btnCloseCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnCloseCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCloseCancel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseCancel.Location = New System.Drawing.Point(470, 218)
        Me.btnCloseCancel.Name = "btnCloseCancel"
        Me.btnCloseCancel.Size = New System.Drawing.Size(139, 39)
        Me.btnCloseCancel.TabIndex = 144
        Me.btnCloseCancel.Text = "Cancel"
        Me.btnCloseCancel.UseVisualStyleBackColor = False
        '
        'btnApply
        '
        Me.btnApply.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnApply.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApply.Location = New System.Drawing.Point(325, 218)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(139, 39)
        Me.btnApply.TabIndex = 143
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = False
        '
        'tbVendor
        '
        Me.tbVendor.Location = New System.Drawing.Point(427, 164)
        Me.tbVendor.Name = "tbVendor"
        Me.tbVendor.Size = New System.Drawing.Size(182, 20)
        Me.tbVendor.TabIndex = 146
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(343, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 145
        Me.Label3.Text = "Vendor"
        '
        'tbMaterial
        '
        Me.tbMaterial.Enabled = False
        Me.tbMaterial.Location = New System.Drawing.Point(307, 190)
        Me.tbMaterial.Name = "tbMaterial"
        Me.tbMaterial.Size = New System.Drawing.Size(277, 20)
        Me.tbMaterial.TabIndex = 148
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(260, 194)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 13)
        Me.Label16.TabIndex = 147
        Me.Label16.Text = "Material"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.BackgroundImage = Global.TAITInventorAddIn.My.Resources.Resources.materialpic
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(590, 190)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 22)
        Me.Button1.TabIndex = 149
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frmPropConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 269)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tbMaterial)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.tbVendor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCloseCancel)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.tbBuildingNo)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.tbProjName)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tbProjNo)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.tbNextAssy)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.tbUsedOn)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tbRevNo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.dtpApprovedDate)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmbApprovers)
        Me.Controls.Add(Me.dtpCheckedDate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmbCheckers)
        Me.Controls.Add(Me.dtpDesignedDate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbDesigners)
        Me.Controls.Add(Me.cmbElements)
        Me.Controls.Add(Me.cmbProjects)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPropConfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modify Document Properties"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents cmbProjects As Windows.Forms.ComboBox
    Friend WithEvents cmbElements As Windows.Forms.ComboBox
    Friend WithEvents cmbDesigners As Windows.Forms.ComboBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents dtpDesignedDate As Windows.Forms.DateTimePicker
    Friend WithEvents dtpCheckedDate As Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents cmbCheckers As Windows.Forms.ComboBox
    Friend WithEvents dtpApprovedDate As Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents cmbApprovers As Windows.Forms.ComboBox
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents tbRevNo As Windows.Forms.TextBox
    Friend WithEvents tbUsedOn As Windows.Forms.TextBox
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents tbNextAssy As Windows.Forms.TextBox
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents tbBuildingNo As Windows.Forms.TextBox
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents tbProjName As Windows.Forms.TextBox
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents tbProjNo As Windows.Forms.TextBox
    Friend WithEvents Label15 As Windows.Forms.Label
    Friend WithEvents btnCloseCancel As Windows.Forms.Button
    Friend WithEvents btnApply As Windows.Forms.Button
    Friend WithEvents tbVendor As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents tbMaterial As Windows.Forms.TextBox
    Friend WithEvents Label16 As Windows.Forms.Label
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents ttUsedOn As Windows.Forms.ToolTip
End Class
