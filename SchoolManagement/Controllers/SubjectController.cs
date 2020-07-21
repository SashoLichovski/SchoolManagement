using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.ViewModels;

namespace SchoolManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SubjectController : Controller
    {
        private readonly ISubjectService subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }
        public IActionResult Overview()
        {
            var subjects = subjectService.GetAll();
            return View(subjects);
        }

        public IActionResult Create()
        {
            var newSubject = new SubjectViewModel();
            return View(newSubject); 
        }
        [HttpPost]
        public IActionResult Create(SubjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = subjectService.Create(model);
                return RedirectToAction("ActionMessage", "Dashboard", response);
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var subject = subjectService.GetById(id);
            return View(subject);
        }
        [HttpPost]
        public IActionResult Edit(SubjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                ActionMessage response = subjectService.Update(model);
                return RedirectToAction("ActionMessage", "Dashboard", response);
            }
            return View(model);
        }
    }
}