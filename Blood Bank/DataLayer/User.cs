using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
       
        public string UserName { get; set; }
        
        public string Email { get; set; }
       
        public string Blood { get; set; }

        [DataType(DataType.Date)]
        public string LastDonated { get; set; }

        public string PreferedArea { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        
        public string PhoneNumber { get; set; }
        public string OtherNumber { get; set; }
        public string Relation { get; set; }

        
        public string Password { get; set; }

        
    }

    



}
