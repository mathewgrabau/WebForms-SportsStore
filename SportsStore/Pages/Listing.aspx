<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="SportsStore.Pages.Listing" MasterPageFile="~/Pages/Store.Master" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <%foreach (SportsStore.Models.Product prod in GetProducts())
            {
                Response.Write("<div class='item'>");
                Response.Write($"<h3>{prod.Name}</h3>");
                Response.Write(prod.Description);
                Response.Write($"<h4>{prod.Price:c}");
                Response.Write("</div>");
            }%>
    </div>
    <div class="pager">
        <% for (int i = 1; i <= MaxPage; i++)
            {
                Response.Write($"<a href='/Pages/Listing.aspx?page={i}' { (i == CurrentPage ? "class = 'selected'" : "") }>{i}</a>");
            }%>
    </div>
</asp:Content>