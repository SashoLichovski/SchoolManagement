using SchoolManagement.Models;
using System.Collections.Generic;

namespace SchoolManagement.Repositories.Interfaces
{
    public interface IClassroomRepository
    {
        List<Classroom> GetAll();
        Classroom GetByRoomNo(int roomNumber);
        void Add(Classroom newClassroom);
        Classroom GetById(int classroomId);
    }
}
