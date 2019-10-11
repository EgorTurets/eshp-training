using EshpProductCommon;
using EshpProductProvider.Interfaces;
using EshpProductService.Interfaces;
using EshpProductService.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class ProductTest
    {
        [SetUp]
        public void Setup()
        {
        }

        #region Gets

        [TestCase(1)]
        [TestCase(10)]
        public void ProductService_GetProductById_IdMoreThan0_ProductBase(int id)
        {
            var mock = new Mock<IProductProvider>();
            mock.Setup(a => a.GetProductBaseById(It.IsAny<int>()))
                .Returns(new ProductBase());
            IProductService service = new ProductService(mock.Object);

            var result = service.GetProductById(id);

            Assert.IsInstanceOf(typeof(ProductBase), result.Result);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void ProductService_GetProductById_IdLessThan1_IsErrored(int id)
        {
            var mock = new Mock<IProductProvider>();
            mock.Setup(a => a.GetProductBaseById(It.IsAny<int>()))
                .Returns(new ProductBase());
            IProductService service = new ProductService(mock.Object);

            Assert.IsTrue(service.GetProductById(id).IsErrored);
        }

        [TestCase(1, 1)]
        [TestCase(10, 5)]
        public void ProductService_GetProducts_ArgsMoreThan0_ProductBaseList(int count, int page)
        {
            var mock = new Mock<IProductProvider>();
            mock.Setup(a => a.Get(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new List<ProductBase>());
            IProductService service = new ProductService(mock.Object);

            var result = service.GetProducts(count, page);

            Assert.IsInstanceOf(typeof(IList<ProductBase>), result.Result);
        }

        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(-10, -5)]
        public void ProductService_GetProducts_ArgsLessThan1_IsErrored(int count, int page)
        {
            var mock = new Mock<IProductProvider>();
            mock.Setup(a => a.Get(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new List<ProductBase>());
            IProductService service = new ProductService(mock.Object);

            Assert.IsTrue(service.GetProducts(count, page).IsErrored);
        }

        [TestCase(1)]
        [TestCase(10)]
        public void ProductService_GetProductsByCompany_CompanyIdMoreThan0_ProductBaseList(int companyId)
        {
            var mock = new Mock<IProductProvider>();
            mock.Setup(a => a.GetByCompany(It.IsAny<int>()))
                .Returns(new List<ProductBase>());
            IProductService service = new ProductService(mock.Object);

            var result = service.GetProductsByCompany(companyId);

            Assert.IsInstanceOf(typeof(IList<ProductBase>), result.Result);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void ProductService_GetProductsByCompany_CompanyIdLessThan1_IsErrored(int companyId)
        {
            var mock = new Mock<IProductProvider>();
            mock.Setup(a => a.GetByCompany(It.IsAny<int>()))
                .Returns(new List<ProductBase>());
            IProductService service = new ProductService(mock.Object);

            Assert.IsTrue(service.GetProductsByCompany(companyId).IsErrored);
        }

        #endregion

        #region CommonProductActions

        [Test]
        public void ProductService_CreateProduct_NullInput_IsErrored()
        {
            var mock = new Mock<IProductProvider>();
            IProductService service = new ProductService(mock.Object);

            Assert.IsTrue(service.CreateProduct(null).IsErrored);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void ProductService_CreateProduct_EmptyName_IsErrored(string name)
        {
            var mock = new Mock<IProductProvider>();
            var testProduct = new ProductBase(){Name = name};
            IProductService service = new ProductService(mock.Object);

            Assert.IsTrue(service.CreateProduct(testProduct).IsErrored);
        }

        [TestCase(new[] {0, 1, 5, 10})]
        [TestCase(new[] {5, -1, 12, 10})]
        [TestCase(new[] {-10})]
        public void ProductService_CreateProduct_OfferIdLessThan1_IsErrored(int[] offerIds)
        {
            var providerMock = new Mock<IProductProvider>();
            var offers = offerIds.Select(oid => new Product() {Id = oid, Name = $"Pr{oid}"}).ToList();
            var testProduct = new ProductBase() { Name = It.IsAny<string>(), Offers = offers};
            IProductService service = new ProductService(providerMock.Object);

            Assert.IsTrue(service.CreateProduct(testProduct).IsErrored);
        }

        [Test]
        public void ProductService_CreateProduct_FailedRequest_Null()
        {
            var testProduct = new ProductBase() { Name = "test", };

            var providerMock = new Mock<IProductProvider>();
            providerMock
                .Setup(a => a.CreateBaseProduct(It.IsAny<ProductBase>()))
                .Returns((ProductBase)null);

            IProductService service = new ProductService(providerMock.Object);

            Assert.That(() => service.CreateProduct(testProduct).Result, Is.Null);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void ProductService_UpdateProduct_ProductIdLessThan1_IsErrored(int id)
        {
            var providerMock = new Mock<IProductProvider>();
            
            IProductService service = new ProductService(providerMock.Object);

            Assert.IsTrue(service.UpdateProduct(id, It.IsAny<ProductBase>()).IsErrored);
        }

        [TestCase(1)]
        [TestCase(10)]
        public void ProductService_UpdateProduct_ProductIdMoreThan0_True(int id)
        {
            var providerMock = new Mock<IProductProvider>();
            providerMock
                .Setup(a => a.UpdateBaseProduct(It.IsAny<int>(), It.IsAny<ProductBase>()))
                .Returns(true);
            IProductService service = new ProductService(providerMock.Object);

            Assert.That(() => 
                service.UpdateProduct(id, new ProductBase{ Name="name" }).Result, 
                Is.True);
        }

        [Test]
        public void ProductService_UpdateProduct_ProductIsNull_IsErrored()
        {
            var mock = new Mock<IProductProvider>();
            IProductService service = new ProductService(mock.Object);

            Assert.IsTrue(service.UpdateProduct(It.IsAny<int>(), null).IsErrored);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void ProductService_UpdateProduct_EmptyName_IsErrored(string name)
        {
            var mock = new Mock<IProductProvider>();
            var testProduct = new ProductBase() { Name = name };
            IProductService service = new ProductService(mock.Object);

            Assert.IsTrue(service.UpdateProduct(It.IsAny<int>(), testProduct).IsErrored);
        }

        [TestCase(new[] { 0, 1, 5, 10 })]
        [TestCase(new[] { 5, -1, 12, 10 })]
        [TestCase(new[] { -10 })]
        public void ProductService_UpdateProduct_OfferIdLessThan1_IsErrored(int[] offerIds)
        {
            var providerMock = new Mock<IProductProvider>();
            var offers = offerIds.Select(oid => new Product() { Id = oid, Name = $"Pr{oid}" }).ToList();
            var testProduct = new ProductBase() { Name = It.IsAny<string>(), Offers = offers };
            IProductService service = new ProductService(providerMock.Object);

            Assert.IsTrue(service.UpdateProduct(It.IsAny<int>(), testProduct).IsErrored);
        }

        [TestCase(true, ExpectedResult = true)]
        [TestCase(false, ExpectedResult = false)]
        public bool ProductService_UpdateProduct_ProviderResult(bool providerResult)
        {
            var providerMock = new Mock<IProductProvider>();
            providerMock
                .Setup(a => a.UpdateBaseProduct(It.IsAny<int>(), It.IsAny<ProductBase>()))
                .Returns(providerResult);

            IProductService service = new ProductService(providerMock.Object);

            return (bool)service.UpdateProduct(1, new ProductBase {Name = "name"}).Result;
        }

        [Category("DeleteProduct")]
        [Test]
        public void ProductService_DeleteProduct_IdLessThan1_IsErrored()
        {
            var providerMock = new Mock<IProductProvider>();
            IProductService service = new ProductService(providerMock.Object);
            var id = It.Is<int>(x => x < 1);

            Assert.IsTrue(service.DeleteProduct(id).IsErrored);

        }

        [Category("DeleteProduct")]
        [TestCase(1)]
        [TestCase(10)]
        public void ProductService_DeleteProduct_IdMoreThan0_True(int id)
        {
            var providerMock = new Mock<IProductProvider>();
            providerMock
                .Setup(a => a.DeleteBaseProduct(It.IsAny<int>()))
                .Returns(true);
            IProductService service = new ProductService(providerMock.Object);

            Assert.That(() => service.DeleteProduct(id).Result, Is.True);
        }

        [Category("DeleteProduct")]
        [TestCase(true, ExpectedResult = true)]
        [TestCase(false, ExpectedResult = false)]
        public bool ProductService_DeleteProduct_ProviderResult(bool providerResult)
        {
            var providerMock = new Mock<IProductProvider>();
            providerMock
                .Setup(a => a.DeleteBaseProduct(It.IsAny<int>()))
                .Returns(providerResult);

            IProductService service = new ProductService(providerMock.Object);

            return (bool)service.DeleteProduct(1).Result;
        }

        #endregion
    }
}