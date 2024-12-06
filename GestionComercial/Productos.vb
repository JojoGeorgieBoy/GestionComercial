Imports System.Xml
Public Class FormProductos

    Private _FileProductos As String = My.Settings._FileProductos
    Private _Child_Detalle As XmlElement
    Private _XmlDocument As XmlDocument
    Private _Separator As Char
    Private _DataRow As DataRow
    Private _HuboRegistroSeleccionado As Boolean
    Private _ObjectProducto As New ClassProducto
    Private _TextBox As System.Windows.Forms.TextBox
    Private _ComboBox As System.Windows.Forms.ComboBox
    Private _TipoLlenadoInputs As String
    Private _Controlar_TextChanged As Boolean


    Private Sub Productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.StartPosition = FormStartPosition.CenterParent

        _TextBox = New System.Windows.Forms.TextBox
        _ComboBox = New System.Windows.Forms.ComboBox

        TextBoxCodigoProducto.CharacterCasing = CharacterCasing.Upper
        TextBoxDescripcionProducto.CharacterCasing = CharacterCasing.Upper
        AddHandler ComboUnidadProducto.KeyPress, AddressOf Not_KeyPressed

        OcultarBotones(True)
        BloquearInputs(Me, True)

        Try
            If FileIO.FileSystem.FileExists(_FileProductos) Then
                PintarGrillaProductos(ClassProducto.PoblarDataTableProducto(ClassProducto.CrearDataTableProducto))
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error con datos")
            Me.Close()
        End Try

        _TipoLlenadoInputs = "Manual"

        _Controlar_TextChanged = True

    End Sub

    Private Sub OcultarBotones(ByVal _Valor As Boolean)

        Activar(ButtonDelete, False)
        Activar(ButtonClean, False)
        Activar(ButtonAdd, False)
        Activar(ButtonSave, False)

    End Sub


    Private Sub PintarGrillaProductos(ByVal _DataTable As DataTable)

        With DataGridViewProductos

            .DataSource = _DataTable
            .RowHeadersVisible = False
            .Columns("Codigo").Width = 150
            .Columns("Descripcion").Width = 350
            .Columns("Unidad").Width = 100
            .Columns("Precio").Width = 100
            .Columns("Precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").Width = 100
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Fecha").Width = 150
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            LayoutGrillaProductos(DataGridViewProductos)

            AddHandler .Click, AddressOf RescatarDatos
            AddHandler .Sorted, AddressOf BorrarProtagonismo

        End With

    End Sub

    Private Sub RescatarDatos()

        If DataGridViewProductos.Rows.Count > 0 Then

            If DataGridViewProductos.CurrentCell.Selected Then

                PoblarObjectProductoDesdeRowDeGrilla()

                PoblarInputsDesdeObjectProducto()

                BloquearInputs(Me, False)

                Activar(ButtonDelete, True)

            End If

        End If

    End Sub

    Private Sub PoblarObjectProductoDesdeRowDeGrilla()

        _ObjectProducto.Codigo = DataGridViewProductos.SelectedCells.Item(0).Value.ToString()
        _ObjectProducto.Descripcion = DataGridViewProductos.SelectedCells.Item(1).Value.ToString()
        _ObjectProducto.Unidad = DataGridViewProductos.SelectedCells.Item(2).Value.ToString()
        _ObjectProducto.Precio = DataGridViewProductos.SelectedCells.Item(3).Value.ToString()
        _ObjectProducto.Cantidad = DataGridViewProductos.SelectedCells.Item(4).Value.ToString()
        _ObjectProducto.Fecha = DataGridViewProductos.SelectedCells.Item(5).Value.ToString()

        Activar(ButtonSave, False)

    End Sub

    Private Sub PoblarInputsDesdeObjectProducto()
        'Me.Text = _TipoLlenadoInputs
        _Controlar_TextChanged = False
        'Me.Text = "Controlar_TextChanged = " & Controlar_TextChanged

        TextBoxCodigoProducto.Text = _ObjectProducto.Codigo
        TextBoxCodigoProducto.ReadOnly = True

        TextBoxDescripcionProducto.Text = _ObjectProducto.Descripcion
        ComboUnidadProducto.Text = _ObjectProducto.Unidad
        TextBoxPrecioProducto.Text = _ObjectProducto.Precio
        TextBoxCantidadProducto.Text = _ObjectProducto.Cantidad

        ButtonClean.Visible = True
        ButtonDelete.Visible = True

        _TipoLlenadoInputs = "Automatico"
        'Me.Text = _TipoLlenadoInputs
        _Controlar_TextChanged = True
        'Me.Text = "Controlar_TextChanged = " & Controlar_TextChanged

    End Sub

    Private Sub BorrarProtagonismo()
        Dim Grilla As DataGridView = DataGridViewProductos
        Try
            If Grilla.Rows.Count > 0 Then
                Grilla.CurrentCell.Selected = False
                LimpiarInputs()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub TextBoxPrecioProductoCompras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxPrecioProducto.KeyPress

        _Separator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(_Separator) Or Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        End If

    End Sub

    Private Sub TextBoxCantidadProductos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxCantidadProducto.KeyPress

        _Separator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(_Separator) Or Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        End If

    End Sub

    Private Sub ButtonAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAdd.Click
        InsercionActualizacion()
        BloquearInputs(Me, True)
        LimpiarInputs()
    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        InsercionActualizacion()
        BloquearInputs(Me, True)
        LimpiarInputs()
    End Sub

    Private Sub InsercionActualizacion()

        Dim _ObjectNodo As New ClassProducto
        PoblarObjectNodoDesdeInputs(_ObjectNodo)

        If Not ClassProducto.Actualizar(_ObjectNodo) Then

            _XmlDocument = New XmlDocument
            If FileIO.FileSystem.FileExists(_FileProductos) Then
                _XmlDocument.Load(_FileProductos)
            Else
                _XmlDocument.LoadXml("<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & "?><root></root>")
                _XmlDocument.Save(_FileProductos)
            End If

            _Child_Detalle = _XmlDocument.SelectSingleNode("root")
            _Child_Detalle.InsertAfter(CrearXmlNodeProducto(_ObjectNodo), _Child_Detalle.LastChild)

            _XmlDocument.Save(_FileProductos)

        End If

        BubbleSortProductos()
        PintarGrillaProductos(ClassProducto.PoblarDataTableProducto(ClassProducto.CrearDataTableProducto))

    End Sub

    Private Sub PoblarObjectNodoDesdeInputs(ByRef _ObjectNodo As ClassProducto)
        _ObjectNodo.Codigo = TextBoxCodigoProducto.Text
        _ObjectNodo.Descripcion = TextBoxDescripcionProducto.Text
        _ObjectNodo.Unidad = ComboUnidadProducto.Text
        _ObjectNodo.Precio = TextBoxPrecioProducto.Text.Replace(".", String.Empty)
        _ObjectNodo.Cantidad = TextBoxCantidadProducto.Text.Replace(".", String.Empty)
    End Sub

    Private Sub ButtonDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click

        If MsgBox("¿Está seguro de eliminar el producto?", MsgBoxStyle.OkCancel, "Confirme ELIMINAR") = 1 Then

            ClassProducto.Eliminar(TextBoxCodigoProducto.Text)
            PintarGrillaProductos(ClassProducto.PoblarDataTableProducto(ClassProducto.CrearDataTableProducto))
            BloquearInputs(Me, True)
            LimpiarInputs()

        End If

    End Sub

    Public Function CrearXmlNodeProducto(ByVal Nodo As ClassProducto) As XmlNode

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
        XmlElementFecha.InnerText = FechaHoy()

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

    Private Sub ButtonClean_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClean.Click

        BloquearInputs(Me, True)
        LimpiarInputs()

    End Sub

    Private Sub LimpiarInputs()

        TextBoxCodigoProducto.Text = String.Empty
        TextBoxCodigoProducto.ReadOnly = False
        TextBoxDescripcionProducto.Text = String.Empty
        ComboUnidadProducto.ResetText()
        TextBoxPrecioProducto.Text = String.Empty
        TextBoxCantidadProducto.Text = String.Empty

        If DataGridViewProductos.Rows.Count > 0 Then
            DataGridViewProductos.CurrentCell.Selected = False
        End If

        OcultarBotones(True)

        _TipoLlenadoInputs = "Manual"
        'Me.Text = _TipoLlenadoInputs

        TextBoxCodigoProducto.Focus()

    End Sub

    'Private Sub TextBoxCodigoProducto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxCodigoProducto.TextChanged

    '    If EncontrarCodigoenXML(TextBoxCodigoProducto.Text) Then
    '        PoblarInputsDesdeObjectProducto()
    '        _CodigoEncontrado = True
    '        _TipoLlenadoInputs = "Automatico"
    '    Else
    '        _CodigoEncontrado = False
    '        _TipoLlenadoInputs = "Manual"
    '    End If

    '    BloquearDesbloquearInputs(False)
    '    AgregarHandlerTextChanged()

    'End Sub

    'Private Sub AgregarHandlerTextChanged()
    '    AddHandler TextBoxCodigoProducto.TextChanged, AddressOf Control_Text_Changes
    '    AddHandler TextBoxDescripcionProductos.TextChanged, AddressOf Control_Text_Changes
    '    AddHandler ComboUnidadProductos.TextChanged, AddressOf Control_Text_Changes
    '    AddHandler TextBoxPrecioProductos.TextChanged, AddressOf Control_Text_Changes
    '    AddHandler TextBoxCantidadProductos.TextChanged, AddressOf Control_Text_Changes
    'End Sub

    'Private Sub QuitarHandlerTextChanged()
    '    RemoveHandler TextBoxCodigoProducto.TextChanged, AddressOf Control_Text_Changes
    '    RemoveHandler TextBoxDescripcionProductos.TextChanged, AddressOf Control_Text_Changes
    '    RemoveHandler ComboUnidadProductos.TextChanged, AddressOf Control_Text_Changes
    '    RemoveHandler TextBoxPrecioProductos.TextChanged, AddressOf Control_Text_Changes
    '    RemoveHandler TextBoxCantidadProductos.TextChanged, AddressOf Control_Text_Changes
    'End Sub

    Private Sub TextBoxPrecioProductos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxPrecioProducto.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            InsercionActualizacion()
            e.Handled = True
        End If
    End Sub

    'Private Sub CompararEstadoProducto(ByVal _Input As Object)

    '    Select Case _Input.name

    '        Case "TextBoxCodigoProducto"
    '            If TextBoxCodigoProducto.Text <> _ObjectProducto.Codigo Then
    '                If TodosTienenDatos() Then
    '                    HabilitarButtonInsertUpdate()
    '                Else
    '                    ButtonInsertUpdate.Visible = False
    '                End If
    '            Else
    '                ButtonInsertUpdate.Visible = True
    '            End If
    '        Case "TextBoxDescripcionProductos"
    '            If TextBoxDescripcionProductos.Text <> _ObjectProducto.Descripcion Then
    '                If TodosTienenDatos() Then
    '                    HabilitarButtonInsertUpdate()
    '                Else
    '                    ButtonInsertUpdate.Visible = False
    '                End If
    '            Else
    '                ButtonInsertUpdate.Visible = True
    '            End If
    '        Case "ComboUnidadProductos"
    '            If ComboUnidadProductos.Text <> _ObjectProducto.Unidad Then
    '                If TodosTienenDatos() Then
    '                    HabilitarButtonInsertUpdate()
    '                Else
    '                    ButtonInsertUpdate.Visible = False
    '                End If
    '            Else
    '                ButtonInsertUpdate.Visible = True
    '            End If
    '        Case "TextBoxPrecioProductos"
    '            If TextBoxPrecioProductos.Text.Replace(".", String.Empty) <> _ObjectProducto.Precio.Replace(".", String.Empty) Then
    '                If TodosTienenDatos() Then
    '                    HabilitarButtonInsertUpdate()
    '                Else
    '                    ButtonInsertUpdate.Visible = False
    '                End If
    '            Else
    '                ButtonInsertUpdate.Visible = True
    '            End If
    '        Case "TextBoxCantidadProductos"
    '            If TextBoxCantidadProductos.Text.Replace(".", String.Empty) <> _ObjectProducto.Cantidad.Replace(".", String.Empty) Then
    '                If TodosTienenDatos() Then
    '                    HabilitarButtonInsertUpdate()
    '                Else
    '                    ButtonInsertUpdate.Visible = False
    '                End If
    '            Else
    '                ButtonInsertUpdate.Visible = True
    '            End If
    '    End Select

    'End Sub

    Private Function TodosTienenDatos() As Boolean

        For Each _Control As System.Windows.Forms.Control In Me.Controls

            If _Control.GetType.ToString = "System.Windows.Forms.TextBox" Then
                _TextBox = _Control
                If _TextBox.Text = String.Empty Then
                    Return False
                End If
            Else
                If _Control.GetType.ToString = "System.Windows.Forms.ComboBox" Then
                    _ComboBox = _Control
                    If _ComboBox.Text = String.Empty Then
                        Return False
                    End If
                End If
            End If

        Next

        Return True

    End Function

    Private Sub BubbleSortProductos()

        _XmlDocument = New XmlDocument
        _XmlDocument.Load(_FileProductos)

        If _XmlDocument.SelectSingleNode("root").ChildNodes.Count > 1 Then

            Dim ListaDeNodos As New List(Of ClassProducto)
            For Each _XmlElement As XmlElement In _XmlDocument.SelectSingleNode("root").ChildNodes
                ListaDeNodos.Add(CreaNodoDesdeXmlElement(_XmlElement))
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
            _XmlDocument.Save(_FileProductos)

        End If

    End Sub

    Private Function CreaNodoDesdeXmlElement(ByVal _XmlElementPadre As Xml.XmlElement) As ClassProducto
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

    Private Sub TextBoxCodigoProducto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxCodigoProducto.TextChanged

        If _TipoLlenadoInputs = "Manual" Then

            If ClassProducto.EncontrarCodigoenXML(TextBoxCodigoProducto.Text, True, _ObjectProducto) Then

                PoblarInputsDesdeObjectProducto()

                ButtonDelete.Visible = True
                ButtonClean.Visible = True

            End If

            BloquearInputs(Me, False)
            Activar(ButtonClean, True)

        End If

    End Sub

    Private Sub ComboUnidadProductos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboUnidadProducto.SelectedIndexChanged
        'Me.Text = _TipoLlenadoInputs
        'Me.Text = "Controlar_TextChanged = " & Controlar_TextChanged
        If _Controlar_TextChanged = True Then
            If _TipoLlenadoInputs = "Automatico" Then
                If ComboUnidadProducto.Text <> _ObjectProducto.Unidad Then
                    If TodosTienenDatos() Then
                        Activar(ButtonAdd, False)
                        Activar(ButtonSave, True)
                    Else
                        Activar(ButtonAdd, False)
                    End If
                Else
                    Activar(ButtonAdd, False)
                End If
            Else
                If TodosTienenDatos() Then
                    Activar(ButtonAdd, True)
                    Activar(ButtonSave, False)
                Else
                    Activar(ButtonAdd, False)
                End If
            End If
        End If
    End Sub

    Private Sub TextBoxDescripcionProducto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxDescripcionProducto.TextChanged
        'Me.Text = _TipoLlenadoInputs
        'Me.Text = "Controlar_TextChanged = " & Controlar_TextChanged
        If _Controlar_TextChanged = True Then
            If _TipoLlenadoInputs = "Automatico" Then
                If TextBoxDescripcionProducto.Text <> _ObjectProducto.Descripcion Then
                    If TodosTienenDatos() Then
                        Activar(ButtonAdd, False)
                        Activar(ButtonSave, True)
                    Else
                        Activar(ButtonAdd, False)
                    End If
                Else
                    Activar(ButtonAdd, False)
                End If
            Else
                If TodosTienenDatos() Then
                    Activar(ButtonAdd, True)
                    Activar(ButtonSave, False)
                Else
                    Activar(ButtonAdd, False)
                End If
            End If
        End If
    End Sub

    Private Sub TextBoxPrecioProducto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxPrecioProducto.TextChanged
        'Me.Text = _TipoLlenadoInputs
        'Me.Text = "Controlar_TextChanged = " & Controlar_TextChanged
        If _Controlar_TextChanged = True Then
            If _TipoLlenadoInputs = "Automatico" Then
                If TextBoxPrecioProducto.Text.Replace(".", String.Empty) <> _ObjectProducto.Precio.Replace(".", String.Empty) Then
                    If TodosTienenDatos() Then
                        Activar(ButtonAdd, False)
                        Activar(ButtonSave, True)
                    Else
                        Activar(ButtonAdd, False)
                    End If
                Else
                    Activar(ButtonAdd, False)
                End If
            Else
                If TodosTienenDatos() Then
                    Activar(ButtonAdd, True)
                    Activar(ButtonSave, False)
                Else
                    Activar(ButtonAdd, False)
                End If
            End If
        End If
    End Sub

    Private Sub TextBoxCantidadProducto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxCantidadProducto.TextChanged
        'Me.Text = _TipoLlenadoInputs
        'Me.Text = "Controlar_TextChanged = " & Controlar_TextChanged
        If _Controlar_TextChanged = True Then
            If _TipoLlenadoInputs = "Automatico" Then
                If TextBoxCantidadProducto.Text.Replace(".", String.Empty) <> _ObjectProducto.Cantidad.Replace(".", String.Empty) Then
                    If TodosTienenDatos() Then
                        Activar(ButtonAdd, False)
                        Activar(ButtonSave, True)
                    Else
                        Activar(ButtonAdd, False)
                    End If
                Else
                    Activar(ButtonAdd, False)
                End If
            Else
                If TodosTienenDatos() Then
                    Activar(ButtonAdd, True)
                    Activar(ButtonSave, False)
                Else
                    Activar(ButtonAdd, False)
                End If
            End If
        End If
    End Sub

#Region "Handlers"
    Private Sub ComboUnidadProductos_KeyPressed(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles ComboUnidadProducto.KeyPress
        e.KeyChar = Nothing
    End Sub
#End Region

End Class
