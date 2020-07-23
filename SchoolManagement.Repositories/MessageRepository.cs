using SchoolManagement.Data;
using SchoolManagement.Repositories.Interfaces;
using System.Threading.Tasks;

namespace SchoolManagement.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly SchoolManagementDbContext context;

        public MessageRepository(SchoolManagementDbContext context)
        {
            this.context = context;
        }

        public async Task Add(Message message)
        {
            context.Messages.Add(message);
            await context.SaveChangesAsync();
        }
    }
}
