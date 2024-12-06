Imports System.Xml
Public Class ClassProducto

    Private _CODIGO As String
    Private _DESCRIPCION As String
    Private _UNIDAD As String
    Private _PRECIO As String
    Private _CANTIDAD As String
    Private _FECHA As String

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

    Public Property Fecha() As String
        Get
            Return _FECHA
        End Get
        Set(ByVal value As String)
            _FECHA = value
        End Set
    End Property

    Public Shared Function EncontrarCodigoenXML(ByVal _CodigoProducto As String, ByVal _PoblarObjectProducto As Boolean, ByRef _ObjectProducto As ClassProducto) As Boolean

        Dim _XmlDocument As New XmlDocument
        _XmlDocument.Load(My.Settings._FileProductos)

        For Each _XmlElementPadre As XmlElement In _XmlDocument.SelectSingleNode("root").ChildNodes

            If _XmlElementPadre.Attributes.GetNamedItem("Codigo").Value = _CodigoProducto Then

                If _PoblarObjectProducto Then

                    _ObjectProducto.Codigo = _XmlElementPadre.Attributes.GetNamedItem("Codigo").Value

                    For Each _XmlElementHijo As XmlElement In _XmlElementPadre.ChildNodes
                        If _XmlElementHijo.Name = "Descripcion" Then
                            _ObjectProducto.Descripcion = _XmlElementHijo.InnerText
                        End If
                        If _XmlElementHijo.Name = "Unidad" Then
                            _ObjectProducto.Unidad = _XmlElementHijo.InnerText
                        End If
                        If _XmlElementHijo.Name = "Precio" Then
                            _ObjectProducto.Precio = _XmlElementHijo.InnerText
                        End If
                        If _XmlElementHijo.Name = "Cantidad" Then
                            _ObjectProducto.Cantidad = _XmlElementHijo.InnerText
                        End If
                        If _XmlElementHijo.Name = "Fecha" Then
                            _ObjectProducto.Fecha = _XmlElementHijo.InnerText
                        End If
                    Next

                End If

                Return True

            End If

        Next

        Return False

    End Function

    Public Shared Function PoblarDataTableProducto(ByRef _DataTable As DataTable) As DataTable

        Dim _ObjNodo As New ClassProducto

        Dim _XmlDocument As New XmlDocument
        _XmlDocument.Load(My.Settings._FileProductos)

        For Each _XmlElementPadre As XmlElement In _XmlDocument.SelectSingleNode("root").ChildNodes

            _ObjNodo.Codigo = _XmlElementPadre.Attributes.GetNamedItem("Codigo").Value

            For Each _XmlElementHijo As XmlElement In _XmlElementPadre.ChildNodes

                Select Case _XmlElementHijo.Name
                    Case "Descripcion"
                        _ObjNodo.Descripcion = _XmlElementHijo.InnerText
                    Case "Unidad"
                        _ObjNodo.Unidad = _XmlElementHijo.InnerText
                    Case "Precio"
                        _ObjNodo.Precio = _XmlElementHijo.InnerText
                    Case "Cantidad"
                        _ObjNodo.Cantidad = _XmlElementHijo.InnerText
                    Case "Fecha"
                        _ObjNodo.Fecha = Convierte_a_fecha(_XmlElementHijo.InnerText)
                End Select

            Next

            With _DataTable
                .Rows.Add(_ObjNodo.Codigo, _ObjNodo.Descripcion, _ObjNodo.Unidad, CInt(_ObjNodo.Precio).ToString("###,###,###,###."), CInt(_ObjNodo.Cantidad).ToString("###,###,###,###."), _ObjNodo.Fecha)
            End With

        Next

        Return _DataTable

    End Function

    Public Shared Function Actualizar(ByVal _ObjectNodo As ClassProducto) As Boolean

        Dim NodoEncontrado As Boolean = False

        Dim _XmlDocument As New XmlDocument

        If FileIO.FileSystem.FileExists(My.Settings._FileProductos) Then
            _XmlDocument.Load(My.Settings._FileProductos)
        Else
            _XmlDocument.LoadXml("<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & "?><root></root>")
            _XmlDocument.Save(My.Settings._FileProductos)
        End If

        For Each _XmlElementPadre As XmlElement In _XmlDocument.SelectSingleNode("root").ChildNodes

            If _XmlElementPadre.Attributes.GetNamedItem("Codigo").Value = _ObjectNodo.Codigo Then

                For Each _XmlElementHijo As XmlElement In _XmlElementPadre.ChildNodes

                    If _XmlElementHijo.Name = "Descripcion" Then
                        _XmlElementHijo.InnerText = _ObjectNodo.Descripcion
                    End If
                    If _XmlElementHijo.Name = "Unidad" Then
                        _XmlElementHijo.InnerText = _ObjectNodo.Unidad
                    End If
                    If _XmlElementHijo.Name = "Precio" Then
                        _XmlElementHijo.InnerText = _ObjectNodo.Precio
                    End If
                    If _XmlElementHijo.Name = "Cantidad" Then
                        _XmlElementHijo.InnerText = _ObjectNodo.Cantidad
                    End If
                    If _XmlElementHijo.Name = "Fecha" Then
                        _XmlElementHijo.InnerText = Now.Year.ToString & Now.Month.ToString.PadLeft(2, "0") & Now.Day.ToString.PadLeft(2, "0")
                    End If

                Next

                NodoEncontrado = True

                _XmlDocument.Save(My.Settings._FileProductos)

                Exit For

            End If

        Next

        Return NodoEncontrado

    End Function

    Public Shared Sub Eliminar(ByVal _Codigo As String)
        Dim _XmlDocument As New XmlDocument
        _XmlDocument.Load(My.Settings._FileProductos)
        For Each _XmlElement As XmlElement In _XmlDocument.SelectSingleNode("root").ChildNodes
            If _XmlElement.Attributes.GetNamedItem("Codigo").Value = _Codigo Then
                _XmlElement.ParentNode.RemoveChild(_XmlElement)
                Exit For
            End If
        Next
        _XmlDocument.Save(My.Settings._FileProductos)
    End Sub

    'Private Sub ActualizarNodo()

    '    For Each _XmlElementPadre As XmlElement In _XmlDocument.SelectSingleNode("root").ChildNodes
    '        If _XmlElementPadre.Attributes.GetNamedItem("Codigo").Value = TextBoxCodigoProducto.Text Then

    '            For Each _XmlElementHijo As XmlElement In _XmlElementPadre.ChildNodes
    '                If _XmlElementHijo.Name = "Descripcion" Then
    '                    _XmlElementHijo.InnerText = TextBoxDescripcionProducto.Text
    '                End If
    '                If _XmlElementHijo.Name = "Precio" Then
    '                    _XmlElementHijo.InnerText = TextBoxPrecioProducto.Text
    '                End If
    '                If _XmlElementHijo.Name = "Unidad" Then
    '                    _XmlElementHijo.InnerText = ComboUnidadProducto.Text
    '                End If
    '                If _XmlElementHijo.Name = "Cantidad" Then
    '                    _XmlElementHijo.InnerText = TextBoxCantidadProducto.Text
    '                End If
    '            Next

    '            Exit For

    '        End If
    '    Next

    'End Sub

    Public Shared Function CreaNodoDesdeXmlElement(ByVal _XmlElementPadre As Xml.XmlElement) As ClassProducto

        Dim _NodoProducto As New ClassProducto

        _NodoProducto.Codigo = _XmlElementPadre.Attributes.GetNamedItem("Codigo").Value

        For Each _XmlElementHijo As XmlElement In _XmlElementPadre.ChildNodes

            Select Case _XmlElementHijo.Name

                Case "Descripcion"
                    _NodoProducto.Descripcion = _XmlElementHijo.InnerText
                Case "Unidad"
                    _NodoProducto.Unidad = _XmlElementHijo.InnerText
                Case "Precio"
                    _NodoProducto.Precio = _XmlElementHijo.InnerText
                Case "Cantidad"
                    _NodoProducto.Cantidad = _XmlElementHijo.InnerText
                Case "Fecha"
                    _NodoProducto.Fecha = _XmlElementHijo.InnerText

            End Select

        Next

        Return _NodoProducto

    End Function

    Public Shared Sub BubbleSortProductos()

        Dim _XmlDocument As New XmlDocument

        _XmlDocument.Load(My.Settings._FileProductos)

        If _XmlDocument.SelectSingleNode("root").ChildNodes.Count > 1 Then

            Dim _Child_Detalle As XmlElement

            Dim ListaDeNodos As New List(Of ClassProducto)

            For Each _XmlElement As XmlElement In _XmlDocument.SelectSingleNode("root").ChildNodes
                ListaDeNodos.Add(ClassProducto.CreaNodoDesdeXmlElement(_XmlElement))
            Next

            Dim _NodoAux As New ClassProducto

            For i = 0 To ListaDeNodos.Count - 2
                For j = i + 1 To ListaDeNodos.Count - 1
                    If ListaDeNodos(i).Descripcion > ListaDeNodos(j).Descripcion Then
                        _NodoAux = ListaDeNodos(i)
                        ListaDeNodos(i) = ListaDeNodos(j)
                        ListaDeNodos(j) = _NodoAux
                    End If
                Next
            Next

            _XmlDocument.LoadXml("<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & "?><root></root>")

            _Child_Detalle = _XmlDocument.SelectSingleNode("root")

            For Each _Nodo In ListaDeNodos
                _Child_Detalle.InsertAfter(CrearXmlNodeProducto(_Nodo), _Child_Detalle.LastChild)
            Next

            _XmlDocument.Save(My.Settings._FileProductos)

        End If

    End Sub

    Public Shared Function CrearXmlNodeProducto(ByVal Nodo As ClassProducto) As XmlNode

        Dim _XmlDocument As New XmlDocument
        _XmlDocument.Load(My.Settings._FileProductos)

        Dim _XmlNodeProducto As XmlNode

        Dim XmlAttributeCodigo As XmlAttribute = _XmlDocument.CreateAttribute("Codigo")
        XmlAttributeCodigo.Value = Nodo.Codigo

        Dim XmlElementDescripcion As XmlElement = _XmlDocument.CreateElement("Descripcion")
        XmlElementDescripcion.InnerText = Nodo.Descripcion

        Dim XmlElementUnidad As XmlElement = _XmlDocument.CreateElement("Unidad")
        XmlElementUnidad.InnerText = Nodo.Unidad

        Dim XmlElementPrecio As XmlElement = _XmlDocument.CreateElement("Precio")
        XmlElementPrecio.InnerText = Nodo.Precio

        Dim XmlElementCantidad As XmlElement = _XmlDocument.CreateElement("Cantidad")
        XmlElementCantidad.InnerText = Nodo.Cantidad

        Dim XmlElementFecha As XmlElement = _XmlDocument.CreateElement("Fecha")
        XmlElementFecha.InnerText = Now.Year.ToString & Now.Month.ToString.PadLeft(2, "0") & Now.Day.ToString.PadLeft(2, "0")

        Try
            _XmlNodeProducto = _XmlDocument.CreateElement("Producto")
            With _XmlNodeProducto
                .Attributes.Append(XmlAttributeCodigo)
                .InsertAfter(XmlElementDescripcion, .LastChild)
                .InsertAfter(XmlElementUnidad, .LastChild)
                .InsertAfter(XmlElementPrecio, .LastChild)
                .InsertAfter(XmlElementCantidad, .LastChild)
                .InsertAfter(XmlElementFecha, .LastChild)
            End With

        Catch ex As Exception
            Throw
        End Try

        Return _XmlNodeProducto

    End Function

    Public Shared Function CrearDataTableProducto() As DataTable
        Return CrearDataTable("Codigo,Descripcion,Unidad,Precio,Cantidad,Fecha")
    End Function

End Class
