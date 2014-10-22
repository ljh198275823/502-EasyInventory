Attribute VB_Name = "Module1"

Public My_Commport As Integer
Public ReadCount As Integer

Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Long, ByVal lpFileName As String) As Long
Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpString As Any, ByVal lpFileName As String) As Long

'以下两个函数,读/写ini文件,不固定节点,in_key为写入/读取的主键
'针对字符串值
'空值表示出错
Public Function GetIniStr(ByVal AppName As String, ByVal In_Key As String) As String
    Dim GetStr As String * 5000
On Error GoTo GetIniStrErr
    If Trim(In_Key) = "" Or Trim(AppName) = "" Then
        GoTo GetIniStrErr
    End If
    GetPrivateProfileString AppName, In_Key, "", GetStr, Len(GetStr), App.Path & "\ICReader.ini"
    GetStr = Replace(Trim(GetStr), Chr(0), "")
    GetIniStr = Trim(GetStr)
    Exit Function
GetIniStrErr:
    err.Clear
    GetIniStr = ""
    GetStr = ""
End Function

Public Sub IncreaseReadCount()
    ReadCount = ReadCount + 1
End Sub

Public Sub CheckReadCount()
    If ReadCount > 10 Then
        MsgBox "试用版读卡次数为10次，软件自动关闭"
        End
    End If
End Sub


Public Function WriteIniStr(ByVal AppName As String, ByVal In_Key As String, ByVal In_Data As String) As Boolean
On Error GoTo WriteIniStrErr
    If VBA.Trim(In_Key) = "" Or VBA.Trim(AppName) = "" Then
        GoTo WriteIniStrErr
    Else
        WritePrivateProfileString AppName, In_Key, In_Data, App.Path & "\ICReader.ini"
        WriteIniStr = True
    End If
    Exit Function
WriteIniStrErr:
    err.Clear
    WriteIniStr = False
End Function

Public Sub WriteLog(ByVal strMsg As String, Optional methodName As String)
    On Error Resume Next
    Open App.Path & "\Log.txt" For Append As #1
        Print #1, strMsg & "  at " & methodName & "  " & Now
    Close #1

    If FileLen(App.Path & "\Log.txt") > 50000 Then
            Kill App.Path & "\Log.txt"
    End If
End Sub

