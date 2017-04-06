<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Todo_Mascota.presentacion.index" %>

<%@ Register Src="~/presentacion/usuarios/menu_principal.ascx" TagPrefix="uc1" TagName="menu_principal" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
<link href="../Content/bootstrap.min.css" rel="stylesheet" />
<link href="../Content/generales.css" rel="stylesheet" />
<link href="../Content/JQWidgets/jqx.base.css" rel="stylesheet" />
<%--<link href="../Content/JQWidgets/jqx.energyblue.css" rel="stylesheet" />--%>
<link rel="shortcut icon" href="">
<script src="../Scripts/jquery-1.9.1.min.js"></script>
<script src="../Scripts/bootstrap.min.js"></script>
<link href="../Content/JQWidgets/jqx.energyblue.css" rel="stylesheet" />
<script src="../Scripts/JQWidgets/jqx-all.js"></script>

<%--<script src="../Scripts/JQWidgets/jqxcore.js"></script>

<script src="../Scripts/JQWidgets/jqxmenu.js"></script>
<script src="../Scripts/JQWidgets/jqxwindow.js"></script>
<script src="../Scripts/JQWidgets/jqxnotification.js"></script>--%>

<script src="../Scripts/usuarios/menu_producto_js.js"></script>

<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="correctNotification">
         <div id="contenidoNotif"></div>
    </div>
    <div class="css_div_general_top">
        <img src="../fonts/todomascota-mapadebits.png"  style="width:100px; height:55px;"/>
    </div>
    <div id="jqxMenu"  runat="server">
    </div>
    <div align='center'>
        <uc1:menu_principal runat="server" id="menu_principal" />
     </div>
    </form>
</body>
</html>
