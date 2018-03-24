using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blood_Bank.Models
{
    public class BloodBankContext: DbContext
    {
        public DbSet<User> User { get; set; }
      
    }
}