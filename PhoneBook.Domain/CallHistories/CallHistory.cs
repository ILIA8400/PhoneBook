using PhoneBook.Domain.BaseEntities;
using PhoneBook.Domain.Contacts;
using PhoneBook.Domain.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.CallHistories
{
    public class CallHistory : BaseEntity
    {
        public string? PhoneNumber { get; set; }
        public int? ContactId { get; set; }
        public Contact? Contact { get; set; }
        public DateTime CallDateTime { get; set; }
        public string? Note { get; set; }
        public int CallTypeId { get; set; }
        public CallType CallType { get; set; }
        public string UserId { get; set; }
    }
}
