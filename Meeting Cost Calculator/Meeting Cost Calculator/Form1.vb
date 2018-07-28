Public Class Form1
    Private stopwatch As New Stopwatch

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim elapsed As TimeSpan = Me.stopwatch.Elapsed
        lblET.Text = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
            Math.Floor(elapsed.TotalHours), elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds)
        'ElapsedTime*HourlyRate*#OfAttendees
        lblMC.Text = "$" & Math.Round(elapsed.TotalSeconds * (Integer.Parse(tbRate.Text) / 3600) * Integer.Parse(tbNumAtt.Text), 2)

    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Timer1.Start()
        Me.stopwatch.Start()
        btnStart.Enabled = False
        btnStop.Enabled = True
        btnReset.Enabled = False
        tbNumAtt.Enabled = False
        tbRate.Enabled = False

    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        Timer1.Stop()
        Me.stopwatch.Stop()
        btnStart.Enabled = True
        btnStop.Enabled = False
        btnReset.Enabled = True
        tbNumAtt.Enabled = True
        tbRate.Enabled = True
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Me.stopwatch.Reset()
        lblET.Text = "00:00:00:00"
        lblMC.Text = "$0000.00"
    End Sub

    Private Sub tbRate_LostFocus(sender As Object, e As EventArgs) Handles tbRate.LostFocus
        'Dim intRate As Integer

        'If Integer.TryParse(tbRate.Text, intRate) Then
        '    MsgBox("Please enter a whole number as the hourly rate.  ")
        '    tbRate.Text = 170
        'End If

    End Sub

    Private Sub tbNumAtt_LostFocus(sender As Object, e As EventArgs) Handles tbNumAtt.LostFocus
        'Dim intNumAtt As Integer

        'If Integer.TryParse(tbNumAtt.Text, intNumAtt) Then
        '    MsgBox("Please enter a whole number for the # of attendees.  ")
        '    tbNumAtt.Text = 1
        'End If
    End Sub
End Class
