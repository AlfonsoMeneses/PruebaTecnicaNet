using AutoMapper;
using PruebaTecnicaNet.Contract.Contracts;
using PruebaTecnicaNet.Contract.Models;
using PruebaTecnicaNet.Domain;
using PruebaTecnicaNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNet.Business.Service
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly PruebaTecnicaNetSqlContext _context;

        public OrderService(PruebaTecnicaNetSqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public OrderDto Create(OrderDto order)
        {
            Order newOrder = _mapper.Map<Order>(order);

            try
            {
                _context.Database.BeginTransaction();

                newOrder.OrderNumber = GetNewOrderName;

                newOrder.TotalAmount = order.Items.Sum(oi => oi.Quantity * oi.UnitPrice);
                
                _context.Orders.Add(newOrder);

                _context.SaveChanges();

                var orderItems = _mapper.Map<List<OrderItem>>(order.Items);

                orderItems.ForEach(oi => oi.OrderId = newOrder.OrderId);

                _context.OrderItems.AddRange(orderItems);

                _context.SaveChanges();

                _context.Database.CommitTransaction();

                return _mapper.Map<OrderDto>(newOrder);
                
            }
            catch (Exception)
            {
                _context.Database.RollbackTransaction();
                throw;
            }
        }

        public IList<OrderDto> GetAll()
        {
            return _mapper.Map<List<OrderDto>>(_context.Orders.ToList());
        }

        private string GetNewOrderName
        {
            get
            {
                var actualDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

                var lastOrder = _context.Orders.OrderByDescending(o => o.OrderId)
                                               .FirstOrDefault(o => o.OrderDate > actualDate);

                var orderNumber = Int32.Parse(lastOrder.OrderNumber);

                orderNumber++;

                string orderFormat = "{0,10:0000000000.##}";

                return string.Format(orderFormat, orderNumber);
            }
        }
    }
}
