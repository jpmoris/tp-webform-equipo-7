<%@ Page Title="" Language="C#" MasterPageFile="~/AppMaster.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="tp_webform_equipo_7.Catalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-3">
    <div class="row">
        
        <!-- sidebar -->
      <div class="col-md-3">

        <h4>Filtros</h4>
        <div class="mb-3">
          <label for="rangoPrecios" class="form-label">Rango de precios</label>
          <input type="range" class="form-range" id="rangoPrecios" min="0" max="100" step="10" >
        </div>
        <!-- filtro categorias -->
        <div class="mb-3">
          <label for="categoria" class="form-label">Categoría</label>
          <asp:DropDownList runat="server" class="form-select" id="ddlCategorias" AutoPostBack="true" OnSelectedIndexChanged="ddlCategorias_SelectedIndexChanged">   
              
          </asp:DropDownList>
        </div>

        <!-- filtro marcas -->
        <div class="mb-3">
          <label for="marcas" class="form-label">Marca</label>

          <asp:DropDownList runat="server" class="form-select" id="ddlMarcas">
              
          </asp:DropDownList>
        </div>

      </div>
        <!-- fin sidebar -->

      <div class="col-md-9">

        <h2>Productos</h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                <div class="row">
                     <asp:Repeater runat="server" id="cardRepeater">
                         <ItemTemplate>
                            <div class="col-md-4">
                                <!-- producto -->
                                <div class="card">
                                  <div class="card-body">
                                    <a href="Producto.aspx?id=<%#Eval("Id")%>" style="text-decoration:none; color:inherit">
                                        <img src="<%#Eval("Imagenes[0]") %>" class="card-img-top" alt="Imagen destacada">
                                        <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                        <p class="card-text fs-5 fw-bold"><%#Eval("Precio")%> 
                                <!--    <span class="badge bg-danger m-2 p-lg-2">Oferta</span>      -->
                                        </p>
                                        <a class="btn btn-primary" runat="server" href="Producto.aspx" role="button">Ver producto</a>
                                    </a>
                                  </div>
                                </div>
                                <!-- fin producto-->
                            </div>
                         </ItemTemplate>
                     </asp:Repeater>
                </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        <nav aria-label="Navegación de página">
          <ul class="pagination mt-3 mb-3">
            <li class="page-item"><a class="page-link" href="#">Anterior</a></li>
            <li class="page-item active"><a class="page-link" href="#">1</a></li>
            <li class="page-item"><a class="page-link" href="#">2</a></li>
            <li class="page-item"><a class="page-link" href="#">3</a></li>
            <li class="page-item"><a class="page-link" href="#">Siguiente</a></li>
          </ul>
        </nav>
      </div>
    </div>
  </div>
</asp:Content>
