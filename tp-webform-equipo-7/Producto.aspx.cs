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
        protected void Page_Load(object sender, EventArgs e)
        {
            idSeleccionado = Convert.ToInt32(Request.QueryString["id"]);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect($"~/Carrito.aspx?id={idSeleccionado}&cant={tbxCantidad.Text}");
        }
    }
}