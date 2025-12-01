Imports Inventor
Imports System.Windows.Forms

Namespace TAITInventorAddIn

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DockForm
        Inherits System.Windows.Forms.Form

        Private Sub InitializeComponent()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.TextBox1 = New System.Windows.Forms.TextBox()
            Me.ListView1 = New System.Windows.Forms.ListView()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.Button3 = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(12, 12)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(112, 24)
            Me.Button1.TabIndex = 1
            Me.Button1.Text = "Button1"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'TextBox1
            '
            Me.TextBox1.Location = New System.Drawing.Point(12, 42)
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(222, 20)
            Me.TextBox1.TabIndex = 2
            '
            'ListView1
            '
            Me.ListView1.HideSelection = False
            Me.ListView1.Location = New System.Drawing.Point(12, 96)
            Me.ListView1.Name = "ListView1"
            Me.ListView1.Size = New System.Drawing.Size(405, 85)
            Me.ListView1.TabIndex = 3
            Me.ListView1.UseCompatibleStateImageBehavior = False
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(12, 80)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(39, 13)
            Me.Label1.TabIndex = 4
            Me.Label1.Text = "Label1"
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(187, 187)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(112, 24)
            Me.Button2.TabIndex = 5
            Me.Button2.Text = "Button2"
            Me.Button2.UseVisualStyleBackColor = True
            '
            'Button3
            '
            Me.Button3.Location = New System.Drawing.Point(305, 187)
            Me.Button3.Name = "Button3"
            Me.Button3.Size = New System.Drawing.Size(112, 24)
            Me.Button3.TabIndex = 6
            Me.Button3.Text = "Button3"
            Me.Button3.UseVisualStyleBackColor = True
            '
            'DockForm
            '
            Me.ClientSize = New System.Drawing.Size(426, 224)
            Me.Controls.Add(Me.Button3)
            Me.Controls.Add(Me.Button2)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.ListView1)
            Me.Controls.Add(Me.TextBox1)
            Me.Controls.Add(Me.Button1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Name = "DockForm"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents Button1 As Button
        Friend WithEvents TextBox1 As Windows.Forms.TextBox
        Friend WithEvents ListView1 As ListView
        Friend WithEvents Label1 As Label
        Friend WithEvents Button2 As Button
        Friend WithEvents Button3 As Button
    End Class
End Namespace
