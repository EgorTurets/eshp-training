using EshpCommon;
using EshpProductCommon;
using System;
using System.Collections.Generic;

namespace EshpProductService.Interfaces
{
    public interface IProductService
    {
        #region Gets

        ServiceResult<Product> GetProductById(int id);
        ServiceResult<IList<ProductBase>> GetProductsBase(int count, int page);
        ServiceResult<int> GetProductsCount();
        ServiceResult<IList<Product>> GetProductsByCompany(int companyId);

        #endregion

        #region CommonProductActions

        ServiceResult<ProductBase> CreateProduct(ProductBase product);
        ServiceResult<bool> UpdateProduct(int productId, ProductBase product);
        ServiceResult<bool> DeleteProduct(int productId);

        #endregion

        #region CompanyProductActions

        ServiceResult<bool> AddProductToCompany(int productId, int companyId);
        ServiceResult<bool> UpdateProductForCompany(int companyId, int productId, Product product);
        ServiceResult<bool> RemoveProductFromCompany(int productId, int companyId);
        ServiceResult<IList<Product>> GetProductsCountForCompany(int companyId);

        #endregion

    }
}
