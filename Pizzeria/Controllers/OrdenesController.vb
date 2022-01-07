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
    Public Class OrdenesController
        Inherits System.Web.Mvc.Controller

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
            ultimaOrden = db.Ordenes.OrderByDescending(Function(x) x.Numero).FirstOrDefault()
            If IsNothing(ultimaOrden) Then
                orden.Numero = 1
            Else
                orden.Numero = ultimaOrden.Numero + 1
            End If


            Return View(orden)
        End Function

        ' POST: Ordenes/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Numero,NombreCliente,Fecha,DireccionEnvio,Comentarios,Estado")> ByVal orden As Orden) As ActionResult
            orden.Fecha = DateTime.Now
            If ModelState.IsValid Then
                db.Ordenes.Add(orden)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
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
            Return View(orden)
        End Function

        ' POST: Ordenes/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Numero,NombreCliente,Fecha,DireccionEnvio,Comentarios,Estado")> ByVal orden As Orden) As ActionResult
            If ModelState.IsValid Then
                db.Entry(orden).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
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
