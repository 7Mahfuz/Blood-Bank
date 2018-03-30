
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;


namespace Blood_Bank.Logics
{
    public class AllRepository<T> : _IAllRepository<T> where T: class //
    {
       internal BloodBankContext _context;
       internal DbSet<T> _DbSet;
        
        public AllRepository(BloodBankContext context)
        {
            this._context = context;
            this._DbSet = _context.Set<T>();
        }


        public IEnumerable<T> GetList(Func<T, bool> predicate = null)
        {
            if (predicate != null)
            {
                return _DbSet.Where(predicate);
            }
            else return _DbSet.AsEnumerable();
        }

        public T GetModelById(int ModelId)
        {
            return _DbSet.Find(ModelId);
        }
        public T GetModel(Func<T, bool> predicate = null)
        {

            return _DbSet.FirstOrDefault(predicate);
        }
        public void InsertModel(T model)
        {
            _DbSet.Add(model);
           
           
        }

        public void UpdateModel(T model)
        {
            _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
        }

        public void DeleteModel(T model)
        {
            _DbSet.Remove(model);
        }

        public int Count(Func<T, bool> predicate = null)
        {
            int x = _DbSet.Count(predicate);
            return x;
        }
        

    }
}
