using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataLayer;

namespace Blood_Bank.Logics
{
    public class BloodBankContext : DbContext
    {
       public DbSet<User> User { get; set; }
        
    }
}
