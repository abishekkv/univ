using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UmsWeb.Models.ViewModels
{
    public class StudentVM
    {
        public Student Student { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CourseList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
        /*[ValidateNever]
        public IEnumerable<SelectListItem> SubjectList { get; set; }*/
    }
}
