
Imports System.IO
Imports System.Net
Imports System.Windows.Forms
Imports GMap
Imports GMap.NET
Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms.Markers
Imports Newtonsoft.Json.Linq
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

<Serializable> Public Class MapType

    Public Property AdresBase As List(Of AdresContentType)
    Public Property FilePath As String

    <NonSerialized()>
    Public GM As GMap.NET.WindowsForms.GMapControl
    Public Sub New(gm As GMap.NET.WindowsForms.GMapControl)
        Me.GM = gm
        Me.AdresBase = New List(Of AdresContentType)

        gm.MinZoom = 1
        gm.MaxZoom = 20

        GMapProvider.WebProxy = WebRequest.DefaultWebProxy
        GMapProvider.WebProxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials

        gm.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance
        GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache
        Dim st = gm.SetPositionByKeywords("Wrocław")
        gm.Zoom = 11

        gm.Overlays.Add(New WindowsForms.GMapOverlay("markers"))

        gm.Refresh()
    End Sub

    Public Function GetAdres(id As String) As AdresContentType
        For Each a In Me.AdresBase
            If a.Id = id Then Return a
        Next
    End Function
    Public Function GetAdresList(Optional rejon As String = Nothing, Optional pna As String = Nothing, Optional street As String = Nothing) As List(Of AdresContentType)
        GetAdresList = New List(Of AdresContentType)
        If Not IsNothing(rejon) Then
            For Each a In Me.AdresBase
                If a.Rejon = rejon Then
                    GetAdresList.Add(a)
                End If
            Next
        End If
        If Not IsNothing(pna) Then
            For Each a In Me.AdresBase
                If a.postcode = pna Then
                    GetAdresList.Add(a)
                End If
            Next
        End If
        If Not IsNothing(street) Then
            For Each a In Me.AdresBase
                If a.road = street Then
                    GetAdresList.Add(a)
                End If
            Next
        End If
    End Function
    '0,Manufaktura Pączków, Oławska, Stare Miasto, Osiedle Stare Miasto, Wrocław, dolnośląskie, 50-123, RP

    Public Shared Function GetAdres(lat As Double, lon As Double) As AdresContentType
        Dim lt As String = lat
        Dim ln As String = lon
        lt = lt.Replace(",", ".")
        ln = ln.Replace(",", ".")

        Dim a As String = "https://nominatim.openstreetmap.org/reverse?format=xml&lat=" & lt.ToString & "&lon=" & ln & "&zoom=18&addressdetails=1"

        a = "https://nominatim.openstreetmap.org/reverse?format=geojson&lat=" & lt & "&lon=" & ln & ""
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader

        request = DirectCast(WebRequest.Create(a), HttpWebRequest)

        request.Proxy = WebRequest.DefaultWebProxy
        request.Proxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:31.0) Gecko/20100101 Firefox/31.0"

        response = DirectCast(request.GetResponse(), HttpWebResponse)
        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String
        rawresp = reader.ReadToEnd()


        Return AdresContentType.FromJson(rawresp)
    End Function

    Public Function GetNode() As TreeNode

        Dim n As New TreeNode(" Baza adresowa  ")
        n.Tag = "baza"
        'GMarkerGoogleType max 37

        Dim i As Integer = 1
        For Each r In Me.DistinctRejon
            Dim rejNode As New TreeNode
            rejNode.Text = r
            rejNode.Tag = "rejon"

            Dim pnaList = (From a In Me.AdresBase
                           Select a.postcode, a Where a.Rejon = r).Distinct



            For Each pn In Me.DistinctPNA(r)

                Dim pnaNode As New TreeNode(pn)
                pnaNode.Tag = "pna"

                For Each st In DistinctStreet(pn, r)
                    Dim streetnode As New TreeNode(st)
                    streetnode.Tag = "street"

                    For Each h In DistinctHouse(pn, st, r)
                        If i > 37 Then i = 1
                        h.MarkerType = i

                        Dim houseNode As New TreeNode(h.house_number & " " & h.placename)
                        houseNode.Tag = h
                        houseNode.Name = h.Id
                        streetnode.Nodes.Add(houseNode)
                    Next
                    Dim stad As Boolean = True
                    For Each n In pnaNode.Nodes
                        If n.Text = streetnode.Text Then
                            stad = False
                        End If
                    Next
                    If stad = True Then
                        pnaNode.Nodes.Add(streetnode)
                    End If
                Next

                rejNode.Nodes.Add(pnaNode)
            Next

            n.Nodes.Add(rejNode)
            i += 1
        Next




        Return n

    End Function

    Function DistinctRejon() As List(Of String)
        Dim rej As New List(Of String)
        For Each a In Me.AdresBase
            If Not rej.Contains(a.Rejon) Then
                rej.Add(a.Rejon)
            End If
        Next
        rej.Sort()

        Return rej
    End Function
    Function DistinctPNA(rejon As String) As List(Of String)
        DistinctPNA = New List(Of String)
        For Each a In Me.AdresBase
            If a.Rejon = rejon Then
                If Not DistinctPNA.Contains(a.postcode) Then
                    DistinctPNA.Add(a.postcode)
                End If
            End If

        Next
    End Function
    Function DistinctStreet(pna As String, rejon As String) As List(Of String)
        DistinctStreet = New List(Of String)
        For Each a In Me.AdresBase
            If a.Rejon = rejon Then
                If a.postcode = pna Then
                    If Not DistinctStreet.Contains(a.road) Then
                        DistinctStreet.Add(a.road)
                    End If
                End If

            End If
        Next
    End Function
    Function DistinctHouse(pna As String, street As String, rejon As String) As List(Of AdresContentType)
        DistinctHouse = New List(Of AdresContentType)
        For Each a In Me.AdresBase
            If a.Rejon = rejon Then
                If a.postcode = pna Then
                    If a.road = street Then
                        Dim ok As Boolean = True
                        For Each hh In DistinctHouse
                            If hh.house_number = a.house_number Then ok = False
                        Next
                        If ok = True Then
                            DistinctHouse.Add(a)
                        End If
                    End If
                End If

            End If
        Next
    End Function
    Public Sub AddAdres(name As String, adr As AdresContentType, point As PointLatLng, showPoint As Boolean)
        '     Me.AdresBase.Clear()
        adr.Lat = point.Lat
        adr.Lon = point.Lng


        Me.AdresBase.Add(adr)
        Console.WriteLine("Dodano adres " & adr.Name)





        'Dim adrr As New AddressType(name, adr, point, AddressType.eMarkerType.blue_dot)
        'If adr.placename <> "" Then
        '    Debug.Print("")
        'End If
        'Dim aded As Boolean = False
        'For Each a In Me.AdresBase

        '    If a.Name = adrr.Name Then
        '        Dim needpnaAdd As Boolean = True
        '        For Each pn In a.Content
        '            If pn.Name = adrr.Content(0).Name Then
        '                needpnaAdd = False
        '                Dim needStreetAdd As Boolean = True
        '                For Each st In pn.Content
        '                    If st.Name = adrr.Content(0).Content(0).Name Then
        '                        needStreetAdd = False
        '                        Dim needAddHR As Boolean = True
        '                        For Each hr In st.Content
        '                            If hr.Name = adrr.Content(0).Content(0).Content(0).Name Then
        '                                needAddHR = False
        '                            End If
        '                        Next
        '                        If needAddHR = True Then
        '                            st.Content.Add(adrr.Content(0).Content(0).Content(0))
        '                            aded = True
        '                        End If
        '                    Else
        '                        st.Content.Add(adrr.Content(0).Content(0))
        '                        aded = True
        '                    End If
        '                Next
        '                If needStreetAdd = True Then
        '                    pn.Content.Add(adrr.Content(0).Content(0))
        '                End If
        '            End If
        '        Next
        '        If needpnaAdd = True Then
        '            a.Content.Add(adrr.Content(0))
        '        End If
        '    End If

        'Next

        'If Me.AdresBase.Count = 0 Then
        '    Me.AdresBase.Add(adrr)
        'End If

        If showPoint Then
            For Each m In adr.GetMarkers
                Me.GM.Overlays(0).Markers.Add(m)
            Next
        End If


    End Sub
    Sub ShowMArkers(adr As AdresContentType)
        Me.GM.Overlays.Clear()
        Me.GM.Overlays.Add(New WindowsForms.GMapOverlay("mark"))
        For Each m In adr.GetMarkers
            Me.GM.Overlays(0).Markers.Add(m)
        Next



    End Sub

    Sub ShowMArkers(Optional rejon As String = Nothing, Optional pna As String = Nothing, Optional street As String = Nothing)
        Me.GM.Overlays.Clear()
        Me.GM.Overlays.Add(New WindowsForms.GMapOverlay("mark"))
        If IsNothing(rejon) And IsNothing(pna) And IsNothing(street) Then
            For Each a In Me.AdresBase
                For Each m In a.GetMarkers
                    Me.GM.Overlays(0).Markers.Add(m)
                Next
            Next
        End If
        If Not IsNothing(rejon) And IsNothing(pna) And IsNothing(street) Then
            For Each a In Me.AdresBase
                If a.Rejon = rejon Then
                    For Each m In a.GetMarkers
                        Me.GM.Overlays(0).Markers.Add(m)
                    Next
                End If
            Next
        End If
        If IsNothing(rejon) And Not IsNothing(pna) And IsNothing(street) Then
            For Each a In Me.AdresBase
                If a.postcode = pna Then
                    For Each m In a.GetMarkers
                        Me.GM.Overlays(0).Markers.Add(m)
                    Next
                End If
            Next
        End If
        If IsNothing(rejon) And IsNothing(pna) And Not IsNothing(street) Then
            For Each a In Me.AdresBase
                If a.road = street Then
                    For Each m In a.GetMarkers
                        Me.GM.Overlays(0).Markers.Add(m)
                    Next
                End If
            Next
        End If

    End Sub
    Sub removeAdres(id As String)
        For Each a In Me.AdresBase
            If a.Id = id Then
                Me.AdresBase.Remove(a)
                Exit For
            End If
        Next
    End Sub

    Sub MoveAdres(ad As AddressType)

        'Dim adrr As AddressType = ad
        'Me.removeAdres(ad.Id)


        'Dim aded As Boolean = False
        'For Each aa In Me.AdresBase
        '    For Each a In aa.Content
        '        If a.Name = adrr.Name Then
        '            Dim needpnaAdd As Boolean = True
        '            For Each pn In a.Content
        '                If pn.Name = adrr.Content(0).Name Then
        '                    needpnaAdd = False
        '                    Dim needStreetAdd As Boolean = True
        '                    For Each st In pn.Content
        '                        If st.Name = adrr.Content(0).Content(0).Name Then
        '                            needStreetAdd = False
        '                            Dim needAddHR As Boolean = True
        '                            For Each hr In st.Content
        '                                If hr.Name = adrr.Content(0).Content(0).Content(0).Name Then
        '                                    needAddHR = False
        '                                End If
        '                            Next
        '                            If needAddHR = True Then
        '                                Try
        '                                    st.Content.Add(adrr.Content(0).Content(0).Content(0))
        '                                    aded = True
        '                                Catch ex As Exception

        '                                End Try
        '                            End If
        '                        Else
        '                            st.Content.Add(adrr.Content(0).Content(0))
        '                            aded = True
        '                        End If
        '                    Next
        '                    If needStreetAdd = True Then
        '                        pn.Content.Add(adrr.Content(0).Content(0))
        '                    End If
        '                End If
        '            Next
        '            If needpnaAdd = True Then
        '                a.Content.Add(adrr.Content(0))
        '            End If
        '        End If

        '    Next
        'Next
        'If Me.AdresBase.Count = 0 Then
        '    Me.AdresBase.Add(adrr)
        'End If


    End Sub
    Public Sub Save()
        If String.IsNullOrEmpty(Me.FilePath) Then
            Dim sf As New SaveFileDialog
            sf.DefaultExt = ".mpd"
            sf.AddExtension = True
            sf.FileName = "adres_base.mpd"

            If sf.ShowDialog = DialogResult.OK Then
                Me.FilePath = sf.FileName


            Else
                Exit Sub
            End If
        End If
        If Path.GetExtension(Me.FilePath) <> ".mpd" Then
            Me.FilePath = Me.FilePath & ".mpd"
        End If

        Dim formatter As IFormatter = New BinaryFormatter
        Dim stream As IO.Stream = New FileStream(Me.FilePath, FileMode.Create, FileAccess.Write, FileShare.None)
        formatter.Serialize(stream, Me)
        stream.Close()
    End Sub


    Public Function Load()
        Dim opf As New OpenFileDialog
        opf.Filter = ".mpd|"

        If opf.ShowDialog = DialogResult.OK Then
            Me.FilePath = opf.FileName
            If File.Exists(Me.FilePath) Then
                Dim formatter As IFormatter = New BinaryFormatter
                Dim stream As IO.Stream = New FileStream(Me.FilePath, FileMode.Open, FileAccess.Read, FileShare.Read)


                Dim bd = DirectCast(formatter.Deserialize(stream), MapType)
                stream.Close()

                Return bd

            End If
        End If
        Return Nothing
    End Function

End Class
