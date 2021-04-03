
Public Class MyVerticalProgessBar
    Inherits ProgressBar
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.Style = cp.Style Or &H4
            Return cp
        End Get
    End Property
End Class

Public Structure TagInfo
    Public Name As String
    Public Pin As Integer
    Public SecPin As Integer
    Public RO As Boolean
    Public IOtype As String
    Public OnForm As Boolean
    Public FieldNo As Integer
    Public TooltipText As String
    Public DBLogging As Boolean
    Public Present As Boolean
End Structure





