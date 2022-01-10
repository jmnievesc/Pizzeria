@ModelType Pizzeria.Usuario
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Usuario</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.NombreUsuario)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NombreUsuario)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Llave)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Llave)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Activo)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Activo)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Rol.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Rol.Nombre)
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
