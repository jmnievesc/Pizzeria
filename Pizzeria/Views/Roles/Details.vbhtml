@ModelType Pizzeria.Rol
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Rol</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Activo)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Activo)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Editar", "Edit", New With {.id = Model.Id}, New With {.class = "btn btn-info"})
    @Html.ActionLink("Regresar", "Index", "", New With {.class = "btn btn-warning"})
</p>
