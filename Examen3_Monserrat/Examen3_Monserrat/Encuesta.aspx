<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Encuesta.aspx.cs" Inherits="Examen3_Monserrat.Encuesta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
    <h1> Formulario a llenar </h1>
    <p>&nbsp;</p>
</div>
<div>
    <br />
    <br />
    <asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
        CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
        RowStyle-CssClass="rows" AllowPaging="True" />

    <br />
    <br />
    <br />

</div>
<div class="container text-center">
    Nombre de participante: <asp:TextBox ID="tnombre" class="form-control" runat="server"></asp:TextBox>
    
     <div class="mb-3">
      Fecha de nacimiento: <asp:TextBox ID="tnacimiento" class="form-control datepicker" runat="server"></asp:TextBox>
     
 </div>
        Correo Electronico: <asp:TextBox ID="tcorreo" class="form-control" runat="server"></asp:TextBox>
   
    <label for="exampleInputPassword1" class="form-label">Partido Politico</label>
<asp:DropDownList ID="DropDownList1" class="form-control" runat="server"></asp:DropDownList>

</div>
<div class="container text-center">

    <asp:Button ID="Button1" class="btn btn-outline-primary" runat="server" Text="Agregar" OnClick="Button1_Click" />
  
    
    </div>

</asp:Content>

