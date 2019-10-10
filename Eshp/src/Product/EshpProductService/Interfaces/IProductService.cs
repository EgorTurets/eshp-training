using EshpCommon;
using EshpProductCommon;

namespace EshpProductService.Interfaces
{
    public interface IProductService
    {
        #region Gets

        ServiceResult GetProductById(int id);
        ServiceResult GetProducts(int count, int page);
        ServiceResult GetProductsCount();
        ServiceResult GetProductsByCompany(int companyId);

        #endregion

        #region CommonProductActions

        ServiceResult CreateProduct(ProductBase product);
        ServiceResult UpdateProduct(int productId, ProductBase product);
        ServiceResult DeleteProduct(int productId);

        #endregion

        #region CompanyProductActions

        ServiceResult AddProductToCompany(int productId, int companyId);
        ServiceResult UpdateProductForCompany(int companyId, int productId, Product product);
        ServiceResult RemoveProductFromCompany(int productId, int companyId);
        ServiceResult GetProductsCountForCompany(int companyId);

        #endregion

    }
}
