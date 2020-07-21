using Microsoft.AspNetCore.Identity;
using SchoolManagement.Models;
using SchoolManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SchoolManagement.Common
{
    public static class ModelConverter
    {
        public static AccountDetailsModel ToDetailsModel(this IdentityUser user)
        {
            return new AccountDetailsModel
            {
                UserId = user.Id,
                Email = user.Email,
                UserName = user.UserName,
            };
        }

        public static SubjectViewModel ToSubjectView(this Subject subject)
        {
            return new SubjectViewModel()
            {
                Id = subject.Id,
                Title=subject.Title,
                PassingScore=subject.PassingScore,
            };
            
        } 

        public static ClassroomViewModel ToClassroomView(this Classroom classroom)
        {
            return new ClassroomViewModel
            {
                Id = classroom.Id,
                RoomNumber = classroom.RoomNumber,
                Capacity = classroom.Capacity,
                Subjects = classroom.Exams.Select(x => x.Subject.ToSubjectView().Title).ToList(),
                Exams = classroom.Exams.Select(x => x.ToExamViewModel()).ToList()
            };
        }

        public static ExamViewModel ToExamViewModel(this Exam exam)
        {
            return new ExamViewModel
            {
                ClassroomId = exam.ClassroomId,
                ExamDate = exam.ExamDate,
                ExamEnd = exam.ExamEnd,
            };
        }
    }
}
