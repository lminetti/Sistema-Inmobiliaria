Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class Panel
    Inherits System.Web.UI.Page

    Dim constr As String = ConfigurationManager.ConnectionStrings("InmCamiletti").ConnectionString
    Dim MesDesdeLiq As Integer
    Dim AñoDesdeLiq As Integer
    Dim MesHastaLiq As Integer
    Dim AñoHastaLiq As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If DirectCast(Session("usuario"), String) = "" Then
            Response.Redirect("Index.aspx")
        Else
            TextBox1.Text = DateTime.Now.ToShortDateString & " - " & "Hola, " & DirectCast(Session("usuario"), String) & "."

            If DirectCast(Session("nivel"), String) = "1" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Button5').style.display = 'none';", True)
            End If

            If Not Page.IsPostBack Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel0').style.display = 'block'", True)

                'Populate DropDownList Propietarios
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

                'Populate DropDownList Propiedades e Inquilinos (en contratos)
                Using con As New SqlConnection(constr)
                    Using cmd As New SqlCommand("SELECT Id, DIRECCION FROM Propiedades WHERE ESTADO = 'ACTIVO' ORDER BY Direccion ASC")
                        cmd.CommandType = CommandType.Text
                        cmd.Connection = con
                        con.Open()
                        DropDownList7.DataSource = cmd.ExecuteReader()
                        DropDownList7.DataTextField = "Direccion"
                        DropDownList7.DataValueField = "Id"
                        DropDownList7.DataBind()
                        con.Close()
                    End Using
                End Using
                DropDownList7.Items.Insert(0, New ListItem("Propiedades", "0"))

                Using con As New SqlConnection(constr)
                    Using cmd As New SqlCommand("SELECT Id, Nombre FROM Personas WHERE Tipo = 'INQUILINO' AND Estado = 'ACTIVO' ORDER BY Nombre ASC")
                        cmd.CommandType = CommandType.Text
                        cmd.Connection = con
                        con.Open()
                        DropDownList8.DataSource = cmd.ExecuteReader()
                        DropDownList8.DataTextField = "Nombre"
                        DropDownList8.DataValueField = "Id"
                        DropDownList8.DataBind()
                        con.Close()
                    End Using
                End Using
                DropDownList8.Items.Insert(0, New ListItem("Inquilinos", "0"))

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

        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox14.Text = ""
        TextBox18.Text = ""
        TextBox12.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""
        TextBox19.Text = ""
        TextBox36.Text = ""
        DropDownList7.SelectedValue = 0
        DropDownList8.SelectedValue = 0

        TextBox29.Text = ""
        TextBox30.Text = ""
        DropDownList4.SelectedValue = 0

        SqlDataSource1.SelectCommand = "SELECT * FROM [Personas] ORDER BY NOMBRE ASC"
        GridView1.DataBind()
        SqlDataSource2.SelectCommand = "SELECT * FROM [Propiedades] ORDER BY DIRECCION ASC"
        GridView2.DataBind()
        SqlDataSource3.SelectCommand = "SELECT * FROM [Contratos] ORDER BY DIRECCION ASC"
        GridView3.DataBind()
        SqlDataSource4.SelectCommand = "SELECT TOP 100 * FROM [Detalle_Contratos]"
        SqlDataSource7.SelectCommand = "SELECT TOP 0 * FROM [Personas] WHERE TIPO = 'INQUILINO' ORDER BY Id ASC"
        GridView6.DataBind()
        SqlDataSource9.SelectCommand = "SELECT TOP 0 * FROM [Detalle_Cobranzas]"
        GridView8.DataBind()
        SqlDataSource10.SelectCommand = "SELECT TOP 0 * FROM [Cobranzas]"
        GridView9.DataBind()
        SqlDataSource6.SelectCommand = "SELECT TOP 0 * FROM [Detalle_Cobranzas] ORDER BY Id ASC"
        GridView5.DataBind()
        SqlDataSource12.SelectCommand = "SELECT TOP 0 * FROM [Detalle_Cobranzas] ORDER BY Id ASC"
        GridView11.DataBind()
        SqlDataSource11.SelectCommand = "SELECT TOP 10 * FROM [Cobranzas] ORDER BY Id DESC"
        GridView10.DataBind()
        SqlDataSource13.SelectCommand = "SELECT TOP 0 * FROM [Personas]"
        GridView12.DataBind()
        SqlDataSource14.SelectCommand = "SELECT TOP 0 * FROM [Detalle_Contratos]"
        GridView13.DataBind()
        SqlDataSource15.SelectCommand = "SELECT TOP 0 * FROM [Contratos]"
        GridView14.DataBind()
        SqlDataSource16.SelectCommand = "SELECT TOP 0 * FROM [Cobranzas]"
        GridView15.DataBind()
        SqlDataSource17.SelectCommand = "SELECT TOP 0 * FROM [Detalle_Cobranzas] ORDER BY Id ASC"
        GridView16.DataBind()

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
        NOMBRE = NOMBRE.Replace("á", "a")
        NOMBRE = NOMBRE.Replace("é", "e")
        NOMBRE = NOMBRE.Replace("í", "i")
        NOMBRE = NOMBRE.Replace("ó", "o")
        NOMBRE = NOMBRE.Replace("ú", "u")
        NOMBRE = NOMBRE.Replace("à", "a")
        NOMBRE = NOMBRE.Replace("è", "e")
        NOMBRE = NOMBRE.Replace("ì", "i")
        NOMBRE = NOMBRE.Replace("ò", "o")
        NOMBRE = NOMBRE.Replace("ù", "u")
        DOCUMENTO = TextBox3.Text.ToUpper()
        DOCUMENTO = DOCUMENTO.Replace(".", "")
        DOCUMENTO = DOCUMENTO.Replace("-", "")


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
        NOMBRE = NOMBRE.Replace("á", "a")
        NOMBRE = NOMBRE.Replace("é", "e")
        NOMBRE = NOMBRE.Replace("í", "i")
        NOMBRE = NOMBRE.Replace("ó", "o")
        NOMBRE = NOMBRE.Replace("ú", "u")
        NOMBRE = NOMBRE.Replace("à", "a")
        NOMBRE = NOMBRE.Replace("è", "e")
        NOMBRE = NOMBRE.Replace("ì", "i")
        NOMBRE = NOMBRE.Replace("ò", "o")
        NOMBRE = NOMBRE.Replace("ù", "u")
        DOCUMENTO = TextBox3.Text.ToUpper()
        DOCUMENTO = DOCUMENTO.Replace(".", "")
        DOCUMENTO = DOCUMENTO.Replace("-", "")

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
        DIRECCION = DIRECCION.Replace("á", "a")
        DIRECCION = DIRECCION.Replace("é", "e")
        DIRECCION = DIRECCION.Replace("í", "i")
        DIRECCION = DIRECCION.Replace("ó", "o")
        DIRECCION = DIRECCION.Replace("ú", "u")
        DIRECCION = DIRECCION.Replace("à", "a")
        DIRECCION = DIRECCION.Replace("è", "e")
        DIRECCION = DIRECCION.Replace("ì", "i")
        DIRECCION = DIRECCION.Replace("ò", "o")
        DIRECCION = DIRECCION.Replace("ù", "u")
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
            Dim chk As CheckBox = CType(gvrow.FindControl("SelectRow2"), CheckBox)

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
            Dim chk As CheckBox = CType(gvrow.FindControl("SelectRow2"), CheckBox)

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
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel2').style.display = 'block', document.getElementById('closepanel').style.display = 'table', document.getElementById('Panel0').style.display = 'none'", True)

    End Sub

    Protected Sub Button15_Click(sender As Object, e As EventArgs)

        'Dar alta contrato
        'Genera un registro por cada mes de contrato
        Dim INICIO As DateTime
        Dim VENCIMIENTO As DateTime
        Dim IMPORTE_MENSUAL As Double
        Dim IMPORTE_IMPUESTOM As Double
        Dim OBSERVACION As String
        Dim COEFICIENTE As String
        Dim PROPIETARIO As String
        Dim INQUILINO As String
        Dim DIRECCION As String
        Dim LOCALIDAD As String
        Dim PROVINCIA As String
        Dim HONORARIOS As Double
        Dim DEPOSITO As Double
        Dim ADMINISTRACION As Double

        If TextBox9.Text = "dd/mm/aaaa" Or TextBox9.Text = "" Or IsDBNull(TextBox9.Text) Then
            Label3.Text = "Ingrese una fecha de inicio de contrato"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel3').style.display = 'block';", True)
            Exit Sub
        End If
        If TextBox13.Text = "dd/mm/aaaa" Or TextBox13.Text = "" Or IsDBNull(TextBox13.Text) Then
            Label3.Text = "Ingrese una fecha de vencimiento de contrato"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel3').style.display = 'block';", True)
            Exit Sub
        End If
        If TextBox10.Text = "" Or Not IsNumeric(TextBox10.Text) Then
            Label3.Text = "Ingrese un importe válido"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel3').style.display = 'block';", True)
            Exit Sub
        End If
        If TextBox11.Text = "" Or Not IsNumeric(TextBox11.Text) Then
            Label3.Text = "Ingrese valor del impuesto municipal"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel3').style.display = 'block';", True)
            Exit Sub
        End If
        If TextBox14.Text = "" Or Not IsNumeric(TextBox14.Text) Then
            Label3.Text = "Ingrese un coeficiente de interés"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel3').style.display = 'block';", True)
            Exit Sub
        End If
        If DropDownList8.SelectedValue = 0 Then
            Label3.Text = "Seleccione un inquilino"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel3').style.display = 'block';", True)
            Exit Sub
        End If
        If DropDownList7.SelectedValue = 0 Then
            Label3.Text = "Seleccione una propiedad"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel3').style.display = 'block';", True)
            Exit Sub
        End If
        If TextBox18.Text = "" Or Not IsNumeric(TextBox18.Text) Then
            Label3.Text = "Ingrese honorarios"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel3').style.display = 'block';", True)
            Exit Sub
        End If
        If TextBox19.Text = "" Or Not IsNumeric(TextBox19.Text) Then
            Label3.Text = "Ingrese valor de depósito"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel3').style.display = 'block';", True)
            Exit Sub
        End If
        If TextBox36.Text = "" Or Not IsNumeric(TextBox36.Text) Then
            Label3.Text = "Ingrese valor de administracion"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel3').style.display = 'block';", True)
            Exit Sub
        End If

        INICIO = CDate(TextBox9.Text).ToString("MM/dd/yyyy")
        VENCIMIENTO = CDate(TextBox13.Text).ToString("MM/dd/yyyy")
        IMPORTE_MENSUAL = CDbl(TextBox10.Text)
        IMPORTE_IMPUESTOM = CDbl(TextBox11.Text)
        OBSERVACION = TextBox12.Text
        COEFICIENTE = TextBox14.Text

        SqlDataSource2.SelectCommand = "SELECT * FROM [Propiedades] WHERE DIRECCION = '" & TextBox15.Text & "'"
        GridView2.DataBind()

        PROPIETARIO = GridView2.Rows(0).Cells(7).Text
        INQUILINO = DropDownList8.SelectedItem.Text
        DIRECCION = TextBox15.Text
        LOCALIDAD = TextBox16.Text
        PROVINCIA = TextBox17.Text
        HONORARIOS = CDbl(TextBox18.Text)
        DEPOSITO = CDbl(TextBox19.Text)
        ADMINISTRACION = CDbl(TextBox36.Text)

        SqlDataSource3.InsertCommand = "INSERT INTO [Contratos] ([INICIO], [VENCIMIENTO], [IMPORTE_MENSUAL], [IMPORTE_IMPUESTOM], [OBSERVACION], [COEFICIENTE], [PROPIETARIO], [INQUILINO], [DIRECCION], [LOCALIDAD], [PROVINCIA], [HONORARIOS], [DEPOSITO], [ADMINISTRACION]) VALUES (@INICIO, @VENCIMIENTO, @IMPORTE_MENSUAL, @IMPORTE_IMPUESTOM, @OBSERVACION, @COEFICIENTE, @PROPIETARIO, @INQUILINO, @DIRECCION, @LOCALIDAD, @PROVINCIA, @HONORARIOS, @DEPOSITO, @ADMINISTRACION)"
        SqlDataSource3.InsertParameters.Add("INICIO", (INICIO).ToString("MM/dd/yyyy hh:mm:ss"))
        SqlDataSource3.InsertParameters.Add("VENCIMIENTO", (VENCIMIENTO).ToString("MM/dd/yyyy hh:mm:ss"))
        SqlDataSource3.InsertParameters.Add("IMPORTE_MENSUAL", IMPORTE_MENSUAL)
        SqlDataSource3.InsertParameters.Add("IMPORTE_IMPUESTOM", IMPORTE_IMPUESTOM)
        SqlDataSource3.InsertParameters.Add("OBSERVACION", OBSERVACION)
        SqlDataSource3.InsertParameters.Add("COEFICIENTE", COEFICIENTE)
        SqlDataSource3.InsertParameters.Add("PROPIETARIO", PROPIETARIO)
        SqlDataSource3.InsertParameters.Add("INQUILINO", INQUILINO)
        SqlDataSource3.InsertParameters.Add("DIRECCION", DIRECCION)
        SqlDataSource3.InsertParameters.Add("LOCALIDAD", LOCALIDAD)
        SqlDataSource3.InsertParameters.Add("PROVINCIA", PROVINCIA)
        SqlDataSource3.InsertParameters.Add("HONORARIOS", HONORARIOS)
        SqlDataSource3.InsertParameters.Add("DEPOSITO", DEPOSITO)
        SqlDataSource3.InsertParameters.Add("ADMINISTRACION", ADMINISTRACION)
        SqlDataSource3.Insert()

        SqlDataSource3.SelectCommand = "SELECT * FROM [Contratos] ORDER BY Id DESC"
        GridView3.DataBind()

        SqlDataSource2.SelectCommand = "SELECT * FROM [Propiedades] ORDER BY DIRECCION ASC"
        GridView2.DataBind()

        'Dim fromDate As DateTime = INICIO
        'Dim toDate As DateTime = VENCIMIENTO
        'Dim month As Double = Math.Round((toDate.Subtract(fromDate).TotalDays) / 30, 1)
        'Dim contador As Integer = 0

        Dim NUMERO As Integer
        Dim IMPORTE As Double
        Dim MES As Integer
        Dim AÑO As Integer
        Dim INTERESES As Double
        Dim PAGADO As Double
        Dim SALDO As Double
        Dim AÑO_VENCIMIENTO As Integer
        Dim MES_VENCIMIENTO As Integer

        MES = INICIO.Month
        AÑO = INICIO.Year
        MES_VENCIMIENTO = VENCIMIENTO.Month
        AÑO_VENCIMIENTO = VENCIMIENTO.Year

        SqlDataSource4.InsertCommand = "INSERT INTO [Detalle_Contratos] ([NUMERO], [PROPIETARIO], [INQUILINO], [IMPORTE], [MES], [AÑO], [INTERESES], [PAGADO], [SALDO], [ESTADO]) VALUES (@NUMERO, @PROPIETARIO, @INQUILINO, @IMPORTE, @MES, @AÑO, @INTERESES, @PAGADO, @SALDO, @ESTADO)"

        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "alert('" & month & "');", True)

        Do

            If MES = 13 Then
                MES = 1
                AÑO += 1
            End If

            NUMERO = CInt(GridView3.Rows(0).Cells(1).Text)
            IMPORTE = IMPORTE_MENSUAL
            INTERESES = 0
            PAGADO = 0
            SALDO = IMPORTE

            SqlDataSource4.InsertParameters.Add("NUMERO", NUMERO)
            SqlDataSource4.InsertParameters.Add("PROPIETARIO", PROPIETARIO)
            SqlDataSource4.InsertParameters.Add("INQUILINO", INQUILINO)
            SqlDataSource4.InsertParameters.Add("IMPORTE", IMPORTE)
            SqlDataSource4.InsertParameters.Add("MES", MES)
            SqlDataSource4.InsertParameters.Add("AÑO", AÑO)
            SqlDataSource4.InsertParameters.Add("INTERESES", INTERESES)
            SqlDataSource4.InsertParameters.Add("PAGADO", PAGADO)
            SqlDataSource4.InsertParameters.Add("SALDO", SALDO)
            SqlDataSource4.InsertParameters.Add("ESTADO", "DEBE")

            SqlDataSource4.Insert()

            SqlDataSource4.InsertParameters.Clear()

            If MES = MES_VENCIMIENTO And AÑO = AÑO_VENCIMIENTO Then
                'Sale del do
                'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "alert('fin');", True)
                Exit Do
            End If

            MES += 1

        Loop

        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox14.Text = ""
        TextBox13.Text = ""
        TextBox18.Text = ""
        TextBox19.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""
        DropDownList7.SelectedValue = 0
        DropDownList8.SelectedValue = 0

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel3').style.display = 'block';", True)

    End Sub

    Protected Sub DropDownList7_SelectedIndexChanged(sender As Object, e As EventArgs)
        SqlDataSource2.SelectCommand = "SELECT * FROM [Propiedades] WHERE Estado = 'ACTIVO' AND DIRECCION = '" & DropDownList7.SelectedItem.Text & "'"
        GridView2.DataBind()
        'Completar campos y volver a filtrar
        TextBox15.Text = GridView2.Rows(0).Cells(2).Text
        TextBox16.Text = GridView2.Rows(0).Cells(3).Text
        TextBox17.Text = GridView2.Rows(0).Cells(4).Text

        SqlDataSource2.SelectCommand = "SELECT * FROM [Propiedades] Order By DIRECCION ASC"
        GridView2.DataBind()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel3').style.display = 'block';", True)
    End Sub

    Protected Sub DropDownList8_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub TextBox20_TextChanged(sender As Object, e As EventArgs)

        SqlDataSource3.SelectCommand = "SELECT * FROM [Contratos] WHERE PROPIETARIO LIKE '%" & TextBox20.Text & "%' OR INQUILINO LIKE '%" & TextBox20.Text & "%' OR DIRECCION LIKE '%" & TextBox20.Text & "%' OR LOCALIDAD LIKE '%" & TextBox20.Text & "%' OR PROVINCIA LIKE '%" & TextBox20.Text & "%' ORDER BY Id DESC"
        GridView3.DataBind()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel3').style.display = 'block';", True)

    End Sub

    Protected Sub Button17_Click(sender As Object, e As EventArgs)

        'Editar contratos
        'Comparo cada textbox con la celda del gridview que corresponda
        'Si es igual, no se editó. Si es distinta, se editó.

        Dim IMPORTE_MENSUAL As Double = CDbl(TextBox10.Text)
        Dim IMPUESTO_MUNICIPAL As Double = CDbl(TextBox11.Text)
        Dim COEFICIENTE As Double = CDbl(TextBox14.Text)
        Dim HONORARIOS As Double = CDbl(TextBox18.Text)
        Dim OBSERVACION As String = TextBox12.Text
        Dim DEPOSITO As Double = CDbl(TextBox19.Text)
        Dim UpdateDetalle As Integer = 0
        Dim ADMINISTRACION As Double = CDbl(TextBox36.Text)

        For Each gvrow As GridViewRow In GridView3.Rows
            Dim chk As CheckBox = CType(gvrow.FindControl("SelectRow3"), CheckBox)

            If chk IsNot Nothing And chk.Checked Then

                Dim ID As String = gvrow.Cells(1).Text

                If Not IMPORTE_MENSUAL = gvrow.Cells(4).Text Then
                    'Cambiar detalle
                    UpdateDetalle = 1
                End If

                'Update a contratos
                SqlDataSource3.UpdateCommand = "UPDATE [Contratos] SET [IMPORTE_MENSUAL] = '" & IMPORTE_MENSUAL & "', [IMPORTE_IMPUESTOM] = '" & IMPUESTO_MUNICIPAL & "', [COEFICIENTE] = '" & COEFICIENTE & "', [HONORARIOS] = '" & HONORARIOS & "', [OBSERVACION] = '" & OBSERVACION & "', [DEPOSITO] = '" & DEPOSITO & "', [ADMINISTRACION] = '" & ADMINISTRACION & "' WHERE Id = '" & ID & "'"
                SqlDataSource3.Update()
                GridView3.DataBind()

                If UpdateDetalle = 1 Then
                    'Update a detalle
                    SqlDataSource4.UpdateCommand = "UPDATE [Detalle_Contratos] SET [IMPORTE] = '" & IMPORTE_MENSUAL & "', [SALDO] = '" & IMPORTE_MENSUAL & "' WHERE NUMERO = '" & ID & "' AND ESTADO = 'DEBE'"
                    SqlDataSource4.Update()
                End If

            End If
        Next

        ClearAll()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel3').style.display = 'block';", True)

    End Sub

    Protected Sub Button16_Click(sender As Object, e As EventArgs)

        'Eliminar contrato
        For Each gvrow As GridViewRow In GridView3.Rows
            Dim chk As CheckBox = CType(gvrow.FindControl("SelectRow3"), CheckBox)

            If chk IsNot Nothing And chk.Checked Then

                Dim ID As String = gvrow.Cells(1).Text

                'Borrar registro
                SqlDataSource3.DeleteCommand = "DELETE FROM [Contratos] WHERE Id = '" & ID & "'"
                SqlDataSource3.DeleteParameters.Add("ID", ID)
                SqlDataSource3.Delete()
                GridView3.DataBind()

                SqlDataSource4.DeleteCommand = "DELETE FROM [Detalle_Contratos] WHERE NUMERO = '" & ID & "'"
                SqlDataSource4.DeleteParameters.Add("NUMERO", ID)
                SqlDataSource4.Delete()

            End If
        Next

        SqlDataSource3.SelectCommand = "SELECT * FROM [Contratos] ORDER BY DIRECCION ASC"
        GridView3.DataBind()

        ClearAll()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel3').style.display = 'block';", True)

    End Sub

    Protected Sub Button14_Click(sender As Object, e As EventArgs)

        Dim USUARIO As String
        Dim CONTRASEÑA As String
        Dim NIVEL As String

        If TextBox29.Text = "" Then
            Label5.Text = "Ingrese un nombre de usuario"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel6').style.display = 'block';", True)
            Exit Sub
        End If
        If TextBox30.Text = "" Then
            Label5.Text = "Ingrese una contraseña"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel6').style.display = 'block';", True)
            Exit Sub
        End If
        If DropDownList4.SelectedValue = 0 Then
            Label5.Text = "Seleccione un nivel"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel6').style.display = 'block';", True)
            Exit Sub
        End If

        USUARIO = TextBox29.Text
        CONTRASEÑA = TextBox30.Text
        NIVEL = DropDownList4.SelectedItem.Text

        SqlDataSource5.InsertCommand = "INSERT INTO [Usuarios] ([Usuario], [Pass], [Nivel]) VALUES (@Usuario, @Pass, @Nivel)"
        SqlDataSource5.InsertParameters.Add("Usuario", USUARIO)
        SqlDataSource5.InsertParameters.Add("Pass", CONTRASEÑA)
        SqlDataSource5.InsertParameters.Add("Nivel", CInt(NIVEL))
        SqlDataSource5.Insert()

        SqlDataSource5.SelectCommand = "SELECT * FROM [Usuarios] ORDER BY Id DESC"
        GridView4.DataBind()

        ClearAll()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel6').style.display = 'block';", True)

    End Sub

    Protected Sub Button18_Click(sender As Object, e As EventArgs)

        'Eliminar usuario
        For Each gvrow As GridViewRow In GridView4.Rows
            Dim chk As CheckBox = CType(gvrow.FindControl("SelectRow4"), CheckBox)

            If chk IsNot Nothing And chk.Checked Then

                Dim ID As String = gvrow.Cells(1).Text

                'Borrar registro
                SqlDataSource5.DeleteCommand = "DELETE FROM [Usuarios] WHERE Id = '" & ID & "'"
                SqlDataSource5.DeleteParameters.Add("ID", ID)
                SqlDataSource5.Delete()
                GridView4.DataBind()

            End If
        Next

        SqlDataSource5.SelectCommand = "SELECT * FROM [Usuarios] ORDER BY Usuario ASC"
        GridView4.DataBind()

        ClearAll()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel6').style.display = 'block';", True)

    End Sub

    Protected Sub Button21_Click(sender As Object, e As EventArgs)

        SqlDataSource6.SelectCommand = "SELECT TOP 0 * FROM [Detalle_Cobranzas]"
        GridView5.DataBind()

        TextBox21.Text = ""
        TextBox22.Text = ""
        TextBox23.Text = ""
        TextBox25.Text = ""
        TextBox26.Text = ""
        DropDownList9.SelectedValue = 0

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel4').style.display = 'block';", True)

    End Sub

    Protected Sub Button20_Click(sender As Object, e As EventArgs)

        If TextBox21.Text = "" Then
            Label8.Text = "Ingrese un inquilino"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel4').style.display = 'block';", True)
            Exit Sub
        End If
        If TextBox22.Text = "" Then
            Label5.Text = "Ingrese un concepto"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel4').style.display = 'block';", True)
            Exit Sub
        End If
        If TextBox25.Visible = True Then
            If TextBox25.Text = "" And TextBox22.Text = "Alquiler" Then
                Label5.Text = "Ingrese un mes"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel4').style.display = 'block';", True)
                Exit Sub
            End If
            If CInt(TextBox25.Text) > 12 Or Not IsNumeric(TextBox25.Text) Then
                Label5.Text = "Ingrese un mes válido (1 al 12)"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel4').style.display = 'block';", True)
                Exit Sub
            End If
            If TextBox26.Text = "" And TextBox22.Text = "Alquiler" Then
                Label5.Text = "Ingrese un año"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel4').style.display = 'block';", True)
                Exit Sub
            End If
        End If
        If TextBox23.Text = "" Then
            Label5.Text = "Ingrese un importe"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel4').style.display = 'block';", True)
            Exit Sub
        End If

        Dim Numero As Integer
        Dim Concepto As String
        Dim Importe As Double
        Dim Fecha As Date
        Dim Cliente As String

        If GridView5.Rows.Count = 0 Then
            'Identificar último número
            If TextBox25.Visible = True Then
                If IsNumeric(TextBox25.Text) And IsNumeric(TextBox26.Text) Then
                    SqlDataSource9.SelectCommand = "SELECT TOP 10 * FROM [Detalle_Cobranzas] ORDER BY NUMERO DESC"
                    GridView8.DataBind()
                End If
            Else
                SqlDataSource9.SelectCommand = "SELECT TOP 10 * FROM [Detalle_Cobranzas] ORDER BY NUMERO DESC"
                GridView8.DataBind()
            End If
            If GridView8.Rows.Count > 0 Then
                'Asigna número
                Numero = CInt(GridView8.Rows(0).Cells(1).Text) + 1
            Else
                'Primera cobranza
                Numero = 1
            End If
        Else
            Numero = CInt(GridView8.Rows(0).Cells(1).Text) + 1
        End If


        Concepto = TextBox22.Text
        Importe = TextBox23.Text
        If Concepto = "Alquiler" Then
            Concepto = Concepto & " mes " & TextBox25.Text & "/" & TextBox26.Text & " $" & Importe.ToString("F2")
        Else
            Concepto = Concepto & " $" & Importe.ToString("F2")
        End If

        If GridView5.Rows.Count > 0 Then
            For Each row As GridViewRow In GridView5.Rows

                If row.Cells(0).Text = Concepto Then
                    Exit Sub
                End If

            Next
        End If

        Importe = CDbl(TextBox23.Text)
        Cliente = TextBox21.Text
        Fecha = DateTime.Now

        SqlDataSource6.InsertCommand = "INSERT INTO [Detalle_Cobranzas] ([Numero], [Concepto], [Importe], [Fecha], [Cliente]) VALUES (@Numero, @Concepto, @Importe, @Fecha, @Cliente)"
        SqlDataSource6.InsertParameters.Add("Numero", Numero)
        SqlDataSource6.InsertParameters.Add("Concepto", Concepto)
        SqlDataSource6.InsertParameters.Add("Importe", Importe)
        SqlDataSource6.InsertParameters.Add("Fecha", Fecha.ToString("MM/dd/yyyy"))
        SqlDataSource6.InsertParameters.Add("Cliente", Cliente)
        SqlDataSource6.Insert()

        SqlDataSource6.SelectCommand = "SELECT * FROM [Detalle_Cobranzas] WHERE NUMERO = " & Numero & " ORDER BY Id ASC"
        GridView5.DataBind()

        Dim Total As Double
        For Each row As GridViewRow In GridView5.Rows
            Dim suma As Decimal = Convert.ToDecimal(row.Cells(2).Text)
            Total += suma
        Next

        TextBox27.Text = "$" & Total.ToString("F2")
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel4').style.display = 'block';", True)

    End Sub

    Protected Sub TextBox24_TextChanged(sender As Object, e As EventArgs)

        SqlDataSource7.SelectCommand = "SELECT * FROM [Personas] WHERE NOMBRE LIKE '" & TextBox24.Text & "%' AND TIPO = 'INQUILINO' OR DOCUMENTO = '" & TextBox24.Text & "' AND TIPO = 'INQUILINO'"
        GridView6.DataBind()

        If GridView6.Rows.Count > 0 Then
            TextBox21.Text = GridView6.Rows(0).Cells(1).Text
        Else
            TextBox21.Text = ""
        End If

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel4').style.display = 'block';", True)

    End Sub

    Protected Sub DropDownList9_SelectedIndexChanged(sender As Object, e As EventArgs)

        If DropDownList9.SelectedValue = 0 Then
            TextBox22.ReadOnly = False
            TextBox23.ReadOnly = True
            TextBox25.Visible = False
            TextBox26.Visible = False
            TextBox22.Text = ""
            TextBox23.Text = ""
        ElseIf DropDownList9.SelectedValue = 1 Then
            TextBox22.ReadOnly = True
            TextBox22.Text = "Alquiler"
            TextBox25.Visible = True
            TextBox26.Visible = True
            TextBox23.ReadOnly = True
        ElseIf DropDownList9.SelectedValue = 2 Then
            TextBox22.ReadOnly = False
            TextBox25.Visible = False
            TextBox26.Visible = False
            TextBox23.ReadOnly = False
            TextBox22.Text = ""
            TextBox23.Text = ""
        ElseIf DropDownList9.SelectedValue = 3 Then
            TextBox22.ReadOnly = True
            TextBox22.Text = "Impuesto municipal"
            TextBox25.Visible = True
            TextBox26.Visible = True
            TextBox23.ReadOnly = False
        End If

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel4').style.display = 'block';", True)

    End Sub

    Protected Sub TextBox26_TextChanged(sender As Object, e As EventArgs)

        'Filtra inquilino por año en detalle_contratos para ver el saldo
        If IsNumeric(TextBox25.Text) And IsNumeric(TextBox26.Text) Then
            SqlDataSource14.SelectCommand = "SELECT * FROM [Detalle_Contratos] WHERE INQUILINO = '" & TextBox21.Text & "' AND MES = " & TextBox25.Text & " AND AÑO = " & TextBox26.Text & " ORDER BY Id ASC"
            GridView13.DataBind()
            TextBox23.Text = GridView13.Rows(0).Cells(9).Text
        End If

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel4').style.display = 'block';", True)

    End Sub

    Protected Sub Button22_Click(sender As Object, e As EventArgs)

        If GridView5.Rows.Count = 0 Then
            Exit Sub
        End If

        Dim Fecha As Date
        Dim Numero As Integer
        Dim Tipo As String
        Dim Cliente As String
        Dim Documento As String
        Dim Total As Double

        Fecha = Date.Now

        Numero = CInt(GridView8.Rows(0).Cells(1).Text) + 1
        Tipo = "ReciboCobranza"
        Cliente = TextBox21.Text
        If TextBox21.Text = "" Or GridView6.Rows.Count = 0 Then
            Documento = "0"
        Else
            Documento = GridView6.Rows(0).Cells(2).Text
        End If

        For Each row As GridViewRow In GridView5.Rows
            Dim suma As Decimal = Convert.ToDecimal(row.Cells(2).Text)
            Total += suma
        Next

        'Guarda datos en cobranzas
        SqlDataSource10.InsertCommand = "INSERT INTO [Cobranzas] ([Fecha], [PDV], [Numero], [Tipo], [Cliente], [Documento], [Total]) VALUES (@Fecha, @PDV, @Numero, @Tipo, @Cliente, @Documento, @Total)"
        SqlDataSource10.InsertParameters.Add("Fecha", Fecha)
        SqlDataSource10.InsertParameters.Add("PDV", 1)
        SqlDataSource10.InsertParameters.Add("Numero", Numero)
        SqlDataSource10.InsertParameters.Add("Tipo", Tipo)
        SqlDataSource10.InsertParameters.Add("Cliente", Cliente)
        SqlDataSource10.InsertParameters.Add("Documento", Documento)
        SqlDataSource10.InsertParameters.Add("Total", Total)
        SqlDataSource10.Insert()
        GridView9.DataBind()

        Session("impresion") = "SI"
        Session("letra") = "X"
        Session("Numero") = "0000-" & Numero.ToString("D8")
        Session("codigo") = "DOCUMENTO NO VALIDO COMO FACTURA"
        Session("compte") = "RECIBO"
        Session("fecha") = Fecha.ToShortDateString
        Session("cliente") = "Señor/a: " & HttpUtility.HtmlDecode(Cliente)
        'Session("domicilio") = GridView6.Rows(0).Cells(2).Text
        'Session("localidad") = GridView6.Rows(0).Cells(2).Text
        Dim ListaConceptos As String = ""
        If GridView5.Rows.Count = 1 Then
            ListaConceptos = GridView5.Rows(0).Cells(1).Text
        Else
            For i As Integer = 0 To GridView5.Rows.Count - 1
                ListaConceptos = ListaConceptos & GridView5.Rows(i).Cells(1).Text & Environment.NewLine
            Next i
        End If
        Session("concepto") = ListaConceptos
        Session("total") = "Total: $" & Total.ToString("F2")

        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "alert('" & ListaConceptos & "');", True)

        Response.Write("<script>window.open('impresion.aspx','_blank');</script>")

        'Update en detalle de contrato
        For Each row As GridViewRow In GridView5.Rows
            If row.Cells(1).Text.Contains("Alquiler") And DropDownList9.SelectedValue = 1 Or row.Cells(1).Text.Contains("Alquiler") And DropDownList9.SelectedValue = 3 Then

                Dim startString As String = row.Cells(1).Text
                Dim tempParts As String()
                Dim testValue As String
                Dim tempDate As DateTime
                Dim CurrentMes As Integer
                Dim CurrentAño As Integer

                tempParts = startString.Split(" ")

                For Each testValue In tempParts
                    If DateTime.TryParse(testValue, tempDate) = True Then
                        Dim fecha1 As String
                        fecha1 = CDate(String.Format("{0}", tempDate)).ToString("MM/dd/yyyy")
                        CurrentMes = Month(fecha1)
                        CurrentAño = Year(fecha1)

                    End If
                Next

                'Dim m As Match = Regex.Match(row.Cells(1).Text, "\d+\.\d+")
                Dim PAGADO As Double = CDbl(row.Cells(2).Text)
                Dim SALDO As Double = CDbl(GridView13.Rows(0).Cells(9).Text)
                SALDO = SALDO - PAGADO
                'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "alert('" & SALDO & "');", True)

                SqlDataSource14.UpdateCommand = "UPDATE [Detalle_Contratos] SET [PAGADO] = " & PAGADO & ", [SALDO] = " & SALDO & ", [ESTADO] = 'PAGO' WHERE NUMERO = " & GridView13.Rows(0).Cells(1).Text & " AND MES = " & CurrentMes & " AND AÑO = " & CurrentAño & ""
                SqlDataSource14.InsertParameters.Add("PAGADO", PAGADO)
                SqlDataSource14.InsertParameters.Add("SALDO", SALDO)
                SqlDataSource14.InsertParameters.Add("ESTADO", "PAGO")
                SqlDataSource14.Update()
            End If
        Next

        GridView13.DataBind()

        SqlDataSource6.SelectCommand = "SELECT TOP 0 * FROM [Detalle_Cobranzas]"
        GridView5.DataBind()

        SqlDataSource16.SelectCommand = "SELECT TOP 0 * FROM [Cobranzas]"
        GridView15.DataBind()

        TextBox21.Text = ""
        TextBox22.Text = ""
        TextBox23.Text = ""
        TextBox25.Text = ""
        TextBox26.Text = ""
        TextBox27.Text = "$0,00"
        DropDownList9.SelectedValue = 0

        Session("usuario") = DirectCast(Session("usuario"), String)
        Session("nivel") = DirectCast(Session("nivel"), String)

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel4').style.display = 'block';", True)

    End Sub

    Protected Sub Button24_Click(sender As Object, e As EventArgs)

        For Each gvrow As GridViewRow In GridView10.Rows
            Dim chk As CheckBox = CType(gvrow.FindControl("SelectRow5"), CheckBox)

            If chk IsNot Nothing And chk.Checked Then

                If GridView11.Rows.Count = 0 Then
                    SqlDataSource12.SelectCommand = "SELECT * FROM [Detalle_Cobranzas] WHERE NUMERO = " & CInt(gvrow.Cells(4).Text) & ""
                    GridView11.DataBind()
                End If

                If GridView10.Rows.Count > 0 Then

                    Session("impresion") = "SI"
                    Session("letra") = "X"
                    Session("Numero") = "0000-" & CInt(gvrow.Cells(4).Text).ToString("D8")
                    Session("codigo") = "DOCUMENTO NO VALIDO COMO FACTURA"
                    Session("compte") = "RECIBO"
                    Session("fecha") = CDate(gvrow.Cells(2).Text).ToString("dd/MM/yyyy")
                    Session("cliente") = "Señor/a: " & gvrow.Cells(6).Text
                    'Session("domicilio") = GridView6.Rows(0).Cells(2).Text
                    'Session("localidad") = GridView6.Rows(0).Cells(2).Text
                    Dim ListaConceptos As String = ""
                    If GridView11.Rows.Count > 1 Then
                        For i As Integer = 0 To GridView11.Rows.Count - 1
                            ListaConceptos = ListaConceptos & GridView11.Rows(i).Cells(2).Text & Environment.NewLine
                        Next i
                        Session("concepto") = ListaConceptos
                    Else
                        Session("concepto") = GridView11.Rows(0).Cells(2).Text
                    End If
                    Session("total") = "Total: $" & CDbl(gvrow.Cells(10).Text).ToString("F2")

                    Response.Write("<script>window.open('impresion.aspx','_blank');</script>")

                End If


            End If
        Next

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel5').style.display = 'block';", True)

    End Sub

    Protected Sub TextBox28_TextChanged(sender As Object, e As EventArgs)
        SqlDataSource11.SelectCommand = "SELECT * FROM [Cobranzas] WHERE CLIENTE LIKE '" & TextBox28.Text & "%' ORDER BY FECHA DESC"
        GridView10.DataBind()

        If GridView10.Rows.Count > 0 Then
            SqlDataSource12.SelectCommand = "SELECT * FROM [Detalle_Cobranzas] WHERE NUMERO = " & CInt(GridView10.Rows(0).Cells(4).Text) & ""
            GridView11.DataBind()
        End If

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel5').style.display = 'block';", True)
    End Sub

    Protected Sub TextBox31_TextChanged(sender As Object, e As EventArgs)

        SqlDataSource15.SelectCommand = "SELECT * FROM [Contratos] WHERE DIRECCION LIKE '" & TextBox31.Text & "%'"
        GridView14.DataBind()

        TextBox33.Text = GridView14.Rows(0).Cells(9).Text
        TextBox32.Text = GridView14.Rows(0).Cells(7).Text
        TextBox39.Text = GridView14.Rows(0).Cells(8).Text
        If Not IsDBNull(GridView14.Rows(0).Cells(14).Text) Then
            TextBox38.Text = GridView14.Rows(0).Cells(14).Text
        ElseIf GridView14.Rows(0).Cells(14).Text = " " Or GridView14.Rows(0).Cells(14).Text = "" Or GridView14.Rows(0).Cells(14).Text = "&nbsp;" Then
            TextBox38.Text = "0,00"
        End If

        If TextBox38.Text = "&nbsp;" Then
            TextBox38.Text = "0,00"
        End If

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel7').style.display = 'block';", True)

    End Sub

    Protected Sub Button25_Click(sender As Object, e As EventArgs)

        'Ingresa detalle a liquidación
        Dim Numero As Integer
        Dim Concepto As String
        Dim Importe As Double
        Dim Fecha As DateTime
        Dim Cliente As String

        If GridView5.Rows.Count = 0 Then
            'Identificar último número
            If TextBox25.Visible = True Then
                If IsNumeric(TextBox25.Text) And IsNumeric(TextBox26.Text) Then
                    SqlDataSource9.SelectCommand = "SELECT TOP 10 * FROM [Detalle_Cobranzas] ORDER BY NUMERO DESC"
                    GridView8.DataBind()
                End If
            Else
                SqlDataSource9.SelectCommand = "SELECT TOP 10 * FROM [Detalle_Cobranzas] ORDER BY NUMERO DESC"
                GridView8.DataBind()
            End If
            If GridView8.Rows.Count > 0 Then
                'Asigna número
                Numero = CInt(GridView8.Rows(0).Cells(1).Text) + 1
            Else
                'Primera cobranza
                Numero = 1
            End If
        Else
            Numero = CInt(GridView8.Rows(0).Cells(1).Text) + 1
        End If

        Dim Total As Double

        Dim Desde As DateTime
        Dim Hasta As DateTime

        Dim Mes_desde As Integer
        Dim Año_desde As Integer
        Dim Mes_hasta As Integer
        Dim Año_hasta As Integer

        Desde = CDate(TextBox34.Text).ToString("MM/dd/yyyy")
        Hasta = CDate(TextBox35.Text).ToString("MM/dd/yyyy")

        Mes_desde = Desde.Month
        Año_desde = Desde.Year

        Mes_hasta = Hasta.Month
        Año_hasta = Hasta.Year

        MesDesdeLiq = Mes_desde
        AñoDesdeLiq = Año_desde
        MesHastaLiq = Mes_hasta
        AñoHastaLiq = Año_hasta

        If GridView13.Rows.Count > 1 Then
            For Each row As GridViewRow In GridView13.Rows
                If Not row.Cells(8).Text = "0,00" Then
                    Dim suma As Decimal = Convert.ToDecimal(row.Cells(8).Text)
                    Total += suma
                End If
            Next
            Concepto = MesDesdeLiq & "/" & AñoDesdeLiq & " a " & MesHastaLiq & "/" & AñoHastaLiq & " - $" & Total.ToString("F2")
        ElseIf GridView13.Rows.Count = 1 Then
            Total = CDbl(GridView13.Rows(0).Cells(8).Text).ToString("F2")
            Concepto = MesDesdeLiq & "/" & AñoDesdeLiq & " a " & MesHastaLiq & "/" & AñoHastaLiq & " - $" & Total.ToString("F2")
        ElseIf GridView13.Rows.Count = 0 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel7').style.display = 'block';", True)
            Exit Sub
        End If

        Importe = Total

        If Importe = 0 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel7').style.display = 'block';", True)
            Exit Sub
        End If

        Cliente = TextBox32.Text
        Fecha = DateTime.Now.ToString("MM/dd/yyyy")

        SqlDataSource17.InsertCommand = "INSERT INTO [Detalle_Cobranzas] ([Numero], [Concepto], [Importe], [Fecha], [Cliente]) VALUES (@Numero, @Concepto, @Importe, @Fecha, @Cliente)"
        SqlDataSource17.InsertParameters.Add("Numero", Numero)
        SqlDataSource17.InsertParameters.Add("Concepto", Concepto)
        SqlDataSource17.InsertParameters.Add("Importe", Importe)
        SqlDataSource17.InsertParameters.Add("Fecha", Fecha.ToString("MM/dd/yyyy"))
        SqlDataSource17.InsertParameters.Add("Cliente", Cliente)
        SqlDataSource17.Insert()

        SqlDataSource17.SelectCommand = "SELECT * FROM [Detalle_Cobranzas] WHERE NUMERO = " & Numero & " ORDER BY Id ASC"
        GridView16.DataBind()

        Dim Total2 As Double
        For Each row As GridViewRow In GridView16.Rows
            Dim suma As Decimal = Convert.ToDecimal(row.Cells(2).Text)
            Total2 += suma
        Next

        Total2 = Total2 - CDbl(TextBox38.Text)
        TextBox37.Text = "$" & Total2.ToString("F2")

        'SqlDataSource13.SelectCommand = "SELECT * FROM [Personas] WHERE TIPO = 'PROPIETARIO' AND NOMBRE = '" & GridView14.Rows(0).Cells(7).Text & "' ORDER BY Id ASC"
        'GridView12.DataBind()

        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "alert('" & GridView14.Rows(0).Cells(7).Text & "');", True)

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel7').style.display = 'block';", True)

    End Sub

    Protected Sub Button26_Click(sender As Object, e As EventArgs)

        SqlDataSource17.SelectCommand = "SELECT TOP 0 * FROM [Detalle_Cobranzas]"
        GridView16.DataBind()

        TextBox31.Text = ""
        TextBox32.Text = ""
        TextBox33.Text = ""
        TextBox38.Text = ""
        TextBox39.Text = ""
        TextBox37.Text = "$0,00"

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel7').style.display = 'block';", True)

    End Sub

    Protected Sub Button27_Click(sender As Object, e As EventArgs)
        'Ingreso cobranza e imprimo

        If GridView16.Rows.Count = 0 Then
            Exit Sub
        End If

        Dim Fecha As DateTime
        Dim Numero As Integer
        Dim Tipo As String
        Dim Cliente As String
        Dim Documento As String
        Dim Total As Double

        Fecha = DateTime.Now.ToString("MM/dd/yyyy")
        Numero = CInt(GridView8.Rows(0).Cells(1).Text) + 1
        Tipo = "Liquidacion"
        Cliente = TextBox32.Text
        Documento = "" 'GridView12.Rows(0).Cells(2).Text

        Dim Total2 As Double
        For Each row As GridViewRow In GridView16.Rows
            Dim suma As Decimal = Convert.ToDecimal(row.Cells(2).Text)
            Total2 += suma
        Next

        Total = Total2
        Total2 = Total2 - CDbl(TextBox38.Text)

        'Guarda datos en cobranzas
        SqlDataSource16.InsertCommand = "INSERT INTO [Cobranzas] ([Fecha], [PDV], [Numero], [Tipo], [Cliente], [Documento], [Total]) VALUES (@Fecha, @PDV, @Numero, @Tipo, @Cliente, @Documento, @Total)"
        SqlDataSource16.InsertParameters.Add("Fecha", Fecha.ToString("MM/dd/yyyy"))
        SqlDataSource16.InsertParameters.Add("PDV", 1)
        SqlDataSource16.InsertParameters.Add("Numero", Numero)
        SqlDataSource16.InsertParameters.Add("Tipo", Tipo)
        SqlDataSource16.InsertParameters.Add("Cliente", Cliente)
        SqlDataSource16.InsertParameters.Add("Documento", Documento)
        SqlDataSource16.InsertParameters.Add("Total", Total2)
        SqlDataSource16.Insert()
        GridView15.DataBind()

        Session("impresion") = "SI"
        Session("letra") = "X"
        Session("Numero") = "0000-" & Numero.ToString("D8")
        Session("codigo") = "DOCUMENTO NO VALIDO COMO FACTURA"
        Session("compte") = "LIQUIDACION"
        Session("fecha") = Fecha.ToString("dd/MM/yyyy")
        Session("inquilino") = "Inquilino/a: " & TextBox39.Text
        Session("cliente") = "Señor/a: " & HttpUtility.HtmlDecode(Cliente)
        'Session("domicilio") = GridView6.Rows(0).Cells(2).Text
        'Session("localidad") = GridView6.Rows(0).Cells(2).Text
        Dim ListaConceptos As String = ""
        If GridView16.Rows.Count > 1 Then
            For i As Integer = 0 To GridView16.Rows.Count - 1
                ListaConceptos = HttpUtility.HtmlDecode(ListaConceptos) & HttpUtility.HtmlDecode(GridView16.Rows(i).Cells(1).Text) & " - $" & HttpUtility.HtmlDecode(GridView16.Rows(i).Cells(2).Text) & Environment.NewLine
            Next i
            Session("concepto") = HttpUtility.HtmlDecode(ListaConceptos)
        Else
            Session("concepto") = HttpUtility.HtmlDecode(GridView16.Rows(0).Cells(1).Text) & " - $" & HttpUtility.HtmlDecode(GridView16.Rows(0).Cells(2).Text)
        End If
        Session("total") = "Total liquidación: $" & Total.ToString("F2")
        Session("honorarios") = "Honorarios: $" & CDbl(TextBox38.Text).ToString("F2") & " | " & "Total pagado: $" & Total2.ToString("F2")

        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "alert('" & ListaConceptos & "');", True)

        Response.Write("<script>window.open('impresion.aspx','_blank');</script>")

        SqlDataSource17.SelectCommand = "SELECT TOP 0 * FROM [Detalle_Cobranzas]"
        GridView16.DataBind()

        TextBox21.Text = ""
        TextBox22.Text = ""
        TextBox23.Text = ""
        TextBox25.Text = ""
        TextBox26.Text = ""
        TextBox27.Text = "$0,00"
        DropDownList9.SelectedValue = 0

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel7').style.display = 'block';", True)

    End Sub

    Protected Sub TextBox35_TextChanged(sender As Object, e As EventArgs)

        If TextBox34.Text = "" Or TextBox34.Text = "dd/mm/aaaa" Then
            Exit Sub
        End If

        Dim Desde As DateTime
        Dim Hasta As DateTime

        Dim Mes_desde As Integer
        Dim Año_desde As Integer
        Dim Mes_hasta As Integer
        Dim Año_hasta As Integer

        Desde = CDate(TextBox34.Text).ToString("MM/dd/yyyy")
        Hasta = CDate(TextBox35.Text).ToString("MM/dd/yyyy")

        Mes_desde = Desde.Month
        Año_desde = Desde.Year

        Mes_hasta = Hasta.Month
        Año_hasta = Hasta.Year

        SqlDataSource14.SelectCommand = "SELECT * FROM [Detalle_Contratos] WHERE NUMERO = '" & GridView14.Rows(0).Cells(0).Text & "' AND MES >= " & Mes_desde & " AND AÑO >= " & Año_desde & " AND MES <= " & Mes_hasta & " AND AÑO <= " & Año_hasta & ""
        GridView13.DataBind()

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel7').style.display = 'block';", True)

    End Sub

    Protected Sub Button28_Click(sender As Object, e As EventArgs)

        If TextBox41.Text = "" Then
            Exit Sub
        End If

        If TextBox42.Text = "" Then
            Exit Sub
        End If

        If Not IsNumeric(TextBox42.Text) Then
            Exit Sub
        End If

        If GridView16.Rows.Count = 0 Then
            Exit Sub
        End If

        'Ingresa detalle a liquidación
        Dim Numero As Integer
        Dim Concepto As String
        Dim Importe As Double
        Dim Fecha As DateTime
        Dim Cliente As String

        Numero = CInt(GridView8.Rows(0).Cells(1).Text) + 1

        Concepto = TextBox41.Text.ToUpper()

        Importe = TextBox42.Text

        If Importe = 0 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel7').style.display = 'block';", True)
            Exit Sub
        End If

        Cliente = TextBox32.Text
        Fecha = DateTime.Now.ToString("MM/dd/yyyy")

        SqlDataSource17.InsertCommand = "INSERT INTO [Detalle_Cobranzas] ([Numero], [Concepto], [Importe], [Fecha], [Cliente]) VALUES (@Numero, @Concepto, @Importe, @Fecha, @Cliente)"
        SqlDataSource17.InsertParameters.Add("Numero", Numero)
        SqlDataSource17.InsertParameters.Add("Concepto", Concepto)
        SqlDataSource17.InsertParameters.Add("Importe", Importe)
        SqlDataSource17.InsertParameters.Add("Fecha", Fecha.ToString("MM/dd/yyyy"))
        SqlDataSource17.InsertParameters.Add("Cliente", Cliente)
        SqlDataSource17.Insert()

        SqlDataSource17.SelectCommand = "SELECT * FROM [Detalle_Cobranzas] WHERE NUMERO = " & Numero & " ORDER BY Id ASC"
        GridView16.DataBind()

        Dim Total2 As Double
        For Each row As GridViewRow In GridView16.Rows
            Dim suma As Decimal = Convert.ToDecimal(row.Cells(2).Text)
            Total2 += suma
        Next

        Total2 = Total2 - CDbl(TextBox38.Text)
        TextBox37.Text = "$" & Total2.ToString("F2")

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alerta", "document.getElementById('Panel7').style.display = 'block';", True)

    End Sub
End Class