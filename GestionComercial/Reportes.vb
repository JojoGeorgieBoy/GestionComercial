Public Class Reportes

    Private _File As String = "C:\GestionComercial\productos.xml"
    Private _DataSetDetalle As New DataSet

    Private Sub Reportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Me.Top = (Screen.PrimaryScreen.WorkingArea.Height / 2 - Me.Height / 2) + 25
        'Me.Left = Screen.PrimaryScreen.WorkingArea.Width / 2 - Me.Width / 2

        '_DataSetDetalle.ReadXml(_File)

        'DataGridViewProductos.DataSource = _DataSetDetalle.Tables(0)

    End Sub
End Class