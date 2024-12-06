Public Class Compras

    Private _File As String = "productos.xml"
    Private _Child_Detalle As System.Xml.XmlElement
    Private _XmlDocument As System.Xml.XmlDocument
    Private Sep As Char

    Private Sub Compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height / 2 - Me.Height / 2) + 25
        Me.Left = Screen.PrimaryScreen.WorkingArea.Width / 2 - Me.Width / 2
        Sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
    End Sub

    Private Sub TextBoxPrecioProductoCompras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxPrecioProductoCompras.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click

        _XmlDocument = New System.Xml.XmlDocument

        If FileIO.FileSystem.FileExists(_File) Then
            _XmlDocument.Load(_File)
        Else
            _XmlDocument.LoadXml("<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & "?><root></root>")
            _XmlDocument.Save(_File)
        End If

        Dim _ObjectNodo As New ClassNodo
        _ObjectNodo.Codigo = TextBoxCodigoProductoCompras.Text
        _ObjectNodo.Descripcion = TextBoxDescripcionProductoCompras.Text
        _ObjectNodo.Precio = TextBoxPrecioProductoCompras.Text
        _ObjectNodo.Cantidad = TextBoxCodigoProductoCompras.Text

        RegistrarMovimiento(_ObjectNodo)
        _XmlDocument.Save(_File)

    End Sub

    Private Sub RegistrarMovimiento(ByVal _ObjectNodo As ClassNodo)

        _Child_Detalle = _XmlDocument.SelectSingleNode("root")
        _Child_Detalle.InsertAfter(CrearNodo(_ObjectNodo), _Child_Detalle.LastChild)

    End Sub

    Public Function CrearNodo(ByVal Nodo As ClassNodo) As System.Xml.XmlNode

        'For Each elemento As String In Nodo.Lista
        '    MsgBox(elemento, MsgBoxStyle.SystemModal, "Nodo.Lista")
        'Next

        Dim _XmlNode As System.Xml.XmlNode

        Dim XmlAttributeCodigo As System.Xml.XmlAttribute = _XmlDocument.CreateAttribute("Codigo")
        XmlAttributeCodigo.Value = Nodo.Codigo

        Dim XmlElementDescripcion As System.Xml.XmlElement = _XmlDocument.CreateElement("Descripcion")
        XmlElementDescripcion.InnerText = Nodo.Descripcion

        Dim XmlElementPrecio As System.Xml.XmlElement = _XmlDocument.CreateElement("Precio")
        XmlElementPrecio.InnerText = Nodo.Precio

        Dim XmlElementCantidad As System.Xml.XmlElement = _XmlDocument.CreateElement("Cantidad")
        XmlElementCantidad.InnerText = Nodo.Cantidad

        Dim XmlElementFecha As System.Xml.XmlElement = _XmlDocument.CreateElement("Hora")
        XmlElementFecha.InnerText = Now.Year.ToString & Now.Month.ToString.PadLeft(2, "0") & Now.Day.ToString.PadLeft(2, "0")

        Try

            _XmlNode = _XmlDocument.CreateElement("Producto")
            _XmlNode.Attributes.Append(XmlAttributeCodigo)
            _XmlNode.InsertAfter(XmlElementDescripcion, _XmlNode.LastChild)
            _XmlNode.InsertAfter(XmlElementPrecio, _XmlNode.LastChild)
            _XmlNode.InsertAfter(XmlElementCantidad, _XmlNode.LastChild)
            _XmlNode.InsertAfter(XmlElementFecha, _XmlNode.LastChild)

        Catch ex As Exception
            Throw
        End Try

        Return _XmlNode

    End Function

End Class

Public Class ClassNodo

    Private _CODIGO As String
    Private _DESCRIPCION As String
    Private _PRECIO As String
    Private _CANTIDAD As String

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

End Class