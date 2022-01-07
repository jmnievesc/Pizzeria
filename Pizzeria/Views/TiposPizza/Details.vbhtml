@ModelType Pizzeria.TipoPizza
@Code
    ViewData("Title") = ("Detalles: " + Model.Nombre)
End Code

<h2>@ViewData("Title").ToString()</h2>

<div>
    <h4>Tipo de Pizza</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CantidadPorciones)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CantidadPorciones)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Descripcion)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Descripcion)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Precio)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Precio)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Tamanio)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Tamanio)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Editar", "Edit", New With {.id = Model.Id}, New With {.class = "btn btn-info"})
    @Html.ActionLink("Regresar", "Index", "", New With {.class = "btn btn-danger"})
</p>
