using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Carrito
    {
        public Articulo articulo { get; set; }
        public int cantidad { get; set; }
        public Carrito(Articulo articulo, int cantidad)
        {
            this.articulo = articulo;
            this.cantidad = cantidad;
        }
    }
}
