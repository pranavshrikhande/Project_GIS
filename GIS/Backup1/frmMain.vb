'Option Explicit On 
'Option Strict On

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Private Declare Function Inp Lib "inpout32.dll" Alias "Inp32" (ByVal PortAddress As Short) As Short
    Private Declare Sub Out Lib "inpout32.dll" Alias "Out32" (ByVal PortAddress As Short, ByVal Value As Short)


    Private Declare Function GetPixel Lib "gdi32" Alias "GetPixel" (ByVal hdc As IntPtr, ByVal x As Int32, ByVal y As Int32) As Int32

    'Following are the constants used for setting application priority
    Private Const NORMAL_PRIORITY_CLASS As Short = &H20S
    Private Const IDLE_PRIORITY_CLASS As Short = &H40S
    Private Const HIGH_PRIORITY_CLASS As Short = &H80S
    Private Const REALTIME_PRIORITY_CLASS As Short = &H100S
    Private Const PROCESS_DUP_HANDLE As Short = &H40S
    Private Const THREAD_BASE_PRIORITY_MAX As Short = 2

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


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents picOutput As System.Windows.Forms.PictureBox
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuStartCam As System.Windows.Forms.MenuItem
    Friend WithEvents mnuStopCam As System.Windows.Forms.MenuItem
    Friend WithEvents mnuResetCam As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSetFrame As System.Windows.Forms.MenuItem
    Friend WithEvents topMenu As System.Windows.Forms.MainMenu
    Friend WithEvents tmrUpdate As System.Windows.Forms.Timer
    Friend WithEvents sBar As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.picOutput = New System.Windows.Forms.PictureBox
        Me.topMenu = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuFile = New System.Windows.Forms.MenuItem
        Me.mnuExit = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.mnuStartCam = New System.Windows.Forms.MenuItem
        Me.mnuStopCam = New System.Windows.Forms.MenuItem
        Me.mnuResetCam = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.mnuSetFrame = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.tmrUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.sBar = New System.Windows.Forms.Label
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar
        Me.HScrollBar2 = New System.Windows.Forms.HScrollBar
        Me.HScrollBar3 = New System.Windows.Forms.HScrollBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Label4 = New System.Windows.Forms.Label
        Me.picImage = New System.Windows.Forms.PictureBox
        CType(Me.picOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picOutput
        '
        Me.picOutput.BackColor = System.Drawing.Color.Black
        Me.picOutput.Location = New System.Drawing.Point(8, 8)
        Me.picOutput.Name = "picOutput"
        Me.picOutput.Size = New System.Drawing.Size(240, 240)
        Me.picOutput.TabIndex = 0
        Me.picOutput.TabStop = False
        '
        'topMenu
        '
        Me.topMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.MenuItem2, Me.MenuItem6})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
        Me.mnuFile.Text = "File"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 0
        Me.mnuExit.Text = "Exit"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuStartCam, Me.mnuStopCam, Me.mnuResetCam, Me.MenuItem3})
        Me.MenuItem2.Text = "Camera"
        '
        'mnuStartCam
        '
        Me.mnuStartCam.Index = 0
        Me.mnuStartCam.Text = "Start Camera"
        '
        'mnuStopCam
        '
        Me.mnuStopCam.Index = 1
        Me.mnuStopCam.Text = "Stop Camera"
        '
        'mnuResetCam
        '
        Me.mnuResetCam.Index = 2
        Me.mnuResetCam.Text = "Reset Camera"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 3
        Me.MenuItem3.Text = "Take Snap"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 2
        Me.MenuItem6.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuSetFrame, Me.MenuItem1})
        Me.MenuItem6.Text = "Settings"
        '
        'mnuSetFrame
        '
        Me.mnuSetFrame.Index = 0
        Me.mnuSetFrame.Text = "Set Frame Rate"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 1
        Me.MenuItem1.Text = "Video Setting"
        '
        'tmrUpdate
        '
        Me.tmrUpdate.Interval = 200
        '
        'sBar
        '
        Me.sBar.Location = New System.Drawing.Point(12, 370)
        Me.sBar.Name = "sBar"
        Me.sBar.Size = New System.Drawing.Size(236, 24)
        Me.sBar.TabIndex = 1
        Me.sBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Location = New System.Drawing.Point(84, 260)
        Me.HScrollBar1.Maximum = 255
        Me.HScrollBar1.Minimum = 1
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(164, 20)
        Me.HScrollBar1.TabIndex = 2
        Me.HScrollBar1.Value = 160
        '
        'HScrollBar2
        '
        Me.HScrollBar2.Location = New System.Drawing.Point(84, 293)
        Me.HScrollBar2.Maximum = 255
        Me.HScrollBar2.Minimum = 1
        Me.HScrollBar2.Name = "HScrollBar2"
        Me.HScrollBar2.Size = New System.Drawing.Size(164, 20)
        Me.HScrollBar2.TabIndex = 3
        Me.HScrollBar2.Value = 150
        '
        'HScrollBar3
        '
        Me.HScrollBar3.Location = New System.Drawing.Point(84, 329)
        Me.HScrollBar3.Maximum = 255
        Me.HScrollBar3.Minimum = 1
        Me.HScrollBar3.Name = "HScrollBar3"
        Me.HScrollBar3.Size = New System.Drawing.Size(164, 20)
        Me.HScrollBar3.TabIndex = 4
        Me.HScrollBar3.Value = 150
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 264)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Red"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 297)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Green"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 333)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Blue"
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(12, 414)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(236, 24)
        Me.Label4.TabIndex = 8
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picImage
        '
        Me.picImage.BackColor = System.Drawing.Color.Black
        Me.picImage.Location = New System.Drawing.Point(269, 109)
        Me.picImage.Name = "picImage"
        Me.picImage.Size = New System.Drawing.Size(240, 240)
        Me.picImage.TabIndex = 11
        Me.picImage.TabStop = False
        Me.picImage.Visible = False
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(257, 449)
        Me.Controls.Add(Me.picImage)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.HScrollBar3)
        Me.Controls.Add(Me.HScrollBar2)
        Me.Controls.Add(Me.HScrollBar1)
        Me.Controls.Add(Me.sBar)
        Me.Controls.Add(Me.picOutput)
        Me.Menu = Me.topMenu
        Me.Name = "frmMain"
        Me.Text = "WebCam Viewer"
        CType(Me.picOutput, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private myCam As iCam


    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'this event will execute on form load / start

        'as we need high speed processing so we need to set application priority to real time
        'following two line will increase application execution priority
        SetThreadPriority(GetCurrentThread, THREAD_BASE_PRIORITY_MAX)
        SetPriorityClass(GetCurrentProcess, REALTIME_PRIORITY_CLASS)

        'set picture box size mode to streach image 
        Me.picOutput.SizeMode = PictureBoxSizeMode.StretchImage
        myCam = New iCam


    End Sub

#Region "Menu items"

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        myCam.closeCam()
        Application.DoEvents()
        myCam = Nothing
    End Sub

    Private Sub mnuStartCam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStartCam.Click
        myCam.initCam(Me.picOutput.Handle.ToInt32)
        tmrUpdate.Enabled = True
    End Sub

    Private Sub mnuStopCam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStopCam.Click
        tmrUpdate.Enabled = False
        myCam.closeCam()
    End Sub

    Private Sub mnuResetCam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResetCam.Click
        myCam.resetCam()
    End Sub

    Private Sub mnuSetFrame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetFrame.Click
        Dim myFrames As String
        myFrames = InputBox("Enter Frames Per Second")
        myCam.setFrameRate(CInt(myFrames))
    End Sub

#End Region

    Private Sub tmrUpdate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrUpdate.Tick
        'this timer code will be executed in loop to process camera view
        Call ProcessPixel()
    End Sub

    Public Sub ProcessPixel()
        On Error Resume Next
        'actual camera view processing code
        Dim i As Integer    ' variable for vertical scanning
        Dim j As Integer    ' variable for Horizontal scanning
        Dim bm As Bitmap    ' variable use to hold current frame in memory 

        'Show current status and frame per second rate
        sBar.Text = ("Curent FPS = " & myCam.FPS & "   " & "Running Status = " & myCam.iRunning)

        'load current or copy current frame in BM variable in memory
        bm = myCam.copyFrame(Me.picOutput, New RectangleF(0, 0, Me.picOutput.Width, Me.picOutput.Height))

        Label4.ForeColor = Color.White  'set default color to normal status

        Dim t As Boolean = False
        'run loop to process current frame to get each pixel status
        For i = 100 To picOutput.Width - 100 Step 1         'Loop to start vertical pixel scan
            For j = 50 To picOutput.Height - 50 Step 1      'Loop to start horizontal pixel scan

                'X is a color object where it can hold R,G,B for given pixel value
                'after executing this line we get 
                'x.r as red
                'x.g as green
                'x.b as blue
                Dim x As Color = bm.GetPixel(i, j)


                'Now compare each value
                'compare color with threash hold value for red
                If x.R > HScrollBar1.Value And x.G < 75 And x.B < 75 Then
                    'If matched Then fill color with Red
                    t = True
                    Label4.ForeColor = Color.Red        'Show Status
                    Exit For
                End If

                'compare color with threash hold value for green
                If x.R < 75 And x.G > HScrollBar2.Value And x.B < 75 Then
                    'If matched Then fill color with green
                    t = True
                    Label4.ForeColor = Color.Green         'Show Status
                    Exit For
                End If

                'compare color with threash hold value for blue
                If x.R < 75 And x.G < 75 And x.B > HScrollBar3.Value Then
                    'If matched Then fill color with Blue
                    t = True
                    Label4.ForeColor = Color.Blue         'Show Status
                    Exit For
                End If

            Next
            'if red point found exit frame process loop
            If t = True Then Exit For
        Next

    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        'call user defined function to show camera source seletion window
        Call myCam.ShowWebCamSource()
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'clear picture box
        DPanel.Clear(Color.White)
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        'this function will save current view as a imgae on disk
        On Error Resume Next

        'set file saving type filter
        SaveFileDialog1.Filter = "All Files|*.*|JPG|*.jpg"

        'open save file dialog
        SaveFileDialog1.ShowDialog()

        'capture current view
        picImage.Image = myCam.copyFrame(Me.picOutput, New RectangleF(0, 0, Me.picOutput.Width, Me.picOutput.Height))

        'save image on disk
        picImage.Image.Save(SaveFileDialog1.FileName)
    End Sub

    Private Sub picImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picImage.Click

    End Sub
End Class
