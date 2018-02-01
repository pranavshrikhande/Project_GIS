Public Class paintFORM
    Dim ma As New main
    Dim g As Graphics
    Dim p As Pen
    Dim mycam As New icam
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Short, ByVal lParam As String) As Integer

    Private Sub paint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        p = New Pen(Color.Black)
        pre_i = pre_j = 0
        g = Graphics.FromHwnd(ma.mycam.hHwnd)
        ma.mycam.initCam(Me.picoutput.Handle.ToInt32)
        Timer1.Enabled = True
        Me.Hide()
    End Sub
    Dim pre_i, pre_j As Integer
    Dim i, j As Integer
    Dim bm As Bitmap
    Dim pixelcount As Integer = 0
    'actual camera view processing code

    'load current or copy current frame in BM variable in memory
    Dim data As IDataObject
    Dim bmap As Image

    Public Sub DDAMouseMove(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer)
        Dim dx, dy, isteps, xinc, yinc, icount, x, y As Double
        dx = x1 - x2
        dy = y1 - y2
        '  Dim g1 As Graphics
        If (Math.Abs(dx) > Math.Abs(dy)) Then
            isteps = Math.Abs(dx)
        Else
            isteps = Math.Abs(dy)
        End If

        xinc = dx / isteps
        yinc = dy / isteps

        x = x1
        y = y1

        For icount = 1 To isteps
            'Cursor.Position = New Point(Math.Floor(x), Math.Floor(y))
            'g1 = Me.CreateGraphics
            'g1.DrawRectangle(p, New Rectangle(x - 2, y - 2, x + 2, y + 2))

            x -= xinc
            y -= yinc
        Next
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
       
        bm = ma.mycam.copyFrame(Me.picoutput, New RectangleF(0, 0, Me.picoutput.Width, Me.picoutput.Height))
        ' Copy image to clipboard
        '

        'SendMessage(mycam.hHwnd, icam.WM_CAP_EDIT_COPY, 0, 0)


        'Get image from clipboard and convert it to a bitmap

        'data = Clipboard.GetDataObject()
        'data.GetDataPresent(GetType(System.Drawing.Bitmap))
        ' bmap = New Bitmap(picoutput.Width, picoutput.Height)
        'bm = New Bitmap(data.GetData(GetType(System.Drawing.Bitmap)), True)
        ' bm = CType(data.GetData(GetType(System.Drawing.Bitmap)), Bitmap)
        'bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)
        'bm = CType(data.GetData(GetType(System.Drawing.Bitmap)), Bitmap)

        'bm = New Bitmap(bmap)


        Dim x As Color

        Dim t As Boolean = False

        For i = 5 To picoutput.Width - 5 Step 5
            For j = 5 To picoutput.Height - 5 Step 5
                x = bm.GetPixel(i, j)
                'check for red color
                If x.R > 140 And x.G < 100 And x.B < 100 Then
                    pixelcount += 1

                    If pixelcount >= 5 Then
                        'g.DrawRectangle(Pens.Black, i - 2, j - 2, 10, 10)
                        'g.DrawLine(Pens.IndianRed, i - 2, j - 2, i, j)
                        p.Width = 5
                        g.DrawLine(p, pre_i, pre_j, i, j)
                        'g.DrawEllipse(p, New Rectangle(i * 2, j * 2, 10, 10))
                        'g.DrawString("G I S", Font.Bold, Brushes.DarkCyan, i, j)
                        'g.DrawRectangle(p, New Rectangle(i * 3, j * 3, 5, 5))
                        'Cursor.Position = New Point(i * 3, j * 3)
                        'DDAMouseMove(pre_i, pre_j, i * 3, j * 3)
                        pre_i = i
                        pre_j = j
                        Me.Text = pre_i & " " & pre_j & " " & i & " " & j
                        t = True
                        Exit For
                    End If
                Else
                    pixelcount = 0
                End If
            Next
            If t = True Then Exit For
        Next
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        p = New Pen(Color.Red)
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        p = New Pen(Color.Green)
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        p = New Pen(Color.Blue)
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        p = New Pen(Color.Yellow)
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        p = New Pen(Color.Black)
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        p = New Pen(Color.Violet)
    End Sub
End Class