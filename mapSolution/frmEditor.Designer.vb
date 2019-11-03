<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditor))
        Me.GM1 = New GMap.NET.WindowsForms.GMapControl()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnSAve = New System.Windows.Forms.ToolStripButton()
        Me.btnLoad = New System.Windows.Forms.ToolStripButton()
        Me.pnsettings = New System.Windows.Forms.Panel()
        Me.ckAutoRefresh = New System.Windows.Forms.CheckBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.pnsettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'GM1
        '
        Me.GM1.Bearing = 0!
        Me.GM1.CanDragMap = True
        Me.GM1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GM1.EmptyTileColor = System.Drawing.Color.Navy
        Me.GM1.GrayScaleMode = False
        Me.GM1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
        Me.GM1.LevelsKeepInMemmory = 5
        Me.GM1.Location = New System.Drawing.Point(0, 0)
        Me.GM1.MarkersEnabled = True
        Me.GM1.MaxZoom = 2
        Me.GM1.MinZoom = 2
        Me.GM1.MouseWheelZoomEnabled = True
        Me.GM1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter
        Me.GM1.Name = "GM1"
        Me.GM1.NegativeMode = False
        Me.GM1.PolygonsEnabled = True
        Me.GM1.RetryLoadTile = 0
        Me.GM1.RoutesEnabled = True
        Me.GM1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.[Integer]
        Me.GM1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.GM1.ShowTileGridLines = False
        Me.GM1.Size = New System.Drawing.Size(607, 450)
        Me.GM1.TabIndex = 0
        Me.GM1.Zoom = 0R
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnsettings)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GM1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TreeView1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Size = New System.Drawing.Size(800, 450)
        Me.SplitContainer1.SplitterDistance = 607
        Me.SplitContainer1.TabIndex = 1
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(34, 177)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(121, 97)
        Me.TreeView1.TabIndex = 2
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.btnSAve, Me.btnLoad, Me.ToolStripButton2, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(189, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Checked = True
        Me.ToolStripButton1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripButton1.Text = "+/-"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(8, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(17, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "-"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(31, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(17, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "+"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnSAve
        '
        Me.btnSAve.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSAve.Image = CType(resources.GetObject("btnSAve.Image"), System.Drawing.Image)
        Me.btnSAve.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSAve.Name = "btnSAve"
        Me.btnSAve.Size = New System.Drawing.Size(23, 22)
        Me.btnSAve.Text = "Zapisz"
        '
        'btnLoad
        '
        Me.btnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLoad.Image = CType(resources.GetObject("btnLoad.Image"), System.Drawing.Image)
        Me.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(23, 22)
        Me.btnLoad.Text = "Otwórz"
        '
        'pnsettings
        '
        Me.pnsettings.Controls.Add(Me.Button3)
        Me.pnsettings.Controls.Add(Me.ckAutoRefresh)
        Me.pnsettings.Location = New System.Drawing.Point(198, 12)
        Me.pnsettings.Name = "pnsettings"
        Me.pnsettings.Size = New System.Drawing.Size(200, 192)
        Me.pnsettings.TabIndex = 3
        '
        'ckAutoRefresh
        '
        Me.ckAutoRefresh.AutoSize = True
        Me.ckAutoRefresh.Checked = True
        Me.ckAutoRefresh.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckAutoRefresh.Location = New System.Drawing.Point(15, 20)
        Me.ckAutoRefresh.Name = "ckAutoRefresh"
        Me.ckAutoRefresh.Size = New System.Drawing.Size(146, 17)
        Me.ckAutoRefresh.TabIndex = 0
        Me.ckAutoRefresh.Text = "Auto odświeżanie drzewa"
        Me.ckAutoRefresh.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(179, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(18, 23)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "X"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        '
        'frmEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmEditor"
        Me.Text = "frmEditor"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pnsettings.ResumeLayout(False)
        Me.pnsettings.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GM1 As GMap.NET.WindowsForms.GMapControl
    Friend WithEvents SplitContainer1 As Windows.Forms.SplitContainer
    Friend WithEvents ToolStrip1 As Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As Windows.Forms.ToolStripButton
    Friend WithEvents TreeView1 As Windows.Forms.TreeView
    Friend WithEvents ContextMenuStrip1 As Windows.Forms.ContextMenuStrip
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents btnSAve As Windows.Forms.ToolStripButton
    Friend WithEvents btnLoad As Windows.Forms.ToolStripButton
    Friend WithEvents pnsettings As Windows.Forms.Panel
    Friend WithEvents Button3 As Windows.Forms.Button
    Friend WithEvents ckAutoRefresh As Windows.Forms.CheckBox
    Friend WithEvents ToolStripButton2 As Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As Windows.Forms.ToolStripButton
End Class
