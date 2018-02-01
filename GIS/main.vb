Public Class main
    Dim markers As Boolean = False
    Const rgbmax As Integer = 255

    Private Const GET_FRAME As Long = 1084
    Private Const COPY As Long = 1054
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Short, ByVal lParam As String) As Integer

    Dim mark As New marker
    Private Declare Function Inp Lib "inpout32.dll" Alias "Inp32" (ByVal PortAddress As Short) As Short
    Private Declare Sub Out Lib "inpout32.dll" Alias "Out32" (ByVal PortAddress As Short, ByVal Value As Short)
    Public temp1x, tempx2 As Integer
    Public temp1y, tempy2 As Integer
    Dim g As Graphics
    Dim pointer As Integer
    Dim bits As Bitmap
    Dim mypen As Pen = New Pen(Color.Blue, 3)

    Public Declare Sub Sleep Lib "kernel32" Alias "Sleep" (ByVal dwMilliseconds As Long)
    Private Declare Function GetPixel Lib "gdi32" Alias "GetPixel" (ByVal hdc As IntPtr, ByVal x As Int32, ByVal y As Int32) As Int32

    'Following are the constants used for setting application priority
    Private Const NORMAL_PRIORITY_CLASS As Short = &H20S
    Private Const IDLE_PRIORITY_CLASS As Short = &H40S
    Private Const HIGH_PRIORITY_CLASS As Short = &H80S
    Private Const REALTIME_PRIORITY_CLASS As Short = &H100S
    Private Const PROCESS_DUP_HANDLE As Short = &H40S
    Private Const THREAD_BASE_PRIORITY_MAX As Short = 2
    Dim ln As Integer

    'Following are the declaration for windows form and controls
    Friend WithEvents HScrollBar1 As System.Windows.Forms.HScrollBar
    Friend WithEvents HScrollBar2 As System.Windows.Forms.HScrollBar
    Friend WithEvents HScrollBar3 As System.Windows.Forms.HScrollBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog


    'Declaration of different API used in the project just read it's name,
    'U can search on google for details description
    Private Declare Function SetThreadPriority Lib "kernel32" (ByVal hThread As Integer, ByVal nPriority As Integer) As Integer
    Private Declare Function SetPriorityClass Lib "kernel32" (ByVal hProcess As Integer, ByVal dwPriorityClass As Integer) As Integer
    Private Declare Function GetCurrentThread Lib "kernel32" () As Integer
    Private Declare Function GetCurrentProcess Lib "kernel32" () As Integer
    Private Declare Function GetObject Lib "gdi32" Alias "GetObjectA" (ByVal hObject As Integer, ByVal nCount As Integer, ByRef lpObject As Bitmap) As Integer
    Private Declare Function GetBitmapBits Lib "gdi32" (ByVal hBitmap As Integer, ByVal dwCount As Integer, ByRef lpBits As Object) As Integer
    Private Declare Function SetBitmapBits Lib "gdi32" (ByVal hBitmap As Integer, ByVal dwCount As Integer, ByRef lpBits As Byte()) As Integer

    Dim DPanel As Graphics
    Dim up As Point
    Dim down As Point
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents picImage As System.Windows.Forms.PictureBox
    Dim r As Rectangle
    Public mycam As New icam

    ' mouse click api's
    Public Declare Auto Function SetCursorPos Lib "User32.dll" (ByVal X As Integer, ByVal Y As Integer) As Long
    Public Declare Auto Function GetCursorPos Lib "User32.dll" (ByRef lpPoint As Point) As Long
    Public Declare Sub mouse_event Lib "user32" Alias "mouse_event" (ByVal dwFlags As Long, ByVal dx As Long, ByVal dy As Long, ByVal cButtons As Long, ByVal dwExtraInfo As Long)
    'Public Const MOUSEEVENTF_LEFTDOWN = &H2 ' left button down
    'Public Const MOUSEEVENTF_LEFTUP = &H4 ' left button up
    'Public Const MOUSEEVENTF_MIDDLEDOWN = &H20 ' middle button down
    'Public Const MOUSEEVENTF_MIDDLEUP = &H40 ' middle button up
    'Public Const MOUSEEVENTF_RIGHTDOWN = &H8 ' right button down
    'Public Const MOUSEEVENTF_RIGHTUP = &H10 ' right button up

#Region "Code Variables"
    Dim useMouse As Boolean = False
#End Region

    Private Sub main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'this event will execute on form load / start

        'as we need high speed processing so we need to set application priority to real time
        'following two line will increase application execution priority
        SetThreadPriority(GetCurrentThread, THREAD_BASE_PRIORITY_MAX)
        SetPriorityClass(GetCurrentProcess, REALTIME_PRIORITY_CLASS)

        'set picture box size mode to streach image 
        Me.picoutput.SizeMode = PictureBoxSizeMode.StretchImage
        'PictureBox3.Width = 1024
        'PictureBox3.Height = 768

    End Sub

    Private Sub startcam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startcam.Click
        
        mycam.initCam(Me.picoutput.Handle.ToInt32)
        'Call Shell("taskkill /f /im LifeFrame.exe")
        
        'mycam.initCam(Me.picoutput.Handle.ToInt32)
        ' Call Shell("taskkill /f /im webcamdell2.exe")
    End Sub


    Private Sub stopcam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stopcam.Click
        mycam.closeCam()
        End
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Timer1.Enabled = False
        pointer = 1
        PictureBox1.Visible = True
        picoutput.Visible = False
        g = Graphics.FromHwnd(mycam.hHwnd)
        'capture current view
        PictureBox1.Image = mycam.copyFrame(Me.picoutput, New RectangleF(0, 0, Me.picoutput.Width, Me.picoutput.Height))
    End Sub
    Private Sub PictureBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseClick
        Dim TempBitmap As New Bitmap(PictureBox1.Image)
        Dim MyColor As Color
        Dim i, j As Integer
        If pointer = 1 Then
            bits = New Bitmap(10, 10)
            For i = 0 To 9 Step 1
                For j = 0 To 9 Step 1
                    bits.SetPixel(i, j, TempBitmap.GetPixel(e.X - 5 + i, e.Y - 5 + j))
                Next
            Next
            MyColor = TempBitmap.GetPixel(e.X, e.Y)
            ' Me.Text = ("Pixel x=" & e.X & ", y=" & e.Y & ", color=" & MyColor.ToString)
            mark.mx = e.X
            mark.my = e.Y
            mark.mr = MyColor.R
            mark.mg = MyColor.G
            mark.mb = MyColor.B
            mark.ma = MyColor.A
            MsgBox("Move Markers : " & " " & mark.mr & " " & mark.mg & " " & mark.mb)
        End If
        'If pointer = 2 Then
        '    'If pointer = 1 Then
        '    bits = New Bitmap(10, 10)
        '    For i = 0 To 9 Step 1
        '        For j = 0 To 9 Step 1
        '            bits.SetPixel(i, j, TempBitmap.GetPixel(e.X - 5 + i, e.Y - 5 + j))
        '        Next
        '    Next
        '    MyColor = TempBitmap.GetPixel(e.X, e.Y)
        '    ' Me.Text = ("Pixel x=" & e.X & ", y=" & e.Y & ", color=" & MyColor.ToString)
        '    mark.cx = e.X
        '    mark.cy = e.Y
        '    mark.cr = MyColor.R
        '    mark.cg = MyColor.G
        '    mark.cb = MyColor.B
        '    MsgBox("Click Markers : " & " " & mark.cr & " " & mark.cg & " " & mark.cb)
        '    'End If
        'End If
        PictureBox1.Visible = False
        picoutput.Visible = True
    End Sub
    Dim tl, tr As Long
    Dim pixelcount As Integer = 0
    'actual camera view processing code
    Dim i As Integer    ' variable for vertical scanning
    Dim j As Integer    ' variable for Horizontal scanning
    Dim k As Integer
    Dim loose As Integer
    'l()

    Dim bm As Bitmap    ' variable use to hold current frame in memory 
    Dim x As Color

    Dim t As Boolean = False
    Dim dist As Integer

    Dim l As Integer
    Dim pre_i As Integer = 0
    Dim pre_j As Integer = 0
    Dim threshold As Integer = 5

    Public Sub ProcessPixel()
        On Error Resume Next
        Application.DoEvents()
        Dim tl, tr As Long
        Dim pixelcount As Integer = 0
        'actual camera view processing code
        Dim i As Integer    ' variable for vertical scanning
        Dim j As Integer    ' variable for Horizontal scanning
        Dim k As Integer
        Dim loose As Integer
        'l()

        Dim bm As Bitmap    ' variable use to hold current frame in memory 

        'load current or copy current frame in BM variable in memory

        bm = mycam.copyFrame(Me.picoutput, New RectangleF(0, 0, Me.picoutput.Width, Me.picoutput.Height))

        Dim data As IDataObject
        Dim bmap As Image


        '
        ' Copy image to clipboard
        '

        ' SendMessage(mycam.hHwnd, icam.WM_CAP_EDIT_COPY, 0, 0)

        '
        ' Get image from clipboard and convert it to a bitmap
        '
        'data = Clipboard.GetDataObject()
        'data.GetDataPresent(GetType(System.Drawing.Bitmap))
        'bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)
        ''bm = CType(data.GetData(GetType(System.Drawing.Bitmap)), Bitmap)
        'bm = New Bitmap(bmap)


        Dim x As Color

        Dim t As Boolean = False
        Dim dist As Integer

        Dim l As Integer

        'loop to move mouse
        For ln = 30 To 210 Step 30
            Me.Text = ln
            ' If t = True Then Exit For
            For i = Math.Max(temp1x - ln, 5) To Math.Min(temp1x + ln, 545) Step 5
                For j = Math.Max(temp1y - ln, 5) To Math.Min(temp1y + ln, 345) Step 5
                    'get current pixel color value

                    x = bm.GetPixel(i, j)
                    '   If (mark.mr <= x.R + 1 And mark.mr >= x.R - 1 And mark.mg <= x.G + 1 And mark.mg >= x.G - 1 And mark.mb <= x.B + 1 And mark.mb >= x.B - 1) Then
                    dist = Math.Sqrt((x.R - mark.mr) ^ 2 + (x.G - mark.mg) ^ 2 + (x.B - mark.mb) ^ 2)
                    If dist < threshold Then
                        Me.Text = i & " " & j & " " & x.A & " " & x.R & " " & x.G & " " & x.B
                        temp1x = i
                        temp1y = j
                        mark.mr = x.R
                        mark.mg = x.G
                        mark.mb = x.B
                        'mark.ma = x.A
                        Dim p As Point
                        'SetCursorPos(PictureBox1.Bounds.X * 2, PictureBox1.Bounds.Y * 2)
                        'DDAMouseMove(pre_i, pre_j, i * 2, j * 2)
                        pre_i = i
                        pre_j = j
                        Cursor.Position = New Point(i * 3, j * 3)
                        g.DrawRectangle(mypen, i - 2, j - 2, 5, 5)
                        t = True
                        Exit For
                    End If
                    If t = True Then Exit For
                Next
                'if red point found exit frame process loop
                If t = True Then Exit For
            Next
            If t = True Then Exit For
        Next

    End Sub

    Public Sub DDAMouseMove(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer)
        Dim dx, dy, isteps, xinc, yinc, icount, x, y As Double
        dx = x1 - x2
        dy = y1 - y2

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
            Cursor.Position = New Point(Math.Floor(x), Math.Floor(y))
            x -= xinc
            y -= yinc
        Next
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ln = 100
        Call ProcessPixel()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
 
        Timer1.Enabled = True
        Me.Size = New Size(20, 20)
  
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Me.Hide()
        'frmSnap.Show()
        PictureBox1.Visible = False
        picoutput.Visible = True

    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Timer1.Enabled = False
        pointer = 2
        'g = Graphics.FromHwnd(mycam.hHwnd)
        'capture current view
        PictureBox1.Image = mycam.copyFrame(Me.picoutput, New RectangleF(0, 0, Me.picoutput.Width, Me.picoutput.Height))
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Timer1.Enabled = False
        pointer = 3
        'g = Graphics.FromHwnd(mycam.hHwnd)
        'capture current view
        PictureBox1.Image = mycam.copyFrame(Me.picoutput, New RectangleF(0, 0, Me.picoutput.Width, Me.picoutput.Height))
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        pointer = 2
        Timer1.Enabled = False
        'PictureBox1.Visible = True
        'picoutput.Visible = False
        'g = Graphics.FromHwnd(mycam.hHwnd)
        ' capture current view
        '  PictureBox1.Image = mycam.copyFrame(Me.picoutput, New RectangleF(0, 0, Me.picoutput.Width, Me.picoutput.Height))
    End Sub

    
    Private Sub pictMOUSE_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    End Sub
    Private Sub pictPHOTO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pictPHOTO.Click
        mycam.closeCam()
        photo.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub pictDXBALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pictDXBALL.Click
        mycam.closeCam()
        dxball.ShowDialog()
        Timer1.Enabled = False
    End Sub
    Private Sub pictPAINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pictPAINT.Click
        mycam.closeCam()
        PaintFORM.ShowDialog()
        Timer1.Enabled = False
    End Sub
    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Button4.Text = "Enable Voice" Then
            Call Shell("Touchless.exe", AppWinStyle.Hide)
            Button4.Text = "Disable Voice"
        ElseIf Button4.Text = "Disable Voice" Then
            Call Shell("taskkill /f /im Touchless.exe")
            Button4.Text = "Enable Voice"
        End If

    End Sub

    Private Sub pictMOUSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub pictSETtINGS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pictSETtINGS.Click

    End Sub
End Class