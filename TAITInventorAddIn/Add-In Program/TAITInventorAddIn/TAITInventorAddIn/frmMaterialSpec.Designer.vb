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
        Me.lblMaterialDescription = New System.Windows.Forms.Label()
        Me.lvGrades = New System.Windows.Forms.ListView()
        Me.lblX1 = New System.Windows.Forms.Label()
        Me.lblX2 = New System.Windows.Forms.Label()
        Me.lblD3 = New System.Windows.Forms.Label()
        Me.lblD2 = New System.Windows.Forms.Label()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.lblD1 = New System.Windows.Forms.Label()
        Me.lblDims = New System.Windows.Forms.Label()
        Me.rbImperial = New System.Windows.Forms.RadioButton()
        Me.rbMetric = New System.Windows.Forms.RadioButton()
        Me.gbUnits = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAISCMaterialDB = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbCustomMaterial = New System.Windows.Forms.TextBox()
        Me.rbCustomMaterial = New System.Windows.Forms.RadioButton()
        Me.rbStandardMaterial = New System.Windows.Forms.RadioButton()
        Me.cbDescr = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.nudD3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudD2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudD1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.gbUnits.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.Label9.Location = New System.Drawing.Point(1437, 105)
        Me.Label9.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(454, 35)
        Me.Label9.TabIndex = 152
        Me.Label9.Text = "Comments about Grade Selected"
        '
        'tbComments
        '
        Me.tbComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbComments.Location = New System.Drawing.Point(1445, 150)
        Me.tbComments.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.tbComments.Multiline = True
        Me.tbComments.Name = "tbComments"
        Me.tbComments.ReadOnly = True
        Me.tbComments.Size = New System.Drawing.Size(583, 166)
        Me.tbComments.TabIndex = 151
        '
        'lbShapes
        '
        Me.lbShapes.FormattingEnabled = True
        Me.lbShapes.ItemHeight = 31
        Me.lbShapes.Location = New System.Drawing.Point(493, 150)
        Me.lbShapes.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.lbShapes.Name = "lbShapes"
        Me.lbShapes.Size = New System.Drawing.Size(455, 314)
        Me.lbShapes.TabIndex = 150
        '
        'lbMaterials
        '
        Me.lbMaterials.FormattingEnabled = True
        Me.lbMaterials.ItemHeight = 31
        Me.lbMaterials.Location = New System.Drawing.Point(16, 150)
        Me.lbMaterials.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.lbMaterials.Name = "lbMaterials"
        Me.lbMaterials.Size = New System.Drawing.Size(455, 314)
        Me.lbMaterials.TabIndex = 149
        '
        'btnMaterialFlowChart
        '
        Me.btnMaterialFlowChart.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnMaterialFlowChart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnMaterialFlowChart.Location = New System.Drawing.Point(1445, 336)
        Me.btnMaterialFlowChart.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btnMaterialFlowChart.Name = "btnMaterialFlowChart"
        Me.btnMaterialFlowChart.Size = New System.Drawing.Size(587, 131)
        Me.btnMaterialFlowChart.TabIndex = 148
        Me.btnMaterialFlowChart.Text = "TAIT" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Structural Material Selection" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Flow Chart"
        Me.btnMaterialFlowChart.UseVisualStyleBackColor = False
        '
        'nudD3
        '
        Me.nudD3.Cursor = System.Windows.Forms.Cursors.Default
        Me.nudD3.DecimalPlaces = 3
        Me.nudD3.Increment = New Decimal(New Integer() {125, 0, 0, 196608})
        Me.nudD3.Location = New System.Drawing.Point(813, 522)
        Me.nudD3.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.nudD3.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudD3.Name = "nudD3"
        Me.nudD3.Size = New System.Drawing.Size(227, 38)
        Me.nudD3.TabIndex = 147
        Me.nudD3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudD3.ThousandsSeparator = True
        Me.nudD3.Visible = False
        '
        'nudD2
        '
        Me.nudD2.Cursor = System.Windows.Forms.Cursors.Default
        Me.nudD2.DecimalPlaces = 3
        Me.nudD2.Increment = New Decimal(New Integer() {125, 0, 0, 196608})
        Me.nudD2.Location = New System.Drawing.Point(517, 522)
        Me.nudD2.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.nudD2.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudD2.Name = "nudD2"
        Me.nudD2.Size = New System.Drawing.Size(227, 38)
        Me.nudD2.TabIndex = 146
        Me.nudD2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudD2.ThousandsSeparator = True
        Me.nudD2.Visible = False
        '
        'nudD1
        '
        Me.nudD1.Cursor = System.Windows.Forms.Cursors.Default
        Me.nudD1.DecimalPlaces = 3
        Me.nudD1.Increment = New Decimal(New Integer() {125, 0, 0, 196608})
        Me.nudD1.Location = New System.Drawing.Point(211, 522)
        Me.nudD1.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.nudD1.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudD1.Name = "nudD1"
        Me.nudD1.Size = New System.Drawing.Size(227, 38)
        Me.nudD1.TabIndex = 145
        Me.nudD1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudD1.ThousandsSeparator = True
        Me.nudD1.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblCurrentMaterialDescription)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(27, 24)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(2045, 64)
        Me.Panel2.TabIndex = 144
        '
        'lblCurrentMaterialDescription
        '
        Me.lblCurrentMaterialDescription.AutoSize = True
        Me.lblCurrentMaterialDescription.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentMaterialDescription.Location = New System.Drawing.Point(488, 14)
        Me.lblCurrentMaterialDescription.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblCurrentMaterialDescription.Name = "lblCurrentMaterialDescription"
        Me.lblCurrentMaterialDescription.Size = New System.Drawing.Size(478, 38)
        Me.lblCurrentMaterialDescription.TabIndex = 22
        Me.lblCurrentMaterialDescription.Text = "lblCurrentMaterialDescription"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 14)
        Me.Label1.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(394, 35)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Current Material Description:"
        '
        'lblMaterialDescription
        '
        Me.lblMaterialDescription.AutoSize = True
        Me.lblMaterialDescription.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaterialDescription.Location = New System.Drawing.Point(488, 17)
        Me.lblMaterialDescription.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblMaterialDescription.Name = "lblMaterialDescription"
        Me.lblMaterialDescription.Size = New System.Drawing.Size(359, 38)
        Me.lblMaterialDescription.TabIndex = 33
        Me.lblMaterialDescription.Text = "lblMaterialDescription"
        '
        'lvGrades
        '
        Me.lvGrades.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col1})
        Me.lvGrades.FullRowSelect = True
        Me.lvGrades.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvGrades.HideSelection = False
        Me.lvGrades.Location = New System.Drawing.Point(971, 150)
        Me.lvGrades.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.lvGrades.MultiSelect = False
        Me.lvGrades.Name = "lvGrades"
        Me.lvGrades.Size = New System.Drawing.Size(455, 314)
        Me.lvGrades.TabIndex = 153
        Me.lvGrades.UseCompatibleStateImageBehavior = False
        Me.lvGrades.View = System.Windows.Forms.View.Details
        '
        'lblX1
        '
        Me.lblX1.AutoSize = True
        Me.lblX1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblX1.Location = New System.Drawing.Point(469, 532)
        Me.lblX1.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblX1.Name = "lblX1"
        Me.lblX1.Size = New System.Drawing.Size(34, 35)
        Me.lblX1.TabIndex = 140
        Me.lblX1.Text = "X"
        Me.lblX1.Visible = False
        '
        'lblX2
        '
        Me.lblX2.AutoSize = True
        Me.lblX2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblX2.Location = New System.Drawing.Point(768, 532)
        Me.lblX2.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblX2.Name = "lblX2"
        Me.lblX2.Size = New System.Drawing.Size(34, 35)
        Me.lblX2.TabIndex = 139
        Me.lblX2.Text = "X"
        Me.lblX2.Visible = False
        '
        'lblD3
        '
        Me.lblD3.AutoSize = True
        Me.lblD3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblD3.Location = New System.Drawing.Point(856, 479)
        Me.lblD3.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblD3.Name = "lblD3"
        Me.lblD3.Size = New System.Drawing.Size(124, 35)
        Me.lblD3.TabIndex = 138
        Me.lblD3.Text = "Descr. 3"
        Me.lblD3.Visible = False
        '
        'lblD2
        '
        Me.lblD2.AutoSize = True
        Me.lblD2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblD2.Location = New System.Drawing.Point(560, 479)
        Me.lblD2.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblD2.Name = "lblD2"
        Me.lblD2.Size = New System.Drawing.Size(124, 35)
        Me.lblD2.TabIndex = 137
        Me.lblD2.Text = "Descr. 2"
        Me.lblD2.Visible = False
        '
        'btnApply
        '
        Me.btnApply.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnApply.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApply.Location = New System.Drawing.Point(1701, 7)
        Me.btnApply.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(333, 55)
        Me.btnApply.TabIndex = 141
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = False
        '
        'lblD1
        '
        Me.lblD1.AutoSize = True
        Me.lblD1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblD1.Location = New System.Drawing.Point(253, 479)
        Me.lblD1.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblD1.Name = "lblD1"
        Me.lblD1.Size = New System.Drawing.Size(124, 35)
        Me.lblD1.TabIndex = 136
        Me.lblD1.Text = "Descr. 1"
        Me.lblD1.Visible = False
        '
        'lblDims
        '
        Me.lblDims.AutoSize = True
        Me.lblDims.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDims.Location = New System.Drawing.Point(11, 525)
        Me.lblDims.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblDims.Name = "lblDims"
        Me.lblDims.Size = New System.Drawing.Size(172, 35)
        Me.lblDims.TabIndex = 135
        Me.lblDims.Text = "Dimensions"
        '
        'rbImperial
        '
        Me.rbImperial.AutoSize = True
        Me.rbImperial.Checked = True
        Me.rbImperial.Location = New System.Drawing.Point(16, 45)
        Me.rbImperial.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.rbImperial.Name = "rbImperial"
        Me.rbImperial.Size = New System.Drawing.Size(153, 36)
        Me.rbImperial.TabIndex = 154
        Me.rbImperial.TabStop = True
        Me.rbImperial.Text = "Imperial"
        Me.rbImperial.UseVisualStyleBackColor = True
        '
        'rbMetric
        '
        Me.rbMetric.AutoSize = True
        Me.rbMetric.Location = New System.Drawing.Point(187, 48)
        Me.rbMetric.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.rbMetric.Name = "rbMetric"
        Me.rbMetric.Size = New System.Drawing.Size(129, 36)
        Me.rbMetric.TabIndex = 155
        Me.rbMetric.Text = "Metric"
        Me.rbMetric.UseVisualStyleBackColor = True
        '
        'gbUnits
        '
        Me.gbUnits.Controls.Add(Me.rbImperial)
        Me.gbUnits.Controls.Add(Me.rbMetric)
        Me.gbUnits.Location = New System.Drawing.Point(1083, 484)
        Me.gbUnits.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.gbUnits.Name = "gbUnits"
        Me.gbUnits.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.gbUnits.Size = New System.Drawing.Size(347, 105)
        Me.gbUnits.TabIndex = 156
        Me.gbUnits.TabStop = False
        Me.gbUnits.Text = "Units"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAISCMaterialDB)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbCustomMaterial)
        Me.GroupBox1.Controls.Add(Me.rbCustomMaterial)
        Me.GroupBox1.Controls.Add(Me.btnMaterialFlowChart)
        Me.GroupBox1.Controls.Add(Me.rbStandardMaterial)
        Me.GroupBox1.Controls.Add(Me.lbMaterials)
        Me.GroupBox1.Controls.Add(Me.gbUnits)
        Me.GroupBox1.Controls.Add(Me.nudD3)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.nudD2)
        Me.GroupBox1.Controls.Add(Me.tbComments)
        Me.GroupBox1.Controls.Add(Me.nudD1)
        Me.GroupBox1.Controls.Add(Me.lvGrades)
        Me.GroupBox1.Controls.Add(Me.lbShapes)
        Me.GroupBox1.Controls.Add(Me.lblDims)
        Me.GroupBox1.Controls.Add(Me.lblX1)
        Me.GroupBox1.Controls.Add(Me.lblD1)
        Me.GroupBox1.Controls.Add(Me.lblX2)
        Me.GroupBox1.Controls.Add(Me.lblD2)
        Me.GroupBox1.Controls.Add(Me.lblD3)
        Me.GroupBox1.Controls.Add(Me.cbDescr)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 103)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupBox1.Size = New System.Drawing.Size(2051, 730)
        Me.GroupBox1.TabIndex = 157
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Material Selection"
        '
        'btnAISCMaterialDB
        '
        Me.btnAISCMaterialDB.BackColor = System.Drawing.Color.IndianRed
        Me.btnAISCMaterialDB.ForeColor = System.Drawing.Color.Black
        Me.btnAISCMaterialDB.Location = New System.Drawing.Point(1445, 484)
        Me.btnAISCMaterialDB.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btnAISCMaterialDB.Name = "btnAISCMaterialDB"
        Me.btnAISCMaterialDB.Size = New System.Drawing.Size(587, 105)
        Me.btnAISCMaterialDB.TabIndex = 166
        Me.btnAISCMaterialDB.Text = "AISC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Shapes Database v15.0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnAISCMaterialDB.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(965, 103)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(343, 36)
        Me.Label5.TabIndex = 162
        Me.Label5.Text = "3.) Select Material Grade"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(488, 105)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(370, 36)
        Me.Label4.TabIndex = 161
        Me.Label4.Text = "2.) Select Structural Shape"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 103)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(253, 36)
        Me.Label2.TabIndex = 160
        Me.Label2.Text = "1.) Select Material"
        '
        'tbCustomMaterial
        '
        Me.tbCustomMaterial.Enabled = False
        Me.tbCustomMaterial.Location = New System.Drawing.Point(392, 656)
        Me.tbCustomMaterial.Margin = New System.Windows.Forms.Padding(5)
        Me.tbCustomMaterial.Name = "tbCustomMaterial"
        Me.tbCustomMaterial.ReadOnly = True
        Me.tbCustomMaterial.Size = New System.Drawing.Size(1071, 38)
        Me.tbCustomMaterial.TabIndex = 159
        '
        'rbCustomMaterial
        '
        Me.rbCustomMaterial.AutoSize = True
        Me.rbCustomMaterial.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCustomMaterial.Location = New System.Drawing.Point(11, 649)
        Me.rbCustomMaterial.Margin = New System.Windows.Forms.Padding(5)
        Me.rbCustomMaterial.Name = "rbCustomMaterial"
        Me.rbCustomMaterial.Size = New System.Drawing.Size(335, 46)
        Me.rbCustomMaterial.TabIndex = 158
        Me.rbCustomMaterial.Text = "Custom Material:"
        Me.rbCustomMaterial.UseVisualStyleBackColor = True
        '
        'rbStandardMaterial
        '
        Me.rbStandardMaterial.AutoSize = True
        Me.rbStandardMaterial.Checked = True
        Me.rbStandardMaterial.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbStandardMaterial.Location = New System.Drawing.Point(16, 41)
        Me.rbStandardMaterial.Margin = New System.Windows.Forms.Padding(5)
        Me.rbStandardMaterial.Name = "rbStandardMaterial"
        Me.rbStandardMaterial.Size = New System.Drawing.Size(562, 46)
        Me.rbStandardMaterial.TabIndex = 157
        Me.rbStandardMaterial.TabStop = True
        Me.rbStandardMaterial.Text = "Standard Material Constructor:"
        Me.rbStandardMaterial.UseVisualStyleBackColor = True
        '
        'cbDescr
        '
        Me.cbDescr.FormattingEnabled = True
        Me.cbDescr.Location = New System.Drawing.Point(251, 522)
        Me.cbDescr.Margin = New System.Windows.Forms.Padding(5)
        Me.cbDescr.Name = "cbDescr"
        Me.cbDescr.Size = New System.Drawing.Size(527, 39)
        Me.cbDescr.TabIndex = 163
        Me.cbDescr.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblMaterialDescription)
        Me.Panel1.Controls.Add(Me.btnApply)
        Me.Panel1.Location = New System.Drawing.Point(27, 873)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(2045, 71)
        Me.Panel1.TabIndex = 158
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 19)
        Me.Label3.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(353, 35)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "New Material Description:"
        '
        'frmMaterialSpec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2101, 973)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.Name = "frmMaterialSpec"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Material Specification Form"
        CType(Me.nudD3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudD2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudD1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.gbUnits.ResumeLayout(False)
        Me.gbUnits.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

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
    Friend WithEvents lblMaterialDescription As Windows.Forms.Label
    Friend WithEvents lvGrades As Windows.Forms.ListView
    Friend WithEvents lblX1 As Windows.Forms.Label
    Friend WithEvents lblX2 As Windows.Forms.Label
    Friend WithEvents lblD3 As Windows.Forms.Label
    Friend WithEvents lblD2 As Windows.Forms.Label
    Friend WithEvents btnApply As Windows.Forms.Button
    Friend WithEvents lblD1 As Windows.Forms.Label
    Friend WithEvents lblDims As Windows.Forms.Label
    Friend WithEvents rbImperial As Windows.Forms.RadioButton
    Friend WithEvents rbMetric As Windows.Forms.RadioButton
    Friend WithEvents gbUnits As Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents rbCustomMaterial As Windows.Forms.RadioButton
    Friend WithEvents rbStandardMaterial As Windows.Forms.RadioButton
    Friend WithEvents tbCustomMaterial As Windows.Forms.TextBox
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents cbDescr As Windows.Forms.ComboBox
    Friend WithEvents btnAISCMaterialDB As Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As ComponentModel.BackgroundWorker
End Class
