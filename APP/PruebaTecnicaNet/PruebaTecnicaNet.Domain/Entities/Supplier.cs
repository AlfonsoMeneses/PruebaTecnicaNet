using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaTecnicaNet.Domain.Entities
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
