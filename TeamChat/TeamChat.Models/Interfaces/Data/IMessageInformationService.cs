using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamChat.Models.DTO;

namespace TeamChat.Models.Interfaces.Data
{
    public interface IMessageInformationService
    {
        List<MessageInformation> GetAll();
        List<MessageInformation> GetById(int id);
        void MarkAsRead(int userId, Messages messages);
    }
}
