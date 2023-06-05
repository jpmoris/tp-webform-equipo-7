<%@ Page Title="" Language="C#" MasterPageFile="~/AppMaster.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="tp_webform_equipo_7.Catalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-3">
    <div class="row">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        
        <!-- sidebar -->
      <div class="col-md-3">

          <div class="d-flex justify-content-between">

          <h4>Filtros</h4>
          <asp:Button ID="Button1" OnClick="btn_Restablecer" cssclass="btn btn-outline-primary" text="Restablecer" runat="server" />
          </div>
        <!-- orden 
        <div class="mb-3">
          <label for="order" class="form-label">Ordenar por</label>
          <asp:DropDownList runat="server" class="form-select" id="order" AutoPostBack="true">   
          </asp:DropDownList>
        </div>
            -->
        <!-- filtro categorias -->
        <div class="mb-3">
          <label for="categoria" class="form-label">Categoría</label>
          <asp:DropDownList runat="server" class="form-select" id="ddlCategorias" AutoPostBack="true" OnSelectedIndexChanged="ddlCategorias_SelectedIndexChanged">   
              
          </asp:DropDownList>
        </div>

        <!-- filtro marcas -->
        <div class="mb-3">
          <label for="marcas" class="form-label">Marca</label>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                  <asp:DropDownList runat="server" class="form-select" id="ddlMarcas" AutoPostBack="true" OnSelectedIndexChanged="ddlMarcas_SelectedIndexChanged">
              
                  </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

      </div>
        <!-- fin sidebar -->

        <!-- buscador-->
      <div class="col-md-9">
        <div class="row">
            <label for="txtBusqueda" class="form-label">Búsqueda</label>
            <div class="input-group mb-3">
              <asp:textBox runat="server" type="text" class="form-control" id="txtBusqueda" placeholder="Buscar producto"></asp:textBox>
              <asp:button runat="server" class="btn btn-primary" type="button" id="btnBusqueda" OnClick="btnBusqueda_Click" Text="Buscar"></asp:button>
                </div>
        </div>
         
          <!-- catalogo-->
        <h2>Productos</h2>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                <div class="row">
                     <asp:Repeater runat="server" id="cardRepeater">
                         <ItemTemplate>
                            <div class="col-md-4">
                                <!-- producto -->
                                <div class="card my-3">
                                  <div class="card-body">
                                    <a href="Producto.aspx?id=<%#Eval("Id")%>" style="text-decoration:none; color:inherit">
                                        <img src="<%#Eval("Imagenes[0]") %>" class="card-img-top" alt="Imagen destacada">
                                        <h5 class="card-title py-2"><%#Eval("Nombre") %></h5>
                                        <p class="card-text fs-5 fw-bold">$ <%#Eval("Precio")%> 
                                <!--    <span class="badge bg-danger m-2 p-lg-2">Oferta</span>      -->
                                        </p>
                                        <a class="btn btn-primary mt-2" href="Producto.aspx?id=<%#Eval("id")%>">Ver producto</a>
                                    </a>
                                  &nbsp;&nbsp;</div>
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
            <asp:Repeater ID="pagerRepeater" runat="server">
              <ItemTemplate>
                <li class='<%# Container.DataItem.Equals(Session["paginaActual"]) ? "page-item active" : "page-item" %>'>
                  <a class="page-link" href='<%# $"?page={Container.DataItem}" %>'><%# Container.DataItem %></a>
                </li>
              </ItemTemplate>
            </asp:Repeater>
          </ul>
        </nav>

      </div>
    </div>
  </div>
</asp:Content>
