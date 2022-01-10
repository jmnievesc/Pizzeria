@ModelType Pizzeria.Orden
@Code
    ViewData("Title") = ("Editar orden: No. " & Model.Numero)
End Code

<h2>@ViewData("Title").ToString()</h2>

@Html.Partial("_form")