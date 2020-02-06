using EshpProductProvider.Interfaces;
using System;

namespace EshpProductService.Helpers
{
    public class ProductHelper
    {
        public static bool CheckForProductBase (int productId, IProductProvider productProvider)
        {
            if (productProvider == null)
            {
                throw new ArgumentNullException(nameof(productProvider));
            }
            var entity = productProvider.GetById(productId);
            return entity.BaseProductId == null;
        }
    }
}
