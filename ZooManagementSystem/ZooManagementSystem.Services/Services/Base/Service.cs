using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZMS.Databases.Data;
using ZMS.Models.EntityModels;
using ZMS.Services.Abstractions.Base;

namespace ZMS.Services.Services.Base
{
    public abstract class Service<T> where T : class
    {
        protected ApplicationDbContext _db;
        public Service(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public bool Add(T entity)
        {
           
            _db.Set<T>().Add(entity);
            return _db.SaveChanges() > 0;
        }
        public bool Update(T entity)
        {
            _db.Set<T>().Update(entity);
            return _db.SaveChanges() > 0;
        }
        public bool Remove(T entity)
        {
            _db.Set<T>().Remove(entity);
            return _db.SaveChanges() > 0;
        }
        public ICollection<T> Get(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return _db.Set<T>().ToList();
            }
            return _db.Set<T>().Where(predicate).ToList();
        }
        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().FirstOrDefault(predicate);
        }
       
        


    }
}
