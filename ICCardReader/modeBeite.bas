Attribute VB_Name = "modeBeite"

'用户卡个人化函数
'1.只有处于初始状态的卡片才能进行卡片的个人化操作
'2.完成个人化操作后的用户卡卡上预购气量为零
Public Declare Function Personalize Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByVal AlarmValue As Integer, ByVal InputValue As Integer, ByVal OverLimit As Long, ByVal Control As Long, ByRef pErrMsg As String) As Long

'用户卡充值函数  每进行一次用户卡购气交易，卡上交易序号加1
Public Declare Function Credit Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByVal ChargeSerialNum As Long, ByVal purchaeAmount As Long, ByRef pErrMsg As String) As Long

'用户卡增款函数  完成操作后，原卡上交易序号保持不变
Public Declare Function Increase Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByRef Buygas As Long, ByVal PurchaseAmount As Long, ByRef pErrMsg As String) As Long

'退气 完成退购交易后，原卡上交易序号保持不变
Public Declare Function Decrease Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, _
    ByVal userNo As String, ByRef Buygas As Long, ByVal PurchaseAmount As Long, ByRef pErrMsg As String) As Long

'读用户卡购气区数据
Public Declare Function rUserData Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByRef userNo As String, _
ByRef ChargeSerialNum As Long, ByRef PurchaseAmount As Long, ByRef AlarmValue As Long, ByRef InputValue As Long, _
ByRef OverLimit As Long, ByRef Control As Long, ByRef pErrMsg As String) As Long

'读用户卡返回写区数据
Public Declare Function rUserDataR Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByRef RStartcode As String, _
ByRef meterNo As String, ByRef TotalBuyGas As Long, ByRef TotalBuyNum As Long, ByRef residualGas As Long, _
ByRef TotalTakeGas As Single, ByRef ChangePassNum As Long, ByRef FMState As Long, ByRef ESAMState As Long, _
ByRef DCState As Long, ByRef CGRState As Long, ByRef Magnet As Long, ByRef Low As Long, ByRef MonthUserGas As String, _
ByRef RDate As String, ByRef pErrMsg As String) As Long

'补卡
Public Declare Function ReissueCard Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByVal AlarmValue As Integer, ByVal InputValue As Integer, ByVal OverLimit As Long, ByVal Control As Long, ByRef pErrMsg As String) As Long

'创建一张换表卡
Public Declare Function ChangeMeter Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, _
ByVal AlarmValue As Integer, ByVal InputValue As Integer, ByVal OverLimit As Long, ByVal buy As Long, _
ByVal TotalBuyGas As Long, ByVal TotalBuyNum As Long, ByVal residualGas As Long, ByVal TotalTakeGas As Single, ByVal Control As Long, _
ByRef pErrMsg As String) As Long

'清空卡
'Public Declare Function ClearCard Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByRef pErrMsg As String) As Long

'制作初使化卡
Public Declare Function MakeIniCard Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal upfrontGas As Long, ByVal AlarmValue As Long, _
ByVal OverLimit As Long, ByVal Control As Long, ByRef pErrMsg As String) As Long

'设置用户卡参数
Public Declare Function SetUserParameter Lib "PC001" (ByVal port As Integer, ByVal Baud As Long, ByVal userNo As String, ByVal AlarmValue As Long, _
ByVal OverLimit As Long, ByVal Control As Long, ByRef pErrMsg As String) As Long




