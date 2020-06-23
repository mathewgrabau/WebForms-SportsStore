using SportsStore.Models;
using SportsStore.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsStore.Pages.Admin
{
    public partial class Products : System.Web.UI.Page
    {
        private Repository _repository = new Repository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Product> GetProducts()
        {
            return _repository.Products;
        }

        public void DeleteProduct(int productId)
        {
            Product product = _repository.Products.Where(p => p.ProductID == productId).FirstOrDefault();
            if (product != null)
            {
                _repository.DeleteProduct();
            }
        }

    }
}