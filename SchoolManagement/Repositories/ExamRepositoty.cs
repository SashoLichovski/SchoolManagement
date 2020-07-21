using SchoolManagement.Models;
using SchoolManagement.Repositories.Interfaces;

namespace SchoolManagement.Repositories
{
    public class ExamRepositoty : IExamRepositoty
    {
        private readonly SchoolManagementDbContext context;

        public ExamRepositoty(SchoolManagementDbContext context)
        {
            this.context = context;
        }

        public void Add(Exam exam)
        {
            context.Exams.Add(exam);
            context.SaveChanges();
        }
    }
}
