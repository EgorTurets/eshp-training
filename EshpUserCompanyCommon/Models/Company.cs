using EshpCommon;

namespace EshpUserCompanyCommon.Models
{
    public class Company : NamedEntry
    {
        public string Address { get; set; }

        public User Contact { get; set; }
    }
}
