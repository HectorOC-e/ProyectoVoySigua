Imports System.ComponentModel

Public Class PrevisualizacionDatos
    Dim ConexionBaseClientes As ConexionBaseClientes = New ConexionBaseClientes()
    Dim Usuario As String
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
    Private Sub PrevisualizacionDatos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Usuario = Usuarios.IdentidadTemp
        txtIdentidad.Text = ConexionBaseClientes.RecuperarDatos(Usuario, 0)
        txtNombreCompleto.Text = ConexionBaseClientes.RecuperarDatos(Usuario, 1)
        txtEdad.Text = ConexionBaseClientes.RecuperarDatos(Usuario, 3)
        txtHistorial.Text = ConexionBaseClientes.RecuperarDatos(Usuario, 8)
        If ConexionBaseClientes.RecuperarDatos(Usuario, 4) = "Femenino" Then
            chkFemenino.Checked = True
        Else
            chkMasculino.Checked = True
        End If
        Usuarios.viajegratis = txtHistorial.Text
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Me.Close()
        BuscarUsuario.Hide()
        Mandados.Show()

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtIdentidad_MouseHover(sender As Object, e As EventArgs) Handles txtIdentidad.MouseHover
        ToolTip.SetToolTip(txtIdentidad, "Identidad del cliente")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtNombreCompleto_MouseHover(sender As Object, e As EventArgs) Handles txtNombreCompleto.MouseHover
        ToolTip.SetToolTip(txtNombreCompleto, "nombre del cliente")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtEdad_MouseHover(sender As Object, e As EventArgs) Handles txtEdad.MouseHover
        ToolTip.SetToolTip(txtEdad, "Edad de cliente")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub chkMasculino_MouseHover(sender As Object, e As EventArgs) Handles chkMasculino.MouseHover
        ToolTip.SetToolTip(chkMasculino, "Masculino")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub chkFemenino_MouseHover(sender As Object, e As EventArgs) Handles chkFemenino.MouseHover
        ToolTip.SetToolTip(chkFemenino, "Femenino")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub btnCancelar_MouseHover(sender As Object, e As EventArgs) Handles btnCancelar.MouseHover
        ToolTip.SetToolTip(btnCancelar, "Cancela la revision de informacion")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub btnAceptar_MouseHover(sender As Object, e As EventArgs) Handles btnAceptar.MouseHover
        ToolTip.SetToolTip(btnAceptar, "Informacion correcta")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtHistorial_MouseHover(sender As Object, e As EventArgs) Handles txtHistorial.MouseHover
        ToolTip.SetToolTip(txtHistorial, "Historial de mandados del cliente")
        ToolTip.ToolTipTitle = "Aviso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

End Class