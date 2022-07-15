using Microsoft.AspNetCore.Mvc;
using UmsWeb.DataAccess.Repository.IRepository;
using UmsWeb.Models;
using UmsWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace UmsWeb.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Area("Admin")]
        public IActionResult Index()
        {
            var course = _unitOfWork.Students.GetAll(includeProperties:"Course,Department,User");
            return View(course);
        }
        [Area("Admin")]
        public IActionResult Create()
        {
            StudentVM studentVM = new StudentVM();
            studentVM.Student = new Models.Student();
            studentVM.CourseList = _unitOfWork.CourseRepository.GetAll().Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString() });
            studentVM.DepartmentList = _unitOfWork.Department.GetAll().Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString() });
            return View(studentVM);
        }
        [Area("Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentVM obj)
        { 
            if (ModelState.IsValid)
            {
                _unitOfWork.Students.Add(obj.Student);
                _unitOfWork.Save();
                TempData["success"] = "Added Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //Get
        [Area("Admin")]
        public IActionResult Edit(int? id)
        {
            var course = _unitOfWork.Students.GetFirstOrDefault(u=>u.Id==id,includeProperties:"Course,Department,User");
            return View(course);
        }
        [Area("Admin")]
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Models.Student obj)
        {
            if (ModelState.IsValid)
            {
                /*var data = _unitOfWork.Students.GetFirstOrDefault(i => i.Id == obj.Id);*/
                _unitOfWork.Students.Update(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Edited Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [Area("Admin")]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Students.GetFirstOrDefault(u => u.Id == id);
            if (obj != null)
            {
                _unitOfWork.Students.Remove(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Edited Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [Area("Admin")]
        #region API CALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var obj = _unitOfWork.Students.GetAll(includeProperties:"Course,Department,User");
            return Json(new { data = obj });
        }
        #endregion
    }
}
