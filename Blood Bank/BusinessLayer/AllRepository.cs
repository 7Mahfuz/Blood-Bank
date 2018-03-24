using Blood_Bank.Models;
using Blood_Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public class AllRepository<T> : _IAllRepository<T> where T:class 
    {
        private BloodBankContext _context = null;
        private IDbSet<T> _DbSet;
        
        public AllRepository(BloodBankContext context)
        {
            _context = context;
            _DbSet = _context.Set<T>();
        }


        public IEnumerable<T> GetList(Func<T, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public T GetModelById(int ModelId)
        {
            throw new NotImplementedException();
        }

        public void InsertModel(T model)
        {
            throw new NotImplementedException();
        }

        public void UpdateModel(T model)
        {
            throw new NotImplementedException();
        }

        public void DeleteModel(T model)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {

        }
    }
}
