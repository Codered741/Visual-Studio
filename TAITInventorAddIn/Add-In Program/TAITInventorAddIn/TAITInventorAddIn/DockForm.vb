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
            Dim myDockableWindow As DockableWindow = uiMgr.DockableWindows.Add(addInCLS, "MyWindow", "TAIT PI Test Dockform")
            myDockableWindow.AddChild(Me.Handle)

            ' Default docking state
            If Not myDockableWindow.IsCustomized Then
                myDockableWindow.DockingState = DockingStateEnum.kFloat
                'myDockableWindow.DockingState = DockingStateEnum.kDockTop
                'myDockableWindow.DisabledDockingStates = DockingStateEnum.kDockLeft + DockingStateEnum.kDockRight
                myDockableWindow.Move(25, 25, myDockableWindow.Height, myDockableWindow.Width)
            End If
            Me.Visible = True
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

        Private Sub InitializeComponent()
            Me.ElementHost1 = New System.Windows.Forms.Integration.ElementHost()
            Me.UserControlG1 = New WpfApp1.UserControlG()
            Me.SuspendLayout()
            '
            'ElementHost1
            '
            Me.ElementHost1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ElementHost1.Location = New System.Drawing.Point(0, 0)
            Me.ElementHost1.Name = "ElementHost1"
            Me.ElementHost1.Size = New System.Drawing.Size(300, 158)
            Me.ElementHost1.TabIndex = 0
            Me.ElementHost1.Text = "ElementHost1"
            Me.ElementHost1.Child = Me.UserControlG1
            '
            'DockForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoSize = True
            Me.ClientSize = New System.Drawing.Size(300, 158)
            Me.Controls.Add(Me.ElementHost1)
            Me.Name = "DockForm"
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents ElementHost1 As Integration.ElementHost
        Friend UserControlG1 As WpfApp1.UserControlG
    End Class
End Namespace
