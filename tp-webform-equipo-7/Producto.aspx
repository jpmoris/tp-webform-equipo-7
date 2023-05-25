<%@ Page Title="" Language="C#" MasterPageFile="~/AppMaster.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="tp_webform_equipo_7.Producto" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@glidejs/glide@3.4.1/dist/css/glide.core.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



    <div class="container mt-3">
     <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
          <li class="breadcrumb-item"><a href="#">Inicio</a></li>
          <li class="breadcrumb-item"><a href="#">Categoría</a></li>
          <li class="breadcrumb-item active" aria-current="page">Producto</li>
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
          <span class="badge bg-danger m-2 p-lg-2">Oferta</span>
        <h2>Título del Producto</h2>
          <p>Descripción corta del producto.</p>
            <p class="card-text fs-2 fw-bold">$100 
             <small class="text-decoration-line-through">$120</small>
             
            </p>
        <div class="input-group mb-3" style="max-width: 200px;">
          <input type="number" class="form-control" placeholder="Cantidad" aria-label="Cantidad" aria-describedby="button-addon2">
          <button class="btn btn-primary" type="button" id="button-addon2">Agregar al carrito</button>
        </div>
      </div>

    <ul class="nav nav-tabs" id="caracteristicas" role="tablist">
      <li class="nav-item" role="presentation">
        <button class="nav-link active" id="descripcion-larga-tab" data-bs-toggle="tab" data-bs-target="#descripcion-larga" type="button" role="tab" aria-controls="descripcion-larga" aria-selected="true">Descripción</button>
      </li>
      <li class="nav-item" role="presentation">
        <button class="nav-link" id="dimensiones-tab" data-bs-toggle="tab" data-bs-target="#dimensiones" type="button" role="tab" aria-controls="dimensiones" aria-selected="false">Dimensiones</button>
      </li>
      <li class="nav-item" role="presentation">
        <button class="nav-link" id="opiniones-tab" data-bs-toggle="tab" data-bs-target="#opiniones" type="button" role="tab" aria-controls="opiniones" aria-selected="false">Valoraciones</button>
      </li>
    </ul>
    <div class="tab-content mt-3" id="caracteristicasContent">
      <div class="tab-pane fade show active" id="descripcion-larga" role="tabpanel" aria-labelledby="descripcion-larga-tab">
        <p>Descripción larga del producto.</p>
      </div>
      <div class="tab-pane fade" id="dimensiones" role="tabpanel" aria-labelledby="dimensiones-tab">
        <p>Dimensiones del producto.</p>
      </div>
      <div class="tab-pane fade" id="opiniones" role="tabpanel" aria-labelledby="opiniones-tab">
        <p>Valoraciones de los clientes.</p>
      </div>
    </div>
  </div>
</div>


</asp:Content>
