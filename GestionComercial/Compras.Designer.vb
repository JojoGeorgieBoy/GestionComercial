<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Compras
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LabelCantidadProductoVentas = New System.Windows.Forms.Label
        Me.NumericUpDownCantidadProductoVentas = New System.Windows.Forms.NumericUpDown
        Me.TextBoxDescripcionProductoCompras = New System.Windows.Forms.TextBox
        Me.TextBoxPrecioProductoCompras = New System.Windows.Forms.TextBox
        Me.TextBoxCodigoProductoCompras = New System.Windows.Forms.TextBox
        Me.LabelDescripcionProductoCompras = New System.Windows.Forms.Label
        Me.LabelPrecioProductoCompras = New System.Windows.Forms.Label
        Me.LabelCodigoProductoCompras = New System.Windows.Forms.Label
        Me.DataGridViewCompras = New System.Windows.Forms.DataGridView
        Me.LabelTtituloCompras = New System.Windows.Forms.Label
        Me.ButtonGuardar = New System.Windows.Forms.Button
        CType(Me.NumericUpDownCantidadProductoVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelCantidadProductoVentas
        '
        Me.LabelCantidadProductoVentas.AutoSize = True
        Me.LabelCantidadProductoVentas.Location = New System.Drawing.Point(330, 120)
        Me.LabelCantidadProductoVentas.Name = "LabelCantidadProductoVentas"
        Me.LabelCantidadProductoVentas.Size = New System.Drawing.Size(52, 13)
        Me.LabelCantidadProductoVentas.TabIndex = 559
        Me.LabelCantidadProductoVentas.Text = "Cantidad:"
        '
        'NumericUpDownCantidadProductoVentas
        '
        Me.NumericUpDownCantidadProductoVentas.BackColor = System.Drawing.Color.White
        Me.NumericUpDownCantidadProductoVentas.Location = New System.Drawing.Point(402, 118)
        Me.NumericUpDownCantidadProductoVentas.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDownCantidadProductoVentas.Name = "NumericUpDownCantidadProductoVentas"
        Me.NumericUpDownCantidadProductoVentas.ReadOnly = True
        Me.NumericUpDownCantidadProductoVentas.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumericUpDownCantidadProductoVentas.Size = New System.Drawing.Size(48, 20)
        Me.NumericUpDownCantidadProductoVentas.TabIndex = 558
        Me.NumericUpDownCantidadProductoVentas.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TextBoxDescripcionProductoCompras
        '
        Me.TextBoxDescripcionProductoCompras.Location = New System.Drawing.Point(402, 70)
        Me.TextBoxDescripcionProductoCompras.Name = "TextBoxDescripcionProductoCompras"
        Me.TextBoxDescripcionProductoCompras.Size = New System.Drawing.Size(308, 20)
        Me.TextBoxDescripcionProductoCompras.TabIndex = 554
        '
        'TextBoxPrecioProductoCompras
        '
        Me.TextBoxPrecioProductoCompras.Location = New System.Drawing.Point(70, 115)
        Me.TextBoxPrecioProductoCompras.Name = "TextBoxPrecioProductoCompras"
        Me.TextBoxPrecioProductoCompras.Size = New System.Drawing.Size(104, 20)
        Me.TextBoxPrecioProductoCompras.TabIndex = 553
        '
        'TextBoxCodigoProductoCompras
        '
        Me.TextBoxCodigoProductoCompras.Location = New System.Drawing.Point(70, 70)
        Me.TextBoxCodigoProductoCompras.Name = "TextBoxCodigoProductoCompras"
        Me.TextBoxCodigoProductoCompras.Size = New System.Drawing.Size(218, 20)
        Me.TextBoxCodigoProductoCompras.TabIndex = 551
        Me.TextBoxCodigoProductoCompras.UseWaitCursor = True
        '
        'LabelDescripcionProductoCompras
        '
        Me.LabelDescripcionProductoCompras.AutoSize = True
        Me.LabelDescripcionProductoCompras.Location = New System.Drawing.Point(330, 75)
        Me.LabelDescripcionProductoCompras.Name = "LabelDescripcionProductoCompras"
        Me.LabelDescripcionProductoCompras.Size = New System.Drawing.Size(66, 13)
        Me.LabelDescripcionProductoCompras.TabIndex = 557
        Me.LabelDescripcionProductoCompras.Text = "Descripción:"
        '
        'LabelPrecioProductoCompras
        '
        Me.LabelPrecioProductoCompras.AutoSize = True
        Me.LabelPrecioProductoCompras.Location = New System.Drawing.Point(20, 120)
        Me.LabelPrecioProductoCompras.Name = "LabelPrecioProductoCompras"
        Me.LabelPrecioProductoCompras.Size = New System.Drawing.Size(40, 13)
        Me.LabelPrecioProductoCompras.TabIndex = 556
        Me.LabelPrecioProductoCompras.Text = "Precio:"
        '
        'LabelCodigoProductoCompras
        '
        Me.LabelCodigoProductoCompras.AutoSize = True
        Me.LabelCodigoProductoCompras.Location = New System.Drawing.Point(20, 75)
        Me.LabelCodigoProductoCompras.Name = "LabelCodigoProductoCompras"
        Me.LabelCodigoProductoCompras.Size = New System.Drawing.Size(43, 13)
        Me.LabelCodigoProductoCompras.TabIndex = 555
        Me.LabelCodigoProductoCompras.Text = "Código:"
        '
        'DataGridViewCompras
        '
        Me.DataGridViewCompras.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DataGridViewCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewCompras.GridColor = System.Drawing.SystemColors.ControlLight
        Me.DataGridViewCompras.Location = New System.Drawing.Point(20, 180)
        Me.DataGridViewCompras.Name = "DataGridViewCompras"
        Me.DataGridViewCompras.Size = New System.Drawing.Size(690, 240)
        Me.DataGridViewCompras.StandardTab = True
        Me.DataGridViewCompras.TabIndex = 552
        '
        'LabelTtituloCompras
        '
        Me.LabelTtituloCompras.AutoSize = True
        Me.LabelTtituloCompras.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTtituloCompras.Location = New System.Drawing.Point(20, 25)
        Me.LabelTtituloCompras.Name = "LabelTtituloCompras"
        Me.LabelTtituloCompras.Size = New System.Drawing.Size(125, 25)
        Me.LabelTtituloCompras.TabIndex = 564
        Me.LabelTtituloCompras.Text = "COMPRAS"
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(530, 105)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(124, 44)
        Me.ButtonGuardar.TabIndex = 565
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'Compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 492)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.LabelTtituloCompras)
        Me.Controls.Add(Me.LabelCantidadProductoVentas)
        Me.Controls.Add(Me.NumericUpDownCantidadProductoVentas)
        Me.Controls.Add(Me.TextBoxDescripcionProductoCompras)
        Me.Controls.Add(Me.TextBoxPrecioProductoCompras)
        Me.Controls.Add(Me.TextBoxCodigoProductoCompras)
        Me.Controls.Add(Me.LabelDescripcionProductoCompras)
        Me.Controls.Add(Me.LabelPrecioProductoCompras)
        Me.Controls.Add(Me.LabelCodigoProductoCompras)
        Me.Controls.Add(Me.DataGridViewCompras)
        Me.Name = "Compras"
        Me.Text = "Compras"
        CType(Me.NumericUpDownCantidadProductoVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewCompras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelCantidadProductoVentas As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownCantidadProductoVentas As System.Windows.Forms.NumericUpDown
    Friend WithEvents TextBoxDescripcionProductoCompras As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPrecioProductoCompras As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCodigoProductoCompras As System.Windows.Forms.TextBox
    Friend WithEvents LabelDescripcionProductoCompras As System.Windows.Forms.Label
    Friend WithEvents LabelPrecioProductoCompras As System.Windows.Forms.Label
    Friend WithEvents LabelCodigoProductoCompras As System.Windows.Forms.Label
    Friend WithEvents DataGridViewCompras As System.Windows.Forms.DataGridView
    Friend WithEvents LabelTtituloCompras As System.Windows.Forms.Label
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
End Class
