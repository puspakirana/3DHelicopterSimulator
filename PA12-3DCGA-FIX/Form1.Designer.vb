<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.displayBox = New System.Windows.Forms.PictureBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.timerStart = New System.Windows.Forms.Timer(Me.components)
        Me.btnStop = New System.Windows.Forms.Button()
        Me.cbHeli1 = New System.Windows.Forms.CheckBox()
        Me.cbHeli2 = New System.Windows.Forms.CheckBox()
        Me.tbSpeed = New System.Windows.Forms.TrackBar()
        Me.tbSpeed2 = New System.Windows.Forms.TrackBar()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        CType(Me.displayBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSpeed2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'displayBox
        '
        Me.displayBox.Location = New System.Drawing.Point(6, 6)
        Me.displayBox.Margin = New System.Windows.Forms.Padding(2)
        Me.displayBox.Name = "displayBox"
        Me.displayBox.Size = New System.Drawing.Size(836, 643)
        Me.displayBox.TabIndex = 0
        Me.displayBox.TabStop = False
        '
        'btnStart
        '
        Me.btnStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.btnStart.FlatAppearance.BorderSize = 0
        Me.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStart.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.ForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnStart.Location = New System.Drawing.Point(870, 15)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(83, 33)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = False
        '
        'timerStart
        '
        '
        'btnStop
        '
        Me.btnStop.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.btnStop.FlatAppearance.BorderSize = 0
        Me.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStop.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStop.ForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnStop.Location = New System.Drawing.Point(959, 15)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(82, 33)
        Me.btnStop.TabIndex = 2
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = False
        '
        'cbHeli1
        '
        Me.cbHeli1.AutoSize = True
        Me.cbHeli1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbHeli1.Location = New System.Drawing.Point(16, 28)
        Me.cbHeli1.Name = "cbHeli1"
        Me.cbHeli1.Size = New System.Drawing.Size(196, 21)
        Me.cbHeli1.TabIndex = 3
        Me.cbHeli1.Text = "Turn On Control Helicopter 1"
        Me.cbHeli1.UseVisualStyleBackColor = True
        '
        'cbHeli2
        '
        Me.cbHeli2.AutoSize = True
        Me.cbHeli2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbHeli2.Location = New System.Drawing.Point(15, 26)
        Me.cbHeli2.Name = "cbHeli2"
        Me.cbHeli2.Size = New System.Drawing.Size(196, 21)
        Me.cbHeli2.TabIndex = 4
        Me.cbHeli2.Text = "Turn On Control Helicopter 2"
        Me.cbHeli2.UseVisualStyleBackColor = True
        '
        'tbSpeed
        '
        Me.tbSpeed.LargeChange = 30
        Me.tbSpeed.Location = New System.Drawing.Point(16, 83)
        Me.tbSpeed.Maximum = 50
        Me.tbSpeed.Minimum = 10
        Me.tbSpeed.Name = "tbSpeed"
        Me.tbSpeed.Size = New System.Drawing.Size(184, 45)
        Me.tbSpeed.SmallChange = 10
        Me.tbSpeed.TabIndex = 7
        Me.tbSpeed.Value = 10
        '
        'tbSpeed2
        '
        Me.tbSpeed2.LargeChange = 30
        Me.tbSpeed2.Location = New System.Drawing.Point(16, 80)
        Me.tbSpeed2.Maximum = 50
        Me.tbSpeed2.Minimum = 10
        Me.tbSpeed2.Name = "tbSpeed2"
        Me.tbSpeed2.Size = New System.Drawing.Size(184, 45)
        Me.tbSpeed2.SmallChange = 10
        Me.tbSpeed2.TabIndex = 8
        Me.tbSpeed2.Value = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tbSpeed)
        Me.GroupBox1.Controls.Add(Me.cbHeli1)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(847, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(218, 139)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Helicopter 1 Controller"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Rotor Speed Control"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cbHeli2)
        Me.GroupBox2.Controls.Add(Me.tbSpeed2)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(847, 215)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(218, 133)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Helicopter 2 Controller"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Rotor Speed Control"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(847, 359)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(203, 195)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = resources.GetString("Label3.Text")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(847, 563)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(158, 39)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Mouse Control:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Drag and release on picture box" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " to make world rotation" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.btnReset.FlatAppearance.BorderSize = 0
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReset.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.ForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnReset.Location = New System.Drawing.Point(918, 612)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(83, 33)
        Me.btnReset.TabIndex = 14
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1070, 660)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.displayBox)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form1"
        Me.Text = "Helicopter Control Simulation"
        CType(Me.displayBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSpeed2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents displayBox As PictureBox
    Friend WithEvents btnStart As Button
    Friend WithEvents timerStart As Timer
    Friend WithEvents btnStop As Button
    Friend WithEvents cbHeli1 As CheckBox
    Friend WithEvents cbHeli2 As CheckBox
    Friend WithEvents tbSpeed As TrackBar
    Friend WithEvents tbSpeed2 As TrackBar
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnReset As Button
End Class
