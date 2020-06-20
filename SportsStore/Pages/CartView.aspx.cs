using SportsStore.Models;
using SportsStore.Pages.Helpers;
using System;
using System.Collections.Generic;

namespace SportsStore.Pages
{
    public partial class CartView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<CartLine> GetCartLines()
        {
            return Session.GetCart().Lines;
        }

        public decimal CartTotal
        {
            get
            {
                return Session.GetCart().CalculateTotal();
            }
        }

        public string ReturnUrl
        {
            get
            {
                return Session.Get<string>(SessionKey.RETURN_URL);
            }
        }
    }
}