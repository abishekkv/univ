using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UmsWeb.Models.ViewModels
{
    public class FeesVM
    {
        public Fees fee { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> courseList { get; set; }
    }
}
