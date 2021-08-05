<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Panel.aspx.vb" Inherits="SistemaGestionInmobiliaria.Panel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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

        function showPanel1() {
            document.getElementById('Panel1').style.display = "block";            
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
                        <asp:Button ID="Button2" runat="server" Text="ABM PROPIEDADES" CssClass="boton_menu" OnClientClick="return false" />
                        <asp:Button ID="Button3" runat="server" Text="CONTRATOS" CssClass="boton_menu" OnClientClick="return false" />
                        <asp:Button ID="Button4" runat="server" Text="COBRANZAS" CssClass="boton_menu" OnClientClick="return false" />
                        <asp:Button ID="Button5" runat="server" Text="USUARIOS" CssClass="boton_menu" OnClientClick="return false" />
                    </div>
                    <asp:Button ID="Button6" runat="server" Text="CERRAR SESION" CssClass="cerrar_sesion" OnClick="Button6_Click" />
                </div>

                <div id="sandwich" class="sandwich"><a>☰</a></div>

                <%-- DATOS DE ACCESO --%>

                <asp:TextBox ID="TextBox1" runat="server" CssClass="hola" ReadOnly="true"></asp:TextBox>

                <%-- PANEL ABM PERSONAS --%>

                <asp:Panel ID="Panel1" runat="server" class="aspnetpanel">

                    <div id="abm_prop" class="panel">

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

            </div>
        </div>
    </form>
</body>
</html>
