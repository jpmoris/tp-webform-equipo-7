﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Categoria
    {
        private int codigo;
        private string nombre;

        public Categoria(int codigo, string nombre)
        {
            this.codigo = codigo;
            this.nombre = nombre;
        }
        public Categoria() { }
        public int Codigo { 
            get { return codigo; }
            set { codigo = value; }
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
