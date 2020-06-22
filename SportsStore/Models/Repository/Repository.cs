using System.Collections.Generic;
using System.Data.Entity;
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
    }
}