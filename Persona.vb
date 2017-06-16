Public Class Persona
    Private _dni As String
    Private _nombre As String
    Private _GestorPersonas As GestorPersonas

    Public Sub New(ByVal dni As String, ByVal nombre As String)
        Me.dni = dni
        Me.nombre = nombre
        Me.GestorPersonas = New GestorPersonas()
    End Sub

    Public Sub New()
        Me.GestorPersonas = New GestorPersonas()
    End Sub

    Public Property dni As String
        Get
            Return _dni
        End Get
        Set(value As String)
            _dni = value
        End Set
    End Property

    Public Property nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property GestorPersonas As GestorPersonas
        Get
            Return _GestorPersonas
        End Get
        Set(value As GestorPersonas)
            _GestorPersonas = value
        End Set
    End Property

    Public Sub leerTodo()
        GestorPersonas.readAll()
    End Sub

    Public Sub leer(ByVal dni As String)
        Me.dni = dni
        GestorPersonas.readPersona(Me)
    End Sub

    Public Function insertar()
        Return GestorPersonas.insert(Me)

    End Function

    Public Sub actualizar()
        GestorPersonas.update(Me)
    End Sub

    Public Sub borrar()
        GestorPersonas.delete(Me)
    End Sub

End Class
