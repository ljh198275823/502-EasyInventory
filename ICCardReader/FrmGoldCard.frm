VERSION 5.00
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form FrmGoldCard 
   Caption         =   "浙江金卡"
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
      Tabs            =   1
      TabHeight       =   520
      TabCaption(0)   =   "购气"
      TabPicture(0)   =   "FrmGoldCard.frx":0000
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "Label1(2)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "Label10(0)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).Control(2)=   "Label3(2)"
      Tab(0).Control(2).Enabled=   0   'False
      Tab(0).Control(3)=   "Label10(1)"
      Tab(0).Control(3).Enabled=   0   'False
      Tab(0).Control(4)=   "cmdRead"
      Tab(0).Control(4).Enabled=   0   'False
      Tab(0).Control(5)=   "cmdBuy"
      Tab(0).Control(5).Enabled=   0   'False
      Tab(0).Control(6)=   "txtCardID1"
      Tab(0).Control(6).Enabled=   0   'False
      Tab(0).Control(7)=   "txtAmount"
      Tab(0).Control(7).Enabled=   0   'False
      Tab(0).Control(8)=   "txtCardType"
      Tab(0).Control(8).Enabled=   0   'False
      Tab(0).Control(9)=   "txtCount"
      Tab(0).Control(9).Enabled=   0   'False
      Tab(0).Control(10)=   "cmdClear"
      Tab(0).Control(10).Enabled=   0   'False
      Tab(0).ControlCount=   11
      Begin VB.CommandButton cmdClear 
         Caption         =   "清空卡"
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
         Left            =   4320
         TabIndex        =   11
         Top             =   4140
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
         Left            =   2880
         TabIndex        =   6
         Top             =   2100
         Width           =   2175
      End
      Begin VB.TextBox txtCardType 
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
         Left            =   2880
         TabIndex        =   5
         Top             =   2700
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
         Left            =   2880
         TabIndex        =   4
         Top             =   1500
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
         Left            =   2880
         TabIndex        =   3
         Top             =   960
         Width           =   2175
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
         Left            =   2880
         TabIndex        =   2
         Top             =   4140
         Width           =   1095
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
         Left            =   1560
         TabIndex        =   1
         Top             =   4140
         Width           =   1095
      End
      Begin VB.Label Label10 
         Alignment       =   1  'Right Justify
         Caption         =   "购气次数："
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
         Left            =   1560
         TabIndex        =   10
         Top             =   2160
         Width           =   1215
      End
      Begin VB.Label Label3 
         Alignment       =   1  'Right Justify
         Caption         =   "卡片类型："
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
         Left            =   1560
         TabIndex        =   9
         Top             =   2805
         Width           =   1215
      End
      Begin VB.Label Label10 
         Alignment       =   1  'Right Justify
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
         Left            =   1920
         TabIndex        =   8
         Top             =   1560
         Width           =   855
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
         Left            =   2040
         TabIndex        =   7
         Top             =   1020
         Width           =   735
      End
   End
End
Attribute VB_Name = "FrmGoldCard"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

''读卡
'参数:     intcom: 串口号 com1为0, com2为1
'Baud：串口通讯波特率（1200－115200）。
'          vskh：用户卡号（00000000－99999999）；
'vlql： 可用气量；
'vics: 表卡内购气次数
'viklx：表类型，1民用表，2工业表，3清零卡，4工程卡（即转移卡）
'  返回值：int
'          = 0：正确
'其它:  厂家自行定义
Private Declare Function Gold_Readcard Lib "goldcard" (ByVal intcom As Integer, ByVal Baud As Long, ByRef userNo As String, ByRef vlql As Long, ByRef vics As Integer, ByRef viklx As Integer) As Long

'购气
Private Declare Function Gold_Buycard Lib "goldcard" (ByVal intcom As Integer, ByVal Baud As Long, ByVal userNo As String, ByVal vlql As Long, ByVal vics As Long) As Long

'清除卡内气量
Private Declare Function Gold_Clearcard Lib "goldcard" (ByVal intcom As Integer, ByVal Baud As Long, ByVal userNo As String) As Long

'返回错误信息字符串
Private Declare Sub Error_message Lib "goldcard" (ByVal errCode As Long, ByVal msg As String)

'检查是否是本公司的卡 返回值 0：用户卡；1：工具卡；其它出错。
Private Declare Function Gold_CheckCard Lib "goldcard" (ByVal intcom As Integer, ByVal Baud As Long, ByRef error As String) As Long

'注意事项
'1、 购气次数一定要正确，购气次数只能比上次购气次数大，否则表会不认卡。
'2、 购气写卡时，如果卡内还有气量，DLL会把卡内的气量替换了，并不会相加。

'-----------------------------------end--------------------------------------------------------------------

Private Sub cmdBuy_Click()
    Dim ret As Long
    Dim msg As String * 50
    
    ret = Gold_Buycard(My_Commport - 1, 9600, txtCardID1.Text, Val(txtAmount.Text), Val(txtCount.Text) + 1)
    If ret = 0 Then
        MsgBox "售气成功。"
        Me.cmdBuy.Enabled = False
        Me.cmdBuy.Enabled = False
    Else
        Call Error_message(ret, msg)
        MsgBox "售气失败，错误:" & msg
    End If
End Sub

Private Sub cmdClear_Click()
    Dim ret As Long
    Dim msg As String * 50
    
    ret = Gold_Clearcard(My_Commport - 1, 9600, txtCardID1.Text)
    If ret = 0 Then
        MsgBox "清卡成功。"
        Me.cmdBuy.Enabled = False
        Me.cmdBuy.Enabled = False
    Else
        Call Error_message(ret, msg)
        MsgBox "清卡失败，错误:" & msg
    End If
End Sub

Private Sub cmdRead_Click()
    Dim ret As Long
    Dim userNo As String
    Dim vlql As Long
    Dim vics As Integer
    Dim viklx As Integer
    Dim msg As String * 50
    
    Call CheckReadCount
    Call IncreaseReadCount
    
    ret = Gold_Readcard(My_Commport - 1, 9600, userNo, vlql, vics, viklx) '串口号0开始，所以要减一
    If ret = 0 Then
        Call CheckReadCount
        Call IncreaseReadCount
        Me.txtCardID1.Text = userCode
        Me.txtAmount.Text = vlql
        Me.txtCount.Text = vics
        Select Case viklx
            Case 1
                txtCardType.Text = "民用卡"
            Case 2
                txtCardType.Text = "工业卡"
            Case 3
                txtCardType.Text = "清零卡"
            Case 4
                txtCardType.Text = "转移卡"
        End Select
        Me.cmdBuy.Enabled = True
        Me.cmdBuy.Enabled = True
    Else
        Call Error_message(ret, msg)
        MsgBox "读卡失败，错误:" & msg
    End If
End Sub



