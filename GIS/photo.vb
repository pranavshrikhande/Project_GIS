Public Class photo
    Dim mark As New marker
    Dim ma As New main
    Dim tx, ty As Integer
    Dim xp, yp, w, h As Integer
    Dim g As Graphics
    Dim i As Integer    ' variable for vertical scanning
    Dim j As Integer    ' variable for Horizontal scanning
    Dim bm As Bitmap    ' variable use to hold current frame in memory 
    Dim fileno As Integer
    Dim rx, ry, rw, rh As Integer

    Private Sub photo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ma.mycam.initCam(Me.picoutput.Handle.ToInt32)
        'tx = mark.mx
        'ty = mark.my
        fileno = 0
        Timer1.Enabled = True
        rx = 0
        ry = 0
        rw = 0
        rh = 0
        g = Graphics.FromHwnd(ma.mycam.hHwnd)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ma.mycam.closeCam()
        ma.Show()
        Me.Close()
        ma.mycam.initCam(ma.picoutput.Handle.ToInt32)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim pixelcount As Integer = 0
        'actual camera view processing code
        
        'load current or copy current frame in BM variable in memory

        bm = ma.mycam.copyFrame(Me.picoutput, New RectangleF(0, 0, Me.picoutput.Width, Me.picoutput.Height))

        Dim x As Color

        Dim t As Boolean = False

        'For i = 5 To picoutput.Width - 5 Step 5
        '    For j = 5 To picoutput.Height - 5 Step 5
        '        x = bm.GetPixel(i, j)
        '        'check for red color
        '        If x.R > 140 And x.G < 100 And x.B < 100 Then

        '            pixelcount += 1

        '            If pixelcount >= 5 Then
        '                g.DrawRectangle(Pens.Blue, New Rectangle(i - 2, j - 2, 5, 5))
        '                rx = i
        '                ry = j
        '                t = True
        '                Exit For
        '            End If
        '        Else
        '            pixelcount = 0
        '        End If
        '    Next
        '    If t = True Then Exit For
        'Next
        'pixelcount = 0
        't = False

        For i = picoutput.Width - 5 To 5 Step -5
            For j = picoutput.Height - 5 To 5 Step -5
                x = bm.GetPixel(i, j)
                'check for red color
                If x.R > 140 And x.G < 100 And x.B < 100 Then
                   
                    pixelcount += 1

                    If pixelcount >= 5 Then
                        g.DrawRectangle(Pens.Blue, i - 2, j - 2, 5, 5)
                        ' Cursor.Position = New Point(i * 2, j * 2)
                        rw = i
                        rh = j
                        t = True
                        Exit For
                    End If
                Else
                    pixelcount = 0
                End If
            Next
            If t = True Then Exit For
        Next
        g.DrawRectangle(Pens.Green, rx, ry, rw - rx, rh - ry)
        'g.DrawLine(Pens.Green, rx, ry, rw, rh)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim b As New Bitmap(rw - rx, rh - ry)
        bm = ma.mycam.copyFrame(Me.picoutput, New RectangleF(rx, ry, rw, rh))
        bm.Save("e:\program\Image & " & fileno & ".jpeg")
        fileno += 1
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class