using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PruebaTecnicaNet.Contract.Contracts;
using PruebaTecnicaNet.Contract.Models;
using PruebaTecnicaNet.Domain;

namespace PruebaTecnicaNet.Business.Service
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly PruebaTecnicaNetSqlContext _context;

        public ProductService(PruebaTecnicaNetSqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ProductDto Create(ProductDto product)
        {
            throw new NotImplementedException();
        }

        public ProductDto Delete(int productId)
        {
           var product = _context.Products.FirstOrDefault(p => !p.IsDiscontinued && p.ProductId == productId);
            if (product != null)
            {
                product.IsDiscontinued = true;
                _context.SaveChanges();

            }

            return _mapper.Map<ProductDto>(product);
        }

        public IList<ProductDto> GetAll()
        {
            var lstProducts = _context.Products.Where(p=>!p.IsDiscontinued).ToList();

            return _mapper.Map<List<ProductDto>>(lstProducts);
        }

        public ProductDto GetProductByID(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => !p.IsDiscontinued && p.ProductId == productId);

            return _mapper.Map<ProductDto>(product);
        }

        public ProductDto GetProductByName(string name)
        {
            var product = _context.Products.FirstOrDefault(p => !p.IsDiscontinued && p.ProductName.Contains(name));

            return _mapper.Map<ProductDto>(product);
        }

        public IList<ProductDto> GetProducts(string name)
        {
            var lstProduct = _context.Products.Where(p => !p.IsDiscontinued && p.ProductName.Contains(name));

            return _mapper.Map<List<ProductDto>>(lstProduct);
        }

        public ProductDto Update(int productId, ProductDto product)
        {
            var selectProduct = _context.Products.FirstOrDefault(p => !p.IsDiscontinued && p.ProductId == productId);

            if (selectProduct != null)
            {
                selectProduct.ProductName = product.ProductName;
                selectProduct.UnitPrice = product.UnitPrice;
                selectProduct.IsDiscontinued = product.IsDiscontinued;
                selectProduct.SupplierId = product.SupplierId;

                _context.SaveChanges();

                return _mapper.Map<ProductDto>(selectProduct);
            }

            return null;

        }
    }
}
