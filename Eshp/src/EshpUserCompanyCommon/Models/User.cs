using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EshpUserCompanyCommon.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public IList<UserCompany> Companies { get; set; }
    }
}
