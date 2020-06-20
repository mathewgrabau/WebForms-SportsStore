using SportsStore.Models;
using SportsStore.Models.Repository;
using SportsStore.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;

namespace SportsStore.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private Repository _repo = new Repository();
        private int _pageSize = 4;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int selectedProductId;
                if (int.TryParse(Request.Form["add"], out selectedProductId))
                {
                    Product selectedProduct = _repo.Products.Where(p => p.ProductID == selectedProductId).FirstOrDefault();
                    if (selectedProduct != null)
                    {
                        Session.GetCart().AddItem(selectedProduct, 1);
                        Session.Set( SessionKey.RETURN_URL, Request.RawUrl);

                        Response.Redirect(RouteTable.Routes.GetVirtualPath(null, "cart", null).VirtualPath);
                    }
                }
            }                                  
        }

        public IEnumerable<Product> GetProducts()
        {
            return FilterProducts().OrderBy(p=>p.ProductID).Skip((CurrentPage - 1) * _pageSize).Take(_pageSize);
        }

        protected int CurrentPage
        {
            get
            {
                int page = GetPageFromRequest();
                return page > MaxPage ? MaxPage : page;
            }
        }

        protected int MaxPage
        {
            get
            {
                int productCount = FilterProducts().Count();
                return (int)Math.Ceiling((decimal)productCount / _pageSize);
            }
        }

        private IEnumerable<Product> FilterProducts()
        {
            IEnumerable<Product> products = _repo.Products;
            string category = (string)RouteData.Values["category"] ?? Request.QueryString["category"];
            return category == null ? products : products.Where(p => p.Category == category);
        }

        private int GetPageFromRequest()
        {
            int page;
            // Pull from either route data or fallback to the query string.
            string requestValue = (string)RouteData.Values["page"] ?? Request.QueryString["page"];
            return requestValue != null && int.TryParse(requestValue, out page) ? page : 1;
        }
    }
}