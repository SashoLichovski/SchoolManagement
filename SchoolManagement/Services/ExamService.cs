﻿using SchoolManagement.Models;
using SchoolManagement.Repositories.Interfaces;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagement.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepositoty examRepositoty;
        private readonly ISubjectService subjectService;
        private readonly IClassroomService classroomService;

        public ExamService(IExamRepositoty examRepositoty, ISubjectService subjectService, IClassroomService classroomService)
        {
            this.examRepositoty = examRepositoty;
            this.subjectService = subjectService;
            this.classroomService = classroomService;
        }

        public ActionMessage Create(int classroomId, string subjectTitle, DateTime examStart, DateTime examEnd)
        {
            ActionMessage response = new ActionMessage();
            ClassroomViewModel model = classroomService.GetById(classroomId);
            if (model.Exams.Count > 0)
            {
                bool isValid = model.Exams.Where(x => examStart > x.ExamEnd || examEnd < x.ExamDate).Any();
                if (!isValid)
                {
                    response.Error = "This time is already scheduled. Please check the classroom details";
                    return response;
                }
            }

            if (examStart < DateTime.Now.AddDays(14))
            {
                response.Error = "Invalid date! Exam must be scheduled 14 days in advance";
            }
            else if (examStart > examEnd)
            {
                response.Error = "Invalid date! Your end time is before your start time !!!";
            }
            else
            {
                Exam exam = new Exam()
                {
                    ClassroomId = classroomId,
                    SubjectId = subjectService.GetByTitle(subjectTitle).Id,
                    ExamDate = examStart,
                    ExamEnd = examEnd,
                };

                examRepositoty.Add(exam);
                response.Message = "Exam successfully created";
            }

            return response;
        }

        public List<string> GetSubjectTitles()
        {
            return subjectService.GetAll().Select(x => x.Title).ToList();
        }
    }
}