<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="SportsStore.Pages.Listing" MasterPageFile="~/Pages/Store.Master" %>
<%@ Import Namespace="System.Web.Routing" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <asp:Repeater runat="server" ItemType="SportsStore.Models.Product" SelectMethod="GetProducts">
            <ItemTemplate>
                <div class='item'>
                    <h3><%# Item.Name %></h3>
                    <%# Item.Description %>
                    <h4><%# Item.Price.ToString("c") %></h4>
                    <button name='add' type='submit' value='<%# Item.ProductID %>'>Add to cart</button>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="pager">
        <% for (int i = 1; i <= MaxPage; i++)
               {
                string path = RouteTable.Routes.GetVirtualPath(null, null, new RouteValueDictionary { { "page", i } }).VirtualPath;
                   Response.Write($"<a href='{path}' { (i == CurrentPage ? "class = 'selected'" : "") }>{i}</a>");
            }%>
    </div>
</asp:Content>