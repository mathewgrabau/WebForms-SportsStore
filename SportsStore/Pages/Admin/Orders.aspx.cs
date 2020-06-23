using SportsStore.Models;
using SportsStore.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsStore.Pages.Admin
{
    public partial class Orders : System.Web.UI.Page
    {
        private Repository _repository = new Repository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int dispatchId;
                if (int.TryParse(Request.Form["dispatch"], out dispatchId))
                {
                    Order order = _repository.Orders.Where(o => o.OrderId == dispatchId).FirstOrDefault();
                    if (order != null)
                    {
                        order.Dispatched = true;
                        _repository.SaveOrder(order);
                    }
                }
            }
        }

        public decimal Total(IEnumerable<OrderLine> orderLines)
        {
            decimal total = 0;
            foreach (OrderLine ol in orderLines)
            {
                total += ol.Product.Price * ol.Quantity;
            }

            return total;
        }

        public IEnumerable<Order> GetOrders([Control] bool showDispatched)
        {
            if (showDispatched)
            {
                return _repository.Orders;
            }
            else
            {
                return _repository.Orders.Where(o => !o.Dispatched);
            }
        }
    }
}