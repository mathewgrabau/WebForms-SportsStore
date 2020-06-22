using SportsStore.Models;
using SportsStore.Models.Repository;
using SportsStore.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Web.ModelBinding;

namespace SportsStore.Pages
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkoutForm.Visible = true;
            checkoutMessage.Visible = false;

            if (IsPostBack)
            {
                Order order = new Order();
                // The FormValueProvider requires .NET 4.5
                if (TryUpdateModel(order, new FormValueProvider(ModelBindingExecutionContext)))
                {
                    order.OrderLines = new List<OrderLine>();

                    Cart cart = Session.GetCart();

                    foreach (CartLine cartLine in cart.Lines)
                    {
                        order.OrderLines.Add(new OrderLine
                        {
                            Order = order,
                            Product = cartLine.Product,
                            Quantity = cartLine.Quantity
                        });
                    }

                    new Repository().SaveOrder(order);
                    cart.Clear();

                    checkoutForm.Visible = false;
                    checkoutMessage.Visible = true;
                }
            }
        }
    }
}