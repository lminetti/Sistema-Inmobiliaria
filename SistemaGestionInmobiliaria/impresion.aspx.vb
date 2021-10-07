Public Class impresion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If DirectCast(Session("usuario"), String) = "" Or DirectCast(Session("impresion"), String) = "" Then
            Response.Redirect("Index.aspx")
        Else
            Session("impresion") = ""
        End If


        TextBoxLetra.Text = DirectCast(Session("letra"), String)
        TextBoxCodigo.Text = DirectCast(Session("codigo"), String)
        TextBoxCompte.Text = DirectCast(Session("compte"), String)
        TextBoxFecha.Text = DirectCast(Session("fecha"), String)
        TextBoxCliente.Text = DirectCast(Session("cliente"), String)
        'TextBoxDomicilio.Text = DirectCast(Session("domicilio"), String)
        'TextBoxLocalidad.Text = DirectCast(Session("localidad"), String)
        TextBoxConcepto.Text = "En concepto de:" & Environment.NewLine & DirectCast(Session("concepto"), String)
        TextBoxTotal.Text = DirectCast(Session("total"), String)

        TextBoxLetra_2.Text = DirectCast(Session("letra"), String)
        TextBoxCodigo_2.Text = DirectCast(Session("codigo"), String)
        TextBoxCompte_2.Text = DirectCast(Session("compte"), String)
        TextBoxFecha_2.Text = DirectCast(Session("fecha"), String)
        TextBoxCliente_2.Text = DirectCast(Session("cliente"), String)
        'TextBoxDomicilio_2.Text = DirectCast(Session("domicilio"), String)
        'TextBoxLocalidad_2.Text = DirectCast(Session("localidad"), String)
        TextBoxConcepto_2.Text = "En concepto de: " & DirectCast(Session("concepto"), String)
        TextBoxTotal_2.Text = DirectCast(Session("total"), String)

    End Sub

End Class