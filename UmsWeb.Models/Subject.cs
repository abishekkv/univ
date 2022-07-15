using System.ComponentModel.DataAnnotations;
namespace UmsWeb.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="Subject Name")]
        public string Name { get; set; }   
    }
}
