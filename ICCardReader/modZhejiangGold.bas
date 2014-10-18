Attribute VB_Name = "modZhejiangGold"
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
Public Declare Function Gold_Readcard Lib "goldcard" (ByVal intcom As Integer, ByVal Baud As Long, ByRef userNo As String, ByRef vlql As Long, ByRef vics As Integer, ByRef viklx As Integer) As Long

'购气
Public Declare Function Gold_Buycard Lib "goldcard" (ByVal intcom As Integer, ByVal Baud As Long, ByVal userNo As String, ByVal vlql As Long, ByVal vics As Long) As Long

'清除卡内气量
Public Declare Function Gold_Clearcard Lib "goldcard" (ByVal intcom As Integer, ByVal Baud As Long, ByVal userNo As String) As Long

'返回错误信息字符串
Public Declare Sub Error_message Lib "goldcard" (ByVal errCode As Long, ByVal msg As String)

'检查是否是本公司的卡 返回值 0：用户卡；1：工具卡；其它出错。
Public Declare Function Gold_CheckCard Lib "goldcard" (ByVal intcom As Integer, ByVal Baud As Long, ByRef error As String) As Long

'注意事项
'1、 购气次数一定要正确，购气次数只能比上次购气次数大，否则表会不认卡。
'2、 购气写卡时，如果卡内还有气量，DLL会把卡内的气量替换了，并不会相加。



