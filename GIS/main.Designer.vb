<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.startcam = New System.Windows.Forms.Button
        Me.stopcam = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.pictSETtINGS = New System.Windows.Forms.PictureBox
        Me.pictPAINT = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.pictDXBALL = New System.Windows.Forms.PictureBox
        Me.pictPHOTO = New System.Windows.Forms.PictureBox
        Me.picoutput = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.pictSETtINGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictPAINT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictDXBALL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictPHOTO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picoutput, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.startcam)
        Me.Panel2.Controls.Add(Me.stopcam)
        Me.Panel2.Location = New System.Drawing.Point(11, 13)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(161, 97)
        Me.Panel2.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(60, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Camera"
        '
        'startcam
        '
        Me.startcam.BackColor = System.Drawing.Color.White
        Me.startcam.BackgroundImage = Global.WebCamViewer.My.Resources.Resources.start
        Me.startcam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.startcam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.startcam.ForeColor = System.Drawing.Color.Black
        Me.startcam.Location = New System.Drawing.Point(9, 25)
        Me.startcam.Name = "startcam"
        Me.startcam.Size = New System.Drawing.Size(68, 65)
        Me.startcam.TabIndex = 15
        Me.startcam.UseVisualStyleBackColor = False
        '
        'stopcam
        '
        Me.stopcam.BackColor = System.Drawing.Color.White
        Me.stopcam.BackgroundImage = Global.WebCamViewer.My.Resources.Resources._stop
        Me.stopcam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.stopcam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stopcam.ForeColor = System.Drawing.Color.Black
        Me.stopcam.Location = New System.Drawing.Point(83, 25)
        Me.stopcam.Name = "stopcam"
        Me.stopcam.Size = New System.Drawing.Size(66, 65)
        Me.stopcam.TabIndex = 16
        Me.stopcam.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Red
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(84, 43)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(68, 31)
        Me.Button3.TabIndex = 23
        Me.Button3.Text = "Resume"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(640, 28)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(59, 44)
        Me.Button4.TabIndex = 43
        Me.Button4.Text = "Enable Voice"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(59, 4)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Marker"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Button3)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Location = New System.Drawing.Point(178, 13)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(164, 97)
        Me.Panel3.TabIndex = 44
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.BackgroundImage = Global.WebCamViewer.My.Resources.Resources.move
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(11, 26)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(67, 65)
        Me.Button1.TabIndex = 0
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.White
        Me.Button6.BackgroundImage = Global.WebCamViewer.My.Resources.Resources.move
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.Black
        Me.Button6.Location = New System.Drawing.Point(567, 17)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(67, 65)
        Me.Button6.TabIndex = 29
        Me.Button6.UseVisualStyleBackColor = False
        Me.Button6.Visible = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.BackgroundImage = Global.WebCamViewer.My.Resources.Resources.play_mouse
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(348, 11)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(106, 98)
        Me.Button2.TabIndex = 22
        Me.Button2.UseVisualStyleBackColor = False
        '
        'pictSETtINGS
        '
        Me.pictSETtINGS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pictSETtINGS.Image = Global.WebCamViewer.My.Resources.Resources.settings
        Me.pictSETtINGS.Location = New System.Drawing.Point(460, 12)
        Me.pictSETtINGS.Name = "pictSETtINGS"
        Me.pictSETtINGS.Size = New System.Drawing.Size(101, 97)
        Me.pictSETtINGS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictSETtINGS.TabIndex = 43
        Me.pictSETtINGS.TabStop = False
        Me.pictSETtINGS.Visible = False
        '
        'pictPAINT
        '
        Me.pictPAINT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pictPAINT.Image = Global.WebCamViewer.My.Resources.Resources.cooltext9248856982
        Me.pictPAINT.Location = New System.Drawing.Point(586, 240)
        Me.pictPAINT.Name = "pictPAINT"
        Me.pictPAINT.Size = New System.Drawing.Size(101, 102)
        Me.pictPAINT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictPAINT.TabIndex = 41
        Me.pictPAINT.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(32, 96)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(37, 31)
        Me.PictureBox2.TabIndex = 24
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'pictDXBALL
        '
        Me.pictDXBALL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pictDXBALL.Image = Global.WebCamViewer.My.Resources.Resources.dxball
        Me.pictDXBALL.Location = New System.Drawing.Point(586, 132)
        Me.pictDXBALL.Name = "pictDXBALL"
        Me.pictDXBALL.Size = New System.Drawing.Size(101, 102)
        Me.pictDXBALL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictDXBALL.TabIndex = 39
        Me.pictDXBALL.TabStop = False
        '
        'pictPHOTO
        '
        Me.pictPHOTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pictPHOTO.Image = Global.WebCamViewer.My.Resources.Resources.cooltext924884977
        Me.pictPHOTO.Location = New System.Drawing.Point(586, 348)
        Me.pictPHOTO.Name = "pictPHOTO"
        Me.pictPHOTO.Size = New System.Drawing.Size(101, 102)
        Me.pictPHOTO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictPHOTO.TabIndex = 40
        Me.pictPHOTO.TabStop = False
        '
        'picoutput
        '
        Me.picoutput.BackColor = System.Drawing.Color.Transparent
        Me.picoutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picoutput.Cursor = System.Windows.Forms.Cursors.Default
        Me.picoutput.Location = New System.Drawing.Point(12, 116)
        Me.picoutput.Name = "picoutput"
        Me.picoutput.Size = New System.Drawing.Size(550, 350)
        Me.picoutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picoutput.TabIndex = 18
        Me.picoutput.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(12, 116)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(550, 350)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(700, 478)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.pictSETtINGS)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pictPAINT)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.pictDXBALL)
        Me.Controls.Add(Me.pictPHOTO)
        Me.Controls.Add(Me.picoutput)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "G I S"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.pictSETtINGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictPAINT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictDXBALL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictPHOTO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picoutput, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents stopcam As System.Windows.Forms.Button
    Friend WithEvents startcam As System.Windows.Forms.Button
    Friend WithEvents picoutput As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents pictSETtINGS As System.Windows.Forms.PictureBox
    Friend WithEvents pictPAINT As System.Windows.Forms.PictureBox
    Friend WithEvents pictPHOTO As System.Windows.Forms.PictureBox
    Friend WithEvents pictDXBALL As System.Windows.Forms.PictureBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
