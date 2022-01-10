@ModelType Pizzeria.TipoPizza
@Code
    ViewData("Title") = ("Eliminar: " + Model.Nombre)
End Code

<h2>@ViewData("Title").ToString()</h2>

<h3>¿Está seguro de eliminar este ítem?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Eliminar" class="btn btn-danger" />
            @Html.ActionLink("Regresar", "Index", "", New With {.class = "btn btn-warning"})
</div>
    End Using
</div>
