VERSION 5.00
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form FrmChengde 
   Caption         =   "承德卡"
   ClientHeight    =   6255
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   8085
   LinkTopic       =   "Form1"
   ScaleHeight     =   6255
   ScaleWidth      =   8085
   StartUpPosition =   3  'Windows Default
   Begin TabDlg.SSTab SSTab1 
      Height          =   5535
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   7695
      _ExtentX        =   13573
      _ExtentY        =   9763
      _Version        =   393216
      Style           =   1
      Tab             =   1
      TabHeight       =   520
      TabCaption(0)   =   "开/补卡"
      TabPicture(0)   =   "FrmChengde.frx":0000
      Tab(0).ControlEnabled=   0   'False
      Tab(0).Control(0)=   "txtCardID"
      Tab(0).Control(1)=   "cmdMake"
      Tab(0).Control(2)=   "cmdRemake"
      Tab(0).Control(3)=   "cmdClear"
      Tab(0).Control(4)=   "Label1(1)"
      Tab(0).Control(5)=   "Label1(0)"
      Tab(0).ControlCount=   6
      TabCaption(1)   =   "售气"
      TabPicture(1)   =   "FrmChengde.frx":001C
      Tab(1).ControlEnabled=   -1  'True
      Tab(1).Control(0)=   "Label10(1)"
      Tab(1).Control(0).Enabled=   0   'False
      Tab(1).Control(1)=   "Label3(2)"
      Tab(1).Control(1).Enabled=   0   'False
      Tab(1).Control(2)=   "Label10(0)"
      Tab(1).Control(2).Enabled=   0   'False
      Tab(1).Control(3)=   "Label1(2)"
      Tab(1).Control(3).Enabled=   0   'False
      Tab(1).Control(4)=   "txtCount"
      Tab(1).Control(4).Enabled=   0   'False
      Tab(1).Control(5)=   "txtFPID"
      Tab(1).Control(5).Enabled=   0   'False
      Tab(1).Control(6)=   "txtAmount"
      Tab(1).Control(6).Enabled=   0   'False
      Tab(1).Control(7)=   "txtCardID1"
      Tab(1).Control(7).Enabled=   0   'False
      Tab(1).Control(8)=   "cmdBuy"
      Tab(1).Control(8).Enabled=   0   'False
      Tab(1).Control(9)=   "cmdRead"
      Tab(1).Control(9).Enabled=   0   'False
      Tab(1).Control(10)=   "List1"
      Tab(1).Control(10).Enabled=   0   'False
      Tab(1).ControlCount=   11
      TabCaption(2)   =   "工具卡"
      TabPicture(2)   =   "FrmChengde.frx":0038
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "txtTestCount"
      Tab(2).Control(1)=   "Option1(5)"
      Tab(2).Control(2)=   "Option1(0)"
      Tab(2).Control(3)=   "Option1(1)"
      Tab(2).Control(4)=   "Option1(2)"
      Tab(2).Control(5)=   "Option1(3)"
      Tab(2).Control(6)=   "Option1(4)"
      Tab(2).Control(7)=   "CmdTool(0)"
      Tab(2).Control(8)=   "txtTestAmount"
      Tab(2).Control(9)=   "Option1(6)"
      Tab(2).Control(10)=   "Label1(4)"
      Tab(2).Control(11)=   "Label1(3)"
      Tab(2).ControlCount=   12
      Begin VB.TextBox txtTestCount 
         Enabled         =   0   'False
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   -68640
         TabIndex        =   28
         Text            =   "100"
         Top             =   2220
         Width           =   975
      End
      Begin VB.OptionButton Option1 
         Caption         =   "补测试卡"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Index           =   5
         Left            =   -74040
         TabIndex        =   26
         Top             =   3360
         Width           =   1215
      End
      Begin VB.OptionButton Option1 
         Caption         =   "初始化卡"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Index           =   0
         Left            =   -74040
         TabIndex        =   25
         Top             =   600
         Value           =   -1  'True
         Width           =   2775
      End
      Begin VB.OptionButton Option1 
         Caption         =   "异常清除卡"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Index           =   1
         Left            =   -74040
         TabIndex        =   24
         Top             =   1140
         Width           =   2775
      End
      Begin VB.OptionButton Option1 
         Caption         =   "换表卡"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Index           =   2
         Left            =   -74040
         TabIndex        =   23
         Top             =   1680
         Width           =   2775
      End
      Begin VB.OptionButton Option1 
         Caption         =   "测试卡"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Index           =   3
         Left            =   -74040
         TabIndex        =   22
         Top             =   2160
         Width           =   975
      End
      Begin VB.OptionButton Option1 
         Caption         =   "清零卡"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Index           =   4
         Left            =   -74040
         TabIndex        =   21
         Top             =   2760
         Width           =   975
      End
      Begin VB.CommandButton CmdTool 
         Caption         =   "发工具卡"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Index           =   0
         Left            =   -73200
         TabIndex        =   20
         Top             =   4680
         Width           =   1815
      End
      Begin VB.TextBox txtTestAmount 
         Enabled         =   0   'False
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   -71400
         TabIndex        =   19
         Text            =   "10"
         Top             =   2220
         Width           =   975
      End
      Begin VB.OptionButton Option1 
         Caption         =   "恢复工具卡为空白卡"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Index           =   6
         Left            =   -74040
         TabIndex        =   18
         Top             =   3960
         Width           =   3615
      End
      Begin VB.ListBox List1 
         Appearance      =   0  'Flat
         Height          =   2175
         ItemData        =   "FrmChengde.frx":0054
         Left            =   3720
         List            =   "FrmChengde.frx":0056
         TabIndex        =   17
         Top             =   660
         Width           =   3615
      End
      Begin VB.CommandButton cmdRead 
         Caption         =   "读卡"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Left            =   1200
         TabIndex        =   16
         Top             =   3840
         Width           =   1095
      End
      Begin VB.CommandButton cmdBuy 
         Caption         =   "售气"
         Enabled         =   0   'False
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Left            =   2520
         TabIndex        =   15
         Top             =   3840
         Width           =   1095
      End
      Begin VB.TextBox txtCardID1 
         Enabled         =   0   'False
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   1200
         TabIndex        =   10
         Top             =   660
         Width           =   2175
      End
      Begin VB.TextBox txtAmount 
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   1200
         TabIndex        =   9
         Top             =   1200
         Width           =   2175
      End
      Begin VB.TextBox txtFPID 
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   450
         Left            =   1200
         TabIndex        =   8
         Top             =   2400
         Width           =   2175
      End
      Begin VB.TextBox txtCount 
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   1200
         TabIndex        =   7
         Top             =   1800
         Width           =   2175
      End
      Begin VB.TextBox txtCardID 
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   -73320
         TabIndex        =   4
         Top             =   840
         Width           =   2055
      End
      Begin VB.CommandButton cmdMake 
         Caption         =   "开卡"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Left            =   -74160
         TabIndex        =   3
         Top             =   3360
         Width           =   1095
      End
      Begin VB.CommandButton cmdRemake 
         Caption         =   "补卡"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Left            =   -72600
         TabIndex        =   2
         Top             =   3360
         Width           =   1095
      End
      Begin VB.CommandButton cmdClear 
         Caption         =   "擦卡"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Left            =   -71160
         TabIndex        =   1
         Top             =   3360
         Width           =   1335
      End
      Begin VB.Label Label1 
         Caption         =   "测试用量(0-100)"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   4
         Left            =   -72960
         TabIndex        =   29
         Top             =   2280
         Width           =   1575
      End
      Begin VB.Label Label1 
         Caption         =   "测试次数(0-255)"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   3
         Left            =   -70200
         TabIndex        =   27
         Top             =   2280
         Width           =   1575
      End
      Begin VB.Label Label1 
         Caption         =   "卡号："
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   2
         Left            =   360
         TabIndex        =   14
         Top             =   720
         Width           =   735
      End
      Begin VB.Label Label10 
         Caption         =   "购买量："
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   0
         Left            =   240
         TabIndex        =   13
         Top             =   1260
         Width           =   855
      End
      Begin VB.Label Label3 
         Caption         =   "发票号："
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   2
         Left            =   240
         TabIndex        =   12
         Top             =   2505
         Width           =   975
      End
      Begin VB.Label Label10 
         Caption         =   "售气次数："
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   1
         Left            =   240
         TabIndex        =   11
         Top             =   1860
         Width           =   855
      End
      Begin VB.Label Label1 
         Caption         =   "8位数字"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FF0000&
         Height          =   255
         Index           =   1
         Left            =   -71160
         TabIndex        =   6
         Top             =   900
         Width           =   735
      End
      Begin VB.Label Label1 
         Caption         =   "卡号："
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   0
         Left            =   -74040
         TabIndex        =   5
         Top             =   900
         Width           =   735
      End
   End
End
Attribute VB_Name = "FrmChengde"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'/底层动态库
'///////////明华函数
Private Declare Function ic_init Lib "MWIC_32" (ByVal port As Long, ByVal Baud As Long) As Long
Private Declare Function ic_exit Lib "MWIC_32" (ByVal icDev As Long) As Long
Private Declare Function csc_4442 Lib "MWIC_32" (ByVal icDev As Long, ByVal leng As Long, ByVal databuff As String) As Long
Private Declare Function wsc_4442 Lib "MWIC_32" (ByVal icDev As Long, ByVal leng As Long, ByVal databuff As String) As Long

'///////////IC卡函数
Private Declare Function rdcompany Lib "BGCard" (ByVal icDev As Long, isTrue As Byte) As Long
Private Declare Function readCard Lib "BGCard" (ByVal icDev As Long, ByVal userCode As String, cardAmount As Single, meterAmount As Single, TestAmount As Single, inserted As Byte) As Long
Private Declare Function makeCard Lib "BGCard" (ByVal icDev As Long, ByVal userCode As String, ByVal Amount As Single, ByVal saveInfo As String, ByVal mark As Byte) As Long
Private Declare Function writeCard Lib "BGCard" (ByVal icDev As Long, ByVal userCode As String, ByVal Amount As Single, ByVal saveInfo As String) As Long
Private Declare Function clearCard Lib "BGCard" (ByVal icDev As Long, ByVal userCode As String) As Long
Private Declare Function writetoolCard Lib "BGCard" (ByVal icDev As Long, ByVal WriteType As Long, ByVal TestAmount As Single, ByVal TestTimes As Long) As Long

'////全局变量，保存返回信息
Private Sub WriteInfo(s As String)
    Open App.Path & "\saveinf.txt" For Output As #1
    Print #1, s
    Close #1
End Sub

Private Function ReadInfo() As String
    Open App.Path & "\saveinf.txt" For Input As #1
    Dim FileData As String
    Input #1, FileData
    ReadInfo = FileData
    Close #1
End Function

Private Function ChengdeErr(ByVal err As Integer) As String
    ChengdeErr = "未知错误"
    Select Case err
        Case 1
            ChengdeErr = "读卡数据是错误的"
        Case 2
            ChengdeErr = "没有这个用户"
        Case 3
            ChengdeErr = "加密数据出错"
        Case 6
            ChengdeErr = "负气量错误"
        Case 9
            ChengdeErr = "用户号和卡不对应"
        Case 10
            ChengdeErr = "写卡出错"
        Case 11
            ChengdeErr = "读卡出错"
        Case 13
            ChengdeErr = "用户号长度错误"
        Case 14
            ChengdeErr = "用户号字符非法"
        Case 15
            ChengdeErr = "用户号已存在"
        Case 16
            ChengdeErr = "非博冠卡"
        Case 17
            ChengdeErr = "校验卡密码错误"
        Case 18
            ChengdeErr = "数据错误"
        Case 19
            ChengdeErr = "IC卡已报废"
        Case 20
            ChengdeErr = "扣气量大于卡内存量错误"
        Case 21
            ChengdeErr = "非用户卡"
        Case 22
            ChengdeErr = "校验和错误"
        Case 23
            ChengdeErr = "气量超大"
    End Select
End Function
'-----------------------------------------------------end-----------------------------------------------------

Private Sub cmdBuy_Click()
    Dim icDev As Long
    Dim reVal As Long
    Dim userCode As String * 8
    Dim saveInfo As String * 16
    
    icDev = ic_init(My_Commport - 1, 9600) '串口号0开始，所以要减一
    userCode = txtCardID1.Text
    saveInfo = ReadInfo
    reVal = writeCard(icDev, userCode, Val(txtAmount.Text), saveInfo)
    If reVal = 0 Then
        WriteInfo saveInfo
        MsgBox "售气成功。"
    Else
        MsgBox "售气失败，错误:" & ChengdeErr(reVal)
    End If
    ic_exit icDev
End Sub

Private Function CheckForMake() As Boolean
    If Len(Me.txtCardID.Text) <> 8 Then
        MsgBox "卡号不正确，应该为8位数字"
        CheckForMake = False
        Exit Function
    End If
    If Not IsNumeric(Me.txtCardID.Text) Then
        MsgBox "卡号不能包函非数字"
        CheckForMake = False
        Exit Function
    End If
    CheckForMake = True
End Function

Private Sub cmdMake_Click()
    Dim icDev As Long
    Dim reVal As Long
    
    Dim saveInfo As String * 16
    
    If CheckForMake() Then
        icDev = ic_init(My_Commport - 1, 9600) '串口号0开始，所以要减一
        reVal = makeCard(icDev, txtCardID.Text, 0, saveInfo, 129)
        If reVal = 0 Then
            WriteInfo saveInfo
            MsgBox "发卡成功"
        Else
            MsgBox "发卡失败，错误:" & ChengdeErr(reVal)
        End If
        ic_exit icDev
    End If
End Sub

Private Sub cmdRemake_Click()
    Dim icDev As Long
    Dim reVal As Long
    Dim saveInfo As String * 16
    
    If CheckForMake() Then
        icDev = ic_init(My_Commport - 1, 9600) '串口号0开始，所以要减一
        saveInfo = ReadInfo
        reVal = makeCard(icDev, txtCardID.Text, 0, saveInfo, 0)  '//mark=0 最后一次购气未输入到气表内，mark=1 最后一次购气已输入到表内
        If reVal = 0 Then
            WriteInfo saveInfo
            MsgBox "补卡成功"
        Else
            MsgBox "补卡失败，错误:" & ChengdeErr(reVal)
        End If
        ic_exit icDev
    End If
End Sub

Private Sub cmdClear_Click()
    Dim icDev As Long
    Dim reVal As Long
    Dim userCode As String * 8
    
    If CheckForMake() Then
        icDev = ic_init(My_Commport - 1, 9600) '串口号0开始，所以要减一
        userCode = txtCardID.Text
        reVal = clearCard(icDev, userCode)
        If reVal = 0 Then
            MsgBox "清卡成功。"
        Else
            MsgBox "清卡失败，错误:" & ChengdeErr(reVal)
        End If
        ic_exit icDev
    End If
End Sub

Private Sub cmdRead_Click()
    Dim icDev As Long
    Dim reVal As Long
    Dim userCode As String * 8
    Dim cardAmount, meterAmount, TestAmount As Single
    Dim inserted As Byte
    Dim times As Long
    
    icDev = ic_init(My_Commport - 1, 9600) '串口号0开始，所以要减一
    reVal = readCard(icDev, userCode, cardAmount, meterAmount, TestAmount, inserted)
    If reVal = 0 Then
        Call CheckReadCount
        Call IncreaseReadCount
        Me.txtCardID1.Text = userCode
        Me.txtAmount.Text = cardAmount
        Me.List1.AddItem "卡号:" & userCode
        Me.List1.AddItem "卡上余量:" & cardAmount
        Me.List1.AddItem "表上余量:" & meterAmount
        Me.List1.AddItem "测试用量:" & TestAmount
        Me.List1.AddItem IIf(inserted = 0, "未", "已") & "在气表上插卡"
    Else
        MsgBox "读卡失败，错误:" & ChengdeErr(reVal)
    End If
    ic_exit icDev
End Sub

Private Sub Option1_Click(Index As Integer)
    txtTestAmount.Enabled = IIf(Index = 3, True, False)
    txtTestCount.Enabled = IIf(Index = 3, True, False)
End Sub

Private Sub CmdTool_Click(Index As Integer)
    Dim icDev As Long
    Dim reVal As Long
    Dim WriteType As Long  '写工具卡类型*，其传入值见下面说明
    Dim TestAmount As Single ' （in） 写测试卡用量 不大于100，写非测试卡时传入0
    Dim TestTimes As Long '写测试卡可使用次数 不大于255，写非测试卡时传入0

    icDev = ic_init(My_Commport - 1, 9600) '串口号0开始，所以要减一
    If Option1(0).Value Then
        reVal = writetoolCard(icDev, 5, 0, 0)
    ElseIf Option1(1).Value Then
        reVal = writetoolCard(icDev, 6, 0, 0)
    ElseIf Option1(2).Value Then
        reVal = writetoolCard(icDev, 7, 0, 0)
    ElseIf Option1(3).Value Then
        reVal = writetoolCard(icDev, 8, Val(txtTestAmount.Text), Val(txtTestCount.Text))
    ElseIf Option1(4).Value Then
        reVal = writetoolCard(icDev, 9, 0, 0)
    ElseIf Option1(5).Value Then
        reVal = writetoolCard(icDev, 10, 0, 0)
    ElseIf Option1(6).Value Then
        reVal = writetoolCard(icDev, 11, 0, 0)
    End If
    If reVal = 0 Then
        MsgBox "发工具卡成功。"
    Else
        MsgBox "发工具卡失败，错误:" & ChengdeErr(reVal)
    End If
    ic_exit icDev
End Sub


