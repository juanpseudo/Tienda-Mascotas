using Todo_Mascota.Models.menu_producto.Clases;
using Todo_Mascota.Models.menu_producto.IRepositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using Todo_Mascota.Models.ejecuta;
using Todo_Mascota.Models.menu_imagen.IRepositorios;
using Todo_Mascota.Models.menu_imagen.Repositorios;
using Todo_Mascota.Models.menu_material.IRepositorios;
using Todo_Mascota.Models.menu_material.Repositorios;
using Todo_Mascota.Models.menu_animal.IRepositorios;
using Todo_Mascota.Models.menu_animal.Repositorios;

namespace Todo_Mascota.Models.menu_producto.Repositorios
{
   public class ProductoRepository : IProductoRepository
   {
        private ConexionOracle conexion = new ConexionOracle();
       private DataTable datos = new DataTable();
        static readonly IImagenRepository repositoryImg = new ImagenRepository();
        static readonly IMaterialRepository repositoryMat = new MaterialRepository();
        static readonly IAnimalRepository repositoryAni = new AnimalRepository();

        public  IEnumerable<Producto> GetAll()
       {
           datos = obtenerProductos();
          if (datos != null)
          {
              foreach (DataRow row in datos.Rows)
              {
                  yield return new Producto
                  {
                      idproductogen = Convert.ToString(row["IDPRODUCTOGEN"]),
                      idtamano = Convert.ToString(row["IDTAMANO"]),
                      tipoproductogen = Convert.ToString(row["TIPOPRODUCTOGEN"]),
                      codigoproductogen = Convert.ToString(row["CODIGOPRODUCTOGEN"]),
                      precioproductogen = Convert.ToString(row["PRECIOPRODUCTOGEN"]),
                      costoproductogen = Convert.ToString(row["COSTOPRODUCTOGEN"]),
                      tipomarcaproductogen = Convert.ToString(row["TIPOMARCAPRODUCTOGEN"]),
                      modeloproductogen = Convert.ToString(row["MODELOPRODUCTOGEN"]),
                      tipounidadpesoproductogen = Convert.ToString(row["TIPOUNIDADPESOPRODUCTOGEN"]),
                      cantpesoproductogen = Convert.ToString(row["CANTPESOPRODUCTOGEN"]),
                      stockproductogen = Convert.ToString(row["STOCKPRODUCTOGEN"]),
                      fechaauditoriaproductogen = Convert.ToString(row["FECHAAUDITORIAPRODUCTOGEN"]),
                      usernameauditoriaproductogen = Convert.ToString(row["USERNAMEAUDITORIAPRODUCTOGEN"]),
                      nom_produc = Convert.ToString(row["NOM_PRODUC"]),
                      descrip_produ = Convert.ToString(row["DESCRIP_PRODU"]),
                      altotamano = Convert.ToString(row["ALTOTAMANO"]),
                      anchotamano = Convert.ToString(row["ANCHOTAMANO"]),
                      largotamano = Convert.ToString(row["LARGOTAMANO"]),
                      tiponombretamano = Convert.ToString(row["TIPONOMBRETAMANO"]),
                      tipounidadtamano = Convert.ToString(row["TIPOUNIDADTAMANO"]),
                      nom_tam = Convert.ToString(row["NOM_TAM"]),
                      nom_unid_tam = Convert.ToString(row["NOM_UNID_TAM"]),
                      nom_marca = Convert.ToString(row["NOM_MARCA"]),
                      nom_unid_peso = Convert.ToString(row["NOM_UNID_PESO"]),
                      color = Convert.ToString(row["COLOR"]),
                      imagen_url = Convert.ToString(row["IMAGEN_URL"]),
                      imagenes = repositoryImg.GetAll(Convert.ToInt32(row["IDPRODUCTOGEN"])),
                      materiales = repositoryMat.GetAll(Convert.ToInt32(row["IDPRODUCTOGEN"])),
                      animales = repositoryAni.GetAll(Convert.ToInt32(row["IDPRODUCTOGEN"]))
                  };
              }
          }
       }

        public IEnumerable<Producto> GetAllClase(string idCLase)
        {
            datos = obtenerProductosClase(idCLase);
            if (datos != null)
            {
                foreach (DataRow row in datos.Rows)
                {
                    yield return new Producto
                    {
                        idproductogen = Convert.ToString(row["IDPRODUCTOGEN"]),
                        idtamano = Convert.ToString(row["IDTAMANO"]),
                        tipoproductogen = Convert.ToString(row["TIPOPRODUCTOGEN"]),
                        codigoproductogen = Convert.ToString(row["CODIGOPRODUCTOGEN"]),
                        precioproductogen = Convert.ToString(row["PRECIOPRODUCTOGEN"]),
                        costoproductogen = Convert.ToString(row["COSTOPRODUCTOGEN"]),
                        tipomarcaproductogen = Convert.ToString(row["TIPOMARCAPRODUCTOGEN"]),
                        modeloproductogen = Convert.ToString(row["MODELOPRODUCTOGEN"]),
                        tipounidadpesoproductogen = Convert.ToString(row["TIPOUNIDADPESOPRODUCTOGEN"]),
                        cantpesoproductogen = Convert.ToString(row["CANTPESOPRODUCTOGEN"]),
                        stockproductogen = Convert.ToString(row["STOCKPRODUCTOGEN"]),
                        fechaauditoriaproductogen = Convert.ToString(row["FECHAAUDITORIAPRODUCTOGEN"]),
                        usernameauditoriaproductogen = Convert.ToString(row["USERNAMEAUDITORIAPRODUCTOGEN"]),
                        nom_produc = Convert.ToString(row["NOM_PRODUC"]),
                        descrip_produ = Convert.ToString(row["DESCRIP_PRODU"]),
                        altotamano = Convert.ToString(row["ALTOTAMANO"]),
                        anchotamano = Convert.ToString(row["ANCHOTAMANO"]),
                        largotamano = Convert.ToString(row["LARGOTAMANO"]),
                        tiponombretamano = Convert.ToString(row["TIPONOMBRETAMANO"]),
                        tipounidadtamano = Convert.ToString(row["TIPOUNIDADTAMANO"]),
                        nom_tam = Convert.ToString(row["NOM_TAM"]),
                        nom_unid_tam = Convert.ToString(row["NOM_UNID_TAM"]),
                        nom_marca = Convert.ToString(row["NOM_MARCA"]),
                        nom_unid_peso = Convert.ToString(row["NOM_UNID_PESO"]),
                        color = Convert.ToString(row["COLOR"]),
                        imagen_url = Convert.ToString(row["IMAGEN_URL"]),
                        imagenes = repositoryImg.GetAll(Convert.ToInt32(row["IDPRODUCTOGEN"])),
                        materiales = repositoryMat.GetAll(Convert.ToInt32(row["IDPRODUCTOGEN"])),
                        animales = repositoryAni.GetAll(Convert.ToInt32(row["IDPRODUCTOGEN"]))
                    };
                }
            }
        }

        public IEnumerable<Producto> GetAllSubClase(string idSubCLase)
        {
            datos = obtenerProductosSubClase(idSubCLase);
            if (datos != null)
            {
                foreach (DataRow row in datos.Rows)
                {
                    yield return new Producto
                    {
                        idproductogen = Convert.ToString(row["IDPRODUCTOGEN"]),
                        idtamano = Convert.ToString(row["IDTAMANO"]),
                        tipoproductogen = Convert.ToString(row["TIPOPRODUCTOGEN"]),
                        codigoproductogen = Convert.ToString(row["CODIGOPRODUCTOGEN"]),
                        precioproductogen = Convert.ToString(row["PRECIOPRODUCTOGEN"]),
                        costoproductogen = Convert.ToString(row["COSTOPRODUCTOGEN"]),
                        tipomarcaproductogen = Convert.ToString(row["TIPOMARCAPRODUCTOGEN"]),
                        modeloproductogen = Convert.ToString(row["MODELOPRODUCTOGEN"]),
                        tipounidadpesoproductogen = Convert.ToString(row["TIPOUNIDADPESOPRODUCTOGEN"]),
                        cantpesoproductogen = Convert.ToString(row["CANTPESOPRODUCTOGEN"]),
                        stockproductogen = Convert.ToString(row["STOCKPRODUCTOGEN"]),
                        fechaauditoriaproductogen = Convert.ToString(row["FECHAAUDITORIAPRODUCTOGEN"]),
                        usernameauditoriaproductogen = Convert.ToString(row["USERNAMEAUDITORIAPRODUCTOGEN"]),
                        nom_produc = Convert.ToString(row["NOM_PRODUC"]),
                        descrip_produ = Convert.ToString(row["DESCRIP_PRODU"]),
                        altotamano = Convert.ToString(row["ALTOTAMANO"]),
                        anchotamano = Convert.ToString(row["ANCHOTAMANO"]),
                        largotamano = Convert.ToString(row["LARGOTAMANO"]),
                        tiponombretamano = Convert.ToString(row["TIPONOMBRETAMANO"]),
                        tipounidadtamano = Convert.ToString(row["TIPOUNIDADTAMANO"]),
                        nom_tam = Convert.ToString(row["NOM_TAM"]),
                        nom_unid_tam = Convert.ToString(row["NOM_UNID_TAM"]),
                        nom_marca = Convert.ToString(row["NOM_MARCA"]),
                        nom_unid_peso = Convert.ToString(row["NOM_UNID_PESO"]),
                        color = Convert.ToString(row["COLOR"]),
                        imagen_url = Convert.ToString(row["IMAGEN_URL"]),
                        imagenes = repositoryImg.GetAll(Convert.ToInt32(row["IDPRODUCTOGEN"])),
                        materiales = repositoryMat.GetAll(Convert.ToInt32(row["IDPRODUCTOGEN"])),
                        animales = repositoryAni.GetAll(Convert.ToInt32(row["IDPRODUCTOGEN"]))
                    };
                }
            }
        }

        public DataTable obtenerProductos()
        {
            try
            {
                string sql = @"SELECT T1.*, 
                                    T2.NOMDESCRIP NOM_PRODUC, 
                                    T2.DESCRIPDESCRIP DESCRIP_PRODU, 
                                    T3.ALTOTAMANO, 
                                    T3.ANCHOTAMANO, 
                                    T3.LARGOTAMANO, 
                                    T3.TIPONOMBRETAMANO, 
                                    T3.TIPOUNIDADTAMANO,
                                    T4.NOMDESCRIP NOM_TAM,
                                    T5.NOMDESCRIP NOM_UNID_TAM,
                                    T6.NOMDESCRIP NOM_MARCA,
                                    T7.NOMDESCRIP NOM_UNID_PESO,
                                    T8.CODIGOCOLOR COLOR,
                                    T9.URLIMAGEN IMAGEN_URL
                            FROM TM_PRODUCTO_GENERAL T1
                            INNER JOIN  TM_PARAMETRO T2
                                ON T1.TIPOPRODUCTOGEN=T2.IDPARAMETRODESCRIP
                            LEFT JOIN TM_TAMANO T3
                                ON T1.IDTAMANO = T3.IDTAMANO
                            LEFT JOIN  TM_PARAMETRO T4
                                ON T3.TIPONOMBRETAMANO=T4.IDPARAMETRODESCRIP
                            LEFT JOIN  TM_PARAMETRO T5
                                ON T3.TIPOUNIDADTAMANO=T5.IDPARAMETRODESCRIP
                            LEFT JOIN  TM_PARAMETRO T6
                                ON T1.TIPOMARCAPRODUCTOGEN=T6.IDPARAMETRODESCRIP
                            LEFT JOIN  TM_PARAMETRO T7
                                ON T1.TIPOUNIDADPESOPRODUCTOGEN=T7.IDPARAMETRODESCRIP
                            LEFT JOIN  TM_COLORES T8
                                ON T1.IDPRODUCTOGEN=T8.IDPRODUCTOGEN
                            LEFT JOIN  TM_IMAGENES_PRODUCTO T9
                                ON T1.IDPRODUCTOGEN=T9.IDPRODUCTOGEN AND T9.ORDENIMAGEN=1";
                DataTable tabla = conexion.EjecutaQuery_DT(sql);
                if ((tabla != null) & (tabla.Rows.Count > 0))
                {
                    return tabla;
                }
                else { return null; }
            }
            catch { return null; }
        }

        public DataTable obtenerProductosClase(string idCLase)
        {
            try
            {
                string sql = @"SELECT T1.*, 
                                    T2.NOMDESCRIP NOM_PRODUC, 
                                    T2.DESCRIPDESCRIP DESCRIP_PRODU,
                                    T2.IDPADREDESCRIP,
                                    T3.ALTOTAMANO, 
                                    T3.ANCHOTAMANO, 
                                    T3.LARGOTAMANO, 
                                    T3.TIPONOMBRETAMANO, 
                                    T3.TIPOUNIDADTAMANO,
                                    T4.NOMDESCRIP NOM_TAM,
                                    T5.NOMDESCRIP NOM_UNID_TAM,
                                    T6.NOMDESCRIP NOM_MARCA,
                                    T7.NOMDESCRIP NOM_UNID_PESO,
                                    T8.CODIGOCOLOR COLOR,
                                    T9.URLIMAGEN IMAGEN_URL
                            FROM TM_PRODUCTO_GENERAL T1
                            INNER JOIN  TM_PARAMETRO T2
                                ON (T1.TIPOPRODUCTOGEN=T2.IDPARAMETRODESCRIP
                                    AND T2.IDPADREDESCRIP 
                                    IN (SELECT P1.IDPARAMETRODESCRIP
                                        FROM TM_PARAMETRO P1
                                        WHERE P1.IDPADREDESCRIP=" + idCLase + @")
                                    )
                            LEFT JOIN TM_TAMANO T3
                                ON T1.IDTAMANO = T3.IDTAMANO
                            LEFT JOIN  TM_PARAMETRO T4
                                ON T3.TIPONOMBRETAMANO=T4.IDPARAMETRODESCRIP
                            LEFT JOIN  TM_PARAMETRO T5
                                ON T3.TIPOUNIDADTAMANO=T5.IDPARAMETRODESCRIP
                            LEFT JOIN  TM_PARAMETRO T6
                                ON T1.TIPOMARCAPRODUCTOGEN=T6.IDPARAMETRODESCRIP
                            LEFT JOIN  TM_PARAMETRO T7
                                ON T1.TIPOUNIDADPESOPRODUCTOGEN=T7.IDPARAMETRODESCRIP
                            LEFT JOIN  TM_COLORES T8
                                ON T1.IDPRODUCTOGEN=T8.IDPRODUCTOGEN
                            LEFT JOIN  TM_IMAGENES_PRODUCTO T9
                                ON T1.IDPRODUCTOGEN=T9.IDPRODUCTOGEN AND T9.ORDENIMAGEN=1";
                DataTable tabla = conexion.EjecutaQuery_DT(sql);
                if ((tabla != null) & (tabla.Rows.Count > 0))
                {
                    return tabla;
                }
                else { return null; }
            }
            catch { return null; }
        }

        public DataTable obtenerProductosSubClase(string idSubCLase)
        {
            try
            {
                string sql = @"SELECT T1.*, 
                                       T2.NOMDESCRIP NOM_PRODUC, 
                                       T2.DESCRIPDESCRIP DESCRIP_PRODU,
                                       T2.IDPADREDESCRIP,
                                       T3.ALTOTAMANO, 
                                       T3.ANCHOTAMANO, 
                                       T3.LARGOTAMANO, 
                                       T3.TIPONOMBRETAMANO, 
                                       T3.TIPOUNIDADTAMANO,
                                       T4.NOMDESCRIP NOM_TAM,
                                       T5.NOMDESCRIP NOM_UNID_TAM,
                                       T6.NOMDESCRIP NOM_MARCA,
                                       T7.NOMDESCRIP NOM_UNID_PESO,
                                       T8.CODIGOCOLOR COLOR,
                                       T9.URLIMAGEN IMAGEN_URL
                                FROM TM_PRODUCTO_GENERAL T1
                                INNER JOIN  TM_PARAMETRO T2
                                  ON (T1.TIPOPRODUCTOGEN=T2.IDPARAMETRODESCRIP
                                      AND T2.IDPADREDESCRIP=" + idSubCLase + @")
                                LEFT JOIN TM_TAMANO T3
                                  ON T1.IDTAMANO = T3.IDTAMANO
                                LEFT JOIN  TM_PARAMETRO T4
                                  ON T3.TIPONOMBRETAMANO=T4.IDPARAMETRODESCRIP
                                LEFT JOIN  TM_PARAMETRO T5
                                  ON T3.TIPOUNIDADTAMANO=T5.IDPARAMETRODESCRIP
                                LEFT JOIN  TM_PARAMETRO T6
                                  ON T1.TIPOMARCAPRODUCTOGEN=T6.IDPARAMETRODESCRIP
                                LEFT JOIN  TM_PARAMETRO T7
                                  ON T1.TIPOUNIDADPESOPRODUCTOGEN=T7.IDPARAMETRODESCRIP
                                LEFT JOIN  TM_COLORES T8
                                  ON T1.IDPRODUCTOGEN=T8.IDPRODUCTOGEN
                                LEFT JOIN  TM_IMAGENES_PRODUCTO T9
                                    ON T1.IDPRODUCTOGEN=T9.IDPRODUCTOGEN AND T9.ORDENIMAGEN=1";
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
