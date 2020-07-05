'Imports System.Runtime.InteropServices
Imports System.ComponentModel
Public Class login

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Application.Exit()

    End Sub
    Private Sub CustomizeComponents()
        ' txtUsername.
        txtusuario.AutoSize = False
        txtusuario.Size = New Size(250, 30)
        'txtPassword
        txtcontrasena.AutoSize = False
        txtcontrasena.Size = New Size(250, 30)
        txtcontrasena.UseSystemPasswordChar = True
    End Sub
    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CustomizeComponents()
    End Sub
    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized

    End Sub



    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click

        Dim usuario, contrasena As String
        usuario = txtusuario.Text
        contrasena = txtcontrasena.Text

        If (usuario = "Administrador") And (contrasena = "Entornos2020") Then
            MsgBox("Accediendo")
            Me.Hide()
            CargandoSistema.Show()
        Else
            MsgBox("usuario y contraseña incorrectos intenta de nuevo")
        End If
    End Sub

    Private Sub txtusuario_Validating(sender As Object, e As CancelEventArgs) Handles txtusuario.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorProvider.SetError(sender, "")
        Else
            Me.ErrorProvider.SetError(sender, "Ingrese El usuario, este campo es obligatorio")
        End If
    End Sub



    Private Sub txtcontrasena_Validating(sender As Object, e As CancelEventArgs) Handles txtcontrasena.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorProvider.SetError(sender, "")
        Else
            Me.ErrorProvider.SetError(sender, "Ingrese la contrasena, este campo es obligatorio")
        End If
    End Sub

    Private Sub txtcontrasena_MouseHover(sender As Object, e As EventArgs) Handles txtcontrasena.MouseHover
        Toolmsj.SetToolTip(txtcontrasena, "ingrese la contrasena")
        Toolmsj.ToolTipTitle = "contrasena"
    End Sub

    Private Sub txtusuario_MouseHover(sender As Object, e As EventArgs) Handles txtusuario.MouseHover
        Toolmsj.SetToolTip(txtusuario, "ingrese el usuario")
        Toolmsj.ToolTipTitle = "usuario"
    End Sub

End Class