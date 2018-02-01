Option Explicit On 
Option Strict On

Public Class frmMain
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents cmdViewStill As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.picOutput = New System.Windows.Forms.PictureBox
        Me.topMenu = New System.Windows.Forms.MainMenu
        Me.mnuFile = New System.Windows.Forms.MenuItem
        Me.mnuExit = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.mnuStartCam = New System.Windows.Forms.MenuItem
        Me.mnuStopCam = New System.Windows.Forms.MenuItem
        Me.mnuResetCam = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.mnuSetFrame = New System.Windows.Forms.MenuItem
        Me.tmrUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.sBar = New System.Windows.Forms.Label
        Me.cmdViewStill = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'picOutput
        '
        Me.picOutput.BackColor = System.Drawing.Color.Black
        Me.picOutput.Location = New System.Drawing.Point(8, 8)
        Me.picOutput.Name = "picOutput"
        Me.picOutput.Size = New System.Drawing.Size(344, 240)
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
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuStartCam, Me.mnuStopCam, Me.mnuResetCam})
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
        'MenuItem6
        '
        Me.MenuItem6.Index = 2
        Me.MenuItem6.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuSetFrame})
        Me.MenuItem6.Text = "Settings"
        '
        'mnuSetFrame
        '
        Me.mnuSetFrame.Index = 0
        Me.mnuSetFrame.Text = "Set Frame Rate"
        '
        'tmrUpdate
        '
        Me.tmrUpdate.Enabled = True
        Me.tmrUpdate.Interval = 500
        '
        'sBar
        '
        Me.sBar.Location = New System.Drawing.Point(8, 280)
        Me.sBar.Name = "sBar"
        Me.sBar.Size = New System.Drawing.Size(344, 24)
        Me.sBar.TabIndex = 1
        Me.sBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdViewStill
        '
        Me.cmdViewStill.Location = New System.Drawing.Point(8, 248)
        Me.cmdViewStill.Name = "cmdViewStill"
        Me.cmdViewStill.Size = New System.Drawing.Size(344, 24)
        Me.cmdViewStill.TabIndex = 2
        Me.cmdViewStill.Text = "View Still Frame"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(360, 305)
        Me.Controls.Add(Me.cmdViewStill)
        Me.Controls.Add(Me.sBar)
        Me.Controls.Add(Me.picOutput)
        Me.Menu = Me.topMenu
        Me.Name = "frmMain"
        Me.Text = "WebCam Viewer"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private myCam As iCam


    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    End Sub

    Private Sub mnuStopCam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStopCam.Click
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
        With SBar
            .Text = ("Curent FPS = " & myCam.FPS & "   " & _
                    "Running Status = " & myCam.iRunning)
        End With
    End Sub

    Private Sub cmdViewStill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewStill.Click
        If myCam.iRunning Then
            Dim a As FrmImage
            a = New FrmImage

            a.picImage.Image = myCam.copyFrame(Me.picOutput, New RectangleF(0, 0, _
                            Me.picOutput.Width, Me.picOutput.Height))
            a.Show()
        Else
            MessageBox.Show("Camera Is Not Running!")
        End If
    End Sub

End Class
