using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using Todo_Mascota.Models.ejecuta;
using Todo_Mascota.Models.menu_parametro.IRepositorios;
using Todo_Mascota.Models.menu_parametro.Clases;

namespace Todo_Mascota.Models.menu_parametro.Repositorios
{
    public class ParametroRepository : IParametroRepository
    {
        private Parametro parametro = new Parametro();
        private string respuesta;
        private DataTable datos = new DataTable();
        private ConexionOracle conexion = new ConexionOracle();

        //public Parametro Add(Parametro item)
        //{
        //   if (item.idpadredescrip == null | item == null)
        //   {
        //       throw new ArgumentNullException("item");
        //   }
        //   respuesta = data.IngresarRegistroParametro(item.idpadredescrip, item.nomdescrip, item.descripdescrip, item.ordendescrip);
        //   if (respuesta == "OK")
        //   {
        //       datos = data.obtenerParametro(item.idpadredescrip);
        //       int LargoDatos = datos.Rows.Count;
        //       DataRow row = datos.Rows[LargoDatos - 1];
        //       item.idparametrodescrip = Convert.ToString(row["IDPARAMETRODESCRIP"]);
        //       return item;
        //   }
        //   else {
        //       item.idpadredescrip = null;
        //       return item;
        //   }

        //public Parametro Get(int idpadredescrip, int idparametrodescrip)
        //{
        //    datos = data.obtenerRegistroParametro(idpadredescrip.ToString(), idparametrodescrip.ToString());
        //   if (datos != null)
        //   {
        //       DataRow row = datos.Rows[0];
        //       parametro.idparametrodescrip = Convert.ToString(row["IDPARAMETRODESCRIP"]);
        //       parametro.idpadredescrip = Convert.ToString(row["IDPADREDESCRIP"]);
        //       parametro.nomdescrip = Convert.ToString(row["NOMDESCRIP"]);
        //       parametro.descripdescrip = Convert.ToString(row["DESCRIPDESCRIP"]);
        //       parametro.resumendescrip = Convert.ToString(row["RESUMENDESCRIP"]);
        //       parametro.ordendescrip = Convert.ToString(row["ORDENDESCRIP"]);
        //       return parametro;
        //   }
        //   return null;
        //}

        public IEnumerable<Parametro> GetAll(int idpadredescrip)
        {
            datos = obtenerParametro(idpadredescrip.ToString());
            if (datos != null)
            {
                foreach (DataRow row in datos.Rows)
                {
                    yield return new Parametro
                    {
                        idparametrodescrip = Convert.ToString(row["IDPARAMETRODESCRIP"]),
                        idpadredescrip = Convert.ToString(row["IDPADREDESCRIP"]),
                        nomdescrip = Convert.ToString(row["NOMDESCRIP"])
                        //descripdescrip = Convert.ToString(row["DESCRIPDESCRIP"]),
                        //resumendescrip = Convert.ToString(row["RESUMENDESCRIP"]),
                        //ordendescrip = Convert.ToString(row["ORDENDESCRIP"])
                    };
                }
            }
        }

        public DataTable obtenerParametro(string idpadredescrip)
        {
            try
            {
                string sql = @" SELECT T1.IDPARAMETRODESCRIP,T1.IDPADREDESCRIP, T1.NOMDESCRIP, T1.DESCRIPDESCRIP
                                FROM TM_PARAMETRO T1
                                WHERE T1.IDPADREDESCRIP=" + idpadredescrip + @"
                                ORDER BY T1.ORDENDESCRIP ASC";

                DataTable tabla = conexion.EjecutaQuery_DT(sql);

                if ((tabla != null) & (tabla.Rows.Count > 0))
                {
                    return tabla;
                }
                else { return null; }

            }
            catch { return null; }
        }

        public DataTable obtenerClases()
        {
            try
            {
                string sql = @" SELECT  DISTINCT (T6.NOMDESCRIP), T6.IDPARAMETRODESCRIP, T6.ORDENDESCRIP
                                FROM (
                                      SELECT T3.IDPADREDESCRIP IDCLASE
                                      FROM (SELECT DISTINCT (T2.IDPADREDESCRIP) IDSUBCLASE
                                            FROM TM_PRODUCTO_GENERAL T1
                                            INNER JOIN TM_PARAMETRO T2
                                            ON T2.IDPARAMETRODESCRIP= T1.TIPOPRODUCTOGEN) T4
                                      INNER JOIN TM_PARAMETRO T3
                                      ON T4.IDSUBCLASE= T3.IDPARAMETRODESCRIP
                                      ) T5
                                INNER JOIN TM_PARAMETRO T6
                                ON T6.IDPARAMETRODESCRIP=T5.IDCLASE
                                ORDER BY T6.ORDENDESCRIP ASC";

                DataTable tabla = conexion.EjecutaQuery_DT(sql);

                if ((tabla != null) & (tabla.Rows.Count > 0))
                {
                    return tabla;
                }
                else { return null; }

            }
            catch { return null; }
        }

        public DataTable obtenerSubClases(string idpadredescrip)
        {
            try
            {
                string sql = @" SELECT  DISTINCT (T3.IDPARAMETRODESCRIP) IDSUBCLASE, T3.IDPADREDESCRIP IDCLASE, T3.NOMDESCRIP, T3.ORDENDESCRIP
                                FROM (SELECT DISTINCT (T2.IDPADREDESCRIP) IDSUBCLASE
                                      FROM TM_PRODUCTO_GENERAL T1
                                      INNER JOIN TM_PARAMETRO T2
                                      ON T2.IDPARAMETRODESCRIP= T1.TIPOPRODUCTOGEN) T4
                                INNER JOIN TM_PARAMETRO T3
                                ON T4.IDSUBCLASE= T3.IDPARAMETRODESCRIP AND T3.IDPADREDESCRIP=" + idpadredescrip +@"
                                ORDER BY T3.ORDENDESCRIP ASC";

                DataTable tabla = conexion.EjecutaQuery_DT(sql);

                if ((tabla != null) & (tabla.Rows.Count > 0))
                {
                    return tabla;
                }
                else { return null; }

            }
            catch { return null; }
        }





        //public void Remove(int idpadredescrip, int idparametrodescrip)
        //{
        //   data.EliminarRegistroParametro(idpadredescrip.ToString(), idparametrodescrip.ToString());
        //}

        //public bool Update(Parametro item)
        //{
        //   if (item.idpadredescrip == null | item == null)
        //   {
        //       throw new ArgumentNullException("item");
        //   }
        //   respuesta = data.ActualizarRegistroParametro(item.idpadredescrip, item.idparametrodescrip, item.nomdescrip, item.descripdescrip, item.ordendescrip);
        //   if (respuesta == "OK")
        //   {
        //       return true;
        //   }
        //   else { return false; }
        //}

    }
}
