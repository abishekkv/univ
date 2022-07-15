using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UmsWeb.DataAccess.Repository.IRepository;
using UmsWeb.Models;

namespace UmsWeb.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class SubjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Area("Admin")]
        public IActionResult Index()
        {
            var course = _unitOfWork.Subjects.GetAll();
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
        public IActionResult Create(Models.Subject obj)
        {
            _unitOfWork.Subjects.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Added Successfully";
            return RedirectToAction("Index");
        }
        [Area("Admin")]
        //Get
        public IActionResult Edit(int? id)
        {
            var course = _unitOfWork.Subjects.GetFirstOrDefault(u=>u.Id==id);
            return View(course);
        }
        [Area("Admin")]
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Models.Subject obj)
        {
            _unitOfWork.Subjects.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Updated Successfully";
            return RedirectToAction("Index");
        }
        [Area("Admin")]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Subjects.GetFirstOrDefault(u => u.Id == id);
            _unitOfWork.Subjects.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
        [Area("Admin")]
        #region API CALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var obj = _unitOfWork.Subjects.GetAll();
            return Json(new { data = obj });
        }
        #endregion
    }
}
