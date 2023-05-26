using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Imagen
    {
        public int id {  get; set; }
        public int idArticulo { get; set; }
        public string url { get; set; }

        public Imagen() { }
        public Imagen(int id, int idArticulo, string url)
        {
            this.id = id;
            this.idArticulo = idArticulo;
            this.url = url;
        }
        public Imagen(int idArticulo, string url) { this.idArticulo = idArticulo; this.url = url; }
    }
}
