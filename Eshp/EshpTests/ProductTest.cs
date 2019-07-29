using System;
using EshpProductCommon;
using EshpProductProvider;
using EshpProductService;
using EshpProductService.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using EshpProductService.Interfaces;
using NUnit.Framework.Internal.Builders;

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
            mock.Setup(a => a.GetById(It.IsAny<int>()))
                .Returns(new ProductBase());
            IProductService service = new ProductService(mock.Object);

            var result = service.GetProductById(id);

            Assert.IsInstanceOf(typeof(ProductBase), result);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void ProductService_GetProductById_IdLessThan1_ArgumentError(int id)
        {
            var mock = new Mock<IProductProvider>();
            mock.Setup(a => a.GetById(It.IsAny<int>()))
                .Returns(new ProductBase());
            IProductService service = new ProductService(mock.Object);

            Assert.That(() => service.GetProductById(id), Throws.ArgumentException);
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

            Assert.IsInstanceOf(typeof(IList<ProductBase>), result);
        }

        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(-10, -5)]
        public void ProductService_GetProducts_ArgsLessThan1_ArgumentError(int count, int page)
        {
            var mock = new Mock<IProductProvider>();
            mock.Setup(a => a.Get(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new List<ProductBase>());
            IProductService service = new ProductService(mock.Object);

            Assert.That(() => service.GetProducts(count, page), Throws.ArgumentException);
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

            Assert.IsInstanceOf(typeof(IList<ProductBase>), result);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void ProductService_GetProductsByCompany_CompanyIdLessThan1_ArgumentError(int companyId)
        {
            var mock = new Mock<IProductProvider>();
            mock.Setup(a => a.GetByCompany(It.IsAny<int>()))
                .Returns(new List<ProductBase>());
            IProductService service = new ProductService(mock.Object);

            Assert.That(() => service.GetProductsByCompany(companyId), Throws.ArgumentException);
        }

        #endregion

        #region CommonProductActions

        [Test]
        public void ProductService_CreateProduct_NullInput_ArgumentException()
        {
            var mock = new Mock<IProductProvider>();
            IProductService service = new ProductService(mock.Object);

            Assert.That(() => service.CreateProduct(null), Throws.ArgumentException);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void ProductService_CreateProduct_EmptyName_ArgumentException(string name)
        {
            var mock = new Mock<IProductProvider>();
            var testProduct = new ProductBase(){Name = name};
            IProductService service = new ProductService(mock.Object);

            Assert.That(() => service.CreateProduct(testProduct), Throws.ArgumentException);
        }

        [TestCase(new[] {0, 1, 5, 10})]
        [TestCase(new[] {5, -1, 12, 10})]
        [TestCase(new[] {-10})]
        public void ProductService_CreateProduct_OfferIdLessThan1_ArgumentException(int[] offerIds)
        {
            var providerMock = new Mock<IProductProvider>();
            var offers = offerIds.Select(oid => new Product() {Id = oid, Name = $"Pr{oid}"}).ToList();
            var testProduct = new ProductBase() { Name = It.IsAny<string>(), Offers = offers};
            IProductService service = new ProductService(providerMock.Object);

            Assert.That(() => service.CreateProduct(testProduct), Throws.ArgumentException);
        }

        [Test]
        public void ProductService_CreateProduct_FailedRequest_Null()
        {
            var testProduct = new ProductBase() { Name = It.IsAny<string>() };

            var providerMock = new Mock<IProductProvider>();
            providerMock
                .Setup(a => a.CreateBaseProduct(It.IsAny<ProductBase>()))
                .Returns((ProductBase)null);

            IProductService service = new ProductService(providerMock.Object);

            Assert.That(() => service.CreateProduct(testProduct), Is.Null);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void ProductService_UpdateProduct_ProductIdLessThan1_ArgumentException(int id)
        {
            var providerMock = new Mock<IProductProvider>();
            
            IProductService service = new ProductService(providerMock.Object);

            Assert.Throws<ArgumentException>(() => service.UpdateProduct(id, It.IsAny<ProductBase>()));
        }

        [TestCase(1)]
        [TestCase(10)]
        public void ProductService_UpdateProduct_ProductIdMoreThan0_True(int id)
        {
            var providerMock = new Mock<IProductProvider>();

            IProductService service = new ProductService(providerMock.Object);

            Assert.That(() => service.UpdateProduct(id, It.IsAny<ProductBase>()), Is.True);
        }

        [Test]
        public void ProductService_UpdateProduct_ProductIsNull_ArgumentException()
        {
            var mock = new Mock<IProductProvider>();
            IProductService service = new ProductService(mock.Object);

            Assert.Throws<ArgumentException>(() => service.UpdateProduct(It.IsAny<int>(), null));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void ProductService_UpdateProduct_EmptyName_ArgumentException(string name)
        {
            var mock = new Mock<IProductProvider>();
            var testProduct = new ProductBase() { Name = name };
            IProductService service = new ProductService(mock.Object);

            Assert.Throws<ArgumentException>(() => service.UpdateProduct(It.IsAny<int>(), testProduct));
        }

        [TestCase(new[] { 0, 1, 5, 10 })]
        [TestCase(new[] { 5, -1, 12, 10 })]
        [TestCase(new[] { -10 })]
        public void ProductService_UpdateProduct_OfferIdLessThan1_ArgumentException(int[] offerIds)
        {
            var providerMock = new Mock<IProductProvider>();
            var offers = offerIds.Select(oid => new Product() { Id = oid, Name = $"Pr{oid}" }).ToList();
            var testProduct = new ProductBase() { Name = It.IsAny<string>(), Offers = offers };
            IProductService service = new ProductService(providerMock.Object);

            Assert.Throws<ApplicationException>(() => service.UpdateProduct(It.IsAny<int>(), testProduct));
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

            return service.UpdateProduct(It.IsAny<int>(), It.IsAny<ProductBase>());
        }

        [Category("DeleteProduct")]
        [Test]
        public void ProductService_DeleteProduct_IdLessThan1_ArgumentException()
        {
            var providerMock = new Mock<IProductProvider>();
            IProductService service = new ProductService(providerMock.Object);
            var id = It.Is<int>(x => x < 1);

            Assert.Throws<ArgumentException>(() => service.DeleteProduct(id));

        }

        [Category("DeleteProduct")]
        [Test]
        public void ProductService_DeleteProduct_IdMoreThan0_True()
        {
            var providerMock = new Mock<IProductProvider>();
            providerMock
                .Setup(a => a.DeleteBaseProduct(It.IsAny<int>()))
                .Returns(true);
            IProductService service = new ProductService(providerMock.Object);
            var id = It.Is<int>(x => x > 0);

            Assert.That(() => service.DeleteProduct(id), Is.True);
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

            return service.DeleteProduct(It.IsAny<int>());
        }

        #endregion
    }
}