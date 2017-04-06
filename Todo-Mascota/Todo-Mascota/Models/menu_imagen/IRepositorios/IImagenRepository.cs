using System;
using Todo_Mascota.Models.menu_imagen.Clases;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Todo_Mascota.Models.menu_imagen.IRepositorios
{
   public interface IImagenRepository
   {
      IEnumerable<Imagen> GetAll(int idproductogen);
      DataTable obtenerImagen(string idproductogen);
   }
}
