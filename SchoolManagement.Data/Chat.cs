using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolManagement.Data
{
    public class Chat
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Enums.ChatType ChatType { get; set; }
        public List<Message> Messages { get; set; }
    }
}
