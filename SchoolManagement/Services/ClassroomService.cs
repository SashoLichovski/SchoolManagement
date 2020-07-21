using SchoolManagement.Common;
using SchoolManagement.Models;
using SchoolManagement.Repositories.Interfaces;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagement.Services
{
    public class ClassroomService : IClassroomService
    {
        private readonly IClassroomRepository classroomRepository;
        private readonly ISubjectService subjectService;

        public ClassroomService(IClassroomRepository classroomRepository, ISubjectService subjectService)
        {
            this.classroomRepository = classroomRepository;
            this.subjectService = subjectService;
        }

        public ActionMessage CreateExam(int classroomId, string subjectTitle, DateTime start, DateTime end)
        {
            var classroom = classroomRepository.GetById(classroomId);
            ActionMessage response = new ActionMessage();
            var minimumDate = DateTime.Now.AddDays(14);
            if (classroom.Exams.Count > 0)
            {
                bool isValid = classroom.Exams.Where(x => start > x.ExamEnd || end < x.ExamDate).Any();
                if (!isValid)
                {
                    response.Error = "This time is already scheduled. Please check the classroom details";
                    return response;
                }
            }

            if (start < minimumDate)
            {
                response.Error = "Invalid date! Exam must be scheduled 14 days in advance";
            }
            else if (start > end)
            {
                response.Error = "Invalid date! Your end time is before your start time !!!";
            }
            else
            {
                var subjectClassroom = new Exam()
                {
                    ClassroomId = classroomId,
                    SubjectId = subjectService.GetByTitle(subjectTitle).Id,
                    ExamDate = start,
                    ExamEnd = end
                };
                classroomRepository.AddExam(subjectClassroom);
                response.Message = "Exam successfully created";
            }
            
            return response;
        }

        public ActionMessage Create(ClassroomViewModel model)
        {
            var response = new ActionMessage();
            var dbClassroom = classroomRepository.GetByRoomNo(model.RoomNumber);
            if (dbClassroom == null)
            {
                var newClassroom = new Classroom()
                {
                    RoomNumber = model.RoomNumber,
                    Capacity = model.Capacity
                };
                response.Message = "Classroom has been successfully created!";
                classroomRepository.Add(newClassroom);
            }
            else
            {
                response.Error = "Create failed. Room number already exists!";
            }
            return response;
        }

        public List<ClassroomViewModel> GetAll()
        {
            return classroomRepository.GetAll()
                .Select(x => x.ToClassroomView())
                .ToList();
        }
    }
}
