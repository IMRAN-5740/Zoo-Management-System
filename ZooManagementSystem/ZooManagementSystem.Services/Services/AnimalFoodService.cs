using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZMS.Databases.Data;
using ZMS.Models.EntityModels;

namespace ZMS.Services.Services
{
    public class AnimalFoodService
    {
        private readonly ApplicationDbContext _db;
        public AnimalFoodService(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Add(AnimalFood entity)
        {
            _db.AnimalFoods.Add(entity);
            return _db.SaveChanges() > 0;
        }
        public bool Update(AnimalFood entity)
        {
            _db.AnimalFoods.Update(entity);
            return _db.SaveChanges() > 0;
        }
        public bool Remove(AnimalFood entity)
        {
            _db.AnimalFoods.Remove(entity);
            return _db.SaveChanges() > 0;
        }
        public ICollection<AnimalFood> GetAll()
        {
            return _db.AnimalFoods.ToList();
        }

    }
}
