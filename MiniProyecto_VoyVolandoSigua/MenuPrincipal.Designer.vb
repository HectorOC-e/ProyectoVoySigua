<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuPrincipal
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
        Me.btnBuscarUsuario = New System.Windows.Forms.Button()
        Me.btnBaseDeClientes = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnBuscarUsuario
        '
        Me.btnBuscarUsuario.FlatAppearance.BorderColor = System.Drawing.Color.Cyan
        Me.btnBuscarUsuario.FlatAppearance.BorderSize = 2
        Me.btnBuscarUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan
        Me.btnBuscarUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnBuscarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarUsuario.Image = Global.MiniProyecto_VoyVolandoSigua.My.Resources.Resources.motorcycle_64px
        Me.btnBuscarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarUsuario.Location = New System.Drawing.Point(10, 208)
        Me.btnBuscarUsuario.Name = "btnBuscarUsuario"
        Me.btnBuscarUsuario.Size = New System.Drawing.Size(335, 64)
        Me.btnBuscarUsuario.TabIndex = 0
        Me.btnBuscarUsuario.Text = "Ingresar Mandado"
        Me.btnBuscarUsuario.UseVisualStyleBackColor = True
        '
        'btnBaseDeClientes
        '
        Me.btnBaseDeClientes.FlatAppearance.BorderColor = System.Drawing.Color.Cyan
        Me.btnBaseDeClientes.FlatAppearance.BorderSize = 2
        Me.btnBaseDeClientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan
        Me.btnBaseDeClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnBaseDeClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBaseDeClientes.Image = Global.MiniProyecto_VoyVolandoSigua.My.Resources.Resources.database_administrator_64px
        Me.btnBaseDeClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBaseDeClientes.Location = New System.Drawing.Point(12, 293)
        Me.btnBaseDeClientes.Name = "btnBaseDeClientes"
        Me.btnBaseDeClientes.Size = New System.Drawing.Size(335, 60)
        Me.btnBaseDeClientes.TabIndex = 1
        Me.btnBaseDeClientes.Text = "Base de clientes"
        Me.btnBaseDeClientes.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Cyan
        Me.btnSalir.FlatAppearance.BorderSize = 2
        Me.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan
        Me.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Image = Global.MiniProyecto_VoyVolandoSigua.My.Resources.Resources.close_window_64px
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(10, 369)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(335, 61)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Engravers MT", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(255, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Menu Principal"
        '
        'MenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.MiniProyecto_VoyVolandoSigua.My.Resources.Resources.images__2_
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(357, 466)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnBaseDeClientes)
        Me.Controls.Add(Me.btnBuscarUsuario)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MenuPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MenuPrincipal"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnBuscarUsuario As Button
    Friend WithEvents btnBaseDeClientes As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents Label1 As Label
End Class
