using EshpCommon;
using EshpProductCommon;
using EshpProductProvider.Interfaces;
using EshpProductService.Interfaces;
using System;
using System.Linq;

namespace EshpProductService.Services
{
    public class ProductService : IProductService
    {
        private IProductProvider _productProvider;

        public ProductService(IProductProvider productProvider)
        {
            _productProvider = productProvider;
        }

        #region Gets

        public ServiceResult GetProductById(int id)
        {
            if (id < 1)
            {
                return ServiceResult.CreateErrorResult($"{nameof(id)} must be more than 0");
            }

            try
            {
                var result = _productProvider.GetById(id);
                return ServiceResult.CreateSuccessResult(result);
            }
            catch (Exception ex)
            {
                return ServiceResult.CreateErrorResult(ex.Message);
            }
        }

        public ServiceResult GetProducts(int count, int page)
        {
            if (count < 1 || page < 1)
            {
                return ServiceResult.CreateErrorResult($"{nameof(count)} and {nameof(page)} must be more than 0");
            }

            try
            {
                var result = _productProvider.Get(count, page);
                return ServiceResult.CreateSuccessResult(result);
            }
            catch (Exception ex)
            {
                return ServiceResult.CreateErrorResult(ex.Message);
            }
        }

        public ServiceResult GetProductsCount()
        {
            var result = _productProvider.GetCount();
            return ServiceResult.CreateSuccessResult(result);
        }

        public ServiceResult GetProductsByCompany(int companyId)
        {
            if (companyId < 1)
            {
                return ServiceResult.CreateErrorResult($"{nameof(companyId)} must be more than 0");
            }

            try
            {
                var result = _productProvider.GetByCompany(companyId);
                return ServiceResult.CreateSuccessResult(result);

            }
            catch (Exception ex)
            {
                return ServiceResult.CreateErrorResult(ex.Message);
            }
        }

        #endregion
        
        #region CommonProductActions

        public ServiceResult CreateProduct(ProductBase product)
        {
            var isProductValid = ValidateProductBase(product);

            ProductBase result = null;
            if (isProductValid)
                return ServiceResult.CreateErrorResult("Model is not valid");

            try
            {
                result = _productProvider.CreateBaseProduct(product);
                return ServiceResult.CreateSuccessResult(result);
            }
            catch (Exception ex)
            {
                return ServiceResult.CreateErrorResult(ex.Message);
            }
        }

        public ServiceResult UpdateProduct(int productId, ProductBase product)
        {
            if (productId < 1)
            {
                throw new ArgumentException($"{nameof(productId)} must be more than 0");
            }

            var isProductValid = ValidateProductBase(product);

            if (isProductValid)
                return ServiceResult.CreateErrorResult("Model is not valid");

            try
            {
                var result = _productProvider.UpdateBaseProduct(productId, product);
                return ServiceResult.CreateSuccessResult(result);
            }
            catch (Exception ex)
            {
                return ServiceResult.CreateErrorResult(ex.Message);
            }
        }

        public ServiceResult DeleteProduct(int productId)
        {
            if (productId < 1)
            {
                return ServiceResult.CreateErrorResult($"{nameof(productId)} must be more than 0");
            }

            try
            {
                var result = _productProvider.DeleteBaseProduct(productId);
                return ServiceResult.CreateSuccessResult(result);
            }
            catch (Exception ex)
            {
                return ServiceResult.CreateErrorResult(ex.Message);
            }
        }

        #endregion

        #region CompanyProductActions

        public ServiceResult AddProductToCompany(int productId, int companyId)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult UpdateProductForCompany(int companyId, int productId, Product product)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult RemoveProductFromCompany(int productId, int companyId)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult GetProductsCountForCompany(int companyId)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Private methods

        private bool ValidateProductBase(ProductBase product)
        {
            if (product == null)
            {
                throw new ArgumentException($"{nameof(product)} cannot be Null");
            }
            if (String.IsNullOrWhiteSpace(product.Name))
            {
                throw new ArgumentException($"{nameof(product.Name)} cannot be empty");
            }
            if (product.Offers?.Any(o => o.Id < 1) ?? false)
            {
                throw new ArgumentException($"Id of {product.Offers} must be more than 0");
            }

            return true;
        }

        #endregion

    }
}
