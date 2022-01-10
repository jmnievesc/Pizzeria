
Namespace Helpers
    ''' <summary>
    ''' Clase estatica confunciones utiles en todo el sistema
    ''' </summary>
    Public NotInheritable Class Utils

        ''' <summary>
        ''' Objeto para manipular la base de datos
        ''' </summary>
        Private Shared db As PizzeriaEntities = New PizzeriaEntities()

        ''' <summary>
        ''' Devuelve una cadena representativa del estado de la orden
        ''' </summary>
        ''' <param name="estado">Entero del estado</param>
        ''' <returns>Etiqueta del estado</returns>
        Public Shared Function NombreEstado(ByVal estado As Integer) As String
            Select Case estado
                Case 0
                    Return "Ingresada"
                Case Else
                    Return "Entregada"
            End Select

        End Function

        ''' <summary>
        ''' Funcion que verifica en base de datos si el rol del usuario autenticado posee permisos para visitar una accion en particular
        ''' </summary>
        ''' <param name="nombreControlador">Controlador de la accion a visitar</param>
        ''' <param name="nombreAccion">Accion a visitar</param>
        ''' <returns>True, si posee permisos. False si no</returns>
        Public Shared Function PoseePermiso(ByVal nombreControlador As String, ByVal nombreAccion As String) As Boolean
            ''Se busca la accion por medio del nombre y del nombre del controlador.
            Dim accion = db.Acciones.Where(Function(a) a.Nombre = nombreAccion And a.Controlador.Nombre = nombreControlador).SingleOrDefault
            If accion IsNot Nothing Then
                Dim idRol = SesionUsuario.Usuario.IdRol
                ''Se verifica si por lo menos tiene un permiso para la accion solicitada. (Siempre será una)
                Dim permiso = db.Permisos.Where(Function(p) p.IdAccion = accion.Id And p.IdRol = idRol).Any()
                Return permiso
            End If
            Return False
        End Function
    End Class
End Namespace

