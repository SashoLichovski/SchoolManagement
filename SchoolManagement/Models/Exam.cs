using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }


        public DateTime ExamDate { get; set; }
        public DateTime ExamEnd { get; set; }
    }
}
