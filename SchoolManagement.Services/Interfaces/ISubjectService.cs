using SchoolManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
