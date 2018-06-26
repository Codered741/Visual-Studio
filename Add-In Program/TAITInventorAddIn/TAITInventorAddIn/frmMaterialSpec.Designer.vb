<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMaterialSpec
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaterialSpec))
        Me.col1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbComments = New System.Windows.Forms.TextBox()
        Me.lbShapes = New System.Windows.Forms.ListBox()
        Me.lbMaterials = New System.Windows.Forms.ListBox()
        Me.btnMaterialFlowChart = New System.Windows.Forms.Button()
        Me.nudD3 = New System.Windows.Forms.NumericUpDown()
        Me.nudD2 = New System.Windows.Forms.NumericUpDown()
        Me.nudD1 = New System.Windows.Forms.NumericUpDown()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblCurrentMaterialDescription = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblMaterialDescription = New System.Windows.Forms.Label()
        Me.lvGrades = New System.Windows.Forms.ListView()
        Me.btnCloseCancel = New System.Windows.Forms.Button()
        Me.lblX1 = New System.Windows.Forms.Label()
        Me.lblX2 = New System.Windows.Forms.Label()
        Me.lblD3 = New System.Windows.Forms.Label()
        Me.lblD2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.lblD1 = New System.Windows.Forms.Label()
        Me.lblDims = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.rbImperial = New System.Windows.Forms.RadioButton()
        Me.rbMetric = New System.Windows.Forms.RadioButton()
        Me.Units = New System.Windows.Forms.GroupBox()
        CType(Me.nudD3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudD2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudD1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Units.SuspendLayout()
        Me.SuspendLayout()
        '
        'col1
        '
        Me.col1.Text = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(547, 67)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 15)
        Me.Label9.TabIndex = 152
        Me.Label9.Text = "Comments"
        '
        'tbComments
        '
        Me.tbComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbComments.Location = New System.Drawing.Point(547, 84)
        Me.tbComments.Multiline = True
        Me.tbComments.Name = "tbComments"
        Me.tbComments.ReadOnly = True
        Me.tbComments.Size = New System.Drawing.Size(171, 57)
        Me.tbComments.TabIndex = 151
        '
        'lbShapes
        '
        Me.lbShapes.FormattingEnabled = True
        Me.lbShapes.Location = New System.Drawing.Point(189, 67)
        Me.lbShapes.Name = "lbShapes"
        Me.lbShapes.Size = New System.Drawing.Size(173, 147)
        Me.lbShapes.TabIndex = 150
        '
        'lbMaterials
        '
        Me.lbMaterials.FormattingEnabled = True
        Me.lbMaterials.Location = New System.Drawing.Point(10, 67)
        Me.lbMaterials.Name = "lbMaterials"
        Me.lbMaterials.Size = New System.Drawing.Size(173, 147)
        Me.lbMaterials.TabIndex = 149
        '
        'btnMaterialFlowChart
        '
        Me.btnMaterialFlowChart.Location = New System.Drawing.Point(547, 150)
        Me.btnMaterialFlowChart.Name = "btnMaterialFlowChart"
        Me.btnMaterialFlowChart.Size = New System.Drawing.Size(171, 64)
        Me.btnMaterialFlowChart.TabIndex = 148
        Me.btnMaterialFlowChart.Text = "Structural Material Selection Flow Chart"
        Me.btnMaterialFlowChart.UseVisualStyleBackColor = True
        '
        'nudD3
        '
        Me.nudD3.Cursor = System.Windows.Forms.Cursors.Default
        Me.nudD3.DecimalPlaces = 3
        Me.nudD3.Increment = New Decimal(New Integer() {125, 0, 0, 196608})
        Me.nudD3.Location = New System.Drawing.Point(254, 265)
        Me.nudD3.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudD3.Name = "nudD3"
        Me.nudD3.Size = New System.Drawing.Size(85, 20)
        Me.nudD3.TabIndex = 147
        Me.nudD3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudD3.ThousandsSeparator = True
        '
        'nudD2
        '
        Me.nudD2.Cursor = System.Windows.Forms.Cursors.Default
        Me.nudD2.DecimalPlaces = 3
        Me.nudD2.Increment = New Decimal(New Integer() {125, 0, 0, 196608})
        Me.nudD2.Location = New System.Drawing.Point(143, 265)
        Me.nudD2.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudD2.Name = "nudD2"
        Me.nudD2.Size = New System.Drawing.Size(85, 20)
        Me.nudD2.TabIndex = 146
        Me.nudD2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudD2.ThousandsSeparator = True
        '
        'nudD1
        '
        Me.nudD1.Cursor = System.Windows.Forms.Cursors.Default
        Me.nudD1.DecimalPlaces = 3
        Me.nudD1.Increment = New Decimal(New Integer() {125, 0, 0, 196608})
        Me.nudD1.Location = New System.Drawing.Point(28, 265)
        Me.nudD1.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudD1.Name = "nudD1"
        Me.nudD1.Size = New System.Drawing.Size(85, 20)
        Me.nudD1.TabIndex = 145
        Me.nudD1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudD1.ThousandsSeparator = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblCurrentMaterialDescription)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(10, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(708, 51)
        Me.Panel2.TabIndex = 144
        '
        'lblCurrentMaterialDescription
        '
        Me.lblCurrentMaterialDescription.AutoSize = True
        Me.lblCurrentMaterialDescription.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentMaterialDescription.Location = New System.Drawing.Point(181, 13)
        Me.lblCurrentMaterialDescription.Name = "lblCurrentMaterialDescription"
        Me.lblCurrentMaterialDescription.Size = New System.Drawing.Size(194, 16)
        Me.lblCurrentMaterialDescription.TabIndex = 22
        Me.lblCurrentMaterialDescription.Text = "lblCurrentMaterialDescription"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 15)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Current Material Description:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 15)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "New Material Description:"
        '
        'lblMaterialDescription
        '
        Me.lblMaterialDescription.AutoSize = True
        Me.lblMaterialDescription.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaterialDescription.Location = New System.Drawing.Point(183, 16)
        Me.lblMaterialDescription.Name = "lblMaterialDescription"
        Me.lblMaterialDescription.Size = New System.Drawing.Size(147, 16)
        Me.lblMaterialDescription.TabIndex = 33
        Me.lblMaterialDescription.Text = "lblMaterialDescription"
        '
        'lvGrades
        '
        Me.lvGrades.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col1})
        Me.lvGrades.FullRowSelect = True
        Me.lvGrades.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvGrades.HideSelection = False
        Me.lvGrades.Location = New System.Drawing.Point(368, 67)
        Me.lvGrades.MultiSelect = False
        Me.lvGrades.Name = "lvGrades"
        Me.lvGrades.Size = New System.Drawing.Size(173, 147)
        Me.lvGrades.TabIndex = 153
        Me.lvGrades.UseCompatibleStateImageBehavior = False
        Me.lvGrades.View = System.Windows.Forms.View.Details
        '
        'btnCloseCancel
        '
        Me.btnCloseCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnCloseCancel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseCancel.Location = New System.Drawing.Point(579, 352)
        Me.btnCloseCancel.Name = "btnCloseCancel"
        Me.btnCloseCancel.Size = New System.Drawing.Size(139, 39)
        Me.btnCloseCancel.TabIndex = 142
        Me.btnCloseCancel.Text = "Cancel"
        Me.btnCloseCancel.UseVisualStyleBackColor = False
        '
        'lblX1
        '
        Me.lblX1.AutoSize = True
        Me.lblX1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblX1.Location = New System.Drawing.Point(122, 268)
        Me.lblX1.Name = "lblX1"
        Me.lblX1.Size = New System.Drawing.Size(14, 15)
        Me.lblX1.TabIndex = 140
        Me.lblX1.Text = "X"
        '
        'lblX2
        '
        Me.lblX2.AutoSize = True
        Me.lblX2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblX2.Location = New System.Drawing.Point(233, 268)
        Me.lblX2.Name = "lblX2"
        Me.lblX2.Size = New System.Drawing.Size(14, 15)
        Me.lblX2.TabIndex = 139
        Me.lblX2.Text = "X"
        '
        'lblD3
        '
        Me.lblD3.AutoSize = True
        Me.lblD3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblD3.Location = New System.Drawing.Point(270, 249)
        Me.lblD3.Name = "lblD3"
        Me.lblD3.Size = New System.Drawing.Size(52, 15)
        Me.lblD3.TabIndex = 138
        Me.lblD3.Text = "Descr. 3"
        '
        'lblD2
        '
        Me.lblD2.AutoSize = True
        Me.lblD2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblD2.Location = New System.Drawing.Point(159, 249)
        Me.lblD2.Name = "lblD2"
        Me.lblD2.Size = New System.Drawing.Size(52, 15)
        Me.lblD2.TabIndex = 137
        Me.lblD2.Text = "Descr. 2"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lblMaterialDescription)
        Me.Panel1.Location = New System.Drawing.Point(10, 295)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(708, 51)
        Me.Panel1.TabIndex = 143
        '
        'btnApply
        '
        Me.btnApply.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnApply.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApply.Location = New System.Drawing.Point(434, 352)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(139, 39)
        Me.btnApply.TabIndex = 141
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = False
        '
        'lblD1
        '
        Me.lblD1.AutoSize = True
        Me.lblD1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblD1.Location = New System.Drawing.Point(44, 249)
        Me.lblD1.Name = "lblD1"
        Me.lblD1.Size = New System.Drawing.Size(52, 15)
        Me.lblD1.TabIndex = 136
        Me.lblD1.Text = "Descr. 1"
        '
        'lblDims
        '
        Me.lblDims.AutoSize = True
        Me.lblDims.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDims.Location = New System.Drawing.Point(10, 226)
        Me.lblDims.Name = "lblDims"
        Me.lblDims.Size = New System.Drawing.Size(75, 15)
        Me.lblDims.TabIndex = 135
        Me.lblDims.Text = "Dimensions"
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipTitle = "ToolTipTitle"
        '
        'rbImperial
        '
        Me.rbImperial.AutoSize = True
        Me.rbImperial.Location = New System.Drawing.Point(6, 19)
        Me.rbImperial.Name = "rbImperial"
        Me.rbImperial.Size = New System.Drawing.Size(61, 17)
        Me.rbImperial.TabIndex = 154
        Me.rbImperial.TabStop = True
        Me.rbImperial.Text = "Imperial"
        Me.rbImperial.UseVisualStyleBackColor = True
        '
        'rbMetric
        '
        Me.rbMetric.AutoSize = True
        Me.rbMetric.Location = New System.Drawing.Point(6, 42)
        Me.rbMetric.Name = "rbMetric"
        Me.rbMetric.Size = New System.Drawing.Size(54, 17)
        Me.rbMetric.TabIndex = 155
        Me.rbMetric.TabStop = True
        Me.rbMetric.Text = "Metric"
        Me.rbMetric.UseVisualStyleBackColor = True
        '
        'Units
        '
        Me.Units.Controls.Add(Me.rbImperial)
        Me.Units.Controls.Add(Me.rbMetric)
        Me.Units.Location = New System.Drawing.Point(644, 222)
        Me.Units.Name = "Units"
        Me.Units.Size = New System.Drawing.Size(72, 67)
        Me.Units.TabIndex = 156
        Me.Units.TabStop = False
        Me.Units.Text = "Units"
        Me.Units.Visible = False
        '
        'frmMaterialSpec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 400)
        Me.Controls.Add(Me.Units)
        Me.Controls.Add(Me.tbComments)
        Me.Controls.Add(Me.lbShapes)
        Me.Controls.Add(Me.lbMaterials)
        Me.Controls.Add(Me.btnMaterialFlowChart)
        Me.Controls.Add(Me.nudD3)
        Me.Controls.Add(Me.nudD2)
        Me.Controls.Add(Me.nudD1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lvGrades)
        Me.Controls.Add(Me.btnCloseCancel)
        Me.Controls.Add(Me.lblX1)
        Me.Controls.Add(Me.lblX2)
        Me.Controls.Add(Me.lblD3)
        Me.Controls.Add(Me.lblD2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.lblD1)
        Me.Controls.Add(Me.lblDims)
        Me.Controls.Add(Me.Label9)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMaterialSpec"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Material Specification Form"
        CType(Me.nudD3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudD2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudD1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Units.ResumeLayout(False)
        Me.Units.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents col1 As Windows.Forms.ColumnHeader
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents tbComments As Windows.Forms.TextBox
    Friend WithEvents lbShapes As Windows.Forms.ListBox
    Friend WithEvents lbMaterials As Windows.Forms.ListBox
    Friend WithEvents btnMaterialFlowChart As Windows.Forms.Button
    Friend WithEvents nudD3 As Windows.Forms.NumericUpDown
    Friend WithEvents nudD2 As Windows.Forms.NumericUpDown
    Friend WithEvents nudD1 As Windows.Forms.NumericUpDown
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents lblCurrentMaterialDescription As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents lblMaterialDescription As Windows.Forms.Label
    Friend WithEvents lvGrades As Windows.Forms.ListView
    Friend WithEvents btnCloseCancel As Windows.Forms.Button
    Friend WithEvents lblX1 As Windows.Forms.Label
    Friend WithEvents lblX2 As Windows.Forms.Label
    Friend WithEvents lblD3 As Windows.Forms.Label
    Friend WithEvents lblD2 As Windows.Forms.Label
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents btnApply As Windows.Forms.Button
    Friend WithEvents lblD1 As Windows.Forms.Label
    Friend WithEvents lblDims As Windows.Forms.Label
    Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
    Friend WithEvents rbImperial As Windows.Forms.RadioButton
    Friend WithEvents rbMetric As Windows.Forms.RadioButton
    Friend WithEvents Units As Windows.Forms.GroupBox
End Class
