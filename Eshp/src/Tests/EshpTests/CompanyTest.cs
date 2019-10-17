using EshpCommon;
using EshpUserCompanyCommon.Models;
using EshpUserCompanyProvider;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using UserCompanyService.Interfaces;
using UserCompanyService.Services;

namespace EshpTests
{
    [TestFixture]
    public class CompanyTest
    {
        [SetUp]
        public void Setup()
        { }

        [TestCase(1)]
        [TestCase(10)]
        public void CompanyService_GetById_IdMoreThan0_Success(int id)
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.GetCompanyById(It.IsAny<int>()))
                .Returns(new Company());
            ICompanyService service = new CompanyService(mock.Object);

            var result = service.GetById(id);

            Assert.IsInstanceOf(typeof(ServiceResult<Company>), result);
            Assert.IsFalse(result.IsErrored);
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void CompanyService_GetById_IdLessThan1_Fail(int id)
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.GetCompanyById(It.IsAny<int>()))
                .Returns(new Company());
            ICompanyService service = new CompanyService(mock.Object);

            var result = service.GetById(id);

            Assert.IsInstanceOf(typeof(ServiceResult<Company>), result);
            Assert.IsTrue(result.IsErrored);
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void CompanyService_GetCompanies_PageLessThan1_Fail(int pageNumber)
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.GetCompanies(It.IsAny<PageRequest>()))
                .Returns(new List<Company>());
            ICompanyService service = new CompanyService(mock.Object);
            var pageInfo = new PageRequest(pageNumber, 10);

            var result = service.GetCompanies(pageInfo);

            Assert.IsInstanceOf(typeof(ServiceResult<IList<Company>>), result);
            Assert.IsTrue(result.IsErrored);
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void CompanyService_GetCompanies_CountLessThan1_Fail(int count)
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.GetCompanies(It.IsAny<PageRequest>()))
                .Returns(new List<Company>());
            ICompanyService service = new CompanyService(mock.Object);
            var pageInfo = new PageRequest(1, count);

            var result = service.GetCompanies(pageInfo);

            Assert.IsInstanceOf(typeof(ServiceResult<IList<Company>>), result);
            Assert.IsTrue(result.IsErrored);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void CompanyService_GetCompanies_PageMoreThan0_Success(int pageNumber)
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.GetCompanies(It.IsAny<PageRequest>()))
                .Returns(new List<Company>());
            ICompanyService service = new CompanyService(mock.Object);
            var pageInfo = new PageRequest(pageNumber, 10);

            var result = service.GetCompanies(pageInfo);

            Assert.IsInstanceOf(typeof(ServiceResult<IList<Company>>), result);
            Assert.IsFalse(result.IsErrored);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void CompanyService_GetCompanies_CountMoreThan0_Success(int count)
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.GetCompanies(It.IsAny<PageRequest>()))
                .Returns(new List<Company>());
            ICompanyService service = new CompanyService(mock.Object);
            var pageInfo = new PageRequest(1, count);

            var result = service.GetCompanies(pageInfo);

            Assert.IsInstanceOf(typeof(ServiceResult<IList<Company>>), result);
            Assert.IsFalse(result.IsErrored);
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void CompanyService_GetByProductId_IdLessThan1_Fail(int baseProductId)
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.GetCompaniesByProduct(It.IsAny<int>()))
                .Returns(new List<Company>());
            ICompanyService service = new CompanyService(mock.Object);

            var result = service.GetByProductId(baseProductId);

            Assert.IsInstanceOf<ServiceResult<IList<Company>>>(result);
            Assert.IsTrue(result.IsErrored);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void CompanyService_GetByProductId_IdMoreThan_Success(int baseProductId)
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.GetCompaniesByProduct(It.IsAny<int>()))
                .Returns(new List<Company>());
            ICompanyService service = new CompanyService(mock.Object);

            var result = service.GetByProductId(baseProductId);

            Assert.IsInstanceOf<ServiceResult<IList<Company>>>(result);
            Assert.IsFalse(result.IsErrored);
        }

        public void CompanyService_CreateCompany_NameIsEmpty_Fail()
        {

        }
    }
}
