using EshpProductProvider.Interfaces;

namespace EshpProductService.Helpers
{
    public class ProductHelper
    {
        public static bool CheckForProductBase (int productId, IProductProvider productProvider)
        {
            var entity = productProvider.GetById(productId);
            return entity.BaseProductId == null;
        }
    }
}
