@ModelType Pizzeria.Rol
@Code
    ViewData("Title") = "Editar rol: " + Model.Nombre
End Code

<h2>@(ViewData("Title").ToString)</h2>
@Html.Partial("_form")