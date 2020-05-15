Imports System.Data.Linq.Mapping

''' <summary>
''' 種別クラス
''' </summary>
<Table(Name:="mstkind")>
Public Class Kind

    ''' <summary>
    ''' 種別コード
    ''' </summary>
    ''' <returns></returns>
    <Column(Name:="kind_cd", IsPrimaryKey:=True)>
    Public Property KindCd As String

    ''' <summary>
    ''' 種別名
    ''' </summary>
    ''' <returns></returns>
    <Column(Name:="kind_name")>
    Public Property KindName As String

End Class