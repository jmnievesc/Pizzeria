''' <summary>
''' Filtro para acciones para poder validar si se puede o no acceder a la accion
''' </summary>
''' 
Public Class PermisosActionFilter
    Inherits ActionFilterAttribute

    Private db As PizzeriaEntities = New PizzeriaEntities()

    ''' <summary>
    ''' Metodo que se ejecuta antes de cada acción, se verifica si está autenticado
    ''' y si el rol del usuario posee permisos para acceder
    ''' </summary>
    ''' <param name="filterContext">Contexto del filtro de donde se origina el llamado</param>
    Public Overrides Sub OnActionExecuting(ByVal filterContext As ActionExecutingContext)
        Dim controllerName = filterContext.RouteData.Values("controller")
        Dim actionName = filterContext.RouteData.Values("action")
        ''Se verifica si hay usuario autenticado
        If Not SesionUsuario.EstaAutenticado Then
            Dim returnURl = filterContext.HttpContext.Request.RawUrl
            filterContext.Result = New RedirectToRouteResult(New RouteValueDictionary() From {{"controller", "Home"},
                     {"action", "Login"}, {"returnUrl", returnURl}})
        Else
            ''Se valida si el rol del usuario posee permisos para visitar la accion
            If Not Helpers.Utils.PoseePermiso(controllerName, actionName) Then
                filterContext.Result = New HttpUnauthorizedResult("No posee permisos para acceder a esta ruta (" + controllerName + "/" + actionName + ")")
            End If
        End If
    End Sub



End Class

