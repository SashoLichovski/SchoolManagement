using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    public class Exam
    {
        public int Id { get; set; }
        [Required]
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
        [Required]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }


        public DateTime ExamDate { get; set; }
        public DateTime ExamEnd { get; set; }

        public EnumExam ExamType { get; set; }
        [Required]
        public string CreatedBy { get; set; }
    }
}
