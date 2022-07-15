using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace UmsWeb.Models.ViewModels
{
    public class TeacherVM
    {
        
        public Teacher Instructor { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> DepartmentList {get; set;}
        [ValidateNever]
        public IEnumerable<SelectListItem> CourseList { get; set; }
    }
}
