<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Panel.aspx.vb" Inherits="SistemaGestionInmobiliaria.Panel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="shortcut icon" href="Images/mini_logo.png" type="image/x-icon" />
    <title>Gestión Inmobiliaria - Panel</title>
    <link rel="stylesheet" href="Estilos.css" />

    <script src="jquery.js"></script>
    <script>

        $(document).ready(function () {

            $("#menu").hide();

            $("#sandwich").click(function (e) {
                $("#menu").animate({
                    opacity: 1,
                    left: "0",
                    width: "toggle"
                }, 200, function () {
                });
            });

            $("#closemenu").click(function (e) {
                $("#menu").animate({
                    opacity: 0,
                    left: "0",
                    width: "toggle"
                }, 200, function () {
                });
            });

            $("#Button1").click(function (e) {
                $("#menu").animate({
                    opacity: 0,
                    left: "0",
                    width: "toggle"
                }, 200, function () {
                });
            });

            $("#Button2").click(function (e) {
                $("#menu").animate({
                    opacity: 0,
                    left: "0",
                    width: "toggle"
                }, 200, function () {
                });
            });

            $("#Button3").click(function (e) {
                $("#menu").animate({
                    opacity: 0,
                    left: "0",
                    width: "toggle"
                }, 200, function () {
                });
            });

            $("#Button4").click(function (e) {
                $("#menu").animate({
                    opacity: 0,
                    left: "0",
                    width: "toggle"
                }, 200, function () {
                });
            });

            $("#Button5").click(function (e) {
                $("#menu").animate({
                    opacity: 0,
                    left: "0",
                    width: "toggle"
                }, 200, function () {
                });
            });

        });

    </script>

    <script>

        function CheckGridList(chckbx) {
            document.getElementById('TextBox2').value = null;
            document.getElementById('TextBox3').value = null;
            document.getElementById('TextBox4').value = null;
            var DropDown1 = document.getElementById("<%= DropDownList1.ClientID %>");
            DropDown1.options[0].selected = true;
            var DropDown2 = document.getElementById("<%= DropDownList2.ClientID %>");
            DropDown2.options[0].selected = true;
            var DropDown3 = document.getElementById("<%= DropDownList3.ClientID %>");
            DropDown3.options[0].selected = true;

            document.getElementById('Button7').style.display = "block";

            var count = 0;
            for (i = 0; i < document.forms[0].elements.length; i++) {
                if ((document.forms[0].elements[i].type == 'checkbox') &&
                    (document.forms[0].elements[i].name.indexOf('SelectRow') > -1)) {
                    if (document.forms[0].elements[i].checked == true) {

                        //alert(document.forms[0].elements[i].checked);

                        //if (document.forms[0].elements[i].checked == "true") {
                        //    document.getElementById('Button7').style.display = "none";  
                        //}                       

                        count++;
                        if (count > 1) {
                            document.getElementById('Button7').style.display = "block";
                            document.getElementById('TextBox2').value = null;
                            document.getElementById('TextBox3').value = null;
                            document.getElementById('TextBox4').value = null;
                            var DropDown1 = document.getElementById("<%= DropDownList1.ClientID %>");
                            DropDown1.options[0].selected = true;
                            var DropDown2 = document.getElementById("<%= DropDownList2.ClientID %>");
                            DropDown2.options[0].selected = true;
                            var DropDown3 = document.getElementById("<%= DropDownList3.ClientID %>");
                            DropDown3.options[0].selected = true;
                            document.forms[0].elements[i].checked = false;

                            var objGridview = chckbx.parentNode.parentNode.parentNode;
                            var list = objGridview.getElementsByTagName("input");

                            for (var i = 0; i < list.length; i++) {
                                var objRow = list[i].parentNode.parentNode;
                                if (list[i].type == "checkbox" && chckbx != list[i]) {
                                    if (chckbx.checked) {
                                        list[i].checked = false;
                                    }
                                }
                            }
                        }
                        else {
                            document.getElementById('Button7').style.display = "none";
                            var row = chckbx.parentElement.parentElement.rowIndex;
                            var Nombre = document.getElementById("GridView1").rows[row].cells[2].innerHTML;
                            var Documento = document.getElementById("GridView1").rows[row].cells[3].innerHTML;
                            var Telefono = document.getElementById("GridView1").rows[row].cells[5].innerHTML;
                            var IVA = document.getElementById("GridView1").rows[row].cells[4].innerHTML;
                            var Tipo = document.getElementById("GridView1").rows[row].cells[6].innerHTML;
                            var Estado = document.getElementById("GridView1").rows[row].cells[7].innerHTML;

                            document.getElementById("TextBox2").value = Nombre;
                            document.getElementById("TextBox3").value = Documento;
                            document.getElementById("TextBox4").value = Telefono;

                            if (IVA == "CONSUMIDOR FINAL") {
                                DropDown1.options[1].selected = true;
                            }
                            else if (IVA == "EXENTO FISCAL") {
                                DropDown1.options[2].selected = true;
                            }
                            else if (IVA == "RESPONSABLE MONOTRIBUTO") {
                                DropDown1.options[3].selected = true;
                            }
                            else if (IVA == "RESPONSABLE INSCRIPTO") {
                                DropDown1.options[4].selected = true;
                            }

                            if (Tipo == "INQUILINO") {
                                DropDown2.options[1].selected = true;
                            }
                            else if (Tipo == "PROPIETARIO") {
                                DropDown2.options[2].selected = true;
                            }

                            if (Estado == "ACTIVO") {
                                DropDown3.options[1].selected = true;
                            }
                            else if (Estado == "INACTIVO") {
                                DropDown3.options[2].selected = true;
                            }
                        }
                    }

                    else {

                    }
                }
            }

            if (count > 1) {
                return false;
            }
            else {
                return true;
            }

        }

        function CheckGridList2(chckbx2) {
            document.getElementById('TextBox5').value = null;
            document.getElementById('TextBox6').value = null;
            document.getElementById('TextBox7').value = null;
            document.getElementById('TextBox8').value = null;
            var DropDown5 = document.getElementById("<%= DropDownList5.ClientID %>");
            DropDown5.options[0].selected = true;
            var DropDown6 = document.getElementById("<%= DropDownList6.ClientID %>");
            DropDown6.options[0].selected = true;

            document.getElementById('Button10').style.display = "block";

            var count = 0;
            for (i = 0; i < document.forms[0].elements.length; i++) {
                if ((document.forms[0].elements[i].type == 'checkbox') &&
                    (document.forms[0].elements[i].name.indexOf('SelectRow2') > -1)) {
                    if (document.forms[0].elements[i].checked == true) {

                        count++;
                        if (count > 1) {
                            document.getElementById('TextBox5').value = null;
                            document.getElementById('TextBox6').value = null;
                            document.getElementById('TextBox7').value = null;
                            document.getElementById('TextBox8').value = null;
                            var DropDown5 = document.getElementById("<%= DropDownList5.ClientID %>");
                            DropDown5.options[0].selected = true;
                            var DropDown6 = document.getElementById("<%= DropDownList6.ClientID %>");
                            DropDown6.options[0].selected = true;
                            document.forms[0].elements[i].checked = false;

                            var objGridview = chckbx2.parentNode.parentNode.parentNode;
                            var list = objGridview.getElementsByTagName("input");

                            for (var i = 0; i < list.length; i++) {
                                var objRow = list[i].parentNode.parentNode;
                                if (list[i].type == "checkbox" && chckbx2 != list[i]) {
                                    if (chckbx2.checked) {
                                        list[i].checked = false;
                                    }
                                }
                            }
                        }
                        else {
                            document.getElementById('Button10').style.display = "none";
                            var row = chckbx2.parentElement.parentElement.rowIndex;
                            var Direccion = document.getElementById("GridView2").rows[row].cells[2].innerHTML;
                            var Localidad = document.getElementById("GridView2").rows[row].cells[3].innerHTML;
                            var Provincia = document.getElementById("GridView2").rows[row].cells[4].innerHTML;
                            var Estado = document.getElementById("GridView2").rows[row].cells[4].innerHTML;
                            var Foto = document.getElementById("GridView2").rows[row].cells[6].innerHTML;
                            var Propietario = document.getElementById("GridView2").rows[row].cells[7].innerHTML;

                            document.getElementById("TextBox5").value = Direccion;
                            document.getElementById("TextBox6").value = Localidad;
                            document.getElementById("TextBox7").value = Provincia;
                            document.getElementById("TextBox8").value = Foto;

                            if (Estado == "ACTIVO") {
                                DropDown5.options[1].selected = true;
                            }
                            else if (Estado == "INACTIVO") {
                                DropDown5.options[2].selected = true;
                            }

                            //DropDown6.textContent = "prueba"
                        }
                    }

                    else {

                    }
                }
            }

            if (count > 1) {
                return false;
            }
            else {
                return true;
            }

        }

        function CheckGridList3(chckbx3) {
            document.getElementById('TextBox9').style.display = 'initial';
            document.getElementById('TextBox13').style.display = 'initial';
            document.getElementById('Label1').style.display = 'initial';
            document.getElementById('Label2').style.display = 'initial';
            document.getElementById('TextBox9').value = null;
            document.getElementById('TextBox13').value = null;
            document.getElementById('TextBox10').value = null;
            document.getElementById('TextBox11').value = null;
            document.getElementById('TextBox12').value = null;
            document.getElementById('TextBox14').value = null;
            document.getElementById('TextBox15').value = null;
            document.getElementById('TextBox16').value = null;
            document.getElementById('TextBox17').value = null;
            document.getElementById('TextBox18').value = null;
            document.getElementById('TextBox19').value = null;
            var DropDown8 = document.getElementById("<%= DropDownList8.ClientID %>");
            DropDown8.options[0].selected = true;
            var DropDown7 = document.getElementById("<%= DropDownList7.ClientID %>");
            DropDown7.options[0].selected = true;

            document.getElementById('Button15').style.display = "initial";

            var count = 0;
            for (i = 0; i < document.forms[0].elements.length; i++) {
                if ((document.forms[0].elements[i].type == 'checkbox') &&
                    (document.forms[0].elements[i].name.indexOf('SelectRow3') > -1)) {
                    if (document.forms[0].elements[i].checked == true) {

                        count++;
                        if (count > 1) {

                            document.getElementById('TextBox9').value = null;
                            document.getElementById('TextBox13').value = null;
                            document.getElementById('TextBox10').value = null;
                            document.getElementById('TextBox11').value = null;
                            document.getElementById('TextBox12').value = null;
                            document.getElementById('TextBox14').value = null;
                            document.getElementById('TextBox15').value = null;
                            document.getElementById('TextBox16').value = null;
                            document.getElementById('TextBox17').value = null;
                            document.getElementById('TextBox18').value = null;
                            document.getElementById('TextBox19').value = null;
                            var DropDown8 = document.getElementById("<%= DropDownList8.ClientID %>");
                            DropDown8.options[0].selected = true;
                            var DropDown7 = document.getElementById("<%= DropDownList7.ClientID %>");
                            DropDown7.options[0].selected = true;
                            document.forms[0].elements[i].checked = false;

                            var objGridview = chckbx3.parentNode.parentNode.parentNode;
                            var list = objGridview.getElementsByTagName("input");

                            for (var i = 0; i < list.length; i++) {
                                var objRow = list[i].parentNode.parentNode;
                                if (list[i].type == "checkbox" && chckbx3 != list[i]) {
                                    if (chckbx3.checked) {
                                        list[i].checked = false;
                                    }
                                }
                            }
                        }
                        else {

                            document.getElementById('TextBox9').style.display = 'none';
                            document.getElementById('TextBox13').style.display = 'none';
                            document.getElementById('Label1').style.display = 'none';
                            document.getElementById('Label2').style.display = 'none';
                            document.getElementById('Button15').style.display = "none";
                            var row = chckbx3.parentElement.parentElement.rowIndex;

                            //var Inicio = (document.getElementById("GridView3").rows[row].cells[2].innerHTML).split(" ");
                            //var Vencimiento = (document.getElementById("GridView3").rows[row].cells[3].innerHTML).split(" ");

                            var Importe_mensual = parseFloat(document.getElementById("GridView3").rows[row].cells[4].innerHTML.replace(',', '.'));
                            var Impuesto_municipal = parseFloat(document.getElementById("GridView3").rows[row].cells[5].innerHTML.replace(',', '.'));
                            var Observacion = document.getElementById("GridView3").rows[row].cells[6].innerHTML;
                            var Coeficiente = parseFloat(document.getElementById("GridView3").rows[row].cells[7].innerHTML.replace(',', '.'));
                            var Direccion = document.getElementById("GridView3").rows[row].cells[10].innerHTML;
                            var Localidad = document.getElementById("GridView3").rows[row].cells[11].innerHTML;
                            var Provincia = document.getElementById("GridView3").rows[row].cells[12].innerHTML;
                            var Honorarios = parseFloat(document.getElementById("GridView3").rows[row].cells[13].innerHTML.replace(',', '.'));
                            var Deposito = parseFloat(document.getElementById("GridView3").rows[row].cells[14].innerHTML.replace(',', '.'));
                            var Inquilino = document.getElementById("GridView3").rows[row].cells[9].innerHTML;
                            var Propiedad = document.getElementById("GridView3").rows[row].cells[10].innerHTML;

                            //var fecha1 = new Date(Inicio[0]).toISOString().split("T");
                            //var fecha2 = new Date(Vencimiento[0]).toISOString().split("T");

                            //document.getElementById('TextBox9').value = fecha1[0];
                            //document.getElementById('TextBox13').value = fecha2[0];

                            document.getElementById('TextBox10').value = Importe_mensual;
                            document.getElementById('TextBox11').value = Impuesto_municipal;
                            document.getElementById('TextBox12').value = Observacion;
                            document.getElementById('TextBox14').value = Coeficiente;
                            document.getElementById('TextBox15').value = Direccion;
                            document.getElementById('TextBox16').value = Localidad;
                            document.getElementById('TextBox17').value = Provincia;
                            document.getElementById('TextBox18').value = Honorarios;
                            document.getElementById('TextBox19').value = Deposito;

                        }
                    }

                    else {

                    }
                }
            }

            if (count > 1) {
                return false;
            }
            else {
                return true;
            }

        }

        function CheckGridList4(chckbx4) {
            document.getElementById('TextBox29').value = null;
            document.getElementById('TextBox30').value = null;
            var DropDown4 = document.getElementById("<%= DropDownList4.ClientID %>");
            DropDown4.options[0].selected = true;

            document.getElementById('Button14').style.display = "initial";

            var count = 0;
            for (i = 0; i < document.forms[0].elements.length; i++) {
                if ((document.forms[0].elements[i].type == 'checkbox') &&
                    (document.forms[0].elements[i].name.indexOf('SelectRow4') > -1)) {
                    if (document.forms[0].elements[i].checked == true) {

                        count++;
                        if (count > 1) {

                            document.getElementById('TextBox29').value = null;
                            document.getElementById('TextBox30').value = null;
                            var DropDown4 = document.getElementById("<%= DropDownList4.ClientID %>");
                            DropDown4.options[0].selected = true;
                            document.forms[0].elements[i].checked = false;

                            var objGridview = chckbx4.parentNode.parentNode.parentNode;
                            var list = objGridview.getElementsByTagName("input");

                            for (var i = 0; i < list.length; i++) {
                                var objRow = list[i].parentNode.parentNode;
                                if (list[i].type == "checkbox" && chckbx4 != list[i]) {
                                    if (chckbx4.checked) {
                                        list[i].checked = false;
                                    }
                                }
                            }
                        }
                        else {

                            document.getElementById('Button14').style.display = "none";
                            var row = chckbx4.parentElement.parentElement.rowIndex;

                            var Usuario = document.getElementById("GridView4").rows[row].cells[2].innerHTML;
                            var Pass = document.getElementById("GridView4").rows[row].cells[3].innerHTML;

                            document.getElementById('TextBox29').value = Usuario;
                            document.getElementById('TextBox30').value = Pass;

                        }
                    }

                    else {

                    }
                }
            }

            if (count > 1) {
                return false;
            }
            else {
                return true;
            }

        }

        function showPanel1() {
            document.getElementById('closepanel').style.display = "table";
            document.getElementById('Panel0').style.display = "none";
            document.getElementById('Panel1').style.display = "block";
            document.getElementById('Panel2').style.display = "none";
            document.getElementById('Panel3').style.display = "none";
            document.getElementById('Panel6').style.display = "none";
            document.getElementById('Panel4').style.display = "none";
        }

        function showPanel2() {
            document.getElementById("Button13").click();
            document.getElementById('closepanel').style.display = "table";
            document.getElementById('Panel6').style.display = "none";
            document.getElementById('Panel4').style.display = "none";
            document.getElementById('Panel3').style.display = "none";
            document.getElementById('Panel2').style.display = "block";
            document.getElementById('Panel1').style.display = "none";
            document.getElementById('Panel0').style.display = "none";            
        }

        function showPanel3() {
            document.getElementById('closepanel').style.display = "table";
            document.getElementById('Panel6').style.display = "none";
            document.getElementById('Panel4').style.display = "none";
            document.getElementById('Panel3').style.display = "block";
            document.getElementById('Panel2').style.display = "none";
            document.getElementById('Panel1').style.display = "none";
            document.getElementById('Panel0').style.display = "none";
        }

        function showPanel4() {
            document.getElementById('closepanel').style.display = "table";
            document.getElementById('Panel4').style.display = "block";
            document.getElementById('Panel6').style.display = "none";
            document.getElementById('Panel3').style.display = "none";
            document.getElementById('Panel2').style.display = "none";
            document.getElementById('Panel1').style.display = "none";
            document.getElementById('Panel0').style.display = "none";
        }

        function showPanel6() {
            document.getElementById('closepanel').style.display = "table";
            document.getElementById('Panel6').style.display = "block";
            document.getElementById('Panel4').style.display = "none";
            document.getElementById('Panel3').style.display = "none";
            document.getElementById('Panel2').style.display = "none";
            document.getElementById('Panel1').style.display = "none";
            document.getElementById('Panel0').style.display = "none";
        }

        function hideallPanels() {
            document.getElementById('closepanel').style.display = "none";
            document.getElementById('Panel0').style.display = "block";
            document.getElementById('Panel1').style.display = "none";
            document.getElementById('Panel2').style.display = "none";
            document.getElementById('Panel3').style.display = "none";
            document.getElementById('Panel4').style.display = "none";
            document.getElementById('Panel6').style.display = "none";
        }

        function ClearTextBox20() {
            document.getElementById('TextBox20').value = "";
        }

        function ClearTextBox24() {
            document.getElementById('TextBox24').value = "";
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="parent" class="parent">
            <div class="contenedor_panel">

                <%-- MENU --%>

                <div id="menu" class="menu">
                    <div id="closemenu" class="closemenu"><a>X</a></div>
                    <div id="menu_titulo" class="menu_titulo"><a>CAMILETTI PROPIEDADES</a></div>
                    <div id="menu_subtitulo" class="menu_subtitulo"><a>Mills Gestión Inmobiliaria</a></div>
                    <div id="botonera" class="botonera">
                        <asp:Button ID="Button1" runat="server" Text="ABM PERSONAS" CssClass="boton_menu" OnClientClick="showPanel1(); return false" />
                        <asp:Button ID="Button2" runat="server" Text="ABM PROPIEDADES" CssClass="boton_menu" OnClientClick="showPanel2(); return false" />
                        <asp:Button ID="Button3" runat="server" Text="CONTRATOS" CssClass="boton_menu" OnClientClick="showPanel3(); return false" />
                        <asp:Button ID="Button4" runat="server" Text="COBRANZAS" CssClass="boton_menu" OnClientClick="showPanel4(); return false" />
                        <asp:Button ID="Button5" runat="server" Text="USUARIOS" CssClass="boton_menu" OnClientClick="showPanel6(); return false" />
                    </div>
                    <asp:Button ID="Button6" runat="server" Text="CERRAR SESION" CssClass="cerrar_sesion" OnClick="Button6_Click" />
                </div>

                <div id="sandwich" class="sandwich"><a>☰</a></div>

                <%-- DATOS DE ACCESO --%>

                <asp:TextBox ID="TextBox1" runat="server" CssClass="hola" ReadOnly="true"></asp:TextBox>

                <div id="closepanel" class="closepanel" onclick="hideallPanels()"><a>X</a></div>

                <%-- PANEL 0 --%>

                <asp:Panel ID="Panel0" runat="server" class="aspnetpanel">

                    <div id="panel0" class="panel">
                        <div class="panel_titulo"><a>GESTIÓN INMOBILIARIA</a></div>

                        <div class="logo_panel0"><img src="Images/logo_big.png"/></div>
                    </div>

                </asp:Panel>

                <%-- PANEL ABM PERSONAS --%>

                <asp:Panel ID="Panel1" runat="server" class="aspnetpanel">

                    <div id="abm_pers" class="panel">

                        <div class="panel_titulo"><a>ABM PERSONAS</a></div>

                        <div id="contenedor_campos" class="contenedor_campos">

                            <asp:TextBox ID="TextBox2" runat="server" CssClass="campo" Placeholder="Nombre"></asp:TextBox>
                            <asp:TextBox ID="TextBox3" runat="server" CssClass="campo" Placeholder="Documento"></asp:TextBox>
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="campo">
                                <asp:ListItem Text="IVA" Value="0" />
                                <asp:ListItem Text="Consumidor Final" Value="1" />
                                <asp:ListItem Text="Exento Fiscal" Value="2" />
                                <asp:ListItem Text="Responsable Monotributo" Value="3" />
                                <asp:ListItem Text="Responsable Inscripto" Value="4" />
                            </asp:DropDownList>
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="campo" Placeholder="Telefono"></asp:TextBox>
                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="campo">
                                <asp:ListItem Text="Tipo" Value="0" />
                                <asp:ListItem Text="Inquilino" Value="1" />
                                <asp:ListItem Text="Propietario" Value="2" />
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="campo">
                                <asp:ListItem Text="Estado" Value="0" />
                                <asp:ListItem Text="Activo" Value="1" />
                                <asp:ListItem Text="Inactivo" Value="2" />
                            </asp:DropDownList>
                            <asp:Button ID="Button7" runat="server" Text="INGRESAR" CssClass="boton_ingresar" OnClick="Button7_Click" />

                        </div>

                        <div class="contenedor_acciones">
                            <asp:Button ID="Button9" runat="server" Text="ELIMINAR" CssClass="boton_borrar" OnClick="Button9_Click" />
                            <asp:Button ID="Button8" runat="server" Text="EDITAR" CssClass="boton_editar" OnClick="Button8_Click" />
                        </div>

                        <div id="contenedor_gridview" class="contenedor_gridview">

                            <asp:SqlDataSource ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:InmCamiletti %>" ProviderName="<%$ ConnectionStrings:InmCamiletti.ProviderName %>" SelectCommand="SELECT * FROM [Personas] ORDER BY NOMBRE ASC" runat="server"></asp:SqlDataSource>
                            <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" Visible="true" CssClass="gridview1" AutoGenerateColumns="false" HeaderStyle-CssClass="gridview_header" BorderColor="White">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="SelectRow" runat="server" AutoPostBack="false" OnClick="CheckGridList(this);" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField ReadOnly="true" DataField="Id" HeaderText="ID" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="false" DataField="NOMBRE" HeaderText="NOMBRE" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="false" DataField="DOCUMENTO" HeaderText="DOCUMENTO" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="true" DataField="IVA" HeaderText="IVA" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="false" DataField="TELEFONO" HeaderText="TELEFONO" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="true" DataField="TIPO" HeaderText="TIPO" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="true" DataField="ESTADO" HeaderText="ESTADO" Visible="True" ItemStyle-CssClass="grid_row">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>

                    </div>

                </asp:Panel>

                <%-- PANEL ABM PROPIEDADES --%>

                <asp:Panel ID="Panel2" runat="server" class="aspnetpanel">

                    <div id="abm_prop" class="panel">

                        <div class="panel_titulo"><a>ABM PROPIEDADES</a></div>

                        <div id="contenedor_campos2" class="contenedor_campos">

                            <asp:TextBox ID="TextBox5" runat="server" CssClass="campo" Placeholder="Dirección"></asp:TextBox>
                            <asp:TextBox ID="TextBox6" runat="server" CssClass="campo" Placeholder="Localidad"></asp:TextBox>
                            <asp:TextBox ID="TextBox7" runat="server" CssClass="campo" Placeholder="Provincia"></asp:TextBox>
                            <asp:TextBox ID="TextBox8" runat="server" CssClass="campo" Placeholder="Foto"></asp:TextBox>
                            <asp:DropDownList ID="DropDownList5" runat="server" CssClass="campo">
                                <asp:ListItem Text="Estado" Value="0" />
                                <asp:ListItem Text="Activo" Value="1" />
                                <asp:ListItem Text="Inactivo" Value="2" />
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownList6" runat="server" CssClass="campo"></asp:DropDownList>
                            <asp:Button ID="Button13" runat="server" Text="↺" CssClass="reload" OnClick="Button13_Click" Style="display: none;" />
                            <asp:Button ID="Button10" runat="server" Text="INGRESAR" CssClass="boton_ingresar" OnClick="Button10_Click" />

                        </div>

                        <div class="contenedor_acciones">
                            <asp:Button ID="Button11" runat="server" Text="ELIMINAR" CssClass="boton_borrar" OnClick="Button11_Click" />
                            <asp:Button ID="Button12" runat="server" Text="EDITAR" CssClass="boton_editar" OnClick="Button12_Click" />
                        </div>

                        <div id="contenedor_gridview2" class="contenedor_gridview">

                            <asp:SqlDataSource ID="SqlDataSource2" ConnectionString="<%$ ConnectionStrings:InmCamiletti %>" ProviderName="<%$ ConnectionStrings:InmCamiletti.ProviderName %>" SelectCommand="SELECT * FROM [Propiedades] ORDER BY DIRECCION ASC" runat="server"></asp:SqlDataSource>
                            <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource2" Visible="true" CssClass="gridview1" AutoGenerateColumns="false" HeaderStyle-CssClass="gridview_header" BorderColor="White">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="SelectRow2" runat="server" AutoPostBack="false" OnClick="CheckGridList2(this);" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField ReadOnly="true" DataField="Id" HeaderText="ID" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="false" DataField="DIRECCION" HeaderText="DIRECCION" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="false" DataField="LOCALIDAD" HeaderText="LOCALIDAD" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="true" DataField="PROVINCIA" HeaderText="PROVINCIA" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="false" DataField="ESTADO" HeaderText="ESTADO" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="true" DataField="FOTO" HeaderText="FOTO" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="true" DataField="PROPIETARIO" HeaderText="PROPIETARIO" Visible="True" ItemStyle-CssClass="grid_row">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>

                    </div>

                </asp:Panel>

                <%-- PANEL CONTRATOS --%>

                <asp:Panel ID="Panel3" runat="server" class="aspnetpanel">

                    <div id="contratos" class="panel">

                        <div class="panel_titulo"><a>CONTRATOS</a></div>

                        <asp:Label ID="Label3" runat="server" CssClass="label_alerta" Text=""></asp:Label>

                        <div id="contenedor_campos3" class="contenedor_campos2">

                            <asp:Label ID="Label1" runat="server" CssClass="label" Text="Inicio"></asp:Label>
                            <asp:TextBox ID="TextBox9" runat="server" CssClass="campo_fecha" TextMode="Date"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" CssClass="label" Text="Vencimiento"></asp:Label>
                            <asp:TextBox ID="TextBox13" runat="server" CssClass="campo_fecha" TextMode="Date"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="TextBox10" runat="server" CssClass="campo" Placeholder="Importe mensual ($)" TextMode="Number"></asp:TextBox>
                            <asp:TextBox ID="TextBox11" runat="server" CssClass="campo" Placeholder="Impuesto municipal ($)" TextMode="Number"></asp:TextBox>
                            <asp:TextBox ID="TextBox12" runat="server" CssClass="campo" Placeholder="Observación"></asp:TextBox>
                            <asp:TextBox ID="TextBox14" runat="server" CssClass="campo" Placeholder="Coeficiente (#,##)"></asp:TextBox>
                            <asp:DropDownList ID="DropDownList8" runat="server" CssClass="campo"></asp:DropDownList>
                            <asp:DropDownList ID="DropDownList7" runat="server" CssClass="campo" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:TextBox ID="TextBox15" runat="server" CssClass="campo" Placeholder="Dirección" ReadOnly="true"></asp:TextBox>
                            <asp:TextBox ID="TextBox16" runat="server" CssClass="campo" Placeholder="Localidad" ReadOnly="true"></asp:TextBox>
                            <asp:TextBox ID="TextBox17" runat="server" CssClass="campo" Placeholder="Provincia" ReadOnly="true"></asp:TextBox>
                            <asp:TextBox ID="TextBox18" runat="server" CssClass="campo" Placeholder="Honorarios ($)" TextMode="Number"></asp:TextBox>
                            <asp:TextBox ID="TextBox19" runat="server" CssClass="campo" Placeholder="Deposito ($)" TextMode="Number"></asp:TextBox>
                            <asp:Button ID="Button15" runat="server" Text="DAR ALTA" CssClass="boton_ingresar2" OnClick="Button15_Click" />

                        </div>

                        <asp:TextBox ID="TextBox20" runat="server" CssClass="buscar" Placeholder="Buscar..." AutoPostBack="true" onclick="ClearTextBox20();" OnTextChanged="TextBox20_TextChanged"></asp:TextBox>

                        <div class="contenedor_acciones2">
                            <asp:Button ID="Button16" runat="server" Text="ELIMINAR" CssClass="boton_borrar" OnClick="Button16_Click" />
                            <asp:Button ID="Button17" runat="server" Text="EDITAR" CssClass="boton_editar" OnClick="Button17_Click" />
                        </div>

                        <div id="contenedor_gridview3" class="contenedor_gridview2">

                            <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:InmCamiletti %>" ProviderName="<%$ ConnectionStrings:InmCamiletti.ProviderName %>" SelectCommand="SELECT * FROM [Contratos] ORDER BY DIRECCION ASC" runat="server"></asp:SqlDataSource>
                            <asp:GridView ID="GridView3" runat="server" DataSourceID="SqlDataSource3" Visible="true" CssClass="gridview1" AutoGenerateColumns="false" HeaderStyle-CssClass="gridview_header" BorderColor="White">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="SelectRow3" runat="server" AutoPostBack="false" OnClick="CheckGridList3(this);" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField ReadOnly="true" DataField="Id" HeaderText="ID" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="false" DataField="INICIO" HeaderText="INICIO" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="false" DataField="VENCIMIENTO" HeaderText="VENCIMIENTO" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="true" DataField="IMPORTE_MENSUAL" HeaderText="MENSUAL" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="false" DataField="IMPORTE_IMPUESTOM" HeaderText="MUNICIPAL" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="true" DataField="OBSERVACION" HeaderText="OBSERVACION" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="true" DataField="COEFICIENTE" HeaderText="COEFICIENTE" Visible="True" ItemStyle-CssClass="grid_row">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="true" DataField="PROPIETARIO" HeaderText="PROPIETARIO" Visible="True" ItemStyle-CssClass="grid_row">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="true" DataField="INQUILINO" HeaderText="INQUILINO" Visible="True" ItemStyle-CssClass="grid_row">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="true" DataField="DIRECCION" HeaderText="DIRECCION" Visible="True" ItemStyle-CssClass="grid_row">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="true" DataField="LOCALIDAD" HeaderText="LOCALIDAD" Visible="True" ItemStyle-CssClass="grid_row">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="true" DataField="PROVINCIA" HeaderText="PROVINCIA" Visible="True" ItemStyle-CssClass="grid_row">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="true" DataField="HONORARIOS" HeaderText="HONORARIOS" Visible="True" ItemStyle-CssClass="grid_row">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="true" DataField="DEPOSITO" HeaderText="DEPOSITO" Visible="True" ItemStyle-CssClass="grid_row">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource4" ConnectionString="<%$ ConnectionStrings:InmCamiletti %>" ProviderName="<%$ ConnectionStrings:InmCamiletti.ProviderName %>" SelectCommand="SELECT TOP 100 * FROM [Detalle_Contratos]" runat="server"></asp:SqlDataSource>

                        </div>

                    </div>

                </asp:Panel>

                <%-- PANEL COBRANZAS --%>

                <asp:Panel ID="Panel4" runat="server" class="aspnetpanel">

                    <div id="cobranzas" class="panel">

                        <div class="panel_titulo"><a>COBRANZAS</a></div>

                        <asp:TextBox ID="TextBox24" runat="server" CssClass="buscar2" Placeholder="Buscar inquilino (nombre o documento)..." AutoPostBack="true" onclick="ClearTextBox24();" OnTextChanged="TextBox24_TextChanged"></asp:TextBox>
                        <asp:SqlDataSource ID="SqlDataSource7" ConnectionString="<%$ ConnectionStrings:InmCamiletti %>" ProviderName="<%$ ConnectionStrings:InmCamiletti.ProviderName %>" SelectCommand="SELECT TOP 0 * FROM [Personas] WHERE TIPO = 'INQUILINO' ORDER BY Id ASC" runat="server"></asp:SqlDataSource>
                        <asp:GridView ID="GridView6" runat="server" DataSourceID="SqlDataSource7" Visible="false" AutoGenerateColumns="true"></asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource8" ConnectionString="<%$ ConnectionStrings:InmCamiletti %>" ProviderName="<%$ ConnectionStrings:InmCamiletti.ProviderName %>" SelectCommand="SELECT TOP 0 * FROM [Detalle_Contratos]" runat="server"></asp:SqlDataSource>
                        <asp:GridView ID="GridView7" runat="server" DataSourceID="SqlDataSource8" Visible="false" AutoGenerateColumns="true"></asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource9" ConnectionString="<%$ ConnectionStrings:InmCamiletti %>" ProviderName="<%$ ConnectionStrings:InmCamiletti.ProviderName %>" SelectCommand="SELECT TOP 0 * FROM [Detalle_Cobranzas]" runat="server"></asp:SqlDataSource>
                        <asp:GridView ID="GridView8" runat="server" DataSourceID="SqlDataSource9" Visible="false" AutoGenerateColumns="true"></asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource10" ConnectionString="<%$ ConnectionStrings:InmCamiletti %>" ProviderName="<%$ ConnectionStrings:InmCamiletti.ProviderName %>" SelectCommand="SELECT TOP 0 * FROM [Cobranzas]" runat="server"></asp:SqlDataSource>
                        <asp:GridView ID="GridView9" runat="server" DataSourceID="SqlDataSource10" Visible="false" AutoGenerateColumns="true"></asp:GridView>

                        <div id="contenedor_campos5" class="contenedor_campos4">

                            <asp:TextBox ID="TextBox21" runat="server" CssClass="campo" Placeholder="Inquilino" ReadOnly="true"></asp:TextBox>
                            <asp:DropDownList ID="DropDownList9" runat="server" CssClass="campo" OnSelectedIndexChanged="DropDownList9_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="Concepto" Value="0" />
                                <asp:ListItem Text="Alquiler" Value="1" />
                                <asp:ListItem Text="Otros" Value="2" />
                            </asp:DropDownList>
                            <asp:TextBox ID="TextBox22" runat="server" CssClass="campo" Placeholder="Concepto" AutoPostBack="false" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                            <asp:TextBox ID="TextBox25" runat="server" CssClass="campo" Placeholder="Mes" Visible="false" AutoPostBack="false" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                            <asp:TextBox ID="TextBox26" runat="server" CssClass="campo" Placeholder="Año" Visible="false" AutoPostBack="true" OnTextChanged="TextBox26_TextChanged"></asp:TextBox>
                            <asp:TextBox ID="TextBox23" runat="server" CssClass="campo" Placeholder="Importe" ReadOnly="true" AutoPostBack="false" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                            <asp:Button ID="Button20" runat="server" Text="INGRESAR" CssClass="boton_ingresar2" OnClick="Button20_Click" />
                            <asp:Label ID="Label8" runat="server" CssClass="label_alerta2" Text=""></asp:Label>

                        </div>

                        <asp:Button ID="Button21" runat="server" Text="REINICIAR" CssClass="boton_reiniciar" OnClick="Button21_Click" />
                        <asp:Button ID="Button22" runat="server" Text="FINALIZAR" CssClass="boton_finalizar" OnClick="Button22_Click" />
                        <asp:TextBox ID="TextBox27" runat="server" CssClass="total" Placeholder="$0,00" ReadOnly="true"></asp:TextBox>

                        <div id="contenedor_gridview5" class="contenedor_gridview3">

                            <asp:SqlDataSource ID="SqlDataSource6" ConnectionString="<%$ ConnectionStrings:InmCamiletti %>" ProviderName="<%$ ConnectionStrings:InmCamiletti.ProviderName %>" SelectCommand="SELECT TOP 0 * FROM [Detalle_Cobranzas] ORDER BY Id ASC" runat="server"></asp:SqlDataSource>
                            <asp:GridView ID="GridView5" runat="server" DataSourceID="SqlDataSource6" Visible="true" CssClass="gridview1" AutoGenerateColumns="false" HeaderStyle-CssClass="gridview_header" BorderColor="Black">
                                <Columns>
                                    <asp:BoundField ReadOnly="true" DataField="Id" HeaderText="ID" Visible="False" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="false" DataField="CONCEPTO" HeaderText="CONCEPTO" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="false" DataField="IMPORTE" HeaderText="IMPORTE" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="true" DataField="CLIENTE" HeaderText="CLIENTE" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>

                        </div>

                    </div>

                </asp:Panel>

                <%-- PANEL USUARIOS --%>

                <asp:Panel ID="Panel6" runat="server" class="aspnetpanel">

                    <div id="usuarios" class="panel">

                        <div class="panel_titulo"><a>USUARIOS</a></div>

                        <asp:Label ID="Label5" runat="server" CssClass="label_alerta" Text=""></asp:Label>

                        <asp:Label ID="Label4" runat="server" CssClass="label_alerta" Text=""></asp:Label>

                        <div id="contenedor_campos4" class="contenedor_campos2">

                            <asp:TextBox ID="TextBox29" runat="server" CssClass="campo" Placeholder="Usuario" ReadOnly="false"></asp:TextBox>
                            <asp:TextBox ID="TextBox30" runat="server" CssClass="campo" Placeholder="Contraseña" ReadOnly="false"></asp:TextBox>
                            <asp:DropDownList ID="DropDownList4" runat="server" CssClass="campo">
                                <asp:ListItem Text="Nivel" Value="0" />
                                <asp:ListItem Text="1" Value="1" />
                                <asp:ListItem Text="2" Value="2" />
                            </asp:DropDownList>
                            <asp:Button ID="Button14" runat="server" Text="DAR ALTA" CssClass="boton_ingresar2" OnClick="Button14_Click" />

                        </div>

                        <div class="contenedor_acciones2">
                            <asp:Button ID="Button18" runat="server" Text="ELIMINAR" CssClass="boton_borrar" OnClick="Button18_Click" />
                        </div>

                        <div id="contenedor_gridview4" class="contenedor_gridview2">

                            <asp:SqlDataSource ID="SqlDataSource5" ConnectionString="<%$ ConnectionStrings:InmCamiletti %>" ProviderName="<%$ ConnectionStrings:InmCamiletti.ProviderName %>" SelectCommand="SELECT * FROM [Usuarios] ORDER BY Usuario ASC" runat="server"></asp:SqlDataSource>
                            <asp:GridView ID="GridView4" runat="server" DataSourceID="SqlDataSource5" Visible="true" CssClass="gridview1" AutoGenerateColumns="false" HeaderStyle-CssClass="gridview_header" BorderColor="White">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="SelectRow4" runat="server" AutoPostBack="false" OnClick="CheckGridList4(this);" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField ReadOnly="true" DataField="Id" HeaderText="ID" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="false" DataField="Usuario" HeaderText="USUARIO" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="false" DataField="Pass" HeaderText="CONTRASEÑA" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ReadOnly="true" DataField="Nivel" HeaderText="NIVEL" Visible="True" ItemStyle-CssClass="grid_row" HeaderStyle-CssClass="gridview_header">
                                        <ItemStyle CssClass="col" Wrap="false"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>

                        </div>

                    </div>

                </asp:Panel>

            </div>
        </div>
    </form>
</body>
</html>
