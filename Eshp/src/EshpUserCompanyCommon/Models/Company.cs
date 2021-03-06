﻿using EshpCommon;
using System.Collections.Generic;

namespace EshpUserCompanyCommon.Models
{
    public class Company : NamedEntry
    {
        public string Address { get; set; }

        public IList<UserCompany> Contacts { get; set; }
    }
}
