using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Web;
using System.Web.Security.AntiXss;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_webform_equipo_7
{
    public partial class Carrito : System.Web.UI.Page
    {
        public List<Modelo.Carrito> carrito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["carrito"] == null && Request.QueryString["id"] == null) Response.Redirect("~/");
            if (!Page.IsPostBack)
            {
                loadCarrito();
            }
        }

        protected void loadCarrito()
        {
            //try
            //{
                List<Articulo> articulos = new List<Articulo>();
                Articulo articulo = new Articulo();
                carrito = (List<Modelo.Carrito>)Session["carrito"];
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    int cant = int.Parse(Request.QueryString["cant"]);
                    articulos = (List<Articulo>)Session["listaArticulos"];
                    articulo = articulos.Find(x => x.Id == id);
                    if (carrito == null)
                    {
                        carrito = new List<Modelo.Carrito>();
                        Modelo.Carrito aux = new Modelo.Carrito(articulo, cant);

                        carrito.Add(aux);
                        Session.Add("carrito", carrito);
                    }
                    else
                    {
                        Modelo.Carrito aux = carrito.Find(x => x.articulo.Id == id);
                        if (aux == null)
                        {
                            aux = new Modelo.Carrito(articulo, cant);
                            carrito.Add(aux);
                            Session.Add("carrito", carrito);
                        }
                        else if (aux.cantidad != cant)
                        {
                            aux.cantidad = cant;
                            carrito[carrito.IndexOf(aux)] = aux;
                            Session.Add("carrito", carrito);
                        }
                    }
                }

                if (carrito != null)
                {
                    repeaterCarrito.DataSource = carrito;
                    repeaterCarrito.DataBind();
                    decimal total = 0;
                    foreach (var item in carrito)
                    {
                        decimal aux = item.articulo.Precio * item.cantidad;
                        total += aux;
                    }
                    lblTotal.Text = total.ToString();
                }
                //else
                //{
                //    Response.Redirect("~/");
                //}
            //}
            //catch (Exception ex) { throw new Exception(ex.Message); }
        }

        protected void repeaterCarrito_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int itemId = Convert.ToInt32(e.CommandArgument);
                carrito = (List<Modelo.Carrito>)Session["carrito"];
                Modelo.Carrito aux = carrito.Find(x => x.articulo.Id == itemId);
                if (aux != null)
                {
                    carrito.Remove(aux);
                    Session.Add("carrito", carrito);
                    repeaterCarrito.DataSource = carrito;
                    repeaterCarrito.DataBind();
                }
            }
        }
    }
}