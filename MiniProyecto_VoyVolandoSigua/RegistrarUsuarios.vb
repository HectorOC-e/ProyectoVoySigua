Public Class RegistrarUsuarios
    Dim ConexionBaseClientes As ConexionBaseClientes = New ConexionBaseClientes()
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

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click


        Try
            If Me.ValidateChildren And txtIdentidad.Text <> String.Empty And txtNombreCompleto.Text <> String.Empty And txtEdad.Text <> String.Empty And (chkFemenino.Checked = True Or chkMasculino.Checked = True) And txtDireccion.Text <> String.Empty And IsNumeric(txtEdad.Text) Then
                If chkFemenino.Checked = True Then
                    Usuario.genero = "Femenino"
                ElseIf chkMasculino.Checked = True Then
                    Usuario.genero = "Masculino"
                End If
                RegistrarUsuario(Usuario)
                MessageBox.Show("Cliente Guardado exitosamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Mandados.Show()
            Else
                MessageBox.Show("Verifique que todos los campos esten completos y escritos correctamente", "Casillas", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub RegistrarUsuario(ByVal genero As Propiedades)
        Dim identidad, NombreCompleto, edad, direccion, sexo As New Propiedades
        Try
            identidad.id = txtIdentidad.Text
            NombreCompleto.NombreComp = txtNombreCompleto.Text
            edad.Edad = txtEdad.Text
            sexo.genero = genero.genero
            direccion.DireccionDom = txtDireccion.Text

            If ConexionBaseClientes.Registrar(identidad, NombreCompleto, edad, direccion, sexo) Then
                MessageBox.Show("Usuario registrado correctamente", "Registrando", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("Error al registrar", "Registrando", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chkMasculino_CheckedChanged(sender As Object, e As EventArgs) Handles chkMasculino.CheckedChanged
        If chkMasculino.Checked = True Then
            chkFemenino.Enabled = False
        Else
            chkFemenino.Enabled = True
        End If
    End Sub

    Private Sub chkFemenino_CheckedChanged(sender As Object, e As EventArgs) Handles chkFemenino.CheckedChanged
        If chkFemenino.Checked = True Then
            chkMasculino.Enabled = False
        Else
            chkMasculino.Enabled = True
        End If
    End Sub

    Private Sub RegistrarUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtIdentidad.Text = Usuarios.IdentidadTemp
    End Sub

    Private Sub txtNombreCompleto_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNombreCompleto.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorValidacion.SetError(sender, "")
        Else
            Me.ErrorValidacion.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub

    Private Sub txtEdad_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtEdad.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
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

    Private Sub chkFemenino_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles chkFemenino.Validating
        If chkFemenino.Checked = True Or chkMasculino.Checked = True Then
            Me.ErrorValidacion.SetError(sender, "")
        Else
            Me.ErrorValidacion.SetError(sender, "Es necesario seleccionar una de ambas")
        End If
    End Sub

    Private Sub chkMasculino_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles chkMasculino.Validating
        If chkFemenino.Checked = True Or chkMasculino.Checked = True Then
            Me.ErrorValidacion.SetError(sender, "")
        Else
            Me.ErrorValidacion.SetError(sender, "Es necesario seleccionar una de ambas")
        End If
    End Sub

    Private Sub txtDireccion_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDireccion.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorValidacion.SetError(sender, "")
        Else
            Me.ErrorValidacion.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub

    Private Sub txtNombreCompleto_MouseHover(sender As Object, e As EventArgs) Handles txtNombreCompleto.MouseHover
        ToolTip.SetToolTip(txtNombreCompleto, "Nombre completo del cliente")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtEdad_MouseHover(sender As Object, e As EventArgs) Handles txtEdad.MouseHover
        ToolTip.SetToolTip(txtEdad, "Edad del cliente")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtIdentidad_MouseHover(sender As Object, e As EventArgs) Handles txtIdentidad.MouseHover
        ToolTip.SetToolTip(txtIdentidad, "Identidad del cliente")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub chkMasculino_MouseHover(sender As Object, e As EventArgs) Handles chkMasculino.MouseHover
        ToolTip.SetToolTip(txtIdentidad, "Masculino")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub chkFemenino_MouseHover(sender As Object, e As EventArgs) Handles chkFemenino.MouseHover
        ToolTip.SetToolTip(txtIdentidad, "Femenino")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtDireccion_MouseHover(sender As Object, e As EventArgs) Handles txtDireccion.MouseHover
        ToolTip.SetToolTip(txtIdentidad, "Dirección del domicilio del cliente")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub


    Private Sub txtNombreCompleto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreCompleto.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub



    Private Sub txtEdad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEdad.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class
