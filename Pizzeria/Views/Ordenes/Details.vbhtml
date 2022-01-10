@ModelType Pizzeria.Orden
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Orden</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Numero)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Numero)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NombreCliente)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NombreCliente)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Fecha)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Fecha)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DireccionEnvio)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DireccionEnvio)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Comentarios)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Comentarios)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Estado)
        </dt>

        <dd>
            @Html.DisplayNameFor(Function(model) model.NombreEstado)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Editar", "Edit", New With {.id = Model.Id}, New With {.class = "btn btn-info"})
    @Html.ActionLink("Regresar", "Index", "", New With {.class = "btn btn-warning"})
</p>
