using Todo_Mascota.Models.menu_imagen.Clases;
using Todo_Mascota.Models.menu_imagen.IRepositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using Todo_Mascota.Models.ejecuta;

namespace Todo_Mascota.Models.menu_imagen.Repositorios
{
   public class ImagenRepository : IImagenRepository
   {
       private Imagen imagen = new Imagen();
       private string respuesta;
       private DataTable datos = new DataTable();
       private ConexionOracle conexion = new ConexionOracle();

        public  IEnumerable<Imagen> GetAll(int idproductogen)
       {
           datos = obtenerImagen(idproductogen.ToString());
          if (datos != null)
          {
              foreach (DataRow row in datos.Rows)
              {
                  yield return new Imagen
                  {
                      idimagen = Convert.ToString(row["IDIMAGEN"]),
                      idproductogen = Convert.ToString(row["IDPRODUCTOGEN"]),
                      nomimagen = Convert.ToString(row["NOMIMAGEN"]),
                      urlimagen = Convert.ToString(row["URLIMAGEN"])
                  };
              }
          }
       }

        public DataTable obtenerImagen(string idproductogen)
        {
            try
            {
                string sql = @" SELECT T1.IDIMAGEN, T1.IDPRODUCTOGEN, T1.NOMIMAGEN, T1.URLIMAGEN
                                FROM TM_IMAGENES_PRODUCTO T1
                                WHERE T1.IDPRODUCTOGEN="+ idproductogen + @"
                                ORDER BY T1.ORDENIMAGEN ASC";

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
