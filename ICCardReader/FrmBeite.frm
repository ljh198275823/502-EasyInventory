VERSION 5.00
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form FrmBeite 
   Caption         =   "���ؿ�"
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
      TabCaption(0)   =   "��/����"
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
      TabCaption(1)   =   "����"
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
      TabCaption(2)   =   "���߿�"
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
            Name            =   "����"
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
         Caption         =   "�����Կ�"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "��ʼ����"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "�쳣�����"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "����"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "���Կ�"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "���㿨"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "�����߿�"
         BeginProperty Font 
            Name            =   "����"
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
            Name            =   "����"
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
         Caption         =   "�ָ����߿�Ϊ�հ׿�"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "����"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "����"
         Enabled         =   0   'False
         BeginProperty Font 
            Name            =   "����"
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
            Name            =   "����"
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
            Name            =   "����"
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
            Name            =   "����"
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
            Name            =   "����"
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
            Name            =   "����"
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
         Caption         =   "����"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "����"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "����"
         BeginProperty Font 
            Name            =   "����"
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
            Name            =   "����"
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
            Name            =   "����"
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
            Name            =   "����"
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
            Name            =   "����"
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
         Caption         =   "��������"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "��ֵ����"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "����������"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "͸֧�޶�"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "��������(0-100)"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "���Դ���(0-255)"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "���ţ�"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "��������"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "��Ʊ�ţ�"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "����������"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "10λ����"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "���ţ�"
         BeginProperty Font 
            Name            =   "����"
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
'/�ײ㶯̬��

'�û������˻�����
'1.ֻ�д��ڳ�ʼ״̬�Ŀ�Ƭ���ܽ��п�Ƭ�ĸ��˻�����
'2.��ɸ��˻���������û�������Ԥ������Ϊ��
Private Declare Function Personalize Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByVal AlarmValue As Long, ByVal InputValue As Long, ByVal overlimit As Long, ByVal Control As Long, ByVal pErrMsg As String) As Long

'�û�����ֵ����  ÿ����һ���û����������ף����Ͻ�����ż�1
Private Declare Function Credit Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByVal ChargeSerialNum As Long, ByVal purchaeAmount As Long, ByVal pErrMsg As String) As Long

'�û��������  ��ɲ�����ԭ���Ͻ�����ű��ֲ���
Private Declare Function Increase Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByRef Buygas As Long, ByVal PurchaseAmount As Long, ByVal pErrMsg As String) As Long

'���� ����˹����׺�ԭ���Ͻ�����ű��ֲ���
Private Declare Function Decrease Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, _
    ByVal userNo As String, ByRef Buygas As Long, ByVal PurchaseAmount As Long, ByVal pErrMsg As String) As Long

'���û�������������
Private Declare Function rUserData Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByRef userNo As String, _
ByRef ChargeSerialNum As Long, ByRef PurchaseAmount As Long, ByRef AlarmValue As Long, ByRef InputValue As Long, _
ByRef overlimit As Long, ByRef Control As Long, ByVal pErrMsg As String) As Long

'���û�������д������
Private Declare Function rUserDataR Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByRef RStartcode As String, _
ByRef meterNo As String, ByRef TotalBuyGas As Long, ByRef TotalBuyNum As Long, ByRef residualGas As Long, _
ByRef TotalTakeGas As Single, ByRef ChangePassNum As Long, ByRef FMState As Long, ByRef ESAMState As Long, _
ByRef DCState As Long, ByRef CGRState As Long, ByRef Magnet As Long, ByRef Low As Long, ByRef MonthUserGas As String, _
ByRef RDate As String, ByVal pErrMsg As String) As Long

'����
Private Declare Function ReissueCard Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, ByVal AlarmValue As Integer, ByVal InputValue As Integer, ByVal overlimit As Long, ByVal Control As Long, ByVal ChargeSerialNum As Long, ByVal PurchaseAmount As Long, ByVal pErrMsg As String) As Long

'����һ�Ż���
Private Declare Function ChangeMeter Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByVal AlarmValue As Integer, ByVal InputValue As Integer, ByVal overlimit As Long, ByVal buy As Long, _
ByVal TotalBuyGas As Long, ByVal TotalBuyNum As Long, ByVal residualGas As Long, ByVal TotalTakeGas As Single, ByVal Control As Long, _
ByVal pErrMsg As String) As Long


'������ʹ����
Private Declare Function MakeIniCard Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal upfrontGas As Long, ByVal AlarmValue As Long, _
ByVal overlimit As Long, ByVal Control As Long, ByVal pErrMsg As String) As Long

'�����û�������
Private Declare Function SetUserParameter Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByVal AlarmValue As Long, ByVal overlimit As Long, ByVal Control As Long, ByVal pErrMsg As Long) As Long

'��տ�
Private Declare Function clearCard Lib "PC001" Alias "ClearCard" (ByVal port As Integer, ByVal Baud As Long, ByVal pErrMsg As Long) As Long

'-----------------------------------------------------end-----------------------------------------------------

Private Function CheckForMake() As Boolean
    If Len(Me.txtCardID.Text) <> 10 Then
        MsgBox "���Ų���ȷ��Ӧ��Ϊ10λ����"
        Exit Function
    End If
    If Not IsNumeric(Me.txtCardID.Text) Then
        MsgBox "���Ų��ܰ���������"
        Exit Function
    End If
    If Val(txtOverLimit.Text) < 0 Or Val(txtOverLimit.Text) > 255 Then
        MsgBox "͸֧�޶�ڷ�Χ��"
        Exit Function
    End If
    If Val(txtInputValue.Text) < 0 Or Val(txtInputValue.Text) > 65535 Then
        MsgBox "��ֵ���޲��ڷ�Χ��"
        Exit Function
    End If
    If Val(txtAlarmValue.Text) < 0 Or Val(txtAlarmValue.Text) > 65535 Then
        MsgBox "�����������ڷ�Χ��"
        Exit Function
    End If
    If Val(txtControlValue.Text) < 0 Or Val(txtControlValue.Text) > 99 Then
        MsgBox "���������޲��ڷ�Χ��"
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
            MsgBox "�����ɹ�"
        Else
            MsgBox "����ʧ�ܣ�����:" & pErrMsg
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
            MsgBox "�����ɹ�"
        Else
            MsgBox "����ʧ�ܣ�����:" & pErrMsg
        End If
    End If
End Sub

Private Sub cmdClear_Click()
    Dim ret As Long
    Dim pErrMsg As String
    
    pErrMsg = Space(1024)
    ret = clearCard(My_Commport, 9600, pErrMsg)
    If ret = 1 Then
        MsgBox "�忨�ɹ�"
    Else
        'MsgBox "�忨ʧ�ܣ�����:" & pErrMsg
    End If
End Sub



Private Sub CmdTool_Click(Index As Integer)
'    Dim icDev As Long
'    Dim ret As Long
'    Dim WriteType As Long  'д���߿�����*���䴫��ֵ������˵��
'    Dim TestAmount As Single ' ��in�� д���Կ����� ������100��д�ǲ��Կ�ʱ����0
'    Dim TestTimes As Long 'д���Կ���ʹ�ô��� ������255��д�ǲ��Կ�ʱ����0
'
'    icDev = ic_init(My_Commport - 1, 9600) '���ں�0��ʼ������Ҫ��һ
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
'        MsgBox "�����߿��ɹ���"
'    Else
'        MsgBox "�����߿�ʧ�ܣ�����:" & ChengdeErr(ret)
'    End If
End Sub


