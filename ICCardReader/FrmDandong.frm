VERSION 5.00
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form FrmDandong 
   Caption         =   "丹东卡"
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
      TabPicture(0)   =   "FrmDandong.frx":0000
      Tab(0).ControlEnabled=   0   'False
      Tab(0).Control(0)=   "Label1(0)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "Label1(1)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).Control(2)=   "cmdClear"
      Tab(0).Control(2).Enabled=   0   'False
      Tab(0).Control(3)=   "cmdRemake"
      Tab(0).Control(3).Enabled=   0   'False
      Tab(0).Control(4)=   "cmdMake"
      Tab(0).Control(4).Enabled=   0   'False
      Tab(0).Control(5)=   "txtCardID"
      Tab(0).Control(5).Enabled=   0   'False
      Tab(0).Control(6)=   "rdIndustry"
      Tab(0).Control(6).Enabled=   0   'False
      Tab(0).Control(7)=   "rdHome"
      Tab(0).Control(7).Enabled=   0   'False
      Tab(0).ControlCount=   8
      TabCaption(1)   =   "售气"
      TabPicture(1)   =   "FrmDandong.frx":001C
      Tab(1).ControlEnabled=   -1  'True
      Tab(1).Control(0)=   "Label10(0)"
      Tab(1).Control(0).Enabled=   0   'False
      Tab(1).Control(1)=   "Label1(2)"
      Tab(1).Control(1).Enabled=   0   'False
      Tab(1).Control(2)=   "Label10(2)"
      Tab(1).Control(2).Enabled=   0   'False
      Tab(1).Control(3)=   "txtAmount"
      Tab(1).Control(3).Enabled=   0   'False
      Tab(1).Control(4)=   "txtCardID1"
      Tab(1).Control(4).Enabled=   0   'False
      Tab(1).Control(5)=   "cmdBuy"
      Tab(1).Control(5).Enabled=   0   'False
      Tab(1).Control(6)=   "cmdRead"
      Tab(1).Control(6).Enabled=   0   'False
      Tab(1).Control(7)=   "List1"
      Tab(1).Control(7).Enabled=   0   'False
      Tab(1).Control(8)=   "cmdBack"
      Tab(1).Control(8).Enabled=   0   'False
      Tab(1).ControlCount=   9
      TabCaption(2)   =   "工具卡"
      TabPicture(2)   =   "FrmDandong.frx":0038
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "Label10(3)"
      Tab(2).Control(1)=   "Label10(4)"
      Tab(2).Control(2)=   "Label10(5)"
      Tab(2).Control(3)=   "Label10(6)"
      Tab(2).Control(4)=   "CmdTool(0)"
      Tab(2).Control(5)=   "Option1(3)"
      Tab(2).Control(6)=   "Option1(2)"
      Tab(2).Control(7)=   "Option1(1)"
      Tab(2).Control(8)=   "Option1(0)"
      Tab(2).Control(9)=   "txtFrontGas"
      Tab(2).Control(10)=   "txtAlarmValue"
      Tab(2).Control(11)=   "txtControlValue"
      Tab(2).Control(12)=   "txtInputValue"
      Tab(2).ControlCount=   13
      Begin VB.TextBox txtInputValue 
         Height          =   375
         Left            =   -72720
         TabIndex        =   29
         Text            =   "0"
         Top             =   1560
         Width           =   1455
      End
      Begin VB.TextBox txtControlValue 
         Height          =   375
         Left            =   -69960
         TabIndex        =   28
         Text            =   "0"
         Top             =   1560
         Width           =   1455
      End
      Begin VB.TextBox txtAlarmValue 
         Height          =   375
         Left            =   -69960
         TabIndex        =   27
         Text            =   "0"
         Top             =   1080
         Width           =   1455
      End
      Begin VB.TextBox txtFrontGas 
         Height          =   375
         Left            =   -72720
         TabIndex        =   26
         Text            =   "0"
         Top             =   1080
         Width           =   1455
      End
      Begin VB.CommandButton cmdBack 
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
         Left            =   3840
         TabIndex        =   21
         Top             =   3840
         Width           =   1095
      End
      Begin VB.OptionButton rdHome 
         Caption         =   "家用卡"
         Height          =   375
         Left            =   -73320
         TabIndex        =   20
         Top             =   1440
         Width           =   975
      End
      Begin VB.OptionButton rdIndustry 
         Caption         =   "工业用卡"
         Height          =   195
         Left            =   -72120
         TabIndex        =   19
         Top             =   1530
         Width           =   1335
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
         TabIndex        =   18
         Top             =   600
         Width           =   2775
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
         Index           =   1
         Left            =   -74040
         TabIndex        =   17
         Top             =   1980
         Value           =   -1  'True
         Width           =   975
      End
      Begin VB.OptionButton Option1 
         Caption         =   "工具卡"
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
         TabIndex        =   16
         Top             =   2520
         Width           =   975
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
         Index           =   3
         Left            =   -74040
         TabIndex        =   15
         Top             =   3000
         Width           =   975
      End
      Begin VB.CommandButton CmdTool 
         Caption         =   "发工具卡"
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
         Index           =   0
         Left            =   -73200
         TabIndex        =   14
         Top             =   4680
         Width           =   1815
      End
      Begin VB.ListBox List1 
         Appearance      =   0  'Flat
         Height          =   2955
         ItemData        =   "FrmDandong.frx":0054
         Left            =   3720
         List            =   "FrmDandong.frx":0056
         TabIndex        =   13
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
         TabIndex        =   12
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
         TabIndex        =   11
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
         TabIndex        =   8
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
         TabIndex        =   7
         Top             =   1200
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
         Caption         =   "清卡"
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
      Begin VB.Label Label10 
         Alignment       =   1  'Right Justify
         Caption         =   "预置气量"
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
         Left            =   -73680
         TabIndex        =   30
         Top             =   1140
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
         Left            =   -71160
         TabIndex        =   25
         Top             =   1620
         Width           =   1095
      End
      Begin VB.Label Label10 
         Alignment       =   1  'Right Justify
         Caption         =   "上限气量"
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
         Left            =   -73680
         TabIndex        =   24
         Top             =   1620
         Width           =   855
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
         Left            =   -70920
         TabIndex        =   23
         Top             =   1140
         Width           =   855
      End
      Begin VB.Label Label10 
         Alignment       =   1  'Right Justify
         Caption         =   "注意：卡上的气量等于本次购买量加上卡上原有余量"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   9
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000000FF&
         Height          =   495
         Index           =   2
         Left            =   240
         TabIndex        =   22
         Top             =   1680
         Width           =   3135
      End
      Begin VB.Label Label1 
         Alignment       =   1  'Right Justify
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
         TabIndex        =   10
         Top             =   720
         Width           =   735
      End
      Begin VB.Label Label10 
         Alignment       =   1  'Right Justify
         Caption         =   "本次购买："
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
         TabIndex        =   9
         Top             =   1260
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
Attribute VB_Name = "FrmDandong"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Cus_Type As Long

'/底层动态库
'///////////明华函数
Private Declare Function CheckOwnCard Lib "DR_Soft" (ByVal port As Long, ByVal Baud As Long) As Long
'读卡
Private Declare Function ReadICCard Lib "DR_Soft" (ByVal port As Long, ByVal Baud As Long, ByVal ICId As String, ByRef ICType As Long, ByRef ICCSpare As Double, ByRef GASCount As Long, ByRef CusType As Long, ByRef ICUsed As Double, ByRef ICMSpare As Double, ByRef ICNum As Long, ByVal ICMark As String, ByVal ICMUType As String) As Long
'写卡
Private Declare Function WriteICCard Lib "DR_Soft" (ByVal port As Long, ByVal Baud As Long, ByVal ICId As String, ByVal OPCode As Long, ByVal GASCount As Long, ByVal ICCSpare As Double, ByVal ICType As Long, ByVal CusType As Long, ByVal ICMark As String) As Long
'清空卡片
Private Declare Function ClearAllCard Lib "DR_Soft" (ByVal port As Long, ByVal Baud As Long) As Long
'制作初始化卡
Private Declare Function MakeIniCard Lib "DR_Soft" (ByVal port As Long, ByVal Baud As Long, ByVal frontGas As Double, ByVal AlarmValue As Double, ByVal InputValue As Double, ByVal controlValue As Double) As Long
'制作工具卡  4：制作清零卡5: 制作管理卡6: 转移卡
Private Declare Function WriteGjkCard Lib "DR_Soft" (ByVal port As Long, ByVal Baud As Long, ByVal GjkType As Long) As Long

Private Function ErrorMsg(ByVal err As Long) As String
    ErrorMsg = "未知错误"
    Select Case err
        Case 1
            ErrorMsg = "卡被更换（卡片核对不符）"
        Case 2
            ErrorMsg = "没有卡"
        Case 3
            ErrorMsg = "读写卡器配置不对"
        Case 4
            ErrorMsg = "读写卡器不工作"
        Case 5
            ErrorMsg = "dll内部故障"
        Case 6
            ErrorMsg = "卡类型错误（新卡为卡型号错误，老卡为卡型号错误及内容算法错误、密码错误等)"
        Case 10
            ErrorMsg = "新卡"
        Case 11
            ErrorMsg = "读卡密码次数失败"
        Case 12
            ErrorMsg = "卡密码次数为0"
        Case 13
            ErrorMsg = "卡片已发行"
        Case 14
            ErrorMsg = "非本系统的卡"
        Case 15
            ErrorMsg = "地区代码错误"
        Case 16
            ErrorMsg = "文件内容错误"
        Case 18
            ErrorMsg = "气量超限"
        Case 19
            ErrorMsg = "溢出"
        Case 97
            ErrorMsg = "读卡错误"
        Case 98
            ErrorMsg = "串口初始化失败"
        Case 100
            ErrorMsg = "配置文件不存在"
    End Select
End Function
'-----------------------------------------------------end-----------------------------------------------------
Private Function CheckForMake() As Boolean
    If Len(Me.txtCardID.Text) <> 8 Then
        MsgBox "卡号不正确，应该为8位数字"
        Exit Function
    End If
    If Not IsNumeric(Me.txtCardID.Text) Then
        MsgBox "卡号不能包函非数字"
        Exit Function
    End If
    If rdHome.Value = False And rdIndustry.Value = False Then
        MsgBox "请选择用户类型"
        Exit Function
    End If
    CheckForMake = True
End Function

Private Sub cmdMake_Click()
    Dim ret As Long
    Dim ICMark As String * 20
    
    If CheckForMake() Then
        ret = WriteICCard(My_Commport - 1, 9600, txtCardID.Text, 127, 0, 0, 32, IIf(rdHome.Value, 1, 2), ICMark)
        If ret = 0 Then
            MsgBox "发卡成功"
        Else
            MsgBox "发卡失败，错误:" & ErrorMsg(ret)
        End If
    End If
End Sub

Private Sub cmdRemake_Click()
    Dim ret As Long
    Dim ICMark As String * 20
    
    If CheckForMake() Then
        ret = WriteICCard(My_Commport - 1, 9600, txtCardID.Text, 127, 0, 0, 32, IIf(rdHome.Value, 1, 2), ICMark)
        If ret = 0 Then
            MsgBox "补卡成功"
        Else
            MsgBox "补卡失败，错误:" & ErrorMsg(ret)
        End If
    End If
End Sub

Private Sub cmdClear_Click()
    Dim ret As Long
    
    ret = ClearAllCard(My_Commport - 1, 9600)
    If ret = 0 Then
        MsgBox "清卡成功。"
    Else
        MsgBox "清卡失败，错误:" & ErrorMsg(ret)
    End If
End Sub

Private Sub cmdRead_Click()
    Dim ICId As String * 10
    Dim ICType As Long
    Dim ICCSpare As Double
    Dim GASCount As Long
    Dim CusType As Long
    Dim ICUsed As Double
    Dim ICMSpare As Double
    Dim ICMark As String * 20
    Dim ICMUType As String * 1
    Dim ret As Long
    ICId = Space(10)
    ICMark = Space(20)
    ICMUType = Space(1)
    
    Me.List1.Clear
    ret = ReadICCard(My_Commport - 1, 9600, ICId, ICType, ICCSpare, GASCount, CusType, ICUsed, ICMSpare, ICNum, ICMark, ICMUType)
    If ret = 0 Then
        Me.txtCardID1.Text = Trim(ICId)
        Me.txtAmount.Text = 0
        Cus_Type = CusType  '用于写卡的时候
        Me.List1.AddItem "卡号:" & Trim(ICId)
        Me.List1.AddItem "用户类型" & IIf(CusType = 1, "家用卡", "工业卡")
        Me.List1.AddItem "卡上余量:" & ICCSpare
        Me.List1.AddItem "表上余量:" & ICMSpare
        Me.cmdBuy.Enabled = True
        Me.cmdBack.Enabled = IIf(ICCSpare > 0, True, False)
    Else
        MsgBox "读卡失败，错误:" & ErrorMsg(ret)
    End If
End Sub

Private Sub cmdBuy_Click()
    Dim ret As Long
    Dim ICMark As String * 20

    ret = WriteICCard(My_Commport - 1, 9600, txtCardID1.Text, 6, Val(txtCount.Text) + 1, Val(txtAmount.Text), 32, Cus_Type, ICMark)
    If ret = 0 Then
        MsgBox "购气成功"
        cmdBuy.Enabled = False
        cmdBack.Enabled = False
    Else
        MsgBox "购气失败，错误:" & ErrorMsg(ret)
    End If
End Sub


Private Sub cmdBack_Click()
    Dim ret As Long
    Dim ICMark As String * 20

    ret = WriteICCard(My_Commport - 1, 9600, txtCardID1.Text, 6, Val(txtCount.Text), 0, 32, Cus_Type, ICMark)
    If ret = 0 Then
        MsgBox "退气成功"
        cmdBuy.Enabled = False
        cmdBack.Enabled = False
    Else
        MsgBox "退气失败，错误:" & ErrorMsg(ret)
    End If
End Sub

Private Sub CmdTool_Click(Index As Integer)
    Dim ret As Long

    If Option1(0).Value Then
        ret = MakeIniCard(My_Commport - 1, 9600, Val(txtFrontGas.Text), Val(txtAlarmValue.Text), Val(txtInputValue.Text), Val(txtControlValue.Text))
    ElseIf Option1(1).Value Then
        ret = WriteGjkCard(My_Commport - 1, 9600, 4)
    ElseIf Option1(2).Value Then
        ret = WriteGjkCard(My_Commport - 1, 9600, 5)
    ElseIf Option1(3).Value Then
        ret = WriteGjkCard(My_Commport - 1, 9600, 6)
    End If
    If ret = 0 Then
        MsgBox "发工具卡成功。"
    Else
        MsgBox "发工具卡失败，错误:" & ErrorMsg(ret)
    End If
End Sub


