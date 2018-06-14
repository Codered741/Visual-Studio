<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModifyDwgNotes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModifyDwgNotes))
        Me.ExistingNotesList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.NotesList = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnShortcutMachined = New System.Windows.Forms.Button()
        Me.btnShortcutSheetMetal = New System.Windows.Forms.Button()
        Me.btnShortcutCutLength = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbtest = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExistingNotesList
        '
        Me.ExistingNotesList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ExistingNotesList.FullRowSelect = True
        Me.ExistingNotesList.GridLines = True
        Me.ExistingNotesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ExistingNotesList.HideSelection = False
        Me.ExistingNotesList.Location = New System.Drawing.Point(127, 25)
        Me.ExistingNotesList.Name = "ExistingNotesList"
        Me.ExistingNotesList.ShowItemToolTips = True
        Me.ExistingNotesList.Size = New System.Drawing.Size(1140, 460)
        Me.ExistingNotesList.TabIndex = 19
        Me.ExistingNotesList.UseCompatibleStateImageBehavior = False
        Me.ExistingNotesList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = ""
        Me.ColumnHeader1.Width = 1500
        '
        'btnDown
        '
        Me.btnDown.BackColor = System.Drawing.SystemColors.Control
        Me.btnDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDown.Location = New System.Drawing.Point(22, 622)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(87, 51)
        Me.btnDown.TabIndex = 18
        Me.btnDown.Text = "MOVE DOWN"
        Me.btnDown.UseVisualStyleBackColor = False
        '
        'btnUp
        '
        Me.btnUp.BackColor = System.Drawing.SystemColors.Control
        Me.btnUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUp.Location = New System.Drawing.Point(22, 565)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(87, 51)
        Me.btnUp.TabIndex = 17
        Me.btnUp.Text = "MOVE UP"
        Me.btnUp.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Salmon
        Me.btnCancel.Location = New System.Drawing.Point(1096, 762)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 30)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnApply
        '
        Me.btnApply.BackColor = System.Drawing.Color.PaleGreen
        Me.btnApply.Location = New System.Drawing.Point(1186, 762)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(81, 30)
        Me.btnApply.TabIndex = 15
        Me.btnApply.Text = "APPLY"
        Me.btnApply.UseVisualStyleBackColor = False
        '
        'NotesList
        '
        Me.NotesList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader3})
        Me.NotesList.FullRowSelect = True
        Me.NotesList.GridLines = True
        Me.NotesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.NotesList.Location = New System.Drawing.Point(127, 508)
        Me.NotesList.Name = "NotesList"
        Me.NotesList.Size = New System.Drawing.Size(1140, 248)
        Me.NotesList.TabIndex = 20
        Me.NotesList.UseCompatibleStateImageBehavior = False
        Me.NotesList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Order"
        Me.ColumnHeader2.Width = 50
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Notes"
        Me.ColumnHeader3.Width = 1500
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.SystemColors.Control
        Me.btnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.Location = New System.Drawing.Point(22, 508)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(87, 51)
        Me.btnRemove.TabIndex = 22
        Me.btnRemove.Text = "REMOVE" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "NOTES"
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.SystemColors.Control
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(22, 354)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(87, 51)
        Me.btnAdd.TabIndex = 21
        Me.btnAdd.Text = "ADD SELECTED " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "NOTES"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnShortcutMachined
        '
        Me.btnShortcutMachined.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnShortcutMachined.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShortcutMachined.Location = New System.Drawing.Point(10, 19)
        Me.btnShortcutMachined.Name = "btnShortcutMachined"
        Me.btnShortcutMachined.Size = New System.Drawing.Size(87, 51)
        Me.btnShortcutMachined.TabIndex = 23
        Me.btnShortcutMachined.Text = "TYP. MACHINED PART NOTES"
        Me.btnShortcutMachined.UseVisualStyleBackColor = False
        '
        'btnShortcutSheetMetal
        '
        Me.btnShortcutSheetMetal.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnShortcutSheetMetal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShortcutSheetMetal.Location = New System.Drawing.Point(10, 133)
        Me.btnShortcutSheetMetal.Name = "btnShortcutSheetMetal"
        Me.btnShortcutSheetMetal.Size = New System.Drawing.Size(87, 51)
        Me.btnShortcutSheetMetal.TabIndex = 24
        Me.btnShortcutSheetMetal.Text = "TYP. SHEET METAL PART NOTES"
        Me.btnShortcutSheetMetal.UseVisualStyleBackColor = False
        '
        'btnShortcutCutLength
        '
        Me.btnShortcutCutLength.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnShortcutCutLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShortcutCutLength.Location = New System.Drawing.Point(10, 76)
        Me.btnShortcutCutLength.Name = "btnShortcutCutLength"
        Me.btnShortcutCutLength.Size = New System.Drawing.Size(87, 51)
        Me.btnShortcutCutLength.TabIndex = 25
        Me.btnShortcutCutLength.Text = "TYP. CUT LENGTH PART NOTES"
        Me.btnShortcutCutLength.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnShortcutMachined)
        Me.GroupBox1.Controls.Add(Me.btnShortcutCutLength)
        Me.GroupBox1.Controls.Add(Me.btnShortcutSheetMetal)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 154)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(109, 194)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SHORTCUTS"
        '
        'cmbtest
        '
        Me.cmbtest.FormattingEnabled = True
        Me.cmbtest.Location = New System.Drawing.Point(127, 762)
        Me.cmbtest.Name = "cmbtest"
        Me.cmbtest.Size = New System.Drawing.Size(342, 21)
        Me.cmbtest.TabIndex = 27
        Me.cmbtest.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(124, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "TAIT PI STANDARD NOTES"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(124, 490)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(161, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "ACTIVE DRAWING NOTES"
        '
        'frmModifyDwgNotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1281, 804)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbtest)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ExistingNotesList)
        Me.Controls.Add(Me.btnDown)
        Me.Controls.Add(Me.btnUp)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.NotesList)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmModifyDwgNotes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modify Drawing Notes"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ExistingNotesList As Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As Windows.Forms.ColumnHeader
    Friend WithEvents btnDown As Windows.Forms.Button
    Friend WithEvents btnUp As Windows.Forms.Button
    Friend WithEvents btnCancel As Windows.Forms.Button
    Friend WithEvents btnApply As Windows.Forms.Button
    Friend WithEvents NotesList As Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As Windows.Forms.ColumnHeader
    Friend WithEvents btnRemove As Windows.Forms.Button
    Friend WithEvents btnAdd As Windows.Forms.Button
    Friend WithEvents btnShortcutMachined As Windows.Forms.Button
    Friend WithEvents btnShortcutSheetMetal As Windows.Forms.Button
    Friend WithEvents btnShortcutCutLength As Windows.Forms.Button
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents cmbtest As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
End Class
