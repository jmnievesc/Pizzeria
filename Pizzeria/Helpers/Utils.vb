
Namespace Helpers
    Public NotInheritable Class Utils
        Public Shared Function NombreEstado(ByVal estado As Integer) As String
            Select Case estado
                Case 0
                    Return "Ingresada"
                Case 1
                    Return "Procesando"
                Case 2
                    Return "En Camino"
                Case Else
                    Return "Entregada"
            End Select

        End Function
    End Class
End Namespace

