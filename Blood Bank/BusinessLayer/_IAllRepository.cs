using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface _IAllRepository<T> where T:class
    {
        IEnumerable<T> GetList(Func<T,bool>predicate=null);
        T GetModelById(int ModelId);

        void InsertModel(T model);
        void UpdateModel(T model);
        void DeleteModel(T model);
        void Save();
        
    }
}
