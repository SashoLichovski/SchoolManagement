using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SchoolManagement.Models;
using SchoolManagement.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Repositories
{
    public class SubjectRepository: ISubjectRepository
    {
        private readonly SchoolManagementDbContext context;

        public SubjectRepository(SchoolManagementDbContext context )
        {
            this.context = context;
        }

        public void Add(Subject subject)
        {
            context.Subjects.Add(subject);
            context.SaveChanges();
        }

        public bool Get(int id, string title)
        {
            return context.Subjects.Where(x => x.Id != id && x.Title == title).Any();
        }

        public List<Subject> GetAll()
        {
            return context.Subjects.ToList();
        }

        public Subject GetById(int id)
        {
            return context.Subjects.FirstOrDefault(x => x.Id == id);
        }

        public Subject GetByTitle(string title)
        {
            return context.Subjects.FirstOrDefault(x => x.Title == title);
        }

        public void Update(Subject dbSubject)
        {
            context.Subjects.Update(dbSubject);
            context.SaveChanges();
        }
    }
}
