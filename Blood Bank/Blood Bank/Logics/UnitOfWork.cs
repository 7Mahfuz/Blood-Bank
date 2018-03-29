
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blood_Bank.Logics
{
    public class UnitOfWork :IDisposable
    {
       

        private BloodBankContext context = null;

        public UnitOfWork()
        {
            context = new BloodBankContext();
        }

        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public _IAllRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as _IAllRepository<T>;
            }
            _IAllRepository<T> repo = new AllRepository<T>(context);
            repositories.Add(typeof(T), repo);
            return repo;
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
    }


//private BloodBankContext context = new BloodBankContext();
// private AllRepository<User> userRepository;

// public AllRepository<User> UserRepository
// {
//     get
//     {

//         if (this.userRepository == null)
//         {
//             this.userRepository = new AllRepository<User>(context);
//         }
//         return userRepository;
//     }
// }