Attribute VB_Name = "modeBeite"

'�û������˻�����
'1.ֻ�д��ڳ�ʼ״̬�Ŀ�Ƭ���ܽ��п�Ƭ�ĸ��˻�����
'2.��ɸ��˻���������û�������Ԥ������Ϊ��
Public Declare Function Personalize Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByVal AlarmValue As Integer, ByVal InputValue As Integer, ByVal OverLimit As Long, ByVal Control As Long, ByRef pErrMsg As String) As Long

'�û�����ֵ����  ÿ����һ���û����������ף����Ͻ�����ż�1
Public Declare Function Credit Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByVal ChargeSerialNum As Long, ByVal purchaeAmount As Long, ByRef pErrMsg As String) As Long

'�û��������  ��ɲ�����ԭ���Ͻ�����ű��ֲ���
Public Declare Function Increase Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByRef Buygas As Long, ByVal PurchaseAmount As Long, ByRef pErrMsg As String) As Long

'���� ����˹����׺�ԭ���Ͻ�����ű��ֲ���
Public Declare Function Decrease Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, _
    ByVal userNo As String, ByRef Buygas As Long, ByVal PurchaseAmount As Long, ByRef pErrMsg As String) As Long

'���û�������������
Public Declare Function rUserData Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByRef userNo As String, _
ByRef ChargeSerialNum As Long, ByRef PurchaseAmount As Long, ByRef AlarmValue As Long, ByRef InputValue As Long, _
ByRef OverLimit As Long, ByRef Control As Long, ByRef pErrMsg As String) As Long

'���û�������д������
Public Declare Function rUserDataR Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByRef RStartcode As String, _
ByRef meterNo As String, ByRef TotalBuyGas As Long, ByRef TotalBuyNum As Long, ByRef residualGas As Long, _
ByRef TotalTakeGas As Single, ByRef ChangePassNum As Long, ByRef FMState As Long, ByRef ESAMState As Long, _
ByRef DCState As Long, ByRef CGRState As Long, ByRef Magnet As Long, ByRef Low As Long, ByRef MonthUserGas As String, _
ByRef RDate As String, ByRef pErrMsg As String) As Long

'����
Public Declare Function ReissueCard Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByVal AlarmValue As Integer, ByVal InputValue As Integer, ByVal OverLimit As Long, ByVal Control As Long, ByRef pErrMsg As String) As Long

'����һ�Ż���
Public Declare Function ChangeMeter Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByVal AlarmValue As Integer, ByVal InputValue As Integer, ByVal OverLimit As Long, ByVal buy As Long, _
ByVal TotalBuyGas As Long, ByVal TotalBuyNum As Long, ByVal residualGas As Long, ByVal TotalTakeGas As Single, ByVal Control As Long, _
ByRef pErrMsg As String) As Long

'��տ�
'Public Declare Function ClearCard Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByRef pErrMsg As String) As Long

'������ʹ����
Public Declare Function MakeIniCard Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal upfrontGas As Long, ByVal AlarmValue As Long, _
ByVal OverLimit As Long, ByVal Control As Long, ByRef pErrMsg As String) As Long

'�����û�������
Public Declare Function SetUserParameter Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, ByVal AlarmValue As Long, _
ByVal OverLimit As Long, ByVal Control As Long, ByRef pErrMsg As String) As Long




