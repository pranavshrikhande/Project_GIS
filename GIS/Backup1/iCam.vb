'This is user defined module which implements camera capturing and 
'frame capturing functions / methods

Public Class iCam

    'declaration of windows API function which are utilized in system

#Region "Api/constants"

    Private Const WM_CAP_DLG_VIDEOFORMAT As Integer = 1065
    Private Const WM_CAP_DLG_VIDEOSOURCE As Integer = 1066

    Private Const WS_CHILD As Integer = &H40000000
    Private Const WS_VISIBLE As Integer = &H10000000
    Private Const SWP_NOMOVE As Short = &H2S
    Private Const SWP_NOZORDER As Short = &H4S
    Private Const WM_USER As Short = &H400S
    Private Const WM_CAP_DRIVER_CONNECT As Integer = WM_USER + 10
    Private Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_USER + 11
    Private Const WM_CAP_SET_VIDEOFORMAT As Integer = WM_USER + 45
    Private Const WM_CAP_SET_PREVIEW As Integer = WM_USER + 50
    Private Const WM_CAP_SET_PREVIEWRATE As Integer = WM_USER + 52
    Private Const WM_CAP_GET_FRAME As Long = 1084
    Private Const WM_CAP_COPY As Long = 1054
    Private Const WM_CAP_START As Long = WM_USER
    Private Const WM_CAP_STOP As Long = (WM_CAP_START + 68)
    Private Const WM_CAP_SEQUENCE As Long = (WM_CAP_START + 62)
    Private Const WM_CAP_SET_SEQUENCE_SETUP As Long = (WM_CAP_START + 64)
    Private Const WM_CAP_FILE_SET_CAPTURE_FILEA As Long = (WM_CAP_START + 20)

    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Short, ByVal lParam As String) As Integer
    Private Declare Function capCreateCaptureWindowA Lib "avicap32.dll" (ByVal lpszWindowName As String, ByVal dwStyle As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Short, ByVal hWndParent As Integer, ByVal nID As Integer) As Integer
    Private Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short, ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, ByVal cbVer As Integer) As Boolean
    Private Declare Function BitBlt Lib "GDI32.DLL" (ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As Int32) As Boolean
    Public Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (ByVal pDst As Byte, ByVal pSrc As Color, ByVal ByteLen As Long)
#End Region

    Private iDevice As String   ' variable use to store driver ID 
    Private hHwnd As Integer    ' variable use to store camera object handle
    Private lwndC As Integer

    Public iRunning As Boolean

    Private CamFrameRate As Integer = 15
    Private OutputHeight As Integer = 240
    Private OutputWidth As Integer = 360

    Public Sub resetCam()
        'consider a condition user change the camera setting in that case we need to reset the camera
        'so, following function will
        'resets the camera after setting change
        If iRunning Then
            closeCam()              ' User define function to close the camera view
            Application.DoEvents()  ' process request from O.S. If any (Not related to project but this will protect application from termination or crash)

            If setCam() = False Then    ' Check cam is running or not user defined toggle variable
                MessageBox.Show("Errror Setting/Re-Setting Camera") 'show message box with error
            End If
        End If

    End Sub

    Public Sub initCam(ByVal parentH As Integer)
        'once we got the driver details we need to create it's object so,
        'This user defined function will get the camera object from O.S. 
        'now this object can be used further to start or stop camera CAPTURING

        If Me.iRunning = True Then          ' Check camera is already running or not
            MessageBox.Show("Camera Is Already Running")
            Exit Sub
        Else

            'Following line will get the camera object
            'where we need to provide
            'iDevice = Driver ID of camera driver
            'mode of visibility
            'co-ordinates
            'height and width
            hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, OutputWidth, CShort(OutputHeight), parentH, 0)


            If setCam() = False Then    ' Set camera initialized sucessfully
                MessageBox.Show("Error setting Up Camera")
            End If
        End If
    End Sub

    Public Sub setFrameRate(ByVal iRate As Long)
        'sets the frame rate of the camera
        CamFrameRate = CInt(1000 / iRate)

        resetCam()

    End Sub

    Private Function setCam() As Boolean
        'This user defined function will actually start camera capturing not processing
        'as we gathered camera object now by sending start signal / message to object 
        'we can start actual capturing

        'send WM_CAP_DRIVER_CONNECT signal to start capturing
        If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, CShort(iDevice), CType(0, String)) = 1 Then
            'Set preview rate that is frame per second
            SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, CShort(CamFrameRate), CType(0, String))
            'set priview mode ON
            SendMessage(hHwnd, WM_CAP_SET_PREVIEW, 1, CType(0, String))
            Me.iRunning = True 'Toggle variable to set camera is running now
            Return True
        Else
            Me.iRunning = False
            Return False
        End If
    End Function


    Public Sub ShowWebCamSize()
        'this user defined function will open camera video format 
        'window where user can set video format
        SendMessage(hHwnd, WM_CAP_DLG_VIDEOFORMAT, 0, 0)
    End Sub

    Public Sub ShowWebCamSource()
        'this user defined function will open camera video source
        'where user can select camera to user for capturing
        'as we can have more that one camera installed in the system
        SendMessage(hHwnd, WM_CAP_DLG_VIDEOSOURCE, 0, 0)
    End Sub

    Public Function closeCam() As Boolean
        'Closes the camera means stop CAPTURING
        If Me.iRunning Then
            'send WM_CAP_DRIVER_DISCONNECT signal to stop camera capturing
            'means stop curent view
            closeCam = CBool(SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, 0, CType(0, String)))
            Me.iRunning = False
        End If
    End Function

    Public Function copyFrame(ByVal src As PictureBox, ByVal rect As RectangleF) As Bitmap
        'as we know that camera view is streaming view means array of frame
        'for processing the camera view we need to get current image or frame 
        'so this user defined funtion will used to extract the current frame from
        'camera view
        If iRunning Then
            Dim srcPic As Graphics = src.CreateGraphics                 'Create a area to hold graphics in memory
            Dim srcBmp As New Bitmap(src.Width, src.Height, srcPic)     'Create a var to hold a current frame in memory
            Dim srcMem As Graphics = Graphics.FromImage(srcBmp)         'Copy current frame to memory

            Dim HDC1 As IntPtr = srcPic.GetHdc
            Dim HDC2 As IntPtr = srcMem.GetHdc

            BitBlt(HDC2, 0, 0, CInt(rect.Width), CInt(rect.Height), HDC1, CInt(rect.X), CInt(rect.Y), 13369376)

            copyFrame = CType(srcBmp.Clone(), Bitmap)

            'Clean Up 
            srcPic.ReleaseHdc(HDC1)
            srcMem.ReleaseHdc(HDC2)
            srcPic.Dispose()
            srcMem.Dispose()
        Else
            'MessageBox.Show("Camera Is Not Running!")
        End If
    End Function

    Public Function FPS() As Integer
        Return CInt(1000 / (CamFrameRate))
    End Function

End Class
