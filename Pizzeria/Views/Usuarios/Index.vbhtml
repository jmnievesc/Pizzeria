@ModelType IEnumerable(Of Pizzeria.Usuario)

@Code
    ViewData("Title") = "Listado de usuarios"

    ''Validamos de manera general del controlador si posee los permisos necesarios para mostrar los enlaces.
    Dim puedeEditar = Helpers.Utils.PoseePermiso("Usuarios", "Edit")
    Dim puedeEliminar = Helpers.Utils.PoseePermiso("Usuarios", "Delete")
    Dim puedeVer = Helpers.Utils.PoseePermiso("Usuarios", "Details")
End Code

<h2>@ViewData("Title").ToString()</h2>
<p>
    @(IIf(Helpers.Utils.PoseePermiso("Usuarios", "Create"), Html.ActionLink("Crear nuevo usuario", "Create", "", New With {.Class = "btn btn-info"}), ""))
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.NombreUsuario)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Activo)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Rol.Nombre)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NombreUsuario)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Activo)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Rol.Nombre)
        </td>
        <td>
            <div class="dropdown">
                <button class="btn btn-default dropdown-toggle" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                    Acciones
                    <span class="caret"></span>
                </button>
                <ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
                    <li>@(IIf(puedeEditar, Html.ActionLink("Editar", "Edit", New With {.id = item.Id}), ""))</li>
                    <li>@(IIf(puedeVer, Html.ActionLink("Detalles", "Details", New With {.id = item.Id}), ""))</li>
                    <li>@(IIf(puedeEliminar, Html.ActionLink("Eliminar", "Delete", New With {.id = item.Id}), ""))</li>
</ul>
            </div>
        </td>
    </tr>
Next

</table>
