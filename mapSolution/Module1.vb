Module Module1

    Sub Main()
        Dim frm As frmEditor = New frmEditor
        frm.WindowState = Windows.Forms.FormWindowState.Maximized
        Try
            frm.ShowDialog()
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
            Main()
        End Try


        Console.ReadLine()
        frm.Focus()


    End Sub

End Module
