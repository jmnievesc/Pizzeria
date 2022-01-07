@ModelType Pizzeria.TipoPizza
@Code
    ViewData("Title") = "Crear tipo de pizza"
End Code

<h2>@ViewData("Title").ToString()</h2>

@Html.Partial("_form")