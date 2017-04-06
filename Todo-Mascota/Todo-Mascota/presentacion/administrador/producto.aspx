<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="producto.aspx.cs" Inherits="Todo_Mascota.presentacion.administrador.producto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="div_producto">
        
        <table style="border-collapse: separate; border-spacing: 3px; width:100%; text-align: left;">

            <tr>
                <td style="text-align:left; width: 215px;">Categoria</td>
                <td style="text-align:left; width: 5px;">:</td>
                <td style="text-align:left; width: 220px;">
                    <select id="input_clase" runat="server"></select>
                </td>
                <td style="text-align:left;">
                </td>
                <td style="text-align:left; width: 120px;">Sub-categoria</td>
                <td style="text-align:left; width: 5px;">:</td>
                <td style="text-align:left;">
                    <select id="input_subclase" runat="server"></select>
                </td>  
                <td style="text-align:left;">
                </td>
            </tr>
            <tr>
                <td style="text-align:left; width: 215px;">Nombre</td>
                <td style="text-align:left; width: 5px;">:</td>
                <td style="text-align:left; width: 220px;">
                    <select id="input_tipoproductogen" runat="server"></select>
                </td>
                <td style="text-align:left;">
                </td>
                <td style="text-align:left; width: 120px;">Precio</td>
                <td style="text-align:left; width: 5px;">:</td>
                <td style="text-align:left;">
                    <input  id="input_precioproductogen" type="number" />
                </td>  
                <td style="text-align:left;">
                </td>
            </tr>
            <tr>
                <td style="text-align:left; width: 215px;">Costo</td>
                <td style="text-align:left; width: 5px;">:</td>
                <td style="text-align:left; width: 220px;">
                    <input  id="input_costoproductogen" type="number" />
                </td>
                <td style="text-align:left;">
                </td>
                <td style="text-align:left; width: 120px;">Marca</td>
                <td style="text-align:left; width: 5px;">:</td>
                <td style="text-align:left;">
                    <select id="input_tipomarcaproductogen" runat="server"></select>
                </td>
                <td style="text-align:left;">
                </td>
            </tr>
            <tr>
                <td style="text-align:left; width: 215px;">Modelo</td>
                <td style="text-align:left; width: 5px;">:</td>
                <td style="text-align:left; width: 220px;">
                    <input  id="input_modeloproductogen" type="number" />
                </td>
                <td style="text-align:left;">
                </td>
                <td style="text-align:left; width: 215px;">Peso</td>
                <td style="text-align:left; width: 5px;">:</td>
                <td style="text-align:left; width: 220px;">
                    <input  id="input_cantpesoproductogen" type="number" />
                </td>
                <td style="text-align:left;">
                    <select id="input_tipounidadpesoproductogen" runat="server"></select>
                </td>
            </tr>
            <tr>
                <td style="text-align:left; width: 120px;">Stock del Producto</td>
                <td style="text-align:left; width: 5px;">:</td>
                <td style="text-align:left;">
                    <input  id="input_stockproductogen" type="number" />
                </td>
                <td style="text-align:left;">
                </td>
                <td style="text-align:left; width: 120px;">Material</td>
                <td style="text-align:left; width: 5px;">:</td>
                <td style="text-align:left;">
                    <select id="input_tipomaterial" runat="server"></select>
                </td>
                <td style="text-align:left;">
                </td>
            </tr>
        </table>
        <div style="text-align:right; border-top: 1px solid #ccc; border-bottom: 1px solid #ccc; height:45px;">
            <button type="button" id="btn_GRABARCableado"  class="btn btn-warning" style="margin-top: 5px;">
                <span class="glyphicon glyphicon-floppy-saved" aria-hidden="true"></span> GRABAR
            </button>
        </div>

    </div>
    </div>
    </form>
</body>
</html>
