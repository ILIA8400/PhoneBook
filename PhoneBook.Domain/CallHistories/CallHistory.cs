using PhoneBook.Domain.Contacts;
using PhoneBook.Domain.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.CallHistories
{
    public class CallHistory
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        public DateTime CallDateTime { get; set; }
        public int CallTypeId { get; set; }
        public CallType CallType { get; set; }
    }
}
