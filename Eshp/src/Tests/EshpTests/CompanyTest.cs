using EshpCommon;
using EshpUserCompanyCommon.Models;
using EshpUserCompanyProvider;
using EshpUserCompanyProvider.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
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
        public void CompanyService_Get_IdMoreThan0_Success(int id)
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.GetCompany(It.IsAny<int>()))
                .Returns(new Company());
            ICompanyService service = new CompanyService(mock.Object, new Mock<ILogger>().Object);

            ServiceResult<Company> result = null;

            Assert.DoesNotThrow(() => result = service.Get(id));
            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(ServiceResult<Company>), result);
            Assert.IsFalse(result.IsErrored);
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void CompanyService_Get_IdLessThan1_Fail(int id)
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.GetCompany(It.IsAny<int>()))
                .Returns(new Company());
            ICompanyService service = new CompanyService(mock.Object, new Mock<ILogger>().Object);

            ServiceResult<Company> result = null;

            Assert.DoesNotThrow(() => result = service.Get(id));
            Assert.IsNotNull(result);
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
            ICompanyService service = new CompanyService(mock.Object, new Mock<ILogger>().Object);
            var pageInfo = new PageRequest(pageNumber, 10);

            ServiceResult<IList<Company>> result = null;

            Assert.DoesNotThrow(() => result = service.GetCompanies(pageInfo));
            Assert.IsNotNull(result);
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
            ICompanyService service = new CompanyService(mock.Object, new Mock<ILogger>().Object);
            var pageInfo = new PageRequest(1, count);

            ServiceResult<IList<Company>> result = null;

            Assert.DoesNotThrow(() => result = service.GetCompanies(pageInfo));
            Assert.IsNotNull(result);
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
            ICompanyService service = new CompanyService(mock.Object, new Mock<ILogger>().Object);
            var pageInfo = new PageRequest(pageNumber, 10);

            ServiceResult<IList<Company>> result = null;

            Assert.DoesNotThrow(() => result = service.GetCompanies(pageInfo));
            Assert.IsNotNull(result);
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
            ICompanyService service = new CompanyService(mock.Object, new Mock<ILogger>().Object);
            var pageInfo = new PageRequest(1, count);

            ServiceResult<IList<Company>> result = null;

            Assert.DoesNotThrow(() => result = service.GetCompanies(pageInfo));
            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(ServiceResult<IList<Company>>), result);
            Assert.IsFalse(result.IsErrored);
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void CompanyService_GetByProductId_IdLessThan1_Fail(int baseProductId)
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.GetCompaniesFor(It.IsAny<int>()))
                .Returns(new List<Company>());
            ICompanyService service = new CompanyService(mock.Object, new Mock<ILogger>().Object);

            ServiceResult<IList<Company>> result = null;

            Assert.DoesNotThrow(() => result = service.GetCompaniesForProduct(baseProductId));
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ServiceResult<IList<Company>>>(result);
            Assert.IsTrue(result.IsErrored);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void CompanyService_GetByProductId_IdMoreThan_Success(int baseProductId)
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.GetCompaniesFor(It.IsAny<int>()))
                .Returns(new List<Company>());
            ICompanyService service = new CompanyService(mock.Object, new Mock<ILogger>().Object);

            ServiceResult<IList<Company>> result = null;

            Assert.DoesNotThrow(() => result = service.GetCompaniesForProduct(baseProductId));
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ServiceResult<IList<Company>>>(result);
            Assert.IsFalse(result.IsErrored);
        }

        [Test]
        public void CompanyService_CreateCompany_CompanyIsNull_FailResult()
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.CreateCompany(It.IsAny<Company>()))
                .Returns(new Company());
            ICompanyService service = new CompanyService(mock.Object, new Mock<ILogger>().Object);

            Company newCompany = null;

            ServiceResult<Company> result = null;

            Assert.DoesNotThrow(() => result = service.CreateCompany(newCompany));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsErrored);
            Assert.IsNull(result.Result);
        }

        [Test]
        public void CompanyService_CreateCompany_NameIsEmpty_FailResult()
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.CreateCompany(It.IsAny<Company>()))
                .Returns(new Company());
            ICompanyService service = new CompanyService(mock.Object, new Mock<ILogger>().Object);

            var newCompany = new Company { Name = String.Empty };

            ServiceResult<Company> result = null;

            Assert.DoesNotThrow(() => result = service.CreateCompany(newCompany));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsErrored);
            Assert.IsNull(result.Result);
        }

        [Test]
        public void CompanyService_CreateCompany_ProviderNullResult_FailResult()
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.CreateCompany(It.IsAny<Company>()))
                .Returns((Company)null);
            ICompanyService service = new CompanyService(mock.Object, new Mock<ILogger>().Object);

            var newCompany = new Company { Name = "Name" };

            ServiceResult<Company> result = null;

            Assert.DoesNotThrow(() => result = service.CreateCompany(newCompany));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsErrored);
            Assert.IsNull(result.Result);
        }

        [Test]
        public void CompanyService_CreateCompany_SuccessResult()
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.CreateCompany(It.IsAny<Company>()))
                .Returns(new Company());
            ICompanyService service = new CompanyService(mock.Object, new Mock<ILogger>().Object);

            var newCompany = new Company { Name = "Name" };

            ServiceResult<Company> result = null;

            Assert.DoesNotThrow(() => result = service.CreateCompany(newCompany));
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsErrored);
            Assert.IsInstanceOf<Company>(result.Result);
        }

        [Test]
        public void CompanyService_UpdateCompany_NullCompany_FaildResult()
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.UpdateCompany(It.IsAny<Company>()))
                .Returns(true);
            ICompanyService service = new CompanyService(mock.Object, new Mock<ILogger>().Object);

            ServiceResult<bool> result = null;
            Assert.DoesNotThrow(() => result = service.UpdateCompany(null));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsErrored);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void CompanyService_UpdateCompany_InvalidId_FaildResult(int id)
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.UpdateCompany(It.IsAny<Company>()))
                .Returns(true);
            ICompanyService service = new CompanyService(mock.Object, new Mock<ILogger>().Object);

            var newCompany = new Company {Id = id, Name = "Name" };

            ServiceResult<bool> result = null;
            Assert.DoesNotThrow(() => result = service.UpdateCompany(newCompany));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsErrored);
        }

        [TestCase(1)]
        [TestCase(10)]
        public void CompanyService_UpdateCompany_ValidId_SuccessResult(int id)
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.UpdateCompany(It.IsAny<Company>()))
                .Returns(true);
            ICompanyService service = new CompanyService(mock.Object, new Mock<ILogger>().Object);

            var newCompany = new Company { Id = id, Name = "Name" };

            ServiceResult<bool> result = null;
            Assert.DoesNotThrow(() => result = service.UpdateCompany(newCompany));
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsErrored);
            Assert.IsTrue(result.Result);
        }

        [Test]
        public void CompanyService_UpdateCompany_EmptyName_FaildResult()
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.UpdateCompany(It.IsAny<Company>()))
                .Returns(true);
            ICompanyService service = new CompanyService(mock.Object, new Mock<ILogger>().Object);

            var newCompany = new Company { Id = 1, Name = String.Empty };

            ServiceResult<bool> result = null;
            Assert.DoesNotThrow(() => result = service.UpdateCompany(newCompany));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsErrored);
        }

        [Test]
        public void CompanyService_UpdateCompany_ValidName_SuccessResult()
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.UpdateCompany(It.IsAny<Company>()))
                .Returns(true);
            ICompanyService service = new CompanyService(mock.Object, new Mock<ILogger>().Object);

            var newCompany = new Company { Id = 1, Name = "Name" };

            ServiceResult<bool> result = null;
            Assert.DoesNotThrow(() => result = service.UpdateCompany(newCompany));
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsErrored);
            Assert.IsTrue(result.Result);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void CompanyService_UpdateCompany_ProviderResult_SuccessResult(bool providerResult)
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.UpdateCompany(It.IsAny<Company>()))
                .Returns(providerResult);
            ICompanyService service = new CompanyService(mock.Object, new Mock<ILogger>().Object);

            var newCompany = new Company { Id = 1, Name = "Name" };

            ServiceResult<bool> result = null;
            Assert.DoesNotThrow(() => result = service.UpdateCompany(newCompany));
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsErrored);
            Assert.AreEqual(providerResult, result.Result);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void CompanyService_DeleteCompany_InvalidId_FaildResult(int id)
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.DeleteCompany(It.IsAny<int>()))
                .Returns(true);
            ICompanyService service = new CompanyService(mock.Object, new Mock<ILogger>().Object);

            ServiceResult<bool> result = null;
            Assert.DoesNotThrow(() => result = service.DeleteCompany(id));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsErrored);
        }

        [TestCase(1)]
        [TestCase(10)]
        public void CompanyService_DeleteCompany_ValidId_SuccessResult(int id)
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.DeleteCompany(It.IsAny<int>()))
                .Returns(true);
            ICompanyService service = new CompanyService(mock.Object, new Mock<ILogger>().Object);

            ServiceResult<bool> result = null;
            Assert.DoesNotThrow(() => result = service.DeleteCompany(id));
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsErrored);
            Assert.IsTrue(result.Result);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void CompanyService_DeleteCompany_ProviderResult_SuccessResult(bool providerResult)
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.DeleteCompany(It.IsAny<int>()))
                .Returns(providerResult);
            ICompanyService service = new CompanyService(mock.Object, new Mock<ILogger>().Object);

            ServiceResult<bool> result = null;
            Assert.DoesNotThrow(() => result = service.DeleteCompany(1));
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsErrored);
            Assert.AreEqual(providerResult, result.Result);
        }


    }
}
