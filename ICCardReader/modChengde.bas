Attribute VB_Name = "modChengde"
'////////////�������ش���ֵ����
Const ERROR_SUCCESS = 0 '//�ɹ�
Const ERROR_CARDDATA = 1 '//���������Ǵ����
Const ERROR_NOUSER = 2 '//û������û�
Const ERROR_ENCRYPT = 3 '//�������ݳ���
Const ERROR_REVDATA = 4 '//���յ����ݴ���
Const ERROR_LOCK = 5 '//������æ����
Const ERROR_NEGAMOUNT = 6 '//����������
Const ERROR_SAVEUSER = 7 '//�����û�����
Const ERROR_SAVEMETER = 8 '//��������ݳ���
Const ERROR_USER = 9 '//�û��źͿ�����Ӧ
Const ERROR_WRITECARD = 10 '//д������
Const ERROR_READCARD = 11 '//��������
Const ERROR_CONNECT = 12 '//���ӷ���������
Const ERROR_USERCODELEN = 13 '//�û��ų��ȴ���
Const ERROR_USERCODECHAR = 14 '//�û����ַ��Ƿ�
Const ERROR_EXISITUSER = 15 '//�û����Ѵ���
Const ERROR_NOTSBOGUANCARD = 16  '//�ǲ��ڿ�
Const ERROR_CARDPASSWORD = 17  '//У�鿨�������
Const ERROR_DATA = 18  '//���ݴ���
Const ERROR_CARD = 19  '//IC���ѱ���
Const ERROR_DEDUCTAMOOUNT = 20  '//���������ڿ��ڴ�������
Const ERROR_USERCARD = 21  '//���û���
Const ERROR_CHECKSUM = 22  '//У��ʹ���
Const ERROR_AMOUNT = 23  '//��������
'///////////��������
Public Declare Function ic_init Lib "MWIC_32" (ByVal port As Long, ByVal baud As Long) As Long
Public Declare Function ic_exit Lib "MWIC_32" (ByVal icDev As Long) As Long
Public Declare Function csc_4442 Lib "MWIC_32" (ByVal icDev As Long, ByVal leng As Long, ByVal databuff As String) As Long
Public Declare Function wsc_4442 Lib "MWIC_32" (ByVal icDev As Long, ByVal leng As Long, ByVal databuff As String) As Long

'///////////IC������
Public Declare Function rdcompany Lib "BGCard" (ByVal icDev As Long, isTrue As Byte) As Long
Public Declare Function readCard Lib "BGCard" (ByVal icDev As Long, ByVal userCode As String, cardAmount As Single, meterAmount As Single, TestAmount As Single, inserted As Byte) As Long
Public Declare Function makeCard Lib "BGCard" (ByVal icDev As Long, ByVal userCode As String, ByVal Amount As Single, ByVal saveInfo As String, ByVal mark As Byte) As Long
Public Declare Function writeCard Lib "BGCard" (ByVal icDev As Long, ByVal userCode As String, ByVal Amount As Single, ByVal saveInfo As String) As Long
Public Declare Function clearCard Lib "BGCard" (ByVal icDev As Long, ByVal userCode As String) As Long
Public Declare Function writeToolCard Lib "BGCard" (ByVal icDev As Long, ByVal WriteType As Long, ByVal TestAmount As Single, ByVal TestTimes As Long) As Long

'////ȫ�ֱ��������淵����Ϣ
Public Sub WriteInfo(s As String)
    Open App.Path & "\saveinf.txt" For Output As #1
    Print #1, s
    Close #1
End Sub

Public Function ReadInfo() As String
    Open App.Path & "\saveinf.txt" For Input As #1
    Dim FileData As String
    Input #1, FileData
    ReadInfo = FileData
    Close #1
End Function

Public Function ChengdeErr(ByVal err As Integer) As String
    ChengdeErr = "δ֪����"
    Select Case err
        Case 1
            ChengdeErr = "���������Ǵ����"
        Case 2
            ChengdeErr = "û������û�"
        Case 3
            ChengdeErr = "�������ݳ���"
        Case 6
            ChengdeErr = "����������"
        Case 9
            ChengdeErr = "�û��źͿ�����Ӧ"
        Case 10
            ChengdeErr = "д������"
        Case 11
            ChengdeErr = "��������"
        Case 13
            ChengdeErr = "�û��ų��ȴ���"
        Case 14
            ChengdeErr = "�û����ַ��Ƿ�"
        Case 15
            ChengdeErr = "�û����Ѵ���"
        Case 16
            ChengdeErr = "�ǲ��ڿ�"
        Case 17
            ChengdeErr = "У�鿨�������"
        Case 18
            ChengdeErr = "���ݴ���"
        Case 19
            ChengdeErr = "IC���ѱ���"
        Case 20
            ChengdeErr = "���������ڿ��ڴ�������"
        Case 21
            ChengdeErr = "���û���"
        Case 22
            ChengdeErr = "У��ʹ���"
        Case 23
            ChengdeErr = "��������"
    End Select
End Function
