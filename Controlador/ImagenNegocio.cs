using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class ImagenNegocio
    {
        public List<Imagen> listarPorIdArticulo(int idArticulo) {
            List<Imagen> imagenes = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = $"select Id, ImagenUrl from imagenes i where i.IdArticulo={idArticulo}";
                datos.SetConsulta(consulta);
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    imagenes.Add(new Imagen((int)datos.Lector["Id"], idArticulo, (string)datos.Lector["ImagenUrl"]));
                }
                return imagenes;
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
        public void agregar(Imagen imagen)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetConsulta("Insert into imagenes values(@idArticulo, @url)");
                datos.setearParametro("@idArticulo", imagen.idArticulo);
                datos.setearParametro("@url", imagen.url);
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
                datos.SetConsulta("delete from imagenes where Id = @id");
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
        public void modificar(Imagen modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetConsulta("update imagenes set url = @url Where Id = @id");
                datos.setearParametro("@url", modificar.url);
                datos.setearParametro("@id", modificar.id);
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
    }
}
