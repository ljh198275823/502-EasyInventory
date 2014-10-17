Attribute VB_Name = "modChengde"
'////////////函数返回错误值定义
Const ERROR_SUCCESS = 0 '//成功
Const ERROR_CARDDATA = 1 '//读卡数据是错误的
Const ERROR_NOUSER = 2 '//没有这个用户
Const ERROR_ENCRYPT = 3 '//加密数据出错
Const ERROR_REVDATA = 4 '//接收的数据错误
Const ERROR_LOCK = 5 '//服务器忙错误
Const ERROR_NEGAMOUNT = 6 '//负气量错误
Const ERROR_SAVEUSER = 7 '//保存用户出错
Const ERROR_SAVEMETER = 8 '//保存表数据出错
Const ERROR_USER = 9 '//用户号和卡不对应
Const ERROR_WRITECARD = 10 '//写卡出错
Const ERROR_READCARD = 11 '//读卡出错
Const ERROR_CONNECT = 12 '//连接服务器出错
Const ERROR_USERCODELEN = 13 '//用户号长度错误
Const ERROR_USERCODECHAR = 14 '//用户号字符非法
Const ERROR_EXISITUSER = 15 '//用户号已存在
Const ERROR_NOTSBOGUANCARD = 16  '//非博冠卡
Const ERROR_CARDPASSWORD = 17  '//校验卡密码错误
Const ERROR_DATA = 18  '//数据错误
Const ERROR_CARD = 19  '//IC卡已报废
Const ERROR_DEDUCTAMOOUNT = 20  '//扣气量大于卡内存量错误
Const ERROR_USERCARD = 21  '//非用户卡
Const ERROR_CHECKSUM = 22  '//校验和错误
Const ERROR_AMOUNT = 23  '//气量超大
'///////////明华函数
Public Declare Function ic_init Lib "MWIC_32" (ByVal port As Long, ByVal baud As Long) As Long
Public Declare Function ic_exit Lib "MWIC_32" (ByVal icDev As Long) As Long
Public Declare Function csc_4442 Lib "MWIC_32" (ByVal icDev As Long, ByVal leng As Long, ByVal databuff As String) As Long
Public Declare Function wsc_4442 Lib "MWIC_32" (ByVal icDev As Long, ByVal leng As Long, ByVal databuff As String) As Long

'///////////IC卡函数
Public Declare Function rdcompany Lib "BGCard" (ByVal icDev As Long, isTrue As Byte) As Long
Public Declare Function readCard Lib "BGCard" (ByVal icDev As Long, ByVal userCode As String, cardAmount As Single, meterAmount As Single, TestAmount As Single, inserted As Byte) As Long
Public Declare Function makeCard Lib "BGCard" (ByVal icDev As Long, ByVal userCode As String, ByVal Amount As Single, ByVal saveInfo As String, ByVal mark As Byte) As Long
Public Declare Function writeCard Lib "BGCard" (ByVal icDev As Long, ByVal userCode As String, ByVal Amount As Single, ByVal saveInfo As String) As Long
Public Declare Function clearCard Lib "BGCard" (ByVal icDev As Long, ByVal userCode As String) As Long
Public Declare Function writeToolCard Lib "BGCard" (ByVal icDev As Long, ByVal WriteType As Long, ByVal TestAmount As Single, ByVal TestTimes As Long) As Long

'////全局变量，保存返回信息
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
    ChengdeErr = "未知错误"
    Select Case err
        Case 1
            ChengdeErr = "读卡数据是错误的"
        Case 2
            ChengdeErr = "没有这个用户"
        Case 3
            ChengdeErr = "加密数据出错"
        Case 6
            ChengdeErr = "负气量错误"
        Case 9
            ChengdeErr = "用户号和卡不对应"
        Case 10
            ChengdeErr = "写卡出错"
        Case 11
            ChengdeErr = "读卡出错"
        Case 13
            ChengdeErr = "用户号长度错误"
        Case 14
            ChengdeErr = "用户号字符非法"
        Case 15
            ChengdeErr = "用户号已存在"
        Case 16
            ChengdeErr = "非博冠卡"
        Case 17
            ChengdeErr = "校验卡密码错误"
        Case 18
            ChengdeErr = "数据错误"
        Case 19
            ChengdeErr = "IC卡已报废"
        Case 20
            ChengdeErr = "扣气量大于卡内存量错误"
        Case 21
            ChengdeErr = "非用户卡"
        Case 22
            ChengdeErr = "校验和错误"
        Case 23
            ChengdeErr = "气量超大"
    End Select
End Function
