VERSION 5.00
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form FrmFuluke 
   Caption         =   "��»��"
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
      TabPicture(0)   =   "FrmFuluke.frx":0000
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "Label1(0)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "Label1(1)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).Control(2)=   "cmdClear"
      Tab(0).Control(2).Enabled=   0   'False
      Tab(0).Control(3)=   "cmdMake"
      Tab(0).Control(3).Enabled=   0   'False
      Tab(0).Control(4)=   "txtCardID"
      Tab(0).Control(4).Enabled=   0   'False
      Tab(0).ControlCount=   5
      TabCaption(1)   =   "����"
      TabPicture(1)   =   "FrmFuluke.frx":001C
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "Label10(1)"
      Tab(1).Control(1)=   "Label10(0)"
      Tab(1).Control(2)=   "Label1(2)"
      Tab(1).Control(3)=   "txtCount"
      Tab(1).Control(4)=   "txtAmount"
      Tab(1).Control(5)=   "txtCardID1"
      Tab(1).Control(6)=   "cmdBuy"
      Tab(1).Control(7)=   "cmdRead"
      Tab(1).Control(8)=   "List1"
      Tab(1).ControlCount=   9
      TabCaption(2)   =   "���߿�"
      TabPicture(2)   =   "FrmFuluke.frx":0038
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "Label1(5)"
      Tab(2).Control(1)=   "Label1(6)"
      Tab(2).Control(2)=   "Label1(3)"
      Tab(2).Control(3)=   "Label1(4)"
      Tab(2).Control(4)=   "CmdTool(0)"
      Tab(2).Control(5)=   "Option1(3)"
      Tab(2).Control(6)=   "Option1(2)"
      Tab(2).Control(7)=   "Option1(1)"
      Tab(2).Control(8)=   "Option1(0)"
      Tab(2).Control(9)=   "txtDataRestorePwd"
      Tab(2).Control(10)=   "txtDataManagePwd"
      Tab(2).Control(11)=   "txtDataChangePWD"
      Tab(2).ControlCount=   12
      Begin VB.TextBox txtDataChangePWD 
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
         Left            =   -71760
         TabIndex        =   22
         Text            =   "10"
         Top             =   1740
         Width           =   1935
      End
      Begin VB.TextBox txtDataManagePwd 
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
         Left            =   -71760
         TabIndex        =   21
         Text            =   "10"
         Top             =   2220
         Width           =   1935
      End
      Begin VB.TextBox txtDataRestorePwd 
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
         Left            =   -71760
         TabIndex        =   20
         Text            =   "10"
         Top             =   1200
         Width           =   1935
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
         Left            =   -74040
         TabIndex        =   19
         Top             =   600
         Value           =   -1  'True
         Width           =   1335
      End
      Begin VB.OptionButton Option1 
         Caption         =   "�ָ���"
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
         TabIndex        =   18
         Top             =   1140
         Width           =   1335
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
         TabIndex        =   17
         Top             =   1680
         Width           =   1095
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
         Index           =   3
         Left            =   -74040
         TabIndex        =   16
         Top             =   2160
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
         Left            =   -73080
         TabIndex        =   15
         Top             =   3840
         Width           =   1815
      End
      Begin VB.ListBox List1 
         Appearance      =   0  'Flat
         Height          =   2175
         ItemData        =   "FrmFuluke.frx":0054
         Left            =   -71280
         List            =   "FrmFuluke.frx":0056
         TabIndex        =   14
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
         TabIndex        =   13
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
         TabIndex        =   12
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
         TabIndex        =   8
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
         TabIndex        =   7
         Top             =   1200
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
         TabIndex        =   6
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
         Left            =   1680
         TabIndex        =   3
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
         Left            =   1920
         TabIndex        =   2
         Top             =   4320
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
         Top             =   4320
         Width           =   1335
      End
      Begin VB.Label Label1 
         Alignment       =   1  'Right Justify
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
         Height          =   255
         Index           =   4
         Left            =   -72840
         TabIndex        =   26
         Top             =   1800
         Width           =   615
      End
      Begin VB.Label Label1 
         Alignment       =   1  'Right Justify
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
         Height          =   255
         Index           =   3
         Left            =   -72840
         TabIndex        =   25
         Top             =   720
         Width           =   615
      End
      Begin VB.Label Label1 
         Alignment       =   1  'Right Justify
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
         Height          =   255
         Index           =   6
         Left            =   -72840
         TabIndex        =   24
         Top             =   2280
         Width           =   615
      End
      Begin VB.Label Label1 
         Alignment       =   1  'Right Justify
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
         Height          =   255
         Index           =   5
         Left            =   -72840
         TabIndex        =   23
         Top             =   1260
         Width           =   615
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
         TabIndex        =   11
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
         TabIndex        =   10
         Top             =   1260
         Width           =   855
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
         TabIndex        =   9
         Top             =   1860
         Width           =   855
      End
      Begin VB.Label Label1 
         Caption         =   "8λ����"
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
         Left            =   3840
         TabIndex        =   5
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
         Left            =   960
         TabIndex        =   4
         Top             =   900
         Width           =   735
      End
   End
End
Attribute VB_Name = "FrmFuluke"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'/�ײ㶯̬��
'��������
Private Declare Function Sle4442_MakeCard_Change Lib "FLK_Card" (ByVal port As Long, ByVal Baud As Long, ByVal pwd As Long) As Long
'�������ÿ�
Private Declare Function Sle4442_MakeCard_Setting Lib "FLK_Card" (ByVal port As Long, ByVal Baud As Long, ByVal DataUserPWD As Long, ByVal DataManagePwd As Long, ByVal DataRestorePwd As Long, ByVal DataChangePWD As Long, ByVal AlarmNum As Long, ByVal MaxNum As Long, ByVal Minnum As Long) As Long
'�����ָ���
Private Declare Function Sle4442_MakeCard_Restore Lib "FLK_Card" (ByVal port As Long, ByVal Baud As Long, ByVal DataRestorePwd As Long) As Long
'��������
Private Declare Function Sle4442_MakeCard_Manage Lib "FLK_Card" (ByVal port As Long, ByVal Baud As Long, ByVal DataManagePwd As String) As Long
'�������㿨
Private Declare Function Sle4442_MakeCard_Clear Lib "FLK_Card" (ByVal port As Long, ByVal Baud As Long) As Long
'�����û���
Private Declare Function Sle4442_MakeCard_Consumer Lib "FLK_Card" (ByVal port As Long, ByVal Baud As Long, ByVal CardNumber As Long, ByVal QAmount As Long, ByVal DataUserPWD As Long, ByVal passwd As String) As Long
'���û���
Private Declare Function Sle4442_ReadCard Lib "FLK_Card" (ByVal port As Long, ByVal Baud As Long, ByRef cardType As Long, ByRef CardCode As Long, ByRef UsedNum As Long, ByRef MeterNum As Long, ByRef cardnum As Long, ByRef BuyCount As Long) As Long
'д�û���
Private Declare Function Sle4442_WriteCard_Consumer Lib "FLK_Card" (ByVal port As Long, ByVal Baud As Long, ByVal CardNumber As Long, ByVal BuyCount As Long, ByVal QAmount As Long, ByVal passwd As String) As Long
'��տ�
Private Declare Function Sle4442_ClearCard Lib "FLK_Card" (ByVal port As Long, ByVal Baud As Long, ByVal passwd As String) As Long


Private Function ChengdeErr(ByVal err As Integer) As String
    ChengdeErr = "δ֪����"
End Function
'-----------------------------------------------------end-----------------------------------------------------

Private Sub cmdBuy_Click()
    Dim ret As Long
    
    ret = Sle4442_WriteCard_Consumer(My_Commport - 1, 9600, Val(txtCardID1.Text), Val(txtCount.Text) + 1, Val(txtAmount.Text) * 10, "")
    If ret = 0 Then
        MsgBox "�����ɹ���"
    Else
        MsgBox "����ʧ�ܣ�����:" & ChengdeErr(ret)
    End If
End Sub

Private Function CheckForMake() As Boolean
    If Len(Me.txtCardID.Text) <> 8 Then
        MsgBox "���Ų���ȷ��Ӧ��Ϊ8λ����"
        CheckForMake = False
        Exit Function
    End If
    If Not IsNumeric(Me.txtCardID.Text) Then
        MsgBox "���Ų��ܰ���������"
        CheckForMake = False
        Exit Function
    End If
    CheckForMake = True
End Function

Private Sub cmdMake_Click()
    Dim ret As Long
    Dim password As String * 20
    
    If CheckForMake() Then
        ret = ret = Sle4442_MakeCard_Consumer(My_Commport - 1, 9600, Val(txtCardID.Text), 0, 123456, password)
        If ret = 0 Then
            MsgBox "�����ɹ� ���ס��Ƭ����: " & Trim(password)
        Else
            MsgBox "����ʧ�ܣ�����:" & ChengdeErr(ret)
        End If
    End If
End Sub

Private Sub cmdClear_Click()
    Dim ret As Long

    ret = Sle4442_ClearCard(My_Commport - 1, 9600, "")
    If ret = 0 Then
        MsgBox "�忨�ɹ���"
    Else
        MsgBox "�忨ʧ�ܣ�����:" & ChengdeErr(ret)
    End If
End Sub

Private Sub cmdRead_Click()
    Dim ret As Long
    Dim cardType  As Long
    Dim CardCode As Long
    Dim UsedNum As Long ' ����������          ����/10�õ�С��
    Dim MeterNum As Long    '��������ʣ������    ����/10�õ�С��
    Dim cardnum As Long    ' �� ���ܵ�ʣ������   ����/10�õ�С��
    Dim BuyCount As Long ':       ����
    
    Me.List1.Clear
    ret = Sle4442_ReadCard(My_Commport - 1, 9600, cardType, CardCode, usernum, MeterNum, cardnum, BuyCount)
    If ret = 0 Then
        If cardType = 5050 Then
            Me.txtCardID1.Text = CardCode
            Me.txtAmount.Text = cardnum / 10
            Me.txtCount.Text = BuyCount
            Me.List1.AddItem "����:" & CardCode
            Me.List1.AddItem "��������:" & cardnum / 10
            Me.List1.AddItem "��������:" & MeterNum / 10
            Me.List1.AddItem "��������:" & usenum / 10
            Me.cmdBuy.Enabled = True
        Else
            Me.List1.AddItem "����:" & CardCode
            Me.List1.AddItem "��Ƭ���ͣ�" & CardTypeStr(cardType)
        End If
    Else
        MsgBox "����ʧ�ܣ�����:" & ChengdeErr(ret)
    End If
End Sub

Private Function CardTypeStr(ByVal cardType As Long) As String
    Select Case cardType
        Case 1010
           CardTypeStr = "�ָ���"
        Case 2020
            CardTypeStr = "���ÿ�"
        Case 3030
            CardTypeStr = "����"
        Case 4040
            CardTypeStr = "����"
        Case 5050
            CardTypeStr = "�û���"
        Case 6060
            CardTypeStr = "ʱ�俨"
        Case 7070
            CardTypeStr = "���Կ�"
        Case 8080
            CardTypeStr = "���㿨"
    End Select
End Function

Private Sub CmdTool_Click(Index As Integer)
    Dim ret As Long
    
    If Option1(0).Value Then '�������㿨
        ret = Sle4442_MakeCard_Clear(My_Commport - 1, 9600)
    ElseIf Option1(1).Value Then '�����ָ���
        ret = Sle4442_MakeCard_Restore(My_Commport - 1, 9600, Val(Me.txtDataRestorePwd.Text))
    ElseIf Option1(2).Value Then '��������
        ret = Sle4442_MakeCard_Change(My_Commport - 1, 9600, Val(Me.txtDataChangePWD.Text))
    ElseIf Option1(3).Value Then '��������
        ret = Sle4442_MakeCard_Manage(My_Commport - 1, 9600, Val(Me.txtDataManagePwd.Text))
    End If
    If ret = 0 Then
        MsgBox "�����߿��ɹ���"
    Else
        MsgBox "�����߿�ʧ�ܣ�����:" & ChengdeErr(ret)
    End If
End Sub


