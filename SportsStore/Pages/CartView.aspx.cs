using SportsStore.Models;
using SportsStore.Models.Repository;
using SportsStore.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Pages
{
    public partial class CartView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Repository repo = new Repository();
                int productId;
                if (int.TryParse(Request.Form["remove"], out productId))
                {
                    Product productToRemove = repo.Products.Where(p => p.ProductID == productId).FirstOrDefault();
                    if (productToRemove != null)
                    {
                        Session.GetCart().RemoveItem(productToRemove);
                    }
                }
            }
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