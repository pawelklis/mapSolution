


Imports GMap.NET
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports Newtonsoft.Json.Linq

<DebuggerDisplay("{Name}")>
<Serializable> Public Class AdresContentType

    Public Property placename As String
    Public Property dispname As String
    Public Property house_number As String
    Public Property road As String
    Public Property suburb As String
    Public Property city As String
    Public Property county As String
    Public Property state As String
    Public Property postcode As String
    Public Property country As String
    Public Property country_code As String
    Public Property MarkerType As GMarkerGoogleType = GMarkerGoogleType.blue_small
    Public Property Lat As Double
    Public Property Lon As Double
    Public Property Id As String
    Public Property Rejon As String

    Sub New()
        Me.Id = Guid.NewGuid.ToString
        Me.Rejon = "Brak"
    End Sub
    Public Function Name() As String
        Return Me.postcode & " " & Me.road & " " & Me.house_number
    End Function


    Public Shared Function FromJson(jsonString As String) As AdresContentType
        Dim o As New AdresContentType

        Dim ser As JObject = JObject.Parse(jsonString)

        Dim ot = ser.SelectToken("features[0].properties.address")
        Try
            Dim st = TryCast(ot.First, Newtonsoft.Json.Linq.JProperty)
            If st.Name <> "house_number" Then
                o.placename = st.Value
            End If

        Catch ex As Exception
            o.placename = ""
        End Try


        o.city = ser.SelectToken("features[0].properties.address.city")
        o.country = ser.SelectToken("features[0].properties.address.country")
        o.country_code = ser.SelectToken("features[0].properties.address.country_code")
        o.county = ser.SelectToken("features[0].properties.address.county")
        o.house_number = ser.SelectToken("features[0].properties.address.house_number")
        o.postcode = ser.SelectToken("features[0].properties.address.postcode")
        o.road = ser.SelectToken("features[0].properties.address.road")
        o.state = ser.SelectToken("features[0].properties.address.state")
        o.suburb = ser.SelectToken("features[0].properties.address.suburb")



        Return o
    End Function


    Public Function Point() As PointLatLng
        Return New PointLatLng(Me.Lat, Me.Lon)
    End Function


    Public Function GetMarkers(Optional ShowContentMarkers As Boolean = True) As List(Of Markers.GMarkerGoogle)
        GetMarkers = New List(Of Markers.GMarkerGoogle)
        If Me.Point.Lat <> 0 And Me.Point.Lng <> 0 Then

            Dim m As New Markers.GMarkerGoogle(Me.Point, Me.MarkerType)
            m.ToolTipText = Me.Rejon & vbNewLine & Me.Name.Replace(",", vbNewLine)

            GetMarkers.Add(m)
        End If


    End Function

End Class
