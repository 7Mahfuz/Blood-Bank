﻿using System;
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

        [Display(Name = "Patient/Reciever")]
        public string Reciever { get; set; }
        public string Disease { get; set; }
        public string Hospital { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}
