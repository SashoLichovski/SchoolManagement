using SchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        void Add(Message message);
    }
}
