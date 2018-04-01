using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Register
    {
       public string UserName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        public string Blood { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        public string Confirmpassword { get; set; }

    }
}
