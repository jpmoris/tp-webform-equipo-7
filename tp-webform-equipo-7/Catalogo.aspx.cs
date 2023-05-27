using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controlador;
using Modelo;

namespace tp_webform_equipo_7
{
    public partial class Catalogo : System.Web.UI.Page
    {
        private string placeholderImg = "https://www.charitycomms.org.uk/wp-content/uploads/2019/02/placeholder-image-square.jpg";
        public List<Articulo> listaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio negocioArt = new ArticuloNegocio();
                listaArticulos = negocioArt.listar();
                ImagenNegocio negocioImg = new ImagenNegocio();
                foreach (Articulo articulo in listaArticulos)
                {
                    List<Imagen> imagenes = negocioImg.listarPorIdArticulo(articulo.Id);
                    List<string> imagenesUrl = new List<string>();
                    foreach (Imagen imagen in imagenes)
                    {
                        try   //Si la imagen no existe, se agrega una imagen de placeholder
                        {
                            WebClient cliente = new WebClient();
                            cliente.OpenRead(imagen.url);
                            imagenesUrl.Add(imagen.url);
                        }
                        catch (WebException)
                        {
                            imagenesUrl.Add(placeholderImg);
                        }
                    }
                    if((imagenesUrl.Count == 0)) //si no hay imagenes, se agrega una imagen de placeholder
                    {
                        imagenesUrl.Add(placeholderImg);
                    }
                    articulo.Imagenes = imagenesUrl;   
                    
                }
                cardRepeater.DataSource = listaArticulos;
                cardRepeater.DataBind();
            }
        }
    }
}