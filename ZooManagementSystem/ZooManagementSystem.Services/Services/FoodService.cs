using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZMS.Databases.Data;
using ZMS.Models.EntityModels;

namespace ZMS.Services.Services
{
    public class FoodService
    {
        private readonly ApplicationDbContext _db;
        public FoodService(ApplicationDbContext db)
        {
                _db= db;
        }

        public bool Add(Food entity )
        {
            _db.Foods.Add(entity);
            return _db.SaveChanges() > 0;
        }
        public bool Update(Food entity)
        {
            _db.Foods.Update(entity);
            return _db.SaveChanges() > 0;
        }
        public bool Remove(Food entity)
        {
            _db.Foods.Remove(entity);
            return _db.SaveChanges() > 0;
        }
        public ICollection<Food> GetAll()
        {
            return _db.Foods.ToList();
        }
    }
}
