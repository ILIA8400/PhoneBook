using PhoneBook.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactDomain = PhoneBook.Domain.Contacts.Contact;

namespace PhoneBook.Application.DTOs.Group
{
    public class IGroupDto
    {
        public string GroupName { get; set; }
    }
}
