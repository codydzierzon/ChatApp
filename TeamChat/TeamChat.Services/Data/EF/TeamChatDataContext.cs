using Microsoft.EntityFrameworkCore;
using TeamChat.Models.DTO;

namespace NorthwindDemo.Services.Data.EF
{
    public class TeamChatDataContext: DbContext
    {
        public TeamChatDataContext(DbContextOptions<TeamChatDataContext> options) : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<MessageInformation> MessagesInfo { get; set; }
        public DbSet<Messages> Messages { get; set; }
    }
}
