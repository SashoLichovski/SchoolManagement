using SchoolManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Interfaces
{
    public interface IClassroomService
    {
        List<ClassroomViewModel> GetAll();
        ActionMessage Create(ClassroomViewModel model);
        ActionMessage CreateExam(int classroomId, string subjectTitle, DateTime examDate, DateTime examEnd);
    }
}
