@ModelType Pizzeria.Orden
@Code
    ViewData("Title") = "Crear orden"
End Code

<h2>@ViewData("Title").ToString()</h2>
@Html.Partial("_form")