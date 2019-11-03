Module Module1

    Sub Main()
        Dim frm As frmEditor = New frmEditor
        frm.WindowState = Windows.Forms.FormWindowState.Maximized
        Try
            frm.ShowDialog()
        Catch ex As Exception

        End Try


        Console.ReadLine()
        frm.Focus()


    End Sub

End Module
