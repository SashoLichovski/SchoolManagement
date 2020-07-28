using SchoolManagement.Services.ViewModels;
using SchoolManagement.Services.ViewModels.Subject;
using System.Collections.Generic;

namespace SchoolManagement.Services.Interfaces
{
    public interface ISubjectService
    {
        List<SubjectViewModel> GetAll();
        ActionMessage Create(SubjectViewModel model);
        SubjectViewModel GetById(int id);
        ActionMessage Update(SubjectViewModel model);
        SubjectViewModel GetByTitle(string title);
    }
}
