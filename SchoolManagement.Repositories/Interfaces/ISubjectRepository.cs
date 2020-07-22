using SchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Repositories.Interfaces
{
    public interface ISubjectRepository
    {
        List<Subject> GetAll();
        Subject GetByTitle(string title);
        void Add(Subject subject);
        Subject GetById(int id);
        void Update(Subject dbSubject);
        bool Get(int id, string title);
    }
}
