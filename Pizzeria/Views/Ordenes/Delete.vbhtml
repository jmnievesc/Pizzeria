@ModelType Pizzeria.Orden
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
            @Html.DisplayFor(Function(model) model.Estado)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Eliminar" class="btn btn-danger" />
            @Html.ActionLink("Regresar", "Index", "", New With {.class = "btn btn-warning"})
        </div>
    End Using
</div>
