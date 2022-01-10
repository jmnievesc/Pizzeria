@ModelType Pizzeria.Usuario
@Code
    ViewData("Title") = "Editar usuario" + Model.NombreUsuario
End Code

<h2>@ViewData("Title").ToString</h2>
@Html.Partial("_form")