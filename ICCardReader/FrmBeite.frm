VERSION 5.00
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form FrmBeite 
   Caption         =   "贝特卡"
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
      TabHeight       =   520
      TabCaption(0)   =   "开/补卡"
      TabPicture(0)   =   "FrmBeite.frx":0000
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "Label1(0)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "Label1(1)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).Control(2)=   "Label10(6)"
      Tab(0).Control(2).Enabled=   0   'False
      Tab(0).Control(3)=   "Label10(5)"
      Tab(0).Control(3).Enabled=   0   'False
      Tab(0).Control(4)=   "Label10(4)"
      Tab(0).Control(4).Enabled=   0   'False
      Tab(0).Control(5)=   "Label10(3)"
      Tab(0).Control(5).Enabled=   0   'False
      Tab(0).Control(6)=   "Label1(5)"
      Tab(0).Control(6).Enabled=   0   'False
      Tab(0).Control(7)=   "Label1(6)"
      Tab(0).Control(7).Enabled=   0   'False
      Tab(0).Control(8)=   "Label1(7)"
      Tab(0).Control(8).Enabled=   0   'False
      Tab(0).Control(9)=   "Label1(8)"
      Tab(0).Control(9).Enabled=   0   'False
      Tab(0).Control(10)=   "cmdClear"
      Tab(0).Control(10).Enabled=   0   'False
      Tab(0).Control(11)=   "cmdRemake"
      Tab(0).Control(11).Enabled=   0   'False
      Tab(0).Control(12)=   "cmdMake"
      Tab(0).Control(12).Enabled=   0   'False
      Tab(0).Control(13)=   "txtCardID"
      Tab(0).Control(13).Enabled=   0   'False
      Tab(0).Control(14)=   "txtInputValue"
      Tab(0).Control(14).Enabled=   0   'False
      Tab(0).Control(15)=   "txtControlValue"
      Tab(0).Control(15).Enabled=   0   'False
      Tab(0).Control(16)=   "txtAlarmValue"
      Tab(0).Control(16).Enabled=   0   'False
      Tab(0).Control(17)=   "txtOverLimit"
      Tab(0).Control(17).Enabled=   0   'False
      Tab(0).ControlCount=   18
      TabCaption(1)   =   "售气"
      TabPicture(1)   =   "FrmBeite.frx":001C
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "List1"
      Tab(1).Control(1)=   "cmdRead"
      Tab(1).Control(2)=   "cmdBuy"
      Tab(1).Control(3)=   "txtCardID1"
      Tab(1).Control(4)=   "txtAmount"
      Tab(1).Control(5)=   "txtFPID"
      Tab(1).Control(6)=   "txtCount"
      Tab(1).Control(7)=   "Label1(2)"
      Tab(1).Control(8)=   "Label10(0)"
      Tab(1).Control(9)=   "Label3(2)"
      Tab(1).Control(10)=   "Label10(1)"
      Tab(1).ControlCount=   11
      TabCaption(2)   =   "工具卡"
      TabPicture(2)   =   "FrmBeite.frx":0038
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
      Begin VB.TextBox txtOverLimit 
         Height          =   375
         Left            =   2160
         TabIndex        =   33
         Text            =   "0"
         Top             =   1320
         Width           =   2055
      End
      Begin VB.TextBox txtAlarmValue 
         Height          =   375
         Left            =   2160
         TabIndex        =   32
         Text            =   "0"
         Top             =   2280
         Width           =   2055
      End
      Begin VB.TextBox txtControlValue 
         Height          =   375
         Left            =   2160
         TabIndex        =   31
         Text            =   "0"
         Top             =   2760
         Width           =   2055
      End
      Begin VB.TextBox txtInputValue 
         Height          =   375
         Left            =   2160
         TabIndex        =   30
         Text            =   "0"
         Top             =   1800
         Width           =   2055
      End
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
         ItemData        =   "FrmBeite.frx":0054
         Left            =   -71280
         List            =   "FrmBeite.frx":0056
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
         Left            =   -73800
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
         Left            =   -72480
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
         Left            =   -73800
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
         Left            =   -73800
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
         Left            =   -73800
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
         Left            =   -73800
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
         Left            =   2160
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
         Left            =   840
         TabIndex        =   3
         Top             =   3480
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
         Left            =   2400
         TabIndex        =   2
         Top             =   3480
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
         Left            =   3840
         TabIndex        =   1
         Top             =   3480
         Width           =   1335
      End
      Begin VB.Label Label1 
         Caption         =   "0-99"
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
         Index           =   8
         Left            =   4320
         TabIndex        =   41
         Top             =   2820
         Width           =   735
      End
      Begin VB.Label Label1 
         Caption         =   "0-65535"
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
         Index           =   7
         Left            =   4320
         TabIndex        =   40
         Top             =   2340
         Width           =   735
      End
      Begin VB.Label Label1 
         Caption         =   "0-65535"
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
         Index           =   6
         Left            =   4320
         TabIndex        =   39
         Top             =   1860
         Width           =   735
      End
      Begin VB.Label Label1 
         Caption         =   "0-255"
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
         Index           =   5
         Left            =   4320
         TabIndex        =   38
         Top             =   1380
         Width           =   2535
      End
      Begin VB.Label Label10 
         Alignment       =   1  'Right Justify
         Caption         =   "报警气量"
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
         Left            =   1080
         TabIndex        =   37
         Top             =   2340
         Width           =   855
      End
      Begin VB.Label Label10 
         Alignment       =   1  'Right Justify
         Caption         =   "充值下限"
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
         Left            =   1080
         TabIndex        =   36
         Top             =   1860
         Width           =   855
      End
      Begin VB.Label Label10 
         Alignment       =   1  'Right Justify
         Caption         =   "大流量控制"
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
         Index           =   5
         Left            =   840
         TabIndex        =   35
         Top             =   2820
         Width           =   1095
      End
      Begin VB.Label Label10 
         Alignment       =   1  'Right Justify
         Caption         =   "透支限额"
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
         Index           =   6
         Left            =   1080
         TabIndex        =   34
         Top             =   1380
         Width           =   855
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
         Left            =   -74640
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
         Left            =   -74760
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
         Left            =   -74760
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
         Left            =   -74760
         TabIndex        =   11
         Top             =   1860
         Width           =   855
      End
      Begin VB.Label Label1 
         Caption         =   "10位数字"
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
         Left            =   4320
         TabIndex        =   6
         Top             =   900
         Width           =   2295
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
         Left            =   1320
         TabIndex        =   5
         Top             =   900
         Width           =   735
      End
   End
End
Attribute VB_Name = "FrmBeite"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'/底层动态库

'用户卡个人化函数
'1.只有处于初始状态的卡片才能进行卡片的个人化操作
'2.完成个人化操作后的用户卡卡上预购气量为零
Private Declare Function Personalize Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByVal AlarmValue As Long, ByVal InputValue As Long, ByVal overlimit As Long, ByVal Control As Long, ByVal pErrMsg As String) As Long

'用户卡充值函数  每进行一次用户卡购气交易，卡上交易序号加1
Private Declare Function Credit Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByVal ChargeSerialNum As Long, ByVal purchaeAmount As Long, ByVal pErrMsg As String) As Long

'用户卡增款函数  完成操作后，原卡上交易序号保持不变
Private Declare Function Increase Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByRef Buygas As Long, ByVal PurchaseAmount As Long, ByVal pErrMsg As String) As Long

'退气 完成退购交易后，原卡上交易序号保持不变
Private Declare Function Decrease Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, _
    ByVal userNo As String, ByRef Buygas As Long, ByVal PurchaseAmount As Long, ByVal pErrMsg As String) As Long

'读用户卡购气区数据
Private Declare Function rUserData Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByRef userNo As String, _
ByRef ChargeSerialNum As Long, ByRef PurchaseAmount As Long, ByRef AlarmValue As Long, ByRef InputValue As Long, _
ByRef overlimit As Long, ByRef Control As Long, ByVal pErrMsg As String) As Long

'读用户卡返回写区数据
Private Declare Function rUserDataR Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByRef RStartcode As String, _
ByRef meterNo As String, ByRef TotalBuyGas As Long, ByRef TotalBuyNum As Long, ByRef residualGas As Long, _
ByRef TotalTakeGas As Single, ByRef ChangePassNum As Long, ByRef FMState As Long, ByRef ESAMState As Long, _
ByRef DCState As Long, ByRef CGRState As Long, ByRef Magnet As Long, ByRef Low As Long, ByRef MonthUserGas As String, _
ByRef RDate As String, ByVal pErrMsg As String) As Long

'补卡
Private Declare Function ReissueCard Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, ByVal AlarmValue As Integer, ByVal InputValue As Integer, ByVal overlimit As Long, ByVal Control As Long, ByVal ChargeSerialNum As Long, ByVal PurchaseAmount As Long, ByVal pErrMsg As String) As Long

'创建一张换表卡
Private Declare Function ChangeMeter Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByVal AlarmValue As Integer, ByVal InputValue As Integer, ByVal overlimit As Long, ByVal buy As Long, _
ByVal TotalBuyGas As Long, ByVal TotalBuyNum As Long, ByVal residualGas As Long, ByVal TotalTakeGas As Single, ByVal Control As Long, _
ByVal pErrMsg As String) As Long


'制作初使化卡
Private Declare Function MakeIniCard Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal upfrontGas As Long, ByVal AlarmValue As Long, _
ByVal overlimit As Long, ByVal Control As Long, ByVal pErrMsg As String) As Long

'设置用户卡参数
Private Declare Function SetUserParameter Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByVal AlarmValue As Long, ByVal overlimit As Long, ByVal Control As Long, ByVal pErrMsg As Long) As Long

'清空卡
Private Declare Function clearCard Lib "PC001" Alias "ClearCard" (ByVal port As Integer, ByVal Baud As Long, ByVal pErrMsg As Long) As Long

'-----------------------------------------------------end-----------------------------------------------------

Private Function CheckForMake() As Boolean
    If Len(Me.txtCardID.Text) <> 10 Then
        MsgBox "卡号不正确，应该为10位数字"
        Exit Function
    End If
    If Not IsNumeric(Me.txtCardID.Text) Then
        MsgBox "卡号不能包函非数字"
        Exit Function
    End If
    If Val(txtOverLimit.Text) < 0 Or Val(txtOverLimit.Text) > 255 Then
        MsgBox "透支限额不在范围内"
        Exit Function
    End If
    If Val(txtInputValue.Text) < 0 Or Val(txtInputValue.Text) > 65535 Then
        MsgBox "充值下限不在范围内"
        Exit Function
    End If
    If Val(txtAlarmValue.Text) < 0 Or Val(txtAlarmValue.Text) > 65535 Then
        MsgBox "报警气量不在范围内"
        Exit Function
    End If
    If Val(txtControlValue.Text) < 0 Or Val(txtControlValue.Text) > 99 Then
        MsgBox "大流量门限不在范围内"
        Exit Function
    End If
    CheckForMake = True
End Function

Private Sub cmdMake_Click()
    Dim ret As Long
    Dim pErrMsg As String
    Dim AlarmValue As Long
    Dim InputValue As Long
    Dim overlimit As Long
    Dim controlValue As Long
    
    If CheckForMake() Then
        AlarmValue = Val(txtAlarmValue.Text)
        InputValue = Val(txtInputValue.Text)
        controlValue = Val(txtControlValue.Text)
        overlimit = Val(txtOverLimit.Text)
        ret = Personalize(My_Commport, 9600, txtCardID.Text, AlarmValue, InputValue, overlimit, controlValue, pErrMsg)
        If ret = 1 Then
            MsgBox "发卡成功"
        Else
            MsgBox "发卡失败，错误:" & pErrMsg
        End If
    End If
End Sub

Private Sub cmdRemake_Click()
    Dim ret As Long
    Dim pErrMsg As String
    Dim AlarmValue As Long
    Dim InputValue As Long
    Dim overlimit As Long
    Dim controlValue As Long
    
    If CheckForMake() Then
        AlarmValue = Val(txtAlarmValue.Text)
        InputValue = Val(txtInputValue.Text)
        controlValue = Val(txtControlValue.Text)
        overlimit = Val(txtOverLimit.Text)
        ret = ReissueCard(My_Commport, 9600, txtCardID.Text, AlarmValue, InputValue, overlimit, controlValue, 0, 0, pErrMsg)
        If ret = 1 Then
            MsgBox "补卡成功"
        Else
            MsgBox "补卡失败，错误:" & pErrMsg
        End If
    End If
End Sub

Private Sub cmdClear_Click()
    Dim ret As Long
    Dim pErrMsg As String
    
    pErrMsg = Space(1024)
    ret = clearCard(My_Commport, 9600, pErrMsg)
    If ret = 1 Then
        MsgBox "清卡成功"
    Else
        'MsgBox "清卡失败，错误:" & pErrMsg
    End If
End Sub



Private Sub CmdTool_Click(Index As Integer)
'    Dim icDev As Long
'    Dim ret As Long
'    Dim WriteType As Long  '写工具卡类型*，其传入值见下面说明
'    Dim TestAmount As Single ' （in） 写测试卡用量 不大于100，写非测试卡时传入0
'    Dim TestTimes As Long '写测试卡可使用次数 不大于255，写非测试卡时传入0
'
'    icDev = ic_init(My_Commport - 1, 9600) '串口号0开始，所以要减一
'    If Option1(0).Value Then
'        ret = writetoolCard(icDev, 5, 0, 0)
'    ElseIf Option1(1).Value Then
'        ret = writetoolCard(icDev, 6, 0, 0)
'    ElseIf Option1(2).Value Then
'        ret = writetoolCard(icDev, 7, 0, 0)
'    ElseIf Option1(3).Value Then
'        ret = writetoolCard(icDev, 8, Val(txtTestAmount.Text), Val(txtTestCount.Text))
'    ElseIf Option1(4).Value Then
'        ret = writetoolCard(icDev, 9, 0, 0)
'    ElseIf Option1(5).Value Then
'        ret = writetoolCard(icDev, 10, 0, 0)
'    ElseIf Option1(6).Value Then
'        ret = writetoolCard(icDev, 11, 0, 0)
'    End If
'    If ret = 0 Then
'        MsgBox "发工具卡成功。"
'    Else
'        MsgBox "发工具卡失败，错误:" & ChengdeErr(ret)
'    End If
End Sub


