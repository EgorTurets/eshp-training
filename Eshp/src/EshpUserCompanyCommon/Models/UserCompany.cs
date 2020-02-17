using System;
using System.Collections.Generic;
using System.Text;

namespace EshpUserCompanyCommon.Models
{
    public class UserCompany
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
