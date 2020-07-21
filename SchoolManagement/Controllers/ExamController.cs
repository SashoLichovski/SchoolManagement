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
        public IActionResult Create(int classroomId, string subjectTitle, DateTime examStart, DateTime examEnd)
        {
            ActionMessage response = examService.Create(classroomId, subjectTitle, examStart, examEnd);
            return RedirectToAction("ActionMessage", "Dashboard", response);
        }
    }
}
