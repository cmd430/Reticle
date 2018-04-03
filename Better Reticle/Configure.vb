﻿Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices

Public Class Configure

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> Public Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto)> Public Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dsNewLong As Integer) As Integer
    End Function

    Private Const GWL_EXSTYLE As Integer = -20
    Private Const WS_EX_TOOLWINDOW As Integer = &H80
    Private Const WS_EX_APPWINDOW As Integer = &H40000
    Private Const WS_EX_TRANSPARENT As Integer = &H20
    Private Const SWP_NOACTIVATE As UInteger = &H10
    Private Const SWP_NOMOVE As UInteger = &H2
    Private Const SWP_NOSIZE As UInteger = &H1

    Private Reticle_Form As Reticle
    Private Reticle_Bitmap As Bitmap
    Private Reticle_Style As String
    Private Settings As String

    Private Sub Configure_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Settings = Application.StartupPath & "\Data\Config.ini"
        Catch ex As Exception
            Try
                Settings = Application.StartupPath & "\" & Process.GetCurrentProcess().MainModule.FileName.Replace(".exe", "") & ".ini"
            Catch ex2 As Exception
                MessageBox.Show(Me, "Error Loading Config!", "Failed to load config", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Application.Exit()
            End Try
        End Try
        Dim ReticleDir As New DirectoryInfo(ReadINI(Settings, "Settings", "reticle-dir", Application.StartupPath))
        Dim ReticleArr As FileInfo() = ReticleDir.GetFiles("*.png")
        Dim ReticleImg As FileInfo
        For Each ReticleImg In ReticleArr
            ReticleStyle.Items.Add(Path.GetFileNameWithoutExtension(ReticleImg.Name))
        Next
        Red.Value = ReadINI(Settings, "Reticle-Settings", "red", 0)
        Green.Value = ReadINI(Settings, "Reticle-Settings", "green", 0)
        Blue.Value = ReadINI(Settings, "Reticle-Settings", "blue", 0)
        Alpha.Value = ReadINI(Settings, "Reticle-Settings", "alpha", 255)
        DropShadow.Checked = ReadINI(Settings, "Reticle-Settings", "drop-shadow", True)
        ReticleStyle.SelectedItem = ReadINI(Settings, "Reticle-Settings", "reticle", "").Replace(".png", "")
        Reticle_Form = New Reticle With {
            .Width = 100,
            .Height = 100,
            .TopMost = True,
            .ShowInTaskbar = False
        }
        Reticle_Form.Show()
        SetWindowLong(Reticle_Form.Handle, GWL_EXSTYLE, (GetWindowLong(Me.Handle, GWL_EXSTYLE) Or WS_EX_TOOLWINDOW Or WS_EX_TRANSPARENT) And Not WS_EX_APPWINDOW)
        Reticle_Style = ReadINI(Settings, "Settings", "reticle-dir", Application.StartupPath) & "\" & ReticleStyle.SelectedItem & ".png"
        SetReticle()
    End Sub

    Private Sub Configure_Move(sender As Object, e As EventArgs) Handles Me.Move
        Try
            Reticle_Form.Location = New Point(Me.Location.X + 20, Me.Location.Y + 43)
        Catch ex As Exception
        End Try
    End Sub

    Private Function InvertedColour(ByVal ColourToInvert As Color) As Color
        Return Color.FromArgb(CByte(Not ColourToInvert.R), CByte(Not ColourToInvert.G), CByte(Not ColourToInvert.B))
    End Function

    Private Sub SetReticle()
        Dim Reticle_Colored As Bitmap
        Dim Custom_Color As Color = Color.FromArgb(255, Red.Value, Green.Value, Blue.Value)
        Try
            Dim Reticle_Base As Bitmap = New Bitmap(TryCast(Image.FromFile(Reticle_Style), Bitmap), New Size(100, 100))
            Reticle_Colored = RecolorBitmap(Reticle_Base, Custom_Color)
            Reticle_Base.Dispose()
            If DropShadow.Checked = True Then
                Reticle_Colored.Filters.DropShadow(InvertedColour(Custom_Color), New Point(0, 0), 2)
                ' .Filters.DropShadow(COLOR, OFFSET, BLUR)
            End If
            Reticle_Form.SetBitmap(Reticle_Colored, CByte(Alpha.Value))
        Catch e As ApplicationException
            MessageBox.Show(Me, e.Message, "Error with bitmap.", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return
        Catch e As Exception
            MessageBox.Show(Me, e.Message & vbCrLf & Reticle_Style, "Could not open image file.", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return
        End Try
        Reticle_Bitmap = Reticle_Colored
        Reticle_Bitmap.Dispose()
        Reticle_Colored.Dispose()
    End Sub

    Private Function RecolorBitmap(ByVal bmp As Bitmap, ByVal newColor As Color) As Bitmap
        Dim lst As List(Of Color) = BuildColorTable(bmp)
        If lst.Count = 0 Then Return bmp
        Dim bmp2 As New Bitmap(bmp.Width, bmp.Height)
        Using ia As New ImageAttributes
            Dim colorTable(lst.Count - 1) As ColorMap
            For i As Integer = 0 To lst.Count - 1
                colorTable(i) = New ColorMap With {
                  .OldColor = lst(i),
                    .NewColor = Color.FromArgb(lst(i).A, newColor)
                }
            Next
            ia.SetRemapTable(colorTable)
            Using g As Graphics = Graphics.FromImage(bmp2)
                Dim rect As New Rectangle(Point.Empty, bmp.Size)
                g.DrawImage(bmp, rect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, ia)
            End Using
        End Using
        Return bmp2
    End Function

    Public Function BuildColorTable(ByVal bmp As Bitmap) As List(Of Color)
        Dim lst As New List(Of Color)
        For y As Integer = 0 To bmp.Height - 1
            For x As Integer = 0 To bmp.Width - 1
                Dim clr = bmp.GetPixel(x, y)
                If clr.A <> 0 Then lst.Add(bmp.GetPixel(x, y))
            Next
        Next
        Return lst.Distinct.ToList
    End Function

    Private StartUp As Boolean = False
    Private Sub Configure_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If StartUp = False Then
            Me.Hide()
            Reticle_Form.Top = (My.Computer.Screen.Bounds.Height / 2) - (Reticle_Form.Height / 2)
            Reticle_Form.Left = (My.Computer.Screen.Bounds.Width / 2) - (Reticle_Form.Width / 2)
        End If
        StartUp = True
    End Sub

    Private Sub Color_ValueChanged(sender As Object, e As EventArgs) Handles Alpha.ValueChanged, Red.ValueChanged, Green.ValueChanged, Blue.ValueChanged, DropShadow.CheckedChanged
        If Reticle_Bitmap IsNot Nothing Then
            SetReticle()
        End If
    End Sub

    Private Sub ColorPicker_Click(sender As Object, e As EventArgs) Handles ColorPicker.Click
        ColorPickerDialog.CustomColors = Array.ConvertAll(ReadINI(Settings, "Settings", "custom-colors", "").Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries), AddressOf StringToInteger)
        If ColorPickerDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Red.Value = ColorPickerDialog.Color.R
            Green.Value = ColorPickerDialog.Color.G
            Blue.Value = ColorPickerDialog.Color.B
            WriteINI(Settings, "Settings", "custom-colors", String.Join(",", Array.ConvertAll(ColorPickerDialog.CustomColors, New Converter(Of Integer, String)(Function(i) i.ToString))))
        End If
    End Sub
    Private Function StringToInteger(ByVal S As String) As Integer
        If Integer.TryParse(S, Nothing) Then Return CInt(S) Else Return 16777215
    End Function

    Private Sub ReticleStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ReticleStyle.SelectedIndexChanged
        If Reticle_Form IsNot Nothing Then
            Reticle_Style = (ReadINI(Settings, "Settings", "reticle-dir", Application.StartupPath) & "\" & ReticleStyle.SelectedItem & ".png")
            SetReticle()
        End If
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        WriteINI(Settings, "Reticle-Settings", "reticle", ReticleStyle.SelectedItem & ".png")
        WriteINI(Settings, "Reticle-Settings", "red", Red.Value)
        WriteINI(Settings, "Reticle-Settings", "green", Green.Value)
        WriteINI(Settings, "Reticle-Settings", "blue", Blue.Value)
        WriteINI(Settings, "Reticle-Settings", "alpha", Alpha.Value)
        WriteINI(Settings, "Reticle-Settings", "drop-shadow", DropShadow.Checked)
        Application.Restart()
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Application.Restart()
    End Sub

    Private Sub TrayMenuExit_Click(sender As Object, e As EventArgs) Handles TrayMenuExit.Click
        Application.Exit()
    End Sub

    Private Sub TrayMenuConfigure_Click(sender As Object, e As EventArgs) Handles TrayMenuConfigure.Click
        Me.Show()
        Reticle_Form.Location = New Point(Me.Location.X + 20, Me.Location.Y + 43)
    End Sub

End Class

Class Reticle
    Inherits PerPixelAlphaForm

End Class