

Public Class GraphScr

    Private TipText As String

    Private PVMax1 As Integer
    Private PVMin1 As Integer
    Private PVPlotMax1 As Integer
    Private PVPlotMin1 As Integer
    Private PVPlot1 As Integer

    Private PVMax2 As Integer
    Private PVMin2 As Integer
    Private PVPlotMax2 As Integer
    Private PVPlotMin2 As Integer
    Private PVPlot2 As Integer

    Private PVMax3 As Integer
    Private PVMin3 As Integer
    Private PVPlotMax3 As Integer
    Private PVPlotMin3 As Integer
    Private PVPlot3 As Integer

    Private PV1old As Integer = 0
    Private PV2old As Integer = 0
    Private PV3old As Integer = 0
    Private PV4old As Integer = 0
    Private PV5old As Integer = 0
    Private PV6old As Integer = 0

    Private PenCursor As Integer = 1

    Private PenUp As Boolean
    Private PenColor As System.Drawing.Pens
    Private Ticker As Boolean = True
    Private TickerTotalTime As Integer = 0

    Private wid As Integer = 800
    Private hgt As Integer = 200
    Private bm As New Bitmap(800, 200)
    Private bmMin1 As New Bitmap(799, 200)
    Private gr As Graphics = Graphics.FromImage(bm)
    Private grMin1 As Graphics = Graphics.FromImage(bmMin1)



    Private Sub btnGraph_Click(sender As Object, e As EventArgs) Handles btnGraph.Click

        If btnGraph.Text = "Pen up" Then
            Interval.Enabled = True
            RefTicker.Enabled = False
            txtMaxValue.Enabled = True
            txtMinValue.Enabled = True
            TxtGridSpacing.Enabled = True
            Schrijver.Enabled = False
            Pennen.Enabled = False
            PV1.Enabled = True
            PV2.Enabled = True
            PV3.Enabled = True
            Max1.Enabled = True
            Max2.Enabled = True
            Max3.Enabled = True
            Min1.Enabled = True
            Min2.Enabled = True
            Min3.Enabled = True
            PlotMax1.Enabled = True
            PlotMax2.Enabled = True
            Plotmax3.Enabled = True
            PlotMin1.Enabled = True
            PlotMin2.Enabled = True
            PlotMin3.Enabled = True
            TickerValue.Enabled = True
            btnGraph.Text = "Pen down"
        Else
            If btnGraph.Text = "Pen down" Then
                Interval.Enabled = False
                txtMaxValue.Enabled = False
                txtMinValue.Enabled = False
                TxtGridSpacing.Enabled = False
                RefTicker.Enabled = True
                PV1.Enabled = False
                PV2.Enabled = False
                PV3.Enabled = False
                Max1.Enabled = False
                Max2.Enabled = False
                Max3.Enabled = False
                Min1.Enabled = False
                Min2.Enabled = False
                Min3.Enabled = False
                PlotMax1.Enabled = False
                PlotMax2.Enabled = False
                Plotmax3.Enabled = False
                PlotMin1.Enabled = False
                PlotMin2.Enabled = False
                PlotMin3.Enabled = False
                TickerValue.Enabled = False
                Ticker = True
                Schrijver.Interval = System.Convert.ToInt32(Interval.Text)
                If PenUp Then
                    DrawGraph(Str(PVValue1), 0, False, Pens.Black, False, False)
                    DrawGraph(Str(PVValue2), 0, False, Pens.Red, False, False)
                    DrawGraph(Str(PVValue3), 0, True, Pens.Orange, False, False)
                Else
                    DrawGraph(Str(PVValue1), PV1old, False, Pens.Black, False, False)
                    DrawGraph(Str(PVValue2), PV2old, False, Pens.Red, False, False)
                    DrawGraph(Str(PVValue3), PV3old, True, Pens.Orange, False, False)
                End If
                PenUp = False
                Schrijver.Enabled = True
                Pennen.Enabled = True
                btnGraph.Text = "Pen up"
            End If
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PenUp = True

    End Sub

    Private Function RemoveDot(PV As String) As String

        Dim TestArray() As String = Split(PV, ".")

        RemoveDot = ""
        For i As Integer = 0 To TestArray.Length - 1
            If TestArray(i) <> "" Then
                RemoveDot = RemoveDot + TestArray(i)
            End If
        Next

        Return RemoveDot

    End Function




    Private Sub DrawGraph(PVString As String, ByRef OldPV As Int32, OnlyDot As Boolean, Stift As System.Drawing.Pen, Digital As Boolean, PenPos As Boolean)

        Dim PVint32 As Int32

        NewValue(PVString, PVint32)
        PlotValue(OldPV, PVint32, OnlyDot, Stift, Digital, PenPos)
        OldPV = PVint32

    End Sub

    Private Sub NewValue(PV As String, ByRef PVint32 As Int32)

        Dim maxValue As Int32
        Dim minValue As Int32

        'Get the new value
        PVint32 = Int(RemoveDot(PV))
        maxValue = Int(txtMaxValue.Text)
        minValue = Int(txtMinValue.Text)

        PVint32 = PicGraph.ClientSize.Height - Int(((PVint32 - minValue) / (maxValue - minValue)) * PicGraph.ClientSize.Height)

        If PVint32 < 0 Then PVint32 = 0
        If PVint32 >= PicGraph.ClientSize.Height - 1 Then PVint32 = PicGraph.ClientSize.Height - 1

    End Sub

    Private Sub PlotValue(ByVal old_y As Integer, ByVal new_y As Integer, Onlydot As Boolean, Stift As System.Drawing.Pen, ByVal Digital As Boolean, ByVal PenPos As Boolean)


        Dim m_Ymid As Integer
        Dim GRID_STEP As Integer = Convert.ToInt32(TxtGridSpacing.Text)
        Dim drawFont As New Font("Arial", 6)
        Dim drawBrush As New SolidBrush(Color.Black)
        Dim GridText As String = ""
        Dim TickerDate As String

        Dim drawFormat As New StringFormat
        drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft

        If Ticker And Not Onlydot Then
            Ticker = False
            GRID_STEP = 5
            ' Draw string to screen.
            If Not PenUp Then
                If TickerTime.Checked Then
                    TickerDate = TimeString
                    GridText = TickerDate
                Else
                    TickerTotalTime = TickerTotalTime + Int(TickerValue.Text)
                    GridText = Str(TickerTotalTime)
                End If
                drawBrush.Color = Color.Black
                gr.DrawString(GridText, drawFont, drawBrush, 799, 188, drawFormat)
            Else
                TickerTotalTime = 0
            End If
        End If


        If Not Onlydot Then

            ' Move the old data one pixel to the left 
            If Not PenUp Then gr.DrawImage(PicGraph.Image, -1, 0, 800, 200)

            ' Erase the right edge and draw guide lines.
            m_Ymid = 200 / 2

            gr.DrawLine(Pens.White, 800 - 1, 0, 800 - 1, 200 - 1)

            For i As Integer = m_Ymid To 200 Step GRID_STEP
                gr.DrawLine(Pens.Gray, 800 - 2, i, 800 - 1, i)
            Next i
            For i As Integer = m_Ymid To 0 Step -GRID_STEP
                gr.DrawLine(Pens.Gray, 800 - 2, i, 800 - 1, i)
            Next i

            ScreenPointer = ScreenPointer + 1
            If ScreenPointer = 600 Then ScreenPointer = 1
            If ScreenPointer = 200 Then
                GridText = "Pen 1:" + ToolTip1
                drawBrush.Color = Color.Gray
                gr.DrawString(GridText, drawFont, drawBrush, 750, 10, drawFormat)
                GridText = "Pen 2:" + ToolTip2
                drawBrush.Color = Color.Gray
                gr.DrawString(GridText, drawFont, drawBrush, 750, 20, drawFormat)
                GridText = "Pen 3:" + ToolTip3
                drawBrush.Color = Color.Gray
                gr.DrawString(GridText, drawFont, drawBrush, 750, 30, drawFormat)
                'GridText = " JBSiemonsma©2016 Arduino FSM "
                'drawBrush.Color = Color.LightGray
                'gr.DrawString(GridText, drawFont, drawBrush, 550, 10, drawFormat)
            End If

        End If

        If PenPos Then
            gr.DrawLine(Stift, 800 - 1, old_y, 800 - 1, new_y)
        Else
            If Not Digital Then
                gr.DrawLine(Stift, 800 - 2, old_y, 800 - 1, new_y)
            Else
                gr.DrawLine(Stift, 800 - 2, new_y, 800 - 1, new_y)
                gr.DrawLine(Stift, 800 - 2, old_y, 800 - 2, new_y)
            End If
        End If

        ' Display the result.
        PicGraph.Image = bm
        PicGraph.Refresh()



    End Sub


    Private Sub Schrijver_Tick(sender As Object, e As EventArgs) Handles Schrijver.Tick

        Dim PVMax1 As Integer
        Dim PVMin1 As Integer
        Dim PVPlotMax1 As Integer
        Dim PVPlotMin1 As Integer
        Dim PVPlot1 As Integer

        Dim PVMax2 As Integer
        Dim PVMin2 As Integer
        Dim PVPlotMax2 As Integer
        Dim PVPlotMin2 As Integer
        Dim PVPlot2 As Integer

        Dim PVMax3 As Integer
        Dim PVMin3 As Integer
        Dim PVPlotMax3 As Integer
        Dim PVPlotMin3 As Integer
        Dim PVPlot3 As Integer

        ActPV1.Text = Str(PVValue1)
        PVMax1 = Int(Max1.Text)
        PVMin1 = Int(Min1.Text)
        PVPlotMax1 = Int(PlotMax1.Text)
        PVPlotMin1 = Int(PlotMin1.Text)
        PVPlot1 = PVPlotMin1 + ((PVPlotMax1 - PVPlotMin1) * ((PVValue1 - PVMin1) / (PVMax1 - PVMin1)))

        ActPV2.Text = Str(PVValue2)
        PVMax2 = Int(Max2.Text)
        PVMin2 = Int(Min2.Text)
        PVPlotMax2 = Int(PlotMax2.Text)
        PVPlotMin2 = Int(PlotMin2.Text)
        PVPlot2 = PVPlotMin2 + ((PVPlotMax2 - PVPlotMin2) * ((PVValue2 - PVMin2) / (PVMax2 - PVMin2)))

        ActPV3.Text = Str(PVValue3)
        PVMax3 = Int(Max3.Text)
        PVMin3 = Int(Min3.Text)
        PVPlotMax3 = Int(Plotmax3.Text)
        PVPlotMin3 = Int(PlotMin3.Text)
        PVPlot3 = PVPlotMin3 + ((PVPlotMax3 - PVPlotMin3) * ((PVValue3 - PVMin3) / (PVMax3 - PVMin3)))


        'Okee, now draw....!
        DrawGraph(Str(PVPlot1), PV1old, True, Pens.Red, (PVMax1 = 1) And (PVMin1 = 0), False)
        DrawGraph(Str(PVPlot2), PV2old, True, Pens.Blue, (PVMax2 = 1) And (PVMin2 = 0), False)
        DrawGraph(Str(PVPlot3), PV3old, False, Pens.Orange, (PVMax3 = 1) And (PVMin3 = 0), False)


    End Sub


    Private Sub RefTicker_Tick(sender As Object, e As EventArgs) Handles RefTicker.Tick
        Ticker = True
    End Sub

    Private Sub PV1_TextChanged(sender As Object, e As EventArgs) Handles PV1.TextChanged
        PVName1 = PV1.Text
    End Sub

    Private Sub PV2_TextChanged(sender As Object, e As EventArgs) Handles PV2.TextChanged
        PVName2 = PV2.Text
    End Sub

    Private Sub PV3_TextChanged(sender As Object, e As EventArgs) Handles PV3.TextChanged
        PVName3 = PV3.Text
    End Sub

    Private Sub TickerValue_TextChanged(sender As Object, e As EventArgs) Handles TickerValue.TextChanged
        RefTicker.Interval = Int(TickerValue.Text)
    End Sub

    Private Sub Pennen_Tick(sender As Object, e As EventArgs) Handles Pennen.Tick


        ActPV1.Text = Str(PVValue1)
        PVMax1 = Int(Max1.Text)
        PVMin1 = Int(Min1.Text)
        PVPlotMax1 = Int(PlotMax1.Text)
        PVPlotMin1 = Int(PlotMin1.Text)
        PVPlot1 = PVPlotMin1 + ((PVPlotMax1 - PVPlotMin1) * ((PVValue1 - PVMin1) / (PVMax1 - PVMin1)))

        ActPV2.Text = Str(PVValue2)
        PVMax2 = Int(Max2.Text)
        PVMin2 = Int(Min2.Text)
        PVPlotMax2 = Int(PlotMax2.Text)
        PVPlotMin2 = Int(PlotMin2.Text)
        PVPlot2 = PVPlotMin2 + ((PVPlotMax2 - PVPlotMin2) * ((PVValue2 - PVMin2) / (PVMax2 - PVMin2)))

        ActPV3.Text = Str(PVValue3)
        PVMax3 = Int(Max3.Text)
        PVMin3 = Int(Min3.Text)
        PVPlotMax3 = Int(Plotmax3.Text)
        PVPlotMin3 = Int(PlotMin3.Text)
        PVPlot3 = PVPlotMin3 + ((PVPlotMax3 - PVPlotMin3) * ((PVValue3 - PVMin3) / (PVMax3 - PVMin3)))

        DrawGraph(Str(PVPlot1), PV1old, True, Pens.Red, (PVMax1 = 1) And (PVMin1 = 0), True)
        DrawGraph(Str(PVPlot2), PV2old, True, Pens.Blue, (PVMax2 = 1) And (PVMin2 = 0), True)
        DrawGraph(Str(PVPlot3), PV3old, True, Pens.Orange, (PVMax3 = 1) And (PVMin3 = 0), True)
    End Sub

    Dim TrackTip As New ToolTip

    Private Sub TrackCoordinates()
        TrackTip = New ToolTip()
    End Sub

    Private Sub PicGraph_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicGraph.MouseMove

        Dim Kleur As Color
        Dim Blauw As Integer = 0
        Dim Rood As Integer = 0
        Dim Oranje As Integer = 0

        Dim Hoog1 As Boolean
        Dim Hoog2 As Boolean
        Dim Hoog3 As Boolean

        Dim Laag1 As Boolean
        Dim Laag2 As Boolean
        Dim Laag3 As Boolean

        Hoog1 = High.Checked
        Laag1 = Low.Checked
        Hoog2 = High.Checked
        Laag2 = Low.Checked
        Hoog3 = High.Checked
        Laag3 = Low.Checked

        For VertLine As Integer = 0 To 197 Step 1

            Kleur = bm.GetPixel(e.X, VertLine)

            If (Kleur.ToArgb = Color.Blue.ToArgb) Or (Kleur.ToArgb = Color.Orange.ToArgb) Or (Kleur.ToArgb = Color.Red.ToArgb) Then

                If (Kleur.ToArgb = Color.Red.ToArgb) And (Hoog1 Or Laag1) Then
                    Rood = Int(((((197 - VertLine) / 197) - (PVPlotMin1 / 1000)) / ((PVPlotMax1 / 1000) - (PVPlotMin1 / 1000)) * (PVMax1 - PVMin1)) * 10)
                    If PVMax1 = 1 Then
                        If (Rood > 8) Then
                            Rood = 1
                        Else
                            Rood = 0
                        End If
                    Else
                        Rood = Int(Rood / 10)
                    End If
                    If Hoog1 Then Hoog1 = False
                End If

                If (Kleur.ToArgb = Color.Blue.ToArgb) And (Hoog2 Or Laag2) Then
                    Blauw = Int(((((197 - VertLine) / 197) - (PVPlotMin2 / 1000)) / ((PVPlotMax2 / 1000) - (PVPlotMin2 / 1000)) * (PVMax2 - PVMin2)) * 10)
                    If PVMax2 = 1 Then
                        If (Blauw > 8) Then
                            Blauw = 1
                        Else
                            Blauw = 0
                        End If
                    Else
                        Blauw = Int(Blauw / 10)
                    End If
                    If Hoog2 Then Hoog2 = False
                End If

                If (Kleur.ToArgb = Color.Orange.ToArgb) And (Hoog3 Or Laag3) Then
                    Oranje = Int(((((197 - VertLine) / 197) - (PVPlotMin3 / 1000)) / ((PVPlotMax3 / 1000) - (PVPlotMin3 / 1000)) * (PVMax3 - PVMin3)) * 10)
                    If PVMax3 = 1 Then
                        If (Oranje > 8) Then
                            Oranje = 1
                        Else
                            Oranje = 0
                        End If
                    Else
                        Oranje = Int(Oranje / 10)
                    End If
                    If Hoog3 Then Hoog3 = False
                End If

            End If

        Next VertLine

        CP1.Text = Str(Rood + PVMin1)
        CP2.Text = Str(Blauw + PVMin2)
        CP3.Text = Str(Oranje + PVMin3)


    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class











