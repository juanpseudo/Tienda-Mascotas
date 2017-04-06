using System;
using Todo_Mascota.Models.menu_producto.Clases;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Todo_Mascota.Models.menu_producto.IRepositorios
{
   public interface IProductoRepository
   {
        IEnumerable<Producto> GetAll();
        IEnumerable<Producto> GetAllClase(string idCLase);
        IEnumerable<Producto> GetAllSubClase(string idSubCLase);
        DataTable obtenerProductos();
        DataTable obtenerProductosClase(string idCLase);
        DataTable obtenerProductosSubClase(string idSubCLase);
      //Producto Get(int idtamano, int idproductogen);
      //Producto Add(Producto item);
      //void Remove(int idtamano, int idproductogen);
      //bool Update(Producto item);
    }
}
