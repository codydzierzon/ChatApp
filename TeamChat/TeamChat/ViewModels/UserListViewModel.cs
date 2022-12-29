using TeamChat.Models.DTO;

namespace TeamChat.ViewModels
{
    public class UserListViewModel
    {
        public List<User> Users { get; set; }
        public List<Messages> Messages { get; set; }

        public bool HasUnreadMessages(int userId)
        {
            var unreadMessages = from m in Messages
                                 where  m.SenderId == userId && m.MessageRead == false
                                 select m;

            return unreadMessages.Any();
        }
    }

    
}
