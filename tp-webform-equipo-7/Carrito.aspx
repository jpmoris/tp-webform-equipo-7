<%@ Page Title="" Language="C#" MasterPageFile="~/AppMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="tp_webform_equipo_7.Carrito" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-3 mb-3">
        <div class="row">
            <div class="col-md-8">
                <h2 class="mt-3 mb-3">Tu carrito de compras</h2>


                <div class="table-responsive">
                    <table class="table">
                        <thead>
                            <tr>
                                <th scope="col">Producto</th>
                                <th scope="col">Precio Unitario</th>
                                <th scope="col">Cantidad</th>
                                <th scope="col">Subtotal</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody>
                <%if (carrito != null && carrito.Count() > 0)
                    {%>
                            <asp:Repeater runat="server" ID="repeaterCarrito" OnItemCommand="repeaterCarrito_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <img src="<%# Convert.ToString(Eval("articulo.Imagenes[0]")) %>" alt="Imagen del producto" width="100" class="img-thumbnail" onerror="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png">
                                            <%#Eval("articulo.Nombre") %>
                                        </td>
                                        <td style="vertical-align: middle"><%#Eval("articulo.Precio")%></td>

                                        <td style="vertical-align: middle">
                                            <%#Eval("cantidad")%>
                                        </td>

                                        <td style="vertical-align: middle"><%# Convert.ToDecimal(Eval("articulo.Precio")) * Convert.ToInt32(Eval("cantidad"))%></td>
                                        <td style="vertical-align: middle">
                                            <asp:Button runat="server" type="button" class="btn btn-danger" Text="X" CommandName="Eliminar" CommandArgument='<%#Eval("articulo.Id")%>' /></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
            <%} else {%>
                <td colspan="5">Todavia no hay items en tu carrito. <a href="Catalogo.aspx">Encontra los mejores productos!</a></td>
            <%}%>
                        </tbody>
                    </table>
                </div>
            </div>

            <div class="col-md-4">
                <h4 class="mt-5 mb-2">Envío</h4>
                <div class="mb-3">
                    <label for="provinciaSelect" class="form-label">Provincia</label>
                    <select class="form-select" id="provinciaSelect">
                        <option selected>Elegir provincia</option>
                        <option value="1">Buenos Aires</option>
                        <option value="2">Córdoba</option>
                        <option value="3">La Pampa</option>
                    </select>
                </div>
                <div class="mb-3">
                    <label for="ciudadSelect" class="form-label">Ciudad</label>
                    <select class="form-select" id="ciudadSelect">
                        <option selected>Elegir ciudad</option>
                        <option value="1">Ciudad 1</option>
                        <option value="2">Ciudad 2</option>
                        <option value="3">Ciudad 3</option>
                    </select>
                </div>
                <h5 class="mb-4">Total con envío: $
                    <asp:Label runat="server" ID="lblTotal">0</asp:Label>
                </h5>
                <button class="btn btn-primary btn-block" type="button">Finalizar compra</button>
                <a href="Catalogo.aspx">
                    <button class="btn btn-link btn-block" type="button">Seguir comprando</button></a>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class="col">
                <div class="coupon-section text-center py-5 p-0 mx-auto" style="background-color: #fff7da;">
                    <h3 class="mb-4">¿Tenés un cupón de descuento?</h3>
                    <div class="input-group w-50 mx-auto">
                        <input type="text" class="form-control" placeholder="Ingresá tu cupón">
                        <button class="btn btn-primary" type="button">Aplicar cupón</button>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
