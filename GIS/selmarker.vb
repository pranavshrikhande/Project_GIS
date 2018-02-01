Public Class selmarker
    Private Declare Function BitBlt Lib "GDI32.DLL" (ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As Int32) As Boolean
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Short, ByVal lParam As String) As Integer
    Const WM_CAP As Integer = &H400
    Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30
    Dim m As New main

    Dim bm, bm2 As Bitmap
    Dim f As Boolean

    Dim pix As Color
    Dim mark As New marker
    Private Declare Function Inp Lib "inpout32.dll" Alias "Inp32" (ByVal PortAddress As Short) As Short
    Private Declare Sub Out Lib "inpout32.dll" Alias "Out32" (ByVal PortAddress As Short, ByVal Value As Short)
    Dim temp1x As Integer
    Dim temp1y As Integer
    Dim g As Graphics
    Dim pointer As Integer
    Dim bits As Bitmap
    Dim mypen As Pen = New Pen(Color.Blue, 3)

    Dim bx, by As Integer 'banana
    Dim sx, sy As Integer 'strwaberry

    Public Declare Sub Sleep Lib "kernel32" Alias "Sleep" (ByVal dwMilliseconds As Long)

    Private Sub selmarker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Call Shell("C:\Program Files (x86)\Dell Webcam\Dell Webcam Central\WebcamDell2.exe")
        'Sleep(4000)
        'm.mycam.initCam(Me.PictureBox1.Handle.ToInt32)
        'Call Shell("taskkill /f /im webcamdell2.exe")
        'suchant(asu)
        'Call Shell("C:\Program Files (x86)\ASUS\ASUS LifeFrame3\LifeFrame.exe")
        'Sleep(2000)
        m.mycam.initCam(Me.PictureBox1.Handle.ToInt32)
        'Call Shell("taskkill /f /im LifeFrame.exe")
        ' bx = 158
        ' by = 84
    End Sub

    Public Sub Processpix()

        bm = m.mycam.copyFrame(Me.PictureBox1, New RectangleF(0, 0, Me.PictureBox1.Width, Me.PictureBox1.Height))
        If (bm.GetPixel(bx + 25, by + 25).R > pix.R + 5 Or bm.GetPixel(bx + 25, by + 25).R < pix.R - 5) Then
            f = True
        ElseIf (bm.GetPixel(bx + 25, by + 25).G > pix.G + 5 Or bm.GetPixel(bx + 25, by + 25).G < pix.G - 5) Then
            f = True
        ElseIf (bm.GetPixel(bx + 25, by + 25).B > pix.B + 5 Or bm.GetPixel(bx + 25, by + 25).B < pix.B - 5) Then
            f = True
        End If
        PictureBox3.Image = bm
        Me.Text = "R = " & bm.GetPixel(bx + 25, by + 25).R & "G = " & bm.GetPixel(bx + 25, by + 25).G & " B = " & bm.GetPixel(bx + 25, by + 25).B & "PIX R= " & pix.R & " " & "PIX G= " & pix.G & " " & "PIX B= " & pix.B & " "
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        f = False
        Call Processpix()
        If f = True Then
            banana.Visible = False
        End If
        Me.Text = Me.Text & f
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        bx = 408
        by = 121

        bm = m.mycam.copyFrame(Me.PictureBox1, New RectangleF(0, 0, Me.PictureBox1.Width, Me.PictureBox1.Height))
        pix = bm.GetPixel(bx + 25, by + 25)
       
        Timer1.Enabled = True
        banana.Visible = True
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        'PictureBox2.Location.X = 100
        PictureBox1.Image.Save("C:\a.jpeg")
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click

    End Sub
End Class