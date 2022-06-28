namespace PruebaTecnicaNet.Web.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public decimal? UnitPrice { get; set; }
        public bool IsDiscontinued { get; set; }
    }
}
