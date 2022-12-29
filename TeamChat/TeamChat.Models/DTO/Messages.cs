using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TeamChat.Models.DTO
{
    public class Messages
    {
        [Key]
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public bool MessageRead { get; set; }
        public string Message { get; set; }
        public DateTime DateSend { get; set; }
        public TimeSpan TimeSend { get; set; }
    }
}
