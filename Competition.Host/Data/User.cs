using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competition.Host.Data
{
    public class User
    {
        public string Cust_Id { get; set; }

        public string Cust_Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public DateTime Birthday { get; set; }
    }
}
