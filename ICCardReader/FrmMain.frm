VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.MDIForm FrmMain 
   BackColor       =   &H8000000C&
   Caption         =   "È¼Æø¿¨¹ÜÀí"
   ClientHeight    =   6960
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   11775
   LinkTopic       =   "MDIForm1"
   StartUpPosition =   3  'Windows Default
   Begin MSComctlLib.StatusBar StatusBar1 
      Align           =   2  'Align Bottom
      Height          =   375
      Left            =   0
      TabIndex        =   2
      Top             =   6585
      Width           =   11775
      _ExtentX        =   20770
      _ExtentY        =   661
      _Version        =   393216
      BeginProperty Panels {8E3867A5-8586-11D1-B16A-00C0F0283628} 
         NumPanels       =   1
         BeginProperty Panel1 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
         EndProperty
      EndProperty
   End
   Begin VB.PictureBox Picture1 
      Align           =   1  'Align Top
      AutoSize        =   -1  'True
      BorderStyle     =   0  'None
      Height          =   5880
      Left            =   0
      ScaleHeight     =   5880
      ScaleWidth      =   11775
      TabIndex        =   1
      Top             =   615
      Width           =   11775
   End
   Begin MSComctlLib.Toolbar Toolbar1 
      Align           =   1  'Align Top
      Height          =   615
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   11775
      _ExtentX        =   20770
      _ExtentY        =   1085
      ButtonWidth     =   1455
      ButtonHeight    =   926
      Appearance      =   1
      _Version        =   393216
      BeginProperty Buttons {66833FE8-8583-11D1-B16A-00C0F0283628} 
         NumButtons      =   3
         BeginProperty Button1 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "º½ÐÇ¿¨"
         EndProperty
         BeginProperty Button2 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "³ÐµÂ¿¨"
         EndProperty
         BeginProperty Button3 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "Õã½­½ð¿¨"
         EndProperty
      EndProperty
   End
End
Attribute VB_Name = "FrmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False


Private Declare Function SetParent Lib "user32" (ByVal hWndChild As Long, ByVal hWndNewParent As Long) As Long
Dim frmHx As FrmHangXing
Dim frmCd As FrmChengde
Dim frmGold As FrmGoldCard


Private Sub MDIForm_Load()
    My_Commport = 4
End Sub

Private Sub MDIForm_Unload(Cancel As Integer)
    If Not frmHx Is Nothing Then
        Unload frmHx
        Set frmHx = Nothing
    End If
    If Not frmCd Is Nothing Then
        Unload frmCd
        Set frmCd = Nothing
    End If
    If Not frmGold Is Nothing Then
        Unload frmGold
        Set frmGold = Nothing
    End If
End Sub

Private Sub Toolbar1_ButtonClick(ByVal Button As MSComctlLib.Button)
    If Button.Caption = "º½ÐÇ¿¨" Then
        If frmHx Is Nothing Then Set frmHx = New FrmHangXing
        Call SetParent(frmHx.SSTab1.hWnd, Me.Picture1.hWnd)
    ElseIf Button.Caption = "³ÐµÂ¿¨" Then
        If frmCd Is Nothing Then Set frmCd = New FrmChengde
        Call SetParent(frmCd.SSTab1.hWnd, Me.Picture1.hWnd)
    ElseIf Button.Caption = "Õã½­½ð¿¨" Then
        If frmGold Is Nothing Then Set frmGold = New FrmGoldCard
        Call SetParent(frmGold.SSTab1.hWnd, Me.Picture1.hWnd)
    End If
End Sub
