using System;
using System.Collections;
using System.Collections.Generic;
using EshpProductCommon;
using EshpProductProvider;
using EshpProductService;
using EshpProductService.Services;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ProductTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1)]
        [TestCase(10)]
        public void ProductService_GetProductById_IdMoreThan0_Success(int id)
        {
            var mock = new Mock<IProductProvider>();
            mock.Setup(a => a.GetById(id)).Returns(new ProductBase());
            IProductService service = new ProductService(mock.Object);

            var result = service.GetProductById(id);

            Assert.IsInstanceOf(typeof(ProductBase), result);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void ProductService_GetProductById_IdLessThan1_ArgumentError(int id)
        {
            var mock = new Mock<IProductProvider>();
            mock.Setup(a => a.GetById(id)).Returns(new ProductBase());
            IProductService service = new ProductService(mock.Object);

            Assert.That(() => service.GetProductById(id), Throws.ArgumentException);
        }

        [TestCase(1, 1)]
        [TestCase(10, 5)]
        public void ProductService_GetProducts_ArgsMoreThan0_Success(int count, int page)
        {
            var mock = new Mock<IProductProvider>();
            mock.Setup(a => a.Get(count, page)).Returns(new List<ProductBase>());
            IProductService service = new ProductService(mock.Object);

            var result = service.GetProducts(count, page);

            Assert.IsInstanceOf(typeof(IList<ProductBase>), result);
        }

        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(-10, -5)]
        public void ProductService_GetProducts_ArgsLessThan1_ArgumentError(int count, int page)
        {
            var mock = new Mock<IProductProvider>();
            mock.Setup(a => a.Get(count, page)).Returns(new List<ProductBase>());
            IProductService service = new ProductService(mock.Object);

            Assert.That(() => service.GetProducts(count, page), Throws.ArgumentException);
        }

        [TestCase(1)]
        [TestCase(10)]
        public void ProductService_GetProductsByCompany_CompanyIdMoreThan0_Success(int companyId)
        {
            var mock = new Mock<IProductProvider>();
            mock.Setup(a => a.GetByCompany(companyId)).Returns(new List<ProductBase>());
            IProductService service = new ProductService(mock.Object);

            var result = service.GetProductsByCompany(companyId);

            Assert.IsInstanceOf(typeof(IList<ProductBase>), result);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void ProductService_GetProductsByCompany_CompanyIdLessThan1_ArgumentError(int companyId)
        {
            var mock = new Mock<IProductProvider>();
            mock.Setup(a => a.GetByCompany(companyId)).Returns(new List<ProductBase>());
            IProductService service = new ProductService(mock.Object);

            Assert.That(() => service.GetProductsByCompany(companyId), Throws.ArgumentException);
        }

        //[Test]
        //public void ProductService_GetProductsCount_ArgumentError()
        //{
        //}
    }
}