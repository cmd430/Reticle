Imports System.Runtime.InteropServices

Public Class Reticle

    Public Settings = Application.StartupPath & "\Data\Config.ini"

    Public HotMouse_Enabled As Boolean = False
    Public HotMouse = ""
    Public HotMouse_isToggle As Boolean = False

    Public HotKey_Enabled As Boolean = False
    Public HotKey = ""
    Public HotKey_isToggle As Boolean = False

    Public isShown = True
    Public config_isShown As Boolean = False

    Private Const GWL_EXSTYLE As Integer = -20
    Private Const WS_EX_TOOLWINDOW As Integer = &H80
    Private Const WS_EX_APPWINDOW As Integer = &H40000
    Private Const WS_EX_TRANSPARENT As Integer = &H20
    Private Const SWP_NOACTIVATE As UInteger = &H10
    Private Const SWP_NOMOVE As UInteger = &H2
    Private Const SWP_NOSIZE As UInteger = &H1

    Private WithEvents kbHook As New KeyboardHook
    Private WithEvents mHook As New MouseHook

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> Public Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto)> Public Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dsNewLong As Integer) As Integer
    End Function

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        If ReadINI(Settings, "Hotkey-Settings", "enabled", "") Then
            HotKey_Enabled = True
            HotKey = ReadINI(Settings, "Hotkey-Settings", "hotkey", "")
            HotKey_isToggle = ReadINI(Settings, "Hotkey-Settings", "isToggle", False)
        End If
        If ReadINI(Settings, "Hotmouse-Settings", "enabled", "") Then
            HotMouse_Enabled = True
            HotMouse = ReadINI(Settings, "Hotmouse-Settings", "Hotmouse", "")
            HotMouse_isToggle = ReadINI(Settings, "Hotmouse-Settings", "isToggle", False)
        End If
        SetWindowLong(Me.Handle, GWL_EXSTYLE, (GetWindowLong(Me.Handle, GWL_EXSTYLE) Or WS_EX_TOOLWINDOW Or WS_EX_TRANSPARENT) And Not WS_EX_APPWINDOW)
    End Sub

#Region "Mouse and Keyboard Event Handlers"

    Public Function formatHotkey(ByVal Key As System.Windows.Forms.Keys)
        Dim pressedKeys As String = ""
        Dim modifiers As String = Control.ModifierKeys.ToString()
        modifiers = modifiers.Replace("Control", "Ctrl")
        modifiers = modifiers.Replace(", ", "+")
        Dim _key = Key.ToString()
        _key = _key.Replace("RShiftKey", "")
        _key = _key.Replace("LShiftKey", "")
        _key = _key.Replace("ShiftKey", "")
        _key = _key.Replace("RMenu", "")
        _key = _key.Replace("LMenu", "")
        _key = _key.Replace("Menu", "")
        _key = _key.Replace("RControlKey", "")
        _key = _key.Replace("LControlKey", "")
        _key = _key.Replace("ControlKey", "")
        _key = _key.Replace("Escape", "")
        _key = _key.Replace("Return", "Enter")
        _key = _key.Replace("NumPad", "")
        If _key.Length > 1 Then
            If Not Char.IsLetter(_key.Chars(1)) Then
                _key = _key.Replace("D", "")
            End If
        End If
        _key = _key.Replace("Oemtilde", "~")
        _key = _key.Replace("Oemplus", "+")
        _key = _key.Replace("OemMinus", "-")
        _key = _key.Replace("OemOpenBrackets", "[")
        _key = _key.Replace("Oem6", "]")
        _key = _key.Replace("Oem5", "\")
        _key = _key.Replace("Oem1", ";")
        _key = _key.Replace("Oem7", "'")
        _key = _key.Replace("Oemcomma", ",")
        _key = _key.Replace("OemPeriod", ".")
        _key = _key.Replace("OemQuestion", "?")
        _key = _key.Replace("Divide", "/")
        _key = _key.Replace("Multiply", "*")
        _key = _key.Replace("Minus", "-")
        _key = _key.Replace("Add", "+")
        _key = _key.Replace("Period", "")
        If modifiers = "None" Then
            pressedKeys = _key
        Else
            pressedKeys = modifiers & "+" & _key
        End If
        Return pressedKeys
    End Function

    Private Sub kbHook_KeyDown(ByVal Key As System.Windows.Forms.Keys) Handles kbHook.KeyDown
        If HotKey_Enabled Then
            Dim pressedKeys As String = formatHotkey(Key)
            If Not pressedKeys = "" And Not pressedKeys.EndsWith("+") Then
                If pressedKeys = HotKey Then
                    If HotKey_isToggle Then
                        If Not isShown Then
                            Handle_Hokey_Hotmouse()
                        End If
                    Else
                        Handle_Hokey_Hotmouse()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub kbHook_KeyUp(ByVal Key As System.Windows.Forms.Keys) Handles kbHook.KeyUp
        If HotKey_Enabled Then
            Dim pressedKeys As String = formatHotkey(Key)
            If Not pressedKeys = "" And Not pressedKeys.EndsWith("+") Then
                If pressedKeys = HotKey Then
                    If Not HotKey_isToggle Then
                        Handle_Hokey_Hotmouse()
                    End If
                End If
            End If
        End If
    End Sub


    Private Sub mHook_Mouse_Left_Down(ByVal ptLocat As System.Drawing.Point) Handles mHook.Mouse_Left_Down
        If HotMouse_Enabled Then
            If HotMouse = "Left Click" Then
                If HotMouse_isToggle Then
                    If Not isShown Then
                        Handle_Hokey_Hotmouse()
                    End If
                Else
                    Handle_Hokey_Hotmouse()
                End If
            End If
        End If
    End Sub
    Private Sub mHook_Mouse_Left_Up(ByVal ptLocat As System.Drawing.Point) Handles mHook.Mouse_Left_Up
        If HotMouse_Enabled Then
            If HotMouse = "Left Click" Then
                If Not HotMouse_isToggle Then
                    Handle_Hokey_Hotmouse()
                End If
            End If
        End If
    End Sub

    Private Sub mHook_Mouse_Middle_Down(ByVal ptLocat As System.Drawing.Point) Handles mHook.Mouse_Middle_Down
        If HotMouse_Enabled Then
            If HotMouse = "Middle Click" Then
                If HotMouse_isToggle Then
                    If Not isShown Then
                        Handle_Hokey_Hotmouse()
                    End If
                Else
                    Handle_Hokey_Hotmouse()
                End If
            End If
        End If
    End Sub
    Private Sub mHook_Mouse_Middle_Up(ByVal ptLocat As System.Drawing.Point) Handles mHook.Mouse_Middle_Up
        If HotMouse_Enabled Then
            If HotMouse = "Middle Click" Then
                If Not HotMouse_isToggle Then
                    Handle_Hokey_Hotmouse()
                End If
            End If
        End If
    End Sub

    Private Sub mHook_Mouse_Right_Down(ByVal ptLocat As System.Drawing.Point) Handles mHook.Mouse_Right_Down
        If HotMouse_Enabled Then
            If HotMouse = "Right Click" Then
                If HotMouse_isToggle Then
                    If Not isShown Then
                        Handle_Hokey_Hotmouse()
                    End If
                Else
                    Handle_Hokey_Hotmouse()
                End If
            End If
        End If
    End Sub
    Private Sub mHook_Mouse_Right_Up(ByVal ptLocat As System.Drawing.Point) Handles mHook.Mouse_Right_Up
        If HotMouse_Enabled Then
            If HotMouse = "Right Click" Then
                If Not HotMouse_isToggle Then
                    Handle_Hokey_Hotmouse()
                End If
            End If
        End If
    End Sub

    Public Sub Handle_Hokey_Hotmouse()
        If Not config_isShown Then
            If isShown = True Then
                Me.Opacity = 0
                isShown = False
            Else
                Me.Opacity = CType(ReadINI(Settings, "Reticle-Settings", "opacity", ""), Double)
                isShown = True
            End If
        End If
    End Sub

#End Region

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Width = ((My.Computer.Screen.Bounds.Width / 2) - (Me.Width / 2))
        Dim Height = ((My.Computer.Screen.Bounds.Height / 2) - (Me.Height / 2))
        Me.Location = New Point(Width, Height)
        Me.BackgroundImage = Image.FromFile(ReadINI(Settings, "Settings", "reticle-dir", "") & "\" & ReadINI(Settings, "Reticle-Settings", "reticle", ""))
        Me.BackColor = Color.FromArgb(255, CType(ReadINI(Settings, "Reticle-Settings", "red", ""), Integer), CType(ReadINI(Settings, "Reticle-Settings", "green", ""), Integer), CType(ReadINI(Settings, "Reticle-Settings", "blue", ""), Integer))
        If ReadINI(Settings, "Settings", "start-hidden", False) Then
            Me.Opacity = 0.00
            isShown = False
        Else
            Me.Opacity = CType(ReadINI(Settings, "Reticle-Settings", "opacity", ""), Double)
        End If
    End Sub

    Private Sub TrayMenuExit_Click(sender As Object, e As EventArgs) Handles TrayMenuExit.Click
        Application.Exit()
    End Sub

    Private Sub TrayMenuConfigure_Click(sender As Object, e As EventArgs) Handles TrayMenuConfigure.Click
        Config.Dispose()
        config_isShown = True
        Config.ShowDialog()
        Application.Restart()
    End Sub

    Private Sub InvertVisibilityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InvertVisibilityToolStripMenuItem.Click
        Handle_Hokey_Hotmouse()
    End Sub

End Class
