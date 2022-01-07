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
    Public Class TiposPizzaController
        Inherits System.Web.Mvc.Controller

        Private db As New PizzeriaEntities

        ' GET: TipoPizzas
        Function Index() As ActionResult
            Return View(db.TiposPizza.ToList())
        End Function

        ' GET: TipoPizzas/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tipoPizza As TipoPizza = db.TiposPizza.Find(id)
            If IsNothing(tipoPizza) Then
                Return HttpNotFound()
            End If
            Return View(tipoPizza)
        End Function

        ' GET: TipoPizzas/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: TipoPizzas/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Nombre,CantidadPorciones,Descripcion,Precio,Tamanio")> ByVal tipoPizza As TipoPizza) As ActionResult
            If ModelState.IsValid Then
                db.TiposPizza.Add(tipoPizza)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(tipoPizza)
        End Function

        ' GET: TipoPizzas/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tipoPizza As TipoPizza = db.TiposPizza.Find(id)
            If IsNothing(tipoPizza) Then
                Return HttpNotFound()
            End If
            Return View(tipoPizza)
        End Function

        ' POST: TipoPizzas/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Nombre,CantidadPorciones,Descripcion,Precio,Tamanio")> ByVal tipoPizza As TipoPizza) As ActionResult
            If ModelState.IsValid Then
                db.Entry(tipoPizza).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(tipoPizza)
        End Function

        ' GET: TipoPizzas/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tipoPizza As TipoPizza = db.TiposPizza.Find(id)
            If IsNothing(tipoPizza) Then
                Return HttpNotFound()
            End If
            Return View(tipoPizza)
        End Function

        ' POST: TipoPizzas/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim tipoPizza As TipoPizza = db.TiposPizza.Find(id)
            db.TiposPizza.Remove(tipoPizza)
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
