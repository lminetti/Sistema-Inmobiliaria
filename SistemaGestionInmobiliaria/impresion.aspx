<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="impresion.aspx.vb" Inherits="SistemaGestionInmobiliaria.impresion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="shortcut icon" href="Images/mini_logo.png" type="image/x-icon" />
    <title>Gestión Inmobiliaria - Impresion</title>
    <link rel="stylesheet" href="Estilos.css" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="contenedor_impresion">
            <div class="impresion_logo">
                <img src="Images/logo_big.png" />
            </div>
            <div class="impresion_datosempresa">
                <a>Almafuerte 3353, Saladillo | Tel: (02345) 424912<br />
                    Responsable Monotributo</a>
            </div>
            <asp:TextBox ID="TextBoxLetra" runat="server" CssClass="impresion_letra" Text="X" ReadOnly="true"></asp:TextBox>
            <asp:TextBox ID="TextBoxCodigo" runat="server" CssClass="impresion_codigo" Text="DOCUMENTO NO VALIDO COMO FACTURA" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
            <asp:TextBox ID="TextBoxCompte" runat="server" CssClass="impresion_compte" Text="RECIBO" ReadOnly="true"></asp:TextBox>
            <asp:TextBox ID="TextBoxFecha" runat="server" CssClass="impresion_fecha" Text="23/09/2021" ReadOnly="true"></asp:TextBox>
            <div class="impresion_datosempresa2">
                <a>CUIT: 20282154715<br />
                    IIBB: 20282154715<br />
                    Inicio de actividades: 09/2021</a>
            </div>

            <div class="impresion_borde"></div>

            <asp:TextBox ID="TextBoxCliente" runat="server" CssClass="impresion_cliente" Text="" ReadOnly="true"></asp:TextBox><br />
            <asp:TextBox ID="TextBoxInquilino" runat="server" CssClass="impresion_cliente" Text="" ReadOnly="true"></asp:TextBox><br />
<%--            <asp:TextBox ID="TextBoxDomicilio" runat="server" CssClass="impresion_domicilio" Text="Domicilio: ESTRADA N.2743" ReadOnly="true"></asp:TextBox>
            <asp:TextBox ID="TextBoxLocalidad" runat="server" CssClass="impresion_localidad" Text="Localidad: SALADILLO" ReadOnly="true"></asp:TextBox>--%>

            <div class="impresion_borde"></div>

            <div class="impresion_contenido">
                <asp:TextBox ID="TextBoxConcepto" runat="server" CssClass="impresion_concepto" Text="En concepto de: ALQUILER 9/2021" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="impresion_borde"></div>

            <div class="impresion_pie">
                <div class="impresion_firma">
                    <a>Firma y aclaración: ______________________<br />ORIGINAL</a>
                </div>
                <asp:TextBox ID="TextBoxTotal" runat="server" CssClass="impresion_total" Text="Total: $6.000,00" ReadOnly="true" style="position:absolute;top:2%;right:2%;width:60%;text-align:left;border:none;outline:none;font-size:14px;font-weight:700;resize:none;font-family:'Segoe UI';" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>

        <br />

        <div class="contenedor_impresion">
            <div class="impresion_logo">
                <img src="Images/logo_big.png" />
            </div>
            <div class="impresion_datosempresa">
                <a>Almafuerte 3353, Saladillo | Tel: (02345) 424912<br />
                    Responsable Monotributo</a>
            </div>
            <asp:TextBox ID="TextBoxLetra_2" runat="server" CssClass="impresion_letra" Text="X" ReadOnly="true"></asp:TextBox>
            <asp:TextBox ID="TextBoxCodigo_2" runat="server" CssClass="impresion_codigo" Text="DOCUMENTO NO VALIDO COMO FACTURA" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
            <asp:TextBox ID="TextBoxCompte_2" runat="server" CssClass="impresion_compte" Text="RECIBO" ReadOnly="true"></asp:TextBox>
            <asp:TextBox ID="TextBoxFecha_2" runat="server" CssClass="impresion_fecha" Text="23/09/2021" ReadOnly="true"></asp:TextBox>
            <div class="impresion_datosempresa2">
                <a>CUIT: 20282154715<br />
                    IIBB: 20282154715<br />
                    Inicio de actividades: 09/2021</a>
            </div>

            <div class="impresion_borde"></div>

            <asp:TextBox ID="TextBoxCliente_2" runat="server" CssClass="impresion_cliente" Text="Señor/a: HERNAEZ ALICIA NOEMI" ReadOnly="true"></asp:TextBox><br />
            <asp:TextBox ID="TextBoxInquilino_2" runat="server" CssClass="impresion_cliente" Text="" ReadOnly="true"></asp:TextBox><br />
<%--            <asp:TextBox ID="TextBoxDomicilio_2" runat="server" CssClass="impresion_domicilio" Text="Domicilio: ESTRADA N.2743" ReadOnly="true"></asp:TextBox>
            <asp:TextBox ID="TextBoxLocalidad_2" runat="server" CssClass="impresion_localidad" Text="Localidad: SALADILLO" ReadOnly="true"></asp:TextBox>--%>

            <div class="impresion_borde"></div>

            <div class="impresion_contenido">
                <asp:TextBox ID="TextBoxConcepto_2" runat="server" CssClass="impresion_concepto" Text="En concepto de: ALQUILER 9/2021" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="impresion_borde"></div>

            <div class="impresion_pie">
                <div class="impresion_firma">
                    <a>Firma y aclaración: ______________________<br />DUPLICADO</a>
                </div>
                <asp:TextBox ID="TextBoxTotal_2" runat="server" CssClass="impresion_total" Text="Total: $6.000,00" ReadOnly="true" style="position:absolute;top:2%;right:2%;width:60%;text-align:left;border:none;outline:none;font-size:14px;font-weight:700;resize:none;font-family:'Segoe UI';" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>

    </form>
</body>
</html>
