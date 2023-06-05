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

        public void setPaginaActual(bool ignoreQueryStrings)
        {
            int paginaActual = 1;
            if (Request.QueryString["page"] != null && !ignoreQueryStrings)
            {
                paginaActual = int.Parse(Request.QueryString["page"]);
            }
            Session["paginaActual"] = paginaActual;
        }

        
        public void cargarListadoPorPagina(List<Articulo> listaArticulos, bool ignoreQueryStrings)
        {
            int cardsPorPagina = 30;
            setPaginaActual(ignoreQueryStrings);
            int paginaActual = (int)Session["paginaActual"];
            int startIndex = (paginaActual - 1) * cardsPorPagina;
            int totalArticulos = listaArticulos.Count;
            

            List<Articulo> listaPaginada = listaArticulos.GetRange(startIndex, Math.Min(cardsPorPagina, totalArticulos - startIndex));

            
            cardRepeater.DataSource = listaPaginada;
            cardRepeater.DataBind();

            int totalPaginas = (int)Math.Ceiling((double)totalArticulos / cardsPorPagina);
            List<int> paginas = new List<int>();
            for (int i = 1; i <= totalPaginas; i++)
            {
                paginas.Add(i);
            }

            pagerRepeater.DataSource = paginas;
            pagerRepeater.DataBind();
        }

        public void filtrarCatalogo()
        {
            if (txtBusqueda.Text == "")
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

            }
            
            cargarListadoPorPagina((List<Articulo>)Session["listaMostrada"],true);
            
            ddlCategorias.DataSource = ((List<Categoria>)Session["listaCategorias"]).FindAll(c => ((List<Articulo>)Session["listaMostrada"]).Any(a => a.Categoria.Codigo == c.Codigo) || c.Codigo == 0);
            ddlCategorias.SelectedItem.Value = "0";
            Session["listaFiltradaPorCategoria"] = Session["listaMostrada"];
            ddlCategorias.DataBind();

            ddlMarcas.DataSource = ((List<Marca>)Session["listaMarcas"]).FindAll(m => ((List<Articulo>)Session["listaMostrada"]).Any(a => a.Marca.Codigo == m.Codigo) || m.Codigo == 0);
            ddlMarcas.SelectedItem.Value = "0";
            ddlMarcas.DataBind();

        }
        public void listarCatalogo()
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

                if (imagenes.Count == 0 || !( negocioImg.comprobarUrl(imagenes[0].url)) ) imagenesUrl.Add(placeholderImg);
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
            cargarListadoPorPagina(listaArticulos,false);
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Add("paginaActual", 1);
                listarCatalogo();

                if (Request.QueryString["busqueda"] != null)
                {
                    txtBusqueda.Text = Request.QueryString["busqueda"];

                    List<Articulo> listaFiltrada = new List<Articulo>();
                    listaFiltrada = ((List<Articulo>)Session["listaArticulos"]).FindAll(a =>
                        a.Nombre.ToLower().Contains(txtBusqueda.Text.ToLower()) ||
                        a.Marca.Nombre.ToLower().Contains(txtBusqueda.Text.ToLower()) ||
                        a.Categoria.Nombre.ToLower().Contains(txtBusqueda.Text.ToLower())
                        );
                    Session["listaMostrada"] = listaFiltrada;
                    cargarListadoPorPagina(listaFiltrada, false);
                }
            }
            
        }

        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["paginaActual"] = 1;

            int codigo = int.Parse(ddlCategorias.SelectedItem.Value);
            List<Articulo> listaFiltrada = (List<Articulo>)Session["listaMostrada"];
            Session.Add("listaFiltradaPorCategoria", listaFiltrada);
            if (codigo != 0)
            {
                listaFiltrada = ((List<Articulo>)Session["listaMostrada"]).FindAll(a => a.Categoria.Codigo == codigo);
                Session["listaFiltradaPorCategoria"] = listaFiltrada;
            }

            cargarListadoPorPagina(listaFiltrada, true);

                //actualiza filtro de marcas
                ddlMarcas.DataSource = ((List<Marca>)Session["listaMarcas"]).FindAll(m => listaFiltrada.Any(a => a.Marca.Codigo == m.Codigo)||m.Codigo==0);
                ddlMarcas.DataBind();
        }

        protected void ddlMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo = int.Parse(ddlMarcas.SelectedItem.Value);
            
            Session["paginaActual"] = 1;
            if(codigo == 0)
            {

                cargarListadoPorPagina((List<Articulo>)Session["listaFiltradaPorCategoria"], true);
            }
            else
            {
                List<Articulo> listaFiltrada = ((List<Articulo>)Session["listaFiltradaPorCategoria"]).FindAll(a => a.Marca.Codigo == codigo);
                cargarListadoPorPagina(listaFiltrada, true);
            }

        }

        protected void btnBusqueda_Click(object sender, EventArgs e)
        {
            filtrarCatalogo();            
        }

        public void btn_Restablecer(object sender, EventArgs e)
        {
            
            Session["paginaActual"] = 1;
            txtBusqueda.Text = "";
            Response.Redirect("Catalogo.aspx");
            //listarCatalogo();

            //ddlCategorias.DataSource = ((List<Categoria>)Session["listaCategorias"]).FindAll(c => ((List<Articulo>)Session["listaMostrada"]).Any(a => a.Categoria.Codigo == c.Codigo) || c.Codigo == 0);
            //ddlCategorias.SelectedItem.Value = "0";
            //Session["listaFiltradaPorCategoria"] = Session["listaMostrada"];
            //ddlCategorias.DataBind();

            //ddlMarcas.DataSource = ((List<Marca>)Session["listaMarcas"]).FindAll(m => ((List<Articulo>)Session["listaMostrada"]).Any(a => a.Marca.Codigo == m.Codigo) || m.Codigo == 0);
            //ddlMarcas.SelectedItem.Value = "0";
            //ddlMarcas.DataBind();
        }

        protected void pagerRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                int pagina = Convert.ToInt32(e.CommandArgument);
                Session["paginaActual"] = pagina;
                cargarListadoPorPagina((List<Articulo>)Session["listaMostrada"], false);
            }
        }

    }
}