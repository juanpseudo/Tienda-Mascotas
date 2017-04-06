using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Todo_Mascota.Models.menu_animal.Clases;
using Todo_Mascota.Models.menu_imagen.Clases;
using Todo_Mascota.Models.menu_material.Clases;

namespace Todo_Mascota.Models.menu_producto.Clases
{
   public class Producto
   {
       public String idproductogen { get; set; }
       public String idtamano { get; set; }
       public String tipoproductogen { get; set; }
       public String codigoproductogen { get; set; }
       public String precioproductogen { get; set; }
       public String costoproductogen { get; set; }
       public String tipomarcaproductogen { get; set; }
       public String modeloproductogen { get; set; }
       public String tipounidadpesoproductogen { get; set; }
       public String cantpesoproductogen { get; set; }
       public String stockproductogen { get; set; }
       public String fechaauditoriaproductogen { get; set; }
       public String usernameauditoriaproductogen { get; set; }
       public String nom_produc { get; set; }
       public String descrip_produ { get; set; }
       public String altotamano { get; set; }
       public String anchotamano { get; set; }
       public String largotamano { get; set; }
       public String tiponombretamano { get; set; }
       public String tipounidadtamano { get; set; }
       public String nom_tam { get; set; }
       public String nom_unid_tam { get; set; }
       public String nom_marca { get; set; }
       public String nom_unid_peso { get; set; }
       public String color { get; set; }
        public String imagen_url { get; set; }
        public IEnumerable<Animal> animales { get; set; }
        public IEnumerable<Imagen> imagenes { get; set; }
        public IEnumerable<Material> materiales { get; set; }
    }
}
