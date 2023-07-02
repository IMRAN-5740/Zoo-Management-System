using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZMS.Models.EntityModels;
using ZMS.Services.Abstractions;
using static System.Net.Mime.MediaTypeNames;

namespace ZooManagementSystem.Controllers
{
    public class AnimalFoodController : Controller
    {
        private readonly IAnimalFoodService _service;
        private readonly IAnimalService _animalService;
        private readonly IFoodService _foodService;


        public AnimalFoodController(IAnimalFoodService service,IAnimalService animalService,IFoodService foodService)
        {
            _service = service;
            _animalService = animalService;
            _foodService = foodService;
        }
        public IActionResult Index()
        {

            var entityList=_service.GetAllResult();
            if(entityList.Any())
            {
                return View(entityList);
            }
            return View();
        }
        public IActionResult Create() {
            var animals = _animalService.Get();
            var animalSelectListItems = animals.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();

            var animalFoodVM = new AnimalFood();
            animalFoodVM.ListAnimal = animalSelectListItems;

            var foods = _foodService.Get();
            var foodSelectListItems = foods.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();

            animalFoodVM.ListFood = foodSelectListItems;
            return View(animalFoodVM);
        }
        [HttpPost]
        public IActionResult Create(AnimalFood entity)
        {
            bool result = _service.Add(entity);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            
            return View(entity);
        }





        [HttpGet]
        public IActionResult Edit(int id)
        {
            var existingEntity = _service.GetFirstOrDefault(data => data.Id == id);

            //var author = new AuthorEditVM()
            //{
            //    Id = existingAuthor.Id,
            //    AuthorName = existingAuthor.AuthorName,
            //    Description = existingAuthor.Description
            //};
            var val = existingEntity.AnimalId;
            var val2 = existingEntity.FoodId;
            var animals = _animalService.GetFirstOrDefault(c => c.Id == val);
            //var categoriesSelectListItems = categories.Select(c => new SelectListItem()
            //{
            //    Text = c.Id + " " + c.CategoryName,
            //    Value = c.Id.ToString()
            //}).ToList();


            //existingEntity.Categories = categoriesSelectListItems;

            var foods = _foodService.GetFirstOrDefault(c => c.Id == val2);
            //var authorSelectListItems = authors.Select(c => new SelectListItem()
            //{
            //    Text = c.Id + " " + c.AuthorName,
            //    Value = c.Id.ToString()
            //}).ToList();

            //bookCreateVM.Authors = authorSelectListItems;
            existingEntity.Animal = animals;
            existingEntity.Food = foods;
            
            existingEntity.FoodId = val2;
            existingEntity.AnimalId = val;
            return View(existingEntity);
        }
        [HttpPost]
        public IActionResult Edit(AnimalFood entity)
        {

            var existingEntity = _service.GetFirstOrDefault(x => x.Id == entity.Id);
            if (existingEntity == null)
            {
                ViewBag.Message = "Requested Page Not Found";
                return View("_NotFound");
            }
            existingEntity.Id = entity.Id;  
            existingEntity.FoodId= entity.FoodId;
            existingEntity.AnimalId= entity.AnimalId;
            existingEntity.Quantity= entity.Quantity;
            existingEntity.Animal.Name = entity.Animal.Name;
            existingEntity.Food.Name = entity.Food.Name;


            bool result = _service.Update(existingEntity);
            if (result)
            {
                ModelState.Clear();
                return RedirectToAction(nameof(Index));
            }
            
            return View();
        }

       

        [HttpGet]
        public IActionResult Details(int id)
        {
            var existingEntity = _service.GetFirstOrDefault(data => data.Id == id);

            //var author = new AuthorEditVM()
            //{
            //    Id = existingAuthor.Id,
            //    AuthorName = existingAuthor.AuthorName,
            //    Description = existingAuthor.Description
            //};
            var val = existingEntity.AnimalId;
            var val2 = existingEntity.FoodId;
            var animals = _animalService.GetFirstOrDefault(c => c.Id == val);


            var foods = _foodService.GetFirstOrDefault(c => c.Id == val2);

            existingEntity.Animal = animals;
            existingEntity.Food = foods;
           
            return View(existingEntity);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var existingEntity = _service.GetFirstOrDefault(data => data.Id == id);

            //var author = new AuthorEditVM()
            //{
            //    Id = existingAuthor.Id,
            //    AuthorName = existingAuthor.AuthorName,
            //    Description = existingAuthor.Description
            //};
            var val = existingEntity.AnimalId;
            var val2 = existingEntity.FoodId;
            var animals = _animalService.GetFirstOrDefault(c => c.Id == val);


            var foods = _foodService.GetFirstOrDefault(c => c.Id == val2);

            existingEntity.Animal = animals;
            existingEntity.Food = foods;

            return View(existingEntity);
        }
        [HttpPost]
        public IActionResult Delete(AnimalFood entity ,int?id)
        {
            //if(ModelState.IsValid)
            //{

            if (id == null)
            {
                ViewBag.Message = "No Data Found";
                return View("_NotFound");
            }
            if (id != entity.Id)
            {
                ViewBag.Message = "No Data Found";
                return View("_NotFound");
            }
            var existingEntity = _service.GetFirstOrDefault(data => data.Id == entity.Id);
            if (existingEntity == null)
            {
                ViewBag.Message = "No Data Found";
                return View("_NotFound");
            }
            
            bool result = _service.Remove(existingEntity);
            if (result)
            {
                ModelState.Clear();
                return RedirectToAction(nameof(Index));
            }
          

            //}
            return View(entity);
        }
        
    }
}
    }
}
