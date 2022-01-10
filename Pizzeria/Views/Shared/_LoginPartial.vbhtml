@Imports Microsoft.AspNet.Identity

@If SesionUsuario.EstaAutenticado Then
    @Using Html.BeginForm("LogOff", "Home", FormMethod.Post, New With {.id = "logoutForm", .class = "navbar-right"})
        @Html.AntiForgeryToken()
        @<ul class="nav navbar-nav navbar-right">
            <li>
                @Html.ActionLink("Hola " + SesionUsuario.Usuario.NombreUsuario + "!", "Index", "Manage", routeValues:=Nothing, htmlAttributes:=New With {.title = "Manage"})
            </li>
            <li> @Html.ActionLink("Logout", "Logout", "Home", routeValues:=Nothing, htmlAttributes:=New With {.title = "Logout"})</li>
        </ul>   End Using
Else
    @<ul class="nav navbar-nav navbar-right">
        <li>@Html.ActionLink("Log in", "Login", "Home", routeValues:=Nothing, htmlAttributes:=New With {.id = "loginLink"})</li>
    </ul>
End If

