using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace Todo_Mascota.Models.ejecuta
{
    public class Conexion
    {
        protected string tipo_conexion;
        protected string cadena_conexion;
        protected int timeout;

        public Conexion()
        {
            tipo_conexion = System.Configuration.ConfigurationManager.ConnectionStrings["TIPO_CONEXION"].ToString();
            timeout = 500;
            cadena_conexion = conector(tipo_conexion);
        }

        protected string conector(string tipo)
        {
            if (tipo == "oracle")
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["ConOracle"].ToString();
            }
            if (tipo == "sqlserver")
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["ConSqlServer"].ToString();
            }
            else
            {
                return "";
            }
        }

        protected string EjecutaQuery(string consulta)
        {
            if (tipo_conexion == "oracle")
            {
                ConexionOracle oracle = new ConexionOracle();
                return oracle.EjecutaQuery(consulta);
            }
            else
            {
                return null;
            }
        }

        protected string EjecutaQuery_Execute(string idsubclase , string precioproducto , string costoproducto, string idcolor , string largotamano, string anchotamano , string altotamano , string nombretamano, string idmaterial, string idmascotas , string unidadpesosproducto , string cantpesoproducto )
        {
            if (tipo_conexion == "oracle")
            {
                ConexionOracle oracle = new ConexionOracle();
                return oracle.EjecutaQuery_Execute( idsubclase,  precioproducto,  costoproducto,  idcolor,  largotamano,  anchotamano,  altotamano,  nombretamano,  idmaterial,  idmascotas,  unidadpesosproducto,  cantpesoproducto);
            }
            else
            {
                return null;
            }
        }

        protected DataTable EjecutaQuery_DT(string consulta)
        {
            if (tipo_conexion == "oracle")
            {
                ConexionOracle oracle = new ConexionOracle();
                return oracle.EjecutaQuery_DT(consulta);
            }
            else
            {
                return null;
            }
        }
        /*
        //protected List<List<String>> GetTagList(string consulta)
        protected List<Tuple<string, string>> GetTagList(string consulta)
        {
            if (tipo_conexion == "oracle")
            {
                ConexionOracle oracle = new ConexionOracle();
                return oracle.GetTagList(consulta);
            }
            else
            {
                return null;
            }
        }
        */
    }
}