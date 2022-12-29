using NorthwindDemo.Services.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamChat.Models.DTO;
using TeamChat.Models.Interfaces.Data;

namespace TeamChat.Services.Data
{
    public class EFMessages : IMessageService
    {
        private TeamChatDataContext db;

        public EFMessages(TeamChatDataContext db)
        {
            this.db = db;
        }
        public List<Messages> GetById(int id)
        {
            var messages = from m in db.Messages
                           where m.ReceiverId == id
                           select m;

            return messages.ToList();
        }
        public Messages Add(Messages message)
        {
            db.Messages.Add(message);
            db.SaveChanges();
            return message;
        }

        public List<Messages> ConversationMessagesList(int currentId, int partnerId)
        {
            var messages = from m in db.Messages
                where( m.ReceiverId == currentId && m.SenderId == partnerId) || (m.SenderId == currentId && m.ReceiverId == partnerId)
                select m;

            return messages.ToList();
        }
    }
}
