using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PruebaTecnicaNet.Contract.Contracts;
using PruebaTecnicaNet.Contract.Models;
using PruebaTecnicaNet.Domain;
using PruebaTecnicaNet.Domain.Entities;

namespace PruebaTecnicaNet.Business.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly PruebaTecnicaNetSqlContext _context;
        public CustomerService(PruebaTecnicaNetSqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CustomerDto Create(CustomerDto customer)
        {
            var newCustomer = _mapper.Map<Customer>(customer);
            _context.Customers.Add(newCustomer);
            _context.SaveChanges();

            return _mapper.Map<CustomerDto>(newCustomer);
        }

        public IList<CustomerDto> GetAll()
        {
            var lstCustomers = _context.Customers.ToList();

            return _mapper.Map<List<CustomerDto>>(lstCustomers);
        }

        public CustomerDto GetByID(int customerId)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);

            return _mapper.Map<CustomerDto>(customer);
        }

        public CustomerDto GetByName(string name)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerName.Contains(name));

            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
