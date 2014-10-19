VERSION 5.00
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form FrmBeite 
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
      TabPicture(0)   =   "FrmBeite.frx":0000
      Tab(0).ControlEnabled=   0   'False
      Tab(0).Control(0)=   "txtCardID"
      Tab(0).Control(1)=   "cmdMake"
      Tab(0).Control(2)=   "cmdRemake"
      Tab(0).Control(3)=   "cmdClear"
      Tab(0).Control(4)=   "Label1(1)"
      Tab(0).Control(5)=   "Label1(0)"
      Tab(0).ControlCount=   6
      TabCaption(1)   =   "售气"
      TabPicture(1)   =   "FrmBeite.frx":001C
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
         Left            =   3720
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
ByVal AlarmValue As Integer, ByVal InputValue As Integer, ByVal OverLimit As Long, ByVal Control As Long, ByRef pErrMsg As String) As Long

'用户卡充值函数  每进行一次用户卡购气交易，卡上交易序号加1
Private Declare Function Credit Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByVal ChargeSerialNum As Long, ByVal purchaeAmount As Long, ByRef pErrMsg As String) As Long

'用户卡增款函数  完成操作后，原卡上交易序号保持不变
Private Declare Function Increase Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByRef Buygas As Long, ByVal PurchaseAmount As Long, ByRef pErrMsg As String) As Long

'退气 完成退购交易后，原卡上交易序号保持不变
Private Declare Function Decrease Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, _
    ByVal userNo As String, ByRef Buygas As Long, ByVal PurchaseAmount As Long, ByRef pErrMsg As String) As Long

'读用户卡购气区数据
Private Declare Function rUserData Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByRef userNo As String, _
ByRef ChargeSerialNum As Long, ByRef PurchaseAmount As Long, ByRef AlarmValue As Long, ByRef InputValue As Long, _
ByRef OverLimit As Long, ByRef Control As Long, ByRef pErrMsg As String) As Long

'读用户卡返回写区数据
Private Declare Function rUserDataR Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByRef RStartcode As String, _
ByRef meterNo As String, ByRef TotalBuyGas As Long, ByRef TotalBuyNum As Long, ByRef residualGas As Long, _
ByRef TotalTakeGas As Single, ByRef ChangePassNum As Long, ByRef FMState As Long, ByRef ESAMState As Long, _
ByRef DCState As Long, ByRef CGRState As Long, ByRef Magnet As Long, ByRef Low As Long, ByRef MonthUserGas As String, _
ByRef RDate As String, ByRef pErrMsg As String) As Long

'补卡
Private Declare Function ReissueCard Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByVal AlarmValue As Integer, ByVal InputValue As Integer, ByVal OverLimit As Long, ByVal Control As Long, ByRef pErrMsg As String) As Long

'创建一张换表卡
Private Declare Function ChangeMeter Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByVal AlarmValue As Integer, ByVal InputValue As Integer, ByVal OverLimit As Long, ByVal buy As Long, _
ByVal TotalBuyGas As Long, ByVal TotalBuyNum As Long, ByVal residualGas As Long, ByVal TotalTakeGas As Single, ByVal Control As Long, _
ByRef pErrMsg As String) As Long

'清空卡
Private Declare Function clearCard Lib "PC001" Alias "ClearCard" (ByVal port As Integer, ByVal Baud As Long, ByRef pErrMsg As String) As Long

'制作初使化卡
Private Declare Function MakeIniCard Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal upfrontGas As Long, ByVal AlarmValue As Long, _
ByVal OverLimit As Long, ByVal Control As Long, ByRef pErrMsg As String) As Long

'设置用户卡参数
Private Declare Function SetUserParameter Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByVal AlarmValue As Long, ByVal OverLimit As Long, ByVal Control As Long, ByRef pErrMsg As String) As Long

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


