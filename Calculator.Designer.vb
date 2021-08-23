<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCalculator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCalculator))
        Me.PnlNumberSystems = New System.Windows.Forms.Panel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DisplayFontSizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForeColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RatiosAndPorportionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseApplicationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnOctal = New System.Windows.Forms.RadioButton()
        Me.BtnHex = New System.Windows.Forms.RadioButton()
        Me.BtnDecimal = New System.Windows.Forms.RadioButton()
        Me.BtnBinary = New System.Windows.Forms.RadioButton()
        Me.PnlTrig = New System.Windows.Forms.Panel()
        Me.BtnGradian = New System.Windows.Forms.RadioButton()
        Me.BtnRadian = New System.Windows.Forms.RadioButton()
        Me.BtnDegree = New System.Windows.Forms.RadioButton()
        Me.PnlCalculator = New System.Windows.Forms.Panel()
        Me.BtnM4 = New System.Windows.Forms.Button()
        Me.BtnM3 = New System.Windows.Forms.Button()
        Me.BtnCubeRt = New System.Windows.Forms.Button()
        Me.BtnFourthRt = New System.Windows.Forms.Button()
        Me.BtnCloseParentheses = New System.Windows.Forms.Button()
        Me.BtnOpenParentheses = New System.Windows.Forms.Button()
        Me.BtnCtoF = New System.Windows.Forms.Button()
        Me.BtnMod = New System.Windows.Forms.Button()
        Me.BtnPercent = New System.Windows.Forms.Button()
        Me.BtnCE = New System.Windows.Forms.Button()
        Me.BtnComma = New System.Windows.Forms.Button()
        Me.BtnFtoC = New System.Windows.Forms.Button()
        Me.Btnex = New System.Windows.Forms.Button()
        Me.Btn10x = New System.Windows.Forms.Button()
        Me.BtnM2 = New System.Windows.Forms.Button()
        Me.BtnM1 = New System.Windows.Forms.Button()
        Me.Btn2Raised = New System.Windows.Forms.Button()
        Me.BtnE = New System.Windows.Forms.Button()
        Me.BtnSqrt = New System.Windows.Forms.Button()
        Me.BtnXsquared = New System.Windows.Forms.Button()
        Me.BtnXcubed = New System.Windows.Forms.Button()
        Me.BtnXraised = New System.Windows.Forms.Button()
        Me.BtnReciprocal = New System.Windows.Forms.Button()
        Me.BtnArcKey = New System.Windows.Forms.Button()
        Me.BtnHypKey = New System.Windows.Forms.Button()
        Me.BtnHexF = New System.Windows.Forms.Button()
        Me.BtnHexE = New System.Windows.Forms.Button()
        Me.BtnHexD = New System.Windows.Forms.Button()
        Me.BtnHexC = New System.Windows.Forms.Button()
        Me.BtnHexB = New System.Windows.Forms.Button()
        Me.BtnHexA = New System.Windows.Forms.Button()
        Me.BtnClearAll = New System.Windows.Forms.Button()
        Me.BtnCot = New System.Windows.Forms.Button()
        Me.BtnCsc = New System.Windows.Forms.Button()
        Me.BtnSec = New System.Windows.Forms.Button()
        Me.BtnPi = New System.Windows.Forms.Button()
        Me.BtnExp = New System.Windows.Forms.Button()
        Me.BtnTangent = New System.Windows.Forms.Button()
        Me.BtnCosine = New System.Windows.Forms.Button()
        Me.BtnSine = New System.Windows.Forms.Button()
        Me.BtnPoint = New System.Windows.Forms.Button()
        Me.BtnNegPos = New System.Windows.Forms.Button()
        Me.BtnLogx = New System.Windows.Forms.Button()
        Me.BtnLoge = New System.Windows.Forms.Button()
        Me.BtnLogc = New System.Windows.Forms.Button()
        Me.BtnEqual = New System.Windows.Forms.Button()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtnSubtract = New System.Windows.Forms.Button()
        Me.BtnMultiply = New System.Windows.Forms.Button()
        Me.BtnDivide = New System.Windows.Forms.Button()
        Me.Btn9 = New System.Windows.Forms.Button()
        Me.Btn8 = New System.Windows.Forms.Button()
        Me.Btn7 = New System.Windows.Forms.Button()
        Me.Btn6 = New System.Windows.Forms.Button()
        Me.Btn5 = New System.Windows.Forms.Button()
        Me.Btn4 = New System.Windows.Forms.Button()
        Me.Btn3 = New System.Windows.Forms.Button()
        Me.Btn2 = New System.Windows.Forms.Button()
        Me.Btn1 = New System.Windows.Forms.Button()
        Me.Btn0 = New System.Windows.Forms.Button()
        Me.LblFormula = New System.Windows.Forms.Label()
        Me.TbDisplay = New System.Windows.Forms.RichTextBox()
        Me.BtnCM = New System.Windows.Forms.Button()
        Me.PnlNumberSystems.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.PnlTrig.SuspendLayout()
        Me.PnlCalculator.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlNumberSystems
        '
        Me.PnlNumberSystems.BackColor = System.Drawing.Color.DimGray
        Me.PnlNumberSystems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlNumberSystems.ContextMenuStrip = Me.ContextMenuStrip1
        Me.PnlNumberSystems.Controls.Add(Me.BtnOctal)
        Me.PnlNumberSystems.Controls.Add(Me.BtnHex)
        Me.PnlNumberSystems.Controls.Add(Me.BtnDecimal)
        Me.PnlNumberSystems.Controls.Add(Me.BtnBinary)
        Me.PnlNumberSystems.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlNumberSystems.Location = New System.Drawing.Point(10, 62)
        Me.PnlNumberSystems.Name = "PnlNumberSystems"
        Me.PnlNumberSystems.Size = New System.Drawing.Size(283, 41)
        Me.PnlNumberSystems.TabIndex = 1
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DisplayFontSizeToolStripMenuItem, Me.RatiosAndPorportionsToolStripMenuItem, Me.AboutToolStripMenuItem, Me.CloseApplicationToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(197, 92)
        '
        'DisplayFontSizeToolStripMenuItem
        '
        Me.DisplayFontSizeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FontToolStripMenuItem, Me.BackColorToolStripMenuItem, Me.ForeColorToolStripMenuItem})
        Me.DisplayFontSizeToolStripMenuItem.Name = "DisplayFontSizeToolStripMenuItem"
        Me.DisplayFontSizeToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.DisplayFontSizeToolStripMenuItem.Text = "Customize Display"
        '
        'FontToolStripMenuItem
        '
        Me.FontToolStripMenuItem.Name = "FontToolStripMenuItem"
        Me.FontToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.FontToolStripMenuItem.Text = "Font"
        '
        'BackColorToolStripMenuItem
        '
        Me.BackColorToolStripMenuItem.Name = "BackColorToolStripMenuItem"
        Me.BackColorToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.BackColorToolStripMenuItem.Text = "BackColor"
        '
        'ForeColorToolStripMenuItem
        '
        Me.ForeColorToolStripMenuItem.Name = "ForeColorToolStripMenuItem"
        Me.ForeColorToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.ForeColorToolStripMenuItem.Text = "ForeColor"
        '
        'RatiosAndPorportionsToolStripMenuItem
        '
        Me.RatiosAndPorportionsToolStripMenuItem.Name = "RatiosAndPorportionsToolStripMenuItem"
        Me.RatiosAndPorportionsToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.RatiosAndPorportionsToolStripMenuItem.Text = "Ratios And Porportions"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'CloseApplicationToolStripMenuItem
        '
        Me.CloseApplicationToolStripMenuItem.Name = "CloseApplicationToolStripMenuItem"
        Me.CloseApplicationToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.CloseApplicationToolStripMenuItem.Text = "Close Application"
        '
        'BtnOctal
        '
        Me.BtnOctal.Appearance = System.Windows.Forms.Appearance.Button
        Me.BtnOctal.AutoSize = True
        Me.BtnOctal.BackColor = System.Drawing.Color.DarkBlue
        Me.BtnOctal.FlatAppearance.CheckedBackColor = System.Drawing.Color.RoyalBlue
        Me.BtnOctal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue
        Me.BtnOctal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnOctal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOctal.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOctal.ForeColor = System.Drawing.Color.White
        Me.BtnOctal.Location = New System.Drawing.Point(225, 5)
        Me.BtnOctal.Name = "BtnOctal"
        Me.BtnOctal.Size = New System.Drawing.Size(49, 27)
        Me.BtnOctal.TabIndex = 3
        Me.BtnOctal.Text = "Octal"
        Me.BtnOctal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtnOctal.UseVisualStyleBackColor = False
        '
        'BtnHex
        '
        Me.BtnHex.Appearance = System.Windows.Forms.Appearance.Button
        Me.BtnHex.AutoSize = True
        Me.BtnHex.BackColor = System.Drawing.Color.DarkBlue
        Me.BtnHex.FlatAppearance.CheckedBackColor = System.Drawing.Color.RoyalBlue
        Me.BtnHex.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue
        Me.BtnHex.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnHex.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnHex.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHex.ForeColor = System.Drawing.Color.White
        Me.BtnHex.Location = New System.Drawing.Point(133, 5)
        Me.BtnHex.Name = "BtnHex"
        Me.BtnHex.Size = New System.Drawing.Size(88, 27)
        Me.BtnHex.TabIndex = 2
        Me.BtnHex.Text = "Hexadecimal"
        Me.BtnHex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtnHex.UseVisualStyleBackColor = False
        '
        'BtnDecimal
        '
        Me.BtnDecimal.Appearance = System.Windows.Forms.Appearance.Button
        Me.BtnDecimal.AutoSize = True
        Me.BtnDecimal.BackColor = System.Drawing.Color.DarkBlue
        Me.BtnDecimal.FlatAppearance.CheckedBackColor = System.Drawing.Color.RoyalBlue
        Me.BtnDecimal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue
        Me.BtnDecimal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnDecimal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDecimal.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDecimal.ForeColor = System.Drawing.Color.White
        Me.BtnDecimal.Location = New System.Drawing.Point(65, 5)
        Me.BtnDecimal.Name = "BtnDecimal"
        Me.BtnDecimal.Size = New System.Drawing.Size(64, 27)
        Me.BtnDecimal.TabIndex = 1
        Me.BtnDecimal.Text = "Decimal"
        Me.BtnDecimal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtnDecimal.UseVisualStyleBackColor = False
        '
        'BtnBinary
        '
        Me.BtnBinary.Appearance = System.Windows.Forms.Appearance.Button
        Me.BtnBinary.AutoSize = True
        Me.BtnBinary.BackColor = System.Drawing.Color.DarkBlue
        Me.BtnBinary.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnBinary.FlatAppearance.CheckedBackColor = System.Drawing.Color.RoyalBlue
        Me.BtnBinary.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue
        Me.BtnBinary.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnBinary.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBinary.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBinary.ForeColor = System.Drawing.Color.White
        Me.BtnBinary.Location = New System.Drawing.Point(4, 5)
        Me.BtnBinary.Name = "BtnBinary"
        Me.BtnBinary.Size = New System.Drawing.Size(57, 27)
        Me.BtnBinary.TabIndex = 0
        Me.BtnBinary.Text = "Binary"
        Me.BtnBinary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtnBinary.UseVisualStyleBackColor = True
        '
        'PnlTrig
        '
        Me.PnlTrig.BackColor = System.Drawing.Color.DimGray
        Me.PnlTrig.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlTrig.ContextMenuStrip = Me.ContextMenuStrip1
        Me.PnlTrig.Controls.Add(Me.BtnGradian)
        Me.PnlTrig.Controls.Add(Me.BtnRadian)
        Me.PnlTrig.Controls.Add(Me.BtnDegree)
        Me.PnlTrig.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlTrig.Location = New System.Drawing.Point(321, 62)
        Me.PnlTrig.Name = "PnlTrig"
        Me.PnlTrig.Size = New System.Drawing.Size(200, 41)
        Me.PnlTrig.TabIndex = 2
        '
        'BtnGradian
        '
        Me.BtnGradian.Appearance = System.Windows.Forms.Appearance.Button
        Me.BtnGradian.AutoSize = True
        Me.BtnGradian.BackColor = System.Drawing.Color.DarkGreen
        Me.BtnGradian.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen
        Me.BtnGradian.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen
        Me.BtnGradian.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnGradian.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnGradian.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGradian.ForeColor = System.Drawing.Color.White
        Me.BtnGradian.Location = New System.Drawing.Point(128, 5)
        Me.BtnGradian.Name = "BtnGradian"
        Me.BtnGradian.Size = New System.Drawing.Size(63, 27)
        Me.BtnGradian.TabIndex = 2
        Me.BtnGradian.Text = "Gradian"
        Me.BtnGradian.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtnGradian.UseVisualStyleBackColor = False
        '
        'BtnRadian
        '
        Me.BtnRadian.Appearance = System.Windows.Forms.Appearance.Button
        Me.BtnRadian.AutoSize = True
        Me.BtnRadian.BackColor = System.Drawing.Color.DarkGreen
        Me.BtnRadian.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen
        Me.BtnRadian.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen
        Me.BtnRadian.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnRadian.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRadian.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRadian.ForeColor = System.Drawing.Color.White
        Me.BtnRadian.Location = New System.Drawing.Point(67, 5)
        Me.BtnRadian.Name = "BtnRadian"
        Me.BtnRadian.Size = New System.Drawing.Size(57, 27)
        Me.BtnRadian.TabIndex = 1
        Me.BtnRadian.Text = "Radian"
        Me.BtnRadian.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtnRadian.UseVisualStyleBackColor = False
        '
        'BtnDegree
        '
        Me.BtnDegree.Appearance = System.Windows.Forms.Appearance.Button
        Me.BtnDegree.AutoSize = True
        Me.BtnDegree.BackColor = System.Drawing.Color.DarkGreen
        Me.BtnDegree.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen
        Me.BtnDegree.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen
        Me.BtnDegree.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnDegree.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDegree.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDegree.ForeColor = System.Drawing.Color.White
        Me.BtnDegree.Location = New System.Drawing.Point(4, 5)
        Me.BtnDegree.Name = "BtnDegree"
        Me.BtnDegree.Size = New System.Drawing.Size(59, 27)
        Me.BtnDegree.TabIndex = 0
        Me.BtnDegree.Text = "Degree"
        Me.BtnDegree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtnDegree.UseVisualStyleBackColor = False
        '
        'PnlCalculator
        '
        Me.PnlCalculator.BackColor = System.Drawing.Color.Gray
        Me.PnlCalculator.ContextMenuStrip = Me.ContextMenuStrip1
        Me.PnlCalculator.Controls.Add(Me.BtnM4)
        Me.PnlCalculator.Controls.Add(Me.BtnM3)
        Me.PnlCalculator.Controls.Add(Me.BtnCubeRt)
        Me.PnlCalculator.Controls.Add(Me.BtnFourthRt)
        Me.PnlCalculator.Controls.Add(Me.BtnCloseParentheses)
        Me.PnlCalculator.Controls.Add(Me.BtnOpenParentheses)
        Me.PnlCalculator.Controls.Add(Me.BtnCtoF)
        Me.PnlCalculator.Controls.Add(Me.BtnMod)
        Me.PnlCalculator.Controls.Add(Me.BtnPercent)
        Me.PnlCalculator.Controls.Add(Me.BtnCE)
        Me.PnlCalculator.Controls.Add(Me.BtnComma)
        Me.PnlCalculator.Controls.Add(Me.BtnFtoC)
        Me.PnlCalculator.Controls.Add(Me.Btnex)
        Me.PnlCalculator.Controls.Add(Me.Btn10x)
        Me.PnlCalculator.Controls.Add(Me.BtnM2)
        Me.PnlCalculator.Controls.Add(Me.BtnM1)
        Me.PnlCalculator.Controls.Add(Me.Btn2Raised)
        Me.PnlCalculator.Controls.Add(Me.BtnE)
        Me.PnlCalculator.Controls.Add(Me.BtnSqrt)
        Me.PnlCalculator.Controls.Add(Me.BtnXsquared)
        Me.PnlCalculator.Controls.Add(Me.BtnXcubed)
        Me.PnlCalculator.Controls.Add(Me.BtnXraised)
        Me.PnlCalculator.Controls.Add(Me.BtnReciprocal)
        Me.PnlCalculator.Controls.Add(Me.BtnArcKey)
        Me.PnlCalculator.Controls.Add(Me.BtnHypKey)
        Me.PnlCalculator.Controls.Add(Me.BtnHexF)
        Me.PnlCalculator.Controls.Add(Me.BtnHexE)
        Me.PnlCalculator.Controls.Add(Me.BtnHexD)
        Me.PnlCalculator.Controls.Add(Me.BtnHexC)
        Me.PnlCalculator.Controls.Add(Me.BtnHexB)
        Me.PnlCalculator.Controls.Add(Me.BtnHexA)
        Me.PnlCalculator.Controls.Add(Me.BtnClearAll)
        Me.PnlCalculator.Controls.Add(Me.BtnCot)
        Me.PnlCalculator.Controls.Add(Me.BtnCsc)
        Me.PnlCalculator.Controls.Add(Me.BtnSec)
        Me.PnlCalculator.Controls.Add(Me.BtnPi)
        Me.PnlCalculator.Controls.Add(Me.BtnExp)
        Me.PnlCalculator.Controls.Add(Me.BtnTangent)
        Me.PnlCalculator.Controls.Add(Me.BtnCosine)
        Me.PnlCalculator.Controls.Add(Me.BtnSine)
        Me.PnlCalculator.Controls.Add(Me.BtnPoint)
        Me.PnlCalculator.Controls.Add(Me.BtnNegPos)
        Me.PnlCalculator.Controls.Add(Me.BtnLogx)
        Me.PnlCalculator.Controls.Add(Me.BtnLoge)
        Me.PnlCalculator.Controls.Add(Me.BtnLogc)
        Me.PnlCalculator.Controls.Add(Me.BtnEqual)
        Me.PnlCalculator.Controls.Add(Me.BtnAdd)
        Me.PnlCalculator.Controls.Add(Me.BtnSubtract)
        Me.PnlCalculator.Controls.Add(Me.BtnMultiply)
        Me.PnlCalculator.Controls.Add(Me.BtnDivide)
        Me.PnlCalculator.Controls.Add(Me.Btn9)
        Me.PnlCalculator.Controls.Add(Me.Btn8)
        Me.PnlCalculator.Controls.Add(Me.Btn7)
        Me.PnlCalculator.Controls.Add(Me.Btn6)
        Me.PnlCalculator.Controls.Add(Me.Btn5)
        Me.PnlCalculator.Controls.Add(Me.Btn4)
        Me.PnlCalculator.Controls.Add(Me.Btn3)
        Me.PnlCalculator.Controls.Add(Me.Btn2)
        Me.PnlCalculator.Controls.Add(Me.Btn1)
        Me.PnlCalculator.Controls.Add(Me.Btn0)
        Me.PnlCalculator.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlCalculator.ForeColor = System.Drawing.Color.DarkBlue
        Me.PnlCalculator.Location = New System.Drawing.Point(10, 109)
        Me.PnlCalculator.Name = "PnlCalculator"
        Me.PnlCalculator.Size = New System.Drawing.Size(603, 299)
        Me.PnlCalculator.TabIndex = 3
        '
        'BtnM4
        '
        Me.BtnM4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnM4.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown
        Me.BtnM4.FlatAppearance.BorderSize = 5
        Me.BtnM4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SaddleBrown
        Me.BtnM4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnM4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnM4.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnM4.ForeColor = System.Drawing.Color.SaddleBrown
        Me.BtnM4.Location = New System.Drawing.Point(542, 150)
        Me.BtnM4.Name = "BtnM4"
        Me.BtnM4.Size = New System.Drawing.Size(54, 46)
        Me.BtnM4.TabIndex = 57
        Me.BtnM4.Text = "ms4"
        Me.BtnM4.UseVisualStyleBackColor = False
        '
        'BtnM3
        '
        Me.BtnM3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnM3.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown
        Me.BtnM3.FlatAppearance.BorderSize = 5
        Me.BtnM3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SaddleBrown
        Me.BtnM3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnM3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnM3.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnM3.ForeColor = System.Drawing.Color.SaddleBrown
        Me.BtnM3.Location = New System.Drawing.Point(542, 102)
        Me.BtnM3.Name = "BtnM3"
        Me.BtnM3.Size = New System.Drawing.Size(54, 46)
        Me.BtnM3.TabIndex = 58
        Me.BtnM3.Text = "ms3"
        Me.BtnM3.UseVisualStyleBackColor = False
        '
        'BtnCubeRt
        '
        Me.BtnCubeRt.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnCubeRt.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnCubeRt.FlatAppearance.BorderSize = 5
        Me.BtnCubeRt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.BtnCubeRt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnCubeRt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCubeRt.Font = New System.Drawing.Font("Times New Roman", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCubeRt.ForeColor = System.Drawing.Color.Black
        Me.BtnCubeRt.Location = New System.Drawing.Point(418, 102)
        Me.BtnCubeRt.Name = "BtnCubeRt"
        Me.BtnCubeRt.Size = New System.Drawing.Size(60, 46)
        Me.BtnCubeRt.TabIndex = 51
        Me.BtnCubeRt.UseVisualStyleBackColor = False
        '
        'BtnFourthRt
        '
        Me.BtnFourthRt.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnFourthRt.FlatAppearance.BorderSize = 5
        Me.BtnFourthRt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.BtnFourthRt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnFourthRt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFourthRt.Font = New System.Drawing.Font("Times New Roman", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFourthRt.ForeColor = System.Drawing.Color.Black
        Me.BtnFourthRt.Location = New System.Drawing.Point(418, 54)
        Me.BtnFourthRt.Name = "BtnFourthRt"
        Me.BtnFourthRt.Size = New System.Drawing.Size(60, 46)
        Me.BtnFourthRt.TabIndex = 52
        Me.BtnFourthRt.UseVisualStyleBackColor = False
        '
        'BtnCloseParentheses
        '
        Me.BtnCloseParentheses.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnCloseParentheses.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnCloseParentheses.FlatAppearance.BorderSize = 5
        Me.BtnCloseParentheses.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.BtnCloseParentheses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnCloseParentheses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCloseParentheses.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCloseParentheses.ForeColor = System.Drawing.Color.Black
        Me.BtnCloseParentheses.Location = New System.Drawing.Point(282, 198)
        Me.BtnCloseParentheses.Name = "BtnCloseParentheses"
        Me.BtnCloseParentheses.Size = New System.Drawing.Size(72, 46)
        Me.BtnCloseParentheses.TabIndex = 54
        Me.BtnCloseParentheses.Text = ")"
        Me.BtnCloseParentheses.UseVisualStyleBackColor = False
        '
        'BtnOpenParentheses
        '
        Me.BtnOpenParentheses.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnOpenParentheses.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnOpenParentheses.FlatAppearance.BorderSize = 5
        Me.BtnOpenParentheses.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.BtnOpenParentheses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnOpenParentheses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOpenParentheses.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOpenParentheses.ForeColor = System.Drawing.Color.Black
        Me.BtnOpenParentheses.Location = New System.Drawing.Point(208, 198)
        Me.BtnOpenParentheses.Name = "BtnOpenParentheses"
        Me.BtnOpenParentheses.Size = New System.Drawing.Size(72, 46)
        Me.BtnOpenParentheses.TabIndex = 53
        Me.BtnOpenParentheses.Text = "("
        Me.BtnOpenParentheses.UseVisualStyleBackColor = False
        '
        'BtnCtoF
        '
        Me.BtnCtoF.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnCtoF.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed
        Me.BtnCtoF.FlatAppearance.BorderSize = 5
        Me.BtnCtoF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed
        Me.BtnCtoF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnCtoF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCtoF.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCtoF.ForeColor = System.Drawing.Color.DarkRed
        Me.BtnCtoF.Location = New System.Drawing.Point(418, 246)
        Me.BtnCtoF.Name = "BtnCtoF"
        Me.BtnCtoF.Size = New System.Drawing.Size(60, 46)
        Me.BtnCtoF.TabIndex = 38
        Me.BtnCtoF.Text = "C>F"
        Me.BtnCtoF.UseVisualStyleBackColor = False
        '
        'BtnMod
        '
        Me.BtnMod.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnMod.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnMod.FlatAppearance.BorderSize = 5
        Me.BtnMod.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.BtnMod.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMod.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMod.ForeColor = System.Drawing.Color.Black
        Me.BtnMod.Location = New System.Drawing.Point(480, 246)
        Me.BtnMod.Name = "BtnMod"
        Me.BtnMod.Size = New System.Drawing.Size(60, 46)
        Me.BtnMod.TabIndex = 49
        Me.BtnMod.Text = "mod"
        Me.BtnMod.UseVisualStyleBackColor = False
        '
        'BtnPercent
        '
        Me.BtnPercent.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnPercent.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnPercent.FlatAppearance.BorderSize = 5
        Me.BtnPercent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.BtnPercent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnPercent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPercent.Font = New System.Drawing.Font("Times New Roman", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPercent.ForeColor = System.Drawing.Color.Black
        Me.BtnPercent.Location = New System.Drawing.Point(480, 55)
        Me.BtnPercent.Name = "BtnPercent"
        Me.BtnPercent.Size = New System.Drawing.Size(60, 46)
        Me.BtnPercent.TabIndex = 42
        Me.BtnPercent.Text = "%"
        Me.BtnPercent.UseVisualStyleBackColor = False
        '
        'BtnCE
        '
        Me.BtnCE.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnCE.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnCE.FlatAppearance.BorderSize = 5
        Me.BtnCE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.BtnCE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnCE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCE.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCE.ForeColor = System.Drawing.Color.Black
        Me.BtnCE.Location = New System.Drawing.Point(480, 6)
        Me.BtnCE.Name = "BtnCE"
        Me.BtnCE.Size = New System.Drawing.Size(60, 46)
        Me.BtnCE.TabIndex = 55
        Me.BtnCE.Text = "CE"
        Me.BtnCE.UseVisualStyleBackColor = False
        '
        'BtnComma
        '
        Me.BtnComma.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnComma.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.BtnComma.FlatAppearance.BorderSize = 5
        Me.BtnComma.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.BtnComma.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnComma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnComma.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnComma.ForeColor = System.Drawing.Color.Blue
        Me.BtnComma.Location = New System.Drawing.Point(151, 150)
        Me.BtnComma.Name = "BtnComma"
        Me.BtnComma.Size = New System.Drawing.Size(55, 46)
        Me.BtnComma.TabIndex = 56
        Me.BtnComma.Text = ","
        Me.BtnComma.UseVisualStyleBackColor = False
        '
        'BtnFtoC
        '
        Me.BtnFtoC.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnFtoC.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed
        Me.BtnFtoC.FlatAppearance.BorderSize = 5
        Me.BtnFtoC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed
        Me.BtnFtoC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnFtoC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFtoC.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFtoC.ForeColor = System.Drawing.Color.DarkRed
        Me.BtnFtoC.Location = New System.Drawing.Point(356, 246)
        Me.BtnFtoC.Name = "BtnFtoC"
        Me.BtnFtoC.Size = New System.Drawing.Size(60, 46)
        Me.BtnFtoC.TabIndex = 37
        Me.BtnFtoC.Text = "F>C"
        Me.BtnFtoC.UseVisualStyleBackColor = False
        '
        'Btnex
        '
        Me.Btnex.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Btnex.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Btnex.FlatAppearance.BorderSize = 5
        Me.Btnex.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.Btnex.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Btnex.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnex.Font = New System.Drawing.Font("Times New Roman", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnex.ForeColor = System.Drawing.Color.Black
        Me.Btnex.Location = New System.Drawing.Point(480, 198)
        Me.Btnex.Name = "Btnex"
        Me.Btnex.Size = New System.Drawing.Size(60, 46)
        Me.Btnex.TabIndex = 44
        Me.Btnex.Text = "ex"
        Me.Btnex.UseVisualStyleBackColor = False
        '
        'Btn10x
        '
        Me.Btn10x.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Btn10x.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Btn10x.FlatAppearance.BorderSize = 5
        Me.Btn10x.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.Btn10x.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Btn10x.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn10x.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn10x.ForeColor = System.Drawing.Color.Black
        Me.Btn10x.Location = New System.Drawing.Point(480, 102)
        Me.Btn10x.Name = "Btn10x"
        Me.Btn10x.Size = New System.Drawing.Size(60, 46)
        Me.Btn10x.TabIndex = 46
        Me.Btn10x.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn10x.UseVisualStyleBackColor = False
        '
        'BtnM2
        '
        Me.BtnM2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnM2.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown
        Me.BtnM2.FlatAppearance.BorderSize = 5
        Me.BtnM2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SaddleBrown
        Me.BtnM2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnM2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnM2.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnM2.ForeColor = System.Drawing.Color.SaddleBrown
        Me.BtnM2.Location = New System.Drawing.Point(542, 54)
        Me.BtnM2.Name = "BtnM2"
        Me.BtnM2.Size = New System.Drawing.Size(54, 46)
        Me.BtnM2.TabIndex = 59
        Me.BtnM2.Text = "ms2"
        Me.BtnM2.UseVisualStyleBackColor = False
        '
        'BtnM1
        '
        Me.BtnM1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnM1.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown
        Me.BtnM1.FlatAppearance.BorderSize = 5
        Me.BtnM1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SaddleBrown
        Me.BtnM1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnM1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnM1.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnM1.ForeColor = System.Drawing.Color.SaddleBrown
        Me.BtnM1.Location = New System.Drawing.Point(542, 6)
        Me.BtnM1.Name = "BtnM1"
        Me.BtnM1.Size = New System.Drawing.Size(54, 46)
        Me.BtnM1.TabIndex = 60
        Me.BtnM1.Text = "ms1"
        Me.BtnM1.UseVisualStyleBackColor = False
        '
        'Btn2Raised
        '
        Me.Btn2Raised.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Btn2Raised.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Btn2Raised.FlatAppearance.BorderSize = 5
        Me.Btn2Raised.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.Btn2Raised.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Btn2Raised.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn2Raised.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn2Raised.ForeColor = System.Drawing.Color.Black
        Me.Btn2Raised.Location = New System.Drawing.Point(480, 150)
        Me.Btn2Raised.Name = "Btn2Raised"
        Me.Btn2Raised.Size = New System.Drawing.Size(60, 46)
        Me.Btn2Raised.TabIndex = 45
        Me.Btn2Raised.UseVisualStyleBackColor = False
        '
        'BtnE
        '
        Me.BtnE.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnE.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.BtnE.FlatAppearance.BorderSize = 5
        Me.BtnE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.BtnE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnE.Font = New System.Drawing.Font("Times New Roman", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnE.ForeColor = System.Drawing.Color.Blue
        Me.BtnE.Location = New System.Drawing.Point(542, 198)
        Me.BtnE.Name = "BtnE"
        Me.BtnE.Size = New System.Drawing.Size(54, 46)
        Me.BtnE.TabIndex = 39
        Me.BtnE.Text = "e"
        Me.BtnE.UseVisualStyleBackColor = False
        '
        'BtnSqrt
        '
        Me.BtnSqrt.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnSqrt.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnSqrt.FlatAppearance.BorderSize = 5
        Me.BtnSqrt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.BtnSqrt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnSqrt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSqrt.Font = New System.Drawing.Font("Times New Roman", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSqrt.ForeColor = System.Drawing.Color.Black
        Me.BtnSqrt.Location = New System.Drawing.Point(418, 150)
        Me.BtnSqrt.Name = "BtnSqrt"
        Me.BtnSqrt.Size = New System.Drawing.Size(60, 46)
        Me.BtnSqrt.TabIndex = 50
        Me.BtnSqrt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSqrt.UseVisualStyleBackColor = False
        '
        'BtnXsquared
        '
        Me.BtnXsquared.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnXsquared.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnXsquared.FlatAppearance.BorderSize = 5
        Me.BtnXsquared.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.BtnXsquared.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnXsquared.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnXsquared.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXsquared.ForeColor = System.Drawing.Color.Black
        Me.BtnXsquared.Location = New System.Drawing.Point(356, 150)
        Me.BtnXsquared.Name = "BtnXsquared"
        Me.BtnXsquared.Size = New System.Drawing.Size(60, 46)
        Me.BtnXsquared.TabIndex = 40
        Me.BtnXsquared.UseVisualStyleBackColor = False
        '
        'BtnXcubed
        '
        Me.BtnXcubed.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnXcubed.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnXcubed.FlatAppearance.BorderSize = 5
        Me.BtnXcubed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.BtnXcubed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnXcubed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnXcubed.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXcubed.ForeColor = System.Drawing.Color.Black
        Me.BtnXcubed.Location = New System.Drawing.Point(356, 102)
        Me.BtnXcubed.Name = "BtnXcubed"
        Me.BtnXcubed.Size = New System.Drawing.Size(60, 46)
        Me.BtnXcubed.TabIndex = 41
        Me.BtnXcubed.UseVisualStyleBackColor = False
        '
        'BtnXraised
        '
        Me.BtnXraised.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnXraised.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnXraised.FlatAppearance.BorderSize = 5
        Me.BtnXraised.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.BtnXraised.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnXraised.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnXraised.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXraised.ForeColor = System.Drawing.Color.Black
        Me.BtnXraised.Location = New System.Drawing.Point(356, 54)
        Me.BtnXraised.Name = "BtnXraised"
        Me.BtnXraised.Size = New System.Drawing.Size(60, 46)
        Me.BtnXraised.TabIndex = 47
        Me.BtnXraised.Text = "x^"
        Me.BtnXraised.UseVisualStyleBackColor = False
        '
        'BtnReciprocal
        '
        Me.BtnReciprocal.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnReciprocal.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnReciprocal.FlatAppearance.BorderSize = 5
        Me.BtnReciprocal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.BtnReciprocal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnReciprocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnReciprocal.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReciprocal.ForeColor = System.Drawing.Color.Black
        Me.BtnReciprocal.Location = New System.Drawing.Point(356, 6)
        Me.BtnReciprocal.Name = "BtnReciprocal"
        Me.BtnReciprocal.Size = New System.Drawing.Size(60, 46)
        Me.BtnReciprocal.TabIndex = 43
        Me.BtnReciprocal.Text = "1/(x)"
        Me.BtnReciprocal.UseVisualStyleBackColor = False
        '
        'BtnArcKey
        '
        Me.BtnArcKey.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnArcKey.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen
        Me.BtnArcKey.FlatAppearance.BorderSize = 5
        Me.BtnArcKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen
        Me.BtnArcKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnArcKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnArcKey.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnArcKey.ForeColor = System.Drawing.Color.DarkGreen
        Me.BtnArcKey.Location = New System.Drawing.Point(282, 150)
        Me.BtnArcKey.Name = "BtnArcKey"
        Me.BtnArcKey.Size = New System.Drawing.Size(72, 46)
        Me.BtnArcKey.TabIndex = 33
        Me.BtnArcKey.Text = "Arc"
        Me.BtnArcKey.UseVisualStyleBackColor = False
        '
        'BtnHypKey
        '
        Me.BtnHypKey.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnHypKey.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen
        Me.BtnHypKey.FlatAppearance.BorderSize = 5
        Me.BtnHypKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen
        Me.BtnHypKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnHypKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnHypKey.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHypKey.ForeColor = System.Drawing.Color.DarkGreen
        Me.BtnHypKey.Location = New System.Drawing.Point(208, 150)
        Me.BtnHypKey.Name = "BtnHypKey"
        Me.BtnHypKey.Size = New System.Drawing.Size(72, 46)
        Me.BtnHypKey.TabIndex = 28
        Me.BtnHypKey.Text = "Hyp"
        Me.BtnHypKey.UseVisualStyleBackColor = False
        '
        'BtnHexF
        '
        Me.BtnHexF.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnHexF.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.BtnHexF.FlatAppearance.BorderSize = 5
        Me.BtnHexF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.BtnHexF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnHexF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnHexF.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHexF.ForeColor = System.Drawing.Color.Blue
        Me.BtnHexF.Location = New System.Drawing.Point(282, 246)
        Me.BtnHexF.Name = "BtnHexF"
        Me.BtnHexF.Size = New System.Drawing.Size(72, 46)
        Me.BtnHexF.TabIndex = 16
        Me.BtnHexF.Text = "F"
        Me.BtnHexF.UseVisualStyleBackColor = False
        '
        'BtnHexE
        '
        Me.BtnHexE.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnHexE.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.BtnHexE.FlatAppearance.BorderSize = 5
        Me.BtnHexE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.BtnHexE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnHexE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnHexE.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHexE.ForeColor = System.Drawing.Color.Blue
        Me.BtnHexE.Location = New System.Drawing.Point(208, 246)
        Me.BtnHexE.Name = "BtnHexE"
        Me.BtnHexE.Size = New System.Drawing.Size(72, 46)
        Me.BtnHexE.TabIndex = 15
        Me.BtnHexE.Text = "E"
        Me.BtnHexE.UseVisualStyleBackColor = False
        '
        'BtnHexD
        '
        Me.BtnHexD.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnHexD.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.BtnHexD.FlatAppearance.BorderSize = 5
        Me.BtnHexD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.BtnHexD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnHexD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnHexD.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHexD.ForeColor = System.Drawing.Color.Blue
        Me.BtnHexD.Location = New System.Drawing.Point(151, 246)
        Me.BtnHexD.Name = "BtnHexD"
        Me.BtnHexD.Size = New System.Drawing.Size(55, 46)
        Me.BtnHexD.TabIndex = 14
        Me.BtnHexD.Text = "D"
        Me.BtnHexD.UseVisualStyleBackColor = False
        '
        'BtnHexC
        '
        Me.BtnHexC.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnHexC.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.BtnHexC.FlatAppearance.BorderSize = 5
        Me.BtnHexC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.BtnHexC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnHexC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnHexC.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHexC.ForeColor = System.Drawing.Color.Blue
        Me.BtnHexC.Location = New System.Drawing.Point(103, 246)
        Me.BtnHexC.Name = "BtnHexC"
        Me.BtnHexC.Size = New System.Drawing.Size(46, 46)
        Me.BtnHexC.TabIndex = 13
        Me.BtnHexC.Text = "C"
        Me.BtnHexC.UseVisualStyleBackColor = False
        '
        'BtnHexB
        '
        Me.BtnHexB.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnHexB.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.BtnHexB.FlatAppearance.BorderSize = 5
        Me.BtnHexB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.BtnHexB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnHexB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnHexB.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHexB.ForeColor = System.Drawing.Color.Blue
        Me.BtnHexB.Location = New System.Drawing.Point(55, 246)
        Me.BtnHexB.Name = "BtnHexB"
        Me.BtnHexB.Size = New System.Drawing.Size(46, 46)
        Me.BtnHexB.TabIndex = 12
        Me.BtnHexB.Text = "B"
        Me.BtnHexB.UseVisualStyleBackColor = False
        '
        'BtnHexA
        '
        Me.BtnHexA.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnHexA.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.BtnHexA.FlatAppearance.BorderSize = 5
        Me.BtnHexA.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.BtnHexA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnHexA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnHexA.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHexA.ForeColor = System.Drawing.Color.Blue
        Me.BtnHexA.Location = New System.Drawing.Point(7, 246)
        Me.BtnHexA.Name = "BtnHexA"
        Me.BtnHexA.Size = New System.Drawing.Size(46, 46)
        Me.BtnHexA.TabIndex = 11
        Me.BtnHexA.Text = "A"
        Me.BtnHexA.UseVisualStyleBackColor = False
        '
        'BtnClearAll
        '
        Me.BtnClearAll.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClearAll.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClearAll.FlatAppearance.BorderSize = 5
        Me.BtnClearAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.BtnClearAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClearAll.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClearAll.ForeColor = System.Drawing.Color.Black
        Me.BtnClearAll.Location = New System.Drawing.Point(418, 6)
        Me.BtnClearAll.Name = "BtnClearAll"
        Me.BtnClearAll.Size = New System.Drawing.Size(60, 46)
        Me.BtnClearAll.TabIndex = 48
        Me.BtnClearAll.Text = "C"
        Me.BtnClearAll.UseVisualStyleBackColor = False
        '
        'BtnCot
        '
        Me.BtnCot.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnCot.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen
        Me.BtnCot.FlatAppearance.BorderSize = 5
        Me.BtnCot.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen
        Me.BtnCot.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnCot.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCot.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCot.ForeColor = System.Drawing.Color.DarkGreen
        Me.BtnCot.Location = New System.Drawing.Point(282, 102)
        Me.BtnCot.Name = "BtnCot"
        Me.BtnCot.Size = New System.Drawing.Size(72, 46)
        Me.BtnCot.TabIndex = 34
        Me.BtnCot.Text = "cot"
        Me.BtnCot.UseVisualStyleBackColor = False
        '
        'BtnCsc
        '
        Me.BtnCsc.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnCsc.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen
        Me.BtnCsc.FlatAppearance.BorderSize = 5
        Me.BtnCsc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen
        Me.BtnCsc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnCsc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCsc.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCsc.ForeColor = System.Drawing.Color.DarkGreen
        Me.BtnCsc.Location = New System.Drawing.Point(282, 54)
        Me.BtnCsc.Name = "BtnCsc"
        Me.BtnCsc.Size = New System.Drawing.Size(72, 46)
        Me.BtnCsc.TabIndex = 35
        Me.BtnCsc.Text = "csc"
        Me.BtnCsc.UseVisualStyleBackColor = False
        '
        'BtnSec
        '
        Me.BtnSec.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnSec.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen
        Me.BtnSec.FlatAppearance.BorderSize = 5
        Me.BtnSec.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen
        Me.BtnSec.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnSec.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSec.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSec.ForeColor = System.Drawing.Color.DarkGreen
        Me.BtnSec.Location = New System.Drawing.Point(282, 6)
        Me.BtnSec.Name = "BtnSec"
        Me.BtnSec.Size = New System.Drawing.Size(72, 46)
        Me.BtnSec.TabIndex = 36
        Me.BtnSec.Text = "sec"
        Me.BtnSec.UseVisualStyleBackColor = False
        '
        'BtnPi
        '
        Me.BtnPi.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnPi.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.BtnPi.FlatAppearance.BorderSize = 5
        Me.BtnPi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.BtnPi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnPi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPi.Font = New System.Drawing.Font("Times New Roman", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPi.ForeColor = System.Drawing.Color.Blue
        Me.BtnPi.Location = New System.Drawing.Point(542, 246)
        Me.BtnPi.Name = "BtnPi"
        Me.BtnPi.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnPi.Size = New System.Drawing.Size(54, 46)
        Me.BtnPi.TabIndex = 32
        Me.BtnPi.Text = "pi"
        Me.BtnPi.UseVisualStyleBackColor = False
        '
        'BtnExp
        '
        Me.BtnExp.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnExp.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.BtnExp.FlatAppearance.BorderSize = 5
        Me.BtnExp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.BtnExp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnExp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExp.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExp.ForeColor = System.Drawing.Color.Blue
        Me.BtnExp.Location = New System.Drawing.Point(418, 198)
        Me.BtnExp.Name = "BtnExp"
        Me.BtnExp.Size = New System.Drawing.Size(60, 46)
        Me.BtnExp.TabIndex = 27
        Me.BtnExp.Text = "exp"
        Me.BtnExp.UseVisualStyleBackColor = False
        '
        'BtnTangent
        '
        Me.BtnTangent.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnTangent.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen
        Me.BtnTangent.FlatAppearance.BorderSize = 5
        Me.BtnTangent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen
        Me.BtnTangent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnTangent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTangent.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTangent.ForeColor = System.Drawing.Color.DarkGreen
        Me.BtnTangent.Location = New System.Drawing.Point(208, 102)
        Me.BtnTangent.Name = "BtnTangent"
        Me.BtnTangent.Size = New System.Drawing.Size(72, 46)
        Me.BtnTangent.TabIndex = 29
        Me.BtnTangent.Text = "tan"
        Me.BtnTangent.UseVisualStyleBackColor = False
        '
        'BtnCosine
        '
        Me.BtnCosine.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnCosine.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen
        Me.BtnCosine.FlatAppearance.BorderSize = 5
        Me.BtnCosine.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen
        Me.BtnCosine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnCosine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCosine.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCosine.ForeColor = System.Drawing.Color.DarkGreen
        Me.BtnCosine.Location = New System.Drawing.Point(208, 54)
        Me.BtnCosine.Name = "BtnCosine"
        Me.BtnCosine.Size = New System.Drawing.Size(72, 46)
        Me.BtnCosine.TabIndex = 30
        Me.BtnCosine.Text = "cos"
        Me.BtnCosine.UseVisualStyleBackColor = False
        '
        'BtnSine
        '
        Me.BtnSine.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnSine.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen
        Me.BtnSine.FlatAppearance.BorderSize = 5
        Me.BtnSine.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen
        Me.BtnSine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnSine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSine.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSine.ForeColor = System.Drawing.Color.DarkGreen
        Me.BtnSine.Location = New System.Drawing.Point(208, 6)
        Me.BtnSine.Name = "BtnSine"
        Me.BtnSine.Size = New System.Drawing.Size(72, 46)
        Me.BtnSine.TabIndex = 31
        Me.BtnSine.Text = "sin"
        Me.BtnSine.UseVisualStyleBackColor = False
        '
        'BtnPoint
        '
        Me.BtnPoint.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnPoint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.BtnPoint.FlatAppearance.BorderSize = 5
        Me.BtnPoint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.BtnPoint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPoint.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPoint.ForeColor = System.Drawing.Color.Blue
        Me.BtnPoint.Location = New System.Drawing.Point(151, 198)
        Me.BtnPoint.Name = "BtnPoint"
        Me.BtnPoint.Size = New System.Drawing.Size(55, 46)
        Me.BtnPoint.TabIndex = 22
        Me.BtnPoint.Text = "."
        Me.BtnPoint.UseVisualStyleBackColor = False
        '
        'BtnNegPos
        '
        Me.BtnNegPos.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnNegPos.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.BtnNegPos.FlatAppearance.BorderSize = 5
        Me.BtnNegPos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.BtnNegPos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnNegPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNegPos.Font = New System.Drawing.Font("Times New Roman", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNegPos.ForeColor = System.Drawing.Color.Blue
        Me.BtnNegPos.Location = New System.Drawing.Point(356, 198)
        Me.BtnNegPos.Name = "BtnNegPos"
        Me.BtnNegPos.Size = New System.Drawing.Size(60, 46)
        Me.BtnNegPos.TabIndex = 23
        Me.BtnNegPos.UseVisualStyleBackColor = False
        '
        'BtnLogx
        '
        Me.BtnLogx.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnLogx.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet
        Me.BtnLogx.FlatAppearance.BorderSize = 5
        Me.BtnLogx.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkViolet
        Me.BtnLogx.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnLogx.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLogx.Font = New System.Drawing.Font("Times New Roman", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLogx.ForeColor = System.Drawing.Color.DarkViolet
        Me.BtnLogx.Location = New System.Drawing.Point(151, 102)
        Me.BtnLogx.Name = "BtnLogx"
        Me.BtnLogx.Size = New System.Drawing.Size(55, 46)
        Me.BtnLogx.TabIndex = 24
        Me.BtnLogx.Text = "logx"
        Me.BtnLogx.UseVisualStyleBackColor = False
        '
        'BtnLoge
        '
        Me.BtnLoge.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnLoge.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet
        Me.BtnLoge.FlatAppearance.BorderSize = 5
        Me.BtnLoge.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkViolet
        Me.BtnLoge.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnLoge.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLoge.Font = New System.Drawing.Font("Times New Roman", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLoge.ForeColor = System.Drawing.Color.DarkViolet
        Me.BtnLoge.Location = New System.Drawing.Point(151, 54)
        Me.BtnLoge.Name = "BtnLoge"
        Me.BtnLoge.Size = New System.Drawing.Size(54, 46)
        Me.BtnLoge.TabIndex = 25
        Me.BtnLoge.Text = "loge"
        Me.BtnLoge.UseVisualStyleBackColor = False
        '
        'BtnLogc
        '
        Me.BtnLogc.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnLogc.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet
        Me.BtnLogc.FlatAppearance.BorderSize = 5
        Me.BtnLogc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkViolet
        Me.BtnLogc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnLogc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLogc.Font = New System.Drawing.Font("Times New Roman", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLogc.ForeColor = System.Drawing.Color.DarkViolet
        Me.BtnLogc.Location = New System.Drawing.Point(151, 6)
        Me.BtnLogc.Name = "BtnLogc"
        Me.BtnLogc.Size = New System.Drawing.Size(54, 46)
        Me.BtnLogc.TabIndex = 26
        Me.BtnLogc.Text = "logc"
        Me.BtnLogc.UseVisualStyleBackColor = False
        '
        'BtnEqual
        '
        Me.BtnEqual.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnEqual.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed
        Me.BtnEqual.FlatAppearance.BorderSize = 5
        Me.BtnEqual.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.BtnEqual.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnEqual.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEqual.Font = New System.Drawing.Font("Times New Roman", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEqual.ForeColor = System.Drawing.Color.DarkRed
        Me.BtnEqual.Location = New System.Drawing.Point(103, 198)
        Me.BtnEqual.Name = "BtnEqual"
        Me.BtnEqual.Size = New System.Drawing.Size(46, 46)
        Me.BtnEqual.TabIndex = 17
        Me.BtnEqual.Text = "="
        Me.BtnEqual.UseVisualStyleBackColor = False
        '
        'BtnAdd
        '
        Me.BtnAdd.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnAdd.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed
        Me.BtnAdd.FlatAppearance.BorderSize = 5
        Me.BtnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.BtnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdd.Font = New System.Drawing.Font("Times New Roman", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.ForeColor = System.Drawing.Color.DarkRed
        Me.BtnAdd.Location = New System.Drawing.Point(103, 150)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(46, 46)
        Me.BtnAdd.TabIndex = 18
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'BtnSubtract
        '
        Me.BtnSubtract.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnSubtract.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed
        Me.BtnSubtract.FlatAppearance.BorderSize = 5
        Me.BtnSubtract.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.BtnSubtract.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnSubtract.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSubtract.Font = New System.Drawing.Font("Times New Roman", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSubtract.ForeColor = System.Drawing.Color.DarkRed
        Me.BtnSubtract.Location = New System.Drawing.Point(103, 102)
        Me.BtnSubtract.Name = "BtnSubtract"
        Me.BtnSubtract.Size = New System.Drawing.Size(46, 46)
        Me.BtnSubtract.TabIndex = 19
        Me.BtnSubtract.Text = "-"
        Me.BtnSubtract.UseVisualStyleBackColor = False
        '
        'BtnMultiply
        '
        Me.BtnMultiply.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnMultiply.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed
        Me.BtnMultiply.FlatAppearance.BorderSize = 5
        Me.BtnMultiply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.BtnMultiply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnMultiply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMultiply.Font = New System.Drawing.Font("Times New Roman", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMultiply.ForeColor = System.Drawing.Color.DarkRed
        Me.BtnMultiply.Location = New System.Drawing.Point(103, 54)
        Me.BtnMultiply.Name = "BtnMultiply"
        Me.BtnMultiply.Size = New System.Drawing.Size(46, 46)
        Me.BtnMultiply.TabIndex = 20
        Me.BtnMultiply.Text = "x"
        Me.BtnMultiply.UseVisualStyleBackColor = False
        '
        'BtnDivide
        '
        Me.BtnDivide.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnDivide.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed
        Me.BtnDivide.FlatAppearance.BorderSize = 5
        Me.BtnDivide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.BtnDivide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnDivide.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDivide.Font = New System.Drawing.Font("Times New Roman", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDivide.ForeColor = System.Drawing.Color.DarkRed
        Me.BtnDivide.Location = New System.Drawing.Point(103, 6)
        Me.BtnDivide.Name = "BtnDivide"
        Me.BtnDivide.Size = New System.Drawing.Size(46, 46)
        Me.BtnDivide.TabIndex = 21
        Me.BtnDivide.Text = "/"
        Me.BtnDivide.UseVisualStyleBackColor = False
        '
        'Btn9
        '
        Me.Btn9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Btn9.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.Btn9.FlatAppearance.BorderSize = 5
        Me.Btn9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.Btn9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn9.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn9.ForeColor = System.Drawing.Color.Blue
        Me.Btn9.Location = New System.Drawing.Point(55, 6)
        Me.Btn9.Name = "Btn9"
        Me.Btn9.Size = New System.Drawing.Size(46, 46)
        Me.Btn9.TabIndex = 9
        Me.Btn9.Text = "9"
        Me.Btn9.UseVisualStyleBackColor = False
        '
        'Btn8
        '
        Me.Btn8.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Btn8.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.Btn8.FlatAppearance.BorderSize = 5
        Me.Btn8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.Btn8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn8.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn8.ForeColor = System.Drawing.Color.Blue
        Me.Btn8.Location = New System.Drawing.Point(7, 6)
        Me.Btn8.Name = "Btn8"
        Me.Btn8.Size = New System.Drawing.Size(46, 46)
        Me.Btn8.TabIndex = 8
        Me.Btn8.Text = "8"
        Me.Btn8.UseVisualStyleBackColor = False
        '
        'Btn7
        '
        Me.Btn7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Btn7.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.Btn7.FlatAppearance.BorderSize = 5
        Me.Btn7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue
        Me.Btn7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn7.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn7.ForeColor = System.Drawing.Color.Blue
        Me.Btn7.Location = New System.Drawing.Point(55, 54)
        Me.Btn7.Name = "Btn7"
        Me.Btn7.Size = New System.Drawing.Size(46, 46)
        Me.Btn7.TabIndex = 7
        Me.Btn7.Text = "7"
        Me.Btn7.UseVisualStyleBackColor = False
        '
        'Btn6
        '
        Me.Btn6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Btn6.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.Btn6.FlatAppearance.BorderSize = 5
        Me.Btn6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.Btn6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn6.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn6.ForeColor = System.Drawing.Color.Blue
        Me.Btn6.Location = New System.Drawing.Point(7, 54)
        Me.Btn6.Name = "Btn6"
        Me.Btn6.Size = New System.Drawing.Size(46, 46)
        Me.Btn6.TabIndex = 6
        Me.Btn6.Text = "6"
        Me.Btn6.UseVisualStyleBackColor = False
        '
        'Btn5
        '
        Me.Btn5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Btn5.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.Btn5.FlatAppearance.BorderSize = 5
        Me.Btn5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.Btn5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn5.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn5.ForeColor = System.Drawing.Color.Blue
        Me.Btn5.Location = New System.Drawing.Point(55, 102)
        Me.Btn5.Name = "Btn5"
        Me.Btn5.Size = New System.Drawing.Size(46, 46)
        Me.Btn5.TabIndex = 5
        Me.Btn5.Text = "5"
        Me.Btn5.UseVisualStyleBackColor = False
        '
        'Btn4
        '
        Me.Btn4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Btn4.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.Btn4.FlatAppearance.BorderSize = 5
        Me.Btn4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.Btn4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn4.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn4.ForeColor = System.Drawing.Color.Blue
        Me.Btn4.Location = New System.Drawing.Point(7, 102)
        Me.Btn4.Name = "Btn4"
        Me.Btn4.Size = New System.Drawing.Size(46, 46)
        Me.Btn4.TabIndex = 4
        Me.Btn4.Text = "4"
        Me.Btn4.UseVisualStyleBackColor = False
        '
        'Btn3
        '
        Me.Btn3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Btn3.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.Btn3.FlatAppearance.BorderSize = 5
        Me.Btn3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.Btn3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn3.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn3.ForeColor = System.Drawing.Color.Blue
        Me.Btn3.Location = New System.Drawing.Point(55, 150)
        Me.Btn3.Name = "Btn3"
        Me.Btn3.Size = New System.Drawing.Size(46, 46)
        Me.Btn3.TabIndex = 3
        Me.Btn3.Text = "3"
        Me.Btn3.UseVisualStyleBackColor = False
        '
        'Btn2
        '
        Me.Btn2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Btn2.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.Btn2.FlatAppearance.BorderSize = 5
        Me.Btn2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.Btn2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn2.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn2.ForeColor = System.Drawing.Color.Blue
        Me.Btn2.Location = New System.Drawing.Point(7, 150)
        Me.Btn2.Name = "Btn2"
        Me.Btn2.Size = New System.Drawing.Size(46, 46)
        Me.Btn2.TabIndex = 2
        Me.Btn2.Text = "2"
        Me.Btn2.UseVisualStyleBackColor = False
        '
        'Btn1
        '
        Me.Btn1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Btn1.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.Btn1.FlatAppearance.BorderSize = 5
        Me.Btn1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue
        Me.Btn1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn1.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn1.ForeColor = System.Drawing.Color.Blue
        Me.Btn1.Location = New System.Drawing.Point(55, 198)
        Me.Btn1.Name = "Btn1"
        Me.Btn1.Size = New System.Drawing.Size(46, 46)
        Me.Btn1.TabIndex = 1
        Me.Btn1.Text = "1"
        Me.Btn1.UseVisualStyleBackColor = False
        '
        'Btn0
        '
        Me.Btn0.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Btn0.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.Btn0.FlatAppearance.BorderSize = 5
        Me.Btn0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue
        Me.Btn0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn0.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn0.ForeColor = System.Drawing.Color.Blue
        Me.Btn0.Location = New System.Drawing.Point(7, 198)
        Me.Btn0.Name = "Btn0"
        Me.Btn0.Size = New System.Drawing.Size(46, 46)
        Me.Btn0.TabIndex = 0
        Me.Btn0.Text = "0"
        Me.Btn0.UseVisualStyleBackColor = False
        '
        'LblFormula
        '
        Me.LblFormula.BackColor = System.Drawing.Color.White
        Me.LblFormula.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFormula.Location = New System.Drawing.Point(11, 424)
        Me.LblFormula.Name = "LblFormula"
        Me.LblFormula.Size = New System.Drawing.Size(600, 34)
        Me.LblFormula.TabIndex = 5
        Me.LblFormula.Visible = False
        '
        'TbDisplay
        '
        Me.TbDisplay.BackColor = System.Drawing.Color.Black
        Me.TbDisplay.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TbDisplay.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbDisplay.ForeColor = System.Drawing.Color.Aqua
        Me.TbDisplay.Location = New System.Drawing.Point(10, 9)
        Me.TbDisplay.Name = "TbDisplay"
        Me.TbDisplay.ReadOnly = True
        Me.TbDisplay.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.TbDisplay.Size = New System.Drawing.Size(603, 46)
        Me.TbDisplay.TabIndex = 10
        Me.TbDisplay.Text = ""
        '
        'BtnCM
        '
        Me.BtnCM.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnCM.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown
        Me.BtnCM.FlatAppearance.BorderSize = 5
        Me.BtnCM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SaddleBrown
        Me.BtnCM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnCM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCM.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCM.ForeColor = System.Drawing.Color.SaddleBrown
        Me.BtnCM.Location = New System.Drawing.Point(552, 61)
        Me.BtnCM.Name = "BtnCM"
        Me.BtnCM.Size = New System.Drawing.Size(54, 41)
        Me.BtnCM.TabIndex = 11
        Me.BtnCM.Text = "CM"
        Me.BtnCM.UseVisualStyleBackColor = False
        '
        'FrmCalculator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Cyan
        Me.ClientSize = New System.Drawing.Size(622, 416)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.BtnCM)
        Me.Controls.Add(Me.TbDisplay)
        Me.Controls.Add(Me.LblFormula)
        Me.Controls.Add(Me.PnlCalculator)
        Me.Controls.Add(Me.PnlTrig)
        Me.Controls.Add(Me.PnlNumberSystems)
        Me.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmCalculator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calculator"
        Me.PnlNumberSystems.ResumeLayout(False)
        Me.PnlNumberSystems.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.PnlTrig.ResumeLayout(False)
        Me.PnlTrig.PerformLayout()
        Me.PnlCalculator.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlNumberSystems As Panel
    Friend WithEvents PnlTrig As Panel
    Friend WithEvents BtnOctal As RadioButton
    Friend WithEvents BtnHex As RadioButton
    Friend WithEvents BtnDecimal As RadioButton
    Friend WithEvents BtnBinary As RadioButton
    Friend WithEvents BtnGradian As RadioButton
    Friend WithEvents BtnRadian As RadioButton
    Friend WithEvents BtnDegree As RadioButton
    Friend WithEvents PnlCalculator As Panel
    Friend WithEvents Btn9 As Button
    Friend WithEvents Btn8 As Button
    Friend WithEvents Btn7 As Button
    Friend WithEvents Btn6 As Button
    Friend WithEvents Btn5 As Button
    Friend WithEvents Btn4 As Button
    Friend WithEvents Btn3 As Button
    Friend WithEvents Btn2 As Button
    Friend WithEvents Btn1 As Button
    Friend WithEvents Btn0 As Button
    Friend WithEvents BtnDivide As Button
    Friend WithEvents BtnAdd As Button
    Friend WithEvents BtnSubtract As Button
    Friend WithEvents BtnMultiply As Button
    Friend WithEvents BtnEqual As Button
    Friend WithEvents BtnPoint As Button
    Friend WithEvents BtnNegPos As Button
    Friend WithEvents BtnLogx As Button
    Friend WithEvents BtnLoge As Button
    Friend WithEvents BtnLogc As Button
    Friend WithEvents BtnPi As Button
    Friend WithEvents BtnExp As Button
    Friend WithEvents BtnTangent As Button
    Friend WithEvents BtnCosine As Button
    Friend WithEvents BtnSine As Button
    Friend WithEvents BtnCot As Button
    Friend WithEvents BtnCsc As Button
    Friend WithEvents BtnSec As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents BtnClearAll As Button
    Friend WithEvents BtnHexF As Button
    Friend WithEvents BtnHexE As Button
    Friend WithEvents BtnHexD As Button
    Friend WithEvents BtnHexC As Button
    Friend WithEvents BtnHexB As Button
    Friend WithEvents BtnHexA As Button
    Friend WithEvents BtnArcKey As Button
    Friend WithEvents BtnHypKey As Button
    Friend WithEvents BtnE As Button
    Friend WithEvents BtnSqrt As Button
    Friend WithEvents BtnXsquared As Button
    Friend WithEvents BtnXcubed As Button
    Friend WithEvents BtnXraised As Button
    Friend WithEvents BtnReciprocal As Button
    Friend WithEvents BtnCtoF As Button
    Friend WithEvents BtnMod As Button
    Friend WithEvents BtnPercent As Button
    Friend WithEvents BtnCE As Button
    Friend WithEvents BtnComma As Button
    Friend WithEvents BtnFtoC As Button
    Friend WithEvents Btnex As Button
    Friend WithEvents Btn10x As Button
    Friend WithEvents BtnM2 As Button
    Friend WithEvents BtnM1 As Button
    Friend WithEvents Btn2Raised As Button
    Friend WithEvents BtnCloseParentheses As Button
    Friend WithEvents BtnOpenParentheses As Button
    Friend WithEvents BtnM4 As Button
    Friend WithEvents BtnM3 As Button
    Friend WithEvents BtnCubeRt As Button
    Friend WithEvents BtnFourthRt As Button
    Friend WithEvents RatiosAndPorportionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CloseApplicationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DisplayFontSizeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LblFormula As Label
    Friend WithEvents TbDisplay As RichTextBox
    Friend WithEvents FontToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BackColorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ForeColorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BtnCM As Button
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
End Class
