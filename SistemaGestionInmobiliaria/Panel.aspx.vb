Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class Panel
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If DirectCast(Session("usuario"), String) = "" Then
            Response.Redirect("Index.aspx")
        Else
            TextBox1.Text = DateTime.Now.ToShortDateString & " - " & "Hola, " & DirectCast(Session("usuario"), String) & "."

            If Not Page.IsPostBack Then
                'Populate DropDownList Propietarios
                Dim constr As String = ConfigurationManager.ConnectionStrings("InmCamiletti").ConnectionString
                Using con As New SqlConnection(constr)
                    Using cmd As New SqlCommand("SELECT Id, Nombre FROM Personas WHERE Tipo = 'PROPIETARIO' AND Estado = 'ACTIVO' ORDER BY Nombre ASC")
                        cmd.CommandType = CommandType.Text
                        cmd.Connection = con
                        con.Open()
                        DropDownList6.DataSource = cmd.ExecuteReader()
                        DropDownList6.DataTextField = "Nombre"
                        DropDownList6.DataValueField = "Id"
                        DropDownList6.DataBind()
                        con.Close()
                    End Using
                End Using
                DropDownList6.Items.Insert(0, New ListItem("Propietario", "0"))
            End If

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

        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        DropDownList5.SelectedValue = 0
        DropDownList6.SelectedValue = 0

        TextBox5.BackColor = System.Drawing.ColorTranslator.FromHtml("#eeeeee")
        TextBox6.BackColor = System.Drawing.ColorTranslator.FromHtml("#eeeeee")
        TextBox7.BackColor = System.Drawing.ColorTranslator.FromHtml("#eeeeee")
        TextBox8.BackColor = System.Drawing.ColorTranslator.FromHtml("#eeeeee")
        DropDownList5.BackColor = System.Drawing.ColorTranslator.FromHtml("#eeeeee")
        DropDownList6.BackColor = System.Drawing.ColorTranslator.FromHtml("#eeeeee")

    End Sub

    Protected Sub Button7_Click(sender As Object, e As EventArgs)

        'Ingresar datos de personas

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

        'Eliminar personas

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

        'Editar personas

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

    Protected Sub Button10_Click(sender As Object, e As EventArgs)

        'Ingresar datos de propiedades

        Dim DIRECCION As String
        Dim LOCALIDAD As String
        Dim PROVINCIA As String
        Dim ESTADO As String
        Dim FOTO As String
        Dim PROPIETARIO As String

        If TextBox5.Text = "" Then
            TextBox5.BackColor = System.Drawing.ColorTranslator.FromHtml("#f39090")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel2').style.display = 'block';", True)
            Exit Sub
        End If
        If TextBox6.Text = "" Then
            TextBox6.BackColor = System.Drawing.ColorTranslator.FromHtml("#f39090")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel2').style.display = 'block';", True)
            Exit Sub
        End If
        If TextBox7.Text = "" Then
            TextBox7.BackColor = System.Drawing.ColorTranslator.FromHtml("#f39090")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel2').style.display = 'block';", True)
            Exit Sub
        End If
        If TextBox8.Text = "" Then
            TextBox8.BackColor = System.Drawing.ColorTranslator.FromHtml("#f39090")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel2').style.display = 'block';", True)
            Exit Sub
        End If

        DIRECCION = TextBox5.Text.ToUpper()
        LOCALIDAD = TextBox6.Text.ToUpper()
        PROVINCIA = TextBox7.Text.ToUpper()
        FOTO = TextBox8.Text.ToUpper()

        If DropDownList5.SelectedValue = 0 Then
            ESTADO = "ACTIVO"
        ElseIf DropDownList5.SelectedValue = 1 Then
            ESTADO = "ACTIVO"
        ElseIf DropDownList5.SelectedValue = 2 Then
            ESTADO = "INACTIVO"
        End If

        PROPIETARIO = DropDownList6.SelectedItem.Text

        SqlDataSource2.InsertCommand = "INSERT INTO [Propiedades] ([DIRECCION], [LOCALIDAD], [PROVINCIA], [ESTADO], [FOTO], [PROPIETARIO]) VALUES (@DIRECCION, @LOCALIDAD, @PROVINCIA, @ESTADO, @FOTO, @PROPIETARIO)"
        SqlDataSource2.InsertParameters.Add("DIRECCION", DIRECCION)
        SqlDataSource2.InsertParameters.Add("LOCALIDAD", LOCALIDAD)
        SqlDataSource2.InsertParameters.Add("PROVINCIA", PROVINCIA)
        SqlDataSource2.InsertParameters.Add("ESTADO", ESTADO)
        SqlDataSource2.InsertParameters.Add("FOTO", FOTO)
        SqlDataSource2.InsertParameters.Add("PROPIETARIO", PROPIETARIO)
        SqlDataSource2.Insert()

        SqlDataSource2.SelectCommand = "SELECT * FROM [Propiedades] ORDER BY DIRECCION ASC"
        GridView2.DataBind()

        ClearAll()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel2').style.display = 'block';", True)

    End Sub

    Protected Sub Button11_Click(sender As Object, e As EventArgs)

        'Eliminar propiedades
        For Each gvrow As GridViewRow In GridView2.Rows
            Dim chk As CheckBox = CType(gvrow.FindControl("SelectRow"), CheckBox)

            If chk IsNot Nothing And chk.Checked Then

                Dim ID As String = gvrow.Cells(1).Text

                'Borrar registro
                SqlDataSource2.DeleteCommand = "DELETE FROM [Propiedades] WHERE Id = '" & ID & "'"
                SqlDataSource2.DeleteParameters.Add("ID", ID)
                SqlDataSource2.Delete()
                GridView2.DataBind()

            End If
        Next

        SqlDataSource2.SelectCommand = "SELECT * FROM [Propiedades] ORDER BY DIRECCION ASC"
        GridView2.DataBind()

        ClearAll()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel2').style.display = 'block';", True)

    End Sub

    Protected Sub Button12_Click(sender As Object, e As EventArgs)

        'Editar propiedades

        Dim DIRECCION As String
        Dim LOCALIDAD As String
        Dim PROVINCIA As String
        Dim ESTADO As String
        Dim FOTO As String
        Dim PROPIETARIO As String

        If TextBox5.Text = "" Then
            TextBox5.BackColor = System.Drawing.ColorTranslator.FromHtml("#f39090")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel2').style.display = 'block';", True)
            Exit Sub
        End If
        If TextBox6.Text = "" Then
            TextBox6.BackColor = System.Drawing.ColorTranslator.FromHtml("#f39090")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel2').style.display = 'block';", True)
            Exit Sub
        End If
        If TextBox7.Text = "" Then
            TextBox7.BackColor = System.Drawing.ColorTranslator.FromHtml("#f39090")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel2').style.display = 'block';", True)
            Exit Sub
        End If
        If TextBox8.Text = "" Then
            TextBox8.BackColor = System.Drawing.ColorTranslator.FromHtml("#f39090")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel2').style.display = 'block';", True)
            Exit Sub
        End If

        DIRECCION = TextBox5.Text.ToUpper()
        LOCALIDAD = TextBox6.Text.ToUpper()
        PROVINCIA = TextBox7.Text.ToUpper()
        FOTO = TextBox8.Text.ToUpper()

        If DropDownList5.SelectedValue = 0 Then
            ESTADO = "ACTIVO"
        ElseIf DropDownList5.SelectedValue = 1 Then
            ESTADO = "ACTIVO"
        ElseIf DropDownList5.SelectedValue = 2 Then
            ESTADO = "INACTIVO"
        End If

        If DropDownList6.SelectedValue = 0 Then
            DropDownList6.BackColor = System.Drawing.ColorTranslator.FromHtml("#f39090")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel2').style.display = 'block';", True)
            Exit Sub
        Else
            PROPIETARIO = DropDownList6.DataTextField
        End If

        For Each gvrow As GridViewRow In GridView2.Rows
            Dim chk As CheckBox = CType(gvrow.FindControl("SelectRow"), CheckBox)

            If chk IsNot Nothing And chk.Checked Then

                Dim ID As String = gvrow.Cells(1).Text

                SqlDataSource2.UpdateCommand = "UPDATE [Personas] SET [DIRECCION] = '" & DIRECCION & "', [LOCALIDAD] = '" & LOCALIDAD & "', [PROVINCIA] = '" & PROVINCIA & "', [ESTADO] = '" & ESTADO & "', [FOTO] = '" & FOTO & "', [PROPIETARIO] = '" & PROPIETARIO & "' WHERE Id = '" & ID & "'"
                SqlDataSource2.InsertParameters.Add("DIRECCION", DIRECCION)
                SqlDataSource2.InsertParameters.Add("LOCALIDAD", LOCALIDAD)
                SqlDataSource2.InsertParameters.Add("PROVINCIA", PROVINCIA)
                SqlDataSource2.InsertParameters.Add("ESTADO", ESTADO)
                SqlDataSource2.InsertParameters.Add("FOTO", FOTO)
                SqlDataSource2.InsertParameters.Add("PROPIETARIO", PROPIETARIO)
                SqlDataSource2.Update()
                GridView2.DataBind()

            End If
        Next

        ClearAll()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel2').style.display = 'block';", True)

    End Sub

    Protected Sub Button13_Click(sender As Object, e As EventArgs)
        'Populate DropDownList Propietarios
        DropDownList6.DataSource = Nothing
        Dim constr As String = ConfigurationManager.ConnectionStrings("InmCamiletti").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("SELECT Id, Nombre FROM Personas WHERE Tipo = 'PROPIETARIO' AND Estado = 'ACTIVO' ORDER BY Nombre ASC")
                cmd.CommandType = CommandType.Text
                cmd.Connection = con
                con.Open()
                DropDownList6.DataSource = cmd.ExecuteReader()
                DropDownList6.DataTextField = "Nombre"
                DropDownList6.DataValueField = "Id"
                DropDownList6.DataBind()
                con.Close()
            End Using
        End Using
        DropDownList6.Items.Insert(0, New ListItem("Propietario", "0"))
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel2').style.display = 'block';", True)
    End Sub
End Class