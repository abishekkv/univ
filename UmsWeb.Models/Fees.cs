using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UmsWeb.Models
{
    public class Fees
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(10000,100000,ErrorMessage ="Range should be in 10000-100000")]
        public int CourseFee { get; set; }

        [Required]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        [ValidateNever]
        public Course Course { get; set; }  
    }
}
