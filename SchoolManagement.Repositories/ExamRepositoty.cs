using SchoolManagement.Data;
using SchoolManagement.Repositories.Interfaces;
using System.Linq;

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

        public Exam GetById(int examId)
        {
            return context.Exams.FirstOrDefault(x => x.Id.Equals(examId));
        }

        public void Update(Exam dbExam)
        {
            context.Exams.Update(dbExam);
            context.SaveChanges();
        }
    }
}
