<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GraphScr
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Interval = New System.Windows.Forms.TextBox()
        Me.PicGraph = New System.Windows.Forms.PictureBox()
        Me.TxtGridSpacing = New System.Windows.Forms.TextBox()
        Me.txtMaxValue = New System.Windows.Forms.TextBox()
        Me.txtMinValue = New System.Windows.Forms.TextBox()
        Me.btnGraph = New System.Windows.Forms.Button()
        Me.RefTicker = New System.Windows.Forms.Timer(Me.components)
        Me.Schrijver = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LMax1 = New System.Windows.Forms.Label()
        Me.LMIn1 = New System.Windows.Forms.Label()
        Me.Max1 = New System.Windows.Forms.TextBox()
        Me.Min1 = New System.Windows.Forms.TextBox()
        Me.PlotMin1 = New System.Windows.Forms.TextBox()
        Me.PlotMax1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PV1 = New System.Windows.Forms.TextBox()
        Me.PV2 = New System.Windows.Forms.TextBox()
        Me.PlotMin2 = New System.Windows.Forms.TextBox()
        Me.PlotMax2 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Min2 = New System.Windows.Forms.TextBox()
        Me.Max2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ActPV1 = New System.Windows.Forms.TextBox()
        Me.ActPV2 = New System.Windows.Forms.TextBox()
        Me.TickerValue = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ActPV3 = New System.Windows.Forms.TextBox()
        Me.PV3 = New System.Windows.Forms.TextBox()
        Me.PlotMin3 = New System.Windows.Forms.TextBox()
        Me.Plotmax3 = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Min3 = New System.Windows.Forms.TextBox()
        Me.Max3 = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TickerTime = New System.Windows.Forms.RadioButton()
        Me.TickerInterval = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.High = New System.Windows.Forms.RadioButton()
        Me.Low = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CP3 = New System.Windows.Forms.TextBox()
        Me.CP2 = New System.Windows.Forms.TextBox()
        Me.CP1 = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Pennen = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PicGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 199)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Lower"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Upper"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 13)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Grid"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Interval"
        '
        'Interval
        '
        Me.Interval.Location = New System.Drawing.Point(69, 89)
        Me.Interval.Name = "Interval"
        Me.Interval.Size = New System.Drawing.Size(59, 20)
        Me.Interval.TabIndex = 1
        Me.Interval.Text = "10"
        Me.Interval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PicGraph
        '
        Me.PicGraph.BackColor = System.Drawing.Color.White
        Me.PicGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicGraph.Cursor = System.Windows.Forms.Cursors.Cross
        Me.PicGraph.Location = New System.Drawing.Point(66, 34)
        Me.PicGraph.Name = "PicGraph"
        Me.PicGraph.Size = New System.Drawing.Size(800, 200)
        Me.PicGraph.TabIndex = 51
        Me.PicGraph.TabStop = False
        '
        'TxtGridSpacing
        '
        Me.TxtGridSpacing.Location = New System.Drawing.Point(69, 66)
        Me.TxtGridSpacing.Name = "TxtGridSpacing"
        Me.TxtGridSpacing.Size = New System.Drawing.Size(59, 20)
        Me.TxtGridSpacing.TabIndex = 0
        Me.TxtGridSpacing.Text = "200"
        Me.TxtGridSpacing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMaxValue
        '
        Me.txtMaxValue.Location = New System.Drawing.Point(14, 34)
        Me.txtMaxValue.Name = "txtMaxValue"
        Me.txtMaxValue.Size = New System.Drawing.Size(36, 20)
        Me.txtMaxValue.TabIndex = 0
        Me.txtMaxValue.Text = "1000"
        Me.txtMaxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMinValue
        '
        Me.txtMinValue.Location = New System.Drawing.Point(11, 215)
        Me.txtMinValue.Name = "txtMinValue"
        Me.txtMinValue.Size = New System.Drawing.Size(36, 20)
        Me.txtMinValue.TabIndex = 1
        Me.txtMinValue.Text = "0"
        Me.txtMinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnGraph
        '
        Me.btnGraph.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnGraph.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGraph.Location = New System.Drawing.Point(15, 28)
        Me.btnGraph.Name = "btnGraph"
        Me.btnGraph.Size = New System.Drawing.Size(141, 23)
        Me.btnGraph.TabIndex = 2
        Me.btnGraph.TabStop = False
        Me.btnGraph.Text = "Pen down"
        Me.btnGraph.UseVisualStyleBackColor = False
        '
        'RefTicker
        '
        Me.RefTicker.Interval = 3600000
        '
        'Schrijver
        '
        Me.Schrijver.Interval = 500
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(12, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Pen 1"
        '
        'LMax1
        '
        Me.LMax1.AutoSize = True
        Me.LMax1.Location = New System.Drawing.Point(165, 31)
        Me.LMax1.Name = "LMax1"
        Me.LMax1.Size = New System.Drawing.Size(33, 13)
        Me.LMax1.TabIndex = 62
        Me.LMax1.Text = "Max1"
        '
        'LMIn1
        '
        Me.LMIn1.AutoSize = True
        Me.LMIn1.Location = New System.Drawing.Point(165, 54)
        Me.LMIn1.Name = "LMIn1"
        Me.LMIn1.Size = New System.Drawing.Size(30, 13)
        Me.LMIn1.TabIndex = 63
        Me.LMIn1.Text = "Min1"
        '
        'Max1
        '
        Me.Max1.Location = New System.Drawing.Point(201, 28)
        Me.Max1.Name = "Max1"
        Me.Max1.Size = New System.Drawing.Size(54, 20)
        Me.Max1.TabIndex = 2
        Me.Max1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Min1
        '
        Me.Min1.Location = New System.Drawing.Point(201, 51)
        Me.Min1.Name = "Min1"
        Me.Min1.Size = New System.Drawing.Size(54, 20)
        Me.Min1.TabIndex = 1
        Me.Min1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PlotMin1
        '
        Me.PlotMin1.Location = New System.Drawing.Point(326, 51)
        Me.PlotMin1.Name = "PlotMin1"
        Me.PlotMin1.Size = New System.Drawing.Size(54, 20)
        Me.PlotMin1.TabIndex = 3
        Me.PlotMin1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PlotMax1
        '
        Me.PlotMax1.Location = New System.Drawing.Point(326, 28)
        Me.PlotMax1.Name = "PlotMax1"
        Me.PlotMax1.Size = New System.Drawing.Size(54, 20)
        Me.PlotMax1.TabIndex = 4
        Me.PlotMax1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(266, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "PlotMin1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(266, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "PlotMax1 "
        '
        'PV1
        '
        Me.PV1.Location = New System.Drawing.Point(57, 28)
        Me.PV1.Name = "PV1"
        Me.PV1.Size = New System.Drawing.Size(100, 20)
        Me.PV1.TabIndex = 0
        Me.PV1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PV2
        '
        Me.PV2.Location = New System.Drawing.Point(57, 77)
        Me.PV2.Name = "PV2"
        Me.PV2.Size = New System.Drawing.Size(100, 20)
        Me.PV2.TabIndex = 5
        Me.PV2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PlotMin2
        '
        Me.PlotMin2.Location = New System.Drawing.Point(326, 100)
        Me.PlotMin2.Name = "PlotMin2"
        Me.PlotMin2.Size = New System.Drawing.Size(54, 20)
        Me.PlotMin2.TabIndex = 8
        Me.PlotMin2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PlotMax2
        '
        Me.PlotMax2.Location = New System.Drawing.Point(326, 77)
        Me.PlotMax2.Name = "PlotMax2"
        Me.PlotMax2.Size = New System.Drawing.Size(54, 20)
        Me.PlotMax2.TabIndex = 9
        Me.PlotMax2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(266, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 77
        Me.Label8.Text = "PlotMin2"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(266, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 76
        Me.Label9.Text = "PlotMax2"
        '
        'Min2
        '
        Me.Min2.Location = New System.Drawing.Point(201, 100)
        Me.Min2.Name = "Min2"
        Me.Min2.Size = New System.Drawing.Size(54, 20)
        Me.Min2.TabIndex = 6
        Me.Min2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Max2
        '
        Me.Max2.Location = New System.Drawing.Point(201, 77)
        Me.Max2.Name = "Max2"
        Me.Max2.Size = New System.Drawing.Size(54, 20)
        Me.Max2.TabIndex = 7
        Me.Max2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(165, 103)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 13)
        Me.Label11.TabIndex = 73
        Me.Label11.Text = "Min2"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(165, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 13)
        Me.Label12.TabIndex = 72
        Me.Label12.Text = "Max2"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(12, 80)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 13)
        Me.Label13.TabIndex = 71
        Me.Label13.Text = "Pen 2"
        '
        'ActPV1
        '
        Me.ActPV1.BackColor = System.Drawing.SystemColors.Menu
        Me.ActPV1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ActPV1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ActPV1.ForeColor = System.Drawing.Color.Red
        Me.ActPV1.Location = New System.Drawing.Point(94, 50)
        Me.ActPV1.Name = "ActPV1"
        Me.ActPV1.ReadOnly = True
        Me.ActPV1.Size = New System.Drawing.Size(63, 20)
        Me.ActPV1.TabIndex = 81
        Me.ActPV1.TabStop = False
        Me.ActPV1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ActPV2
        '
        Me.ActPV2.BackColor = System.Drawing.SystemColors.Menu
        Me.ActPV2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ActPV2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ActPV2.ForeColor = System.Drawing.Color.Blue
        Me.ActPV2.Location = New System.Drawing.Point(94, 100)
        Me.ActPV2.Name = "ActPV2"
        Me.ActPV2.ReadOnly = True
        Me.ActPV2.Size = New System.Drawing.Size(63, 20)
        Me.ActPV2.TabIndex = 82
        Me.ActPV2.TabStop = False
        Me.ActPV2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TickerValue
        '
        Me.TickerValue.Location = New System.Drawing.Point(16, 31)
        Me.TickerValue.Name = "TickerValue"
        Me.TickerValue.Size = New System.Drawing.Size(59, 20)
        Me.TickerValue.TabIndex = 0
        Me.TickerValue.Text = "1000"
        Me.TickerValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(81, 38)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(22, 13)
        Me.Label17.TabIndex = 87
        Me.Label17.Text = "mS"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(135, 96)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(22, 13)
        Me.Label18.TabIndex = 88
        Me.Label18.Text = "mS"
        '
        'ActPV3
        '
        Me.ActPV3.BackColor = System.Drawing.SystemColors.Menu
        Me.ActPV3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ActPV3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ActPV3.ForeColor = System.Drawing.Color.Orange
        Me.ActPV3.Location = New System.Drawing.Point(93, 148)
        Me.ActPV3.Name = "ActPV3"
        Me.ActPV3.ReadOnly = True
        Me.ActPV3.Size = New System.Drawing.Size(63, 20)
        Me.ActPV3.TabIndex = 109
        Me.ActPV3.TabStop = False
        Me.ActPV3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PV3
        '
        Me.PV3.Location = New System.Drawing.Point(56, 126)
        Me.PV3.Name = "PV3"
        Me.PV3.Size = New System.Drawing.Size(100, 20)
        Me.PV3.TabIndex = 10
        Me.PV3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PlotMin3
        '
        Me.PlotMin3.Location = New System.Drawing.Point(325, 149)
        Me.PlotMin3.Name = "PlotMin3"
        Me.PlotMin3.Size = New System.Drawing.Size(54, 20)
        Me.PlotMin3.TabIndex = 13
        Me.PlotMin3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Plotmax3
        '
        Me.Plotmax3.Location = New System.Drawing.Point(325, 126)
        Me.Plotmax3.Name = "Plotmax3"
        Me.Plotmax3.Size = New System.Drawing.Size(54, 20)
        Me.Plotmax3.TabIndex = 14
        Me.Plotmax3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(265, 152)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(48, 13)
        Me.Label26.TabIndex = 103
        Me.Label26.Text = "PlotMin3"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(265, 129)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(51, 13)
        Me.Label27.TabIndex = 102
        Me.Label27.Text = "PlotMax3"
        '
        'Min3
        '
        Me.Min3.Location = New System.Drawing.Point(200, 149)
        Me.Min3.Name = "Min3"
        Me.Min3.Size = New System.Drawing.Size(54, 20)
        Me.Min3.TabIndex = 11
        Me.Min3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Max3
        '
        Me.Max3.Location = New System.Drawing.Point(200, 126)
        Me.Max3.Name = "Max3"
        Me.Max3.Size = New System.Drawing.Size(54, 20)
        Me.Max3.TabIndex = 12
        Me.Max3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(164, 152)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(30, 13)
        Me.Label28.TabIndex = 101
        Me.Label28.Text = "Min3"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(164, 129)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(33, 13)
        Me.Label29.TabIndex = 100
        Me.Label29.Text = "Max3"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Orange
        Me.Label30.Location = New System.Drawing.Point(11, 129)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(40, 13)
        Me.Label30.TabIndex = 99
        Me.Label30.Text = "Pen 3"
        '
        'TickerTime
        '
        Me.TickerTime.AutoSize = True
        Me.TickerTime.Checked = True
        Me.TickerTime.Location = New System.Drawing.Point(16, 71)
        Me.TickerTime.Name = "TickerTime"
        Me.TickerTime.Size = New System.Drawing.Size(81, 17)
        Me.TickerTime.TabIndex = 1
        Me.TickerTime.TabStop = True
        Me.TickerTime.Text = "System time"
        Me.TickerTime.UseVisualStyleBackColor = True
        '
        'TickerInterval
        '
        Me.TickerInterval.AutoSize = True
        Me.TickerInterval.Location = New System.Drawing.Point(16, 94)
        Me.TickerInterval.Name = "TickerInterval"
        Me.TickerInterval.Size = New System.Drawing.Size(60, 17)
        Me.TickerInterval.TabIndex = 2
        Me.TickerInterval.Text = "Interval"
        Me.TickerInterval.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Silver
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.High)
        Me.GroupBox1.Controls.Add(Me.Low)
        Me.GroupBox1.Controls.Add(Me.btnGraph)
        Me.GroupBox1.Controls.Add(Me.TxtGridSpacing)
        Me.GroupBox1.Controls.Add(Me.Interval)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Location = New System.Drawing.Point(587, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(174, 195)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Grid lines / Poll interval"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(12, 144)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(63, 13)
        Me.Label20.TabIndex = 92
        Me.Label20.Text = "in the graph"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 131)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(77, 13)
        Me.Label19.TabIndex = 91
        Me.Label19.Text = "Cursor positon "
        '
        'High
        '
        Me.High.AutoSize = True
        Me.High.Location = New System.Drawing.Point(102, 129)
        Me.High.Name = "High"
        Me.High.Size = New System.Drawing.Size(59, 17)
        Me.High.TabIndex = 90
        Me.High.Text = "highest"
        Me.High.UseVisualStyleBackColor = True
        '
        'Low
        '
        Me.Low.AutoSize = True
        Me.Low.Checked = True
        Me.Low.Location = New System.Drawing.Point(101, 150)
        Me.Low.Name = "Low"
        Me.Low.Size = New System.Drawing.Size(55, 17)
        Me.Low.TabIndex = 89
        Me.Low.TabStop = True
        Me.Low.Text = "lowest"
        Me.Low.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Silver
        Me.GroupBox2.Controls.Add(Me.TickerValue)
        Me.GroupBox2.Controls.Add(Me.TickerInterval)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.TickerTime)
        Me.GroupBox2.Location = New System.Drawing.Point(767, 32)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(145, 195)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ticker information"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Silver
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.CP3)
        Me.GroupBox3.Controls.Add(Me.CP2)
        Me.GroupBox3.Controls.Add(Me.CP1)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.LMax1)
        Me.GroupBox3.Controls.Add(Me.LMIn1)
        Me.GroupBox3.Controls.Add(Me.ActPV3)
        Me.GroupBox3.Controls.Add(Me.Max1)
        Me.GroupBox3.Controls.Add(Me.PV3)
        Me.GroupBox3.Controls.Add(Me.Min1)
        Me.GroupBox3.Controls.Add(Me.PlotMin3)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Plotmax3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.PlotMax1)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.PlotMin1)
        Me.GroupBox3.Controls.Add(Me.Min3)
        Me.GroupBox3.Controls.Add(Me.PV1)
        Me.GroupBox3.Controls.Add(Me.Max3)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label29)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label30)
        Me.GroupBox3.Controls.Add(Me.Max2)
        Me.GroupBox3.Controls.Add(Me.ActPV2)
        Me.GroupBox3.Controls.Add(Me.Min2)
        Me.GroupBox3.Controls.Add(Me.ActPV1)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.PV2)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.PlotMin2)
        Me.GroupBox3.Controls.Add(Me.PlotMax2)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(25, 32)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(556, 195)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Plotter pens"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(460, 28)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 13)
        Me.Label16.TabIndex = 116
        Me.Label16.Text = "Cursor position"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(396, 150)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 13)
        Me.Label15.TabIndex = 115
        Me.Label15.Text = "PV 3 Graph"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(396, 99)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 13)
        Me.Label14.TabIndex = 114
        Me.Label14.Text = "PV 2 Graph"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(396, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 113
        Me.Label10.Text = "PV 1 Graph"
        '
        'CP3
        '
        Me.CP3.BackColor = System.Drawing.SystemColors.Menu
        Me.CP3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CP3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CP3.ForeColor = System.Drawing.Color.Orange
        Me.CP3.Location = New System.Drawing.Point(463, 147)
        Me.CP3.Name = "CP3"
        Me.CP3.ReadOnly = True
        Me.CP3.Size = New System.Drawing.Size(73, 20)
        Me.CP3.TabIndex = 112
        Me.CP3.TabStop = False
        Me.CP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CP2
        '
        Me.CP2.BackColor = System.Drawing.SystemColors.Menu
        Me.CP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CP2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CP2.ForeColor = System.Drawing.Color.Blue
        Me.CP2.Location = New System.Drawing.Point(463, 99)
        Me.CP2.Name = "CP2"
        Me.CP2.ReadOnly = True
        Me.CP2.Size = New System.Drawing.Size(73, 20)
        Me.CP2.TabIndex = 111
        Me.CP2.TabStop = False
        Me.CP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CP1
        '
        Me.CP1.BackColor = System.Drawing.SystemColors.Menu
        Me.CP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CP1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CP1.ForeColor = System.Drawing.Color.Red
        Me.CP1.Location = New System.Drawing.Point(463, 51)
        Me.CP1.Name = "CP1"
        Me.CP1.ReadOnly = True
        Me.CP1.Size = New System.Drawing.Size(73, 20)
        Me.CP1.TabIndex = 110
        Me.CP1.TabStop = False
        Me.CP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Silver
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.PicGraph)
        Me.GroupBox4.Controls.Add(Me.txtMaxValue)
        Me.GroupBox4.Controls.Add(Me.txtMinValue)
        Me.GroupBox4.Location = New System.Drawing.Point(25, 246)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(887, 259)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Plot screen"
        '
        'Pennen
        '
        Me.Pennen.Interval = 500
        '
        'GraphScr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(924, 549)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "GraphScr"
        Me.Text = "Plotter"
        CType(Me.PicGraph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Interval As TextBox
    Friend WithEvents PicGraph As PictureBox
    Friend WithEvents TxtGridSpacing As TextBox
    Friend WithEvents txtMaxValue As TextBox
    Friend WithEvents txtMinValue As TextBox
    Friend WithEvents btnGraph As Button
    Friend WithEvents RefTicker As Timer
    Friend WithEvents Schrijver As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents LMax1 As Label
    Friend WithEvents LMIn1 As Label
    Friend WithEvents Max1 As TextBox
    Friend WithEvents Min1 As TextBox
    Friend WithEvents PlotMin1 As TextBox
    Friend WithEvents PlotMax1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PV1 As TextBox
    Friend WithEvents PV2 As TextBox
    Friend WithEvents PlotMin2 As TextBox
    Friend WithEvents PlotMax2 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Min2 As TextBox
    Friend WithEvents Max2 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents ActPV1 As TextBox
    Friend WithEvents ActPV2 As TextBox
    Friend WithEvents TickerValue As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents ActPV3 As TextBox
    Friend WithEvents PV3 As TextBox
    Friend WithEvents PlotMin3 As TextBox
    Friend WithEvents Plotmax3 As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Min3 As TextBox
    Friend WithEvents Max3 As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents TickerTime As RadioButton
    Friend WithEvents TickerInterval As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Pennen As Timer
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents CP3 As TextBox
    Friend WithEvents CP2 As TextBox
    Friend WithEvents CP1 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents High As RadioButton
    Friend WithEvents Low As RadioButton
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
End Class
