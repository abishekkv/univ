using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UmsWeb.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public double Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public DateTime DOJ { get; set; }
        [Required]
        public int CourseId {get; set;}
        [ForeignKey("CourseId")]
        [ValidateNever]
        public Course Course { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        [ValidateNever]
        public Department Department { get; set; }

    }
}
