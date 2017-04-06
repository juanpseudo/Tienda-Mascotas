using System;
using Todo_Mascota.Models.menu_parametro.Clases;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Todo_Mascota.Models.menu_parametro.IRepositorios
{
   public interface IParametroRepository
   {
      IEnumerable <Parametro> GetAll(int idpadredescrip);
         DataTable obtenerParametro(string idpadredescrip);
        DataTable obtenerClases();
        DataTable obtenerSubClases(string idpadredescrip);
      //Parametro Get(int idpadredescrip, int idparametrodescrip);
      //Parametro Add(Parametro item);
      //void Remove(int idpadredescrip, int idparametrodescrip);
      //bool Update(Parametro item);
    }
}
