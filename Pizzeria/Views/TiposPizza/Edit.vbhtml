@ModelType Pizzeria.TipoPizza
@Code
    ViewData("Title") = ("Editar: " + Model.Nombre)
End Code

<h2>@ViewData("Title").ToString()</h2>
@Html.Partial("_form")