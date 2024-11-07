using PhoneBook.Domain.BaseEntities;
using PhoneBook.Domain.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = PhoneBook.Domain.Groups.Group;
namespace PhoneBook.Domain.Contacts
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber{ get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public ICollection<Group>? Groups { get; set; }
    }
}
