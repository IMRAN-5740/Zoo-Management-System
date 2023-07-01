using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ZMS.Services.Abstractions.Base
{
    
        public interface IService<T> where T : class
        {
            ICollection<T> Get(Expression<Func<T, bool>> predicate = null);
            T GetFirstOrDefault(Expression<Func<T, bool>> predicate);

            bool Add(T entity);
            bool Update(T entity);
            bool Remove(T entity);
        }
    
}
