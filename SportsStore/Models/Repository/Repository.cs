using System.Collections.Generic;
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
    }
}