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

        private string ordenarPor = "0";
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

                Session.Add("ListaCategorias", listaCategorias);
                ddlCategorias.DataSource = Session["listaCategorias"];
                ddlCategorias.DataTextField = "Nombre";
                ddlCategorias.DataValueField = "Codigo";
                ddlCategorias.DataBind();

                Session.Add("listaMarcas", listaMarcas);
                ddlMarcas.DataSource = Session["listaMarcas"];
                ddlMarcas.DataTextField = "Nombre";
                ddlMarcas.DataValueField = "Codigo";
                ddlMarcas.DataBind();

                Session.Add("listaArticulos", listaArticulos);
                Session.Add("listaMostrada", listaArticulos);
                cardRepeater.DataSource = Session["listaMostrada"];
                cardRepeater.DataBind();

                
            }
        }

        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

            int codigo = int.Parse(ddlCategorias.SelectedItem.Value);
            List<Articulo> listaFiltrada = (List<Articulo>)Session["ListaMostrada"];
            Session.Add("listaFiltradaPorCategoria", listaFiltrada);
            if (codigo == 0)
            {
                cardRepeater.DataSource = Session["listaMostrada"];
                cardRepeater.DataBind();
            }
            else
            {
                listaFiltrada = ((List<Articulo>)Session["listaMostrada"]).FindAll(a => a.Categoria.Codigo == codigo);
                Session["listaFiltradaPorCategoria"] = listaFiltrada;
                cardRepeater.DataSource = listaFiltrada;
                cardRepeater.DataBind();

            }
                //actualiza filtro de marcas
                ddlMarcas.DataSource = ((List<Marca>)Session["listaMarcas"]).FindAll(m => listaFiltrada.Any(a => a.Marca.Codigo == m.Codigo)||m.Codigo==0);
                ddlMarcas.DataBind();
        }

        protected void ddlMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo = int.Parse(ddlMarcas.SelectedItem.Value);
            
            if(codigo == 0)
            {

                cardRepeater.DataSource = Session["listaFiltradaPorCategoria"];
                cardRepeater.DataBind();
            }
            else
            {
                cardRepeater.DataSource = ((List<Articulo>)Session["listaFiltradaPorCategoria"]).FindAll(a => a.Marca.Codigo == codigo);
                cardRepeater.DataBind();
            }

        }

        protected void btnBusqueda_Click(object sender, EventArgs e)
        {
            if(txtBusqueda.Text == "")
            {
                Session["listaMostrada"] = Session["listaArticulos"];
                cardRepeater.DataSource = Session["listaMostrada"];
                cardRepeater.DataBind();
            }
            else
            {
                List<Articulo> listaFiltrada = new List<Articulo>();
                listaFiltrada = ((List<Articulo>)Session["listaArticulos"]).FindAll(a =>
                    a.Nombre.ToLower().Contains(txtBusqueda.Text.ToLower()) ||
                    a.Marca.Nombre.ToLower().Contains(txtBusqueda.Text.ToLower()) ||
                    a.Categoria.Nombre.ToLower().Contains(txtBusqueda.Text.ToLower())
                    );
                Session["listaMostrada"] = listaFiltrada;
                cardRepeater.DataSource = listaFiltrada;
                cardRepeater.DataBind();

            }

            ddlCategorias.DataSource = ((List<Categoria>)Session["listaCategorias"]).FindAll(c => ((List<Articulo>)Session["listaMostrada"]).Any(a => a.Categoria.Codigo == c.Codigo) || c.Codigo == 0);
            ddlCategorias.SelectedItem.Value = "0";
            Session["listaFiltradaPorCategoria"] = Session["listaMostrada"];
            ddlCategorias.DataBind();

            ddlMarcas.DataSource = ((List<Marca>)Session["listaMarcas"]).FindAll(m => ((List<Articulo>)Session["listaMostrada"]).Any(a => a.Marca.Codigo == m.Codigo) || m.Codigo == 0);
            ddlMarcas.SelectedItem.Value = "0";
            ddlMarcas.DataBind();
        }

        
    }
}