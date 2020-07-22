using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Data
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

        public Enums.ExamType ExamType { get; set; }
        [Required]
        public string CreatedBy { get; set; }
    }
}
