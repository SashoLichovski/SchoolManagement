using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Services.ViewModels.Subject
{
    public class SubjectViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public decimal PassingScore { get; set; }
    }
}
