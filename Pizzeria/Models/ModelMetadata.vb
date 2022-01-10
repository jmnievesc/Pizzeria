
Imports System.ComponentModel.DataAnnotations

<MetadataType(GetType(TipoPizzaMetadata))>
Partial Public Class TipoPizza


End Class


Public Class TipoPizzaMetadata

    <Display(Name:="Descripción")>
    Public Property Descripcion As String

    <Display(Name:="Cantidad de porciones")>
    Public Property CantidadPorciones As Integer

    <Display(Name:="Tamaño")>
    Public Property Tamanio As String
End Class


<MetadataType(GetType(OrdenMetadata))>
Partial Public Class Orden
    Public ReadOnly Property NombreEstado As String
        Get
            Return Helpers.Utils.NombreEstado(Me.Estado)

        End Get
    End Property

End Class


Public Class OrdenMetadata

    <Display(Name:="Número")>
    Public Property Numero As Integer

    <Display(Name:="Nombre del cliente")>
    Public Property NombreCliente As String

    <Display(Name:="Dirección de envío")>
    Public Property DireccionEnvio As String

    <Display(Name:="Tipo de pizza")>
    Public Property IdTipoPizza As Integer


    <Display(Name:="Estado")>
    Public Property NombreEstado As Integer
End Class