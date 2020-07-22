using SchoolManagement.Data;
using SchoolManagement.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly SchoolManagementDbContext context;

        public MessageRepository(SchoolManagementDbContext context)
        {
            this.context = context;
        }

        public void Add(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
        }
    }
}
