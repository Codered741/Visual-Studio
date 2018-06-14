Imports Inventor
Imports System.Windows.Forms

Namespace TAITInventorAddIn

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DockForm
        Inherits System.Windows.Forms.Form

        Public Sub New(app As Inventor.Application, addInCLS As String)

            MyBase.New
            InitializeComponent()
            Dim uiMgr As UserInterfaceManager = app.UserInterfaceManager
            Dim myDockableWindow As DockableWindow = uiMgr.DockableWindows.Add(addInCLS, "MyWindow", "TAIT PI Test Form")
            myDockableWindow.AddChild(Me.Handle)

            ' Default docking state
            If Not myDockableWindow.IsCustomized Then
                myDockableWindow.DockingState = DockingStateEnum.kFloat
                myDockableWindow.Move(25, 25, myDockableWindow.Height, myDockableWindow.Width)
            End If
            'Me.Visible = True
            myDockableWindow.Visible = True

        End Sub

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.ElementHost2 = New System.Windows.Forms.Integration.ElementHost()
            Me.SuspendLayout()
            '
            'ElementHost2
            '
            Me.ElementHost2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ElementHost2.Location = New System.Drawing.Point(0, 0)
            Me.ElementHost2.Name = "ElementHost2"
            Me.ElementHost2.Size = New System.Drawing.Size(248, 155)
            Me.ElementHost2.TabIndex = 3
            Me.ElementHost2.Text = "ElementHost2"
            Me.ElementHost2.Child = Nothing
            '
            'DockForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(248, 155)
            Me.Controls.Add(Me.ElementHost2)
            Me.Name = "DockForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Form1"
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents ElementHost2 As Integration.ElementHost

    End Class
End Namespace
