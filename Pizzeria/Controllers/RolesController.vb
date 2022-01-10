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
    Public Class RolesController
        Inherits System.Web.Mvc.Controller

        Private db As New PizzeriaEntities

        ' GET: Roles
        <PermisosActionFilter>
        Function Index() As ActionResult
            Return View(db.Roles.ToList())
        End Function

        ' GET: Roles/Details/5
        <PermisosActionFilter>
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim rol As Rol = db.Roles.Find(id)
            If IsNothing(rol) Then
                Return HttpNotFound()
            End If
            Return View(rol)
        End Function

        ' GET: Roles/Create
        <PermisosActionFilter>
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Roles/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        <PermisosActionFilter>
        Function Create(<Bind(Include:="Id,Nombre,Activo")> ByVal rol As Rol) As ActionResult
            If ModelState.IsValid Then
                db.Roles.Add(rol)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(rol)
        End Function

        ' GET: Roles/Edit/5
        <PermisosActionFilter>
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim rol As Rol = db.Roles.Find(id)
            If IsNothing(rol) Then
                Return HttpNotFound()
            End If
            Return View(rol)
        End Function

        ' POST: Roles/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        <PermisosActionFilter>
        Function Edit(<Bind(Include:="Id,Nombre,Activo")> ByVal rol As Rol) As ActionResult
            If ModelState.IsValid Then
                db.Entry(rol).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(rol)
        End Function

        ' GET: Roles/Delete/5
        <PermisosActionFilter>
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim rol As Rol = db.Roles.Find(id)
            If IsNothing(rol) Then
                Return HttpNotFound()
            End If
            Return View(rol)
        End Function

        ' POST: Roles/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        <PermisosActionFilter>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim rol As Rol = db.Roles.Find(id)
            db.Roles.Remove(rol)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub


        <PermisosActionFilter>
        Function Permisos(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim rol As Rol = db.Roles.Find(id)
            If IsNothing(rol) Then
                Return HttpNotFound()
            End If
            ViewBag.Controladores = db.Controladores.OrderBy(Function(x) x.Nombre).ToList
            Return View(rol)
        End Function

        <HttpPost()>
        <PermisosActionFilter>
        Function Permisos(ByVal idRol As Integer?, ByVal ParamArray acciones() As Integer) As ActionResult
            If IsNothing(idRol) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim rol As Rol = db.Roles.Find(idRol)
            If IsNothing(rol) Then
                Return HttpNotFound()
            End If
            rol.Permisos.ToList.ForEach(Function(p) db.Permisos.Remove(p))
            db.SaveChanges()

            For Each idAccion In acciones
                Dim permiso = New Permiso
                permiso.IdAccion = idAccion
                permiso.IdRol = idRol
                db.Permisos.Add(permiso)
                db.SaveChanges()
            Next
            Return RedirectToAction("Index")
        End Function
    End Class
End Namespace
