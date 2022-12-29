using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamChat.Models.DTO
{
    public class MessageInformation
    {
        [Key]
        public string Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public bool MessageRead { get; set; }
        public string Message { get; set; }
        public DateTime DateSend { get; set; }
        public DateTime TimeSend { get; set; }
        public string MessageType { get; set; }
    }
}
