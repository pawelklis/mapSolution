Module Module1

    Sub Main()
        Dim frm As frmEditor
        If IsNothing(frm) Then frm = New frmEditor
        frm.WindowState = Windows.Forms.FormWindowState.Maximized
        Try
            frm.ShowDialog()
        Catch ex As Exception
            Try
                frm.mapa.Save()
                Console.WriteLine("Zapisano baze przed błędem")
            Catch eex As Exception
                Console.WriteLine("UWAGA, możliwe że zmiany nie zostały zapisane")
            End Try
            Console.WriteLine(ex.ToString)
            Main()
        End Try


        Console.ReadLine()
        frm.Focus()


    End Sub

End Module
