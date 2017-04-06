using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Todo_Mascota.Models.menu_producto.Clases;
using Todo_Mascota.Models.menu_animal.Clases;
using Todo_Mascota.Models.menu_imagen.Clases;
using Todo_Mascota.Models.menu_material.Clases;

namespace Todo_Mascota.Models.menu_producto_general.Clases
{
    public class ProductoGeneral
    {
        public IEnumerable<Producto> productos { get; set; }
        public IEnumerable<Animal> animales { get; set; }
        public IEnumerable<Imagen> imagenes { get; set; }
        public IEnumerable<Material> materiales { get; set; }

    }
}