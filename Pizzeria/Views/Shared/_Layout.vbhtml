<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - Mi Pizzeria</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
    @Scripts.Render("~/bundles/jquery")
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Pizzeria", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
            </div>
            <div class="navbar-collapse collapse">
                @If SesionUsuario.EstaAutenticado Then
                    @<ul Class="nav navbar-nav">
                        <li>@Html.ActionLink("Home", "Index", "Home")</li>
                        <li>@Html.Raw(HtmlExtensions.Link("Ordenes", "Index", "Ordenes"))</li>
                        <li>@Html.Raw(HtmlExtensions.Link("Tipos de Pizza", "Index", "TiposPizza"))</li>
                        <li>@Html.Raw(HtmlExtensions.Link("Usuarios", "Index", "Usuarios"))</li>
                        <li>@Html.Raw(HtmlExtensions.Link("Roles", "Index", "Roles"))</li>
                                                                                                                            
                    </ul>
                End If
                @Html.Partial("_LoginPartial")
            </div>
        </div>
    </div>
    <div class="container body-content">
        @Code
            Dim message = TempData("Message")
        End Code
            @If (message IsNot Nothing) Then

                @<div class="alert alert-info">@message.ToString</div>
            End If


        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - Pizzeria Prueba Desarrollo</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
