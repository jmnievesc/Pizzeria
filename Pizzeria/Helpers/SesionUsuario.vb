''' <summary>
''' Clase para control de la sesión
''' </summary>
Public NotInheritable Class SesionUsuario

    ''' <summary>
    ''' Usuario autenticado
    ''' </summary>
    ''' <returns>Si esta autenticado retorna el usuario, si no Nothing</returns>
    Public Shared Property Usuario As Usuario
        Get
            Dim ctx As HttpContext = HttpContext.Current
            If ctx.Session("Usuario") Is Nothing Then
                Return Nothing
            Else
                Return CType(ctx.Session("Usuario"), Usuario)
            End If

        End Get
        Set(value As Usuario)
            Dim ctx As HttpContext = HttpContext.Current
            ctx.Session("Usuario") = value
        End Set
    End Property

    ''' <summary>
    ''' Propiedad auxiliar que verifica si hay usuario autenticado
    ''' </summary>
    ''' <returns>True, si esta logeado. False si no</returns>
    Public Shared ReadOnly Property EstaAutenticado As Boolean
        Get
            Return SesionUsuario.Usuario IsNot Nothing
        End Get
    End Property

End Class
