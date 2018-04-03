<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reticle
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reticle))
        Me.TrayMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TrayMenuConfigure = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TrayMenuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.InvertVisibilityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TrayMenu
        '
        Me.TrayMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TrayMenuConfigure, Me.ToolStripSeparator2, Me.InvertVisibilityToolStripMenuItem, Me.ToolStripSeparator1, Me.TrayMenuExit})
        Me.TrayMenu.Name = "ContextMenuStrip1"
        Me.TrayMenu.Size = New System.Drawing.Size(153, 104)
        '
        'TrayMenuConfigure
        '
        Me.TrayMenuConfigure.Name = "TrayMenuConfigure"
        Me.TrayMenuConfigure.Size = New System.Drawing.Size(152, 22)
        Me.TrayMenuConfigure.Text = "Configure"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'TrayMenuExit
        '
        Me.TrayMenuExit.Name = "TrayMenuExit"
        Me.TrayMenuExit.Size = New System.Drawing.Size(152, 22)
        Me.TrayMenuExit.Text = "Exit"
        '
        'TrayIcon
        '
        Me.TrayIcon.ContextMenuStrip = Me.TrayMenu
        Me.TrayIcon.Icon = CType(resources.GetObject("TrayIcon.Icon"), System.Drawing.Icon)
        Me.TrayIcon.Text = "Reticle"
        Me.TrayIcon.Visible = True
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(149, 6)
        '
        'InvertVisibilityToolStripMenuItem
        '
        Me.InvertVisibilityToolStripMenuItem.Name = "InvertVisibilityToolStripMenuItem"
        Me.InvertVisibilityToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.InvertVisibilityToolStripMenuItem.Text = "Invert Visibility"
        '
        'Reticle
        '
        Me.BackColor = System.Drawing.Color.Aqua
        Me.BackgroundImage = Global.Reticle.My.Resources.Resources.Retical
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(100, 100)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(100, 100)
        Me.MinimumSize = New System.Drawing.Size(100, 100)
        Me.Name = "Reticle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Yellow
        Me.TrayMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TrayMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TrayIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents TrayMenuConfigure As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TrayMenuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents InvertVisibilityToolStripMenuItem As ToolStripMenuItem
End Class
