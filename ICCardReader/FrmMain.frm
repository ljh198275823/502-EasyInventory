VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.MDIForm FrmMain 
   BackColor       =   &H8000000C&
   Caption         =   "ȼ��������"
   ClientHeight    =   6960
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   7980
   Icon            =   "FrmMain.frx":0000
   LinkTopic       =   "MDIForm1"
   StartUpPosition =   3  '����ȱʡ
   Begin MSComctlLib.StatusBar StatusBar1 
      Align           =   2  'Align Bottom
      Height          =   375
      Left            =   0
      TabIndex        =   2
      Top             =   6585
      Width           =   7980
      _ExtentX        =   14076
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
      Height          =   6000
      Left            =   0
      ScaleHeight     =   6000
      ScaleWidth      =   7980
      TabIndex        =   1
      Top             =   615
      Width           =   7980
   End
   Begin MSComctlLib.Toolbar Toolbar1 
      Align           =   1  'Align Top
      Height          =   615
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   7980
      _ExtentX        =   14076
      _ExtentY        =   1085
      ButtonWidth     =   1455
      ButtonHeight    =   926
      Appearance      =   1
      _Version        =   393216
      BeginProperty Buttons {66833FE8-8583-11D1-B16A-00C0F0283628} 
         NumButtons      =   9
         BeginProperty Button1 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "���ǿ�"
         EndProperty
         BeginProperty Button2 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "�е¿�"
         EndProperty
         BeginProperty Button3 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "�㽭��"
         EndProperty
         BeginProperty Button4 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Caption         =   "�㽭����"
         EndProperty
         BeginProperty Button5 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "������"
         EndProperty
         BeginProperty Button6 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "��»��"
         EndProperty
         BeginProperty Button7 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Caption         =   "����ʯ"
         EndProperty
         BeginProperty Button8 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "����"
         EndProperty
         BeginProperty Button9 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "�˳�"
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
Dim frmBt As FrmBeite
Dim frmDd As FrmDandong
Dim frmbs As FrmBlue
Dim frmfu As FrmFuluke


Private Sub MDIForm_Load()
    Dim strTemp As String
    strTemp = GetIniStr("Reader", "Commport")
    My_Commport = Val(strTemp)

    Set frmHx = New FrmHangXing
    Set frmCd = New FrmChengde
    Set frmGold = New FrmGoldCard
    Set frmBt = New FrmBeite
    Set frmDd = New FrmDandong
    Set frmbs = New FrmBlue
    Set frmfu = New FrmFuluke
End Sub

Private Sub MDIForm_Unload(Cancel As Integer)
    Unload frmHx
    Unload frmCd
    Unload frmGold
    Unload frmBt
    Unload frmDd
    Unload frmbs
    Unload frmfu
End Sub

Private Sub Toolbar1_ButtonClick(ByVal Button As MSComctlLib.Button)
    Select Case Button.Caption
        Case "���ǿ�"
            frmHx.SSTab1.Tab = 1
            Call SetParent(frmHx.SSTab1.hWnd, Me.Picture1.hWnd)
        Case "�е¿�"
            frmCd.SSTab1.Tab = 1
            Call SetParent(frmCd.SSTab1.hWnd, Me.Picture1.hWnd)
        Case "�㽭��"
            frmGold.SSTab1.Tab = 0
            Call SetParent(frmGold.SSTab1.hWnd, Me.Picture1.hWnd)
        Case "�㽭����"
            frmBt.SSTab1.Tab = 1
            Call SetParent(frmBt.SSTab1.hWnd, Me.Picture1.hWnd)
        Case "������"
            frmDd.SSTab1.Tab = 1
            Call SetParent(frmDd.SSTab1.hWnd, Me.Picture1.hWnd)
        Case "��»��"
            frmfu.SSTab1.Tab = 1
            Call SetParent(frmfu.SSTab1.hWnd, Me.Picture1.hWnd)
        Case "����ʯ"
            frmbs.SSTab1.Tab = 1
            Call SetParent(frmbs.SSTab1.hWnd, Me.Picture1.hWnd)
        Case "����"
            FrmSetting.Show vbModal
        Case "�˳�"
            Unload Me
    End Select
End Sub


