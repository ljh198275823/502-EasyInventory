VERSION 5.00
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form FrmHangXing 
   Caption         =   "���ǿ�"
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
      TabCaption(0)   =   "��/����"
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
      TabCaption(1)   =   "����"
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
      TabCaption(2)   =   "���߿�"
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
         Caption         =   "����ҵ���߿�"
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
         Left            =   3360
         TabIndex        =   32
         Top             =   4200
         Visible         =   0   'False
         Width           =   1815
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
         Index           =   0
         Left            =   960
         TabIndex        =   31
         Top             =   600
         Value           =   -1  'True
         Width           =   2775
      End
      Begin VB.OptionButton Option1 
         Caption         =   "���̿�"
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
         Left            =   960
         TabIndex        =   30
         Top             =   1140
         Width           =   2775
      End
      Begin VB.OptionButton Option1 
         Caption         =   "1����"
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
         Left            =   960
         TabIndex        =   29
         Top             =   1680
         Width           =   2775
      End
      Begin VB.OptionButton Option1 
         Caption         =   "��ʱ��"
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
         Left            =   960
         TabIndex        =   28
         Top             =   2220
         Width           =   2775
      End
      Begin VB.OptionButton Option1 
         Caption         =   "�趨�ۻ�����"
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
         Left            =   960
         TabIndex        =   27
         Top             =   2760
         Width           =   1695
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
         Left            =   1200
         TabIndex        =   26
         Top             =   4200
         Width           =   1815
      End
      Begin VB.TextBox Text11 
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
         Left            =   2040
         TabIndex        =   25
         Text            =   "60"
         Top             =   2280
         Width           =   1575
      End
      Begin VB.TextBox Text12 
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
         Left            =   2640
         TabIndex        =   24
         Top             =   2820
         Width           =   1455
      End
      Begin VB.OptionButton Option1 
         Caption         =   "�������趨��"
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
         Left            =   960
         TabIndex        =   23
         Top             =   3420
         Width           =   1695
      End
      Begin VB.TextBox Text4 
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
         TabIndex        =   20
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
         TabIndex        =   19
         Top             =   3840
         Width           =   1095
      End
      Begin VB.CommandButton cmdBuqi 
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
         Left            =   -71040
         TabIndex        =   18
         Top             =   3840
         Width           =   1095
      End
      Begin VB.CommandButton CmdBack 
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
         Left            =   -69720
         TabIndex        =   17
         Top             =   3840
         Width           =   1095
      End
      Begin VB.TextBox txtCardID1 
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
         TabIndex        =   12
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
         TabIndex        =   11
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
         TabIndex        =   10
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
         TabIndex        =   9
         Top             =   1800
         Width           =   2175
      End
      Begin VB.OptionButton rdIndustry 
         Caption         =   "��ҵ�ÿ�"
         Height          =   195
         Left            =   -72000
         TabIndex        =   8
         Top             =   1770
         Width           =   1335
      End
      Begin VB.OptionButton rdHome 
         Caption         =   "���ÿ�"
         Height          =   375
         Left            =   -73200
         TabIndex        =   7
         Top             =   1680
         Width           =   975
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
         Left            =   -73320
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
         Left            =   -74160
         TabIndex        =   3
         Top             =   3360
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
         Left            =   -72600
         TabIndex        =   2
         Top             =   3360
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
         Left            =   -71160
         TabIndex        =   1
         Top             =   3360
         Width           =   1335
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
         TabIndex        =   16
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
         TabIndex        =   15
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
         TabIndex        =   14
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
         TabIndex        =   13
         Top             =   1860
         Width           =   855
      End
      Begin VB.Label Label1 
         Caption         =   "6λ����"
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
         Left            =   -71160
         TabIndex        =   6
         Top             =   900
         Width           =   735
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
Private Str_QuID As String  '�������
'***********************    operate sle 4442    **************************TestIc_Type
'Declare Function TEST_COM Lib "Saron_Rq.dll" (ByVal icdev As Long) As Integer

'��ȡ��Ƭ����
Private Declare Function Read_CardType Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Int_CardType As Long) As Integer
'��ȡ��Ƭ��Ϣ
Private Declare Function Read_UserCard Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Str_Cardnum As String, str_CityCode As String, Str_type As String) As Integer
'д�뿨Ƭ��Ϣ
Private Declare Function Write_UserCard Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_Cardnum As String, ByVal str_CityCode As String, ByVal Str_type As String) As Integer
'��ȡ8888
Private Declare Function Read_CardBuy Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Str_Flag As String, R_BuyNum As Double, Int_Count As Long, Str_QYID As String) As Integer
Private Declare Function Read_CardBuy_01 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Str_Flag As String, R_BuyNum As Double, Int_Count As Long, Str_QYID As String) As Integer

 
     
Private Declare Function Write_CardBuy Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal R_BuyNum As Double, ByVal Str_QYID As String, ByVal Int_WriteFlag As Long) As Integer
Private Declare Function Write_CardBuy_01 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal R_BuyNum As Double, ByVal Str_QYID As String, ByVal Int_WriteFlag As Long) As Integer

' �⿨88888888888

'Read_CardType(Str_Com:Pchar;Int_Beep:integer;var Int_CardType:integer):smallint;stdcall;

' д���߿�   20 ���㿨  30 ���̿�88888888
Private Declare Function Write_Tools Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Int_CardType As Integer, ByVal Str_CityNum As String, ByVal Str_QYID As String, ByVal Int_Offset1 As Integer) As Integer

' д���߿�   40 Ϊ�趨��  50 ��ʱ��8888888888
Private Declare Function Write_Tools1 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Int_CardType As Integer, ByVal D_Num As Double, ByVal Str_QYID As String, ByVal Int_Offset1 As Integer) As Integer
'д��Ʊ��

Private Declare Function Write_FPID Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_FP As String) As Integer

'����Ʊ��Write_BackCard

Private Declare Function Read_FPID Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Str_FP As String) As Integer

'��������88888888888
Private Declare Function Write_BackCard Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_Cardnum As String) As Integer
'��֤����
Private Declare Function CheckCard_Pass Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_Cardnum As String) As Integer

'��ʼ����888888888888
Private Declare Function Write_CardInit Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_Pass As String) As Integer
'��ȡ���߿�88888888888888
Private Declare Function Read_Tool Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, D_Num As Double, ByVal Int_Offset1 As Integer, Str_QYID As String) As Integer

'�ض��û���888888888888888888888888
Private Declare Function Read_BackNum Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, D_SYNum As Double, D_LJNum As Double) As Integer
Private Declare Function Read_BackNum_01 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, D_SYNum As Double, D_LJNum As Double) As Integer

Private Declare Function Ver_Number Lib "Srq_01.dll" (Str_Ver As String) As Integer

Private Function IcErrMsg(ByVal intErrCode As Integer) As String
    Dim Str_Err As String
    Select Case intErrCode
        Case -1
           Str_Err = "�򿪴��ڴ���"
        Case -2
           Str_Err = "�رմ��ڴ���"
        Case -10
           Str_Err = "�����IC��"
        Case -3
           Str_Err = "�Ǳ�ϵͳ�����ǿ��巴"
        Case -4
           Str_Err = "��������"
        Case -5
           Str_Err = "д������"
        Case -8
           Str_Err = "�˶��������"
        Case -9
           Str_Err = "ת���������"
        Case -6
          Str_Err = "����ת������"
        Case -11
          Str_Err = "���ݳ���"
        Case -13
          Str_Err = "���Ѿ���"
       
        Case -100
          Str_Err = "δ֪����"
         Case -101
          Str_Err = "������Ч�������²���"
    End Select
    IcErrMsg = Str_Err
End Function

Private Function str_CardType(ByVal Int_CardType As Integer) As String
    Select Case Int_CardType
       Case 0
         str_CardType = "�հ׿�"
       Case 10
         str_CardType = "�û���(���ñ�)"
       Case 90
         str_CardType = "�û���(��ҵ��)"
       Case 20
         str_CardType = "���㿨"
         Case 30
         str_CardType = "���̿�"
        Case 31
        str_CardType = "���̿�(����)"
         Case 32
        str_CardType = "��ҵ���̿�(����)"
        Case 41
        str_CardType = "��ο�"
        Case 40
        str_CardType = "�趨��"
        Case 50
        str_CardType = "��ʱ��"
         Case 51
        str_CardType = "���������ÿ�"
        Case 70
        str_CardType = "�Ǳ�ϵͳ��"
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
    Str_QuID = "00000001" '�趨�������
    Str_Commport = "COM" & My_Commport
End Sub

Private Function CheckForMake() As Boolean
    If Len(Me.txtCardID.Text) <> 6 Then
        MsgBox "���Ų���ȷ��Ӧ��Ϊ6λ����"
        CheckForMake = False
        Exit Function
    End If
    If Not IsNumeric(Me.txtCardID.Text) Then
        MsgBox "���Ų��ܰ���������"
        CheckForMake = False
        Exit Function
    End If
    If Me.rdHome.Value = False And Me.rdIndustry.Value = False Then
        MsgBox "��ѡ��һ�ֿ�Ƭ����"
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
        MsgBox "�����ɹ�"
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
        MsgBox "�����ɹ�"
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
        Case 10, 90 ' �û���
            Card_Type = FInt_CardType
            st = Read_UserCard(Str_Commport, 0, Fstr_UserID, FStr_CityNum, Str_type1)
            Str_CardNum1 = Fstr_UserID
            msg = MsgBox(str_CardType(FInt_CardType) & "Ҫ������", vbOKCancel + vbQuestion + vbDefaultButton2, "������ʾ��")
            If msg = vbOK Then
                st = Write_BackCard(Str_Commport, 1, Str_CardNum1)
                If st < 0 Then
                    MsgBox IcErrMsg(st), vbExclamation, Title
                    Exit Sub
                End If
                MsgBox "�����ɹ���", vbInformation, Title
             End If
        Case 20, 30, 31, 40, 41, 50, 32, 51 '���㿨
            Str_CardNum1 = "000000"
            msg = MsgBox(str_CardType(FInt_CardType) & "Ҫ������", vbOKCancel + vbQuestion + vbDefaultButton2, "������ʾ��")
            If msg = vbOK Then
                st = Write_BackCard(Str_Commport, 1, Str_CardNum1)
                If st < 0 Then
                    MsgBox IcErrMsg(st), vbExclamation, Title
                    Exit Sub
                End If
                MsgBox "�����ɹ���", vbInformation, Title
             End If
        Case 0
           MsgBox "�˿���Ϊ�հ׿���", vbInformation, Title
        Case 70
           MsgBox str_CardType(FInt_CardType) & "�����ܲ�����", vbInformation, Title
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
    List1.AddItem "�������ͣ�" & str_CardType(Int_CardType)
    Select Case Int_CardType
        Case 10, 90
            st = Read_UserCard(Str_Commport, 0, Fstr_UserID, FStr_CityNum, Str_type)
            If st < 0 Then GoTo ReadFail
            List1.AddItem "���ţ�" & Fstr_UserID
            txtCardID1.Text = Fstr_UserID
            If Int_CardType = 10 Then
                st = Read_CardBuy(Str_Commport, 0, Str_Flag, FR_BuyNum, Int_Count, Str_QYID)
            Else
                st = Read_CardBuy_01(Str_Commport, 0, Str_Flag, FR_BuyNum, Int_Count, Str_QYID)
            End If
            If st < 0 Then GoTo ReadFail
            Me.txtAmount.Text = FR_BuyNum
            Me.txtCount.Text = Int_Count
            st = Read_FPID(Str_Commport, 0, fstr_FP) '��Ʊ��
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
              List1.AddItem "����״̬���¿�(δ��)"
              List1.AddItem "������(������)��" & Format(FR_BuyNum, "##0.00")
            ElseIf Str_Flag = 12 Then
              List1.AddItem "����״̬���ɿ�(����)"
              List1.AddItem "�ϴι�����(������)��" & Format(FR_BuyNum, "##0.00")
              List1.AddItem "ʣ����(������)��" & Format(D_SYNum1, "##0.00")
              List1.AddItem "�ۼ�����(������)��" & Format(D_LJNum1, "##0.00")
              cmdBuy.Enabled = True
            ElseIf Str_Flag = 13 Then
              List1.AddItem "����״̬��������"
              cmdBuy.Enabled = True
            ElseIf Str_Flag = 14 Then
              List1.AddItem "����״̬������"
              cmdBuy.Enabled = True
            End If
            cmdBuqi.Enabled = True
            CmdBack.Enabled = True
        Case 31
          st = Read_Tool(Str_Commport, 1, FR_BuyNum, 48, Str_QYID)
          If st < 0 Then GoTo ReadFail
          List1.AddItem "Ҫת������(���ñ�)��" & Format(FR_BuyNum, "##0.00")
        Case 40
          st = Read_Tool(Str_Commport, 1, FR_BuyNum, 48, Str_QYID)
          If st < 0 Then GoTo ReadFail
          List1.AddItem "�ۼ�����" & Format(FR_BuyNum, "##0.00")
        Case 50
          st = Read_Tool(Str_Commport, 1, FR_BuyNum, 48, Str_QYID)
          If st < 0 Then GoTo ReadFail
          List1.AddItem "��ʱ����(��)��" & FR_BuyNum
        Case 41
          st = Read_Tool(Str_Commport, 1, FR_BuyNum, 48, Str_QYID)
          If st < 0 Then GoTo ReadFail
          List1.AddItem "��������" & Format(FR_BuyNum, "0.00")
        Case 51
          st = Read_Tool(Str_Commport, 1, FR_BuyNum, 48, Str_QYID)
          If st < 0 Then GoTo ReadFail
          List1.AddItem "��������" & Format(FR_BuyNum, "0.00")
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
    Int_Offset = IIf(Index = 0, 48, 80) '���ñ�48 ��ҵ��80
    Select Case Int_Type
    Case 0 '����
      Ht = Write_Tools(Str_Commport, 1, 20, Str_City, Str_QuID, Int_Offset)
    Case 1 '���̿�
      Ht = Write_Tools(Str_Commport, 1, 30, Str_City, Str_QuID, Int_Offset)
    Case 2 'һ����
      D_Temp = 1
      Ht = Write_Tools1(Str_Commport, 1, 41, D_Temp, Str_QuID, Int_Offset)
    Case 3 '��ʱ��
      Ht = Write_Tools1(Str_Commport, 1, 50, Val(Text11.Text), Str_QuID, Int_Offset)
    Case 4 '�趨�ۻ���
      Ht = Write_Tools1(Str_Commport, 1, 40, Val(Text12.Text), Str_QuID, Int_Offset)
    Case 5 '���������ÿ�
      Ht = Write_Tools1(Str_Commport, 1, 51, Val(Text4.Text), Str_QuID, Int_Offset)
    End Select
    If Ht < 0 Then
      MsgBox IcErrMsg(Ht)
    Else
      MsgBox "�������߿��ɹ�"
    End If
End Sub


