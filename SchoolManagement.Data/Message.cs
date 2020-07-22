using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolManagement.Data
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
