using SportsStore.Models;
using SportsStore.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsStore.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private Repository _repo = new Repository();
        private int _pageSize = 4;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected IEnumerable<Product> GetProducts()
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