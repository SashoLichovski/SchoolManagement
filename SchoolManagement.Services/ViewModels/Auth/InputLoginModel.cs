using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Services.ViewModels.Auth
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
