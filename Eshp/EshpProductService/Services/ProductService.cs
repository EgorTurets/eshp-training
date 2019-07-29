using System;
using System.Collections.Generic;
using EshpProductCommon;
using EshpProductProvider;
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
            throw new System.NotImplementedException();
        }

        public bool UpdateProduct(int productId, ProductBase product)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteProduct(int productId)
        {
            throw new System.NotImplementedException();
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

    }
}
