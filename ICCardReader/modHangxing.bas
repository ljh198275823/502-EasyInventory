Attribute VB_Name = "modHangxing"
Option Explicit
Public Ht As Integer
Public Str_QuID As String '区域代码
'***********************    operate sle 4442    **************************TestIc_Type
'Declare Function TEST_COM Lib "Saron_Rq.dll" (ByVal icdev As Long) As Integer

'读取卡片类型
Declare Function Read_CardType Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Int_CardType As Long) As Integer
'读取卡片信息
Declare Function Read_UserCard Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Str_Cardnum As String, str_CityCode As String, Str_type As String) As Integer
'写入卡片信息
Declare Function Write_UserCard Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_Cardnum As String, ByVal str_CityCode As String, ByVal Str_type As String) As Integer
'读取8888
Declare Function Read_CardBuy Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Str_Flag As String, R_BuyNum As Double, Int_Count As Long, Str_QYID As String) As Integer
Declare Function Read_CardBuy_01 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Str_Flag As String, R_BuyNum As Double, Int_Count As Long, Str_QYID As String) As Integer

 
     
Declare Function Write_CardBuy Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal R_BuyNum As Double, ByVal Str_QYID As String, ByVal Int_WriteFlag As Long) As Integer
Declare Function Write_CardBuy_01 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal R_BuyNum As Double, ByVal Str_QYID As String, ByVal Int_WriteFlag As Long) As Integer

' 测卡88888888888

'Read_CardType(Str_Com:Pchar;Int_Beep:integer;var Int_CardType:integer):smallint;stdcall;

' 写工具卡   20 清零卡  30 工程卡88888888
Declare Function Write_Tools Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Int_CardType As Integer, ByVal Str_CityNum As String, ByVal Str_QYID As String, ByVal Int_Offset1 As Integer) As Integer

' 写工具卡   40 为设定卡  50 限时卡8888888888
Declare Function Write_Tools1 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Int_CardType As Integer, ByVal D_Num As Double, ByVal Str_QYID As String, ByVal Int_Offset1 As Integer) As Integer
'写发票号

Declare Function Write_FPID Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_FP As String) As Integer

'读发票号Write_BackCard

Declare Function Read_FPID Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Str_FP As String) As Integer

'擦卡操作88888888888
Declare Function Write_BackCard Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_Cardnum As String) As Integer
'验证密码
Declare Function CheckCard_Pass Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_Cardnum As String) As Integer

'初始化卡888888888888
Declare Function Write_CardInit Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_Pass As String) As Integer
'读取工具卡88888888888888
Declare Function Read_Tool Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, D_Num As Double, ByVal Int_Offset1 As Integer, Str_QYID As String) As Integer

'回读用户卡888888888888888888888888
Declare Function Read_BackNum Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, D_SYNum As Double, D_LJNum As Double) As Integer
Declare Function Read_BackNum_01 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, D_SYNum As Double, D_LJNum As Double) As Integer

Declare Function Ver_Number Lib "Srq_01.dll" (Str_Ver As String) As Integer


'Declare Function Write_CardBuy1 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal R_BuyNum As Double, ByVal Str_QYID As String, ByVal Int_WriteFlag As Long, ByVal Int_WCount As Long, ByVal Int_BCount As Long, ByVal Int_BZHI As Long) As Integer

''读取硬盘号
'Declare Function Ver_HDS Lib "Srq_01.dll" (Str_HDS As String) As Integer
''得到源码天数
'Declare Function Des_ReadSource Lib "Srq_01.dll" (ByVal Str_Dest1 As String, ByVal Str_HDS1 As String, Str_Number1 As String) As Integer
'
'Declare Function Des_Source Lib "Srq_01.dll" (ByVal Str_Number1 As String, ByVal Str_HDS1 As String, Str_Dest1 As String) As Integer





Function IcErrMsg(ByVal intErrCode As Integer) As String
Dim Str_Err As String
Select Case intErrCode
        Case -1
           Str_Err = "打开串口错误"
        Case -2
           Str_Err = "关闭串口错误"
        Case -10
           Str_Err = "请插入IC卡"
        Case -3
           Str_Err = "非本系统卡或是卡插反"
        Case -4
           Str_Err = "读卡错误"
        Case -5
           Str_Err = "写卡错误"
        Case -8
           Str_Err = "核对密码错误"
        Case -9
           Str_Err = "转换密码错误"
        Case -6
          Str_Err = "数据转换错误"
        Case -11
          Str_Err = "数据超限"
        Case -13
          Str_Err = "卡已经损坏"
       
        Case -100
          Str_Err = "未知错误"
         Case -101
          Str_Err = "操作无效！请重新操作"
End Select
IcErrMsg = Str_Err



End Function
Function str_CardType(ByVal Int_CardType As Integer) As String
Select Case Int_CardType
       Case 0
         str_CardType = "空白卡"
       Case 10
         str_CardType = "用户卡(家用表)"
       Case 90
         str_CardType = "用户卡(工业表)"
       Case 20
         str_CardType = "清零卡"
         Case 30
         str_CardType = "工程卡"
        Case 31
        str_CardType = "工程卡(有数)"
         Case 32
        str_CardType = "工业表工程卡(有数)"
        Case 41
        str_CardType = "多次卡"
        Case 40
        str_CardType = "设定卡"
        Case 50
        str_CardType = "限时卡"
         Case 51
        str_CardType = "报警量设置卡"
        Case 70
        str_CardType = "非本系统卡"
    End Select
End Function
