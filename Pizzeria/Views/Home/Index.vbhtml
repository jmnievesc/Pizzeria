@ModelType IEnumerable(Of Pizzeria.Orden)
@Code
    ViewData("Title") = "Ordenes pendientes de entrega"

    ''Validamos de manera general del controlador si posee los permisos necesarios para mostrar los enlaces.
    Dim puedeEditar = Helpers.Utils.PoseePermiso("Ordenes", "Edit")
    Dim puedeEliminar = Helpers.Utils.PoseePermiso("Ordenes", "Delete")
    Dim puedeVer = Helpers.Utils.PoseePermiso("Ordenes", "Details")
End Code

<h2>@ViewData("Title").ToString()</h2>

<p>
    @(IIf(Helpers.Utils.PoseePermiso("Ordenes", "Create"), Html.ActionLink("Crear nueva orden", "Create", "Ordenes", "", New With {.Class = "btn btn-info"}), ""))
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Fecha)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Numero)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NombreCliente)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Cantidad)
        </th>
        <th>
            Precio unitario
        </th>
        <th>
            Total
        </th>
        @If SesionUsuario.Usuario.Rol.EsAdmin Then
            @<th>
                Usuario
            </th>
        End If

        <th></th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @(item.Fecha.ToString("dd/MM/yyyy hh:mm tt"))
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Numero)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.NombreCliente)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Cantidad)
            </td>
            <td>
                $@(item.TipoPizza.Precio)
            </td>
            <td>

                $@(item.Cantidad * item.TipoPizza.Precio)
            </td>
            @If SesionUsuario.Usuario.Rol.EsAdmin Then
                @<th>
                    @item.Usuario.NombreUsuario
                </th>
            End If
            <td>
                <div class="dropdown">
                    <button class="btn btn-default dropdown-toggle" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                        Acciones
                        <span class="caret"></span>
                    </button>
                    <ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
                        <li>@(IIf(puedeEditar, Html.ActionLink("Editar", "Edit", "Ordenes", New With {.id = item.Id}, ""), ""))</li>
                        <li>@(IIf(puedeVer, Html.ActionLink("Detalles", "Details", "Ordenes", New With {.id = item.Id}, ""), ""))</li>
                        <li>@(IIf(puedeEliminar, Html.ActionLink("Eliminar", "Delete", "Ordenes", New With {.id = item.Id}, ""), ""))</li>
                    </ul>
                </div>
            </td>
            <td>
                <a class="btn btn-info entregar" href="#" data-ordenid="@item.Id">Entregar</a>
            </td>
        </tr>
    Next

</table>
<script type="text/javascript">
    jQuery(document).ready(function () {
        //Se dispara al dar click al link entregar para cambiar el estado de la orden.
        jQuery(".entregar").click(function () {
            //Se obtiene el id del link presionado
            var idOrden = jQuery(this).data("ordenid");
            //Enviamos el id a la accion Entregar/Ordenes para que actualice la orden.
            jQuery.post("/Ordenes/Entregar", { id: idOrden }, function (json) {
                if (json.Correcto) {
                    window.location.reload();
                }
                else {
                    alert(json.Mensaje);
                }
            });
        });
    });
</script>