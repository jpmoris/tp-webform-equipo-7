using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace tp_webform_equipo_7
{
    public partial class Producto : System.Web.UI.Page
    {
        public int idSeleccionado { get; set; }
        public Articulo aux = new Articulo();

        private string placeholderImg = "https://www.charitycomms.org.uk/wp-content/uploads/2019/02/placeholder-image-square.jpg";
        ArticuloNegocio negocioArt = new ArticuloNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                idSeleccionado = Convert.ToInt32(Request.QueryString["id"]);
                aux = negocioArt.buscarArticulo(idSeleccionado);
                if (aux != null)
                {
                    lblProductoMarca.Text = aux.Marca.Nombre;
                    lblNombreProducto.Text = aux.Nombre;
                    lblProductoTitulo.Text = aux.Nombre;
                    lblProductoDescripcion.Text = aux.Descripcion;
                    hrefCategoria.Text = aux.Categoria.Nombre;
                    lblProductoPrecio.Text = "$" + aux.Precio.ToString();
                    listarImagenes();
                }
            }
            else
            {

                // mostrar buscador y botón
                // comprobar si existe el ID.
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            idSeleccionado = Convert.ToInt32(Request.QueryString["id"]);
            Response.Redirect($"~/Carrito.aspx?id={idSeleccionado}&cant={tbxCantidad.Text}");
        }

        protected void btnBusqueda_Click(object sender, EventArgs e)
        {
            Response.Redirect($"~/Catalogo.aspx?busqueda={txtBusqueda.Text}");
        }

        public void listarImagenes()
        {
            ImagenNegocio negocioImg = new ImagenNegocio();
            
            List<Imagen> imagenes = negocioImg.listarPorIdArticulo(aux.Id);

            List<string> imagenesUrl = new List<string>();
            if (imagenes.Count == 0)
            {
                imagenesUrl.Add(placeholderImg);
            }
            else
            {
                foreach (Imagen imagen in imagenes) {
                    if(negocioImg.comprobarUrl(imagen.url))
                    {
                        imagenesUrl.Add(imagen.url);
                    } 
                    else
                    {
                        imagenesUrl.Add(placeholderImg);
                    }
                }
            }
            aux.Imagenes = imagenesUrl;
        }
    }
}