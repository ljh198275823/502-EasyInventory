VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "HangXing"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Dim Int_Type As Integer
Dim Str_Commport As String
Dim Card_Type As Integer
Private Ht As Integer
Private Str_QuID As String  '�������
Private m_Port As Integer
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
        str_CardType = "��ҵ�����̿�(����)"
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

Private Sub Class_Initialize()
    Int_Type = 0
    Str_QuID = "00000001" '�趨�������
    Str_Commport = "COM" & My_Commport
End Sub

Public Function IsMyCard() As Boolean
    Dim FInt_CardType As Long
       
    Ht = Read_CardType(Str_Commport, 0, FInt_CardType)
    If FInt_CardType <> 70 Then
        IsMyCard = True
    End If
End Function

Public Sub Back()  '����
    If Card_Type = 10 Then
        Ht = Write_CardBuy(Str_Commport, 1, 0, Str_QuID, 4)
    Else
        Ht = Write_CardBuy_01(Str_Commport, 1, 0, Str_QuID, 4)
    End If
    If Ht < 0 Then
      MsgBox IcErrMsg(Ht)
      Exit Sub
    End If
    FrmCardReader.cmdBuy.Enabled = False
    FrmCardReader.CmdBack.Enabled = False
End Sub


Public Sub Buy()  '����
    If Card_Type = 10 Then
        Ht = Write_CardBuy(Str_Commport, 0, Val(FrmCardReader.txtAmount.Text), Str_QuID, 2)
    Else
        Ht = Write_CardBuy_01(Str_Commport, 0, Val(FrmCardReader.txtAmount.Text), Str_QuID, 2)
    End If
    If Ht < 0 Then
      MsgBox IcErrMsg(Ht)
      Exit Sub
    End If
    Ht = Write_FPID(Str_Commport, 1, Trim(FrmCardReader.txtFPID.Text))
    If Ht < 0 Then
      MsgBox IcErrMsg(st), vbExclamation, Title
      Exit Sub
    End If
    FrmCardReader.cmdBuy.Enabled = False
    FrmCardReader.CmdBack.Enabled = False
End Sub


Private Function CheckForMake() As Boolean
    If Len(FrmCardReader.txtCardID.Text) <> 6 Then
        MsgBox "���Ų���ȷ��Ӧ��Ϊ6λ����"
        CheckForMake = False
        Exit Function
    End If
    If Not IsNumeric(FrmCardReader.txtCardID.Text) Then
        MsgBox "���Ų��ܰ���������"
        CheckForMake = False
        Exit Function
    End If
    If FrmCardReader.rdHome.Value = False And FrmCardReader.rdIndustry.Value = False Then
        MsgBox "��ѡ��һ�ֿ�Ƭ����"
        Exit Function
    End If
    CheckForMake = True
End Function

Public Sub Make()  '����
    Dim str_CardType  As String
    Dim str_CityCode As String
    
    If CheckForMake() Then
        str_CityCode = "0001"
        str_CardType = IIf(FrmCardReader.rdHome.Value, "0001", "0002")
        Ht = Write_UserCard(Str_Commport, 0, Trim(FrmCardReader.txtCardID.Text), str_CityCode, str_CardType)
        If Ht < 0 Then
          MsgBox IcErrMsg(Ht)
          Exit Sub
        End If
        If FrmCardReader.rdHome.Value Then
            Ht = Write_CardBuy(Str_Commport, 1, 0, Str_QuID, 1)
        Else
            Ht = Write_CardBuy_01(Str_Commport, 1, 0, Str_QuID, 1)
        End If
        If Ht < 0 Then
          MsgBox IcErrMsg(st), vbExclamation, Title
          Exit Sub
        End If
        MsgBox "�����ɹ�"
    End If
End Sub

Public Sub Remake() '����
    Dim str_CardType  As String
    Dim str_CityCode As String
    
    If CheckForMake() Then
    str_CityCode = "0001"
        str_CardType = IIf(FrmCardReader.rdHome.Value, "0001", "0002")
        Ht = Write_UserCard(Str_Commport, 0, Trim(FrmCardReader.txtCardID.Text), str_CityCode, str_CardType)
        If Ht < 0 Then
          MsgBox IcErrMsg(Ht)
          Exit Sub
        End If
        If FrmCardReader.rdHome.Value Then
            Ht = Write_CardBuy(Str_Commport, 1, 0, Str_QuID, 3)
        Else
            Ht = Write_CardBuy_01(Str_Commport, 1, 0, Str_QuID, 3)
        End If
        If Ht < 0 Then
          MsgBox IcErrMsg(st), vbExclamation, Title
          Exit Sub
        End If
        MsgBox "�����ɹ�"
    End If
End Sub

Public Sub Clear() '�����Ƭ
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
       
    Ht = Read_CardType(Str_Commport, 0, FInt_CardType)
    If (Ht < 0) And (Ht <> -14) Then
        MsgBox IcErrMsg(st), vbExclamation, Title
        Exit Sub
     End If
      
    Select Case FInt_CardType
        Case 10, 90 ' �û���
            Card_Type = FInt_CardType
            Ht = Read_UserCard(Str_Commport, 0, Fstr_UserID, FStr_CityNum, Str_type1)
            Str_CardNum1 = Fstr_UserID
            msg = MsgBox(str_CardType(FInt_CardType) & "Ҫ������", vbOKCancel + vbQuestion + vbDefaultButton2, "������ʾ��")
            If msg = vbOK Then
                Ht = Write_BackCard(Str_Commport, 1, Str_CardNum1)
                If Ht < 0 Then
                    MsgBox IcErrMsg(st), vbExclamation, Title
                    Exit Sub
                End If
                MsgBox "�����ɹ���", vbInformation, Title
             End If
        Case 20, 30, 31, 40, 41, 50, 32, 51 '���㿨
            Str_CardNum1 = "000000"
            msg = MsgBox(str_CardType(FInt_CardType) & "Ҫ������", vbOKCancel + vbQuestion + vbDefaultButton2, "������ʾ��")
            If msg = vbOK Then
                Ht = Write_BackCard(Str_Commport, 1, Str_CardNum1)
                If Ht < 0 Then
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

Public Sub Read() '����
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
    
    FrmCardReader.cmdBuy.Enabled = False
    Ht = Read_CardType(Str_Commport, 0, Int_CardType)
    If Ht < 0 Then GoTo ReadFail
    Call CheckReadCount
    Call IncreaseReadCount
    FrmCardReader.List1.Clear
    FrmCardReader.List1.AddItem "�������ͣ�" & str_CardType(Int_CardType)
    Select Case Int_CardType
        Case 10, 90
            Ht = Read_UserCard(Str_Commport, 0, Fstr_UserID, FStr_CityNum, Str_type)
            If Ht < 0 Then GoTo ReadFail
            FrmCardReader.List1.AddItem "���ţ�" & Fstr_UserID
            FrmCardReader.txtCardID1.Text = Fstr_UserID
            If Int_CardType = 10 Then
                Ht = Read_CardBuy(Str_Commport, 0, Str_Flag, FR_BuyNum, Int_Count, Str_QYID)
            Else
                Ht = Read_CardBuy_01(Str_Commport, 0, Str_Flag, FR_BuyNum, Int_Count, Str_QYID)
            End If
            If Ht < 0 Then GoTo ReadFail
            FrmCardReader.txtAmount.Text = FR_BuyNum
            FrmCardReader.txtCount.Text = Int_Count
            Ht = Read_FPID(Str_Commport, 0, fstr_FP) '��Ʊ��
            If Ht < 0 Then GoTo ReadFail
            FrmCardReader.txtFPID.Text = Format(Val(fstr_FP) + 1, "0000000000")
            If Int_CardType = 10 Then
                Ht = Read_BackNum(Str_Commport, 0, D_SYNum1, D_LJNum1)
            Else
                Ht = Read_BackNum_01(Str_Commport, 0, D_SYNum1, D_LJNum1)
            End If
            Ht = Read_BackNum(Str_Commport, 0, D_SYNum1, D_LJNum1)
            If Ht < 0 Then GoTo ReadFail
            If Str_Flag = 11 Then
              FrmCardReader.List1.AddItem "����״̬���¿�(δ��)"
              FrmCardReader.List1.AddItem "������(������)��" & Format(FR_BuyNum, "##0.00")
            ElseIf Str_Flag = 12 Then
              FrmCardReader.List1.AddItem "����״̬���ɿ�(����)"
              FrmCardReader.List1.AddItem "�ϴι�����(������)��" & Format(FR_BuyNum, "##0.00")
              FrmCardReader.List1.AddItem "ʣ����(������)��" & Format(D_SYNum1, "##0.00")
              FrmCardReader.List1.AddItem "�ۼ�����(������)��" & Format(D_LJNum1, "##0.00")
              FrmCardReader.cmdBuy.Enabled = True
            ElseIf Str_Flag = 13 Then
              FrmCardReader.List1.AddItem "����״̬��������"
              FrmCardReader.cmdBuy.Enabled = True
            ElseIf Str_Flag = 14 Then
              FrmCardReader.List1.AddItem "����״̬������"
              FrmCardReader.cmdBuy.Enabled = True
            End If
            FrmCardReader.CmdBack.Enabled = True
        Case 31
          Ht = Read_Tool(Str_Commport, 1, FR_BuyNum, 48, Str_QYID)
          If Ht < 0 Then GoTo ReadFail
          FrmCardReader.List1.AddItem "Ҫת������(���ñ�)��" & Format(FR_BuyNum, "##0.00")
        Case 40
          Ht = Read_Tool(Str_Commport, 1, FR_BuyNum, 48, Str_QYID)
          If Ht < 0 Then GoTo ReadFail
          FrmCardReader.List1.AddItem "�ۼ�����" & Format(FR_BuyNum, "##0.00")
        Case 50
          Ht = Read_Tool(Str_Commport, 1, FR_BuyNum, 48, Str_QYID)
          If Ht < 0 Then GoTo ReadFail
          FrmCardReader.List1.AddItem "��ʱ����(��)��" & FR_BuyNum
        Case 41
          Ht = Read_Tool(Str_Commport, 1, FR_BuyNum, 48, Str_QYID)
          If Ht < 0 Then GoTo ReadFail
          FrmCardReader.List1.AddItem "��������" & Format(FR_BuyNum, "0.00")
        Case 51
          Ht = Read_Tool(Str_Commport, 1, FR_BuyNum, 48, Str_QYID)
          If Ht < 0 Then GoTo ReadFail
          FrmCardReader.List1.AddItem "��������" & Format(FR_BuyNum, "0.00")
    End Select
    Exit Sub
ReadFail:
    MsgBox IcErrMsg(Ht), vbExclamation, "���ǿ�"
    Exit Sub
End Sub

Public Sub MakeTool()
    Dim Str_City As String
    Dim Int_Offset As Integer
    Dim D_Temp As Double
    Str_City = "1234"
    Int_Offset = 48 '���ñ�48 ��ҵ��80
    If FrmCardReader.Option1(0).Value Then  '��ʼ��
      
    ElseIf FrmCardReader.Option1(1) Then '����
      Ht = Write_Tools(Str_Commport, 1, 20, Str_City, Str_QuID, Int_Offset)
    ElseIf FrmCardReader.Option1(2) Then  'ת�ƿ�
    
    End If
    If Ht < 0 Then
      MsgBox IcErrMsg(Ht)
    Else
      MsgBox "�������߿��ɹ�"
    End If
End Sub



