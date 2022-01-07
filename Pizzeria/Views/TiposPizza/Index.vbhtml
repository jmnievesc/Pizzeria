@ModelType IEnumerable(Of Pizzeria.TipoPizza)
@Code
    ViewData("Title") = "Listado de tipos de pizza"
End Code

<h2>Listado de tipos de pizza</h2>

<p>
    @Html.ActionLink("Nuevo tipo", "Create", "", New With {.class = "btn btn-info"})
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
                    <li>@Html.ActionLink("Editar", "Edit", New With {.id = item.Id})</li>
                    <li>@Html.ActionLink("Detalles", "Details", New With {.id = item.Id})</li>
                    <li>@Html.ActionLink("Eliminar", "Delete", New With {.id = item.Id})</li>
                </ul>
            </div>
        </td>
    </tr>
Next

</table>
