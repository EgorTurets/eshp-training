using System;
using System.Collections.Generic;
using EshpProductCommon;
using EshpProductProvider;

namespace EshpProductService.Services
{
    public class ProductService : IProductService
    {
        private IProductProvider _productProvider;

        public ProductService(IProductProvider productProvider)
        {
            _productProvider = productProvider;
        }

        public ProductBase GetProductById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("id must be more than 1");
            }

            return _productProvider.GetById(id);
        }

        public IList<ProductBase> GetProducts(int count, int page)
        {
            throw new System.NotImplementedException();
        }

        public int GetProductsCount()
        {
            throw new System.NotImplementedException();
        }

        public IList<ProductBase> GetProductsByCompany(int companyId)
        {
            throw new System.NotImplementedException();
        }

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
    }
}
