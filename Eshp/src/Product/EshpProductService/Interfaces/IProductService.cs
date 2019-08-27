﻿using System.Collections.Generic;
using EshpProductCommon;

namespace EshpProductService.Interfaces
{
    public interface IProductService
    {
        #region Gets

        ProductBase GetProductById(int id);
        IList<ProductBase> GetProducts(int count, int page);
        int GetProductsCount();
        IList<ProductBase> GetProductsByCompany(int companyId);

        #endregion

        #region CommonProductActions

        ProductBase CreateProduct(ProductBase product);
        bool UpdateProduct(int productId, ProductBase product);
        bool DeleteProduct(int productId);

        #endregion

        #region CompanyProductActions

        Product AddProductToCompany(int productId, int companyId);
        bool UpdateProductForCompany(int companyId, int productId, Product product);
        bool RemoveProductFromCompany(int productId, int companyId);
        int GetProductsCountForCompany(int companyId);

        #endregion

    }
}