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


        public string Blood { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string GotBlood { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PostDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BloodNeed { get; set; }

    }
}
