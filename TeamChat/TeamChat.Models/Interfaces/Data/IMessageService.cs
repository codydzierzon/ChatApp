using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamChat.Models.DTO;

namespace TeamChat.Models.Interfaces.Data
{
    public interface IMessageService
    {
        List<Messages> GetById(int id);
        Messages Add(Messages message);
        List<Messages> ConversationMessagesList(int currentId, int partnerId);
    }
}
