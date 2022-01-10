@ModelType Pizzeria.Orden

@Code
    Dim tipos As SelectList = CType(ViewBag.TiposPizza, SelectList)
End Code

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
    <h4>Orden</h4>
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Numero, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Numero, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            @Html.ValidationMessageFor(Function(model) model.Numero, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.NombreCliente, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.NombreCliente, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.NombreCliente, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.DireccionEnvio, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.DireccionEnvio, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.DireccionEnvio, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Comentarios, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Comentarios, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Comentarios, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Cantidad, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Cantidad, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Cantidad, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.IdTipoPizza, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.DropDownListFor(Function(model) model.IdTipoPizza, tipos, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.IdTipoPizza, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        <div class="col-md-12">
            <input type="submit" value="Guardar" class="btn btn-success" /> @Html.ActionLink("Regresar", "Index", "", New With {.class = "btn btn-danger"})
        </div>
    </div>
</div>
End Using


@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
