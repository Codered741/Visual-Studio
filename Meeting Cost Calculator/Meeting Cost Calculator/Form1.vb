Imports System.Collections
Imports System.Diagnostics
Imports System.Reflection
Imports System.Text

Public Class Form1
    Private stopwatch As New Stopwatch

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Dim versionNumber As Version
        versionNumber = Assembly.GetExecutingAssembly().GetName().Version
        lblVer.Text = "v" & versionNumber.ToString()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        SetEnables()

        Dim elapsed As TimeSpan = Me.stopwatch.Elapsed
        lblET.Text = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
            Math.Floor(elapsed.TotalHours), elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds)
        'ElapsedTime*HourlyRate*#OfAttendees
        lblMC.Text = Calculate()
        '"$" & Math.Round(elapsed.TotalSeconds * (Integer.Parse(tbRate.Text) / 3600) * Integer.Parse(tbNumAtt.Text), 2)
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Timer1.Start()
        Me.stopwatch.Start()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        Timer1.Stop()
        Me.stopwatch.Stop()
        SetEnables()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Me.stopwatch.Reset()
        lblET.Text = "00:00:00:00"
        lblMC.Text = "$0000.00"
    End Sub

    Private Sub tbRate_LostFocus(sender As Object, e As EventArgs) Handles tbRate.LostFocus
        Dim intRate As Integer

        If Not Integer.TryParse(tbRate.Text, intRate) Then
            MsgBox("Please enter a whole number as the hourly rate.  ")
            tbRate.Text = 170
        Else
            lblMC.Text = Calculate()
        End If

    End Sub

    Private Sub tbNumAtt_LostFocus(sender As Object, e As EventArgs) Handles tbNumAtt.LostFocus
        Dim intNumAtt As Integer

        If Not Integer.TryParse(tbNumAtt.Text, intNumAtt) Then
            MsgBox("Please enter a whole number for the # of attendees.  ")
            tbNumAtt.Text = 1
        Else
            lblMC.Text = Calculate()
        End If

    End Sub

    Private Sub SetEnables()
        If stopwatch.IsRunning Then
            btnStart.Enabled = False
            btnStop.Enabled = True
            btnReset.Enabled = False
            tbNumAtt.Enabled = False
            tbRate.Enabled = False
        Else
            btnStart.Enabled = True
            btnStop.Enabled = False
            btnReset.Enabled = True
            tbNumAtt.Enabled = True
            tbRate.Enabled = True
        End If
    End Sub

    Private Function Calculate() As String
        Dim elapsed As TimeSpan = Me.stopwatch.Elapsed
        Calculate = "$" & Math.Round(elapsed.TotalSeconds * (Integer.Parse(tbRate.Text) / 3600) * Integer.Parse(tbNumAtt.Text), 2)
    End Function

    Sub lblContact_Click(sender As Object, e As EventArgs) Handles lblContact.Click

        Dim theStringBuilder As New StringBuilder()

        theStringBuilder.Append("mailto:codered741@gmail.com")

        theStringBuilder.Append("&subject=MCC Feedback")

        theStringBuilder.Append("&body=This is Awesome!")

        Process.Start(theStringBuilder.ToString())
    End Sub

End Class
