using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UmsWeb.DataAccess;
using UmsWeb.DataAccess.Repository.IRepository;
using UmsWeb.Models;
using UmsWeb.Models.ViewModels;

namespace UmsWeb.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class TeacherController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public TeacherController(IUnitOfWork db)
        {
            unitOfWork = db;
        }
        [Area("Admin")]
        public IActionResult Index()
        {
            var obj = unitOfWork.Teachers.GetAll(includeProperties:"Course,Department");
            return View(obj);
        }
        [Area("Admin")]
        public IActionResult Create()
        {
            TeacherVM teacherVM = new TeacherVM();
            teacherVM.Instructor = new Teacher();
            teacherVM.CourseList = unitOfWork.CourseRepository.GetAll().Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString() });
            teacherVM.DepartmentList = unitOfWork.Department.GetAll().Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString() });
            return View(teacherVM);
        }
        [Area("Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TeacherVM obj)
        {
            if(ModelState.IsValid)
            {
                unitOfWork.Teachers.Add(obj.Instructor);
                unitOfWork.Save();
                TempData["success"] = "Added Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [Area("Admin")]
        public IActionResult Edit(int? id)
        {
            var obj = unitOfWork.Teachers.GetFirstOrDefault(u => u.Id == id, includeProperties:"Course,Department");
            return View(obj);
        }
        [Area("Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Teacher obj)
        {
            if(ModelState.IsValid)
            {
                var data = unitOfWork.Teachers.GetFirstOrDefault(i => i.Id == obj.Id);
                unitOfWork.Teachers.Update(obj);
                unitOfWork.Save();
                TempData["Success"] = "Edited Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [Area("Admin")]
        public IActionResult Delete(int? id)
        {
            var obj = unitOfWork.Teachers.GetFirstOrDefault(u => u.Id == id);
            if (obj != null)
            {
                unitOfWork.Teachers.Remove(obj);
                unitOfWork.Save();
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
            var obj = unitOfWork.Teachers.GetAll(includeProperties:"Course,Department");
            return Json(new {data=obj});
        }
        #endregion
    }
}

