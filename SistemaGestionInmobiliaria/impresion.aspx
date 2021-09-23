<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="impresion.aspx.vb" Inherits="SistemaGestionInmobiliaria.impresion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="shortcut icon" href="Images/mini_logo.png" type="image/x-icon" />
    <title>Gestión Inmobiliaria - Impresion</title>
    <link rel="stylesheet" href="Estilos.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor_impresion">
            <div class="impresion_logo"><img src="Images/logo_big.png"/></div>
            <div class="impresion_datosempresa"><a>Almafuerte 3353, Saladillo | Tel: (02345) 424912<br/>Responsable Monotributo</a></div>
            <asp:TextBox ID="TextBoxLetra" runat="server" CssClass="impresion_letra" Text="X"></asp:TextBox>
            <asp:TextBox ID="TextBoxCompte" runat="server" CssClass="impresion_compte" Text="RECIBO"></asp:TextBox>
            <asp:TextBox ID="TextBoxFecha" runat="server" CssClass="impresion_fecha" Text="23/09/2021"></asp:TextBox>
            <div class="impresion_datosempresa2"><a></a></div>
        </div>
    </form>
</body>
</html>
