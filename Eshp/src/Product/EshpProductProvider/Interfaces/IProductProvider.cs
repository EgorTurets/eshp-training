using System.Collections.Generic;
using EshpProductCommon;

namespace EshpProductProvider.Interfaces
{
    public interface IProductProvider
    {
        ProductBase GetProductBaseById(int id);
        IList<ProductBase> Get(int count, int page);
        IList<ProductBase> GetByCompany(int id);
        int GetCount();

        #region CommonProductActions

        ProductBase CreateBaseProduct(ProductBase product);
        bool UpdateBaseProduct(int productId, ProductBase product);
        bool DeleteBaseProduct(int productId);

        #endregion

        #region CompanyProductActions

        Product AddToCompany(int productId, int companyId);
        bool UpdateForCompany(int companyId, int productId, Product product);
        bool RemoveFromCompany(int productId, int companyId);
        int GetCountForCompany(int companyId);

        #endregion

    }
}
