<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reportes
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
        Me.LabelCantidadProductoVentass = New System.Windows.Forms.Label
        Me.LabelTtituloVentas = New System.Windows.Forms.Label
        Me.DataGridViewProductos = New System.Windows.Forms.DataGridView
        Me.ComboBoxProductos = New System.Windows.Forms.ComboBox
        CType(Me.DataGridViewProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelCantidadProductoVentass
        '
        Me.LabelCantidadProductoVentass.AutoSize = True
        Me.LabelCantidadProductoVentass.Location = New System.Drawing.Point(34, 84)
        Me.LabelCantidadProductoVentass.Name = "LabelCantidadProductoVentass"
        Me.LabelCantidadProductoVentass.Size = New System.Drawing.Size(53, 13)
        Me.LabelCantidadProductoVentass.TabIndex = 553
        Me.LabelCantidadProductoVentass.Text = "Producto:"
        '
        'LabelTtituloVentas
        '
        Me.LabelTtituloVentas.AutoSize = True
        Me.LabelTtituloVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTtituloVentas.Location = New System.Drawing.Point(32, 25)
        Me.LabelTtituloVentas.Name = "LabelTtituloVentas"
        Me.LabelTtituloVentas.Size = New System.Drawing.Size(135, 25)
        Me.LabelTtituloVentas.TabIndex = 554
        Me.LabelTtituloVentas.Text = "REPORTES"
        '
        'DataGridViewProductos
        '
        Me.DataGridViewProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewProductos.GridColor = System.Drawing.SystemColors.ControlLight
        Me.DataGridViewProductos.Location = New System.Drawing.Point(37, 122)
        Me.DataGridViewProductos.Name = "DataGridViewProductos"
        Me.DataGridViewProductos.Size = New System.Drawing.Size(649, 304)
        Me.DataGridViewProductos.StandardTab = True
        Me.DataGridViewProductos.TabIndex = 551
        '
        'ComboBoxProductos
        '
        Me.ComboBoxProductos.FormattingEnabled = True
        Me.ComboBoxProductos.Location = New System.Drawing.Point(93, 81)
        Me.ComboBoxProductos.Name = "ComboBoxProductos"
        Me.ComboBoxProductos.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxProductos.TabIndex = 555
        '
        'Reportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 492)
        Me.Controls.Add(Me.ComboBoxProductos)
        Me.Controls.Add(Me.LabelCantidadProductoVentass)
        Me.Controls.Add(Me.LabelTtituloVentas)
        Me.Controls.Add(Me.DataGridViewProductos)
        Me.Name = "Reportes"
        Me.Text = "Reportes"
        CType(Me.DataGridViewProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelCantidadProductoVentass As System.Windows.Forms.Label
    Friend WithEvents LabelTtituloVentas As System.Windows.Forms.Label
    Friend WithEvents DataGridViewProductos As System.Windows.Forms.DataGridView
    Friend WithEvents ComboBoxProductos As System.Windows.Forms.ComboBox
End Class
