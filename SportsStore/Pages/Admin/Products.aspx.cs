using SportsStore.Models;
using SportsStore.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;

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

        public void UpdateProduct(int productID)
        {
            Product product = _repository.Products.Where(p => p.ProductID == productID).FirstOrDefault();
            if (product != null && TryUpdateModel(product, new FormValueProvider(ModelBindingExecutionContext)))
            {
                _repository.SaveProduct(product);
            }
        }

        public void DeleteProduct(int productId)
        {
            Product product = _repository.Products.Where(p => p.ProductID == productId).FirstOrDefault();
            if (product != null)
            {
                _repository.DeleteProduct(product);
            }
        }

        public void InsertProduct()
        {
            Product p = new Product();
            if (TryUpdateModel(p, new FormValueProvider(ModelBindingExecutionContext)))
            {
                _repository.SaveProduct(p);
            }
        }
    }
}