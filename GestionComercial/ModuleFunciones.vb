Imports System.Xml
Module ModuleFunciones
    Dim _TextBox As TextBox
    Dim _ComboBox As ComboBox
    Dim _Button As Button
    Dim _NumericUpDown As NumericUpDown
    Sub CentrarMe(ByRef Formulario As Form)
        With Formulario
            .Top = (Screen.PrimaryScreen.WorkingArea.Height / 2 - .Height / 2) + 25
            .Left = Screen.PrimaryScreen.WorkingArea.Width / 2 - .Width / 2
        End With
    End Sub
    Public Function ValidarTextoVacio(ByVal Valor As String, ByVal Mensaje As String) As Boolean
        If (Valor.Trim = String.Empty) Then
            MsgBox(Mensaje, MsgBoxStyle.Exclamation, "Falta completar datos")
            Return False
        Else
            Return True
        End If
    End Function
    Function Convierte_a_fecha(ByVal Texto As String) As String
        Dim ano As String = Texto.Substring(0, 4)
        Dim mes As String = Texto.Substring(4, 2)
        Dim dia As String = Texto.Substring(6, 2)
        Return dia & "/" & mes & "/" & ano
    End Function
    Function Convierte_a_hora(ByVal Texto As String) As String
        Dim hor As String = Texto.Substring(0, 4)
        Dim min As String = Texto.Substring(4, 2)
        Dim seg As String = Texto.Substring(6, 2)
        Return hor & ":" & min & ":" & seg
    End Function
    Function FechaHoy() As String
        Return Now.Year.ToString & Now.Month.ToString.PadLeft(2, "0") & Now.Day.ToString.PadLeft(2, "0")
    End Function
    Function HoraAhora() As String
        Return Now.Hour.ToString.PadLeft(2, "0") & Now.Minute.ToString.PadLeft(2, "0") & Now.Second.ToString.PadLeft(2, "0")
    End Function

    Sub LayoutGrillaProductos(ByRef Grilla As DataGridView)
        With Grilla
            LayoutGrillaComun(Grilla)
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        'DimensionarColumnasGrillaProductos(Grilla)
    End Sub

    Sub LayoutGrillaItemsVentas(ByRef Grilla As DataGridView)
        With Grilla
            LayoutGrillaComun(Grilla)
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Item").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .CurrentCell.Selected = False
        End With
        DimensionarColumnasGrillaVentas(Grilla)
    End Sub

    Sub LayoutDataGridViewNomArch(ByRef Grilla As DataGridView)
        With Grilla
            LayoutGrillaComun(Grilla)
            .Columns("Fullname").Visible = False
            .Columns("NomArchYYYYMMDD").Visible = False
        End With
    End Sub

    Sub LayoutDataGridViewReporteVentasConsolidado(ByRef Grilla As DataGridView)
        With Grilla
            LayoutGrillaComun(Grilla)
            .Columns("Folio").Width = 40
            .Columns("Hora").Width = 50
            .Columns("Total").Width = 70
            .Columns("InnerXML").Visible = False
            .Columns("Folio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Hora").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
    End Sub

    Sub LayoutDataGridViewReporteVentasDetalle(ByRef Grilla As DataGridView)
        LayoutGrillaComun(Grilla)
        Grilla.Columns("Descripcion").Width = 150
    End Sub

    Sub LayoutGrillaComun(ByRef Grilla As DataGridView)
        With Grilla
            '.AlternatingRowsDefaultCellStyle.BackColor = Color.Snow
            .CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical
            .ReadOnly = True
            .RowHeadersVisible = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToAddRows = False
            .BackgroundColor = Color.WhiteSmoke
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .BackgroundColor = Color.White
            .GridColor = Color.White
        End With
    End Sub

    Sub DimensionarColumnasGrillaVentas(ByRef Grilla As DataGridView)
        With Grilla
            .Columns("Codigo").Width = 130
            .Columns("Descripcion").Width = 350
            .Columns("Unidad").Width = 100
            .Columns("Precio").Width = 100
            .Columns("Cantidad").Width = 80
            .Columns("Total_Item").Width = 140
        End With
    End Sub

    Function TotalizarGrilla(ByRef Grilla As DataGridView) As Decimal

        Dim _Total As Decimal
        For Each _DataGridViewRow As DataGridViewRow In Grilla.Rows
            _DataGridViewRow.Cells("Cantidad").Value = CDec(_DataGridViewRow.Cells("Cantidad").Value).ToString("N2") 'Format(CDec(_DataGridViewRow.Cells("Cantidad").Value), "N")
            _DataGridViewRow.Cells("Precio").Value = CInt(_DataGridViewRow.Cells("Precio").Value).ToString("N0") 'Format(CInt(_DataGridViewRow.Cells("Precio").Value), "##,##0")
            _Total += _DataGridViewRow.Cells("Total_Item").Value
            _DataGridViewRow.Cells("Total_Item").Value = CInt(_DataGridViewRow.Cells("Total_Item").Value).ToString("N0")
        Next

        Return _Total

    End Function

    Function ObtenerFolio() As String

        Dim _XmlDocument As New XmlDocument
        _XmlDocument.Load(My.Settings._FileFolio)
        Return _XmlDocument.SelectSingleNode("root/Folio").InnerText

    End Function

    Sub IncrementarFolio()

        Dim _XmlDocument As New XmlDocument
        _XmlDocument.Load(My.Settings._FileFolio)
        _XmlDocument.SelectSingleNode("root/Folio").InnerText += 1
        _XmlDocument.Save(My.Settings._FileFolio)

    End Sub

    Sub BloquearInputs(ByRef _Formulario As Form, ByVal _ValorBooleano As Boolean)

        If _Formulario.Name = "FormProductos" Then

            For Each _Control As System.Windows.Forms.Control In _Formulario.Controls

                If _Control.GetType.ToString = "System.Windows.Forms.TextBox" Then
                    _TextBox = _Control
                    Select Case _Control.Name
                        Case "TextBoxCodigoProducto", "TextBoxCodigoProductoVentas"
                        Case Else
                            _TextBox.ReadOnly = _ValorBooleano
                    End Select
                    _TextBox.BackColor = Color.White
                Else
                    If _Control.GetType.ToString = "System.Windows.Forms.ComboBox" Then
                        _ComboBox = _Control
                        _ComboBox.Enabled = Not _ValorBooleano
                        _ComboBox.BackColor = Color.White
                    Else
                        If _Control.GetType.ToString = "System.Windows.Forms.NumericUpDown" Then
                            _NumericUpDown = _Control
                            _NumericUpDown.Enabled = Not _ValorBooleano
                            _NumericUpDown.BackColor = Color.White
                        End If
                    End If
                End If

            Next

        End If

    End Sub

    Sub InicializarInputsVentas(ByRef _Formulario As Form, ByVal Excepcion As String)

        For Each _Control As System.Windows.Forms.Control In _Formulario.Controls

            Select Case _Control.GetType.ToString
                Case "System.Windows.Forms.GroupBox"
                    For Each _ControlButton As System.Windows.Forms.Control In _Control.Controls
                        _ControlButton.Enabled = False
                    Next
                Case "System.Windows.Forms.TextBox"
                    _TextBox = _Control
                    If _TextBox.Name <> Excepcion Then
                        _TextBox.Text = String.Empty
                        _TextBox.BackColor = Color.White
                    End If
                    _TextBox.ReadOnly = True
                Case "System.Windows.Forms.ComboBox"
                    _ComboBox = _Control
                    _ComboBox.SelectedIndex = -1
                Case "System.Windows.Forms.Button"
                    _Button = _Control
                    If _Button.Name <> "ButtonBuscarProductos" Then
                        _Button.Enabled = False
                    End If
                    If _Button.Name = "ButtonCerrarGrilla" Then
                        _Button.Visible = False
                    End If
            End Select

        Next

    End Sub

    Sub LimpiarGrilla(ByRef _DataGridView As DataGridView)
        _DataGridView.DataSource = Nothing
        _DataGridView.Rows.Clear()
        _DataGridView.Refresh()
    End Sub

    Sub PintarGrillaProductos(ByRef _DataGridViewProductos As DataGridView, ByVal _DataTable As DataTable)

        With _DataGridViewProductos

            .DataSource = _DataTable
            .RowHeadersVisible = False
            .Columns("Codigo").Width = 130
            .Columns("Descripcion").Width = 300
            .Columns("Unidad").Width = 90
            .Columns("Precio").Width = 80
            .Columns("Precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").Width = 75
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Fecha").Width = 100
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'LayoutGrillaProductos(_DataGridViewProductos)

            'AddHandler .Click, AddressOf RescatarDatos
            'AddHandler .Sorted, AddressOf BorrarProtagonismo

        End With

    End Sub

    Sub PintarGrillaProductosVentas(ByRef _DataGridViewProductos As DataGridView)

        With _DataGridViewProductos

            .Left = 35
            .Top = 55
            .Width = 920
            .Height = 420

            .Columns("Codigo").Width = 180
            .Columns("Descripcion").Width = 380
            .Columns("Unidad").Width = 130
            .Columns("Precio").Width = 130
            .Columns("Precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").Width = 95
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Fecha").Width = 0

            .RowHeadersVisible = False
            .ColumnHeadersHeight = 40
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .CurrentCell.Selected = False


            .BringToFront()

        End With


    End Sub

    Sub Activar(ByRef _Button As Button, ByVal _Activate As Boolean)
        Select Case _Button.Name
            Case "ButtonClean"
                If _Activate Then
                    _Button.Image = Image.FromFile("C:\GestionComercial\GestionComercial\Resources\clean.png")
                Else
                    _Button.Image = Image.FromFile("C:\GestionComercial\GestionComercial\Resources\clean_bn.png")
                End If
            Case "ButtonAdd"
                If _Activate Then
                    _Button.Image = Image.FromFile("C:\GestionComercial\GestionComercial\Resources\add.png")
                Else
                    _Button.Image = Image.FromFile("C:\GestionComercial\GestionComercial\Resources\add_bn.png")
                End If
            Case "ButtonDelete"
                If _Activate Then
                    _Button.Image = Image.FromFile("C:\GestionComercial\GestionComercial\Resources\delete.png")
                Else
                    _Button.Image = Image.FromFile("C:\GestionComercial\GestionComercial\Resources\delete_bn.png")
                End If
            Case "ButtonSave"
                If _Activate Then
                    _Button.Image = Image.FromFile("C:\GestionComercial\GestionComercial\Resources\save.png")
                Else
                    _Button.Image = Image.FromFile("C:\GestionComercial\GestionComercial\Resources\save_bn.png")
                End If
        End Select
        If _Activate Then
            _Button.Enabled = True
        Else
            _Button.Enabled = False
        End If
    End Sub

    Function CrearDataTable(ByVal Nombre_Campos As String) As DataTable

        Dim _DataTable As New DataTable

        With _DataTable
            For Each NombreCampo As String In Nombre_Campos.Split(",")
                .Columns.Add(NombreCampo, GetType(String))
            Next
        End With

        Return _DataTable

    End Function


#Region "Handlers"
    Public Sub Not_KeyPressed(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        e.KeyChar = Nothing
    End Sub
#End Region

End Module
