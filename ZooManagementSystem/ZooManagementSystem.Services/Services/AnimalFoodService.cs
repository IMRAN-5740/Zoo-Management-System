using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZMS.Databases.Data;
using ZMS.Models.EntityModels;
using ZMS.Services.Abstractions;
using ZMS.Services.Services.Base;

namespace ZMS.Services.Services
{
    public class AnimalFoodService : Service<AnimalFood>,IAnimalFoodService
    {
        public AnimalFoodService(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public ICollection<AnimalFood> Get(Expression<Func<AnimalFood, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return _db.Set<AnimalFood>().ToList();
            }
            return _db.Set<AnimalFood>().Where(predicate).ToList();
        }

        public ICollection<AnimalFood> GetAllResult(Expression<Func<AnimalFood, bool>> predicate = null)
        {
             if (predicate == null)
                {
                    return (ICollection<AnimalFood>)_db.Set<AnimalFood>().Include(c => c.Animal).Include(data => data.Food).ToList();
                }
                return _db.Set<AnimalFood>().Where(predicate).ToList();
           
        }
    }
}
