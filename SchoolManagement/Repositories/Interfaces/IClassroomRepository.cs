using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Repositories.Interfaces
{
    public interface IClassroomRepository
    {
        List<Classroom> GetAll();
        Classroom GetByRoomNo(int roomNumber);
        void Add(Classroom newClassroom);
        void AddExam(Exam subjectClassroom);
        Classroom GetById(int classroomId);
    }
}
