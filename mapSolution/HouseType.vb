
Imports System.Net
Imports GMap
Imports GMap.NET.MapProviders

Public Class HouseType
    Inherits AddressType
    Public Property PlaceName As String
    Public Sub New()
        Me.Atype = eAdresTYpe.HouseNumber
    End Sub

End Class
