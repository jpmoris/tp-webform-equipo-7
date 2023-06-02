<%@ Page Title="" Language="C#" MasterPageFile="~/AppMaster.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="tp_webform_equipo_7.Producto" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@glidejs/glide@3.4.1/dist/css/glide.core.min.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


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
          <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
            <ol class="carousel-indicators">
              <li data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active"></li>
              <li data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1"></li>
              <li data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2"></li>
            </ol>
            <div class="carousel-inner">
              <div class="carousel-item active" data-bs-toggle="modal" data-bs-target="#modalImagen1">
                <img src="https://images.fravega.com/f300/44abb86f01c772ff7e9810450c9aa1a9.jpg.webp" alt="Imagen 1" class="d-block w-100">
              </div>
              <div class="carousel-item" data-bs-toggle="modal" data-bs-target="#modalImagen2">
                <img src="https://images.fravega.com/f1000/a943fd097b785f6e522e909127146e42.jpg.webp" alt="Imagen 2" class="d-block w-100">
              </div>
              <div class="carousel-item" data-bs-toggle="modal" data-bs-target="#modalImagen3">
                <img src="https://images.fravega.com/f120/291b79ca3afa4c3fdb09093a584c1224.jpg.webp" alt="Imagen 3" class="d-block w-100">
              </div>
            </div>
            <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-bs-slide="prev">
              <span class="carousel-control-prev-icon" aria-hidden="true"></span>
              <span class="visually-hidden">Anterior</span>
            </a>
            <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-bs-slide="next">
              <span class="carousel-control-next-icon" aria-hidden="true"></span>
              <span class="visually-hidden">Siguiente</span>
            </a>
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


  </div>
</div>


</asp:Content>
