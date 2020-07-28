using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Data
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        public byte[] UserImage { get; set; }
        [Required]
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
