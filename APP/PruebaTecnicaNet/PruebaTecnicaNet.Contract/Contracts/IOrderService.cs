using PruebaTecnicaNet.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNet.Contract.Contracts
{
    public interface IOrderService
    {
        OrderDto Create(OrderDto order);

        IList<OrderDto> GetAll();
    }
}
