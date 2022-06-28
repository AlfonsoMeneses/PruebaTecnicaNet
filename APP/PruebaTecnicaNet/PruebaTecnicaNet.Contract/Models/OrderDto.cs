using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNet.Contract.Models
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public IList<OrderItemDto> Items { get; set; }

    }
}
