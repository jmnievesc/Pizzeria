@ModelType Pizzeria.Rol
@Code
    ViewData("Title") = "Eliminar rol: " + Model.Nombre
End Code

<h2>Eliminar</h2>

<h3>Esta seguro de eliminar el rol?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
        <input type="submit" value="Eliminar" class="btn btn-danger" />
        @Html.ActionLink("Regresar", "Index", "", New With {.class = "btn btn-warning"})
</div>
    End Using
</div>
