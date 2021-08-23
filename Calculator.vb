Option Explicit On
Option Infer Off
Imports System.ComponentModel
Imports Bestcode.MathParser
Imports System.Math
Imports System.Text
Imports System.Globalization

Public Class FrmCalculator
    Private Declare Function GetTickCount Lib "kernel32" () As Integer
    Private Base As String 'Numerical System Base, Decimal, Binary, Octal, Hex
    Private TrigFunction As String 'Which Trig Function Selected
    Private ParseBuild As String 'Actual Formula Sent To Parser
    Private SegmentValue(0) As String 'Array Of Variable Values Sent To Parser
    Private BinarySegmentValue(0) As String 'Binary Value Changes During Conversions, Store Original Values For Deletion
    Private SegmentValueTemp As String 'Temporary values for Constants PI,e, etc...
    Private SegmentName(0) As String ' Alphabetical Names Of Variables, A-W
    Private SegmentIndex As Int16 'Number Of Variables Set To Parser
    Private TwoParameters(0) As Boolean
    Private Memory(3) As String
    Private ReadyForValue As Boolean 'Math Function Was Clicked, +-/* etc...
    Private ParseValueX As String 'Parser Defined "X" Variable
    Private ParseValueY As String 'Parser Defined "Y" Variable
    Private DisplayBuild As String 'Text Displayed On TextBox Display
    Private BracketsOpen(0) As Boolean 'Determines Beginning And End Of Parentheses Brackets
    Private BracketsIndex As Integer = 0 'Running Count Of Open Parentheses Brackets
    Private DoubleBracket As Boolean = False '((
    Private Answer As String
    Private DecimalAnswer As String 'Returned Answer From Parser
    Private BinaryAnswer As String 'Returned Answer From Parser Converted
    Private HexAnswer As String 'Returned Answer From Parser Converted
    Private OctalAnswer As String 'Returned Answer From Parser Converted
    Private AnswerReceived As Boolean ' = Key Was Pressed And Parsing Acured
    Private FunctionAnswer As Boolean 'Value Squared, Cubed, Recriprocal ..etc... Exist
    Private AnswerExisted As Boolean 'Values Were Converted To Decimal Value For Parsing
    Private hypKey As Boolean ' hypKey Trig Key
    Private ArcKey As Boolean '2nd Trig Key
    Private NegPos As String
    Private ToolTip1 As New ToolTip
    Private Function ReplaceEndSubstring(StrToModify As String, SubStrToReplace As String, NewSubString As String) As String
        Dim NewString As New StringBuilder(StrToModify)
        NewString.Length -= SubStrToReplace.Length
        Dim ReturnStr As String = NewString.ToString() & NewSubString
        Return ReturnStr
    End Function
    Private Function ConvertFromBaseToBase(ValueToConvert As String, FromBaseValue As Int16, ToBaseValue As Int16, Formatted As Boolean, Padded As Boolean) As String
        'BaseValues = ' 2, 8, 10, 16
        'Function Converts Any Of These Numerical Bases.
        'Formatting Add Spaces Or Commas Depending On The ToBaseValue. Commas If Decimal, Spaces If Binary, Hexadecimal Or Octal.
        'Padding Adds Extra Zeros To Complete The Byte If ToBaseValue Is Binary, Hexadecimal Or Octal.
        'Padded Values = 7 777 777 = 007 777 777,  FFF FFFF = 0FFF FFFF
        'Formatted Values = 'Decimal: 1,234,567,890,  Binary: 1101 1111 0011 1101,  Hex: FFC0 AB20 FFFC EFCD,  Oct: 771 772 654
        'If FromBaseValue = ToBaseValue Then Format And/Or Pad Only
        Dim RtnStr As String = Nothing
        If FromBaseValue = ToBaseValue Then 'Just Use For Formatting Or Padding
            RtnStr = ValueToConvert
        Else
            RtnStr = Nothing
        End If
        Try
            'Remove All Spaces And Commas Within The String Because Generates Parser Error
            Dim NewString As String = ValueToConvert.Replace(" ", "") 'Remove All Spaces
            If FromBaseValue = 10 Then NewString = NewString.Replace(",", "") 'Remove All commas
            ValueToConvert = NewString
            Select Case FromBaseValue
                Case = 2 'From Binary
                    Dim c As Int16 = ValueToConvert.Length - 48
                    If ValueToConvert.Length > 48 Then ValueToConvert = ValueToConvert.Remove(0, c)
                    Select Case ToBaseValue 'OK
                        Case = 8 'To Octal OK
                            Dim I As Int64 = Convert.ToInt64(ValueToConvert, 2) 'Binary To Decimal
                            RtnStr = Oct(I) 'Decimal To Octal
                        Case = 10 'To Decimal OK
                            Dim I As Int64 = Convert.ToInt64(ValueToConvert, 2)
                            RtnStr = CStr(I)
                        Case = 16 'To Hexadecimal OK
                            Dim I As Int64 = Convert.ToInt64(ValueToConvert, 2)
                            RtnStr = Hex(CStr(I))
                        Case Else
                    End Select
                Case = 8 'From Octal
                    Dim L As Int16 = ValueToConvert.Length - 16
                    If ValueToConvert.Length > 16 Then ValueToConvert = ValueToConvert.Remove(0, L)
                    Select Case ToBaseValue
                        Case = 2 'Octal To Binary OK
                            Dim o As Int64 = Convert.ToInt64(ValueToConvert, 8) 'Binary To Decimal
                            Dim DecimalNumber As String = CStr(o) 'Octal To Decimal
                            Dim result As String = ""
                            'Decimal ToBinary
                            If DecimalNumber.Contains(".") = False Then
                                Dim n As Double = CDbl(DecimalNumber)
                                If n = 0 Then
                                    result = 0
                                ElseIf n > 0 Then
                                    Dim i As Double
                                    Dim c As Long
                                    i = 2 ^ CLng(Math.Log(n) / Math.Log(2) + 0.1)
                                    Do While i >= 1
                                        c = Fix(n / i)
                                        result &= c
                                        n -= i * c
                                        i /= 2
                                    Loop
                                    Dim SB As New StringBuilder(result)
                                    If String.IsNullOrEmpty(result) Then Return result
                                    Dim startIndex = SB.Length - 4 '(SB.Length Mod CharSpacing)
                                    For s As Int32 = startIndex To 1 Step -4
                                        SB.Insert(s, 4)
                                    Next s
                                End If
                            End If
                            'Remove Leading Zero From String
                            RtnStr = result.TrimStart("0"c)
                        Case = 10 'Octal To Decimal OK
                            Dim I As Int64 = Convert.ToInt64(ValueToConvert, 8) 'Octal To Decimal
                            RtnStr = CStr(I) 'Octal To Decimal
                        Case = 16 'Octal To Hexadecimal OK
                            Dim I As Int64 = Convert.ToInt64(ValueToConvert, 8) 'Octal To Decimal
                            Dim d As String = CStr(I) 'Octal To Decimal
                            'Decimal To Hexadecimal
                            RtnStr = Hex(d)
                        Case Else
                    End Select
                Case = 10 'From Decimal
                    If Val(ValueToConvert) > 281474976710655 Then ValueToConvert = CStr(281474976710655) 'Max Value
                    Select Case ToBaseValue
                        Case = 2 'Decimal To Binary OK
                            Dim result As String = ""
                            'Decimal ToBinary
                            If ValueToConvert.Contains(".") = False Then
                                Dim n As Double = CDbl(ValueToConvert)
                                If n = 0 Then
                                    result = 0
                                ElseIf n > 0 Then
                                    Dim i As Double
                                    Dim c As Long
                                    i = 2 ^ CLng(Math.Log(n) / Math.Log(2) + 0.1)
                                    Do While i >= 1
                                        c = Fix(n / i)
                                        result &= c
                                        n -= i * c
                                        i /= 2
                                    Loop
                                    Dim SB As New StringBuilder(result)
                                    If String.IsNullOrEmpty(result) Then Return result
                                    Dim startIndex = SB.Length - 4 '(SB.Length Mod CharSpacing)
                                    For s As Int32 = startIndex To 1 Step -4
                                        SB.Insert(s, 4)
                                    Next s
                                End If
                            End If
                            'Remove Leading Zero From String
                            RtnStr = result.TrimStart("0"c)
                        Case = 8 'Decimal To Octal OK
                            Dim I As Int64 = Convert.ToInt64(ValueToConvert) 'Decimal
                            RtnStr = Oct(I) 'Decimal To Octal
                        Case = 16 'Decimal To Hexadecimal OK
                            Dim I As Int64 = Convert.ToInt64(ValueToConvert)
                            RtnStr = Hex(I)
                        Case Else
                    End Select
                Case = 16 'From Hexadecimal
                    Dim L As Int16 = ValueToConvert.Length - 12
                    If ValueToConvert.Length > 12 Then ValueToConvert = ValueToConvert.Remove(0, L)
                    Select Case ToBaseValue
                        Case = 2 'Hex To Binary OK
                            Dim DecNum As String = Nothing
                            Dim HexLength As Long
                            Dim HexPower As Integer
                            Dim HexString As String
                            Dim ForwardCount As Integer
                            Dim DecimalPosition As Double
                            Dim DecimalNumber As Double
                            DecimalNumber = 0
                            ForwardCount = 0
                            HexLength = Len(ValueToConvert)
                            For HexPower = HexLength - 1 To 0 Step -1
                                ForwardCount += 1
                                HexString = Mid(ValueToConvert, ForwardCount, 1)
                                Select Case HexString
                                    Case "A"
                                        DecimalPosition = 10 * 16 ^ HexPower
                                    Case "B"
                                        DecimalPosition = 11 * 16 ^ HexPower
                                    Case "C"
                                        DecimalPosition = 12 * 16 ^ HexPower
                                    Case "D"
                                        DecimalPosition = 13 * 16 ^ HexPower
                                    Case "E"
                                        DecimalPosition = 14 * 16 ^ HexPower
                                    Case "F"
                                        DecimalPosition = 15 * 16 ^ HexPower
                                    Case Else
                                        DecimalPosition = Val(HexString) * 16 ^ HexPower
                                End Select
                                DecimalNumber += DecimalPosition
                            Next
                            DecNum = CStr(DecimalNumber)
                            'Decimal ToBinary
                            Dim result As String = ""
                            If DecNum.Contains(".") = False Then
                                Dim n As Double = CDbl(DecNum)
                                If n = 0 Then
                                    result = 0
                                ElseIf n > 0 Then
                                    Dim i As Double
                                    Dim c As Long
                                    i = 2 ^ CLng(Math.Log(n) / Math.Log(2) + 0.1)
                                    Do While i >= 1
                                        c = Fix(n / i)
                                        result &= c
                                        n -= i * c
                                        i /= 2
                                    Loop
                                    Dim SB As New StringBuilder(result)
                                    If String.IsNullOrEmpty(result) Then Exit Function
                                    Dim startIndex = SB.Length - 4 '(SB.Length Mod CharSpacing)
                                    For s As Int32 = startIndex To 1 Step -4
                                        SB.Insert(s, 4)
                                    Next s
                                End If
                            End If
                            'Remove Leading Zero From String
                            RtnStr = result.TrimStart("0"c)
                        Case = 8 'Hex To Octal
                            'Hex To Decimal
                            Dim HexLength As Long
                            Dim HexPower As Integer
                            Dim HexString As String
                            Dim ForwardCount As Integer
                            Dim DecimalPosition As Double
                            Dim DecimalNumber As Double
                            DecimalNumber = 0
                            ForwardCount = 0
                            HexLength = Len(ValueToConvert)
                            For HexPower = HexLength - 1 To 0 Step -1
                                ForwardCount += 1
                                HexString = Mid(ValueToConvert, ForwardCount, 1)
                                Select Case HexString
                                    Case "A"
                                        DecimalPosition = 10 * 16 ^ HexPower
                                    Case "B"
                                        DecimalPosition = 11 * 16 ^ HexPower
                                    Case "C"
                                        DecimalPosition = 12 * 16 ^ HexPower
                                    Case "D"
                                        DecimalPosition = 13 * 16 ^ HexPower
                                    Case "E"
                                        DecimalPosition = 14 * 16 ^ HexPower
                                    Case "F"
                                        DecimalPosition = 15 * 16 ^ HexPower
                                    Case Else
                                        DecimalPosition = Val(HexString) * 16 ^ HexPower
                                End Select
                                DecimalNumber += DecimalPosition
                            Next
                            Dim DecStr As String = CStr(DecimalNumber)
                            'Decimal To Octal
                            Dim I As Int64 = Convert.ToInt64(DecStr) 'Decimal
                            RtnStr = Oct(I) 'Decimal To Octal
                        Case = 10 'Hex To Decimal OK
                            Dim HexLength As Long
                            Dim HexPower As Integer
                            Dim HexString As String
                            Dim ForwardCount As Integer
                            Dim DecimalPosition As Double
                            Dim DecimalNumber As Double
                            DecimalNumber = 0
                            ForwardCount = 0
                            HexLength = Len(ValueToConvert)
                            For HexPower = HexLength - 1 To 0 Step -1
                                ForwardCount += 1
                                HexString = Mid(ValueToConvert, ForwardCount, 1)
                                Select Case HexString
                                    Case "A"
                                        DecimalPosition = 10 * 16 ^ HexPower
                                    Case "B"
                                        DecimalPosition = 11 * 16 ^ HexPower
                                    Case "C"
                                        DecimalPosition = 12 * 16 ^ HexPower
                                    Case "D"
                                        DecimalPosition = 13 * 16 ^ HexPower
                                    Case "E"
                                        DecimalPosition = 14 * 16 ^ HexPower
                                    Case "F"
                                        DecimalPosition = 15 * 16 ^ HexPower
                                    Case Else
                                        DecimalPosition = Val(HexString) * 16 ^ HexPower
                                End Select
                                DecimalNumber += DecimalPosition
                            Next
                            RtnStr = CStr(DecimalNumber)
                        Case Else
                    End Select
                Case Else
            End Select
            Select Case ToBaseValue'Pad And Format
                Case = 2, 16
                    If Padded Then
                        Dim TotalWidth As Int16
                        Dim PadNum As Int16
                        Select Case RtnStr.Length
                            Case 1, 5, 9, 13, 17, 21, 25, 29, 33, 37, 41
                                PadNum = 3
                            Case 2, 6, 10, 14, 18, 22, 26, 30, 34, 38, 42
                                PadNum = 2
                            Case 3, 7, 11, 15, 19, 23, 27, 31, 35, 39, 43
                                PadNum = 1
                            Case Else
                                PadNum = 0
                        End Select
                        TotalWidth = RtnStr.Length + PadNum
                        Dim PadString As String = RtnStr.PadLeft(TotalWidth, "0")
                        RtnStr = PadString
                    End If
                    If Formatted Then 'Add Spaces
                        Dim SB As New StringBuilder(RtnStr)
                        If String.IsNullOrEmpty(RtnStr) Then Exit Function
                        Dim startIndex = SB.Length - 4 '(SB.Length Mod CharSpacing)
                        For i As Int32 = startIndex To 1 Step -4
                            SB.Insert(i, " ")
                        Next i
                        RtnStr = SB.ToString()
                    End If
                Case = 8
                    If Padded Then
                        Dim TotalWidth As Int16
                        Dim PadNum As Int16
                        Select Case RtnStr.Length
                            Case 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34, 37, 40, 43
                                PadNum = 2
                            Case 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35, 38, 41, 44
                                PadNum = 1
                            Case Else
                                PadNum = 0
                        End Select
                        TotalWidth = RtnStr.Length + PadNum
                        Dim PadString As String = RtnStr.PadLeft(TotalWidth, "0")
                        RtnStr = PadString
                    End If
                    If Formatted Then 'Add Spaces
                        Dim SB As New StringBuilder(RtnStr)
                        If String.IsNullOrEmpty(RtnStr) Then Exit Function
                        Dim startIndex = SB.Length - 3 '(SB.Length Mod CharSpacing)
                        For i As Int32 = startIndex To 1 Step -3
                            SB.Insert(i, " ")
                        Next i
                        RtnStr = SB.ToString()
                    End If
                Case = 10
                    If IsNumeric(Val(RtnStr)) Then
                        If Formatted Then 'Add Comma To Integers Or Doubles
                            Dim Number As Int64
                            Dim Sucess As Boolean = Int64.TryParse(RtnStr, Number)
                            If Sucess Then 'Value Is Integer
                                RtnStr = Number.ToString("N0", CultureInfo.InvariantCulture)
                            Else 'Value Is Double
                                'IF Double Get Decimal Places And Return Decimal Unchanged
                                'Examine String For Length To Decimal Point
                                For i As Integer = 1 To RtnStr.Length
                                    Dim SearchChar As Char = Mid(RtnStr, i)
                                    If SearchChar = ("."c) Then
                                        Dim DecimalPlaces As Integer = RtnStr.Length - i
                                        Dim formatString As String = "N" & CStr(DecimalPlaces)
                                        Dim DecValue As Decimal = CDec(RtnStr)
                                        RtnStr = DecValue.ToString(formatString, CultureInfo.InvariantCulture)
                                    End If
                                Next i
                            End If
                        End If
                    End If
            End Select
        Catch exception As Exception
            MsgBox(exception.Message)
        End Try
        Return RtnStr
#Disable Warning BC42105 ' Function doesn't return a value on all code paths
    End Function
#Enable Warning BC42105 ' Function doesn't return a value on all code paths
    Private Function ExamineLastEntry(StrToExam As String) As String
        If StrToExam = Nothing Then Exit Function
        'Check For Function At End Of DisplayBuild
        Dim DisplayFunctionIndex As Integer = 36
        Dim DisplayFunction(DisplayFunctionIndex) As String
        DisplayFunction(0) = "Sin"
        DisplayFunction(1) = "Cos"
        DisplayFunction(2) = "Tan"
        DisplayFunction(3) = "Sec"
        DisplayFunction(4) = "Csc"
        DisplayFunction(5) = "Cot"
        DisplayFunction(6) = "Sinh"
        DisplayFunction(7) = "Cosh"
        DisplayFunction(8) = "Tanh"
        DisplayFunction(9) = "Sech"
        DisplayFunction(10) = "Csch"
        DisplayFunction(11) = "Coth"
        DisplayFunction(12) = "Sin" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
        DisplayFunction(13) = "Cos" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
        DisplayFunction(14) = "Tan" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
        DisplayFunction(15) = "Sec" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
        DisplayFunction(16) = "Csc" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
        DisplayFunction(17) = "Cot" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
        DisplayFunction(18) = "Sinh" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
        DisplayFunction(19) = "Cosh" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
        DisplayFunction(20) = "Tanh" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
        DisplayFunction(21) = "Sech" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
        DisplayFunction(22) = "Csch" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
        DisplayFunction(23) = "Coth" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
        DisplayFunction(24) = "^" & Strings.ChrW(&H2E3)
        DisplayFunction(25) = "e^"
        DisplayFunction(26) = "2^"
        DisplayFunction(27) = "10^"
        DisplayFunction(28) = "Pwr"
        DisplayFunction(29) = "Logc"
        DisplayFunction(30) = "Loge"
        DisplayFunction(31) = "Logx"
        DisplayFunction(32) = Strings.Chr(178) & ChrW(&H221A)
        DisplayFunction(33) = Strings.Chr(179) & ChrW(&H221A)
        DisplayFunction(34) = Strings.ChrW(&H2E3) & ChrW(&H221A)
        DisplayFunction(35) = "Mod"
        Dim StrToExamine As String = ""
        Dim StrToExamineLength As Integer
        Dim pf As Integer
        'Find Position Of SubString To Remove
        'Cycle Throu Functions List
        For pf = 0 To DisplayFunctionIndex - 1
            Dim StartLength As Integer = 1
            Dim StartIndex As Integer = StrToExam.Length - 1
            'Check For Function At End Of ParseBuild
            'If Exist Then Remove
            For nt As Integer = StrToExam.Length To 1 Step -1
                If StartIndex = -1 Then Exit For
                'Build SubString
                StrToExamine = StrToExam.Substring(StartIndex, StartLength)
                If StrToExamine = DisplayFunction(pf) Then
                    StrToExamineLength = StrToExamine.Length
                    Exit For
                End If
                StartIndex -= 1
                StartLength += 1
            Next
            If StrToExamine = DisplayFunction(pf) Then
                Return "Function"
                Exit Function
            End If
        Next
        'Check For Operators AtEnd Of DisplayBuild
        Dim DisplayOperatorIndex As Integer = 5
        Dim DisplayOperator(DisplayOperatorIndex) As String
        DisplayOperator(0) = "+"
        DisplayOperator(1) = "-"
        DisplayOperator(2) = "*"
        DisplayOperator(3) = "/"
        DisplayOperator(4) = ","
        'Find Position Of SubString To Remove
        'Cycle Throu Operators List
        For pf = 0 To DisplayOperatorIndex - 1
            Dim StartLength As Integer = 1
            Dim StartIndex As Integer = StrToExam.Length - 1
            'Check For Function At End Of ParseBuild
            'If Exist Then Remove
            For nt As Integer = StrToExam.Length To 1 Step -1
                If StartIndex = -1 Then Exit For
                'Build SubString
                StrToExamine = StrToExam.Substring(StartIndex, StartLength)
                If StrToExamine = DisplayOperator(pf) Then
                    StrToExamineLength = StrToExamine.Length
                    Exit For
                End If
                StartIndex -= 1
                StartLength += 1
            Next
            If StrToExamine = DisplayOperator(pf) Then
                Return "Operator"
                Exit Function
            End If
        Next
        'Check For Values At End Of Display Build
        'Convert Values To Display Values For Comparison
        Dim TempValue As String = ""
        If AnswerExisted Then
            Select Case Base
                Case "Decimal"
                    TempValue = SegmentValue(SegmentIndex)
                Case "Binary"
                    TempValue = BinarySegmentValue(SegmentIndex)
                Case "Hex"
                    TempValue = Hex(SegmentValue(SegmentIndex))
                Case "Octal"
                    Dim I As Int64 = Convert.ToInt64(SegmentValue(SegmentIndex))
                    TempValue = Oct(I)
            End Select
            AnswerReceived = False
        Else
            TempValue = SegmentValue(SegmentIndex)
        End If
        For i As Integer = StrToExam.Length To 1 Step -1
            Dim DisplayLen As Integer = StrToExam.Length
            Dim RemoveStr As String = Mid(StrToExam, i)
            If InStr(1, RemoveStr, TempValue, CompareMethod.Text) Then
                Return "Value"
                Exit For
            End If
        Next i
#Disable Warning BC42105 ' Function doesn't return a value on all code paths
    End Function
#Enable Warning BC42105 ' Function doesn't return a value on all code paths
    Private Sub DeleteOperators()
        If ParseBuild = Nothing Then Exit Sub
        Dim OperatorsIndex As Integer = 5
        Dim Operators(OperatorsIndex) As String
        Try
            Operators(0) = "+"
            Operators(1) = "-"
            Operators(2) = "*"
            Operators(3) = "/"
            Operators(4) = ","
            Dim StrToRemove As String = ""
            Dim StrToRemoveLength As Integer
            Dim pf As Integer
            'Find Position Of SubString To Remove
            'Cycle Throu Functions List
            For pf = 0 To OperatorsIndex - 1
                Dim StartLength As Integer = 1
                Dim StartIndex As Integer = ParseBuild.Length - 1
                'Check For Function At End Of ParseBuild
                'If Exist Then Remove
                For nt As Integer = ParseBuild.Length To 1 Step -1
                    If StartIndex = -1 Then Exit For
                    'Build SubString
                    StrToRemove = ParseBuild.Substring(StartIndex, StartLength)
                    If StrToRemove = Operators(pf) Then
                        StrToRemoveLength = StrToRemove.Length
                        Exit For
                    End If
                    StartIndex -= 1
                    StartLength += 1
                Next
                If StrToRemove = Operators(pf) Then
                    Exit For
                End If
            Next
            'Remove Math Function From ParseBuild
            If StrToRemove = Operators(pf) Then
                Dim NewString As New StringBuilder(ParseBuild)
                NewString.Length -= StrToRemoveLength
                ParseBuild = NewString.ToString()
                LblFormula.Text = "Formula = " & ParseBuild
            End If
            LblFormula.Text = "Formula = " & ParseBuild
            '****************************************************DISPLAY OPERATORS**************************************************
            If DisplayBuild = Nothing Then Exit Sub
            'Find Position Of SubString To Remove
            'Cycle Throu Functions List
            For pf = 0 To OperatorsIndex - 1
                Dim StartLength As Integer = 1
                Dim StartIndex As Integer = DisplayBuild.Length - 1
                'Check For Function At End Of ParseBuild
                'If Exist Then Remove
                For nt As Integer = DisplayBuild.Length To 1 Step -1
                    If StartIndex = -1 Then Exit For
                    'Build SubString
                    StrToRemove = DisplayBuild.Substring(StartIndex, StartLength)
                    If StrToRemove = Operators(pf) Then
                        StrToRemoveLength = StrToRemove.Length
                        Exit For
                    End If
                    StartIndex -= 1
                    StartLength += 1
                Next
                If StrToRemove = Operators(pf) Then
                    Exit For
                End If
            Next
            'Remove Math Function From DisplayBuild
            If StrToRemove = Operators(pf) Then
                Dim NewString As New StringBuilder(DisplayBuild)
                NewString.Length -= StrToRemoveLength
                DisplayBuild = NewString.ToString()
                TbDisplay.Text = DisplayBuild
                SegmentIndex -= 1
                ReDim Preserve SegmentValue(SegmentIndex)
                ReDim Preserve SegmentName(SegmentIndex)
                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve TwoParameters(SegmentIndex)
                If StrToRemove = "," Then
                    ReadyForValue = False
                End If
            End If
        Catch exception As Exception
            MsgBox("DeleteParseOperators" & exception.Message)
        End Try
    End Sub
    Private Sub DeleteFunctions()
        If ParseBuild = Nothing Then
            ClearAll()
            Exit Sub
        End If
        Dim ParseFunctionIndex As Integer = 36
        Dim ParseFunction(ParseFunctionIndex) As String
        Try
            ParseFunction(0) = "SINE"
            ParseFunction(1) = "COSN"
            ParseFunction(2) = "TANG"
            ParseFunction(3) = "SEC"
            ParseFunction(4) = "CSC"
            ParseFunction(5) = "COT"
            ParseFunction(6) = "SINEH"
            ParseFunction(7) = "COSNH"
            ParseFunction(8) = "TANH"
            ParseFunction(9) = "SECH"
            ParseFunction(10) = "CSCH"
            ParseFunction(11) = "COTH"
            ParseFunction(12) = "SINA"
            ParseFunction(13) = "COSA"
            ParseFunction(14) = "TANA"
            ParseFunction(15) = "SECA"
            ParseFunction(16) = "CSCA"
            ParseFunction(17) = "COTA"
            ParseFunction(18) = "SINHA"
            ParseFunction(19) = "COSHA"
            ParseFunction(20) = "TANHA"
            ParseFunction(21) = "SECHA"
            ParseFunction(22) = "CSCHA"
            ParseFunction(23) = "COTHA"
            ParseFunction(24) = "XPWR"
            ParseFunction(25) = "EPWR"
            ParseFunction(26) = "TWOPWR"
            ParseFunction(27) = "TENPWR"
            ParseFunction(28) = "YPWR"
            ParseFunction(29) = "LOG"
            ParseFunction(30) = "LN"
            ParseFunction(31) = "LOGX"
            ParseFunction(32) = "SQRT"
            ParseFunction(33) = "CURT"
            ParseFunction(34) = "ROTX"
            ParseFunction(35) = "MOD"
            Dim StrToRemove As String = ""
            Dim StrToRemoveLength As Integer
            Dim pf As Integer
            'Find Position Of SubString To Remove
            'Cycle Throu Functions List
            For pf = 0 To ParseFunctionIndex - 1
                Dim StartLength As Integer = 1
                Dim StartIndex As Integer = ParseBuild.Length - 1
                'Check For Function At End Of ParseBuild
                'If Exist Then Remove
                For nt As Integer = ParseBuild.Length To 1 Step -1
                    If StartIndex = -1 Then Exit For
                    'Build SubString
                    StrToRemove = ParseBuild.Substring(StartIndex, StartLength)
                    If StrToRemove = ParseFunction(pf) Then
                        StrToRemoveLength = StrToRemove.Length
                        Exit For
                    End If
                    StartIndex -= 1
                    StartLength += 1
                Next
                If StrToRemove = ParseFunction(pf) Then
                    Exit For
                End If
            Next
            'Remove Math Function From ParseBuild
            If StrToRemove = ParseFunction(pf) Then
                ParseBuild = ReplaceEndSubstring(ParseBuild, StrToRemove, "")
            End If
            LblFormula.Text = "Formula = " & ParseBuild
            Select Case StrToRemove
                Case ParseFunction(24)
                    TwoParameters(SegmentIndex) = False'xpwr
                Case ParseFunction(28)
                    TwoParameters(SegmentIndex) = False'ypwr
                Case ParseFunction(34)
                    TwoParameters(SegmentIndex) = False 'xroot
                Case ParseFunction(35)
                    TwoParameters(SegmentIndex) = False 'Mod
            End Select
            '************************************************DELETE DISPLAY FUNCTIONS********************************************
            'Delete The DisplayFunctions
            If DisplayBuild = Nothing Then
                ClearAll()
                Exit Sub
            End If
            Dim DisplayFunctionIndex As Integer = 36
            Dim DisplayFunction(DisplayFunctionIndex) As String
            DisplayFunction(0) = "Sin"
            DisplayFunction(1) = "Cos"
            DisplayFunction(2) = "Tan"
            DisplayFunction(3) = "Sec"
            DisplayFunction(4) = "Csc"
            DisplayFunction(5) = "Cot"
            DisplayFunction(6) = "Sinh"
            DisplayFunction(7) = "Cosh"
            DisplayFunction(8) = "Tanh"
            DisplayFunction(9) = "Sech"
            DisplayFunction(10) = "Csch"
            DisplayFunction(11) = "Coth"
            DisplayFunction(12) = "Sin" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            DisplayFunction(13) = "Cos" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            DisplayFunction(14) = "Tan" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            DisplayFunction(15) = "Sec" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            DisplayFunction(16) = "Csc" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            DisplayFunction(17) = "Cot" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            DisplayFunction(18) = "Sinh" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            DisplayFunction(19) = "Cosh" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            DisplayFunction(20) = "Tanh" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            DisplayFunction(21) = "Sech" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            DisplayFunction(22) = "Csch" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            DisplayFunction(23) = "Coth" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            DisplayFunction(24) = "^" & Strings.ChrW(&H2E3)
            DisplayFunction(25) = "e^"
            DisplayFunction(26) = "2^"
            DisplayFunction(27) = "10^"
            DisplayFunction(28) = "Pwr"
            DisplayFunction(29) = "Logc"
            DisplayFunction(30) = "Loge"
            DisplayFunction(31) = "Logx"
            DisplayFunction(32) = Strings.Chr(178) & ChrW(&H221A)
            DisplayFunction(33) = Strings.Chr(179) & ChrW(&H221A)
            DisplayFunction(34) = Strings.ChrW(&H2E3) & ChrW(&H221A)
            DisplayFunction(35) = "Mod"
            'Find Position Of SubString To Remove
            'Cycle Throu Functions List
            For pf = 0 To DisplayFunctionIndex - 1
                Dim StartLength As Integer = 1
                Dim StartIndex As Integer = DisplayBuild.Length - 1
                'Check For Function At End Of ParseBuild
                'If Exist Then Remove
                For nt As Integer = DisplayBuild.Length To 1 Step -1
                    If StartIndex = -1 Then Exit For
                    'Build SubString
                    StrToRemove = DisplayBuild.Substring(StartIndex, StartLength)
                    If StrToRemove = DisplayFunction(pf) Then
                        StrToRemoveLength = StrToRemove.Length
                        Exit For
                    End If
                    StartIndex -= 1
                    StartLength += 1
                Next
                If StrToRemove = DisplayFunction(pf) Then
                    Exit For
                End If
            Next
            'Remove Math Function From DisplayBuild
            If StrToRemove = DisplayFunction(pf) Then DisplayBuild = ReplaceEndSubstring(DisplayBuild, StrToRemove, "")
            TbDisplay.Text = DisplayBuild
            If ParseBuild & DisplayBuild = Nothing Then
                ClearAll()
            End If
        Catch exception As Exception
            MsgBox("DeleteParseFunctions" & exception.Message)
        End Try
    End Sub
    Private Sub DeleteValues()
        If ParseBuild = Nothing Then
            ClearAll()
            Exit Sub
        End If
        Dim ParseLen As Integer = ParseBuild.Length
        Dim StartLength As Integer = 1
        Dim StartIndex As Integer = ParseBuild.Length - 1
        Try
            For i As Integer = ParseBuild.Length - 1 To 0 Step -1
                Dim CharName As Char = ParseBuild.Chars(i)
                If Char.IsLetter(ParseBuild.Chars(i)) Then
                    Dim CharToDelete As String = CStr(CharName)
                    If CharToDelete = SegmentName(SegmentIndex) Then
                        Dim StrToDelete = ParseBuild.Substring(StartIndex, StartLength)
                        If StrToDelete = CharToDelete Then
                            ParseBuild = ReplaceEndSubstring(ParseBuild, StrToDelete, "")
                            Exit For
                        End If
                    End If
                Else
                    Exit Sub
                End If
            Next i
            '******************************************DELETE DISPLAY VALUES*****************************************
            If DisplayBuild = Nothing Then
                ClearAll()
                Exit Sub
            End If
            Dim TempValue As String = ""
            If AnswerExisted Then 'All Values Was Converted To Decimal
                Select Case Base
                    Case "Decimal"
                        TempValue = SegmentValue(SegmentIndex)
                    Case "Binary"
                        TempValue = BinarySegmentValue(SegmentIndex)
                    Case "Hex"
                        TempValue = Hex(SegmentValue(SegmentIndex))
                    Case "Octal"
                        Dim I As Int64 = Convert.ToInt64(SegmentValue(SegmentIndex))
                        TempValue = Oct(I)
                End Select
            Else
                TempValue = SegmentValue(SegmentIndex)
            End If
            'Trim Math Functions And Other Characters Off End Of DisplayBuild
            For i As Integer = DisplayBuild.Length To 1 Step -1
                If SegmentValue(SegmentIndex) <> Nothing Then
                    Dim DisplayLen As Integer = DisplayBuild.Length
                    Dim RemoveStr As String = Mid(DisplayBuild, i)
                    If InStr(1, RemoveStr, TempValue, CompareMethod.Text) Then
                        DisplayBuild = ReplaceEndSubstring(DisplayBuild, RemoveStr, "")
                        Exit For
                    End If
                Else
                    Exit For
                End If
            Next i
            SegmentValue(SegmentIndex) = Nothing
            SegmentName(SegmentIndex) = Nothing
            ReDim Preserve SegmentValue(SegmentIndex)
            ReDim Preserve SegmentName(SegmentIndex)
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            ReadyForValue = True
            TbDisplay.Text = DisplayBuild
            LblFormula.Text = "Formula = " & ParseBuild
            ReadyForValue = True
            AnswerReceived = False
            If ParseBuild & DisplayBuild = Nothing Then
                ClearAll()
            End If
        Catch exception As Exception
            MsgBox(" DeleteParseValues" & exception.Message)
        End Try
    End Sub
    Private Function EndTrim(StrToTrim As String) As String
        If DisplayBuild = Nothing Or ParseBuild = Nothing Then Exit Function
        'Trim Math Functions And Other Characters Off End Of DisplayBuild Or ParseBuild
        If StrToTrim = Nothing Then
            ClearAll()
            Exit Function
        End If
        Try
            Dim MyChar(4) As Char
            MyChar(0) = ")"
            MyChar(1) = "("
            MyChar(2) = " "
            Dim LastChar As Char
            Dim TempStr As String = StrToTrim
            If TempStr = DisplayBuild Then TempStr = "Display"
            If TempStr = ParseBuild Then TempStr = "Parse"
            For s As Integer = 1 To StrToTrim.Length - 1
                'If Char = Letter or Number Then Trim End OK, Exit Loop
                If IsNumeric(LastChar) Or Char.IsLetter(LastChar) Then Exit For
                LastChar = StrToTrim(StrToTrim.Length - 1)
                For i As Integer = 0 To UBound(MyChar) - 1
                    LastChar = StrToTrim(StrToTrim.Length - 1)
                    If LastChar = MyChar(i) Then
                        StrToTrim = StrToTrim.TrimEnd(MyChar(i))
                        If TempStr = "Display" Then
                            If MyChar(i) = ")" Then
                                BracketsIndex += 1 'Increment Open Parentheses Array Index
                                ReDim Preserve BracketsOpen(BracketsIndex) 'Preserve The Incremented Array
                                BracketsOpen(BracketsIndex) = True 'Assign Value
                                RelabelBtnOpenParentheses()
                            End If
                            If BracketsIndex > 0 And MyChar(i) = "(" Then
                                BracketsIndex -= 1 'Decrease Open Parentheses Array Index
                                ReDim Preserve BracketsOpen(BracketsIndex) 'Preserve The Incremented Array
                                BracketsOpen(BracketsIndex) = True 'Assign Value
                                RelabelBtnOpenParentheses()
                            End If
                        End If
                    End If
                Next i
            Next s
        Catch exception As Exception
            MsgBox("EndTrim" & exception.Message)
        End Try
        Return StrToTrim
#Disable Warning BC42105 ' Function doesn't return a value on all code paths
    End Function
#Enable Warning BC42105 ' Function doesn't return a value on all code paths
    Private Sub FrmCalculator_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Select Case e.KeyChar
            Case "0"
                Btn0.PerformClick()
            Case "1"
                Btn1.PerformClick()
            Case "2"
                Btn2.PerformClick()
            Case "3"
                Btn3.PerformClick()
            Case "4"
                Btn4.PerformClick()
            Case "5"
                Btn5.PerformClick()
            Case "6"
                Btn6.PerformClick()
            Case "7"
                Btn7.PerformClick()
            Case "8"
                Btn8.PerformClick()
            Case "9"
                Btn9.PerformClick()
            Case "A"
                BtnHexA.PerformClick()
            Case "a"
                BtnHexA.PerformClick()
            Case "B"
                BtnHexB.PerformClick()
            Case "b"
                BtnHexB.PerformClick()
            Case "C"
                BtnHexC.PerformClick()
            Case "c"
                BtnHexC.PerformClick()
            Case "D"
                BtnHexD.PerformClick()
            Case "d"
                BtnHexD.PerformClick()
            Case "E"
                BtnHexE.PerformClick()
            Case "e"
                BtnHexE.PerformClick()
            Case "F"
                BtnHexF.PerformClick()
            Case "f"
                BtnHexF.PerformClick()
            Case "+"
                BtnAdd.PerformClick()
            Case "-"
                BtnSubtract.PerformClick()
            Case "*"
                BtnMultiply.PerformClick()
            Case "/"
                BtnDivide.PerformClick()
            Case "^"
                BtnXraised.PerformClick()
            Case "%"
                BtnPercent.PerformClick()
            Case "("
                BtnOpenParentheses.PerformClick()
            Case ")"
                BtnCloseParentheses.PerformClick()
            Case "."
                BtnPoint.PerformClick()
            Case vbBack
                BtnCE.PerformClick()
            Case vbCr
                BtnEqual.PerformClick()
        End Select
        e.Handled = True
    End Sub
    Private Sub EnableButtons()
        Select Case Base
            Case "Decimal"
                Btn0.Enabled = True
                Btn1.Enabled = True
                Btn2.Enabled = True
                Btn3.Enabled = True
                Btn4.Enabled = True
                Btn5.Enabled = True
                Btn6.Enabled = True
                Btn7.Enabled = True
                Btn8.Enabled = True
                Btn9.Enabled = True
                Btn0.BackColor = Color.WhiteSmoke
                Btn1.BackColor = Color.WhiteSmoke
                Btn2.BackColor = Color.WhiteSmoke
                Btn3.BackColor = Color.WhiteSmoke
                Btn4.BackColor = Color.WhiteSmoke
                Btn5.BackColor = Color.WhiteSmoke
                Btn6.BackColor = Color.WhiteSmoke
                Btn7.BackColor = Color.WhiteSmoke
                Btn8.BackColor = Color.WhiteSmoke
                Btn9.BackColor = Color.WhiteSmoke
                BtnHexA.Enabled = False
                BtnHexB.Enabled = False
                BtnHexC.Enabled = False
                BtnHexD.Enabled = False
                BtnHexE.Enabled = False
                BtnHexF.Enabled = False
                BtnHexA.BackColor = Color.Gray
                BtnHexB.BackColor = Color.Gray
                BtnHexC.BackColor = Color.Gray
                BtnHexD.BackColor = Color.Gray
                BtnHexE.BackColor = Color.Gray
                BtnHexF.BackColor = Color.Gray
            Case "Binary"
                Btn0.Enabled = True
                Btn1.Enabled = True
                Btn0.BackColor = Color.WhiteSmoke
                Btn1.BackColor = Color.WhiteSmoke
                Btn2.Enabled = False
                Btn3.Enabled = False
                Btn4.Enabled = False
                Btn5.Enabled = False
                Btn6.Enabled = False
                Btn7.Enabled = False
                Btn8.Enabled = False
                Btn9.Enabled = False
                Btn2.BackColor = Color.Gray
                Btn3.BackColor = Color.Gray
                Btn4.BackColor = Color.Gray
                Btn5.BackColor = Color.Gray
                Btn6.BackColor = Color.Gray
                Btn7.BackColor = Color.Gray
                Btn8.BackColor = Color.Gray
                Btn9.BackColor = Color.Gray
                BtnHexA.Enabled = False
                BtnHexB.Enabled = False
                BtnHexC.Enabled = False
                BtnHexD.Enabled = False
                BtnHexE.Enabled = False
                BtnHexF.Enabled = False
                BtnHexA.BackColor = Color.Gray
                BtnHexB.BackColor = Color.Gray
                BtnHexC.BackColor = Color.Gray
                BtnHexD.BackColor = Color.Gray
                BtnHexE.BackColor = Color.Gray
                BtnHexF.BackColor = Color.Gray
            Case "Hex"
                BtnHexA.Enabled = True
                BtnHexB.Enabled = True
                BtnHexC.Enabled = True
                BtnHexD.Enabled = True
                BtnHexE.Enabled = True
                BtnHexF.Enabled = True
                BtnHexA.BackColor = Color.WhiteSmoke
                BtnHexB.BackColor = Color.WhiteSmoke
                BtnHexC.BackColor = Color.WhiteSmoke
                BtnHexD.BackColor = Color.WhiteSmoke
                BtnHexE.BackColor = Color.WhiteSmoke
                BtnHexF.BackColor = Color.WhiteSmoke
                Btn0.Enabled = True
                Btn1.Enabled = True
                Btn2.Enabled = True
                Btn3.Enabled = True
                Btn4.Enabled = True
                Btn5.Enabled = True
                Btn6.Enabled = True
                Btn7.Enabled = True
                Btn8.Enabled = True
                Btn9.Enabled = True
                Btn0.BackColor = Color.WhiteSmoke
                Btn1.BackColor = Color.WhiteSmoke
                Btn2.BackColor = Color.WhiteSmoke
                Btn3.BackColor = Color.WhiteSmoke
                Btn4.BackColor = Color.WhiteSmoke
                Btn5.BackColor = Color.WhiteSmoke
                Btn6.BackColor = Color.WhiteSmoke
                Btn7.BackColor = Color.WhiteSmoke
                Btn8.BackColor = Color.WhiteSmoke
                Btn9.BackColor = Color.WhiteSmoke
            Case "Octal"
                Btn0.Enabled = True
                Btn1.Enabled = True
                Btn2.Enabled = True
                Btn3.Enabled = True
                Btn4.Enabled = True
                Btn5.Enabled = True
                Btn6.Enabled = True
                Btn7.Enabled = True
                Btn8.Enabled = False
                Btn9.Enabled = False
                Btn0.BackColor = Color.WhiteSmoke
                Btn1.BackColor = Color.WhiteSmoke
                Btn2.BackColor = Color.WhiteSmoke
                Btn3.BackColor = Color.WhiteSmoke
                Btn4.BackColor = Color.WhiteSmoke
                Btn5.BackColor = Color.WhiteSmoke
                Btn6.BackColor = Color.WhiteSmoke
                Btn7.BackColor = Color.WhiteSmoke
                Btn8.BackColor = Color.Gray
                Btn9.BackColor = Color.Gray
                BtnHexA.Enabled = False
                BtnHexB.Enabled = False
                BtnHexC.Enabled = False
                BtnHexD.Enabled = False
                BtnHexE.Enabled = False
                BtnHexF.Enabled = False
                BtnHexA.BackColor = Color.Gray
                BtnHexB.BackColor = Color.Gray
                BtnHexC.BackColor = Color.Gray
                BtnHexD.BackColor = Color.Gray
                BtnHexE.BackColor = Color.Gray
                BtnHexF.BackColor = Color.Gray
        End Select
        If Base <> "Decimal" Then
            BtnLogc.Enabled = False
            BtnLoge.Enabled = False
            BtnLogx.Enabled = False
            BtnNegPos.Enabled = False
            BtnPoint.Enabled = False
            BtnComma.Enabled = False
            BtnSine.Enabled = False
            BtnCosine.Enabled = False
            BtnTangent.Enabled = False
            BtnHypKey.Enabled = False
            BtnExp.Enabled = False
            BtnSec.Enabled = False
            BtnCsc.Enabled = False
            BtnCot.Enabled = False
            BtnArcKey.Enabled = False
            BtnPi.Enabled = False
            BtnReciprocal.Enabled = False
            BtnPercent.Enabled = False
            BtnE.Enabled = False
            BtnXraised.Enabled = False
            Btn10x.Enabled = False
            Btn2Raised.Enabled = False
            Btnex.Enabled = False
            BtnCtoF.Enabled = False
            BtnFtoC.Enabled = False
            BtnFourthRt.Enabled = False
            BtnCubeRt.Enabled = False
            BtnSqrt.Enabled = False
            BtnMod.Enabled = False
            BtnLogc.BackColor = Color.Gray
            BtnLoge.BackColor = Color.Gray
            BtnLogx.BackColor = Color.Gray
            BtnNegPos.BackColor = Color.Gray
            BtnPoint.BackColor = Color.Gray
            BtnComma.BackColor = Color.Gray
            BtnSine.BackColor = Color.Gray
            BtnCosine.BackColor = Color.Gray
            BtnTangent.BackColor = Color.Gray
            BtnHypKey.BackColor = Color.Gray
            BtnExp.BackColor = Color.Gray
            BtnSec.BackColor = Color.Gray
            BtnCsc.BackColor = Color.Gray
            BtnCot.BackColor = Color.Gray
            BtnArcKey.BackColor = Color.Gray
            BtnPi.BackColor = Color.Gray
            BtnReciprocal.BackColor = Color.Gray
            BtnPercent.BackColor = Color.Gray
            BtnE.BackColor = Color.Gray
            BtnXraised.BackColor = Color.Gray
            Btn10x.BackColor = Color.Gray
            Btn2Raised.BackColor = Color.Gray
            Btnex.BackColor = Color.Gray
            BtnCtoF.BackColor = Color.Gray
            BtnFtoC.BackColor = Color.Gray
            BtnFourthRt.BackColor = Color.Gray
            BtnCubeRt.BackColor = Color.Gray
            BtnSqrt.BackColor = Color.Gray
            BtnMod.BackColor = Color.Gray
        Else
            BtnLogc.Enabled = True
            BtnLoge.Enabled = True
            BtnLogx.Enabled = True
            BtnNegPos.Enabled = True
            BtnPoint.Enabled = True
            BtnComma.Enabled = True
            BtnSine.Enabled = True
            BtnCosine.Enabled = True
            BtnTangent.Enabled = True
            BtnHypKey.Enabled = True
            BtnExp.Enabled = True
            BtnSec.Enabled = True
            BtnCsc.Enabled = True
            BtnCot.Enabled = True
            BtnArcKey.Enabled = True
            BtnPi.Enabled = True
            BtnReciprocal.Enabled = True
            BtnPercent.Enabled = True
            BtnE.Enabled = True
            BtnXraised.Enabled = True
            Btn10x.Enabled = True
            Btn2Raised.Enabled = True
            Btnex.Enabled = True
            BtnCtoF.Enabled = True
            BtnFtoC.Enabled = True
            BtnFourthRt.Enabled = True
            BtnCubeRt.Enabled = True
            BtnSqrt.Enabled = True
            BtnMod.Enabled = True
            BtnLogc.BackColor = Color.WhiteSmoke
            BtnLoge.BackColor = Color.WhiteSmoke
            BtnLogx.BackColor = Color.WhiteSmoke
            BtnNegPos.BackColor = Color.WhiteSmoke
            BtnPoint.BackColor = Color.WhiteSmoke
            BtnComma.BackColor = Color.WhiteSmoke
            BtnSine.BackColor = Color.WhiteSmoke
            BtnCosine.BackColor = Color.WhiteSmoke
            BtnTangent.BackColor = Color.WhiteSmoke
            BtnHypKey.BackColor = Color.WhiteSmoke
            BtnExp.BackColor = Color.WhiteSmoke
            BtnSec.BackColor = Color.WhiteSmoke
            BtnCsc.BackColor = Color.WhiteSmoke
            BtnCot.BackColor = Color.WhiteSmoke
            BtnArcKey.BackColor = Color.WhiteSmoke
            BtnPi.BackColor = Color.WhiteSmoke
            BtnReciprocal.BackColor = Color.WhiteSmoke
            BtnPercent.BackColor = Color.WhiteSmoke
            BtnE.BackColor = Color.WhiteSmoke
            BtnXraised.BackColor = Color.WhiteSmoke
            Btn10x.BackColor = Color.WhiteSmoke
            Btn2Raised.BackColor = Color.WhiteSmoke
            Btnex.BackColor = Color.WhiteSmoke
            BtnCtoF.BackColor = Color.WhiteSmoke
            BtnFtoC.BackColor = Color.WhiteSmoke
            BtnFourthRt.BackColor = Color.WhiteSmoke
            BtnCubeRt.BackColor = Color.WhiteSmoke
            BtnSqrt.BackColor = Color.WhiteSmoke
            BtnMod.BackColor = Color.WhiteSmoke
        End If
    End Sub
    Private Function FormulaParse(MathExpression As String, ParseValues() As String, Xvalue As String, Yvalue As String) As String
        'Instantiate The Parser
        'Allow For String Variables
        Dim myParser As MathParser = New MathParser
        myParser.StringLiteralsAllowed = True
        Try
            'Alphabetically Assign Variable Names To Value Array And SetVariables With Parser
            'Value Assignment Should Be Identical To Values Assigned By Calculator But May Be Different
            'Only Use A-W, X And Y Reserved By MathParser .X,.Y Variables
            Dim C As Integer = 0
            For I As Int16 = Convert.ToInt16("A"c) To Convert.ToInt16("W"c)
                C += 1
                Dim ChrLetter As Char = Convert.ToChar(I)
                Dim VarName As String = CStr(ChrLetter)
                Dim VarValue As String = ParseValues(C)
                myParser.SetVariable(VarName, VarValue, Nothing)
                If C >= UBound(ParseValues) Then Exit For
            Next
            'My Created Functions That Are Not Available With Parser
            myParser.CreateOneParamFunc("SINE", New OneParamFunc(AddressOf MySIN))
            myParser.CreateOneParamFunc("COSN", New OneParamFunc(AddressOf MyCOS))
            myParser.CreateOneParamFunc("TANG", New OneParamFunc(AddressOf MyTAN))
            myParser.CreateOneParamFunc("SINEH", New OneParamFunc(AddressOf MySINH))
            myParser.CreateOneParamFunc("COSNH", New OneParamFunc(AddressOf MyCOSH))
            myParser.CreateOneParamFunc("TANH", New OneParamFunc(AddressOf MyTANH))
            myParser.CreateOneParamFunc("SINA", New OneParamFunc(AddressOf MyASIN))
            myParser.CreateOneParamFunc("COSA", New OneParamFunc(AddressOf MyACOS))
            myParser.CreateOneParamFunc("TANA", New OneParamFunc(AddressOf MyATAN))
            myParser.CreateOneParamFunc("SEC", New OneParamFunc(AddressOf MySEC))
            myParser.CreateOneParamFunc("CSC", New OneParamFunc(AddressOf MyCSC))
            myParser.CreateOneParamFunc("COT", New OneParamFunc(AddressOf MyCOT))
            myParser.CreateOneParamFunc("SECH", New OneParamFunc(AddressOf MySECH))
            myParser.CreateOneParamFunc("CSCH", New OneParamFunc(AddressOf MyCSCH))
            myParser.CreateOneParamFunc("COTH", New OneParamFunc(AddressOf MyCOTH))
            myParser.CreateOneParamFunc("SINHA", New OneParamFunc(AddressOf MyASINH))
            myParser.CreateOneParamFunc("COSHA", New OneParamFunc(AddressOf MyACOSH))
            myParser.CreateOneParamFunc("TANHA", New OneParamFunc(AddressOf MyATANH))
            myParser.CreateOneParamFunc("SECA", New OneParamFunc(AddressOf MyASEC))
            myParser.CreateOneParamFunc("CSCA", New OneParamFunc(AddressOf MyACSC))
            myParser.CreateOneParamFunc("COTA", New OneParamFunc(AddressOf MyACOT))
            myParser.CreateOneParamFunc("SECHA", New OneParamFunc(AddressOf MyASECH))
            myParser.CreateOneParamFunc("CSCHA", New OneParamFunc(AddressOf MyACSCH))
            myParser.CreateOneParamFunc("COTHA", New OneParamFunc(AddressOf MyACOTH))
            myParser.CreateOneParamFunc("EPWR", New OneParamFunc(AddressOf MyEPWR)) 'e^X
            myParser.CreateOneParamFunc("TWOPWR", New OneParamFunc(AddressOf MyTWOPWR)) '2^X
            myParser.CreateOneParamFunc("TENPWR", New OneParamFunc(AddressOf MyTENPWR)) '10^X
            myParser.CreateTwoParamFunc("YPWR", New TwoParamFunc(AddressOf MyYPWR)) 'X^Y
            myParser.CreateTwoParamFunc("LOGX", New TwoParamFunc(AddressOf MyLOGX)) 'X Log Base
            myParser.CreateOneParamFunc("CURT", New OneParamFunc(AddressOf MyCURT)) 'Cubed Root
            myParser.CreateTwoParamFunc("ROTX", New TwoParamFunc(AddressOf MyROTX)) 'X Root
            'If X Is Used In Formula
            If Xvalue <> Nothing Then
                myParser.Expression = Xvalue
                myParser.OptimizationOn = True
                'Return The Answer As String
                Xvalue = myParser.ValueAsString()
                'Input X Into The MathExpression As String Value
                myParser.X = Double.Parse(Xvalue)
            End If
            'If Y Is Used In Formula
            If Yvalue <> Nothing Then
                myParser.Expression = Yvalue
                myParser.OptimizationOn = True
                'Return The Answer As String
                Yvalue = myParser.ValueAsString()
                'Input Y Into The MathExpression As String Value
                myParser.Y = Double.Parse(Yvalue)
            End If
            myParser.CreateFunc("MYADD", New MyAddFunc)
            myParser.Expression = MathExpression
            myParser.OptimizationOn = True
            'Return The Answer As String
            Return myParser.ValueAsString()
            'Measure Repeated Evaluation
            Dim Start As Integer
            Dim r As Int32
            Start = GetTickCount()
            For r = 0 To 1000000
                myParser.Evaluate()
            Next
            Dim TcMilliSeconds As String = (GetTickCount() - Start) & " milliseconds"
            myParser.FreeParseTree()
        Catch exception As Exception
            MsgBox("FormulaParse:" & exception.Message)
        End Try
#Disable Warning BC42105 ' Function doesn't return a value on all code paths
    End Function
#Enable Warning BC42105 ' Function doesn't return a value on all code paths
    Private Function MyROTX(x As IParameter, y As IParameter) As Double
        'X Root Of Y
        Dim xVal As Double = x.GetValueAsDouble()
        Dim yVal As Double = y.GetValueAsDouble()
        Dim result As Double = Math.Pow(yVal, 1 / xVal)
        Dim rAnswer As String = result.ToString()
        Return rAnswer
    End Function
    Private Function MyCURT(x As IParameter) As Double
        'Cubed Root
        Dim xVal As Double = x.GetValueAsDouble()
        Dim result As Double = Math.Pow(xVal, 1 / 3)
        Dim cAnswer As String = result.ToString()
        ' Check the result.
        'Dim check As Double = Math.Pow(result, 3)
        'Dim tAnswer As String = check.ToString()
        'If CStr(xVal) = tAnswer Then
        Return cAnswer
    End Function
    Private Function MyYPWR(x As IParameter, y As IParameter) As Double
        'X^Y
        Dim xVal As Double = x.GetValueAsDouble()
        Dim yVal As Double = y.GetValueAsDouble()
        Dim xAnswer As Double = xVal ^ yVal
        Return xAnswer
    End Function
    Private Function MyLOGX(x As IParameter, y As IParameter) As Double
        'LOGx(X)
        Dim xVal As Double = x.GetValueAsDouble()
        Dim yVal As Double = y.GetValueAsDouble()
        Dim LogAnswer As Double = Log(yVal) / Log(xVal)
        Return LogAnswer
    End Function
    Private Function MyEPWR(x As IParameter) As Double
        'e^x
        Dim xVal As Double = x.GetValueAsDouble()
        Dim eAnswer As Double = Math.E ^ xVal
        Return eAnswer
    End Function
    Private Function MyTWOPWR(x As IParameter) As Double
        '1 Parameter Function
        Dim xVal As Double = x.GetValueAsDouble()
        Dim pAnswer As Double = 2 ^ xVal
        Return pAnswer
    End Function
    Private Function MyTENPWR(x As IParameter) As Double
        '1 Parameter Function
        Dim xVal As Double = x.GetValueAsDouble()
        Dim pAnswer As Double = 10 ^ xVal
        Return pAnswer
    End Function
    Private Function MySIN(x As IParameter) As Double
        '1 Parameter Function
        Dim TrigAnswer As Double
        Dim xVal As Double = x.GetValueAsDouble()
        Select Case TrigFunction
            Case "Radian"
                TrigAnswer = Math.Sin(xVal)
            Case "Degree"
                TrigAnswer = Math.Sin(xVal * (PI / 180))
            Case "Gradian"
                TrigAnswer = Math.Sin(xVal * (PI / 200))
        End Select
        Return TrigAnswer
    End Function
    Private Function MyCOS(x As IParameter) As Double
        '1 Parameter Function
        Dim TrigAnswer As Double
        Dim xVal As Double = x.GetValueAsDouble()
        Select Case TrigFunction
            Case "Radian"
                TrigAnswer = Math.Cos(xVal)
            Case "Degree"
                TrigAnswer = Math.Cos(xVal * (PI / 180))
            Case "Gradian"
                TrigAnswer = Math.Cos(xVal * (PI / 200))
        End Select
        Return TrigAnswer
    End Function
    Private Function MyTAN(x As IParameter) As Double
        '1 Parameter Function
        Dim TrigAnswer As Double
        Dim xVal As Double = x.GetValueAsDouble()
        Select Case TrigFunction
            Case "Radian"
                TrigAnswer = Math.Tan(xVal)
            Case "Degree"
                TrigAnswer = Math.Tan(xVal * (PI / 180))
            Case "Gradian"
                TrigAnswer = Math.Tan(xVal * (PI / 200))
        End Select
        Return TrigAnswer
    End Function
    Private Function MySINH(x As IParameter) As Double
        '1 Parameter Function
        Dim TrigAnswer As Double
        Dim xVal As Double = x.GetValueAsDouble()
        Select Case TrigFunction
            Case "Radian"
                TrigAnswer = Math.Sinh(xVal)
            Case "Degree"
                TrigAnswer = Math.Sinh(xVal * (PI / 180))
            Case "Gradian"
                TrigAnswer = Math.Sinh(xVal * (PI / 200))
        End Select
        Return TrigAnswer
    End Function
    Private Function MyCOSH(x As IParameter) As Double
        '1 Parameter Function
        Dim TrigAnswer As Double
        Dim xVal As Double = x.GetValueAsDouble()
        Select Case TrigFunction
            Case "Radian"
                TrigAnswer = Math.Cosh(xVal)
            Case "Degree"
                TrigAnswer = Math.Cosh(xVal * (PI / 180))
            Case "Gradian"
                TrigAnswer = Math.Cosh(xVal * (PI / 200))
        End Select
        Return TrigAnswer
    End Function
    Private Function MyTANH(x As IParameter) As Double
        '1 Parameter Function
        'myParser.CreateOneParamFunc("TANH", New OneParamFunc(AddressOf MyTANH))
        Dim TrigAnswer As Double
        Dim xVal As Double = x.GetValueAsDouble()
        Select Case TrigFunction
            Case "Radian"
                TrigAnswer = Math.Tanh(xVal)
            Case "Degree"
                TrigAnswer = Math.Tanh(xVal * (PI / 180))
            Case "Gradian"
                TrigAnswer = Math.Tanh(xVal * (PI / 200))
        End Select
        Return TrigAnswer
    End Function
    Private Function MySEC(x As IParameter) As Double
        '1 Parameter Function
        Dim TrigAnswer As Double
        Dim xVal As Double = x.GetValueAsDouble()
        Select Case TrigFunction
            Case "Radian"
                TrigAnswer = 1 / Cos(xVal)
            Case "Degree"
                TrigAnswer = 1 / Cos(xVal * (PI / 180))
            Case "Gradian"
                TrigAnswer = 1 / Cos(xVal * (PI / 200))
        End Select
        Return TrigAnswer
    End Function
    Private Function MyCSC(x As IParameter) As Double
        '1 Parameter Function
        Dim xVal As Double = x.GetValueAsDouble()
        Dim TrigAnswer As Double
        Select Case TrigFunction
            Case "Radian"
                TrigAnswer = 1 / Sin(xVal)
            Case "Degree"
                TrigAnswer = 1 / Sin(xVal * (PI / 180))
            Case "Gradian"
                TrigAnswer = 1 / Sin(xVal * (PI / 200))
        End Select
        Return TrigAnswer
    End Function
    Private Function MyCOT(x As IParameter) As Double
        '1 Parameter Function
        Dim xVal As Double = x.GetValueAsDouble()
        Dim TrigAnswer As Double
        Select Case TrigFunction
            Case "Radian"
                TrigAnswer = 1 / Tan(xVal)
            Case "Degree"
                TrigAnswer = 1 / Tan(xVal * (PI / 180))
            Case "Gradian"
                TrigAnswer = 1 / Tan(xVal * (PI / 200))
        End Select
        Return TrigAnswer
    End Function
    Private Function MyASECH(x As IParameter) As Double
        '1 Parameter Function
        'Log((Sqrt(-x * x + 1) + 1) / x)
        Dim xVal As Double = x.GetValueAsDouble()
        Dim TrigAnswer As Double
        Select Case TrigFunction
            Case "Radian"
                TrigAnswer = Log((Sqrt(-xVal * xVal + 1) + 1) / xVal)
            Case "Degree"
                TrigAnswer = Log((Sqrt(-xVal * xVal + 1) + 1) / xVal) * 57.295779513082323
            Case "Gradian"
                TrigAnswer = Log((Sqrt(-xVal * xVal + 1) + 1) / xVal) / 1.1111111111111112
        End Select
        Return TrigAnswer
    End Function
    Private Function MyACSCH(x As IParameter) As Double
        '1 Parameter Function
        'Log((Sign(x) * Sqrt(x * x + 1) + 1) / x)
        Dim xVal As Double = x.GetValueAsDouble()
        Dim TrigAnswer As Double
        Select Case TrigFunction
            Case "Radian"
                TrigAnswer = Log((Sign(xVal) * Sqrt(xVal * xVal + 1) + 1) / xVal)
            Case "Degree"
                TrigAnswer = Log((Sign(xVal) * Sqrt(xVal * xVal + 1) + 1) / xVal) * 57.295779513082323
            Case "Gradian"
                TrigAnswer = Log((Sign(xVal) * Sqrt(xVal * xVal + 1) + 1) / xVal) / 1.1111111111111112
        End Select
        Return TrigAnswer
    End Function
    Private Function MyACOTH(x As IParameter) As Double
        '1 Parameter Function
        'Log((x + 1) / (x – 1)) / 2
        Dim xVal As Double = x.GetValueAsDouble()
        Dim TrigAnswer As Double
        Select Case TrigFunction
            Case "Radian"
                TrigAnswer = Log((xVal + 1) / (xVal - 1)) / 2
            Case "Degree"
                TrigAnswer = (Log((xVal + 1) / (xVal - 1)) / 2) * 57.295779513082323
            Case "Gradian"
                TrigAnswer = (Log((xVal + 1) / (xVal - 1)) / 2) / 1.1111111111111112
        End Select
        Return TrigAnswer
    End Function
    Private Function MySECH(x As IParameter) As Double
        '1 Parameter Function
        '2 / (Exp(x) + Exp(-x))
        Dim xVal As Double = x.GetValueAsDouble()
        Dim TrigAnswer As Double
        Select Case TrigFunction
            Case "Radian"
                TrigAnswer = 2 / (Exp(xVal) + Exp(-xVal))
            Case "Degree"
                TrigAnswer = 2 / (Exp((xVal * (PI / 180))) + Exp((-xVal * (PI / 180))))
            Case "Gradian"
                TrigAnswer = 2 / (Exp((xVal * (PI / 200))) + Exp((-xVal * (PI / 200))))
        End Select
        Return TrigAnswer
    End Function
    Private Function MyCSCH(x As IParameter) As Double
        '1 Parameter Function
        '2 / (Exp(x) – Exp(-x))
        Dim xVal As Double = x.GetValueAsDouble()
        Dim TrigAnswer As Double
        Select Case TrigFunction
            Case "Radian"
                TrigAnswer = 2 / (Exp(xVal) - Exp(-xVal))
            Case "Degree"
                TrigAnswer = 2 / (Exp((xVal * (PI / 180))) - Exp((-xVal * (PI / 180))))
            Case "Gradian"
                TrigAnswer = 2 / (Exp((xVal * (PI / 200))) - Exp((-xVal * (PI / 200))))
        End Select
        Return TrigAnswer
    End Function
    Private Function MyCOTH(x As IParameter) As Double
        '1 Parameter Function
        '(Exp(x) + Exp(-x)) / (Exp(x) – Exp(-x))
        Dim xVal As Double = x.GetValueAsDouble()
        Dim TrigAnswer As Double
        Select Case TrigFunction
            Case "Radian"
                TrigAnswer = (Exp(xVal) + Exp(-xVal)) / (Exp(xVal) - Exp(-xVal))
            Case "Degree"
                TrigAnswer = (Exp((xVal * (PI / 180))) + Exp((-xVal * (PI / 180)))) / (Exp((xVal * (PI / 180))) - Exp((-xVal * (PI / 180))))
            Case "Gradian"
                TrigAnswer = (Exp((xVal * (PI / 200))) + Exp((-xVal * (PI / 200)))) / (Exp((xVal * (PI / 200))) - Exp((-xVal * (PI / 200))))
        End Select
        Return TrigAnswer
    End Function
    Private Function MyASIN(x As IParameter) As Double
        '1 Parameter Function
        Dim xVal As Double = x.GetValueAsDouble()
        Dim TrigAnswer As Double
        Select Case TrigFunction
            Case "Radian"
                TrigAnswer = Math.Asin(xVal)
            Case "Degree"
                TrigAnswer = Math.Asin(xVal) * (180 / Math.PI)
            Case "Gradian"
                TrigAnswer = Math.Asin(xVal) * (200 / Math.PI)
        End Select
        Return TrigAnswer
    End Function
    Private Function MyACOS(x As IParameter) As Double
        '1 Parameter Function
        Dim xVal As Double = x.GetValueAsDouble()
        Dim TrigAnswer As Double
        Select Case TrigFunction
            Case "Radian"
                TrigAnswer = Math.Acos(xVal)
            Case "Degree"
                TrigAnswer = Math.Acos(xVal) * (180 / Math.PI)
            Case "Gradian"
                TrigAnswer = Math.Acos(xVal) * (200 / Math.PI)
        End Select
        Return TrigAnswer
    End Function
    Private Function MyATAN(x As IParameter) As Double
        '1 Parameter Function
        Dim xVal As Double = x.GetValueAsDouble()
        Dim TrigAnswer As Double
        Select Case TrigFunction
            Case "Radian"
                TrigAnswer = Math.Atan(xVal)
            Case "Degree"
                TrigAnswer = Math.Atan(xVal) * (180 / Math.PI)
            Case "Gradian"
                TrigAnswer = Math.Atan(xVal) * (200 / Math.PI)
        End Select
        Return TrigAnswer
    End Function
    Private Function MyASINH(x As IParameter) As Double
        '1 Parameter Function
        'Log(x + Sqrt(x * x + 1))
        Dim xVal As Double = x.GetValueAsDouble()
        Dim TrigAnswer As Double
        Select Case TrigFunction
            Case "Radian"
                TrigAnswer = Log(xVal + Sqrt(xVal * xVal + 1))
            Case "Degree"
                TrigAnswer = Log((xVal * (PI / 180)) + Sqrt((xVal * (PI / 180)) * (xVal * (PI / 180)) + 1))
            Case "Gradian"
                TrigAnswer = Log((xVal * (PI / 200)) + Sqrt((xVal * (PI / 200)) * (xVal * (PI / 200)) + 1))
        End Select
        Return TrigAnswer
    End Function
    Private Function MyACOSH(x As IParameter) As Double
        '1 Parameter Function
        'Log(x + Sqrt(x * x – 1))
        Dim xVal As Double = x.GetValueAsDouble()
        Dim TrigAnswer As Double
        Select Case TrigFunction
            Case "Radian"
                TrigAnswer = Math.Log(xVal + Sqrt(xVal * xVal - 1))
            Case "Degree"
                TrigAnswer = Math.Log((xVal * (PI / 180)) + Sqrt((xVal * (PI / 180)) * (xVal * (PI / 180)) - 1))
            Case "Gradian"
                TrigAnswer = Math.Log((xVal * (PI / 200)) + Sqrt((xVal * (PI / 200)) * (xVal * (PI / 200)) - 1))
        End Select
        Return TrigAnswer
    End Function
    Private Function MyATANH(x As IParameter) As Double
        '1 Parameter Function
        'Log((1 + x) / (1 – x)) / 2
        Dim xVal As Double = x.GetValueAsDouble()
        Dim TrigAnswer As Double
        Select Case TrigFunction
            Case "Radian"
                TrigAnswer = Math.Log((1 + xVal) / (1 - xVal)) / 2
            Case "Degree"
                TrigAnswer = (Math.Log((1 + (xVal * (PI / 180))) / (1 - (xVal * (PI / 180)))) / 2)
            Case "Gradian"
                TrigAnswer = (Math.Log((1 + (xVal * (PI / 200))) / (1 - (xVal * (PI / 200)))) / 2)
        End Select
        Return TrigAnswer
    End Function
    Private Function MyTwoParameter(x As IParameter, y As IParameter) As Double
        '2 Parameter Function Example
        ' myParser.CreateTwoParamFunc("MULT", New TwoParamFunc(AddressOf MyTwoParameter))
        Dim xVal As Double = x.GetValueAsDouble()
        Dim yVal As Double = y.GetValueAsDouble
        Return xVal * yVal
    End Function
    Private Function MyASEC(x As IParameter) As Double
        '1 Parameter Function
        '2 * Atan(1) – Atan(Sign(x) / Sqrt(x * x – 1))
        Dim TrigAnswer As Double
        Dim xVal As Double
        Select Case TrigFunction
            Case "Radian"
                xVal = x.GetValueAsDouble()
                TrigAnswer = 2 * Atan(1) - Atan(Sign(xVal) / Sqrt(xVal * xVal - 1))
            Case "Degree"
                xVal = x.GetValueAsDouble()
                TrigAnswer = (2 * Atan(1) - Atan(Sign(xVal) / Sqrt(xVal * xVal - 1))) * (180 / Math.PI)
            Case "Gradian"
                xVal = x.GetValueAsDouble()
                TrigAnswer = (2 * Atan(1) - Atan(Sign(xVal) / Sqrt(xVal * xVal - 1))) * (200 / Math.PI)
        End Select
        Return TrigAnswer
    End Function
    Private Function MyACSC(x As IParameter) As Double
        '1 Parameter Function
        'Atan(Sign(x) / Sqrt(x * x – 1))
        Dim TrigAnswer As Double
        Dim xVal As Double
        Select Case TrigFunction
            Case "Radian"
                xVal = x.GetValueAsDouble()
                TrigAnswer = Atan(Sign(xVal) / Sqrt(xVal * xVal - 1))
            Case "Degree"
                xVal = x.GetValueAsDouble()
                TrigAnswer = Atan(Sign(xVal) / Sqrt(xVal * xVal - 1)) * (180 / Math.PI)
            Case "Gradian"
                xVal = x.GetValueAsDouble()
                TrigAnswer = Atan(Sign(xVal) / Sqrt(xVal * xVal - 1)) * (200 / Math.PI)
        End Select
        Return TrigAnswer
    End Function
    Private Function MyACOT(x As IParameter) As Double
        '1 Parameter Function
        '2 * Atan(1) - Atan(x)
        Dim TrigAnswer As Double
        Dim xVal As Double
        Select Case TrigFunction
            Case "Radian"
                xVal = x.GetValueAsDouble()
                TrigAnswer = 2 * Atan(1) - Atan(xVal)
            Case "Degree"
                xVal = x.GetValueAsDouble()
                TrigAnswer = (2 * Atan(1) - Atan(xVal)) * (180 / Math.PI)
            Case "Gradian"
                xVal = x.GetValueAsDouble()
                TrigAnswer = (2 * Atan(1) - Atan(xVal)) * (200 / Math.PI)
        End Select
        Return TrigAnswer
    End Function
    Private Function GetVarValue(ByVal sender As MathParser, ByVal varName As String) As IConvertible
        'Implement Function To Return Variable Value
        'Example Of Creating A Constant Variables "A,B,C" With A Return Value
        'The Parser Uses UPPERCASE Identifiers.
        'myParser.SetVariable("Z", 0.0, New VariableDelegate(AddressOf GetVarValue))
        'myParser.SetVariable("ZZ", 0.0, New VariableDelegate(AddressOf GetVarValue))
        'myParser.SetVariable("ZZZ", 0.0, New VariableDelegate(AddressOf GetVarValue))
        Select Case varName
            Case "Z"
                GetVarValue = "2.7182818284590452353602874713527"
            Case "ZZ"
                GetVarValue = PI / 180
            Case "ZZZ"
                GetVarValue = PI / 200
            Case Else
                'Should Not Happen But Just In Case
                Throw New InvalidExpressionException(varName + " Is Not A Valid Variable")
        End Select
    End Function
    Class MyAddFunc
        Implements Bestcode.MathParser.IFunction
        Private Function Run(ByVal x() As IParameter) As IConvertible Implements Bestcode.MathParser.IFunction.Run
            Return x(0).GetValueAsDouble() + x(1).GetValueAsDouble()
        End Function
        Private Function GetNumberOfParams() As Integer Implements Bestcode.MathParser.IFunction.GetNumberOfParams
            'Instantiate The Parser
            Return -1
        End Function
    End Class
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = SystemInformation.UserName & "'s Calculator"
        Me.KeyPreview = True
        AnswerReceived = False
        TbDisplay.Text = ""
        BtnXraised.Text = "(x)" & Strings.ChrW(&H2B8)
        BtnDivide.Text = Strings.Chr(247)
        BtnMultiply.Text = Strings.Chr(215)
        BtnSubtract.Text = Strings.Chr(150)
        BtnAdd.Text = Strings.Chr(43)
        BtnEqual.Text = Strings.Chr(61)
        BtnOpenParentheses.Text = "(" & Strings.ChrW(&H2070)
        BtnNegPos.Text = Strings.Chr(177)
        BtnPoint.Text = Strings.ChrW(&H2E)
        BtnPi.Text = Strings.ChrW(960)
        BtnSqrt.Text = Strings.Chr(178) & ChrW(&H221A)
        BtnCubeRt.Text = Strings.Chr(179) & ChrW(&H221A)
        BtnFourthRt.Text = Strings.ChrW(&H2E3) & ChrW(&H221A)
        Btn2Raised.Text = "(2)" & Strings.ChrW(&H2E3)
        BtnXcubed.Text = "(x)" & Strings.Chr(179)
        BtnXsquared.Text = "(x)" & Strings.Chr(178)
        BtnFtoC.Text = Strings.Chr(176) & "F" & Strings.ChrW(&H2794) & Strings.Chr(176) & "C"
        BtnCtoF.Text = Strings.Chr(176) & "C" & Strings.ChrW(&H2794) & Strings.Chr(176) & "F"
        Btnex.Text = "(e)" & Strings.ChrW(&H2E3)
        Btn10x.Text = "(" & Strings.Chr(49) & Strings.Chr(48) & ")" & Strings.ChrW(&H2E3)
        BtnHypKey.Enabled = True
        BtnHypKey.BackColor = Color.WhiteSmoke
        hypKey = False
        ArcKey = False
        ReadyForValue = False
        NegPos = "Pos"
        Dim i As Integer
        For i = 0 To UBound(BracketsOpen) - 1
            BracketsOpen(i) = False
        Next
        BtnDecimal.PerformClick()
        Base = "Decimal"
        BtnDegree.PerformClick()
        TrigFunction = "Degree"
    End Sub
    Private Function BinaryToDecimal(NumToConvert As String) As String
        Dim I As Int64 = Convert.ToInt64(NumToConvert, 2)
        Dim S2 As String = CStr(I)
        Return S2
    End Function
    Private Function GetNextVariableName(ByRef SegmentIndex) As String
        'Used To Build Parse Formula With Variable Names
        'If New Variable Then Give New Name Between A To W
        'A To W = 65 - 87
        'Alphabetically Assign Variable Names To Value Array And SetVariables With Parser
        Dim I As Int16 = SegmentIndex + 64
        If I > 87 Then Exit Function
        Dim ChrLetter As Char = Convert.ToChar(I)
        Return CStr(ChrLetter)
#Disable Warning BC42105 ' Function doesn't return a value on all code paths
    End Function
#Enable Warning BC42105 ' Function doesn't return a value on all code paths
    Private Sub RelabelBtnOpenParentheses()
        If Not DoubleBracket Then 'Only Show Brackets Open For Calculator Display, Formula Brackets May Be Greater
            Select Case BracketsIndex
                Case 0
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&H2070)
                Case 1
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9)
                Case 2
                    BtnOpenParentheses.Text = "(" & ChrW(&HB2)
                Case 3
                    BtnOpenParentheses.Text = "(" & ChrW(&HB3)
                Case 4
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&H2074)
                Case 5
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&H2075)
                Case 6
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&H2076)
                Case 7
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&H2077)
                Case 8
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&H2078)
                Case 9
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&H2079)
                Case 10
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9) & Strings.ChrW(&H2070)
                Case 11
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9) & Strings.ChrW(&HB9)
                Case 12
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9) & ChrW(&HB2)
                Case 13
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9) & ChrW(&HB3)
                Case 14
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9) & Strings.ChrW(&H2074)
                Case 15
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9) & Strings.ChrW(&H2075)
                Case 16
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9) & Strings.ChrW(&H2076)
                Case 17
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9) & Strings.ChrW(&H2077)
                Case 18
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9) & Strings.ChrW(&H2078)
                Case 19
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9) & Strings.ChrW(&H2079)
                Case 20
                    BtnOpenParentheses.Text = "(" & ChrW(&HB2) & Strings.ChrW(&H2070)
                Case 21
                    BtnOpenParentheses.Text = "(" & ChrW(&HB2) & Strings.ChrW(&HB9)
                Case 22
                    BtnOpenParentheses.Text = "(" & ChrW(&HB2) & Strings.ChrW(&HB2)
                Case 23
                    BtnOpenParentheses.Text = "(" & ChrW(&HB2) & Strings.ChrW(&HB3)
                Case 24
                    BtnOpenParentheses.Text = "(" & ChrW(&HB2) & Strings.ChrW(&H2074)
                Case 25
                    BtnOpenParentheses.Text = "(" & ChrW(&HB2) & Strings.ChrW(&H2075)
                Case Else
                    BtnOpenParentheses.Text = "("
            End Select
        Else 'Only Show Brackets Open For Calculator Display, Formula Brackets May Be Greater
            Select Case BracketsIndex
                Case 1
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&H2070)
                Case 2
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9)
                Case 3
                    BtnOpenParentheses.Text = "(" & ChrW(&HB2)
                Case 4
                    BtnOpenParentheses.Text = "(" & ChrW(&HB3)
                Case 5
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&H2074)
                Case 6
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&H2075)
                Case 7
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&H2076)
                Case 8
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&H2077)
                Case 9
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&H2078)
                Case 10
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&H2079)
                Case 11
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9) & Strings.ChrW(&H2070)
                Case 12
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9) & Strings.ChrW(&HB9)
                Case 13
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9) & ChrW(&HB2)
                Case 14
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9) & ChrW(&HB3)
                Case 15
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9) & Strings.ChrW(&H2074)
                Case 16
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9) & Strings.ChrW(&H2075)
                Case 17
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9) & Strings.ChrW(&H2076)
                Case 18
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9) & Strings.ChrW(&H2077)
                Case 19
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9) & Strings.ChrW(&H2078)
                Case 20
                    BtnOpenParentheses.Text = "(" & Strings.ChrW(&HB9) & Strings.ChrW(&H2079)
                Case 21
                    BtnOpenParentheses.Text = "(" & ChrW(&HB2) & Strings.ChrW(&H2070)
                Case 22
                    BtnOpenParentheses.Text = "(" & ChrW(&HB2) & Strings.ChrW(&HB9)
                Case 23
                    BtnOpenParentheses.Text = "(" & ChrW(&HB2) & Strings.ChrW(&HB2)
                Case 24
                    BtnOpenParentheses.Text = "(" & ChrW(&HB2) & Strings.ChrW(&HB3)
                Case 25
                    BtnOpenParentheses.Text = "(" & ChrW(&HB2) & Strings.ChrW(&H2074)
                Case 26
                    BtnOpenParentheses.Text = "(" & ChrW(&HB2) & Strings.ChrW(&H2075)
                Case Else
                    BtnOpenParentheses.Text = "("
            End Select
        End If
    End Sub
    Private Sub BtnPi_Click(sender As Object, e As EventArgs) Handles BtnPi.Click
        If SegmentValue(SegmentIndex) <> Nothing Then Exit Sub
        If ReadyForValue Then ParseBuild &= SegmentName(SegmentIndex)
        ReadyForValue = False
        DisplayBuild &= "3.1415926535897932384626433832795"
        TbDisplay.Text = DisplayBuild
        If SegmentIndex = 0 Then
            SegmentIndex = 1 'Increment Segment Value
            ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            ParseBuild &= SegmentName(SegmentIndex)
        End If
        SegmentValue(SegmentIndex) &= "3.1415926535897932384626433832795"
        LblFormula.Text = "Formula = " & ParseBuild
    End Sub
    Private Sub Btn0_Click(sender As Object, e As EventArgs) Handles Btn0.Click
        If ReadyForValue Then
            ParseBuild &= SegmentName(SegmentIndex)
            ReadyForValue = False
        End If
        DisplayBuild &= "0"
        TbDisplay.Text = DisplayBuild
        'TbDisplay.Text = DisplayBuild
        If SegmentIndex = 0 Then
            SegmentIndex = 1 'Increment Segment Value
            ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            ParseBuild &= SegmentName(SegmentIndex)
        End If
        If Base = "Binary" Then BinarySegmentValue(SegmentIndex) &= "0"
        SegmentValue(SegmentIndex) &= "0"
        LblFormula.Text = "Formula = " & ParseBuild
        NegPos = "Pos"
    End Sub
    Private Sub Btn1_Click(sender As Object, e As EventArgs) Handles Btn1.Click
        If ReadyForValue Then
            ParseBuild &= SegmentName(SegmentIndex)
            ReadyForValue = False
        End If
        DisplayBuild &= "1"
        TbDisplay.Text = DisplayBuild
        If SegmentIndex = 0 Then
            SegmentIndex = 1 'Increment Segment Value
            ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            ParseBuild &= SegmentName(SegmentIndex)
        End If
        If Base = "Binary" Then BinarySegmentValue(SegmentIndex) &= "1"
        SegmentValue(SegmentIndex) &= "1"
        LblFormula.Text = "Formula = " & ParseBuild
        NegPos = "Pos"
    End Sub
    Private Sub Btn2_Click(sender As Object, e As EventArgs) Handles Btn2.Click
        If ReadyForValue Then
            ParseBuild &= SegmentName(SegmentIndex)
            ReadyForValue = False
        End If
        DisplayBuild &= "2"
        TbDisplay.Text = DisplayBuild
        If SegmentIndex = 0 Then
            SegmentIndex = 1 'Increment Segment Value
            ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            ParseBuild &= SegmentName(SegmentIndex)
        End If
        SegmentValue(SegmentIndex) &= "2"
        LblFormula.Text = "Formula = " & ParseBuild
        NegPos = "Pos"
    End Sub
    Private Sub Btn3_Click(sender As Object, e As EventArgs) Handles Btn3.Click
        If ReadyForValue Then
            ParseBuild &= SegmentName(SegmentIndex)
            ReadyForValue = False
        End If
        DisplayBuild &= "3"
        TbDisplay.Text = DisplayBuild
        If SegmentIndex = 0 Then
            SegmentIndex = 1 'Increment Segment Value
            ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            ParseBuild &= SegmentName(SegmentIndex)
        End If
        SegmentValue(SegmentIndex) &= "3"
        LblFormula.Text = "Formula = " & ParseBuild
        NegPos = "Pos"
    End Sub
    Private Sub Btn4_Click(sender As Object, e As EventArgs) Handles Btn4.Click
        If ReadyForValue Then
            ParseBuild &= SegmentName(SegmentIndex)
            ReadyForValue = False
        End If
        DisplayBuild &= "4"
        TbDisplay.Text = DisplayBuild
        If SegmentIndex = 0 Then
            SegmentIndex = 1 'Increment Segment Value
            ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            ParseBuild &= SegmentName(SegmentIndex)
        End If
        SegmentValue(SegmentIndex) &= "4"
        LblFormula.Text = "Formula = " & ParseBuild
        NegPos = "Pos"
    End Sub
    Private Sub Btn5_Click(sender As Object, e As EventArgs) Handles Btn5.Click
        If ReadyForValue Then
            ParseBuild &= SegmentName(SegmentIndex)
            ReadyForValue = False
        End If
        DisplayBuild &= "5"
        TbDisplay.Text = DisplayBuild
        If SegmentIndex = 0 Then
            SegmentIndex = 1 'Increment Segment Value
            ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            ParseBuild &= SegmentName(SegmentIndex)
        End If
        SegmentValue(SegmentIndex) &= "5"
        LblFormula.Text = "Formula = " & ParseBuild
        NegPos = "Pos"
    End Sub
    Private Sub Btn6_Click(sender As Object, e As EventArgs) Handles Btn6.Click
        If ReadyForValue Then
            ParseBuild &= SegmentName(SegmentIndex)
            ReadyForValue = False
        End If
        DisplayBuild &= "6"
        TbDisplay.Text = DisplayBuild
        If SegmentIndex = 0 Then
            SegmentIndex = 1 'Increment Segment Value
            ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            ParseBuild &= SegmentName(SegmentIndex)
        End If
        SegmentValue(SegmentIndex) &= "6"
        LblFormula.Text = "Formula = " & ParseBuild
        NegPos = "Pos"
    End Sub
    Private Sub Btn7_Click(sender As Object, e As EventArgs) Handles Btn7.Click
        If ReadyForValue Then
            ParseBuild &= SegmentName(SegmentIndex)
            ReadyForValue = False
        End If
        DisplayBuild &= "7"
        TbDisplay.Text = DisplayBuild
        If SegmentIndex = 0 Then
            SegmentIndex = 1 'Increment Segment Value
            ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            ParseBuild &= SegmentName(SegmentIndex)
        End If
        SegmentValue(SegmentIndex) &= "7"
        LblFormula.Text = "Formula = " & ParseBuild
        NegPos = "Pos"
    End Sub
    Private Sub Btn8_Click(sender As Object, e As EventArgs) Handles Btn8.Click
        If ReadyForValue Then
            ParseBuild &= SegmentName(SegmentIndex)
            ReadyForValue = False
        End If
        DisplayBuild &= "8"
        TbDisplay.Text = DisplayBuild
        If SegmentIndex = 0 Then
            SegmentIndex = 1 'Increment Segment Value
            ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            ParseBuild &= SegmentName(SegmentIndex)
        End If
        SegmentValue(SegmentIndex) &= "8"
        LblFormula.Text = "Formula = " & ParseBuild
        NegPos = "Pos"
    End Sub
    Private Sub Btn9_Click(sender As Object, e As EventArgs) Handles Btn9.Click
        If ReadyForValue Then
            ParseBuild &= SegmentName(SegmentIndex)
            ReadyForValue = False
        End If
        DisplayBuild &= "9"
        TbDisplay.Text = DisplayBuild
        If SegmentIndex = 0 Then
            SegmentIndex = 1 'Increment Segment Value
            ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            ParseBuild &= SegmentName(SegmentIndex)
        End If
        SegmentValue(SegmentIndex) &= "9"
        LblFormula.Text = "Formula = " & ParseBuild
        NegPos = "Pos"
    End Sub
    Private Sub ReadyNextValue()
        If TbDisplay.Text = Nothing Then Exit Sub
        Try
            If AnswerReceived Then
                'If Answer Received Then Redim So Answer = SegmentName A 
                'Set SegmentIndex To 1, Ready A To Continue Calculations
                SegmentIndex = 1 'Increment Segment Value
                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
                Select Case Base
                    Case "Decimal"
                        SegmentValue(SegmentIndex) = DecimalAnswer
                        DisplayBuild = DecimalAnswer
                    Case "Binary"
                        SegmentValue(SegmentIndex) = BinaryAnswer
                        DisplayBuild = BinaryAnswer
                    Case "Hex"
                        SegmentValue(SegmentIndex) = HexAnswer
                        DisplayBuild = HexAnswer
                    Case "Octal"
                        SegmentValue(SegmentIndex) = OctalAnswer
                        DisplayBuild = OctalAnswer
                End Select
                ParseBuild = SegmentName(SegmentIndex)
                LblFormula.Text = "Formula = " & ParseBuild
                AnswerReceived = False
            Else
            End If
            'Only Allow 1 Math Function
            If DisplayBuild <> "" And DisplayBuild.Length > 1 Then
                Dim LenStr As Integer = DisplayBuild.Length
                If Mid(DisplayBuild, LenStr - 1) = "+ " Then Exit Sub
                If Mid(DisplayBuild, LenStr - 1) = "- " Then Exit Sub
                If Mid(DisplayBuild, LenStr - 1) = "* " Then Exit Sub
                If Mid(DisplayBuild, LenStr - 1) = "/ " Then Exit Sub
            End If
        Catch exception As Exception
            MsgBox(exception.Message)
        End Try

    End Sub
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If SegmentValue(SegmentIndex) = Nothing Then Exit Sub
        ReadyNextValue()
        DisplayBuild &= " + "
        TbDisplay.Text = DisplayBuild
        ParseBuild &= "+"
        SegmentIndex += 1 'Increment Segment Value
        ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
        SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
        ReadyForValue = True
        LblFormula.Text = "Formula = " & ParseBuild
        NegPos = "Pos"
    End Sub
    Private Sub BtnSubtract_Click(sender As Object, e As EventArgs) Handles BtnSubtract.Click
        If SegmentValue(SegmentIndex) = Nothing Then Exit Sub
        ReadyNextValue()
        DisplayBuild &= " - "
        TbDisplay.Text = DisplayBuild
        ParseBuild &= "-"
        SegmentIndex += 1 'Increment Segment Value
        ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
        SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
        ReadyForValue = True
        LblFormula.Text = "Formula = " & ParseBuild
        NegPos = "Pos"
    End Sub
    Private Sub BtnMultiply_Click(sender As Object, e As EventArgs) Handles BtnMultiply.Click
        If SegmentValue(SegmentIndex) = Nothing Then Exit Sub
        ReadyNextValue()
        DisplayBuild &= " * "
        TbDisplay.Text = DisplayBuild
        ParseBuild &= "*"
        SegmentIndex += 1 'Increment Segment Value
        ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
        SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
        ReadyForValue = True
        LblFormula.Text = "Formula = " & ParseBuild
        NegPos = "Pos"
    End Sub
    Private Sub BtnDivide_Click(sender As Object, e As EventArgs) Handles BtnDivide.Click
        If SegmentValue(SegmentIndex) = Nothing Then Exit Sub
        ReadyNextValue()
        DisplayBuild &= " / "
        TbDisplay.Text = DisplayBuild
        ParseBuild &= "/"
        SegmentIndex += 1 'Increment Segment Value
        ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
        SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
        ReadyForValue = True
        LblFormula.Text = "Formula = " & ParseBuild
        NegPos = "Pos"
    End Sub
    Private Sub BtnEqual_Click(sender As Object, e As EventArgs) Handles BtnEqual.Click
        If TbDisplay.Text = "" Or AnswerReceived Then Exit Sub
        ReadyForValue = False
        'Math Function Open, Not Ready For Answer
        TbDisplay.Text = DisplayBuild
        If DisplayBuild <> "" And DisplayBuild.Length > 1 Then
            Dim LenStr As Integer = DisplayBuild.Length
            If Mid(DisplayBuild, LenStr - 1) = "+ " Then Exit Sub
            If Mid(DisplayBuild, LenStr - 1) = "- " Then Exit Sub
            If Mid(DisplayBuild, LenStr - 1) = "* " Then Exit Sub
            If Mid(DisplayBuild, LenStr - 1) = "/ " Then Exit Sub
        End If
        'If Braxkets Are Open Then Close Brackets
        If BracketsIndex > 0 Then 'Open Parentheses
            Dim i As Integer
            For i = 0 To UBound(BracketsOpen) - 1
                BracketsOpen(i) = False
                ParseBuild &= ")"
                DisplayBuild &= ")"
            Next
            BracketsIndex = 0
            RelabelBtnOpenParentheses()
            LblFormula.Text = "Formula = " & ParseBuild
        End If
        Try
            'Convert All Values To Decimal Values With No Formatting Or Padding For Parsing.
            'After Parsing, Convert Answer Back To Selected Base With Formatting And Padding For Display.
            Select Case Base
                Case "Decimal"
                    DecimalAnswer = FormulaParse(ParseBuild, SegmentValue, ParseValueX, ParseValueY)
                    DecimalAnswer = ConvertFromBaseToBase(DecimalAnswer, 10, 10, True, False) 'Format Answer
                    DisplayBuild &= " = " & DecimalAnswer
                    AnswerReceived = True
                    Answer = DecimalAnswer
                Case "Binary"
                    For i As Integer = 1 To SegmentIndex
                        SegmentValue(i) = ConvertFromBaseToBase(SegmentValue(i), 2, 10, False, False)
                    Next
                    DecimalAnswer = FormulaParse(ParseBuild, SegmentValue, ParseValueX, ParseValueY)
                    BinaryAnswer = ConvertFromBaseToBase(DecimalAnswer, 10, 2, True, True)
                    DisplayBuild &= " = " & BinaryAnswer
                    AnswerReceived = True
                    Answer = BinaryAnswer
                Case "Octal"
                    For i As Integer = 1 To SegmentIndex
                        SegmentValue(i) = ConvertFromBaseToBase(SegmentValue(i), 8, 10, False, False)
                    Next
                    DecimalAnswer = FormulaParse(ParseBuild, SegmentValue, ParseValueX, ParseValueY)
                    OctalAnswer = ConvertFromBaseToBase(DecimalAnswer, 10, 8, True, True)
                    DisplayBuild &= " = " & OctalAnswer
                    AnswerReceived = True
                    Answer = OctalAnswer
                Case "Hex"
                    For i As Integer = 1 To SegmentIndex
                        SegmentValue(i) = ConvertFromBaseToBase(SegmentValue(i), 16, 10, False, False)
                    Next
                    DecimalAnswer = FormulaParse(ParseBuild, SegmentValue, ParseValueX, ParseValueY)
                    HexAnswer = ConvertFromBaseToBase(DecimalAnswer, 10, 16, True, True)
                    DisplayBuild &= " = " & HexAnswer
                    AnswerReceived = True
                    Answer = HexAnswer
            End Select
            LblFormula.Text = "Formula = " & ParseBuild
            TbDisplay.Text = DisplayBuild
            AnswerReceived = True
            ReDim BracketsOpen(0)
        Catch exception As Exception
            MsgBox(exception.Message)
        End Try
        NegPos = "Pos"
    End Sub
    Private Sub BtnClearAll_Click(sender As Object, e As EventArgs) Handles BtnClearAll.Click
        ClearAll()
    End Sub
    Private Sub ClearAll()
        TbDisplay.Text = Nothing
        DisplayBuild = Nothing
        ParseBuild = Nothing
        AnswerExisted = False
        LblFormula.Text = Nothing
        Answer = Nothing
        AnswerReceived = False
        ReadyForValue = False
        ReDim BracketsOpen(0)
        BracketsIndex = 0
        RelabelBtnOpenParentheses()
        SegmentIndex = 0
        ReDim BinarySegmentValue(0)
        ReDim SegmentName(0)
        ReDim SegmentValue(0)
        ReDim TwoParameters(0)
        LblFormula.Text = "Formula = " & ParseBuild
        NegPos = "Pos"
    End Sub
    Private Sub BtnSine_Click(sender As Object, e As EventArgs) Handles BtnSine.Click
        If SegmentValue(SegmentIndex) <> Nothing Then Exit Sub
        If hypKey = False And ArcKey = False Then
            DisplayBuild &= "Sin"
            ParseBuild &= "SINE"
        ElseIf hypKey = True And ArcKey = False Then
            DisplayBuild &= "Sinh"
            ParseBuild &= "SINEH"
        ElseIf hypKey = False And ArcKey = True Then
            DisplayBuild &= "Sin" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            ParseBuild &= "SINA"
        ElseIf hypKey = True And ArcKey = True Then
            DisplayBuild &= "Sinh" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            ParseBuild &= "SINHA"
        End If
        DisplayBuild &= "("
        ParseBuild &= "("
        BracketsIndex += 1 'Increment Open Parentheses Array Index
        ReDim Preserve BracketsOpen(BracketsIndex) 'Preserve The Incremented Array
        BracketsOpen(BracketsIndex) = True 'Assign Value
        RelabelBtnOpenParentheses()
        ReadyForValue = True
        LblFormula.Text = "Formula = " & ParseBuild
        TbDisplay.Text = DisplayBuild
    End Sub
    Private Sub BtnCosine_Click(sender As Object, e As EventArgs) Handles BtnCosine.Click
        If SegmentValue(SegmentIndex) <> Nothing Then Exit Sub
        If hypKey = False And ArcKey = False Then
            DisplayBuild &= "Cos"
            ParseBuild &= "COSN"
        ElseIf hypKey = True And ArcKey = False Then
            DisplayBuild &= "Cosh"
            ParseBuild &= "COSNH"
        ElseIf hypKey = False And ArcKey = True Then
            DisplayBuild &= "Cos" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            ParseBuild &= "COSA"
        ElseIf hypKey = True And ArcKey = True Then
            DisplayBuild &= "Cosh" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            ParseBuild &= "COSHA"
        End If
        DisplayBuild &= "("
        ParseBuild &= "("
        BracketsIndex += 1 'Increment Open Parentheses Array Index
        ReDim Preserve BracketsOpen(BracketsIndex) 'Preserve The Incremented Array
        BracketsOpen(BracketsIndex) = True 'Assign Value
        RelabelBtnOpenParentheses()
        ReadyForValue = True
        LblFormula.Text = "Formula = " & ParseBuild
        TbDisplay.Text = DisplayBuild
    End Sub
    Private Sub BtnTangent_Click(sender As Object, e As EventArgs) Handles BtnTangent.Click
        If SegmentValue(SegmentIndex) <> Nothing Then Exit Sub
        If hypKey = False And ArcKey = False Then
            DisplayBuild &= "Tan"
            ParseBuild &= "TANG"
        ElseIf hypKey = True And ArcKey = False Then
            DisplayBuild &= "Tanh"
            ParseBuild &= "TANH"
        ElseIf hypKey = False And ArcKey = True Then
            DisplayBuild &= "Tan" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            ParseBuild &= "TANA"
        ElseIf hypKey = True And ArcKey = True Then
            DisplayBuild &= "Tanh" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            ParseBuild &= "TANHA"
        End If
        DisplayBuild &= "("
        ParseBuild &= "("
        BracketsIndex += 1 'Increment Open Parentheses Array Index
        ReDim Preserve BracketsOpen(BracketsIndex) 'Preserve The Incremented Array
        BracketsOpen(BracketsIndex) = True 'Assign Value
        RelabelBtnOpenParentheses()
        ReadyForValue = True
        LblFormula.Text = "Formula = " & ParseBuild
        TbDisplay.Text = DisplayBuild
    End Sub
    Private Sub BtnHypKey_Click(sender As Object, e As EventArgs) Handles BtnHypKey.Click
        Select Case ArcKey
            Case False
                Select Case hypKey
                    Case False
                        BtnHypKey.ForeColor = Color.Black
                        BtnHypKey.BackColor = Color.LimeGreen
                        BtnHypKey.Refresh()
                        BtnSine.Text = "sinh"
                        BtnCosine.Text = "cosh"
                        BtnTangent.Text = "tanh"
                        BtnSec.Text = "sech"
                        BtnCsc.Text = "csch"
                        BtnCot.Text = "coth"
                        hypKey = True
                    Case True
                        BtnHypKey.ForeColor = Color.DarkGreen
                        BtnHypKey.BackColor = Color.WhiteSmoke
                        BtnHypKey.Refresh()
                        BtnSine.Text = "sin"
                        BtnCosine.Text = "cos"
                        BtnTangent.Text = "tan"
                        BtnSec.Text = "sec"
                        BtnCsc.Text = "csc"
                        BtnCot.Text = "cot"
                        hypKey = False
                End Select
            Case True
                Select Case hypKey
                    Case False
                        BtnHypKey.ForeColor = Color.Black
                        BtnHypKey.BackColor = Color.LimeGreen
                        BtnHypKey.Refresh()
                        BtnSine.Text = "Asinh"
                        BtnCosine.Text = "Acosh"
                        BtnTangent.Text = "Atanh"
                        BtnSec.Text = "Asech"
                        BtnCsc.Text = "Acsch"
                        BtnCot.Text = "Acoth"
                        hypKey = True
                    Case True
                        BtnHypKey.ForeColor = Color.DarkGreen
                        BtnHypKey.BackColor = Color.WhiteSmoke
                        BtnHypKey.Refresh()
                        BtnSine.Text = "Asin"
                        BtnCosine.Text = "Acos"
                        BtnTangent.Text = "Atan"
                        BtnSec.Text = "Asec"
                        BtnCsc.Text = "Acsc"
                        BtnCot.Text = "Acot"
                        hypKey = False
                End Select
        End Select
    End Sub
    Private Sub BtnArcKey_Click(sender As Object, e As EventArgs) Handles BtnArcKey.Click
        Select Case hypKey
            Case False
                Select Case ArcKey
                    Case False
                        BtnArcKey.ForeColor = Color.Black
                        BtnArcKey.BackColor = Color.LimeGreen
                        BtnArcKey.Refresh()
                        BtnSine.Text = "Asin"
                        BtnCosine.Text = "Acos"
                        BtnTangent.Text = "Atan"
                        BtnSec.Text = "Asec"
                        BtnCsc.Text = "Acsc"
                        BtnCot.Text = "Acot"
                        ArcKey = True
                    Case True
                        BtnArcKey.ForeColor = Color.DarkGreen
                        BtnArcKey.BackColor = Color.WhiteSmoke
                        BtnArcKey.Refresh()
                        BtnSine.Text = "sin"
                        BtnCosine.Text = "cos"
                        BtnTangent.Text = "tan"
                        BtnSec.Text = "sec"
                        BtnCsc.Text = "csc"
                        BtnCot.Text = "cot"
                        ArcKey = False
                End Select
            Case True
                Select Case ArcKey
                    Case False
                        BtnArcKey.ForeColor = Color.Black
                        BtnArcKey.BackColor = Color.LimeGreen
                        BtnArcKey.Refresh()
                        BtnSine.Text = "Asinh"
                        BtnCosine.Text = "Acosh"
                        BtnTangent.Text = "Atanh"
                        BtnSec.Text = "Asech"
                        BtnCsc.Text = "Acsch"
                        BtnCot.Text = "Acoth"
                        ArcKey = True
                    Case True
                        BtnArcKey.ForeColor = Color.DarkGreen
                        BtnArcKey.BackColor = Color.WhiteSmoke
                        BtnArcKey.Refresh()
                        BtnSine.Text = "sinh"
                        BtnCosine.Text = "cosh"
                        BtnTangent.Text = "tanh"
                        BtnSec.Text = "sech"
                        BtnCsc.Text = "csch"
                        BtnCot.Text = "coth"
                        ArcKey = False
                End Select
        End Select
    End Sub
    Private Sub BtnE_Click(sender As Object, e As EventArgs) Handles BtnE.Click
        If SegmentValue(SegmentIndex) <> Nothing Then Exit Sub
        If ReadyForValue Then ParseBuild &= SegmentName(SegmentIndex)
        ReadyForValue = False
        Dim BaseE As String = "2.7182818284590452353602874713527"
        DisplayBuild &= BaseE
        TbDisplay.Text = DisplayBuild
        If SegmentIndex = 0 Then
            SegmentIndex = 1 'Increment Segment Value
            ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            ParseBuild &= SegmentName(SegmentIndex)
        End If
        SegmentValue(SegmentIndex) &= BaseE
        LblFormula.Text = "Formula = " & ParseBuild
    End Sub
    Private Sub BtnCtoF_Click(sender As Object, e As EventArgs) Handles BtnCtoF.Click
        'CelsiusToFahrenheit = CStr((9 * (Val(DegreesC)) / 5) + 32)
        If Base = "Decimal" Then
            If AnswerReceived Then
                'If Answer Received Then Redim So Answer = SegmentName A 
                'Set SegmentIndex To 1, Ready A To Continue Calculations
                SegmentIndex = 1 'Increment Segment Value
                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
                SegmentValue(SegmentIndex) = Answer
                ParseBuild = SegmentName(SegmentIndex)
                LblFormula.Text = "Formula = " & ParseBuild
                DisplayBuild = Answer
                AnswerReceived = False
            End If
            'ReCreate DisplayBuild
            Dim LenStr As Integer = DisplayBuild.Length - SegmentValue(SegmentIndex).Length
            'Trim DisplayBuild Last Value And Divide Last Value Into 1
            DisplayBuild = Mid(DisplayBuild, 1, LenStr) & SegmentValue(SegmentIndex)
            SegmentValue(SegmentIndex) = CStr((9 * Val(SegmentValue(SegmentIndex)) / 5) + 32)
            If SegmentIndex = 1 Then
                TbDisplay.Text = DisplayBuild & " = " & SegmentValue(SegmentIndex)
                AnswerReceived = True
                Answer = SegmentValue(SegmentIndex)
            End If
        End If
    End Sub
    Private Sub BtnFtoC_Click(sender As Object, e As EventArgs) Handles BtnFtoC.Click
        'FahrenheitToCelsius = CStr((5 * (Val(DegreesF) - 32)) / 9)
        If Base = "Decimal" Then
            If AnswerReceived Then
                'If Answer Received Then Redim So Answer = SegmentName A 
                'Set SegmentIndex To 1, Ready A To Continue Calculations
                SegmentIndex = 1 'Increment Segment Value
                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
                SegmentValue(SegmentIndex) = Answer
                ParseBuild = SegmentName(SegmentIndex)
                LblFormula.Text = "Formula = " & ParseBuild
                DisplayBuild = Answer
                AnswerReceived = False
            End If
            'ReCreate DisplayBuild
            Dim LenStr As Integer = DisplayBuild.Length - SegmentValue(SegmentIndex).Length
            'Trim DisplayBuild Last Value And Divide Last Value Into 1
            DisplayBuild = Mid(DisplayBuild, 1, LenStr) & SegmentValue(SegmentIndex)
            SegmentValue(SegmentIndex) = CStr((5 * Val(SegmentValue(SegmentIndex) - 32)) / 9)
            If SegmentIndex = 1 Then
                TbDisplay.Text = DisplayBuild & " = " & SegmentValue(SegmentIndex)
                AnswerReceived = True
                Answer = SegmentValue(SegmentIndex)
            End If
        End If
    End Sub
    Private Sub BtnOpenParentheses_Click(sender As Object, e As EventArgs) Handles BtnOpenParentheses.Click
        If SegmentValue(SegmentIndex) <> Nothing Then Exit Sub
        Try
            ReadyForValue = True
            If AnswerReceived Then
                ParseBuild = Answer
                LblFormula.Text = "Formula = " & ParseBuild
                DisplayBuild = Answer
                TbDisplay.Text = Nothing
                AnswerReceived = False
                ReDim BracketsOpen(0)
                BracketsIndex = 0
                ReDim SegmentValue(0)
                ReDim SegmentName(0)
                SegmentIndex = 0
            End If
            ParseBuild &= "("
            DisplayBuild += "("
            If ReadyForValue Then
                ParseBuild &= SegmentName(SegmentIndex)
                LblFormula.Text = "Formula = " & ParseBuild
            End If
            LblFormula.Text = "Formula = " & ParseBuild
            ReadyForValue = False
            BracketsIndex += 1 'Increment Open Parentheses Array Index
            ReDim Preserve BracketsOpen(BracketsIndex) 'Preserve The Incremented Array
            BracketsOpen(BracketsIndex) = True 'Assign Value
            RelabelBtnOpenParentheses()
            TbDisplay.Text = DisplayBuild
        Catch Exception As Exception
            MsgBox("FormulaParse:" & Exception.Message)
        End Try
    End Sub
    Private Sub BtnCloseParentheses_Click(sender As Object, e As EventArgs) Handles BtnCloseParentheses.Click
        If BracketsIndex = 0 Then Exit Sub
        Try
            If AnswerReceived Then
                DisplayBuild = ""
                ParseBuild = ""
                TbDisplay.Text = ""
                AnswerReceived = False
                LblFormula.Text = "Formula = " & ParseBuild
            End If
            If DoubleBracket Then
                BracketsIndex -= 2
                DisplayBuild &= ")"
                ParseBuild &= "))"
                DoubleBracket = False
            Else
                BracketsIndex -= 1
                DisplayBuild &= ")"
                ParseBuild &= ")"
            End If
            RelabelBtnOpenParentheses()
            ReDim Preserve BracketsOpen(BracketsIndex)
            LblFormula.Text = "Formula = " & ParseBuild
            TbDisplay.Text = DisplayBuild
        Catch exception As Exception
            MsgBox("FormulaParse:" & exception.Message)
        End Try

    End Sub
    Private Sub BtnNegPos_Click(sender As Object, e As EventArgs) Handles BtnNegPos.Click
        If SegmentValue(SegmentIndex) = Nothing Then Exit Sub
        If AnswerReceived Then
            'If Answer Received Then Redim So Answer = SegmentName A 
            'Set SegmentIndex To 1, Ready A To Continue Calculations
            SegmentIndex = 1 'Increment Segment Value
            ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            SegmentValue(SegmentIndex) = Answer
            ParseBuild = SegmentName(SegmentIndex)
            LblFormula.Text = "Formula = " & ParseBuild
            DisplayBuild = Answer
            'Ready For Positive Value
            If Val(Answer) < 0 Then NegPos = "Neg"
            AnswerReceived = False
        End If
        Dim TempSegmentValue As String = ""
        Dim DisplayLen As Integer = DisplayBuild.Length
        If NegPos = "Pos" Then 'Change Positive Number To Negative
            'Change Positive Number To Negative
            'ReCreate DisplayBuild (Negative)
            If DisplayLen > 2 Then
                If InStr(DisplayLen - 2, DisplayBuild, ")", CompareMethod.Text) Then
                    'Build Last Text Inside Parenthesis
                    For i As Integer = DisplayLen To 1 Step -1
                        Dim NewBuild As String = Mid(DisplayBuild, i)
                        If InStr(1, NewBuild, "(", CompareMethod.Text) Then
                            Dim result As String = New DataTable().Compute(NewBuild, Nothing)
                            TempSegmentValue = "-" & result
                            Dim RemoveStr As String = NewBuild
                            DisplayBuild = Replace(DisplayBuild, RemoveStr, TempSegmentValue)
                            TbDisplay.Text = DisplayBuild
                            Exit For
                        End If
                    Next i
                Else
                    Dim SegmentLength As Integer = SegmentValue(SegmentIndex).Length
                    Dim NewBuild As String = DisplayBuild.Remove(DisplayLen - SegmentLength, SegmentLength)
                    SegmentValue(SegmentIndex) = "-" & SegmentValue(SegmentIndex)
                    DisplayBuild = NewBuild & SegmentValue(SegmentIndex)
                    TbDisplay.Text = DisplayBuild
                End If
            Else
                Dim NewBuild As String = DisplayBuild.Remove(DisplayLen - SegmentValue(SegmentIndex).Length, SegmentValue(SegmentIndex).Length)
                SegmentValue(SegmentIndex) = "-" & SegmentValue(SegmentIndex)
                DisplayBuild = NewBuild & SegmentValue(SegmentIndex)
                TbDisplay.Text = DisplayBuild
            End If
        Else 'Change Negative Number To Positive
            'ReCreate DisplayBuild (Positive)
            If DisplayLen > 2 Then
                If InStr(DisplayLen - 2, DisplayBuild, ")", CompareMethod.Text) Then
                    'Build Last Text Inside Parenthesis
                    For i As Integer = DisplayLen To 1 Step -1
                        Dim NewBuild As String = Mid(DisplayBuild, i)
                        If InStr(1, NewBuild, "(", CompareMethod.Text) Then
                            Dim result As String = New DataTable().Compute(NewBuild, Nothing)
                            TempSegmentValue = Val(result * -1)
                            Dim RemoveStr As String = NewBuild
                            DisplayBuild = Replace(DisplayBuild, RemoveStr, TempSegmentValue)
                            TbDisplay.Text = DisplayBuild
                            Exit For
                        End If
                    Next i
                Else
                    Dim SegmentLength As Integer = SegmentValue(SegmentIndex).Length
                    Dim NewBuild As String = DisplayBuild.Remove(DisplayLen - SegmentLength, SegmentLength)
                    SegmentValue(SegmentIndex) = SegmentValue(SegmentIndex) * -1
                    DisplayBuild = NewBuild & SegmentValue(SegmentIndex)
                    TbDisplay.Text = DisplayBuild
                End If
            Else
                Dim NewBuild As String = DisplayBuild.Remove(DisplayLen - SegmentValue(SegmentIndex).Length, SegmentValue(SegmentIndex).Length)
                SegmentValue(SegmentIndex) = SegmentValue(SegmentIndex) * -1
                DisplayBuild = NewBuild & SegmentValue(SegmentIndex)
                TbDisplay.Text = DisplayBuild
            End If
        End If
        Dim ParseLen As Integer = ParseBuild.Length
        'ReCreate ParseBuild
        If ParseLen > 2 Then
            If InStr(ParseLen - 2, ParseBuild, ")", CompareMethod.Text) Then
                'Build Last Text Inside Parenthesis
                For i As Integer = ParseLen To 1 Step -1
                    Dim NewBuild As String = Mid(ParseBuild, i)
                    If InStr(1, NewBuild, "(", CompareMethod.Text) Then
                        Dim RemoveStr As String = NewBuild
                        ParseBuild = Replace(ParseBuild, RemoveStr, "")
                        Dim LenRemoveStr As Integer = RemoveStr.Length
                        Dim Left As String = RemoveStr.Substring(1, 1)
                        Select Case Left
                            Case "A"
                                SegmentIndex = 1 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "A"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "B"
                                SegmentIndex = 2 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "B"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "C"
                                SegmentIndex = 3 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "C"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "D"
                                SegmentIndex = 4 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "D"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "E"
                                SegmentIndex = 5 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "E"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "F"
                                SegmentIndex = 6 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "F"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "G"
                                SegmentIndex = 7 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "G"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "H"
                                SegmentIndex = 8 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "H"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "I"
                                SegmentIndex = 9 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "I"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "J"
                                SegmentIndex = 10 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "J"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "K"
                                SegmentIndex = 11 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "K"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "L"
                                SegmentIndex = 12 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "L"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "M"
                                SegmentIndex = 13 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "M"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "N"
                                SegmentIndex = 14 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "N"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "O"
                                SegmentIndex = 15 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "O"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "P"
                                SegmentIndex = 16 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "P"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "Q"
                                SegmentIndex = 17 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "Q"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "R"
                                SegmentIndex = 18 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "R"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "S"
                                SegmentIndex = 19 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "S"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "T"
                                SegmentIndex = 20 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "T"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "U"
                                SegmentIndex = 21 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "U"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "V"
                                SegmentIndex = 22 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "V"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                            Case "W"
                                SegmentIndex = 23 'Increment Segment Value
                                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                                SegmentName(SegmentIndex) = "W"
                                SegmentValue(SegmentIndex) = TempSegmentValue
                                ParseBuild &= SegmentName(SegmentIndex)
                        End Select
                        Exit For
                    End If
                Next i
            End If
        End If
        If NegPos = "Pos" Then NegPos = "Neg"
        LblFormula.Text = "Formula = " & ParseBuild
    End Sub
    Private Sub BtnPoint_Click(sender As Object, e As EventArgs) Handles BtnPoint.Click
        Dim LastChar As String = Nothing
        If DisplayBuild <> "" Then
            Dim LenStr As Integer = DisplayBuild.Length
            LastChar = Mid(DisplayBuild, LenStr)
            If LastChar = "." Then Exit Sub
        End If
        'Only Allow Decimal Point After Number
        If IsNumeric(lastchar) Then
            If ReadyForValue Then ParseBuild &= SegmentName(SegmentIndex)
            ReadyForValue = False
            DisplayBuild &= "."
            TbDisplay.Text = DisplayBuild
            If SegmentIndex = 0 Then
                SegmentIndex += 1 'Increment Segment Value
                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                SegmentValue(SegmentIndex) &= "."
                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
                ParseBuild &= SegmentName(SegmentIndex)
                LblFormula.Text = "Formula = " & ParseBuild
            Else
                SegmentValue(SegmentIndex) &= "."
            End If
            LblFormula.Text = "Formula = " & ParseBuild
        End If
    End Sub
    Private Sub BtnSec_Click(sender As Object, e As EventArgs) Handles BtnSec.Click
        If SegmentValue(SegmentIndex) <> Nothing Then Exit Sub
        If hypKey = False And ArcKey = False Then
            DisplayBuild &= "Sec"
            ParseBuild &= "SEC"
        ElseIf hypKey = True And ArcKey = False Then
            DisplayBuild &= "Sech"
            ParseBuild &= "SECH"
        ElseIf hypKey = False And ArcKey = True Then
            DisplayBuild &= "Sec" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            ParseBuild &= "SECA"
        ElseIf hypKey = True And ArcKey = True Then
            DisplayBuild &= "Sech" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            ParseBuild &= "SECHA"
        End If
        DisplayBuild &= "("
        ParseBuild &= "("
        BracketsIndex += 1 'Increment Open Parentheses Array Index
        ReDim Preserve BracketsOpen(BracketsIndex) 'Preserve The Incremented Array
        BracketsOpen(BracketsIndex) = True 'Assign Value
        RelabelBtnOpenParentheses()
        ReadyForValue = True
        LblFormula.Text = "Formula = " & ParseBuild
        TbDisplay.Text = DisplayBuild
    End Sub
    Private Sub BtnCsc_Click(sender As Object, e As EventArgs) Handles BtnCsc.Click
        If SegmentValue(SegmentIndex) <> Nothing Then Exit Sub
        If hypKey = False And ArcKey = False Then
            DisplayBuild &= "Csc"
            ParseBuild &= "CSC"
        ElseIf hypKey = True And ArcKey = False Then
            DisplayBuild &= "Csch"
            ParseBuild &= "CSCH"
        ElseIf hypKey = False And ArcKey = True Then
            DisplayBuild &= "Csc" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            ParseBuild &= "CSCA"
        ElseIf hypKey = True And ArcKey = True Then
            DisplayBuild &= "Csch" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            ParseBuild &= "CSCHA"
        End If
        DisplayBuild &= "("
        ParseBuild &= "("
        BracketsIndex += 1 'Increment Open Parentheses Array Index
        ReDim Preserve BracketsOpen(BracketsIndex) 'Preserve The Incremented Array
        BracketsOpen(BracketsIndex) = True 'Assign Value
        RelabelBtnOpenParentheses()
        ReadyForValue = True
        LblFormula.Text = "Formula = " & ParseBuild
        TbDisplay.Text = DisplayBuild
    End Sub
    Private Sub BtnCot_Click(sender As Object, e As EventArgs) Handles BtnCot.Click
        If SegmentValue(SegmentIndex) <> Nothing Then Exit Sub
        If hypKey = False And ArcKey = False Then
            DisplayBuild &= "Cot"
            ParseBuild &= "COT"
        ElseIf hypKey = True And ArcKey = False Then
            DisplayBuild &= "Coth"
            ParseBuild &= "COTH"
        ElseIf hypKey = False And ArcKey = True Then
            DisplayBuild &= "Cot" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            ParseBuild &= "COTA"
        ElseIf hypKey = True And ArcKey = True Then
            DisplayBuild &= "Coth" & Strings.ChrW(&H207B) & Strings.ChrW(&HB9)
            ParseBuild &= "COTHA"
        End If
        DisplayBuild &= "("
        ParseBuild &= "("
        BracketsIndex += 1 'Increment Open Parentheses Array Index
        ReDim Preserve BracketsOpen(BracketsIndex) 'Preserve The Incremented Array
        BracketsOpen(BracketsIndex) = True 'Assign Value
        RelabelBtnOpenParentheses()
        ReadyForValue = True
        LblFormula.Text = "Formula = " & ParseBuild
        TbDisplay.Text = DisplayBuild
    End Sub
    Private Sub BtnLogc_Click(sender As Object, e As EventArgs) Handles BtnLogc.Click
        If SegmentValue(SegmentIndex) <> Nothing Then Exit Sub
        DisplayBuild &= "Logc"
        ParseBuild &= "LOG"
        DisplayBuild &= "("
        ParseBuild &= "("
        BracketsIndex += 1 'Increment Open Parentheses Array Index
        ReDim Preserve BracketsOpen(BracketsIndex) 'Preserve The Incremented Array
        BracketsOpen(BracketsIndex) = True 'Assign Value
        RelabelBtnOpenParentheses()
        ReadyForValue = True
        LblFormula.Text = "Formula = " & ParseBuild
        TbDisplay.Text = DisplayBuild
    End Sub
    Private Sub BtnDecimal_Click(sender As Object, e As EventArgs) Handles BtnDecimal.Click
        If TbDisplay.Text = Nothing Then
            Base = "Decimal"
            EnableButtons()
            Exit Sub
        End If
        Try
            Select Case Base
                Case "Binary" 'Binary To Decimal
                    If AnswerReceived Then TbDisplay.Text = BinaryAnswer
                    Dim s As String = ConvertFromBaseToBase(TbDisplay.Text, 2, 10, True, False)
                    TbDisplay.Text = s
                    DecimalAnswer = s
                    AnswerReceived = True
                Case "Hex" 'Hex To Decimal
                    If AnswerReceived Then TbDisplay.Text = HexAnswer
                    Dim s As String = ConvertFromBaseToBase(TbDisplay.Text, 16, 10, True, False)
                    TbDisplay.Text = s
                    DecimalAnswer = s
                    AnswerReceived = True
                Case "Octal" 'Octal To Decimal
                    If AnswerReceived Then TbDisplay.Text = OctalAnswer
                    Dim s As String = ConvertFromBaseToBase(TbDisplay.Text, 8, 10, True, False)
                    TbDisplay.Text = s
                    DecimalAnswer = s
                    AnswerReceived = True
            End Select
            Base = "Decimal"
            EnableButtons()
        Catch exception As Exception
            MsgBox(exception.Message)
        End Try
    End Sub
    Private Sub BtnOctal_Click(sender As Object, e As EventArgs) Handles BtnOctal.Click
        If TbDisplay.Text = Nothing Then
            Base = "Octal"
            EnableButtons()
            Exit Sub
        End If
        Try
            Select Case Base
                Case "Decimal" 'Decimal To Octal
                    If AnswerReceived Then TbDisplay.Text = DecimalAnswer
                    Dim s As String = ConvertFromBaseToBase(TbDisplay.Text, 10, 8, True, True)
                    TbDisplay.Text = s
                    OctalAnswer = s
                    AnswerReceived = True
                Case "Hex" 'Hex To Octal
                    If AnswerReceived Then TbDisplay.Text = HexAnswer
                    Dim s As String = ConvertFromBaseToBase(TbDisplay.Text, 16, 8, True, True)
                    TbDisplay.Text = s
                    OctalAnswer = s
                    AnswerReceived = True
                Case "Binary" 'Binary To Octal
                    If AnswerReceived Then TbDisplay.Text = BinaryAnswer
                    Dim s As String = ConvertFromBaseToBase(TbDisplay.Text, 2, 8, True, True)
                    TbDisplay.Text = s
                    OctalAnswer = s
                    AnswerReceived = True
            End Select
            Base = "Octal"
            EnableButtons()
        Catch exception As Exception
            MsgBox(exception.Message)
        End Try
    End Sub
    Private Sub BtnBinary_Click(sender As Object, e As EventArgs) Handles BtnBinary.Click
        If TbDisplay.Text = Nothing Then
            Base = "Binary"
            EnableButtons()
        End If
        Try
            Select Case Base
                Case "Decimal" 'Decimal To Binarys
                    If AnswerReceived Then TbDisplay.Text = DecimalAnswer
                    Dim s As String = ConvertFromBaseToBase(TbDisplay.Text, 10, 2, True, True)
                    BinaryAnswer = s
                    TbDisplay.Text = s
                    AnswerReceived = True
                Case "Hex" 'Hex To Binary
                    If AnswerReceived Then TbDisplay.Text = HexAnswer
                    Dim s As String = ConvertFromBaseToBase(TbDisplay.Text, 16, 2, True, True)
                    TbDisplay.Text = s
                    BinaryAnswer = s
                    AnswerReceived = True
                Case "Octal" 'Octal To Binary
                    If AnswerReceived Then TbDisplay.Text = OctalAnswer
                    Dim s As String = ConvertFromBaseToBase(TbDisplay.Text, 8, 2, True, True)
                    TbDisplay.Text = s
                    BinaryAnswer = s
                    AnswerReceived = True
            End Select
            Base = "Binary"
            EnableButtons()
        Catch Exception As Exception
            MsgBox(Exception.Message)
        End Try
    End Sub
    Private Sub BtnHex_Click(sender As Object, e As EventArgs) Handles BtnHex.Click
        If TbDisplay.Text = Nothing Then
            Base = "Hex"
            EnableButtons()
            Exit Sub
        End If
        Try
            Select Case Base
                Case "Decimal" 'Decimal To Hex
                    If AnswerReceived Then TbDisplay.Text = DecimalAnswer
                    Dim s As String = ConvertFromBaseToBase(TbDisplay.Text, 10, 16, True, True)
                    TbDisplay.Text = s
                    HexAnswer = s
                    AnswerReceived = True
                Case "Binary" 'Binary To Hex
                    If AnswerReceived Then TbDisplay.Text = BinaryAnswer
                    Dim s As String = ConvertFromBaseToBase(TbDisplay.Text, 2, 16, True, True)
                    HexAnswer = s
                    TbDisplay.Text = s
                    AnswerReceived = True
                Case "Octal" 'Octal To Hex
                    If AnswerReceived Then TbDisplay.Text = OctalAnswer
                    Dim s As String = ConvertFromBaseToBase(TbDisplay.Text, 8, 16, True, True)
                    TbDisplay.Text = s
                    HexAnswer = s
                    AnswerReceived = True
            End Select
            Base = "Hex"
            EnableButtons()
        Catch Exception As Exception
            MsgBox(Exception.Message)
        End Try
    End Sub
    Private Sub BtnHexA_Click(sender As Object, e As EventArgs) Handles BtnHexA.Click
        If ReadyForValue Then ParseBuild &= SegmentName(SegmentIndex)
        ReadyForValue = False
        DisplayBuild &= "A"
        TbDisplay.Text = DisplayBuild
        If SegmentIndex = 0 Then
            SegmentIndex = 1 'Increment Segment Value
            ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            ParseBuild = SegmentName(SegmentIndex)
        End If
        SegmentValue(SegmentIndex) &= "A"
        LblFormula.Text = "Formula = " & ParseBuild
    End Sub
    Private Sub BtnHexB_Click(sender As Object, e As EventArgs) Handles BtnHexB.Click
        If ReadyForValue Then ParseBuild &= SegmentName(SegmentIndex)
        ReadyForValue = False
        DisplayBuild &= "B"
        TbDisplay.Text = DisplayBuild
        If SegmentIndex = 0 Then
            SegmentIndex = 1 'Increment Segment Value
            ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            ParseBuild = SegmentName(SegmentIndex)
        End If
        SegmentValue(SegmentIndex) &= "B"
        LblFormula.Text = "Formula = " & ParseBuild
    End Sub
    Private Sub BtnHexC_Click(sender As Object, e As EventArgs) Handles BtnHexC.Click
        If ReadyForValue Then ParseBuild &= SegmentName(SegmentIndex)
        ReadyForValue = False
        DisplayBuild &= "C"
        TbDisplay.Text = DisplayBuild
        If SegmentIndex = 0 Then
            SegmentIndex = 1 'Increment Segment Value
            ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            ParseBuild = SegmentName(SegmentIndex)
        End If
        SegmentValue(SegmentIndex) &= "C"
        LblFormula.Text = "Formula = " & ParseBuild
    End Sub
    Private Sub BtnHexD_Click(sender As Object, e As EventArgs) Handles BtnHexD.Click
        If ReadyForValue Then ParseBuild &= SegmentName(SegmentIndex)
        ReadyForValue = False
        DisplayBuild &= "D"
        TbDisplay.Text = DisplayBuild
        If SegmentIndex = 0 Then
            SegmentIndex = 1 'Increment Segment Value
            ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            ParseBuild = SegmentName(SegmentIndex)
        End If
        SegmentValue(SegmentIndex) &= "D"
        LblFormula.Text = "Formula = " & ParseBuild
    End Sub
    Private Sub BtnHexE_Click(sender As Object, e As EventArgs) Handles BtnHexE.Click
        If ReadyForValue Then ParseBuild &= SegmentName(SegmentIndex)
        ReadyForValue = False
        DisplayBuild &= "E"
        TbDisplay.Text = DisplayBuild
        If SegmentIndex = 0 Then
            SegmentIndex = 1 'Increment Segment Value
            ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            ParseBuild = SegmentName(SegmentIndex)
        End If
        SegmentValue(SegmentIndex) &= "E"
        LblFormula.Text = "Formula = " & ParseBuild
    End Sub
    Private Sub BtnHexF_Click(sender As Object, e As EventArgs) Handles BtnHexF.Click
        If ReadyForValue Then ParseBuild &= SegmentName(SegmentIndex)
        ReadyForValue = False
        DisplayBuild &= "F"
        TbDisplay.Text = DisplayBuild
        If SegmentIndex = 0 Then
            SegmentIndex = 1 'Increment Segment Value
            ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            ParseBuild = SegmentName(SegmentIndex)
        End If
        SegmentValue(SegmentIndex) &= "F"
        LblFormula.Text = "Formula = " & ParseBuild
    End Sub
    Private Sub BtnReciprocal_Click(sender As Object, e As EventArgs) Handles BtnReciprocal.Click
        'ReCreate DisplayBuild
        'Change Last SegmentValue To 1/SegmentValue
        If SegmentValue(SegmentIndex) = Nothing Then Exit Sub
        If Base = "Decimal" Then
            If AnswerReceived Then
                'If Answer Received Then Redim So Answer = SegmentName A 
                'Set SegmentIndex To 1, Ready A To Continue Calculations
                SegmentIndex = 1 'Increment Segment Value
                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
                SegmentValue(SegmentIndex) = DecimalAnswer
                ParseBuild = SegmentName(SegmentIndex)
                LblFormula.Text = "Formula = " & ParseBuild
                DisplayBuild = DecimalAnswer
                AnswerReceived = False
                FunctionAnswer = True
            End If
            'ReCreate DisplayBuild
            'Change DisplayBuild To Squared Value
            Dim LenStr As Integer = DisplayBuild.Length - SegmentValue(SegmentIndex).Length
            DisplayBuild = Mid(DisplayBuild, 1, LenStr) & 1 / CStr(Val(SegmentValue(SegmentIndex)))
            SegmentValue(SegmentIndex) = 1 / CStr(Val(SegmentValue(SegmentIndex)))
            TbDisplay.Text = DisplayBuild
        End If
    End Sub
    Private Sub BtnPercent_Click(sender As Object, e As EventArgs) Handles BtnPercent.Click
        If AnswerReceived Then
            'If Answer Received Then Redim So Answer = SegmentName A 
            'Set SegmentIndex To 1, Ready A To Continue Calculations
            SegmentIndex = 1 'Increment Segment Value
            ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
            ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            SegmentValue(SegmentIndex) = DecimalAnswer
            ParseBuild = SegmentName(SegmentIndex)
            LblFormula.Text = "Formula = " & ParseBuild
            DisplayBuild = DecimalAnswer
            AnswerReceived = False
            FunctionAnswer = True
        End If
        'ReCreate DisplayBuild
        'Change DisplayBuild To Squared Value
        Dim LenStr As Integer = DisplayBuild.Length - SegmentValue(SegmentIndex).Length
        DisplayBuild = Mid(DisplayBuild, 1, LenStr) & CStr(Val(SegmentValue(SegmentIndex) * 0.01))
        SegmentValue(SegmentIndex) = CStr(Val(SegmentValue(SegmentIndex) * 0.01))
        TbDisplay.Text = DisplayBuild
    End Sub
    Private Sub BtnXsquared_Click(sender As Object, e As EventArgs) Handles BtnXsquared.Click
        If SegmentValue(SegmentIndex) = Nothing Then Exit Sub
        Select Case Base
            Case "Decimal"
                If AnswerReceived Then
                    'If Answer Received Then Redim So Answer = SegmentName A 
                    'Set SegmentIndex To 1, Ready A To Continue Calculations
                    SegmentIndex = 1 'Increment Segment Value
                    ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                    SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
                    SegmentValue(SegmentIndex) = DecimalAnswer
                    ParseBuild = SegmentName(SegmentIndex)
                    LblFormula.Text = "Formula = " & ParseBuild
                    DisplayBuild = DecimalAnswer
                    AnswerReceived = False
                    FunctionAnswer = True
                End If
                'ReCreate DisplayBuild With Squared Value
                Dim LenStr As Integer = DisplayBuild.Length - SegmentValue(SegmentIndex).Length
                DisplayBuild = Mid(DisplayBuild, 1, LenStr) & CStr(Val(SegmentValue(SegmentIndex) ^ 2))
                SegmentValue(SegmentIndex) = CStr(Val(SegmentValue(SegmentIndex) ^ 2))
                TbDisplay.Text = DisplayBuild
            Case "Binary"
                If AnswerReceived Then
                    'If Answer Received Then Redim So Answer = SegmentName A 
                    'Set SegmentIndex To 1, Ready A To Continue Calculations
                    SegmentIndex = 1 'Increment Segment Value
                    ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                    SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
                    SegmentValue(SegmentIndex) = BinaryAnswer
                    BinarySegmentValue(SegmentIndex) = BinaryAnswer
                    ParseBuild = SegmentName(SegmentIndex)
                    LblFormula.Text = "Formula = " & ParseBuild
                    DisplayBuild = BinaryAnswer
                    AnswerReceived = False
                    FunctionAnswer = True
                End If
                'ReCreate DisplayBuild With Squared Value
                Dim LenStr As Integer = DisplayBuild.Length - SegmentValue(SegmentIndex).Length
                'Convert To Decimal To Square
                Dim DecValue As String = ConvertFromBaseToBase(SegmentValue(SegmentIndex), 2, 10, False, False)
                'Square Decimal Value
                Dim DVSquared As String = CStr(Val(DecValue ^ 2))
                'Convert Squared Value Back To Binary
                Dim BinaryValue As String = ConvertFromBaseToBase(DVSquared, 10, 2, False, True)
                'Remove Old Segment Value From DisplayBuild And Replace With Squared Value
                'ReCreate DisplayBuild
                DisplayBuild = Mid(DisplayBuild, 1, LenStr) & BinaryValue
                SegmentValue(SegmentIndex) = BinaryValue
                BinarySegmentValue(SegmentIndex) = BinaryValue
                TbDisplay.Text = DisplayBuild
            Case "Hex"
                If AnswerReceived Then
                    'If Answer Received Then Redim So Answer = SegmentName A 
                    'Set SegmentIndex To 1, Ready A To Continue Calculations
                    SegmentIndex = 1 'Increment Segment Value
                    ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                    SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
                    SegmentValue(SegmentIndex) = HexAnswer
                    ParseBuild = SegmentName(SegmentIndex)
                    LblFormula.Text = "Formula = " & ParseBuild
                    DisplayBuild = HexAnswer
                    AnswerReceived = False
                    FunctionAnswer = True
                End If
                'ReCreate DisplayBuild With Squared Value
                Dim LenStr As Integer = DisplayBuild.Length - SegmentValue(SegmentIndex).Length
                'Convert To Decimal To Square
                Dim DecValue As String = ConvertFromBaseToBase(SegmentValue(SegmentIndex), 16, 10, False, False)
                Dim DVSquared As String = CStr(Val(DecValue ^ 2))
                'Convert Decimal Result Back To Hex
                Dim HexValue As String = ConvertFromBaseToBase(DVSquared, 10, 16, False, True)
                'ReCreate DisplayBuild
                DisplayBuild = Mid(DisplayBuild, 1, LenStr) & HexValue
                TbDisplay.Text = DisplayBuild
                SegmentValue(SegmentIndex) = HexValue
            Case "Octal"
                If AnswerReceived And Not FunctionAnswer Then
                    'If Answer Received Then Redim So Answer = SegmentName A 
                    'Set SegmentIndex To 1, Ready A To Continue Calculations
                    SegmentIndex = 1 'Increment Segment Value
                    ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                    SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
                    SegmentValue(SegmentIndex) = OctalAnswer
                    ParseBuild = SegmentName(SegmentIndex)
                    LblFormula.Text = "Formula = " & ParseBuild
                    DisplayBuild = OctalAnswer
                    AnswerReceived = False
                    FunctionAnswer = True
                End If
                'ReCreate DisplayBuild With Squared Value
                Dim LenStr As Integer = DisplayBuild.Length - SegmentValue(SegmentIndex).Length
                'Convert To Decimal To Square
                Dim DecValue As String = ConvertFromBaseToBase(SegmentValue(SegmentIndex), 8, 10, False, False)
                'Square Decimal Result
                Dim DVSquared As String = CStr(Val(DecValue ^ 2))
                'Convert Decimal Result Back To Octal
                Dim OctalValue As String = ConvertFromBaseToBase(DVSquared, 10, 8, False, True)
                'ReCreate DisplayBuild
                DisplayBuild = Mid(DisplayBuild, 1, LenStr) & OctalValue
                TbDisplay.Text = DisplayBuild
                SegmentValue(SegmentIndex) = OctalValue
        End Select
    End Sub
    Private Sub BtnXcubed_Click(sender As Object, e As EventArgs) Handles BtnXcubed.Click
        If SegmentValue(SegmentIndex) = Nothing Then Exit Sub
        Select Case Base
            Case "Decimal"
                If AnswerReceived Then
                    'If Answer Received Then Redim So Answer = SegmentName A 
                    'Set SegmentIndex To 1, Ready A To Continue Calculations
                    SegmentIndex = 1 'Increment Segment Value
                    ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                    SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
                    SegmentValue(SegmentIndex) = DecimalAnswer
                    ParseBuild = SegmentName(SegmentIndex)
                    LblFormula.Text = "Formula = " & ParseBuild
                    DisplayBuild = DecimalAnswer
                    AnswerReceived = False
                    FunctionAnswer = True
                End If
                'ReCreate DisplayBuild With Squared Value
                Dim LenStr As Integer = DisplayBuild.Length - SegmentValue(SegmentIndex).Length
                DisplayBuild = Mid(DisplayBuild, 1, LenStr) & CStr(Val(SegmentValue(SegmentIndex) ^ 3))
                SegmentValue(SegmentIndex) = CStr(Val(SegmentValue(SegmentIndex) ^ 3))
                TbDisplay.Text = DisplayBuild
            Case "Binary"
                If AnswerReceived Then
                    'If Answer Received Then Redim So Answer = SegmentName A 
                    'Set SegmentIndex To 1, Ready A To Continue Calculations
                    SegmentIndex = 1 'Increment Segment Value
                    ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                    SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
                    SegmentValue(SegmentIndex) = BinaryAnswer
                    BinarySegmentValue(SegmentIndex) = BinaryAnswer
                    ParseBuild = SegmentName(SegmentIndex)
                    LblFormula.Text = "Formula = " & ParseBuild
                    DisplayBuild = BinaryAnswer
                    AnswerReceived = False
                    FunctionAnswer = True
                End If
                'ReCreate DisplayBuild With Squared Value
                Dim LenStr As Integer = DisplayBuild.Length - SegmentValue(SegmentIndex).Length
                'Convert To Decimal To Square
                Dim DecValue As String = ConvertFromBaseToBase(SegmentValue(SegmentIndex), 2, 10, False, False)
                'Square Decimal Value
                Dim DVSquared As String = CStr(Val(DecValue ^ 3))
                'Convert Squared Value Back To Binary
                Dim BinaryValue As String = ConvertFromBaseToBase(DVSquared, 10, 2, False, True)
                'Remove Old Segment Value From DisplayBuild And Replace With Squared Value
                'ReCreate DisplayBuild
                DisplayBuild = Mid(DisplayBuild, 1, LenStr) & BinaryValue
                SegmentValue(SegmentIndex) = BinaryValue
                BinarySegmentValue(SegmentIndex) = BinaryValue
                TbDisplay.Text = DisplayBuild
            Case "Hex"
                If AnswerReceived Then
                    'If Answer Received Then Redim So Answer = SegmentName A 
                    'Set SegmentIndex To 1, Ready A To Continue Calculations
                    SegmentIndex = 1 'Increment Segment Value
                    ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                    SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
                    SegmentValue(SegmentIndex) = HexAnswer
                    ParseBuild = SegmentName(SegmentIndex)
                    LblFormula.Text = "Formula = " & ParseBuild
                    DisplayBuild = HexAnswer
                    AnswerReceived = False
                    FunctionAnswer = True
                End If
                'ReCreate DisplayBuild With Squared Value
                Dim LenStr As Integer = DisplayBuild.Length - SegmentValue(SegmentIndex).Length
                'Convert To Decimal To Square
                Dim DecValue As String = ConvertFromBaseToBase(SegmentValue(SegmentIndex), 16, 10, False, False)
                Dim DVSquared As String = CStr(Val(DecValue ^ 3))
                'Convert Decimal Result Back To Hex
                Dim HexValue As String = ConvertFromBaseToBase(DVSquared, 10, 16, False, True)
                'ReCreate DisplayBuild
                DisplayBuild = Mid(DisplayBuild, 1, LenStr) & HexValue
                TbDisplay.Text = DisplayBuild
                SegmentValue(SegmentIndex) = HexValue
            Case "Octal"
                If AnswerReceived And Not FunctionAnswer Then
                    'If Answer Received Then Redim So Answer = SegmentName A 
                    'Set SegmentIndex To 1, Ready A To Continue Calculations
                    SegmentIndex = 1 'Increment Segment Value
                    ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                    ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                    SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
                    SegmentValue(SegmentIndex) = OctalAnswer
                    ParseBuild = SegmentName(SegmentIndex)
                    LblFormula.Text = "Formula = " & ParseBuild
                    DisplayBuild = OctalAnswer
                    AnswerReceived = False
                    FunctionAnswer = True
                End If
                'ReCreate DisplayBuild With Squared Value
                Dim LenStr As Integer = DisplayBuild.Length - SegmentValue(SegmentIndex).Length
                'Convert To Decimal To Square
                Dim DecValue As String = ConvertFromBaseToBase(SegmentValue(SegmentIndex), 8, 10, False, False)
                'Square Decimal Result
                Dim DVSquared As String = CStr(Val(DecValue ^ 3))
                'Convert Decimal Result Back To Octal
                Dim OctalValue As String = ConvertFromBaseToBase(DVSquared, 10, 8, False, True)
                'ReCreate DisplayBuild
                DisplayBuild = Mid(DisplayBuild, 1, LenStr) & OctalValue
                TbDisplay.Text = DisplayBuild
                SegmentValue(SegmentIndex) = OctalValue
        End Select
    End Sub
    Private Sub BtnXraised_Click(sender As Object, e As EventArgs) Handles BtnXraised.Click
        If SegmentValue(SegmentIndex) = Nothing Then Exit Sub
        'Rearange DisplayBuild So SegmentName ONLY Appears Inside Brackets
        DisplayBuild = ReplaceEndSubstring(DisplayBuild, SegmentValue(SegmentIndex), "Pwr(" & SegmentValue(SegmentIndex) & ", ")
        'Rearange ParseBuild So SegmentName ONLY Appears Inside Brackets
        ParseBuild = ReplaceEndSubstring(ParseBuild, SegmentName(SegmentIndex), "YPWR(" & SegmentName(SegmentIndex) & ",")
        'Turn On Or Off Commas During Build Or CE
        'If Segment With 2 Parameters Is Deleted Then Turn Off
        'If Is Not Segment Then Turn Off
        'Only Turn On For Focused Segment Containing 2 Parameters 
        ReDim Preserve TwoParameters(SegmentIndex)
        TwoParameters(SegmentIndex) = True
        ReadyForValue = True
        LblFormula.Text = "Formula = " & ParseBuild
        TbDisplay.Text = DisplayBuild
        BracketsIndex += 1 'Increment Open Parentheses Array Index
        ReDim Preserve BracketsOpen(BracketsIndex) 'Preserve The Incremented Array
        BracketsOpen(BracketsIndex) = True 'Assign Value
        RelabelBtnOpenParentheses()
        SegmentIndex += 1 'Increment Segment Value
        ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve TwoParameters(SegmentIndex)
        TwoParameters(SegmentIndex) = False
        SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
    End Sub
    Private Sub BtnExp_Click(sender As Object, e As EventArgs) Handles BtnExp.Click
        If Base = "Decimal" Then
            If SegmentIndex = 0 Then
                If TbDisplay.Text <> Nothing Then
                    DisplayBuild = Format(TbDisplay.Text, "Scientific")
                    TbDisplay.Text = DisplayBuild
                End If
            Else
                'ReCreate DisplayBuild
                If SegmentValue(SegmentIndex) = Nothing Then
                    If SegmentValueTemp <> Nothing Then
                        SegmentValue(SegmentIndex) = SegmentValueTemp
                    Else
                        Exit Sub
                    End If
                End If
                'ReCreate DisplayBuild
                Dim LenStr As Integer = DisplayBuild.Length - SegmentValue(SegmentIndex).Length
                'Trim DisplayBuild Last Value And Change To Scientific Notation
                Dim S As String = Format(SegmentValue(SegmentIndex), "Scientific")
                DisplayBuild = Mid(DisplayBuild, 1, LenStr) & S
                TbDisplay.Text = DisplayBuild
            End If
        End If
    End Sub
    Private Sub BtnSqrt_Click(sender As Object, e As EventArgs) Handles BtnSqrt.Click
        ' Calculate the root.
        If SegmentValue(SegmentIndex) <> Nothing Then Exit Sub
        DisplayBuild &= Strings.Chr(178) & ChrW(&H221A)
        ParseBuild &= "SQRT"
        DisplayBuild &= "("
        ParseBuild &= "("
        BracketsIndex += 1 'Increment Open Parentheses Array Index
        ReDim Preserve BracketsOpen(BracketsIndex) 'Preserve The Incremented Array
        BracketsOpen(BracketsIndex) = True 'Assign Value
        RelabelBtnOpenParentheses()
        ReadyForValue = True
        LblFormula.Text = "Formula = " & ParseBuild
        TbDisplay.Text = DisplayBuild
    End Sub
    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        Dim FontDlg As New FontDialog
        FontDlg.Font = TbDisplay.Font
        If FontDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            If TbDisplay.SelectedText.Trim = "" Then
                TbDisplay.Font = FontDlg.Font
            Else
                TbDisplay.Font = FontDlg.Font
            End If
        End If
    End Sub
    Private Sub BackColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackColorToolStripMenuItem.Click
        Dim BackColorDlg As New ColorDialog
        BackColorDlg.Color = TbDisplay.BackColor
        If BackColorDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            If TbDisplay.SelectedText.Trim = "" Then
                TbDisplay.BackColor = BackColorDlg.Color
            Else
                TbDisplay.BackColor = BackColorDlg.Color
            End If
        End If
    End Sub
    Private Sub ForeColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForeColorToolStripMenuItem.Click
        Dim ForeColorDlg As New ColorDialog
        ForeColorDlg.Color = TbDisplay.ForeColor
        If ForeColorDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            If TbDisplay.SelectedText.Trim = "" Then
                TbDisplay.ForeColor = ForeColorDlg.Color
            Else
                TbDisplay.ForeColor = ForeColorDlg.Color
            End If
        End If
    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show("Created By Ross Waters (RossWatersjr@gmail.com)" & vbCrLf & "Created In VB Using Visual Studio 2019 Version 16.11.1" & vbCrLf & ".NET Framework 4.8.04" & vbCrLf & "Last Revision Date 08/19,2021" & vbCrLf & "Revision 2.0.1", "About", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub RatiosAndPorportionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RatiosAndPorportionsToolStripMenuItem.Click
        FrmRatio.Show()
        Me.Hide()
    End Sub

    Private Sub CloseApplicationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseApplicationToolStripMenuItem.Click
        FrmRatio.Close()
        Me.Close()
        Application.Exit()
    End Sub
    Private Sub FrmCalculator_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        FrmRatio.Close()
        Application.Exit()
    End Sub
    Private Sub BtnCE_Click(sender As Object, e As EventArgs) Handles BtnCE.Click
        Dim TempAnswer As String = ""
        If AnswerReceived And DisplayBuild <> Nothing Then
            'Delete Answer From String
            Select Case Base
                Case "Decimal"
                    TempAnswer = " = " & DecimalAnswer
                Case "Binary"
                    TempAnswer = " = " & BinaryAnswer
                Case "Octal"
                    TempAnswer = " = " & OctalAnswer
                Case "Hex"
                    TempAnswer = " = " & HexAnswer
            End Select
            Dim LenStr As Integer = DisplayBuild.Length - TempAnswer.Length
            DisplayBuild = Mid(DisplayBuild, 1, LenStr)
            TbDisplay.Text = DisplayBuild
            AnswerReceived = False
            AnswerExisted = True
            Exit Sub
        End If
        'If Answer Was Squared Or Cubed Or etc... Then Make Segment 1 This Value
        'So Deletion Of This Value Is Possible.
        If FunctionAnswer And Not AnswerReceived Then
            DisplayBuild = TbDisplay.Text
            If SegmentIndex = 1 Then SegmentValue(SegmentIndex) = TbDisplay.Text
            FunctionAnswer = False
        End If
        ParseBuild = EndTrim(ParseBuild)
        LblFormula.Text = "Formula = " & ParseBuild
        DisplayBuild = EndTrim(DisplayBuild)
        TbDisplay.Text = DisplayBuild
        If TbDisplay.Text = Nothing Then
            ClearAll()
            Exit Sub
        End If
        Dim LastEntry As String = ExamineLastEntry(DisplayBuild)
        Select Case LastEntry
            Case "Function"
                DeleteFunctions()
            Case "Operator"
                DeleteOperators()
            Case "Value"
                DeleteValues()
        End Select
        LblFormula.Text = "Formula = " & ParseBuild
        TbDisplay.Text = DisplayBuild
    End Sub
    Private Sub Btnex_Click(sender As Object, e As EventArgs) Handles Btnex.Click
        If SegmentValue(SegmentIndex) <> Nothing Then Exit Sub
        DisplayBuild &= "e^("
        ParseBuild &= "EPWR("
        ReadyForValue = True
        LblFormula.Text = "Formula = " & ParseBuild
        TbDisplay.Text = DisplayBuild
        BracketsIndex += 1 'Increment Open Parentheses Array Index
        ReDim Preserve BracketsOpen(BracketsIndex) 'Preserve The Incremented Array
        BracketsOpen(BracketsIndex) = True 'Assign Value
        RelabelBtnOpenParentheses()
    End Sub
    Private Sub Btn2Raised_Click(sender As Object, e As EventArgs) Handles Btn2Raised.Click
        If SegmentValue(SegmentIndex) <> Nothing Then Exit Sub
        DisplayBuild &= "2^("
        ParseBuild &= "TWOPWR("
        ReadyForValue = True
        LblFormula.Text = "Formula = " & ParseBuild
        TbDisplay.Text = DisplayBuild
        BracketsIndex += 1 'Increment Open Parentheses Array Index
        ReDim Preserve BracketsOpen(BracketsIndex) 'Preserve The Incremented Array
        BracketsOpen(BracketsIndex) = True 'Assign Value
        RelabelBtnOpenParentheses()
    End Sub
    Private Sub Btn10x_Click(sender As Object, e As EventArgs) Handles Btn10x.Click
        If SegmentValue(SegmentIndex) <> Nothing Then Exit Sub
        DisplayBuild &= "10^("
        ParseBuild &= "TENPWR("
        ReadyForValue = True
        LblFormula.Text = "Formula = " & ParseBuild
        TbDisplay.Text = DisplayBuild
        BracketsIndex += 1 'Increment Open Parentheses Array Index
        ReDim Preserve BracketsOpen(BracketsIndex) 'Preserve The Incremented Array
        BracketsOpen(BracketsIndex) = True 'Assign Value
        RelabelBtnOpenParentheses()
    End Sub
    Private Sub BtnLoge_Click(sender As Object, e As EventArgs) Handles BtnLoge.Click
        If SegmentValue(SegmentIndex) <> Nothing Then Exit Sub
        DisplayBuild &= "Loge"
        ParseBuild &= "LN"
        DisplayBuild &= "("
        ParseBuild &= "("
        BracketsIndex += 1 'Increment Open Parentheses Array Index
        ReDim Preserve BracketsOpen(BracketsIndex) 'Preserve The Incremented Array
        BracketsOpen(BracketsIndex) = True 'Assign Value
        RelabelBtnOpenParentheses()
        ReadyForValue = True
        LblFormula.Text = "Formula = " & ParseBuild
        TbDisplay.Text = DisplayBuild
    End Sub
    Private Sub BtnFourthRt_Click(sender As Object, e As EventArgs) Handles BtnFourthRt.Click
        If SegmentValue(SegmentIndex) = Nothing Then Exit Sub
        'Rearange DisplayBuild So SegmentName ONLY Appears Inside Brackets
        DisplayBuild = ReplaceEndSubstring(DisplayBuild, SegmentValue(SegmentIndex), Strings.ChrW(&H2E3) & ChrW(&H221A) & "(" & SegmentValue(SegmentIndex) & ", ")
        'Rearange ParseBuild So SegmentName ONLY Appears Inside Brackets
        ParseBuild = ReplaceEndSubstring(ParseBuild, SegmentName(SegmentIndex), "ROTX(" & SegmentName(SegmentIndex) & ",")
        'Turn On Or Off Commas During Build Or CE
        'If Segment With 2 Parameters Is Deleted Then Turn Off
        'If Is Not Segment Then Turn Off
        'Only Turn On For Focused Segment Containing 2 Parameters 
        ReDim Preserve TwoParameters(SegmentIndex)
        TwoParameters(SegmentIndex) = True
        ReadyForValue = True
        LblFormula.Text = "Formula = " & ParseBuild
        TbDisplay.Text = DisplayBuild
        BracketsIndex += 1 'Increment Open Parentheses Array Index
        ReDim Preserve BracketsOpen(BracketsIndex) 'Preserve The Incremented Array
        BracketsOpen(BracketsIndex) = True 'Assign Value
        RelabelBtnOpenParentheses()
        SegmentIndex += 1 'Increment Segment Value
        ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve TwoParameters(SegmentIndex)
        TwoParameters(SegmentIndex) = False
        SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
    End Sub
    Private Sub BtnLogx_Click(sender As Object, e As EventArgs) Handles BtnLogx.Click
        If SegmentValue(SegmentIndex) = Nothing Then Exit Sub
        'Rearange DisplayBuild So SegmentName ONLY Appears Inside Brackets
        DisplayBuild = ReplaceEndSubstring(DisplayBuild, SegmentValue(SegmentIndex), "Logx(" & SegmentValue(SegmentIndex) & ", ")
        'Rearange ParseBuild So SegmentName ONLY Appears Inside Brackets
        ParseBuild = ReplaceEndSubstring(ParseBuild, SegmentName(SegmentIndex), "LOGX(" & SegmentName(SegmentIndex) & ",")
        'Turn On Or Off Commas During Build Or CE
        'If Segment With 2 Parameters Is Deleted Then Turn Off
        'If Is Not Segment Then Turn Off
        'Only Turn On For Focused Segment Containing 2 Parameters 
        ReDim Preserve TwoParameters(SegmentIndex)
        TwoParameters(SegmentIndex) = True
        ReadyForValue = True
        LblFormula.Text = "Formula = " & ParseBuild
        TbDisplay.Text = DisplayBuild
        BracketsIndex += 1 'Increment Open Parentheses Array Index
        ReDim Preserve BracketsOpen(BracketsIndex) 'Preserve The Incremented Array
        BracketsOpen(BracketsIndex) = True 'Assign Value
        RelabelBtnOpenParentheses()
        SegmentIndex += 1 'Increment Segment Value
        ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve TwoParameters(SegmentIndex)
        TwoParameters(SegmentIndex) = False
        SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
    End Sub
    Private Sub BtnMod_Click(sender As Object, e As EventArgs) Handles BtnMod.Click
        'Rearange DisplayBuild So SegmentName ONLY Appears Inside Brackets
        DisplayBuild = ReplaceEndSubstring(DisplayBuild, SegmentValue(SegmentIndex), "Mod(" & SegmentValue(SegmentIndex) & ", ")
        'Rearange ParseBuild So SegmentName ONLY Appears Inside Brackets
        ParseBuild = ReplaceEndSubstring(ParseBuild, SegmentName(SegmentIndex), "MOD(" & SegmentName(SegmentIndex) & ",")
        'Turn On Or Off Commas During Build Or CE
        'If Segment With 2 Parameters Is Deleted Then Turn Off
        'If Is Not Segment Then Turn Off
        'Only Turn On For Focused Segment Containing 2 Parameters 
        ReDim Preserve TwoParameters(SegmentIndex)
        TwoParameters(SegmentIndex) = True
        ReadyForValue = True
        LblFormula.Text = "Formula = " & ParseBuild
        TbDisplay.Text = DisplayBuild
        BracketsIndex += 1 'Increment Open Parentheses Array Index
        ReDim Preserve BracketsOpen(BracketsIndex) 'Preserve The Incremented Array
        BracketsOpen(BracketsIndex) = True 'Assign Value
        RelabelBtnOpenParentheses()
        SegmentIndex += 1 'Increment Segment Value
        ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
        ReDim Preserve TwoParameters(SegmentIndex)
        TwoParameters(SegmentIndex) = False
        SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
    End Sub
    Private Sub BtnComma_Click(sender As Object, e As EventArgs) Handles BtnComma.Click
        'Parse Does Not Like COMMAS Except Inside 2 Parameter Function
        'If Comma Exist Then Don't Allow Second Comma
        If AnswerReceived Then Exit Sub
        If DisplayBuild = Nothing Then Exit Sub
        Dim DisplayLen As Integer = DisplayBuild.Length
        Dim CharStr As String = Mid(DisplayBuild, DisplayLen)
        If InStr(1, CharStr, ",", CompareMethod.Text) Then Exit Sub
        If InStr(1, CharStr, ")", CompareMethod.Text) Then Exit Sub
        If TwoParameters(SegmentIndex) = True Then
            'If First Value Missing Then No Comma Allowed
            If SegmentValue(SegmentIndex) = Nothing Then Exit Sub
            If ReadyForValue Then ParseBuild &= SegmentName(SegmentIndex)
            SegmentIndex += 1
            ReDim Preserve SegmentValue(SegmentIndex)
            ReDim Preserve SegmentName(SegmentIndex)
            ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
            SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            DisplayBuild &= ", "
            ParseBuild &= ","
            TbDisplay.Text = DisplayBuild
            LblFormula.Text = "Formula = " & ParseBuild
            ReadyForValue = True
        End If
    End Sub
    Private Sub BtnCubeRt_Click(sender As Object, e As EventArgs) Handles BtnCubeRt.Click
        If SegmentValue(SegmentIndex) <> Nothing Then Exit Sub
        DisplayBuild &= Strings.Chr(179) & ChrW(&H221A)
        ParseBuild &= "CURT"
        DisplayBuild &= "("
        ParseBuild &= "("
        BracketsIndex += 1 'Increment Open Parentheses Array Index
        ReDim Preserve BracketsOpen(BracketsIndex) 'Preserve The Incremented Array
        BracketsOpen(BracketsIndex) = True 'Assign Value
        RelabelBtnOpenParentheses()
        ReadyForValue = True
        LblFormula.Text = "Formula = " & ParseBuild
        TbDisplay.Text = DisplayBuild
    End Sub
    Private Sub BtnCE_MouseHover(sender As Object, e As EventArgs) Handles BtnCE.MouseHover
        'Force the ToolTip text to be displayed whether Or Not the form Is active.
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnCE, "Deletes The Last (Entry): Math Operator, MathFunction Or Value.")
    End Sub
    Private Sub BtnLogx_MouseHover(sender As Object, e As EventArgs) Handles BtnLogx.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnLogx, "Enter Log Base Value First, Then Press ME. Parameters Are Log(xBaseValue, Value)")
    End Sub
    Private Sub BtnLogc_MouseHover(sender As Object, e As EventArgs) Handles BtnLogc.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnLogc, "Press ME First, Then Enter Value. Parameters Are Logc(Value)")
    End Sub
    Private Sub BtnLoge_MouseHover(sender As Object, e As EventArgs) Handles BtnLoge.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnLoge, "Press ME First, Then Enter Value. Parameters Are Loge(Value)")
    End Sub
    Private Sub BtnFourthRt_MouseHover(sender As Object, e As EventArgs) Handles BtnFourthRt.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnFourthRt, "Enter The Root Value First, Then Press ME. Parameters Are  " & ChrW(&H221A) & "(xRoot, Value)")
    End Sub
    Private Sub BtnXcubed_MouseHover(sender As Object, e As EventArgs) Handles BtnXcubed.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnXcubed, "Enter X Value First Then Press ME, Parameters Are (xValue)" & Strings.Chr(179))
    End Sub
    Private Sub BtnXraised_MouseHover(sender As Object, e As EventArgs) Handles BtnXraised.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnXraised, "Enter X Value First Then Press ME, Parameters Are Pwr(XValue, yPwrValue)")
    End Sub
    Private Sub BtnXsquared_MouseHover(sender As Object, e As EventArgs) Handles BtnXsquared.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnXsquared, "Enter X Value First Then Press ME, Parameters Are (xValue)" & Strings.Chr(178))
    End Sub
    Private Sub Btnex_MouseHover(sender As Object, e As EventArgs) Handles Btnex.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(Btnex, "Press ME First, Then Enter xValue. Parameters Are e^(xValue)")
    End Sub
    Private Sub Btn2Raised_MouseHover(sender As Object, e As EventArgs) Handles Btn2Raised.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(Btn2Raised, "Press ME First, Then Enter xValue. Parameters Are 2^(xValue)")
    End Sub
    Private Sub Btn10x_MouseHover(sender As Object, e As EventArgs) Handles Btn10x.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(Btn10x, "Press ME First, Then Enter xValue. Parameters Are 10^(xValue)")
    End Sub
    Private Sub BtnSqrt_MouseHover(sender As Object, e As EventArgs) Handles BtnSqrt.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnSqrt, "Press ME First, Then Enter xValue. Parameters Are  " & Strings.Chr(178) & ChrW(&H221A) & "(Value)")
    End Sub
    Private Sub BtnCubeRt_MouseHover(sender As Object, e As EventArgs) Handles BtnCubeRt.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnCubeRt, "Press ME First, Then Enter xValue. Parameters Are  " & Strings.Chr(179) & ChrW(&H221A) & "(Value)")
    End Sub
    Private Sub BtnSine_MouseHover(sender As Object, e As EventArgs) Handles BtnSine.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnSine, "Press ME First, Then Enter xValue. Parameters Are  " & BtnSine.Text & "(Value)")
    End Sub
    Private Sub BtnCosine_MouseHover(sender As Object, e As EventArgs) Handles BtnCosine.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnCosine, "Press ME First, Then Enter xValue. Parameters Are  " & BtnCosine.Text & "(Value)")
    End Sub
    Private Sub BtnTangent_MouseHover(sender As Object, e As EventArgs) Handles BtnTangent.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnTangent, "Press ME First, Then Enter xValue. Parameters Are  " & BtnTangent.Text & "(Value)")
    End Sub
    Private Sub BtnSec_MouseHover(sender As Object, e As EventArgs) Handles BtnSec.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnSec, "Press ME First, Then Enter xValue. Parameters Are  " & BtnSec.Text & "(Value)")
    End Sub
    Private Sub BtnCsc_MouseHover(sender As Object, e As EventArgs) Handles BtnCsc.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnCsc, "Press ME First, Then Enter xValue. Parameters Are  " & BtnCsc.Text & "(Value)")
    End Sub
    Private Sub BtnCot_MouseHover(sender As Object, e As EventArgs) Handles BtnCot.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnCot, "Press ME First, Then Enter xValue. Parameters Are  " & BtnCot.Text & "(Value)")
    End Sub
    Private Sub BtnReciprocal_MouseHover(sender As Object, e As EventArgs) Handles BtnReciprocal.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnReciprocal, "Enter X Value First Then Press ME, Parameters Are  1/(xValue)")
    End Sub
    Private Sub BtnClearAll_MouseHover(sender As Object, e As EventArgs) Handles BtnClearAll.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnClearAll, "Clears All Entries And Sets Calculator To Default State.")
    End Sub
    Private Sub BtnComma_MouseHover(sender As Object, e As EventArgs) Handles BtnComma.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnComma, "Comma Only Available For 2 Parameter Functions. Logx, " & "(x)" & Strings.ChrW(&H2B8) & " and  " & Strings.ChrW(&H2E3) & ChrW(&H221A))
    End Sub
    Private Sub BtnMod_MouseHover(sender As Object, e As EventArgs) Handles BtnMod.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnMod, "Enter Numerator Value First Then Press ME, Parameters Are  Mod(Numerator, Denominator).  Returns Remainder")
    End Sub
    Private Sub BtnM1_MouseHover(sender As Object, e As EventArgs) Handles BtnM1.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnM1, "If Answer Present Then Store Answer, Else Store Last Value.")
    End Sub
    Private Sub BtnM2_MouseHover(sender As Object, e As EventArgs) Handles BtnM2.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnM2, "If Answer Present Then Store Answer, Else Store Last Value.")
    End Sub
    Private Sub BtnM3_MouseHover(sender As Object, e As EventArgs) Handles BtnM3.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnM3, "If Answer Present Then Store Answer, Else Store Last Value.")
    End Sub
    Private Sub BtnM4_MouseHover(sender As Object, e As EventArgs) Handles BtnM4.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnM4, "If Answer Present Then Store Answer, Else Store Last Value.")
    End Sub
    Private Sub BtnCM_MouseHover(sender As Object, e As EventArgs) Handles BtnCM.MouseHover
        ToolTip1 = New ToolTip With {.InitialDelay = 500, .ReshowDelay = 250, .ShowAlways = True}
        'Set up the ToolTip text for the Object.
        ToolTip1.SetToolTip(BtnCM, "Clears ALL Memory Locations.")
    End Sub
    Private Sub BtnM1_Click(sender As Object, e As EventArgs) Handles BtnM1.Click
        If BtnM1.Text = "ms1" Then 'Set Memory
            If AnswerReceived And Answer <> Nothing Then
                Memory(0) = Answer
                BtnM1.Text = "mr1"
            ElseIf SegmentValue(SegmentIndex) <> Nothing Then
                Memory(0) = SegmentValue(SegmentIndex)
                BtnM1.Text = "mr1"
            ElseIf TbDisplay.Text <> Nothing Then
                Memory(0) = TbDisplay.Text
                BtnM1.Text = "mr1"
            End If
        Else 'Recall Memory
            DisplayBuild &= Memory(0)
            TbDisplay.Text = DisplayBuild
            If SegmentIndex = 0 Then
                SegmentIndex = 1 'Increment Segment Value
                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            End If
            ParseBuild &= SegmentName(SegmentIndex)
            SegmentValue(SegmentIndex) &= Memory(0)
            LblFormula.Text = "Formula = " & ParseBuild
            NegPos = "Pos"
            ReadyForValue = False
        End If
    End Sub
    Private Sub BtnM2_Click(sender As Object, e As EventArgs) Handles BtnM2.Click
        If BtnM2.Text = "ms2" Then 'Set Memory
            If AnswerReceived And Answer <> Nothing Then
                Memory(1) = Answer
                BtnM2.Text = "mr2"
            ElseIf SegmentValue(SegmentIndex) <> Nothing Then
                Memory(1) = SegmentValue(SegmentIndex)
                BtnM2.Text = "mr2"
            ElseIf TbDisplay.Text <> Nothing Then
                Memory(1) = TbDisplay.Text
                BtnM2.Text = "mr2"
            End If
        Else 'Recall Memory
            DisplayBuild &= Memory(1)
            TbDisplay.Text = DisplayBuild
            If SegmentIndex = 0 Then
                SegmentIndex = 1 'Increment Segment Value
                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            End If
            ParseBuild &= SegmentName(SegmentIndex)
            SegmentValue(SegmentIndex) &= Memory(1)
            LblFormula.Text = "Formula = " & ParseBuild
            NegPos = "Pos"
            ReadyForValue = False
        End If
    End Sub
    Private Sub BtnM3_Click(sender As Object, e As EventArgs) Handles BtnM3.Click
        If BtnM3.Text = "ms3" Then 'Set Memory
            If AnswerReceived And Answer <> Nothing Then
                Memory(2) = Answer
                BtnM3.Text = "mr3"
            ElseIf SegmentValue(SegmentIndex) <> Nothing Then
                Memory(2) = SegmentValue(SegmentIndex)
                BtnM3.Text = "mr3"
            ElseIf TbDisplay.Text <> Nothing Then
                Memory(2) = TbDisplay.Text
                BtnM3.Text = "mr3"
            End If
        Else 'Recall Memory
            DisplayBuild &= Memory(2)
            TbDisplay.Text = DisplayBuild
            If SegmentIndex = 0 Then
                SegmentIndex = 1 'Increment Segment Value
                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            End If
            ParseBuild &= SegmentName(SegmentIndex)
            SegmentValue(SegmentIndex) &= Memory(2)
            LblFormula.Text = "Formula = " & ParseBuild
            NegPos = "Pos"
            ReadyForValue = False
        End If
    End Sub
    Private Sub BtnM4_Click(sender As Object, e As EventArgs) Handles BtnM4.Click
        If BtnM4.Text = "ms4" Then 'Set Memory
            If AnswerReceived And Answer <> Nothing Then
                Memory(3) = Answer
                BtnM4.Text = "mr4"
            ElseIf SegmentValue(SegmentIndex) <> Nothing Then
                Memory(3) = SegmentValue(SegmentIndex)
                BtnM4.Text = "mr4"
            ElseIf TbDisplay.Text <> Nothing Then
                Memory(3) = TbDisplay.Text
                BtnM4.Text = "mr4"
            End If
        Else 'Recall Memory
            DisplayBuild &= Memory(3)
            TbDisplay.Text = DisplayBuild
            If SegmentIndex = 0 Then
                SegmentIndex = 1 'Increment Segment Value
                ReDim Preserve SegmentValue(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve SegmentName(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve BinarySegmentValue(SegmentIndex) 'Preserve The Incremented Array
                ReDim Preserve TwoParameters(SegmentIndex) 'Preserve The Incremented Array
                SegmentName(SegmentIndex) = GetNextVariableName(SegmentIndex)
            End If
            ParseBuild &= SegmentName(SegmentIndex)
            SegmentValue(SegmentIndex) &= Memory(3)
            LblFormula.Text = "Formula = " & ParseBuild
            NegPos = "Pos"
            ReadyForValue = False
        End If
    End Sub
    Private Sub BtnCM_Click(sender As Object, e As EventArgs) Handles BtnCM.Click
        Memory(0) = Nothing
        Memory(1) = Nothing
        Memory(2) = Nothing
        Memory(3) = Nothing
        BtnM1.Text = "ms1"
        BtnM2.Text = "ms2"
        BtnM3.Text = "ms3"
        BtnM4.Text = "ms4"
    End Sub
    Private Sub BtnDegree_Click(sender As Object, e As EventArgs) Handles BtnDegree.Click
        'Degrees = Radians × 180° / π
        If Base <> "Decimal" Then Exit Sub
        If TbDisplay.Text <> "" Then
            If AnswerReceived Then
                Select Case TrigFunction
                    Case "Radian"
                        TbDisplay.Text = Val(Answer) * 57.295779513082323
                        Answer = TbDisplay.Text
                    Case "Gradian"
                        TbDisplay.Text = Val(Answer) / 1.1111111111111112
                        Answer = TbDisplay.Text
                End Select
            Else
                Select Case TrigFunction
                    Case "Radian"
                        TbDisplay.Text = Val(TbDisplay.Text) * 57.295779513082323
                    Case "Gradian"
                        TbDisplay.Text = Val(TbDisplay.Text) / 1.1111111111111112
                End Select
            End If
        End If
        If Not hypKey And Not ArcKey Then
            BtnSine.Text = "sin"
            BtnCosine.Text = "cos"
            BtnTangent.Text = "tan"
            BtnSec.Text = "sec"
            BtnCsc.Text = "csc"
            BtnCot.Text = "cot"
        ElseIf hypKey And Not ArcKey Then
            BtnSine.Text = "sinh"
            BtnCosine.Text = "cosh"
            BtnTangent.Text = "tanh"
            BtnSec.Text = "sech"
            BtnCsc.Text = "csch"
            BtnCot.Text = "coth"
        ElseIf Not hypKey And ArcKey Then
            BtnSine.Text = "Asin"
            BtnCosine.Text = "Acos"
            BtnTangent.Text = "Atan"
            BtnSec.Text = "Asec"
            BtnCsc.Text = "Acsc"
            BtnCot.Text = "Acot"
        ElseIf hypKey And ArcKey Then
            BtnSine.Text = "Asinh"
            BtnCosine.Text = "Acosh"
            BtnTangent.Text = "Atanh"
            BtnSec.Text = "Asech"
            BtnCsc.Text = "Acsch"
            BtnCot.Text = "Acoth"
        End If
        TrigFunction = "Degree"
    End Sub
    Private Sub BtnRadian_Click(sender As Object, e As EventArgs) Handles BtnRadian.Click
        ' π rad = 180°
        '1 rad = 180°/π = 57.295779513°
        If Base <> "Decimal" Then Exit Sub
        If TbDisplay.Text <> "" Then
            If AnswerReceived Then
                Select Case TrigFunction
                    Case "Degree"
                        TbDisplay.Text = Val(Answer) / 57.295779513082323
                        Answer = TbDisplay.Text
                    Case "Gradian"
                        TbDisplay.Text = Val(Answer) / 63.661977236758
                        Answer = TbDisplay.Text
                End Select
            Else
                Select Case TrigFunction
                    Case "Degree"
                        TbDisplay.Text = Val(TbDisplay.Text) / 57.295779513082323
                    Case "Gradian"
                        TbDisplay.Text = Val(TbDisplay.Text) / 63.661977236758
                End Select
            End If
        End If
        If Not hypKey And Not ArcKey Then
            BtnSine.Text = "sin"
            BtnCosine.Text = "cos"
            BtnTangent.Text = "tan"
            BtnSec.Text = "sec"
            BtnCsc.Text = "csc"
            BtnCot.Text = "cot"
        ElseIf hypKey And Not ArcKey Then
            BtnSine.Text = "sinh"
            BtnCosine.Text = "cosh"
            BtnTangent.Text = "tanh"
            BtnSec.Text = "sech"
            BtnCsc.Text = "csch"
            BtnCot.Text = "coth"
        ElseIf Not hypKey And ArcKey Then
            BtnSine.Text = "Asin"
            BtnCosine.Text = "Acos"
            BtnTangent.Text = "Atan"
            BtnSec.Text = "Asec"
            BtnCsc.Text = "Acsc"
            BtnCot.Text = "Acot"
        ElseIf hypKey And ArcKey Then
            BtnSine.Text = "Asinh"
            BtnCosine.Text = "Acosh"
            BtnTangent.Text = "Atanh"
            BtnSec.Text = "Asech"
            BtnCsc.Text = "Acsch"
            BtnCot.Text = "Acoth"
        End If
        TrigFunction = "Radian"
    End Sub
    Private Sub BtnGradian_Click(sender As Object, e As EventArgs) Handles BtnGradian.Click
        'Gradians = Degrees * 1.111111111
        If Base <> "Decimal" Then Exit Sub
        If TbDisplay.Text <> "" Then
            If AnswerReceived Then
                Select Case TrigFunction
                    Case "Degree"
                        TbDisplay.Text = Val(Answer) * 1.1111111111111112
                        Answer = TbDisplay.Text
                    Case "Radian"
                        TbDisplay.Text = Val(Answer) * 63.661977236758
                        Answer = TbDisplay.Text
                End Select
            Else
                Select Case TrigFunction
                    Case "Degree"
                        TbDisplay.Text = Val(TbDisplay.Text) * 1.1111111111111112
                    Case "Radian"
                        TbDisplay.Text = Val(TbDisplay.Text) * 63.661977236758
                End Select
            End If
        End If
        If Not hypKey And Not ArcKey Then
            BtnSine.Text = "sin"
            BtnCosine.Text = "cos"
            BtnTangent.Text = "tan"
            BtnSec.Text = "sec"
            BtnCsc.Text = "csc"
            BtnCot.Text = "cot"
        ElseIf hypKey And Not ArcKey Then
            BtnSine.Text = "sinh"
            BtnCosine.Text = "cosh"
            BtnTangent.Text = "tanh"
            BtnSec.Text = "sech"
            BtnCsc.Text = "csch"
            BtnCot.Text = "coth"
        ElseIf Not hypKey And ArcKey Then
            BtnSine.Text = "Asin"
            BtnCosine.Text = "Acos"
            BtnTangent.Text = "Atan"
            BtnSec.Text = "Asec"
            BtnCsc.Text = "Acsc"
            BtnCot.Text = "Acot"
        ElseIf hypKey And ArcKey Then
            BtnSine.Text = "Asinh"
            BtnCosine.Text = "Acosh"
            BtnTangent.Text = "Atanh"
            BtnSec.Text = "Asech"
            BtnCsc.Text = "Acsch"
            BtnCot.Text = "Acoth"
        End If
        TrigFunction = "Gradian"
    End Sub
End Class
