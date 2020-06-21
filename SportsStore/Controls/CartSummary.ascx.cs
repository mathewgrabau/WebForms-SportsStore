using SportsStore.Models;
using SportsStore.Pages.Helpers;
using System;
using System.Linq;
using System.Web.Routing;

namespace SportsStore.Controls
{
    public partial class CartSummary : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cart cart = Session.GetCart();
            csQuantity.InnerText = cart.Lines.Sum(l => l.Quantity).ToString();
            csTotal.InnerText = cart.CalculateTotal().ToString("c");
            csLink.HRef = RouteTable.Routes.GetVirtualPath(null, "cart", null).VirtualPath;
        }
    }
}