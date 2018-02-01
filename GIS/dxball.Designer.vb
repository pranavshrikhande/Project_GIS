<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dxball
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dxball))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pictBALL = New System.Windows.Forms.PictureBox
        Me.pictSLIDER = New System.Windows.Forms.PictureBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.picoutput = New System.Windows.Forms.PictureBox
        Me.Panel1.SuspendLayout()
        CType(Me.pictBALL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictSLIDER, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picoutput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.pictBALL)
        Me.Panel1.Controls.Add(Me.pictSLIDER)
        Me.Panel1.Location = New System.Drawing.Point(332, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(640, 440)
        Me.Panel1.TabIndex = 23
        '
        'pictBALL
        '
        Me.pictBALL.BackColor = System.Drawing.Color.White
        Me.pictBALL.Image = CType(resources.GetObject("pictBALL.Image"), System.Drawing.Image)
        Me.pictBALL.Location = New System.Drawing.Point(-1, -1)
        Me.pictBALL.Name = "pictBALL"
        Me.pictBALL.Size = New System.Drawing.Size(72, 68)
        Me.pictBALL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictBALL.TabIndex = 24
        Me.pictBALL.TabStop = False
        '
        'pictSLIDER
        '
        Me.pictSLIDER.Image = CType(resources.GetObject("pictSLIDER.Image"), System.Drawing.Image)
        Me.pictSLIDER.Location = New System.Drawing.Point(327, 375)
        Me.pictSLIDER.Name = "pictSLIDER"
        Me.pictSLIDER.Size = New System.Drawing.Size(177, 30)
        Me.pictSLIDER.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictSLIDER.TabIndex = 23
        Me.pictSLIDER.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(121, 218)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(107, 33)
        Me.Button1.TabIndex = 24
        Me.Button1.Text = "Go Back"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(8, 218)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(107, 33)
        Me.Button2.TabIndex = 25
        Me.Button2.Text = "Start Game"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(50, 282)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 24)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Score : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(139, 282)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 24)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "0"
        '
        'Timer2
        '
        Me.Timer2.Interval = 2
        '
        'picoutput
        '
        Me.picoutput.BackColor = System.Drawing.Color.Transparent
        Me.picoutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picoutput.Cursor = System.Windows.Forms.Cursors.Default
        Me.picoutput.Image = CType(resources.GetObject("picoutput.Image"), System.Drawing.Image)
        Me.picoutput.Location = New System.Drawing.Point(8, 12)
        Me.picoutput.Name = "picoutput"
        Me.picoutput.Size = New System.Drawing.Size(320, 200)
        Me.picoutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picoutput.TabIndex = 28
        Me.picoutput.TabStop = False
        '
        'dxball
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(993, 458)
        Me.Controls.Add(Me.picoutput)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dxball"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "dxball"
        Me.Panel1.ResumeLayout(False)
        CType(Me.pictBALL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictSLIDER, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picoutput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pictBALL As System.Windows.Forms.PictureBox
    Friend WithEvents pictSLIDER As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents picoutput As System.Windows.Forms.PictureBox
    Protected WithEvents Timer2 As System.Windows.Forms.Timer
End Class
