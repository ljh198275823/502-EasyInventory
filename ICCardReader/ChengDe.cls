VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "ChengDe"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
'/底层动态库
'///////////明华函数
Private Declare Function ic_init Lib "MWIC_32" (ByVal port As Long, ByVal Baud As Long) As Long
Private Declare Function ic_exit Lib "MWIC_32" (ByVal icDev As Long) As Long
Private Declare Function csc_4442 Lib "MWIC_32" (ByVal icDev As Long, ByVal leng As Long, ByVal databuff As String) As Long
Private Declare Function wsc_4442 Lib "MWIC_32" (ByVal icDev As Long, ByVal leng As Long, ByVal databuff As String) As Long

'///////////IC卡函数
Private Declare Function rdcompany Lib "BGCard" (ByVal icDev As Long, isTrue As Byte) As Long
Private Declare Function readCard Lib "BGCard" (ByVal icDev As Long, ByVal userCode As String, cardAmount As Single, meterAmount As Single, TestAmount As Single, inserted As Byte) As Long
Private Declare Function MakeCard Lib "BGCard" Alias "makeCard" (ByVal icDev As Long, ByVal userCode As String, ByVal Amount As Single, ByVal saveInfo As String, ByVal mark As Byte) As Long
Private Declare Function writeCard Lib "BGCard" (ByVal icDev As Long, ByVal userCode As String, ByVal Amount As Single, ByVal saveInfo As String) As Long
Private Declare Function ClearCard Lib "BGCard" Alias "clearCard" (ByVal icDev As Long, ByVal userCode As String) As Long
Private Declare Function writetoolCard Lib "BGCard" (ByVal icDev As Long, ByVal WriteType As Long, ByVal TestAmount As Single, ByVal TestTimes As Long) As Long

'////全局变量，保存返回信息
Private Sub WriteInfo(s As String)
    Open App.Path & "\saveinf.txt" For Output As #1
    Print #1, s
    Close #1
End Sub

Private Function ReadInfo() As String
    Open App.Path & "\saveinf.txt" For Input As #1
    Dim FileData As String
    Input #1, FileData
    ReadInfo = FileData
    Close #1
End Function

Private Function ChengdeErr(ByVal err As Integer) As String
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
'-----------------------------------------------------end-----------------------------------------------------

Public Function IsMyCard() As Boolean
    Dim icDev As Long
    Dim isTrue As Byte
    Dim reVal As Long
    icDev = ic_init(My_Commport - 1, 9600) '串口号0开始，所以要减一
    reVal = rdcompany(icDev, isTrue)
    If reVal = 0 Then
        If isTrue = 0 Then IsMyCard = True
    End If
    ic_exit icDev
End Function

Public Sub Buy()
    Dim icDev As Long
    Dim reVal As Long
    Dim userCode As String * 8
    Dim saveInfo As String * 16
    
    icDev = ic_init(My_Commport - 1, 9600) '串口号0开始，所以要减一
    userCode = FrmCardReader.txtCardID1.Text
'    saveInfo = ReadInfo
    reVal = writeCard(icDev, userCode, Val(FrmCardReader.txtAmount.Text), saveInfo)
    If reVal = 0 Then
'        WriteInfo saveInfo
        MsgBox "售气成功。"
    Else
        MsgBox "售气失败，错误:" & ChengdeErr(reVal)
    End If
    ic_exit icDev
End Sub

Public Sub Back()
    Dim icDev As Long
    Dim reVal As Long
    Dim userCode As String * 8
    Dim saveInfo As String * 16
    
    icDev = ic_init(My_Commport - 1, 9600) '串口号0开始，所以要减一
    userCode = FrmCardReader.txtCardID1.Text
'    saveInfo = ReadInfo
    reVal = writeCard(icDev, userCode, 0, saveInfo)
    If reVal = 0 Then
'        WriteInfo saveInfo
        MsgBox "退气成功。"
    Else
        MsgBox "退气失败，错误:" & ChengdeErr(reVal)
    End If
    ic_exit icDev
End Sub

Private Function CheckForMake() As Boolean
    If Len(FrmCardReader.txtCardID.Text) <> 8 Then
        MsgBox "卡号不正确，应该为8位数字"
        CheckForMake = False
        Exit Function
    End If
    If Not IsNumeric(FrmCardReader.txtCardID.Text) Then
        MsgBox "卡号不能包函非数字"
        CheckForMake = False
        Exit Function
    End If
    CheckForMake = True
End Function

Public Sub Make()
    Dim icDev As Long
    Dim reVal As Long
    
    Dim saveInfo As String * 16
    
    If CheckForMake() Then
        icDev = ic_init(My_Commport - 1, 9600) '串口号0开始，所以要减一
        reVal = MakeCard(icDev, FrmCardReader.txtCardID.Text, 0, saveInfo, 129)
        If reVal = 0 Then
'            WriteInfo saveInfo
            MsgBox "发卡成功"
        Else
            MsgBox "发卡失败，错误:" & ChengdeErr(reVal)
        End If
        ic_exit icDev
    End If
End Sub

Public Sub Remake()
    Dim icDev As Long
    Dim reVal As Long
    Dim saveInfo As String * 16
    
    If CheckForMake() Then
        icDev = ic_init(My_Commport - 1, 9600) '串口号0开始，所以要减一
'        saveInfo = ReadInfo
        reVal = MakeCard(icDev, FrmCardReader.txtCardID.Text, 0, saveInfo, 0)  '//mark=0 最后一次购气未输入到气表内，mark=1 最后一次购气已输入到表内
        If reVal = 0 Then
'            WriteInfo saveInfo
            MsgBox "补卡成功"
        Else
            MsgBox "补卡失败，错误:" & ChengdeErr(reVal)
        End If
        ic_exit icDev
    End If
End Sub

Public Sub Clear()
    Dim icDev As Long
    Dim reVal As Long
    Dim userCode As String * 8
    
    icDev = ic_init(My_Commport - 1, 9600) '串口号0开始，所以要减一
    userCode = FrmCardReader.txtCardID1.Text
    reVal = ClearCard(icDev, userCode)
    If reVal = 0 Then
        MsgBox "清卡成功。"
    Else
        MsgBox "清卡失败，错误:" & ChengdeErr(reVal)
    End If
    ic_exit icDev
End Sub

Public Sub Read()
    Dim icDev As Long
    Dim reVal As Long
    Dim userCode As String * 8
    Dim cardAmount, meterAmount, TestAmount As Single
    Dim inserted As Byte
    Dim times As Long
    
    icDev = ic_init(My_Commport - 1, 9600) '串口号0开始，所以要减一
    reVal = readCard(icDev, userCode, cardAmount, meterAmount, TestAmount, inserted)
    If reVal = 0 Then
        Call CheckReadCount
        Call IncreaseReadCount
        FrmCardReader.txtCardID1.Text = userCode
        FrmCardReader.txtAmount.Text = cardAmount
        FrmCardReader.List1.AddItem "卡号:" & userCode
        FrmCardReader.List1.AddItem "卡上余量:" & cardAmount
        FrmCardReader.List1.AddItem "表上余量:" & meterAmount
        FrmCardReader.List1.AddItem IIf(inserted = 0, "未", "已") & "在气表上插卡"
    Else
        MsgBox "读卡失败，错误:" & ChengdeErr(reVal)
    End If
    ic_exit icDev
End Sub

Public Sub MakeTool()
    Dim icDev As Long
    Dim reVal As Long

    icDev = ic_init(My_Commport - 1, 9600) '串口号0开始，所以要减一
    If FrmCardReader.Option1(0).Value Then
        reVal = writetoolCard(icDev, 5, 0, 0)
    ElseIf FrmCardReader.Option1(1).Value Then
        reVal = writetoolCard(icDev, 9, 0, 0)
    ElseIf FrmCardReader.Option1(2).Value Then
        reVal = writetoolCard(icDev, 7, 0, 0)
    End If
    If reVal = 0 Then
        MsgBox "发工具卡成功。"
    Else
        MsgBox "发工具卡失败，错误:" & ChengdeErr(reVal)
    End If
    ic_exit icDev
End Sub



