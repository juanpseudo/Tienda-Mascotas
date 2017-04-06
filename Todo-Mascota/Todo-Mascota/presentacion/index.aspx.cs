using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Todo_Mascota.Models.menu_parametro.Clases;
using Todo_Mascota.Models.menu_parametro.IRepositorios;
using Todo_Mascota.Models.menu_parametro.Repositorios;
using System.Data;
using Todo_Mascota.Models.menu_producto.IRepositorios;
using Todo_Mascota.Models.menu_producto.Repositorios;
using Todo_Mascota.Models.menu_producto.Clases;

namespace Todo_Mascota.presentacion
{
    public partial class index : System.Web.UI.Page
    {
        static readonly IParametroRepository repository = new ParametroRepository();
        static readonly IProductoRepository repositoryProducto = new ProductoRepository();

        [WebMethod]
        public static IEnumerable<Parametro> crearMenuLateral(int idpadredescrip)
        {
           return repository.GetAll(idpadredescrip);
        }

        [WebMethod]
        public static IEnumerable<Producto> crearMenuPrincipal(string idCLase)
        {
            return repositoryProducto.GetAllClase(idCLase);
        }

        //    [WebMethod]
        //    public static string crearMenuLateral(string idParametro)
        //    {

        //        string retorno = "";
        //        DataTable dt_datos = new DataTable();

        //        parametros_neg bll = new parametros_neg();
        //        dt_datos = bll.mostrarParametros(idParametro);

        //        if (dt_datos != null)
        //        {

        //            var list = new List<Dictionary<string, object>>();

        //            foreach (DataRow row in dt_datos.Rows)
        //            {
        //                var dict = new Dictionary<string, object>();

        //                foreach (DataColumn col in dt_datos.Columns)
        //                {
        //                    dict[col.ColumnName] = (Convert.ToString(row[col]));
        //                }
        //                list.Add(dict);
        //            }
        //            JavaScriptSerializer serializer = new JavaScriptSerializer();
        //            serializer.MaxJsonLength = Int32.MaxValue;

        //            retorno = serializer.Serialize(list);

        //        }

        //        return retorno;

        //    }

        public StringBuilder crearMenu()
        {
            StringBuilder html = new StringBuilder();
            DataTable dtClases = repository.obtenerClases();
            html.AppendLine("<ul>");
            html.AppendLine("<li><a href = '#'> PRINCIPAL </a></li>");
            //< li >< a href = "#" onclick = "RedireccionaMENU(this, 1);" > Juguetes </ a ></ li >
            if (dtClases != null)
            {
                foreach (DataRow row in dtClases.Rows)
                {
                    html.AppendLine("<li><a href = '#' onclick='crearMenuLateral(&quot;" + row["IDPARAMETRODESCRIP"].ToString() + "&quot;)'> " + row["NOMDESCRIP"].ToString() + " </a>");
                    DataTable dtSubClases = repository.obtenerSubClases(row["IDPARAMETRODESCRIP"].ToString());
                    if (dtSubClases != null)
                    {
                        html.AppendLine("<ul>");
                        foreach (DataRow rowSub in dtSubClases.Rows)
                            
                        {
                            html.AppendLine("<li><a href = '#' onclick='crearMenuLateral(&quot;" + rowSub["IDSUBCLASE"].ToString() + "&quot;)'> " + rowSub["NOMDESCRIP"].ToString() + " </a></li>");
                          

                        }
                        html.AppendLine("</ul></li>");
                    }
                }
            }
            html.AppendLine("<li><a href = '#'> CONTACTOS </a></li>");
            html.Append("</ul>");
            return html;
        }

        //public StringBuilder crearMenuLateral()
        //{
        //    StringBuilder html = new StringBuilder();
        //    html.AppendLine("<div id = 'jqxMenuVertical'>");
        //    html.AppendLine("<ul id = 'menu'>");
        //    html.AppendLine("<li class='ui-widget-header'><div>Category 1</div></li>");
        //    html.AppendLine("<li><div>Option 1</div></li>");
        //    html.AppendLine("<li><div>Option 2</div></li>");
        //    html.AppendLine("<li><div>Option 3</div></li>");
        //    html.AppendLine("<li class='ui-widget-header'><div>Category 2</div></li>");
        //    html.AppendLine("<li><div>Option 4</div></li>");
        //    html.AppendLine("<li><div>Option 5</div></li>");
        //    html.AppendLine("<li><div>Option 6</div></li>");
        //    html.AppendLine("</ul>");
        //    html.AppendLine("</div>");
        //    return html;
        //}


        protected void Page_Load(object sender, EventArgs e)
        {
            jqxMenu.InnerHtml = crearMenu().ToString();
            //  dv_menu_lateral.InnerHtml = crearMenuLateral().ToString();
            //   ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "cargarMenu(); crearMenuLateral();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "cargarMenu();", true);
        }
    }
}