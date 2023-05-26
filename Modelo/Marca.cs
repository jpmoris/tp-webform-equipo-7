using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modelo
{
    public class Marca
    {
        private int codigo;
        private string nombre;

        public Marca(int codigo, string nombre)
        {
            this.codigo = codigo;
            this.nombre = nombre;
        }
        public Marca() {}
        public int Codigo 
        {
            get { return codigo; }
            set { codigo = value;} 
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public override string ToString()
        {
            return nombre;
        }
    }
}
