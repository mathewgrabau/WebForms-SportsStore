using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace SportsStore.Models.Repository
{
    public class Repository
    {
        private EFDbContext _context = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get => _context.Products;
        }

        public IEnumerable<Order> Orders
        {
            get => _context.Orders.Include(o => o.OrderLines.Select(ol => ol.Product));
        }

        public void SaveOrder(Order order)
        {
            if (order.OrderId == 0)
            {
                order = _context.Orders.Add(order);

                foreach (OrderLine line in order.OrderLines)
                {
                    _context.Entry(line.Product).State = System.Data.Entity.EntityState.Modified;
                }
            }
            else
            {
                Order existing = _context.Orders.Find(order.OrderId);
                if (existing != null)
                {
                    existing.Name = order.Name;
                    existing.Line1 = order.Line1;
                    existing.Line2 = order.Line2;
                    existing.Line3 = order.Line3;
                    existing.City = order.City;
                    existing.State = order.State;
                    existing.GiftWrap = order.GiftWrap;
                    existing.Dispatched = order.Dispatched;
                }
            }

            _context.SaveChanges();
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                product = _context.Products.Add(product);
            }
            else
            {
                Product productRecord = _context.Products.Find(product.ProductID);
                if (productRecord != null)
                {
                    productRecord.Name = product.Name;
                    productRecord.Description = product.Description;
                    productRecord.Price = product.Price;
                    productRecord.Category = product.Category;
                }
            }

            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            // TODO I don't like this implementation! Better to archive so it doesn't
            // impact the records in the system.
            IEnumerable<Order> orders = _context.Orders.Include(o => o.OrderLines.Select(ol => ol.Product))
                .Where(o => o.OrderLines.Count(ol => ol.Product.ProductID == product.ProductID) > 0).ToArray();

            foreach (Order order in orders)
            {
                _context.Orders.Remove(order);
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}