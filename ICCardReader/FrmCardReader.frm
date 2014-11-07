VERSION 5.00
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form FrmCardReader 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "燃气卡管理"
   ClientHeight    =   6330
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   7995
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6330
   ScaleWidth      =   7995
   StartUpPosition =   1  'CenterOwner
   Begin MSComctlLib.Toolbar Toolbar1 
      Align           =   1  'Align Top
      Height          =   615
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   7995
      _ExtentX        =   14102
      _ExtentY        =   1085
      ButtonWidth     =   1455
      ButtonHeight    =   926
      Appearance      =   1
      _Version        =   393216
      BeginProperty Buttons {66833FE8-8583-11D1-B16A-00C0F0283628} 
         NumButtons      =   2
         BeginProperty Button1 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "设置参数"
         EndProperty
         BeginProperty Button2 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "退出系统"
         EndProperty
      EndProperty
   End
   Begin TabDlg.SSTab SSTab1 
      Height          =   5295
      Left            =   120
      TabIndex        =   1
      Top             =   840
      Width           =   7695
      _ExtentX        =   13573
      _ExtentY        =   9340
      _Version        =   393216
      Style           =   1
      Tab             =   2
      TabHeight       =   520
      TabCaption(0)   =   "开/补卡"
      TabPicture(0)   =   "FrmCardReader.frx":0000
      Tab(0).ControlEnabled=   0   'False
      Tab(0).Control(0)=   "Label1(0)"
      Tab(0).Control(1)=   "rdIndustry"
      Tab(0).Control(2)=   "rdHome"
      Tab(0).Control(3)=   "txtCardID"
      Tab(0).Control(4)=   "cmdMake"
      Tab(0).Control(5)=   "cmdRemake"
      Tab(0).ControlCount=   6
      TabCaption(1)   =   "售气"
      TabPicture(1)   =   "FrmCardReader.frx":001C
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "Label1(2)"
      Tab(1).Control(0).Enabled=   0   'False
      Tab(1).Control(1)=   "Label10(0)"
      Tab(1).Control(1).Enabled=   0   'False
      Tab(1).Control(2)=   "Label3(2)"
      Tab(1).Control(2).Enabled=   0   'False
      Tab(1).Control(3)=   "Label10(1)"
      Tab(1).Control(3).Enabled=   0   'False
      Tab(1).Control(4)=   "List1"
      Tab(1).Control(4).Enabled=   0   'False
      Tab(1).Control(5)=   "cmdRead"
      Tab(1).Control(5).Enabled=   0   'False
      Tab(1).Control(6)=   "cmdBuy"
      Tab(1).Control(6).Enabled=   0   'False
      Tab(1).Control(7)=   "CmdBack"
      Tab(1).Control(7).Enabled=   0   'False
      Tab(1).Control(8)=   "txtCardID1"
      Tab(1).Control(8).Enabled=   0   'False
      Tab(1).Control(9)=   "txtAmount"
      Tab(1).Control(9).Enabled=   0   'False
      Tab(1).Control(10)=   "txtFPID"
      Tab(1).Control(10).Enabled=   0   'False
      Tab(1).Control(11)=   "txtCount"
      Tab(1).Control(11).Enabled=   0   'False
      Tab(1).Control(12)=   "cmdClear"
      Tab(1).Control(12).Enabled=   0   'False
      Tab(1).ControlCount=   13
      TabCaption(2)   =   "工具卡"
      TabPicture(2)   =   "FrmCardReader.frx":0038
      Tab(2).ControlEnabled=   -1  'True
      Tab(2).Control(0)=   "Label10(6)"
      Tab(2).Control(0).Enabled=   0   'False
      Tab(2).Control(1)=   "Label10(5)"
      Tab(2).Control(1).Enabled=   0   'False
      Tab(2).Control(2)=   "Label10(4)"
      Tab(2).Control(2).Enabled=   0   'False
      Tab(2).Control(3)=   "Label10(3)"
      Tab(2).Control(3).Enabled=   0   'False
      Tab(2).Control(4)=   "Option1(1)"
      Tab(2).Control(4).Enabled=   0   'False
      Tab(2).Control(5)=   "CmdTool"
      Tab(2).Control(5).Enabled=   0   'False
      Tab(2).Control(6)=   "txtInputValue"
      Tab(2).Control(6).Enabled=   0   'False
      Tab(2).Control(7)=   "txtControlValue"
      Tab(2).Control(7).Enabled=   0   'False
      Tab(2).Control(8)=   "txtAlarmValue"
      Tab(2).Control(8).Enabled=   0   'False
      Tab(2).Control(9)=   "txtFrontGas"
      Tab(2).Control(9).Enabled=   0   'False
      Tab(2).Control(10)=   "Option1(0)"
      Tab(2).Control(10).Enabled=   0   'False
      Tab(2).Control(11)=   "Option1(2)"
      Tab(2).Control(11).Enabled=   0   'False
      Tab(2).ControlCount=   12
      Begin VB.OptionButton Option1 
         Caption         =   "转移卡"
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
         Left            =   720
         TabIndex        =   32
         Top             =   2760
         Width           =   2775
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
         Left            =   720
         TabIndex        =   27
         Top             =   480
         Width           =   2775
      End
      Begin VB.TextBox txtFrontGas 
         Height          =   375
         Left            =   2040
         TabIndex        =   26
         Text            =   "0"
         Top             =   960
         Width           =   1455
      End
      Begin VB.TextBox txtAlarmValue 
         Height          =   375
         Left            =   4800
         TabIndex        =   25
         Text            =   "0"
         Top             =   960
         Width           =   1455
      End
      Begin VB.TextBox txtControlValue 
         Height          =   375
         Left            =   4800
         TabIndex        =   24
         Text            =   "0"
         Top             =   1440
         Width           =   1455
      End
      Begin VB.TextBox txtInputValue 
         Height          =   375
         Left            =   2040
         TabIndex        =   23
         Text            =   "0"
         Top             =   1440
         Width           =   1455
      End
      Begin VB.CommandButton cmdClear 
         Caption         =   "清除卡片(&A)"
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
         Left            =   -69240
         TabIndex        =   22
         Top             =   3840
         Width           =   1335
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
         Left            =   -71160
         TabIndex        =   16
         Top             =   3000
         Width           =   1575
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
         Left            =   -73080
         TabIndex        =   15
         Top             =   3000
         Width           =   1455
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
         Left            =   -72600
         TabIndex        =   14
         Top             =   1320
         Width           =   2895
      End
      Begin VB.OptionButton rdHome 
         Caption         =   "家用卡"
         Height          =   375
         Left            =   -72600
         TabIndex        =   13
         Top             =   2160
         Width           =   975
      End
      Begin VB.OptionButton rdIndustry 
         Caption         =   "工业用卡"
         Height          =   195
         Left            =   -71400
         TabIndex        =   12
         Top             =   2250
         Width           =   1335
      End
      Begin VB.TextBox txtCount 
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
         TabIndex        =   11
         Top             =   1800
         Width           =   2175
      End
      Begin VB.TextBox txtFPID 
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
         Height          =   450
         Left            =   -73800
         TabIndex        =   10
         Top             =   2400
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
         TabIndex        =   8
         Top             =   660
         Width           =   2175
      End
      Begin VB.CommandButton CmdBack 
         Caption         =   "退气(&D)"
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
         Left            =   -70920
         TabIndex        =   7
         Top             =   3840
         Width           =   1335
      End
      Begin VB.CommandButton cmdBuy 
         Caption         =   "售气(&S)"
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
         Left            =   -72600
         TabIndex        =   6
         Top             =   3840
         Width           =   1335
      End
      Begin VB.CommandButton cmdRead 
         Caption         =   "读卡(&R)"
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
         Left            =   -74280
         TabIndex        =   5
         Top             =   3840
         Width           =   1335
      End
      Begin VB.ListBox List1 
         Appearance      =   0  'Flat
         Height          =   2565
         ItemData        =   "FrmCardReader.frx":0054
         Left            =   -71280
         List            =   "FrmCardReader.frx":0056
         TabIndex        =   4
         Top             =   660
         Width           =   3615
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
         Left            =   1200
         TabIndex        =   3
         Top             =   4200
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
         Index           =   1
         Left            =   720
         TabIndex        =   2
         Top             =   2040
         Width           =   2775
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
         Left            =   3840
         TabIndex        =   31
         Top             =   1020
         Width           =   855
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
         Left            =   1080
         TabIndex        =   30
         Top             =   1500
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
         Left            =   3600
         TabIndex        =   29
         Top             =   1500
         Width           =   1095
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
         Left            =   1080
         TabIndex        =   28
         Top             =   1020
         Width           =   855
      End
      Begin VB.Label Label1 
         Alignment       =   1  'Right Justify
         Caption         =   "卡号"
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
         Left            =   -73560
         TabIndex        =   21
         Top             =   1380
         Width           =   735
      End
      Begin VB.Label Label10 
         Alignment       =   1  'Right Justify
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
         TabIndex        =   20
         Top             =   1860
         Width           =   855
      End
      Begin VB.Label Label3 
         Alignment       =   1  'Right Justify
         Caption         =   "发票号"
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
         Left            =   -74880
         TabIndex        =   19
         Top             =   2520
         Width           =   975
      End
      Begin VB.Label Label10 
         Alignment       =   1  'Right Justify
         Caption         =   "购买量"
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
         TabIndex        =   18
         Top             =   1260
         Width           =   855
      End
      Begin VB.Label Label1 
         Alignment       =   1  'Right Justify
         Caption         =   "卡  号"
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
         TabIndex        =   17
         Top             =   720
         Width           =   735
      End
   End
End
Attribute VB_Name = "FrmCardReader"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private m_HangXing As HangXing
Private m_goldcard As GoldCard
Private m_DanDong As DanDong
Private m_ChengDe As ChengDe
Private Supplier As Integer '卡片供应商 1航星卡 2浙江金卡 3丹东卡 4承德卡

Private Sub Form_Load()
    Dim strTemp As String
    strTemp = GetIniStr("Reader", "Commport")
    My_Commport = Val(strTemp)
    Set m_HangXing = New HangXing
    Set m_goldcard = New GoldCard
    Set m_DanDong = New DanDong
    Set m_ChengDe = New ChengDe
End Sub

Private Sub cmdMake_Click()
    Select Case Supplier
        Case 1
            m_HangXing.Make
        Case 2
            m_goldcard.Make
        Case 3
            m_DanDong.Make
        Case 4
            m_ChengDe.Make
    End Select
End Sub

Private Sub cmdRemake_Click()
    Select Case Supplier
        Case 1
            m_HangXing.Remake
        Case 2
            m_goldcard.Remake
        Case 3
            m_DanDong.Remake
        Case 4
            m_ChengDe.Remake
    End Select
End Sub

Private Sub cmdRead_Click()
    If m_HangXing.IsMyCard() Then
        m_HangXing.Read
        Supplier = 1
    ElseIf m_goldcard.IsMyCard() Then
        m_goldcard.Read
        Supplier = 2
    ElseIf m_DanDong.IsMyCard() Then
        m_DanDong.Read
        Supplier = 3
    ElseIf m_ChengDe.IsMyCard() Then
        m_ChengDe.Read
        Supplier = 4
    Else
        MsgBox "未识别的卡片类别"
    End If
End Sub

Private Sub cmdBuy_Click()
    Select Case Supplier
        Case 1
            m_HangXing.Buy
        Case 2
            m_goldcard.Buy
        Case 3
            m_DanDong.Buy
        Case 4
            m_ChengDe.Buy
    End Select
End Sub

Private Sub CmdBack_Click()
    Select Case Supplier
        Case 1
            m_HangXing.Back
        Case 2
            m_goldcard.Back
        Case 3
            m_DanDong.Back
        Case 4
            m_ChengDe.Back
    End Select
End Sub

Private Sub cmdClear_Click()
    If MsgBox("清除卡片后，卡内信息将丢失，是否要清除卡片？", vbYesNo, "警告") = vbYes Then
        Select Case Supplier
        Case 1
            m_HangXing.Clear
        Case 2
            m_goldcard.Clear
        Case 3
            m_DanDong.Clear
        Case 4
            m_ChengDe.Clear
    End Select
    End If
End Sub

Private Sub CmdTool_Click()
    Select Case Supplier
        Case 1
            m_HangXing.MakeTool
        Case 2
            m_goldcard.MakeTool
        Case 3
            m_DanDong.MakeTool
        Case 4
            m_ChengDe.MakeTool
    End Select
End Sub

Private Sub Toolbar1_ButtonClick(ByVal Button As MSComctlLib.Button)
    Select Case Button.Index
        Case 1 '"设置"
            FrmSetting.Show vbModal
        Case 2 '"退出"
            Unload Me
    End Select
End Sub

