Imports System.ComponentModel.DataAnnotations
Public Class LoginViewModel
    <Required>
    <Display(Name:="Usuario")>
    Public Property Usuario As String

    <Required>
    <DataType(DataType.Password)>
    <Display(Name:="Password")>
    Public Property Password As String
End Class