
Public Class NumericToLiteral
    Private Const Zero = "صفر"
    Private Const One = "واحد"
    Private Const OneFemale = "واحدة"
    Private Const Ahad = "أحد"
    Private Const Ehda = "إحدى"
    Private Const Two = "اثنان"
    Private Const TwoFemales = "اثنتان"
    Private Const Ethna = "اثنا"
    Private Const Ethnta = "اثنتا"
    Private Const Three = "ثلاثة"
    Private Const Four = "أربعة"
    Private Const Five = "خمسة"
    Private Const Six = "ستة"
    Private Const Seven = "سبعة"
    Private Const Eight = "ثمانية"
    Private Const Nine = "تسعة"
    Private Const Ten = "عشرة"
    Private Const Ten2 = "عشر"
    Private Const Twenty = "عشرون"
    Private Const Thirty = "ثلاثون"
    Private Const Fourty = "أربعون"
    Private Const Fifty = "خمسون"
    Private Const Sixty = "ستون"
    Private Const Seventy = "سبعون"
    Private Const Eighty = "ثمانون"
    Private Const Ninety = "تسعون"
    Private Const Hundred = "مئة"
    Private Const TwoHundreds = "مئتان"
    Private Const Thousand = "ألف"
    Private Const Thousands = "آلاف"
    Private Const Million = "مليون"
    Private Const Millions = "ملايين"
    Private Const Pillion = "مليار"
    Private Const Pillions = "مليارات"
    Private Const Trillion = "تريليون"
    Private Const Trillions = "تريليونات"
    Private Const Quadrillion = "كدريليون"
    Private Const Quadrillions = "كدريليونات"
    Private Const Quintillion = "كوينتيليون"
    Private Const Quintillions = "كوينتيليونات"

    Private Shared namesMap As New Dictionary(Of Long, String)

    Private Shared Sub Map()
        If namesMap.Count > 0 Then Return
        namesMap.Add(0, Zero)
        namesMap.Add(1, One)
        namesMap.Add(2, Two)
        namesMap.Add(3, Three)
        namesMap.Add(4, Four)
        namesMap.Add(5, Five)
        namesMap.Add(6, Six)
        namesMap.Add(7, Seven)
        namesMap.Add(8, Eight)
        namesMap.Add(9, Nine)
        namesMap.Add(10, Ten)
        namesMap.Add(20, Twenty)
        namesMap.Add(30, Thirty)
        namesMap.Add(40, Fourty)
        namesMap.Add(50, Fifty)
        namesMap.Add(60, Sixty)
        namesMap.Add(70, Seventy)
        namesMap.Add(80, Eighty)
        namesMap.Add(90, Ninety)
        namesMap.Add(100, Hundred)
        namesMap.Add(1000, Thousand)
        namesMap.Add(10 ^ 6, Million)
        namesMap.Add(10 ^ 9, Pillion)
        namesMap.Add(10 ^ 12, Trillion)
        namesMap.Add(10 ^ 15, Quadrillion)
        namesMap.Add(10 ^ 18, Quintillion)

    End Sub

    Private Shared Function Parse(a As Long, Female As Boolean, SingleName As String, PluralName As String) As String
        Map()
        Dim buf As String = a.ToString()
        buf = StrReverse(buf)
        Dim index As Long = 0
        Dim negative As Boolean = (buf(buf.Length() - 1) = "-"c)
        Dim len As Long = If(negative, buf.Length - 1, buf.Length)

        Dim name(len - 1) As String
        Dim unitValue As Long = 0
        Do While index < len
            Dim n = Val(buf(index))
            Dim decimalPos As Long = index Mod 3
            If decimalPos = 0 Then
                unitValue = Math.Pow(10, index)
            End If
            Dim decimalPlace As Long = Math.Pow(10, decimalPos)
            Select Case decimalPlace
                Case 1
                    If unitValue > 1 AndAlso index + 1 = len Then
                        Select Case n
                            Case 1
                                name(index) = namesMap(unitValue) & "، "
                            Case 2
                                name(index) = namesMap(unitValue) & ("ان") & "، "
                            Case Else
                                name(index) = PluralNames(namesMap(n), unitValue) & "، "
                        End Select
                    ElseIf n < 3 Then
                        If Female AndAlso n = 2 AndAlso index = 0 Then
                            name(index) = TwoFemales
                        Else
                            name(index) = namesMap(n)
                        End If
                    Else
                        name(index) = If(Female AndAlso index < 3, namesMap(n).Substring(0, namesMap(n).Length - 1), namesMap(n))
                    End If
                Case 10
                    Dim tmp As String = name(index - 1)
                    If n = 1 Then
                        If tmp = One Then
                            tmp = If(Female AndAlso index < 3, Ehda, Ahad)
                        ElseIf tmp = Two OrElse tmp = TwoFemales Then
                            tmp = If(Female AndAlso index < 3, Ethnta, Ethna)
                        End If
                    End If

                    If unitValue > 1 AndAlso index + 1 = len Then
                        If n = 1 AndAlso tmp = Zero Then
                            name(index) = PluralNames(Ten, unitValue) & "، "
                        ElseIf n = 1 Then
                            name(index) = Ten2 & " " & namesMap(unitValue) & "، "
                        Else
                            name(index) = namesMap(n * 10) & " " & namesMap(unitValue) & "، "
                        End If
                    Else
                        name(index) = namesMap(n * 10)
                        If name(index - 1) = Zero Then
                            If n = 1 AndAlso Female AndAlso index < 3 Then name(index) = Ten2
                        Else
                            If n = 1 AndAlso Not (Female AndAlso index < 3) Then name(index) = Ten2
                        End If
                    End If

                    If n <> 0 Then
                        name(index - 1) = name(index)
                        name(index) = tmp
                    End If

                Case 100
                    Dim s1 As String
                    If n > 2 Then
                        s1 = namesMap(n)
                        s1 = s1.Substring(0, s1.Length - (If(n = 8, 2, 1))) + Hundred
                    Else
                        s1 = If(n = 2, TwoHundreds, namesMap(n * 100))
                    End If
                    If unitValue > 1 AndAlso name(index - 2) <> Zero Then
                        Dim X = If(name(index - 2) = Ten2, Ten, name(index - 2))
                        For Each Elm In namesMap
                            Dim val = Elm.Key
                            If namesMap(val) = X Then
                                If val > 2 AndAlso val < 10 OrElse val = 10 AndAlso name(index - 1) = Zero Then
                                    name(index - 2) = PluralNames(name(index - 2), unitValue) & "، "
                                ElseIf s1 = Zero AndAlso name(index - 1) = Zero Then
                                    If val = 1 Then
                                        name(index - 2) = namesMap(unitValue) & "، "
                                    ElseIf val = 2 Then
                                        name(index - 2) = namesMap(unitValue) & "ان، "
                                    Else
                                        name(index - 2) = name(index - 2) & " " & namesMap(unitValue) & "، "
                                    End If
                                Else
                                    name(index - 2) = name(index - 2) & " " & namesMap(unitValue) & "، "
                                End If
                                Exit For
                            End If
                        Next
                    ElseIf unitValue > 1 AndAlso n <> 0 Then
                        If s1 = TwoHundreds Then s1 = s1.TrimEnd("ن")
                        s1 &= " " & namesMap(unitValue) & "،"
                    End If

                    name(index) = s1

            End Select
            index += 1
        Loop

        Dim s As String = ""
        For c As Long = 0 To len - 1
            If name(c) = Zero Then Continue For
            If Female AndAlso c = 0 AndAlso name(c) = One Then name(c) = OneFemale
            name(c) = name(c).Trim()
            If s <> "" AndAlso Not ((s.StartsWith(Ten2 & " ") OrElse s.StartsWith(Ten)) AndAlso (Not name(c - 1) = Zero)) Then
                If c > 0 Then
                    Dim X = name(c).Split(" ")
                    If X.Length > 0 Then
                        Select Case X(0)
                            Case Ten2, Twenty, Thirty, Fourty, Fifty, Sixty, Seventy, Eighty, Ninety
                                name(c) &= "ا"
                        End Select
                    End If
                End If
                s = name(c) & " و" & s
            Else
                s = name(c) & " " & s
            End If
        Next

        s = "(" & s.Trim.Trim("،").Replace("،ا ", "ا، ") & ")"
        If SingleName <> "" AndAlso PluralName <> "" Then
            Dim N As Long
            Dim X = a.ToString
            If X.Length < 2 Then
                N = a
            Else
                N = X.Substring(X.Length - 2, 2)
            End If

            If N = 0 Then
                If a > 0 Then
                    If s.EndsWith("ان" & ")") Then s = s.TrimEnd(")").TrimEnd("ن") & ")"
                    s &= " " & SingleName
                End If
            ElseIf N < 11 Then
                Select Case name(0)
                    Case Zero

                    Case One, OneFemale
                        If a = 1 Then
                            s = SingleName & " " & name(0)
                        Else
                            s &= " من ال" & PluralName
                        End If
                    Case Two, TwoFemales
                        If a = 2 Then
                            SingleName = SingleName.Replace("ة", "ت")
                            s = SingleName & "ان " & name(0)
                        Else
                            s &= " من ال" & PluralName
                        End If
                    Case Else
                        s &= " " & PluralName
                End Select
            Else
                s &= " " & SingleName & If(SingleName.EndsWith("ة"), "", "ا")
            End If
        End If

        Return If(s = "", Zero, (If(negative, "سالب " & s, s)).Trim())
    End Function

    Private Shared Function PluralNames(Word As String, unitValue As Long) As String
        If unitValue = 1000 Then
            Return Word & " " & Thousands
        ElseIf unitValue = 10 ^ 6 Then
            Return Word & " " & Millions
        ElseIf unitValue = 10 ^ 9 Then
            Return Word & " " & Pillions
        ElseIf unitValue = 10 ^ 12 Then
            Return Word & " " & Trillions
        ElseIf unitValue = 10 ^ 15 Then
            Return Word & " " & Quadrillions
        Else
            Return Word & " " & Quintillions
        End If
    End Function

    Public Shared Function Convert(a As Decimal, Optional Female As Boolean = False, Optional SingleName As String = "", Optional PluralName As String = "") As String
        If Fix(a) > Long.MaxValue Then Return "هذا العدد أكبر من القيمة العظمى التي يمكن تحويلها"
        Dim array() As String = a.ToString.Split(".")
        Dim i As Long = array(0)
        Dim f As Long = If(array.Length = 2, array(1), 0)

        Dim fractSize As Long = If(f > 0, array(1).Length, 0)

        Dim integralPart As String = If(i <> 0 OrElse f = 0, Parse(i, Female, SingleName, PluralName), "")

        Dim fractionalPart As String = If(f > 0, Parse(f, False, "", "").TrimEnd(")") & ") قرشاَ ", "")

        Return integralPart & (If(f * i <> 0, " و ", "")) & fractionalPart
    End Function

End Class


