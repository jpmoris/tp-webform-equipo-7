using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Articulo
    {
        private int codigo;
        private string nombre;
        private string descripcion;
        Marca marca;
        Categoria categoria;
        List<string> imagenes;
        private float precio;

        public Articulo(int codigo, string nombre, string descripcion, Marca marca, Categoria categoria, List<string> imagenes, float precio)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.marca = marca;
            this.categoria = categoria;
            this.imagenes = imagenes;
            this.precio = precio;
        }
        public Articulo() {}
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public Categoria Categoria 
        {
            get { return categoria; }
            set { categoria = value;} 
        }
        public Marca Marca 
        {
            get { return marca; }
            set { marca = value; }
        }
    }


}   


