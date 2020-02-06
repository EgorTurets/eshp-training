using System;
using System.Collections.Generic;
using System.Text;

namespace EshpProductProvider.Models
{
    public class ProductDB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? BaseProductId { get; set; }
        public int? Price { get; set; }
        public int? Amount { get; set; }
        public int? CompanyId { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
