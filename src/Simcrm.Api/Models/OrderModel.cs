using System;

namespace Simcrm.Api.Controllers
{
    public class OrderModel : IOrder
    {
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public string ProductCode { get; set;  }
    }
}