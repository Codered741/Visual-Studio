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
        Me.btnGet = New System.Windows.Forms.Button()
        Me.tbPartNum = New System.Windows.Forms.TextBox()
        Me.lblPartNum = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnGet
        '
        Me.btnGet.Location = New System.Drawing.Point(13, 13)
        Me.btnGet.Name = "btnGet"
        Me.btnGet.Size = New System.Drawing.Size(775, 34)
        Me.btnGet.TabIndex = 0
        Me.btnGet.Text = "Get Part Info"
        Me.btnGet.UseVisualStyleBackColor = True
        '
        'tbPartNum
        '
        Me.tbPartNum.Location = New System.Drawing.Point(24, 118)
        Me.tbPartNum.Name = "tbPartNum"
        Me.tbPartNum.Size = New System.Drawing.Size(252, 26)
        Me.tbPartNum.TabIndex = 1
        '
        'lblPartNum
        '
        Me.lblPartNum.AutoSize = True
        Me.lblPartNum.Location = New System.Drawing.Point(24, 97)
        Me.lblPartNum.Name = "lblPartNum"
        Me.lblPartNum.Size = New System.Drawing.Size(98, 20)
        Me.lblPartNum.TabIndex = 2
        Me.lblPartNum.Text = "Part Number"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lblPartNum)
        Me.Controls.Add(Me.tbPartNum)
        Me.Controls.Add(Me.btnGet)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnGet As Button
    Friend WithEvents tbPartNum As TextBox
    Friend WithEvents lblPartNum As Label
End Class
