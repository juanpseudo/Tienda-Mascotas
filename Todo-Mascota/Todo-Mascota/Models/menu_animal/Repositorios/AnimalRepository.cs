using Todo_Mascota.Models.menu_animal.Clases;
using Todo_Mascota.Models.menu_animal.IRepositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using Todo_Mascota.Models.ejecuta;

namespace Todo_Mascota.Models.menu_animal.Repositorios
{
   public class AnimalRepository : IAnimalRepository
   {
       private Animal animal = new Animal();
       private string respuesta;
       private DataTable datos = new DataTable();
       private ConexionOracle conexion = new ConexionOracle();

        public  IEnumerable<Animal> GetAll(int idproductogen)
       {
           datos = obtenerAnimal(idproductogen.ToString());
          if (datos != null)
          {
              foreach (DataRow row in datos.Rows)
              {
                  yield return new Animal
                  {
                      idmascotas = Convert.ToString(row["IDMASCOTAS"]),
                      tipomascotas = Convert.ToString(row["TIPOMASCOTAS"]),
                      tipotamanomascotas = Convert.ToString(row["TIPOTAMANOMASCOTAS"]),
                      nom_animal = Convert.ToString(row["NOM_ANIMAL"]),
                      nom_tam_animal = Convert.ToString(row["NOM_TAM_ANIMAL"])
                  };
              }
          }
       }

        public DataTable obtenerAnimal(string idproductogen)
        {
            try
            {
                string sql = @" SELECT T1.IDMASCOTAS, T1.TIPOMASCOTAS, T1.TIPOTAMANOMASCOTAS, T3.NOMDESCRIP NOM_ANIMAL, T4.NOMDESCRIP NOM_TAM_ANIMAL
                                FROM TM_MASCOTA T1
                                INNER JOIN TM_PRODUCTO_MASCOTA T2
                                ON (T1.IDMASCOTAS = T2.IDMASCOTAS AND T2.IDPRODUCTOGEN="+ idproductogen + @")
                                INNER JOIN TM_PARAMETRO T3
                                ON T3.IDPARAMETRODESCRIP = T1.TIPOMASCOTAS
                                INNER JOIN TM_PARAMETRO T4
                                ON T4.IDPARAMETRODESCRIP = T1.TIPOTAMANOMASCOTAS
                                ORDER BY T3.ORDENDESCRIP";

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
