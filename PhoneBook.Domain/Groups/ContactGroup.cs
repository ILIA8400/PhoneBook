using PhoneBook.Domain.BaseEntities;
using PhoneBook.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Groups
{
    public class ContactGroup : BaseEntity
    {
        public string GroupName { get; set; }
        public List<Contact> Contacts { get; set; }
        public string UserId { get; set; }
    }
}
