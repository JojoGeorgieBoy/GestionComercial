Imports System.Xml
Public Class ClassVenta

#Region "VariablesInternas"
    Private _FOLIO As String
    Private _FECHA As String
    Private _HORA As String
    Private Shared _NombreArchivoVentas As String = My.Settings._FileVentas & Now.Year.ToString & Now.Month.ToString.PadLeft(2, "0") & Now.Day.ToString.PadLeft(2, "0") & ".xml"
#End Region

#Region "Properties"

    Public Property Folio() As String
        Get
            Return _FOLIO
        End Get
        Set(ByVal value As String)
            _FOLIO = value
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

    Public Property Hora() As String
        Get
            Return _HORA
        End Get
        Set(ByVal value As String)
            _HORA = value
        End Set
    End Property

    Public Shared ReadOnly Property NombreArchivoVentas() As String
        Get
            Return _NombreArchivoVentas
        End Get
    End Property

#End Region

#Region "Functions"

    Public Shared Function EncontrarFolioenXML(ByVal _Folio As String, ByVal _PoblarObjectVenta As Boolean, ByRef _ObjectVenta As ClassVenta) As Boolean

        Dim _XmlDocument As New XmlDocument
        _XmlDocument.Load(NombreArchivoVentas())

        For Each _XmlElementPadre As XmlElement In _XmlDocument.SelectSingleNode("root").ChildNodes

            If _XmlElementPadre.Attributes.GetNamedItem("Folio").Value = _Folio Then

                If _PoblarObjectVenta Then

                    _ObjectVenta.Folio = _XmlElementPadre.Attributes.GetNamedItem("_Folio").Value

                    For Each _XmlElementHijo As XmlElement In _XmlElementPadre.ChildNodes
                        'If _XmlElementHijo.Name = "Codigo" Then
                        '    _ObjectVenta.Codigo = _XmlElementHijo.InnerText
                        'End If
                        'If _XmlElementHijo.Name = "Descripcion" Then
                        '    _ObjectVenta.Descripcion = _XmlElementHijo.InnerText
                        'End If
                        'If _XmlElementHijo.Name = "Unidad" Then
                        '    _ObjectVenta.Unidad = _XmlElementHijo.InnerText
                        'End If
                        'If _XmlElementHijo.Name = "Cantidad" Then
                        '    _ObjectVenta.Cantidad = _XmlElementHijo.InnerText
                        'End If
                        'If _XmlElementHijo.Name = "Precio" Then
                        '    _ObjectVenta.Precio = _XmlElementHijo.InnerText
                        'End If
                        If _XmlElementHijo.Name = "Fecha" Then
                            _ObjectVenta.Fecha = _XmlElementHijo.InnerText
                        End If
                        If _XmlElementHijo.Name = "Hora" Then
                            _ObjectVenta.Hora = _XmlElementHijo.InnerText
                        End If
                    Next

                End If

                Return True

            End If

        Next

        Return False

    End Function

    Public Shared Function PoblarDataTableVenta(ByRef _DataTable As DataTable) As DataTable

        Dim _ObjNodo As New ClassVenta

        Dim _XmlDocument As New XmlDocument
        _XmlDocument.Load(NombreArchivoVentas())

        For Each _XmlElementPadre As XmlElement In _XmlDocument.SelectSingleNode("root").ChildNodes

            _ObjNodo.Folio = _XmlElementPadre.Attributes.GetNamedItem("Folio").Value

            For Each _XmlElementHijo As XmlElement In _XmlElementPadre.ChildNodes

                Select Case _XmlElementHijo.Name
                    'Case "Codigo"
                    '    _ObjNodo.Codigo = _XmlElementHijo.InnerText
                    'Case "Descripcion"
                    '    _ObjNodo.Descripcion = _XmlElementHijo.InnerText
                    'Case "Unidad"
                    '    _ObjNodo.Unidad = _XmlElementHijo.InnerText
                    'Case "Cantidad"
                    '    _ObjNodo.Cantidad = _XmlElementHijo.InnerText
                    'Case "Precio"
                    '    _ObjNodo.Precio = _XmlElementHijo.InnerText
                    Case "Fecha"
                        _ObjNodo.Fecha = Convierte_a_fecha(_XmlElementHijo.InnerText)
                    Case "Hora"
                        _ObjNodo.Hora = Convierte_a_hora(_XmlElementHijo.InnerText)

                End Select

            Next

            With _DataTable
                '.Rows.Add(_ObjNodo.Folio, _ObjNodo.Codigo, _ObjNodo.Descripcion, _ObjNodo.Unidad, CInt(_ObjNodo.Cantidad).ToString("###,###,###,###."), CInt(_ObjNodo.Precio).ToString("###,###,###,###."), _ObjNodo.Fecha, _ObjNodo.Hora)
            End With

        Next

        Return _DataTable

    End Function

    Public Shared Function Actualizar(ByVal _ObjectNodo As ClassVenta) As Boolean

        Dim NodoEncontrado As Boolean = False

        Dim _XmlDocument As New XmlDocument

        If FileIO.FileSystem.FileExists(NombreArchivoVentas()) Then
            _XmlDocument.Load(NombreArchivoVentas())
        Else
            _XmlDocument.LoadXml("<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & "?><root></root>")
            _XmlDocument.Save(NombreArchivoVentas())
        End If

        For Each _XmlElementPadre As XmlElement In _XmlDocument.SelectSingleNode("root").ChildNodes

            If _XmlElementPadre.Attributes.GetNamedItem("Folio").Value = _ObjectNodo.Folio Then

                For Each _XmlElementHijo As XmlElement In _XmlElementPadre.ChildNodes

                    'If _XmlElementHijo.Name = "Codigo" Then
                    '    _XmlElementHijo.InnerText = _ObjectNodo.Codigo
                    'End If
                    'If _XmlElementHijo.Name = "Descripcion" Then
                    '    _XmlElementHijo.InnerText = _ObjectNodo.Descripcion
                    'End If
                    'If _XmlElementHijo.Name = "Unidad" Then
                    '    _XmlElementHijo.InnerText = _ObjectNodo.Unidad
                    'End If
                    'If _XmlElementHijo.Name = "Cantidad" Then
                    '    _XmlElementHijo.InnerText = _ObjectNodo.Cantidad
                    'End If
                    'If _XmlElementHijo.Name = "Precio" Then
                    '    _XmlElementHijo.InnerText = _ObjectNodo.Precio
                    'End If
                    If _XmlElementHijo.Name = "Fecha" Then
                        _XmlElementHijo.InnerText = FechaHoy()
                    End If
                    If _XmlElementHijo.Name = "Hora" Then
                        _XmlElementHijo.InnerText = HoraAhora()
                    End If
                Next

                NodoEncontrado = True

                _XmlDocument.Save(My.Settings._FileVentas)

                Exit For

            End If

        Next

        Return NodoEncontrado

    End Function

    Public Shared Sub Eliminar(ByVal _Folio As String)
        Dim _XmlDocument As New XmlDocument
        _XmlDocument.Load(My.Settings._FileVentas)
        For Each _XmlElement As XmlElement In _XmlDocument.SelectSingleNode("root").ChildNodes
            If _XmlElement.Attributes.GetNamedItem("Folio").Value = _Folio Then
                _XmlElement.ParentNode.RemoveChild(_XmlElement)
                Exit For
            End If
        Next
        _XmlDocument.Save(My.Settings._FileVentas)
    End Sub

    Private Sub ActualizarNodo(ByRef _XmlDocument As XmlDocument, ByVal _ObjectVenta As ClassVenta)

        For Each _XmlElementPadre As XmlElement In _XmlDocument.SelectSingleNode("root").ChildNodes

            'If _XmlElementPadre.Attributes.GetNamedItem("Codigo").Value = _ObjectVenta.Codigo Then

            '    For Each _XmlElementHijo As XmlElement In _XmlElementPadre.ChildNodes
            '        If _XmlElementHijo.Name = "Descripcion" Then
            '            _XmlElementHijo.InnerText = _ObjectVenta.Descripcion
            '        End If
            '        If _XmlElementHijo.Name = "Precio" Then
            '            _XmlElementHijo.InnerText = _ObjectVenta.Precio
            '        End If
            '        If _XmlElementHijo.Name = "Unidad" Then
            '            _XmlElementHijo.InnerText = _ObjectVenta.Unidad
            '        End If
            '        If _XmlElementHijo.Name = "Cantidad" Then
            '            _XmlElementHijo.InnerText = _ObjectVenta.Cantidad
            '        End If
            '    Next

            '    Exit For

            'End If

        Next

    End Sub

    Public Shared Function CreaNodoDesdeXmlElement(ByVal _XmlElementPadre As Xml.XmlElement) As ClassVenta

        Dim _NodoVenta As New ClassVenta

        _NodoVenta.Folio = _XmlElementPadre.Attributes.GetNamedItem("Folio").Value

        For Each _XmlElementHijo As XmlElement In _XmlElementPadre.ChildNodes

            Select Case _XmlElementHijo.Name

                'Case "Codigo"
                '    _NodoVenta.Codigo = _XmlElementHijo.InnerText
                'Case "Descripcion"
                '    _NodoVenta.Descripcion = _XmlElementHijo.InnerText
                'Case "Unidad"
                '    _NodoVenta.Unidad = _XmlElementHijo.InnerText
                'Case "Cantidad"
                '    _NodoVenta.Cantidad = _XmlElementHijo.InnerText
                'Case "Precio"
                '    _NodoVenta.Precio = _XmlElementHijo.InnerText
                Case "Fecha"
                    _NodoVenta.Fecha = _XmlElementHijo.InnerText
                Case "Hora"
                    _NodoVenta.Hora = _XmlElementHijo.InnerText
            End Select

        Next

        Return _NodoVenta

    End Function

    Public Shared Sub BubbleSortVentas()

        Dim _XmlDocument As New XmlDocument

        _XmlDocument.Load(My.Settings._FileVentas)

        If _XmlDocument.SelectSingleNode("root").ChildNodes.Count > 1 Then

            Dim _Child_Detalle As XmlElement

            Dim ListaDeNodos As New List(Of ClassVenta)

            For Each _XmlElement As XmlElement In _XmlDocument.SelectSingleNode("root").ChildNodes
                ListaDeNodos.Add(ClassVenta.CreaNodoDesdeXmlElement(_XmlElement))
            Next

            Dim _NodoAux As New ClassVenta

            For i = 0 To ListaDeNodos.Count - 2
                For j = i + 1 To ListaDeNodos.Count - 1
                    If ListaDeNodos(i).Folio > ListaDeNodos(j).Folio Then
                        _NodoAux = ListaDeNodos(i)
                        ListaDeNodos(i) = ListaDeNodos(j)
                        ListaDeNodos(j) = _NodoAux
                    End If
                Next
            Next

            _XmlDocument.LoadXml("<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & "?><root></root>")

            _Child_Detalle = _XmlDocument.SelectSingleNode("root")

            For Each _Nodo In ListaDeNodos
                '_Child_Detalle.InsertAfter(CrearXmlNodeVenta(_Nodo), _Child_Detalle.LastChild)
            Next

            _XmlDocument.Save(My.Settings._FileVentas)

        End If

    End Sub

    Public Shared Function GrabarVenta(ByVal _DataTable As DataTable, ByVal _Folio As String) As Long

        Dim _XmlDocument As New XmlDocument

        If FileIO.FileSystem.FileExists(NombreArchivoVentas()) Then
            _XmlDocument.Load(NombreArchivoVentas())
        Else
            _XmlDocument.LoadXml("<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & "?><root></root>")
            _XmlDocument.Save(NombreArchivoVentas())
        End If

        Dim _XmlElementRoot As XmlElement = _XmlDocument.SelectSingleNode("root")

        Dim _Sumador As Long = 0
        Dim _Contador As Long = 0

        Dim _XmlNodeVenta As XmlNode = _XmlDocument.CreateElement("Venta")

        Try

            For Each _Row As System.Data.DataRow In _DataTable.Rows

                Dim _ObjectItemVenta As New ClassItemVenta

                With _ObjectItemVenta

                    .Codigo = _Row.Item("Codigo")
                    .Descripcion = _Row.Item("Descripcion")
                    .Unidad = _Row.Item("Unidad")
                    .Precio = _Row.Item("Precio")
                    .Cantidad = _Row.Item("Cantidad")
                    _Sumador += CInt(_Row.Item("Precio")) * CInt(_Row.Item("Cantidad"))

                    _Contador += 1

                    _ObjectItemVenta.InsertarItemVenta(_ObjectItemVenta, _XmlDocument, _XmlNodeVenta, _Contador)

                End With

            Next

        Catch ex As Exception
            Return 0
        End Try

        Dim XmlAttributeTotal As XmlAttribute = _XmlDocument.CreateAttribute("Total")
        _XmlNodeVenta.Attributes.Append(XmlAttributeTotal)
        XmlAttributeTotal.Value = _Sumador

        Dim XmlAttributeHora As XmlAttribute = _XmlDocument.CreateAttribute("Hora")
        _XmlNodeVenta.Attributes.Append(XmlAttributeHora)
        XmlAttributeHora.Value = HoraAhora()

        Dim XmlAttributeFolio As XmlAttribute = _XmlDocument.CreateAttribute("Folio")
        _XmlNodeVenta.Attributes.Append(XmlAttributeFolio)
        XmlAttributeFolio.Value = _Folio

        _XmlElementRoot.InsertAfter(_XmlNodeVenta, _XmlElementRoot.LastChild)

        _XmlDocument.Save(NombreArchivoVentas())

        Return _Sumador

    End Function

    Public Shared Function CrearDataTableVentas() As DataTable
        Return CrearDataTable("Codigo,Descripcion,Unidad,Precio,Cantidad,Total_Item")
    End Function

#End Region

End Class