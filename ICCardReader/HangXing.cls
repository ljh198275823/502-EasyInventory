VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "HangXing"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Dim Int_Type As Integer
Dim Str_Commport As String
Dim Card_Type As Integer
Private Ht As Integer
Private Str_QuID As String  '区域代码
Private m_Port As Integer
'***********************    operate sle 4442    **************************TestIc_Type
'Declare Function TEST_COM Lib "Saron_Rq.dll" (ByVal icdev As Long) As Integer

'读取卡片类型
Private Declare Function Read_CardType Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Int_CardType As Long) As Integer
'读取卡片信息
Private Declare Function Read_UserCard Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Str_Cardnum As String, str_CityCode As String, Str_type As String) As Integer
'写入卡片信息
Private Declare Function Write_UserCard Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_Cardnum As String, ByVal str_CityCode As String, ByVal Str_type As String) As Integer
'读取8888
Private Declare Function Read_CardBuy Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Str_Flag As String, R_BuyNum As Double, Int_Count As Long, Str_QYID As String) As Integer
Private Declare Function Read_CardBuy_01 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Str_Flag As String, R_BuyNum As Double, Int_Count As Long, Str_QYID As String) As Integer

 
     
Private Declare Function Write_CardBuy Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal R_BuyNum As Double, ByVal Str_QYID As String, ByVal Int_WriteFlag As Long) As Integer
Private Declare Function Write_CardBuy_01 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal R_BuyNum As Double, ByVal Str_QYID As String, ByVal Int_WriteFlag As Long) As Integer

' 测卡88888888888

'Read_CardType(Str_Com:Pchar;Int_Beep:integer;var Int_CardType:integer):smallint;stdcall;

' 写工具卡   20 清零卡  30 工程卡88888888
Private Declare Function Write_Tools Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Int_CardType As Integer, ByVal Str_CityNum As String, ByVal Str_QYID As String, ByVal Int_Offset1 As Integer) As Integer

' 写工具卡   40 为设定卡  50 限时卡8888888888
Private Declare Function Write_Tools1 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Int_CardType As Integer, ByVal D_Num As Double, ByVal Str_QYID As String, ByVal Int_Offset1 As Integer) As Integer
'写发票号

Private Declare Function Write_FPID Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_FP As String) As Integer

'读发票号Write_BackCard

Private Declare Function Read_FPID Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, Str_FP As String) As Integer

'擦卡操作88888888888
Private Declare Function Write_BackCard Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_Cardnum As String) As Integer
'验证密码
Private Declare Function CheckCard_Pass Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_Cardnum As String) As Integer

'初始化卡888888888888
Private Declare Function Write_CardInit Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, ByVal Str_Pass As String) As Integer
'读取工具卡88888888888888
Private Declare Function Read_Tool Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, D_Num As Double, ByVal Int_Offset1 As Integer, Str_QYID As String) As Integer

'回读用户卡888888888888888888888888
Private Declare Function Read_BackNum Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, D_SYNum As Double, D_LJNum As Double) As Integer
Private Declare Function Read_BackNum_01 Lib "Srq_01.dll" (ByVal Str_Com As String, ByVal Int_Beep As Integer, D_SYNum As Double, D_LJNum As Double) As Integer

Private Declare Function Ver_Number Lib "Srq_01.dll" (Str_Ver As String) As Integer

Private Function IcErrMsg(ByVal intErrCode As Integer) As String
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

Private Function str_CardType(ByVal Int_CardType As Integer) As String
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
'---------------------------------------end----------------------------------------------------------------

Private Sub Class_Initialize()
    Int_Type = 0
    Str_QuID = "00000001" '设定区域代码
    Str_Commport = "COM" & My_Commport
End Sub


Public Sub Back()  '退气
    If Card_Type = 10 Then
        Ht = Write_CardBuy(Str_Commport, 1, 0, Str_QuID, 4)
    Else
        Ht = Write_CardBuy(Str_Commport, 1, 0, Str_QuID, 4)
    End If
    If Ht < 0 Then
      MsgBox IcErrMsg(Ht)
      Exit Sub
    End If
    FrmCardReader.cmdBuy.Enabled = False
    FrmCardReader.cmdBuqi.Enabled = False
    FrmCardReader.CmdBack.Enabled = False
End Sub

Public Sub Buqi()  '补气
    If Card_Type = 10 Then
        Ht = Write_CardBuy(Str_Commport, 1, Val(txtAmount.Text), Str_QuID, 3)
    Else
        Ht = Write_CardBuy(Str_Commport, 1, Val(txtAmount.Text), Str_QuID, 3)
    End If
    If Ht < 0 Then
      MsgBox IcErrMsg(Ht)
      Exit Sub
    End If
    FrmCardReader.cmdBuy.Enabled = False
    FrmCardReader.cmdBuqi.Enabled = False
    FrmCardReader.CmdBack.Enabled = False
End Sub

Public Sub Buy()  '购气
    If Card_Type = 10 Then
        Ht = Write_CardBuy(Str_Commport, 0, Val(FrmCardReader.txtAmount.Text), Str_QuID, 2)
    Else
        Ht = Write_CardBuy_01(Str_Commport, 0, Val(FrmCardReader.txtAmount.Text), Str_QuID, 2)
    End If
    If Ht < 0 Then
      MsgBox IcErrMsg(Ht)
      Exit Sub
    End If
    st = Write_FPID(Str_Commport, 1, Trim(FrmCardReader.txtFPID.Text))
    If st < 0 Then
      MsgBox IcErrMsg(st), vbExclamation, Title
      Exit Sub
    End If
    FrmCardReader.cmdBuy.Enabled = False
    FrmCardReader.cmdBuqi.Enabled = False
    FrmCardReader.CmdBack.Enabled = False
End Sub


Private Function CheckForMake() As Boolean
    If Len(FrmCardReader.txtCardID.Text) <> 6 Then
        MsgBox "卡号不正确，应该为6位数字"
        CheckForMake = False
        Exit Function
    End If
    If Not IsNumeric(FrmCardReader.txtCardID.Text) Then
        MsgBox "卡号不能包函非数字"
        CheckForMake = False
        Exit Function
    End If
    If FrmCardReader.rdHome.value = False And FrmCardReader.rdIndustry.value = False Then
        MsgBox "请选择一种卡片类型"
        Exit Function
    End If
    CheckForMake = True
End Function

Public Sub MakeCard()  '发卡
    Dim str_CardType  As String
    Dim str_CityCode As String
    
    If CheckForMake() Then
        str_CityCode = "0001"
        str_CardType = IIf(FrmCardReader.rdHome.value, "0001", "0002")
        Ht = Write_UserCard(Str_Commport, 0, Trim(FrmCardReader.txtCardID.Text), str_CityCode, str_CardType)
        If Ht < 0 Then
          MsgBox IcErrMsg(Ht)
          Exit Sub
        End If
        If FrmCardReader.rdHome.value Then
            Ht = Write_CardBuy(Str_Commport, 1, 0, Str_QuID, 1)
        Else
            Ht = Write_CardBuy_01(Str_Commport, 1, 0, Str_QuID, 1)
        End If
        If st < 0 Then
          MsgBox IcErrMsg(st), vbExclamation, Title
          Exit Sub
        End If
        MsgBox "发卡成功"
    End If
End Sub

Public Sub RemakeCard() '补卡
    Dim str_CardType  As String
    Dim str_CityCode As String
    
    If CheckForMake() Then
    str_CityCode = "0001"
        str_CardType = IIf(FrmCardReader.rdHome.value, "0001", "0002")
        Ht = Write_UserCard(Str_Commport, 0, Trim(FrmCardReader.txtCardID.Text), str_CityCode, str_CardType)
        If Ht < 0 Then
          MsgBox IcErrMsg(Ht)
          Exit Sub
        End If
        If FrmCardReader.rdHome.value Then
            Ht = Write_CardBuy(Str_Commport, 1, 0, Str_QuID, 3)
        Else
            Ht = Write_CardBuy_01(Str_Commport, 1, 0, Str_QuID, 3)
        End If
        If st < 0 Then
          MsgBox IcErrMsg(st), vbExclamation, Title
          Exit Sub
        End If
        MsgBox "补卡成功"
    End If
End Sub

Public Sub ClearCard() '清除卡片
    Dim msg As Integer
    Dim Int_type1 As Integer
    Dim FInt_CardType As Long
    Dim Str_CardNum1 As String
    Dim Fstr_UserID As String
    Dim FStr_CityNum As String
    Dim Str_type1 As String
    Fstr_UserID = Space(6)
    FStr_CityNum = Space(4)
    Str_type1 = Space(4)
       
    st = Read_CardType(Str_Commport, 0, FInt_CardType)
    If (st < 0) And (st <> -14) Then
        MsgBox IcErrMsg(st), vbExclamation, Title
        Exit Sub
     End If
      
    Select Case FInt_CardType
        Case 10, 90 ' 用户卡
            Card_Type = FInt_CardType
            st = Read_UserCard(Str_Commport, 0, Fstr_UserID, FStr_CityNum, Str_type1)
            Str_CardNum1 = Fstr_UserID
            msg = MsgBox(str_CardType(FInt_CardType) & "要擦除吗？", vbOKCancel + vbQuestion + vbDefaultButton2, "擦除提示：")
            If msg = vbOK Then
                st = Write_BackCard(Str_Commport, 1, Str_CardNum1)
                If st < 0 Then
                    MsgBox IcErrMsg(st), vbExclamation, Title
                    Exit Sub
                End If
                MsgBox "擦卡成功！", vbInformation, Title
             End If
        Case 20, 30, 31, 40, 41, 50, 32, 51 '清零卡
            Str_CardNum1 = "000000"
            msg = MsgBox(str_CardType(FInt_CardType) & "要擦除吗？", vbOKCancel + vbQuestion + vbDefaultButton2, "擦除提示：")
            If msg = vbOK Then
                st = Write_BackCard(Str_Commport, 1, Str_CardNum1)
                If st < 0 Then
                    MsgBox IcErrMsg(st), vbExclamation, Title
                    Exit Sub
                End If
                MsgBox "擦卡成功！", vbInformation, Title
             End If
        Case 0
           MsgBox "此卡已为空白卡！", vbInformation, Title
        Case 70
           MsgBox str_CardType(FInt_CardType) & "，不能擦除！", vbInformation, Title
    End Select
End Sub

Public Sub Read() '读卡
    Dim Int_CardType As Long
    Dim Fstr_UserID As String
    Dim FStr_CityNum As String
    Dim Str_type  As String
    Dim Str_Flag As String
    Dim Int_Count As Long
    Dim FR_BuyNum As Double
    Dim Str_QYID As String
    Dim fstr_FP As String
    Dim D_SYNum1 As Double
    Dim D_LJNum1 As Double
    Dim D_Temp As Double
    
    Str_type = Space(4)
    Fstr_UserID = Space(6)
    FStr_CityNum = Space(4)
    Str_Flag = Space(2)
    Str_QYID = Space(8)
    fstr_FP = Space(10)
    
    FrmCardReader.cmdBuy.Enabled = False
    st = Read_CardType(Str_Commport, 0, Int_CardType)
    If st < 0 Then GoTo ReadFail
    Call CheckReadCount
    Call IncreaseReadCount
    FrmCardReader.List1.Clear
    FrmCardReader.List1.AddItem "卡的类型：" & str_CardType(Int_CardType)
    Select Case Int_CardType
        Case 10, 90
            st = Read_UserCard(Str_Commport, 0, Fstr_UserID, FStr_CityNum, Str_type)
            If st < 0 Then GoTo ReadFail
            FrmCardReader.List1.AddItem "卡号：" & Fstr_UserID
            FrmCardReader.txtCardID1.Text = Fstr_UserID
            If Int_CardType = 10 Then
                st = Read_CardBuy(Str_Commport, 0, Str_Flag, FR_BuyNum, Int_Count, Str_QYID)
            Else
                st = Read_CardBuy_01(Str_Commport, 0, Str_Flag, FR_BuyNum, Int_Count, Str_QYID)
            End If
            If st < 0 Then GoTo ReadFail
            FrmCardReader.txtAmount.Text = FR_BuyNum
            FrmCardReader.txtCount.Text = Int_Count
            st = Read_FPID(Str_Commport, 0, fstr_FP) '发票号
            If st < 0 Then GoTo ReadFail
            FrmCardReader.txtFPID.Text = Format(Val(fstr_FP) + 1, "0000000000")
            If Int_CardType = 10 Then
                st = Read_BackNum(Str_Commport, 0, D_SYNum1, D_LJNum1)
            Else
                st = Read_BackNum_01(Str_Commport, 0, D_SYNum1, D_LJNum1)
            End If
            st = Read_BackNum(Str_Commport, 0, D_SYNum1, D_LJNum1)
            If st < 0 Then GoTo ReadFail
            If Str_Flag = 11 Then
              FrmCardReader.List1.AddItem "卡的状态：新卡(未用)"
              FrmCardReader.List1.AddItem "购买量(立方米)：" & Format(FR_BuyNum, "##0.00")
            ElseIf Str_Flag = 12 Then
              FrmCardReader.List1.AddItem "卡的状态：旧卡(已用)"
              FrmCardReader.List1.AddItem "上次购买量(立方米)：" & Format(FR_BuyNum, "##0.00")
              FrmCardReader.List1.AddItem "剩余量(立方米)：" & Format(D_SYNum1, "##0.00")
              FrmCardReader.List1.AddItem "累计用量(立方米)：" & Format(D_LJNum1, "##0.00")
              FrmCardReader.cmdBuy.Enabled = True
            ElseIf Str_Flag = 13 Then
              FrmCardReader.List1.AddItem "卡的状态：开户卡"
              FrmCardReader.cmdBuy.Enabled = True
            ElseIf Str_Flag = 14 Then
              FrmCardReader.List1.AddItem "卡的状态：补卡"
              FrmCardReader.cmdBuy.Enabled = True
            End If
            FrmCardReader.cmdBuqi.Enabled = True
            FrmCardReader.CmdBack.Enabled = True
        Case 31
          st = Read_Tool(Str_Commport, 1, FR_BuyNum, 48, Str_QYID)
          If st < 0 Then GoTo ReadFail
          FrmCardReader.List1.AddItem "要转的数据(家用表)：" & Format(FR_BuyNum, "##0.00")
        Case 40
          st = Read_Tool(Str_Commport, 1, FR_BuyNum, 48, Str_QYID)
          If st < 0 Then GoTo ReadFail
          FrmCardReader.List1.AddItem "累计量：" & Format(FR_BuyNum, "##0.00")
        Case 50
          st = Read_Tool(Str_Commport, 1, FR_BuyNum, 48, Str_QYID)
          If st < 0 Then GoTo ReadFail
          FrmCardReader.List1.AddItem "限时天数(天)：" & FR_BuyNum
        Case 41
          st = Read_Tool(Str_Commport, 1, FR_BuyNum, 48, Str_QYID)
          If st < 0 Then GoTo ReadFail
          FrmCardReader.List1.AddItem "数据量：" & Format(FR_BuyNum, "0.00")
        Case 51
          st = Read_Tool(Str_Commport, 1, FR_BuyNum, 48, Str_QYID)
          If st < 0 Then GoTo ReadFail
          FrmCardReader.List1.AddItem "数据量：" & Format(FR_BuyNum, "0.00")
    End Select
    Exit Sub
ReadFail:
    MsgBox IcErrMsg(st), vbExclamation, Title
    Exit Sub
End Sub

Public Sub MakeTool()
    Dim Str_City As String
    Dim Int_Offset As Integer
    Dim D_Temp As Double
    Str_City = "1234"
    Int_Offset = 48 '家用表48 工业表80
    If FrmCardReader.Option1(0).value Then  '清零
      Ht = Write_Tools(Str_Commport, 1, 20, Str_City, Str_QuID, Int_Offset)
    ElseIf FrmCardReader.Option1(1) Then '工程卡
      Ht = Write_Tools(Str_Commport, 1, 30, Str_City, Str_QuID, Int_Offset)
    ElseIf FrmCardReader.Option1(2) Then  '一方卡
      D_Temp = 1
      Ht = Write_Tools1(Str_Commport, 1, 41, D_Temp, Str_QuID, Int_Offset)
    ElseIf FrmCardReader.Option1(3) Then  '限时卡
      Ht = Write_Tools1(Str_Commport, 1, 50, Val(FrmCardReader.Text11.Text), Str_QuID, Int_Offset)
    ElseIf FrmCardReader.Option1(4) Then '设定累积量
      Ht = Write_Tools1(Str_Commport, 1, 40, Val(FrmCardReader.Text12.Text), Str_QuID, Int_Offset)
    ElseIf FrmCardReader.Option1(5) Then  '报警量设置卡
      Ht = Write_Tools1(Str_Commport, 1, 51, Val(FrmCardReader.Text4.Text), Str_QuID, Int_Offset)
    End If
    If Ht < 0 Then
      MsgBox IcErrMsg(Ht)
    Else
      MsgBox "制作工具卡成功"
    End If
End Sub




