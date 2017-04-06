using System;
using Todo_Mascota.Models.menu_animal.Clases;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Todo_Mascota.Models.menu_animal.IRepositorios
{
   public interface IAnimalRepository
   {
      IEnumerable<Animal> GetAll(int idproductogen);
   }
}
