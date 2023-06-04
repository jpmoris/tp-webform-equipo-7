<%@ Page Title="" Language="C#" MasterPageFile="~/AppMaster.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="tp_webform_equipo_7.Producto" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@glidejs/glide@3.4.1/dist/css/glide.core.min.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%
     if (aux != null)
     {
     %>

    <div class="container mt-3">
     <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
          <li class="breadcrumb-item"><a href="Catalogo.aspx">Inicio</a></li>
          <li class="breadcrumb-item">
              <asp:HyperLink ID="hrefCategoria" text="hey" href="Catalogo.aspx" runat="server">
              </asp:HyperLink>
          </li>
          <li class="breadcrumb-item active" aria-current="page">
              <asp:Label ID="lblNombreProducto" runat="server" Text="Nombre Producto"></asp:Label>
           </li>
        </ol>
      </nav>
    </div>

  <div class="container">
    <div class="row h-100">
      <div class="col-md-5">
          <div id="carouselImgProducto" class="carousel carousel-dark slide" data-bs-ride="carousel">
            <div class="carousel-indicators">
                <% int index = 0; %>
                <% foreach (string img in aux.Imagenes) %>
                <% { %>
                        <%if (index == 0) %>
                        <%{%>
                        <button data-bs-target="#carouselImgProducto" data-bs-slide-to="<% Response.Write(index);%>"  class="active"></button>
                        <%}
                        else
                        { %>
                        <button data-bs-target="#carouselImgProducto" data-bs-slide-to="<% Response.Write(index);%>" "></button>

                      <%} %>
                <%      index++; %>
                <% } %>
            </div>
              <!-- carousel -->
            <div class="carousel-inner" style="height: 500px;">
                <%index = 0; %>
            <% foreach (string img in aux.Imagenes) %>
            <% { %>
                    <%
                      if (index == 0)
                      { %>
                      <div class="carousel-item active" data-bs-toggle="modal" data-bs-target="#modalImagen1">
                        <img src="<% Response.Write(img); %>" alt="Imagen <% Response.Write(index+1); %>" class="d-block w-100">
                      </div>
                    <%}
                      else
                      { %>
                      <div class="carousel-item" data-bs-toggle="modal" data-bs-target="#modalImagen1">
                        <img src="<% Response.Write(img); %>" alt="Imagen <% Response.Write(index+1); %>" class="d-block w-100">
                      </div>
                  <%  } %>
                <%  index++;
               } %>
            </div>
            <%if(aux.Imagenes.Count > 1) %>
            <% { %>
            <button class="carousel-control-prev" href="#carouselImgProducto" role="button" data-bs-slide="prev">
              <span class="carousel-control-prev-icon" aria-hidden="true"></span>
              <span class="visually-hidden">Anterior</span>
            </button>
            <a class="carousel-control-next" href="#carouselImgProducto" role="button" data-bs-slide="next">
              <span class="carousel-control-next-icon" aria-hidden="true"></span>
              <span class="visually-hidden">Siguiente</span>
            </a>
              <% } %>
          </div>
      </div>

      <div class="col-md-6 offset-md-1">
          <asp:Label ID="lblProductoMarca" runat="server" CssClass="badge bg-danger m-2 p-lg-2 fs-6" Text="Marca"></asp:Label>
          <h1>
            <asp:Label ID="lblProductoTitulo" runat="server" Text="Nombre Producto"></asp:Label>
          </h1>
          <p>
             <asp:Label ID="lblProductoDescripcion" runat="server" Text="Nombre Producto"></asp:Label>
          </p>
            <p class="card-text fs-2 fw-bold">
                <asp:Label ID="lblProductoPrecio" runat="server" Text="$100"></asp:Label>
            </p>
        <div class="input-group mb-3" style="max-width: 200px;">
            <asp:TextBox  type="number" class="form-control" ID="tbxCantidad" runat="server">0</asp:TextBox>
          <asp:Button id="btnAgregar" Text="Agregar al carrito" CssClass="btn btn-success" runat="server" OnClick="btnAgregar_Click"/>
        </div>
      </div>

     <%
     } else
            {
        %>
        <div class="container my-5 py-3">
          <div class="p-5 text-center bg-body-tertiary rounded-3">
            <div class="text-center">
              <img class="img-fluid" style="width: 350px;" src="https://www.breathearomatherapy.com/assets/images/global/no-product.png" alt="Producto inválido" />
            </div>
              <h1 class="text-body-emphasis mt-3">No se encontró el producto.</h1>
            <p class="col-lg-8 mx-auto fs-5 text-muted">
                El producto es inválido o no existe. Por favor, intenta una nueva búsqueda:
            </p>
            <!-- buscador-->
            <div class="col-md-6 mx-auto">
                <div class="row">
                    <div class="input-group mb-3">
                      <asp:textBox runat="server" type="text" class="form-control" id="txtBusqueda" placeholder="Buscar producto"></asp:textBox>
                      <asp:button runat="server" class="btn btn-primary" type="button" id="btnBusqueda" OnClick="btnBusqueda_Click" Text="Buscar"></asp:button>
                    </div>
                </div>
            </div>
          </div>
       </div>

        <%
            }
    %>
  </div>
</div>


</asp:Content>
