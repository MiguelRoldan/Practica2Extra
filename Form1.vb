Public Class Form1
    Dim ruta As String
    Dim Persona As Persona

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MessageBox.Show("¿Quieres abrir una base de datos?", "nueva sesion", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim ventanaAbrirBD As New OpenFileDialog()
            ventanaAbrirBD.Title = "Selecciona una base de datos"
            ventanaAbrirBD.Filter = "Archivos de base de datos|*.accdb"

            If ventanaAbrirBD.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                ventanaAbrirBD.OpenFile()
                ruta = ventanaAbrirBD.FileName
                AgenteBD.Ruta = ruta
            End If
        End If
        Try
            Persona = New Persona
            Persona.leerTodo()
            Dim pAux As Persona
            For Each pAux In Persona.GestorPersonas.Collection
                Me.ListBox.Items.Add(pAux.dni)
            Next

        Catch excepcion As Exception
            MessageBox.Show("Error al conectar con datos" & ControlChars.CrLf & excepcion.Message & ControlChars.CrLf & excepcion.Source())
        End Try ''

    End Sub

    Private Sub btnAñadir_Click(sender As Object, e As EventArgs) Handles btnAñadir.Click
        If txtDNI.Text.Equals("") Or txtNombre.Text.Equals("") Then
            MsgBox("ALGUNO DE LOS CAMPOS ESTÁ VACIO")
            Exit Sub
        End If
        Try
            Persona = New Persona(txtDNI.Text, txtNombre.Text)
            If Persona.insertar() = 1 Then

                MsgBox("EL REGISTRO HA SIDO AÑADIDO CON ÉXITO")
            End If
            'Form1_Load(sender, e)
        Catch ex As Exception
            MsgBox("FALLO AL INTRODUCIR EL REGISTRO" & ex.Source & ex.Message)
        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If txtDNI.Text.Equals("") Or txtNombre.Text.Equals("") Then
            MsgBox("ALGUNO DE LOS CAMPOS ESTÁ VACIO")
            Exit Sub
        End If
        Try
            Persona = New Persona(txtDNI.Text, txtNombre.Text)
            Persona.actualizar()
            MsgBox("EL REGISTRO HA SIDO MODIFICADO CON ÉXITO")
            Form1_Load(sender, e)
        Catch ex As Exception
            MsgBox("FALLO AL MODIFICAR EL NUEVO REGISTRO")
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            Persona = New Persona(txtDNI.Text, txtNombre.Text)
            Persona.borrar()

            MsgBox("EL REGISTRO HA SIDO ELIMINADO CON ÉXITO")
            Form1_Load(sender, e)
        Catch ex As Exception
            MsgBox("FALLO AL ELIMINAR EL NUEVO REGISTRO" & ex.Source & ex.Message)
        End Try
    End Sub

    Private Sub ListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox.SelectedIndexChanged
        Persona = New Persona
        Persona.leer(ListBox.SelectedItem)
        txtDNI.Text = Persona.dni
        txtNombre.Text = Persona.nombre
    End Sub

    Private Sub btnLimpiarCampos_Click(sender As Object, e As EventArgs) Handles btnLimpiarCampos.Click
        txtDni.Clear()
        txtNombre.Clear()
    End Sub
End Class
