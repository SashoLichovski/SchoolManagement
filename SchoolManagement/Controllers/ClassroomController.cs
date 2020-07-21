using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.ViewModels;

namespace SchoolManagement.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly IClassroomService classroomService;
        private readonly ISubjectService subjectService;

        public ClassroomController(IClassroomService classroomService, ISubjectService subjectService)
        {
            this.classroomService = classroomService;
            this.subjectService = subjectService;
        }
        public IActionResult Overview()
        {
            var classrooms = classroomService.GetAll();
            // Da se prikazat detali za class room ( koi predmeti se zakani i koga )
            return View(classrooms);
        }

        public IActionResult Create()
        {
            var model = new ClassroomViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(ClassroomViewModel model)
        {
            if (ModelState.IsValid)
            {
                ActionMessage response = classroomService.Create(model);
                return RedirectToAction("ActionMessage", "Dashboard", response);
            }
            return View(model);
        }

        public IActionResult CreateExam(int classroomId)
        {
            var model = new ExamViewModel()
            {
                ClassroomId = classroomId,
                SubjectTitles = subjectService.GetAll().Select(x => x.Title).ToList()
        };
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateExam(int classroomId, string subjectTitle, DateTime examDate, DateTime examEnd)
        {
            ActionMessage response = classroomService.CreateExam(classroomId, subjectTitle, examDate, examEnd);
            return RedirectToAction("ActionMessage", "Dashboard", response);
        }
    }
}
