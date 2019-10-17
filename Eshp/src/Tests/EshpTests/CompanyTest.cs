using EshpUserCompanyCommon.Models;
using EshpUserCompanyProvider;
using Moq;
using NUnit.Framework;
using UserCompanyService.Interfaces;

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
        public void CompanyService_GetById_IdMoreThan0_SrCompany(int id)
        {
            var mock = new Mock<ICompanyProvider>();
            mock.Setup(a => a.GetCompanyById(It.IsAny<int>()))
                .Returns(new Company());
            ICompanyService
        }
    }
}
