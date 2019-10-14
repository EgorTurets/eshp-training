using EshpCommon;
using EshpProductCommon;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace UserService
{
    public class Company : NamedEntry
    {
        public IdentityUser Contact { get; set; }

        public string PhoneNumber { get; set; }

        public List<Product> Products { get; set; }
    }
}
