using Todo_Mascota.Models.menu_material.Clases;
using Todo_Mascota.Models.menu_material.IRepositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using Todo_Mascota.Models.ejecuta;

namespace Todo_Mascota.Models.menu_material.Repositorios
{
   public class MaterialRepository : IMaterialRepository
   {
       private Material material = new Material();
       private string respuesta;
       private DataTable datos = new DataTable();
       private ConexionOracle conexion = new ConexionOracle();


        public  IEnumerable<Material> GetAll(int idproductogen)
       {
           datos = obtenerMaterial(idproductogen.ToString());
          if (datos != null)
          {
              foreach (DataRow row in datos.Rows)
              {
                  yield return new Material
                  {
                      idmaterial = Convert.ToString(row["IDMATERIAL"]),
                      tipomaterial = Convert.ToString(row["TIPOMATERIAL"]),
                      nom_material = Convert.ToString(row["NOM_MATERIAL"]),
                      descrip_material = Convert.ToString(row["DESCRIP_MATERIAL"])
                  };
              }
          }
       }

        public DataTable obtenerMaterial(string idproductogen)
        {
            try
            {
                string sql = @" SELECT T1.IDMATERIAL, T1.TIPOMATERIAL, T3.NOMDESCRIP NOM_MATERIAL, T3.DESCRIPDESCRIP DESCRIP_MATERIAL
                                FROM TM_MATERIAL T1
                                INNER JOIN TM_MATERIAL_PRODUCTO T2
                                ON (T1.IDMATERIAL = T2.IDMATERIAL AND T2.IDPRODUCTOGEN=" + idproductogen + @")
                                INNER JOIN TM_PARAMETRO T3
                                ON T3.IDPARAMETRODESCRIP = T1.TIPOMATERIAL
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


    }
}
