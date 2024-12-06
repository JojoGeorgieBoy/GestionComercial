Imports System.Xml
Public Class FormVentas

    Private _FileProductos As String = My.Settings._FileProductos
    Private _XmlDocument As XmlDocument
    Private _ObjectVenta As New ClassVenta
    Private _ObjectItemVenta As New ClassItemVenta
    Private _ObjectProducto As New ClassProducto
    Private _DataSet As DataSet
    Private _DataRow As DataRow
    Private _DataTableVenta As DataTable
    Private _Total As Decimal
    Private _TipoLlenadoInputs As String
    Private _Folio As String
    Private _PxQ As Decimal
    Private _Encontrado As Boolean
    Private _DataGridViewProductos As New DataGridView
    Private _DataTableProductos As New DataTable
    Private _ButtonCerrarGrilla As New Button

    Private Sub Ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CrearGrillaProductos()
        CrearButtonCerrarGrilla()

        IniciarForm()

    End Sub

    Private Sub IniciarForm()

        Me.StartPosition = FormStartPosition.CenterParent

        InicializarInputsVentas(Me, String.Empty)
        TextBoxCodigo.ReadOnly = False

        TextBoxCodigo.CharacterCasing = CharacterCasing.Upper
        TextBoxDescripcion.CharacterCasing = CharacterCasing.Upper
        TextBoxTotal.TextAlign = HorizontalAlignment.Right
        TextBoxTotal.Text = 0  'Format(0, "C")

        AddHandler TextBoxUnidad.KeyPress, AddressOf Not_KeyPressed
        AddHandler TextBoxDescripcion.KeyPress, AddressOf Not_KeyPressed
        AddHandler TextBoxPrecio.KeyPress, AddressOf Not_KeyPressed

        Try
            _Folio = ObtenerFolio()
            'Me.Text = "Folio: " & _Folio
            _XmlDocument = New XmlDocument
            _XmlDocument.Load(_FileProductos)

        Catch ex As Exception
            MsgBox("Problemas al cargar archivo", MsgBoxStyle.SystemModal, "Error")
            Me.Close()
        End Try

        _DataTableVenta = ClassVenta.CrearDataTableVentas()

        AddHandler DataGridViewItemsVentas.Click, AddressOf RescatarDatosVentas

        _Total = 0
        _TipoLlenadoInputs = "Manual"
        'Me.Text = "_TipoLlenadoInputs: " & _TipoLlenadoInputs

    End Sub

    Private Sub BloquearControlesDatosRecuperados(ByVal DatosRecuperados As Boolean)
        For Each _Control As Windows.Forms.Control In Me.Controls
            If TypeOf (_Control) Is TextBox Then
                Dim _TextBox As TextBox = _Control
                If DatosRecuperados Then
                    If _Control.Name = "TextBoxCodigo" Or _Control.Name = "TextBoxCantidad" Then
                        _TextBox.ReadOnly = Not DatosRecuperados
                    Else
                        _TextBox.ReadOnly = DatosRecuperados
                    End If
                Else
                    If _Control.Name = "TextBoxCantidad" Then
                        _TextBox.ReadOnly = Not DatosRecuperados
                    Else
                        _TextBox.ReadOnly = DatosRecuperados
                    End If
                    _Control.Text = String.Empty
                End If
            End If
        Next
    End Sub

    Sub CrearGrillaProductos()
        'Creación de grilla de productos (que servirá de apoyo con info de los productos durante la venta)
        LayoutGrillaComun(_DataGridViewProductos)
        _DataGridViewProductos.DataSource = ClassProducto.PoblarDataTableProducto(ClassVenta.CrearDataTableVentas)
        AddHandler _DataGridViewProductos.Click, AddressOf RescatarDatosDataGridViewProductos
        AddHandler _DataGridViewProductos.Sorted, AddressOf AnularSelectedDataGridViewProductos
    End Sub

    Sub CrearButtonCerrarGrilla()
        _ButtonCerrarGrilla.BackColor = System.Drawing.Color.Red
        _ButtonCerrarGrilla.ForeColor = System.Drawing.Color.White
        _ButtonCerrarGrilla.Text = "Cerrar grilla"
        _ButtonCerrarGrilla.Size = New Size(115, 33)
        _ButtonCerrarGrilla.Location = New Point(435, 476)
        AddHandler _ButtonCerrarGrilla.Click, AddressOf CerrarGrillaProductos
    End Sub


    Private Sub TextBoxCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxCodigo.TextChanged

        If TextBoxCodigo.Text <> String.Empty Then
            If _TipoLlenadoInputs = "Manual" Then
                If ClassProducto.EncontrarCodigoenXML(TextBoxCodigo.Text, True, _ObjectProducto) Then
                    PoblarInputsVentasDesdeObjectProducto(_ObjectProducto)
                    Activar(ButtonClean, True)
                End If
            End If
        End If

    End Sub

    Private Sub TextBoxCodigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxCodigo.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextBoxCodigo.Text.Trim = String.Empty Then
                DesplegarGrillaProductos()
            End If
        End If
    End Sub


    Private Sub PoblarInputsVentasDesdeObjectProducto(ByVal Objetoproducto As ClassProducto)

        TextBoxDescripcion.Text = Objetoproducto.Descripcion
        TextBoxUnidad.Text = Objetoproducto.Unidad
        TextBoxPrecio.Text = Format(CInt(Objetoproducto.Precio), "##,##0")

        BloquearControlesDatosRecuperados(True)
        TextBoxCantidad.ReadOnly = False
        TextBoxCantidad.Focus()

    End Sub

    Private Sub ButtonInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAdd.Click

        AgregarItem()

    End Sub

    Private Sub AgregarItem()

        For Each _Control As Windows.Forms.Control In Me.Controls
            If TypeOf (_Control) Is TextBox Then
                If _Control.Name <> "TextBoxTotal" Then
                    If _Control.Text.Trim = String.Empty Then
                        MsgBox("Falta completar datos del campo: " & _Control.Name.Replace("TextBox", String.Empty), MsgBoxStyle.Exclamation, "Debe llenar todos los inputs")
                        _Control.Focus()
                        Exit Sub
                    End If
                    If _Control.Name = "TextBoxCantidad" Then
                        If CInt(_Control.Text) > 100000 Then
                            MsgBox("Valor del campo: " & _Control.Name.Replace("TextBox", String.Empty) & " excede cantidad lógica de venta", MsgBoxStyle.Exclamation, "Exceso en cantidad de venta")
                            _Control.Text = String.Empty
                            Exit Sub
                        End If
                    End If
                End If
            End If
        Next

        _PxQ = CInt(TextBoxPrecio.Text) * CDec(TextBoxCantidad.Text)

        With _DataTableVenta
            If .Rows.Count > 0 Then
                _Encontrado = False
                For Each _Row As System.Data.DataRow In .Rows
                    If TextBoxCodigo.Text = _Row.Item("Codigo") Then
                        _Encontrado = True
                        _Row.Item("Cantidad") = TextBoxCantidad.Text
                        _Row.Item("Total_Item") = _PxQ
                        Exit For
                    End If
                Next
                If Not _Encontrado Then
                    '.Rows.Add(_Folio, TextBoxCodigo.Text, TextBoxDescripcion.Text, TextBoxUnidad.Text, TextBoxCantidad.Text, TextBoxPrecio.Text, _PxQ, FechaHoy(), HoraAhora())
                    .Rows.Add(TextBoxCodigo.Text, TextBoxDescripcion.Text, TextBoxUnidad.Text, TextBoxPrecio.Text, TextBoxCantidad.Text, _PxQ)
                End If
            Else
                '.Rows.Add(_Folio, TextBoxCodigo.Text, TextBoxDescripcion.Text, TextBoxUnidad.Text, TextBoxCantidad.Text, TextBoxPrecio.Text, _PxQ, FechaHoy(), HoraAhora())
                .Rows.Add(TextBoxCodigo.Text, TextBoxDescripcion.Text, TextBoxUnidad.Text, TextBoxPrecio.Text, TextBoxCantidad.Text, _PxQ)
                TextBoxTotal.ReadOnly = False
            End If
        End With

        DataGridViewItemsVentas.DataSource = _DataTableVenta
        LayoutGrillaItemsVentas(DataGridViewItemsVentas)

        TextBoxTotal.Text = TotalizarGrilla(DataGridViewItemsVentas).ToString("N0")

        InicializarInputsVentas(Me, "TextBoxTotal")

        Activar(ButtonSave, True)
        TextBoxCodigo.ReadOnly = False
        TextBoxCodigo.Focus()

        _TipoLlenadoInputs = "Manual"
        'Me.Text = "_TipoLlenadoInputs: " & _TipoLlenadoInputs

    End Sub

    Private Sub LimpiarForm()

        TextBoxCodigo.Text = String.Empty
        TextBoxDescripcion.Text = String.Empty
        TextBoxUnidad.Text = String.Empty
        TextBoxPrecio.Text = String.Empty
        TextBoxCantidad.Text = String.Empty

        TextBoxCodigo.Focus()

        If _TipoLlenadoInputs = "Manual" Then

        End If

    End Sub

    Private Sub RescatarDatosVentas()

        If DataGridViewItemsVentas.Rows.Count > 0 Then

            If DataGridViewItemsVentas.CurrentCell.Selected Then

                _TipoLlenadoInputs = "Automatico"
                'Me.Text = "_TipoLlenadoInputs: " & _TipoLlenadoInputs

                PoblarObjectProductoDesdeRowEnDataGridViewItemsVentas()

                PoblarInputsDesdeObjectProducto()

                Activar(ButtonDelete, True)
                Activar(ButtonClean, True)

                TextBoxCantidad.Focus()

            End If

        End If

    End Sub

    Private Sub PoblarObjectProductoDesdeRowEnDataGridViewItemsVentas()

        _ObjectItemVenta.Codigo = DataGridViewItemsVentas.SelectedCells.Item(0).Value.ToString()
        _ObjectItemVenta.Descripcion = DataGridViewItemsVentas.SelectedCells.Item(1).Value.ToString()
        _ObjectItemVenta.Unidad = DataGridViewItemsVentas.SelectedCells.Item(2).Value.ToString()
        _ObjectItemVenta.Precio = DataGridViewItemsVentas.SelectedCells.Item(3).Value.ToString()
        _ObjectItemVenta.Cantidad = DataGridViewItemsVentas.SelectedCells.Item(4).Value.ToString()
        _ObjectItemVenta.Total_Item = DataGridViewItemsVentas.SelectedCells.Item(5).Value.ToString()

    End Sub

    Private Sub PoblarInputsDesdeObjectProducto()

        TextBoxCodigo.Text = _ObjectItemVenta.Codigo
        TextBoxCodigo.ReadOnly = True

        TextBoxDescripcion.Text = _ObjectItemVenta.Descripcion
        TextBoxUnidad.Text = _ObjectItemVenta.Unidad
        TextBoxPrecio.Text = _ObjectItemVenta.Precio
        TextBoxCantidad.Text = String.Empty
        TextBoxCantidad.ReadOnly = False

    End Sub

    Private Sub ButtonClean_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClean.Click

        InicializarInputsVentas(Me, "TextBoxTotal")
        If DataGridViewItemsVentas.Rows.Count > 0 Then
            DataGridViewItemsVentas.CurrentCell.Selected = False
            Activar(ButtonSave, True)
        End If

        _TipoLlenadoInputs = "Manual"
        'Me.Text = "_TipoLlenadoInputs: " & _TipoLlenadoInputs

        TextBoxCodigo.ReadOnly = False
        TextBoxCodigo.Focus()

    End Sub

    Private Sub TextBoxCantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxCantidad.TextChanged
        'Me.Text = "_TipoLlenadoInputs: " & _TipoLlenadoInputs
        If TextBoxCodigo.Text.Trim <> String.Empty Then
            If TextBoxCantidad.Text.Trim <> String.Empty Then
                If TextBoxCantidad.Text > 0 Then
                    Activar(ButtonDelete, False)
                    Activar(ButtonAdd, True)
                Else
                    Activar(ButtonAdd, False)
                End If
            Else
                Activar(ButtonAdd, False)
            End If
        End If
    End Sub

    Private Sub TextBoxCantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxCantidad.KeyPress
        Dim _Separator As Char = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(_Separator) Or Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            AgregarItem()
        End If
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click

        For Each _Row As DataRow In _DataTableVenta.Rows
            If TextBoxCodigo.Text = _Row.Item("Codigo") Then

                _Row.Delete()
                'DataGridViewVentas.Refresh()
                InicializarInputsVentas(Me, "TextBoxCodigo")

                LayoutGrillaItemsVentas(DataGridViewItemsVentas)
                If DataGridViewItemsVentas.Rows.Count > 0 Then
                    DataGridViewItemsVentas.CurrentCell.Selected = False
                End If
                TextBoxTotal.Text = TotalizarGrilla(DataGridViewItemsVentas).ToString("N0")

                'InicializarInputsVentas(Me, "TextBoxCodigo")

                If DataGridViewItemsVentas.RowCount > 0 Then
                    DataGridViewItemsVentas.CurrentCell.Selected = False
                    Activar(ButtonSave, True)
                    'Else
                    '    InicializarInputsVentas(Me, "TextBoxCodigo")
                End If

                _TipoLlenadoInputs = "Manual"
                'Me.Text = "_TipoLlenadoInputs: " & _TipoLlenadoInputs

                TextBoxCodigo.Text = String.Empty
                TextBoxCodigo.ReadOnly = False
                TextBoxCodigo.Focus()

                Exit For

            End If
        Next

    End Sub

    Private Sub ReiniciarForm()

        InicializarInputsVentas(Me, String.Empty)
        TextBoxCodigo.ReadOnly = False
        TextBoxCodigo.Focus()

        TextBoxTotal.Text = 0  'Format(0, "C")

        Try
            _Folio = ObtenerFolio()
            'Me.Text = "Folio: " & _Folio

        Catch ex As Exception
            MsgBox("Problemas al cargar archivo", MsgBoxStyle.SystemModal, "Error")
            Me.Close()
        End Try

        _DataTableVenta = ClassVenta.CrearDataTableVentas

        DataGridViewItemsVentas.DataSource = Nothing

        _Total = 0
        _TipoLlenadoInputs = "Manual"

    End Sub

    Private Sub ButtonGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click

        Dim _ValorVenta As Long = ClassVenta.GrabarVenta(_DataTableVenta, _Folio)

        If _ValorVenta > 0 Then
            IncrementarFolio()
            'MsgBox("Venta registrada exitosamente por un monto de " & Format(_ValorVenta, "C"), MsgBoxStyle.SystemModal, "Venta exitosa")
            ReiniciarForm()
        End If

    End Sub

    Private Sub RescatarDatosDataGridViewProductos(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If _DataGridViewProductos.Rows.Count > 0 Then

            If _DataGridViewProductos.CurrentCell.Selected Then

                TextBoxCodigo.Text = _DataGridViewProductos.SelectedCells.Item(0).Value.ToString()
                Me.Controls.Remove(_DataGridViewProductos)
                Me.Controls.Remove(_ButtonCerrarGrilla)

            End If

        End If

    End Sub

    Private Sub ButtonBuscarProductos_Click(sender As Object, e As EventArgs) Handles ButtonBuscarProductos.Click
        DesplegarGrillaProductos()
    End Sub

    Private Sub DesplegarGrillaProductos()
        Me.Controls.Add(_DataGridViewProductos)
        PintarGrillaProductosVentas(_DataGridViewProductos)
        Me.Controls.Add(_ButtonCerrarGrilla)
    End Sub

    Private Sub AnularSelectedDataGridViewProductos()
        _DataGridViewProductos.CurrentCell.Selected = False
    End Sub

    Private Sub CerrarGrillaProductos(sender As Object, e As EventArgs)
        Me.Controls.Remove(_DataGridViewProductos)
        Me.Controls.Remove(_ButtonCerrarGrilla)
    End Sub

End Class