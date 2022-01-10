Imports System.Web.Security
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private db As PizzeriaEntities = New PizzeriaEntities()
    <PermisosActionFilter>
    Function Index() As ActionResult

        Return View(db.Ordenes.Where(Function(o) o.Estado = 0).OrderBy(Function(o) o.Fecha).ToList())
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function
    '
    ' GET: /Account/Login
    <AllowAnonymous>
    Public Function Login(returnUrl As String) As ActionResult
        ViewData!ReturnUrl = returnUrl
        Return View()
    End Function

    '
    ' POST: /Account/Login
    <HttpPost>
    <AllowAnonymous>
    <ValidateAntiForgeryToken>
    Public Function Login(model As LoginViewModel, returnUrl As String) As ActionResult
        If Not ModelState.IsValid Then
            Return View(model)
        End If
        Dim usuario As Usuario
        usuario = db.Usuarios.Where(Function(x) x.NombreUsuario = model.Usuario).SingleOrDefault

        If usuario IsNot Nothing Then
            If usuario.Activo And usuario.Rol.Activo Then
                FormsAuthentication.SetAuthCookie(model.Usuario, createPersistentCookie:=True)
                SesionUsuario.Usuario = usuario
                If returnUrl IsNot Nothing Then
                    Return Redirect(returnUrl)
                End If
                Return RedirectToAction("Index")
            End If
        End If
        Return View(model)
    End Function


    <AllowAnonymous>
    Public Function Logout() As ActionResult
        FormsAuthentication.SignOut()
        SesionUsuario.Usuario = Nothing
        Return RedirectToAction("Login")
    End Function
End Class
