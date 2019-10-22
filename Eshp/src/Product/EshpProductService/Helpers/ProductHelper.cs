using EshpProductCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshpProductService.Helpers
{
    public class ProductHelper
    {
        public static bool CheckForProductBase (Product product)
        {
            return product.BaseProductId == null;
        }
    }
}
