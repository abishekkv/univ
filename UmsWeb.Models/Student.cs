using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UmsWeb.Models
{ 
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Student Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Father's Name")]
        public string FatherName { get; set; }
        [Required]
        [Display(Name = "Mother's Name")]
        public string MotherName { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public int  UserId{ get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public Users User { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int YearOfJoining { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        [ValidateNever]
        public Course Course { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        [ValidateNever]
        public Department Department { get; set; }
        [Required]
       
        [Range(1,9,ErrorMessage ="Range 1-8")]
        public int? Semester { get; set; }
        /*public int? SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        [ValidateNever]
        public Subject Subject { get; set; }
        public string? subject1  { get; set; }
        public string? subject2 { get; set; }
        public string? subject3 { get; set; }
        public string? subject4 { get; set; }
        public string? subject5 { get; set; }*/
        /*public string? subject6 { get; set; }
        public string? subject7 { get; set; }
        public string? subject8 { get; set; }*/







    }
}
