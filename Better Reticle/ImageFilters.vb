Public Module ext_ImageFilters

    '
    '   I Didn't write this but i can't
    '   Find the Original if i find it all 
    '   add the link In here :/
    '

    Public BitmapsWithFilters As New Dictionary(Of Bitmap, ImageFilter)

    <System.Runtime.CompilerServices.Extension()>
    Public Function Filters(ByVal b As Bitmap) As ImageFilter
        If BitmapsWithFilters.ContainsKey(b) Then
            Return BitmapsWithFilters(b)
        Else
            Dim ImageFilter = New ImageFilter(b)
            BitmapsWithFilters.Add(b, ImageFilter)
            Return ImageFilter
        End If
    End Function

    Public Class ImageFilter
        Dim b As Bitmap
        Public Sub New(ByVal b As Bitmap)
            Me.b = b
        End Sub

        Public Shared Sub ConvertToSupportLockBits(ByRef b As Bitmap)
            Dim bClone As New Bitmap(b.Width, b.Height, Imaging.PixelFormat.Format32bppArgb)
            Using g = Graphics.FromImage(bClone)
                b.SetResolution(96, 96)
                g.DrawImage(b, Point.Empty)
            End Using
            b.Dispose()
            b = bClone
        End Sub

        Public Shared Function SupportsLockBits(ByVal b As Bitmap) As Boolean
            Return Bitmap.GetPixelFormatSize(b.PixelFormat) = 32 AndAlso b.PixelFormat <> Imaging.PixelFormat.Indexed
        End Function

#Region "Bitmap Data"

        Private Class BitmapData
            Public Bitmap As Bitmap
            Public ByteData As Byte()
            Public BitmapData As Imaging.BitmapData

            Private Sub New()
            End Sub

            Public Shared Function LockBits(ByVal b As Bitmap) As BitmapData
                If SupportsLockBits(b) = False Then
                    Throw New Exception("Your bitmap must be 32bit non-indexed in order to apply filters")
                End If
                LockBits = New BitmapData
                LockBits.Bitmap = b
                Dim bmpRect As New Rectangle(0, 0, b.Width, b.Height)
                ReDim LockBits.ByteData(b.Width * b.Height * 4 - 1)
                LockBits.BitmapData = b.LockBits(bmpRect, Imaging.ImageLockMode.ReadWrite, b.PixelFormat)
                System.Runtime.InteropServices.Marshal.Copy(LockBits.BitmapData.Scan0, LockBits.ByteData, 0, LockBits.ByteData.Length)
            End Function

            Public Sub UnlockBits()
                System.Runtime.InteropServices.Marshal.Copy(Me.ByteData, 0, Me.BitmapData.Scan0, Me.ByteData.Length)
                Me.Bitmap.UnlockBits(Me.BitmapData)
            End Sub

            Public Function YFromOffset(ByVal Offset As Integer) As Integer
                Return CInt(Int(Offset / (Bitmap.Width * 4)))
            End Function

            Public Function StartOfLineFromOffset(ByVal Offset As Integer) As Integer
                Return Offset - (Offset Mod (Bitmap.Width * 4))
            End Function

        End Class

#End Region

        Private Sub Clear()
            Dim bData = BitmapData.LockBits(b)
            Dim OutBytes As Byte()
            ReDim OutBytes(bData.ByteData.Count - 1)
            bData.ByteData = OutBytes
            bData.UnlockBits()
        End Sub

        Private Function BlendByte(ByVal From As Byte, ByVal [To] As Byte, ByVal Amount As Byte) As Byte
            Return CByte(((CInt([To]) - [From]) * (Amount / 255)) + [From])
        End Function

#Region "Filters"

        Public Sub ApplyWPFEffect(ByVal Effect As System.Windows.Media.Effects.Effect)
            Dim ImageSource As New System.Windows.Media.Imaging.BitmapImage()
            Using ms As New IO.MemoryStream()
                b.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                ImageSource.BeginInit()
                ImageSource.StreamSource = ms
                ImageSource.EndInit()
                Dim FormImage As New System.Windows.Controls.Image()
                FormImage.Effect = Effect
                FormImage.Source = ImageSource
                Dim ImageSize = New System.Windows.Size(b.Width, b.Height)
                FormImage.Measure(ImageSize)
                Dim renderingRectangle As New System.Windows.Rect(ImageSize)
                FormImage.Arrange(renderingRectangle)
                Dim enc As New System.Windows.Media.Imaging.PngBitmapEncoder
                Dim bmpSource As New System.Windows.Media.Imaging.RenderTargetBitmap(b.Width, b.Height, 96, 96, System.Windows.Media.PixelFormats.Pbgra32)
                bmpSource.Render(FormImage)
                enc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(bmpSource))
                Using msOut As New IO.MemoryStream
                    enc.Save(msOut)
                    Using bOut As New Bitmap(msOut)
                        Using g As Graphics = Graphics.FromImage(b)
                            g.Clear(Color.Transparent)
                            g.DrawImageUnscaled(bOut, New Point(0, 0))
                        End Using
                    End Using
                End Using
            End Using
        End Sub

        Public Sub GausianBlur(Optional ByVal Amount As Integer = 4)
            Dim Blur As New System.Windows.Media.Effects.BlurEffect
            Blur.Radius = Amount
            b.Filters.ApplyWPFEffect(Blur)
        End Sub

        Public Sub AlphaMask(ByVal AlphaColor As Color, ByVal SolidColor As Color)
            Dim bData = BitmapData.LockBits(b)
            For ii = LBound(bData.ByteData) To UBound(bData.ByteData) Step 4
                Dim AlphaByte = bData.ByteData(ii + 3)
                bData.ByteData(ii) = BlendByte(AlphaColor.B, SolidColor.B, AlphaByte) 'blue
                bData.ByteData(ii + 1) = BlendByte(AlphaColor.G, SolidColor.G, AlphaByte)  'green
                bData.ByteData(ii + 2) = BlendByte(AlphaColor.R, SolidColor.R, AlphaByte)  'red
                bData.ByteData(ii + 3) = BlendByte(AlphaColor.A, SolidColor.A, AlphaByte)  'alpha
            Next
            bData.UnlockBits()
        End Sub

        Public Sub DropShadow(ByVal ShadowColor As Color, ByVal Depth As Point, Optional ByVal BlurAmount As Integer = 4)
            Using bCloneShadow = DirectCast(b.Clone, Bitmap)
                Using bImage = DirectCast(b.Clone, Bitmap)
                    Clear()
                    Using g = Graphics.FromImage(b)
                        bCloneShadow.Filters.AlphaMask(Color.Transparent, ShadowColor)
                        bCloneShadow.Filters.GausianBlur(BlurAmount)
                        g.DrawImage(bCloneShadow, Depth)
                    End Using
                    Using g = Graphics.FromImage(b)
                        g.DrawImage(bImage, Point.Empty)
                    End Using
                End Using
            End Using
        End Sub

#End Region

    End Class
End Module
