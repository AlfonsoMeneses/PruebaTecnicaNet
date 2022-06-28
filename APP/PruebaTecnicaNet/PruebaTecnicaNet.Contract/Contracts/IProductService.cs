using PruebaTecnicaNet.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNet.Contract.Contracts
{
    public interface IProductService
    {
        IList<ProductDto> GetAll();
        ProductDto GetProductByID(int productId);
        ProductDto Create(ProductDto product);
        ProductDto Update(int productId,ProductDto product);
        ProductDto Delete(int productId);
        ProductDto GetProductByName(string name);
        IList<ProductDto> GetProducts(string name);

    }
}
