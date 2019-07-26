using System;
using System.Linq;
using EshpProductService.Models;

namespace EshpProductService
{
    public interface IProductService
    {
        ProductBase GetProductById(int id);

        IList<ProductBase> GetProducts(int count);

        IList<ProductBase> GetProductsByCompany(int companyId);

        #region CommonProductActions

        Product CreateProduct(ProductBase product);
        bool UpdateProduct(int productId, ProductBase product);
        bool DeleteProduct(int productId);

        #endregion

        #region CompanyProductActions

        Product AddProductToCompany(int productId, int companyId);
        bool UpdateProductForCompany(int companyId, int productId, Product product);

        bool RemoveProductFromCompany(int productId, int companyId);

        #endregion

    }
}
