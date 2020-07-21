using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModels
{
    public class ExamViewModel
    {
        public int ClassroomId { get; set; }
        public List<string> SubjectTitles { get; set; }
        //[Range(typeof(DateTime), DateTime.Now.AddDays(14).ToString("dd-MM-yyyy hh:mm"), DateTime.Now.AddYears(1).ToString("dd-MM-yyyy hh:mm"),
        //    ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime ExamDate { get; set; }
        public DateTime ExamEnd { get; set; }

    }
}
