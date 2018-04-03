Imports System.IO

Public Class Config

    Public Settings = Application.StartupPath & "\Data\Config.ini"

    Private Sub Config_Load(sender As Object, e As EventArgs) Handles MyBase.Load    	
    	Dim ReticleDir As New DirectoryInfo(ReadINI(Settings, "Settings", "reticle-dir", ""))
        Dim ReticleArr As FileInfo() = ReticleDir.GetFiles("*.png")
        Dim ReticleImg As FileInfo
        For Each ReticleImg In ReticleArr
            ComboBox1.Items.Add(Path.GetFileNameWithoutExtension(ReticleImg.Name))
        Next
        Reticle.Location = New Point(Me.Location.X + 20, Me.Location.Y + 42)
        ReticlePreview.BackColor = Color.Yellow
        Red.Value = ReadINI(Settings, "Reticle-Settings", "red", "")
        Green.Value = ReadINI(Settings, "Reticle-Settings", "green", "")
        Blue.Value = ReadINI(Settings, "Reticle-Settings", "blue", "")
        frm_Opacity.Value = ReadINI(Settings, "Reticle-Settings", "opacity", "")
        ComboBox1.SelectedItem = ReadINI(Settings, "Reticle-Settings", "reticle", "").Replace(".png", "")
        CheckBox1.Checked = ReadINI(Settings, "Hotkey-Settings", "enabled", False)
        TextBox1.Text = ReadINI(Settings, "Hotkey-Settings", "hotkey", "")
        CheckBox4.Checked = ReadINI(Settings, "Hotkey-Settings", "isToggle", False)
        CheckBox2.Checked = ReadINI(Settings, "Hotmouse-Settings", "enabled", False)
        TextBox2.Text = ReadINI(Settings, "Hotmouse-Settings", "Hotmouse", "")
        CheckBox3.Checked = ReadINI(Settings, "Hotmouse-Settings", "isToggle", False)
        If CheckBox1.Checked Then
            TextBox1.Enabled = True
        End If
        If CheckBox2.Checked Then
            TextBox2.Enabled = True
        End If
        CheckBox5.Checked = ReadINI(Settings, "Settings", "start-hidden", False)
    End Sub

    Private Sub Form1_Move(sender As Object, e As System.EventArgs) Handles MyBase.Move
        Reticle.Location = New Point(Me.Location.X + 20, Me.Location.Y + 42)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WriteINI(Settings, "Reticle-Settings", "reticle", ComboBox1.SelectedItem & ".png")
        WriteINI(Settings, "Reticle-Settings", "red", Red.Value)
        WriteINI(Settings, "Reticle-Settings", "green", Green.Value)
        WriteINI(Settings, "Reticle-Settings", "blue", Blue.Value)
        WriteINI(Settings, "Reticle-Settings", "opacity", frm_Opacity.Value)
        WriteINI(Settings, "Hotkey-Settings", "enabled", CheckBox1.Checked)
        If CheckBox1.Checked Then
            WriteINI(Settings, "Hotkey-Settings", "hotkey", TextBox1.Text)
        End If
        WriteINI(Settings, "Hotkey-Settings", "isToggle", CheckBox4.Checked)
        WriteINI(Settings, "Hotmouse-Settings", "enabled", CheckBox2.Checked)
        If CheckBox2.Checked Then
            WriteINI(Settings, "Hotmouse-Settings", "hotmouse", TextBox2.Text)
        End If
        WriteINI(Settings, "Hotmouse-Settings", "isToggle", CheckBox3.Checked)
        WriteINI(Settings, "Settings", "start-hidden", CheckBox5.Checked)
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If ColorDialog1.Color = Color.Yellow Then
                MsgBox("That Shade of Yellow is Not Allowed Sorry!")
                Red.Value = 0
                Green.Value = 0
                Blue.Value = 0
            Else
                Red.Value = ColorDialog1.Color.R
                Green.Value = ColorDialog1.Color.G
                Blue.Value = ColorDialog1.Color.B
            End If
            Reticle.BackColor = Color.FromArgb(255, Red.Value, Green.Value, Blue.Value)
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Reticle.BackgroundImage = Image.FromFile(ReadINI(Settings, "Settings", "reticle-dir", "") & "\" & ComboBox1.SelectedItem & ".png")
    End Sub

    Private Sub Blue_ValueChanged(sender As Object, e As EventArgs) Handles Blue.ValueChanged
        Reticle.BackColor = Color.FromArgb(255, Red.Value, Green.Value, Blue.Value)
    End Sub

    Private Sub Green_ValueChanged(sender As Object, e As EventArgs) Handles Green.ValueChanged
        Reticle.BackColor = Color.FromArgb(255, Red.Value, Green.Value, Blue.Value)
    End Sub

    Private Sub Red_ValueChanged(sender As Object, e As EventArgs) Handles Red.ValueChanged
        Reticle.BackColor = Color.FromArgb(255, Red.Value, Green.Value, Blue.Value)
    End Sub

    Private Sub Opacity_ValueChanged(sender As Object, e As EventArgs) Handles frm_Opacity.ValueChanged
        Reticle.Opacity = frm_Opacity.Value
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox1.Enabled = True
        Else
            TextBox1.Enabled = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            TextBox2.Enabled = True
        Else
            TextBox2.Enabled = False
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        e.SuppressKeyPress = True
        Dim modifiers = e.Modifiers.ToString()
        modifiers = modifiers.Replace("Control", "Ctrl")
        modifiers = modifiers.Replace(", ", "+")
        Dim key = e.KeyCode.ToString()
        key = key.Replace("ShiftKey", "")
        key = key.Replace("Menu", "")
        key = key.Replace("ControlKey", "")
        key = key.Replace("Escape", "")
        key = key.Replace("Return", "Enter")
        key = key.Replace("NumPad", "")
        If key.Length > 1 Then
            If Not Char.IsLetter(key.Chars(1)) Then
                key = key.Replace("D", "")
            End If
        End If
        key = key.Replace("Oemtilde", "~")
        key = key.Replace("Oemplus", "+")
        key = key.Replace("OemMinus", "-")
        key = key.Replace("OemOpenBrackets", "[")
        key = key.Replace("Oem6", "]")
        key = key.Replace("Oem5", "\")
        key = key.Replace("Oem1", ";")
        key = key.Replace("Oem7", "'")
        key = key.Replace("Oemcomma", ",")
        key = key.Replace("OemPeriod", ".")
        key = key.Replace("OemQuestion", "?")
        key = key.Replace("Divide", "/")
        key = key.Replace("Multiply", "*")
        key = key.Replace("Minus", "-")
        key = key.Replace("Add", "+")
        key = key.Replace("Period", "")
        If modifiers = "None" Then
            TextBox1.Text = key
        Else
            TextBox1.Text = modifiers & "+" & key
        End If
    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        If TextBox1.Text.EndsWith("+") Then
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub TextBox2_MouseDown(sender As Object, e As MouseEventArgs) Handles TextBox2.MouseDown
        TextBox2.Text = e.Button.ToString() & " Click"
    End Sub

    Private Sub TextBox2_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyUp
        TextBox1.Text = ""
    End Sub

End Class