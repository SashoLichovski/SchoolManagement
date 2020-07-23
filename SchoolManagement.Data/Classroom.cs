using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Data
{
    public class Classroom
    {
        public int Id { get; set; }
        [Required]
        public int RoomNumber { get; set; }
        [Required]
        public int Capacity { get; set; }
        public List<Exam> Exams { get; set; }
    }
}
