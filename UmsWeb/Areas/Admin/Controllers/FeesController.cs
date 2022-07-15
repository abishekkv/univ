using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UmsWeb.DataAccess.Repository.IRepository;
using UmsWeb.Models;
using UmsWeb.Models.ViewModels;

namespace UmsWeb.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class FeesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public FeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Area("Admin")]
        public IActionResult Index()
        {
            var course = _unitOfWork.Fees.GetAll(includeProperties:"Course");
            return View(course);
        }
        [Area("Admin")]
        public IActionResult Create()
        {
            FeesVM feesVM = new FeesVM();
            feesVM.fee = new UmsWeb.Models.Fees();
            feesVM.courseList = _unitOfWork.CourseRepository.GetAll().Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString()});
            return View(feesVM);
        }
        [Area("Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FeesVM obj)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.Fees.Add(obj.fee);
                _unitOfWork.Save();
                TempData["success"] = "Added Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);   
            
        }
        [Area("Admin")]
        //Get
        public IActionResult Edit(int? id)
        {
            var course = _unitOfWork.Fees.GetFirstOrDefault(u=>u.Id==id,includeProperties:"Course");
            return View(course);
        }
        //Post
        [Area("Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Fees obj)
        {
            _unitOfWork.Fees.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Updated Successfully";
            return RedirectToAction("Index");
        }
        [Area("Admin")]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Fees.GetFirstOrDefault(u => u.Id == id);
            _unitOfWork.Fees.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
        [Authorize] 
        [Area("Admin")]
        #region API CALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var fees = _unitOfWork.Fees.GetAll(includeProperties: "Course");
            return Json(new { data = fees });
        }
        #endregion
    }
}
