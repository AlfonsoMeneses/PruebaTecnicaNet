using PruebaTecnicaNet.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNet.Contract.Contracts
{
    public interface ISupplierService
    {
        IList<SupplierDto> GetAll();
        SupplierDto GetProductByID(int supplierId);
        SupplierDto Create(SupplierDto supplier);
        SupplierDto Update(int supplierId, SupplierDto supplier);
        SupplierDto Delete(int supplierId);
    }
}
