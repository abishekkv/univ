using System.ComponentModel.DataAnnotations;

namespace UmsWeb.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [Display(Name="Course Name")]
        public string Name { get; set; }    
    }
}
