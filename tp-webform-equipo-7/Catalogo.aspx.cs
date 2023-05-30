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

      
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                List<Articulo> listaArticulos = new List<Articulo>();
                List<Marca> listaMarcas = new List<Marca>();
                List<Categoria> listaCategorias = new List<Categoria>();
                ArticuloNegocio negocioArt = new ArticuloNegocio();
                listaArticulos = negocioArt.listar();
                ImagenNegocio negocioImg = new ImagenNegocio();
                Categoria todasCat = new Categoria(0, "Todas las categorias");
                listaCategorias.Add(todasCat);
                Marca todasMarc = new Marca(0, "Todas las marcas");
                listaMarcas.Add(todasMarc);
                foreach (Articulo articulo in listaArticulos)
                {
                    List<Imagen> imagenes = negocioImg.listarPorIdArticulo(articulo.Id);
                    List<string> imagenesUrl = new List<string>();
                    //si hay imagenes guardadas se agrega la primera, sino se agrega un placeholder

                    if (imagenes.Count == 0) imagenesUrl.Add(placeholderImg);
                    else imagenesUrl.Add(imagenes[0].url);
                    
                    articulo.Imagenes = imagenesUrl;

                    if (!listaCategorias.Any(c => c.Codigo == articulo.Categoria.Codigo && c.Nombre == articulo.Categoria.Nombre))
                    {
                        listaCategorias.Add(articulo.Categoria);
                    }

                    if (!listaMarcas.Any(m => m.Codigo == articulo.Marca.Codigo && m.Nombre == articulo.Marca.Nombre))
                    {
                        listaMarcas.Add(articulo.Marca);
                    }
                }

                ddlCategorias.DataSource = listaCategorias;
                ddlCategorias.DataTextField = "Nombre";
                ddlCategorias.DataValueField = "Codigo";
                ddlCategorias.DataBind();

                Session.Add("listaMarcas", listaMarcas);
                ddlMarcas.DataSource = Session["lsitaMarcacs"];
                ddlMarcas.DataTextField = "Nombre";
                ddlMarcas.DataValueField = "Codigo";
                ddlMarcas.DataBind();

                Session.Add("listaArticulos", listaArticulos);
                cardRepeater.DataSource = Session["listaArticulos"];
                cardRepeater.DataBind();
                

                
            }
        }

        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo = int.Parse(ddlCategorias.SelectedItem.Value);
            if (codigo == 0)
            {
                cardRepeater.DataSource = Session["listaArticulos"];
                cardRepeater.DataBind();
            }
            else
            {
                cardRepeater.DataSource = ((List<Articulo>)Session["listaArticulos"]).FindAll(a => a.Categoria.Codigo == codigo);
                cardRepeater.DataBind();
            }
            //updateFiltroMarcas()
        }

    }
}