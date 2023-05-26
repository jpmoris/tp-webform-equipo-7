using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Articulo
    {
        private int id;
        private string codigo;
        private string nombre;
        private string descripcion;
        Marca marca;
        Categoria categoria;
        List<string> imagenes = new List<string>();
        private decimal precio;

        public Articulo(int id,string codigo, string nombre, string descripcion, Marca marca, Categoria categoria, List<string> imagenes, decimal precio, Imagen imagen)
        {
            this.id = id;
            this.codigo = codigo;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.marca = marca;
            this.categoria = categoria;
            this.imagenes.AddRange(imagenes);
            this.precio = precio;
        }
        public Articulo() { }
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
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
        public decimal Precio
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
        public List<string> Imagenes
        {
            get { return imagenes; }
            set { imagenes.AddRange(value) ; }
        }
    }


}   


