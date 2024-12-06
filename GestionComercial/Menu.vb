Public Class FormularioPrincipal

    Private Sub FormularioPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.Width = Screen.PrimaryScreen.WorkingArea.Width
        Me.Height = Screen.PrimaryScreen.WorkingArea.Height
    End Sub

    Private Sub VentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasToolStripMenuItem.Click
        FormVentas.Show()
        FormProductos.Hide()
        Reportes.Hide()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductosToolStripMenuItem.Click
        FormVentas.Hide()
        FormProductos.Show()
        Reportes.Hide()
    End Sub

    Private Sub ReportesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportesToolStripMenuItem.Click
        'FormVentas.Hide()
        'FormProductos.Hide()
        'Reportes.Show()
    End Sub

    Private Sub ExistenciasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExistenciasToolStripMenuItem.Click
        FormVentas.Hide()
        FormProductos.Hide()
        Reportes.Hide()
        MsgBox("Módulo en proceso de desarrollo, aún no disponible!", MsgBoxStyle.ApplicationModal, "Atención")
    End Sub

    Private Sub ReportesToolStripMenuItemVentas_Click(sender As Object, e As EventArgs) Handles ReportesToolStripMenuItemVentas.Click
        FormVentas.Hide()
        FormProductos.Hide()
        ReporteVentas.Show()
    End Sub

    Private Sub ReportesToolStripMenuItemExistencias_Click(sender As Object, e As EventArgs) Handles ReportesToolStripMenuItemExistencias.Click

    End Sub

End Class
