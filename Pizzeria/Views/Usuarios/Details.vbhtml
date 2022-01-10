@ModelType Pizzeria.Usuario
@Code
    ViewData("Title") = "Detailles usuario: " + Model.NombreUsuario
End Code

<h2>Details</h2>

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
</div>
<p>
    @Html.ActionLink("Editar", "Edit", New With {.id = Model.Id}, New With {.class = "btn btn-info"})
    @Html.ActionLink("Regresar", "Index", "", New With {.class = "btn btn-warning"})
</p>
