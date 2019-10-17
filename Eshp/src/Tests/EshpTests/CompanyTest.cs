using EshpCommon;
using EshpUserCompanyCommon.Models;
using EshpUserCompanyProvider;
using Moq;
using NUnit.Framework;
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
            Assert.IsInstanceOf(typeof(Company), result.Result);
            Assert.IsFalse(result.IsErrored);
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void CompanyService_GetById_IdLessThan1_Success(int id)
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.GetCompanyById(It.IsAny<int>()))
                .Returns(new Company());
            ICompanyService service = new CompanyService(mock.Object);

            var result = service.GetById(id);

            Assert.IsInstanceOf(typeof(ServiceResult<Company>), result);
            Assert.IsInstanceOf(typeof(Company), result.Result);
            Assert.IsTrue(result.IsErrored);
        }
    }
}
