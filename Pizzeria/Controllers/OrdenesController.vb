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
        Function Index() As ActionResult
            Return View(db.Ordenes.ToList())
        End Function

        ' GET: Ordenes/Details/5
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
        Function Create() As ActionResult
            Dim orden As New Orden()
            Dim ultimaOrden As Orden
            ''Se busca la ultima orden ingresada para calcular el siguiente correlativo de orden.
            ultimaOrden = db.Ordenes.OrderByDescending(Function(x) x.Numero).FirstOrDefault()
            orden.Numero = IIf(IsNothing(ultimaOrden), 1, ultimaOrden.Numero + 1)
            ViewBag.TiposPizza = New SelectList(db.TiposPizza.OrderBy(Function(x) x.Nombre).ToList, "Id", "Nombre")
            Return View(orden)
        End Function

        ' POST: Ordenes/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Numero,NombreCliente,Fecha,DireccionEnvio,Comentarios,Estado")> ByVal orden As Orden) As ActionResult
            orden.Fecha = DateTime.Now
            orden.Estado = 0
            If ModelState.IsValid Then
                db.Ordenes.Add(orden)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            ViewBag.TiposPizza = New SelectList(db.TiposPizza.OrderBy(Function(x) x.Nombre).ToList, "Id", "Nombre")
            Return View(orden)
        End Function

        ' GET: Ordenes/Edit/5
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
        Function Edit(<Bind(Include:="Id,Numero,NombreCliente,Fecha,DireccionEnvio,Comentarios,Estado,IdTipoPizza,Cantidad")> ByVal orden As Orden) As ActionResult
            If ModelState.IsValid Then
                db.Entry(orden).State = EntityState.Modified
                db.Entry(orden).Property(Function(o) o.Fecha).IsModified = False
                db.Entry(orden).Property(Function(o) o.Estado).IsModified = False
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.TiposPizza = New SelectList(db.TiposPizza.OrderBy(Function(x) x.Nombre).ToList, "Id", "Nombre")
            Return View(orden)
        End Function

        ' GET: Ordenes/Delete/5
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
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim orden As Orden = db.Ordenes.Find(id)
            db.Ordenes.Remove(orden)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
