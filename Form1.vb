Public Class Form1
    Dim Num2Lit As New NumericToLiteral()
    Private Sub txtNumber_TextChanged(sender As Object, e As EventArgs) Handles txtNumber.TextChanged
        ConvertNumber()

    End Sub

    Private Sub txtNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumber.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnConvert_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ConvertNumber()
        If (txtNumber.TextLength > 0) Then
            Dim Numeric As Decimal = Decimal.Parse(txtNumber.Text.Trim)
            txtLiteral.Text = NumericToLiteral.Convert(Numeric, False, "جنيه", "جنيهات")
        Else
            txtLiteral.Text = ""
        End If
    End Sub

End Class
