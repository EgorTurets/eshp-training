using EshpCommon;

namespace UserService.Interfaces
{
    public interface ICompanyService
    {
        ServiceResult GetById(int id);

        ServiceResult GetCompanies(int count, int page);
    }
}
