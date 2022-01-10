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
    Public Class UsuariosController
        Inherits System.Web.Mvc.Controller

        Private db As New PizzeriaEntities

        ' GET: Usuarios
        <PermisosActionFilter>
        Function Index() As ActionResult
            Dim usuarios = db.Usuarios.Include(Function(u) u.Rol)
            Return View(usuarios.ToList())
        End Function

        ' GET: Usuarios/Details/5
        <PermisosActionFilter>
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim usuario As Usuario = db.Usuarios.Find(id)
            If IsNothing(usuario) Then
                Return HttpNotFound()
            End If
            Return View(usuario)
        End Function

        ' GET: Usuarios/Create
        <PermisosActionFilter>
        Function Create() As ActionResult
            ViewBag.IdRol = New SelectList(db.Roles, "Id", "Nombre")
            Return View()
        End Function

        ' POST: Usuarios/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        <PermisosActionFilter>
        Function Create(<Bind(Include:="Id,NombreUsuario,Password,Activo,IdRol")> ByVal usuario As Usuario) As ActionResult
            If ModelState.IsValid Then
                db.Usuarios.Add(usuario)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.IdRol = New SelectList(db.Roles, "Id", "Nombre", usuario.IdRol)
            Return View(usuario)
        End Function

        ' GET: Usuarios/Edit/5
        <PermisosActionFilter>
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim usuario As Usuario = db.Usuarios.Find(id)
            If IsNothing(usuario) Then
                Return HttpNotFound()
            End If
            ViewBag.IdRol = New SelectList(db.Roles, "Id", "Nombre", usuario.IdRol)
            Return View(usuario)
        End Function

        ' POST: Usuarios/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        <PermisosActionFilter>
        Function Edit(<Bind(Include:="Id,NombreUsuario,Password,Activo,IdRol")> ByVal usuario As Usuario) As ActionResult
            If ModelState.IsValid Then
                db.Entry(usuario).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.IdRol = New SelectList(db.Roles, "Id", "Nombre", usuario.IdRol)
            Return View(usuario)
        End Function

        ' GET: Usuarios/Delete/5
        <PermisosActionFilter>
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim usuario As Usuario = db.Usuarios.Find(id)
            If IsNothing(usuario) Then
                Return HttpNotFound()
            End If
            Return View(usuario)
        End Function

        ' POST: Usuarios/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        <PermisosActionFilter>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim usuario As Usuario = db.Usuarios.Find(id)
            db.Usuarios.Remove(usuario)
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
