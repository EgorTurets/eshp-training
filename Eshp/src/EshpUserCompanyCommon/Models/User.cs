using System;

namespace EshpUserCompanyCommon.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                foreach (var symbol in value)
                {
                    if (Char.IsDigit(symbol))
                    {
                        throw new ArgumentException("Phone number can't have not numeric symbols.");
                    }
                }
                
                phoneNumber = value;
            }
        }

    }
}
