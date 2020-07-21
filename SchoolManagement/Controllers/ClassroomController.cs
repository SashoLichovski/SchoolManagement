using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.ViewModels;

namespace SchoolManagement.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly IClassroomService classroomService;

        public ClassroomController(IClassroomService classroomService)
        {
            this.classroomService = classroomService;
        }
        public IActionResult Overview()
        {
            var classrooms = classroomService.GetAll();
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
    }
}
