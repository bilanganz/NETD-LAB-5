Option Strict On
Imports System.IO

Public Class MainForm
    ''' <summary>
    ''' Code for Menu Strip (About, Exit, New, Open, SaveAs, Save, Copy, Cust, Paste, and Close)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show("NETD-2202" & vbNewLine & vbNewLine & "Lab #5" & vbNewLine & vbNewLine & "G. Nathan L.", "About")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        txtContent.Clear()
        Me.Text = "Text Editor"
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                Dim reader As New StreamReader(OpenFileDialog.FileName)
                txtContent.Text = reader.ReadToEnd
                reader.Close()
                Me.Text = "Text Editor " + OpenFileDialog.FileName
            Catch ex As Exception
                Throw New ApplicationException(ex.ToString())
            End Try
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveFileDialog.Filter = "TXT Files (*.txt*)|*.txt"

        If SaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then

            My.Computer.FileSystem.WriteAllText(SaveFileDialog.FileName, txtContent.Text, False)
            Me.Text = "Text Editor " + SaveFileDialog.FileName

        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click

        If (File.Exists(OpenFileDialog.FileName)) Then

            My.Computer.FileSystem.WriteAllText(OpenFileDialog.FileName, txtContent.Text, False)
            Me.Text = "Text Editor " + OpenFileDialog.FileName

        ElseIf (File.Exists(SaveFileDialog.FileName)) Then

            My.Computer.FileSystem.WriteAllText(SaveFileDialog.FileName, txtContent.Text, False)
            Me.Text = "Text Editor " + SaveFileDialog.FileName
        Else

            SaveFileDialog.Filter = "TXT Files (*.txt*)|*.txt"
            If SaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                My.Computer.FileSystem.WriteAllText(SaveFileDialog.FileName, txtContent.Text, False)
                Me.Text = "Text Editor " + SaveFileDialog.FileName
            End If

        End If

    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        txtContent.Copy()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        txtContent.Cut()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        txtContent.Paste()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Close()
    End Sub
End Class
