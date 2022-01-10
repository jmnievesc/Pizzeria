Public NotInheritable Class HtmlExtensions
    ''' <summary>
    ''' Genera un link si el rol del usuario autenticado posee permisos
    ''' </summary>
    ''' <param name="texto">Texto del enlace</param>
    ''' <param name="accion">Accion del link</param>
    ''' <param name="controlador">Controlador</param>
    ''' <returns>Enlace validado</returns>
    Public Shared Function Link(ByVal texto As String, ByVal accion As String, ByVal controlador As String) As String

        If Helpers.Utils.PoseePermiso(controlador, accion) Then
            Return String.Format("<a href='/{0}/{1}'>{2}</a>", controlador, accion, texto)
        End If
        Return ""
    End Function

    ''' <summary>
    ''' Genera un link si el rol del usuario autenticado posee permisos
    ''' </summary>
    ''' <param name="texto">Texto del enlace</param>
    ''' <param name="accion">Accion del link</param>
    ''' <param name="controlador">Controlador</param>
    ''' <param name="params">Parametros adicionales para el enlace</param>
    ''' <returns>Enlace validado</returns>
    Public Shared Function Link(ByVal texto As String, ByVal accion As String, ByVal controlador As String, ByVal params As String) As String

        If Helpers.Utils.PoseePermiso(controlador, accion) Then
            Return String.Format("<a href='/{0}/{1}?{2}'>{3}</a>", controlador, accion, params, texto)
        End If
        Return ""
    End Function
End Class