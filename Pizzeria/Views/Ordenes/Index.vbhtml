@ModelType IEnumerable(Of Pizzeria.Orden)
@Code
    ViewData("Title") = "Listado de ordenes"
End Code

<h2>@ViewData("Title").ToString()</h2>

<p>
    @Html.ActionLink("Crear nueva orden", "Create", "", New With {.class = "btn btn-info"})
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
        @(item.Fecha.ToString("dd/MM/yyyy h:m tt"))
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
                <li>@Html.ActionLink("Editar", "Edit", New With {.id = item.Id})</li>
                <li>@Html.ActionLink("Detalles", "Details", New With {.id = item.Id})</li>
                <li>@Html.ActionLink("Eliminar", "Delete", New With {.id = item.Id})</li>
            </ul>
        </div>
    </td>
</tr>
Next

</table>
