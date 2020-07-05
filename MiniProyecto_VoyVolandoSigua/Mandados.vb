Imports System.ComponentModel
Imports System.Text

Public Class Mandados
    Dim ConexionBaseClientes As ConexionBaseClientes = New ConexionBaseClientes()
    Dim Usuario As String
    Public Tiempo As Integer

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

    Private Sub txtIdentidad_MouseHover(sender As Object, e As EventArgs) Handles txtIdentidad.MouseHover
        ToolTip.SetToolTip(txtIdentidad, "Identidad del cliente")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtDistancia2_MouseHover(sender As Object, e As EventArgs) Handles txtDistancia2.MouseHover
        ToolTip.SetToolTip(txtDistancia2, "Distancia de la entrega(Km)")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub
    Private Sub txtDistancia1_MouseHover(sender As Object, e As EventArgs) Handles txtDistancia1.MouseHover
        ToolTip.SetToolTip(txtDistancia1, "Distancia de la entrega(Km)")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub cmbTipoMandado_MouseHover(sender As Object, e As EventArgs) Handles cmbTipoMandado.MouseHover
        ToolTip.SetToolTip(cmbTipoMandado, "Tipo de mandado a realizar")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtPrecio_MouseHover(sender As Object, e As EventArgs) Handles txtPrecio.MouseHover
        ToolTip.SetToolTip(txtPrecio, "Costo del mandado")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub btnMandado_MouseHover(sender As Object, e As EventArgs) Handles btnMandado.MouseHover
        ToolTip.SetToolTip(btnMandado, "carga los datos del mandado")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub
    Private Sub VerificarPrecio()
        If Usuarios.viajegratis = 5 Then
            txtPrecio.Text = "Viaje Gratis"
            Usuarios.PrecioF = 0
        ElseIf txtDistancia2.Text <> "" And txtDistancia1.Text <> "" Then
            Usuarios.PrecioF = (Val(txtDistancia2.Text) + Val(txtDistancia1.Text)) * 0.1
            txtPrecio.Text = Usuarios.PrecioF
        Else
            txtPrecio.Text = ""
        End If
    End Sub

    Private Sub Mandados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtIdentidad.Text = Usuarios.IdentidadTemp
        Try
            Dim queryAdress As New StringBuilder
            queryAdress.Append("https://www.google.com/maps/place/Siguatepeque/")

            Gmap.Navigate(queryAdress.ToString)
            Gmap.ScriptErrorsSuppressed = True
        Catch ex As Exception
            MessageBox.Show("No ha podido cargarse correctamente el mapa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        MsgBox("Datos Registrados, Envie un motorista")

    End Sub

    Private Sub btnMandado_Click(sender As Object, e As EventArgs) Handles btnMandado.MouseClick
        Dim Historial As Integer

        Try
            If Me.ValidateChildren And txtDistancia2.Text <> String.Empty And cmbTipoMandado.Text <> String.Empty And IsNumeric(txtDistancia2.Text) And IsNumeric(txtDistancia2.Text) And IsNumeric(txtTiempo.Text) Then
                Usuarios.IdentidadTemp = txtIdentidad.Text
                Usuarios.Recorrido = Val(txtDistancia2.Text) + Val(txtDistancia1.Text)
                Usuarios.TipoMandado = cmbTipoMandado.SelectedItem
                Historial = RecuperarHistorial()
                Usuarios.historialmandado = Historial + 1
                Tiempo = Val(txtTiempo.Text)
                Usuarios.tiempo = Tiempo
                Motoristas.Show()
            Else
                MessageBox.Show("Asegurese de ingresar todos los datos correctamente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Function RecuperarHistorial()

        Usuario = Usuarios.IdentidadTemp
        Return ConexionBaseClientes.RecuperarDatos(Usuario, 8)

    End Function
    Private Sub txtDistancia2_TextChanged(sender As Object, e As EventArgs) Handles txtDistancia2.TextChanged
        VerificarPrecio()
    End Sub

    Private Sub txtDistancia2_Validating(sender As Object, e As CancelEventArgs) Handles txtDistancia2.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorProvider.SetError(sender, "")
        Else
            Me.ErrorProvider.SetError(sender, " Campo es obligatorio")
        End If
    End Sub
    Private Sub txtDistancia1_Validating(sender As Object, e As CancelEventArgs) Handles txtDistancia1.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorProvider.SetError(sender, "")
        Else
            Me.ErrorProvider.SetError(sender, " Campo es obligatorio")
        End If
    End Sub

    Private Sub txtIdentidad_Validating(sender As Object, e As CancelEventArgs) Handles txtIdentidad.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorProvider.SetError(sender, "")
        Else
            Me.ErrorProvider.SetError(sender, " Campo es obligatorio")
        End If
    End Sub

    Private Sub txtDistancia1_TextChanged(sender As Object, e As EventArgs) Handles txtDistancia1.TextChanged
        VerificarPrecio()
    End Sub

    Private Sub btnMandado_Click_1(sender As Object, e As EventArgs) Handles btnMandado.Click

    End Sub
End Class