using SchoolManagement.Models;

namespace SchoolManagement.Repositories.Interfaces
{
    public interface IExamRepositoty
    {
        void Add(Exam exam);
        Exam GetById(int examId);
        void Update(Exam dbExam);
    }
}
