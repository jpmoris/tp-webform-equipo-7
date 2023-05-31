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
        private int itemsPorPagina = 20;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Articulo> listaArticulos = new List<Articulo>();
                // ... código para cargar los datos ...

                Session["listaArticulos"] = listaArticulos;
                FiltrarYMostrarArticulos();
            }
        }

        protected void btnBusqueda_Click(object sender, EventArgs e)
        {
            // ... código para filtrar los artículos según la búsqueda ...

            FiltrarYMostrarArticulos();
        }

        protected void cardRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // Solo muestra los datos si el elemento es de tipo Item
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Obtener el artículo actual del repeater
                Articulo articulo = (Articulo)e.Item.DataItem;

                // ... código para mostrar los datos del artículo en la tarjeta ...
            }
        }

        protected void dataPager_PreRender(object sender, EventArgs e)
        {
            FiltrarYMostrarArticulos();
        }

        private void FiltrarYMostrarArticulos()
        {
            List<Articulo> listaArticulos = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada = FiltrarArticulos(listaArticulos);

            int totalItems = listaFiltrada.Count;
            int paginaActual = dataPager.StartRowIndex / itemsPorPagina;
            int totalPaginas = (int)Math.Ceiling((double)totalItems / itemsPorPagina);

            if (paginaActual >= totalPaginas)
            {
                paginaActual = totalPaginas - 1;
                dataPager.SetPageProperties(paginaActual * itemsPorPagina, itemsPorPagina, true);
            }

            int startIndex = paginaActual * itemsPorPagina;
            int endIndex = Math.Min(startIndex + itemsPorPagina - 1, totalItems - 1);

            List<Articulo> listaMostrada = listaFiltrada.GetRange(startIndex, endIndex - startIndex + 1);
            cardRepeater.DataSource = listaMostrada;
            cardRepeater.DataBind();
        }

        private List<Articulo> FiltrarArticulos(List<Articulo> listaArticulos)
        {
            string busqueda = txtBusqueda.Text.ToLower();

            if (string.IsNullOrWhiteSpace(busqueda))
            {
                return listaArticulos;
            }

            List<Articulo> listaFiltrada = listaArticulos.FindAll(a =>
                a.Nombre.ToLower().Contains(busqueda) ||
                a.Marca.Nombre.ToLower().Contains(busqueda) ||
                a.Categoria.Nombre.ToLower().Contains(busqueda)
            );

            return listaFiltrada;
        }
    }

}