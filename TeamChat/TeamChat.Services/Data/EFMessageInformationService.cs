using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindDemo.Services.Data.EF;
using TeamChat.Models.DTO;
using TeamChat.Models.Interfaces.Data;

namespace TeamChat.Services.Data
{
    public class EFMessageInformationService : IMessageInformationService
    {
        private TeamChatDataContext db;

        public List<MessageInformation> GetAll()
        {
            return db.MessagesInfo.ToList();
        }

        public List<MessageInformation> GetById(int id)
        {
            var messages = from u in db.MessagesInfo
                where u.UserId == id
                select u;

            return messages.ToList();
        }

        public void MarkAsRead(int userId, Messages messages)
        {

        }
    }
}
