<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="SistemaGestionInmobiliaria.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="shortcut icon" href="Images/mini_logo.png" type="image/x-icon" />
    <title>Gestión Inmobiliaria</title>
    <link rel="stylesheet" href="Estilos.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="parent" class="parent">
            <div id="login" class="contenedor_login">
                <div id="logo" class="logo"><img src="Images/logo.png"/></div>
                <asp:TextBox ID="TextBox1" runat="server" Text="" Placeholder="Ingrese contraseña" CssClass="login_textbox" TextMode="Password"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="INGRESAR" CssClass="login_button" OnClick="Button1_Click" />
                <div class="login_footer"><a>Mills Gestión Inmobiliaria</a></div>
            </div>
        </div>

        <%-- GRID CON USUARIOS --%>

        <asp:SqlDataSource ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:InmCamiletti %>" ProviderName="<%$ ConnectionStrings:InmCamiletti.ProviderName %>" SelectCommand="SELECT * FROM [Usuarios]" runat="server"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" Visible="false"></asp:GridView>

    </form>
</body>
</html>
