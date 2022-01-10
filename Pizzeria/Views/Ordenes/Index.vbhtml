@ModelType IEnumerable(Of Pizzeria.Orden)
@Code
    ViewData("Title") = "Listado de ordenes"

    ''Validamos de manera general del controlador si posee los permisos necesarios para mostrar los enlaces.
    Dim puedeEditar = Helpers.Utils.PoseePermiso("Ordenes", "Edit")
    Dim puedeEliminar = Helpers.Utils.PoseePermiso("Ordenes", "Delete")
    Dim puedeVer = Helpers.Utils.PoseePermiso("Ordenes", "Details")
End Code

<h2>@ViewData("Title").ToString()</h2>

<p>
    @(IIf(Helpers.Utils.PoseePermiso("Ordenes", "Create"), Html.ActionLink("Crear nueva orden", "Create", "", New With {.Class = "btn btn-info"}), ""))
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Numero)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NombreCliente)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Fecha)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DireccionEnvio)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Comentarios)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Estado)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
    <td>
        @Html.DisplayFor(Function(modelItem) item.Numero)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.NombreCliente)
    </td>
    <td>
        @(item.Fecha.ToString("dd/MM/yyyy hh:mm tt"))
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.DireccionEnvio)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.Comentarios)
    </td>
    <td>

        @Html.DisplayFor(Function(modelItem) item.NombreEstado)
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
