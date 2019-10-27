
Imports System.Net
Imports GMap
Imports GMap.NET
Imports GMap.NET.MapProviders

Public Class MapType

    Public Property AdresBase As List(Of AddressType)

    Private GM As GMap.NET.WindowsForms.GMapControl
    Public Sub New(gm As GMap.NET.WindowsForms.GMapControl)
        Me.GM = gm
        Me.AdresBase = New List(Of AddressType)

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
    '0,Manufaktura Pączków, Oławska, Stare Miasto, Osiedle Stare Miasto, Wrocław, dolnośląskie, 50-123, RP

    Public Sub AddAdres(housenumberNameStreetDzielSuburbCityStatePostCodeCountryCode As String, point As PointLatLng, showPoint As Boolean)


        Dim adr As New AddressType(housenumberNameStreetDzielSuburbCityStatePostCodeCountryCode, housenumberNameStreetDzielSuburbCityStatePostCodeCountryCode, point, AddressType.eMarkerType.blue_dot)

        Dim ok As Boolean = True
        For Each a In Me.AdresBase
            If a.DispName = adr.DispName Then
                ok = False
                adr = a
                Exit For
            End If
        Next
        If ok Then Me.AdresBase.Add(adr)

        If showPoint Then
            For Each m In adr.GetMarkers
                Me.GM.Overlays(0).Markers.Add(m)
            Next
        End If


    End Sub


    Public Sub AddAdres(plc As Placemark, point As PointLatLng, showPoint As Boolean)
        Dim adr As AddressType



        adr = New AddressType(plc.Address, plc.Address, point, AddressType.eMarkerType.blue_dot)

        Dim ok As Boolean = True
        For Each a In Me.AdresBase
            If a.DispName = adr.DispName Then
                ok = False
                adr = a
                Exit For
            End If
        Next
        If ok Then Me.AdresBase.Add(adr)

        If showPoint Then
            For Each m In adr.GetMarkers
                Me.GM.Overlays(0).Markers.Add(m)
            Next
        End If


    End Sub


End Class
