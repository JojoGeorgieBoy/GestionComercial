<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteVentas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteVentas))
        Me.LabelTtituloVentas = New System.Windows.Forms.Label()
        Me.ButtonBuscarProductos = New System.Windows.Forms.Button()
        Me.DataGridViewNomArch = New System.Windows.Forms.DataGridView()
        Me.DataGridViewReporteVentasConsolidado = New System.Windows.Forms.DataGridView()
        Me.DataGridViewReporteVentasDetalle = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DataGridViewNomArch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewReporteVentasConsolidado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewReporteVentasDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelTtituloVentas
        '
        Me.LabelTtituloVentas.AutoSize = True
        Me.LabelTtituloVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTtituloVentas.Location = New System.Drawing.Point(59, 34)
        Me.LabelTtituloVentas.Name = "LabelTtituloVentas"
        Me.LabelTtituloVentas.Size = New System.Drawing.Size(77, 25)
        Me.LabelTtituloVentas.TabIndex = 558
        Me.LabelTtituloVentas.Text = "Fecha"
        '
        'ButtonBuscarProductos
        '
        Me.ButtonBuscarProductos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonBuscarProductos.Image = CType(resources.GetObject("ButtonBuscarProductos.Image"), System.Drawing.Image)
        Me.ButtonBuscarProductos.Location = New System.Drawing.Point(811, 29)
        Me.ButtonBuscarProductos.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonBuscarProductos.Name = "ButtonBuscarProductos"
        Me.ButtonBuscarProductos.Size = New System.Drawing.Size(33, 30)
        Me.ButtonBuscarProductos.TabIndex = 802
        Me.ButtonBuscarProductos.UseVisualStyleBackColor = True
        '
        'DataGridViewNomArch
        '
        Me.DataGridViewNomArch.BackgroundColor = System.Drawing.Color.White
        Me.DataGridViewNomArch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewNomArch.GridColor = System.Drawing.SystemColors.ControlLight
        Me.DataGridViewNomArch.Location = New System.Drawing.Point(56, 64)
        Me.DataGridViewNomArch.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridViewNomArch.Name = "DataGridViewNomArch"
        Me.DataGridViewNomArch.Size = New System.Drawing.Size(103, 340)
        Me.DataGridViewNomArch.StandardTab = True
        Me.DataGridViewNomArch.TabIndex = 804
        '
        'DataGridViewReporteVentasConsolidado
        '
        Me.DataGridViewReporteVentasConsolidado.BackgroundColor = System.Drawing.Color.White
        Me.DataGridViewReporteVentasConsolidado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewReporteVentasConsolidado.GridColor = System.Drawing.SystemColors.ControlLight
        Me.DataGridViewReporteVentasConsolidado.Location = New System.Drawing.Point(187, 64)
        Me.DataGridViewReporteVentasConsolidado.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridViewReporteVentasConsolidado.Name = "DataGridViewReporteVentasConsolidado"
        Me.DataGridViewReporteVentasConsolidado.Size = New System.Drawing.Size(167, 340)
        Me.DataGridViewReporteVentasConsolidado.StandardTab = True
        Me.DataGridViewReporteVentasConsolidado.TabIndex = 805
        '
        'DataGridViewReporteVentasDetalle
        '
        Me.DataGridViewReporteVentasDetalle.BackgroundColor = System.Drawing.Color.White
        Me.DataGridViewReporteVentasDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewReporteVentasDetalle.GridColor = System.Drawing.SystemColors.ControlLight
        Me.DataGridViewReporteVentasDetalle.Location = New System.Drawing.Point(385, 64)
        Me.DataGridViewReporteVentasDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridViewReporteVentasDetalle.Name = "DataGridViewReporteVentasDetalle"
        Me.DataGridViewReporteVentasDetalle.Size = New System.Drawing.Size(459, 340)
        Me.DataGridViewReporteVentasDetalle.StandardTab = True
        Me.DataGridViewReporteVentasDetalle.TabIndex = 806
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(190, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 25)
        Me.Label1.TabIndex = 807
        Me.Label1.Text = "Ventas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(380, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 25)
        Me.Label2.TabIndex = 808
        Me.Label2.Text = "Detalle"
        '
        'ReporteVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(901, 465)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridViewReporteVentasDetalle)
        Me.Controls.Add(Me.DataGridViewReporteVentasConsolidado)
        Me.Controls.Add(Me.DataGridViewNomArch)
        Me.Controls.Add(Me.ButtonBuscarProductos)
        Me.Controls.Add(Me.LabelTtituloVentas)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReporteVentas"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.DataGridViewNomArch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewReporteVentasConsolidado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewReporteVentasDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelTtituloVentas As System.Windows.Forms.Label
    Friend WithEvents ButtonBuscarProductos As System.Windows.Forms.Button
    Friend WithEvents DataGridViewNomArch As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewReporteVentasConsolidado As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewReporteVentasDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
