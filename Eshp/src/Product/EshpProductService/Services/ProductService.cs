using EshpCommon;
using EshpProductCommon;
using EshpProductProvider.Interfaces;
using EshpProductService.Interfaces;
using System;
using System.Collections.Generic;
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

        public ServiceResult<Product> GetProductById(int id)
        {
            if (id < 1)
            {
                return ServiceResult<Product>.CreateErrorResult($"{nameof(id)} must be more than 0");
            }

            try
            {
                var result = _productProvider.GetById(id);
                return ServiceResult<Product>.CreateSuccessResult(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<Product>.CreateErrorResult(ex.Message);
            }
        }

        public ServiceResult<IList<ProductBase>> GetProductsBase(int count, int page)
        {
            if (count < 1 || page < 1)
            {
                return ServiceResult<IList<ProductBase>>.CreateErrorResult($"{nameof(count)} and {nameof(page)} must be more than 0");
            }

            try
            {
                var result = _productProvider.GetProductsBase(count, page);
                return ServiceResult<IList<ProductBase>>.CreateSuccessResult(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<IList<ProductBase>>.CreateErrorResult(ex.Message);
            }
        }

        public ServiceResult<int> GetProductsCount()
        {
            var result = _productProvider.GetCount();
            return ServiceResult<int>.CreateSuccessResult(result);
        }

        public ServiceResult<IList<Product>> GetProductsByCompany(int companyId)
        {
            if (companyId < 1)
            {
                return ServiceResult<IList<Product>>.CreateErrorResult($"{nameof(companyId)} must be more than 0");
            }

            try
            {
                var result = _productProvider.GetByCompany(companyId);
                return ServiceResult<IList<Product>>.CreateSuccessResult(result);

            }
            catch (Exception ex)
            {
                return ServiceResult<IList<Product>>.CreateErrorResult(ex.Message);
            }
        }

        #endregion
        
        #region CommonProductActions

        public ServiceResult<ProductBase> CreateProduct(ProductBase product)
        {
            bool isProductValid;
            try
            {
                isProductValid = ValidateProductBase(product);
            }
            catch (ArgumentException aex)
            {
                return ServiceResult<ProductBase>.CreateErrorResult(aex.Message);
            }

            if (!isProductValid)
                return ServiceResult<ProductBase>.CreateErrorResult("Model is not valid");

            try
            {
                var result = _productProvider.CreateBaseProduct(product);
                return ServiceResult<ProductBase>.CreateSuccessResult(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<ProductBase>.CreateErrorResult(ex.Message);
            }
        }

        public ServiceResult<bool> UpdateProduct(int productId, ProductBase product)
        {
            if (productId < 1)
            {
                return ServiceResult<bool>.CreateErrorResult($"{nameof(productId)} must be more than 0");
            }

            bool isProductValid;
            try
            {
                isProductValid = ValidateProductBase(product);
            }
            catch (ArgumentException aex)
            {
                return ServiceResult<bool>.CreateErrorResult(aex.Message);
            }

            if (!isProductValid)
                return ServiceResult<bool>.CreateErrorResult("Model is not valid");

            try
            {
                var result = _productProvider.UpdateBaseProduct(productId, product);
                return ServiceResult<bool>.CreateSuccessResult(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.CreateErrorResult(ex.Message);
            }
        }

        public ServiceResult<bool> DeleteProduct(int productId)
        {
            if (productId < 1)
            {
                return ServiceResult<bool>.CreateErrorResult($"{nameof(productId)} must be more than 0");
            }

            try
            {
                var result = _productProvider.DeleteBaseProduct(productId);
                return ServiceResult<bool>.CreateSuccessResult(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.CreateErrorResult(ex.Message);
            }
        }

        #endregion

        #region CompanyProductActions

        public ServiceResult<bool> AddProductToCompany(int productId, int companyId)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<bool> UpdateProductForCompany(int companyId, int productId, Product product)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<bool> RemoveProductFromCompany(int productId, int companyId)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<IList<Product>> GetProductsCountForCompany(int companyId)
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
