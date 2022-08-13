using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        //Get   
        public IActionResult Upsert(int? id)
        {
            Company company = new();
            if (id == null || id == 0)
            {
                return View(company);
            }
            else
            {
                company=unitOfWork.Company.GetFirstOrDefault(u=>u.Id == id);
                return View(company);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company obj)
        {
            if (ModelState.IsValid)
            {
               
                if(obj.Id==0)
                {
                    unitOfWork.Company.Add(obj);
                    TempData["Success"] = "Company created successfuly";
                }
                else
                {
                    unitOfWork.Company.Update(obj);
                    TempData["Success"] = "Company updated successfuly";
                }
                
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var companyList = unitOfWork.Company.GetAll();
            return Json(new { data = companyList });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = unitOfWork.Company.GetFirstOrDefault(u=>u.Id==id);
            if(obj == null)
            {
                return Json(new {success = false, message = "Error while deleting"});
            }
            
            unitOfWork.Company.Remove(obj);
            unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successfull" });

        }
        #endregion
    }

}
