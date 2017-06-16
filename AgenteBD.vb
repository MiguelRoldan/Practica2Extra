Imports System.Data.OleDb
Public Class AgenteBD
    Private Shared CadConexion = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
    Private Shared mConexion As OleDbConnection
    Private Shared instancia As AgenteBD = Nothing
    Private Shared Ruta_ As String
    Public Shared Property Ruta As String
        Get
            Return Ruta_
        End Get
        Set(value As String)
            Ruta_ = value
        End Set
    End Property

    Private Sub New()
        AgenteBD.mConexion = New OleDbConnection
        AgenteBD.mConexion.ConnectionString = CadConexion & Ruta

        AgenteBD.mConexion.Open()
        ''Catch excepcion As Exception
        'MessageBox.Show("Error al conectar con datos" & ControlChars.CrLf & excepcion.Message & ControlChars.CrLf & excepcion.Source())
        'End Try ''
    End Sub

    Public Shared Function getAgente() As AgenteBD
        If instancia Is Nothing Then
            instancia = New AgenteBD()
        End If
        Return instancia
    End Function

    Public Function read(ByVal sql As String) As OleDbDataReader
        Dim com As New OleDbCommand(sql, mConexion)
        Return com.ExecuteReader()
    End Function

    Public Function create(ByVal sql As String) As Integer
        Dim com As New OleDbCommand(sql, mConexion)
        Return com.ExecuteNonQuery()
    End Function

    Public Function update(ByVal sql As String) As Integer
        Dim com As New OleDbCommand(sql, mConexion)
        Return com.ExecuteNonQuery()
    End Function

    Public Function delete(ByVal sql As String) As Integer
        Dim com As New OleDbCommand(sql, mConexion)
        Return com.ExecuteNonQuery()
    End Function
End Class
