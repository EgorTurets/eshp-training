using EshpCommon;

namespace EshpProductService.Models
{
    public class ProductBase : NamedEntry
    {
        public string BaseDescription { get; set; }
        public IList<Product> Offers { get; set; }
    }

    public class Product : ProductBase
    {
        public int? Price { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public int? CompanyId { get; set; }
    }
}
