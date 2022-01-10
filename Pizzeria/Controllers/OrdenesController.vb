Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Pizzeria

Namespace Controllers
    ''' <summary>
    ''' Controlador para ordenes de pizza
    ''' </summary>
    Public Class OrdenesController
        Inherits System.Web.Mvc.Controller
        ''' <summary>
        ''' Atributo que permite la conexión a la base de datos.
        ''' </summary>
        Private db As New PizzeriaEntities

        ' GET: Ordenes
        <PermisosActionFilter>
        Function Index() As ActionResult
            Return View(db.Ordenes.OrderByDescending(Function(x) x.Fecha).ToList())
        End Function

        ' GET: Ordenes/Details/5
        <PermisosActionFilter>
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim orden As Orden = db.Ordenes.Find(id)
            If IsNothing(orden) Then
                Return HttpNotFound()
            End If
            Return View(orden)
        End Function

        ' GET: Ordenes/Create
        <PermisosActionFilter>
        Function Create() As ActionResult
            Dim orden As New Orden()
            Dim ultimaOrden As Orden
            orden.Numero = 1
            ''Se busca la ultima orden ingresada para calcular el siguiente correlativo de orden.
            ultimaOrden = db.Ordenes.OrderByDescending(Function(x) x.Numero).FirstOrDefault()
            If ultimaOrden IsNot Nothing Then
                orden.Numero = ultimaOrden.Numero + 1
            End If
            ViewBag.TiposPizza = New SelectList(db.TiposPizza.OrderBy(Function(x) x.Nombre).ToList, "Id", "Nombre")
            Return View(orden)
        End Function

        ' POST: Ordenes/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        <PermisosActionFilter>
        Function Create(<Bind(Include:="Id,Numero,NombreCliente,Fecha,DireccionEnvio,Comentarios,Estado,Cantidad,IdTipoPizza")> ByVal orden As Orden) As ActionResult
            orden.Fecha = DateTime.Now
            orden.Estado = 0
            orden.IdUsuario = SesionUsuario.Usuario.Id
            If ModelState.IsValid Then
                db.Ordenes.Add(orden)
                db.SaveChanges()
                TempData("Message") = "Se ha creado la orden " & orden.Numero
                Return RedirectToAction("Index", "Home")
            End If

            ViewBag.TiposPizza = New SelectList(db.TiposPizza.OrderBy(Function(x) x.Nombre).ToList, "Id", "Nombre")
            Return View(orden)
        End Function

        ' GET: Ordenes/Edit/5
        <PermisosActionFilter>
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim orden As Orden = db.Ordenes.Find(id)
            If IsNothing(orden) Then
                Return HttpNotFound()
            End If
            ViewBag.TiposPizza = New SelectList(db.TiposPizza.OrderBy(Function(x) x.Nombre).ToList, "Id", "Nombre")
            Return View(orden)
        End Function

        ' POST: Ordenes/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        <PermisosActionFilter>
        Function Edit(<Bind(Include:="Id,Numero,NombreCliente,Fecha,DireccionEnvio,Comentarios,Estado,IdTipoPizza,Cantidad")> ByVal orden As Orden) As ActionResult
            If ModelState.IsValid Then
                db.Entry(orden).State = EntityState.Modified
                db.Entry(orden).Property(Function(o) o.Fecha).IsModified = False
                db.Entry(orden).Property(Function(o) o.Estado).IsModified = False
                db.Entry(orden).Property(Function(o) o.IdUsuario).IsModified = False
                db.SaveChanges()
                TempData("Message") = "Se ha actualizado la orden " & orden.Numero
                Return RedirectToAction("Index", "Home")
            End If
            ViewBag.TiposPizza = New SelectList(db.TiposPizza.OrderBy(Function(x) x.Nombre).ToList, "Id", "Nombre")
            Return View(orden)
        End Function

        ' GET: Ordenes/Delete/5
        <PermisosActionFilter>
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim orden As Orden = db.Ordenes.Find(id)
            If IsNothing(orden) Then
                Return HttpNotFound()
            End If
            Return View(orden)
        End Function

        ' POST: Ordenes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        <PermisosActionFilter>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim orden As Orden = db.Ordenes.Find(id)
            db.Ordenes.Remove(orden)
            db.SaveChanges()
            Return RedirectToAction("Index", "Home")
        End Function


        <HttpPost()>
        Function Entregar(ByVal id As Integer) As JsonResult
            Try
                Dim orden As Orden = db.Ordenes.Find(id)
                orden.Estado = 1
                db.Entry(orden).State = EntityState.Modified
                db.SaveChanges()
                Return Json(New With {.Correcto = True})
            Catch exception As Exception

                Return Json(New With {.Correcto = False, .Mensaje = "Ha ocurrrido un error"})
            End Try

        End Function
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
