using EshpProductCommon;
using EshpProductProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EshpProductProvider.Providers
{
    public class ProductProvider : IProductProvider
    {
        private EshpProductDbContext db;

        public ProductProvider(EshpProductDbContext context)
        {
            db = context;
        }

        public Product AddToCompany(int productId, int companyId)
        {
            throw new NotImplementedException();
        }

        public ProductBase CreateBaseProduct(ProductBase product)
        {
            var entityEntry = db.Products.Add((Product)product);
            db.SaveChanges(true);

            return entityEntry.Entity;
        }

        public bool DeleteBaseProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public IList<ProductBase> Get(int count, int page)
        {
            throw new NotImplementedException();
        }

        public IList<ProductBase> GetByCompany(int id)
        {
            throw new NotImplementedException();
        }

        public ProductBase GetProductBaseById(int id)
        {
            var product = db.Products.Find(id);
            return product;
        }

        public int GetCount()
        {
            return db.Products.Count();
        }

        public int GetCountForCompany(int companyId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFromCompany(int productId, int companyId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBaseProduct(int productId, ProductBase product)
        {
            throw new NotImplementedException();
        }

        public bool UpdateForCompany(int companyId, int productId, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
