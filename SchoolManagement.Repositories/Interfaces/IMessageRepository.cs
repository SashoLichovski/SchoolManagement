using SchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task Add(Message message);
    }
}
