using PhoneBook.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Group
{
    public class ContactGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
