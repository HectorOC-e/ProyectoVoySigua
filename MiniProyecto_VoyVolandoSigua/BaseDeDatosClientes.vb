Public Class BaseDeDatosClientes
    Dim ConexionBaseClientes As ConexionBaseClientes = New ConexionBaseClientes()
    Dim DataT As New DataTable
    Dim Usuario As New Propiedades

    Dim ex, ey As Integer
    Dim Arrastre As Boolean

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        ex = e.X
        ey = e.Y
        Arrastre = True
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        Arrastre = False
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If Arrastre Then Me.Location = Me.PointToScreen(New Point(Me.MousePosition.X - Me.Location.X - ex, Me.MousePosition.Y - Me.Location.Y - ey))
    End Sub

    Private Sub BaseDeDatosClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbOperacion.SelectedItem = "Consultar Base"
    End Sub

    Private Sub btnRealizar_Click(sender As Object, e As EventArgs) Handles btnRealizar.Click
        If Me.ValidateChildren = True And txtIdentidad.Text.Length = 13 And txtIdentidad.Text <> "" Then
            Select Case cmbOperacion.SelectedIndex

                Case 0
                    eliminarUsuario()
                Case 1
                    If Me.ValidateChildren = True And txtIdentidad.Text.Length <> "" And txtNombreCompleto.Text.Length <> "" And txtEdad.Text.Length <> "" And txtDireccion.Text.Length <> "" Then
                        ActualizarUsuario()
                    End If
                Case 2
                    BuscarUsuario()
                Case Else
                    MessageBox.Show("Debe seleccionar una opcion de la operacion que desea realizar", "Error al realizar operación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Select

        Else
            MessageBox.Show("Debe ingresar una identidad correctamente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub consultarBase()
        Try
            DataT = ConexionBaseClientes.consultarBase
            If DataT.Rows.Count <> 0 Then
                dgvBaseDeClientes.DataSource = DataT
                ConexionBaseClientes.conexion.Close()
            Else
                dgvBaseDeClientes.DataSource = Nothing
                ConexionBaseClientes.conexion.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub eliminarUsuario()
        Try
            Usuario.id = txtIdentidad.Text
            If ConexionBaseClientes.eliminar(Usuario) Then
                MessageBox.Show("Usuario eliminado correctamente", "Eliminando", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtIdentidad.Text = ""
            Else
                MessageBox.Show("Usuario no encontrado", "Eliminando", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtIdentidad.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ActualizarUsuario()
        Dim identidad, NombreCompleto, edad, direccion As New Propiedades
        Try
            identidad.id = txtIdentidad.Text
            NombreCompleto.NombreComp = txtNombreCompleto.Text
            edad.Edad = txtEdad.Text
            direccion.DireccionDom = txtDireccion.Text
            If ConexionBaseClientes.Actualizar(identidad, NombreCompleto, edad, direccion) Then
                MessageBox.Show("Información Actualizado correctamente", "Actualizando", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtIdentidad.Text = ""
            Else
                MessageBox.Show("Usuario no encontrado", "Actualizando", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtIdentidad.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BuscarUsuario()
        Try
            Usuario.id = txtIdentidad.Text
            DataT = ConexionBaseClientes.BuscarCliente(Usuario)
            If DataT.Rows.Count <> 0 Then
                MessageBox.Show("Usuario Encontrado correctamente", "Buscando", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvBaseDeClientes.DataSource = DataT
                txtIdentidad.Text = ""
            Else
                MessageBox.Show("Usuario no encontrado", "Buscando", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dgvBaseDeClientes.DataSource = Nothing
                txtIdentidad.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbOperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOperacion.SelectedIndexChanged
        Select Case cmbOperacion.SelectedIndex
            Case 0
                txtDireccion.Enabled = False
                txtEdad.Enabled = False
                txtNombreCompleto.Enabled = False
                btnRealizar.Enabled = True
                txtIdentidad.Enabled = True
            Case 1
                txtDireccion.Enabled = True
                txtEdad.Enabled = True
                txtNombreCompleto.Enabled = True
                btnRealizar.Enabled = True
                txtIdentidad.Enabled = True
            Case 2
                txtDireccion.Enabled = False
                txtEdad.Enabled = False
                txtNombreCompleto.Enabled = False
                btnRealizar.Enabled = True
                txtIdentidad.Enabled = True
            Case 3
                txtIdentidad.Enabled = False
                txtDireccion.Enabled = False
                txtEdad.Enabled = False
                txtNombreCompleto.Enabled = False
                btnRealizar.Enabled = False
                consultarBase()
        End Select
    End Sub

    Private Sub txtIdentidad_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtIdentidad.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 And cmbOperacion.SelectedItem <> "Actualizar" Then
            Me.ErrorValidacion.SetError(sender, "")
        Else
            Me.ErrorValidacion.SetError(sender, " Campo Obligatorio para todas las operaciones")
        End If
    End Sub

    Private Sub txtNombreCompleto_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNombreCompleto.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 And cmbOperacion.SelectedItem <> "Actualizar" Then
            Me.ErrorValidacion.SetError(sender, "")
        Else
            Me.ErrorValidacion.SetError(sender, " Campo es obligatorio para actualizar")
        End If
    End Sub

    Private Sub txtEdad_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtEdad.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 And cmbOperacion.SelectedItem <> "Actualizar" Then
            Me.ErrorValidacion.SetError(sender, "")
            If (Val(txtEdad.Text) - Int(Val(txtEdad.Text)) = 0) Then
                Me.ErrorValidacion.SetError(sender, "")
            Else
                Me.ErrorValidacion.SetError(sender, "Ingrese una edad valida")
            End If
        Else
            Me.ErrorValidacion.SetError(sender, "Es un campo obligatorio")
        End If

    End Sub

    Private Sub txtDireccion_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDireccion.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 And cmbOperacion.SelectedItem <> "Actualizar" Then
            Me.ErrorValidacion.SetError(sender, "")
        Else
            Me.ErrorValidacion.SetError(sender, " Campo es obligatorio para actualizar")
        End If
    End Sub

    Private Sub dgvBaseDeClientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBaseDeClientes.CellContentClick
        txtIdentidad.Text = dgvBaseDeClientes.CurrentRow.Cells("Identidad").Value.ToString
        txtNombreCompleto.Text = dgvBaseDeClientes.CurrentRow.Cells("NombreCompleto").Value.ToString
        txtEdad.Text = dgvBaseDeClientes.CurrentRow.Cells("Edad").Value.ToString
        txtDireccion.Text = dgvBaseDeClientes.CurrentRow.Cells("Direccion").Value.ToString
    End Sub

    Private Sub txtIdentidad_MouseHover(sender As Object, e As EventArgs) Handles txtIdentidad.MouseHover
        ToolTip.SetToolTip(txtIdentidad, "Identidad del cliente")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtEdad_MouseHover(sender As Object, e As EventArgs) Handles txtEdad.MouseHover
        ToolTip.SetToolTip(txtEdad, "Edad del cliente")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtNombreCompleto_MouseHover(sender As Object, e As EventArgs) Handles txtNombreCompleto.MouseHover
        ToolTip.SetToolTip(txtNombreCompleto, "Nombre completo del usuario")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub

    Private Sub txtDireccion_MouseHover(sender As Object, e As EventArgs) Handles txtDireccion.MouseHover
        ToolTip.SetToolTip(txtDireccion, "Direccion del cliente")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub btnRegresar_MouseHover(sender As Object, e As EventArgs) Handles btnRegresar.MouseHover
        ToolTip.SetToolTip(btnRegresar, "Regresar al Menu Principal")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub
End Class