Imports System.Runtime.Remoting.Channels

Public Class Form1
    Dim WithEvents w_timer As New Timer
    Dim w_tick As Integer
    Const row = 1
    Const col = 1
    Dim v As String
    Dim cen As Integer = 4
    Dim check As Integer = 0
    Dim Bot(row, col) As PictureBox

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i As Integer = 0 To row
            For j As Integer = 0 To col
                v = (i * 2 + j + 1).ToString()
                Bot(i, j) = New PictureBox
                Me.Controls.Add(Bot(i, j))
                Bot(i, j).Name = "PictureBox" & ((2 + 1) * i + j + 1)
                Bot(i, j).Tag = v
                Bot(i, j).Image = CType(My.Resources.ResourceManager.GetObject("box"), Image)
                Bot(i, j).SizeMode = PictureBoxSizeMode.StretchImage
                Bot(i, j).BorderStyle = BorderStyle.Fixed3D
                Bot(i, j).Visible = True
                Bot(i, j).Width = 70
                Bot(i, j).Height = 70
                Bot(i, j).Top = 70 * i
                Bot(i, j).Left = 70 * j
                AddHandler Bot(i, j).Click, AddressOf AC_click
            Next j
        Next i
        Randomize()
        back(cen)

    End Sub

    Sub back(sin As Integer)
        Dim c As Integer
        Dim t As Integer
        Dim flag As Integer
        Dim a(4)
        Dim N2 As Integer
        Dim i As Integer
        Dim N1 As Integer
        a(0) = Int(4 * Rnd() + 1)

        For i = 1 To 4
            c = Int(4 * Rnd() + 1)
            flag = 1

            For t = 0 To i - 1
                If c = a(t) Then
                    i = i - 1
                    flag = 0
                    Exit For
                End If
            Next t

            If flag = 1 Then
                a(i) = c
            End If
        Next i
        For k As Integer = 0 To 3
            If k = 0 Then
                N1 = 0
                N2 = 0
            ElseIf k = 1 Then
                N1 = 1
                N2 = 0
            ElseIf k = 3 Then
                N1 = 1
                N2 = 1
            ElseIf k = 3 Then
                N1 = 1
                N2 = 1
            Else
                N1 = 0
                N2 = 1
            End If
            If a(k) = 1 Then
                Bot(N1, N2).Tag = "1"
                Bot(N1, N2).BackgroundImage = My.Resources.ResourceManager.GetObject("1")
                Bot(N1, N2).BackgroundImageLayout = ImageLayout.Stretch
            ElseIf a(k) = 2 Then
                Bot(N1, N2).Tag = "2"
                Bot(N1, N2).BackgroundImage = My.Resources.ResourceManager.GetObject("2")
                Bot(N1, N2).BackgroundImageLayout = ImageLayout.Stretch
            ElseIf a(k) = 3 Then
                Bot(N1, N2).Tag = "3"
                Bot(N1, N2).BackgroundImage = My.Resources.ResourceManager.GetObject("3")
                Bot(N1, N2).BackgroundImageLayout = ImageLayout.Stretch
            ElseIf a(k) = 4 Then
                Bot(N1, N2).Tag = "4"
                Bot(N1, N2).BackgroundImage = My.Resources.ResourceManager.GetObject("4")
                Bot(N1, N2).BackgroundImageLayout = ImageLayout.Stretch

            End If
        Next
    End Sub

    Sub AC_click(sendeer As Object, e As EventArgs)
        Dim B = CType(sendeer, PictureBox)

        If B.Tag = "1" Then
            B.Image = Nothing
            B.Enabled = False
            wait(1)
            If check <> 0 Then
                B.Image = CType(My.Resources.ResourceManager.GetObject("box"), Image)
                B.Enabled = True
            Else
                check = 1
            End If

        ElseIf B.Tag = "2" Then
            B.Image = Nothing
            B.Enabled = False
            wait(1)
            If check <> 1 Then
                B.Image = CType(My.Resources.ResourceManager.GetObject("box"), Image)
                B.Enabled = True
            Else
                check = 2
            End If

        ElseIf B.Tag = "3" Then
            B.Image = Nothing
            B.Enabled = False
            wait(1)
            If check <> 2 Then
                B.Image = CType(My.Resources.ResourceManager.GetObject("box"), Image)
                B.Enabled = True
            Else
                check = 3
            End If

        ElseIf B.Tag = "4" Then
            B.Image = Nothing
            B.Enabled = False
            wait(1)
            If check <> 3 Then
                B.Image = CType(My.Resources.ResourceManager.GetObject("box"), Image)
                B.Enabled = True
            Else
                check = 4
            End If
        End If
        If check = 4 Then
            check = 0
        End If
    End Sub

    Private Sub wait(ByVal second As Integer)
        w_tick = 0
        w_timer.Interval = second * 1000
        w_timer.Enabled = True
        Do Until w_tick >= 1
            Application.DoEvents()
        Loop
        w_timer.Enabled = False
        w_timer.Interval = 1
    End Sub

    Private Sub w_timer_tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles w_timer.Tick
        w_tick += 1
    End Sub
End Class
