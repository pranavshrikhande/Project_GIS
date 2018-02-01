Public Class FrmImage
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
    Friend WithEvents picImage As System.Windows.Forms.PictureBox
    Friend WithEvents SBar As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents SaveFile As System.Windows.Forms.SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.picImage = New System.Windows.Forms.PictureBox
        Me.SBar = New System.Windows.Forms.Label
        Me.cmdSave = New System.Windows.Forms.Button
        Me.SaveFile = New System.Windows.Forms.SaveFileDialog
        Me.SuspendLayout()
        '
        'picImage
        '
        Me.picImage.BackColor = System.Drawing.Color.Black
        Me.picImage.Location = New System.Drawing.Point(8, 8)
        Me.picImage.Name = "picImage"
        Me.picImage.Size = New System.Drawing.Size(344, 240)
        Me.picImage.TabIndex = 1
        Me.picImage.TabStop = False
        '
        'SBar
        '
        Me.SBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SBar.Location = New System.Drawing.Point(8, 256)
        Me.SBar.Name = "SBar"
        Me.SBar.Size = New System.Drawing.Size(344, 32)
        Me.SBar.TabIndex = 2
        Me.SBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(80, 296)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(200, 24)
        Me.cmdSave.TabIndex = 3
        Me.cmdSave.Text = "Save Image"
        '
        'FrmImage
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(360, 326)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.SBar)
        Me.Controls.Add(Me.picImage)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmImage"
        Me.Text = "Capture Still Image"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmImage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SBar.Text = ("Image Taken At - " & TimeString & " , On the - " & DateString)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim savePath As String

        With SaveFile
            .Title = "Save Image File!"
            .Filter = "BitMap files only (.bmp)|*.bmp"
            .InitialDirectory = "c:\"
            .ShowDialog()
            savePath = .FileName
        End With
        picImage.Image.Save(savePath)
    End Sub
End Class
