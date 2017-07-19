Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Opacity = 0
        Timer1.Enabled = True


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim savefilediaglog1 As New SaveFileDialog
        Try
            savefilediaglog1.Title = "savefile"
            savefilediaglog1.FileName = "Save As..."
            savefilediaglog1.Filter = "jpeg|*.jpeg"
            If savefilediaglog1.ShowDialog() = DialogResult.OK Then
                PictureBox1.Image.Save(savefilediaglog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp)

            End If
        Catch ex As Exception
            'Do nothing'
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim bounds As Rectangle
        Dim screenshot As System.Drawing.Bitmap
        Dim graph As Graphics
        bounds = Screen.PrimaryScreen.Bounds
        screenshot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        graph = Graphics.FromImage(screenshot)
        graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
        PictureBox1.Image = screenshot
        Timer1.Enabled = False
        Me.Opacity = 100

    End Sub
End Class
