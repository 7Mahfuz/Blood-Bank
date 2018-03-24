using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DonateList
    {
        [Key]
        public int id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Reciever { get; set; }
        public string Disease { get; set; }
        public string Hospital { get; set; }
        public DateTime Date { get; set; }
    }
}
