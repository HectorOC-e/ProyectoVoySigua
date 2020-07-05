Imports System.Data.SqlClient
Public Class ConexionBaseClientes
    Public conexion As SqlConnection = New SqlConnection("Data Source= HECTOROS\SQLEXPRESS01;Initial Catalog=Delivery; Integrated Security=True")
    Private cmb As SqlCommandBuilder
    Public ds As DataSet = New DataSet()
    Public da As SqlDataAdapter
    Public lectura As SqlDataReader
    Public comando As SqlCommand
    Public cmd As New SqlCommand
    Public Sub conectar()
        Try
            conexion.Open()
            MessageBox.Show("Conectado con exito")
        Catch ex As Exception
            MessageBox.Show("No se ha podido acceder a la base de datos")
        Finally
            conexion.Close()
        End Try
    End Sub

    Public Function consultarBase()
        Try
            conexion.Open()
            Dim cmd As New SqlCommand("ConsultarBase", conexion)

            cmd.CommandType = CommandType.StoredProcedure
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
                conexion.Close()
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function eliminar(ByVal data As Propiedades) As Boolean
        Try
            conexion.Open()
            cmd = New SqlCommand("EliminarUsuario", conexion)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Identidad", data.id)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try

    End Function
    Public Function Actualizar(ByVal Id As Propiedades, ByVal Nombre As Propiedades, ByVal Edad As Propiedades, ByVal Direccion As Propiedades) As Boolean
        Try
            conexion.Open()
            cmd = New SqlCommand("ActualizarUsuario", conexion)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Identidad", Id.id)
            cmd.Parameters.AddWithValue("@NombreCompleto", Nombre.NombreComp)
            cmd.Parameters.AddWithValue("@Edad", Edad.Edad)
            cmd.Parameters.AddWithValue("@Direccion", Direccion.DireccionDom)


            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try
    End Function
    Public Function Registrar(ByVal Id As Propiedades, ByVal Nombre As Propiedades, ByVal Edad As Propiedades, ByVal Direccion As Propiedades, ByVal Genero As Propiedades) As Boolean
        Try
            conexion.Open()
            cmd = New SqlCommand("InsertarUsuario", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Identidad", Id.id)
            cmd.Parameters.AddWithValue("@NombreCompleto", Nombre.NombreComp)
            cmd.Parameters.AddWithValue("@Direccion", Direccion.DireccionDom)
            cmd.Parameters.AddWithValue("@Edad", Edad.Edad)
            cmd.Parameters.AddWithValue("@Genero", Genero.genero)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function BuscarCliente(ByVal Data As Propiedades)
        Try
            conexion.Open()
            cmd = New SqlCommand("BuscarUsuario", conexion)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@identidad", Data.id)

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                Return dt

            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conexion.Close()
        End Try
    End Function
    Public Function ValidarCliente(ByVal Data As Propiedades)
        Try
            conexion.Open()
            cmd = New SqlCommand("BuscarUsuario", conexion)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@identidad", Data.id)

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conexion.Close()
        End Try
    End Function
    'Identidad 0
    'NombreCompleto 1
    'Direccion 2
    'Edad 3 
    'Genero 4
    'NombreMotorista 5
    'EstadoMotorista 6 
    'TipoMandado 7 
    'Historial 8
    'Precio 9 
    'Recorrido 10
    Public Function RecuperarDatos(ByVal Data As String, ByVal columna As Integer)
        Dim texto As String
        Try
            conexion.Open()
            cmd = New SqlCommand("BuscarUsuario", conexion)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@identidad", Data)
            lectura = cmd.ExecuteReader()

            If lectura.Read() Then
                texto = lectura(columna).ToString()
                Return texto
            Else
                Return Nothing
            End If
            lectura.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conexion.Close()
        End Try
    End Function
    Public Function ActualizarEstadoMotorista(ByVal Nombre As Propiedades, ByVal estado As Propiedades) As Boolean

        Try
            conexion.Open()
            cmd = New SqlCommand("ActualizarEstadoMotorista", conexion)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@NombreMotorista", Nombre.NombreMotorista)
            cmd.Parameters.AddWithValue("@EstadoMotorista", estado.estadoMotorista)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function ActualizarMandado(ByVal Id As Propiedades, ByVal tipoMandado As Propiedades, ByVal Motorista As Propiedades, ByVal HistorialMandado As Propiedades, ByVal Precio As Propiedades, ByVal Recorrido As Propiedades) As Boolean
        Try
            conexion.Open()
            cmd = New SqlCommand("ActualizarMandado", conexion)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Identidad", Id.id)
            cmd.Parameters.AddWithValue("@TipoMandado", tipoMandado.TipoMandado)
            cmd.Parameters.AddWithValue("@motorista", Motorista.NombreMotorista)
            cmd.Parameters.AddWithValue("@HistorialMandados", HistorialMandado.historialMandados)
            cmd.Parameters.AddWithValue("@Precio", Precio.Precio)
            cmd.Parameters.AddWithValue("@Recorrido", Recorrido.Recorrido)


            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try
    End Function

End Class
