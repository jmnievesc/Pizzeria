@ModelType IEnumerable(Of Pizzeria.TipoPizza)
@Code
    ViewData("Title") = "Listado de tipos de pizza"

    ''Validamos de manera general del controlador si posee los permisos necesarios para mostrar los enlaces.
    Dim puedeEditar = Helpers.Utils.PoseePermiso("TiposPizza", "Edit")
    Dim puedeEliminar = Helpers.Utils.PoseePermiso("TiposPizza", "Delete")
    Dim puedeVer = Helpers.Utils.PoseePermiso("TiposPizza", "Details")
End Code

<h2>@ViewData("Title").ToString()</h2>

<p>
    @(IIf(Helpers.Utils.PoseePermiso("TiposPizza", "Create"), Html.ActionLink("Crear nuevo tipo de pizza", "Create", "", New With {.Class = "btn btn-info"}), ""))
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CantidadPorciones)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Descripcion)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Precio)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Tamanio)
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Nombre)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.CantidadPorciones)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Descripcion)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Precio)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Tamanio)
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
