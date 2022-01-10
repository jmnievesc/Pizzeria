@ModelType Pizzeria.Usuario
@Code
    ViewData("Title") = "Crear rol"
End Code

<h2>@ViewData("Title").ToString</h2>
@Html.Partial("_form")