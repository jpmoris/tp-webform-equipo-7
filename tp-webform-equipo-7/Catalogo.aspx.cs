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
        //public List<Articulo> listaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Articulo> listaArticulos = new List<Articulo>();

            if (!IsPostBack)
            {
                ArticuloNegocio negocioArt = new ArticuloNegocio();
                listaArticulos = negocioArt.listar();
                ImagenNegocio negocioImg = new ImagenNegocio();
                foreach (Articulo articulo in listaArticulos)
                {
                    List<Imagen> imagenes = negocioImg.listarPorIdArticulo(articulo.Id);
                    List<string> imagenesUrl = new List<string>();
                    //si hay imagenes guardadas se agrega la primera, sino se agrega un placeholder

                    if (imagenes.Count == 0) imagenesUrl.Add(placeholderImg);
                    else imagenesUrl.Add(imagenes[0].url);

                    articulo.Imagenes = imagenesUrl;

                }
                Session.Add("listaArticulos", listaArticulos);
                cardRepeater.DataSource = Session["listaArticulos"];
                cardRepeater.DataBind();
            }
        }
    }
}