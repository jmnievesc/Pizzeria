'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Usuario
    Public Property Id As Integer
    Public Property NombreUsuario As String
    Public Property Activo As Boolean
    Public Property IdRol As Integer
    Public Property Password As String

    Public Overridable Property Rol As Rol
    Public Overridable Property Ordenes As ICollection(Of Orden) = New HashSet(Of Orden)

End Class
