@ModelType  Pizzeria.Rol
@Code
    ViewData("Title") = "Permisos rol " + Model.Nombre
    Dim permitidos = Model.Permisos.Select(Function(p) p.IdAccion).ToList()
    Dim controladores = CType(ViewBag.Controladores, List(Of Controlador))

End Code

<h2>@ViewData("Title").ToString</h2>


@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @<table class="table table-condensed">
        <tr>
            <th>
                Controlador
            </th>
            <th>
                Accion
            </th>
        </tr>


        @For Each controlador In controladores
            @<tr>
                <td>
                    @controlador.Nombre
                </td>
                <td>
                    <table class="table table-condensed">
                        @For Each accion In controlador.Acciones
                            @<tr>
                                <td>@accion.Nombre</td>
                                <td><input type="checkbox" name="acciones" value="@accion.Id" @(IIf(permitidos.Contains(accion.Id), "checked='checked'", ""))></td>
                            </tr>

                        Next

                    </table>
                </td>
            </tr>
        Next

        <input type="hidden" value="@Model.Id" name="idRol" />
    </table>
    @<div Class="form-group">
    <div Class="col-md-offset-2 col-md-10">
        <input type = "submit" value="Guardar" Class="btn btn-success" /> @Html.ActionLink("Regresar", "Index", "", New With {.class = "btn btn-danger"})
                    </div>
                </div>
End Using