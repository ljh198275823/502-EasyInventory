VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "DanDong"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
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
'�������߿�  4���������㿨5: ����������6: ת�ƿ�
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

Public Function IsMyCard() As Boolean
    Dim ret As Long
    ret = CheckOwnCard(My_Commport - 1, 9600)
    If ret = 0 Then IsMyCard = True
End Function

Private Function CheckForMake() As Boolean
    If Len(FrmCardReader.txtCardID.Text) <> 8 Then
        MsgBox "���Ų���ȷ��Ӧ��Ϊ8λ����"
        Exit Function
    End If
    If Not IsNumeric(FrmCardReader.txtCardID.Text) Then
        MsgBox "���Ų��ܰ���������"
        Exit Function
    End If
    If FrmCardReader.rdHome.Value = False And FrmCardReader.rdIndustry.Value = False Then
        MsgBox "��ѡ���û�����"
        Exit Function
    End If
    CheckForMake = True
End Function

Public Sub Make()
    Dim ret As Long
    Dim ICMark As String * 20
    
    If CheckForMake() Then
        ret = WriteICCard(My_Commport - 1, 9600, FrmCardReader.txtCardID.Text, 127, 0, 0, 32, IIf(FrmCardReader.rdHome.Value, 1, 2), ICMark)
        If ret = 0 Then
            MsgBox "�����ɹ�"
        Else
            MsgBox "����ʧ�ܣ�����:" & ErrorMsg(ret)
        End If
    End If
End Sub

Public Sub Remake()
    Dim ret As Long
    Dim ICMark As String * 20
    
    If CheckForMake() Then
        ret = WriteICCard(My_Commport - 1, 9600, FrmCardReader.txtCardID.Text, 127, 0, 0, 32, IIf(FrmCardReader.rdHome.Value, 1, 2), ICMark)
        If ret = 0 Then
            MsgBox "�����ɹ�"
        Else
            MsgBox "����ʧ�ܣ�����:" & ErrorMsg(ret)
        End If
    End If
End Sub

Public Sub Clear()
    Dim ret As Long
    
    ret = ClearAllCard(My_Commport - 1, 9600)
    If ret = 0 Then
        MsgBox "�忨�ɹ���"
    Else
        MsgBox "�忨ʧ�ܣ�����:" & ErrorMsg(ret)
    End If
End Sub

Public Sub Read()
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
    
    FrmCardReader.List1.Clear
    ret = ReadICCard(My_Commport - 1, 9600, ICId, ICType, ICCSpare, GASCount, CusType, ICUsed, ICMSpare, ICNum, ICMark, ICMUType)
    If ret = 0 Then
        Call CheckReadCount
        Call IncreaseReadCount
        FrmCardReader.txtCardID1.Text = Trim(ICId)
        FrmCardReader.txtAmount.Text = 0
        FrmCardReader.txtCount.Text = IIf(GASCount < 0, 0, GASCount) + 1
        Cus_Type = CusType  '����д����ʱ��
        FrmCardReader.List1.AddItem "���ţ�" & Trim(ICId)
        FrmCardReader.List1.AddItem "�û����ͣ�" & IIf(CusType = 1, "���ÿ�", "��ҵ��")
        FrmCardReader.List1.AddItem "����������" & ICCSpare
        FrmCardReader.List1.AddItem "��Ƭ���ࣺ" & "������"
        FrmCardReader.cmdBuy.Enabled = True
        FrmCardReader.CmdBack.Enabled = IIf(ICCSpare > 0, True, False)
        FrmCardReader.cmdClear.Enabled = True
        FrmCardReader.Option1(0).Enabled = False
    Else
        MsgBox "����ʧ�ܣ�����:" & ErrorMsg(ret)
    End If
End Sub

Public Sub Buy()
    Dim ret As Long
    Dim ICMark As String * 20

    ret = WriteICCard(My_Commport - 1, 9600, FrmCardReader.txtCardID1.Text, 6, Val(FrmCardReader.txtCount.Text), Val(FrmCardReader.txtAmount.Text), 32, Cus_Type, ICMark)
    If ret = 0 Then
        MsgBox "�����ɹ�"
        FrmCardReader.cmdBuy.Enabled = False
        FrmCardReader.CmdBack.Enabled = False
    Else
        MsgBox "����ʧ�ܣ�����:" & ErrorMsg(ret)
    End If
End Sub


Public Sub Back()
    Dim ret As Long
    Dim ICMark As String * 20

    ret = WriteICCard(My_Commport - 1, 9600, FrmCardReader.txtCardID1.Text, 6, Val(FrmCardReader.txtCount.Text), 0, 32, Cus_Type, ICMark)
    If ret = 0 Then
        MsgBox "�����ɹ�"
        FrmCardReader.cmdBuy.Enabled = False
        FrmCardReader.CmdBack.Enabled = False
    Else
        MsgBox "����ʧ�ܣ�����:" & ErrorMsg(ret)
    End If
End Sub

Public Sub MakeTool()
    Dim ret As Long

    'If FrmCardReader.Option1(0).Value Then
        'ret = MakeIniCard(My_Commport - 1, 9600, Val(txtFrontGas.Text), Val(txtAlarmValue.Text), Val(txtInputValue.Text), Val(txtControlValue.Text))
    'Else
    If FrmCardReader.Option1(1).Value Then
        ret = WriteGjkCard(My_Commport - 1, 9600, 4)
    ElseIf FrmCardReader.Option1(2).Value Then
        ret = WriteGjkCard(My_Commport - 1, 9600, 6)
    End If
    If ret = 0 Then
        MsgBox "�����߿��ɹ���"
    Else
        MsgBox "�����߿�ʧ�ܣ�����:" & ErrorMsg(ret)
    End If
End Sub


