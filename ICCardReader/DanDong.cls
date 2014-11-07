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

'/底层动态库
'///////////明华函数
Private Declare Function CheckOwnCard Lib "DR_Soft" (ByVal port As Long, ByVal Baud As Long) As Long
'读卡
Private Declare Function ReadICCard Lib "DR_Soft" (ByVal port As Long, ByVal Baud As Long, ByVal ICId As String, ByRef ICType As Long, ByRef ICCSpare As Double, ByRef GASCount As Long, ByRef CusType As Long, ByRef ICUsed As Double, ByRef ICMSpare As Double, ByRef ICNum As Long, ByVal ICMark As String, ByVal ICMUType As String) As Long
'写卡
Private Declare Function WriteICCard Lib "DR_Soft" (ByVal port As Long, ByVal Baud As Long, ByVal ICId As String, ByVal OPCode As Long, ByVal GASCount As Long, ByVal ICCSpare As Double, ByVal ICType As Long, ByVal CusType As Long, ByVal ICMark As String) As Long
'清空卡片
Private Declare Function ClearAllCard Lib "DR_Soft" (ByVal port As Long, ByVal Baud As Long) As Long
'制作初始化卡
Private Declare Function MakeIniCard Lib "DR_Soft" (ByVal port As Long, ByVal Baud As Long, ByVal frontGas As Double, ByVal AlarmValue As Double, ByVal InputValue As Double, ByVal controlValue As Double) As Long
'制作工具卡  4：制作清零卡5: 制作管理卡6: 转移卡
Private Declare Function WriteGjkCard Lib "DR_Soft" (ByVal port As Long, ByVal Baud As Long, ByVal GjkType As Long) As Long

Private Function ErrorMsg(ByVal err As Long) As String
    ErrorMsg = "未知错误"
    Select Case err
        Case 1
            ErrorMsg = "卡被更换（卡片核对不符）"
        Case 2
            ErrorMsg = "没有卡"
        Case 3
            ErrorMsg = "读写卡器配置不对"
        Case 4
            ErrorMsg = "读写卡器不工作"
        Case 5
            ErrorMsg = "dll内部故障"
        Case 6
            ErrorMsg = "卡类型错误（新卡为卡型号错误，老卡为卡型号错误及内容算法错误、密码错误等)"
        Case 10
            ErrorMsg = "新卡"
        Case 11
            ErrorMsg = "读卡密码次数失败"
        Case 12
            ErrorMsg = "卡密码次数为0"
        Case 13
            ErrorMsg = "卡片已发行"
        Case 14
            ErrorMsg = "非本系统的卡"
        Case 15
            ErrorMsg = "地区代码错误"
        Case 16
            ErrorMsg = "文件内容错误"
        Case 18
            ErrorMsg = "气量超限"
        Case 19
            ErrorMsg = "溢出"
        Case 97
            ErrorMsg = "读卡错误"
        Case 98
            ErrorMsg = "串口初始化失败"
        Case 100
            ErrorMsg = "配置文件不存在"
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
        MsgBox "卡号不正确，应该为8位数字"
        Exit Function
    End If
    If Not IsNumeric(FrmCardReader.txtCardID.Text) Then
        MsgBox "卡号不能包函非数字"
        Exit Function
    End If
    If FrmCardReader.rdHome.Value = False And FrmCardReader.rdIndustry.Value = False Then
        MsgBox "请选择用户类型"
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
            MsgBox "发卡成功"
        Else
            MsgBox "发卡失败，错误:" & ErrorMsg(ret)
        End If
    End If
End Sub

Public Sub Remake()
    Dim ret As Long
    Dim ICMark As String * 20
    
    If CheckForMake() Then
        ret = WriteICCard(My_Commport - 1, 9600, FrmCardReader.txtCardID.Text, 127, 0, 0, 32, IIf(FrmCardReader.rdHome.Value, 1, 2), ICMark)
        If ret = 0 Then
            MsgBox "补卡成功"
        Else
            MsgBox "补卡失败，错误:" & ErrorMsg(ret)
        End If
    End If
End Sub

Public Sub Clear()
    Dim ret As Long
    
    ret = ClearAllCard(My_Commport - 1, 9600)
    If ret = 0 Then
        MsgBox "清卡成功。"
    Else
        MsgBox "清卡失败，错误:" & ErrorMsg(ret)
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
        Cus_Type = CusType  '用于写卡的时候
        FrmCardReader.List1.AddItem "卡号：" & Trim(ICId)
        FrmCardReader.List1.AddItem "用户类型：" & IIf(CusType = 1, "家用卡", "工业卡")
        FrmCardReader.List1.AddItem "卡上余量：" & ICCSpare
        FrmCardReader.List1.AddItem "卡片种类：" & "丹东卡"
        FrmCardReader.cmdBuy.Enabled = True
        FrmCardReader.CmdBack.Enabled = IIf(ICCSpare > 0, True, False)
        FrmCardReader.cmdClear.Enabled = True
        FrmCardReader.Option1(0).Enabled = False
    Else
        MsgBox "读卡失败，错误:" & ErrorMsg(ret)
    End If
End Sub

Public Sub Buy()
    Dim ret As Long
    Dim ICMark As String * 20

    ret = WriteICCard(My_Commport - 1, 9600, FrmCardReader.txtCardID1.Text, 6, Val(FrmCardReader.txtCount.Text), Val(FrmCardReader.txtAmount.Text), 32, Cus_Type, ICMark)
    If ret = 0 Then
        MsgBox "购气成功"
        FrmCardReader.cmdBuy.Enabled = False
        FrmCardReader.CmdBack.Enabled = False
    Else
        MsgBox "购气失败，错误:" & ErrorMsg(ret)
    End If
End Sub


Public Sub Back()
    Dim ret As Long
    Dim ICMark As String * 20

    ret = WriteICCard(My_Commport - 1, 9600, FrmCardReader.txtCardID1.Text, 6, Val(FrmCardReader.txtCount.Text), 0, 32, Cus_Type, ICMark)
    If ret = 0 Then
        MsgBox "退气成功"
        FrmCardReader.cmdBuy.Enabled = False
        FrmCardReader.CmdBack.Enabled = False
    Else
        MsgBox "退气失败，错误:" & ErrorMsg(ret)
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
        MsgBox "发工具卡成功。"
    Else
        MsgBox "发工具卡失败，错误:" & ErrorMsg(ret)
    End If
End Sub



