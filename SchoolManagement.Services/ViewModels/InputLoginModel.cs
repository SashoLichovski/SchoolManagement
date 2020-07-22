using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.ViewModels
{
    public class InputLoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
