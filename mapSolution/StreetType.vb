
Imports System.Net
Imports GMap
Imports GMap.NET.MapProviders

<serializable> public class StreetType
    Inherits AddressType

    Public Sub New()
        Me.Atype = eAdresTYpe.Street
    End Sub

End Class
