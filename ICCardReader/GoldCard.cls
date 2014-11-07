VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "GoldCard"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
''读卡
'参数:     intcom: 串口号 com1为0, com2为1
'Baud：串口通讯波特率（1200－115200）。
'          vskh：用户卡号（00000000－99999999）；
'vlql： 可用气量；
'vics: 表卡内购气次数
'viklx：表类型，1民用表，2工业表，3清零卡，4工程卡（即转移卡）
'  返回值：int
'          = 0：正确
'其它:  厂家自行定义
Private Declare Function Gold_Readcard Lib "GoldCard" (ByVal intcom As Integer, ByVal Baud As Long, ByRef userNo As String, ByRef vlql As Long, ByRef vics As Integer, ByRef viklx As Integer) As Long

'购气
Private Declare Function Gold_Buycard Lib "GoldCard" (ByVal intcom As Integer, ByVal Baud As Long, ByVal userNo As String, ByVal vlql As Long, ByVal vics As Long) As Long

'清除卡内气量
Private Declare Function Gold_Clearcard Lib "GoldCard" (ByVal intcom As Integer, ByVal Baud As Long, ByVal userNo As String) As Long

'返回错误信息字符串
Private Declare Sub Error_message Lib "GoldCard" (ByVal errCode As Long, ByVal msg As String)

'检查是否是本公司的卡 返回值 0：用户卡；1：工具卡；其它出错。
Private Declare Function Gold_CheckCard Lib "GoldCard" (ByVal intcom As Integer, ByVal Baud As Long, ByRef error As String) As Long

'注意事项
'1、 购气次数一定要正确，购气次数只能比上次购气次数大，否则表会不认卡。
'2、 购气写卡时，如果卡内还有气量，DLL会把卡内的气量替换了，并不会相加。

'-----------------------------------end--------------------------------------------------------------------

Public Sub Buy()
    Dim ret As Long
    Dim msg As String * 50
    
    ret = Gold_Buycard(My_Commport - 1, 9600, FrmCardReader.txtCardID1.Text, Val(FrmCardReader.txtAmount.Text), Val(FrmCardReader.txtCount.Text))
    If ret = 0 Then
        MsgBox "售气成功。"
        FrmCardReader.cmdBuy.Enabled = False
    Else
        Call Error_message(ret, msg)
        MsgBox "售气失败，错误:" & msg
    End If
End Sub

Public Sub Back()
    Dim ret As Long
    Dim msg As String * 50
    
    ret = Gold_Buycard(My_Commport - 1, 9600, FrmCardReader.txtCardID1.Text, 0, IIf(Val(FrmCardReader.txtCount.Text) > 1, Val(FrmCardReader.txtCount.Text) - 1, 0))
    If ret = 0 Then
        MsgBox "退气成功。"
        FrmCardReader.cmdBuy.Enabled = False
    Else
        Call Error_message(ret, msg)
        MsgBox "退气失败，错误:" & msg
    End If
End Sub

Public Sub Clear()
    Dim ret As Long
    Dim msg As String * 50
    
    ret = Gold_Clearcard(My_Commport - 1, 9600, FrmCardReader.txtCardID.Text)
    If ret = 0 Then
        MsgBox "清卡成功。"
    Else
        Call Error_message(ret, msg)
        MsgBox "清卡失败，错误:" & msg
    End If
End Sub

Public Sub Read()
    Dim ret As Long
    Dim userNo As String
    Dim vlql As Long
    Dim vics As Integer
    Dim viklx As Integer
    Dim msg As String * 50
    
    Call CheckReadCount
    Call IncreaseReadCount
    FrmCardReader.List1.Clear
    
    ret = Gold_Readcard(My_Commport - 1, 9600, userNo, vlql, vics, viklx) '串口号0开始，所以要减一
    If ret = 0 Then
        Call CheckReadCount
        Call IncreaseReadCount
        FrmCardReader.txtCardID1.Text = userCode
        FrmCardReader.List1.AddItem "卡号：" & userCode
        FrmCardReader.txtAmount.Text = vlql
        FrmCardReader.List1.AddItem "卡片气余量：" & vlql
        FrmCardReader.txtCount.Text = vics + 1
        FrmCardReader.List1.AddItem "充气次数：" & vics
        Select Case viklx
            Case 1
                FrmCardReader.List1.AddItem "卡片类型：民用卡"
            Case 2
                FrmCardReader.List1.AddItem "卡片类型：工业卡"
            Case 3
                FrmCardReader.List1.AddItem "卡片类型：清零卡"
            Case 4
                FrmCardReader.List1.AddItem "卡片类型：转移卡"
        End Select
        FrmCardReader.cmdBuy.Enabled = True
    Else
        Call Error_message(ret, msg)
        MsgBox "读卡失败，错误:" & msg
    End If
End Sub

Public Function IsMyCard() As Boolean
    Dim ret As Long
    Dim msg As String * 50
    
    ret = Gold_CheckCard(My_Commport - 1, 9600, msg)
    If ret = 0 Or ret = 1 Then
        IsMyCard = True
    End If
End Function




