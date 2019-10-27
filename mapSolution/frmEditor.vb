Imports System.Windows.Forms
Imports GMap.NET
Imports GMap.NET.MapProviders

Public Class frmEditor
    Dim mapa As MapType
    Private Sub FrmEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mapa = New MapType(Me.GM1)

    End Sub

    Private Sub map_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles GM1.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            Dim lat As Double = GM1.FromLocalToLatLng(e.X, e.Y).Lat
            Dim lng As Double = GM1.FromLocalToLatLng(e.X, e.Y).Lng
            Dim plc As Placemark = Nothing
            Dim st
            plc = GMapProviders.OpenStreetMap.GetPlacemark(GM1.FromLocalToLatLng(e.X, e.Y), st)

            If st = GeoCoderStatusCode.OK Then

                If String.IsNullOrEmpty(AddressType.GetHouseNumber(plc.Address)) Then
                    Dim hr As String = InputBox("Numer budynku")
                    Dim adrStr As String = hr & "," & plc.Address
                    mapa.AddAdres(adrStr, New PointLatLng(lat, lng), True)
                End If

                mapa.AddAdres(plc, New PointLatLng(lat, lng), True)
            End If

        End If




    End Sub
End Class