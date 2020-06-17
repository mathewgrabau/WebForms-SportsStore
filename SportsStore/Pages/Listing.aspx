<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="SportsStore.Pages.Listing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sports Store</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%foreach (SportsStore.Models.Product prod in GetProducts())
                {
                    Response.Write("<div class='item'>");
                    Response.Write($"<h3>{prod.Name}</h3>");
                    Response.Write(prod.Description);
                    Response.Write($"<h4>{prod.Price:c}");
                    Response.Write("</div>");
                }%>
        </div>
    </form>
    <div>
        <% for (int i = 1; i <= MaxPage; i++)
            {
                Response.Write($"<a href='/Pages/Listing.aspx?page={i}' { (i == CurrentPage ? "class = 'selected'" : "") }>{i}</a>");
            }%>
    </div>
</body>
</html>
