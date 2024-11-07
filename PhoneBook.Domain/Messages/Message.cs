using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Domain.BaseEntities;

namespace PhoneBook.Domain.Messages
{
    public class Message : BaseEntity
    {
        public string Text { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime SendTime { get; set; }
    }
}
