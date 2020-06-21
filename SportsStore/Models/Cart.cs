using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.Models
{
    public class Cart
    {
        private List<CartLine> _lines = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine line = _lines.Where(p => product.ProductID == p.Product.ProductID).FirstOrDefault();

            // If we need to add it or it's already there
            if (line == null)
            {
                _lines.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveItem(Product product)
        {
            _lines.RemoveAll(l => product.ProductID == l.Product.ProductID);
        }

        public decimal CalculateTotal()
        {
            return _lines.Sum(l => l.Product.Price * l.Quantity);
        }

        public void Clear()
        {
            _lines.Clear();
        }

        public IEnumerable<CartLine> Lines => _lines;
    }
}