using SchoolManagement.Common;
using SchoolManagement.Data;
using SchoolManagement.Repositories.Interfaces;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagement.Services
{
    public class ClassroomService : IClassroomService
    {
        private readonly IClassroomRepository classroomRepository;

        public ClassroomService(IClassroomRepository classroomRepository)
        {
            this.classroomRepository = classroomRepository;
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

        public ClassroomViewModel GetById(int classroomId)
        {
            return classroomRepository.GetById(classroomId).ToClassroomView();
        }
    }
}
