Public Class Propiedades
    Private _Identidad As String
    Private _NombreCompleto As String
    Private _Direccion As String
    Private _Edad As Integer
    Private _Genero As String
    Private _NombreMotorista As String
    Private _EstadoMotorista As String
    Private _TipoMandado As String
    Private _Precio As Double
    Private _Recorrido As Double
    Private _HistorialMandados As Integer

    Public Property id As String
        Get
            Return _Identidad
        End Get
        Set(value As String)
            _Identidad = value
        End Set
    End Property
    Public Property NombreComp As String
        Get
            Return _NombreCompleto
        End Get
        Set(value As String)
            _NombreCompleto = value
        End Set
    End Property

    Public Property DireccionDom As String
        Get
            Return _Direccion
        End Get
        Set(value As String)
            _Direccion = value
        End Set
    End Property

    Public Property Edad As Integer
        Get
            Return _Edad
        End Get
        Set(value As Integer)
            _Edad = value
        End Set
    End Property
    Public Property genero As String
        Get
            Return _Genero
        End Get
        Set(value As String)
            _Genero = value
        End Set
    End Property
    Public Property NombreMotorista As String
        Get
            Return _NombreMotorista
        End Get
        Set(value As String)
            _NombreMotorista = value
        End Set
    End Property
    Public Property estadoMotorista As String
        Get
            Return _EstadoMotorista
        End Get
        Set(value As String)
            _EstadoMotorista = value
        End Set
    End Property
    Public Property TipoMandado As String
        Get
            Return _TipoMandado
        End Get
        Set(value As String)
            _TipoMandado = value
        End Set
    End Property

    Public Property Precio As Double
        Get
            Return _Precio
        End Get
        Set(value As Double)
            _Precio = value
        End Set
    End Property

    Public Property Recorrido As Double
        Get
            Return _Recorrido
        End Get
        Set(value As Double)
            _Recorrido = value
        End Set
    End Property
    Public Property historialMandados As Integer
        Get
            Return _HistorialMandados
        End Get
        Set(value As Integer)
            _HistorialMandados = value
        End Set
    End Property
End Class
