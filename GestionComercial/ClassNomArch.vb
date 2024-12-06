Imports System.Xml
Public Class ClassNomArch

    Private _FULLNAME As String
    Private _VENTASDIA As String
    Private _NOMARCHYYYYMMDD As String

    Public Property Fullname() As String
        Get
            Return _FULLNAME
        End Get
        Set(ByVal value As String)
            _FULLNAME = value
        End Set
    End Property

    Public Property VentasDia() As String
        Get
            Return _VENTASDIA
        End Get
        Set(ByVal value As String)
            _VENTASDIA = value
        End Set
    End Property

    Public Property NomArchYYYYMMDD() As String
        Get
            Return _NOMARCHYYYYMMDD
        End Get
        Set(ByVal value As String)
            _NOMARCHYYYYMMDD = value
        End Set
    End Property
    Public Shared Function CrearDataTableNomArch() As DataTable
        Return CrearDataTable("Fullname,VentasDia,NomArchYYYYMMDD")
    End Function
    'Public Shared Function PoblarDataTableNomArch(ByRef _DataTable As DataTable) As DataTable

    '    'For Each _Nodo As ClassNomArch In SortMayorMenor(Crear_Lista_NomArch)
    '    '    _DataTableNombresArchVentas.Rows.Add(_Nodo.Fullname, _Nodo.VentasDia, _Nodo.NomArchYYYYMMDD)
    '    'Next

    '    Return _DataTable

    'End Function
    Public Shared Function SortMayorMenor(ByVal _ListaDeNodos As List(Of ClassNomArch)) As List(Of ClassNomArch)

        Dim _NodoAux As New ClassNomArch

        For i = 0 To _ListaDeNodos.Count - 2
            For j = i + 1 To _ListaDeNodos.Count - 1
                If _ListaDeNodos(i).NomArchYYYYMMDD < _ListaDeNodos(j).NomArchYYYYMMDD Then
                    _NodoAux = _ListaDeNodos(i)
                    _ListaDeNodos(i) = _ListaDeNodos(j)
                    _ListaDeNodos(j) = _NodoAux
                End If
            Next
        Next

        Return _ListaDeNodos

    End Function
End Class

