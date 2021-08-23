Imports System.ComponentModel
Imports System.Math
Public Class FrmRatio
    Dim A_Answer As String
    Sub GetLinearRatio()
        '*******Find The Missing Number By Examining Existing Ratio (Values Entered) And Determine Missing Number*******
        Dim A1 As Single = CSng(Val(tbScaleA_Start.Text))
        Dim A2 As Single = CSng(Val(tbScaleA_End.Text))
        Dim B1 As Single = CSng(Val(tbScaleB_Start.Text))
        Dim B2 As Single = CSng(Val(tbScaleB_End.Text))
        Dim A_Value As String
        Dim B_Value As String
        Dim Count As Integer
        'Examine Text Boxes For Missing Entry
        'At Least 3 Entrys Must Be Present For Calculations
        If IsNumeric(tbScaleA_Start.Text) Then Count = 1
        If IsNumeric(tbScaleA_End.Text) Then Count += 1
        If IsNumeric(tbScaleB_Start.Text) Then Count += 1
        If IsNumeric(tbScaleB_End.Text) Then Count += 1
        If Count < 3 Then
            MessageBox.Show("A Minimum Of 3 Variables Are Required For Calculations." & vbCrLf &
                                "Please Enter The " & 3 - Count & " Missing Variable(s).",
                "Missing Entry Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
            Exit Sub
        End If
        If Count = 4 Then
            If tbScaleA_Value.Text <> vbNullString Then
                A_Value = tbScaleA_Value.Text
            Else
                A_Value = ""
            End If
            If tbScaleB_Value.Text <> vbNullString Then
                B_Value = tbScaleB_Value.Text
            Else
                B_Value = ""
            End If
            'No Missing Variables Everything Good To GO
            GetLinearProportion(A1, A2, B1, B2, B_Value, A_Value)
            Me.Refresh()
        Else
            'Something Is Missing
            'Determine What Variable Is Missing
            Dim Value_Missing As String
            Value_Missing = ""
            If Not IsNumeric(tbScaleA_Start.Text) Then Value_Missing = "A1"
            If Not IsNumeric(tbScaleA_End.Text) Then Value_Missing = "A2"
            If Not IsNumeric(tbScaleB_Start.Text) Then Value_Missing = "B1"
            If Not IsNumeric(tbScaleB_End.Text) Then Value_Missing = "B2"
            'Use Know Value To Determine Missing Value 
            'Prohibit Division By Zero
            'A1 = 1 / 0 = Infinity
            'A1 = 0 / 0 = NaN
            Select Case Value_Missing
                Case = "A1"
                    A1 = (B1 * A2) / B2
                    'Division By B2 = 0, Change Value To 1
                    If Single.IsInfinity((B1 * A2) / B2) Or CStr(A1) = "NaN" Then
                        MessageBox.Show("B2 Value Cannot = 0. Number / 0 = Infinity" & vbCrLf &
                                        "And/Or 0 / 0 = Nothing. Please Try Again!",
                        "Division By Zero Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
                        tbScaleB_End.Text = ""
                        tbScaleB_End.Refresh()
                        tbScaleB_End.Focus()
                        Exit Sub
                        tbScaleB_End.Text = CStr(B2)
                    End If
                    A_Answer = " A1 = (B1 * A2) / B2 = " & A1
                    tbScaleA_Start.Text = CStr(A1)
                Case = "A2"
                    A2 = (A1 / B1) * B2
                    'Division By B1 = 0, Change Value To 1
                    If Single.IsInfinity((A1 / B1) * B2) Or CStr(A2) = "NaN" Then
                        MessageBox.Show("B1 Value Cannot = 0. Number / 0 = Infinity" & vbCrLf &
                                        "And/Or 0 / 0 = Nothing. Please Try Again!",
                        "Division By Zero Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
                        tbScaleB_Start.Text = ""
                        tbScaleB_Start.Refresh()
                        tbScaleB_Start.Focus()
                        Exit Sub
                    End If
                    A_Answer = " A2 = (A1 / B1) * B2 = " & A2
                    tbScaleA_End.Text = CStr(A2)
                Case = "B1"
                    B1 = (A1 * B2) / A2
                    'Division By B1 = 0, Change Value To 1
                    If Single.IsInfinity((A1 * B2) / A2) Or CStr(B1) = "NaN" Then
                        MessageBox.Show("A2 Value Cannot = 0. Number / 0 = Infinity" & vbCrLf &
                                        "And/Or 0 / 0 = Nothing. Please Try Again!",
                        "Division By Zero Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
                        tbScaleA_End.Text = ""
                        tbScaleA_End.Refresh()
                        tbScaleA_End.Focus()
                        Exit Sub
                    End If
                    A_Answer = " B1 = (A1 * B2) / A2 = " & B1
                    tbScaleB_Start.Text = CStr(B1)
                Case = "B2"
                    B2 = (B1 * A2) / A1
                    'Division By B1 = 0, Change Value To 1
                    If Single.IsInfinity((B1 * A2) / A1) Or CStr(B2) = "NaN" Then
                        MessageBox.Show("A1 Value Cannot = 0. Number / 0 = Infinity" & vbCrLf &
                                        "And/Or 0 / 0 = Nothing. Please Try Again!",
                        "Division By Zero Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
                        tbScaleA_Start.Text = ""
                        tbScaleA_Start.Refresh()
                        tbScaleA_Start.Focus()
                        Exit Sub
                    End If
                    A_Answer = " B2 = (B1 * A2) / A1 = " & B2
                    tbScaleB_End.Text = CStr(B2)
            End Select
            Me.Refresh()
            A_Value = tbScaleA_Value.Text
            B_Value = tbScaleB_Value.Text
            GetLinearProportion(A1, A2, B1, B2, B_Value, A_Value)
        End If
    End Sub
    Function GetLinearProportion(ByVal ClientAStartPt As Single, ByVal ClientAEndPt As Single, ByVal ClientBStartPt As Single,
                                  ByVal ClientBEndPt As Single, FindA_UsingB As String, FindB_UsingA As String) As String
        'This Functions Return The Posiition Of The Client Object To Any Given Scaled Position On The Object
        Dim A_Inverse As Boolean
        Dim B_Inverse As Boolean
        Dim Inverse As Boolean
        Dim ClientBSize As Single
        Dim ClientASize As Single
        Dim KDisplayA As String
        Dim KDisplayB As String
        If ClientAStartPt > ClientAEndPt Then A_Inverse = True
        If ClientBStartPt > ClientBEndPt Then B_Inverse = True
        If A_Inverse And Not B_Inverse Then Inverse = True
        If Not A_Inverse And B_Inverse Then Inverse = True
        If Not A_Inverse And Not B_Inverse Then Inverse = False
        If A_Inverse And B_Inverse Then Inverse = False
        If ClientAStartPt >= 0 And ClientAEndPt > 0 Then
            ClientASize = Abs(ClientAEndPt - ClientAStartPt) '0,100 or 10,100
            ClientBSize = Abs(ClientBStartPt - ClientBEndPt)
        ElseIf ClientBStartPt > 0 And ClientBEndPt >= 0 Then
            ClientASize = Abs(ClientAStartPt - ClientAEndPt)
            ClientBSize = Abs(ClientBEndPt - ClientBStartPt) '0,100 or 10,100
        Else
            ClientASize = Abs(ClientAStartPt - ClientAEndPt) '0,-100 or -10,-100 Examples
            ClientBSize = Abs(ClientBStartPt - ClientBEndPt) '0,-100 or 10,-100
        End If
        Dim ScaleRatio_BA As Single = Abs(ClientBSize / ClientASize) 'X Amount Of B's Per X Amount Of A's
        KDisplayB = "Abs(B Size / A Size)"
        Dim ScaleRatio_AB As Single = Abs(ClientASize / ClientBSize) 'X Amount Of A's Per X Amount Of B's
        KDisplayA = "Abs(A Size / B Size)"
        Dim C_Answer As String = Nothing
        Dim B_Answer As String = Nothing
        TxtFormula.Text = Nothing
        'Calculate The Proportions
        Select Case Inverse
            Case False
                'Case Not A_Inverse And Not B_Inverse, A_Inverse And B_Inverse
                If tbScaleA_Value.Text <> vbNullString Then
                    lblScaleB_Answer.Text = CStr(Val(Round(ClientBStartPt - (ScaleRatio_BA * (ClientAStartPt - FindB_UsingA)), 5, MidpointRounding.AwayFromZero))) 'A Finding B Non-Inverse
                    B_Answer = " K = |B/A| = " & KDisplayB & " = " & CStr(ScaleRatio_BA) & vbCrLf & " B = B1 - (K * (A1 - A)) = " & lblScaleB_Answer.Text
                End If
                If tbScaleB_Value.Text <> vbNullString Then
                    lblScaleA_Answer.Text = CStr(Val(Round(ClientAStartPt - (ScaleRatio_AB * (ClientBStartPt - FindA_UsingB)), 5, MidpointRounding.AwayFromZero))) 'B Finding A Non-Inverse
                    C_Answer = " K = |A/B| = " & KDisplayA & " = " & CStr(ScaleRatio_AB) & vbCrLf & " A = A1 - (K * (B1 - B)) = " & lblScaleA_Answer.Text
                End If
            Case True
                'A_Inverse And Not B_Inverse Or Not A_Inverse And B_Inverse
                If tbScaleA_Value.Text <> vbNullString Then
                    lblScaleB_Answer.Text = CStr(Val(Round(ClientBStartPt - ((FindB_UsingA - ClientAStartPt) * ScaleRatio_BA), 5, MidpointRounding.AwayFromZero))) 'A Finding B Inverse
                    B_Answer = " K = |B/A| = " & KDisplayB & " = " & CStr(ScaleRatio_BA) & vbCrLf & " B = B1 - ((A - A1) * K) = " & lblScaleB_Answer.Text
                End If
                If tbScaleB_Value.Text <> vbNullString Then
                    lblScaleA_Answer.Text = CStr(Val(Round(ClientAStartPt - ((FindA_UsingB - ClientBStartPt) * ScaleRatio_AB), 5, MidpointRounding.AwayFromZero))) 'B Finding A Inverse
                    C_Answer = " K = |A/B| = " & KDisplayA & " = " & CStr(ScaleRatio_AB) & vbCrLf & " A = A1 - ((B - B1) * K) = " & lblScaleA_Answer.Text
                End If
        End Select
        GetLinearProportion = lblScaleA_Answer.Text & ", " & lblScaleB_Answer.Text
        lblScaleA_Answer.Refresh()
        lblScaleB_Answer.Refresh()
        TxtFormula.Text = Nothing
        TxtFormula.Refresh()
        'Add New Lines To TextBox
        TxtFormula.Text = A_Answer
        If B_Answer <> vbNullString Then TxtFormula.Text &= Environment.NewLine & B_Answer
        If C_Answer <> vbNullString Then TxtFormula.Text &= Environment.NewLine & C_Answer
        TxtFormula.Refresh()
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TxtFormula.Text = ""
        TxtFormula.Refresh()
        GetLinearRatio()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tbScaleA_Start.Text = ""
        tbScaleA_End.Text = ""
        tbScaleB_Start.Text = ""
        tbScaleB_End.Text = ""
        tbScaleA_Value.Text = ""
        tbScaleB_Value.Text = ""
        lblScaleA_Answer.Text = ""
        lblScaleB_Answer.Text = ""
        TxtFormula.Text = ""
        Me.Refresh()
    End Sub
    Private Sub FrmRatio_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FrmCalculator.Show()
        Me.Dispose()
    End Sub

    Private Sub FrmRatio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
End Class
