Attribute VB_Name = "modZhejiangGold"
''����
'����:     intcom: ���ں� com1Ϊ0, com2Ϊ1
'Baud������ͨѶ�����ʣ�1200��115200����
'          vskh���û����ţ�00000000��99999999����
'vlql�� ����������
'vics: ���ڹ�������
'viklx�������ͣ�1���ñ�2��ҵ��3���㿨��4���̿�����ת�ƿ���
'  ����ֵ��int
'          = 0����ȷ
'����:  �������ж���
Public Declare Function Gold_Readcard Lib "goldcard" (ByVal intcom As Integer, ByVal Baud As Long, ByRef userNo As String, ByRef vlql As Long, ByRef vics As Integer, ByRef viklx As Integer) As Long

'����
Public Declare Function Gold_Buycard Lib "goldcard" (ByVal intcom As Integer, ByVal Baud As Long, ByVal userNo As String, ByVal vlql As Long, ByVal vics As Long) As Long

'�����������
Public Declare Function Gold_Clearcard Lib "goldcard" (ByVal intcom As Integer, ByVal Baud As Long, ByVal userNo As String) As Long

'���ش�����Ϣ�ַ���
Public Declare Sub Error_message Lib "goldcard" (ByVal errCode As Long, ByVal msg As String)

'����Ƿ��Ǳ���˾�Ŀ� ����ֵ 0���û�����1�����߿�����������
Public Declare Function Gold_CheckCard Lib "goldcard" (ByVal intcom As Integer, ByVal Baud As Long, ByRef error As String) As Long

'ע������
'1�� ��������һ��Ҫ��ȷ����������ֻ�ܱ��ϴι��������󣬷����᲻�Ͽ���
'2�� ����д��ʱ��������ڻ���������DLL��ѿ��ڵ������滻�ˣ���������ӡ�



