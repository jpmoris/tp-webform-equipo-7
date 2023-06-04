using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_webform_equipo_7
{
    public partial class AppMaster : System.Web.UI.MasterPage
    {
        public int cantidad { get;set;}
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Modelo.Carrito> elementosCarrito = new List<Modelo.Carrito>();
            elementosCarrito = (List<Modelo.Carrito>)Session["carrito"];
            cantidad = 0;
            if (elementosCarrito != null )
            {
                cantidad = elementosCarrito.Count();
                lblCant.Text = cantidad.ToString();
            }
        }
    }
}