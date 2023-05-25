<%@ Page Title="" Language="C#" MasterPageFile="~/AppMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="tp_webform_equipo_7.Carrito" %>
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
                <th width="25" scope="col">Cantidad</th>
                <th scope="col">Subtotal</th>
                <th scope="col"></th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>
                  <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png" alt="Imagen del producto" width="100" class="img-thumbnail">
                  Nombre del producto
                </td>
                <td>$100</td>
                <td><input type="number" class="form-control" value="1"></td>
                <td>$100</td>
                <td><span class="badge bg-danger">X</span></td>
              </tr>
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
        <h5 class="mb-4">Total con envío: $150000</h5>
        <button class="btn btn-primary btn-block" type="button">Finalizar compra</button>
        <button class="btn btn-link btn-block" type="button">Seguir comprando</button>
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
