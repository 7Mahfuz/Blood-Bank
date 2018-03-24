using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Request
    {
        [Key]
        public int id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Blood { get; set; }

        public string Description { get; set; }

        public int GotOrNot { get; set; }

        public DateTime PostDate { get; set; }
        public DateTime BloodNeed { get; set; }

    }
}
