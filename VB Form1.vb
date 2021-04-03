

Imports System.IO.Ports
Imports System.Threading


'Arduino Finite State Machine
'Copyright(C) 2018 Jelle Siemonsma

'This program Is free software : you can redistribute it And/Or modify
'it under the terms Of the GNU General Public License As published by
'the Free Software Foundation, either version 3 Of the License, Or
'(at your option) any later version.

'This program Is distributed In the hope that it will be useful,
'but WITHOUT ANY WARRANTY; without even the implied warranty Of
'MERCHANTABILITY Or FITNESS FOR A PARTICULAR PURPOSE.See the
'GNU General Public License For more details.

'<https://www.gnu.org/licenses/>.


Public Class Standard

    Private PV1old As Integer = 0
    Private PV2old As Integer = 0
    Private PenUp As Boolean
    Private PenColor As System.Drawing.Pens
    Private Ticker As Boolean = True
    Private ToolTipsOn As Boolean = False
    Private LiveCounter As Integer = 0
    Private CurrMessageCount As Integer = 0


    Public Structure MessageQueType
        Public Id As Integer
        Public Message As String
        Public Retry As Integer
    End Structure

    Public CurrMessageQue As New LinkedList(Of MessageQueType)
    Public CurrMessageNode As LinkedListNode(Of MessageQueType)
    Public QueMessage As MessageQueType
    Public OldTagNo As Integer
    Public NoOfCtrl As Integer
    Public Offset As Integer
    Public TagOffset As Integer
    Public PageOffset As Integer
    Public TopOffset As Integer
    Public Kolom As Integer
    Public ListLen As Integer
    Public Meting As Integer
    Public BWStop As Boolean
    Public MessageIdNumber As Integer
    Public Minimum As Integer
    Public Maximum As Integer
    Public OnderMinimum As Integer
    Public OverMaximum As Integer
    Public NoInformational As Integer
    Public ApplicationName As String
    Public NoDBItems As Integer
    Public MakeFields As Boolean




    Public Function UnixTimestampToDateTime(ByVal _UnixTimeStamp As Long) As DateTime
        Return (New DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds(_UnixTimeStamp)
    End Function

    Public Class ArgumentType
        Public Fetch As String
    End Class

    'Private Lock As New ReaderWriterLockSlim()
    Private Shared Iglo As New Mutex()

    'Communication between the background and the foreground is made by text control Transport. NEVER DELETE this thinny control on the main form.
    'Changes of Transport.text are done by sub ToForeGround.

    Private Sub Transport(ByVal [text] As String)


        If Me.TransportLabel.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf Transport)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.TransportLabel.Text = [text]
        End If

    End Sub



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'TODO: This line of code loads data into the 'HistorianDataSet.Applications' table. You can move, or remove it, as needed.
        ' Me.Applications.Fill(Me.HistorianDataSet.Applications)
        'TODO: This line of code loads data into the 'HistorianDataSet.Tags' table. You can move, or remove it, as needed.
        'Me.TAGS.Fill(Me.HistorianDataSet.Tags)
        'TODO: This line of code loads data into the 'HistorianDataSet.RAW' table. You can move, or remove it, as needed.
        'Me.RAW.Fill(Me.HistorianDataSet.RAW)

        ApplicationName = Me.Text

        'Only thing to do is sending the @GMI command to fill up the list.. and than wait for the board to fill it
        'This command is given after starting the backupworker.
        'After receiving the @GMI respons, the Tags list is filled with all known tags on the board.
        'Now the program is able to send poll messages or change request messages for all fields also present on the form. Jahoo, the form is dynamic!   

        Dim ComPort As String
        Dim BaudRate As Integer
        Dim Monitor As String
        Dim ComPortDefault As String = ""
        Dim BaudRateDefault As String = ""
        Dim MonitorDefault As String = "No"

        Dim inputArgument1 As String = "/comport="
        Dim inputArgument2 As String = "/baudrate="
        Dim inputArgument3 As String = "/monitor="
        Dim inputName As String = ""

        ComPort = ""
        BaudRate = 0
        Monitor = "NO"

        For Each s As String In My.Application.CommandLineArgs
            If s.ToLower.StartsWith(inputArgument1) Then
                ComPort = s.Remove(0, inputArgument1.Length)
            End If
            If s.ToLower.StartsWith(inputArgument2) Then
                BaudRate = s.Remove(0, inputArgument2.Length)
            End If
            If s.ToLower.StartsWith(inputArgument3) Then
                Monitor = s.Remove(0, inputArgument3.Length)
            End If
        Next

        PenUp = True

        If ComPort = "" Then
            ComPort = "COM5"
            ComPortDefault = "*"
        End If

        If BaudRate = 0 Then
            BaudRate = 9600
            BaudRateDefault = "*"
        End If

        If Monitor = "YES" Then
            MakeFields = True
        Else
            MakeFields = False
        End If



        CommicationPort.Text = ComPort + ComPortDefault + " " + Str(BaudRate) + BaudRateDefault
        Mega2560Port.PortName = ComPort 'change com port to match your Arduino port
        Mega2560Port.BaudRate = BaudRate
        Mega2560Port.DataBits = 8
        Mega2560Port.Parity = Parity.None
        Mega2560Port.StopBits = StopBits.One
        Mega2560Port.Handshake = Handshake.None


        Try
            Mega2560Port.Open()
        Catch ex As Exception
            MsgBox("%HMI-ERR-CONFAIL, Connection to MEGA2560 failed")
            MessageBox.Show(ex.Message)
        End Try

        ' Create the argument object.
        Dim args As ArgumentType = New ArgumentType()
        args.Fetch = ""

        ' Start up the BackgroundWorker1.
        ' ... Pass argument object to it. It's empty... nha... so what!
        BWStop = False
        BackgroundWorker1.RunWorkerAsync(args)

        TagNo = 0
        OldTagNo = TagNo
        NoOfCtrl = -1
        Offset = 0
        TagOffset = 40
        PageOffset = 150
        TopOffset = 35
        Kolom = 270
        ListLen = 15
        Meting = 1
        MessageIdNumber = 1000
        NoDBItems = 0
        Minimum = 1000
        Maximum = -1000
        OverMaximum = 0
        OnderMinimum = 0
        NoInformational = 0

        'Mega2560Port.WriteLine("@GMI")
        'Send the time to the board to sync. 
        SyncTimeBoard()


    End Sub

    Private Sub CloseForm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closing

        Mega2560Port.WriteLine("@CHM") 'Cancel all poll and report messages from the board.

    End Sub



    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim returnValue As Char
        Dim Tstring As String
        Dim CR As Char = ChrW(13)
        Dim LF As Char = ChrW(10)

        Dim args As ArgumentType = e.Argument
        'Return value based on the argument.
        Tstring = ""

        Do While True

            Try

                returnValue = ChrW(Mega2560Port.ReadChar)

                If returnValue = "@" Then 'Reply command control
                    returnValue = ChrW(Mega2560Port.ReadChar)
                    Do While returnValue <> LF
                        Tstring = Tstring + returnValue
                        returnValue = ChrW(Mega2560Port.ReadChar)
                    Loop
                    'Get the info from the background worker to the main thread
                    Tstring = "@" + Tstring
                    Transport(Tstring)
                    Tstring = ""
                End If

                'let the foreground play... if there is something to do
                'Thread.Sleep(10)

            Catch ex As Exception
            End Try


        Loop

    End Sub

    Private Sub HandleMessage(ByVal Message As String, ByVal Action As Integer, ByVal Id As Integer)

        CurrMessageCount = CurrMessageQue.Count
        If CurrMessageCount > ProgressBar2.Maximum Then CurrMessageCount = ProgressBar2.Maximum
        ProgressBar2.Value = Str(CurrMessageCount)
        If CurrMessageCount > 0 Then ProgressBar2.ForeColor = Color.DarkGray
        If CurrMessageCount > 30 Then ProgressBar2.ForeColor = Color.Orange
        If CurrMessageCount > 60 Then ProgressBar2.ForeColor = Color.Red

        Try

            Select Case Action
                Case 1

                    ' send to Arduino
                    MessageIdNumber = MessageIdNumber + 1
                    If MessageIdNumber > 9999 Then MessageIdNumber = 1000
                    QueMessage.Id = MessageIdNumber
                    QueMessage.Message = Message
                    QueMessage.Retry = 0
                    Dim MessageNode As New LinkedListNode(Of MessageQueType)(QueMessage)
                    MessageNode.Value = QueMessage
                    CurrMessageQue.AddLast(MessageNode)
                    'Message queued for administration purposes, now actual send this message with the Id number attached
                    'MsgBox("Handle message (send action): " + Message + Str(MessageIdNumber))
                    Mega2560Port.WriteLine(Message + Str(MessageIdNumber))

                Case 2

                    ' validation from Arduino received
                    If Not CurrMessageQue.First Is Nothing Then CurrMessageNode = CurrMessageQue.First
                    While (Not CurrMessageNode Is Nothing) And (CurrMessageQue.Count <> 0)
                        If CurrMessageNode.Value.Id = Id Then
                            'VBA has received the respons from arduino, so this node can be deleted form the list
                            'MsgBox("Handle message (validation): " + Str(CurrMessageNode.Value.Id) + " removed from the list")
                            CurrMessageQue.Find(CurrMessageNode.Value)
                            If CurrMessageQue.Count <> 0 Then CurrMessageQue.Remove(CurrMessageNode)
                            'ToolStripStatusLabel1.Text = "id: " + Str(Id) + " removed from queue (now " + Str(CurrMessageCount - 1) + ")"
                        End If
                        If Not CurrMessageQue.First Is Nothing Then CurrMessageNode = CurrMessageNode.Next
                    End While


                Case 3

                    ' request for retries
                    If Not CurrMessageQue.First Is Nothing Then
                        CurrMessageNode = CurrMessageQue.First
                        QueMessage.Id = CurrMessageNode.Value.Id
                        QueMessage.Retry = CurrMessageNode.Value.Retry + 1
                        QueMessage.Message = CurrMessageNode.Value.Message
                        CurrMessageNode.Value = QueMessage
                        'ToolStripStatusLabel1.Text = "message: " + QueMessage.Message + " " + Str(QueMessage.Id)
                        If CurrMessageNode.Value.Retry = 25 Then
                            'MsgBox("Failed to send message after 25 times: " + QueMessage.Message)
                            ToolStripStatusLabel1.Text = "%SNDMSG-ERR-WRITEMESSAGE, Failed to send message after 25 times: " + QueMessage.Message
                            CurrMessageQue.Find(CurrMessageNode.Value)
                            CurrMessageQue.Remove(CurrMessageNode)
                        Else
                            'ToolStripStatusLabel1.Text = "handle message (retry): " + CurrMessageNode.Value.Message + Str(CurrMessageNode.Value.Id)
                            Mega2560Port.WriteLine(QueMessage.Message + Str(QueMessage.Id))
                        End If
                    End If

            End Select

        Catch ex As Exception
            ToolStripStatusLabel1.Text = "%SNDMSG-ERR-WRITEMESSAGE, Exception sending message to board"
        End Try


    End Sub

    Private Function UnknownTag(NewTag As String) As Boolean

        Dim Index As Integer
        Dim RecordFound As Boolean
        Dim LoopTeller As Integer = TagNo - 1


        For Index = 1 To LoopTeller
            RecordFound = False
            If GeneralDeclarations.Tags(Index).Name = NewTag Then
                If GeneralDeclarations.Tags(Index).OnForm = True Then
                    RecordFound = True
                    Exit For
                End If
            End If

        Next

        Return (Not RecordFound)

    End Function

    Private Sub Logging(ByVal TagName As String, ByVal ProcesValue As String, ToolTipText As String, ToDB As Boolean, IOType As String)

        Try
            If ToDB And (DBTagName <> TagName Or DBValue <> ProcesValue) Then
                Dim newRow As DataRow = HistorianDataSet.RAW.NewRow
                newRow("DateTime") = DateTime.Now
                newRow("TagName") = TagName
                newRow("PValue") = ProcesValue
                HistorianDataSet.RAW.Rows.Add(newRow)
                RAW.Update(HistorianDataSet.RAW)
                DBTagName = TagName
                DBValue = ProcesValue
            End If

        Catch ex As Exception

            Dim foundRows() As DataRow
            Dim SearchString As String

            'Check existens of Application entry! Maybe the Application name is not yet added!
            SearchString = "Application LIKE '" & ApplicationName + "'"
            foundRows = HistorianDataSet.Applications.Select(SearchString)
            If foundRows.Length = 0 Then
                'Application does not exist! Make a new entry in the database
                Dim newAppRow As DataRow = HistorianDataSet.Applications.NewRow
                newAppRow("Application") = ApplicationName
                HistorianDataSet.Applications.Rows.Add(newAppRow)
                Applications.Update(HistorianDataSet.Applications)
            End If

            'Check existens of TAGS! Possible missing TAG (add a new one)!
            SearchString = "TagName LIKE '" & TagName + "'"
            foundRows = HistorianDataSet.Tags.Select(SearchString)
            If foundRows.Length = 0 Then
                'Tagname does not exist! Make a new entry in the database
                Dim newTagRow As DataRow = HistorianDataSet.Tags.NewRow
                newTagRow("TagName") = TagName
                newTagRow("Application") = ApplicationName
                newTagRow("Datatype") = IOType
                HistorianDataSet.Tags.Rows.Add(newTagRow)
                TAGS.Update(HistorianDataSet.Tags)
            End If

            ToolStripStatusLabel1.Text = "An exception caused by writing to db; missing column name. Repaired."


        End Try

        'For the plotter....
        If TagName = PVName1 Then
            PVValue1 = Int(ProcesValue)
            ToolTip1 = ToolTipText
        End If
        If TagName = PVName2 Then
            PVValue2 = Int(ProcesValue)
            ToolTip2 = ToolTipText
        End If
        If TagName = PVName3 Then
            PVValue3 = Int(ProcesValue)
            ToolTip3 = ToolTipText
        End If



    End Sub

    Private Sub SendData(ByVal Message As String)


        HandleMessage(Message, 1, 0)
        'ToolStripStatusLabel1.Text = "Message: " + Message

    End Sub


    Private Sub ToForeGround(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransportLabel.TextChanged
        'Put it in the message list

        Dim Index As Integer
        Dim Count As Integer
        Dim OneWireChannel As Integer
        Dim ForeGroundString() As String
        Dim ValidationId As Integer

        LiveCounter = LiveCounter + 1
        If LiveCounter = ProgressBar1.Maximum Then
            LiveCounter = ProgressBar1.Minimum
        End If
        ProgressBar1.Value = LiveCounter


        ' Create the argument object.
        Dim args As ArgumentType = New ArgumentType()
        args.Fetch = ""

        'Processing of all strings comming from the screen and the background is done here!!
        ForeGroundString = Split(TransportLabel.Text, ",")



        'Validation message received from arduino
        If ForeGroundString(0) = "@VAL" Then
            ValidationId = Val(ForeGroundString(1))
            HandleMessage("", 2, Int(ValidationId))
            'MsgBox("Foreground (validation): id=" + Str(ValidationId))
        End If


        'GMI Digital (inputs)
        If ForeGroundString(0) = "@GMIDI" Then
            Count = Val(ForeGroundString(1))
            For I = 1 To Count

                'Haal de tagnaam uit de string en zet hem in de linked list
                TagRec.IOtype = "DI"
                TagRec.Name = ForeGroundString(2 + (I - 1) * 5)
                TagRec.Pin = ForeGroundString(3 + (I - 1) * 5)
                TagRec.OnForm = False

                OldTagNo = TagNo
                Index = -1
                For Each Items In Me.Controls
                    Index = Index + 1
                    If (Items.GetType() Is GetType(TextBox)) Then
                        Dim txt As TextBox = CType(Items, TextBox)
                        If txt.Name = TagRec.Name And UnknownTag(txt.Name) Then
                            txt.ReadOnly = True
                            TagRec.RO = True
                            TagNo = TagNo + 1
                            'ToolStripStatusLabel1.Text = TagRec.Name + " is present on this form, ask for updates!"
                            Me.Controls.Item(Index).BackColor = Color.LightGray
                            ' Me.Controls.Item(Index).ContextMenuStrip.Name = "DigInMask"
                            SendData("@RDC" + TagRec.Name)
                            SendData("@PDI0010" + TagRec.Name)
                            TagRec.FieldNo = Index
                            ToolTips.SetToolTip(Me.Controls.Item(Index), "Digital input " + TagRec.Name + ", pin no. " + Str(TagRec.Pin))
                            TagRec.TooltipText = "Digital input " + TagRec.Name + ", pin no. " + Str(TagRec.Pin)
                            GeneralDeclarations.Tags(TagNo) = TagRec
                        End If
                    End If
                Next

                'Check if the TagNo is increased, when not the case, make controls on the form
                If TagNo = OldTagNo And MakeFields And (Not TagRec.OnForm) Then
                    Dim NewText As New TextBox
                    Dim NewLabel As New Label
                    NoOfCtrl = NoOfCtrl + 1
                    Me.Width = 150 + Kolom * (NoOfCtrl \ ListLen + 1)
                    Offset = PageOffset + 250 * (NoOfCtrl \ ListLen)
                    NewText.Name = TagRec.Name
                    NewText.ContextMenuStrip = DigInMask
                    NewText.TextAlign = HorizontalAlignment.Center
                    NewText.Left = 150 + Offset
                    NewText.Top = TopOffset + (NoOfCtrl Mod ListLen) * 30
                    Me.Controls.Add(NewText)
                    NewLabel.Text = "DI:" + TagRec.Name
                    NewLabel.Left = TagOffset + Offset
                    NewLabel.Top = TopOffset + (NoOfCtrl Mod ListLen) * 30
                    NewLabel.BorderStyle = BorderStyle.Fixed3D
                    NewLabel.BackColor = Color.Silver
                    NewLabel.Height = 20
                    Me.Controls.Add(NewLabel)
                End If

            Next
        End If

        'GMI Digital (Outputs)
        If ForeGroundString(0) = "@GMIDO" Then
            Count = Val(ForeGroundString(1))
            For I = 1 To Count

                'Haal de tagnaam uit de string en zet hem in de linked list
                TagRec.IOtype = "DO"
                TagRec.Name = ForeGroundString(2 + (I - 1) * 5)
                TagRec.OnForm = False
                TagRec.Pin = ForeGroundString(3 + (I - 1) * 5)

                OldTagNo = TagNo
                Index = -1
                For Each Items In Me.Controls
                    Index = Index + 1
                    If (Items.GetType() Is GetType(TextBox)) Then
                        Dim txt As TextBox = CType(Items, TextBox)
                        If txt.Name = TagRec.Name And UnknownTag(txt.Name) Then
                            txt.ReadOnly = True
                            TagRec.RO = True
                            TagNo = TagNo + 1
                            'ToolStripStatusLabel1.Text = TagRec.Name + " is present on this form, ask for updates!"
                            Me.Controls.Item(Index).BackColor = Color.LightGray
                            'Me.Controls.Item(Index).ContextMenuStrip.Name = "DigOutForce"
                            SendData("@RDC" + TagRec.Name)
                            SendData("@PDI0010" + TagRec.Name)
                            TagRec.FieldNo = Index
                            'TagRec.OnForm = True
                            ToolTips.SetToolTip(Me.Controls.Item(Index), "Digital output " + TagRec.Name + ", pin no. " + Str(TagRec.Pin))
                            TagRec.TooltipText = "Digital output " + TagRec.Name + ", pin no. " + Str(TagRec.Pin)
                            GeneralDeclarations.Tags(TagNo) = TagRec
                        End If
                    End If
                Next

                'Check if the TagNo is increased, when not the case, make controls on the form
                If TagNo = OldTagNo And MakeFields And (Not TagRec.OnForm) Then
                    Dim NewText As New TextBox
                    Dim NewLabel As New Label
                    NoOfCtrl = NoOfCtrl + 1
                    Me.Width = 180 + Kolom * (NoOfCtrl \ ListLen + 1)
                    Offset = PageOffset + 250 * (NoOfCtrl \ ListLen)
                    NewText.Name = TagRec.Name
                    NewText.ContextMenuStrip = DigOutForce
                    NewText.TextAlign = HorizontalAlignment.Center
                    NewText.Left = 150 + Offset
                    NewText.Top = TopOffset + (NoOfCtrl Mod ListLen) * 30
                    Me.Controls.Add(NewText)
                    NewLabel.Text = "DO:" + TagRec.Name
                    NewLabel.Left = TagOffset + Offset
                    NewLabel.Top = TopOffset + (NoOfCtrl Mod ListLen) * 30
                    NewLabel.BorderStyle = BorderStyle.Fixed3D
                    NewLabel.BackColor = Color.Silver
                    NewLabel.Height = 20
                    Me.Controls.Add(NewLabel)
                End If

            Next
        End If


        'GMI Analogue(inputs)
        If ForeGroundString(0) = "@GMIAI" Then
            Count = Val(ForeGroundString(1))
            For I = 1 To Count
                'Haal de tagnaam uit de string en zet hem in de linked list
                TagRec.IOtype = "AI"
                TagRec.Name = ForeGroundString(2 + (I - 1) * 4)
                TagRec.Pin = ForeGroundString(3 + (I - 1) * 4)
                TagRec.OnForm = False
                OldTagNo = TagNo
                Index = -1
                For Each Items In Me.Controls
                    Index = Index + 1
                    If (Items.GetType() Is GetType(TextBox)) Then
                        Dim txt As TextBox = CType(Items, TextBox)
                        If txt.Name = TagRec.Name And UnknownTag(txt.Name) Then
                            TagNo = TagNo + 1
                            TagRec.RO = True
                            txt.ReadOnly = TagRec.RO
                            'ToolStripStatusLabel1.Text = TagRec.Name + " is present on this form, ask for updates!"
                            Me.Controls.Item(Index).BackColor = Color.LightGray
                            'Me.Controls.Item(Index).ContextMenuStrip.Name = "AnaInMask"
                            'MsgBox("ContextMenuStripName:" + Me.Controls.Item(Index).ContextMenuStrip.Name)
                            SendData("@PAI0010" + TagRec.Name)
                            'TagRec.OnForm = True
                            TagRec.FieldNo = Index
                            ToolTips.SetToolTip(Me.Controls.Item(Index), "Analogue input " + TagRec.Name + ", pin no. " + Str(TagRec.Pin))
                            TagRec.TooltipText = "Analogue input " + TagRec.Name + ", pin no. " + Str(TagRec.Pin)
                            GeneralDeclarations.Tags(TagNo) = TagRec
                        End If
                    End If
                Next

                'Check if the TagNo is increased, when not the case, make controls on the form
                If TagNo = OldTagNo And MakeFields And (Not TagRec.OnForm) Then
                    Dim NewText As New TextBox
                    Dim NewLabel As New Label
                    NoOfCtrl = NoOfCtrl + 1
                    Me.Width = 180 + Kolom * (NoOfCtrl \ ListLen + 1)
                    Offset = PageOffset + 250 * (NoOfCtrl \ ListLen)
                    NewText.Name = TagRec.Name
                    NewText.ContextMenuStrip = AnaInMask
                    NewText.TextAlign = HorizontalAlignment.Center
                    NewText.Left = 150 + Offset
                    NewText.Top = TopOffset + (NoOfCtrl Mod ListLen) * 30
                    Me.Controls.Add(NewText)
                    NewLabel.Text = "AI:" + TagRec.Name
                    NewLabel.Left = TagOffset + Offset
                    NewLabel.Top = TopOffset + (NoOfCtrl Mod ListLen) * 30
                    NewLabel.BorderStyle = BorderStyle.Fixed3D
                    NewLabel.BackColor = Color.Silver
                    NewLabel.Height = 20
                    Me.Controls.Add(NewLabel)
                End If

            Next
        End If

        'GMI Temperature(inputs)
        If ForeGroundString(0) = "@GMITT" Then
            Count = Val(ForeGroundString(1))
            OneWireChannel = Val(ForeGroundString(2))
            For I = 1 To Count
                'Haal de tagnaam uit de string en zet hem in de linked list
                TagRec.IOtype = "TT"
                TagRec.Name = ForeGroundString(3 + (I - 1) * 4)
                TagRec.Pin = ForeGroundString(4 + (I - 1) * 4)
                TagRec.OnForm = False
                OldTagNo = TagNo
                Index = -1
                For Each Items In Me.Controls
                    Index = Index + 1
                    If (Items.GetType() Is GetType(TextBox)) Then
                        Dim txt As TextBox = CType(Items, TextBox)
                        If txt.Name = TagRec.Name And UnknownTag(txt.Name) Then
                            TagNo = TagNo + 1
                            TagRec.RO = True
                            txt.ReadOnly = TagRec.RO
                            'ToolStripStatusLabel1.Text = TagRec.Name + " is present on this form, ask for updates!"
                            Me.Controls.Item(Index).BackColor = Color.LightGray
                            'Me.Controls.Item(Index).ContextMenuStrip.Name = "TTMask"
                            SendData("@PAI0010" + TagRec.Name)
                            'TagRec.OnForm = True
                            TagRec.FieldNo = Index
                            ToolTips.SetToolTip(Me.Controls.Item(Index), "Temp sensor " + TagRec.Name + " on one-wire-channel pin no." + Str(OneWireChannel) + ", device no. " + Str(TagRec.Pin))
                            TagRec.TooltipText = "Temp sensor " + TagRec.Name + " on one-wire-channel pin no." + Str(OneWireChannel) + ", device no. " + Str(TagRec.Pin)
                            GeneralDeclarations.Tags(TagNo) = TagRec
                        End If
                    End If
                Next

                'Check if the TagNo is increased, when not the case, make controls on the form
                If TagNo = OldTagNo And MakeFields And (Not TagRec.OnForm) Then
                    Dim NewText As New TextBox
                    Dim NewLabel As New Label
                    NoOfCtrl = NoOfCtrl + 1
                    Me.Width = 180 + Kolom * (NoOfCtrl \ ListLen + 1)
                    Offset = PageOffset + 250 * (NoOfCtrl \ ListLen)
                    NewText.Name = TagRec.Name
                    NewText.ContextMenuStrip = TTMask
                    NewText.TextAlign = HorizontalAlignment.Center
                    NewText.Left = 150 + Offset
                    NewText.Top = TopOffset + (NoOfCtrl Mod ListLen) * 30
                    Me.Controls.Add(NewText)
                    NewLabel.Text = "TT:" + TagRec.Name
                    NewLabel.Left = TagOffset + Offset
                    NewLabel.Top = TopOffset + (NoOfCtrl Mod ListLen) * 30
                    NewLabel.BorderStyle = BorderStyle.Fixed3D
                    NewLabel.BackColor = Color.Silver
                    NewLabel.Height = 20
                    Me.Controls.Add(NewLabel)
                End If
            Next
        End If



        'GMI Analogue(Outputs)
        If ForeGroundString(0) = "@GMIAO" Then
            Count = Val(ForeGroundString(1))
            For I = 1 To Count
                'Haal de tagnaam uit de string en zet hem in de linked list
                TagRec.IOtype = "AO"
                TagRec.Name = ForeGroundString(2 + (I - 1) * 4)
                TagRec.Pin = ForeGroundString(3 + (I - 1) * 4)
                TagRec.OnForm = False
                OldTagNo = TagNo
                Index = -1
                For Each Items In Me.Controls
                    Index = Index + 1
                    If (Items.GetType() Is GetType(TextBox)) Then
                        Dim txt As TextBox = CType(Items, TextBox)
                        If txt.Name = TagRec.Name And UnknownTag(txt.Name) Then
                            TagNo = TagNo + 1
                            TagRec.RO = True
                            txt.ReadOnly = TagRec.RO
                            'ToolStripStatusLabel1.Text = TagRec.Name + " is present on this form, ask for updates!"
                            Me.Controls.Item(Index).BackColor = Color.LightGray
                            'Me.Controls.Item(Index).ContextMenuStrip.Name = "AnaOutForce"
                            SendData("@PAI0010" + TagRec.Name)
                            'TagRec.OnForm = True
                            TagRec.FieldNo = Index
                            ToolTips.SetToolTip(Me.Controls.Item(Index), "PWM Output " + TagRec.Name + ", pin no. " + Str(TagRec.Pin))
                            TagRec.TooltipText = "PWM Output " + TagRec.Name + ", pin no. " + Str(TagRec.Pin)
                            GeneralDeclarations.Tags(TagNo) = TagRec
                        End If
                    End If
                Next

                'Check if the TagNo is increased, when not the case, make controls on the form
                If TagNo = OldTagNo And MakeFields And (Not TagRec.OnForm) Then
                    Dim NewText As New TextBox
                    Dim NewLabel As New Label
                    NoOfCtrl = NoOfCtrl + 1
                    Me.Width = 180 + Kolom * (NoOfCtrl \ ListLen + 1)
                    Offset = PageOffset + 250 * (NoOfCtrl \ ListLen)
                    NewText.Name = TagRec.Name
                    NewText.ContextMenuStrip = AnaOutForce
                    NewText.TextAlign = HorizontalAlignment.Center
                    NewText.Left = 150 + Offset
                    NewText.Top = TopOffset + (NoOfCtrl Mod ListLen) * 30
                    Me.Controls.Add(NewText)
                    NewLabel.Text = "AO:" + TagRec.Name
                    NewLabel.Left = TagOffset + Offset
                    NewLabel.Top = TopOffset + (NoOfCtrl Mod ListLen) * 30
                    NewLabel.BorderStyle = BorderStyle.Fixed3D
                    NewLabel.BackColor = Color.Silver
                    NewLabel.Height = 20
                    Me.Controls.Add(NewLabel)
                End If

            Next
        End If

        'GMI Servo's
        If ForeGroundString(0) = "@GMISO" Then
            Count = Val(ForeGroundString(1))
            For I = 1 To Count
                'Haal de tagnaam uit de string en zet hem in de linked list
                TagRec.IOtype = "SO"
                TagRec.Name = ForeGroundString(2 + (I - 1) * 4)
                TagRec.Pin = ForeGroundString(3 + (I - 1) * 4)
                TagRec.OnForm = False
                OldTagNo = TagNo
                Index = -1
                For Each Items In Me.Controls
                    Index = Index + 1
                    If (Items.GetType() Is GetType(TextBox)) Then
                        Dim txt As TextBox = CType(Items, TextBox)
                        If txt.Name = TagRec.Name And UnknownTag(txt.Name) Then
                            TagNo = TagNo + 1
                            TagRec.RO = True
                            txt.ReadOnly = TagRec.RO
                            'ToolStripStatusLabel1.Text = TagRec.Name + " is present on this form, ask for updates!"
                            Me.Controls.Item(Index).BackColor = Color.LightGray
                            'Me.Controls.Item(Index).ContextMenuStrip.Name = "ServoForce"
                            SendData("@PAI0001" + TagRec.Name)
                            'TagRec.OnForm = True
                            TagRec.FieldNo = Index
                            ToolTips.SetToolTip(Me.Controls.Item(Index), "Servo " + TagRec.Name + ", pin no. " + Str(TagRec.Pin))
                            TagRec.TooltipText = "Servo " + TagRec.Name + ", pin no. " + Str(TagRec.Pin)
                            GeneralDeclarations.Tags(TagNo) = TagRec
                        End If
                    End If
                Next

                'Check if the TagNo is increased, when not the case, make controls on the form
                If TagNo = OldTagNo And MakeFields And (Not TagRec.OnForm) Then
                    Dim NewText As New TextBox
                    Dim NewLabel As New Label
                    NoOfCtrl = NoOfCtrl + 1
                    Me.Width = 180 + Kolom * (NoOfCtrl \ ListLen + 1)
                    Offset = PageOffset + 250 * (NoOfCtrl \ ListLen)
                    NewText.Name = TagRec.Name
                    NewText.ContextMenuStrip = ServoForce
                    NewText.TextAlign = HorizontalAlignment.Center
                    NewText.Left = 150 + Offset
                    NewText.Top = TopOffset + (NoOfCtrl Mod ListLen) * 30
                    Me.Controls.Add(NewText)
                    NewLabel.Text = "SV:" + TagRec.Name
                    NewLabel.Left = TagOffset + Offset
                    NewLabel.Top = TopOffset + (NoOfCtrl Mod ListLen) * 30
                    NewLabel.BorderStyle = BorderStyle.Fixed3D
                    NewLabel.BackColor = Color.Silver
                    NewLabel.Height = 20
                    Me.Controls.Add(NewLabel)
                End If

            Next
        End If

        'GMI Ultrasonics (inputs)
        If ForeGroundString(0) = "@GMIDM" Then
            Count = Val(ForeGroundString(1))
            For I = 1 To Count
                TagRec.IOtype = "DM"
                TagRec.Name = ForeGroundString(2 + (I - 1) * 6)
                TagRec.Pin = ForeGroundString(3 + (I - 1) * 6)
                TagRec.SecPin = ForeGroundString(4 + (I - 1) * 6)
                TagRec.OnForm = False
                OldTagNo = TagNo
                Index = -1
                For Each Items In Me.Controls
                    'Thread.Sleep(10)
                    Index = Index + 1
                    If (Items.GetType() Is GetType(TextBox)) Then
                        Dim txt As TextBox = CType(Items, TextBox)
                        If txt.Name = TagRec.Name And UnknownTag(txt.Name) Then
                            TagNo = TagNo + 1
                            TagRec.RO = True
                            txt.ReadOnly = TagRec.RO
                            'ToolStripStatusLabel1.Text = TagRec.Name + " is present on this form, ask for updates!"
                            Me.Controls.Item(Index).BackColor = Color.LightGray
                            'Me.Controls.Item(Index).ContextMenuStrip.Name = "UltrasonicMask"
                            SendData("@PAI0001" + TagRec.Name)
                            'TagRec.OnForm = True
                            TagRec.FieldNo = Index
                            ToolTips.SetToolTip(Me.Controls.Item(Index), "Ultrasonic " + TagRec.Name + ", trigger pin no. " + Str(TagRec.Pin) + ", echo pin no. " + Str(TagRec.SecPin))
                            TagRec.TooltipText = "Ultrasonic " + TagRec.Name + ", trigger pin no. " + Str(TagRec.Pin) + ", echo pin no. " + Str(TagRec.SecPin)
                            GeneralDeclarations.Tags(TagNo) = TagRec
                        End If
                    End If
                Next

                'Check if the TagNo is increased, when not the case, make controls on the form
                If TagNo = OldTagNo And MakeFields And (Not TagRec.OnForm) Then
                    Dim NewText As New TextBox
                    Dim NewLabel As New Label
                    NoOfCtrl = NoOfCtrl + 1
                    Me.Width = 180 + Kolom * (NoOfCtrl \ ListLen + 1)
                    Offset = PageOffset + 250 * (NoOfCtrl \ ListLen)
                    NewText.Name = TagRec.Name
                    NewText.ContextMenuStrip = UltrasonicMask
                    NewText.TextAlign = HorizontalAlignment.Center
                    NewText.Left = 150 + Offset
                    NewText.Top = TopOffset + (NoOfCtrl Mod ListLen) * 30
                    Me.Controls.Add(NewText)
                    NewLabel.Text = "DM:" + TagRec.Name
                    NewLabel.Left = TagOffset + Offset
                    NewLabel.Top = TopOffset + (NoOfCtrl Mod ListLen) * 30
                    NewLabel.BorderStyle = BorderStyle.Fixed3D
                    NewLabel.BackColor = Color.Silver
                    NewLabel.Height = 20
                    Me.Controls.Add(NewLabel)
                End If

            Next
        End If

        'GMI markers
        If ForeGroundString(0) = "@GMIMK" Then
            Count = Val(ForeGroundString(1))
            For I = 1 To Count
                TagRec.IOtype = "MK"
                TagRec.Name = ForeGroundString(2 + (I - 1) * 4)
                TagRec.OnForm = False
                OldTagNo = TagNo
                Index = -1
                For Each Items In Me.Controls
                    Index = Index + 1
                    If (Items.GetType() Is GetType(TextBox)) Then
                        Dim txt As TextBox = CType(Items, TextBox)
                        If txt.Name = TagRec.Name And UnknownTag(txt.Name) Then
                            TagNo = TagNo + 1
                            TagRec.RO = True
                            txt.ReadOnly = TagRec.RO
                            Me.Controls.Item(Index).BackColor = Color.LightGray
                            Try
                                If Me.Controls.Item(Index).ContextMenuStrip.AccessibleName = "DigOutForce" Then SendData("@RDC" + TagRec.Name)
                                If Me.Controls.Item(Index).ContextMenuStrip.AccessibleName = "AnaOutForce" Then SendData("@PAI0001" + TagRec.Name)
                                If Me.Controls.Item(Index).ContextMenuStrip.AccessibleName = "TextForce" Then SendData("@RDC" + TagRec.Name)
                            Catch
                                MsgBox("Marker " & txt.Name & " whitout a known ContextMenuStrip")
                                Me.Controls.Item(Index).BackColor = Color.Orange
                            End Try
                            'TagRec.OnForm = True
                            TagRec.FieldNo = Index
                            ToolTips.SetToolTip(Me.Controls.Item(Index), "Marker " + TagRec.Name + ", no I/O attached")
                            TagRec.TooltipText = "Marker " + TagRec.Name + ", no I/O attached"
                            GeneralDeclarations.Tags(TagNo) = TagRec
                        End If
                    End If
                Next

                'Check if the TagNo is increased, when not the case, make controls on the form
                If TagNo = OldTagNo And MakeFields And (Not TagRec.OnForm) Then
                    Dim NewText As New TextBox
                    Dim NewLabel As New Label
                    NoOfCtrl = NoOfCtrl + 1
                    Me.Width = 180 + Kolom * (NoOfCtrl \ ListLen + 1)
                    Offset = PageOffset + 250 * (NoOfCtrl \ ListLen)
                    NewText.Name = TagRec.Name
                    NewText.ContextMenuStrip = TextForce
                    NewText.TextAlign = HorizontalAlignment.Center
                    NewText.Left = 150 + Offset
                    NewText.Top = TopOffset + (NoOfCtrl Mod ListLen) * 30
                    Me.Controls.Add(NewText)
                    NewLabel.Text = "MT:" + TagRec.Name
                    NewLabel.Left = TagOffset + Offset
                    NewLabel.Top = TopOffset + (NoOfCtrl Mod ListLen) * 30
                    NewLabel.BorderStyle = BorderStyle.Fixed3D
                    NewLabel.BackColor = Color.Silver
                    NewLabel.Height = 20
                    Me.Controls.Add(NewLabel)
                End If

            Next
        End If


        'RDC message
        If (ForeGroundString(0) = "@RDC") Or (ForeGroundString(0) = "@PDI") Then
            'find the field name in the array
            For Index = 1 To TagNo
                If InStr(ForeGroundString(2), GeneralDeclarations.Tags(Index).Name) = 1 Then

                    GeneralDeclarations.Tags(Index).DBLogging = ForeGroundString(4) = "1" & vbCr
                    If GeneralDeclarations.Tags(Index).DBLogging Then
                        Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).Font = New Font(Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).Font, FontStyle.Bold)
                    Else
                        Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).Font = New Font(Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).Font, FontStyle.Regular)
                    End If

                    If ForeGroundString(0) = "@RDC" Then Logging(GeneralDeclarations.Tags(Index).Name, ForeGroundString(1), GeneralDeclarations.Tags(Index).TooltipText, GeneralDeclarations.Tags(Index).DBLogging, GeneralDeclarations.Tags(Index).IOtype)
                    If ForeGroundString(0) = "@PDI" Then Logging(GeneralDeclarations.Tags(Index).Name, ForeGroundString(1), GeneralDeclarations.Tags(Index).TooltipText, 0, GeneralDeclarations.Tags(Index).IOtype)

                    Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).Text = ForeGroundString(1)

                    If GeneralDeclarations.Tags(Index).IOtype = "MK" Then
                        If Val(ForeGroundString(3)) = 0 Then 'HAND
                            Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.Orange
                        ElseIf Val(ForeGroundString(1)) = 1 Then
                            Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.Silver
                        Else
                            Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.LightGray
                        End If
                    End If

                    If GeneralDeclarations.Tags(Index).IOtype = "DI" Then
                        If Val(ForeGroundString(3)) = 1 Then 'MASK
                            Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.Yellow
                        ElseIf Val(ForeGroundString(1)) = 1 Then
                            Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.Silver
                        Else
                            Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.LightGray
                        End If
                    End If

                    If GeneralDeclarations.Tags(Index).IOtype = "DO" Then
                        If Val(ForeGroundString(3)) = 0 Then 'HAND
                            Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.Yellow
                        ElseIf Val(ForeGroundString(1)) = 1 Then
                            Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.Silver
                        Else
                            Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.LightGray
                        End If
                    End If

                End If

            Next
        End If

        'PAI message
        If ForeGroundString(0) = "@PAI" Then
            'find the field name in the array
            For Index = 1 To TagNo
                If InStr(ForeGroundString(2), GeneralDeclarations.Tags(Index).Name) = 1 Then

                    GeneralDeclarations.Tags(Index).DBLogging = ForeGroundString(4) = "1" & vbCr
                    If GeneralDeclarations.Tags(Index).DBLogging Then
                        Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).Font = New Font(Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).Font, FontStyle.Bold)
                    Else
                        Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).Font = New Font(Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).Font, FontStyle.Regular)
                    End If

                    Logging(GeneralDeclarations.Tags(Index).Name, ForeGroundString(1), GeneralDeclarations.Tags(Index).TooltipText, GeneralDeclarations.Tags(Index).DBLogging, GeneralDeclarations.Tags(Index).IOtype)

                    If GeneralDeclarations.Tags(Index).IOtype = "AI" Then
                        Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).Text = ForeGroundString(1)
                        Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.LightGray
                        If Val(ForeGroundString(3)) = 1 Then 'MASK
                            Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.Yellow
                        Else
                            Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.LightGray
                        End If
                    End If

                    If GeneralDeclarations.Tags(Index).IOtype = "TT" Then
                        Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).Text = ForeGroundString(1)
                        Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.LightGray
                        If Val(ForeGroundString(3)) = 1 Then 'MASK
                            Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.Yellow
                        Else
                            Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.LightGray
                        End If
                    End If

                    If GeneralDeclarations.Tags(Index).IOtype = "DM" Then
                        Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).Text = ForeGroundString(1)
                        Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.LightGray
                        If Val(ForeGroundString(3)) = 1 Then 'MASK
                            Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.Yellow
                        Else
                            Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.LightGray
                        End If
                    End If

                    If GeneralDeclarations.Tags(Index).IOtype = "AO" Then
                        Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).Text = ForeGroundString(1)
                        Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.LightGray
                        If Val(ForeGroundString(3)) = 0 Then 'Hand
                            Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.Yellow
                        Else
                            Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.LightGray
                        End If
                    End If

                    If GeneralDeclarations.Tags(Index).IOtype = "SO" Then
                        Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).Text = ForeGroundString(1)
                        Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.LightGray
                        If Val(ForeGroundString(3)) = 0 Then 'Hand
                            Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.Yellow
                        Else
                            Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.LightGray
                        End If
                    End If

                    If GeneralDeclarations.Tags(Index).IOtype = "MK" Then
                        Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).Text = ForeGroundString(1)
                        Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.LightYellow
                        If Val(ForeGroundString(3)) = 0 Then 'Hand
                            Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.Orange
                        Else
                            Me.Controls.Item(GeneralDeclarations.Tags(Index).FieldNo).BackColor = Color.LightGray
                        End If
                    End If

                End If
            Next
        End If

        'FSM message
        If ForeGroundString(0) = "@FSM" Then

            Dim FSFound As Boolean

            'FSMBox.Items.Clear()

            'check for existing state
            FSFound = False
            For i As Integer = 0 To FSMBox.Items.Count - 1
                If FSMBox.Items(i) = ForeGroundString(1) Then
                    FSFound = True
                End If
            Next

            If Not FSFound Then
                FSMBox.Items.Add(ForeGroundString(1))
            End If

            For i As Integer = 0 To FSMBox.Items.Count - 1
                If FSMBox.Items(i) = ForeGroundString(1) Then
                    If (ForeGroundString(2).Contains("RUN")) Then
                        FSMBox.SetItemChecked(i, True)
                    Else
                        FSMBox.SetItemChecked(i, False)
                    End If
                End If
            Next

        End If

        'CLT Message
        If ForeGroundString(0) = "@CLT" Then
            CycleTime.Text = ForeGroundString(1) + " mS"
        End If

        'RAM Message
        If ForeGroundString(0) = "@RAM" Then
            FreeMemory.Text = ForeGroundString(1) + " bytes free RAM"
        End If

        'TIM Message
        If ForeGroundString(0) = "@TIM" Then
            'TimeStamp.Text = ForeGroundString(1)
            Dim TimeOfBoard As DateTime
            TimeOfBoard = UnixTimestampToDateTime(ForeGroundString(1))
            TimeStamp.Text = "MEGA 2560 time " + TimeOfBoard.ToShortTimeString
        End If


    End Sub

    Private Sub SendToArduino_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendToArduino.Click
        If ToArduino.Text = "@GMI" Then
            ' TagNo = 0
            ClearTextFields()
        End If
        SendData(ToArduino.Text)
        TransportLabel.Text = "Send (" + TimeValue(Now) + "): " + ToArduino.Text
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerSendGMI.Tick

        'Send the GMI message to the board..
        'TagNo = 0
        ClearTextFields()
        SendData("@GMI")
        TimerSendGMI.Enabled = False


    End Sub

    Private Sub ClearTextFields()

        Dim Index As Integer
        TagNo = 0
        Index = -1

        For Each Items In Me.Controls
            Index = Index + 1
            If (Items.GetType() Is GetType(TextBox)) Then
                Me.Controls.Item(Index).BackColor = Color.White
                'Me.Controls.Item(Index).Text = ""
            End If
        Next


    End Sub


    Private Sub Timer1_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Retry.Tick

        'Retry message that are not validated yet
        HandleMessage("check", 3, 0)

    End Sub


    Private Sub Uit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        SendData("@FDO0" + FieldName)


    End Sub

    Private Sub Automaat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        SendData("@RTA" + FieldName)


    End Sub

    Private Sub Aan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        SendData("@FDO1" + FieldName)

    End Sub

    Private Sub Maskeer0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        SendData("@MDI0" + FieldName)

    End Sub

    Private Sub Maskeer1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        SendData("@MDI1" + FieldName)

    End Sub

    Private Sub DigOutTagName_Click(sender As System.Object, e As System.EventArgs) Handles DigOutForce.Opened
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        DigOutTagName.Text = "Tag(DO): " + FieldName

        For Index = 1 To TagNo
            If InStr(FieldName, GeneralDeclarations.Tags(Index).Name) = 1 Then
                DigOutDBLogging.Checked = GeneralDeclarations.Tags(Index).DBLogging
            End If
        Next
        If ActiveControl.BackColor = Color.Yellow Then Forcing.Checked = True Else Forcing.Checked = False

    End Sub

    Private Sub DigInTagName_Click(sender As System.Object, e As System.EventArgs) Handles DigInMask.Opened
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        DigInTagName.Text = "Tag(DI): " + FieldName

        For Index = 1 To TagNo
            If InStr(FieldName, GeneralDeclarations.Tags(Index).Name) = 1 Then
                DigInDBLogging.Checked = GeneralDeclarations.Tags(Index).DBLogging
            End If
        Next
        If ActiveControl.BackColor = Color.Yellow Then Masking.Checked = True Else Masking.Checked = False

    End Sub

    Private Sub TTTagName_Click(sender As System.Object, e As System.EventArgs) Handles TTMask.Opened
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        TTTagName.Text = "Tag(TT): " + FieldName

        For Index = 1 To TagNo
            If InStr(FieldName, GeneralDeclarations.Tags(Index).Name) = 1 Then
                TTDBLogging.Checked = GeneralDeclarations.Tags(Index).DBLogging
            End If
        Next


    End Sub

    Private Sub UltrasonicTagName_Click(sender As System.Object, e As System.EventArgs) Handles UltrasonicMask.Opened
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        UltrasonicTagName.Text = "Tag(DM): " + FieldName

    End Sub

    Private Sub AnaOutTagName_Click(sender As System.Object, e As System.EventArgs) Handles AnaOutForce.Opened
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        AnaOutTagName.Text = "Tag(AO): " + FieldName

        For Index = 1 To TagNo
            If InStr(FieldName, GeneralDeclarations.Tags(Index).Name) = 1 Then
                AnaOutDBLogging.Checked = GeneralDeclarations.Tags(Index).DBLogging
            End If
        Next


    End Sub

    Private Sub ServoTagName_Click(sender As System.Object, e As System.EventArgs) Handles ServoForce.Opened
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        ServoTagName.Text = "Tag(SV): " + FieldName

    End Sub

    Private Sub AnaInTagName_Click(sender As System.Object, e As System.EventArgs) Handles AnaInMask.Opened
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        AnaInTagName.Text = "Tag(AI): " + FieldName

        For Index = 1 To TagNo
            If InStr(FieldName, GeneralDeclarations.Tags(Index).Name) = 1 Then
                AnaInDBLogging.Checked = GeneralDeclarations.Tags(Index).DBLogging
            End If
        Next


    End Sub


    Private Sub MKTagName_Click(sender As Object, e As EventArgs) Handles TextForce.Opened

        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        MKTagName.Text = "Tag(MK): " + FieldName

    End Sub

    Private Sub VeldWaarde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        SendData("@RMM" + FieldName)

    End Sub

    Private Function LeadingZero(ByVal IntValue, ByVal NoChar) As String

        Dim StrLen As Integer
        Dim StringValue As String
        Dim Negative As Boolean

        Negative = True
        If IntValue < 0 Then Negative = True

        StringValue = CStr(IntValue)
        StrLen = Len(StringValue)
        For index = 1 To (NoChar - StrLen)
            If Not Negative Then
                StringValue = "0" + StringValue
            Else
                StringValue = " " + StringValue
            End If
        Next
        LeadingZero = StringValue

        Return LeadingZero


    End Function


    Private Sub AnalogueAutomatic_Click(sender As System.Object, e As System.EventArgs) Handles AnalogueAutomatic.Click
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        SendData("@RMM" + FieldName)

    End Sub

    Private Sub AnalogueSetMask_Click(sender As System.Object, e As System.EventArgs) Handles AnalogueSetMask.Click

        'Value has to be a number between 0 and 1023
        'If ok send a @MAI message

        Dim ActiveControl As Control
        Dim FieldName As String
        Dim Value As Integer

        Value = 0
        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name

        Try
            Value = CInt(AnalogueMaskValue.Text)
            If Value < 0 Or Value > 1023 Then
                Value = 0
                AnalogueMaskValue.Text = ""
                MsgBox("Value must be in the range 0..1023")
            Else
                'send a @MAI message to the board
                SendData("@MAI" + LeadingZero(Value, 4) + FieldName)
            End If
        Catch ex As Exception
            AnalogueMaskValue.Text = ""
            MsgBox("No valid analogue value, must be 0..1023")
        End Try

    End Sub


    Private Sub UltrasonicSetMask_Click(sender As System.Object, e As System.EventArgs) Handles UltrasonicSetMask.Click
        'Value has to be a number between 0 and 500
        'If ok send a @MAI message

        Dim ActiveControl As Control
        Dim FieldName As String
        Dim Value As Integer

        Value = 0
        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name

        Try
            Value = CInt(UltrasonicValue.Text)
            If Value < 0 Or Value > 500 Then
                Value = 0
                UltrasonicValue.Text = ""
                MsgBox("Value must be in the range 0..500")
            Else
                'send a @MAI message to the board
                SendData("@MAI" + LeadingZero(Value, 4) + FieldName)
            End If
        Catch ex As Exception
            UltrasonicValue.Text = ""
            MsgBox("No valid analogue value, must be 0..500")
        End Try

    End Sub

    Private Sub UltrasonicAutomatic_Click(sender As System.Object, e As System.EventArgs) Handles UltrasonicAutomatic.Click
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        SendData("@RMM" + FieldName)

    End Sub

    Private Sub TTSetMask_Click(sender As System.Object, e As System.EventArgs) Handles TTSetMask.Click
        'Value has to be a number between -55 and 125
        'If ok send a @MAI message

        Dim ActiveControl As Control
        Dim FieldName As String
        Dim Value As Integer

        Value = 0
        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name

        Try
            Value = CInt(TTValue.Text)
            If Value <= -55 Or Value >= 125 Then
                Value = 0
                TTValue.Text = ""
                MsgBox("Value must be in the range -55..125")
            Else
                'send a @MAI message to the board
                SendData("@MAI" + LeadingZero(Value, 4) + FieldName)
            End If
        Catch ex As Exception
            TTValue.Text = ""
            MsgBox("No valid analogue value, must be -55..125")
        End Try


    End Sub

    Private Sub TTAutomatic_Click(sender As System.Object, e As System.EventArgs) Handles TTAutomatic.Click
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        SendData("@RMM" + FieldName)

    End Sub

    Private Sub AnaOutAutomatic_Click(sender As System.Object, e As System.EventArgs) Handles AnaOutAutomatic.Click
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        SendData("@RTA" + FieldName)

    End Sub

    Private Sub Force_Click(sender As System.Object, e As System.EventArgs) Handles Force.Click
        'Value has to be a number between 0 and 255
        'If ok send a @FAO message

        Dim ActiveControl As Control
        Dim FieldName As String
        Dim Value As Integer

        Value = 0
        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name

        Try
            If AnaOutForceValue.Text <> "0" Then Value = CInt(AnaOutForceValue.Text)
            If Value < 0 Or Value > 255 Then
                Value = 0
                AnaOutForceValue.Text = ""
                MsgBox("Value must be in the range 0..255")
            Else
                'send a @FAO message to the board
                SendData("@FAO" + LeadingZero(Value, 3) + FieldName)
            End If
        Catch ex As Exception
            TTValue.Text = ""
            MsgBox("No valid analogue value, must be 0..255")
        End Try


    End Sub

    Private Sub ServoAutomatic_Click(sender As System.Object, e As System.EventArgs) Handles ServoAutomatic.Click
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        SendData("@RTA" + FieldName)

    End Sub

    Private Sub ServoForceOn_Click(sender As System.Object, e As System.EventArgs) Handles ServoForceOn.Click
        'Value has to be a number between 0 and 180
        'If ok send a @FSO message

        Dim ActiveControl As Control
        Dim FieldName As String
        Dim Value As Integer

        Value = 0
        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name

        Try
            If ServoForceValue.Text <> "0" Then Value = CInt(ServoForceValue.Text)
            If Value < 0 Or Value > 180 Then
                Value = 0
                ServoForceValue.Text = ""
                MsgBox("Angle must be in the range 0..180")
            Else
                'send a @FSO message to the board
                SendData("@FSO" + LeadingZero(Value, 3) + FieldName)
            End If
        Catch ex As Exception
            ServoForceValue.Text = ""
            MsgBox("No valid angle, must be 0..180")
        End Try

    End Sub

    Private Sub TextAutomatic_Click(sender As Object, e As EventArgs) Handles TextAutomatic.Click
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        SendData("@RTA" + FieldName)
    End Sub

    Private Sub MKForce_Click(sender As Object, e As EventArgs) Handles MKForce.Click
        'Value maybe every character
        'The message is send as @FMT, then the length of the textstring, the textstring itself and then the tagname

        Dim ActiveControl As Control
        Dim FieldName As String
        Dim Value As String
        Dim LenValue As Integer

        Value = MKForceValue.Text
        LenValue = Len(Value)

        If LenValue > 80 Then
            MsgBox("Text must be smaller or equal then 80, not forced!")
        Else
            ActiveControl = Me.ActiveControl
            FieldName = ActiveControl.Name
            SendData("@FMT" + LeadingZero(LenValue, 3) + Value + FieldName)
        End If

    End Sub

    Private Sub WatchDog_Tick(sender As Object, e As EventArgs) Handles WatchDog.Tick
        SendData("@WTD")
        SendData("@FSM")
    End Sub

    Private Sub SyncTimeBoard()

        Dim UnixTime As Int64
        Dim UnixTimeStr As String

        UnixTime = DateDiff("S", "1/1/1970", Now)
        UnixTimeStr = Format(UnixTime, "##########")
        SendData("@THM" + Format(UnixTime, "##########"))

    End Sub

    Private Sub SyncTimeBoardTimer_Tick(sender As Object, e As EventArgs) Handles SyncTimeBoardTimer.Tick
        SyncTimeBoard()
    End Sub

    Private Sub ToolTips_Popup(sender As Object, e As PopupEventArgs) Handles ToolTips.Popup
        e.AssociatedControl.Focus()
    End Sub


    Private Sub Timer1_Tick_2(sender As Object, e As EventArgs) Handles AfterStartup.Tick

        'ClearTextFields()
        SendData("@FSM")
        SendData("@CLT")
        SendData("@RAM")
        SendData("@TIM")
        SendData("@GMI")

        AfterStartup.Enabled = False

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles ActualStates.Tick
        SendData("@FSM")
        ActualStates.Enabled = False
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles CycleTimer.Tick
        SendData("@CLT")
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles FreeRam.Tick
        SendData("@RAM")
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles GetTime.Tick
        SendData("@TIM")
    End Sub



    Private Sub ToolStripTextBox1_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox1.Click
        GraphScr.Show()
    End Sub

    Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click

        Dim response = MsgBox("Are you sure to RESET the board?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "Copyright (c) 2017 Arduino Finite State Machine")

        ' Take some action based on the response. 
        If response = MsgBoxResult.Yes Then
            NoDBItems = 0
            DBImage.Visible = False
            TagNo = 0
            'Let the board jump to baseaddress 0000, expect no validation message
            Mega2560Port.WriteLine("@JM0")
        End If

    End Sub


    Private Sub DigInDBLogging_Click(sender As Object, e As EventArgs) Handles DigInDBLogging.Click

        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name

        For Index = 1 To TagNo
            If InStr(FieldName, GeneralDeclarations.Tags(Index).Name) = 1 Then
                DigInDBLogging.Checked = Not GeneralDeclarations.Tags(Index).DBLogging
                If DigInDBLogging.Checked Then
                    SendData("@RDB" + FieldName)
                Else
                    SendData("@CDB" + FieldName)
                End If
                ToggleDBImage(DigInDBLogging.Checked)
            End If
        Next

    End Sub

    Private Sub DigInMaskOn_Click(sender As Object, e As EventArgs) Handles DigInMaskOn.Click

        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        SendData("@MDI1" + FieldName)
        Masking.Checked = True

    End Sub

    Private Sub DigInMaskOff_Click(sender As Object, e As EventArgs) Handles DigInMaskOff.Click

        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        SendData("@MDI0" + FieldName)
        Masking.Checked = True

    End Sub

    Private Sub Masking_Click(sender As Object, e As EventArgs) Handles Masking.Click
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        SendData("@RMM" + FieldName)
        Masking.Checked = False
        DigInMask.Close()

    End Sub

    Private Sub DigOutDBLogging_Click(sender As Object, e As EventArgs) Handles DigOutDBLogging.Click
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name

        For Index = 1 To TagNo
            If InStr(FieldName, GeneralDeclarations.Tags(Index).Name) = 1 Then
                DigOutDBLogging.Checked = Not GeneralDeclarations.Tags(Index).DBLogging
                If DigOutDBLogging.Checked Then
                    SendData("@RDB" + FieldName)
                Else
                    SendData("@CDB" + FieldName)
                End If
                ToggleDBImage(DigOutDBLogging.Checked)
            End If
        Next

    End Sub

    Private Sub ToggleDBImage(Checked As Boolean)
        If Checked Then NoDBItems = NoDBItems + 1 Else NoDBItems = NoDBItems - 1
        If NoDBItems > 0 Then DBImage.Visible = True Else DBImage.Visible = False
    End Sub

    Private Sub ForceOn_Click(sender As Object, e As EventArgs) Handles ForceOn.Click
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        SendData("@FDO1" + FieldName)
        Forcing.Checked = True

    End Sub

    Private Sub ForceOff_Click(sender As Object, e As EventArgs) Handles ForceOff.Click
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        SendData("@FDO0" + FieldName)
        Forcing.Checked = True

    End Sub

    Private Sub Forcing_Click(sender As Object, e As EventArgs) Handles Forcing.Click
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        SendData("@RTA" + FieldName)
        Forcing.Checked = False
        DigOutForce.Close()

    End Sub

    Private Sub CheckNoDB_Tick(sender As Object, e As EventArgs) Handles CheckNoDB.Tick

        'Just to have a periodic check on db items (for example after the start of the monitor programm)
        NoDBItems = 0
        For Index As Integer = 1 To TagNo
            If GeneralDeclarations.Tags(Index).DBLogging Then NoDBItems = NoDBItems + 1
        Next
        If NoDBItems > 0 Then DBImage.Visible = True Else DBImage.Visible = False

    End Sub

    Private Sub AnaInDBLogging_Click(sender As Object, e As EventArgs) Handles AnaInDBLogging.Click

        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name

        For Index = 1 To TagNo
            If InStr(FieldName, GeneralDeclarations.Tags(Index).Name) = 1 Then
                AnaInDBLogging.Checked = Not GeneralDeclarations.Tags(Index).DBLogging
                If AnaInDBLogging.Checked Then
                    SendData("@RDB" + FieldName)
                Else
                    SendData("@CDB" + FieldName)
                End If
                ToggleDBImage(AnaInDBLogging.Checked)
            End If
        Next

        AnaInMask.Close()

    End Sub

    Private Sub TTDBLogging_Click(sender As Object, e As EventArgs) Handles TTDBLogging.Click

        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name

        For Index = 1 To TagNo
            If InStr(FieldName, GeneralDeclarations.Tags(Index).Name) = 1 Then
                TTDBLogging.Checked = Not GeneralDeclarations.Tags(Index).DBLogging
                If TTDBLogging.Checked Then
                    SendData("@RDB" + FieldName)
                Else
                    SendData("@CDB" + FieldName)
                End If
                ToggleDBImage(TTDBLogging.Checked)
            End If
        Next

        TTMask.Close()

    End Sub

    Private Sub AnaOutDBLogging_Click(sender As Object, e As EventArgs) Handles AnaOutDBLogging.Click

        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name

        For Index = 1 To TagNo
            If InStr(FieldName, GeneralDeclarations.Tags(Index).Name) = 1 Then
                AnaOutDBLogging.Checked = Not GeneralDeclarations.Tags(Index).DBLogging
                If AnaOutDBLogging.Checked Then
                    SendData("@RDB" + FieldName)
                Else
                    SendData("@CDB" + FieldName)
                End If
                ToggleDBImage(AnaOutDBLogging.Checked)
            End If
        Next

        AnaOutForce.Close()

    End Sub

    Private Sub ClearFSMStates_Tick(sender As Object, e As EventArgs) Handles ClearFSMStates.Tick
        FSMBox.Items.Clear()
        SendData("@FSM")
    End Sub

    Private Sub ToggleOnOffToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim ActiveControl As Control
        Dim FieldName As String

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name

        For Index = 1 To TagNo
            If InStr(FieldName, GeneralDeclarations.Tags(Index).Name) = 1 Then
                AnaInDBLogging.Checked = Not GeneralDeclarations.Tags(Index).DBLogging
                If AnaInDBLogging.Checked Then
                    SendData("@RDB" + FieldName)
                Else
                    SendData("@CDB" + FieldName)
                End If
                ToggleDBImage(AnaInDBLogging.Checked)
            End If
        Next
    End Sub

    Private Sub SetAnaInDBInterval_Click(sender As Object, e As EventArgs) Handles SetAnaInDBInterval.Click
        Dim ActiveControl As Control
        Dim FieldName As String
        Dim Value As Integer = 0
        Dim LenValue As Integer

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        LenValue = AnaInDBInterval.TextLength

        For Index = 1 To TagNo
            If InStr(FieldName, GeneralDeclarations.Tags(Index).Name) = 1 Then
                Try
                    Value = CInt(AnaInDBInterval.Text)
                    If Value < 1 Or Value > 9999 Then
                        MsgBox("Interval must be 1..9999")
                    Else
                        SendData("@PAI" + LeadingZero(Value, 4) + FieldName)
                        ToolStripStatusLabel1.Text = "%SNDMSG-INF-POLL, Poll interval send to board: " + AnaInDBInterval.Text + " (x0,1Sec) for " + FieldName
                    End If
                Catch ex As Exception
                    MsgBox("No valid interval, must be 1..9999")
                End Try
            End If
        Next

    End Sub

    Private Sub SetTTDBInterval_Click(sender As Object, e As EventArgs) Handles SetTTDBInterval.Click
        Dim ActiveControl As Control
        Dim FieldName As String
        Dim Value As Integer = 0
        Dim LenValue As Integer

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        LenValue = TTDBInterval.TextLength

        For Index = 1 To TagNo
            If InStr(FieldName, GeneralDeclarations.Tags(Index).Name) = 1 Then
                Try
                    Value = CInt(TTDBInterval.Text)
                    If Value < 1 Or Value > 9999 Then
                        MsgBox("Interval must be 1..9999")
                    Else
                        SendData("@PAI" + LeadingZero(Value, 4) + FieldName)
                        ToolStripStatusLabel1.Text = "%SNDMSG-INF-POLL, Poll interval send to board: " + TTDBInterval.Text + " (x0,1Sec) for " + FieldName
                    End If
                Catch ex As Exception
                    MsgBox("No valid interval, must be 1..9999")
                End Try
            End If
        Next

    End Sub

    Private Sub AnaOutDBInterval_Click(sender As Object, e As EventArgs) Handles SetAnaOutDBInterval.Click
        Dim ActiveControl As Control
        Dim FieldName As String
        Dim Value As Integer = 0
        Dim LenValue As Integer

        ActiveControl = Me.ActiveControl
        FieldName = ActiveControl.Name
        LenValue = AnaOutDBInterval.TextLength

        For Index = 1 To TagNo
            If InStr(FieldName, GeneralDeclarations.Tags(Index).Name) = 1 Then
                Try
                    Value = CInt(AnaOutDBInterval.Text)
                    If Value < 1 Or Value > 9999 Then
                        MsgBox("Interval must be 1..9999")
                    Else
                        SendData("@PAI" + LeadingZero(Value, 4) + FieldName)
                        ToolStripStatusLabel1.Text = "%SNDMSG-INF-POLL, Poll interval send to board: " + AnaOutDBInterval.Text + " (x0,1Sec) for " + FieldName
                    End If
                Catch ex As Exception
                    MsgBox("No valid interval, must be 1..9999")
                End Try
            End If
        Next

    End Sub

    Private Sub LogoAFSM_Click(sender As Object, e As EventArgs)

    End Sub
End Class


