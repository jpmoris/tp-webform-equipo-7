using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;
using Modelo;



namespace Controlador
{
    public class ArticuloNegocio
    {
        
        public Articulo buscarArticulo(int id)
        {
            Articulo aux = new Articulo();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetConsulta("SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.precio,m.Id IdMarca, m.Descripcion Marca, c.Id IdCategoria, c.Descripcion Categoria " +
                   "from ARTICULOS A " +
                   "Join Marcas as m on A.IdMarca = M.Id " +
                   "Join CATEGORIAS as c on A.IdCategoria = C.Id " +
                   "WHERE a.Id=" + id);
                datos.EjecutarLectura();
                if (datos.Lector.Read())
                {
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Codigo = (int)datos.Lector["IdMarca"];
                    aux.Marca.Nombre = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Codigo = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Nombre = (string)datos.Lector["Categoria"];
                    aux.Precio = decimal.Round((decimal)datos.Lector["Precio"], 2);
                }
                else aux = null;
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public int GetUltimoIDArticulo()
        {
            int n=0;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetConsulta("SELECT TOP(1) A.Id from Articulos A ORDER BY Id DESC\r\n");
                datos.EjecutarLectura();
                if(datos.Lector.Read())
                {
                    n = (int)datos.Lector["Id"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
            return n; 
        }

        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetConsulta("SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.precio,m.Id IdMarca, m.Descripcion Marca, c.Id IdCategoria, c.Descripcion Categoria " +
                   "from ARTICULOS A " +
                   "Join Marcas as m on A.IdMarca = M.Id " +
                   "Join CATEGORIAS as c on A.IdCategoria = C.Id");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Codigo = (int)datos.Lector["IdMarca"];
                    aux.Marca.Nombre = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Codigo = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Nombre = (string)datos.Lector["Categoria"];
                    aux.Precio = decimal.Round((decimal)datos.Lector["Precio"], 2);
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
               
        }
        public List<Articulo> listar(Categoria cat)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetConsulta("SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.precio,m.Id IdMarca, m.Descripcion Marca, c.Id IdCategoria, c.Descripcion Categoria " +
                   "from ARTICULOS A " +
                   "Join Marcas as m on A.IdMarca = M.Id " +
                   "Join CATEGORIAS as c on A.IdCategoria = C.Id " +
                   "WHERE IdCategoria = " + cat.Codigo);
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Codigo = (int)datos.Lector["IdMarca"];
                    aux.Marca.Nombre = (string)datos.Lector["Marca"];
                    aux.Categoria = cat;
                    aux.Categoria.Codigo = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Nombre = (string)datos.Lector["Categoria"];
                    aux.Precio = decimal.Round((decimal)datos.Lector["Precio"], 2);
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }

        public List<Articulo> listar(Marca marca)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetConsulta("SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.precio,m.Id IdMarca, m.Descripcion Marca, c.Id IdCategoria, c.Descripcion Categoria " +
                   "from ARTICULOS A " +
                   "Join Marcas as m on A.IdMarca = M.Id " +
                   "Join CATEGORIAS as c on A.IdCategoria = C.Id " +
                   "WHERE IdMarca = " + marca.Codigo);
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = marca;
                    aux.Marca.Codigo = (int)datos.Lector["IdMarca"];
                    aux.Marca.Nombre = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Codigo = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Nombre = (string)datos.Lector["Categoria"];
                    aux.Precio = decimal.Round((decimal)datos.Lector["Precio"], 2);
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }

        public void agregar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valorTexto = articulo.Precio.ToString();
                valorTexto = Regex.Replace(valorTexto, "[,]", ".");
                datos.SetConsulta("Insert into articulos values(@codigo,@nombre,@descripcion,@idmarca,@idcategoria,@precio)");
                datos.setearParametro("@codigo", articulo.Codigo);
                datos.setearParametro("@nombre", articulo.Nombre);
                datos.setearParametro("@descripcion", articulo.Descripcion);
                datos.setearParametro("@idmarca", articulo.Marca.Codigo);
                datos.setearParametro("@idcategoria", articulo.Categoria.Codigo);
                datos.setearParametro("@precio", valorTexto);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetConsulta("delete from articulos where Id = @id");
                datos.setearParametro("@id", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.SetConsulta("Update articulos set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idmarca, IdCategoria = @idcategoria, Precio = @precio where Id=@id");
                datos.setearParametro("@codigo", articulo.Codigo);
                datos.setearParametro("@nombre", articulo.Nombre);
                datos.setearParametro("@descripcion", articulo.Descripcion);
                datos.setearParametro("@idmarca", articulo.Marca.Codigo);
                datos.setearParametro("@idcategoria", articulo.Categoria.Codigo);
                datos.setearParametro("@precio", articulo.Precio);
                datos.setearParametro("@id", articulo.Id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.precio, m.Id IdMarca, m.Descripcion Marca, c.Id IdCategoria, c.Descripcion Categoria\r\nfrom ARTICULOS A inner Join Marcas as m on A.IdMarca = M.Id inner Join CATEGORIAS as c on A.IdCategoria = C.Id WHERE ";
                if (campo == "Precio")
                {
                    if (criterio == "Mayor que")
                    {
                        consulta += "A.Precio > " + filtro;
                    }
                    else if (criterio == "Menor que")
                    {
                        consulta += "A.Precio < " + filtro;
                    }
                    else if (criterio == "Igual a")
                    {
                        consulta += "A.Precio = " + filtro;
                    }
                }
                else if(campo == "Código")
                {
                    if (criterio == "Empieza con")
                    {
                        consulta += "A.Codigo like '" + filtro +"%'";
                    }
                    else if(criterio == "Termina con")
                    {
                        consulta += "A.Codigo like '%" + filtro + "'";

                    } else if(criterio == "Contiene")
                    {
                        consulta += "A.Codigo like '%" + filtro + "%'";
                    }
                }
                else if (campo == "Nombre")
                {
                    if (criterio == "Empieza con")
                    {
                        consulta += "A.Nombre like '" + filtro + "%'";
                    }
                    else if (criterio == "Termina con")
                    {
                        consulta += "A.Nombre like '%" + filtro + "'";

                    }
                    else if (criterio == "Contiene")
                    {
                        consulta += "A.Nombre like '%" + filtro + "%'";
                    }
                }
                else if (campo == "Descripción")
                {
                    if (criterio == "Empieza con")
                    {
                        consulta += "A.Descripcion like '" + filtro + "%'";
                    }
                    else if (criterio == "Termina con")
                    {
                        consulta += "A.Descripcion like '%" + filtro + "'";

                    }
                    else if (criterio == "Contiene")
                    {
                        consulta += "A.Descripcion like '%" + filtro + "%'";
                    }
                }
                else if (campo == "Categoría")
                {
                    if (criterio == "Empieza con")
                    {
                        consulta += "c.Descripcion like '" + filtro + "%'";
                    }
                    else if (criterio == "Termina con")
                    {
                        consulta += "c.Descripcion like '%" + filtro + "'";

                    }
                    else if (criterio == "Contiene")
                    {
                        consulta += "c.Descripcion like '%" + filtro + "%'";
                    }
                }
                else if (campo == "Marca")
                {
                    if (criterio == "Empieza con")
                    {
                        consulta += "m.Descripcion like '" + filtro + "%'";
                    }
                    else if (criterio == "Termina con")
                    {
                        consulta += "m.Descripcion like '%" + filtro + "'";

                    }
                    else if (criterio == "Contiene")
                    {
                        consulta += "m.Descripcion like '%" + filtro + "%'";
                    }
                }
                datos.SetConsulta(consulta);
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Codigo = (int)datos.Lector["IdMarca"];
                    aux.Marca.Nombre = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Codigo = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Nombre = (string)datos.Lector["Categoria"];
                    aux.Precio = decimal.Round((decimal)datos.Lector["Precio"], 2);
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
