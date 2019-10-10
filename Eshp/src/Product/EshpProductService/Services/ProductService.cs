using System;
using System.Collections.Generic;
using System.Linq;
using EshpProductCommon;
using EshpProductProvider.Interfaces;
using EshpProductService.Interfaces;

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

        public ProductBase GetProductById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException($"{nameof(id)} must be more than 0");
            }

            return _productProvider.GetById(id);
        }

        public IList<ProductBase> GetProducts(int count, int page)
        {
            if (count < 1 || page < 1)
            {
                throw new ArgumentException($"{nameof(count)} and {nameof(page)} must be more than 0");
            }

            return _productProvider.Get(count, page);
        }

        public int GetProductsCount()
        {
            return _productProvider.GetCount();
        }

        public IList<ProductBase> GetProductsByCompany(int companyId)
        {
            if (companyId < 1)
            {
                throw new ArgumentException($"{nameof(companyId)} must be more than 0");
            }

            return _productProvider.GetByCompany(companyId);
        }

        #endregion
        
        #region CommonProductActions

        public ProductBase CreateProduct(ProductBase product)
        {
            var isProductValid = ValidateProductBase(product);

            ProductBase result = null;
            if (isProductValid)
                result = _productProvider.CreateBaseProduct(product);

            return result;
        }

        public bool UpdateProduct(int productId, ProductBase product)
        {
            if (productId < 1)
            {
                throw new ArgumentException($"{nameof(productId)} must be more than 0");
            }

            var isProductValid = ValidateProductBase(product);

            bool result = false;
            if (isProductValid)
                result = _productProvider.UpdateBaseProduct(productId, product);

            return result;
        }

        public bool DeleteProduct(int productId)
        {
            if (productId < 1)
            {
                throw new ArgumentException($"{nameof(productId)} must be more than 0");
            }

            return _productProvider.DeleteBaseProduct(productId);
        }

        #endregion

        #region CompanyProductActions

        public Product AddProductToCompany(int productId, int companyId)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateProductForCompany(int companyId, int productId, Product product)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveProductFromCompany(int productId, int companyId)
        {
            throw new System.NotImplementedException();
        }

        public int GetProductsCountForCompany(int companyId)
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
