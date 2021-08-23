<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRatio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRatio))
        Me.tbScaleA_Start = New System.Windows.Forms.TextBox()
        Me.tbScaleB_Start = New System.Windows.Forms.TextBox()
        Me.tbScaleA_End = New System.Windows.Forms.TextBox()
        Me.tbScaleB_End = New System.Windows.Forms.TextBox()
        Me.lblScaleB_Answer = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbScaleA_Value = New System.Windows.Forms.TextBox()
        Me.tbScaleB_Value = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblScaleA_Answer = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtFormula = New System.Windows.Forms.TextBox()
        Me.LblProportion = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbScaleA_Start
        '
        Me.tbScaleA_Start.BackColor = System.Drawing.Color.LightCyan
        Me.tbScaleA_Start.ForeColor = System.Drawing.Color.Black
        Me.tbScaleA_Start.Location = New System.Drawing.Point(30, 32)
        Me.tbScaleA_Start.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbScaleA_Start.Name = "tbScaleA_Start"
        Me.tbScaleA_Start.Size = New System.Drawing.Size(117, 22)
        Me.tbScaleA_Start.TabIndex = 0
        '
        'tbScaleB_Start
        '
        Me.tbScaleB_Start.BackColor = System.Drawing.Color.LightCyan
        Me.tbScaleB_Start.ForeColor = System.Drawing.Color.Black
        Me.tbScaleB_Start.Location = New System.Drawing.Point(30, 94)
        Me.tbScaleB_Start.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbScaleB_Start.Name = "tbScaleB_Start"
        Me.tbScaleB_Start.Size = New System.Drawing.Size(117, 22)
        Me.tbScaleB_Start.TabIndex = 1
        '
        'tbScaleA_End
        '
        Me.tbScaleA_End.BackColor = System.Drawing.Color.LightCyan
        Me.tbScaleA_End.ForeColor = System.Drawing.Color.Black
        Me.tbScaleA_End.Location = New System.Drawing.Point(190, 32)
        Me.tbScaleA_End.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbScaleA_End.Name = "tbScaleA_End"
        Me.tbScaleA_End.Size = New System.Drawing.Size(117, 22)
        Me.tbScaleA_End.TabIndex = 2
        '
        'tbScaleB_End
        '
        Me.tbScaleB_End.BackColor = System.Drawing.Color.LightCyan
        Me.tbScaleB_End.ForeColor = System.Drawing.Color.Black
        Me.tbScaleB_End.Location = New System.Drawing.Point(190, 94)
        Me.tbScaleB_End.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbScaleB_End.Name = "tbScaleB_End"
        Me.tbScaleB_End.Size = New System.Drawing.Size(117, 22)
        Me.tbScaleB_End.TabIndex = 3
        '
        'lblScaleB_Answer
        '
        Me.lblScaleB_Answer.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblScaleB_Answer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblScaleB_Answer.ForeColor = System.Drawing.Color.White
        Me.lblScaleB_Answer.Location = New System.Drawing.Point(190, 32)
        Me.lblScaleB_Answer.Name = "lblScaleB_Answer"
        Me.lblScaleB_Answer.Size = New System.Drawing.Size(117, 24)
        Me.lblScaleB_Answer.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightGray
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbScaleB_End)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tbScaleB_Start)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tbScaleA_Start)
        Me.GroupBox1.Controls.Add(Me.tbScaleA_End)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(9, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(320, 139)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "    Calculate Ratio Or Enter Values For Proportions"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(190, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 16)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "______________"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(163, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 16)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "B2"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(163, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "A2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(5, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 16)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "B1"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(30, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "______________"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(154, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 32)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = ":"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "A1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbScaleA_Value
        '
        Me.tbScaleA_Value.BackColor = System.Drawing.Color.LightCyan
        Me.tbScaleA_Value.ForeColor = System.Drawing.Color.Black
        Me.tbScaleA_Value.Location = New System.Drawing.Point(30, 32)
        Me.tbScaleA_Value.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbScaleA_Value.Name = "tbScaleA_Value"
        Me.tbScaleA_Value.Size = New System.Drawing.Size(117, 22)
        Me.tbScaleA_Value.TabIndex = 3
        '
        'tbScaleB_Value
        '
        Me.tbScaleB_Value.BackColor = System.Drawing.Color.LightCyan
        Me.tbScaleB_Value.ForeColor = System.Drawing.Color.Black
        Me.tbScaleB_Value.Location = New System.Drawing.Point(30, 94)
        Me.tbScaleB_Value.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbScaleB_Value.Name = "tbScaleB_Value"
        Me.tbScaleB_Value.Size = New System.Drawing.Size(117, 22)
        Me.tbScaleB_Value.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.LightGray
        Me.GroupBox2.Controls.Add(Me.LblProportion)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.lblScaleA_Answer)
        Me.GroupBox2.Controls.Add(Me.tbScaleA_Value)
        Me.GroupBox2.Controls.Add(Me.tbScaleB_Value)
        Me.GroupBox2.Controls.Add(Me.lblScaleB_Answer)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox2.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(9, 159)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(320, 141)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "                       Find Unknown Proportions"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(161, 97)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(26, 16)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "A ="
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(8, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 16)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "A"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(8, 97)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(17, 16)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "B"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(161, 36)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(27, 16)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "B ="
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblScaleA_Answer
        '
        Me.lblScaleA_Answer.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblScaleA_Answer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblScaleA_Answer.ForeColor = System.Drawing.Color.White
        Me.lblScaleA_Answer.Location = New System.Drawing.Point(190, 94)
        Me.lblScaleA_Answer.Name = "lblScaleA_Answer"
        Me.lblScaleA_Answer.Size = New System.Drawing.Size(117, 24)
        Me.lblScaleA_Answer.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Pink
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(250, 428)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 24)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Calculate"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(169, 428)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 24)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Clear"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DimGray
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Location = New System.Drawing.Point(9, 110)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(338, 312)
        Me.Panel1.TabIndex = 12
        '
        'TxtFormula
        '
        Me.TxtFormula.BackColor = System.Drawing.Color.LightCyan
        Me.TxtFormula.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFormula.ForeColor = System.Drawing.Color.Black
        Me.TxtFormula.Location = New System.Drawing.Point(9, 10)
        Me.TxtFormula.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtFormula.Multiline = True
        Me.TxtFormula.Name = "TxtFormula"
        Me.TxtFormula.ReadOnly = True
        Me.TxtFormula.Size = New System.Drawing.Size(338, 90)
        Me.TxtFormula.TabIndex = 13
        '
        'LblProportion
        '
        Me.LblProportion.Font = New System.Drawing.Font("Times New Roman", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProportion.Location = New System.Drawing.Point(150, 56)
        Me.LblProportion.Name = "LblProportion"
        Me.LblProportion.Size = New System.Drawing.Size(38, 38)
        Me.LblProportion.TabIndex = 9
        Me.LblProportion.Text = "::"
        Me.LblProportion.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FrmRatio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkTurquoise
        Me.ClientSize = New System.Drawing.Size(357, 460)
        Me.Controls.Add(Me.TxtFormula)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmRatio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ratio And Proportion Calculator"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbScaleA_Start As TextBox
    Friend WithEvents tbScaleB_Start As TextBox
    Friend WithEvents tbScaleA_End As TextBox
    Friend WithEvents tbScaleB_End As TextBox
    Friend WithEvents lblScaleB_Answer As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents tbScaleA_Value As TextBox
    Friend WithEvents tbScaleB_Value As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblScaleA_Answer As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtFormula As TextBox
    Friend WithEvents LblProportion As Label
End Class
