
Imports System.Net
Imports GMap
Imports GMap.NET.MapProviders

<serializable> public class PNAType
    Inherits AddressType

    Public Sub New()
        Me.Atype = eAdresTYpe.PostCode
    End Sub

End Class
