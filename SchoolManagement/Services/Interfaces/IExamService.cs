using SchoolManagement.ViewModels;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Services.Interfaces
{
    public interface IExamService
    {
        List<string> GetSubjectTitles();
        ActionMessage Create(int classroomId, string subjectTitle, DateTime examStart, DateTime examEnd);
    }
}
