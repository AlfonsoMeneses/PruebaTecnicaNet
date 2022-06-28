using AutoMapper;
using PruebaTecnicaNet.Contract.Models;
using PruebaTecnicaNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNet.Business.Mapper
{
    public class DtoMapProfile: Profile
    {
        public DtoMapProfile()
        {
            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>();

            CreateMap<OrderItemDto, OrderItem>();
            CreateMap<OrderItem, OrderItemDto>();

            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();

            CreateMap<Supplier, SupplierDto>();
            CreateMap<SupplierDto, Supplier>();

            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();

            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();
        }
    }
}
