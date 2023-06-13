using System.ComponentModel.DataAnnotations;

namespace APIStartCourseApp.Models
{
    public class Group
    {
        public int Id { get; set; }
        [Required]
        public string No { get; set; }
    }
}
