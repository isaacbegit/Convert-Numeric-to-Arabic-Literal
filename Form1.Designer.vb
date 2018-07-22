<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.txtNumber = New System.Windows.Forms.TextBox()
        Me.txtLiteral = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtNumber
        '
        Me.txtNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumber.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.txtNumber.Location = New System.Drawing.Point(151, 106)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(320, 32)
        Me.txtNumber.TabIndex = 0
        Me.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLiteral
        '
        Me.txtLiteral.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtLiteral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLiteral.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtLiteral.Font = New System.Drawing.Font("Adobe Arabic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLiteral.ForeColor = System.Drawing.Color.White
        Me.txtLiteral.Location = New System.Drawing.Point(0, 158)
        Me.txtLiteral.Multiline = True
        Me.txtLiteral.Name = "txtLiteral"
        Me.txtLiteral.ReadOnly = True
        Me.txtLiteral.Size = New System.Drawing.Size(636, 157)
        Me.txtLiteral.TabIndex = 1
        Me.txtLiteral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(636, 85)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Convert Numeric to Arabic Literal"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(149, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 19)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Enter number"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(636, 315)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtLiteral)
        Me.Controls.Add(Me.txtNumber)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Convert Numeric to Arabic Literal"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtNumber As TextBox
    Friend WithEvents txtLiteral As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
