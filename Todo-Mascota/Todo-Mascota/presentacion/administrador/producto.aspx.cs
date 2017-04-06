using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Todo_Mascota.Models.menu_parametro.IRepositorios;
using Todo_Mascota.Models.menu_parametro.Repositorios;

namespace Todo_Mascota.presentacion.administrador
{
    public partial class producto : System.Web.UI.Page
    {
        static readonly IParametroRepository repository = new ParametroRepository();

        protected void Page_Load(object sender, EventArgs e)
        {

            input_clase.DataSource = repository.obtenerParametro("1");
            input_clase.DataTextField = "NOMDESCRIP";
            input_clase.DataValueField = "IDPARAMETRODESCRIP";
            input_clase.DataBind();
            input_clase.Items.Insert(0, new ListItem("-- Seleccione --", ""));

            //input_tipoproductogen.DataSource = repository.obtenerParametro("");
            //input_tipoproductogen.DataTextField = "DESCRIPCION";
            //input_tipoproductogen.DataValueField = "ID_CONDESC";
            //input_tipoproductogen.DataBind();
            //input_tipoproductogen.Items.Insert(0, new ListItem("-- Seleccione --", ""));

            input_tipomarcaproductogen.DataSource = repository.obtenerParametro("84");
            input_tipomarcaproductogen.DataTextField = "NOMDESCRIP";
            input_tipomarcaproductogen.DataValueField = "IDPARAMETRODESCRIP";
            input_tipomarcaproductogen.DataBind();
            input_tipomarcaproductogen.Items.Insert(0, new ListItem("-- Seleccione --", ""));

            input_tipounidadpesoproductogen.DataSource = repository.obtenerParametro("50");
            input_tipounidadpesoproductogen.DataTextField = "NOMDESCRIP";
            input_tipounidadpesoproductogen.DataValueField = "IDPARAMETRODESCRIP";
            input_tipounidadpesoproductogen.DataBind();
            input_tipounidadpesoproductogen.Items.Insert(0, new ListItem("-- Seleccione --", ""));
        }
    }
}