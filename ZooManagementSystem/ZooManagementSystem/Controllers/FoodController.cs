using Microsoft.AspNetCore.Mvc;
using ZMS.Models.EntityModels;
using ZMS.Services.Abstractions;

namespace ZooManagementSystem.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodService _service;
        public FoodController(IFoodService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            ICollection<Food> entityList = _service.Get();
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
        public IActionResult Create(Food entity) 
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
            var entity = _service.GetFirstOrDefault(data => data.Id == id);
            if(entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }
        
        [HttpPost]
        public IActionResult Edit(Food entity)
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
                    checkEntity.Price = entity.Price;
                  
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
            var entity = _service.GetFirstOrDefault(data => data.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        public IActionResult Delete(int?id) 
        {
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
                    //checkEntity.Id = entity.Id;
                    //checkEntity.Name = entity.Name;
                    //checkEntity.Quantity = entity.Quantity;
                    //checkEntity.Origin = entity.Origin;

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
