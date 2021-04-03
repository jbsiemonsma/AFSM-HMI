<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Standard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Standard))
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.TransportLabel = New System.Windows.Forms.Label()
        Me.ToArduino = New System.Windows.Forms.TextBox()
        Me.DATALOGGER = New System.Windows.Forms.Label()
        Me.SendToArduino = New System.Windows.Forms.Button()
        Me.CommicationPort = New System.Windows.Forms.Label()
        Me.DigInMask = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DigInTagName = New System.Windows.Forms.ToolStripTextBox()
        Me.DigInDBLogging = New System.Windows.Forms.ToolStripMenuItem()
        Me.Masking = New System.Windows.Forms.ToolStripMenuItem()
        Me.DigInMaskOn = New System.Windows.Forms.ToolStripMenuItem()
        Me.DigInMaskOff = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mega2560Port = New System.IO.Ports.SerialPort(Me.components)
        Me.TimerSendGMI = New System.Windows.Forms.Timer(Me.components)
        Me.AnaInMask = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AnaInTagName = New System.Windows.Forms.ToolStripTextBox()
        Me.AnaInDBLogging = New System.Windows.Forms.ToolStripMenuItem()
        Me.IntervalmSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnaInDBInterval = New System.Windows.Forms.ToolStripTextBox()
        Me.SetAnaInDBInterval = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnalogueAutomatic = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnalogueMaskOn = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnalogueMaskValue = New System.Windows.Forms.ToolStripTextBox()
        Me.AnalogueSetMask = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltrasonicMask = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UltrasonicTagName = New System.Windows.Forms.ToolStripTextBox()
        Me.UltrasonicAutomatic = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltrasonicMaskOn = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltrasonicValue = New System.Windows.Forms.ToolStripTextBox()
        Me.UltrasonicSetMask = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DigOutForce = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DigOutTagName = New System.Windows.Forms.ToolStripTextBox()
        Me.DigOutDBLogging = New System.Windows.Forms.ToolStripMenuItem()
        Me.Forcing = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForceOn = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForceOff = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnaOutForce = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AnaOutTagName = New System.Windows.Forms.ToolStripTextBox()
        Me.AnaOutDBLogging = New System.Windows.Forms.ToolStripMenuItem()
        Me.Intervalx01SecToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnaOutDBInterval = New System.Windows.Forms.ToolStripTextBox()
        Me.SetAnaOutDBInterval = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnaOutAutomatic = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnaOutForceOn = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnaOutForceValue = New System.Windows.Forms.ToolStripTextBox()
        Me.Force = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServoForce = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ServoTagName = New System.Windows.Forms.ToolStripTextBox()
        Me.ServoAutomatic = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServoForceValue = New System.Windows.Forms.ToolStripTextBox()
        Me.ServoForceOn = New System.Windows.Forms.ToolStripMenuItem()
        Me.Retry = New System.Windows.Forms.Timer(Me.components)
        Me.TTMask = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TTTagName = New System.Windows.Forms.ToolStripTextBox()
        Me.TTDBLogging = New System.Windows.Forms.ToolStripMenuItem()
        Me.Intervalx01SecToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TTDBInterval = New System.Windows.Forms.ToolStripTextBox()
        Me.SetTTDBInterval = New System.Windows.Forms.ToolStripMenuItem()
        Me.TTAutomatic = New System.Windows.Forms.ToolStripMenuItem()
        Me.TTMaskOn = New System.Windows.Forms.ToolStripMenuItem()
        Me.TTValue = New System.Windows.Forms.ToolStripTextBox()
        Me.TTSetMask = New System.Windows.Forms.ToolStripMenuItem()
        Me.Manual = New System.Windows.Forms.PrintPreviewDialog()
        Me.WatchDog = New System.Windows.Forms.Timer(Me.components)
        Me.TextForce = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MKTagName = New System.Windows.Forms.ToolStripTextBox()
        Me.TextAutomatic = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MKForceValue = New System.Windows.Forms.ToolStripTextBox()
        Me.MKForce = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.FreeMemory = New System.Windows.Forms.TextBox()
        Me.CycleTime = New System.Windows.Forms.TextBox()
        Me.TimeStamp = New System.Windows.Forms.TextBox()
        Me.FSMBox = New System.Windows.Forms.CheckedListBox()
        Me.SyncTimeBoardTimer = New System.Windows.Forms.Timer(Me.components)
        Me.AfterStartup = New System.Windows.Forms.Timer(Me.components)
        Me.ActualStates = New System.Windows.Forms.Timer(Me.components)
        Me.CycleTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FreeRam = New System.Windows.Forms.Timer(Me.components)
        Me.GetTime = New System.Windows.Forms.Timer(Me.components)
        Me.Monitor = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.DBImage = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Main = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.CheckNoDB = New System.Windows.Forms.Timer(Me.components)
        Me.ClearFSMStates = New System.Windows.Forms.Timer(Me.components)
        Me.HistorianRAW = New System.Windows.Forms.BindingSource(Me.components)
        Me.HistorianDataSet = New WindowsApplication1.HistorianDataSet()
        Me.RAW = New WindowsApplication1.HistorianDataSetTableAdapters.RAWTableAdapter()
        Me.HistorianTAGS = New System.Windows.Forms.BindingSource(Me.components)
        Me.TAGS = New WindowsApplication1.HistorianDataSetTableAdapters.TagsTableAdapter()
        Me.HistorianApplications = New System.Windows.Forms.BindingSource(Me.components)
        Me.Applications = New WindowsApplication1.HistorianDataSetTableAdapters.ApplicationsTableAdapter()
        Me.DigInMask.SuspendLayout()
        Me.AnaInMask.SuspendLayout()
        Me.UltrasonicMask.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.DigOutForce.SuspendLayout()
        Me.AnaOutForce.SuspendLayout()
        Me.ServoForce.SuspendLayout()
        Me.TTMask.SuspendLayout()
        Me.TextForce.SuspendLayout()
        Me.Monitor.SuspendLayout()
        CType(Me.DBImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.HistorianRAW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HistorianDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HistorianTAGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HistorianApplications, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BackgroundWorker1
        '
        '
        'TransportLabel
        '
        Me.TransportLabel.AutoSize = True
        Me.TransportLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TransportLabel.Enabled = False
        Me.TransportLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TransportLabel.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TransportLabel.Location = New System.Drawing.Point(184, 493)
        Me.TransportLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TransportLabel.Name = "TransportLabel"
        Me.TransportLabel.Size = New System.Drawing.Size(15, 15)
        Me.TransportLabel.TabIndex = 6
        Me.TransportLabel.Text = "  "
        Me.TransportLabel.Visible = False
        '
        'ToArduino
        '
        Me.ToArduino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToArduino.Location = New System.Drawing.Point(10, 406)
        Me.ToArduino.Margin = New System.Windows.Forms.Padding(2)
        Me.ToArduino.Name = "ToArduino"
        Me.ToArduino.Size = New System.Drawing.Size(128, 20)
        Me.ToArduino.TabIndex = 7
        '
        'DATALOGGER
        '
        Me.DATALOGGER.AutoSize = True
        Me.DATALOGGER.Location = New System.Drawing.Point(8, 380)
        Me.DATALOGGER.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.DATALOGGER.Name = "DATALOGGER"
        Me.DATALOGGER.Size = New System.Drawing.Size(52, 13)
        Me.DATALOGGER.TabIndex = 8
        Me.DATALOGGER.Text = "TX Board"
        '
        'SendToArduino
        '
        Me.SendToArduino.BackColor = System.Drawing.Color.Silver
        Me.SendToArduino.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SendToArduino.Location = New System.Drawing.Point(75, 378)
        Me.SendToArduino.Margin = New System.Windows.Forms.Padding(2)
        Me.SendToArduino.Name = "SendToArduino"
        Me.SendToArduino.Size = New System.Drawing.Size(62, 25)
        Me.SendToArduino.TabIndex = 9
        Me.SendToArduino.Text = "SEND"
        Me.SendToArduino.UseVisualStyleBackColor = False
        '
        'CommicationPort
        '
        Me.CommicationPort.AutoSize = True
        Me.CommicationPort.Location = New System.Drawing.Point(14, 443)
        Me.CommicationPort.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.CommicationPort.Name = "CommicationPort"
        Me.CommicationPort.Size = New System.Drawing.Size(39, 13)
        Me.CommicationPort.TabIndex = 11
        Me.CommicationPort.Text = "Label3"
        '
        'DigInMask
        '
        Me.DigInMask.AccessibleName = "DigInMask"
        Me.DigInMask.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.DigInMask.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DigInTagName, Me.DigInDBLogging, Me.Masking})
        Me.DigInMask.Name = "MaskInput"
        Me.DigInMask.Size = New System.Drawing.Size(161, 73)
        '
        'DigInTagName
        '
        Me.DigInTagName.BackColor = System.Drawing.SystemColors.Info
        Me.DigInTagName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.DigInTagName.Name = "DigInTagName"
        Me.DigInTagName.Size = New System.Drawing.Size(100, 23)
        '
        'DigInDBLogging
        '
        Me.DigInDBLogging.Name = "DigInDBLogging"
        Me.DigInDBLogging.Size = New System.Drawing.Size(160, 22)
        Me.DigInDBLogging.Text = "DB Logging"
        '
        'Masking
        '
        Me.Masking.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DigInMaskOn, Me.DigInMaskOff})
        Me.Masking.Name = "Masking"
        Me.Masking.Size = New System.Drawing.Size(160, 22)
        Me.Masking.Text = "Masking"
        '
        'DigInMaskOn
        '
        Me.DigInMaskOn.Name = "DigInMaskOn"
        Me.DigInMaskOn.Size = New System.Drawing.Size(111, 22)
        Me.DigInMaskOn.Text = "Mask 1"
        '
        'DigInMaskOff
        '
        Me.DigInMaskOff.Name = "DigInMaskOff"
        Me.DigInMaskOff.Size = New System.Drawing.Size(111, 22)
        Me.DigInMaskOff.Text = "Mask 0"
        '
        'Mega2560Port
        '
        Me.Mega2560Port.WriteBufferSize = 4096
        '
        'TimerSendGMI
        '
        Me.TimerSendGMI.Enabled = True
        Me.TimerSendGMI.Interval = 3000
        '
        'AnaInMask
        '
        Me.AnaInMask.AccessibleName = "AnaInMask"
        Me.AnaInMask.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.AnaInMask.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnaInTagName, Me.AnaInDBLogging, Me.AnalogueAutomatic, Me.AnalogueMaskOn})
        Me.AnaInMask.Name = "ContextMenuStrip1"
        Me.AnaInMask.Size = New System.Drawing.Size(161, 95)
        '
        'AnaInTagName
        '
        Me.AnaInTagName.BackColor = System.Drawing.SystemColors.Info
        Me.AnaInTagName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.AnaInTagName.Name = "AnaInTagName"
        Me.AnaInTagName.Size = New System.Drawing.Size(100, 23)
        '
        'AnaInDBLogging
        '
        Me.AnaInDBLogging.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IntervalmSToolStripMenuItem})
        Me.AnaInDBLogging.Name = "AnaInDBLogging"
        Me.AnaInDBLogging.Size = New System.Drawing.Size(160, 22)
        Me.AnaInDBLogging.Text = "DB Logging"
        '
        'IntervalmSToolStripMenuItem
        '
        Me.IntervalmSToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnaInDBInterval, Me.SetAnaInDBInterval})
        Me.IntervalmSToolStripMenuItem.Name = "IntervalmSToolStripMenuItem"
        Me.IntervalmSToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.IntervalmSToolStripMenuItem.Text = "Interval (x0,1Sec)"
        '
        'AnaInDBInterval
        '
        Me.AnaInDBInterval.Name = "AnaInDBInterval"
        Me.AnaInDBInterval.Size = New System.Drawing.Size(100, 23)
        Me.AnaInDBInterval.Text = "0010"
        Me.AnaInDBInterval.ToolTipText = "Poll interval between 1..9999 (x0,1Sec)"
        '
        'SetAnaInDBInterval
        '
        Me.SetAnaInDBInterval.Name = "SetAnaInDBInterval"
        Me.SetAnaInDBInterval.Size = New System.Drawing.Size(160, 22)
        Me.SetAnaInDBInterval.Text = "Set poll interval"
        '
        'AnalogueAutomatic
        '
        Me.AnalogueAutomatic.Name = "AnalogueAutomatic"
        Me.AnalogueAutomatic.Size = New System.Drawing.Size(160, 22)
        Me.AnalogueAutomatic.Text = "Remove mask"
        '
        'AnalogueMaskOn
        '
        Me.AnalogueMaskOn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnalogueMaskValue, Me.AnalogueSetMask})
        Me.AnalogueMaskOn.Name = "AnalogueMaskOn"
        Me.AnalogueMaskOn.Size = New System.Drawing.Size(160, 22)
        Me.AnalogueMaskOn.Text = "Mask"
        '
        'AnalogueMaskValue
        '
        Me.AnalogueMaskValue.AutoToolTip = True
        Me.AnalogueMaskValue.Name = "AnalogueMaskValue"
        Me.AnalogueMaskValue.Size = New System.Drawing.Size(100, 23)
        Me.AnalogueMaskValue.ToolTipText = "Analogue value 0..1023"
        '
        'AnalogueSetMask
        '
        Me.AnalogueSetMask.Name = "AnalogueSetMask"
        Me.AnalogueSetMask.Size = New System.Drawing.Size(160, 22)
        Me.AnalogueSetMask.Text = "Set mask"
        '
        'UltrasonicMask
        '
        Me.UltrasonicMask.AccessibleName = "UltrasonicMask"
        Me.UltrasonicMask.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.UltrasonicMask.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UltrasonicTagName, Me.UltrasonicAutomatic, Me.UltrasonicMaskOn})
        Me.UltrasonicMask.Name = "UltrasonicMask"
        Me.UltrasonicMask.Size = New System.Drawing.Size(161, 73)
        '
        'UltrasonicTagName
        '
        Me.UltrasonicTagName.BackColor = System.Drawing.SystemColors.Info
        Me.UltrasonicTagName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UltrasonicTagName.Name = "UltrasonicTagName"
        Me.UltrasonicTagName.Size = New System.Drawing.Size(100, 23)
        '
        'UltrasonicAutomatic
        '
        Me.UltrasonicAutomatic.Name = "UltrasonicAutomatic"
        Me.UltrasonicAutomatic.Size = New System.Drawing.Size(160, 22)
        Me.UltrasonicAutomatic.Text = "Remove mask"
        '
        'UltrasonicMaskOn
        '
        Me.UltrasonicMaskOn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UltrasonicValue, Me.UltrasonicSetMask})
        Me.UltrasonicMaskOn.Name = "UltrasonicMaskOn"
        Me.UltrasonicMaskOn.Size = New System.Drawing.Size(160, 22)
        Me.UltrasonicMaskOn.Text = "Mask"
        '
        'UltrasonicValue
        '
        Me.UltrasonicValue.AcceptsReturn = True
        Me.UltrasonicValue.AutoToolTip = True
        Me.UltrasonicValue.Name = "UltrasonicValue"
        Me.UltrasonicValue.Size = New System.Drawing.Size(100, 23)
        Me.UltrasonicValue.ToolTipText = "Ultrasonic 0..500cm"
        '
        'UltrasonicSetMask
        '
        Me.UltrasonicSetMask.Name = "UltrasonicSetMask"
        Me.UltrasonicSetMask.Size = New System.Drawing.Size(160, 22)
        Me.UltrasonicSetMask.Text = "Set mask"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 523)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 10, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(583, 22)
        Me.StatusStrip1.TabIndex = 28
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(79, 17)
        Me.ToolStripStatusLabel1.Text = "Informational"
        Me.ToolStripStatusLabel1.ToolTipText = "."
        '
        'DigOutForce
        '
        Me.DigOutForce.AccessibleName = "DigOutForce"
        Me.DigOutForce.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.DigOutForce.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.DigOutForce.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DigOutTagName, Me.DigOutDBLogging, Me.Forcing})
        Me.DigOutForce.Name = "OutputManipulatie"
        Me.DigOutForce.Size = New System.Drawing.Size(161, 73)
        '
        'DigOutTagName
        '
        Me.DigOutTagName.BackColor = System.Drawing.SystemColors.Info
        Me.DigOutTagName.Name = "DigOutTagName"
        Me.DigOutTagName.Size = New System.Drawing.Size(100, 23)
        '
        'DigOutDBLogging
        '
        Me.DigOutDBLogging.Name = "DigOutDBLogging"
        Me.DigOutDBLogging.Size = New System.Drawing.Size(160, 22)
        Me.DigOutDBLogging.Text = "DB Logging"
        '
        'Forcing
        '
        Me.Forcing.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ForceOn, Me.ForceOff})
        Me.Forcing.Name = "Forcing"
        Me.Forcing.Size = New System.Drawing.Size(160, 22)
        Me.Forcing.Text = "Forcing"
        '
        'ForceOn
        '
        Me.ForceOn.Name = "ForceOn"
        Me.ForceOn.Size = New System.Drawing.Size(123, 22)
        Me.ForceOn.Text = "Force On"
        '
        'ForceOff
        '
        Me.ForceOff.Name = "ForceOff"
        Me.ForceOff.Size = New System.Drawing.Size(123, 22)
        Me.ForceOff.Text = "Force Off"
        '
        'AnaOutForce
        '
        Me.AnaOutForce.AccessibleName = "AnaOutForce"
        Me.AnaOutForce.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.AnaOutForce.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnaOutTagName, Me.AnaOutDBLogging, Me.AnaOutAutomatic, Me.AnaOutForceOn})
        Me.AnaOutForce.Name = "AnaOutForce"
        Me.AnaOutForce.Size = New System.Drawing.Size(161, 95)
        '
        'AnaOutTagName
        '
        Me.AnaOutTagName.BackColor = System.Drawing.SystemColors.Info
        Me.AnaOutTagName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.AnaOutTagName.Name = "AnaOutTagName"
        Me.AnaOutTagName.Size = New System.Drawing.Size(100, 23)
        '
        'AnaOutDBLogging
        '
        Me.AnaOutDBLogging.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Intervalx01SecToolStripMenuItem1})
        Me.AnaOutDBLogging.Name = "AnaOutDBLogging"
        Me.AnaOutDBLogging.Size = New System.Drawing.Size(160, 22)
        Me.AnaOutDBLogging.Text = "DB Logging"
        '
        'Intervalx01SecToolStripMenuItem1
        '
        Me.Intervalx01SecToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnaOutDBInterval, Me.SetAnaOutDBInterval})
        Me.Intervalx01SecToolStripMenuItem1.Name = "Intervalx01SecToolStripMenuItem1"
        Me.Intervalx01SecToolStripMenuItem1.Size = New System.Drawing.Size(162, 22)
        Me.Intervalx01SecToolStripMenuItem1.Text = "Interval (x0,1Sec)"
        '
        'AnaOutDBInterval
        '
        Me.AnaOutDBInterval.Name = "AnaOutDBInterval"
        Me.AnaOutDBInterval.Size = New System.Drawing.Size(100, 23)
        Me.AnaOutDBInterval.Text = "0010"
        Me.AnaOutDBInterval.ToolTipText = "Poll interval between 1..9999 (x0,1Sec)"
        '
        'SetAnaOutDBInterval
        '
        Me.SetAnaOutDBInterval.Name = "SetAnaOutDBInterval"
        Me.SetAnaOutDBInterval.Size = New System.Drawing.Size(160, 22)
        Me.SetAnaOutDBInterval.Text = "set poll interval"
        '
        'AnaOutAutomatic
        '
        Me.AnaOutAutomatic.Name = "AnaOutAutomatic"
        Me.AnaOutAutomatic.Size = New System.Drawing.Size(160, 22)
        Me.AnaOutAutomatic.Text = "Automatic"
        '
        'AnaOutForceOn
        '
        Me.AnaOutForceOn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnaOutForceValue, Me.Force})
        Me.AnaOutForceOn.Name = "AnaOutForceOn"
        Me.AnaOutForceOn.Size = New System.Drawing.Size(160, 22)
        Me.AnaOutForceOn.Text = "Force Output"
        '
        'AnaOutForceValue
        '
        Me.AnaOutForceValue.AutoToolTip = True
        Me.AnaOutForceValue.Name = "AnaOutForceValue"
        Me.AnaOutForceValue.Size = New System.Drawing.Size(100, 23)
        Me.AnaOutForceValue.ToolTipText = "Value between 0..255"
        '
        'Force
        '
        Me.Force.Name = "Force"
        Me.Force.Size = New System.Drawing.Size(160, 22)
        Me.Force.Text = "Force"
        '
        'ServoForce
        '
        Me.ServoForce.AccessibleName = "ServoForce"
        Me.ServoForce.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ServoForce.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ServoTagName, Me.ServoAutomatic, Me.ToolStripMenuItem2})
        Me.ServoForce.Name = "AnaOutForce"
        Me.ServoForce.Size = New System.Drawing.Size(161, 73)
        '
        'ServoTagName
        '
        Me.ServoTagName.BackColor = System.Drawing.SystemColors.Info
        Me.ServoTagName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ServoTagName.Name = "ServoTagName"
        Me.ServoTagName.Size = New System.Drawing.Size(100, 23)
        Me.ServoTagName.Text = "Tagname"
        '
        'ServoAutomatic
        '
        Me.ServoAutomatic.Name = "ServoAutomatic"
        Me.ServoAutomatic.Size = New System.Drawing.Size(160, 22)
        Me.ServoAutomatic.Text = "Automatic"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ServoForceValue, Me.ServoForceOn})
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(160, 22)
        Me.ToolStripMenuItem2.Text = "Force Output"
        '
        'ServoForceValue
        '
        Me.ServoForceValue.AutoToolTip = True
        Me.ServoForceValue.Name = "ServoForceValue"
        Me.ServoForceValue.Size = New System.Drawing.Size(100, 23)
        Me.ServoForceValue.ToolTipText = "Angle between 0..180"
        '
        'ServoForceOn
        '
        Me.ServoForceOn.Name = "ServoForceOn"
        Me.ServoForceOn.Size = New System.Drawing.Size(160, 22)
        Me.ServoForceOn.Text = "Force"
        '
        'Retry
        '
        Me.Retry.Enabled = True
        Me.Retry.Interval = 150
        '
        'TTMask
        '
        Me.TTMask.AccessibleName = "TTMask"
        Me.TTMask.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.TTMask.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TTTagName, Me.TTDBLogging, Me.TTAutomatic, Me.TTMaskOn})
        Me.TTMask.Name = "TTMask"
        Me.TTMask.Size = New System.Drawing.Size(161, 95)
        '
        'TTTagName
        '
        Me.TTTagName.BackColor = System.Drawing.SystemColors.Info
        Me.TTTagName.Name = "TTTagName"
        Me.TTTagName.Size = New System.Drawing.Size(100, 23)
        '
        'TTDBLogging
        '
        Me.TTDBLogging.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Intervalx01SecToolStripMenuItem})
        Me.TTDBLogging.Name = "TTDBLogging"
        Me.TTDBLogging.Size = New System.Drawing.Size(160, 22)
        Me.TTDBLogging.Text = "DB Logging"
        '
        'Intervalx01SecToolStripMenuItem
        '
        Me.Intervalx01SecToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TTDBInterval, Me.SetTTDBInterval})
        Me.Intervalx01SecToolStripMenuItem.Name = "Intervalx01SecToolStripMenuItem"
        Me.Intervalx01SecToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.Intervalx01SecToolStripMenuItem.Text = "Interval(x0,1Sec)"
        '
        'TTDBInterval
        '
        Me.TTDBInterval.Name = "TTDBInterval"
        Me.TTDBInterval.Size = New System.Drawing.Size(100, 23)
        Me.TTDBInterval.ToolTipText = "Poll interval between 1..9999 (x0,1Sec)"
        '
        'SetTTDBInterval
        '
        Me.SetTTDBInterval.Name = "SetTTDBInterval"
        Me.SetTTDBInterval.Size = New System.Drawing.Size(160, 22)
        Me.SetTTDBInterval.Text = "Set poll interval"
        '
        'TTAutomatic
        '
        Me.TTAutomatic.Name = "TTAutomatic"
        Me.TTAutomatic.Size = New System.Drawing.Size(160, 22)
        Me.TTAutomatic.Text = "Remove mask"
        '
        'TTMaskOn
        '
        Me.TTMaskOn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TTValue, Me.TTSetMask})
        Me.TTMaskOn.Name = "TTMaskOn"
        Me.TTMaskOn.Size = New System.Drawing.Size(160, 22)
        Me.TTMaskOn.Text = "Mask"
        '
        'TTValue
        '
        Me.TTValue.AutoToolTip = True
        Me.TTValue.Name = "TTValue"
        Me.TTValue.Size = New System.Drawing.Size(100, 23)
        Me.TTValue.ToolTipText = "Set mask temperature -50..125"
        '
        'TTSetMask
        '
        Me.TTSetMask.Name = "TTSetMask"
        Me.TTSetMask.Size = New System.Drawing.Size(160, 22)
        Me.TTSetMask.Text = "Set mask"
        '
        'Manual
        '
        Me.Manual.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.Manual.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.Manual.ClientSize = New System.Drawing.Size(400, 300)
        Me.Manual.Enabled = True
        Me.Manual.Icon = CType(resources.GetObject("Manual.Icon"), System.Drawing.Icon)
        Me.Manual.Name = "PrintPreviewDialog1"
        Me.Manual.Visible = False
        '
        'WatchDog
        '
        Me.WatchDog.Enabled = True
        Me.WatchDog.Interval = 2000
        '
        'TextForce
        '
        Me.TextForce.AccessibleName = "TextForce"
        Me.TextForce.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.TextForce.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MKTagName, Me.TextAutomatic, Me.ToolStripMenuItem3})
        Me.TextForce.Name = "AnaOutForce"
        Me.TextForce.Size = New System.Drawing.Size(161, 73)
        '
        'MKTagName
        '
        Me.MKTagName.BackColor = System.Drawing.SystemColors.Info
        Me.MKTagName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.MKTagName.Name = "MKTagName"
        Me.MKTagName.Size = New System.Drawing.Size(100, 23)
        '
        'TextAutomatic
        '
        Me.TextAutomatic.Name = "TextAutomatic"
        Me.TextAutomatic.Size = New System.Drawing.Size(160, 22)
        Me.TextAutomatic.Text = "Automatic"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MKForceValue, Me.MKForce})
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(160, 22)
        Me.ToolStripMenuItem3.Text = "Force Output"
        '
        'MKForceValue
        '
        Me.MKForceValue.AutoToolTip = True
        Me.MKForceValue.Name = "MKForceValue"
        Me.MKForceValue.Size = New System.Drawing.Size(100, 23)
        Me.MKForceValue.ToolTipText = "Value between 0..255"
        '
        'MKForce
        '
        Me.MKForce.Name = "MKForce"
        Me.MKForce.Size = New System.Drawing.Size(160, 22)
        Me.MKForce.Text = "Force"
        '
        'ToolTips
        '
        Me.ToolTips.AutomaticDelay = 10
        Me.ToolTips.AutoPopDelay = 2000
        Me.ToolTips.InitialDelay = 10
        Me.ToolTips.ReshowDelay = 2
        Me.ToolTips.ShowAlways = True
        '
        'FreeMemory
        '
        Me.FreeMemory.BackColor = System.Drawing.SystemColors.ControlLight
        Me.FreeMemory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FreeMemory.Location = New System.Drawing.Point(10, 239)
        Me.FreeMemory.Margin = New System.Windows.Forms.Padding(2)
        Me.FreeMemory.Name = "FreeMemory"
        Me.FreeMemory.Size = New System.Drawing.Size(128, 20)
        Me.FreeMemory.TabIndex = 32
        Me.FreeMemory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTips.SetToolTip(Me.FreeMemory, "Free RAM polled every 15 sec.")
        '
        'CycleTime
        '
        Me.CycleTime.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CycleTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CycleTime.Location = New System.Drawing.Point(76, 262)
        Me.CycleTime.Margin = New System.Windows.Forms.Padding(2)
        Me.CycleTime.Name = "CycleTime"
        Me.CycleTime.Size = New System.Drawing.Size(61, 20)
        Me.CycleTime.TabIndex = 33
        Me.CycleTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTips.SetToolTip(Me.CycleTime, "Measured average 1200 cycles polled every 15 sec")
        '
        'TimeStamp
        '
        Me.TimeStamp.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TimeStamp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TimeStamp.Location = New System.Drawing.Point(10, 285)
        Me.TimeStamp.Margin = New System.Windows.Forms.Padding(2)
        Me.TimeStamp.Name = "TimeStamp"
        Me.TimeStamp.Size = New System.Drawing.Size(128, 20)
        Me.TimeStamp.TabIndex = 35
        Me.TimeStamp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTips.SetToolTip(Me.TimeStamp, "Polled every 30 sec by HMI")
        '
        'FSMBox
        '
        Me.FSMBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FSMBox.FormattingEnabled = True
        Me.FSMBox.Location = New System.Drawing.Point(10, 16)
        Me.FSMBox.Margin = New System.Windows.Forms.Padding(2)
        Me.FSMBox.Name = "FSMBox"
        Me.FSMBox.Size = New System.Drawing.Size(128, 212)
        Me.FSMBox.TabIndex = 29
        Me.ToolTips.SetToolTip(Me.FSMBox, "State overview; when checked active")
        '
        'SyncTimeBoardTimer
        '
        Me.SyncTimeBoardTimer.Enabled = True
        Me.SyncTimeBoardTimer.Interval = 180000
        '
        'AfterStartup
        '
        Me.AfterStartup.Enabled = True
        Me.AfterStartup.Interval = 1000
        '
        'ActualStates
        '
        Me.ActualStates.Enabled = True
        Me.ActualStates.Interval = 10000
        '
        'CycleTimer
        '
        Me.CycleTimer.Enabled = True
        Me.CycleTimer.Interval = 15000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 265)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Cycle time"
        '
        'FreeRam
        '
        Me.FreeRam.Enabled = True
        Me.FreeRam.Interval = 15000
        '
        'GetTime
        '
        Me.GetTime.Enabled = True
        Me.GetTime.Interval = 30000
        '
        'Monitor
        '
        Me.Monitor.BackColor = System.Drawing.Color.Silver
        Me.Monitor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Monitor.Controls.Add(Me.Label2)
        Me.Monitor.Controls.Add(Me.ResetButton)
        Me.Monitor.Controls.Add(Me.Label6)
        Me.Monitor.Controls.Add(Me.ProgressBar2)
        Me.Monitor.Controls.Add(Me.Label4)
        Me.Monitor.Controls.Add(Me.ProgressBar1)
        Me.Monitor.Controls.Add(Me.CommicationPort)
        Me.Monitor.Controls.Add(Me.TimeStamp)
        Me.Monitor.Controls.Add(Me.DBImage)
        Me.Monitor.Controls.Add(Me.DATALOGGER)
        Me.Monitor.Controls.Add(Me.SendToArduino)
        Me.Monitor.Controls.Add(Me.Label1)
        Me.Monitor.Controls.Add(Me.CycleTime)
        Me.Monitor.Controls.Add(Me.ToArduino)
        Me.Monitor.Controls.Add(Me.FreeMemory)
        Me.Monitor.Controls.Add(Me.FSMBox)
        Me.Monitor.Location = New System.Drawing.Point(9, 32)
        Me.Monitor.Margin = New System.Windows.Forms.Padding(2)
        Me.Monitor.Name = "Monitor"
        Me.Monitor.Padding = New System.Windows.Forms.Padding(2)
        Me.Monitor.Size = New System.Drawing.Size(151, 475)
        Me.Monitor.TabIndex = 36
        Me.Monitor.TabStop = False
        Me.Monitor.Text = "Dashboard"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 350)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Board reset"
        '
        'ResetButton
        '
        Me.ResetButton.BackColor = System.Drawing.Color.Red
        Me.ResetButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResetButton.ForeColor = System.Drawing.Color.Yellow
        Me.ResetButton.Location = New System.Drawing.Point(74, 348)
        Me.ResetButton.Margin = New System.Windows.Forms.Padding(2)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(63, 25)
        Me.ResetButton.TabIndex = 42
        Me.ResetButton.Text = "Reset"
        Me.ResetButton.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 329)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Retry que"
        '
        'ProgressBar2
        '
        Me.ProgressBar2.BackColor = System.Drawing.Color.Gainsboro
        Me.ProgressBar2.ForeColor = System.Drawing.Color.Red
        Me.ProgressBar2.Location = New System.Drawing.Point(76, 329)
        Me.ProgressBar2.Margin = New System.Windows.Forms.Padding(2)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(61, 9)
        Me.ProgressBar2.Step = 1
        Me.ProgressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar2.TabIndex = 41
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 309)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Mail RX"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.Gainsboro
        Me.ProgressBar1.ForeColor = System.Drawing.Color.Green
        Me.ProgressBar1.Location = New System.Drawing.Point(76, 309)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(2)
        Me.ProgressBar1.Maximum = 20
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(61, 9)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 40
        '
        'DBImage
        '
        Me.DBImage.Image = Global.WindowsApplication1.My.Resources.Resources._1486063050_database_edit
        Me.DBImage.Location = New System.Drawing.Point(116, 438)
        Me.DBImage.Margin = New System.Windows.Forms.Padding(2)
        Me.DBImage.Name = "DBImage"
        Me.DBImage.Size = New System.Drawing.Size(22, 23)
        Me.DBImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.DBImage.TabIndex = 40
        Me.DBImage.TabStop = False
        Me.DBImage.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(200, 494)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(169, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Transport Label NEVER DELETE "
        Me.Label3.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Main})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(583, 24)
        Me.MenuStrip1.TabIndex = 39
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Main
        '
        Me.Main.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox1})
        Me.Main.Name = "Main"
        Me.Main.ShortcutKeyDisplayString = ""
        Me.Main.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.Main.Size = New System.Drawing.Size(46, 20)
        Me.Main.Text = "Main"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 23)
        Me.ToolStripTextBox1.Text = "Digital Logger"
        '
        'CheckNoDB
        '
        Me.CheckNoDB.Enabled = True
        Me.CheckNoDB.Interval = 10000
        '
        'ClearFSMStates
        '
        Me.ClearFSMStates.Enabled = True
        Me.ClearFSMStates.Interval = 120000
        '
        'HistorianRAW
        '
        Me.HistorianRAW.DataMember = "RAW"
        Me.HistorianRAW.DataSource = Me.HistorianDataSet
        '
        'HistorianDataSet
        '
        Me.HistorianDataSet.DataSetName = "HistorianDataSet"
        Me.HistorianDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RAW
        '
        Me.RAW.ClearBeforeFill = True
        '
        'HistorianTAGS
        '
        Me.HistorianTAGS.DataMember = "Tags"
        Me.HistorianTAGS.DataSource = Me.HistorianDataSet
        '
        'TAGS
        '
        Me.TAGS.ClearBeforeFill = True
        '
        'HistorianApplications
        '
        Me.HistorianApplications.DataMember = "Applications"
        Me.HistorianApplications.DataSource = Me.HistorianDataSet
        '
        'Applications
        '
        Me.Applications.ClearBeforeFill = True
        '
        'Standard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(583, 545)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Monitor)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TransportLabel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Standard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AFSM HMI"
        Me.DigInMask.ResumeLayout(False)
        Me.DigInMask.PerformLayout()
        Me.AnaInMask.ResumeLayout(False)
        Me.AnaInMask.PerformLayout()
        Me.UltrasonicMask.ResumeLayout(False)
        Me.UltrasonicMask.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.DigOutForce.ResumeLayout(False)
        Me.DigOutForce.PerformLayout()
        Me.AnaOutForce.ResumeLayout(False)
        Me.AnaOutForce.PerformLayout()
        Me.ServoForce.ResumeLayout(False)
        Me.ServoForce.PerformLayout()
        Me.TTMask.ResumeLayout(False)
        Me.TTMask.PerformLayout()
        Me.TextForce.ResumeLayout(False)
        Me.TextForce.PerformLayout()
        Me.Monitor.ResumeLayout(False)
        Me.Monitor.PerformLayout()
        CType(Me.DBImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.HistorianRAW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HistorianDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HistorianTAGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HistorianApplications, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents TransportLabel As System.Windows.Forms.Label
    Friend WithEvents ToArduino As System.Windows.Forms.TextBox
    Friend WithEvents SendToArduino As System.Windows.Forms.Button
    Friend WithEvents CommicationPort As System.Windows.Forms.Label
    Friend WithEvents Arduino As System.IO.Ports.SerialPort
    Friend WithEvents Mega2560 As System.IO.Ports.SerialPort
    Friend WithEvents Mega2560Port As System.IO.Ports.SerialPort
    Friend WithEvents TimerSendGMI As System.Windows.Forms.Timer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents DigInMask As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AnaInMask As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Retry As System.Windows.Forms.Timer
    Friend WithEvents AnalogueAutomatic As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnalogueMaskOn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnalogueMaskValue As System.Windows.Forms.ToolStripTextBox
    Private WithEvents DigOutForce As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents UltrasonicMask As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents UltrasonicAutomatic As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltrasonicMaskOn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltrasonicValue As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents TTMask As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TTAutomatic As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TTMaskOn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TTValue As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents TTSetMask As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltrasonicSetMask As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnalogueSetMask As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnaOutAutomatic As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnaOutForceOn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnaOutForceValue As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Force As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnaOutForce As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DigOutTagName As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents TTTagName As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents UltrasonicTagName As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents AnaOutTagName As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents AnaInTagName As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Manual As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents ServoForce As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ServoAutomatic As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServoForceValue As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ServoForceOn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServoTagName As System.Windows.Forms.ToolStripTextBox
    Private WithEvents DATALOGGER As System.Windows.Forms.Label
    Friend WithEvents WatchDog As System.Windows.Forms.Timer
    Friend WithEvents TextForce As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MKTagName As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents TextAutomatic As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MKForceValue As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents MKForce As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTips As System.Windows.Forms.ToolTip
    Friend WithEvents SyncTimeBoardTimer As System.Windows.Forms.Timer
    Friend WithEvents AfterStartup As System.Windows.Forms.Timer
    Friend WithEvents FSMBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents ActualStates As System.Windows.Forms.Timer
    Friend WithEvents FreeMemory As System.Windows.Forms.TextBox
    Friend WithEvents CycleTime As System.Windows.Forms.TextBox
    Friend WithEvents CycleTimer As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FreeRam As System.Windows.Forms.Timer
    Friend WithEvents TimeStamp As System.Windows.Forms.TextBox
    Friend WithEvents GetTime As System.Windows.Forms.Timer
    Friend WithEvents Monitor As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents Main As ToolStripMenuItem
    Friend WithEvents ToolStripTextBox1 As ToolStripTextBox
    Friend WithEvents ResetButton As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents DigInDBLogging As ToolStripMenuItem
    Friend WithEvents DigInTagName As ToolStripTextBox
    Friend WithEvents HistorianRAW As BindingSource
    Friend WithEvents HistorianDataSet As HistorianDataSet
    Friend WithEvents RAW As HistorianDataSetTableAdapters.RAWTableAdapter
    Friend WithEvents HistorianTAGS As BindingSource
    Friend WithEvents TAGS As HistorianDataSetTableAdapters.TagsTableAdapter
    Friend WithEvents Masking As ToolStripMenuItem
    Friend WithEvents DigInMaskOn As ToolStripMenuItem
    Friend WithEvents DigInMaskOff As ToolStripMenuItem
    Friend WithEvents DigOutDBLogging As ToolStripMenuItem
    Friend WithEvents Forcing As ToolStripMenuItem
    Friend WithEvents ForceOn As ToolStripMenuItem
    Friend WithEvents ForceOff As ToolStripMenuItem
    Friend WithEvents DBImage As PictureBox
    Friend WithEvents CheckNoDB As Timer
    Friend WithEvents HistorianApplications As BindingSource
    Friend WithEvents Applications As HistorianDataSetTableAdapters.ApplicationsTableAdapter
    Friend WithEvents AnaInDBLogging As ToolStripMenuItem
    Friend WithEvents TTDBLogging As ToolStripMenuItem
    Friend WithEvents AnaOutDBLogging As ToolStripMenuItem
    Friend WithEvents ClearFSMStates As Timer
    Friend WithEvents IntervalmSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AnaInDBInterval As ToolStripTextBox
    Friend WithEvents SetAnaInDBInterval As ToolStripMenuItem
    Friend WithEvents Intervalx01SecToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TTDBInterval As ToolStripTextBox
    Friend WithEvents SetTTDBInterval As ToolStripMenuItem
    Friend WithEvents Intervalx01SecToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents AnaOutDBInterval As ToolStripTextBox
    Friend WithEvents SetAnaOutDBInterval As ToolStripMenuItem
End Class
