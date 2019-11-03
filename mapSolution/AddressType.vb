
Imports System.Net
Imports System.Windows.Forms
Imports GMap
Imports GMap.NET
Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms

<DebuggerDisplay("{Name}")>
<Serializable> Public Class AddressType


    Public Property Id As String
    Public Property Name As String
    Public Property Content As List(Of AddressType)
    Public Property Atype As eAdresTYpe
    Public Property Lat As Double = 0
    Public Property Lon As Double = 0
    Public Property MarkerType As eMarkerType
    Public Property DispName As String

    Public Sub New()
        Me.Id = Guid.NewGuid.ToString
    End Sub
    Public Sub New(name As String, placemarkAddres As AdresContentType, point As PointLatLng, markertype As eMarkerType)
ck:


        Me.DispName = placemarkAddres.Name
        Me.Content = New List(Of AddressType)
        Me.Name = name
        Me.MarkerType = markertype
        Me.Atype = eAdresTYpe.Region


        Dim pna As PNAType
        Dim pnaExist As Boolean = False
        For Each c As PNAType In Me.Content
            If c.DispName = placemarkAddres.postcode Then
                pnaExist = True
                pna = c
                Exit For
            End If
        Next

        If pnaExist = False Then
            pna = New PNAType With {
            .Atype = eAdresTYpe.PostCode,
            .DispName = placemarkAddres.postcode,
            .MarkerType = Me.MarkerType,
            .Name = placemarkAddres.postcode,
            .Content = New List(Of AddressType)
                    }
        End If

        Dim street As StreetType
        Dim streetExist As Boolean = False
        For Each s As StreetType In pna.Content
            If s.DispName = placemarkAddres.road Then
                streetExist = True
                street = s
                Exit For
            End If
        Next
        If streetExist = False Then
            street = New StreetType With {
                   .DispName = placemarkAddres.road,
                   .Atype = eAdresTYpe.Street,
                   .MarkerType = Me.MarkerType,
                   .Name = placemarkAddres.road,
                   .Content = New List(Of AddressType)
                   }
        End If

        Dim house As HouseType
        Dim houseExist As Boolean = False
        For Each c As HouseType In street.Content
            If c.Name = placemarkAddres.house_number And c.DispName = placemarkAddres.placename Then
                houseExist = True
                house = c
                Exit For
            End If
        Next

        If houseExist = False Then
            house = New HouseType With {
            .DispName = placemarkAddres.postcode & ", " & placemarkAddres.road & ", " & placemarkAddres.placename & ", " & placemarkAddres.house_number,
            .MarkerType = Me.MarkerType,
            .PlaceName = placemarkAddres.placename,
            .Name = placemarkAddres.house_number,
            .Content = New List(Of AddressType),
            .Lon = point.Lng,
            .Lat = point.Lat
            }
        End If


        If houseExist = False Then street.Content.Add(house)

        If streetExist = False Then pna.Content.Add(street)

        If pnaExist = False Then Me.Content.Add(pna)

    End Sub

    Function getNode()
        Dim node As New TreeNode
        node.Text = Me.Name
        node.Tag = Me.Id

        For Each pna In Me.Content
            Dim pnanode As New TreeNode
            pnanode.Text = pna.Name
            pnanode.Tag = pna.Id
            For Each st In pna.Content
                Dim streetnode As New TreeNode
                streetnode.Text = st.Name
                streetnode.Tag = st.Id
                For Each hr In st.Content
                    Dim hrnode As New TreeNode
                    If hr.GetType = GetType(HouseType) Then
                        Dim hh As HouseType = hr
                        hrnode.Text = hh.Name & " " & hh.PlaceName
                        hrnode.Tag = hh.Id
                        streetnode.Nodes.Add(hrnode)
                    End If
                Next
                pnanode.Nodes.Add(streetnode)
            Next
            node.Nodes.Add(pnanode)
        Next


        Return node
    End Function

    Public Function GetAdres(id As String) As AddressType
        If Me.Id = id Then Return Me
        For Each c In Me.Content
            If c.Id = id Then
                Return c
            End If
            GetAdres = c.GetAdres(id)
            If Not IsNothing(GetAdres) Then Return GetAdres
        Next
    End Function


    Public Function Point() As PointLatLng
        Return New PointLatLng(Me.Lat, Me.Lon)
    End Function


    Public Function GetMarkers(Optional ShowContentMarkers As Boolean = True) As List(Of Markers.GMarkerGoogle)
        GetMarkers = New List(Of Markers.GMarkerGoogle)
        If Me.Point.Lat <> 0 And Me.Point.Lng <> 0 Then

            Dim m As New Markers.GMarkerGoogle(Me.Point, Me.MarkerType)
            m.ToolTipText = Me.DispName.Replace(",", vbNewLine)

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
