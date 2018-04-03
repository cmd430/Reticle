<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Configure
    Inherits System.Windows.Forms.Form

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Configure))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ReticleStyle = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DropShadow = New System.Windows.Forms.CheckBox()
        Me.Alpha = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ColorPicker = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Red = New System.Windows.Forms.NumericUpDown()
        Me.Blue = New System.Windows.Forms.NumericUpDown()
        Me.Green = New System.Windows.Forms.NumericUpDown()
        Me.ReticlePreview = New System.Windows.Forms.PictureBox()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.Save = New System.Windows.Forms.Button()
        Me.ColorPickerDialog = New System.Windows.Forms.ColorDialog()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.TrayMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TrayMenuConfigure = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TrayMenuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Alpha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Red, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Blue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Green, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReticlePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TrayMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(46, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Reticle Style"
        '
        'ReticleStyle
        '
        Me.ReticleStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ReticleStyle.FormattingEnabled = True
        Me.ReticleStyle.Location = New System.Drawing.Point(118, 118)
        Me.ReticleStyle.Name = "ReticleStyle"
        Me.ReticleStyle.Size = New System.Drawing.Size(286, 21)
        Me.ReticleStyle.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DropShadow)
        Me.GroupBox1.Controls.Add(Me.Alpha)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ColorPicker)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Red)
        Me.GroupBox1.Controls.Add(Me.Blue)
        Me.GroupBox1.Controls.Add(Me.Green)
        Me.GroupBox1.Location = New System.Drawing.Point(118, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(286, 100)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reticle Color"
        '
        'DropShadow
        '
        Me.DropShadow.AutoSize = True
        Me.DropShadow.Location = New System.Drawing.Point(173, 61)
        Me.DropShadow.Name = "DropShadow"
        Me.DropShadow.Size = New System.Drawing.Size(89, 17)
        Me.DropShadow.TabIndex = 12
        Me.DropShadow.Text = "Drop shadow"
        Me.DropShadow.UseVisualStyleBackColor = True
        '
        'Alpha
        '
        Me.Alpha.Location = New System.Drawing.Point(219, 32)
        Me.Alpha.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.Alpha.Name = "Alpha"
        Me.Alpha.Size = New System.Drawing.Size(48, 20)
        Me.Alpha.TabIndex = 11
        Me.Alpha.Value = New Decimal(New Integer() {255, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(170, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Alpha"
        '
        'ColorPicker
        '
        Me.ColorPicker.Location = New System.Drawing.Point(105, 19)
        Me.ColorPicker.Name = "ColorPicker"
        Me.ColorPicker.Size = New System.Drawing.Size(42, 72)
        Me.ColorPicker.TabIndex = 9
        Me.ColorPicker.Text = "Pick Color"
        Me.ColorPicker.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Blue"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Green"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Red"
        '
        'Red
        '
        Me.Red.Location = New System.Drawing.Point(51, 19)
        Me.Red.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.Red.Name = "Red"
        Me.Red.Size = New System.Drawing.Size(48, 20)
        Me.Red.TabIndex = 3
        '
        'Blue
        '
        Me.Blue.Location = New System.Drawing.Point(51, 71)
        Me.Blue.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.Blue.Name = "Blue"
        Me.Blue.Size = New System.Drawing.Size(48, 20)
        Me.Blue.TabIndex = 5
        '
        'Green
        '
        Me.Green.Location = New System.Drawing.Point(51, 45)
        Me.Green.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.Green.Name = "Green"
        Me.Green.Size = New System.Drawing.Size(48, 20)
        Me.Green.TabIndex = 4
        '
        'ReticlePreview
        '
        Me.ReticlePreview.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ReticlePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ReticlePreview.Location = New System.Drawing.Point(12, 12)
        Me.ReticlePreview.Name = "ReticlePreview"
        Me.ReticlePreview.Size = New System.Drawing.Size(100, 100)
        Me.ReticlePreview.TabIndex = 9
        Me.ReticlePreview.TabStop = False
        '
        'Cancel
        '
        Me.Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Cancel.Location = New System.Drawing.Point(248, 148)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 23)
        Me.Cancel.TabIndex = 14
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'Save
        '
        Me.Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Save.Location = New System.Drawing.Point(329, 148)
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(75, 23)
        Me.Save.TabIndex = 13
        Me.Save.Text = "Save"
        Me.Save.UseVisualStyleBackColor = True
        '
        'ColorPickerDialog
        '
        Me.ColorPickerDialog.AnyColor = True
        Me.ColorPickerDialog.FullOpen = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 158)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Created by cmd430"
        '
        'TrayIcon
        '
        Me.TrayIcon.ContextMenuStrip = Me.TrayMenu
        Me.TrayIcon.Icon = CType(resources.GetObject("TrayIcon.Icon"), System.Drawing.Icon)
        Me.TrayIcon.Text = "Reticle"
        Me.TrayIcon.Visible = True
        '
        'TrayMenu
        '
        Me.TrayMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TrayMenuConfigure, Me.ToolStripSeparator1, Me.TrayMenuExit})
        Me.TrayMenu.Name = "ContextMenuStrip1"
        Me.TrayMenu.Size = New System.Drawing.Size(128, 54)
        '
        'TrayMenuConfigure
        '
        Me.TrayMenuConfigure.Name = "TrayMenuConfigure"
        Me.TrayMenuConfigure.Size = New System.Drawing.Size(127, 22)
        Me.TrayMenuConfigure.Text = "Configure"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(124, 6)
        '
        'TrayMenuExit
        '
        Me.TrayMenuExit.Name = "TrayMenuExit"
        Me.TrayMenuExit.Size = New System.Drawing.Size(127, 22)
        Me.TrayMenuExit.Text = "Exit"
        '
        'Configure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(417, 183)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Save)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ReticleStyle)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ReticlePreview)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(433, 222)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(433, 222)
        Me.Name = "Configure"
        Me.Text = "Configure Reticle"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.SystemColors.ControlDark
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Alpha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Red, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Blue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Green, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReticlePreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TrayMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As Label
    Friend WithEvents ReticleStyle As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Alpha As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents ColorPicker As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Red As NumericUpDown
    Friend WithEvents Blue As NumericUpDown
    Friend WithEvents Green As NumericUpDown
    Friend WithEvents ReticlePreview As PictureBox
    Friend WithEvents Cancel As Button
    Friend WithEvents Save As Button
    Friend WithEvents ColorPickerDialog As ColorDialog
    Friend WithEvents Label6 As Label
    Friend WithEvents TrayIcon As NotifyIcon
    Friend WithEvents TrayMenu As ContextMenuStrip
    Friend WithEvents TrayMenuConfigure As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents TrayMenuExit As ToolStripMenuItem
    Friend WithEvents DropShadow As CheckBox
End Class
