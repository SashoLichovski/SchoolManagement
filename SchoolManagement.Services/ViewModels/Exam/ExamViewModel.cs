using SchoolManagement.Data;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Services.ViewModels.Exam
{
    public class ExamViewModel
    {
        public int Id { get; set; }
        public int ClassroomId { get; set; }
        public List<string> SubjectTitles { get; set; }
        public DateTime ExamDate { get; set; }
        public DateTime ExamEnd { get; set; }
        public Enums.ExamType ExamType { get; set; }
        public string CreatedBy { get; set; }
    }
}
