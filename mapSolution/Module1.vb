Module Module1

    Sub Main()
        Dim frm As frmEditor = New frmEditor
        frm.WindowState = Windows.Forms.FormWindowState.Maximized

        frm.ShowDialog()

        Console.ReadLine()
        frm.Focus()


    End Sub

End Module
