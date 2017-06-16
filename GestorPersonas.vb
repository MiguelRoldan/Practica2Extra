Imports System.Data.OleDb

Public Class GestorPersonas
    Private _Collection As Collection
    Dim persona As Persona
    Dim agente As AgenteBD
    Dim bbdd As OleDbDataReader
    Dim num As Integer

    Public Sub New()
        Me.Collection = New Collection
    End Sub

    Public Property Collection As Collection
        Get
            Return _Collection
        End Get
        Set(value As Collection)
            _Collection = value
        End Set
    End Property

    Public Sub readAll()
        agente = AgenteBD.getAgente
        bbdd = agente.read("SELECT * FROM PERSONAS")
        While bbdd.Read()
            persona = New Persona(bbdd(0), bbdd(1))
            Me.Collection.Add(persona)
        End While
    End Sub

    Public Sub readPersona(ByRef persona As Persona)
        agente = AgenteBD.getAgente
        bbdd = agente.read("SELECT * FROM PERSONAS WHERE DNI='" & persona.dni & "';")
        While bbdd.Read()
            persona.dni = bbdd(0)
            persona.nombre = bbdd(1)
        End While
    End Sub


    Public Function insert(ByRef persona As Persona) As Integer
        agente = AgenteBD.getAgente()
        Dim sql As String
        sql = "INSERT INTO Personas VALUES ('" & persona.dni & "','" & persona.nombre & "');"
        MessageBox.Show(sql)
        Return agente.create(sql)

    End Function

    Public Function update(ByRef persona As Persona) As Integer
        agente = AgenteBD.getAgente()
        num = agente.create("UPDATE Gente Personas Nombre='" & persona.nombre & "'WHERE DNI='" & persona.dni & "';")
        Return num
    End Function

    Public Function delete(ByRef persona As Persona) As Integer
        agente = AgenteBD.getAgente()

        num = agente.delete("DELETE FROM Personas WHERE DNI='" & persona.dni & "';")
        Return num
    End Function

End Class
