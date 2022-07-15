
using System.ComponentModel.DataAnnotations;

namespace UmsWeb.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Department")]
        public string Name { get; set; }
    }
}
