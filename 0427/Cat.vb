Imports System.Data.Linq.Mapping

''' <summary>
''' 猫クラス
''' </summary>
<Table(Name:="tblcat")>
Public Class Cat

    <Column(Name:="no", IsPrimaryKey:=True)>
    Public Property No As Integer

    <Column(Name:="name")>
    Public Property Name As String

    <Column(Name:="sex")>
    Public Property Sex As String

    <Column(Name:="age")>
    Public Property Age As Integer

    <Column(Name:="kind_cd")>
    Public Property KindCd As String

    <Column(Name:="favorite")>
    Public Property Favorite As String

End Class