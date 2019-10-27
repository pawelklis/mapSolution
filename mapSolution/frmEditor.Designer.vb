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
        Me.GM1 = New GMap.NET.WindowsForms.GMapControl()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.GM1)
        Me.SplitContainer1.Size = New System.Drawing.Size(800, 450)
        Me.SplitContainer1.SplitterDistance = 607
        Me.SplitContainer1.TabIndex = 1
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
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GM1 As GMap.NET.WindowsForms.GMapControl
    Friend WithEvents SplitContainer1 As Windows.Forms.SplitContainer
End Class
