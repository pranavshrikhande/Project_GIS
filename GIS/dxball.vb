Public Class dxball
    Dim ma As New main
    Dim g As Graphics
    Dim ln As Integer
    Dim mark As New marker
    Dim cen As Integer
    Dim temp1x, temp1y As Integer
    Dim mypen As Pen = New Pen(Color.Blue, 3)

    Dim PixelCount As Integer

    Dim dir As String = "left" ' for slider
    Dim dir1 As String = "right" ' for ball
    Dim dir2 As String = "down" 'for ball

    ' code to move slider
    'If dir = "left" Then
    '        pictSLIDER.Left = pictSLIDER.Left - 10
    '    ElseIf dir = "right" Then
    '        pictSLIDER.Left = pictSLIDER.Left + 10
    '    End If
    '    If pictSLIDER.Left < 10 Then dir = "right"
    '    If pictSLIDER.Left > 400 Then dir = "left"
    ''*****
    Private Sub pictSLIDER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        pictSLIDER.Left = pictSLIDER.Left - 10
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Button2.Text = "Start Game" Then
            Button2.Text = "Stop Game"
            Label2.Text = "0"
            Timer1.Enabled = True
            Timer2.Enabled = True
        ElseIf Button2.Text = "Stop Game" Then
            Button2.Text = "Start Game"
            Timer1.Enabled = False
            Timer2.Enabled = False
            pictBALL.Location = New Point(10, 10)
            dir1 = "left"
            dir2 = "down"
        End If
    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If dir1 = "right" Then
            pictBALL.Left += 10
            If pictBALL.Left >= Panel1.Width - pictBALL.Width Then dir1 = "left"
        ElseIf dir1 = "left" Then
            pictBALL.Left -= 10
            If pictBALL.Left <= 0 Then dir1 = "right"
        End If

        If dir2 = "up" Then
            pictBALL.Top -= 10
            If pictBALL.Top <= 0 Then dir2 = "down"
        ElseIf dir2 = "down" Then
            pictBALL.Top += 10
            If pictBALL.Top >= Panel1.Height - pictBALL.Height - 35 Then
                dir2 = "up"
                If (pictBALL.Left > pictSLIDER.Left And pictBALL.Left < pictSLIDER.Right) Then
                    Label2.Text = Val(Label2.Text) + 10
                Else
                    Label2.Text = Val(Label2.Text) - 10
                End If
            End If
            End If

            'If pictBALL.Top >= pictSLIDER.Top - pictBALL.Top - 5 And (pictBALL.Left > pictSLIDER.Left And pictBALL.Left < pictSLIDER.Left) Then
            '    Label2.Text = Val(Label2.Text) - 10
            'ElseIf pictBALL.Top >= pictSLIDER.Top - pictBALL.Top - 5 Then
            '    Label2.Text = Val(Label2.Text) + 10
            'End If

            cen = pictBALL.Left + (pictBALL.Width / 2)
            'If pictBALL.Top + pictBALL.Height >= pictSLIDER.Top And pictBALL.Left >= pictSLIDER.Left And pictBALL.Left + pictBALL.Width <= pictSLIDER.Left + pictSLIDER.Width Then If dir2 = "down" Then Label2.Text = Val(Label2.Text) + 20 : dir2 = "up"
            If pictBALL.Top + pictBALL.Height >= pictSLIDER.Top And cen >= pictSLIDER.Left And cen <= pictSLIDER.Left + pictSLIDER.Width Then If dir2 = "uown" Then Label2.Text = Val(Label2.Text) + 20 : dir2 = "up"
    End Sub

    Private Sub dxball_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ma.mycam.initCam(Me.picoutput.Handle.ToInt32)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Call ProcessPixel()
    End Sub
    Public Sub ProcessPixel()
        On Error Resume Next
        'actual camera view processing code
        Dim i As Integer    ' variable for vertical scanning
        Dim j As Integer    ' variable for Horizontal scanning
        Dim bm As Bitmap    ' variable use to hold current frame in memory 


        'load current or copy current frame in BM variable in memory
        bm = ma.mycam.copyFrame(Me.picoutput, New RectangleF(0, 0, Me.picoutput.Width, Me.picoutput.Height))

        Dim t As Boolean = False
        'run loop to process current frame to get each pixel status
        For i = 5 To Me.picoutput.Width - 5 Step 1
            For j = 100 To Me.picoutput.Height - 5 Step 1

                'get current pixel color value
                Dim x As Color = bm.GetPixel(i, j)

                'companre color with threash hold value
                If x.R > 140 And x.G < 100 And x.B < 100 Then
                    ''If matched Then draw line and point

                    PixelCount += 1

                    If PixelCount >= 10 Then
                        Me.Text = i & " " & j
                        pictSLIDER.Location = New Point((i * 2) - (pictSLIDER.Width / 2), 373 + 35)
                        t = True
                        Exit For
                    End If
                Else
                    PixelCount = 0
                End If
            Next
            'if red point found exit frame process loop
            If t = True Then Exit For
        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Timer1.Enabled = False
        ma.mycam.closeCam()
        Me.Close()
    End Sub

    Private Sub pictSLIDER_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pictSLIDER.Click

    End Sub
End Class
