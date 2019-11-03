Imports System.Windows.Forms
Imports GMap.NET
Imports GMap.NET.MapProviders

<Serializable> Public Class frmEditor
    Dim mapa As MapType
    Private Sub FrmEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mapa = New MapType(Me.GM1)
        TreeView1.Dock = DockStyle.Fill
        'TreeView1.ExpandAll()
    End Sub

    Private Sub map_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles GM1.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            Dim lat As Double = GM1.FromLocalToLatLng(e.X, e.Y).Lat
            Dim lng As Double = GM1.FromLocalToLatLng(e.X, e.Y).Lng
            Dim plc As Placemark = Nothing
            Dim st
            plc = GMapProviders.OpenStreetMap.GetPlacemark(GM1.FromLocalToLatLng(e.X, e.Y), st)

            If GM1.Zoom < 18 Then Me.GM1.Zoom = 20
            Me.GM1.Position = New PointLatLng(lat, lng)

            If st = GeoCoderStatusCode.OK Then
                Dim AdresObject As AdresContentType = MapType.GetAdres(lat, lng)
                If String.IsNullOrEmpty(AdresObject.house_number) Then
                    Dim hr As String = InputBox(AdresObject.postcode & " " & AdresObject.road & " wprowadź numer budynku", "Nowy punkt")
                    If String.IsNullOrEmpty(hr) Then
                        hr = "0"
                        Exit Sub
                    End If
                    AdresObject.house_number = hr
                    mapa.AddAdres("", AdresObject, New PointLatLng(lat, lng), True)
                End If

                mapa.AddAdres("", AdresObject, New PointLatLng(lat, lng), True)
            End If
            RefreshTreeView1()
        End If





    End Sub
    Sub RefreshTreeView1(Optional skin As Boolean = False)
        If skin = False Then
            If ckAutoRefresh.Checked = False Then
                Exit Sub
            End If
        End If

        TreeView1.Nodes.Clear()
        TreeView1.Nodes.Add(mapa.GetNode)
        If ToolStripButton1.Checked = True Then
            TreeView1.ExpandAll()

        Else
            TreeView1.CollapseAll()

        End If

    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If sender.checked = True Then sender.checked = False Else sender.checked = True
        If sender.checked = True Then
            TreeView1.ExpandAll()

        Else
            TreeView1.CollapseAll()

        End If
    End Sub


    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        If e.Button = MouseButtons.Right Then
            TreeView1.SelectedNode = e.Node

            Dim ctm As New ContextMenuStrip

            If e.Node.Tag.GetType = GetType(AdresContentType) Then
                ctm.Items.Add("Zmień")
            End If

            ctm.Items.Add("Usuń")
            ctm.Items.Add("Rejon")
            ctm.Items.Add("Pokaż punkty")

            AddHandler ctm.ItemClicked, AddressOf ctm_Item_Click
            TreeView1.ContextMenuStrip = ctm
            ctm.Show()


        End If
    End Sub


    Private Sub ctm_Item_Click(sender As Object, e As ToolStripItemClickedEventArgs)
        Select Case e.ClickedItem.Text
            Case "Zmień"
                Try
                    Dim node As TreeNode = TreeView1.SelectedNode
                    Dim ad As AdresContentType = node.Tag
                    Dim newName As String = InputBox("Nowa wartość", "Edycja", ad.Name)
                    If String.IsNullOrEmpty(newName) Then Exit Sub
                Catch ex As Exception

                End Try

                'ad.Name = newName
                'If ad.Atype = AddressType.eAdresTYpe.PostCode Then mapa.MoveAdres(ad)
            Case "Usuń"
                Dim node As TreeNode = TreeView1.SelectedNode
                Dim typ = node.Tag
                If typ.GetType = GetType(AdresContentType) Then
                    Dim a As AdresContentType = node.Tag
                    mapa.removeAdres(node.Name)
                Else
                    Select Case node.Tag
                        Case "rejon"
                            Dim lr As List(Of String) = mapa.DistinctRejon
                            For Each r In lr
                                If r = node.Text Then
                                    For Each adr In mapa.GetAdresList(r)
                                        mapa.AdresBase.Remove(adr)
                                    Next
                                End If
                            Next
                        Case "pna"
                            For Each adr In mapa.GetAdresList(Nothing, node.Text)
                                mapa.AdresBase.Remove(adr)
                            Next
                        Case "street"
                            For Each adr In mapa.GetAdresList(Nothing, Nothing, node.Text)
                                mapa.AdresBase.Remove(adr)
                            Next
                    End Select
                End If

            Case "Pokaż punkty"
                Dim node As TreeNode = TreeView1.SelectedNode
                Dim typ = node.Tag
                If typ.GetType = GetType(AdresContentType) Then
                    Dim a As AdresContentType = node.Tag
                    mapa.ShowMArkers(a)
                Else
                    Select Case typ
                        Case "rejon"
                            mapa.ShowMArkers(node.Text)
                        Case "pna"
                            mapa.ShowMArkers(Nothing, node.Text)
                        Case "street"
                            mapa.ShowMArkers(Nothing, Nothing, node.Text)
                        Case "baza"
                            mapa.ShowMArkers()
                    End Select
                End If

            Case "Rejon"
                Dim r As String = InputBox("Numer rejonu")
                If String.IsNullOrEmpty(r) Then r = "Brak"
                Dim node As TreeNode = TreeView1.SelectedNode
                Dim typ = node.Tag
                If typ.GetType = GetType(AdresContentType) Then
                    typ.rejon = r
                Else
                    Select Case typ
                        Case "rejon"
                            For Each a In mapa.AdresBase
                                If a.Rejon = node.Text Then
                                    a.Rejon = r
                                End If
                            Next
                        Case "pna"
                            For Each a In mapa.AdresBase
                                If a.postcode = node.Text Then
                                    a.Rejon = r
                                End If
                            Next

                        Case "street"
                            For Each a In mapa.AdresBase
                                If a.road = node.Text Then
                                    a.Rejon = r
                                End If
                            Next

                    End Select

                End If

        End Select

        RefreshTreeView1()
        If e.ClickedItem.Text <> "Pokaż punkty" Then mapa.ShowMArkers()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            GM1.Zoom -= 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            GM1.Zoom += 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSAve_Click(sender As Object, e As EventArgs) Handles btnSAve.Click
        mapa.Save()
        Console.WriteLine("Zapisano " & Now)
    End Sub

    Private Sub BtnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim m = mapa.Load()
        If Not IsNothing(m) Then
            mapa = m
            mapa.GM = Me.GM1
            RefreshTreeView1()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        pnsettings.Visible = False
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        pnsettings.Visible = True

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        RefreshTreeView1(True)
    End Sub
End Class