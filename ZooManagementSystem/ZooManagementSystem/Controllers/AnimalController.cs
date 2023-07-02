using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ZMS.Models.EntityModels;
using ZMS.Services.Abstractions;
using ZMS.Services.Services.Base;

namespace ZooManagementSystem.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalService _service;
        public AnimalController(IAnimalService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            ICollection<Animal> entityList = _service.Get();
            if(entityList.Any())
            {
                return View(entityList);
            }

            return View();
        }


        public IActionResult Create() 
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Animal entity) 
        {
            if(ModelState.IsValid)
            {
                bool isSaved=_service.Add(entity);
                if(isSaved)
                {
                    return RedirectToAction("Index");
                }
               
            }
            return View(entity);
            
        }

        public IActionResult Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var entity = _service.GetFirstOrDefault(data => data.Id == id);
            if(entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }
        
        [HttpPost]
        public IActionResult Edit(Animal entity)
        {
            if (ModelState.IsValid)
            {
                var checkEntity = _service.GetFirstOrDefault(data => data.Id == entity.Id);
                if (checkEntity == null)
                {
                    return NotFound();
                }
                else
                {
                    checkEntity.Id = entity.Id;
                    checkEntity.Name = entity.Name; 
                   checkEntity.Quantity= entity.Quantity;
                    checkEntity.Origin = entity.Origin;
                   
                    bool isSaved = _service.Update(checkEntity);
                    if (isSaved)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(entity);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _service.GetFirstOrDefault(data => data.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        public IActionResult Delete(int?id) 
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _service.GetFirstOrDefault(data => data.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }
        [HttpPost]
        public IActionResult Delete(Animal entity) 
         {
            if (ModelState.IsValid)
            {
                var checkEntity = _service.GetFirstOrDefault(data => data.Id == entity.Id);
                if (checkEntity == null)
                {
                    return NotFound();
                }
                else
                {
                    bool isSaved = _service.Remove(checkEntity);
                    if (isSaved)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(entity);
           
         }



    }

}
