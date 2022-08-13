using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork= unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = unitOfWork.Category.GetAll();
            return View(objCategoryList);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display Order can not exactly match the Name.");
            }    
            if(ModelState.IsValid)
            {
                TempData["Success"] = "Category created successfuly";
                unitOfWork.Category.Add(obj);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
           return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            //var categoryFromDb = db.Categories.Find(id);
            var categoryFromDbFirst= unitOfWork.Category.GetFirstOrDefault(x=>x.Id == id);
            if(categoryFromDbFirst==null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display Order can not exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                TempData["Success"] = "Category updated successfuly";
                unitOfWork.Category.Update(obj);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDbFirst = unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
            TempData["Success"] = "Category deleted successfuly";
            unitOfWork.Category.Remove(obj);
                unitOfWork.Save();
                return RedirectToAction("Index");

        }
    }
}
