Public Class BuscarUsuario
    Dim ConexionBaseClientes As ConexionBaseClientes = New ConexionBaseClientes()
    Dim DataT As New DataTable
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
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        If txtIdentidad.Text.Length = 13 And IsNumeric(txtIdentidad.Text) Then

            If buscarusuario() = 1 Then
                Usuarios.IdentidadTemp = txtIdentidad.Text
                PrevisualizacionDatos.Show()
            Else
                Usuarios.IdentidadTemp = txtIdentidad.Text
                MessageBox.Show("No se encontro registro del cliente en el sistema,se registrara el cliente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Hide()
                RegistrarUsuarios.Show()
            End If
        Else
            MessageBox.Show("Ingrese un numero de identidad valido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub
    Function buscarusuario()
        Dim Usuario As New Propiedades
        Try
            Usuario.id = txtIdentidad.Text
            DataT = ConexionBaseClientes.BuscarCliente(Usuario)
            If DataT.Rows.Count <> 0 Then
                MessageBox.Show("Usuario Existente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return 1
            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub txtIdentidad_MouseHover(sender As Object, e As EventArgs) Handles txtIdentidad.MouseHover
        ToolTip.SetToolTip(txtIdentidad, "Identidad del cliente")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub btnBuscar_MouseHover(sender As Object, e As EventArgs) Handles btnBuscar.MouseHover
        ToolTip.SetToolTip(btnBuscar, "Busca al cliente en la base de datos")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtIdentidad_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtIdentidad.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorValidacion.SetError(sender, "")
        Else
            Me.ErrorValidacion.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub
End Class