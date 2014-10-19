VERSION 5.00
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form FrmHangXing 
   Caption         =   "航星卡"
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
      Tab             =   2
      TabHeight       =   520
      TabCaption(0)   =   "开/补卡"
      TabPicture(0)   =   "FrmHangXing.frx":0000
      Tab(0).ControlEnabled=   0   'False
      Tab(0).Control(0)=   "Label1(0)"
      Tab(0).Control(1)=   "Label1(1)"
      Tab(0).Control(2)=   "cmdClear"
      Tab(0).Control(3)=   "cmdRemake"
      Tab(0).Control(4)=   "cmdMake"
      Tab(0).Control(5)=   "txtCardID"
      Tab(0).Control(6)=   "rdHome"
      Tab(0).Control(7)=   "rdIndustry"
      Tab(0).ControlCount=   8
      TabCaption(1)   =   "售气"
      TabPicture(1)   =   "FrmHangXing.frx":001C
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "Label10(1)"
      Tab(1).Control(1)=   "Label3(2)"
      Tab(1).Control(2)=   "Label10(0)"
      Tab(1).Control(3)=   "Label1(2)"
      Tab(1).Control(4)=   "txtCount"
      Tab(1).Control(5)=   "txtFPID"
      Tab(1).Control(6)=   "txtAmount"
      Tab(1).Control(7)=   "txtCardID1"
      Tab(1).Control(8)=   "CmdBack"
      Tab(1).Control(9)=   "cmdBuqi"
      Tab(1).Control(10)=   "cmdBuy"
      Tab(1).Control(11)=   "cmdRead"
      Tab(1).Control(12)=   "List1"
      Tab(1).ControlCount=   13
      TabCaption(2)   =   "工具卡"
      TabPicture(2)   =   "FrmHangXing.frx":0038
      Tab(2).ControlEnabled=   -1  'True
      Tab(2).Control(0)=   "Text4"
      Tab(2).Control(0).Enabled=   0   'False
      Tab(2).Control(1)=   "Option1(5)"
      Tab(2).Control(1).Enabled=   0   'False
      Tab(2).Control(2)=   "Text12"
      Tab(2).Control(2).Enabled=   0   'False
      Tab(2).Control(3)=   "Text11"
      Tab(2).Control(3).Enabled=   0   'False
      Tab(2).Control(4)=   "CmdTool(0)"
      Tab(2).Control(4).Enabled=   0   'False
      Tab(2).Control(5)=   "Option1(4)"
      Tab(2).Control(5).Enabled=   0   'False
      Tab(2).Control(6)=   "Option1(3)"
      Tab(2).Control(6).Enabled=   0   'False
      Tab(2).Control(7)=   "Option1(2)"
      Tab(2).Control(7).Enabled=   0   'False
      Tab(2).Control(8)=   "Option1(1)"
      Tab(2).Control(8).Enabled=   0   'False
      Tab(2).Control(9)=   "Option1(0)"
      Tab(2).Control(9).Enabled=   0   'False
      Tab(2).Control(10)=   "CmdTool(1)"
      Tab(2).Control(10).Enabled=   0   'False
      Tab(2).ControlCount=   11
      Begin VB.CommandButton CmdTool 
         Caption         =   "发工业表工具卡"
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
         Left            =   3360
         TabIndex        =   32
         Top             =   4200
         Visible         =   0   'False
         Width           =   1815
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
         Index           =   0
         Left            =   960
         TabIndex        =   31
         Top             =   600
         Value           =   -1  'True
         Width           =   2775
      End
      Begin VB.OptionButton Option1 
         Caption         =   "工程卡"
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
         Left            =   960
         TabIndex        =   30
         Top             =   1140
         Width           =   2775
      End
      Begin VB.OptionButton Option1 
         Caption         =   "1方卡"
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
         Left            =   960
         TabIndex        =   29
         Top             =   1680
         Width           =   2775
      End
      Begin VB.OptionButton Option1 
         Caption         =   "限时卡"
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
         Left            =   960
         TabIndex        =   28
         Top             =   2220
         Width           =   2775
      End
      Begin VB.OptionButton Option1 
         Caption         =   "设定累积量卡"
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
         Left            =   960
         TabIndex        =   27
         Top             =   2760
         Width           =   1695
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
         Left            =   1200
         TabIndex        =   26
         Top             =   4200
         Width           =   1815
      End
      Begin VB.TextBox Text11 
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
         Left            =   2040
         TabIndex        =   25
         Text            =   "60"
         Top             =   2280
         Width           =   1575
      End
      Begin VB.TextBox Text12 
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
         Left            =   2640
         TabIndex        =   24
         Top             =   2820
         Width           =   1455
      End
      Begin VB.OptionButton Option1 
         Caption         =   "报警量设定卡"
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
         Left            =   960
         TabIndex        =   23
         Top             =   3420
         Width           =   1695
      End
      Begin VB.TextBox Text4 
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
         Left            =   2640
         TabIndex        =   22
         Top             =   3480
         Width           =   1455
      End
      Begin VB.ListBox List1 
         Appearance      =   0  'Flat
         Height          =   2175
         ItemData        =   "FrmHangXing.frx":0054
         Left            =   -71280
         List            =   "FrmHangXing.frx":0056
         TabIndex        =   21
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
         TabIndex        =   20
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
         TabIndex        =   19
         Top             =   3840
         Width           =   1095
      End
      Begin VB.CommandButton cmdBuqi 
         Caption         =   "补气"
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
         Left            =   -71040
         TabIndex        =   18
         Top             =   3840
         Width           =   1095
      End
      Begin VB.CommandButton CmdBack 
         Caption         =   "退气"
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
         Left            =   -69720
         TabIndex        =   17
         Top             =   3840
         Width           =   1095
      End
      Begin VB.TextBox txtCardID1 
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
         TabIndex        =   12
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
         TabIndex        =   11
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
         TabIndex        =   10
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
         TabIndex        =   9
         Top             =   1800
         Width           =   2175
      End
      Begin VB.OptionButton rdIndustry 
         Caption         =   "工业用卡"
         Height          =   195
         Left            =   -72000
         TabIndex        =   8
         Top             =   1770
         Width           =   1335
      End
      Begin VB.OptionButton rdHome 
         Caption         =   "家用卡"
         Height          =   375
         Left            =   -73200
         TabIndex        =   7
         Top             =   1680
         Width           =   975
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
         Caption         =   "开户"
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
         TabIndex        =   16
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
         TabIndex        =   15
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
         TabIndex        =   14
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
         TabIndex        =   13
         Top             =   1860
         Width           =   855
      End
      Begin VB.Label Label1 
         Caption         =   "6位卡号"
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
Attribute VB_Name = "FrmHangXing"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Dim Int_Type As Integer
Dim Str_Commport As String
Dim Card_Type As Integer
Private Ht As Integer
Private Str_QuID As String  '区域代码
'***********************    operate sle 4442    **************************TestIc_Type
'Declare Function TEST_COM Lib "Saron_Rq.dll" (ByVal icdev As Long) As Integer

'读取卡片类型
Private Declare Function Read_CardType Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Int_CardType As Long) As Integer
'读取卡片信息
Private Declare Function Read_UserCard Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Str_Cardnum As String, str_CityCode As String, Str_type As String) As Integer
'写入卡片信息
Private Declare Function Write_UserCard Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_Cardnum As String, ByVal str_CityCode As String, ByVal Str_type As String) As Integer
'读取8888
Private Declare Function Read_CardBuy Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Str_Flag As String, R_BuyNum As Double, Int_Count As Long, Str_QYID As String) As Integer
Private Declare Function Read_CardBuy_01 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Str_Flag As String, R_BuyNum As Double, Int_Count As Long, Str_QYID As String) As Integer

 
     
Private Declare Function Write_CardBuy Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal R_BuyNum As Double, ByVal Str_QYID As String, ByVal Int_WriteFlag As Long) As Integer
Private Declare Function Write_CardBuy_01 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal R_BuyNum As Double, ByVal Str_QYID As String, ByVal Int_WriteFlag As Long) As Integer

' 测卡88888888888

'Read_CardType(Str_Com:Pchar;Int_Beep:integer;var Int_CardType:integer):smallint;stdcall;

' 写工具卡   20 清零卡  30 工程卡88888888
Private Declare Function Write_Tools Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Int_CardType As Integer, ByVal Str_CityNum As String, ByVal Str_QYID As String, ByVal Int_Offset1 As Integer) As Integer

' 写工具卡   40 为设定卡  50 限时卡8888888888
Private Declare Function Write_Tools1 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Int_CardType As Integer, ByVal D_Num As Double, ByVal Str_QYID As String, ByVal Int_Offset1 As Integer) As Integer
'写发票号

Private Declare Function Write_FPID Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_FP As String) As Integer

'读发票号Write_BackCard

Private Declare Function Read_FPID Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Str_FP As String) As Integer

'擦卡操作88888888888
Private Declare Function Write_BackCard Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_Cardnum As String) As Integer
'验证密码
Private Declare Function CheckCard_Pass Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_Cardnum As String) As Integer

'初始化卡888888888888
Private Declare Function Write_CardInit Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_Pass As String) As Integer
'读取工具卡88888888888888
Private Declare Function Read_Tool Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, D_Num As Double, ByVal Int_Offset1 As Integer, Str_QYID As String) As Integer

'回读用户卡888888888888888888888888
Private Declare Function Read_BackNum Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, D_SYNum As Double, D_LJNum As Double) As Integer
Private Declare Function Read_BackNum_01 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, D_SYNum As Double, D_LJNum As Double) As Integer

Private Declare Function Ver_Number Lib "Srq_01.dll" (Str_Ver As String) As Integer

Private Function IcErrMsg(ByVal intErrCode As Integer) As String
    Dim Str_Err As String
    Select Case intErrCode
        Case -1
           Str_Err = "打开串口错误"
        Case -2
           Str_Err = "关闭串口错误"
        Case -10
           Str_Err = "请插入IC卡"
        Case -3
           Str_Err = "非本系统卡或是卡插反"
        Case -4
           Str_Err = "读卡错误"
        Case -5
           Str_Err = "写卡错误"
        Case -8
           Str_Err = "核对密码错误"
        Case -9
           Str_Err = "转换密码错误"
        Case -6
          Str_Err = "数据转换错误"
        Case -11
          Str_Err = "数据超限"
        Case -13
          Str_Err = "卡已经损坏"
       
        Case -100
          Str_Err = "未知错误"
         Case -101
          Str_Err = "操作无效！请重新操作"
    End Select
    IcErrMsg = Str_Err
End Function

Private Function str_CardType(ByVal Int_CardType As Integer) As String
    Select Case Int_CardType
       Case 0
         str_CardType = "空白卡"
       Case 10
         str_CardType = "用户卡(家用表)"
       Case 90
         str_CardType = "用户卡(工业表)"
       Case 20
         str_CardType = "清零卡"
         Case 30
         str_CardType = "工程卡"
        Case 31
        str_CardType = "工程卡(有数)"
         Case 32
        str_CardType = "工业表工程卡(有数)"
        Case 41
        str_CardType = "多次卡"
        Case 40
        str_CardType = "设定卡"
        Case 50
        str_CardType = "限时卡"
         Case 51
        str_CardType = "报警量设置卡"
        Case 70
        str_CardType = "非本系统卡"
    End Select
End Function
'---------------------------------------end----------------------------------------------------------------






Private Sub CmdBack_Click()
    If Card_Type = 10 Then
        Ht = Write_CardBuy(Str_Commport, 1, 0, Str_QuID, 4)
    Else
        Ht = Write_CardBuy(Str_Commport, 1, 0, Str_QuID, 4)
    End If
    If Ht < 0 Then
      MsgBox IcErrMsg(Ht)
      Exit Sub
    End If
    cmdBuy.Enabled = False
    cmdBuqi.Enabled = False
    CmdBack.Enabled = False
End Sub

Private Sub cmdBuqi_Click()
    If Card_Type = 10 Then
        Ht = Write_CardBuy(Str_Commport, 1, Val(txtAmount.Text), Str_QuID, 3)
    Else
        Ht = Write_CardBuy(Str_Commport, 1, Val(txtAmount.Text), Str_QuID, 3)
    End If
    If Ht < 0 Then
      MsgBox IcErrMsg(Ht)
      Exit Sub
    End If
    cmdBuy.Enabled = False
    cmdBuqi.Enabled = False
    CmdBack.Enabled = False
End Sub

Private Sub cmdBuy_Click()
    If Card_Type = 10 Then
        Ht = Write_CardBuy(Str_Commport, 0, Val(txtAmount.Text), Str_QuID, 2)
    Else
        Ht = Write_CardBuy_01(Str_Commport, 0, Val(txtAmount.Text), Str_QuID, 2)
    End If
    If Ht < 0 Then
      MsgBox IcErrMsg(Ht)
      Exit Sub
    End If
    st = Write_FPID(Str_Commport, 1, Trim(Me.txtFPID.Text))
    If st < 0 Then
      MsgBox IcErrMsg(st), vbExclamation, Title
      Exit Sub
    End If
    cmdBuy.Enabled = False
    cmdBuqi.Enabled = False
    CmdBack.Enabled = False
End Sub

Private Sub Form_Load()
    Int_Type = 0
    Str_QuID = "00000001" '设定区域代码
    Str_Commport = "COM" & My_Commport
End Sub

Private Function CheckForMake() As Boolean
    If Len(Me.txtCardID.Text) <> 6 Then
        MsgBox "卡号不正确，应该为6位数字"
        CheckForMake = False
        Exit Function
    End If
    If Not IsNumeric(Me.txtCardID.Text) Then
        MsgBox "卡号不能包函非数字"
        CheckForMake = False
        Exit Function
    End If
    If Me.rdHome.Value = False And Me.rdIndustry.Value = False Then
        MsgBox "请选择一种卡片类型"
        Exit Function
    End If
    CheckForMake = True
End Function

Private Sub cmdMake_Click()
    Dim str_CardType  As String
    Dim str_CityCode As String
    
    If CheckForMake() Then
        str_CityCode = "0001"
        str_CardType = IIf(rdHome.Value, "0001", "0002")
        Ht = Write_UserCard(Str_Commport, 0, Trim(txtCardID.Text), str_CityCode, str_CardType)
        If Ht < 0 Then
          MsgBox IcErrMsg(Ht)
          Exit Sub
        End If
        If rdHome.Value Then
            Ht = Write_CardBuy(Str_Commport, 1, 0, Str_QuID, 1)
        Else
            Ht = Write_CardBuy_01(Str_Commport, 1, 0, Str_QuID, 1)
        End If
        If st < 0 Then
          MsgBox IcErrMsg(st), vbExclamation, Title
          Exit Sub
        End If
        MsgBox "发卡成功"
    End If
End Sub

Private Sub cmdRemake_Click()
    Dim str_CardType  As String
    Dim str_CityCode As String
    
    If CheckForMake() Then
    str_CityCode = "0001"
        str_CardType = IIf(rdHome.Value, "0001", "0002")
        Ht = Write_UserCard(Str_Commport, 0, Trim(txtCardID.Text), str_CityCode, str_CardType)
        If Ht < 0 Then
          MsgBox IcErrMsg(Ht)
          Exit Sub
        End If
        If rdHome.Value Then
            Ht = Write_CardBuy(Str_Commport, 1, 0, Str_QuID, 3)
        Else
            Ht = Write_CardBuy_01(Str_Commport, 1, 0, Str_QuID, 3)
        End If
        If st < 0 Then
          MsgBox IcErrMsg(st), vbExclamation, Title
          Exit Sub
        End If
        MsgBox "补卡成功"
    End If
End Sub

Private Sub cmdClear_Click()
    Dim msg As Integer
    Dim Int_type1 As Integer
    Dim FInt_CardType As Long
    Dim Str_CardNum1 As String
    Dim Fstr_UserID As String
    Dim FStr_CityNum As String
    Dim Str_type1 As String
    Fstr_UserID = Space(6)
    FStr_CityNum = Space(4)
    Str_type1 = Space(4)
       
    st = Read_CardType(Str_Commport, 0, FInt_CardType)
    If (st < 0) And (st <> -14) Then
        MsgBox IcErrMsg(st), vbExclamation, Title
        Exit Sub
     End If
      
    Select Case FInt_CardType
        Case 10, 90 ' 用户卡
            Card_Type = FInt_CardType
            st = Read_UserCard(Str_Commport, 0, Fstr_UserID, FStr_CityNum, Str_type1)
            Str_CardNum1 = Fstr_UserID
            msg = MsgBox(str_CardType(FInt_CardType) & "要擦除吗？", vbOKCancel + vbQuestion + vbDefaultButton2, "擦除提示：")
            If msg = vbOK Then
                st = Write_BackCard(Str_Commport, 1, Str_CardNum1)
                If st < 0 Then
                    MsgBox IcErrMsg(st), vbExclamation, Title
                    Exit Sub
                End If
                MsgBox "擦卡成功！", vbInformation, Title
             End If
        Case 20, 30, 31, 40, 41, 50, 32, 51 '清零卡
            Str_CardNum1 = "000000"
            msg = MsgBox(str_CardType(FInt_CardType) & "要擦除吗？", vbOKCancel + vbQuestion + vbDefaultButton2, "擦除提示：")
            If msg = vbOK Then
                st = Write_BackCard(Str_Commport, 1, Str_CardNum1)
                If st < 0 Then
                    MsgBox IcErrMsg(st), vbExclamation, Title
                    Exit Sub
                End If
                MsgBox "擦卡成功！", vbInformation, Title
             End If
        Case 0
           MsgBox "此卡已为空白卡！", vbInformation, Title
        Case 70
           MsgBox str_CardType(FInt_CardType) & "，不能擦除！", vbInformation, Title
    End Select
End Sub

Private Sub cmdRead_Click()
    Dim Int_CardType As Long
    Dim Fstr_UserID As String
    Dim FStr_CityNum As String
    Dim Str_type  As String
    Dim Str_Flag As String
    Dim Int_Count As Long
    Dim FR_BuyNum As Double
    Dim Str_QYID As String
    Dim fstr_FP As String
    Dim D_SYNum1 As Double
    Dim D_LJNum1 As Double
    Dim D_Temp As Double
    
    Str_type = Space(4)
    Fstr_UserID = Space(6)
    FStr_CityNum = Space(4)
    Str_Flag = Space(2)
    Str_QYID = Space(8)
    fstr_FP = Space(10)
    
    cmdBuy.Enabled = False
    st = Read_CardType(Str_Commport, 0, Int_CardType)
    If st < 0 Then GoTo ReadFail
    List1.Clear
    List1.AddItem "卡的类型：" & str_CardType(Int_CardType)
    Select Case Int_CardType
        Case 10, 90
            st = Read_UserCard(Str_Commport, 0, Fstr_UserID, FStr_CityNum, Str_type)
            If st < 0 Then GoTo ReadFail
            List1.AddItem "卡号：" & Fstr_UserID
            txtCardID1.Text = Fstr_UserID
            If Int_CardType = 10 Then
                st = Read_CardBuy(Str_Commport, 0, Str_Flag, FR_BuyNum, Int_Count, Str_QYID)
            Else
                st = Read_CardBuy_01(Str_Commport, 0, Str_Flag, FR_BuyNum, Int_Count, Str_QYID)
            End If
            If st < 0 Then GoTo ReadFail
            Me.txtAmount.Text = FR_BuyNum
            Me.txtCount.Text = Int_Count
            st = Read_FPID(Str_Commport, 0, fstr_FP) '发票号
            If st < 0 Then GoTo ReadFail
            txtFPID.Text = Format(Val(fstr_FP) + 1, "0000000000")
            If Int_CardType = 10 Then
                st = Read_BackNum(Str_Commport, 0, D_SYNum1, D_LJNum1)
            Else
                st = Read_BackNum_01(Str_Commport, 0, D_SYNum1, D_LJNum1)
            End If
            st = Read_BackNum(Str_Commport, 0, D_SYNum1, D_LJNum1)
            If st < 0 Then GoTo ReadFail
            If Str_Flag = 11 Then
              List1.AddItem "卡的状态：新卡(未用)"
              List1.AddItem "购买量(立方米)：" & Format(FR_BuyNum, "##0.00")
            ElseIf Str_Flag = 12 Then
              List1.AddItem "卡的状态：旧卡(已用)"
              List1.AddItem "上次购买量(立方米)：" & Format(FR_BuyNum, "##0.00")
              List1.AddItem "剩余量(立方米)：" & Format(D_SYNum1, "##0.00")
              List1.AddItem "累计用量(立方米)：" & Format(D_LJNum1, "##0.00")
              cmdBuy.Enabled = True
            ElseIf Str_Flag = 13 Then
              List1.AddItem "卡的状态：开户卡"
              cmdBuy.Enabled = True
            ElseIf Str_Flag = 14 Then
              List1.AddItem "卡的状态：补卡"
              cmdBuy.Enabled = True
            End If
            cmdBuqi.Enabled = True
            CmdBack.Enabled = True
        Case 31
          st = Read_Tool(Str_Commport, 1, FR_BuyNum, 48, Str_QYID)
          If st < 0 Then GoTo ReadFail
          List1.AddItem "要转的数据(家用表)：" & Format(FR_BuyNum, "##0.00")
        Case 40
          st = Read_Tool(Str_Commport, 1, FR_BuyNum, 48, Str_QYID)
          If st < 0 Then GoTo ReadFail
          List1.AddItem "累计量：" & Format(FR_BuyNum, "##0.00")
        Case 50
          st = Read_Tool(Str_Commport, 1, FR_BuyNum, 48, Str_QYID)
          If st < 0 Then GoTo ReadFail
          List1.AddItem "限时天数(天)：" & FR_BuyNum
        Case 41
          st = Read_Tool(Str_Commport, 1, FR_BuyNum, 48, Str_QYID)
          If st < 0 Then GoTo ReadFail
          List1.AddItem "数据量：" & Format(FR_BuyNum, "0.00")
        Case 51
          st = Read_Tool(Str_Commport, 1, FR_BuyNum, 48, Str_QYID)
          If st < 0 Then GoTo ReadFail
          List1.AddItem "数据量：" & Format(FR_BuyNum, "0.00")
    End Select
    Exit Sub
ReadFail:
    MsgBox IcErrMsg(st), vbExclamation, Title
    Exit Sub
End Sub

Private Sub Option1_Click(Index As Integer)
    Int_Type = Index
End Sub

Private Sub CmdTool_Click(Index As Integer)
    Dim Str_City As String
    Dim Int_Offset As Integer
    Dim D_Temp As Double
    Str_City = "1234"
    Int_Offset = IIf(Index = 0, 48, 80) '家用表48 工业表80
    Select Case Int_Type
    Case 0 '清零
      Ht = Write_Tools(Str_Commport, 1, 20, Str_City, Str_QuID, Int_Offset)
    Case 1 '工程卡
      Ht = Write_Tools(Str_Commport, 1, 30, Str_City, Str_QuID, Int_Offset)
    Case 2 '一方卡
      D_Temp = 1
      Ht = Write_Tools1(Str_Commport, 1, 41, D_Temp, Str_QuID, Int_Offset)
    Case 3 '限时卡
      Ht = Write_Tools1(Str_Commport, 1, 50, Val(Text11.Text), Str_QuID, Int_Offset)
    Case 4 '设定累积量
      Ht = Write_Tools1(Str_Commport, 1, 40, Val(Text12.Text), Str_QuID, Int_Offset)
    Case 5 '报警量设置卡
      Ht = Write_Tools1(Str_Commport, 1, 51, Val(Text4.Text), Str_QuID, Int_Offset)
    End Select
    If Ht < 0 Then
      MsgBox IcErrMsg(Ht)
    Else
      MsgBox "制作工具卡成功"
    End If
End Sub


