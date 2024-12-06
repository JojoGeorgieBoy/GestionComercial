<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProductos))
        Me.LabelUnidadProductos = New System.Windows.Forms.Label()
        Me.TextBoxDescripcionProducto = New System.Windows.Forms.TextBox()
        Me.TextBoxPrecioProducto = New System.Windows.Forms.TextBox()
        Me.TextBoxCodigoProducto = New System.Windows.Forms.TextBox()
        Me.LabelDescripcionProductos = New System.Windows.Forms.Label()
        Me.LabelPrecioProductos = New System.Windows.Forms.Label()
        Me.DataGridViewProductos = New System.Windows.Forms.DataGridView()
        Me.LabelTtituloProductos = New System.Windows.Forms.Label()
        Me.TextBoxCantidadProducto = New System.Windows.Forms.TextBox()
        Me.LabelCantidadProductos = New System.Windows.Forms.Label()
        Me.ComboUnidadProducto = New System.Windows.Forms.ComboBox()
        Me.LabelCodigoProductos = New System.Windows.Forms.Label()
        Me.GroupBoxBotonera = New System.Windows.Forms.GroupBox()
        Me.ButtonClean = New System.Windows.Forms.Button()
        Me.ButtonAdd = New System.Windows.Forms.Button()
        Me.ButtonDelete = New System.Windows.Forms.Button()
        Me.ButtonSave = New System.Windows.Forms.Button()
        CType(Me.DataGridViewProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxBotonera.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelUnidadProductos
        '
        Me.LabelUnidadProductos.AutoSize = True
        Me.LabelUnidadProductos.Location = New System.Drawing.Point(428, 72)
        Me.LabelUnidadProductos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelUnidadProductos.Name = "LabelUnidadProductos"
        Me.LabelUnidadProductos.Size = New System.Drawing.Size(75, 24)
        Me.LabelUnidadProductos.TabIndex = 559
        Me.LabelUnidadProductos.Text = "Unidad:"
        '
        'TextBoxDescripcionProducto
        '
        Me.TextBoxDescripcionProducto.Location = New System.Drawing.Point(159, 112)
        Me.TextBoxDescripcionProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxDescripcionProducto.Name = "TextBoxDescripcionProducto"
        Me.TextBoxDescripcionProducto.Size = New System.Drawing.Size(474, 29)
        Me.TextBoxDescripcionProducto.TabIndex = 20
        '
        'TextBoxPrecioProducto
        '
        Me.TextBoxPrecioProducto.Location = New System.Drawing.Point(159, 155)
        Me.TextBoxPrecioProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxPrecioProducto.Name = "TextBoxPrecioProducto"
        Me.TextBoxPrecioProducto.Size = New System.Drawing.Size(200, 29)
        Me.TextBoxPrecioProducto.TabIndex = 30
        '
        'TextBoxCodigoProducto
        '
        Me.TextBoxCodigoProducto.Location = New System.Drawing.Point(159, 69)
        Me.TextBoxCodigoProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxCodigoProducto.Name = "TextBoxCodigoProducto"
        Me.TextBoxCodigoProducto.Size = New System.Drawing.Size(200, 29)
        Me.TextBoxCodigoProducto.TabIndex = 0
        Me.TextBoxCodigoProducto.UseWaitCursor = True
        '
        'LabelDescripcionProductos
        '
        Me.LabelDescripcionProductos.AutoSize = True
        Me.LabelDescripcionProductos.Location = New System.Drawing.Point(40, 112)
        Me.LabelDescripcionProductos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelDescripcionProductos.Name = "LabelDescripcionProductos"
        Me.LabelDescripcionProductos.Size = New System.Drawing.Size(115, 24)
        Me.LabelDescripcionProductos.TabIndex = 557
        Me.LabelDescripcionProductos.Text = "Descripción:"
        '
        'LabelPrecioProductos
        '
        Me.LabelPrecioProductos.AutoSize = True
        Me.LabelPrecioProductos.Location = New System.Drawing.Point(39, 158)
        Me.LabelPrecioProductos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelPrecioProductos.Name = "LabelPrecioProductos"
        Me.LabelPrecioProductos.Size = New System.Drawing.Size(69, 24)
        Me.LabelPrecioProductos.TabIndex = 556
        Me.LabelPrecioProductos.Text = "Precio:"
        '
        'DataGridViewProductos
        '
        Me.DataGridViewProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewProductos.GridColor = System.Drawing.SystemColors.ControlLight
        Me.DataGridViewProductos.Location = New System.Drawing.Point(42, 205)
        Me.DataGridViewProductos.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridViewProductos.Name = "DataGridViewProductos"
        Me.DataGridViewProductos.Size = New System.Drawing.Size(958, 261)
        Me.DataGridViewProductos.StandardTab = True
        Me.DataGridViewProductos.TabIndex = 552
        '
        'LabelTtituloProductos
        '
        Me.LabelTtituloProductos.AutoSize = True
        Me.LabelTtituloProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTtituloProductos.Location = New System.Drawing.Point(37, 23)
        Me.LabelTtituloProductos.Name = "LabelTtituloProductos"
        Me.LabelTtituloProductos.Size = New System.Drawing.Size(212, 36)
        Me.LabelTtituloProductos.TabIndex = 567
        Me.LabelTtituloProductos.Text = "PRODUCTOS"
        '
        'TextBoxCantidadProducto
        '
        Me.TextBoxCantidadProducto.Location = New System.Drawing.Point(513, 152)
        Me.TextBoxCantidadProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxCantidadProducto.Name = "TextBoxCantidadProducto"
        Me.TextBoxCantidadProducto.Size = New System.Drawing.Size(120, 29)
        Me.TextBoxCantidadProducto.TabIndex = 40
        '
        'LabelCantidadProductos
        '
        Me.LabelCantidadProductos.AutoSize = True
        Me.LabelCantidadProductos.Location = New System.Drawing.Point(416, 155)
        Me.LabelCantidadProductos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelCantidadProductos.Name = "LabelCantidadProductos"
        Me.LabelCantidadProductos.Size = New System.Drawing.Size(89, 24)
        Me.LabelCantidadProductos.TabIndex = 568
        Me.LabelCantidadProductos.Text = "Cantidad:"
        '
        'ComboUnidadProducto
        '
        Me.ComboUnidadProducto.FormattingEnabled = True
        Me.ComboUnidadProducto.Items.AddRange(New Object() {"UNIDAD", "BOTELLA", "CAJA", "POTE", "BOLSA", "SOBRE", "TARRO", "LATA", "SACO", "PAQUETE", "CORTE", "KG", "GR", "LT", "CC"})
        Me.ComboUnidadProducto.Location = New System.Drawing.Point(513, 69)
        Me.ComboUnidadProducto.Name = "ComboUnidadProducto"
        Me.ComboUnidadProducto.Size = New System.Drawing.Size(120, 32)
        Me.ComboUnidadProducto.TabIndex = 10
        '
        'LabelCodigoProductos
        '
        Me.LabelCodigoProductos.AutoSize = True
        Me.LabelCodigoProductos.Location = New System.Drawing.Point(39, 71)
        Me.LabelCodigoProductos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelCodigoProductos.Name = "LabelCodigoProductos"
        Me.LabelCodigoProductos.Size = New System.Drawing.Size(76, 24)
        Me.LabelCodigoProductos.TabIndex = 555
        Me.LabelCodigoProductos.Text = "Código:"
        '
        'GroupBoxBotonera
        '
        Me.GroupBoxBotonera.Controls.Add(Me.ButtonClean)
        Me.GroupBoxBotonera.Controls.Add(Me.ButtonAdd)
        Me.GroupBoxBotonera.Controls.Add(Me.ButtonDelete)
        Me.GroupBoxBotonera.Controls.Add(Me.ButtonSave)
        Me.GroupBoxBotonera.Location = New System.Drawing.Point(695, 99)
        Me.GroupBoxBotonera.Name = "GroupBoxBotonera"
        Me.GroupBoxBotonera.Size = New System.Drawing.Size(305, 80)
        Me.GroupBoxBotonera.TabIndex = 569
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
        'FormProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1047, 512)
        Me.Controls.Add(Me.GroupBoxBotonera)
        Me.Controls.Add(Me.ComboUnidadProducto)
        Me.Controls.Add(Me.TextBoxCantidadProducto)
        Me.Controls.Add(Me.LabelCantidadProductos)
        Me.Controls.Add(Me.LabelTtituloProductos)
        Me.Controls.Add(Me.LabelUnidadProductos)
        Me.Controls.Add(Me.TextBoxDescripcionProducto)
        Me.Controls.Add(Me.TextBoxPrecioProducto)
        Me.Controls.Add(Me.TextBoxCodigoProducto)
        Me.Controls.Add(Me.LabelDescripcionProductos)
        Me.Controls.Add(Me.LabelPrecioProductos)
        Me.Controls.Add(Me.LabelCodigoProductos)
        Me.Controls.Add(Me.DataGridViewProductos)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProductos"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.DataGridViewProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxBotonera.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelUnidadProductos As System.Windows.Forms.Label
    Friend WithEvents TextBoxDescripcionProducto As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPrecioProducto As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCodigoProducto As System.Windows.Forms.TextBox
    Friend WithEvents LabelDescripcionProductos As System.Windows.Forms.Label
    Friend WithEvents LabelPrecioProductos As System.Windows.Forms.Label
    Friend WithEvents DataGridViewProductos As System.Windows.Forms.DataGridView
    Friend WithEvents LabelTtituloProductos As System.Windows.Forms.Label
    Friend WithEvents TextBoxCantidadProducto As System.Windows.Forms.TextBox
    Friend WithEvents LabelCantidadProductos As System.Windows.Forms.Label
    Friend WithEvents ComboUnidadProducto As System.Windows.Forms.ComboBox
    Friend WithEvents LabelCodigoProductos As System.Windows.Forms.Label
    Friend WithEvents GroupBoxBotonera As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonClean As System.Windows.Forms.Button
    Friend WithEvents ButtonAdd As System.Windows.Forms.Button
    Friend WithEvents ButtonDelete As System.Windows.Forms.Button
    Friend WithEvents ButtonSave As System.Windows.Forms.Button
End Class
