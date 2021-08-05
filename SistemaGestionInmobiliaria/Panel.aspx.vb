Public Class Panel
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If DirectCast(Session("usuario"), String) = "" Then
            Response.Redirect("Index.aspx")
        Else
            TextBox1.Text = DateTime.Now.ToShortDateString & " - " & "Hola, " & DirectCast(Session("usuario"), String) & "."
        End If
    End Sub

    Protected Sub Button6_Click(sender As Object, e As EventArgs)
        Session.Clear()
        Response.Redirect("Index.aspx")
    End Sub

    Protected Sub ClearAll()
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        DropDownList1.SelectedValue = 0
        DropDownList2.SelectedValue = 0
        DropDownList3.SelectedValue = 0

        TextBox2.BackColor = System.Drawing.ColorTranslator.FromHtml("#eeeeee")
        TextBox3.BackColor = System.Drawing.ColorTranslator.FromHtml("#eeeeee")
        TextBox4.BackColor = System.Drawing.ColorTranslator.FromHtml("#eeeeee")
        DropDownList1.BackColor = System.Drawing.ColorTranslator.FromHtml("#eeeeee")
        DropDownList2.BackColor = System.Drawing.ColorTranslator.FromHtml("#eeeeee")
        DropDownList3.BackColor = System.Drawing.ColorTranslator.FromHtml("#eeeeee")

    End Sub

    Protected Sub Button7_Click(sender As Object, e As EventArgs)

        Dim NOMBRE As String
        Dim DOCUMENTO As String
        Dim IVA As String
        Dim TELEFONO As String
        Dim TIPO As String
        Dim ESTADO As String

        If TextBox2.Text = "" Then
            TextBox2.BackColor = System.Drawing.ColorTranslator.FromHtml("#f39090")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel1').style.display = 'block';", True)
            Exit Sub
        End If
        If TextBox3.Text = "" Then
            TextBox3.BackColor = System.Drawing.ColorTranslator.FromHtml("#f39090")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel1').style.display = 'block';", True)
            Exit Sub
        End If
        If TextBox4.Text = "" Then
            TextBox4.BackColor = System.Drawing.ColorTranslator.FromHtml("#f39090")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel1').style.display = 'block';", True)
            Exit Sub
        End If

        NOMBRE = TextBox2.Text.ToUpper()
        DOCUMENTO = TextBox3.Text.ToUpper()

        If DropDownList1.SelectedValue = 0 Then
            DropDownList1.BackColor = System.Drawing.ColorTranslator.FromHtml("#f39090")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel1').style.display = 'block';", True)
            Exit Sub
        ElseIf DropDownList1.SelectedValue = 1 Then
            IVA = "CONSUMIDOR FINAL"
        ElseIf DropDownList1.SelectedValue = 2 Then
            IVA = "EXENTO FISCAL"
        ElseIf DropDownList1.SelectedValue = 3 Then
            IVA = "RESPONSABLE MONOTRIBUTO"
        ElseIf DropDownList1.SelectedValue = 4 Then
            IVA = "RESPONSABLE INSCRIPTO"
        End If

        If IsNumeric(TextBox4.Text) Then
            TELEFONO = TextBox4.Text
        Else
            TextBox4.BackColor = System.Drawing.ColorTranslator.FromHtml("#f39090")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel1').style.display = 'block';", True)
            Exit Sub
        End If

        If DropDownList2.SelectedValue = 0 Then
            DropDownList2.BackColor = System.Drawing.ColorTranslator.FromHtml("#f39090")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel1').style.display = 'block';", True)
            Exit Sub
        ElseIf DropDownList2.SelectedValue = 1 Then
            TIPO = "INQUILINO"
        ElseIf DropDownList2.SelectedValue = 2 Then
            TIPO = "PROPIETARIO"
        End If

        If DropDownList3.SelectedValue = 0 Then
            ESTADO = "ACTIVO"
        ElseIf DropDownList3.SelectedValue = 1 Then
            ESTADO = "ACTIVO"
        ElseIf DropDownList3.SelectedValue = 2 Then
            ESTADO = "INACTIVO"
        End If

        SqlDataSource1.InsertCommand = "INSERT INTO [Personas] ([NOMBRE], [DOCUMENTO], [IVA], [TELEFONO], [TIPO], [ESTADO]) VALUES (@NOMBRE, @DOCUMENTO, @IVA, @TELEFONO, @TIPO, @ESTADO)"
        SqlDataSource1.InsertParameters.Add("NOMBRE", NOMBRE)
        SqlDataSource1.InsertParameters.Add("DOCUMENTO", DOCUMENTO)
        SqlDataSource1.InsertParameters.Add("IVA", IVA)
        SqlDataSource1.InsertParameters.Add("TELEFONO", TELEFONO)
        SqlDataSource1.InsertParameters.Add("TIPO", TIPO)
        SqlDataSource1.InsertParameters.Add("ESTADO", ESTADO)
        SqlDataSource1.Insert()

        SqlDataSource1.SelectCommand = "SELECT * FROM [Personas] ORDER BY NOMBRE ASC"
        GridView1.DataBind()

        ClearAll()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel1').style.display = 'block';", True)

    End Sub

    Protected Sub Button9_Click(sender As Object, e As EventArgs)

        For Each gvrow As GridViewRow In GridView1.Rows
            Dim chk As CheckBox = CType(gvrow.FindControl("SelectRow"), CheckBox)

            If chk IsNot Nothing And chk.Checked Then

                Dim ID As String = gvrow.Cells(1).Text

                'Borrar registro
                SqlDataSource1.DeleteCommand = "DELETE FROM [Personas] WHERE Id = '" & ID & "'"
                SqlDataSource1.DeleteParameters.Add("ID", ID)
                SqlDataSource1.Delete()
                GridView1.DataBind()

            End If
        Next

        SqlDataSource1.SelectCommand = "SELECT * FROM [Personas] ORDER BY NOMBRE ASC"
        GridView1.DataBind()

        ClearAll()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel1').style.display = 'block';", True)

    End Sub

    Protected Sub Button8_Click(sender As Object, e As EventArgs)

        Dim NOMBRE As String
        Dim DOCUMENTO As String
        Dim IVA As String
        Dim TELEFONO As String
        Dim TIPO As String
        Dim ESTADO As String

        If TextBox2.Text = "" Then
            TextBox2.BackColor = System.Drawing.ColorTranslator.FromHtml("#f39090")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel1').style.display = 'block';", True)
            Exit Sub
        End If
        If TextBox3.Text = "" Then
            TextBox3.BackColor = System.Drawing.ColorTranslator.FromHtml("#f39090")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel1').style.display = 'block';", True)
            Exit Sub
        End If
        If TextBox4.Text = "" Then
            TextBox4.BackColor = System.Drawing.ColorTranslator.FromHtml("#f39090")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel1').style.display = 'block';", True)
            Exit Sub
        End If

        NOMBRE = TextBox2.Text.ToUpper()
        DOCUMENTO = TextBox3.Text.ToUpper()

        If DropDownList1.SelectedValue = 0 Then
            DropDownList1.BackColor = System.Drawing.ColorTranslator.FromHtml("#f39090")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel1').style.display = 'block';", True)
            Exit Sub
        ElseIf DropDownList1.SelectedValue = 1 Then
            IVA = "CONSUMIDOR FINAL"
        ElseIf DropDownList1.SelectedValue = 2 Then
            IVA = "EXENTO FISCAL"
        ElseIf DropDownList1.SelectedValue = 3 Then
            IVA = "RESPONSABLE MONOTRIBUTO"
        ElseIf DropDownList1.SelectedValue = 4 Then
            IVA = "RESPONSABLE INSCRIPTO"
        End If

        If IsNumeric(TextBox4.Text) Then
            TELEFONO = TextBox4.Text
        Else
            TextBox4.BackColor = System.Drawing.ColorTranslator.FromHtml("#f39090")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel1').style.display = 'block';", True)
            Exit Sub
        End If

        If DropDownList2.SelectedValue = 0 Then
            DropDownList2.BackColor = System.Drawing.ColorTranslator.FromHtml("#f39090")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel1').style.display = 'block';", True)
            Exit Sub
        ElseIf DropDownList2.SelectedValue = 1 Then
            TIPO = "INQUILINO"
        ElseIf DropDownList2.SelectedValue = 2 Then
            TIPO = "PROPIETARIO"
        End If

        If DropDownList3.SelectedValue = 0 Then
            ESTADO = "ACTIVO"
        ElseIf DropDownList3.SelectedValue = 1 Then
            ESTADO = "ACTIVO"
        ElseIf DropDownList3.SelectedValue = 2 Then
            ESTADO = "INACTIVO"
        End If

        For Each gvrow As GridViewRow In GridView1.Rows
            Dim chk As CheckBox = CType(gvrow.FindControl("SelectRow"), CheckBox)

            If chk IsNot Nothing And chk.Checked Then

                Dim ID As String = gvrow.Cells(1).Text

                SqlDataSource1.UpdateCommand = "UPDATE [Personas] SET [NOMBRE] = '" & NOMBRE & "', [DOCUMENTO] = '" & DOCUMENTO & "', [IVA] = '" & IVA & "', [TELEFONO] = '" & TELEFONO & "', [TIPO] = '" & TIPO & "', [ESTADO] = '" & ESTADO & "' WHERE Id = '" & ID & "'"
                SqlDataSource1.InsertParameters.Add("NOMBRE", NOMBRE)
                SqlDataSource1.InsertParameters.Add("DOCUMENTO", DOCUMENTO)
                SqlDataSource1.InsertParameters.Add("IVA", IVA)
                SqlDataSource1.InsertParameters.Add("TELEFONO", TELEFONO)
                SqlDataSource1.InsertParameters.Add("TIPO", TIPO)
                SqlDataSource1.InsertParameters.Add("ESTADO", ESTADO)
                SqlDataSource1.Update()
                GridView1.DataBind()

            End If
        Next

        ClearAll()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel1').style.display = 'block';", True)

    End Sub
End Class