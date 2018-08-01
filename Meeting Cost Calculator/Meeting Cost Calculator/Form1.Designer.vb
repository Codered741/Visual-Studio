<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnStart = New System.Windows.Forms.Button()
        Me.tbRate = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblMC = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblET = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.lblVer = New System.Windows.Forms.Label()
        Me.lblContact = New System.Windows.Forms.Label()
        Me.tbNumAtt = New System.Windows.Forms.NumericUpDown()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Form1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.tbNumAtt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Form1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(12, 114)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(84, 32)
        Me.btnStart.TabIndex = 3
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'tbRate
        '
        Me.tbRate.AcceptsReturn = True
        Me.tbRate.AcceptsTab = True
        Me.tbRate.Location = New System.Drawing.Point(12, 28)
        Me.tbRate.Name = "tbRate"
        Me.tbRate.Size = New System.Drawing.Size(100, 20)
        Me.tbRate.TabIndex = 1
        Me.tbRate.Text = "170"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Hourly Rate"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(119, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "$/Labor Hour"
        '
        'lblMC
        '
        Me.lblMC.AutoSize = True
        Me.lblMC.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMC.Location = New System.Drawing.Point(53, 255)
        Me.lblMC.Name = "lblMC"
        Me.lblMC.Size = New System.Drawing.Size(185, 46)
        Me.lblMC.TabIndex = 0
        Me.lblMC.Text = "$0000.00"
        Me.lblMC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(119, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Persons"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "# of Attendees"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(106, 242)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Meeting Cost"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblET
        '
        Me.lblET.AutoSize = True
        Me.lblET.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblET.Location = New System.Drawing.Point(20, 182)
        Me.lblET.Name = "lblET"
        Me.lblET.Size = New System.Drawing.Size(251, 46)
        Me.lblET.TabIndex = 0
        Me.lblET.Text = "00:00:00:000"
        Me.lblET.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(104, 169)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Elapsed Time"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        '
        'btnStop
        '
        Me.btnStop.Enabled = False
        Me.btnStop.Location = New System.Drawing.Point(102, 114)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(84, 32)
        Me.btnStop.TabIndex = 4
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(192, 114)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(84, 32)
        Me.btnReset.TabIndex = 5
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'lblVer
        '
        Me.lblVer.AutoSize = True
        Me.lblVer.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblVer.Location = New System.Drawing.Point(439, 9)
        Me.lblVer.Name = "lblVer"
        Me.lblVer.Size = New System.Drawing.Size(52, 13)
        Me.lblVer.TabIndex = 6
        Me.lblVer.Text = "v0.0.0.00"
        Me.lblVer.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblContact
        '
        Me.lblContact.AutoSize = True
        Me.lblContact.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblContact.Location = New System.Drawing.Point(376, 295)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Size = New System.Drawing.Size(44, 13)
        Me.lblContact.TabIndex = 7
        Me.lblContact.Text = "Contact"
        Me.lblContact.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tbNumAtt
        '
        Me.tbNumAtt.Location = New System.Drawing.Point(13, 83)
        Me.tbNumAtt.Name = "tbNumAtt"
        Me.tbNumAtt.Size = New System.Drawing.Size(100, 20)
        Me.tbNumAtt.TabIndex = 8
        Me.tbNumAtt.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(294, 28)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(195, 264)
        Me.ListBox1.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(294, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Segments"
        '
        'Form1BindingSource
        '
        Me.Form1BindingSource.DataSource = GetType(Meeting_Cost_Calculator.Form1)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 311)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.tbNumAtt)
        Me.Controls.Add(Me.lblContact)
        Me.Controls.Add(Me.lblVer)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblET)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblMC)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbRate)
        Me.Controls.Add(Me.btnStart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(0, 350)
        Me.Name = "Form1"
        Me.Text = "Meeting Cost"
        CType(Me.tbNumAtt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Form1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnStart As Button
    Friend WithEvents tbRate As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblMC As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblET As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents btnStop As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents lblVer As Label
    Friend WithEvents lblContact As Label
    Friend WithEvents tbNumAtt As NumericUpDown
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Form1BindingSource As BindingSource
    Friend WithEvents Label3 As Label
End Class
