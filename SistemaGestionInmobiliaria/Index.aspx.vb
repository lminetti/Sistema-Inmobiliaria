Public Class Index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Login()
    End Sub

    Protected Sub Login()
        If TextBox1.Text = "" Then
            Exit Sub
        Else
            TextBox1.Text = TextBox1.Text.Replace("%", "")
            TextBox1.Text = TextBox1.Text.Replace("''", "")
            TextBox1.Text = TextBox1.Text.Replace("&", "")
            TextBox1.Text = TextBox1.Text.Replace("=", "")
            Session("pass") = TextBox1.Text
            Dim Pass As String = TextBox1.Text
            SqlDataSource1.SelectCommand = "SELECT * FROM [Usuarios] WHERE PASS LIKE '" & TextBox1.Text & "'"
            GridView1.DataBind()
            If GridView1.Rows.Count = 0 Then
                Session.Clear()
            Else
                Session("usuario") = HttpUtility.HtmlDecode(GridView1.Rows(0).Cells(1).Text)
                Session("nivel") = HttpUtility.HtmlDecode(GridView1.Rows(0).Cells(3).Text)
                Response.Redirect("Panel.aspx")
                'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "alert('" & Pass & "');", True)
            End If
        End If
    End Sub

End Class