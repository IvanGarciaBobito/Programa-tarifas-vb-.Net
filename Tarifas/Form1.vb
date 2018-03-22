Public Class Form1
    Dim tramo1 As Decimal
    Dim tramo2 As Decimal

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()

        For i = 1 To 60

            DataGridView1.Rows.Add(Tiempo(i), Math.Round(0.053 * i, 2, MidpointRounding.ToEven).ToString("N2"))
            tramo1 = Math.Round(0.053 * i, 2, MidpointRounding.ToEven)
        Next
        For i = 1 To 420
            DataGridView1.Rows.Add(Tiempo(i + 60), (Math.Round(0.043 * i, 2, MidpointRounding.ToEven) + tramo1).ToString("N2"))
            tramo2 = Math.Round(0.043 * i, 2, MidpointRounding.ToEven) + tramo1
        Next

        For i = 1 To 255
            DataGridView1.Rows.Add(Tiempo(i + 480), (Math.Round(0.032 * i, 2, MidpointRounding.ToEven) + tramo2).ToString("N2"))
        Next
    End Sub


    Private Function Tiempo(ByVal time As Integer) As String
        Dim hora As Integer
        Dim minutos As Integer
        While time >= 60
            hora = hora + 1
            minutos = time - 60
            time = time - 60
        End While
        minutos = time

        Return hora & " horas y " & minutos & " minutos       "
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value = NumericUpDown1.Value & " horas y " & NumericUpDown2.Value & " minutos       " Then
                row.Selected = True
                DataGridView1.CurrentCell = row.Cells(0)
            End If
        Next
    End Sub
End Class
