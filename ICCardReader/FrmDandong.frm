VERSION 5.00
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form FrmDandong 
   Caption         =   "������"
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
      TabCaption(0)   =   "��/����"
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
      TabCaption(1)   =   "����"
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
      TabCaption(2)   =   "���߿�"
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
         Left            =   3840
         TabIndex        =   21
         Top             =   3840
         Width           =   1095
      End
      Begin VB.OptionButton rdHome 
         Caption         =   "���ÿ�"
         Height          =   375
         Left            =   -73320
         TabIndex        =   20
         Top             =   1440
         Width           =   975
      End
      Begin VB.OptionButton rdIndustry 
         Caption         =   "��ҵ�ÿ�"
         Height          =   195
         Left            =   -72120
         TabIndex        =   19
         Top             =   1530
         Width           =   1335
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
         TabIndex        =   18
         Top             =   600
         Width           =   2775
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
         Index           =   1
         Left            =   -74040
         TabIndex        =   17
         Top             =   1980
         Value           =   -1  'True
         Width           =   975
      End
      Begin VB.OptionButton Option1 
         Caption         =   "���߿�"
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
         TabIndex        =   16
         Top             =   2520
         Width           =   975
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
         TabIndex        =   15
         Top             =   3000
         Width           =   975
      End
      Begin VB.CommandButton CmdTool 
         Caption         =   "�����߿�"
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
         Left            =   1200
         TabIndex        =   12
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
         Left            =   2520
         TabIndex        =   11
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
         Left            =   1200
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
         Left            =   1200
         TabIndex        =   7
         Top             =   1200
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
         Caption         =   "�忨"
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
      Begin VB.Label Label10 
         Alignment       =   1  'Right Justify
         Caption         =   "Ԥ������"
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
         Left            =   -73680
         TabIndex        =   30
         Top             =   1140
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
         Left            =   -71160
         TabIndex        =   25
         Top             =   1620
         Width           =   1095
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
         Index           =   4
         Left            =   -73680
         TabIndex        =   24
         Top             =   1620
         Width           =   855
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
         Left            =   -70920
         TabIndex        =   23
         Top             =   1140
         Width           =   855
      End
      Begin VB.Label Label10 
         Alignment       =   1  'Right Justify
         Caption         =   "ע�⣺���ϵ��������ڱ��ι��������Ͽ���ԭ������"
         BeginProperty Font 
            Name            =   "����"
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
         Left            =   360
         TabIndex        =   10
         Top             =   720
         Width           =   735
      End
      Begin VB.Label Label10 
         Alignment       =   1  'Right Justify
         Caption         =   "���ι���"
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
         Left            =   240
         TabIndex        =   9
         Top             =   1260
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
Attribute VB_Name = "FrmDandong"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Cus_Type As Long

'/�ײ㶯̬��
'///////////��������
Private Declare Function CheckOwnCard Lib "DR_Soft" (ByVal port As Long, ByVal Baud As Long) As Long
'����
Private Declare Function ReadICCard Lib "DR_Soft" (ByVal port As Long, ByVal Baud As Long, ByVal ICId As String, ByRef ICType As Long, ByRef ICCSpare As Double, ByRef GASCount As Long, ByRef CusType As Long, ByRef ICUsed As Double, ByRef ICMSpare As Double, ByRef ICNum As Long, ByVal ICMark As String, ByVal ICMUType As String) As Long
'д��
Private Declare Function WriteICCard Lib "DR_Soft" (ByVal port As Long, ByVal Baud As Long, ByVal ICId As String, ByVal OPCode As Long, ByVal GASCount As Long, ByVal ICCSpare As Double, ByVal ICType As Long, ByVal CusType As Long, ByVal ICMark As String) As Long
'��տ�Ƭ
Private Declare Function ClearAllCard Lib "DR_Soft" (ByVal port As Long, ByVal Baud As Long) As Long
'������ʼ����
Private Declare Function MakeIniCard Lib "DR_Soft" (ByVal port As Long, ByVal Baud As Long, ByVal frontGas As Double, ByVal AlarmValue As Double, ByVal InputValue As Double, ByVal controlValue As Double) As Long
'�������߿�  4���������㿨5: ��������6: ת�ƿ�
Private Declare Function WriteGjkCard Lib "DR_Soft" (ByVal port As Long, ByVal Baud As Long, ByVal GjkType As Long) As Long

Private Function ErrorMsg(ByVal err As Long) As String
    ErrorMsg = "δ֪����"
    Select Case err
        Case 1
            ErrorMsg = "������������Ƭ�˶Բ�����"
        Case 2
            ErrorMsg = "û�п�"
        Case 3
            ErrorMsg = "��д�������ò���"
        Case 4
            ErrorMsg = "��д����������"
        Case 5
            ErrorMsg = "dll�ڲ�����"
        Case 6
            ErrorMsg = "�����ʹ����¿�Ϊ���ͺŴ����Ͽ�Ϊ���ͺŴ��������㷨������������)"
        Case 10
            ErrorMsg = "�¿�"
        Case 11
            ErrorMsg = "�����������ʧ��"
        Case 12
            ErrorMsg = "���������Ϊ0"
        Case 13
            ErrorMsg = "��Ƭ�ѷ���"
        Case 14
            ErrorMsg = "�Ǳ�ϵͳ�Ŀ�"
        Case 15
            ErrorMsg = "�����������"
        Case 16
            ErrorMsg = "�ļ����ݴ���"
        Case 18
            ErrorMsg = "��������"
        Case 19
            ErrorMsg = "���"
        Case 97
            ErrorMsg = "��������"
        Case 98
            ErrorMsg = "���ڳ�ʼ��ʧ��"
        Case 100
            ErrorMsg = "�����ļ�������"
    End Select
End Function
'-----------------------------------------------------end-----------------------------------------------------
Private Function CheckForMake() As Boolean
    If Len(Me.txtCardID.Text) <> 8 Then
        MsgBox "���Ų���ȷ��Ӧ��Ϊ8λ����"
        Exit Function
    End If
    If Not IsNumeric(Me.txtCardID.Text) Then
        MsgBox "���Ų��ܰ���������"
        Exit Function
    End If
    If rdHome.Value = False And rdIndustry.Value = False Then
        MsgBox "��ѡ���û�����"
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
            MsgBox "�����ɹ�"
        Else
            MsgBox "����ʧ�ܣ�����:" & ErrorMsg(ret)
        End If
    End If
End Sub

Private Sub cmdRemake_Click()
    Dim ret As Long
    Dim ICMark As String * 20
    
    If CheckForMake() Then
        ret = WriteICCard(My_Commport - 1, 9600, txtCardID.Text, 127, 0, 0, 32, IIf(rdHome.Value, 1, 2), ICMark)
        If ret = 0 Then
            MsgBox "�����ɹ�"
        Else
            MsgBox "����ʧ�ܣ�����:" & ErrorMsg(ret)
        End If
    End If
End Sub

Private Sub cmdClear_Click()
    Dim ret As Long
    
    ret = ClearAllCard(My_Commport - 1, 9600)
    If ret = 0 Then
        MsgBox "�忨�ɹ���"
    Else
        MsgBox "�忨ʧ�ܣ�����:" & ErrorMsg(ret)
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
        Cus_Type = CusType  '����д����ʱ��
        Me.List1.AddItem "����:" & Trim(ICId)
        Me.List1.AddItem "�û�����" & IIf(CusType = 1, "���ÿ�", "��ҵ��")
        Me.List1.AddItem "��������:" & ICCSpare
        Me.List1.AddItem "��������:" & ICMSpare
        Me.cmdBuy.Enabled = True
        Me.cmdBack.Enabled = IIf(ICCSpare > 0, True, False)
    Else
        MsgBox "����ʧ�ܣ�����:" & ErrorMsg(ret)
    End If
End Sub

Private Sub cmdBuy_Click()
    Dim ret As Long
    Dim ICMark As String * 20

    ret = WriteICCard(My_Commport - 1, 9600, txtCardID1.Text, 6, Val(txtCount.Text) + 1, Val(txtAmount.Text), 32, Cus_Type, ICMark)
    If ret = 0 Then
        MsgBox "�����ɹ�"
        cmdBuy.Enabled = False
        cmdBack.Enabled = False
    Else
        MsgBox "����ʧ�ܣ�����:" & ErrorMsg(ret)
    End If
End Sub


Private Sub cmdBack_Click()
    Dim ret As Long
    Dim ICMark As String * 20

    ret = WriteICCard(My_Commport - 1, 9600, txtCardID1.Text, 6, Val(txtCount.Text), 0, 32, Cus_Type, ICMark)
    If ret = 0 Then
        MsgBox "�����ɹ�"
        cmdBuy.Enabled = False
        cmdBack.Enabled = False
    Else
        MsgBox "����ʧ�ܣ�����:" & ErrorMsg(ret)
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
        MsgBox "�����߿��ɹ���"
    Else
        MsgBox "�����߿�ʧ�ܣ�����:" & ErrorMsg(ret)
    End If
End Sub


