
Imports System.Net
Imports GMap
Imports GMap.NET
Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms

Public Class AddressType


    Public Property Id As String
    Public Property Name As String
    Public Property Content As List(Of AddressType)
    Public Property Atype As eAdresTYpe
    Public Property Lat As Double = 0
    Public Property Lon As Double = 0
    Public Property MarkerType As eMarkerType
    Public Property DispName As String

    Public Sub New()
    End Sub
    Public Sub New(name As String, placemarkAddres As String, point As PointLatLng, markertype As eMarkerType)
ck:
        If placemarkAddres.Split(",").Length < 9 Then
            placemarkAddres = "," & placemarkAddres
            GoTo ck
        End If

        Me.DispName = placemarkAddres
        Me.Content = New List(Of AddressType)
        Me.Name = name
        Me.MarkerType = markertype
        Me.Atype = eAdresTYpe.Region

        Dim pna As New PNAType With {
        .Atype = eAdresTYpe.PostCode,
        .DispName = placemarkAddres,
        .MarkerType = Me.MarkerType,
        .Name = Me.GetPNA,
        .Content = New List(Of AddressType)
                }

        Dim street As New StreetType With {
        .DispName = Me.DispName,
        .Atype = eAdresTYpe.Street,
        .MarkerType = Me.MarkerType,
        .Name = Me.GetStreet,
        .Content = New List(Of AddressType)
        }

        Dim house As New HouseType With {
        .DispName = Me.DispName,
        .MarkerType = Me.MarkerType,
        .Name = Me.GetHouseNumber,
        .Content = New List(Of AddressType),
        .Lon = point.Lng,
        .Lat = point.Lat
        }

        street.Content.Add(house)

        pna.Content.Add(street)

        Me.Content.Add(pna)

    End Sub


    Private Function GetName()
        Return Me.DispName.Split(",")(0)
    End Function
    Private Function GetStreet()
        Return Me.DispName.Split(",")(2)
    End Function
    Private Function GetPNA()
        Return Me.DispName.Split(",")(7)
    End Function
    Private Function GetHouseNumber()
        Return Me.DispName.Split(",")(1)
    End Function

    Public Shared Function GetHouseNumber(placemarkString As String)
ck:
        If placemarkString.Split(",").Length < 9 Then
            placemarkString = "," & placemarkString
            GoTo ck
        End If
        Return placemarkString.Split(",")(1)
    End Function



    Public Function Point() As PointLatLng
        Return New PointLatLng(Me.Lat, Me.Lon)
    End Function


    Public Function GetMarkers(Optional ShowContentMarkers As Boolean = True) As List(Of Markers.GMarkerGoogle)
        GetMarkers = New List(Of Markers.GMarkerGoogle)
        If Me.Point.Lat <> 0 And Me.Point.Lng <> 0 Then

            Dim m As New Markers.GMarkerGoogle(Me.Point, Me.MarkerType)
            m.ToolTipText = Me.DispName .Replace(",",vbNewLine )

            GetMarkers.Add(m)
        End If


        If ShowContentMarkers Then
            If Not IsNothing(Me.Content) Then
                For Each adr In Me.Content
                    For Each mm In adr.GetMarkers(ShowContentMarkers)
                        GetMarkers.Add(mm)
                    Next
                Next
            End If
        End If

    End Function

    Public Enum eAdresTYpe
        Region = 0
        PostCode = 1
        Street = 2
        HouseNumber = 3

    End Enum

    Public Enum eMarkerType

        arrow = 1
        blue = 2
        blue_small = 3
        blue_dot = 4
        blue_pushpin = 5
        brown_small = 6
        gray_small = 7
        green = 8
        green_small = 9
        green_dot = 10
        green_pushpin = 11
        green_big_go = 12
        yellow = 13
        yellow_small = 14
        yellow_dot = 15
        yellow_big_pause = 16
        yellow_pushpin = 17
        lightblue = 18
        lightblue_dot = 19
        lightblue_pushpin = 20
        orange = 21
        orange_small = 22
        orange_dot = 23
        pink = 24
        pink_dot = 25
        pink_pushpin = 26
        purple = 27
        purple_small = 28
        purple_dot = 29
        purple_pushpin = 30
        red = 31
        red_small = 32
        red_dot = 33
        red_pushpin = 34
        red_big_stop = 35
        black_small = 36
        white_small = 37
    End Enum
End Class
