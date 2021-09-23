Public Class impresion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If DirectCast(Session("usuario"), String) = "" Or DirectCast(Session("impresion"), String) = "" Then
        '    Response.Redirect("Index.aspx")
        'Else
        '    Session("impresion") = ""
        'End If
    End Sub

End Class