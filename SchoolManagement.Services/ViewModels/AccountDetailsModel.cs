using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.ViewModels
{
    public class AccountDetailsModel
    {
        public string UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        public byte[] UserImage { get; set; }
    }
}
