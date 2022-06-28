using PruebaTecnicaNet.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNet.Contract.Contracts
{
    public interface ICustomerService
    {
        IList<CustomerDto> GetAll();
        CustomerDto GetByID(int customerId);
       
        CustomerDto GetByName(string name);

        CustomerDto Create(CustomerDto customer);
    }
}
