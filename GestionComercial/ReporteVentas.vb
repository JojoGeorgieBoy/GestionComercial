Imports System.IO
Imports System.Xml

Public Class ReporteVentas

    Private _DirectoryInfo As New DirectoryInfo(My.Settings._FolderVentas.ToString)

    Private Sub ReporteVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.StartPosition = FormStartPosition.CenterParent
        Me.Text = _DirectoryInfo.FullName

        DataGridViewNomArch.DataSource = PoblarDataTableNomArch(ClassNomArch.CrearDataTableNomArch)

        LayoutDataGridViewNomArch(DataGridViewNomArch)

        AddHandler DataGridViewNomArch.Click, AddressOf RescatarDatosDataGridViewNomArch
        AddHandler DataGridViewNomArch.Sorted, AddressOf AnularSelectedDataGridViewNomArch

    End Sub

    Private Function PoblarDataTableNomArch(ByRef _DataTable As DataTable) As DataTable
        For Each _Nodo As ClassNomArch In ClassNomArch.SortMayorMenor(Crear_Lista_NomArch)
            _DataTable.Rows.Add(_Nodo.Fullname, _Nodo.VentasDia, _Nodo.NomArchYYYYMMDD)
        Next
        Return _DataTable
    End Function

    Private Sub RescatarDatosDataGridViewNomArch()

        Dim _XmlDocument As New XmlDocument
        _XmlDocument.Load(DataGridViewNomArch.CurrentRow.Cells(0).Value.ToString)
        Dim _DataTable As DataTable = CrearDataTable("Folio,Hora,Total,InnerXML")
        For Each _XmlElementVentas As XmlElement In _XmlDocument.SelectSingleNode("root").ChildNodes
            _DataTable.Rows.Add(_XmlElementVentas.Attributes("Folio").Value,
            Convertir_a_formato_hora(_XmlElementVentas.Attributes("Hora").Value),
            CInt(_XmlElementVentas.Attributes("Total").Value).ToString("###,###,###,###."),
            _XmlElementVentas.InnerXml)
        Next

        With DataGridViewReporteVentasConsolidado
            .DataSource = _DataTable
            LayoutDataGridViewReporteVentasConsolidado(DataGridViewReporteVentasConsolidado)
        End With

    End Sub

    Private Sub DataGridViewReporteVentasConsolidado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewReporteVentasConsolidado.CellContentClick
        Dim _DataGridViewRow As DataGridViewRow = DataGridViewReporteVentasConsolidado.Rows(e.RowIndex)

        Dim _XmlDocument As New XmlDocument
        _XmlDocument.LoadXml("<Venta>" & Convert.ToString(_DataGridViewRow.Cells("InnerXML").Value) & "</Venta>")
        Dim _DataTable As DataTable = CrearDataTable("Descripcion,Cantidad,Precio,Total_Item")
        For Each _XmlElementVentas As XmlElement In _XmlDocument.SelectSingleNode("Venta").ChildNodes
            With _XmlElementVentas
                _DataTable.Rows.Add(
                .SelectSingleNode("Descripcion").InnerText,
                .SelectSingleNode("Cantidad").InnerText,
                .SelectSingleNode("Precio").InnerText,
                .SelectSingleNode("Total_Item").InnerText)
            End With            
        Next

        DataGridViewReporteVentasDetalle.DataSource = _DataTable
        LayoutDataGridViewReporteVentasDetalle(DataGridViewReporteVentasDetalle)

    End Sub


    Private Sub LeerXML(_StreamReader As StreamReader)

    End Sub

#Region "Funciones básicas"

    Private Function Convertir_a_formato_hora(ByVal Hora As String) As String
        Return Hora.Substring(0, 2) & ":" & Hora.Substring(2, 2) & ":" & Hora.Substring(4, 2)
    End Function

    Private Function NomArchToDate(ByVal NomArch As String) As String
        Dim Fecha As String = NomArch.Replace("Ventas", String.Empty).Replace(".xml", String.Empty)
        Return Fecha.Substring(6, 2) & "/" & Fecha.Substring(4, 2) & "/" & Fecha.Substring(0, 4)
    End Function

    Private Function NomArchYYYYMMDD(ByVal NomArch As String) As String
        Dim Fecha As String = NomArch.Replace("Ventas", String.Empty).Replace(".xml", String.Empty)
        Return Fecha.Substring(0, 4) & Fecha.Substring(4, 2) & Fecha.Substring(6, 2)
    End Function

    Private Sub AnularSelectedDataGridView(ByRef _DataGridView As DataGridView)
        _DataGridView.ClearSelection()
        '_DataGridView.Rows.
    End Sub

    Private Sub AnularSelectedDataGridViewNomArch()
        DataGridViewNomArch.CurrentCell.Selected = False
    End Sub

    Private Sub ButtonBuscarProductos_Click(sender As Object, e As EventArgs) Handles ButtonBuscarProductos.Click
        Dim _ArchVentFechaHoy As String = ClassVenta.NombreArchivoVentas
        If File.Exists(_ArchVentFechaHoy) Then
            MsgBox("File does exists", MsgBoxStyle.SystemModal, "File.Exists")
        Else
            MsgBox("File does not exists", MsgBoxStyle.SystemModal, "File.Exists")
        End If
    End Sub

#End Region

#Region "Funciones específicas"

    Private Function Crear_Lista_NomArch() As List(Of ClassNomArch)
        Dim Lista_NomArch As New List(Of ClassNomArch)
        For Each _FileInfo As FileInfo In _DirectoryInfo.GetFiles
            Dim ObjNomArch As New ClassNomArch
            ObjNomArch.Fullname = _FileInfo.FullName
            ObjNomArch.VentasDia = NomArchToDate(_FileInfo.ToString)
            ObjNomArch.NomArchYYYYMMDD = NomArchYYYYMMDD(_FileInfo.ToString)
            Lista_NomArch.Add(ObjNomArch)
        Next
        Return Lista_NomArch
    End Function

#End Region

End Class