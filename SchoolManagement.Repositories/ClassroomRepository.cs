using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagement.Repositories
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly SchoolManagementDbContext context;

        public ClassroomRepository(SchoolManagementDbContext context)
        {
            this.context = context;
        }

        public void Add(Classroom newClassroom)
        {
            context.Classrooms.Add(newClassroom);
            context.SaveChanges();
        }

        public Classroom GetById(int classroomId)
        {
            return context.Classrooms
                .Include(x => x.Exams)
                .FirstOrDefault(x => x.Id == classroomId);
        }

        public List<Classroom> GetAll()
        {
            return context.Classrooms
                .Include(x => x.Exams)
                .ThenInclude(x => x.Subject)
                .ToList();
        }

        public Classroom GetByRoomNo(int roomNumber)
        {
            return context.Classrooms.FirstOrDefault(x => x.RoomNumber == roomNumber);
        }
    }
}
