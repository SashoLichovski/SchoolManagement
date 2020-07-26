using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.ViewModels;
using System;

namespace SchoolManagement.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamService examService;

        public ExamController(IExamService examService)
        {
            this.examService = examService;
        }
        public IActionResult Create(int classroomId)
        {
            ExamViewModel model = new ExamViewModel()
            {
                ClassroomId = classroomId,
                SubjectTitles = examService.GetSubjectTitles(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(int classroomId, string subjectTitle, DateTime examStart, DateTime examEnd, string userId)
        {
            if (examStart == default || examEnd == default)
            {
                return RedirectToAction("ActionMessage", "Dashboard", new { Error = "All input fields are required" });
            }
            ActionMessage response = examService.Create(classroomId, subjectTitle, examStart, examEnd, userId);
            return RedirectToAction("ActionMessage", "Dashboard", response);
        }

        public IActionResult ChangeExamType(string examType, int examId)
        {
            ActionMessage response = examService.UpdateExamType(examType, examId);
            if (string.IsNullOrEmpty(response.Error))
            {
                return RedirectToAction("Overview", "Classroom");
            }
            return RedirectToAction("ActionMessage", "Dashboard", response);
        }
    }
}