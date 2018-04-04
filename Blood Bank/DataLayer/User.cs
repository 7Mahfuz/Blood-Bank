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
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
       
        public string Blood { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string LastDonated { get; set; }

        public string PreferedArea { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        
        public string PhoneNumber { get; set; }
        public string RelativePhoneNumber { get; set; }
        public string Relative { get; set; }

        public string Show { get; set; }
        
        public string Password { get; set; }

        
    }

    



}
