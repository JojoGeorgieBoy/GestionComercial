<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVentas))
        Me.DataGridViewItemsVentas = New System.Windows.Forms.DataGridView()
        Me.LabelCodigoProductoVentas = New System.Windows.Forms.Label()
        Me.LabelPrecioProductoVentas = New System.Windows.Forms.Label()
        Me.LabelDescripcionProductoVentas = New System.Windows.Forms.Label()
        Me.TextBoxCodigo = New System.Windows.Forms.TextBox()
        Me.TextBoxPrecio = New System.Windows.Forms.TextBox()
        Me.TextBoxDescripcion = New System.Windows.Forms.TextBox()
        Me.LabelCantidadProductoVentas = New System.Windows.Forms.Label()
        Me.LabelTotalText = New System.Windows.Forms.Label()
        Me.LabelUnidadProductos = New System.Windows.Forms.Label()
        Me.LabelTtituloVentas = New System.Windows.Forms.Label()
        Me.TextBoxCantidad = New System.Windows.Forms.TextBox()
        Me.TextBoxUnidad = New System.Windows.Forms.TextBox()
        Me.GroupBoxBotonera = New System.Windows.Forms.GroupBox()
        Me.ButtonClean = New System.Windows.Forms.Button()
        Me.ButtonAdd = New System.Windows.Forms.Button()
        Me.ButtonDelete = New System.Windows.Forms.Button()
        Me.ButtonSave = New System.Windows.Forms.Button()
        Me.TextBoxTotal = New System.Windows.Forms.TextBox()
        Me.ButtonBuscarProductos = New System.Windows.Forms.Button()
        CType(Me.DataGridViewItemsVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxBotonera.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridViewItemsVentas
        '
        Me.DataGridViewItemsVentas.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DataGridViewItemsVentas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridViewItemsVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewItemsVentas.GridColor = System.Drawing.SystemColors.ControlLight
        Me.DataGridViewItemsVentas.Location = New System.Drawing.Point(35, 182)
        Me.DataGridViewItemsVentas.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridViewItemsVentas.Name = "DataGridViewItemsVentas"
        Me.DataGridViewItemsVentas.Size = New System.Drawing.Size(916, 258)
        Me.DataGridViewItemsVentas.StandardTab = True
        Me.DataGridViewItemsVentas.TabIndex = 6
        '
        'LabelCodigoProductoVentas
        '
        Me.LabelCodigoProductoVentas.AutoSize = True
        Me.LabelCodigoProductoVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCodigoProductoVentas.Location = New System.Drawing.Point(35, 66)
        Me.LabelCodigoProductoVentas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelCodigoProductoVentas.Name = "LabelCodigoProductoVentas"
        Me.LabelCodigoProductoVentas.Size = New System.Drawing.Size(60, 18)
        Me.LabelCodigoProductoVentas.TabIndex = 500
        Me.LabelCodigoProductoVentas.Text = "Código:"
        '
        'LabelPrecioProductoVentas
        '
        Me.LabelPrecioProductoVentas.AutoSize = True
        Me.LabelPrecioProductoVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPrecioProductoVentas.Location = New System.Drawing.Point(435, 144)
        Me.LabelPrecioProductoVentas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelPrecioProductoVentas.Name = "LabelPrecioProductoVentas"
        Me.LabelPrecioProductoVentas.Size = New System.Drawing.Size(55, 18)
        Me.LabelPrecioProductoVentas.TabIndex = 700
        Me.LabelPrecioProductoVentas.Text = "Precio:"
        '
        'LabelDescripcionProductoVentas
        '
        Me.LabelDescripcionProductoVentas.AutoSize = True
        Me.LabelDescripcionProductoVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDescripcionProductoVentas.Location = New System.Drawing.Point(35, 106)
        Me.LabelDescripcionProductoVentas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelDescripcionProductoVentas.Name = "LabelDescripcionProductoVentas"
        Me.LabelDescripcionProductoVentas.Size = New System.Drawing.Size(91, 18)
        Me.LabelDescripcionProductoVentas.TabIndex = 600
        Me.LabelDescripcionProductoVentas.Text = "Descripción:"
        '
        'TextBoxCodigo
        '
        Me.TextBoxCodigo.Location = New System.Drawing.Point(152, 63)
        Me.TextBoxCodigo.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxCodigo.Name = "TextBoxCodigo"
        Me.TextBoxCodigo.Size = New System.Drawing.Size(200, 24)
        Me.TextBoxCodigo.TabIndex = 1
        Me.TextBoxCodigo.UseWaitCursor = True
        '
        'TextBoxPrecio
        '
        Me.TextBoxPrecio.Location = New System.Drawing.Point(506, 141)
        Me.TextBoxPrecio.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxPrecio.Name = "TextBoxPrecio"
        Me.TextBoxPrecio.Size = New System.Drawing.Size(120, 24)
        Me.TextBoxPrecio.TabIndex = 5
        '
        'TextBoxDescripcion
        '
        Me.TextBoxDescripcion.Location = New System.Drawing.Point(152, 103)
        Me.TextBoxDescripcion.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxDescripcion.Name = "TextBoxDescripcion"
        Me.TextBoxDescripcion.Size = New System.Drawing.Size(474, 24)
        Me.TextBoxDescripcion.TabIndex = 3
        '
        'LabelCantidadProductoVentas
        '
        Me.LabelCantidadProductoVentas.AutoSize = True
        Me.LabelCantidadProductoVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCantidadProductoVentas.Location = New System.Drawing.Point(35, 144)
        Me.LabelCantidadProductoVentas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelCantidadProductoVentas.Name = "LabelCantidadProductoVentas"
        Me.LabelCantidadProductoVentas.Size = New System.Drawing.Size(70, 18)
        Me.LabelCantidadProductoVentas.TabIndex = 650
        Me.LabelCantidadProductoVentas.Text = "Cantidad:"
        '
        'LabelTotalText
        '
        Me.LabelTotalText.AutoSize = True
        Me.LabelTotalText.Location = New System.Drawing.Point(772, 450)
        Me.LabelTotalText.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelTotalText.Name = "LabelTotalText"
        Me.LabelTotalText.Size = New System.Drawing.Size(45, 18)
        Me.LabelTotalText.TabIndex = 800
        Me.LabelTotalText.Text = "Total:"
        '
        'LabelUnidadProductos
        '
        Me.LabelUnidadProductos.AutoSize = True
        Me.LabelUnidadProductos.Location = New System.Drawing.Point(429, 66)
        Me.LabelUnidadProductos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelUnidadProductos.Name = "LabelUnidadProductos"
        Me.LabelUnidadProductos.Size = New System.Drawing.Size(58, 18)
        Me.LabelUnidadProductos.TabIndex = 550
        Me.LabelUnidadProductos.Text = "Unidad:"
        '
        'LabelTtituloVentas
        '
        Me.LabelTtituloVentas.AutoSize = True
        Me.LabelTtituloVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTtituloVentas.Location = New System.Drawing.Point(33, 19)
        Me.LabelTtituloVentas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelTtituloVentas.Name = "LabelTtituloVentas"
        Me.LabelTtituloVentas.Size = New System.Drawing.Size(152, 29)
        Me.LabelTtituloVentas.TabIndex = 450
        Me.LabelTtituloVentas.Text = "Mantenedor"
        '
        'TextBoxCantidad
        '
        Me.TextBoxCantidad.Location = New System.Drawing.Point(152, 141)
        Me.TextBoxCantidad.Name = "TextBoxCantidad"
        Me.TextBoxCantidad.Size = New System.Drawing.Size(200, 24)
        Me.TextBoxCantidad.TabIndex = 4
        '
        'TextBoxUnidad
        '
        Me.TextBoxUnidad.Location = New System.Drawing.Point(506, 63)
        Me.TextBoxUnidad.Name = "TextBoxUnidad"
        Me.TextBoxUnidad.Size = New System.Drawing.Size(120, 24)
        Me.TextBoxUnidad.TabIndex = 2
        '
        'GroupBoxBotonera
        '
        Me.GroupBoxBotonera.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBoxBotonera.Controls.Add(Me.ButtonClean)
        Me.GroupBoxBotonera.Controls.Add(Me.ButtonAdd)
        Me.GroupBoxBotonera.Controls.Add(Me.ButtonDelete)
        Me.GroupBoxBotonera.Controls.Add(Me.ButtonSave)
        Me.GroupBoxBotonera.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBoxBotonera.Location = New System.Drawing.Point(646, 85)
        Me.GroupBoxBotonera.Name = "GroupBoxBotonera"
        Me.GroupBoxBotonera.Size = New System.Drawing.Size(305, 80)
        Me.GroupBoxBotonera.TabIndex = 8
        Me.GroupBoxBotonera.TabStop = False
        '
        'ButtonClean
        '
        Me.ButtonClean.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonClean.Image = CType(resources.GetObject("ButtonClean.Image"), System.Drawing.Image)
        Me.ButtonClean.Location = New System.Drawing.Point(35, 22)
        Me.ButtonClean.Name = "ButtonClean"
        Me.ButtonClean.Size = New System.Drawing.Size(46, 46)
        Me.ButtonClean.TabIndex = 9
        Me.ButtonClean.UseVisualStyleBackColor = True
        '
        'ButtonAdd
        '
        Me.ButtonAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdd.ForeColor = System.Drawing.Color.White
        Me.ButtonAdd.Image = CType(resources.GetObject("ButtonAdd.Image"), System.Drawing.Image)
        Me.ButtonAdd.Location = New System.Drawing.Point(101, 22)
        Me.ButtonAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonAdd.Name = "ButtonAdd"
        Me.ButtonAdd.Size = New System.Drawing.Size(46, 46)
        Me.ButtonAdd.TabIndex = 10
        Me.ButtonAdd.UseVisualStyleBackColor = False
        '
        'ButtonDelete
        '
        Me.ButtonDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDelete.ForeColor = System.Drawing.Color.White
        Me.ButtonDelete.Image = CType(resources.GetObject("ButtonDelete.Image"), System.Drawing.Image)
        Me.ButtonDelete.Location = New System.Drawing.Point(167, 22)
        Me.ButtonDelete.Name = "ButtonDelete"
        Me.ButtonDelete.Size = New System.Drawing.Size(46, 46)
        Me.ButtonDelete.TabIndex = 11
        Me.ButtonDelete.UseVisualStyleBackColor = False
        '
        'ButtonSave
        '
        Me.ButtonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSave.ForeColor = System.Drawing.Color.White
        Me.ButtonSave.Image = CType(resources.GetObject("ButtonSave.Image"), System.Drawing.Image)
        Me.ButtonSave.Location = New System.Drawing.Point(232, 22)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(46, 46)
        Me.ButtonSave.TabIndex = 12
        Me.ButtonSave.UseVisualStyleBackColor = False
        '
        'TextBoxTotal
        '
        Me.TextBoxTotal.Location = New System.Drawing.Point(829, 447)
        Me.TextBoxTotal.Name = "TextBoxTotal"
        Me.TextBoxTotal.Size = New System.Drawing.Size(122, 24)
        Me.TextBoxTotal.TabIndex = 7
        '
        'ButtonBuscarProductos
        '
        Me.ButtonBuscarProductos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonBuscarProductos.Image = CType(resources.GetObject("ButtonBuscarProductos.Image"), System.Drawing.Image)
        Me.ButtonBuscarProductos.Location = New System.Drawing.Point(362, 63)
        Me.ButtonBuscarProductos.Name = "ButtonBuscarProductos"
        Me.ButtonBuscarProductos.Size = New System.Drawing.Size(31, 29)
        Me.ButtonBuscarProductos.TabIndex = 801
        Me.ButtonBuscarProductos.UseVisualStyleBackColor = True
        '
        'FormVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(984, 512)
        Me.Controls.Add(Me.ButtonBuscarProductos)
        Me.Controls.Add(Me.TextBoxTotal)
        Me.Controls.Add(Me.GroupBoxBotonera)
        Me.Controls.Add(Me.TextBoxUnidad)
        Me.Controls.Add(Me.TextBoxCantidad)
        Me.Controls.Add(Me.LabelTtituloVentas)
        Me.Controls.Add(Me.LabelUnidadProductos)
        Me.Controls.Add(Me.LabelTotalText)
        Me.Controls.Add(Me.LabelCantidadProductoVentas)
        Me.Controls.Add(Me.TextBoxDescripcion)
        Me.Controls.Add(Me.TextBoxPrecio)
        Me.Controls.Add(Me.TextBoxCodigo)
        Me.Controls.Add(Me.LabelDescripcionProductoVentas)
        Me.Controls.Add(Me.LabelPrecioProductoVentas)
        Me.Controls.Add(Me.LabelCodigoProductoVentas)
        Me.Controls.Add(Me.DataGridViewItemsVentas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormVentas"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.DataGridViewItemsVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxBotonera.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewItemsVentas As System.Windows.Forms.DataGridView
    Friend WithEvents LabelCodigoProductoVentas As System.Windows.Forms.Label
    Friend WithEvents LabelPrecioProductoVentas As System.Windows.Forms.Label
    Friend WithEvents LabelDescripcionProductoVentas As System.Windows.Forms.Label
    Friend WithEvents TextBoxCodigo As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPrecio As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents LabelCantidadProductoVentas As System.Windows.Forms.Label
    Friend WithEvents LabelTotalText As System.Windows.Forms.Label
    Friend WithEvents LabelUnidadProductos As System.Windows.Forms.Label
    Friend WithEvents LabelTtituloVentas As System.Windows.Forms.Label
    Friend WithEvents TextBoxCantidad As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxUnidad As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxBotonera As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonClean As System.Windows.Forms.Button
    Friend WithEvents ButtonAdd As System.Windows.Forms.Button
    Friend WithEvents ButtonDelete As System.Windows.Forms.Button
    Friend WithEvents ButtonSave As System.Windows.Forms.Button
    Friend WithEvents TextBoxTotal As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarProductos As System.Windows.Forms.Button
End Class
