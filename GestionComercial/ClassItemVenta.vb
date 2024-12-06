Imports System.Xml
Public Class ClassItemVenta

    Private _CODIGO As String
    Private _DESCRIPCION As String
    Private _UNIDAD As String
    Private _PRECIO As String
    Private _CANTIDAD As String
    Private _TOTAL_ITEM As String

    Public Property Codigo() As String
        Get
            Return _CODIGO
        End Get
        Set(ByVal value As String)
            _CODIGO = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _DESCRIPCION
        End Get
        Set(ByVal value As String)
            _DESCRIPCION = value
        End Set
    End Property

    Public Property Unidad() As String
        Get
            Return _UNIDAD
        End Get
        Set(ByVal value As String)
            _UNIDAD = value
        End Set
    End Property

    Public Property Precio() As String
        Get
            Return _PRECIO
        End Get
        Set(ByVal value As String)
            _PRECIO = value
        End Set
    End Property

    Public Property Cantidad() As String
        Get
            Return _CANTIDAD
        End Get
        Set(ByVal value As String)
            _CANTIDAD = value
        End Set
    End Property

    Public Property Total_Item() As String
        Get
            Return _TOTAL_ITEM
        End Get
        Set(ByVal value As String)
            _TOTAL_ITEM = value
        End Set
    End Property

    Public Sub InsertarItemVenta(ByVal _ObjectItemVenta As ClassItemVenta, ByRef _XmlDocument As XmlDocument, ByRef _XmlNodeVenta As XmlNode, ByVal _RowNum As Integer)

        Dim XmlAttributeRowNum As XmlAttribute = _XmlDocument.CreateAttribute("RowNum")
        XmlAttributeRowNum.Value = _RowNum

        Dim XmlElementCodigo As XmlElement = _XmlDocument.CreateElement("Codigo")
        XmlElementCodigo.InnerText = _ObjectItemVenta.Codigo

        Dim XmlElementDescripcion As XmlElement = _XmlDocument.CreateElement("Descripcion")
        XmlElementDescripcion.InnerText = _ObjectItemVenta.Descripcion

        Dim XmlElementUnidad As XmlElement = _XmlDocument.CreateElement("Unidad")
        XmlElementUnidad.InnerText = _ObjectItemVenta.Unidad

        Dim XmlElementPrecio As XmlElement = _XmlDocument.CreateElement("Precio")
        XmlElementPrecio.InnerText = _ObjectItemVenta.Precio

        Dim XmlElementCantidad As XmlElement = _XmlDocument.CreateElement("Cantidad")
        XmlElementCantidad.InnerText = _ObjectItemVenta.Cantidad

        Dim XmlElementTotal_Item As XmlElement = _XmlDocument.CreateElement("Total_Item")
        XmlElementTotal_Item.InnerText = _ObjectItemVenta.Precio * _ObjectItemVenta.Cantidad

        Dim _XmlNodeItemVenta As XmlNode

        _XmlNodeItemVenta = _XmlDocument.CreateElement("ItemVenta")
        With _XmlNodeItemVenta
            .Attributes.Append(XmlAttributeRowNum)
            .InsertAfter(XmlElementCodigo, .LastChild)
            .InsertAfter(XmlElementDescripcion, .LastChild)
            .InsertAfter(XmlElementUnidad, .LastChild)
            .InsertAfter(XmlElementCantidad, .LastChild)
            .InsertAfter(XmlElementPrecio, .LastChild)
            .InsertAfter(XmlElementTotal_Item, .LastChild)
        End With

        _XmlNodeVenta.InsertAfter(_XmlNodeItemVenta, _XmlNodeVenta.LastChild)

    End Sub

    'Public Shared Function CrearDataTableItemsVenta() As DataTable

    '    Dim _DataTableVenta As New DataTable

    '    With _DataTableVenta

    '        .Columns.Add("Codigo", GetType(String))
    '        .Columns.Add("Descripcion", GetType(String))
    '        .Columns.Add("Unidad", GetType(String))
    '        .Columns.Add("Precio", GetType(String))
    '        .Columns.Add("Cantidad", GetType(String))
    '        .Columns.Add("Total_Item", GetType(String))

    '    End With

    '    Return _DataTableVenta

    'End Function

End Class