using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZMS.Databases.Data;
using ZMS.Models.EntityModels;

namespace ZMS.Services.Services
{
    public class AnimalService
    {
        private readonly ApplicationDbContext _db;
        public AnimalService(ApplicationDbContext db)
        {
                _db = db;
        }
        public bool Add(Animal entity)
        {
            _db.Animals.Add(entity);
            return _db.SaveChanges() > 0;
        }
        public bool Update(Animal entity)
        {
            _db.Animals.Update(entity);
            return _db.SaveChanges() > 0;
        }
        public bool Remove(Animal entity)
        {
            _db.Animals.Remove(entity);
            return _db.SaveChanges() > 0;
        }

        public ICollection<Animal> GetAll()
        {
            return _db.Animals.ToList();
        }
    }
}
