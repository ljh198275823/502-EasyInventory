Attribute VB_Name = "modHangxing"
Option Explicit
Public Ht As Integer
Public Str_QuID As String '�������
'***********************    operate sle 4442    **************************TestIc_Type
'Declare Function TEST_COM Lib "Saron_Rq.dll" (ByVal icdev As Long) As Integer

'��ȡ��Ƭ����
Declare Function Read_CardType Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Int_CardType As Long) As Integer
'��ȡ��Ƭ��Ϣ
Declare Function Read_UserCard Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Str_Cardnum As String, str_CityCode As String, Str_type As String) As Integer
'д�뿨Ƭ��Ϣ
Declare Function Write_UserCard Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_Cardnum As String, ByVal str_CityCode As String, ByVal Str_type As String) As Integer
'��ȡ8888
Declare Function Read_CardBuy Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Str_Flag As String, R_BuyNum As Double, Int_Count As Long, Str_QYID As String) As Integer
Declare Function Read_CardBuy_01 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Str_Flag As String, R_BuyNum As Double, Int_Count As Long, Str_QYID As String) As Integer

 
     
Declare Function Write_CardBuy Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal R_BuyNum As Double, ByVal Str_QYID As String, ByVal Int_WriteFlag As Long) As Integer
Declare Function Write_CardBuy_01 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal R_BuyNum As Double, ByVal Str_QYID As String, ByVal Int_WriteFlag As Long) As Integer

' �⿨88888888888

'Read_CardType(Str_Com:Pchar;Int_Beep:integer;var Int_CardType:integer):smallint;stdcall;

' д���߿�   20 ���㿨  30 ���̿�88888888
Declare Function Write_Tools Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Int_CardType As Integer, ByVal Str_CityNum As String, ByVal Str_QYID As String, ByVal Int_Offset1 As Integer) As Integer

' д���߿�   40 Ϊ�趨��  50 ��ʱ��8888888888
Declare Function Write_Tools1 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Int_CardType As Integer, ByVal D_Num As Double, ByVal Str_QYID As String, ByVal Int_Offset1 As Integer) As Integer
'д��Ʊ��

Declare Function Write_FPID Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_FP As String) As Integer

'����Ʊ��Write_BackCard

Declare Function Read_FPID Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Str_FP As String) As Integer

'��������88888888888
Declare Function Write_BackCard Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_Cardnum As String) As Integer
'��֤����
Declare Function CheckCard_Pass Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_Cardnum As String) As Integer

'��ʼ����888888888888
Declare Function Write_CardInit Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_Pass As String) As Integer
'��ȡ���߿�88888888888888
Declare Function Read_Tool Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, D_Num As Double, ByVal Int_Offset1 As Integer, Str_QYID As String) As Integer

'�ض��û���888888888888888888888888
Declare Function Read_BackNum Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, D_SYNum As Double, D_LJNum As Double) As Integer
Declare Function Read_BackNum_01 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, D_SYNum As Double, D_LJNum As Double) As Integer

Declare Function Ver_Number Lib "Srq_01.dll" (Str_Ver As String) As Integer


'Declare Function Write_CardBuy1 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal R_BuyNum As Double, ByVal Str_QYID As String, ByVal Int_WriteFlag As Long, ByVal Int_WCount As Long, ByVal Int_BCount As Long, ByVal Int_BZHI As Long) As Integer

''��ȡӲ�̺�
'Declare Function Ver_HDS Lib "Srq_01.dll" (Str_HDS As String) As Integer
''�õ�Դ������
'Declare Function Des_ReadSource Lib "Srq_01.dll" (ByVal Str_Dest1 As String, ByVal Str_HDS1 As String, Str_Number1 As String) As Integer
'
'Declare Function Des_Source Lib "Srq_01.dll" (ByVal Str_Number1 As String, ByVal Str_HDS1 As String, Str_Dest1 As String) As Integer





Function IcErrMsg(ByVal intErrCode As Integer) As String
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
Function str_CardType(ByVal Int_CardType As Integer) As String
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
