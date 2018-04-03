
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;


namespace Blood_Bank.Logics
{
    public class AllRepository<T> : _IAllRepository<T> where T: class //
    {
       private BloodBankContext context;
       private DbSet<T> _DbSet;
        
        public AllRepository(BloodBankContext _context)
        {
            context = _context;
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
            context.Set<T>().AddOrUpdate(model);
           // context.Entry(model).State = System.Data.Entity.EntityState.Modified;
        }

        public void DeleteModel(T model)
        {
            _DbSet.Attach(model);
            _DbSet.Remove(model);
        }

        public int Count(Func<T, bool> predicate = null)
        {

            if (predicate == null)
            {
                int x = _DbSet.Count();
                return x;
            }
            else
            {
                int x = _DbSet.Count(predicate);
                return x;
            }
        }
        

    }
}
