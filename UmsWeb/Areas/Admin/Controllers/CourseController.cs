using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UmsWeb.DataAccess.Repository.IRepository;
using UmsWeb.Models;

namespace UmsWeb.Areas.Admin.Controllers
{
    [Authorize(Roles ="admin")]
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Area("Admin")]
        public IActionResult Index()
        {
            var course = _unitOfWork.CourseRepository.GetAll();
            return View(course);
        }
        [Area("Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [Area("Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course obj)
        {
            _unitOfWork.CourseRepository.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Added Successfully";
            return RedirectToAction("Index");
        }
        [Area("Admin")]
        //Get
        public IActionResult Edit(int? id)
        {
            var course = _unitOfWork.CourseRepository.GetFirstOrDefault(u=>u.Id==id);
            return View(course);
        }
        [Area("Admin")]
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course obj)
        {
            _unitOfWork.CourseRepository.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Updated Successfully";
            return RedirectToAction("Index");
        }
        [Area("Admin")]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.CourseRepository.GetFirstOrDefault(u => u.Id == id);
            _unitOfWork.CourseRepository.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
        [Area("Admin")]
        #region API CALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var obj = _unitOfWork.CourseRepository.GetAll();
            return Json(new { data = obj });
        }
        #endregion
    }
}
