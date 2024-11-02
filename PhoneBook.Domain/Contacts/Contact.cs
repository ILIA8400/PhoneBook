using PhoneBook.Domain.BaseEntities;
using PhoneBook.Domain.Group;
using PhoneBook.Domain.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Contacts
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public long PhoneNumber{ get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public ICollection<ContactGroup>? Groups { get; set; }
    }
}
