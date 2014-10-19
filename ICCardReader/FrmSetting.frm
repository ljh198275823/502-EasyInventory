VERSION 5.00
Begin VB.Form FrmSetting 
   Caption         =   "设置"
   ClientHeight    =   3195
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   3195
   ScaleWidth      =   4680
   StartUpPosition =   1  'CenterOwner
   Begin VB.ComboBox Combo1 
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   10.5
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   330
      ItemData        =   "FrmSetting.frx":0000
      Left            =   1920
      List            =   "FrmSetting.frx":0002
      Style           =   2  'Dropdown List
      TabIndex        =   2
      Top             =   600
      Width           =   1935
   End
   Begin VB.CommandButton cmdOK 
      Caption         =   "确定(&O)"
      Default         =   -1  'True
      Height          =   375
      Left            =   1440
      TabIndex        =   1
      Top             =   2520
      Width           =   1335
   End
   Begin VB.CommandButton cmdCancel 
      Cancel          =   -1  'True
      Caption         =   "取消(&C)"
      Height          =   375
      Left            =   3000
      TabIndex        =   0
      Top             =   2535
      Width           =   1335
   End
   Begin VB.Label Label5 
      Alignment       =   1  'Right Justify
      Caption         =   "读卡器串口："
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   10.5
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   360
      TabIndex        =   3
      Top             =   638
      Width           =   1455
   End
End
Attribute VB_Name = "FrmSetting"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub cmdCancel_Click()
    Unload Me
End Sub

Private Sub cmdOK_Click()
    Dim commport As Integer
    
    commport = Me.Combo1.ListIndex
    Call WriteIniStr("Reader", "Commport", commport)
    Unload Me
End Sub

Private Sub Form_Load()
    Dim i As Integer
    Dim commport As Integer
    Dim con As Integer
    
    con = 20
    Me.Combo1.AddItem ""
    For i = 1 To con
        Me.Combo1.AddItem ("COM" & i)
    Next
    
    commport = Val(GetIniStr("Reader", "Commport"))
    If commport >= 0 And commport <= con Then
        Me.Combo1.ListIndex = commport
    End If
End Sub
