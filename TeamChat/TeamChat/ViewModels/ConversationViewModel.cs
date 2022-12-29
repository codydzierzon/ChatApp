using TeamChat.Models.DTO;

namespace TeamChat.ViewModels
{
    public class ConversationViewModel
    {

        public List<Messages> Messages { get; set; }
        public User OtherUser { get; set; }
        public User Me { get; set; }
    }
}
