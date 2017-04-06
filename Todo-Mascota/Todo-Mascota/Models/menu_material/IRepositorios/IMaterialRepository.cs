using System;
using Todo_Mascota.Models.menu_material.Clases;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Todo_Mascota.Models.menu_material.IRepositorios
{
   public interface IMaterialRepository
   {
      IEnumerable<Material> GetAll(int idproductogen);
        DataTable obtenerMaterial(string idproductogen);
   }
}
