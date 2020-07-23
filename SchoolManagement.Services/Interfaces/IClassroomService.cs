using SchoolManagement.ViewModels;
using System.Collections.Generic;

namespace SchoolManagement.Services.Interfaces
{
    public interface IClassroomService
    {
        List<ClassroomViewModel> GetAll();
        ActionMessage Create(ClassroomViewModel model);
        ClassroomViewModel GetById(int classroomId);
    }
}
