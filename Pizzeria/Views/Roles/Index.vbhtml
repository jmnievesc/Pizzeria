@ModelType IEnumerable(Of Pizzeria.Rol)
@Code
    ViewData("Title") = "Listado de Roles"

    ''Validamos de manera general del controlador si posee los permisos necesarios para mostrar los enlaces.
    Dim puedeEditar = Helpers.Utils.PoseePermiso("Roles", "Edit")
    Dim puedeEliminar = Helpers.Utils.PoseePermiso("Roles", "Delete")
    Dim puedeVer = Helpers.Utils.PoseePermiso("Roles", "Details")
    Dim puedeDarPermisos = Helpers.Utils.PoseePermiso("Roles", "Permisos")
End Code

<h2>@ViewData("Title").ToString()</h2>

<p>
    @(IIf(Helpers.Utils.PoseePermiso("Roles", "Create"), Html.ActionLink("Crear nuevo Rol", "Create", "", New With {.Class = "btn btn-info"}), ""))
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Activo)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Activo)
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
                    <li>@(IIf(puedeDarPermisos, Html.ActionLink("Permisos", "Permisos", New With {.id = item.Id}), ""))</li>
                    <li>@(IIf(puedeEliminar, Html.ActionLink("Eliminar", "Delete", New With {.id = item.Id}), ""))</li>
                </ul>
            </div>
        </td>
    </tr>
Next

</table>
