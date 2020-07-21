using System;
using System.Collections.Generic;

namespace SchoolManagement.ViewModels
{
    public class ExamViewModel
    {
        public int ClassroomId { get; set; }
        public List<string> SubjectTitles { get; set; }
        public DateTime ExamDate { get; set; }
        public DateTime ExamEnd { get; set; }
    }
}
