using SchoolManagement.Common;
using SchoolManagement.Data;
using SchoolManagement.Repositories.Interfaces;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.Services.ViewModels;
using SchoolManagement.Services.ViewModels.Subject;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagement.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            this.subjectRepository = subjectRepository;
        }

        public ActionMessage Create(SubjectViewModel model)
        {
            var response = new ActionMessage();
            var subject = subjectRepository.GetByTitle(model.Title);
            if (subject == null)
            {
                var newSubject = new Subject()
                {
                    Title = model.Title,
                    PassingScore = model.PassingScore
                };
                subjectRepository.Add(newSubject);
                response.Message = "Subject has been successfully created";
            }
            else
            {
                response.Error = "Create faild! Subject already exists.";
            }
            return response;
        }

        public List<SubjectViewModel> GetAll()
        {
            var subjects = subjectRepository.GetAll();
            var subjectViewList = subjects.Select(x => x.ToSubjectView()).ToList();
            return subjectViewList;
        }

        public SubjectViewModel GetById(int id)
        {
            var dbSubject = subjectRepository.GetById(id);
            return dbSubject.ToSubjectView();
        }

        public ActionMessage Update(SubjectViewModel model)
        {
            var response = new ActionMessage();
            var dbSubject = subjectRepository.GetById(model.Id);
            bool exists = subjectRepository.Get(model.Id, model.Title);
            if (!exists && dbSubject != null)
            {
                dbSubject.PassingScore = model.PassingScore;
                dbSubject.Title = model.Title;
                subjectRepository.Update(dbSubject);
                response.Message = "Subject has been succesfully updated!";
            }
            else
            {
                response.Error = "Update failed!";
            }
            return response;
        }

        public SubjectViewModel GetByTitle(string title)
        {
            var dbSubject = subjectRepository.GetByTitle(title);
            return dbSubject.ToSubjectView();
        }
    }
}
