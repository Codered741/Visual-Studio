Imports System.Drawing
Imports System.Windows.Forms
Imports System.Text
Imports Inventor

Public Class frmModifyDwgNotes
    Private Sub frmModifyDwgNotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'For x = 1 To 65535

        '    cmbtest.Font = New Font("Helvetica", 8)
        '    cmbtest.Items.Add(ChrW(x) & " = " & x.ToString("X4"))
        'Next

        Dim titlefont As New Font("Helvetica", 9, System.Drawing.FontStyle.Bold)
        Dim notefont As New Font("Helvetica", 8)
        Dim filename As String
        Dim directories As String()
        Dim d As Integer

        '''''GROUPS TAIT PI DB'''''
        Dim files() As String = IO.Directory.GetFiles("Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\PI_Standard Drawing Notes\")
        For Each file As String In files
            directories = file.Split("\")
            d = directories.Length
            filename = directories(d - 1)

            Dim LVtitle As New ListViewGroup
            LVtitle.Header = filename.Substring(0, filename.Length - 10)
            ExistingNotesList.Groups.Add(LVtitle)

            Dim notes() As String = IO.File.ReadAllLines(file)
            Dim notesarray As New ArrayList()
            For x As Integer = 0 To notes.GetUpperBound(0)
                notesarray.Add(notes(x))
            Next
            For n = 0 To notesarray.Count - 1
                If notesarray.Item(n) = "" Then
                    GoTo NXTnote
                End If
                Dim notedetail() As String
                notedetail = notesarray.Item(n).split("|")
                Dim LVnote As New ListViewItem
                LVnote.Text = notedetail(1).Replace("[mew]", "μ")
                LVnote.Font = notefont
                LVnote.Group = LVtitle
                LVnote.Tag = notedetail(0)
                ExistingNotesList.Items.Add(LVnote)
                LVnote = Nothing
NXTnote:
            Next
            LVtitle = Nothing
        Next

        '''''Load existing notes if they exist'''''
        ' Connect to a running instance of Inventor. 
        Dim invApp As Inventor.Application
        invApp = System.Runtime.InteropServices.Marshal.GetActiveObject("Inventor.Application")

        ' Get the active document. 
        Dim Doc As Inventor.Document
        Doc = invApp.ActiveDocument

        ' Set a reference to the GeneralNotes object
        Dim oGeneralNotes As GeneralNotes
        oGeneralNotes = Doc.ActiveSheet.DrawingNotes.GeneralNotes
        Dim OGnote As String = ""
        Try

            For Each oGeneralNote As GeneralNote In oGeneralNotes
                'Load the existing note if one exists
                If oGeneralNote.Text Like "NOTES: *" Then
                    OGnote = oGeneralNote.FormattedText

                    Dim OGnotes() As String
                    Dim item As String
                    Dim firstP As Integer = 0
                    Dim loaditem(1) As String
                    Dim myDelims As String() = New String() {"<Br/>"}
                    OGnotes = OGnote.Split(myDelims, StringSplitOptions.None)
                    Dim i As Integer
                    'MsgBox(OGnotes.Length)
                    For i = 1 To OGnotes.Length - 2
                        Dim LVitem As New ListViewItem(OGnotes.Length - 3)
                        Dim LVsubitem As New ListViewItem.ListViewSubItem
                        ' MsgBox("i = " & i & vbNewLine &
                        '          "Current Note: " & OGnotes(i).ToString)
                        item = OGnotes(i).ToString.Substring(OGnotes(i).ToString.IndexOf(">") + 2, OGnotes(i).ToString.IndexOf("<", OGnotes(i).ToString.IndexOf(">") + 2) - OGnotes(i).ToString.IndexOf(">") - 2)

                        firstP = item.IndexOf(".")
                        'MsgBox("firstP: " & firstP)
                        loaditem(0) = item.Substring(0, firstP)
                        'MsgBox("loaditem(0): |" & loaditem(0) & "|")
                        loaditem(1) = item.Substring(3, item.Length - 3)
                        'MsgBox("loaditem(1): |" & loaditem(1) & "|")
                        LVitem.Text = loaditem(0)
                        LVsubitem.Text = loaditem(1)
                        'MsgBox(LVitem.Text & vbNewLine & LVsubitem.Text)
                        LVitem.SubItems.Add(LVsubitem)
                        'MsgBox("Add item# " & i)
                        NotesList.Items.Add(LVitem)
                    Next
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("Failed retrieval existing notes.")
        End Try

        invApp = Nothing
        Doc = Nothing

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim index As Integer = 1

        For Each item As ListViewItem In ExistingNotesList.SelectedItems
            Dim count As Integer
            count = NotesList.Items.Count
            index = count + 1

            If count <> 0 Then
                Dim lvi As New ListViewItem(count + 1)
                lvi.Text = CStr(index)
                lvi.SubItems.Add(item.Text)
                NotesList.Items.Add(lvi)
            Else
                Dim lvi As New ListViewItem(1)
                lvi.SubItems.Add(item.Text)
                NotesList.Items.Add(lvi)
            End If
        Next

    End Sub
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click

        For Each item As ListViewItem In NotesList.SelectedItems
            item.Remove()
        Next

        Call ReOrgNumbers()
    End Sub
    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        If NotesList.SelectedItems.Count > 1 Then
            MsgBox("You can only move one item at a time. Please Retry.")
        Else
            If NotesList.SelectedItems.Item(0).Index > 0 Then
                Dim indx As Integer
                Dim lvi As ListViewItem
                lvi = NotesList.SelectedItems.Item(0)
                indx = lvi.Index
                lvi.Remove()
                NotesList.Items.Insert(indx - 1, lvi)
            Else
                Exit Sub
            End If
        End If
        Call ReOrgNumbers()
    End Sub
    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        If NotesList.SelectedItems.Count > 1 Then
            MsgBox("You can only move one item at a time. Please Retry.")
        Else
            If NotesList.SelectedItems.Item(0).Index < NotesList.Items.Count - 1 Then
                Dim indx As Integer
                Dim lvi As ListViewItem
                lvi = NotesList.SelectedItems.Item(0)
                indx = lvi.Index
                lvi.Remove()
                NotesList.Items.Insert(indx + 1, lvi)
            Else
                Exit Sub
            End If
        End If
        Call ReOrgNumbers()
    End Sub
    Private Sub ReOrgNumbers()

        For Each item As ListViewItem In NotesList.Items
            If item.Text <> item.Index + 1 Then
                item.Text = item.Index + 1
            End If
        Next

    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        If NotesList.Items.Count = 0 Then
            MsgBox("There are no notes to add to the active drawing!")
            Exit Sub
        End If

        ' Connect to a running instance of Inventor. 
        Dim invApp As Inventor.Application
        invApp = System.Runtime.InteropServices.Marshal.GetActiveObject("Inventor.Application")

        ' Get the active document. 
        Dim Doc As Inventor._DrawingDocument
        Doc = invApp.ActiveDocument

        'Convert the NotesList to a string
        Dim builder As New StringBuilder
        builder.Append("<StyleOverride FontSize = '0.25'>NOTES: ").AppendLine()
        For Each item As ListViewItem In NotesList.Items
            ' Append a string and then another line break.
            builder.Append(" " & item.Text & ". " & item.SubItems.Item(1).Text).AppendLine()
        Next
        builder.Append("</StyleOverride>")
        ' Get internal String value from StringBuilder.
        Dim s As String = builder.ToString

        ' Set a reference to the GeneralNotes object
        Dim oGeneralNotes As GeneralNotes
        oGeneralNotes = Doc.ActiveSheet.DrawingNotes.GeneralNotes

        Dim oTG As TransientGeometry
        oTG = invApp.TransientGeometry

        'Delete existing note before adding a new one.
        Dim OGnote As String = ""
        Try
            For Each oGeneralNote As GeneralNote In oGeneralNotes
                If oGeneralNote.Text Like "NOTES: *" Then
                    OGnote = oGeneralNote.FormattedText
                    oGeneralNote.Delete()
                    Exit For
                End If
            Next
        Catch

        End Try

        Dim NewNote As GeneralNote

        Dim templateNAME As String
        templateNAME = Doc.ActiveSheet.TitleBlock.Name

        If templateNAME.ToString = "PROJECT KAPPA" Or templateNAME.ToString = "PROJECT KAPPA COVER SHEET" Then
            NewNote = oGeneralNotes.AddFitted(oTG.CreatePoint2d(1.5, 26.5), s)
        ElseIf templateNAME.ToString = "UNIVERSAL MARIO KART" Or templateNAME.ToString = "UNIVERSAL MARIO KART COVER SHEET" Then
            NewNote = oGeneralNotes.AddFitted(oTG.CreatePoint2d(1.25, 26.75), s)
        Else
            NewNote = oGeneralNotes.AddFitted(oTG.CreatePoint2d(1.25, 26.75), s)
        End If


        invApp = Nothing
        Doc = Nothing
        Me.Close()
    End Sub

    Private Sub btnShortcutMachined_Click(sender As Object, e As EventArgs) Handles btnShortcutMachined.Click
        Dim index As Integer = 1

        For Each item As ListViewItem In ExistingNotesList.Items

            If item.Tag = "M2" Or item.Tag = "F2" Or item.Tag = "P1" Or item.Tag = "P2" Then
                Dim count As Integer
                count = NotesList.Items.Count
                index = count + 1

                If count <> 0 Then
                    Dim lvi As New ListViewItem(count + 1)
                    lvi.Text = CStr(index)
                    lvi.SubItems.Add(item.Text)
                    NotesList.Items.Add(lvi)
                Else
                    Dim lvi As New ListViewItem(1)
                    lvi.SubItems.Add(item.Text)
                    NotesList.Items.Add(lvi)
                End If
            End If

        Next
    End Sub

    Private Sub btnShortcutCutLength_Click(sender As Object, e As EventArgs) Handles btnShortcutCutLength.Click
        Dim index As Integer = 1

        For Each item As ListViewItem In ExistingNotesList.Items

            If item.Tag = "F1" Then
                Dim count As Integer
                count = NotesList.Items.Count
                index = count + 1

                If count <> 0 Then
                    Dim lvi As New ListViewItem(count + 1)
                    lvi.Text = CStr(index)
                    lvi.SubItems.Add(item.Text)
                    NotesList.Items.Add(lvi)
                Else
                    Dim lvi As New ListViewItem(1)
                    lvi.SubItems.Add(item.Text)
                    NotesList.Items.Add(lvi)
                End If
            End If

        Next
    End Sub

    Private Sub btnShortcutSheetMetal_Click(sender As Object, e As EventArgs) Handles btnShortcutSheetMetal.Click
        Dim index As Integer = 1

        For Each item As ListViewItem In ExistingNotesList.Items

            If item.Tag = "M3" Then
                Dim count As Integer
                count = NotesList.Items.Count
                index = count + 1

                If count <> 0 Then
                    Dim lvi As New ListViewItem(count + 1)
                    lvi.Text = CStr(index)
                    lvi.SubItems.Add(item.Text)
                    NotesList.Items.Add(lvi)
                Else
                    Dim lvi As New ListViewItem(1)
                    lvi.SubItems.Add(item.Text)
                    NotesList.Items.Add(lvi)
                End If
            End If

        Next
    End Sub
End Class